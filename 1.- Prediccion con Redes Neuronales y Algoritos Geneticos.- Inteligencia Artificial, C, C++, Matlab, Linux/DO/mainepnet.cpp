
/* EPNet in C++
 * Author: 			Carlos Torres and Victor Landassuri 
 * Modified at: 	26 Feb 2012
 * Compile:
 * g++ -O -lm -o mainepnet mainepnet.cpp
 *
 * Input arguments
 * ./mainepnet r1 > res/r1S.txt
 * r1 						is the name of the independent run, r1, r2, ..., r30. you can pass as much as you want
 * > res/r1S.txt 		is only used to save the output of the program, mainly for debugging
 *
 * What you can do
 *
 * Prediction (SSP and MSP) or classification, any number of inputs, hidden nodes and output nodes
 *
 * Train multiple tasks for a single networks (during evolution) or a single network for testnetwork file
 *
 * Files:
 * mainepenet.hpp  	contain the general configuration to run
 * txtFiles/config.hpp 	contain specific experiment parameters to configure, e.g. SSP, MSP, Prediction, classification, data used, etc.
 * txtFiles/datainput	Patterns to predict/classify - The problem to solve, containing all the data, training, validation and test set
 *
 * For modular neural networks
 * txtFiles/nameModules 						give the name of each module (natural number)
 * txtFiles/numberInputsANDClasses		how many inputs and outputs
 * txtFiles/outputsInMod							how many outputs per module indicating the name of the module in each output
 * txtFiles/outputsPerMod						the number of output per module
 * txtFiles/TSname								 	name of the TS or data set
 * txtFiles/typeDS 									for classification, determinate how is perform the error measure, winner takes all or other variation
 * 																see Readme file in txtFiles/
 *
 * 	Output files
 * 	res/
 * 		config.txt											General variables for configuration of the experiment
 * 		r1AllNum.txt 									first independent run
 * 		r2xxxxxx.txt									second independent run
 * 		rnxxxxxx.txt 									n-esima independent run
 * resPop/ 												Each independent network of the last population, is specified
 *
 * 	/// after running the C code, run the m file ../RecuperateInfoAllRunsAllTS.m
 * 	TS.mat 												must contain the name (columns) of experiments ran, e.g. lorenz, logistic, ... in a row (horizontal)
 * 																this name is the same as the folder in the same path
 *
 * Outputs after running the matlab code
 * res/allrun.mat										all the information from all independent runs, organised and ready to analyse
 * figs/ 														some figures from different aspects are plotted here, Matlab format
 * figs_av, figs_STD, figs_STE 					other figures with the average, standard deviation (error bars) and standard error are plotted in each directory
 *
 * To use the t-test run /epnetFunsMatlab/ttest_fun_scirp/analyse2exp_ttest_and_AvValues_ALL.m   or other file from this directory
 *
 */


// include all libraries and some initial parameters
#include "mainepnet.hpp"


