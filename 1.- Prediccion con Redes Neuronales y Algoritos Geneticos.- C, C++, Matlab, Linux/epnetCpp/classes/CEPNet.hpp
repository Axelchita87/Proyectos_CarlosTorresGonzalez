/*!
 * C_EPNet.hpp
 * Created: 26/11/09
 * Class that contains all the other classes: ALLParam, sets, netowrk, ...
 */

#ifndef C_EPNET_HPP
#define C_EPNET_HPP

class C_EPNet{

public:
	int Generation;

	C_ALLParam *ALLParam;	//to save Av, min max, ... per generation
	C_ALLParam *ALLParam2;

    //C_network *population;
    C_network *Ppopulation[populationNum];
    C_network *Ppopulation2[populationNum];
    C_ensemble *ensemble;



    // empty network
    C_network *emptyNet;

    // Temporal networks ////
    C_network *net1, *net2, *vecNet[4];

    // Temporal network to hold all scales
    C_network *scaleNet[7];


    //Contructor for C_EPNet
    C_EPNet(char []);
    
    //Destructor
    ~C_EPNet();
    
    //The main algorithm
    virtual void startEPNet(void) {
    	cout << "Enter to startEPNet in class EPNet. Do nothing ................................" << endl;
    }
    //void startTournamentEPNet(void);
    //void startCOEVOEPNet(void);
    //void startAssimetricEPNet(void);

    // trian with MBP
    virtual void epnetTrainMBP(int);
    //void epnetTrainMBP2(int); 						// for the co-evo population 2
    // train with SA
    virtual void epnetTrainSA(int , double);
    //void epnetTrainSA2(int , double);
    // Delete Hidden nodes
    int epnetDelNodes(int );
    int epnetDelSharedNodes(int);
    int epnetAddStrongCon(int );


    // Delete connecions
    int epnetDelConn(int );
    int epnetDelSharedConn(int );


    // Delete inputs
    virtual int epnetDelInputs(int );
    //int epnetDelInputs2(int );
    // Delete Delays
    virtual int epnetDelDelays(int );
    //int epnetDelDelays2(int );
    // Add inputs delays hidden and connections (Tournament)
    virtual int epnetAddTournament(int );


    //Print all the population
    void printPop();

    //Print the fitness of all Population
    void printPopFit(void);

    //To save into a file all the class
    void save2file(char [], char []);
    void save2fileCONFIG(char []);
    void save2fileCLASSES(char [], char[]);
    void save2fileNETWORKS(char []);
    void save2fileMODULES(char []);

    // Train all the population with multiple data sets for a single network
    void trainPopMultiScales(int, C_network **);

    // Train all the population with multiple data sets for a single network
    virtual void trainPop(int);

	//Train the final population, here it is restarted the weights and train to see if the error can be reduced
    void trainPopFinal();

    // Rank the population
    void rankk(void);



    // Select an individual
    //int selection(double **);

    //Obtain and save values per generation
    void saveAllparam(int , int);


    // Stopping criterias
    int stopEPNet(int , double *,  double, double *, double );
    // stop by module performance
    int stopEPNet_byModules(int , double *, int, int);

   // void saveAllperGen(int Generation, int corrida, int selected);

    //Fucntion to determinate the probaility of being selected
    //void obtainProb(double **);

    //Average Ensemble
    void averageEnsemble();

    //RBLC Ensemble
    void RBLCEnsemble();



}; // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////






/// Section for the methods ///

