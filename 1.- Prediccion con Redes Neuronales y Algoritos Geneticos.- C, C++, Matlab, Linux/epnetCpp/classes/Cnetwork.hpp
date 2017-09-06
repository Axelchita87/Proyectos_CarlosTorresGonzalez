/*!
 *  C_network.hpp
 * All methods from class network
 * The complete class and their methods are in the file
 */

#ifndef C_NETWORK_HPP
#define C_NETWORK_HPP


//Default Constructor using the variables of the mainepnet.hpp
C_network::C_network(int loadNet, char *file2load, const char Data2load[]){
	// Input: parameters
	// 		loadNet			0 initialize a random net, 1 load a net from a file
	//		file2load			is the file that will be opened to be loaded
	//
	// Global variables
	//
	// note the names have changed..... put new names later
	// 		epochs1			the number of epochs declarated in hpp
	//		targetPos1		the position of the vector to set2MSP in the data loaded
	//		Minputs			maximum number of inputs
	//		Mhidden			maximum number of hidden nodes
	//		outputs			the number of outpues in the network
	//		filelines		the lines of the data loaded
	//		filecols		columns in the loaded file
	//		sizetpos1		size of the targetPos variable, i.e. how many variables are going to be predicted in one step (number of outputs)
	//		Pred_stepAhead1	steps to set2MSP
	//		Mdelays			maximun number of delays
	// Outputs:
	//		this			the network is created and initizlized, ready to be trained.
	////////////////////////////////////////////////////////////////////////////////////

	/////////// Local variables //////////

	int tmpInp = 0;
	int tmpOut = 0;
	int j =0;

	sets = NULL;
	Epochs = NULL;
	varN = NULL;

	CW = NULL;
    W = NULL;
    W2 = NULL;
    DeltaW = NULL;
    nodes = NULL;
    bias = NULL;
    posinputs = NULL;
    poshidden = NULL;

    momentum = NULL;

    // Learning rate
    singleLrate = NULL;
    lrate = NULL;
    lrateB = NULL;

    fitness = NULL;
    fitnessReal = NULL;
    Errori = NULL;

    status = NULL;
    trainingWith = NULL;

    sizepos = NULL;

    // Variables for the extra prediction, they are declared even if they are not used
    set2SSP = NULL;
    set2MSP = NULL;

    // For Dual weights / incremental learning
    set4DualWeight = NULL;
    p = NULL;
    t = NULL;

    // Variables for the normal predictions inside the EA or at the end of it
    predictI = NULL;
    predictF = NULL;
    ////////////////////////////////////////////////////////////////////////////////////

    strcpy(tmpData2load,Data2load);

    int inputs = 0, delays = 0, hidden = 0, nodesN = 0, maxNodesN = 0, maxfinalInp = 0;

    if(loadNet == OFF){									// if no load network from file

    	// here determinate the inputs and delays if they are evolved //////////////////////
    	if(fixedinputs == EVOLVE){											// if evolved inputs
    		if (task2solve == PREDICT){
    			// Select an input in the range 1 to maxinputs (Minputs)
    			inputs = (int) (minInp + (maxInputs - minInp) * rando());	 			//RANDOM min+(max-min)*rando();
    			// Delays
    			delays = (int) (minDelay+ (maxDelays - minDelay) * rando());
    		}
    		else if( task2solve == CLASSIFY )
    			load_inputs_and_classes(&inputs, &tmpOut);
    	}
    	else{
    		if ((fixedinputs == FIXED ) || fixedinputs == FIX_EVOvra){
    			if ( task2solve == PREDICT )
    				load_FixedInputs_and_Delay(&inputs, &delays); 				//function in main file
    			else if ( task2solve == CLASSIFY )
    				load_inputs_and_classes(&inputs, &tmpOut);
    		}
    	}

    	// calculate the maximun number of Hidden nodes
    	if ( FIXED_HIDDEN == ON ){ 																	// it means that in this moment it is used the MLP and the hidden are fixed
    		hidden = NUM_HIDDEN[0];					// only one layer in MLP in this moment

    		// check that the values are corect configured
    		if ( hidden > totalMaxHidden ){
    			cout << "The NUM_HIDDEN[0] in MLPconf.hpp  exceeds the totalMaxHidden in conf.hpp, error, EXIT" << endl;
    			exit (0);
    		}

    	}
    	else 																									// default option, init them at random
    	    hidden = (int) (minHid + (maxHidden - minHid) * rando());


    }
    else{

    	if ( task2solve == CLASSIFY && reuseModule == ON ){ // I need to read the extra inputs
    		load_inputs_and_classes(&inputs, &tmpOut);
    		tmpInp = inputs; // temporarly save the inputs of the new combined tasks
    		// here tmpOutputs have the new outputvalues with is not the desired, next is overwriten
    	}

    	// Load the inputs, final niputs, delays, hidden nodes and outputs form the network from the file
    	loadNet2setup(&inputs, &delays, &hidden, &tmpOut, file2load);
    	inputs = tmpInp; 		// restore the original value
    	// now tmpOutput has the previos output and that can be added at the end of the preocess to read the network next... many lones below
    }

    // it does not matter if it is PREDIC or CLASSIFY, for CLASSIFY always filecol = 1, new var FILECOL with the real columns
    // IF the flag reuseModule is ON, and it was read another tasks with more outputs (only in this scenario works this), then the new output are considered
    // even if when the network is loaded with the output it has
    if ( reuseModule == OFF)
    	nodesN = (inputs*filecol) + hidden + noOutputs;
    else if (reuseModule == ON)
    	nodesN = (inputs*filecol) + hidden + noOutputs;

    maxNodesN = (totalMaxInput * filecol) + totalMaxHidden + noOutputs;
    maxfinalInp = totalMaxInput * filecol;


    if(MYDEBUG_EPNET == 1) cout << "inputs = " << inputs << ", delays = " << delays << ", Hidden = " << hidden << ", ...Nodes = " << nodesN << endl;

    // initialize the classes ///////////////////////////////////////////////////////////

    //set values with the global variables
    varN = new C_varN;												//allocate all vars
    varN->set_values(epochsK,targetPos,maxInputs,maxHidden,noOutputs, fileline,filecol,sizetpos,  Pred_stepAhead,inputs, inputs * filecol, delays, hidden);

    // Set the epochs structure
    Epochs = new C_Epochs;											//allocate all vars
    //Epochs->set_Epochs(varN->Vepochs[1]);



    //set set2SSP and set2MSP classes
    if (extraPredictions == ON && task2solve == PREDICT){
    	set2SSP = (C_predParam *) new C_predParam [numDiffPredict];		//no allocate any var
    	set2MSP = (C_predParam *) new C_predParam [numDiffPredict];		//no allocate any var
    	set_allPredictionsStruct(numDiffPredict, initialStepPred);
    }



    if (isDualWeights == ON){
    	// this variable is only for predictions outside the EA, PredictI is used normally for the predictions inside and it is the same set during all evolution
    	set4DualWeight = (C_predParam *) new C_predParam [numBatches];		//no allocate any var

    	if ( kindPred == SSP){
    		for(int i=0; i<numBatches; i++)
    			set4DualWeight[i].set_predParam(varN->VnoOutputs,Pred_stepAhead,varN->finalInp,Pred_stepAhead);
    	}
    	else if ( kindPred == MSP){
    		for(int i=0; i<numBatches; i++)
    			set4DualWeight[i].set_predParam(varN->VnoOutputs,Pred_stepAhead,varN->finalInp,1);
    	}
    }



    // Set the structures where the predction inside and outside will be saved
    predictI = new C_predParam;
    predictF = new C_predParam;

    if ( kindPred == MSP ){
    	predictI->set_predParam(sizetpos,Pred_stepAheadInside,varN->finalInp,1);																	/// chenged Pred_stepAhead by Pred_stepAheadInside
    	predictF->set_predParam(sizetpos,Pred_stepAhead,varN->finalInp,1);
    }
    else if( kindPred == SSP){
    	// for classification and prediction it is the same configuration, in both cases the number of steps to predict are the same as the number of inputs/patterns
    	predictI->set_predParam(sizetpos,Pred_stepAheadInside,varN->finalInp,Pred_stepAheadInside);
    	predictF->set_predParam(sizetpos,Pred_stepAhead,varN->finalInp,Pred_stepAhead);
    }


    //set the data that will be used

    // if it is used the quick learning to generalize
    if ( fitness_learnQuick2Genaralize == ON || generateDS_eachGen == ON )
    	sets = new C_sets_generateDataSets(varN->Vfileline, varN->finalInp, varN->VnoOutputs); 					//  virtual function derived from sets
    else
    	sets = new C_sets;




    if (task2solve == PREDICT )
    	sets->prepo(varN, set2SSP, set2MSP, predictI, predictF, tmpData2load);
    else if (task2solve == CLASSIFY )
    	sets->prepoClassification(varN, predictI, predictF, tmpData2load);

    // Set the internal parameters for the netowrk
    CW = allocate(CW,maxNodesN,maxNodesN);
    W = allocate(W,maxNodesN,maxNodesN);
    if (isDualWeights == ON)
    	W2 = allocate(W2,maxNodesN,maxNodesN);
    DeltaW = allocate(DeltaW,maxNodesN,maxNodesN);
    nodes = allocate(nodes,maxNodesN);
    bias = allocate(bias,maxNodesN);

    posinputs = allocate(posinputs, maxfinalInp);
    poshidden = allocate(poshidden, totalMaxHidden + noOutputs);

    momentum = (double *) malloc(sizeof(double));

    // Learning rate
    singleLrate = allocate(singleLrate,NUM_MODULES+5); 			// +5 as a security offset
    lrate = allocate(lrate, maxNodesN);
    lrateB = allocate(lrateB, maxNodesN);

    fitness = (double*) malloc(sizeof(double));
    fitnessReal = (double*) malloc(sizeof(double));
    Errori = allocate(Errori,7);

    status = (int*) malloc(sizeof(int));
    trainingWith = (int*) malloc(sizeof(int));

    sizepos = allocate(sizepos, 2);		//contain how many inputs and nodes it have, sizepos[0], sizepos[1].
    //initialize some variables
    momentum[0] = momentum1;

   // settle the learing rate
    reset_lrate();

    status[0] = 0;
    trainingWith[0] = 0;
    fitness[0] = -100;
    fitnessReal[0] = -100;



    // Initialize the network (which inputs, hidden are in the network)
    if(loadNet == OFF) 		// at random
    	initNet();
    else{					// load from a file CW, W, nodes, bias, ....

    	loadNetAll(file2load);
    	// I need to introduce extra inputs at the end of the inputs only to set the required spaces for the new task
    	if (reuseModule == ON){
    		//imprime(CW, varN->finalInp + varN->hidden+varN->VnoOutputs,varN->finalInp + varN->hidden+varN->VnoOutputs);
    		for ( j = 0; j<inputs - sizepos[0]; j++)   // only add the difference, just works if the new data to load is bigger
    			copyBeforeAdd(posinputs[ sizepos[0]  -1 ] );
    		sizepos[0] = inputs;
    		sizepos[1] += varN->VnoOutputs-tmpOut;

    		// update nodes variable for the outputs
    		for ( j = (varN->finalInp + varN->hidden);  j < (varN->finalInp + varN->hidden + varN->VnoOutputs); j++)
    			nodes[j] = 1;

    		recalculateInputs();
    		//imprime(CW, varN->finalInp + varN->hidden+varN->VnoOutputs,varN->finalInp + varN->hidden+varN->VnoOutputs);
    	}
    }

    // Swap coonection, only in this place is used this function
    if (algoFeatures == SWAP_CONN)
    	obtainActive_and_deact_conn();


    // If it is used the modularity of husken
    if (isModule1 == ON){
    	// asing memory
    	huskenModule = new C_module1();
    	sharedModule = new C_module1();

    	// Calculate the modularity
    	huskenModule->setup(this);
    	sharedModule->setup(this);

    	huskenModule->isThereModulesHuskenTopDown();
    	sharedModule->isThereSharedModule();

    	// obtain the isolated nodes from inputs and output using Mweight (note the in the matlab code I use March)
    	huskenModule->isolatedNodes();

    	// update the learning rate for each node, I do this here in case a node change of module
    	// for evolution of lrate =0,1,3 it does not matter if the change of module, only in case 2
    	//update_Lrate(0);  I think in this moment it does not matter if the node change of module, it will increas eor decrease its lrate as the module does
    }



}//////////////////////////////////////////////////////////////////////////////////////


C_network::~C_network(){

	// Check if the netwrok is not empty

	if(this->CW != NULL)
		deleteAllStruct();


}////////////////////////////////////////////////////////////////////////////////


void C_network::deleteAllStruct(void){




	if (isModule1 == ON){
		delete (sharedModule);
		sharedModule = NULL;

	   delete (huskenModule);
	   huskenModule = NULL;
	}

	 // Swap connection, only in this place is used this function
	if (algoFeatures == SWAP_CONN){
		safefree(&activeConn, 3);
		safefree(&deactConn, 3);
		safefree(&rangeDeact, 2);
	}

	int maxNodesN = (totalMaxInput * filecol) + totalMaxHidden + noOutputs;
	safefree(&sizepos);

	//sizepos = NULL;
	safefree(&trainingWith);
	safefree(&status);
	safefree(&fitness);
	safefree(&fitnessReal);
	safefree(&Errori);
	safefree(&lrate);
	safefree(&lrateB);
   safefree(&singleLrate);

	safefree(&momentum);
	safefree(&poshidden);
	safefree(&posinputs);
	safefree(&bias);
	safefree(&nodes);
	safefree(&DeltaW,maxNodesN);
	if (isDualWeights == ON)
		safefree(&W2,maxNodesN);
	safefree(&W,maxNodesN);
	safefree(&CW,maxNodesN);

	delete(sets);
	sets = NULL;

	delete predictF;				predictF = NULL;

	delete predictI;				predictI = NULL;

	if (extraPredictions == ON && task2solve == PREDICT){
		delete [] set2MSP;
		set2MSP = NULL;

		delete [] set2SSP;
		set2SSP = NULL;
	}

	delete(Epochs);
	Epochs = NULL;

	delete(varN);
	varN = NULL;

}




void C_network::print(){
	int nodesNet = (varN->inputs * varN->Vfilecol) + varN->hidden + varN->VnoOutputs;
	cout << endl;

	cout << "---- **** NETWORK **** ----" << endl;
	cout << "CW" << endl;
	imprime(CW,nodesNet,nodesNet);
	cout << "W" << endl;
	imprime(W,nodesNet,nodesNet);
	//cout << "DeltaW" << endl;
	//imprime(DeltaW,nodesNet,nodesNet);
	cout << "nodes" << endl;
	imprime(nodes,nodesNet);
	cout << "bias" << endl;
	imprime(bias,nodesNet);
	cout << "posinputs" << endl;
	imprime(posinputs,varN->inputs * varN->Vfilecol);
	cout << "poshidden" << endl;
	imprime(poshidden,varN->hidden + varN->VnoOutputs);

	cout << "sizepos = [" << sizepos[0] << "][" << sizepos[1] << "]" << endl;

	cout << "varN->inputs = " << varN->inputs << endl;
	cout << "varN->finalInp= " << varN->finalInp<< endl;
	cout << "varN->hidden = " << varN->hidden<< endl;
	cout << "varN->delays = " << varN->delays << endl;


	/*cout << "momentum = [" << momentum[0] << "]" << endl;
	cout << "lrate = [" << lrate[0] << "]" << endl;

	cout << "Epochs structure" << endl;
	Epochs->print();
	//lrateXepochs...
	cout << "iteratePredI" << endl;
	imprime(iteratePredI, varN->Vsizetpos, varN->VPred_stepAhead);

	cout << "iterateNRMSE_I" << endl;
	imprime(iterateNRMSE_I, varN->Vsizetpos);

	cout << "accuracyPointValI" << endl;
	imprime(accuracyPointValI, varN->Vsizetpos,varN->VPred_stepAhead);

	cout << "accuracyValI" << endl;
	imprime(accuracyValI, varN->Vsizetpos);

	cout << "fitness" << endl;
	imprime(fitness, varN->Vsizetpos);

	cout << "iteratePredF" << endl;
	imprime(iteratePredF, varN->Vsizetpos,varN->VPred_stepAhead);

	cout << "iterateNRMSE_F" << endl;
	imprime(iterateNRMSE_F, varN->Vsizetpos);

	cout << "accuracyPointF" << endl;
	imprime(accuracyPointF, varN->Vsizetpos,varN->VPred_stepAhead);

	cout << "accuracyF" << endl;
	imprime(accuracyF, varN->Vsizetpos);

	cout << "status = " << status[0] << endl;
	cout << "training with = " << trainingWith[0] << endl;*/
	cout << "------------End Network --------------" << endl;
}

