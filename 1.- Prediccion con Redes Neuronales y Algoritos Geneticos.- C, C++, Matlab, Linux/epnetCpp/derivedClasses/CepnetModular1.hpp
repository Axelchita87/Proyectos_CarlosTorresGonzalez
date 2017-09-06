/*!
 * CepnetModular1
 *
 * This class inplement the Modular epnet
 * It is used the shared nodes and shared connectins (interconnection between modules) to be the first deleted in the code
 * if that does not work, then it is used the standard EPNet algortihm
 *
 * Created: 17/01/11
 * modified at:
 * Author: 	Carlos Torres and Victor Landassuri
 *
 * Class derived form the EPNet class
 */

#ifndef C_EPNETMODULAR1_HPP
#define C_EPNETMODULAR1_HPP

class C_epnetModular1: public C_EPNet{
public:

	// List of modules to be loaded
	int FileModule_count;
	int **mod2load; 								// 3xn, [0][] individual, [1][] data set, [2][] number of module

	// methods

	//Constructor and destructor
	C_epnetModular1( char fileRun[] ) :  C_EPNet( fileRun ){
		// I pass the number of the run, but I do not do anything with it, change later

		FileModule_count = 0;
		mod2load = NULL;
	}

	~C_epnetModular1(){

		if (mod2load != NULL)
			safefree(&mod2load,3);

	}

	void obtainModule2Load(void);

	void startEPNet(void);

	int MRepnet_swapModule( int );

};// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