//Constructor
C_EPNet::C_EPNet( char fileRun[] ){
	//Constructor fo C_EPNet, allocate memory for all variables
	try{

		int i = 0;
		ALLParam = new C_ALLParam;


		// old way to create the population
		//population = (C_network *) new C_network [populationNum]; //I expect that corridas =1, if not, check if it works
		// Initialize each network taking the global variables form mainepnet.hpp

		/*!
		 * Create the population, randomly initialized or loaded from a file
		 */
		if (loadNets2continueEvo == OFF){ 						// If run ANNs randomly initialized
			for(i=0; i<populationNum; i++){
				Ppopulation[i] = NULL;
				if ( fitness_learnQuick2Genaralize == ON )
					Ppopulation[i] = (C_net_quickLearning *) new C_net_quickLearning(OFF, (char*) "noLoad", INPUTF.c_str() );
				else
					Ppopulation[i] = (C_network *) new C_network(OFF, (char*) "noLoad", INPUTF.c_str() );
			}
		}
		else if (loadNets2continueEvo == ON){ 					// load ANNs previosly saved and continue the evolution of them
			// some local variables
			string fileNet = toSavePop; 							// Global var

			// The path may be different if it is only continue the evoluiotn than if it intended to reuse modules
			if ( reuseModule == ON )
				fileNet = reusePop;

			string fileFinal;
			fileNet = fileNet + fileRun + "Net"; 			// resPop/r1
			char strTemp[3];
			int n;

			// Save all the population in separate files
			for( i=0; i<populationNum; i++){
				// convert i to string
				n = sprintf (strTemp, "%d", i+1);

				// create final name for the network to be loaded
				fileFinal = fileNet + strTemp + ".txt";

				Ppopulation[i] = NULL;

				// create individual loading the given file
				if ( fitness_learnQuick2Genaralize == ON )
					Ppopulation[i] = (C_net_quickLearning *) new C_net_quickLearning(ON, (char*)  fileFinal.c_str(), INPUTF.c_str());
				else
					Ppopulation[i] = (C_network *) new C_network(ON, (char*)  fileFinal.c_str(), INPUTF.c_str());

				cout << "Network loaded::: " << fileFinal << endl;
			}
		} // End Population creation

		// Set to NULL ///////////////////////////////////
		net1 = NULL;
		net2 = NULL;
		emptyNet = NULL;

		// For the networks that is used in the addition deletion, be carreful to not use more network inside one method than the created here
		for(int i=0; i<7; i++)
			vecNet[i] = NULL;

		// For the network that is used to load the scales
		if (trainMultipleSets == ON){
			for(int i=0; i<7; i++)
				scaleNet[i] = NULL;
		}
		///////////////////////////////////////////////////////////

		// the vector for the probability
		//probability = allocate(probability,2,populationNum);

		if ( fitness_learnQuick2Genaralize == ON ){																	// Derived networks
			net1 = (C_net_quickLearning *) new C_net_quickLearning(OFF, (char*)"noLoad", INPUTF.c_str());
			net2 = (C_net_quickLearning *) new C_net_quickLearning(OFF,  (char*)"noLoad", INPUTF.c_str());
			emptyNet = (C_net_quickLearning *) new C_net_quickLearning(OFF,  (char*)"noLoad", INPUTF.c_str());
			for(int i=0; i<4; i++)
				vecNet[i] = (C_net_quickLearning *) new C_net_quickLearning(OFF,  (char*)"noLoad", INPUTF.c_str());

			if (trainMultipleSets == ON){
				for(int i=0; i<7; i++)
					scaleNet[i] =(C_net_quickLearning *) new C_net_quickLearning(OFF,  (char*)"noLoad", INPUTF.c_str());     // in this point it does not matter which data set is used, only is to allocate mem
			}
		}
		else{ 																																		// Normal networks
			net1 = (C_network *) new C_network(OFF, (char*)"noLoad", INPUTF.c_str());
			net2 = (C_network *) new C_network(OFF,  (char*)"noLoad", INPUTF.c_str());
			emptyNet = (C_network *) new C_network(OFF,  (char*)"noLoad", INPUTF.c_str());
			for(int i=0; i<4; i++)
				vecNet[i] = (C_network *) new C_network(OFF,  (char*)"noLoad", INPUTF.c_str());

			if (trainMultipleSets == ON){
				for(int i=0; i<7; i++)
					scaleNet[i] = (C_network *) new C_network(OFF,  (char*)"noLoad", INPUTF.c_str());     // in this point it does not matter which data set is used, only is to allocate mem
			}
		}
		///////////////////////////////////////////////////////////


		if(RUN_ENSEMBLE == 1)
			ensemble = new C_ensemble;
	}
	catch (...) {
		cout << "Something were wrong in the EPNet constructor" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
}

//Destructor
C_EPNet::~C_EPNet(){

	if(RUN_ENSEMBLE == 1)
		delete ensemble;

	if(trainMultipleSets == ON){
		for(int i=6; i>=0; i--){
			delete scaleNet[i];
			scaleNet[i] = NULL;
		}
	}

	//safefree(&probability,2);

	for(int i=6; i>=0; i--){
		delete vecNet[i];
		vecNet[i] = NULL;
	}

	delete emptyNet;
	delete net2;
	delete net1;

	emptyNet = NULL;
	net2 = NULL;
	net1 = NULL;

	for(int i=populationNum-1; i>=0; i--){
		delete Ppopulation[i];
		Ppopulation[i] = NULL;
		}


	delete(ALLParam);
	ALLParam = NULL;
}
















void C_EPNet::epnetTrainMBP(int indSelected){
	if(MYDEBUG_EPNET ==1 ) 				cout << "Furter trainig for a succesful network..." << endl << "Fitness before enter = " << Ppopulation[indSelected]->fitness[0] << endl;

	if(trainMultipleSets == ON){
		// copy networks to train in another scales
		Ppopulation[indSelected]->copyALLscales(&scaleNet[0]);
		// train all scales
		Ppopulation[indSelected]->trainScales(&scaleNet[0], epochsK[TRAIN_INSIDE], TRAIN_INSIDE);
	}else
		Ppopulation[indSelected]->trainMBP(epochsK[0], TRAIN_INSIDE);

	// save some Global variables
	mutHT ++;
	mutMBP ++;
	evaluationsPrun ++;
	totalEval++;
	if(MYDEBUG_EPNET ==1){
		cout << "Fitness after enter = " << Ppopulation[indSelected]->fitness[0] << endl;
		cout << "Status = " << Ppopulation[indSelected]->status[0] << endl;
	}
}




void C_EPNet::epnetTrainSA(int indSelected, double Temp){
	// determinate if the SA is used, i.e. if it is used and hbrid training
	if(useSA == ON){
		if( MYDEBUG_EPNET == 1) {
			cout << endl << "-*-*- Train with Simulate Annealing -*-*- " << endl;
			cout << "Fitness before enter in SA = " << Ppopulation[indSelected]->fitness[0] << endl;
		}

		//Copy Networks ///////////
		net2->copyCleanNet(Ppopulation[indSelected]);
		net1->copyCleanNet(Ppopulation[indSelected]);

		//Train with SA ///////////////////////////
		net2->trainSA(net1, Temp, SAalfa);
		evaluationsPrun ++;
		totalEval++;
		if( MYDEBUG_EPNET == 1)                 cout << "Fitness after enter in SA = " << net1->fitness[0] << endl;
	}
}



int C_EPNet::epnetDelNodes(int indSelected){

	int Winner = -1;
	if ( FIXED_HIDDEN == OFF ){
		if(MYDEBUG_EPNET == 1) {
			cout << endl << "- - - Delete (Input or hidden Node) - - -" << endl;
			cout << "Fitness before enter in Delete function = " << Ppopulation[indSelected]->fitness[0] << endl;
			cout << "March     = " << Ppopulation[indSelected]->huskenModule->MarchTD << endl;
			cout << "Mweight = " << Ppopulation[indSelected]->huskenModule->MweightTD << endl;
		}
		//Copy Networks
		net2->copyCleanNet(Ppopulation[indSelected]);

		//Delete Nodes
		Winner = net2->deleteNode(&scaleNet[0]);			// if it is not trainMultipleSets it does not matter if it is passed the addres of the network

		if(MYDEBUG_EPNET == 1){
			cout << "Fitness after enter in Delete Node = " << net2->fitness[0] << endl;
			cout << "March     = " << net2->huskenModule->MarchTD << endl;
			cout << "Mweight = " << net2->huskenModule->MweightTD << endl << endl;

			cout << " Fitness last = " << Ppopulation[populationNum-1]->fitness[0] << endl;

		}

	}

	return (Winner);

}//////////////////////////

int C_EPNet::epnetDelSharedNodes(int indSelected){
	/*!
	 * function that belongs to the base class EPNet and used to called the funton to delete shared nodes
	 * in this moment only is deleted the shared hidden nodes, it is not used to delet shared inputs
	 */
	int Winner = -1;
	if ( FIXED_HIDDEN == OFF ){
		if(MYDEBUG_EPNET == 1) {        	    	cout << endl << "- - - Delete Shared (Input or hidden Node) - - -" << endl;         	    	cout << "Fitness before enter in Delete shared function = " << Ppopulation[indSelected]->fitness[0] << endl; }

		//Copy Networks
		net2->copyCleanNet(Ppopulation[indSelected]);

		//Delete Shared Nodes
		Winner = net2->deleteSharedNode(&scaleNet[0]);			// if it is not trainMultipleSets it does not matter if it is passed the addres of the network

		if(MYDEBUG_EPNET == 1){        	    	cout << "Fitness after enter in Delete shared Node = " << net2->fitness[0] << endl;         	    	cout << " Fitness last = " << Ppopulation[populationNum-1]->fitness[0] << endl; }
	}
	return Winner;
}


int C_EPNet::epnetDelConn(int indSelected){
	int Winner = -1;
	// Calculate the importance of connections and delete some of them
	if(MYDEBUG_EPNET == 1)   {      	        	cout << endl << "- - @@@@  Delete connection(s)  @@@@- - - \n" << endl; 	cout << "Fitness before enter to delete connections= " << Ppopulation[indSelected]->fitness[0] << endl;}

	//Copy Networks
	net2->copyCleanNet(Ppopulation[indSelected]);

	//Delete connections
	if (algoFeatures == SWAP_CONN)
			Winner = net2->swapConn(&scaleNet[0]);
	else
		Winner = net2->deleteCon(&scaleNet[0]);

	if(MYDEBUG_EPNET == 1){ 					cout << "Fitness after enter to delete connections= " << net2->fitness[0] << endl; 		cout << "Fitness last = " << Ppopulation[populationNum-1]->fitness[0] << endl;}

	return Winner;
}

int C_EPNet::epnetDelSharedConn(int indSelected){
	/*!
	 * Function that belongs to the base class EPNet and used to called the funton to delete shared connections
	 */
	int Winner = -1;
	if(MYDEBUG_EPNET == 1)   {      	        	cout << endl << "- - @@@@  Delete shared connection(s)  @@@@- - - \n" << endl; 	cout << "Fitness before enter to delete shared connections= " << Ppopulation[indSelected]->fitness[0] << endl;}

	//Copy Networks
	net2->copyCleanNet(Ppopulation[indSelected]);

	//Delete connections
	if (algoFeatures == SWAP_CONN)
		Winner = net2->swapConn(&scaleNet[0]); 				// I will never use this option as this function as epnetDelSharedConn is only called from algoFeatures = MODULAR1, but I leav it in case if the code is expanded in the future. to avoid erros
	else
		Winner = net2->deleteSharedCon(&scaleNet[0]);


	if(MYDEBUG_EPNET == 1){ 					cout << "Fitness after enter to delete shared connections= " << net2->fitness[0] << endl; 		cout << "Fitness last = " << Ppopulation[populationNum-1]->fitness[0] << endl;}

	return Winner;
}


int C_EPNet::epnetAddStrongCon(int indSelected){
	/*!
	 * Function that belongs to the base class EPNet and used to called the funton to add intra -module connection addition
	 */
	int Winner = -1;
	if(MYDEBUG_EPNET == 1)   {      	        	cout << endl << "- - @@@@  Add intra-module connectivity  @@@@- - - \n" << endl; 	cout << "Fitness before enter to Add intra-module connectivitys= " << Ppopulation[indSelected]->fitness[0] << endl;}

	//Copy Networks
	net2->copyCleanNet(Ppopulation[indSelected]);

	//Add intra-module connectivity
	Winner = net2->addStrongCon(&scaleNet[0]);


	if(MYDEBUG_EPNET == 1){ 					cout << "Fitness after enter to Add intra-module connectivity= " << net2->fitness[0] << endl; 		cout << "Fitness last = " << Ppopulation[populationNum-1]->fitness[0] << endl;}

	return Winner;
}




int C_EPNet::epnetDelInputs(int indSelected){
	int Winner = -1;
	if(MYDEBUG_EPNET == 1){ 				cout << endl << " %%%%% - - delete inputs - - %%%%%" << endl;      	            	cout << "Fitness before enter to add node / con = " << Ppopulation[indSelected]->fitness[0] << endl; }

	// Copy networks, allocating memory
	if(fixedinputs != FIXED && task2solve != CLASSIFY){
		net2->copyCleanNet(Ppopulation[indSelected]);
		Winner = net2->deleteInput(&scaleNet[0]);
	}
	else if (fixedinputs != FIXED && task2solve == CLASSIFY){
		net2->copyCleanNet(Ppopulation[indSelected]);
		Winner = net2->deleteInputAssymetric(&scaleNet[0]);   // In a classification task I could delete nputs in an assymetric way
	}

	return Winner;
}



int C_EPNet::epnetDelDelays(int indSelected){
	int Winner = -1;
	if(MYDEBUG_EPNET == 1){ 				cout << endl << " %%%%% - - delete delays - - %%%%%" << endl;      	            	cout << "Fitness before enter to add node / con = " << Ppopulation[indSelected]->fitness[0] << endl; }

	// Copy networks, allocating memory
	if(fixedinputs != FIXED && task2solve != CLASSIFY){
		net2->copyCleanNet(Ppopulation[indSelected]);
		Winner = net2->deleteDelay(&scaleNet[0]);
	}
	return Winner;
}




int C_EPNet::epnetAddTournament(int indSelected){
	int Winner = -1;

	// The winner replace the last network, no matter its performance
	if(MYDEBUG_EPNET == 1){ 				cout << endl << " %%%%% - - Add connection / node / delay / Input (tournament)- - %%%%%" << endl;      	            	cout << "Fitness before enter to add node / con = " << Ppopulation[indSelected]->fitness[0] << endl; }

	// Copy networks, allocating memory
	net2->copyCleanNet(Ppopulation[indSelected]);

	// Call add Nodes / connections
	if(fixedinputs == FIXED){
		if ( FIXED_HIDDEN == OFF )
			Winner = emptyNet->addNodeCon(&net2, &vecNet[0], &scaleNet[0]); // pas the addres of the net allow to modify the pointer to it and return it automatically
		else{
			if (algoFeatures == SWAP_CONN)
				Winner = net2->swapConn(&scaleNet[0]);
			else
				Winner = net2->addCon(&scaleNet[0]);				// if the hidden nodes are fixed
		}
	}
	else{																								// useful if the size of the net changes inside the function
		if ( FIXED_HIDDEN == OFF )
			Winner = emptyNet->addIDHC(&net2,&vecNet[0], &scaleNet[0]);
		else
			Winner = emptyNet->addIDC(&net2,&vecNet[0], &scaleNet[0]);				// hidden nodes are fixed
	}

	if( Winner > 0 ){
		if (MYDEBUG_EPNET == 1)  cout << "Last network replaced by function addNodeCon or  addIDHC, check ahead to now more"<< endl << endl;
		Ppopulation[populationNum-1]->copyCleanNet(net2);
	}

	return Winner;
}




void C_EPNet::printPop(){
	for(int i=0; i<populationNum; i++)
	{
		cout << endl << "...NETWORK[" << i << "]..." << endl;
		Ppopulation[i]->print();
	}
}

void C_EPNet::printPopFit(void){
	cout << endl << "Population Fitness" << endl;
	for(int i=0; i<populationNum; i++)
		cout << "Fitness[" << i << "]= " << Ppopulation[i]->fitness[0] << endl;
}




void C_EPNet::save2file(char filetemp[], char ext[]){
	/*!
	 * Function C_EPNet::save2file
	 * This function is in charge to save all the information of the program
	 * As the epnet structure has all the information here is save into a file,
	 * each one with the name of the independent run
	 */

    // save the global variables and others in the CONFiIG file
    save2fileCONFIG(filetemp);

    // Save all the classes, ALLParam, Population
    save2fileCLASSES(filetemp, ext);

    // Save individuals in the populaiton (the whole network)
    if (saveNets2beReloaded == ON)
    	save2fileNETWORKS(filetemp);

    // Save modules
    if (saveModulesINpool == ON && ( algoFeatures ==MODULAR1  || algoFeatures == MR_EPNET))
    	save2fileMODULES(filetemp);


    /*!
     * S A V E   M O D U L E S
     * Section to save the individual modules of each network into independent files
     * Thus, it may be possiblt to reload them for their reuse during evolution with the MR_EPNET algorithm
     *
     * Format
     * 		j indicate the data set to solve
     * 		i indicate the sub-task or module for the dats set 'j'
     * 		r1,r2, indicate the run the module was obtained
     *
     * 	Final Format
     * 		rk_jMi
     */
/*
        if (saveModulesINpool == ON){
        	// some local variables
        	int ind, module;
        	string filePath = "../pool/";
        	string fileM = "M"; 	//fileNet = "resPop/";
        	string dataSet = ""; 										// there is a list of data set and ther correspondient number in the file CONS.hpp
        	string subtask = "";

        	string fileFinal = "";

        	//

        	fileM = fileNet + filetemp + "Net"; 			// resPop/r1
        	char strInd[3];
        	char strMod[3];

        	int n;

        	 // In this moment just save the modules of the best individual
        	for( ind=0; ind<1; ind++){
        		for ( module = 0; module < NUM_MODULES; module++ ){
        			// Create the name of the file to be saved

        			// convert i to string
        			n = sprintf (strInd, "%d", ind+1);
        			n = sprintf (strMod, "%d", ind+1);
        			fileFinal = filePath + filetemp;

        		// create final name for the network to be save
        		fileFinal = fileNet + strTemp + ".txt";

        		// Create the file pointer
        		if ((fwriteNum = fopen(fileFinal.c_str() , "w")) == NULL){
        			printf("Error can not open the file '%s' for writing...\n",fileFinal.c_str() );
        		}

        		// save each individual whit a different name
        		Ppopulation[i]->save2fileSingleNet(fwriteNum, (char *) fileFinal.c_str() );

        		cout << "Network saved::: " << fileFinal << endl;

        		// Close the file
        		fclose(fwriteNum);
        	}
        } // end if to save networks to be reloaded

*/

}/////////////////////////////////////////////////////////////////////////////////////////







void C_EPNet::save2fileCONFIG(char fileNum[]){
/*!
 * Save global Variables
 * They are saved in the config file, fwriteNum is the variable that is used to oipen this file and the rest of the variables
 *
 * In the past only the first run use to save the value of the cong.txt file, which contain the global variables, constants and variables that determinate
 *	 the existence of other variables, among others
 *	The code is updates and here any run can save such file, the first that finish will be the one that save them, for any run this are the same parameters
 *	so there is no problem which one save the values
 *
 */

	// Local variables
	FILE *fwriteNum;

	//  Check if the file is present
	if (FileExists("res/config.txt") == false ){ 					// if does not exist, thne we can write on it
		// origianl line // if(strcmp(filetemp,"r1")==0){ 			// only save the first run

		if ((fwriteNum = fopen("res/config.txt" , "w")) == NULL){
			printf("Error can not open the file '%s' for writing...\n", "res/config.txt");
		}    //Only check for the second error, implement in c++ the rest of exeption handling

		// CONSTANT VARAIBALES
		// +++++++++++++++++++++++++++++++++++++++++++++++++

		// PREDICT = 0;
		fprintf(fwriteNum, "%d\t",PREDICT);
		//CLASSIFY = 1;
		fprintf(fwriteNum, "%d\t",CLASSIFY);

		// Different algorithms implemnted to evolve the features
		// HIERARQUICAL = 0;
		fprintf(fwriteNum, "%d\t",HIERARQUICAL);
		// TOURNAMNET = 1;
		fprintf(fwriteNum, "%d\t",TOURNAMNET);
		// CO_EVO = 2;
		fprintf(fwriteNum, "%d\t",CO_EVO);
		// ASSYMETRIC = 3;
		fprintf(fwriteNum, "%d\t",ASYMMETRIC);
		//  MODULAR1 = 4
		fprintf(fwriteNum, "%d\t",MODULAR1);
		//  MLP1 = 5
		fprintf(fwriteNum, "%d\t",SWAP_CONN);
		//
		fprintf(fwriteNum, "%d\t",MR_EPNET);

		// MBP = 1;
		fprintf(fwriteNum, "%d\t",MBP);
		// SA =  2;
		fprintf(fwriteNum, "%d\t",SA);
		// SUCCESS = 1;
		fprintf(fwriteNum, "%d\t",SUCCESS);
		// FAILURE = 0;
		fprintf(fwriteNum, "%d\t",FAILURE);
		// TRAIN_INSIDE = 0;
		fprintf(fwriteNum, "%d\t",TRAIN_INSIDE );
		// TRAIN_OUTSIDE = 1;
		fprintf(fwriteNum, "%d\t",TRAIN_OUTSIDE );
		// BAND = -1;		//values to check for error when saving, related when is loaded into Matlab
		fprintf(fwriteNum, "%d\t",BAND);


		// ON = 1;
		fprintf(fwriteNum, "%d\t",ON );
		// OFF = 0;
		fprintf(fwriteNum, "%d\t",OFF );

		// kind of prediction
		// MSP = 0;
		fprintf(fwriteNum, "%d\t",MSP);			// multi-step prediction
		// SSP = 1;
		fprintf(fwriteNum, "%d\t",SSP );			// single-step prediction

		// Evolution of features
		// EVOLVE = 0;
		fprintf(fwriteNum, "%d\t",EVOLVE );
		// FIXED = 1;
		fprintf(fwriteNum, "%d\t",FIXED);
		// FIX_EVOvra = 2;
		fprintf(fwriteNum, "%d\t",FIX_EVOvra );

		// Tranfer functions
		fprintf(fwriteNum, "%d\t",HTAN);
		// SIGMOID
		fprintf(fwriteNum, "%d\t",SIGMOID );
		// LINEAL
		fprintf(fwriteNum, "%d\t",LINEAL );

		// Modules
		fprintf(fwriteNum, "%d\t",MODULES );

		if((fprintf(fwriteNum, "%d\t",BAND)) == EOF){
			printf("Error writing to file '%s'...\n",fileNum); exit(0);
		}
		// +++++++++++++++++++++++++++++++++++++++++++++++++


		//  Variables the determinate the existance of other variables
		// ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo

		// Prediction or classification
		fprintf(fwriteNum, "%d\t",task2solve);

		// to know if the esemble part was executed
		fprintf(fwriteNum, "%d\t",RunEnsemble);

		//trainMultipleSets
		fprintf(fwriteNum, "%d\t",trainMultipleSets);

		//extraPredictions
		fprintf(fwriteNum, "%d\t",extraPredictions);

		//algoFeatures 				(tournament, hierarquical, ....)
		fprintf(fwriteNum, "%d\t",algoFeatures);

		// output denormalized
		fprintf(fwriteNum,"%d\t", outputDenormalized);

		// How many individual are saved from the population
		fprintf(fwriteNum,"%d\t", saveNumIndividual);

		// Is it saved each network form the population to let them be reloaded in the future and continue the evolution
		fprintf(fwriteNum,"%d\t", saveNets2beReloaded);

		// Is it saved each network form the population to let them be reloaded in the future and continue the evolution
		fprintf(fwriteNum,"%d\t", saveModulesINpool);

		// module1
		fprintf(fwriteNum,"%d\t", isModule1);

		// to indicate if the inputs are considered into the modularity
		fprintf(fwriteNum,"%d\t", considerInputsInMod);

		// Evolve learning rate per module
		fprintf(fwriteNum,"%d\t", evolveLrate);

		// Dual weights
		fprintf(fwriteNum,"%d\t", isDualWeights);


		// reuse Module
		fprintf(fwriteNum,"%d\t", reuseModule);



		fprintf(fwriteNum, "%d\t",BAND);
		///////////////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////
		/////////////////////

		if((fprintf(fwriteNum, "%d\t",epochsK[0])) == EOF){
			printf("Error writing to file '%s'...\n",fileNum); exit(0);
		}
		fprintf(fwriteNum, "%d\t",epochsK[1]);

		fprintf(fwriteNum, "%d\t",transferFunOutput);
		fprintf(fwriteNum, "%d\t",transferFunHidden);

		// Validation
		fprintf(fwriteNum, "%d\t",useValidation);
		fprintf(fwriteNum, "%d\t",valiAuto);
		fprintf(fwriteNum, "%g\t",sizeValiAutoPercentage);
		fprintf(fwriteNum, "%d\t",sizeVali);
		fprintf(fwriteNum, "%d\t",useValidationOutside);

		//// int sizetpos;  ////
		fprintf(fwriteNum, "%d\t",sizetpos);
		//// int success Training parameter ////
		fprintf(fwriteNum, "%g\t",STP);
		fprintf(fwriteNum, "%d\t",fileline);
		fprintf(fwriteNum, "%d\t",filecol);
		fprintf(fwriteNum, "%d\t",fixedinputs);
		//cout << "fixedinputs = " << fixedinputs << endl;

		fprintf(fwriteNum, "%d\t",Corridas);
		fprintf(fwriteNum, "%d\t",populationNum);
		fprintf(fwriteNum, "%d\t",expectedGenerations); 				// Thia are the expected generations
		fprintf(fwriteNum, "%d\t",maxdata);
		fprintf(fwriteNum, "%d\t",Pred_stepAhead);
		fprintf(fwriteNum, "%d\t",Pred_stepAheadInside);
		fprintf(fwriteNum, "%d\t",DeltaT);
		fprintf(fwriteNum, "%d\t",kindPred);

		fprintf(fwriteNum, "%d\t",numDiffPredict);
		fprintf(fwriteNum, "%d\t",initialStepPred);
		fprintf(fwriteNum, "%d\t",incremenInData);

		// save the minimum values
		fprintf(fwriteNum, "%d\t",minInp);
		fprintf(fwriteNum, "%d\t",minDelay);
		fprintf(fwriteNum, "%d\t",minHid);

		// save the minimum values
		fprintf(fwriteNum, "%d\t",maxInputs);
		fprintf(fwriteNum, "%d\t",maxDelays);
		fprintf(fwriteNum, "%d\t",maxHidden);

		fprintf(fwriteNum, "%d\t",noOutputs);
		fprintf(fwriteNum, "%f\t",(double)smallW);
		fprintf(fwriteNum, "%f\t",(double)momentum1);
		fprintf(fwriteNum, "%f\t",(double)lrate1);

		/*fprintf(fwriteNum, "%d\t",minmutateN);
			fprintf(fwriteNum, "%d\t",mutatednodes);
				fprintf(fwriteNum, "%d\t",mutatedcon);
			fprintf(fwriteNum, "%f\t",(double)initDensity);
	    	 */
		fprintf(fwriteNum, "%d\t",temperature);
		fprintf(fwriteNum, "%f\t",(double)mintemp);
		fprintf(fwriteNum, "%d\t",iterationTemp);
		fprintf(fwriteNum, "%f\t",(double)YMIN);
		fprintf(fwriteNum, "%f\t",(double)YMAX);
		fprintf(fwriteNum, "%d\t",stopAlpha);
		fprintf(fwriteNum, "%d\t",strip);
		/// Put a band to look for error  //finish headers
		if((fprintf(fwriteNum, "%d\t",BAND)) == EOF){
			printf("Error writing to file '%s'...\n",fileNum); exit(0);
		}

		//////////////////// variables from main /////////////////////////////

		// save special variables that are not saved from predParam

		// save the information from any individual, all are the same
		if(extraPredictions == ON){
			//int cont = initialStepPred;

			for(int i=0; i < numDiffPredict; i++){
				saveD(Ppopulation[0]->set2MSP[i].toPredict, Ppopulation[0]->set2MSP[i].linesT, Ppopulation[0]->set2MSP[i].colsT, fwriteNum, fileNum);
				//  				cont *= 2;
			}
		}

		saveD(Ppopulation[0]->predictI->toPredict, sizetpos,Pred_stepAheadInside, fwriteNum, fileNum);
		saveD(Ppopulation[0]->predictF->toPredict, sizetpos,Pred_stepAhead, fwriteNum, fileNum);


		/// Put a band to look for error  //finish headers
		if((fprintf(fwriteNum, "%d\t",BAND)) == EOF){
			printf("Error writing to file '%s'...\n","conf,txt"); exit(0);
		}

		// Close the file
		fclose(fwriteNum);
	}	// End if save these values for the conf.txt run
} // End method to save the CONFIG.txt file




void C_EPNet::save2fileCLASSES(char filetemp[], char ext[]){
	/*!
	 *
	 * Section for all classes, ALLParam, Popolation, Ensembles (GECCO09 paper)
	 *
	 */

	// Local vars
	char fileNum[BUFSIZ];
	FILE *fwriteNum;

	//res/r*ALLNum.txt
	strcpy(fileNum,"res/");
	strcat(fileNum,filetemp);        	// res/r1
	strcat(fileNum,"ALLNum");         	// res/r1ALLNum
	strcat(fileNum,ext);  				//res/r1ALLNum.txt


	//Started to save the global variables
    if ((fwriteNum = fopen(fileNum , "w")) == NULL){
    	printf("Error can not open the file '%s' for writing...\n",fileNum);
    }    //Only check for the second error, implement in c++ the rest of exeption handling


    // Save the total generations used
    fprintf( fwriteNum, "%d\t",Generation );

    // Save time
    fprintf(fwriteNum, "%f\t",cpu_time_used());



    //// Start to save the CLASSES ////
   ALLParam->save2file(fwriteNum, fileNum, Generation);

    if( algoFeatures == CO_EVO)
    	ALLParam2->save2file(fwriteNum, fileNum, Generation);


    //Save all the population or the number of individulas specified
    for(int i=0; i<saveNumIndividual; i++){
    	Ppopulation[i]->save2file(fwriteNum, fileNum);
    }
    // For the Coevo it is not saved the second population


    /// Put a band to look for error
    if((fprintf(fwriteNum, "%d\t",BAND)) == EOF){
    	printf("Error writing to file '%s'...\n",fileNum); exit(0);
    }

    //// Save variables for ensembles ////
    if(RUN_ENSEMBLE == 1){
    	//Average
    	ensemble->save2fileAv(fwriteNum, fileNum);
    	//RBLC
    	ensemble->save2fileRBLC(fwriteNum, fileNum);

    	/// Put the last band to look for error
    	if((fprintf(fwriteNum, "%d\t",BAND)) == EOF){
    		printf("Error writing to file '%s'...\n",fileNum); exit(0);
    	}
	}

    // Close the file
    fclose(fwriteNum);

}





void C_EPNet::save2fileNETWORKS(char filetemp[]){
	/*!
    * Section to save the individual networks from the population to independent files
    * This is in case you may want to reload them to continuie the evolution
    *
    * Aloso they can be saven to reuse networks, e.g. save tasl A1-B1, then reload and solve task A1-B1-c1
    */

   	// some local variables
	FILE *fwriteNum;
   	string fileNet = toSavePop;
   	string fileFinal;
   	fileNet = fileNet + filetemp + "Net"; 			// resPop/r1
   	char strTemp[3];
   	int n;

   	 // Save all the population in separate files
   	for(int i=0; i<populationNum; i++){
   		// convert i to string
   		n = sprintf (strTemp, "%d", i+1);

   		// create final name for the network to be save
   		fileFinal = fileNet + strTemp + ".txt";

   		// Create the file pointer
   		if ((fwriteNum = fopen(fileFinal.c_str() , "w")) == NULL){
   			printf("Error can not open the file '%s' for writing...\n",fileFinal.c_str() );
   		}

   		// save each individual whit a different name
   		Ppopulation[i]->save2fileSingleNet(fwriteNum, (char *) fileFinal.c_str() );

   		cout << "Network saved::: " << fileFinal << endl;

   		// Close the file
   		fclose(fwriteNum);
   	}
}// end if to save networks to be reloaded


void C_EPNet:: save2fileMODULES(char filetemp[] ){
	/*!
	 * S A V E   M O D U L E S
	 * Section to save the individual modules of each network into independent files
	 * Thus, it may be possiblt to reload them for their reuse during evolution with the MR_EPNET algorithm
	 *
	 * Inuts:
	 * 		filetemp 			is the number of run, e.g. r1, r2, ...
	 * Format
	 * 		j indicate the data set to solve
	 * 		i indicate the sub-task or module for the dats set 'j'
	 * 		r1,r2, indicate the run the module was obtained
	 *		ind is the number of the individual in the population, so it could be save all module of all individual from all runs
	 *
	 * 	Final Format
	 * 		rk_jMi_indx,				k,j,i,x are numerical values
	 */

	// local variables
	//FILE *fwriteNum;

	int ind, module, n;

	string filePath = "../pool/";
	string fileM = "M"; 	//fileNet = "resPop/";
	//string dataSet = ""; 										// j value ...there is a list of data set and ther correspondient number in the file CONS.hpp
	string subtask = "";
	string fileFinal = "";

	// Declarate variables that use a convertion form int to char
	char strInd[3];
	char strMod[3];
	char dataSet[3];

	// convert number data set to string
	n = sprintf (dataSet , "%d", DSnumber); 				// DSnumberis a global var, defined in conf.hpp

	// In this moment just save the modules of the best individual (in other moment use populationNum)
	for( ind=0; ind<saveMod_ind; ind++){
		n = sprintf (strInd, "%d", ind);

		for ( module = 0; module < NUM_MODULES; module++ ){
			n = sprintf (strMod, "%d", module);

			// Create the name of the file to be saved
			fileFinal = filePath + filetemp + "_" + dataSet + fileM + strMod + "_ind" + strInd;
			cout << fileFinal << endl;

			// save each module from each individual in the populaiton, shaed modules or a module with isolated nodes is not taken into account
			Ppopulation[ind]->save2fileModule(module+1, fileFinal, &vecNet[0]); 			// module+1 because the name of the modules start in 1
		/*
   		// save each individual whit a different name
    		Ppopulation[i]->save2fileSingleNet(fwriteNum, (char *) fileFinal.c_str() );
    		cout << "Network saved::: " << fileFinal << endl;
   		      		*/
    	}
    } // end if to save networks to be reloaded


}// End save modules funciton



void C_EPNet::trainPopMultiScales(int where, C_network **scalesNet){
	if (where == TRAIN_INSIDE){
		for(int i=0; i<populationNum; i++){
			// copy all scales before training
			Ppopulation[i]->copyALLscales(&scalesNet[0]);		// copy the i network to all scales and update data sets

			// Train the network with all scales selected in the mainepnet.hpp file
			Ppopulation[i]->trainScales(&scalesNet[0], epochsK[TRAIN_INSIDE], TRAIN_INSIDE);
			//Ppopulation[i]->trainMBP(epochsK[TRAIN_INSIDE],TRAIN_INSIDE);

			// Set to success to all the networks
			Ppopulation[i]->status[0] = SUCCESS;
		}
	}
	else if (where == TRAIN_OUTSIDE){
		for(int i=0; i<populationNum; i++){

			// copy all scales before training
			Ppopulation[i]->copyALLscales(&scalesNet[0]);		// copy the i network to all scales and update data sets
			// Train the network with all scales selected in the mainepnet.hpp file
			Ppopulation[i]->trainScales(&scalesNet[0], epochsK[TRAIN_OUTSIDE], TRAIN_OUTSIDE);

		}
	}
}/////////////////////////////////////////////////////////////////////////////////////////

void C_EPNet::trainPop(int where){
	/*!
	 * Train all the population
	 * This fuction could be used too, to save the error per epochs. It should not be used that in a normal evolution because in every trianing
	 * it will write to disk
	 */

	// Local variable to save error per epochs
	//  Comment them if not used because in the normal evolution it will write to disk every trainiing n times where n is the number of epochs
	// The rest of the varibales to comment uncomment are in mainepnet.hpp, and Cnetwork class in complexES
	/*int n;
	string toSave;
	//string toSave2;
	string strExt = ".txt";
	string str_InitPart = "res/epochsNet";
	string str_InitPart2 = "res/lrateNet";
	string str_InitPart3 = "res/EpPerModule";
	char strTemp[3];
	lratePERepochs = allocate(lratePERepochs, epochsK[0]);
	lratePerModule = allocate(lratePerModule, NUM_MODULES, epochsK[0]);
	ErrorPerModule = allocate(ErrorPerModule, NUM_MODULES, epochsK[0]);
*/
	// Normal procedure
	if (where == TRAIN_INSIDE){
		for(int i=0; i<populationNum; i++){

			// comment next line, Clean the lrated per epochs (To save error per epochs )
			// set(lratePERepochs, epochsK[0], 0);

			Ppopulation[i]->trainMBP(epochsK[TRAIN_INSIDE],TRAIN_INSIDE);
			Ppopulation[i]->status[0] = SUCCESS;															// Set to success to all the networks

			/*
			// Use these lines of you want to save the error per epochs, if not comment them
			n = sprintf (strTemp, "%d", i+1); 			cout << "strTemp = " << strTemp << endl;

			// Ep per epochs
			toSave =  str_InitPart + strTemp + strExt; 				cout << "toSave = " << toSave << endl;
			saveD( (char *)(toSave.c_str()), Ppopulation[i]->Epochs->Eval, epochsK[0] );

			// learning rate
			toSave =  str_InitPart2 + strTemp + strExt; 				cout << "toSave lrate = " << toSave << endl;
			//saveD( (char *)(toSave.c_str()), lratePERepochs, epochsK[0] ); 				// learning rate for al network
			saveD( (char *)(toSave.c_str()), lratePerModule,NUM_MODULES,  epochsK[0] ); 				// learning rate per module

			// Ep per module
			toSave =  str_InitPart3 + strTemp + strExt; 				cout << "toSave lrate = " << toSave << endl;
			saveD( (char *)(toSave.c_str()), ErrorPerModule, NUM_MODULES, epochsK[0] );
*/
		}
	}
	/*
	// liberate memory, error per epochs
	safefree(&lratePERepochs);
	safefree(&lratePerModule,NUM_MODULES);
	safefree(&ErrorPerModule,NUM_MODULES);
	// comment next else if the error per epochs is used, because the final training overwrite the error measured before
	*/
	else if (where == TRAIN_OUTSIDE){
		//Train the final population

		if ( restartWeight_afterEvolution == ON ){

			if (reuseModule == ON){
				cout << "Function C_EPNet::trainPop error, yo are reusing modules and activated the flag  restartWeight_afterEvolution" << endl;
				cout << "It has not been updated this function ot load networks, exit and change flag restartWeight_afterEvolution <- OFF " << endl;
				cout << " ... or update funtion and run again" << endl;
				exit(0);
			}

			C_network *net1;
			if ( fitness_learnQuick2Genaralize == ON )
				net1 = new C_net_quickLearning(0,  (char*)"0", INPUTF.c_str());
			else
				net1 = new C_network(0,  (char*)"0", INPUTF.c_str());

			///////// Train all the networks whit the last test set /////////
			cout << " **Training all Networks of the final population **** A copy of the network is created to restart weights" << endl;

			for(int i=0; i<populationNum; i++){
				Ppopulation[i]->trainMBP(epochsK[TRAIN_OUTSIDE],TRAIN_OUTSIDE);

				//condition to determinate if re-start the weight for the bestnetwork
				if(Ppopulation[i]->fitness[0] > 0.5){
					if (MYDEBUG_FINAL_TRAIN == ON) 						cout << endl << "Creat a copy (NET1) and restart weights, then train again to see if there is an improvement, the network is in the position" << i << endl;

					net1->copyCleanNet(Ppopulation[i]);
					net1->initweights();     																// initialize the weights
					net1->trainMBP(epochsK[TRAIN_OUTSIDE],TRAIN_OUTSIDE);

					if(net1->fitness[0] < Ppopulation[i]->fitness[0]){
						if (MYDEBUG_FINAL_TRAIN == ON) 		            	cout << "net1 replace a network in population" << endl;

						Ppopulation[i]->copyNet(net1);
					}
				}
			}
			delete(net1);
			net1 = NULL;

		} /////////// finihs if restartWeight_afterEvolution == ON
		else{
			///////// Train all the networks whit the last test set /////////
			cout << " **Training all Networks of the final population **" << endl;
			for(int i=0; i<populationNum; i++)
				Ppopulation[i]->trainMBP(epochsK[TRAIN_OUTSIDE],TRAIN_OUTSIDE);
		}


		cout << endl << "- - -  End - Training all Network of the final population" << endl;

	}
}/////////////////////////////////////////////////////////////////////////////////////////


void C_EPNet::rankk(void){
	//Arrange the individual given their fitness
	register int i,j;
	C_network *tempN;
	for(i=0; i<populationNum; i++){
		for(j=i+1; j<populationNum; j++){
			if( (Ppopulation[i]->fitness[0] > Ppopulation[j]->fitness[0]) || isnan( Ppopulation[i]->fitness[0] ) ){
				tempN = Ppopulation[i];
				Ppopulation[i] = Ppopulation[j];
				Ppopulation[j] = tempN;
			}
		}
	}

	tempN = NULL;
}/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////






/*
//Function to select one individual from the population
int C_EPNet::selection(double **probability)
{
    register int j;
    int acepted = populationNum-1;
    double temprand = rando();

    //Selec one individual
    if(temprand <= probability[1][0])
        acepted = 1;
    else{
        for(j=1; j<populationNum; j++){
            if((temprand > probability[1][j-1]) && (temprand <= probability[1][j]))
                acepted = j;
        }
    }
    return(acepted);
}/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
*/






//obtain and save averages values per generation
void C_EPNet::saveAllparam(int Gen, int selec)
{
	ALLParam->saveAllperGen(Gen, selec, Ppopulation);

}//////////////////////////////////////////////////////////////////////////////////




void C_EPNet::trainPopFinal(){
	//Train the final population

	C_network *net1;
	net1 = new C_network(0,  (char*)"0", INPUTF.c_str());

	///////// Train all the networks whit the last test set /////////
    cout << " **Training all Networks of the final population **" << endl;

    for(int i=0; i<populationNum; i++){
    	Ppopulation[i]->trainMBP(epochsK[TRAIN_OUTSIDE],TRAIN_OUTSIDE);
    	Ppopulation[i]->trainingWith[0] = MBP;

    	//condition to determinate if re-start the weight for the bestnetwork
    	if(Ppopulation[i]->fitness[0] > 0.5){

			#ifdef MYDEBUG_FINAL_TRAIN
				cout << "Creat a copy (NET1) and restart weights, then train again to see if there is an improvement, the network is in the position" << i << endl;
			#endif

			net1->copyCleanNet(Ppopulation[i]);
			net1->initweights();     //initialize the weights

            net1->trainMBP(epochsK[TRAIN_OUTSIDE],TRAIN_OUTSIDE);
            net1->trainingWith[0] = MBP;

            #ifdef MYDEBUG_FINAL_TRAIN
				cout << "NET1 trained with MBP,...IterateNRMMSE F =" << net1->fitness[0] << endl;
            #endif

            if(net1->fitness[0] < Ppopulation[i]->fitness[0]){
			#ifdef MYDEBUG_FINAL_TRAIN
            	cout << "net1 replace a network in population" << endl;
			#endif
            	Ppopulation[i]->copyNet(net1);
            }
    	}
    }
    delete(net1);
    net1 = NULL;
    cout << endl << "- - -  End - Training all Network of the final population" << endl;
}////////////////////////////////////////////////////////////////////////////////////////



int C_EPNet::stopEPNet(int gen, double *prevFit,  double fitness, double *prevClassE, double classifError ){
	/*!
	 * Function to stop the generation of the EPNet
	 * intputs
	 * 	gen 			the actual generation
	 * prevFit 	previous fitness taken n stopGenStrip, the latter is a global variable
	 * fitness 		fitness of the best individual in the population
	 * prevClassE 	previous calssifiaction error taken n  stopGenStrip
	 * classifError 	classification error of the best individual in the actual generation
	 *
	 * Output
	 * 1 or 0 	indicating if the Genrations are finished
	 */

	if (gen == 0){
		prevFit[0] = fitness;
		if ( task2solve == CLASSIFY && ( strcmp( typeDS.c_str(), "NRMSE" ) != 0) )
			prevClassE[0] = classifError;
	}
	else if ( gen % stopGenStrip == 0 ){
		// Check the fitness first
		if ( fitness <  prevFit[0] ) 			// if the fitness of the best was reduced
			prevFit[0] = fitness;
		else																					// if not exit
			return (1);


		// Now check classification error, maybe it reaches zero, even if the error is not zero

		if ( task2solve == CLASSIFY  && (  classifError < prevClassE[0] ) ){ 	// if the class error was reduced
			if ( strcmp( typeDS.c_str(), "NRMSE" ) != 0){
				if ( classifError < prevClassE[0] )
					prevClassE[0] = classifError;
				else
					return (1); 					// exit
			}
		}
	}

	// in case of classification check every epoch if the best reached perfent prediciton

	if ( task2solve == CLASSIFY  && ( strcmp( typeDS.c_str(), "NRMSE" ) != 0)  && (gen > 5) ){
		if ( classifError == 0){
			cout << "Best classify correctly all patterns of the validation set" << endl << "classificaiton error = " << classifError << endl;
			cout << "Error Percentage = " <<   fitness << endl;
			cout << endl << "Finish generations ................" << endl;
			return (1); 					// exit
		}

	}

	// If arrive until here it means not exit
	return (0);
}// End stop EPNet


int C_EPNet::stopEPNet_byModules(int gen, double *fitperMod,  int module1, int module2){
	/*!
	 * Function to stop the generation of the EPNet determined by the fitness of two modules
	 * intputs
	 * 	gen 			the actual generation
	 * fitperMod the fitness off all modules in all generations
	 * module1 	index of module 1, correspond to the lines in fitPerMod
	 * module2 	second index for the second module, this is the one that must improve the error of the module one to finish
	 *
	 * Output
	 * 1 or 0 	indicating whether the genrations are finished
	 */
	/*if (flagDebug == ON){
		cout << endl << " -------- Check Stopping Criteria by modules  --------" << endl;
		cout << "Error mod1 = " << fitperMod[module1] << ", error mod2 = " << fitperMod[module2] << endl;
		cout << endl;
	}

	if ( fitperMod[module2] <= fitperMod[module1] )
		return (1);
	else
	*/
		return (0);

}// End stop EPNet by module performance


/*void C_EPNet::obtainProb(double ** prob){
	//Use the rank base to calculate the probabilities
	int i;
	double tempsum =0;

	set(prob,2,populationNum,0); // clear values

	//Obtain the total sum from all individual
	for(int i=0; i<populationNum; i++)
			tempsum+= i+1;

	//Obtain probabilities
	for(i=0; i<populationNum; i++){
		prob[0][i] = (i+1)/tempsum;
		if(i==0)
			prob[1][i] = (i+1)/tempsum;
		else
			prob[1][i] = prob[1][i-1] + prob[0][i];
	}
	//imprime(prob,2,populationNum);

}*/



//Calculate the ensemble output with Average ensemble from the networks or the last generation
void C_EPNet::averageEnsemble(){
    //calculate the output with the average
 /*   register int i,j;
    double *mean = (double *) malloc(sizetpos*sizeof(double));

	#ifdef MYDEBUG
		cout << "Enter to ensembleAverage..." << endl;
	#endif

    for(i=0; i<populationNum; i++){
        for(j=0; j<Pred_stepAhead; j++){
            ensemble->Average->Pred[0][j] += Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
        }
    }
    for(j=0; j<Pred_stepAhead; j++){
        ensemble->Average->Pred[0][j] /= populationNum;
    }

     fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean);
     //cout << "In function AverageENsemble Mean =" << endl; imprime(mean,sizetpos);
     nrmse(ensemble->Average->Pred, sets->toPredictFn, mean, ensemble->Average->NRMSE);
     //cout << "Nrmse = " << ensemble->Average->NRMSE[0] << endl;
     accuracy(ensemble->Average->Pred, sets->toPredictFn, ensemble->Average->accuracyPoint, ensemble->Average->accuracy);

     safefree(&mean);
     */
}//////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////



void C_EPNet::RBLCEnsemble(){
	//Calculate the ensemble output with RBLC ensemble from the networks of the last generation
/*
	register int i,j;
    double *mean = (double *) malloc(sizetpos*sizeof(double));
    double sumBeta = 0;
    double minimo, nrmsMin;

	#ifdef MYDEBUG
		cout << "Enter to ensembleRankBLC..." << endl;
	#endif
    /// FOR 0.05 /////////////////////////////////////////////////////////////////////////////////////////
    for(i=0; i<populationNum; i++){
        sumBeta += exp(beta_05*(i+1));   //sum^{N}_{j=1}exp(beta*j)
    }
    // Calculte weights for the networks
    for(i=0; i<populationNum; i++){
    	ensemble->weightsRankBase_05[i] = (exp(beta_05*(populationNum + 1 - (i+1)))) / sumBeta;  //w_{i} = (exp(beta*(N+1-i))) / (sum^{N}_{j=1}exp(beta*j))
    }
    //calculate the output
    for(i=0; i<populationNum; i++){
        for(j=0; j<Pred_stepAhead; j++){
        	ensemble->SRank_base_LCombination_05->Pred[0][j] += ensemble->weightsRankBase_05[i] * Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
        }
    }
    //Obtain the rest of the parameters
    fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean);
    nrmse(ensemble->SRank_base_LCombination_05->Pred, sets->toPredictFn, mean, ensemble->SRank_base_LCombination_05->NRMSE);
    accuracy(ensemble->SRank_base_LCombination_05->Pred, sets->toPredictFn, ensemble->SRank_base_LCombination_05->accuracyPoint, ensemble->SRank_base_LCombination_05->accuracy);
    minimo = 0.05;
    nrmsMin = ensemble->SRank_base_LCombination_05->NRMSE[0];

    // FOR 0.1 //////////////////////////////////////////////////////////////////////////////////////////

    set(mean,sizetpos, 0);
    sumBeta = 0;
    // Calculte weights for the networks
    for(i=0; i<populationNum; i++){
        sumBeta += exp(beta_1*(i+1));   //sum^{N}_{j=1}exp(beta*j)
    }
    for(i=0; i<populationNum; i++){
    	ensemble->weightsRankBase_1[i] = (exp(beta_1*(populationNum + 1 - (i+1)))) / sumBeta;  //w_{i} = (exp(beta*(N+1-i))) / (sum^{N}_{j=1}exp(beta*j))
    }
    //calculate the output
    for(i=0; i<populationNum; i++){
        for(j=0; j<Pred_stepAhead; j++){
            ensemble->SRank_base_LCombination_1->Pred[0][j] += ensemble->weightsRankBase_1[i] * Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
        }
    }
    //Obtain the rest of the parameters
    fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean); //printf("in function Mean ====\n"); imprimeVd(mean,sizetpos);
    nrmse(ensemble->SRank_base_LCombination_1->Pred, sets->toPredictFn, mean, ensemble->SRank_base_LCombination_1->NRMSE);
    accuracy(ensemble->SRank_base_LCombination_1->Pred, sets->toPredictFn, ensemble->SRank_base_LCombination_1->accuracyPoint, ensemble->SRank_base_LCombination_1->accuracy);
    if(ensemble->SRank_base_LCombination_1->NRMSE[0] < nrmsMin){ //only works with 1 value
        minimo = 0.1;
        nrmsMin = ensemble->SRank_base_LCombination_1->NRMSE[0];
     }

    /// FOR 0.15 /////////////////////////////////////////////////////////////////////////////////////////

    set(mean,sizetpos, 0);
    sumBeta = 0;
    // Calculte weights for the networks
    for(i=0; i<populationNum; i++){
        sumBeta += exp(beta_15*(i+1));
    }
    for(i=0; i<populationNum; i++){
    	ensemble->weightsRankBase_15[i] = (exp(beta_15*(populationNum + 1 - (i+1)))) / sumBeta;
    }
    //calculate the output
    for(i=0; i<populationNum; i++){
        for(j=0; j<Pred_stepAhead; j++){
            ensemble->SRank_base_LCombination_15->Pred[0][j] += ensemble->weightsRankBase_15[i] * Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
        }
    }
    //Obtain the rest of the parameters
    fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean);
    nrmse(ensemble->SRank_base_LCombination_15->Pred, sets->toPredictFn, mean, ensemble->SRank_base_LCombination_15->NRMSE);
    accuracy(ensemble->SRank_base_LCombination_15->Pred, sets->toPredictFn, ensemble->SRank_base_LCombination_15->accuracyPoint, ensemble->SRank_base_LCombination_15->accuracy);
    if(ensemble->SRank_base_LCombination_15->NRMSE[0] < nrmsMin){ //only works with 1 value
        minimo = 0.15;
        nrmsMin = ensemble->SRank_base_LCombination_15->NRMSE[0];
     }

    /// FOR 0.2 //////////////////////////////////////////////////////////////////////////////////////////

    //calculate the output with the Rank-base Linear Combination
    set(mean,sizetpos, 0);
    sumBeta = 0;
    // Calculte weights for the networks
    for(i=0; i<populationNum; i++){
        sumBeta += exp(beta_2*(i+1));
    }
    for(i=0; i<populationNum; i++){
    	ensemble->weightsRankBase_2[i] = (exp(beta_2*(populationNum + 1 - (i+1)))) / sumBeta;
    }
    //calculate the output
    for(i=0; i<populationNum; i++){
        for(j=0; j<Pred_stepAhead; j++){
            ensemble->SRank_base_LCombination_2->Pred[0][j] += ensemble->weightsRankBase_2[i] * Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
        }
    }
    //Obtain the rest of the parameters
    fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean);
    nrmse(ensemble->SRank_base_LCombination_2->Pred, sets->toPredictFn, mean, ensemble->SRank_base_LCombination_2->NRMSE);
    accuracy(ensemble->SRank_base_LCombination_2->Pred, sets->toPredictFn, ensemble->SRank_base_LCombination_2->accuracyPoint, ensemble->SRank_base_LCombination_2->accuracy);
    if(ensemble->SRank_base_LCombination_2->NRMSE[0] < nrmsMin){ //only works with 1 value
    	minimo = 0.2;
        nrmsMin = ensemble->SRank_base_LCombination_2->NRMSE[0];
     }

    /// FOR 0.25 ////////////////////////////////////////////////////////////////////////////////////////

    set(mean,sizetpos, 0);
    sumBeta = 0;
    // Calculte weights for the networks
    for(i=0; i<populationNum; i++){
        sumBeta += exp(beta_25*(i+1));
    }
    for(i=0; i<populationNum; i++){390
    	ensemble->weightsRankBase_25[i] = (exp(beta_25*(populationNum + 1 - (i+1)))) / sumBeta;
    }
    //calculate the output
    for(i=0; i<populationNum; i++){
        for(j=0; j<Pred_stepAhead; j++){
            ensemble->SRank_base_LCombination_25->Pred[0][j] += ensemble->weightsRankBase_25[i] * Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
        }
    }
    fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean);
    nrmse(ensemble->SRank_base_LCombination_25->Pred, sets->toPredictFn, mean, ensemble->SRank_base_LCombination_25->NRMSE);
    accuracy(ensemble->SRank_base_LCombination_25->Pred, sets->toPredictFn, ensemble->SRank_base_LCombination_25->accuracyPoint, ensemble->SRank_base_LCombination_25->accuracy);
    if(ensemble->SRank_base_LCombination_25->NRMSE[0] < nrmsMin){ //only works with 1 value
        minimo = 0.25;
        nrmsMin = ensemble->SRank_base_LCombination_25->NRMSE[0];
     }

    /// FOR 0.3 /////////////////////////////////////////////////////////////////////////////////////////

    set(mean,sizetpos, 0);
    sumBeta = 0;
    // Calculte weights for the networks
    for(i=0; i<populationNum; i++){
        sumBeta += exp(beta_3*(i+1));
    }
    for(i=0; i<populationNum; i++){
    	ensemble->weightsRankBase_3[i] = (exp(beta_3*(populationNum + 1 - (i+1)))) / sumBeta;
    }
    //calculate the output
    for(i=0; i<populationNum; i++){
        for(j=0; j<Pred_stepAhead; j++){
        	ensemble->SRank_base_LCombination_3->Pred[0][j] += ensemble->weightsRankBase_3[i] * Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
        }
    }
    fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean);
    nrmse(ensemble->SRank_base_LCombination_3->Pred, sets->toPredictFn, mean, ensemble->SRank_base_LCombination_3->NRMSE);
    accuracy(ensemble->SRank_base_LCombination_3->Pred, sets->toPredictFn, ensemble->SRank_base_LCombination_3->accuracyPoint, ensemble->SRank_base_LCombination_3->accuracy);
    if(ensemble->SRank_base_LCombination_3->NRMSE[0] < nrmsMin){ //only works with 1 value
    	minimo = 0.3;
        nrmsMin = ensemble->SRank_base_LCombination_3->NRMSE[0];
     }

	/// FOR 0.35 ////////////////////////////////////////////////////////////////////////////////////////

    set(mean,sizetpos, 0);
    sumBeta = 0;
    // Calculte weights for the networks
    for(i=0; i<populationNum; i++){
        sumBeta += exp(beta_35*(i+1));
    }
    for(i=0; i<populationNum; i++){
    	ensemble->weightsRankBase_35[i] = (exp(beta_35*(populationNum + 1 - (i+1)))) / sumBeta;
    }
    //calculate the output
    for(i=0; i<populationNum; i++){
        for(j=0; j<Pred_stepAhead; j++){
        	ensemble->SRank_base_LCombination_35->Pred[0][j] += ensemble->weightsRankBase_35[i] * Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
        }
    }
    fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean);
    nrmse(ensemble->SRank_base_LCombination_35->Pred, sets->toPredictFn, mean, ensemble->SRank_base_LCombination_35->NRMSE);
    accuracy(ensemble->SRank_base_LCombination_35->Pred, sets->toPredictFn, ensemble->SRank_base_LCombination_35->accuracyPoint, ensemble->SRank_base_LCombination_35->accuracy);
    if(ensemble->SRank_base_LCombination_35->NRMSE[0] < nrmsMin){ //only works with 1 value
        minimo = 0.35;
        nrmsMin = ensemble->SRank_base_LCombination_35->NRMSE[0];
     }

    /// FOR 0.4 /////////////////////////////////////////////////////////////////////////////////////////

    set(mean,sizetpos, 0);
    sumBeta = 0;
    // Calculte weights for the networks
    for(i=0; i<populationNum; i++){
        sumBeta += exp(beta_4*(i+1));
    }
    for(i=0; i<populationNum; i++){
    	ensemble->weightsRankBase_4[i] = (exp(beta_4*(populationNum + 1 - (i+1)))) / sumBeta;
    }
    //calculate the output
    for(i=0; i<populationNum; i++){
        for(j=0; j<Pred_stepAhead; j++){
        	ensemble->SRank_base_LCombination_4->Pred[0][j] += ensemble->weightsRankBase_4[i] * Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
        }
    }
    fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean);
    nrmse(ensemble->SRank_base_LCombination_4->Pred, sets->toPredictFn, mean, ensemble->SRank_base_LCombination_4->NRMSE);
    accuracy(ensemble->SRank_base_LCombination_4->Pred, sets->toPredictFn, ensemble->SRank_base_LCombination_4->accuracyPoint, ensemble->SRank_base_LCombination_4->accuracy);
    if(ensemble->SRank_base_LCombination_4->NRMSE[0] < nrmsMin){ //only works with 1 value
        minimo = 0.4;
        nrmsMin = ensemble->SRank_base_LCombination_4->NRMSE[0];
     }

    /// FOR 0.45 ////////////////////////////////////////////////////////////////////////////////////////

    set(mean,sizetpos, 0);
    sumBeta = 0;
    // Calculte weights for the networks
    for(i=0; i<populationNum; i++){
        sumBeta += exp(beta_45*(i+1));
    }
    for(i=0; i<populationNum; i++){
    	ensemble->weightsRankBase_45[i] = (exp(beta_45*(populationNum + 1 - (i+1)))) / sumBeta;
    }
    //calculate the output
    for(i=0; i<populationNum; i++){
        for(j=0; j<Pred_stepAhead; j++){
            ensemble->SRank_base_LCombination_45->Pred[0][j] += ensemble->weightsRankBase_45[i] * Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
        }
    }
    fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean);
    nrmse(ensemble->SRank_base_LCombination_45->Pred, sets->toPredictFn, mean, ensemble->SRank_base_LCombination_45->NRMSE);
    accuracy(ensemble->SRank_base_LCombination_45->Pred, sets->toPredictFn, ensemble->SRank_base_LCombination_45->accuracyPoint, ensemble->SRank_base_LCombination_45->accuracy);
    if(ensemble->SRank_base_LCombination_45->NRMSE[0] < nrmsMin){ //only works with 1 value
        minimo = 0.45;
        nrmsMin = ensemble->SRank_base_LCombination_45->NRMSE[0];
     }

    /// FOR 0.5 /////////////////////////////////////////////////////////////////////////////////////////

    set(mean,sizetpos, 0);
    sumBeta = 0;
    // Calculte weights for the networks
    for(i=0; i<populationNum; i++){
        sumBeta += exp(beta_5*(i+1));
    }
    for(i=0; i<populationNum; i++){
    	ensemble->weightsRankBase_5[i] = (exp(beta_5*(populationNum + 1 - (i+1)))) / sumBeta;
    }
    //calculate the output
    for(i=0; i<populationNum; i++){
        for(j=0; j<Pred_stepAhead; j++){
            ensemble->SRank_base_LCombination_5->Pred[0][j] += ensemble->weightsRankBase_5[i] * Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
        }
    }
    fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean);
    nrmse(ensemble->SRank_base_LCombination_5->Pred, sets->toPredictFn, mean, ensemble->SRank_base_LCombination_5->NRMSE);
    accuracy(ensemble->SRank_base_LCombination_5->Pred, sets->toPredictFn, ensemble->SRank_base_LCombination_5->accuracyPoint, ensemble->SRank_base_LCombination_5->accuracy);
    if(ensemble->SRank_base_LCombination_5->NRMSE[0] < nrmsMin){ //only works with 1 value
        minimo = 0.5;
        nrmsMin = ensemble->SRank_base_LCombination_5->NRMSE[0];
     }

    /// FOR 0.55 ////////////////////////////////////////////////////////////////////////////////////////

    set(mean,sizetpos, 0);
    sumBeta = 0;
    // Calculte weights for the networks
    for(i=0; i<populationNum; i++){
        sumBeta += exp(beta_55*(i+1));
    }
    for(i=0; i<populationNum; i++){
    	ensemble->weightsRankBase_55[i] = (exp(beta_55*(populationNum + 1 - (i+1)))) / sumBeta;
    }
    //calculate the output
    for(i=0; i<populationNum; i++){
        for(j=0; j<Pred_stepAhead; j++){
        	ensemble->SRank_base_LCombination_55->Pred[0][j] += ensemble->weightsRankBase_55[i] * Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
        }
    }
    fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean);
     nrmse(ensemble->SRank_base_LCombination_55->Pred, sets->toPredictFn, mean, ensemble->SRank_base_LCombination_55->NRMSE);
     accuracy(ensemble->SRank_base_LCombination_55->Pred, sets->toPredictFn, ensemble->SRank_base_LCombination_55->accuracyPoint, ensemble->SRank_base_LCombination_55->accuracy);
     if(ensemble->SRank_base_LCombination_55->NRMSE[0] < nrmsMin){ //only works with 1 value
        minimo = 0.55;
        nrmsMin = ensemble->SRank_base_LCombination_55->NRMSE[0];
     }

     /// FOR 0.6 ////////////////////////////////////////////////////////////////////////////////////////

     set(mean,sizetpos, 0);
     sumBeta = 0;
     // Calculte weights for the networks
    for(i=0; i<populationNum; i++){
        sumBeta += exp(beta_6*(i+1));
    }
    for(i=0; i<populationNum; i++){
    	ensemble->weightsRankBase_6[i] = (exp(beta_6*(populationNum + 1 - (i+1)))) / sumBeta;
    }
    //calculate the output
    for(i=0; i<populationNum; i++){
        for(j=0; j<Pred_stepAhead; j++){
            ensemble->SRank_base_LCombination_6->Pred[0][j] += ensemble->weightsRankBase_6[i] * Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
        }
    }
    fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean);
    nrmse(ensemble->SRank_base_LCombination_6->Pred, sets->toPredictFn, mean, ensemble->SRank_base_LCombination_6->NRMSE);
    accuracy(ensemble->SRank_base_LCombination_6->Pred, sets->toPredictFn, ensemble->SRank_base_LCombination_6->accuracyPoint, ensemble->SRank_base_LCombination_6->accuracy);
    if(ensemble->SRank_base_LCombination_6->NRMSE[0] < nrmsMin){ //only works with 1 value
        minimo = 0.6;
        nrmsMin = ensemble->SRank_base_LCombination_6->NRMSE[0];
     }

    /// FOR 0.65 ////////////////////////////////////////////////////////////////////////////////////////
    set(mean,sizetpos, 0);
    sumBeta = 0;
    // Calculte weights for the networks
    for(i=0; i<populationNum; i++){
        sumBeta += exp(beta_65*(i+1));
    }
    for(i=0; i<populationNum; i++){
    	ensemble->weightsRankBase_65[i] = (exp(beta_65*(populationNum + 1 - (i+1)))) / sumBeta;
    }
    //calculate the output
    for(i=0; i<populationNum; i++){
        for(j=0; j<Pred_stepAhead; j++){
        	ensemble->SRank_base_LCombination_65->Pred[0][j] += ensemble->weightsRankBase_65[i] * Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
        }
    }
    fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean);
     nrmse(ensemble->SRank_base_LCombination_65->Pred, sets->toPredictFn, mean, ensemble->SRank_base_LCombination_65->NRMSE);
     accuracy(ensemble->SRank_base_LCombination_65->Pred, sets->toPredictFn, ensemble->SRank_base_LCombination_65->accuracyPoint, ensemble->SRank_base_LCombination_65->accuracy);
     if(ensemble->SRank_base_LCombination_65->NRMSE[0] < nrmsMin){ //only works with 1 value
        minimo = 0.65;
        nrmsMin = ensemble->SRank_base_LCombination_65->NRMSE[0];
     }

     /// FOR 0.7 ////////////////////////////////////////////////////////////////////////////////////////

     set(mean,sizetpos, 0);
     sumBeta = 0;
     // Calculte weights for the networks
     for(i=0; i<populationNum; i++){
    	 sumBeta += exp(beta_7*(i+1));
     }
     for(i=0; i<populationNum; i++){
    	 ensemble->weightsRankBase_7[i] = (exp(beta_7*(populationNum + 1 - (i+1)))) / sumBeta;
     }
     //calculate the output
     for(i=0; i<populationNum; i++){
    	 for(j=0; j<Pred_stepAhead; j++){
    		 ensemble->SRank_base_LCombination_7->Pred[0][j] += ensemble->weightsRankBase_7[i] * Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
    	 }
     }
     fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean);
     nrmse(ensemble->SRank_base_LCombination_7->Pred, sets->toPredictFn, mean, ensemble->SRank_base_LCombination_7->NRMSE);
     accuracy(ensemble->SRank_base_LCombination_7->Pred, sets->toPredictFn, ensemble->SRank_base_LCombination_7->accuracyPoint, ensemble->SRank_base_LCombination_7->accuracy);
     if(ensemble->SRank_base_LCombination_7->NRMSE[0] < nrmsMin){ //only works with 1 value
    	 minimo = 0.7;
    	 nrmsMin = ensemble->SRank_base_LCombination_7->NRMSE[0];
     }

     /// FOR 0.75 ///////////////////////////////////////////////////////////////////////////////////////

     set(mean,sizetpos, 0);
     sumBeta = 0;
     // Calculte weights for the networks
    for(i=0; i<populationNum; i++){
        sumBeta += exp(beta_75*(i+1));
    }
    for(i=0; i<populationNum; i++){
        ensemble->weightsRankBase_75[i] = (exp(beta_75*(populationNum + 1 - (i+1)))) / sumBeta;
    }
    //calculate the output
    for(i=0; i<populationNum; i++){
        for(j=0; j<Pred_stepAhead; j++){
            ensemble->SRank_base_LCombination_75->Pred[0][j] += ensemble->weightsRankBase_75[i] * Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
        }
    }
    fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean);
    nrmse(ensemble->SRank_base_LCombination_75->Pred, sets->toPredictFn, mean, ensemble->SRank_base_LCombination_75->NRMSE);
    accuracy(ensemble->SRank_base_LCombination_75->Pred, sets->toPredictFn, ensemble->SRank_base_LCombination_75->accuracyPoint, ensemble->SRank_base_LCombination_75->accuracy);
    if(ensemble->SRank_base_LCombination_75->NRMSE[0] < nrmsMin){ //only works with 1 value
        minimo = 0.75;
        nrmsMin = ensemble->SRank_base_LCombination_75->NRMSE[0];
     }

    /// FOR 0.8 /////////////////////////////////////////////////////////////////////////////////////////

    set(mean,sizetpos, 0);
    sumBeta = 0;
    // Calculte weights for the networks
    for(i=0; i<populationNum; i++){
        sumBeta += exp(beta_8*(i+1));
    }
    for(i=0; i<populationNum; i++){
    	ensemble->weightsRankBase_8[i] = (exp(beta_8*(populationNum + 1 - (i+1)))) / sumBeta;
    }
    //calculate the output
    for(i=0; i<populationNum; i++){
        for(j=0; j<Pred_stepAhead; j++){
        	ensemble->SRank_base_LCombination_8->Pred[0][j] += ensemble->weightsRankBase_8[i] * Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
        }
    }
    fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean);
    nrmse(ensemble->SRank_base_LCombination_8->Pred, sets->toPredictFn, mean, ensemble->SRank_base_LCombination_8->NRMSE);
    accuracy(ensemble->SRank_base_LCombination_8->Pred, sets->toPredictFn, ensemble->SRank_base_LCombination_8->accuracyPoint, ensemble->SRank_base_LCombination_8->accuracy);
    if(ensemble->SRank_base_LCombination_8->NRMSE[0] < nrmsMin){ //only works with 1 value
        minimo = 0.8;
        nrmsMin = ensemble->SRank_base_LCombination_8->NRMSE[0];
     }

    /// FOR 0.85 ////////////////////////////////////////////////////////////////////////////////////////

    //calculate the output with the Rank-base Linear Combination
    set(mean,sizetpos, 0);
    sumBeta = 0;
    // Calculte weights for the networks
    for(i=0; i<populationNum; i++){
        sumBeta += exp(beta_85*(i+1));
    }
    for(i=0; i<populationNum; i++){
    	ensemble->weightsRankBase_85[i] = (exp(beta_85*(populationNum + 1 - (i+1)))) / sumBeta;
    }
    //calculate the output
    for(i=0; i<populationNum; i++){
        for(j=0; j<Pred_stepAhead; j++){
            ensemble->SRank_base_LCombination_85->Pred[0][j] += ensemble->weightsRankBase_85[i] * Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
        }
    }
    fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean);
    nrmse(ensemble->SRank_base_LCombination_85->Pred, sets->toPredictFn, mean, ensemble->SRank_base_LCombination_85->NRMSE);
    accuracy(ensemble->SRank_base_LCombination_85->Pred, sets->toPredictFn, ensemble->SRank_base_LCombination_85->accuracyPoint, ensemble->SRank_base_LCombination_85->accuracy);
    if(ensemble->SRank_base_LCombination_85->NRMSE[0] < nrmsMin){ //only works with 1 value
        minimo = 0.85;
        nrmsMin = ensemble->SRank_base_LCombination_85->NRMSE[0];
     }

    /// FOR 0.9 /////////////////////////////////////////////////////////////////////////////////////////

    set(mean,sizetpos, 0);
    sumBeta = 0;
    // Calculte weights for the networks
    for(i=0; i<populationNum; i++){
        sumBeta += exp(beta_9*(i+1));
    }
    for(i=0; i<populationNum; i++){
    	ensemble->weightsRankBase_9[i] = (exp(beta_9*(populationNum + 1 - (i+1)))) / sumBeta;
    }
    //calculate the output
    for(i=0; i<populationNum; i++){
        for(j=0; j<Pred_stepAhead; j++){
        	ensemble->SRank_base_LCombination_9->Pred[0][j] += ensemble->weightsRankBase_9[i] * Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
        }
    }
    fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean);
     nrmse(ensemble->SRank_base_LCombination_9->Pred, sets->toPredictFn, mean, ensemble->SRank_base_LCombination_9->NRMSE);
     accuracy(ensemble->SRank_base_LCombination_9->Pred, sets->toPredictFn, ensemble->SRank_base_LCombination_9->accuracyPoint, ensemble->SRank_base_LCombination_9->accuracy);
     if(ensemble->SRank_base_LCombination_9->NRMSE[0] < nrmsMin){ //only works with 1 value
        minimo = 0.9;
        nrmsMin = ensemble->SRank_base_LCombination_9->NRMSE[0];
     }

     /// FOR 0.95 ///////////////////////////////////////////////////////////////////////////////////////

     set(mean,sizetpos, 0);
     sumBeta = 0;
     // Calculte weights for the networks
    for(i=0; i<populationNum; i++){
        sumBeta += exp(beta_95*(i+1));
    }
    for(i=0; i<populationNum; i++){
    	ensemble->weightsRankBase_95[i] = (exp(beta_95*(populationNum + 1 - (i+1)))) / sumBeta;
    }
    //calculate the output
    for(i=0; i<populationNum; i++){
        for(j=0; j<Pred_stepAhead; j++){
        	ensemble->SRank_base_LCombination_95->Pred[0][j] += ensemble->weightsRankBase_95[i] * Ppopulation[i]->iteratePredF[0][j]; //0 in this moment only put the first line (1 pred)
        }
    }
    fmean(sets->toPredictFn, sizetpos, Pred_stepAhead, mean);
    nrmse(ensemble->SRank_base_LCombination_95->Pred, sets->toPredictFn, mean, ensemble->SRank_base_LCombination_95->NRMSE);
    accuracy(ensemble->SRank_base_LCombination_95->Pred, sets->toPredictFn, ensemble->SRank_base_LCombination_95->accuracyPoint, ensemble->SRank_base_LCombination_95->accuracy);
    if(ensemble->SRank_base_LCombination_95->NRMSE[0] < nrmsMin){ //only works with 1 value
        minimo = 0.95;
        nrmsMin = ensemble->SRank_base_LCombination_95->NRMSE[0];
     }

    ensemble->OutputBestSRBLC[0] = minimo;

    safefree(&mean);
*/
}//////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////




#endif