int main(int argc, char *argv[])
{


	//try{
		// local var //////////////////////////////
		// char filetemp[BUFSIZ];
		char ext[]=".txt";

		if(MYDEBUG_MAIN == 1) 		cout << "Start EPNet algorithm" << endl;

		//////////////////////////////////////////////////////////////////////////////////
		//////////////////// INITIZLIZATION /////////////////////////////////////////////

		// empty class used in all the program
		//emptyNet = (C_network *) new C_network;

		// Check that the required directories exist
		checkDir();

		// set the path of the directories, where teh files are
		//setPathDirectories();

		// Check if modules will be reused, way 1 saving networks and loading them
		if ( reuseModule == ON ){
			loadNets2continueEvo = ON; 					// activate this flag to continue evolution
			restartWeight_afterEvolution = OFF;
		}


		// Now obtain the name of the TS
		NAMETS = loadNameTS();

		// Initialize the random number generator
		seedRand = (unsigned int) time(NULL);				// uncoment this line to run the code
		//seedRand = (1309244048); 										// coment this line to run the code
		srand (seedRand);
		//rv.reset( seedRand );
		cout << "seed used = " << seedRand << endl;

		// Init Clock
		startTime = clock();

		// Check there are more than one input parameters
		arguments(argc);

		// Dual weights
		if ( isDualWeights == ON){
			if ( task2solve == CLASSIFY)								// for prediciton it is the same name
				INPUTF.assign("txtFiles/dataInputNDW");
		}
		// Setup the lines and cols from the datainput (filecol, filelines)
		SetSizeDatainput();

		// copy the run to the global var
		isRun = argv[1];


		if ( fitness_learnQuick2Genaralize == ON){
			// update the number of lines required because it does not matter the data input to read (in terms of lines)
			// in theory it should be trainingData + ValInside + TestInside + ValOutside + TestOutside, but as this function is used for classification only and because validation set are the same as test set here
			// it will not be taken the validation set
			// in this moment it will be used 400, they are modify here, so you do not to change the conf.txt file
			Pred_stepAhead = patters_learnQuick2Gen;
			Pred_stepAheadInside = patters_learnQuick2Gen;
			sizeVali = patters_learnQuick2Gen;
			fileline = Pred_stepAhead + Pred_stepAhead + Pred_stepAhead + Pred_stepAhead;  // all must have the same value train, test inside and final test

			// Use baldwing evolution in this case
			//baldwin = ON;

		}


		// If if is classification, then modify the columns of the file
		 if ( task2solve == CLASSIFY){
			 FILECOL = filecol;
			 filecol = 1;

			 // set up other variables that are important
			 Pred_stepAheadInside = sizeVali;

			  //maxdata = fileline;						// IN THIS MOMENT IS USED THE NUMBER OF PATTERS SPECIFIED IN THE CONF.HPP FILE
		 }
		 else{ 							// update the range to update the lrate for evolution of it per node for prediction tasks
			 lrateModRange[0] = -0.02; //min
			 lrateModRange[1] = 0.02; // max
		 }

		// I have not check the enmseble for memory leack with valgrind
		if(RUN_ENSEMBLE == 1)     	RunEnsemble = 1;

		sizetpos = sizeof(targetPos)/sizeof(targetPos[0]);  // here it is determinated how many outputs in the network there are

		// replace to the new number the outputs
		noOutputs = sizetpos;

		//Check for an error in the number of inputs (file) and outputs (network)
		 if ( task2solve == PREDICT)
			 correctInputOutput(noOutputs, filecol);
		//--------------------------------------------------------------------


		 // set up values for number of modules, ouptuts per module and number of output per module
		 if ( isModule1 == ON )
			 obtainModuleInfo();


		 // check the epochs inside and outside
		 if ( epochsK[1] < epochsK[0] ){
			 epochsK[1] = epochsK[0] + 1;
			 cout << "W A R N I N G  . . .  epoch[1] < epochsK[0]. Value updated... " << endl;
		 }





		//////////////// After know the size of the previous variables ////////////////////
		//Create the main structure containing all
		C_EPNet *EPNet;
		//EPNet = new C_EPNet;
		//EPNet = new C_epnetHierarchical;



		/// Which kind of algorithm was selected
		//for(corrida=0; corrida<Corridas; corrida++)
		//{
		switch (algoFeatures) {
		case  0:
			EPNet = new C_epnetHierarchical( argv[1] );
			break;
		case  1:
			EPNet = new C_epnetTournament( argv[1] );
			break;
		case  2:
			EPNet = new C_epnetCoEvo( argv[1] );
			break;
		case  3:
			EPNet = new C_epnetAsymmetric( argv[1] );
			break;
		case  4:
			EPNet = new C_epnetModular1( argv[1] );
			break;
		case  5:
			EPNet = new C_epnetSWAP_CONN( argv[1] );
			break;
		case  6:
			EPNet = new C_epnetModular1( argv[1] ); 		// the Mr-EPNet uses M-EPNet (modular1 algorithm)
			break;

		default:
			cout << "The algorithm chosen to evolve the features is incorrect, .... exit" << endl;

		}

		// Start the epnet algorithm, use the correct start epnet function accordingly the algorithm chosen
		EPNet->startEPNet();

		//}//////////////////////////////////////////////////////////////////
		///////////////////////   END corridas    /////////////////////////
		///////////////////////////////////////////////////////////////////

		//Section to save all to files
		//strcpy(filetemp,argv[1]);

		endTime = clock();

		//printf("Saving all info to file(s)\n");
		EPNet->save2file( argv[1], ext);						 //EPNet->save2file(filetemp,ext);
		cout << "All the information has been saved" << endl;

		/////////////////////////////////////////////////////////
		// Section to liberate memory
		delete EPNet;

		// memory for variables in mainepnet.hpp allocated in additional.hpp::function::obtainModuleInfo
		 if ( isModule1 == ON ){
			 safefree(&NAME_MODULE);
			 safefree(&OUT_IN_MOD);
			 safefree(&NUM_OUT_Per_MOD);
		 }

		//////////////////////////////////////////////////////////
/*	}
	catch (...) {
		cout << "Something were wrong in the main" << endl;
		processException();
		return EXIT_FAILURE;    // exit main() with error status
	}
*/
	cout << "seed used = " << seedRand << endl;
	cout << "Program EPNet finished ;)" << endl << "There were no errors. Now you can close me" << endl;
return(1);
} /////// End MAIN /////
//////////////////////////////
//--------------------//


