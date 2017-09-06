/*!
 * CepnetCoEvo.hpp
 *
 * This class inplement the CO-EVOLUTIONARY EPNet algorithm
 *
 * Created: 18/08/10
 * modified at:
 * Class derived form the EPNet class
 */

#ifndef C_EPNETCO_EVO_HPP
#define C_EPNETCO_EVO_HPP



class C_epnetCoEvo: public C_EPNet{
public:
	//C_ALLParam *ALLParam2;  // this two are not declared here, insted are declared in EPNet to avoid to create a new class to save only this
	//C_network *Ppopulation2[populationNum];

	// methods

	//Constructor and destructor
	C_epnetCoEvo(char []); // char [] ) :  C_EPNet( char [] );
	~C_epnetCoEvo();

	void startEPNet(void);
	 // trian with MBP
	void epnetTrainMBP2(int);
	// train with SA
	void epnetTrainSA2(int , double);
	// Delete inputs
	int epnetDelInputs2(int );
	// Delete Delays
	int epnetDelDelays2(int );

	void saveAllparam(int , int, int );

	 // Rank the second population
	void rankk2(void);

	// Train both populations, it the EPNet this is virtual
	 void trainPop(int);


};// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// constructor
C_epnetCoEvo::C_epnetCoEvo( char fileRun[] ) :  C_EPNet( fileRun ){
	ALLParam2 = new C_ALLParam;

	for(int i=0; i<populationNum; i++){
		Ppopulation2[i] = NULL;
		Ppopulation2[i] = (C_network *) new C_network(OFF, (char*) "noLoad", INPUTF.c_str());
	}
}



// destructor
C_epnetCoEvo::~C_epnetCoEvo(){

	for(int i=populationNum-1; i>=0; i--){
			delete Ppopulation2[i];
			Ppopulation2[i] = NULL;
		}

	delete(ALLParam2);
	ALLParam2 = NULL;

}


