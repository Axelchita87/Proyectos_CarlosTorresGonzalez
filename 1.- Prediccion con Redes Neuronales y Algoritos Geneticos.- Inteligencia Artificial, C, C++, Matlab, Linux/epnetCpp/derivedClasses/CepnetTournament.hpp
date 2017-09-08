/*!
 * CepnetTournament
 *
 * This class inplement the tournamnet EPNet algorithm
 *
 * Created: 18/08/10
 * modified at:
 * Class derived form the EPNet class
 */

#ifndef C_EPNETTOURNAMENT_HPP
#define C_EPNETTOURNAMENT_HPP

class C_epnetTournament: public C_EPNet{
public:


	// methods

	//Constructor and destructor
	C_epnetTournament( char fileRun[] ) :  C_EPNet( fileRun ){

	}
	~C_epnetTournament(){

	}

	void startEPNet(void);
};// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




void C_epnetTournament::startEPNet(void){
	/*!
	 * Tournament algorithm for the EPNet algorithm
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
		//double **probability = NULL;
		double initTemp = temperature;					// temperature is a global variable
		int winner = -1;
/*    I will not delete this.
 * I am not sure but if net1 or net2 or scaleNet, ... or other are deleted completely, I think there is going to be an error
 * in case that happend, do not declate those variables inside the class, instead decleare them here, in the past
 * tese variables work ok here, but I am not sure if work ok inside the main class
 *
		// empty network
		C_network *emptyNet;

		// Temporal networks ////
		C_network *net1, *net2, *vecNet[4];

		// Temporal network to hold all scales
		C_network *scaleNet[7];


		net1 = NULL;
		net2 = NULL;
		emptyNet = NULL;

		// For the networks that is used in the addition deleteion
		for(int i=0; i<4; i++)
			vecNet[i] = NULL;

		// For the network that is used to load the scales
		if (trainMultipleSets == ON){
			for(int i=0; i<7; i++)
				scaleNet[i] = NULL;
		}
		///////////////////////////////////////////////////////////

		// Initialize local variables

		// the vector for the probability
		//probability = allocate(probability,2,populationNum);

		net1 = (C_network *) new C_network(OFF, "noLoad", INPUTF);
		net2 = (C_network *) new C_network(OFF, "noLoad", INPUTF);
		emptyNet = (C_network *) new C_network(OFF, "noLoad", INPUTF);
		for(int i=0; i<4; i++)
			vecNet[i] = (C_network *) new C_network(OFF, "noLoad", INPUTF);

		if (trainMultipleSets == ON){
			for(int i=0; i<7; i++)
				scaleNet[i] = (C_network *) new C_network(OFF, "noLoad", INPUTF);     // in this point it does not matter which data set is used, only is to allocate mem
		}
		///////////////////////////////////////////////////////////
*/


		/////////////////////  PARTIAL TRAINING  //////////////////////////
		cout << "- - - - start Tournament EPNet main -- first training - before enter to the main loop of the epnet" << endl;

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
			if(Ppopulation[selected]->status[0] == SUCCESS &&   (baldwin == OFF)){

				epnetTrainMBP(selected);

			}
			///////// STEP 7 //////////////////////////////////////////////
			// Train with Simulate Annealing (SA) ///////////////////////
			else{
				if (baldwin == OFF)
				epnetTrainSA(selected, initTemp);

				// Evaluation for the SA
				if( ( (net1->fitness[0]*100) / Ppopulation[selected]->fitness[0])  <= STP   &&   net1->fitness[0] > 0   &&   useSA == ON  &&   (baldwin == OFF)){
					Ppopulation[selected]->copyNet(net1);
					Ppopulation[selected]->status[0] = SUCCESS;
					mutHT ++;
					mutSA ++;
					if (MYDEBUG_EPNET == 1) 				cout << "Replace Selected individual by Network trainied with SA " << endl;
				}
				////////// STEP 8 //////////////////////////////////////////////////////////////////////
				/// Delete nodes / Inputs / delays and train with MBP ///////////////////////////////////////////////////
				else{
					if(MYDEBUG_EPNET == 1) {        	    	cout << endl << "- - - Delete (Input or hidden Node) - - -" << endl;         	    	cout << "Fitness before enter in Delete function = " << Ppopulation[selected]->fitness[0] << endl; }

					//Copy Networks
					net2->copyCleanNet(Ppopulation[selected]);

					//Delete Nodes or inputs delays and hidden nodes and compete to survive
					if(fixedinputs == FIXED)
						winner = net2->deleteNode(&scaleNet[0]);
					else
						winner = emptyNet->deleteIDH(&net2, &vecNet[0], &scaleNet[0]);


					if(MYDEBUG_EPNET == 1){        	    	cout << "Fitness after enter in Delete Node/Input/Delays = " << net2->fitness[0] << endl;         	    	cout << " Fitness last = " << Ppopulation[populationNum-1]->fitness[0] << endl; }

					if( (winner > 0) && (net2->fitness[0] < Ppopulation[populationNum-1]->fitness[0])){
						Ppopulation[populationNum-1]->copyCleanNet(net2);
						if (MYDEBUG_EPNET == 1)  cout << "Last network replaced by function deleteNode or deleteIDH, check ahead to know more" << endl << endl;
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
						//// Add nodes and connections delays or inputs /////////
						else{
							winner = epnetAddTournament(selected);
						}				   //end additons	/////////////////////
					} 					  //end delete connections  /////
				}						 //end delete node,	delay,	input	 ////
			}							//end SA							///
			// Here the mutation have finished 	/////////////

			// call a function to update the correct mutation used
			updateMutation(winner);

			//rank the population that have been modified
			rankk();

			//save all the information needed in the variables per generation
			saveAllparam(Generation,selected);

			// Stopping criteria
			if ( stopEPNet(Generation, previousFit,  Ppopulation[0]->fitness[0], previousClassE, Ppopulation[0]->predictI->classifError )  ){
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

/*    The same I do not delete them brom here, if something happend restore this code
 *
		// Liberate memory
		delete net2;
		delete net1;
		delete emptyNet;

		for(int i=3; i>=0; i--){
			delete vecNet[i];
			vecNet[i] = NULL;
		}
		if(trainMultipleSets == ON){
			for(int i=6; i>=0; i--){
				delete scaleNet[i];
				scaleNet[i] = NULL;
			}
		}

		//safefree(&probability,2);

		emptyNet = NULL;
		net2 = NULL;
		net1 = NULL;*/

		// liberate memory
		safefree( &previousFit);
		safefree( &previousClassE);


	}
	catch (...) {
		cout << "Something were wrong in the EPNet Tournamentclass" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	} // end try
} // End TOURNAMENT EPNET///////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////
/////////////////////////////
///////////
///



#endif