void C_epnetModular1::startEPNet(void){
	/*!
		 * MODULAR1 EPNet algorithm
		 * Delete shared nodes and connections.
		 * add strong connection too, to incremnet the intra-modular connectivity
		 */
		try{

			// local variables ////////////////////////////////

			/// to stop the algorithm
			double *previousFit = NULL;
			double *previousClassE = NULL;
			previousFit = allocate(previousFit, 1);
			previousClassE = allocate(previousClassE, 1);
			previousFit[0] = 100.0;
			previousClassE[0] = 100.0;
			// ----------------------------------------------------------

			int selected;
			int selected4Mod;
			//double **probability = NULL;
			double initTemp = temperature;					// temperature is a global variable
			int winner = -1;

			// Before start, check if it will reuse module - MR-EPNet, it that is the case, create a list of all possible values to load
			if( algoFeatures == MR_EPNET )
				obtainModule2Load();
			// here FileModule_count is the number of modules to insert and mod2load is a matrix with the indexes of the modules saved in pool



			/////////////////////  PARTIAL TRAINING  //////////////////////////
			cout << "- - - - start MODULAR1 EPNet main -- first training - before enter to the main loop of the epnet" << endl;

			if(trainMultipleSets == ON)
				trainPopMultiScales(TRAIN_INSIDE,&scaleNet[0]);
			else
				trainPop(TRAIN_INSIDE);

			cout << " - - - - '''' End '''' first training - - - - - - before enter epnet" << endl;

			//cout << "Before Rank.........." << endl; EPNet.printPop();
			///////////////  Rank the population  /////////////////////////
			rankk();					        //cout << "After Rank.........." << endl;            EPNet.printPop();

			// CALCULATE THE PROBABILITY
			// Use the rank base to obtain the probabilities
			//obtainProb(probability);

			Generation = 0;
			while(Generation < expectedGenerations){
				cout << "__________________________________________________" << endl;
				cout << endl << "+ + + + Main Loop EPNet, Generation = " << Generation << " + + + + + + " << endl << endl;     		cout << "-------------------------------------------------------------------------------" << endl;


				/////   Select one individual accordingly its probability  /////
				//selected = selection(probability);
				selected = (int ) (populationNum * rando());
				if(MYDEBUG_EPNET == 1)         	cout << "Individual Selected = " << selected << endl << "Status =" << Ppopulation[selected]->status[0] << endl << "Fitness = " << Ppopulation[selected]->fitness[0] << endl;


				////////// STEP 6 EPNET ALG ///////////////////////////////////
				/////////  Modified Backpropagation MBP //////////////////////
				if(  (Ppopulation[selected]->status[0] == SUCCESS)   &&   (baldwin == OFF)  ){
					epnetTrainMBP(selected);

				}

				///////// STEP 7 //////////////////////////////////////////////
				// Train with Simulate Annealing (SA) ///////////////////////
				else{
					if (baldwin == OFF)
						epnetTrainSA(selected, initTemp);

					// Evaluation for the SA
					if( ( (net1->fitness[0]*100) / Ppopulation[selected]->fitness[0])  <= STP   &&   net1->fitness[0] > 0   &&   useSA == ON &&  (baldwin == OFF)){
						Ppopulation[selected]->copyNet(net1);
						Ppopulation[selected]->status[0] = SUCCESS;
						mutHT ++;
						mutSA ++;
						if (MYDEBUG_EPNET == 1) 				cout << "Replace Selected individual by Network trainied with SA " << endl;
					}
					////////// STEP 8 //////////////////////////////////////////////////////////////////////


					/// New stages in the hierarquical algorithm:: deletion of shared nodes/connections

					/// step 8.1 Shared node Deletion
					else{
						winner = epnetDelSharedNodes(selected);
						if( (winner > 0) && (net2->fitness[0] < Ppopulation[populationNum-1]->fitness[0])){
							Ppopulation[populationNum-1]->copyCleanNet(net2);
							if (MYDEBUG_EPNET == 1)  cout << "Last network replaced by function deleteSharedNode" << endl << endl;
						}

					/// step 8.2 Shared connection Deletion
						else{
							winner = epnetDelSharedConn(selected);
							if( (winner > 0) && (net2->fitness[0] < Ppopulation[populationNum-1]->fitness[0])){
								Ppopulation[populationNum-1]->copyCleanNet(net2);
								if (MYDEBUG_EPNET == 1)  cout << "Last network replaced by function deleteSharedConnection" << endl << endl;
							}
							/// step 8.3 add intra-module connectivity
							else{
								winner = epnetAddStrongCon(selected);
								if( (winner > 0) && (net2->fitness[0] < Ppopulation[populationNum-1]->fitness[0])){
									Ppopulation[populationNum-1]->copyCleanNet(net2);
									if (MYDEBUG_EPNET == 1)  cout << "Last network replaced by function epnetAddStrongCon" << endl << endl;
								}


					///  Delete nodes ///////////////////////////////////////////////////
					else{
						winner = epnetDelNodes(selected);
						if( (winner > 0) && (net2->fitness[0] < Ppopulation[populationNum-1]->fitness[0])){
							Ppopulation[populationNum-1]->copyCleanNet(net2);
							if (MYDEBUG_EPNET == 1)  cout << "Last network replaced by function deleteNode" << endl << endl;
						}
						////////// STEP 9 ////////////////////////////////////////////////////////////////////
						// Delete Connections ////////////////////////////////////////////////////////////////
						else{
							winner = epnetDelConn(selected);

							if((winner > 0) && (net2->fitness[0] < Ppopulation[populationNum-1]->fitness[0])){
								Ppopulation[populationNum-1]->copyCleanNet(net2);
								if (MYDEBUG_EPNET == 1)  cout << "Last network replaced by function delete connenctions, check ahead to know if the network was mutated or not"<< endl << endl;
							}
							////////// STEP 10 ////////////////////////////////////////////////////////////////////////////////
							//// delete inputs
							else{
								winner = epnetDelInputs(selected);

								if( winner > 0  && (net2->fitness[0] < Ppopulation[populationNum-1]->fitness[0])){
									Ppopulation[populationNum-1]->copyCleanNet(net2);
									if (MYDEBUG_EPNET == 1)  cout << "Last network replaced by function delete input"<< endl << endl;
								}
								////////////////////////////////////////////////////////////////////////////////////////////////////////
								//// delete delays
								else if (Ppopulation[selected]->varN->inputs > 1){
									winner = epnetDelDelays(selected);

									if( winner > 0 && (net2->fitness[0] < Ppopulation[populationNum-1]->fitness[0])){
										Ppopulation[populationNum-1]->copyCleanNet(net2);
										if (MYDEBUG_EPNET == 1)  cout << "Last network replaced by function delete delay"<< endl << endl;
									}
									////////////////////////////////////////////////////////////////////
									//// Add nodes and connections delays or inputs /////////
									else{
										winner = epnetAddTournament(selected);

									}			 //end additons	/////////////////////
								}				// end delete delay
							}				   // end delete input
						} 					  //end delete connections  /////
					}						 //end delete node			 ////
						} // end delete shared connection ///
					}  // end delete share node ///
					} // add intra module connectivity
				}							//end SA							///
				// Here the mutation have finished 	/////////////

				// call a function to update the correct mutation used
				updateMutation(winner);
				winner = -1; 						// put to -1 to allow the sapw module update this value if it iis better







				//////////////////////////////// Section for the MR-EPNet algorithm /////////////////////////////////////////
if (algoFeatures == MR_EPNET){
				/// Select one Individual ////////////////////////////////////////////
				// Take at random one individual (different to selected) and replace the second works in case the module swap was better than it
				selected4Mod = (int ) (populationNum * rando());
				while(selected4Mod == selected)
					selected4Mod = (int ) (populationNum * rando());

				if(MYDEBUG_EPNET == 1)         	cout << "Individual Selected = " << selected4Mod << endl << "Status =" << Ppopulation[selected4Mod]->status[0] << endl << "Fitness = " << Ppopulation[selected4Mod]->fitness[0] << endl;
				//////////////////////////////////////////////////////////////////////////////////

				/// Swap one module at random with one taken from the list
				if ( FileModule_count > 0 )
					winner =	MRepnet_swapModule(selected4Mod);

				// call a function to update the correct mutation used. This time for the swap module
				updateMutation(winner);
}








				//rank the population that have been modified
				rankk();

				//save all the information needed in the variables per generation
				saveAllparam(Generation,selected);



				// Stopping criteria
				if ( stopEPNet(Generation, previousFit,  Ppopulation[0]->fitness[0], previousClassE, Ppopulation[0]->predictI->classifError )  ){
					Generation++;
					break;
				}

				// Stopping criteria fro modules, if the error of the third module is <= than the first module stop, it means that it was reused the module
				if ( stopEPNet_byModules(Generation, Ppopulation[0]->predictI->EpercentagePerModule, 0, 2) ) {
					Generation++;
					break;
				}


				Generation++;
			}//////////////////////////////////////////////////////////////////
			///////////////////////   END EPNET    ////////////////////////////
			///////////////////////////////////////////////////////////////////


			/////// All the individual in the last generations ////////////////
			///////      are trained with the last test set    ////////////////

			//Only to be shure that the best network is in the first position
			//if not, in this moment do not care, implication, lost one good solution
			// check later

			/////////////////////  FINAL TRAINING  //////////////////////////
			//cout << "Fitness before final training" << endl; EPNet.printPopFit();
			if(trainMultipleSets == ON)
				trainPopMultiScales(TRAIN_OUTSIDE,&scaleNet[0]);
			else
				trainPop(TRAIN_OUTSIDE);

			//trainPopFinal();//(&scaleNet[0]); 												// this one restart the weights and the train

			//rank the population again
			rankk();       	//cout << "Fitness after rankk" << endl; EPNet.printPopFit();

			// run the ensemble
			if( RUN_ENSEMBLE == 1){
				//////// New version of the code - ENSEMBLE method ////////////////
				cout << endl << "Ensemble method " << endl;
				//Average
				//averageEnsemble();

				//RBLC
				//RBLCEnsemble();
			}

			// liberate memory
			safefree( &previousFit);
			safefree( &previousClassE);


		}
		catch (...) {
			cout << "Something were wrong in the EPNet hierarquical class" << endl;
			processException();
			exit(EXIT_FAILURE);    // exit main() with error status
		} // end try
	} // End HIERARQUICAL ///////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////
	/////////////////////////////
	///////////
	///