void C_epnetCoEvo::startEPNet(void){
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

		int selected, selected2;
		//double **probability = NULL;
		double initTemp = temperature;					// temperature is a global variable
		int winner = -1;
		int cont = 0;

		// Evaluate for the possible values of some variables
		if(migrationInd >=  populationNum){
			cout << "WARNING the individuals to migrate are too many in comaprison the the individual in the population" << endl;
			migrationInd = populationNum - 1;		// only to avoid errors
			cout << " WARNING WARNING WARNING WARNING             WARNING WARNING WARNING !!!!!!!!!!!!!!!" << endl;
		}


		/////////////////////  PARTIAL TRAINING  //////////////////////////
		cout << "- - - - start Co-evolutionary EPNet main -- first training - before enter to the main loop of the epnet" << endl;

		if(trainMultipleSets == ON)
			trainPopMultiScales(TRAIN_INSIDE,&scaleNet[0]);
		else
			trainPop(TRAIN_INSIDE);

		cout << " - - - - '''' End '''' first training - - - - - - before enter epnet" << endl;

		//cout << "Before Rank.........." << endl; EPNet.printPop();
		///////////////  Rank the population  /////////////////////////
		rankk();					        //cout << "After Rank.........." << endl;            EPNet.printPop();
		rankk2();
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

			////////////////////////////////////////////////////////
			// POPULATION ONE
			///////////////////////////////////////////////////////////////////

			////////// STEP 6 EPNET ALG ///////////////////////////////////
			/////////  Modified Backpropagation MBP //////////////////////
			if(Ppopulation[selected]->status[0] == SUCCESS  &&   (baldwin == OFF) ){
				epnetTrainMBP(selected);

			}
			///////// STEP 7 //////////////////////////////////////////////
			// Train with Simulate Annealing (SA) ///////////////////////
			else{
				if (baldwin == OFF)
				epnetTrainSA(selected, initTemp);

				// Evaluation for the SA
				if( ( (net1->fitness[0]*100) / Ppopulation[selected]->fitness[0])  <= STP   &&   net1->fitness[0] > 0   &&   useSA == ON  &&  (baldwin == OFF)){
					Ppopulation[selected]->copyNet(net1);
					Ppopulation[selected]->status[0] = SUCCESS;
					mutHT ++;
					mutSA ++;
					if (MYDEBUG_EPNET == 1) 				cout << "Replace Selected individual by Network trainied with SA " << endl;
				}
				////////// STEP 8 //////////////////////////////////////////////////////////////////////

				/// Delete nodes ///////////////////////////////////////////////////
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
						//// Add nodes and connections /////////
						else{
							if(MYDEBUG_EPNET == 1){ 				cout << endl << " %%%%% - - Add connection / node - - %%%%%" << endl;      	            	cout << "Fitness before enter to add node / con = " << Ppopulation[selected]->fitness[0] << endl; }
							// Copy networks, allocating memory
							net2->copyCleanNet(Ppopulation[selected]);

							// Call add Nodes / connections
							winner = emptyNet->addNodeCon(&net2, &vecNet[0], &scaleNet[0]);
							if( winner > 0 ){
								if (MYDEBUG_EPNET == 1)  cout << "Last network replaced by function addNodeCon or  addIDHC, check ahead to now more"<< endl << endl;
								Ppopulation[populationNum-1]->copyCleanNet(net2);
							}
						}			 //end additons	/////////////////////
					} 					  //end delete connections  /////
				}						 //end delete node			 ////
			}							//end SA							///
			// Here the mutation have finished 	/////////////


			// call a function to update the correct mutation used
			updateMutation(winner);

			selected2 = (int ) (populationNum * rando());

			////////////////////////////////////////////////////////
			// POPULATION 2
			///////////////////////////////////////////////////////////////////
			///////////////////////////////////////////////////////////////////
			cout << "SECOND POPULATION -----------------------------------------------" << endl;

			////////// STEP 6 EPNET ALG ///////////////////////////////////
			/////////  Modified Backpropagation MBP //////////////////////
			if(Ppopulation2[selected2]->status[0] == SUCCESS){
				epnetTrainMBP2(selected2);

			}
			///////// STEP 7 //////////////////////////////////////////////
			// Train with Simulate Annealing (SA) ///////////////////////
			else{
				epnetTrainSA2(selected2, initTemp);

				// Evaluation for the SA
				if( ( (net1->fitness[0]*100) / Ppopulation2[selected2]->fitness[0])  <= STP   &&   net1->fitness[0] > 0   &&   useSA == ON){
					Ppopulation2[selected2]->copyNet(net1);
					Ppopulation2[selected2]->status[0] = SUCCESS;
					mutHT ++;
					mutSA ++;
					if (MYDEBUG_EPNET == 1) 				cout << "Replace Selected individual by Network trainied with SA " << endl;
				}
				////////// STEP 8 //////////////////////////////////////////////////////////////////////
				//// delete inputs
				else{
					winner = epnetDelInputs2(selected2);

					if( winner > 0  && (net2->fitness[0] < Ppopulation2[populationNum-1]->fitness[0])){
						Ppopulation2[populationNum-1]->copyCleanNet(net2);
						if (MYDEBUG_EPNET == 1)  cout << "Last network replaced by function delete input"<< endl << endl;
					}
					////////////////////////////////////////////////////////////////////////////////////////////////////////
					//// delete delays
					else{
						winner = epnetDelDelays2(selected2);

						if( winner > 0 && (net2->fitness[0] < Ppopulation2[populationNum-1]->fitness[0])){
							Ppopulation2[populationNum-1]->copyCleanNet(net2);
							if (MYDEBUG_EPNET == 1)  cout << "Last network replaced by function delete delay"<< endl << endl;
						}
						////////////////////////////////////////////////////////////////////
						//// Add nodes and connections delays or inputs /////////
						else{
							if(MYDEBUG_EPNET == 1){ 				cout << endl << " 2%%%%% - - Add delay / Input- - %%%%%" << endl;      	            	cout << "2Fitness before enter to add inputs / delays= " << Ppopulation2[selected2]->fitness[0] << endl; }
							// Copy networks, allocating memory
							net2->copyCleanNet(Ppopulation2[selected2]);

							// Call add inputs / delays
							winner = emptyNet->addInpDelay(&net2, &vecNet[0], &scaleNet[0]);
							if( winner > 0 ){
								if (MYDEBUG_EPNET == 1)  cout << "Last network replaced by function addInput or  adddelay, check ahead to now more"<< endl << endl;
								Ppopulation2[populationNum-1]->copyCleanNet(net2);
							}
						}			 //end additons	/////////////////////
					}				// end delete delay
				}				   // end delete input
			}							//end SA							///
			// Here the mutation have finished 	/////////////


			// call a function to update the correct mutation used
			updateMutation(winner);


			// Migration
			if((Generation % migrationGen) == 0){
				cout << "ENTER MIGRATION ******************************************" << endl;

				// copy best individual from one population to the other, replace the worst individuals
				cont = populationNum - migrationInd;
				for(int i=0; i<migrationInd; i++){
					Ppopulation2[cont]->copyCleanNet(Ppopulation[i]);
					Ppopulation[cont]->copyCleanNet(Ppopulation2[i]);
					cont ++;
				}
			}

			//rank the population that have been modified
			rankk();
			rankk2();

			//save all the information needed in the variables per generation
			saveAllparam(Generation,selected, selected2);

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

		// liberate memory
		safefree( &previousFit);
		safefree( &previousClassE);

	}
	catch (...) {
		cout << "Something were wrong in the EPNet co-evolutionary class" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	} // end try
} // End Co-EVO ///////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////
/////////////////////////////
///////////
///