void C_network::save2file(FILE *fwrite, char file[]){
	// Vj, Phi, ... and other variables are not saved
	int nodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;

	// save sets class
	//sets->save2file(fwrite, file);

	// save all the variables from Epochs
	Epochs->save2file(varN->Vepochs[1], fwrite, file);

	// save varN
	varN->save2file(fwrite,file);

	// save CW
    saveInt(CW, nodesNet, nodesNet, fwrite, file);
    // save W
    saveD(W, nodesNet,nodesNet, fwrite, file);
    if (isDualWeights == ON)
    	saveD(W2, nodesNet,nodesNet, fwrite, file);

    // save DeltaW
    saveD(DeltaW, nodesNet,nodesNet, fwrite, file);

    // save nodes
    saveInt(nodes, nodesNet, fwrite, file);
    // save bias
    saveInt(bias, nodesNet, fwrite, file);
    // save posinputs
    saveInt(posinputs, varN->finalInp, fwrite, file);    // modified, check if it works ok

    // save poshidden, including the outputs
    saveInt(poshidden, varN->hidden + varN->VnoOutputs, fwrite, file);
    // save sizepos
    saveInt(sizepos, 2, fwrite, file);
    // save momentum
    fprintf(fwrite, "%g\t",momentum[0]);

    // save lrate
    saveD( singleLrate, NUM_MODULES, fwrite, file);
    saveD(lrate, nodesNet, fwrite, file);
    saveD(lrateB, nodesNet, fwrite, file); // learning rate for the bias


    // status
    fprintf(fwrite, "%d\t",status[0]);
    ///////////////////////////////////////////////////////////////////////
    /// Put a band to look for error
    if((fprintf(fwrite, "%d\t",BAND)) == EOF){
    	printf("Error writing to file '%s'...\n",file); exit(0);
    }
    ///////////////////////////////////////////////////////////////////////



    // save classes predParam
    if(extraPredictions == ON && task2solve == PREDICT){
    	int cont = initialStepPred;
    	for(int i = 0; i < numDiffPredict; i++){
    		set2SSP[i].save2file(fwrite, file);    	//cout << "imprime predParam class" << endl; set2SSP[0].imprime();  Modifications .... cont and below was 1 in the called function
    		set2MSP[i].save2file(fwrite, file);
    		cont *= 2;
    	}
    }
    predictI->save2file(fwrite, file);
    predictF->save2file(fwrite, file);


    // save fitness
    fprintf(fwrite, "%g\t",fitness[0]);
    fprintf(fwrite, "%g\t",fitnessReal[0]);

    // Save variables from module1
    if (isModule1 == ON){
    	huskenModule->save2file(fwrite,file);
    	sharedModule->save2file(fwrite,file);
    }






    if((fprintf(fwrite, "%d\t",BAND)) == EOF){
    	printf("(savingNetwork) Error writing to file '%s'...\n",file); exit(0);
    }

}///////////////////////////////////////////////////////////////////////////////////////




void C_network::save2fileSingleNet(FILE *fwrite, char file[]){
	/*!
	 * Function to save just some variables from the network
	 * This variables are useful to reload the network and continue the evolution of them
	 * Or to load the network and perform a prediciton
	 *
	 * This function it is the same as saveSingleNetALLTS.m witht he difference that here is only for the actual network
	 *
	 * Inputs:
	 * fwrite 		pointer to file that will be written
	 * file 			name of the file to save, this variable just is used to indicate in case of error, which file filed
	 */

	int nodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;

	// save variables from varN
	fprintf(fwrite, "%d\t",varN->inputs);
	fprintf(fwrite, "%d\t",varN->finalInp);
	fprintf(fwrite, "%d\t",varN->delays);
	fprintf(fwrite, "%d\t",varN->hidden);
	fprintf(fwrite, "%d\t",varN->VnoOutputs);

	// save CW
    saveInt(CW, nodesNet, nodesNet, fwrite, file);
    // save W
    saveD(W, nodesNet,nodesNet, fwrite, file);
    if (isDualWeights == ON)
    	saveD(W2, nodesNet,nodesNet, fwrite, file);

    // save DeltaW
    saveD(DeltaW, nodesNet,nodesNet, fwrite, file);
    // save nodes
    saveInt(nodes, nodesNet, fwrite, file);
    // save bias
    saveInt(bias, nodesNet, fwrite, file);

    // save sizepos
    saveInt(sizepos, 2, fwrite, file);
    // save posinputs
    saveInt(posinputs, varN->finalInp, fwrite, file);    // modified, check if it works ok
    // save poshidden, including the outputs
    saveInt(poshidden, varN->hidden + varN->VnoOutputs, fwrite, file);

    // save momentum
    fprintf(fwrite, "%g\t",momentum[0]);
    // save lrate
    saveD(lrate, nodesNet, fwrite, file);
    saveD(lrateB, nodesNet, fwrite, file);

    // Put a counter to know how many times the network has been loaded
    fprintf(fwrite, "%d\t",varN->counterLoaded);



    ///////////////////////////////////////////////////////////////////////
    /// Put a band to look for error
    if((fprintf(fwrite, "%d\t",BAND)) == EOF){
    	printf("Error writing to file '%s'...\n",file); exit(0);
    }
    ///////////////////////////////////////////////////////////////////////



}///////////////////////////////////////////////////////////////////////////////////////





void C_network::save2fileModule(int module, string file, C_network **net){
	/*!
	 * Save a module to a file
	 *
	 * Inputs:
	 * 		module 			the number of the module to save
	 * 		file					the name of the file to be saved the module
	 * 		net 					a temporal network to save the acutal network, this one is modufied ot save only the required module
	 */

	// local variables
	FILE *fwrite;
	int nodesNet, k;
	string strInputs = "Inputs";
	string strOutputs = "outputs";
	string strHidden = "hidden";


	cout << "Save Module Fuction" << endl;

	// Before start to save the module, create a copy of the network
	net[0]->copyCleanNet(this);
	nodesNet = net[0]->varN->finalInp + net[0]->varN->hidden + net[0]->varN->VnoOutputs;

	// now it is nedded to delete the nodes that does not belong to the actual module.


	// For inputs
	// In this moment it is not consider the inputs to be deleted, regardless if they are used for the modularity or not (considerInputsInMod)
	// because even if one input belongs to one module, it may be conencted to another module, for 021a,0023a,...
	//if (considerInputsInMod == ON){}

	// output nodes
	for (k = 1; k<=NUM_MODULES; k++){
		if (k != module) 										// delete all different modules than 'module'
			net[0]->deleteModule(k, nodesNet-1, (net[0]->varN->inputs + net[0]->varN->hidden), strOutputs );
	}

	// hidden nodes nodes
	for (k = 1; k<=NUM_MODULES; k++){
		if (k != module) 										// delete all different modules than 'module'
			net[0]->deleteModule(k, (net[0]->varN->inputs + net[0]->varN->hidden - 1), net[0]->varN->inputs, strHidden );
	}
	// hidden nodes nodes for isolated nodes, module -2
	net[0]->deleteModule(-2, (net[0]->varN->inputs + net[0]->varN->hidden - 1), net[0]->varN->inputs, strHidden );

	nodesNet = net[0]->varN->finalInp + net[0]->varN->hidden + net[0]->varN->VnoOutputs;

	// The input section has not been programmed, check that for prediciton it does not mess with inputs and final input when do it

/* Original code that works for hidden and output nodes // module deletion
	// move from last node to the first hidden node
	for (node = nodesNet-1; node >= net[0]->varN->inputs; node-- ){
		//imprime(net[0]->CW,nodesNet,nodesNet);
		//imprime(net[0]->huskenModule->nodesInModule, nodesNet, 2 );
		if ( net[0]->huskenModule->nodesInModule[node][1] != module  ){
			// delete the actual node becuase it does not belong the the module
			net[0]->copyBeforeDelete(node);
			net[0]->sizepos[1] --;

			if (node < net[0]->varN->finalInp + net[0]->varN->hidden)
				net[0]->varN->hidden--;
			else
				net[0]->varN->VnoOutputs --;

			net[0]->recalculateHNodes();

			// move positions in husken module->nodesInModule
			for(cols = node; cols < nodesNet -1 ; cols++)
				net[0]->huskenModule->nodesInModule[cols][1] = net[0]->huskenModule->nodesInModule[cols+1][1];

			nodesNet = net[0]->varN->finalInp + net[0]->varN->hidden + net[0]->varN->VnoOutputs;

		}
	}
*/

	//imprime(net[0]->CW,nodesNet,nodesNet);
	//imprime(net[0]->huskenModule->nodesInModule, nodesNet, 2 );



	// After the module has been isolated, save it
    // I am assumig that the node at least have one hidden node

	// Create the file pointer
	if ((fwrite = fopen(file.c_str() , "w")) == NULL){
		printf("Error can not open the file '%s' for writing...\n",file.c_str() );
	}

	// save them
	fprintf(fwrite, "%d\t",net[0]->varN->inputs);
	fprintf(fwrite, "%d\t",net[0]->varN->finalInp);
	//fprintf(fwrite, "%d\t",net[0]->varN->delays);
	fprintf(fwrite, "%d\t",net[0]->varN->hidden);
	fprintf(fwrite, "%d\t",net[0]->varN->VnoOutputs);

	// save CW
	saveInt(net[0]->CW, nodesNet, nodesNet, fwrite, (char *)file.c_str());
	// save W
	saveD(net[0]->W, nodesNet,nodesNet, fwrite, (char *)file.c_str());
	if (isDualWeights == ON)
		 saveD(net[0]->W2, nodesNet,nodesNet, fwrite, (char *)file.c_str());
	// save DeltaW
	saveD(net[0]->DeltaW, nodesNet,nodesNet, fwrite, (char *)file.c_str());
	// save nodes
	saveInt(net[0]->nodes, nodesNet, fwrite, (char *)file.c_str());
	// save bias
	saveInt(net[0]->bias, nodesNet, fwrite, (char *)file.c_str());

	// save sizepos
	saveInt(net[0]->sizepos, 2, fwrite, (char *)file.c_str());
	// save posinputs
	saveInt(net[0]->posinputs,  net[0]->varN->finalInp, fwrite, (char *)file.c_str());    // modified, check if it works ok
	// save poshidden, including the outputs
	saveInt(net[0]->poshidden,  net[0]->varN->hidden +  net[0]->varN->VnoOutputs, fwrite, (char *)file.c_str());

	// save momentum
	fprintf(fwrite, "%g\t",net[0]->momentum[0]);

	// save lrate per from the only module
	saveD(net[0]->lrate, nodesNet, fwrite, (char *)file.c_str());
	saveD(net[0]->lrateB, nodesNet, fwrite, (char *)file.c_str());

	// save how many times this module has been loaded
	fprintf( fwrite, "%d\t",net[0]->huskenModule->loadModule[module-1] );

	// save the history, if it has not been loadded, then is one position (indicating data set and number of module)
	// if it has been loadded the it is loadModule[x]+1
	net[0]->huskenModule->history[module-1].save2file( fwrite, (char *)file.c_str() );





	    ///////////////////////////////////////////////////////////////////////
	    /// Put a band to look for error
	    if((fprintf(fwrite, "%d\t",BAND)) == EOF){
	    	printf("Error writing to file '%s'...\n",(char *)file.c_str()); exit(0);
	    }
	    ///////////////////////////////////////////////////////////////////////

	// Close the file
	fclose(fwrite);


}// end save module /////////////////////////////////////////////////////////////////////////////////////