void C_epnetModular1::obtainModule2Load(void){
	/*!
	 * Function to obtain a list of available modules to load
	 * Only load modules form the same run, so I can test statistically the results making several independent runs
	 *
	 */

	// Local variables
	int ind, ds, module, n, idx;

	string filePath = "../pool/";
	string fileM = "M";
	string subtask = "";
	string fileFinal = "";

	// Declarate variables that use a convertion form int to char
	char strInd[3];
	char strMod[3];
	char dataSet[3]; 	// j value ...there is a list of data set and ther correspondient number in the file CONS.hpp

	// flags to determinate where to stop to load
	int flagInd = 0;
	int flagDS = 0;
	//int stripDS = 0;
	//int stripInd = 0;

	// start to load the possible available data set
	// start in data set 0 to n and module 0 to m
	// if module m+x does not exist, it means that the previous module is the last module of the data set, thus, data set only have m+x-1 modules, knowing that I can resize the number of modules for each data set (in case many individulas are saved)
	// if data set n+y does not exist, it means that the previous data set is the last one

	// With thsi code I count the number of files in the directory,
	// it load all, in this moment I save different runs there
	// Here I just load the files from the same run, but it does not matter I will allocate a matrix with thsi number of columns

	// count how many files there are in the pool
	FileModule_count = countFiles(filePath) + 100;

	idx = 0;

	if ( FileModule_count > 0 ){
		mod2load = allocate( mod2load, 3, FileModule_count );
		// obtan the list of modules

		// individual could be seen as a network, it is usppose that all runs have the same number of individulas saved
		for( ind=0; ind<1; ind++){ 							// probably it was just save the best individual, but here I loo for all the population, take care if there are more than that
			n = sprintf (strInd, "%d", ind);

			// check that there this individual exist
	/*		fileFinal = filePath + isRun + "_" + "0" + fileM + "0" + "_ind" + strInd;
			if ( FileExists( fileFinal ) == true)
				stripInd = 0;
			else{
				//cout << "this individual does not exist, chenck next" << endl;
				stripInd++;
				if (stripInd > 10) 			// probably the data set are not consecutive (which will be extrnage), but if there is a gap of 10 I will not continue loading them
					break;
				continue;
			}
*/

			// Check data sets
			for (ds = 0; ds < 100; ds++){										// look for may data sets, check it if it is bigger than that
				n = sprintf (dataSet , "%d", ds);

	/*			// check that there this data set exist, it is usde the first module for the fisrt individual, if not it menas that there are not any data neither modules for it
				fileFinal = filePath + isRun + "_" + dataSet + fileM + "0" + "_ind" + "0";
				if ( FileExists( fileFinal ) == true)
					stripDS = 0;
				else{
					//cout << "this data set does not exist, chenck next" << endl;
					stripDS++;
					if (stripDS > 100) 			// probably the data set are not consecutive, but if there is a gap of 100 I will not continue loading them
						break;
					continue;
				}
*/


				// Check modules
				for ( module = 0; module < 1000; module++ ){ 				// look for a very big number of modules for each data set, to not miss any of them, check them if that value is increased
					n = sprintf (strMod, "%d", module);

					// Create the name of the file to be saved
					fileFinal = filePath + isRun + "_" + dataSet + fileM + strMod + "_ind" + strInd;
					cout << fileFinal << endl;

					// check if the file exist
					if ( FileExists( fileFinal ) == true){
						mod2load[0][idx] = ind;
						mod2load[1][idx] = ds;
						mod2load[2][idx] = module;
						idx++;

						// check I do not exceed the allocated space for the list
						if (idx >= FileModule_count){
							cout << "WARNING ... Something were wrong, it try to load more modules than the allocated in the list of modules, stop loading modules, check, function C_epnetModular1::obtainModule2Load" << endl;
							flagInd = 1;
							flagDS = 1;
							break;
						}
					}
					else
						break; 					// it means that this is the last module of this data set, so it can exit
				} // end modules
			} // end data sets
		} // end individulas
	} // end check if there are files to load
	else
		cout << "Warning, there are not modules to load, the evoluiton will run as the normal M-EPNet ";

	// idx is the number of modules availabe to copy
	imprime(mod2load,3,idx);
	FileModule_count = idx;

}// End obtainModules2Load