// Function for the co-evo for the second population for the fatures evolution
void C_epnetCoEvo::epnetTrainMBP2(int indSelected){
	if(MYDEBUG_EPNET ==1 ) 				cout << "Furter trainig for a succesful network..." << endl << "Fitness before enter = " << Ppopulation2[indSelected]->fitness[0] << endl;

	if(trainMultipleSets == ON){
		// copy networks to train in another scales
		Ppopulation2[indSelected]->copyALLscales(&scaleNet[0]);
		// train all scales
		Ppopulation2[indSelected]->trainScales(&scaleNet[0], epochsK[TRAIN_INSIDE], TRAIN_INSIDE);
	}else
		Ppopulation2[indSelected]->trainMBP(epochsK[0], TRAIN_INSIDE);

	// save some Global variables
	mutHT ++;
	mutMBP ++;
	evaluationsPrun ++;
	totalEval++;
	if(MYDEBUG_EPNET ==1){
		cout << "Fitness after enter = " << Ppopulation2[indSelected]->fitness[0] << endl;
		cout << "Status = " << Ppopulation2[indSelected]->status[0] << endl;
	}
}



// For the co-evo algorithm for features
void C_epnetCoEvo::epnetTrainSA2(int indSelected, double Temp){
	// determinate if the SA is used, i.e. if it is used and hbrid training
	if(useSA == ON){
		if( MYDEBUG_EPNET == 1) {
			cout << endl << "-*-*- Train with Simulate Annealing -*-*- " << endl;
			cout << "Fitness before enter in SA = " << Ppopulation2[indSelected]->fitness[0] << endl;
		}

		//Copy Networks ///////////
		net2->copyCleanNet(Ppopulation2[indSelected]);
		net1->copyCleanNet(Ppopulation2[indSelected]);

		//Train with SA ///////////////////////////
		net2->trainSA(net1, Temp, SAalfa);
		evaluationsPrun ++;
		totalEval++;
		if( MYDEBUG_EPNET == 1)                 cout << "Fitness after enter in SA = " << net1->fitness[0] << endl;
	}
}



// For the co-evo algorithm for fetures
int C_epnetCoEvo::epnetDelInputs2(int indSelected){
	int Winner = -1;
	if(MYDEBUG_EPNET == 1){ 				cout << endl << " %%%%% - - delete inputs - - %%%%%" << endl;      	            	cout << "Fitness before enter to add node / con = " << Ppopulation2[indSelected]->fitness[0] << endl; }

	// Copy networks, allocating memory
	if(fixedinputs != FIXED ){
		net2->copyCleanNet(Ppopulation2[indSelected]);
		Winner = net2->deleteInput(&scaleNet[0]);
	}
	return Winner;
}




int C_epnetCoEvo::epnetDelDelays2(int indSelected){
	int Winner = -1;
	if(MYDEBUG_EPNET == 1){ 				cout << endl << " %%%%% - - delete delays - - %%%%%" << endl;      	            	cout << "Fitness before enter to add node / con = " << Ppopulation2[indSelected]->fitness[0] << endl; }

	// Copy networks, allocating memory
	if(fixedinputs != FIXED ){
		net2->copyCleanNet(Ppopulation2[indSelected]);
		Winner = net2->deleteDelay(&scaleNet[0]);
	}
	return Winner;
}


//obtain and save averages values per generation for both populations in the coevo alg
void C_epnetCoEvo::saveAllparam(int Gen, int selec, int selec2)
{
	ALLParam->saveAllperGen(Gen, selec, Ppopulation);
	ALLParam2->saveAllperGen(Gen, selec2, Ppopulation2);

}//////////////////////////////////////////////////////////////////////////////////

void C_epnetCoEvo::rankk2(void){
	//Arrange the individual given their fitness
	// this functio shuld act over a class, improve in the futures if it is possible
	register int i,j;
	C_network *tempN;
	for(i=0; i<populationNum; i++){
		for(j=i+1; j<populationNum; j++){
			if(Ppopulation2[i]->fitness[0] > Ppopulation2[j]->fitness[0]){ 	 // translate this if i have the problem ---> || isnan(Network{i}.fitness)
				tempN = Ppopulation2[i];
				Ppopulation2[i] = Ppopulation2[j];
				Ppopulation2[j] = tempN;
			}
		}
	}

	tempN = NULL;
}/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


void C_epnetCoEvo::trainPop(int where){
	if (where == TRAIN_INSIDE){
		for(int i=0; i<populationNum; i++){
			Ppopulation[i]->trainMBP(epochsK[TRAIN_INSIDE],TRAIN_INSIDE);
			Ppopulation[i]->status[0] = SUCCESS;															// Set to success to all the networks

			Ppopulation2[i]->trainMBP(epochsK[TRAIN_INSIDE],TRAIN_INSIDE);
			Ppopulation2[i]->status[0] = SUCCESS;													// Set to success to all the networks
		}
	}
	else if (where == TRAIN_OUTSIDE){
		for(int i=0; i<populationNum; i++){
			Ppopulation[i]->trainMBP(epochsK[TRAIN_OUTSIDE],TRAIN_OUTSIDE);
			Ppopulation2[i]->trainMBP(epochsK[TRAIN_OUTSIDE],TRAIN_OUTSIDE);
		}
	}
}/////////////////////////////////////////////////////////////////////////////////////////

#endif