//Train the network with MBP
void C_network::trainMBP(int epochs1,int where)
{
	try{
		double **prediction = NULL;  		// where it is saved the prediciton if it is used ES
		int *flag2lratePnode = 0; 																			// this variable is used to know if we neew to incremnet (value 1) or decrement (value -1)
		    																												// the evolution of lrate per node
		int *bandES = NULL;

		double **pn = NULL;
		double **tn = NULL;

		C_val *val = NULL;

		// Allocate in train
		double **Vj = NULL;;
		double **Phi = NULL;
		double *Gradient = NULL;
		double **tempW = NULL;

		int *poshidden2 = NULL;
		int *poshidden22 = NULL;

		int cont1,contnode,contii,epoch,nump;
		double Error,SumDOW;
		int colpn,linepn,linetn,linepnval,colpnval,*node = NULL;
		int *ii = NULL;
		int outputCont = 0;																	// variable to count the number of outputs fo tn

		double Emin_strip = 0;
		double sumEstrip = 0;
		int tempEmin_strip = 0;
		double *Eopt = NULL;

		// allocate space
		bandES = (int *) malloc(sizeof(int));
		Eopt = allocate(Eopt, 1+NUM_MODULES); 						// if it is not evolved per module, pos [0] is for the lreate for the whole network

		int nodesNet = (varN->inputs * varN->Vfilecol) + varN->hidden + varN->VnoOutputs;

		//Acomodate the data if the training is inside or outside
		if(where == TRAIN_OUTSIDE){
			//printf("where == 1 Outside epnet\n");
			linepn = sets->sizes->SpnF[0];
			colpn = sets->sizes->SpnF[1];
			linetn = sets->sizes->StnF[0];
			pn = sets->pnF;
			tn = sets->tnF;

			if (useValidation == ON && useValidationOutside == ON){
				val = sets->valF;
				linepnval = sets->sizes->SvalF[0];
				colpnval = sets->sizes->SvalF[1];
			}
		}
		else{
			//printf("where != 1 -> 0 inside epnet\n");
			linepn = sets->sizes->SpnI[0];
			colpn = sets->sizes->SpnI[1];
			linetn = sets->sizes->StnI[0];
			pn = sets->pnI;
			tn = sets->tnI;

			if (useValidation == ON){
				val = sets->valI;
				linepnval = sets->sizes->SvalI[0];
				colpnval = sets->sizes->SvalI[1];
			}
		}

		//	Allocate
		Vj = allocate(Vj,nodesNet,sets->sizes->SpnF[1]);
		Phi = allocate(Phi,nodesNet,sets->sizes->SpnF[1]);
		Gradient = allocate(Gradient,nodesNet);
		tempW = allocate(tempW,nodesNet,nodesNet);
		prediction = allocate(prediction,sizetpos,colpnval);
		flag2lratePnode = allocate(flag2lratePnode, NUM_MODULES);

		Epochs->setClass2val(varN->Vepochs[1], 0);


		//maybe I can put insie of a function //////////////////////////
		cont1=0;
		poshidden2 = allocate(poshidden2, sizepos[1]);
		poshidden22 = allocate(poshidden22, sizepos[1]-varN->VnoOutputs);

		inverseVec(poshidden, sizepos[1], poshidden2);										// have all hidden and output nodes in inverse order
		inverseVec(poshidden, sizepos[1]-varN->VnoOutputs, poshidden22);		// only hidden nodes in inverse order




		// If it is used the balwin evolution, the weights are restarted before training
		if ( baldwin == ON ){
			initweights();
			reset_lrate();
		}
		// if every generation is generated a new data set, only for 0024, 0024a, ... AS it can be seen only the selected network is restarted
		if ( generateDS_eachGen == ON )
			rearrangeData();
		// evolve learning rate per node, perturbate at random some learning rates
		if ( evolveLrate == 2 )
			perturbateLratePerNode();
		//cout << "poshidden" << endl; imprime(poshidden,sizepos[1]);  puts("poshidden2");   imprime(poshidden2,sizepos[1]);    puts("poshidden22");    imprime(poshidden22,sizepos[1]);
		////////////////////////////////////////////////////////////////

		for(epoch=0; epoch<epochs1; epoch++){
			Error = 0;
			//cout << "epoch " << epoch << endl;
			for(nump=0; nump<colpn; nump++){
				//cout << "nump " << nump << endl;
				contnode=0;
				outputCont = 0;
				for(node=poshidden; contnode<sizepos[1]; node++){
					//cou << "node " << *node << endl;
					if(bias[*node] == 1)
						Vj[*node][nump] = W[*node][*node]; //sum the bias
					else
						Vj[*node][nump] = 0;

					contii=0;
					//cout << "pos inputs " << endl; imprime(posinputs,sizepos[0]);

					for(ii=posinputs; contii<sizepos[0]; ii++){  //for all the entrances
						if( nodes[ *ii ] != 0){									// before if (*ii != 0){
							//printf("for inputs ii=%d\n",*ii);
							if(CW[*ii][*node] == 1){
								Vj[*node][nump] = Vj[*node][nump] + pn[*ii][nump] * W[*ii][*node];
								//printf("Inputs for Vj,   Vj[%d][%d]=%f, pn[%d][%d]=%f, Network->W[%d][%d]=%f\n",*node,nump,Vj[*node][nump],*ii,nump,pn[*ii][nump],*ii,*node,Network->W[*ii][*node]);
							}
						}
						contii++;
					}

					contii=0;
					for(ii=poshidden; contii<sizepos[1]; ii++){ //for the rest of the patterns
						//printf("for hidden ii=%d\n",*ii);
						if(CW[*ii][*node] == 1){
							Vj[*node][nump]= Vj[*node][nump] + Phi[*ii][nump] * W[*ii][*node];
							//printf("Hidden for Vj,   Vj[%d][%d]=%f, Phi[%d][%d]=%f, Network->W[%d][%d]=%f\n",*node,nump,Vj[*node][nump],*ii,nump,Phi[*ii][nump],*ii,*node,Network->W[*ii][*node]);
						}
						else{
							if(*ii == *node){
								//printf("Break for hidden *ii = *node = %d\n",*ii);
								break;
							}
						}
						contii++;
					}

					if( (*node >= (varN->finalInp + varN->hidden) ) &&  (*node <= nodesNet) ){  												 // if it is the last layer
						if ( transferFunOutput == LINEAL ){																												// Linear transfer funtion in output nodes
							// linear output
							Phi[*node][nump] = Vj[*node][nump];
							// Linear output, SSE
							Gradient[*node] = tn[outputCont][nump] - Phi[*node][nump];  																				//the derivate is 1, so it is the same as the error, linear output
						}
						else if ( transferFunOutput == SIGMOID ){																																								// sigmoid transfer funtion
							Phi[*node][nump] = 1.0/(1.0 + exp(-Vj[*node][nump])) ;   																		// Sigmoidal Outputs
							if (SSEoCE == SSE)
								Gradient[*node] = ( tn[outputCont][nump] - Phi[*node][nump] )  * Phi[*node][nump] * (1 - Phi[*node][nump]); // derivate of sigmoid. Sigmoidal outputs, SSE
							else if (SSEoCE == CE)
								Gradient[*node] =  tn[outputCont][nump] - Phi[*node][nump] ; 							// Sigmoidal Outputs, Cross-Entropy Error
						}

						// Calculate the error from all outputs
						if (SSEoCE == SSE)
							Error += 0.5 * ((tn[outputCont][nump] - Phi[*node][nump])*(tn[outputCont][nump] - Phi[*node][nump]));									//MSE (SSE)
						else if (SSEoCE == CE)
							Error -= ( tn[outputCont][nump] * log( Phi[*node][nump] ) + ( 1.0 - tn[outputCont][nump] ) * log( 1.0 - Phi[*node][nump] ) ) ;    //Cross-Entropy Error

						Error += 0.5 * 0.0011 *  SUMmat(W,nodesNet,nodesNet); 					// weigh decay Method 2, only here is penalized the error 1/2 * lambda * sum (w)

						//printf("tn[0][%d]=%f\n",nump,tn[0][nump]);//printf("last layer epoch = %d, nump=%d, Phi[%d][%d] = %f, Error=%f, Gradient[%d]=%f\n",epoch,nump,*node,nump,Phi[*node][nump],Error,*node,Gradient[*node]);
						outputCont++;
					}
					else{
						// hidden nodes, transfer function
						if(transferFunHidden == HTAN)
							Phi[*node][nump] = tanh(Vj[*node][nump]);																							//(exp(Vj[*node][nump])-exp(-Vj[*node][nump]))/(exp(Vj[*node][nump])+exp(Vj[*node][nump]));
						else if(transferFunHidden == SIGMOID)
							Phi[*node][nump] = 1.0/(1.0 + exp(-Vj[*node][nump])) ;  // Sigmoidal Outputs
						//printf("Not last layer,   epoch = %d, nump=%d, Phi[%d][%d] = %f \n",epoch,nump,*node,nump,Phi[*node][nump]);
					}
					contnode++;
				}//for to calculate outputs

				//Back-propagate error to hidden nodes%
				contnode=0; //printf("Calculate the rest of the gradients\n Network->sizepos[1]-1=%d\n",Network->sizepos[1]-1);
				for( node = poshidden22 ; contnode < ( sizepos[1] - varN->VnoOutputs) ; node++ ){   									// for all hidden nodes
					SumDOW = 0;
					contii=0;
					for(ii=poshidden2; contii<sizepos[1]; ii++){ 																									// check hidden and output nodes
						//printf("ii=%d\n",*ii);
						if(CW[*node][*ii] == 1)
							SumDOW+= W[*node][*ii] * Gradient[*ii];
						else if(*node==*ii)
								break;
						contii++;
					}
					if(task2solve == PREDICT || ( strcmp( typeDS.c_str(), "NRMSE" ) == 0))
						Gradient[*node] = SumDOW * (1 - ((Phi[*node][nump])*(Phi[*node][nump])));   // derivate of tanh  // in the future check cause I think it is 1-tan^2(x) posted 24/07/10
					else
						Gradient[*node] = SumDOW * Phi[*node][nump] * (1 - Phi[*node][nump]);  		// derivate of sigmoid
					//printf("Gradient[%d]=%f , Phi[%d][%d]=%f\n",*node,Gradient[*node],*node,nump,Phi[*node][nump]);
					contnode++;
				}

				//update weights
				contnode=0;
				for(node=poshidden; contnode<sizepos[1]; node++){
					if(bias[*node] == 1){
						DeltaW[*node][*node] = lrateB[*node] * Gradient[*node] + momentum[0] * DeltaW[*node][*node]; //generalized delta rule, here is implicit delta * wji(n-1)
						W[*node][*node] += DeltaW[*node][*node];    				//original //W[*node][*node] = W[*node][*node] + DeltaW[*node][*node];
						//W[*node][*node] += DeltaW[*node][*node] - ( 0.0011 * W[*node][*node] );    				// using weight decay Method1
					}
					contii=0;
					for(ii=posinputs; contii<sizepos[0]; ii++){  //for all the entrances
						if( *ii != -1){
							if(CW[*ii][*node] == 1){
								DeltaW[*ii][*node] = lrate[*node] * pn[*ii][nump] * Gradient[*node] + momentum[0] * DeltaW[*ii][*node];
								W[*ii][*node] += DeltaW[*ii][*node];   // original //W[*ii][*node] = W[*ii][*node] + DeltaW[*ii][*node];
								//W[*ii][*node] += DeltaW[*ii][*node] - ( 0.0011 *W[*ii][*node]  );							// using weight decay Method1
							}
						}
						contii++;
					}
					contii=0;
					for(ii=poshidden; contii< sizepos[1]; ii++){  //for the rest of the patterns
						if(*ii >= *node)
							break;
						else{
							if(CW[*ii][*node] == 1){
								DeltaW[*ii][*node] = lrate[*node] * Phi[*ii][nump] * Gradient[*node] + momentum[0] * DeltaW[*ii][*node];
								W[*ii][*node] += DeltaW[*ii][*node];  								// original //W[*ii][*node] = W[*ii][*node] + DeltaW[*ii][*node];
								//W[*ii][*node] += DeltaW[*ii][*node] - ( 0.0011 *W[*ii][*node]  );	 						// using weight decay Method1
							}
						}
						contii++;
					}
					contnode++;
				}
			}// for nump --> all paterns ////////////////

			Epochs->Etr[epoch] = Error;


			if ( isnan(Error) != 0 ){
				cout << "the value is not a number" << endl;
				Epochs->Eval[epochs1-1] = Epochs->Eval[epoch];
				break;
			}

			/// Cross validation, Early stopping  ///
			if ( useValidation == ON){
				if( (where == TRAIN_INSIDE) || (where == TRAIN_OUTSIDE && useValidationOutside == ON )){
					bandES[0]=0;
					complexES(val->pn, colpnval, val->tn, epoch,tempW, &Emin_strip, &sumEstrip, &tempEmin_strip, Eopt, bandES, prediction, flag2lratePnode);

					// copy the actual error to the last one
					if(bandES[0]==1){
						Epochs->Eval[epochs1-1] = Epochs->Eval[epoch];
						break;
					}
				}
			}
			if(MYDEBUG_MBP == 1){
				//if (epoch%100 == 0 || epoch == epochs1-1){
					if(useValidation == ON )
						cout << "Epoch = " << epoch << " Error = " << Error <<   " error Val = " << Epochs->Eval[epoch] << endl;
					else
						cout << "Epoch = " << epoch << " Error = " << Error <<  endl;
				//}
			}


			// Rearange data or generate new one
			if (fitness_learnQuick2Genaralize == OFF)
				randomPT(pn,tn,linepn,colpn,linetn);											// Rearrange the data randomly
			else if ( evaluate_LearnQuick() )
				break;																							// break epochs

			// If it is used the epochs as a fitness in a normal EA, i.e. not generating data sets every epoch, then use this
			if ( fitness_byEpochs == ON){
				if ( evaluate_fitness_byEpochs() )
					break;																					// break epochs
			}



		}////// for epoch	//////////////////////////////////////////////////////////////





		//printf("epochs finished\n");
		//if flagexit == 0

		// Determinate the STP

		// For the traing of a single data set use this function
		// For the multiple data sets trainig: It does not have sence evaluate the STP here casue it depends now of the training of all scales
		if(trainMultipleSets == OFF){
			if(useValidation == ON){
				if( (where == TRAIN_INSIDE) || (where == TRAIN_OUTSIDE && useValidationOutside == ON) )
					status[0] = obtainSTP(Epochs->Eval[epochs1-1], Epochs->Eval[0]);
			}
			else
				status[0] = obtainSTP(Epochs->Etr[epochs1-1], Epochs->Etr[0]); 			// if there is no validation, the error is taken from the training error
		}

		// Perform the prediciton, calculate the errors and set up the fitness
		evaluateANN(where, epoch);

		trainingWith[0] = MBP;






		if(MYDEBUG_MBP == 1 && isRealPredictionUsed == OFF)     cout << "MBP TRAINING, Fitness = " << fitness[0] << "Fitness real = " << fitnessReal[0] << endl;

		// Liberate memory ///////////////////
		safefree(&poshidden22);
		safefree(&poshidden2);

		safefree(&tempW,nodesNet);
		safefree(&Gradient);

		safefree(&Phi,nodesNet);
		safefree(&Vj,nodesNet);

		safefree(&Eopt);

		val = NULL;

		tn = NULL;
		pn = NULL;

		safefree(&bandES);
		safefree(&prediction,sizetpos);
		safefree(&flag2lratePnode);

	}
	catch (...) {
		cout << "Something were wrong in the MBP algorithm" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}

} // End trainig with MBP ///////////////////////////////////////////////////////////////////////////


// Perform the prediciton, calculate the errors and set up the fitness
void C_network::evaluateANN(int where, int epochStopped)
{
	/*!
	 * Function to determinate if the training is inside or outside the EA, to assign the fitness and to calculate the modularity of the network
	 */
	// This function is like the TrainMBP but without training
	// is used only to evaluate the network for all predicitons lapses
	// if measure the modularity is ON it is calculated too

	try{

		/// Evaluate the network using the test set inside or outside /////////
		if(where == TRAIN_OUTSIDE){							// Last training, after the evolution finish
			obtainPerformanceNet(sets->inputF, sets->sizes->SinputF, predictF, kindPred);
			if(  task2solve == PREDICT || ( strcmp( typeDS.c_str(), "NRMSE" ) == 0) ){
				fitness[0] = predictF->NRMSE[0];
				fitnessReal[0] = predictF->NRMSE[0];
			}
			else{
				fitness[0] = predictF->Epercentage;
				fitnessReal[0] = predictF->Epercentage;
			}

			// Probably here put some code check if the fitness is nan
			/*if ( isnan(fitness[0]) != 0 ){
				cout << "the fitness  is not a number,  network::evaluateANN fun" << endl;
				fitness[0] = 100;
				fitnessReal[0] = 100;
			}
			*/

			// test other prediction to see how well the network can deal with them
			if(extraPredictions == ON && task2solve == PREDICT)
				obtainPerformanceNetCell(sets->input, sets->sizes->Sinput);

		}
		else if (where == TRAIN_INSIDE &&  isRealPredictionUsed == OFF ){									// training inside the evolution
			obtainPerformanceNet(sets->inputI,sets->sizes->SinputI,predictI, kindPred);
			if(  task2solve == PREDICT || ( strcmp( typeDS.c_str(), "NRMSE" ) == 0) ){
				fitness[0] = predictI->NRMSE[0];
				fitnessReal[0] = predictI->NRMSE[0];
			}
			else{
				fitness[0] = predictI->Epercentage;
				fitnessReal[0] = predictI->Epercentage;
			}
		}


		 // If it is used the modularity of husken
		if (isModule1 == ON){
			// clean
			huskenModule->clean();
			sharedModule->clean();
			// Calculate the modularity
			huskenModule->setup(this);
			sharedModule->setup(this);

			huskenModule->isThereModulesHuskenTopDown();
			sharedModule->isThereSharedModule();

			/// obtain the isolated nodes from inputs and output using Mweight (note the in the matlab code I use March)
	    	huskenModule->isolatedNodes();
	    	//cout << "Modularity values :::::: " << endl;
	    	//cout << "March = " << huskenModule->MarchTD << ",   Mweight = " << huskenModule->MweightTD << endl;


	    	// update the learning rate for each node, I do this here in case a node change of module
	    	//update_Lrate(); check network constructor, same line, in this moment it is not updated here


	    	// Penalize the fitness given the modularity
	    	if (biasModularityFit == ON)
	    		fitness[0] = updateFitnessWithModularity(fitness[0], huskenModule->MarchTD );

		}

		// settle the fitness with the number of epochs used
		if (   fitness_learnQuick2Genaralize == ON  || fitness_byEpochs == ON )
			fitness[0] = epochStopped;


	}
	catch (...) {
		cout << "Something were wrong in the MBP algorithm" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}

} // End EvalALL ///////////////////////////////////////////////////////////////////////////


int C_network::evaluate_fitness_byEpochs( void ){
	/*!
	 * Funtion to evaluate the network every epoch and see if all patterns have been correctly classified
	 *
	 * Quite similar to fucntion C_net_quickLearning::evaluate_LearnQuick. IF MODIDY THIS CHANGE THE OTHER AND  C_network::obtainPerformanceNet
	 */

	// evaluate error percentage
	obtainPredictions(sets->inputI,sets->sizes->SinputI,predictI, kindPred); 			  			// first calculate the predicitons with the test set inside which was passed to this function

	if(  strcmp( typeDS.c_str(), "wta")  == 0 )
		predictI->classifError = classifEWinnerTakeAllMOD(predictI->pred, predictI->toPredict, predictI->linesT, predictI->colsT, varN->minClass, varN->maxClass, predictI->classifErrorPerModule, predictI->incorrectPred);

	else if( strcmp( typeDS.c_str(), "modified" ) == 0 ){
		predictI->classifError = classificationError(predictI->pred, predictI->toPredict, predictI->linesT, predictI->colsT, varN->minClass, varN->maxClass);
		classifErrorPerModule(predictI->classifErrorPerModule, predictI->pred, predictI->toPredict, predictI->colsT, varN->minClass, varN->maxClass,predictI->incorrectPred);
	}
	else{
				cout << "incorrect option for the class ..... function  C_network::evaluate_fitness_byEpoch ........ exit" << endl;
				exit (0);
			}

	// this vars are loaded with acript_plotClasses_plorBadPrediciton in workspace2\generateDS
	/* saveD((char *)"../../workspace2/genDataSetModular/res/inputANN.txt", predictI->inputAnn, predictI->linesP, predictI->colsP);
		 saveD((char *)"../../workspace2/genDataSetModular/res/target.txt", predictI->toPredict, predictI->linesT, predictI->colsT);
		 	 saveD((char *)"../../workspace2/genDataSetModular/res/pred.txt", predictI->pred, predictI->linesT, predictI->colsP);
		 saveInt((char *)"../../workspace2/genDataSetModular/res/incorrect.txt",predictI->incorrectPred, NUM_MODULES, predictI->colsT);
	*/
	if ( flagDebug == ON ) cout << "classification Error = " << predictI->classifError << endl;


	// if error percentage is zero, finish (<= 1 so there may be very difficult patterns, I will not consider them in this moment)
	if ( predictI->classifError <= minClassError_fitByEpochs)
		return ( 1 ); 								// finish epochs as all patterns where classify correctly
	else{												// if it is not,  continue epochs
		return( 0 );
	}

}