int C_epnetModular1::MRepnet_swapModule(int indSelected){
/*!
 * Function to swap a module from the selcted network by one at random
 */
	int Winner = -1;
	int tmpCont = 0;
	int deleteMod = 0;
	int loadMod = 0;

	if(MYDEBUG_EPNET == 1) {
		cout << endl << "- - - Swap Module function -- --- ---- -----   M R - E P N e t  ----- ---- ---- --" << endl;
		cout << "Fitness before enter in Module swap = " << Ppopulation[indSelected]->fitness[0] << endl;
		cout << "March     = " << Ppopulation[indSelected]->huskenModule->MarchTD << endl;
		cout << "Mweight = " << Ppopulation[indSelected]->huskenModule->MweightTD << endl;
	}
	//Copy Networks
	net2->copyCleanNet(Ppopulation[indSelected]);

	deleteMod = (int ) ( NUM_MODULES  * rando() );
	//deleteMod = 0;
	loadMod = deleteMod; //(int ) ( FileModule_count * rando() ); 				// Ok  // in this moment the module deleted its loaded with the same index
	//loadMod = 0;


	// load module into a network, try maximum 10 times
	while ( vecNet[0]->loadModule( mod2load[0][loadMod], mod2load[1][loadMod], mod2load[2][loadMod]  )  || tmpCont > 10){		// pass: individual, datase and number of the module to load
		loadMod = (int ) ( FileModule_count * rando() ); 				// try another one if there was a flaw in the previous
		tmpCont++;
	}

	// to debug
	int allnodes = net2->varN->inputs + net2->varN->hidden + net2->varN->VnoOutputs;
	//imprime(net2->CW,allnodes,allnodes);


	//Swap the module
	Winner = net2->swapModule(deleteMod, vecNet[0]);


	if(MYDEBUG_EPNET == 1){
		cout << "Fitness after enter in Module swap = " << net2->fitness[0] << endl;
		cout << "March     = " << net2->huskenModule->MarchTD << endl;
		cout << "Mweight = " << net2->huskenModule->MweightTD << endl << endl;
		cout << " Fitness second last = " << Ppopulation[populationNum-2]->fitness[0] << endl;
	}

	// check if it was better than the second works
	if( net2->fitness[0] < Ppopulation[populationNum-2]->fitness[0] ){
		Ppopulation[populationNum-2]->copyCleanNet(net2);
		return (Winner);
	}
	else
		return (-1);

}//////////////////////////




#endif