//complexES calculate the complex early stopping, save in str_network (Network)
 void C_network::complexES(double **pn,int colpn, double **tn,int epoch, double **tempW, double *Emin_strip, double *sumEstrip,int *tempEmin_strip, double *Eopt, int *bandES, double **prediction, int *flag2lratePnode)
{

    int i;

    singleStepPred(pn,colpn,prediction);														    //imprimeMd(prediction,1,colpn);

    Epochs->Eval[epoch] = errorPercentage(prediction, tn, sizetpos, colpn);

    if ( epoch%strip == 0 && evolveLrate > 0  && isModule1 == ON && NUM_MODULES > 1)
    	errorPercentagePerModule(predictI->EpercentagePerModule, prediction, tn, sizetpos, colpn);  // it is used temporaly predictI, even at the end of the learning is overwritten this value





    //int allNodes = varN->finalInp+varN->hidden+varN->VnoOutputs;

// Just early stopping, update whne use it
/*
    if(epoch==0){				// first epoch
        //copy(tempW,W,allNodes,allNodes);
        Eopt[0] = Epochs->Eval[epoch];

        Epochs->GL[epoch] = 100*((Epochs->Eval[epoch] / *Eopt)-1);
        *Emin_strip = Epochs->Etr[epoch];
        *sumEstrip = Epochs->Etr[epoch];
        *tempEmin_strip = 1;
    }
    else{
        if (Epochs->Eval[epoch] <= *Eopt){		// if the actual error is smaller than the previous
            *Eopt = Epochs->Eval[epoch]; 																	// I do not use this code to evoolve the lrate, but check if every epoch is needed to enter for ES, for lrate I think there was an error
            //copy(tempW,W,allNodes,allNodes);  //copy the last good weights
            *tempEmin_strip = 0;
        }
        //else
        //    tempEmin_strip[0]++;							// if not, increment the counter



       if (Epochs->Etr[epoch] < *Emin_strip)
            *Emin_strip = Epochs->Etr[epoch];

        *sumEstrip += Epochs->Etr[epoch];
        *sumEstrip
    }
*/ // finks this part of code for ES



    // evolve learning rate, take values fisrt epoch
    if(epoch==0 && evolveLrate > 0){
    	if (NUM_MODULES == 1){    // for a single network
    		Eopt[0] = Epochs->Eval[epoch];
    	}
    	else if (NUM_MODULES > 1 ){
    		for (i = 0; i < NUM_MODULES; i++)
    			Eopt[i] = predictI->EpercentagePerModule[i];
    	}
    }


    if (epoch%strip == 0 && epoch != 0 && evolveLrate > 0){           //enter every strip epochs (strip is a global var)

    	/* not used ES in this momet
    	Epochs->GL[epoch] = 100*((Epochs->Eval[epoch] / *Eopt)-1);

        Epochs->Pk[epoch] = 1000* ((*sumEstrip/(strip * *Emin_strip))-1);
        *sumEstrip = 0;
        Epochs->PQalfa[epoch] = Epochs->GL[epoch]/Epochs->Pk[epoch];

        if ((Epochs->PQalfa[epoch] > stopAlpha) || *tempEmin_strip > stopStrip){
        	copy(W,tempW,allNodes,allNodes);																			// restore the last good weight matrix found
           bandES[0] = 1;
           if(MYDEBUG_MBP == 1)  cout << "Exit ES, *tempEmin_strip = " << *tempEmin_strip << endl;

        }
        */
    	// if it is option 1 or 3 and there is only one module
    	if (  NUM_MODULES == 1 ){ 	 //if ( (evolveLrate == 1 || evolveLrate == 3 )  && NUM_MODULES == 1 ){ 											// for only one module or ANN
    		if ((Epochs->Eval[epoch] <= Eopt[0]) && (singleLrate[0] <= maxlrate)){ 		// increment
    			Eopt[0] = Epochs->Eval[epoch]; 															// update this only if the actual is smaller than the previous
    			singleLrate[0] += lrateMod;
    			flag2lratePnode[0] = 1;																			// for option 3, to know that I need to incremnet
    		}
    		else{
                if ((Epochs->Eval[epoch] > Eopt[0]) && singleLrate[0] >= minlrate ){ 		// decrement
                	singleLrate[0] -=  lrateMod;
                	flag2lratePnode[0] = -1;																		// for option 3, to know that I need to decrement
                }
    		}
    	}

    	else if (NUM_MODULES > 1 ){ 				//else if ( ( evolveLrate == 2  || evolveLrate == 3 ) && NUM_MODULES > 1 ){ 													// evolve lrate per module
    		for (i = 0; i < NUM_MODULES; i++){
    			if (predictI->EpercentagePerModule[i] <= Eopt[i] && singleLrate[i] <= maxlrate ){
    				Eopt[i] = predictI->EpercentagePerModule[i];
    				singleLrate[i] +=  lrateMod;
    				flag2lratePnode[i] = 1;
    			}
    			else{																										// decrement
    				if ( ( predictI->EpercentagePerModule[i] > Eopt[i] ) && singleLrate[i] >= minlrate ) 		// decrement
    					singleLrate[i] -=  lrateMod;
    					flag2lratePnode[i] = -1;
    			}
    		}
    	}

    	// update the learning rate per module
    	update_Lrate(flag2lratePnode);
    }// finish epoch module strip

/*
    // Temporal variables to save the lrate per epochs, comment them if they are not used
    if (evolveLrate == ON){
    	lratePERepochs[epoch] =  lrate[0];
    	for (int i = 0; i< NUM_MODULES; i++){
    		ErrorPerModule[i][epoch] = predictI->EpercentagePerModule[i];
    	}
    }

    if (evolveLratePer_module == ON){
    	for (int i = 0; i< NUM_MODULES; i++){
    		lratePerModule[i][epoch] = lratePer_module[i];
    		ErrorPerModule[i][epoch] = predictI->EpercentagePerModule[i];

    	}
    }
*/
    // Liberate memory

}//////////////////////////////////////////////////////////////////////////





 //train with simulate annealing
 void C_network::trainSA(C_network *smallestNetwork, double Temp, double alfa){
	 // Train with SA algorihtm
	 // smallestNetwork is a copy of 'this'
	 try{
		 register int t,cont;
		 register double vmin,vmax;

		 int *all = NULL;
		 double **smallestW = NULL;
		 double smallFitness = -100;

		 double **pn = NULL;
		 double **tn = NULL;
		 C_val *val = NULL;
		 double **Want = NULL;

		 int contii,contjj,*ii,*jj;
		 double fitnessant;
		 int netNodes = 0;


		 // Initialize the variables
		 all = (int *) malloc((sizepos[0]+sizepos[1])*sizeof(int));
		 netNodes = varN->finalInp + varN->hidden + varN->VnoOutputs;

		 // mantain a copy of the smallest W and fitness
		 smallestW = copyAlloc(smallestW, smallestNetwork->W,netNodes,netNodes);
		 smallFitness = smallestNetwork->fitness[0];

		 vmin = -0.05; //before a
		 vmax = 0.05;  //before b

		 //Take the values for inside the EA, I do not expect use this fun in the final training
		 pn = sets->pnI;
		 tn = sets->tnI;

		 // I think I do not use validatio in SA, even that I leave as I programmed it
		 if (useValidation == ON)
			 val = sets->valI;

		 Want = copyAlloc(Want,W,netNodes,netNodes);
		 fitnessant = fitness[0];

		 //Create a vector with all the neurons
		/* cont = 0;
		 for(i=0; i<sizepos[0]; i++){
			 if( nodes[i] == 1){
				 all[cont] = posinputs[i];
				 cont++;
			 }
		 }
		 //cont = sizepos[0];
		 for(i=0; i<sizepos[1]; i++){
			 all[cont] = poshidden[i];
			 cont++;
		 }*/ // old code incase there is an error retunr this code
		 cont = obtainAllnodes(all);

		 do
		 {
			 //if (band==1) break;
			 for(t=0; t<iterationTemp; t++){
				 //printf("Temp %f \t t%d\n",Temp,t);
				 //generate s'
				 //for all nodes
				 contii = 0;
				 for(ii=poshidden; contii<sizepos[1]; ii++){
					 //printf("ii=%d  \t",*ii);
					 contjj=0;
					 for (jj=all; contjj<(sizepos[0]+sizepos[1]); jj++){
						 if(*jj >= *ii)
							 break;
						 else{
							 if(CW[*jj][*ii] == 1)
								 W[*jj][*ii] += ((vmin + (vmax-vmin) * rando())/temperature)*Temp;
						 }
						 contjj++;
					 }
					 contii++;
				 }	    //for the bias
				 contii = 0;
				 for(ii=poshidden; contii<sizepos[1]; ii++){
					 if(bias[*ii] == 1)
						 W[*ii][*ii] += ((vmin + (vmax-vmin) * rando())/temperature)*Temp;
					 contii++;
				 }

				 // Obtain the performance of the network
				 obtainPerformanceNet(sets->inputI, sets->sizes->SinputI, predictI, kindPred);
				 if(  task2solve == PREDICT || ( strcmp( typeDS.c_str(), "NRMSE" ) == 0) ){
					 fitness[0] = predictI->NRMSE[0];
					 fitnessReal[0] = predictI->NRMSE[0];
				 }
				 else{
					 fitness[0] = predictI->Epercentage;
					 fitnessReal[0] = predictI->Epercentage;
				 }

				 //mantain a copy of the best
				 if(fitness[0] < smallestNetwork->fitness[0]){
					 //smallestNetwork->copyNet(this);
					 copy(smallestW, W,netNodes,netNodes);
					 smallFitness = fitness[0];

					 copy(Want,W,netNodes,netNodes);
					 fitnessant = fitness[0];
				 }
				 else if(fitness[0] <= fitnessant){
					 copy(Want,W,netNodes,netNodes);
					 fitnessant = fitness[0];
				 }
				 else{
					 if(rando() <= exp(-1*(fitness[0]-fitnessant)/(Temp*alfa))){  //probabilistic behaviour
						 // accept the actual weights even they do not improve the fitness
						 copy(Want,W,netNodes,netNodes);
						 fitnessant = fitness[0];
					 }
					 else{
						 copy(W,Want,netNodes,netNodes);
						 fitness[0] = fitnessant;
						 fitnessReal[0] = fitnessant;
					 }
				 }

			 }
			 Temp *= alfa;
			 //start the new cycle with the smallest
			 //this->copyNet(smallestNetwork);
			 copy(W,smallestW,netNodes,netNodes);
			 fitness[0] = smallFitness;
			 fitnessReal[0] = smallFitness;

		 }while(Temp > 0.1);

		 // put the smallest values in the smallest network to be returned
		 copy(smallestNetwork->W,smallestW,netNodes,netNodes);
		 smallestNetwork->fitness[0] = smallFitness;
		 smallestNetwork->trainingWith[0] = SA;


		 // Check the modularity ********************************************* arch and weight
		 // If it is used the modularity of husken
		    if (isModule1 == ON){
		    	// clean
		    	huskenModule->clean();
		    	sharedModule->clean();
		    	// Calculate the modularity
		    	huskenModule->setup(this);
		    	sharedModule->setup(this);
		    	huskenModule->isThereModulesHuskenTopDown();
		    	sharedModule->isThereSharedModule();

		    	// obtain the isolated nodes from inputs and output using Mweight (note the in the matlab code I use March)
		    	huskenModule->isolatedNodes();

		    	// Penalize the fitness given the modularity
		    	if (biasModularityFit == ON)
		    		fitness[0] = updateFitnessWithModularity(fitness[0], huskenModule->MarchTD );
		    }


		 if(MYDEBUG_SA == 1) cout << "SA training, Fitness = " << smallestNetwork->fitness[0] << endl;
		 if(MYDEBUG_SA == 1) cout << "SA training, Fitness this = " << fitness[0] << endl;

		 // Liberate space /////////
		 ii = NULL;
		 jj = NULL;

		 safefree(&Want,netNodes);
		 val = NULL;
		 tn = NULL;
		 pn = NULL;
		 safefree(&smallestW,netNodes);

		 safefree(&all);
	 }
	 catch (...) {
		 cout << "Something were wrong in the SA funtion" << endl;
		 processException();
		 exit(EXIT_FAILURE);
	 }

}  //// Finish Simulate Annealling





// Obtain all nodes in the N, save in allnodes and return the size
int C_network::obtainAllnodes(int *allnodes){
	register int i,cont;

	cont=0;
	for(i=0; i< varN->finalInp + varN->hidden + varN->VnoOutputs; i++){
		if(nodes[i] == 1){
			allnodes[cont] = i;
			cont++;
		}
	}
	return(cont);
}///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Obtain all inputs in the N, save in allinputs and return the size, this fun was designed for the assimetric case
int C_network::obtainAllInputs(int *allnodes){
	register int i,cont;

	cont=0;
	for(i=0; i<(varN->inputs * varN->Vfilecol) ; i++){
		if(nodes[i] == 1){
			allnodes[cont] = i;
			cont++;
		}
	}
	return(cont);
}///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// Obtain all inputs in the N, save in allinputs and return the size, this fun was designed for the assimetric case
int C_network::obtainAllFreeInputs(int *allnodes){
	register int i,cont;

	cont=0;
	for(i=0; i<(varN->inputs * varN->Vfilecol) ; i++){
		if(nodes[i] == 0){
			allnodes[cont] = i;
			cont++;
		}
	}
	return(cont);
}///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


 // Calculate the importance of the conections before delete it
 void C_network::importance(double **test)
 {
	 try{

	 // local variables
     register int i,j,k,cont1,nump,contnode,contii,contjj;
     register double Error, SumDOW, SumDOW2;
     int sizeallnodes,linepn,colpn,linetn,epoch;
     int sizepn;

     int *allnodes = NULL;
     double **pn = NULL;
     double **tn = NULL;

     double **Vj = NULL;;
     double **Phi = NULL;
     double *Gradient = NULL;
     //double **tempW = NULL;
     double ***tempSum = NULL;
     double **tempSum2 = NULL;

     double **divisor = NULL;
     double **meantempSum = NULL;
     double *Gradient2 = NULL;
     double **DeltaW2 = NULL;

     int *poshidden2 = NULL;
     int *poshidden22 = NULL;

     int *node = NULL;
     int *ii = NULL;
     int *jj = NULL;
     ////////////////////////////////////////////////////////////////////////////////////////////

     int NumNodesNet = (varN->inputs * varN->Vfilecol) + varN->hidden + varN->VnoOutputs;

     allnodes = (int *) malloc(NumNodesNet * sizeof(int));

     // obtain all nodes
     sizeallnodes = obtainAllnodes(allnodes); //cout << endl << "Inside of importance Function..." << endl << "ALL Nodes" << endl; imprime(allnodes,sizeallnodes);

     sizepn = sets->sizes->SpnI[1];
     linepn = sets->sizes->SpnI[0];
     colpn = sets->sizes->SpnI[1];
     linetn = sets->sizes->StnI[0];
     pn = sets->pnI;
     tn = sets->tnI;


     // Allocate
     Vj = allocate(Vj,NumNodesNet,sets->sizes->SpnF[1]);
     Phi = allocate(Phi,NumNodesNet,sets->sizes->SpnF[1]);
     Gradient = allocate(Gradient,NumNodesNet);
     tempSum = allocate(tempSum,sizepn,NumNodesNet,NumNodesNet);

     //clear some variables
     set(test,NumNodesNet,NumNodesNet, 0);
     set(DeltaW,NumNodesNet,NumNodesNet, 0);

     //Set up other parameters
     tempSum2 = copyAlloc(tempSum2,test,NumNodesNet,NumNodesNet);
     divisor = copyAlloc(divisor,test,NumNodesNet,NumNodesNet);
     meantempSum = copyAlloc(meantempSum,test,NumNodesNet,NumNodesNet);

     Gradient2 = allocate(Gradient2,NumNodesNet);
     DeltaW2 = allocate(DeltaW2,NumNodesNet,NumNodesNet);

     cont1=0;
     poshidden2 = (int *) malloc(sizepos[1]*sizeof(int));
     poshidden22 = (int *) malloc(sizepos[1]*sizeof(int));

     for(i=sizepos[1]-1; i>=0; i--){    //invert
         poshidden2[cont1] = poshidden[i];
         if(i!=sizepos[1]-1)
             poshidden22[cont1-1] = poshidden[i]; //not count the last
         cont1++;
         //cout << "i" << i << endl;
     }


 epoch=0;
         Error = 0;
         //printf("epoch %d\n",epoch);
         for(nump=0; nump<colpn; nump++){
            //printf("nump %d\n",nump);
             contnode=0;
             for(node=poshidden; contnode<sizepos[1]; node++){
                 //printf("node %d\n",*node);
                if(bias[*node] == 1)
                     Vj[*node][nump] = W[*node][*node]; //sum the bias
                 else
                     Vj[*node][nump] = 0;

                 //imprimeMd(Network->W,varN->finalInp+varN->hidden+varN->VnoOutputs,varN->finalInp+varN->hidden+varN->VnoOutputs);
                 //printf("Sum bias,   Vj[%d][%d]=%f\n",*node,nump,Vj[*node][nump]);

                 contii=0;
                 //printf("pos inputs \n"); imprimeVi(Network->posinputs,Network->sizepos[0]);

                 for(ii=posinputs; contii<sizepos[0]; ii++){  //for all the entrances
                     //printf("for inputs ii=%d\n",*ii);
                	 if( nodes[ *ii ] != 0){	 				//if( *ii != -1){
                		 if(CW[*ii][*node] == 1){
                			 Vj[*node][nump] = Vj[*node][nump] + pn[*ii][nump] * W[*ii][*node];
                			 //printf("Inputs for Vj,   Vj[%d][%d]=%f, pn[%d][%d]=%f, Network->W[%d][%d]=%f\n",*node,nump,Vj[*node][nump],*ii,nump,pn[*ii][nump],*ii,*node,Network->W[*ii][*node]);
                		 }
                	 }
                	 contii++;
                 }

                 contii=0;
                 for(ii=poshidden; contii<sizepos[1]; ii++){ //for the rest of the patterns
                      //printf("for hidden ii=%d\n",*ii);
                	 if( *ii != -1){
                		 if(CW[*ii][*node] == 1){
                			 Vj[*node][nump]= Vj[*node][nump] + Phi[*ii][nump] * W[*ii][*node];
                			 //printf("Hidden for Vj,   Vj[%d][%d]=%f, Phi[%d][%d]=%f, Network->W[%d][%d]=%f\n",*node,nump,Vj[*node][nump],*ii,nump,Phi[*ii][nump],*ii,*node,Network->W[*ii][*node]);
                		 }
                		 else{
                			 if(*ii == *node){
                				 //printf("Break for hidden *ii = *node = %d\n",*ii);
                				 break;
                			 }
                		 }
                	 }
                	 contii++;
                 }
                 if( (*node >= (varN->finalInp + varN->hidden) ) &&  (*node <= NumNodesNet) ){  												 // if it is the last layer
                	 if ( transferFunOutput == LINEAL ){																												// Linear transfer funtion in output nodes
                		 Phi[*node][nump] = Vj[*node][nump];  																										//linear output
                		 Gradient[*node] = tn[0][nump] - Phi[*node][nump];  																				//the derivate is 1, so it is the same as the error, linear output
                		 Gradient2[*node] = fabs(tn[0][nump] - Phi[*node][nump]);
                	 }
                	 else if ( transferFunOutput == SIGMOID ){																																								// sigmoid transfer funtion
                		 Phi[*node][nump] = 1.0/(1.0 + exp(-Vj[*node][nump])) ;   																		// Sigmoidal Outputs
                		 Gradient[*node] = ( tn[0][nump] - Phi[*node][nump] )  * Phi[*node][nump] * (1 - Phi[*node][nump]);  	// derivate of sigmoid;
                		 Gradient2[*node] = fabs(tn[0][nump] - Phi[*node][nump]);  // I am not sure if with sigmoid in the outputs this function work as with lineal functions
                	 }
                	 // Calculate the error from all outputs
                	 Error += 0.5 * ((tn[0][nump] - Phi[*node][nump])*(tn[0][nump] - Phi[*node][nump]));								//MSE
                	 //printf("tn[0][%d]=%f\n",nump,tn[0][nump]);//printf("last layer epoch = %d, nump=%d, Phi[%d][%d] = %f, Error=%f, Gradient[%d]=%f\n",epoch,nump,*node,nump,Phi[*node][nump],Error,*node,Gradient[*node]);
                 }
                 else{																																									// hidden nodes, transfer function
                	 if(transferFunHidden == HTAN)
                		 Phi[*node][nump] = tanh(Vj[*node][nump]);																							//(exp(Vj[*node][nump])-exp(-Vj[*node][nump]))/(exp(Vj[*node][nump])+exp(Vj[*node][nump]));
                	 else if(transferFunHidden == SIGMOID)
                		 Phi[*node][nump] = 1.0/(1.0 + exp(-Vj[*node][nump])) ;   																		// Sigmoidal Outputs
                	 //printf("Not last layer,   epoch = %d, nump=%d, Phi[%d][%d] = %f \n",epoch,nump,*node,nump,Phi[*node][nump]);
                 }
                 contnode++;
             }//for to calculate outputs



             //Back-propagate error to hidden nodes%
             contnode=0; //printf("Calculate the rest of the gradients\n Network->sizepos[1]-1=%d\n",Network->sizepos[1]-1);
             for(node=poshidden22; contnode<sizepos[1]-1; node++){   //all the nodes except the input layer
            	 SumDOW = 0; //printf("Node=%d --not the last--, SumDow = 0, SumDOW=%f\n",*node,SumDOW);
            	 SumDOW2 = 0;
                 //printf("node=%d\n",*node);
                 contii=0;
                 for(ii=poshidden2; contii<sizepos[1]; ii++){
                     //printf("ii=%d\n",*ii);
                     if(CW[*node][*ii] == 1){
                         SumDOW+= W[*node][*ii] * Gradient[*ii]; //printf("ii=%d,  SumDOW=%f ,  Network->W[%d][%d]=%f * Gradient[%d]=%f\n",*ii,SumDOW,*node,*ii,Network->W[*node][*ii],*ii,Gradient[*ii]);
                         SumDOW2+= W[*node][*ii] * Gradient2[*ii];
                     }
                     else{
                         if(*node==*ii){
                             //printf("Break calculating gradients, *node==*ii = %d\n",*node);
                             break;
                         }
                     }
                     contii++;
                 }
                 if(task2solve == PREDICT || ( strcmp( typeDS.c_str(), "NRMSE" ) == 0)){
                	 Gradient[*node] = SumDOW * (1 - ((Phi[*node][nump])*(Phi[*node][nump])));   // derivate of tanh  // in the future check cause I think it is 1-tan^2(x) posted 24/07/10
                	 Gradient2[*node] = SumDOW2 * (1 - ((Phi[*node][nump])*(Phi[*node][nump])));
                 }
                 else{
                	 Gradient[*node] = SumDOW * Phi[*node][nump] * (1 - Phi[*node][nump]);  		// derivate of sigmoid
                	 Gradient2[*node] = SumDOW2 * Phi[*node][nump] * (1 - Phi[*node][nump]);
                 }
                 //printf("Gradient[%d]=%f , Phi[%d][%d]=%f\n",*node,Gradient[*node],*node,nump,Phi[*node][nump]);
                 contnode++;
             }

             //update weights
             contnode=0;
             for(node=poshidden; contnode<sizepos[1]; node++){
                 if(bias[*node] == 1){
                	 DeltaW[*node][*node] = lrateB[*node] * Gradient[*node] + momentum[0] * DeltaW[*node][*node]; //generalized delta rule, here is implicit delta * wji(n-1)
                	 DeltaW2[*node][*node] = lrateB[*node] * Gradient2[*node] + momentum[0] * DeltaW2[*node][*node]; //generalized delta rule, here is implicit delta * wji(n-1)
                	 tempSum[nump][*node][*node] = W[*node][*node] + DeltaW2[*node][*node];
                     W[*node][*node] += DeltaW[*node][*node];     // original  W[*node][*node] = W[*node][*node] + DeltaW[*node][*node];
                 }
                 contii=0;
                 for(ii=posinputs; contii<sizepos[0]; ii++){  //for all the entrances
                	 if( *ii != -1){
                		 if(CW[*ii][*node] == 1){
                			 DeltaW[*ii][*node] = lrate[*node] * pn[*ii][nump] * Gradient[*node] + momentum[0] * DeltaW[*ii][*node];
                			 DeltaW2[*ii][*node] = lrate[*node] * pn[*ii][nump] * Gradient2[*node] + momentum[0] * DeltaW2[*ii][*node];
                			 tempSum[nump][*ii][*node] = W[*ii][*node] + DeltaW2[*ii][*node];
                			 W[*ii][*node] += DeltaW[*ii][*node];    // original W[*ii][*node] = W[*ii][*node] + DeltaW[*ii][*node];
                		 }
                	 }
                	 contii++;
                 }
                 contii=0;
                 for(ii=poshidden; contii<sizepos[1]; ii++){  //for the rest of the patterns
                     if(*ii >= *node)
                         break;
                     else{
                         if(CW[*ii][*node] == 1){
                             DeltaW[*ii][*node] = lrate[*node] * Phi[*ii][nump] * Gradient[*node] + momentum[0] * DeltaW[*ii][*node];
                             DeltaW2[*ii][*node] = lrate[*node] * Phi[*ii][nump] * Gradient2[*node] + momentum[0] * DeltaW2[*ii][*node];
                             tempSum[nump][*ii][*node] = W[*ii][*node] + DeltaW2[*ii][*node];
                             W[*ii][*node] += DeltaW[*ii][*node];    // original // W[*ii][*node] = W[*ii][*node] + DeltaW[*ii][*node];
                         }
                     }
                     contii++;
                 }
                 contnode++;
             }
         }//for nump --> all paterns

         for(k=0; k<sizepn; k++){
        	 for(i=0; i<NumNodesNet; i++){
        		 for(j=0; j<NumNodesNet; j++){
        			 tempSum2[i][j] += tempSum[k][i][j];
        		 }
        	 }
         }
         //	printf("Tempsum2\n"); 	imprimeMd(tempSum2,varN->finalInp+varN->hidden+varN->VnoOutputs,varN->finalInp+varN->hidden+varN->VnoOutputs);
         abs(tempSum2,NumNodesNet,NumNodesNet,tempSum2);
         //	printf("Tempsum2 with abs\n"); 	imprimeMd(tempSum2,varN->finalInp+varN->hidden+varN->VnoOutputs,varN->finalInp+varN->hidden+varN->VnoOutputs);

         //calculate the mean
         for(i=0; i<NumNodesNet; i++){
        	 for(j=0; j<NumNodesNet; j++){
        		 meantempSum[i][j] = tempSum2[i][j]/sizepn;
        	 }
         }
         //	printf("Mean temp sum\n"); 	imprimeMd(meantempSum,varN->finalInp+varN->hidden+varN->VnoOutputs,varN->finalInp+varN->hidden+varN->VnoOutputs);

         // Rest the mean and sum all the weights
         copy(divisor,test,NumNodesNet,NumNodesNet);

         for(k=0; k<sizepn; k++){
        	 for(i=0; i<NumNodesNet; i++){
        		 for(j=0; j<NumNodesNet; j++){
        			 divisor[i][j] += (tempSum[k][i][j] - meantempSum[i][j]) * (tempSum[k][i][j] - meantempSum[i][j]);
        		 }
        	 }
         }
         //	printf("Divisor\n"); 	imprimeMd(divisor,varN->finalInp+varN->hidden+varN->VnoOutputs,varN->finalInp+varN->hidden+varN->VnoOutputs);

         for(i=0; i<NumNodesNet; i++){
        	 for(j=0; j<NumNodesNet; j++){
        		 divisor[i][j] = sqrt(divisor[i][j]);
        	 }
         }
         //	printf("Divisor after sqrt\n"); 	imprimeMd(divisor,varN->finalInp+varN->hidden+varN->VnoOutputs,varN->finalInp+varN->hidden+varN->VnoOutputs);

         contii=0;
         for(ii=allnodes; contii<sizeallnodes; ii++){
        	 contjj = 0;
        	 for(jj=poshidden; contjj<sizepos[1]; jj++){
        		 if((CW[*ii][*jj] == 1) && (divisor[*ii][*jj] !=0))
        			 test[*ii][*jj] = tempSum2[*ii][*jj]/divisor[*ii][*jj];
        		 contjj++;
        	 }
        	 contii++;
         }

         contii = 0;
         for(ii=poshidden; contii<sizepos[1]; ii++){
        	 if(bias[*ii] == 1 && divisor[*ii][*ii] !=0)
                 test[*ii][*ii] = tempSum2[*ii][*ii]/divisor[*ii][*ii];
        	 contii++;
         }
         //cout << "Test Matrix " << endl; 	imprime(test,varN->finalInp+varN->hidden+varN->VnoOutputs,varN->finalInp+varN->hidden+varN->VnoOutputs);

         /////////////////////////////////////////////////////////////////////////////////
         jj = NULL;
         ii = NULL;
         node = NULL;
         safefree(&poshidden22);
         safefree(&poshidden2);
         safefree(&DeltaW2,NumNodesNet);
         safefree(&Gradient2);
         safefree(&meantempSum,NumNodesNet);
         safefree(&divisor,NumNodesNet);
         safefree(&tempSum2,NumNodesNet);
         safefree(&tempSum,sizepn,NumNodesNet);
         safefree(&Gradient);
         safefree(&Phi,NumNodesNet);
         safefree(&Vj,NumNodesNet);
         tn = NULL;
         pn = NULL;
         safefree(&allnodes);
	 }
	 catch (...) {
		 cout << "Something were wrong in importance funtion" << endl;
		 processException();
		 exit(EXIT_FAILURE);
	 }
}//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




// copy network n2 into (this), no allocate mem, it is suppose that the same network have the same
//Number of parameters
void C_network::copyNet(C_network *n2)
{
	try{
		int n2Nodes = (n2->varN->inputs * n2->varN->Vfilecol) + n2->varN->hidden + n2->varN->VnoOutputs;
		int n1Nodes = (varN->inputs * varN->Vfilecol) + varN->hidden + varN->VnoOutputs;


		// if at leat both networks have the same number of node sin the net
		if(n2Nodes != n1Nodes){
			throw 6;
		}

		//Copy classes
		varN->copyClass(n2->varN);
		Epochs->copyClass(n2->Epochs, n2->varN);

		// if I copy two nets, I am interested in the weights or more param of the net, not in the sets
		// they must be the same, so sets are not copied, even the funtion exist to do that
		//sets->copyClass(n2->sets);

		// Copy the rest of the parameters
		copy(CW,n2->CW,n2Nodes,n2Nodes);
		copy(W,n2->W,n2Nodes,n2Nodes);
		if (isDualWeights == ON)
			 copy(W2,n2->W2,n2Nodes,n2Nodes);

		copy(DeltaW,n2->DeltaW,n2Nodes,n2Nodes);
		copy(nodes,n2->nodes,n2Nodes);
		copy(bias,n2->bias,n2Nodes);
		copy(posinputs,n2->posinputs,(n2->varN->inputs * n2->varN->Vfilecol));
		copy(poshidden,n2->poshidden,n2->varN->hidden + n2->varN->VnoOutputs);
		copy(sizepos,n2->sizepos,2);
		momentum[0] = n2->momentum[0];

		copy(singleLrate, n2->singleLrate, NUM_MODULES);
		copy(lrate, n2->lrate,  n2Nodes);
		copy(lrateB, n2->lrateB,  n2Nodes);

		//lrateXepochs -- I do not use it, if do, the initialize
		status[0] = n2->status[0];

		// copy parameters where the predictios are saved
		if(extraPredictions)
			this->copyAllPredictionsStruct(n2);

		if (isModule1 == ON){
			huskenModule->copyClass(n2->huskenModule);
			sharedModule->copyClass(n2->sharedModule);
		}

		predictI->copyClass(n2->predictI);
		predictF->copyClass(n2->predictF);
		/////////////////////////////////////////////////

		fitness[0] = n2->fitness[0];
		fitnessReal[0] = n2->fitnessReal[0];
		trainingWith[0] = n2->trainingWith[0];


		if (algoFeatures == SWAP_CONN){
			 contActiveConn = n2->contActiveConn;
			 contDeactConn = n2->contDeactConn;
			copy(activeConn, n2->activeConn, 3, contActiveConn);
			copy(deactConn, n2->deactConn, 3, contDeactConn);
			copy(rangeDeact, n2->rangeDeact, 2, 6);
		}





	}

	catch(const int &e){
		processException(e);
	}

	catch (...) {
		cout << "Something were wrong in the main" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
} /// end copy net /////////////////////////////////////////////////////////////////////////////


// copy network n2 into (this), allocate mem
void C_network::copyAllocNet(C_network *n2){
	/*!
	 * Importnat: allways copy allocating the maximum size as done in the initialization
	 * if it is allocated a small amount (when copying) and in a further genneration the matrix/vector require more space (max calculated at the beginning)
	 * there may be a seg fault or overwitten other info
	 */
	try{
		//Delete all structures in the actual class
		//if (this != NULL)
		if (this->varN != NULL)
			deleteAllStruct();


		//Allocate space for classes

		varN = new C_varN;
		varN->copyClass(n2->varN);

		// Next for epochs, now I have the correct varibales in varN
		Epochs = new C_Epochs;
		Epochs->copyAllocClass(n2->Epochs, n2->varN);

		// copy parameters where the predictios are saved
		if(extraPredictions == ON && task2solve == PREDICT){
			set2SSP = (C_predParam *) new C_predParam [numDiffPredict];		//no allocate any var
			set2MSP = (C_predParam *) new C_predParam [numDiffPredict];		//no allocate any var
			this->copyAllocAllPred(n2);
		}

		if (isModule1 == ON){
			huskenModule = new C_module1();
			sharedModule = new C_module1();
			huskenModule->copyClass(n2->huskenModule);
			sharedModule->copyClass(n2->sharedModule);
		}

		predictI = new C_predParam;
		predictI->copyAllocClass(n2->predictI);

		predictF = new C_predParam;
		predictF->copyAllocClass(n2->predictF);

		// Next for sets
		sets = new C_sets;
		sets->copyAllocClass(n2->sets);		//copy allocating memory

		// Copy the rest of the variables
		int n2Nodes = (n2->varN->inputs * n2->varN->Vfilecol) + n2->varN->hidden + n2->varN->VnoOutputs;
		CW = copyAlloc(CW,n2->CW,n2Nodes,n2Nodes);
		W = copyAlloc(W,n2->W,n2Nodes,n2Nodes);
		if (isDualWeights == ON)
			W2 = copyAlloc(W2,n2->W2,n2Nodes,n2Nodes);

		DeltaW = copyAlloc(DeltaW,n2->DeltaW,n2Nodes,n2Nodes);
		nodes = copyAlloc(nodes,n2->nodes,n2Nodes);
		bias = copyAlloc(bias,n2->bias,n2Nodes);
		posinputs = copyAlloc(posinputs,n2->posinputs, n2->varN->finalInp);
		poshidden = copyAlloc(poshidden,n2->poshidden,n2->varN->hidden + n2->varN->VnoOutputs);

		momentum = copyAlloc(momentum,n2->momentum,1);

		singleLrate = copyAlloc(singleLrate, n2->singleLrate, NUM_MODULES);
		lrate= copyAlloc(lrate, n2->lrate,  n2Nodes);
		lrateB= copyAlloc(lrateB, n2->lrateB,  n2Nodes);

		fitness = copyAlloc(fitness,n2->fitness,1);
		fitnessReal = copyAlloc(fitnessReal,n2->fitnessReal,1);
		status = copyAlloc(status,n2->status,1);
		trainingWith = copyAlloc(trainingWith,n2->trainingWith,1);
		sizepos = copyAlloc(sizepos,n2->sizepos,2);

		if (algoFeatures == SWAP_CONN){
			contActiveConn = n2->contActiveConn;
			contDeactConn = n2->contDeactConn;
			activeConn = copyAlloc(activeConn, n2->activeConn, 3, n2Nodes*n2Nodes);
			deactConn = copyAlloc(deactConn, n2->deactConn, 3, n2Nodes*n2Nodes);
			rangeDeact = copyAlloc(rangeDeact, n2->rangeDeact, 2, 6);
		}




	}
	catch (...) {
		cout << "Something were wrong in copyAllocNet" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
}

// copy network n2 into (this), no allocate mem
void C_network::copyCleanNet(C_network *n2)
{
	try{
		//Clean all structures in the actual class
		if (this != NULL)
			this->cleanNet();

		// strat to copy
		varN->copyClass(n2->varN);
		Epochs->copyClass(n2->Epochs, n2->varN);

		if (extraPredictions == ON && task2solve == PREDICT)
			this->copyAllPredictionsStruct(n2);

		if (isModule1 == ON){
			huskenModule->copyClass(n2->huskenModule);
			sharedModule->copyClass(n2->sharedModule);
		}

		predictI->copyClass(n2->predictI);
		predictF->copyClass(n2->predictF);

		// Next for sets
		sets->copyClass(n2->sets);

		// Copy the rest of the variables
		int n2Nodes = (n2->varN->inputs * n2->varN->Vfilecol) + n2->varN->hidden + n2->varN->VnoOutputs;
		copy(CW,n2->CW,n2Nodes,n2Nodes);
		copy(W,n2->W,n2Nodes,n2Nodes);
		if (isDualWeights == ON)
			copy(W2,n2->W2,n2Nodes,n2Nodes);

		copy(DeltaW,n2->DeltaW,n2Nodes,n2Nodes);
		copy(nodes,n2->nodes,n2Nodes);
		copy(bias,n2->bias,n2Nodes);
		copy(posinputs,n2->posinputs, n2->varN->finalInp);
		copy(poshidden,n2->poshidden,n2->varN->hidden + n2->varN->VnoOutputs);
		copy(sizepos,n2->sizepos,2);

		momentum[0] = n2->momentum[0];

		copy(singleLrate, n2->singleLrate, NUM_MODULES);
		copy(lrate, n2->lrate,  n2Nodes);
		copy(lrateB, n2->lrateB,  n2Nodes);

		fitness[0] = n2->fitness[0];
		fitnessReal[0] = n2->fitnessReal[0];
		status[0] = n2->status[0];
		trainingWith[0] = n2->trainingWith[0];


		if (algoFeatures == SWAP_CONN){
			contActiveConn = n2->contActiveConn;
			contDeactConn = n2->contDeactConn;
			copy(activeConn, n2->activeConn, 3, contActiveConn);
			copy(deactConn, n2->deactConn, 3, contDeactConn);
			copy(rangeDeact, n2->rangeDeact, 2, 6);
		}




	}
	catch (...) {
		cout << "Something were wrong in copyAllocNet" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
}

// copy network n2 into (this), allocate mem
void C_network::cleanNet()
{
	try{

		int maxNodesN = (totalMaxInput * filecol) + totalMaxHidden + noOutputs;
		int maxfinalInp = totalMaxInput * filecol;
		//Clean all

		if (isModule1 == ON){
			huskenModule->clean();
			sharedModule->clean();
		}

		varN->clean();

		// Next for epochs, now I have the correct varibales in varN
		Epochs->clean();

		// copy parameters where the predictios are saved
		if(extraPredictions == ON && task2solve == PREDICT)
			this->cleanAllPred();

		predictI->clean();
		predictF->clean();

		// Next for sets
		sets->clean();

		set(CW,maxNodesN,maxNodesN, 0);
		set(W,maxNodesN,maxNodesN, 0);
		if (isDualWeights == ON)
			set(W2,maxNodesN,maxNodesN, 0);

		set(DeltaW,maxNodesN,maxNodesN, 0);
		set(nodes,maxNodesN, 0);
		set(bias,maxNodesN, 0);

		set(posinputs, maxfinalInp, 0);
		set(poshidden, totalMaxHidden + noOutputs, 0);

		set(sizepos, 2, 0);		//contain how many inputs and nodes it have, sizepos[0], sizepos[1].
		momentum[0] = momentum1;

		set(singleLrate, NUM_MODULES, 0);
		set(lrate, maxNodesN, 0);
		set(lrateB, maxNodesN, 0);

		status[0] = 0;
		trainingWith[0] = 0;
		fitness[0] = -100;
		fitnessReal[0] = -100;


		if (algoFeatures == SWAP_CONN){
			contActiveConn = 0;
			contDeactConn = 0;
			set(activeConn, 3, maxNodesN*maxNodesN, 0);
			set(deactConn, 3, maxNodesN*maxNodesN, 0);
			set(rangeDeact, 2, 6, 0);
		}





	}
	catch (...) {
		cout << "Something were wrong in copyAllocNet" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
}

void C_network::loadNet2setup(int *Input, int *Delay, int *Hidden, int *Outputs, char *file){
	//This file is related to the funtion in matlab saveSingleNet.m

	if (MYDEBUG_LOADNET == 1) 	cout << "file used to load =" << file << endl;

    FILE *f3;
    //register int i,j;
    //int sizei = *sizeii;
    int finalInp = 0;
    //int bandE = 0;		//to detect an error, 0= ok, 1 = error

    float svalue;

    //open file
    if((f3 = fopen(file,"r")) == NULL){
    	cout << "Error cannot open file to read network " << endl;
    	exit(0);
    }

    //Start to load
    //input
    if(fscanf(f3,"%f",&svalue) != EOF){
    	Input[0] = (int) svalue;
    }
    //Final input
    if(fscanf(f3,"%f",&svalue)!= EOF){
    	finalInp = (int) svalue;
    }
    //Delay
    if(fscanf(f3,"%f",&svalue)!= EOF){
    	Delay[0] = (int) svalue;
    }
    //Hidden
    if(fscanf(f3,"%f",&svalue)!= EOF){
    	Hidden[0] = (int) svalue;
    }

    //Outputs
    if(fscanf(f3,"%f",&svalue)!= EOF){
    	Outputs[0] = (int) svalue;
    }

    if (MYDEBUG_LOADNET == 1){
    cout << "inputs = " << Input[0] << endl;
   	cout << "FinalInputs (not saved) = " << finalInp << endl;
   	cout << "Delays = " << Delay[0] << endl;
   	cout << "Hidden = " << Hidden[0] << endl;
 	cout << "Outputs = " << Outputs[0] << endl;
    }

    fclose(f3);
//getchar();
}////////////////////////////////////////////////////////////////////////////////////////


void C_network::loadNetAll(char *file){
	//This file is related to the funtion in matlab saveSingleNet.m

	if (MYDEBUG_LOADNET == 1) 	cout << "file used to load =" << file << endl;

    FILE *f2;
    register int i,j;
    //int sizei = *sizeii;
    int input = 0, finalInp = 0, delay = 0, hidden = 0, output = 0, allnodes = 0;


    float svalue;

    //open file
    if((f2 = fopen(file,"r")) == NULL){
    	cout << "Error cannot open file to read network (method: loadNetAll)" << endl;
    	exit(0);
    }

    //Start to load
    if(fscanf(f2,"%f",&svalue) != EOF){
    	input = (int) svalue;
    	//cout << "input = " << input << " svalue = " << svalue << " maxinput = " << varN->inputs << endl;
    }
    if(fscanf(f2,"%f",&svalue) != EOF){
    	finalInp = (int) svalue;
    	//cout << "FinalInp = " << finalInp << " svalue = " << svalue << endl;
    }

    if(fscanf(f2,"%f",&svalue)!= EOF){
    	delay = (int) svalue;
		//cout << "delay = " << delay << " svalue = " << svalue << " varN->delay = " << varN->delays << endl;
    }
    if(fscanf(f2,"%f",&svalue)!= EOF){
    	hidden = (int) svalue;
    	//cout << "hidden = " << hidden << " svalue = " << svalue << " varN->hidden = " << varN->hidden << endl;
    }
    if(fscanf(f2,"%f",&svalue)!= EOF){
    	output = (int) svalue;
    	//cout << "output = " << output << " svalue = " << svalue << " varN->VnoOutputs = " << varN->VnoOutputs << endl;
        }

    //Check if the network was initialized correctly with the hpp file
    if ( reuseModule == OFF){
    	if(input != varN->inputs || finalInp != varN->finalInp || delay != varN->delays || hidden != varN->hidden || varN->VnoOutputs != output){
    		cout << "Error, the input (or finalInp, delay of hidden nodes) in the network do not match with values previously read" << endl;
    	}
    }

   allnodes = finalInp + hidden + output; //varN->VnoOutputs;

    //Continue loading the rest of the network
    for (i=0; i<allnodes; i++){
    	for(j=0; j<allnodes; j++){
    		if(fscanf(f2,"%f",&svalue)!= EOF)
    			CW[i][j] = (int) svalue;
    	}
    }
    for (i=0; i<allnodes; i++){
    	for(j=0; j<allnodes; j++){
    		if(fscanf(f2,"%f",&svalue)!= EOF)
    			W[i][j] = svalue;
    	}
    }
    if (isDualWeights == ON){
    	for (i=0; i<allnodes; i++){
    		for(j=0; j<allnodes; j++){
    			if(fscanf(f2,"%f",&svalue)!= EOF)
    				W2[i][j] = svalue;
    		}
    	}
    }
    for (i=0; i<allnodes; i++){
    	for(j=0; j<allnodes; j++){
    		if(fscanf(f2,"%f",&svalue)!= EOF)
    			DeltaW[i][j] = svalue;
    	}
    }
    for (i=0; i<allnodes; i++){
    	if(fscanf(f2,"%f",&svalue)!= EOF)
    		nodes[i] = (int) svalue;
    }
    for (i=0; i<allnodes; i++){
    	if(fscanf(f2,"%f",&svalue)!= EOF)
    		bias[i] = (int) svalue;
    }
    //sizepos
    for (i=0; i<2; i++){
    	if(fscanf(f2,"%f",&svalue)!= EOF)
    		sizepos[i] = (int) svalue;
    }

    for (i=0; i<sizepos[0]; i++){
    	if(fscanf(f2,"%f",&svalue)!= EOF)
    		posinputs[i] = (int) svalue;
    }

    for (i=0; i<sizepos[1]; i++){
    	if(fscanf(f2,"%f",&svalue)!= EOF)
    		poshidden[i] = (int) svalue;
    }

    //momentum
    if(fscanf(f2,"%f",&svalue)!= EOF)
    	momentum[0] = svalue;

    // lrate
    for (i=0; i<allnodes; i++){
    	if(fscanf(f2,"%f",&svalue)!= EOF)
    		lrate[i] = svalue;
    }
    // lrateB (learning rate for the bias)
    for (i=0; i<allnodes; i++){
    	if(fscanf(f2,"%f",&svalue)!= EOF)
    		lrateB[i] = svalue;
    }

    // To know how many times has been loaded
    if(fscanf(f2,"%f",&svalue)!= EOF)
    	varN->counterLoaded = (int) svalue;

    // increment the counter
    varN->counterLoaded++;


    //check the last band, must be -1
    if(fscanf(f2,"%f",&svalue)!= EOF){
    	if(svalue != -1){
    		cout << "There is an error at the end, the band doesn not mach, check the file it could be bigger or maybe smaller" << endl;
    		exit(0);
    	}
    }

    fclose(f2);
    //getchar();

    //to test that the information is correct, save in independent file each part
   /* saveInt("temp/CW.txt", CW, allnodes, allnodes);
    saveD("temp/W.txt", W, allnodes, allnodes);
    saveInt("temp/nodes.txt", nodes, allnodes);
    saveInt("temp/bias.txt", bias, allnodes);
    saveInt("temp/posinputs.txt", posinputs, input);
    saveInt("temp/poshidden.txt", poshidden+varN->VnoOutputs, hidden);
    cout << "sizepos[] = " << sizepos[0] << "," << sizepos[1] << endl;
    cout << "momentum = " << momentum[0] << endl;
    cout << "lrate = " << lrate[0] << endl;

*/

}////////////////////////////////////////////////////////////////////////////////////////






int C_network::loadModule( int ind, int ds, int mod  ){
/*!
 * Load a module from a list of modules
 *
 */

	// Local variables
	int n,i,j, allnodes;
	FILE *f2;

	string filePath = "../pool/";
	string fileM = "M"; 	//fileNet = "resPop/";
	//string dataSet = ""; 										// j value ...there is a list of data set and ther correspondient number in the file CONS.hpp
	string subtask = "";
	string fileFinal = "";

	// Declarate variables that use a convertion form int to char
	char strInd[3];
	char strMod[3];
	char dataSet[3];

	// obtain name to load
	n = sprintf (strInd , "%d", ind);
	n = sprintf (dataSet , "%d", ds);
	n = sprintf (strMod , "%d", mod);
	fileFinal = filePath + isRun + "_" + dataSet + fileM + strMod + "_ind" + strInd;
	//cout << fileFinal << endl;

	// clean this network, it does not matter that structures like predParam are not set up,
	// I will use the class just to save the loaded module and later copy it to the real network
	cleanNet();

	// Start to copy the loaded values into the network



	if (MYDEBUG_LOADNET == 1) 	cout << "file used to load =" << fileFinal << endl;

    //int input = 0, finalInp = 0, delay = 0, hidden = 0, output = 0, allnodes = 0;


    float svalue;

    //open file
    if((f2 = fopen( fileFinal.c_str(), "r" )) == NULL){
    	cout << "Error cannot open file to read network (method: loadModule)" << endl;
    	exit(0);
    }

    //Start to load
    if(fscanf(f2,"%f",&svalue) != EOF){
    	varN->inputs = (int) svalue;
    	//cout << "input = " << input << " svalue = " << svalue << " maxinput = " << varN->inputs << endl;
    }
    if(fscanf(f2,"%f",&svalue) != EOF){
    	varN->finalInp = (int) svalue;
    	//cout << "FinalInp = " << finalInp << " svalue = " << svalue << endl;
    }


    if(fscanf(f2,"%f",&svalue)!= EOF){
    	varN->hidden = (int) svalue;
    	//cout << "hidden = " << hidden << " svalue = " << svalue << " varN->hidden = " << varN->hidden << endl;
    }


    /// Important here !!!!!!!
    // if the module does not have any hidden nodes, discard this one and reload another
    if (varN->hidden <= 0)
    	return (1); 		// something was wrong



    if(fscanf(f2,"%f",&svalue)!= EOF){
    	varN->VnoOutputs = (int) svalue;
    	//cout << "output = " << output << " svalue = " << svalue << " varN->VnoOutputs = " << varN->VnoOutputs << endl;
        }


   allnodes = varN->finalInp + varN->hidden + varN->VnoOutputs;

    //Continue loading the rest of the network
    for (i=0; i<allnodes; i++){
    	for(j=0; j<allnodes; j++){
    		if(fscanf(f2,"%f",&svalue)!= EOF)
    			CW[i][j] = (int) svalue;
    	}
    }
    for (i=0; i<allnodes; i++){
    	for(j=0; j<allnodes; j++){
    		if(fscanf(f2,"%f",&svalue)!= EOF)
    			W[i][j] = svalue;
    	}
    }

    if (isDualWeights == ON){
    	for (i=0; i<allnodes; i++){
    		for(j=0; j<allnodes; j++){
    			if(fscanf(f2,"%f",&svalue)!= EOF)
    				W2[i][j] = svalue;
    		}
    	}
    }

    for (i=0; i<allnodes; i++){
    	for(j=0; j<allnodes; j++){
    		if(fscanf(f2,"%f",&svalue)!= EOF)
    			DeltaW[i][j] = svalue;
    	}
    }
    for (i=0; i<allnodes; i++){
    	if(fscanf(f2,"%f",&svalue)!= EOF)
    		nodes[i] = (int) svalue;
    }
    for (i=0; i<allnodes; i++){
    	if(fscanf(f2,"%f",&svalue)!= EOF)
    		bias[i] = (int) svalue;
    }
    //sizepos
    for (i=0; i<2; i++){
    	if(fscanf(f2,"%f",&svalue)!= EOF)
    		sizepos[i] = (int) svalue;
    }

    for (i=0; i<sizepos[0]; i++){
    	if(fscanf(f2,"%f",&svalue)!= EOF)
    		posinputs[i] = (int) svalue;
    }

    for (i=0; i<sizepos[1]; i++){
    	if(fscanf(f2,"%f",&svalue)!= EOF)
    		poshidden[i] = (int) svalue;
    }

    //momentum
    if(fscanf(f2,"%f",&svalue)!= EOF)
    	momentum[0] = svalue;

    // lrate
    for (i=0; i<allnodes; i++){
    	if(fscanf(f2,"%f",&svalue)!= EOF)
    		lrate[i] = svalue;
    }
    // lrateB (learning rate for the bias)
    for (i=0; i<allnodes; i++){
    	if(fscanf(f2,"%f",&svalue)!= EOF)
    		lrateB[i] = svalue;
    }


    // To know how many times the module has been loaded
    if(fscanf(f2,"%f",&svalue)!= EOF)
    	varN->counterLoaded = (int) svalue;


    // increment the counter
    varN->counterLoaded++;

    // create a temporal matrix to save the history
    //C_matrix *tmpMat = NULL;
    //tmpMat = new C_matrix;


    // load lines and cols for the history
    huskenModule->history[0].loadMat(f2);
    //imprime(huskenModule->history[0].m, huskenModule->history[0].lines, huskenModule->history[0].cols);




    //check the last band, must be -1
    if(fscanf(f2,"%f",&svalue)!= EOF){
    	if(svalue != -1){
    		cout << "There is an error at the end, the band doesn not mach, check the file it could be bigger or maybe smaller" << endl;
    		exit(0);
    	}
    }

    fclose(f2);
    //getchar();

    //to test that the information is correct, save in independent file each part
   /* saveInt("temp/CW.txt", CW, allnodes, allnodes);
    saveD("temp/W.txt", W, allnodes, allnodes);
    saveInt("temp/nodes.txt", nodes, allnodes);
    saveInt("temp/bias.txt", bias, allnodes);
    saveInt("temp/posinputs.txt", posinputs, input);
    saveInt("temp/poshidden.txt", poshidden+varN->VnoOutputs, hidden);
    cout << "sizepos[] = " << sizepos[0] << "," << sizepos[1] << endl;
    cout << "momentum = " << momentum[0] << endl;
    cout << "lrate = " << lrate[0] << endl;

*/

    // Liberate memory
   // delete tmpMat;

    return (0); // all was ok
}////////////////////////////////////////////////////////////////////////////////////////





void C_network::set_allPredictionsStruct(int num,int initialStep){
	// set all the prediciton structures
	int cont = initialStep;
	for(int i=0; i<num; i++){
		set2SSP[i].set_predParam(varN->Vsizetpos,cont,varN->finalInp,cont);
		set2MSP[i].set_predParam(varN->Vsizetpos,cont,varN->finalInp,1);
		cont *= 2;
	}

}


void C_network::copyAllocAllPred(C_network *n2){
	//int cont = initialStepPred;
	for(int i=0; i<numDiffPredict; i++){
		set2SSP[i].copyAllocClass( &(n2->set2SSP[i]) );
		set2MSP[i].copyAllocClass( &(n2->set2MSP[i]) );
		/* Old code check that it works for prediction the code above
		 * set2SSP[i].copyAllocClass(&(n2->set2SSP[i]), cont);
		set2MSP[i].copyAllocClass(&(n2->set2MSP[i]), 1);
		 cont *= 2;
		*/
	}

}

void C_network::copyAllPredictionsStruct(C_network *n2){
	//int cont = initialStepPred;
	for(int i=0; i<numDiffPredict; i++){
		set2SSP[i].copyClass( &(n2->set2SSP[i]) );
		set2MSP[i].copyClass( &(n2->set2MSP[i]) );
		/* Old caode the same as the previous funtion
		 * set2SSP[i].copyClass(&(n2->set2SSP[i]), cont);
		set2MSP[i].copyClass(&(n2->set2MSP[i]), 1);
		 cont *= 2;
		*/
	}
}

void C_network::cleanAllPred(void){
	for(int i=0; i<numDiffPredict; i++){
		set2SSP[i].clean();
		set2MSP[i].clean();
	}
}


// forecast a value, the inputs are send through the network
 void C_network::singleStepPred(double **pn, int colpn, double **prediction)
 {
	 int register nump,contnode,contii;
	 double **Vj = NULL;
	 double **Phi = NULL;

	 int *ii = NULL;
     int *node = NULL;
     int linepred = 0;
     int nodesNet = (varN->inputs * varN->Vfilecol) + varN->hidden + varN->VnoOutputs;


     Vj = allocate(Vj,nodesNet,colpn);
     Phi = allocate(Phi,nodesNet,colpn);

     //Send patterns through the network
     for(nump=0; nump<colpn; nump++){            //printf("nump %d\n",nump);
             contnode=0;
             for(node=poshidden; contnode<sizepos[1]; node++){                //printf("node %d\n",*node);
                 if(bias[*node] == 1)
                     Vj[*node][nump] = W[*node][*node]; //sum the bias
                 else
                     Vj[*node][nump] = 0;               //imprimeMd(Network->W,varN->finalInp+varN->hidden+varN->VnoOutputs,varN->finalInp+varN->hidden+varN->VnoOutputs);                //printf("Sum bias,   Vj[%d][%d]=%f\n",*node,nump,Vj[*node][nump]);

                 contii=0;                //printf("pos inputs \n"); imprimeVi(Network->posinputs,Network->sizepos[0]);
                 for(ii=posinputs; contii<sizepos[0]; ii++){  //for all the entrances                    //printf("for inputs ii=%d\n",*ii);
                	 if( nodes[ *ii ] != 0){	  // if( *ii != -1){
                		 if(CW[*ii][*node] == 1){
                			 Vj[*node][nump] = Vj[*node][nump] + pn[*ii][nump] * W[*ii][*node];                        //printf("Inputs for Vj,   Vj[%d][%d]=%f, pn[%d][%d]=%f, Network->W[%d][%d]=%f\n",*node,nump,Vj[*node][nump],*ii,nump,pn[*ii][nump],*ii,*node,Network->W[*ii][*node]);
                		 }
                	 }
                	 contii++;
                 }

                 contii=0;
                 for(ii=poshidden; contii<sizepos[1]; ii++){ //for the rest of the patterns                     //printf("for hidden ii=%d\n",*ii);
                     if(CW[*ii][*node] == 1){

                         Vj[*node][nump]= Vj[*node][nump] + Phi[*ii][nump] * W[*ii][*node];                        //printf("Hidden for Vj,   Vj[%d][%d]=%f, Phi[%d][%d]=%f, Network->W[%d][%d]=%f\n",*node,nump,Vj[*node][nump],*ii,nump,Phi[*ii][nump],*ii,*node,Network->W[*ii][*node]);
                     }
                     else{
                         if(*ii == *node){                            //printf("Break for hidden *ii = *node = %d\n",*ii);
                             break;
                         }
                     }
                     contii++;
                 }
                 if( (*node >= (varN->finalInp + varN->hidden) ) &&  (*node <= nodesNet) ){  												 // if it is the last layer
                	 if ( transferFunOutput == LINEAL )																													// Linear transfer funtion in output nodes
                		 Phi[*node][nump] = Vj[*node][nump];  																										//linear output
                	else if ( transferFunOutput == SIGMOID )																																								// sigmoid transfer funtion
                		 Phi[*node][nump] = 1.0/(1.0 + exp(-Vj[*node][nump])) ;   																		// Sigmoidal Outputs

                	 // save the predictions
                	 prediction[linepred][nump] = Phi[*node][nump];
                	 linepred++;
                }
                 else{																																									// hidden nodes, transfer function
                	 if(transferFunHidden == HTAN)
                		 Phi[*node][nump] = tanh(Vj[*node][nump]);																							//(exp(Vj[*node][nump])-exp(-Vj[*node][nump]))/(exp(Vj[*node][nump])+exp(Vj[*node][nump]));
                	 else if(transferFunHidden == SIGMOID)
                		 Phi[*node][nump] = 1.0/(1.0 + exp(-Vj[*node][nump])) ;   																		// Sigmoidal Outputs
                 }
                 contnode++;
             }//for to calculate outputs
             linepred = 0;				// restart to count from zero for the next pattern
         }//for nump --> all paterns


     // Liberate memory
     node = NULL;
     ii = NULL;
     safefree(&Phi,nodesNet);
     safefree(&Vj,nodesNet);
}//////////////////////////////////////////////////////////////////////////

 double **C_network::iteratepred(C_predParam *pred, double **input11, int *Sinput1){

 	 // Inputs: //////////////////////////////////////////////////////////////////////
 	 //			pred 					contain all the informatin needed
 	 //			input11					all the input file, it is used to append the predctions and
 	 //									take the next inputs for the ann (iterate predicion)
 	 //			Sinput1					Size of the input11(lines and cols)
 	 // Output	input11					cause it is incremente here and declarate one level up is returned with the new Sinput
 	 //			prediciton				is a pointer, so it is returned automatically
 	 /////////////////////////////////////////////////////////////////////////////////

 	 register int i,j;

     //int menos = varN->VnoInputsDelay;
     int lineinput1, colinput1;
     double **predictionnorm = NULL;
     double **set4predictn = NULL;

     predictionnorm = allocate(predictionnorm,varN->Vsizetpos,1);

     //initizlize some variables
     lineinput1 = Sinput1[0];
     colinput1 = Sinput1[1];
     //printf("line %d col %d",lineinput1,colinput1);
     set4predictn = copyAlloc(set4predictn,pred->inputAnn, pred->linesP, pred->colsP);						// old line /// - >     set4predictn = copyAlloc(set4predictn,pred->inputAnn,noInputs,1);

     // This is a code designed to test that the lines and cols of pred param are setup correctly, it is put here randonly and the pourpose is to detect errors
     if ( pred->linesP != varN->finalInp || pred->linesT != varN->Vsizetpos || pred->colsP != 1){     	 cout << "ERROR.... PREDPARAM IS NOT SETUP CORRECTLY, LINESP, LINEST OR COLSP... EXIT" << endl;  		exit (0); 		}

     //for all the point to set2MSP
     for(i=0; i < pred->colsT; i++){
    	 singleStepPred(set4predictn,1,predictionnorm);				// I am not usre that varN->Vsizetpos works ok when there where more outputs, checkkkkkkk
																															 // Changed varN->Vsizetpos by 1, becuase in MSP always there is only one input vector

         for(j=0; j < varN->Vsizetpos; j++){
             pred->pred[j][i] = predictionnorm[j][0];
         }
         //cout << "prediciton" << endl;
         //imprime(pred->pred,1,i+1);

         //IDEA HERE I COULD RETRAIN THE NETWORK ONLY WITH THIS NEW PATTERN AND
         //CONTINIUE

         //increment the original vector with last forecasting

         input11 = (double **) realloc(input11,((lineinput1+1)*sizeof(double *)));
         input11[lineinput1] = (double *) malloc(sizeof(double));
         for(j=0; j<varN->Vsizetpos; j++){
             input11[lineinput1] = (double *) realloc(input11[lineinput1],(j+1)*sizeof(double));
             input11[lineinput1][j] = predictionnorm[j][0];
         }
        lineinput1++;

         //obtain the new input set to introduce in the Network
        takeInputAnn(set4predictn,input11,lineinput1,Sinput1,varN, 1);   //1 because it is MSP, so take only one input
        //cout << "set to set2MSP" << endl;
        //imprime(set4predictn, pred->maxInp,1);
     }

     Sinput1[0] = lineinput1;
     //printf("Preeictio\n"); imprimeMd(prediction,varN->Vsizetpos,varN->VPred_stepAhead);


     safefree(&set4predictn,pred->linesP);
     safefree(&predictionnorm,varN->Vsizetpos);

     return(input11);
  }/////////////////////////////////////////////////////////////////////////////////////////






void C_network::obtainPerformanceNet(double **input, int *Sinput,C_predParam *pred, int KindPred){
	/*!
	 *  Function to calculate the prediction, mean, NRMSE and accuracy
	 *  Input:
	*			input			the original data loaded
	*	 		Sinput			size of the input
	*			pred			structure with all the fields to save the performance
	* Output:
	* 			pred			The structure with the prediciton, NRMSE, accuracyPoint and accuracy
	*/


	obtainPredictions(input, Sinput, pred, KindPred);


	// Obtain the performance
	if ( isRealPredictionUsed == OFF){
		if (task2solve == PREDICT  || ( strcmp( typeDS.c_str(), "NRMSE" ) == 0)){ 			// ( strcmp( typeDS.c_str(), "wta" ) == 0) is for prediction tasks formatted as DataSets, they use only SSP
			nrmse(pred);
			//mse(pred);
			rmse(pred);

			if ( (  ( strcmp( typeDS.c_str(), "NRMSE" ) == 0) || ( isModule1 == ON ) ) && NUM_MODULES > 1 )    // if there are modules, calculate the NRMSE per module
				nrmsePerModule(pred->EpercentagePerModule, pred->pred, pred->toPredict, pred->linesT, pred->colsT);  // if you commet this line the error per module will be in terms of Ep

		}
		else if( ( strcmp( typeDS.c_str(), "NRMSE" ) != 0) ) {

			// E r r o r   p e r c e n t a g e
			pred->Epercentage = errorPercentage(pred->pred, pred->toPredict, pred->linesT, pred->colsT);   // most used for classification

			if ( task2solve == CLASSIFY  && isModule1 == ON)
				errorPercentagePerModule(pred->EpercentagePerModule, pred->pred, pred->toPredict, pred->linesT, pred->colsT);


			// C l a s s f i c a t i o n   E r r o r
			// Note that in this moment (at 10 Feb 2011) breast cancer, heart, ... and the similar to them are consdered as each output one module, but it may be all outputs one module too.
			if( ( strcmp( typeDS.c_str(), "wta" ) == 0)  || strcmp( typeDS.c_str(), "wta1" ) == 0 )
				pred->classifError = classifEWinnerTakeAllMOD(pred->pred, pred->toPredict, pred->linesT, pred->colsT, varN->minClass, varN->maxClass, pred->classifErrorPerModule, pred->incorrectPred);

			else if( strcmp( typeDS.c_str(), "modified" ) == 0 ){
				pred->classifError = classificationError(pred->pred, pred->toPredict, pred->linesT, pred->colsT, varN->minClass, varN->maxClass);
				classifErrorPerModule(pred->classifErrorPerModule, pred->pred, pred->toPredict, pred->colsT, varN->minClass, varN->maxClass,pred->incorrectPred);
			}
			else
				pred->classifError = classifEWinnerTakeAll(pred->pred, pred->toPredict, pred->linesT, pred->colsT, varN->minClass, varN->maxClass, pred->incorrectPred);

			 if( strcmp( typeDS.c_str(), "wta1" ) == 0 ) // I use this to cases like data set a1, b1, ..., one output per class and jsut one task to solve (i.e. one module or ANN)
				 pred->classifError = classifEWinnerTakeAll(pred->pred, pred->toPredict, pred->linesT, pred->colsT, varN->minClass, varN->maxClass, pred->incorrectPred);

			// this vars are loaded with acript_plotClasses_plorBadPrediciton in workspace2\generateDS
			/*saveD((char *)"../../workspace2/genDataSetModular/res/inputANN.txt", predictI->inputAnn, predictI->linesP, predictI->colsP);
			saveD((char *)"../../workspace2/genDataSetModular/res/target.txt", predictI->toPredict, predictI->linesT, predictI->colsT);
			saveD((char *)"../../workspace2/genDataSetModular/res/pred.txt", predictI->pred, predictI->linesT, predictI->colsP);
			saveInt((char *)"../../workspace2/genDataSetModular/res/incorrect.txt",predictI->incorrectPred, NUM_MODULES, predictI->colsT);
*/
			if ( flagDebug == ON ) cout << "C l a s s i f i c a t i o n   E r r o r  (general - InsideEA) =   "  << pred->classifError << endl;
		}
		accuracy(pred);
		//cout << "NRMSE = " << pred->NRMSE[0] << " Accuracy  = " << pred->accuracy[0] << "Accuracy point == " << endl;
		//imprime(pred->accuracyPoint,pred->lines, pred->stepsAhead);
		//saveD((char *)"../../workspace2/genDataSetModular/res/inputANN.txt", pred->inputAnn, pred->linesP, pred->colsP);


	}
}//////////////// Finish Obtain performance net





void C_network::obtainPredictions(double **input, int *Sinput,C_predParam *pred, int KindPred){
	/*!
	 * Fuction to obtain the predicciotn or classifications
	 */

	// Obtain the predictions
	if ( KindPred == MSP){
		//create local variables to not modify the original input and Sinput
		int *Sinp = NULL;
		double **inp = NULL;

		Sinp = copyAlloc(Sinp, Sinput, 2);
		inp = copyAlloc(inp, input, Sinput[0], Sinput[1]);

		////////////////////////////////////////////////////////////////////
		//Obtain the performance of the network
		inp = iteratepred(pred, inp, Sinp);

		// liberate memory
		safefree(&inp,Sinp[0]);
		safefree(&Sinp);
	}
	else if ( KindPred == SSP )
		singleStepPred(pred->inputAnn,pred->colsP, pred->pred);

}




// Function to calculate the prediction, mean, NRMSE and accuracy
void C_network::obtainPerformanceNetCell(double **input, int *Sinput){
	// Input: ////////////////////////////////////////////////////////////////////
	//			input			the original data loaded
	//	 		Sinput			size of the input
	//			pred			structure with all the fields to save the performance
	// Output:	pred			The structure with the prediciton, NRMSE, accuracyPoint and accuracy
	//////////////////////////////////////////////////////////////////////////////

	int i,cont = 0;

	/// first for the iterate case ///
	/////////////////////////////////

	//Obtain the performance of the network for each step_ahead: 15, 30, 60, 120,...
	for(i=0; i < numDiffPredict; i++)
		obtainPerformanceNet(input, Sinput, &(set2MSP[i]), MSP);


	// Now for the one Step ahead case //
	////////////////////////////////////

	cont = initialStepPred;
	for(i=0; i < numDiffPredict; i++){
		singleStepPred(set2SSP[i].inputAnn,cont,set2SSP[i].pred);
		nrmse( &(set2SSP[i]) );
		//mse( &(set2SSP[i]) );
		rmse( &(set2SSP[i]) );
		set2SSP[i].Epercentage = errorPercentage(set2SSP[i].pred, set2SSP[i].toPredict, set2SSP[i].linesT, set2SSP[i].colsT);   // most used for classification

		accuracy(&(set2SSP[i]));
		//cout << "New_OneStep_Pred[" << cont << "], NRMSE = " << set2SSP[i].NRMSE[0] << " accuracy =  " << set2SSP[i].accuracy[0] << endl;
		cont *= 2;
	}
	//cout << "pause... give enter" << endl; 	getchar();

}/////////////////////////////////////////////////////////////////////////////////////////////


void C_network::obtainActive_and_deact_conn(void){
	/*!
	 * Find the active and deactivated connections and thier ranges of each submatrix in the case if deactivated con
	 * How it will works, active and deactivated conn wil lhave three lines, [0][] indicate the submatrix they belong in range (0,4) where 0 = IH, 1= HO, ...
	 * rangeDeact have the horizontal index where each submatrix start, they are organized already in block by submatrices, e.g. [][0] to [][5] is IH, pos [][6] to [][12] is HO, ....
	 *
	 * The activeConn will be rearrange randomly every time a conenction is selected to swap, when it is selected, the first line [0][] indicate to which set it belongs
	 * then it is generated a ramdom number in accordance to its set and the ranges in deactive conn to choose a connection from the same set and swap it
	 *
	 * As you can see the ranges in rangeDEact will always be the same, and the first row of deactConn  will be the same, only positions [1][] and [2][] will be updated by the swap action
	 * The same happend in activeConn, in the swaoing process inly the lines 1 and 2 are swapped.
	 *
	 * Whit is information if is possible to select randomly an active connection from one sub-matrix and randomly select a non-activated conneciton in the same set to interchnage them
	 */

	// Local var
	int maxNodesN = (totalMaxInput * filecol) + totalMaxHidden + noOutputs;
	int i, subMat;

	// variables declarated in class
	activeConn = NULL;
	deactConn = NULL;
	rangeDeact = NULL;

	// allocate vars
	activeConn = allocate(activeConn, 3, maxNodesN * maxNodesN);
	deactConn =  allocate(deactConn, 3, maxNodesN * maxNodesN);
	// e.g. [0 1; 2 8;, ...] IH is ion range 0 to 1, HO in rnage 2 to 8 index, .... IO, HH and OO
    rangeDeact = allocate(rangeDeact, 2, 6);					// 5 because it is 6 sub-matrices IH,HO fro MLP and IO, HH and OO for GMLP and the bias


    // Method

    // obtain active and deactivated connection for MLP or GMLP (vars declarated in constructor)
    contActiveConn = obtaintConn(activeConn, 1);
    contDeactConn = obtaintConn(deactConn, 0);

    //cout << "C W" << endl;     																		imprime(CW,allnodes,allnodes);
    //cout << endl << "A c t i v e   c o n n e c t i o n s" << endl;     				imprime(activeConn,3,contActiveConn);
    //cout << endl << "D e a c t i v a t e d   c o n n e c t i o n s" << endl;     	imprime(deactConn,3,contDeactConn);

    // change in a random way active connections
    randomMat(activeConn, 0, 3, 0, contActiveConn);


    // obtain the ranges in deactivated connections
    rangeDeact[0][0] = 0; 																// first pos is the first idx of IH and it is ZERO
    rangeDeact[1][4] = contDeactConn-1; 			// not considering the bias

    subMat = 0;																					// identified for IH, I know it is the first
    for (i = 0; i < contDeactConn; i ++){
    	if ( deactConn[0][i] != subMat ){													// every time it changes it means that the next submatrix start
    		rangeDeact[1][subMat] = i-1;													// the second values of the previous sub-matrix (where it finishes)
    		rangeDeact[0][subMat + 1] = i;													// fill the first val of the next sub-matrix (where it strart)
    		subMat ++;
    	}
    	if (subMat > 4)
    		break;							//exit if arrives to OO, bias not counted in th is moment
    }

    //imprime(rangeDeact, 2, 6);

}//////////////////



void C_network::update_Lrate(int *flag2update){
	/*!
	 * Fuction to upadte the learning rate Clrate given lrate[module]
	 * If one node does not belog to any module, for any reason, it will be assigned the standard learning rate lrate1
	 */


	int nodesN = varN->finalInp + varN->hidden + varN->VnoOutputs;
	int i;


	// update the learning rate, case 0 do nothing as it is fixed the lrate
	switch (evolveLrate){
	case 1:
		// Evolve the learing rate, one for all the network. Put all to the base lrate
		if (NUM_MODULES == 1){
			for ( i = 0; i < nodesN; i++){
				lrate[i] = singleLrate[0];
				lrateB[i] = singleLrate[0];
			}
		}
		else if(NUM_MODULES > 1){
			for (i = 0; i < nodesN; i++ ){
				if (huskenModule->nodesInModule[i][1] > 0){
					lrate[i] =  singleLrate[ huskenModule->nodesInModule[i][1] -1];
					lrateB[i] =  singleLrate[ huskenModule->nodesInModule[i][1] -1];
				}
				else{
					lrate[i] = lrate1;						// if the nodes gets activated, this value will be override
					lrateB[i] = lrate1;
				}
			}
		}
		break;

	case 2:
		// Evolve lrate per node. Initialize each one in the selected range CHECK !!!
		if (NUM_MODULES == 1){
			for ( i = 0; i < nodesN; i++){
				lrate[i] += lrateMod * flag2update[0];
				lrateB[i] += lrateMod * flag2update[0];
				singleLrate[0] += lrate[i] + lrateB[i]; 												// to have an stimation of the av lrate in the module
			}
			singleLrate[0] /= (nodesN*2);
		}
		else if(NUM_MODULES > 1){
			int *cont = NULL;
			cont = allocate(cont, NUM_MODULES+5);							//+5 as an security offset
			set(singleLrate, NUM_MODULES,0);

			for ( i = 0; i < nodesN; i++){
				if (huskenModule->nodesInModule[i][1] > 0){
					lrate[i] += lrateMod *  flag2update[ huskenModule->nodesInModule[i][1] -1];   // it is lrateMod * 1 or -1
					lrateB[i] += lrateMod  * flag2update[ huskenModule->nodesInModule[i][1] -1];
					singleLrate[ huskenModule->nodesInModule[i][1] -1 ] += lrate[i] + lrateB[i]; 			// to have an stimation of the av lrate in the module
					cont[ huskenModule->nodesInModule[i][1] -1]+= 2;													// doubel as I sum lrate and lrateB
				}
				else{
					lrate[i] = lrate1;						// if the nodes gets activated, this value will be override
					lrateB[i] = lrate1;
				}
			}
			for ( i = 0; i < NUM_MODULES; i++){
				if (cont[i]>0)
					singleLrate[i] /= cont[i];
			}
			// liberate mem
			safefree(&cont);
		}

		break;

	default:
		cout << " Error, C_network::update_Lrate  the option to evolve the learing rate does not match with any of availables, check your initial conditions are run again." << endl;
		cout << "Exit, error in function C_network::reset_lrate" << endl;
		exit(0);
	}

	// For debug
	//if (flagDebug == ON){
	//	for (i = 0; i < NUM_MODULES; i++)
	//		cout << "lrate Module " << i << " = " << singleLrate[i] << endl;
	//}


}


void C_network::reset_lrate(void){
	/*!
	 * Function to reset the learing rate
	 * It is considered different scenarion.
	 * if the lrate is fixed, evolved for all the network or evolved per nodes
	 */

	int nodesN = varN->finalInp + varN->hidden + varN->VnoOutputs;
	int i;
	// reset the learning rate
	switch (evolveLrate){
	case 0:
		// the same learing rate in the network, there is no need to reset it it never change. however in case of any error, it will be rest here
		for ( i = 0; i < nodesN; i++){
			lrate[i] = lrate1;
			lrateB[i] = lrate1;
		}
		// settle the single lrate as here it is evolved just one per network
		for ( i = 0; i< NUM_MODULES; i++)
			singleLrate[0] = lrate1;

		break;

	case 1:
		// Evolve the learing rate, one for all the network. Put all to the base lrate
		for ( i = 0; i < nodesN; i++){
			lrate[i] = lrate1;
			lrateB[i] = lrate1;
		}
		// settle the single lrate as here it is evolved just one per network
		for ( i = 0; i< NUM_MODULES; i++)
			singleLrate[i] = lrate1;

		break;

	case 2:
		// Evolve lrate per node. Initialize each one in the selected range
		for ( i = 0; i < nodesN; i++){
			lrate[i] = 0.01 + ( (0.5-0.01 ) * rando() );   	// a+(b-a)* rando();
			lrateB[i] = 0.01 + ( (0.5-0.01 ) * rando() );  	// in range [0.01, 0.5]
		}
		for ( i = 0; i< NUM_MODULES; i++)
			singleLrate[i] = lrate1;

		break;
	default:
		cout << " Error, the option to evolve the learing rate does not match with any of availables, check your initial conditions are run again." << endl;
		cout << "Exit, error in function C_network::reset_lrate" << endl;
		exit(0);
	}

}///////////////////////////////////////////////////////////


void C_network::perturbateLratePerNode(void){
	/*!
	 * Function to perturbate the learnig rate of some nodes
	 * For the case the learning rate is evolved per node in a steady state algorithm,
	 * i.e. as it is not used crossover it is not possible to evovle this parameter using two parents
	 */
	int nodesN = varN->finalInp + varN->hidden + varN->VnoOutputs;
	int i;

	for ( i = 0; i < nodesN; i++){
		lrate[i] += lrateModRange[0] + ( (lrateModRange[1] - lrateModRange[0] ) * rando() );   	// a+(b-a)* rando();
		lrateB[i] += lrateModRange[0] + ( (lrateModRange[1] - lrateModRange[0] ) * rando() );

		// check that I do not exeed the minimum
		if ( lrate[i] < minlrate )
			 lrate[i] = minlrate;
		if ( lrateB[i] < minlrate )
			lrateB[i] = minlrate;
	}
}/////////////////////////////////////////////////////////////////////////////////////////////////////////////////


#endif
