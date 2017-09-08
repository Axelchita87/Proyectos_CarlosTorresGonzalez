/*!
 * addDelNet.hpp
 *
 * Continuation of the methods from the network class
 * Created: 6/12/09
 * modified at: 18/08/10
 * Class val, contain the validation set for the ANN, val.p and val.t
 */

#ifndef ADDDELNET_HPP
#define ADDDELNET_HPP

int C_network::deleteNode(C_network **scalesNet){
	// function to delete hidden nodes (Looks ok)
	try{
		///////////////////////////////////////////////////////////////////////
		register int i;
		int nodes2delete=0,todelete;
		int validMutation = -1;
		/////////////////////////////////////////////////////////////////////////

		if(MYDEBUG_DelNode == 1){
			cout << " ******* Entering Delete Hidden Nodes function ***********" << endl;
			imprime(CW, (varN->finalInp + varN->hidden + varN->VnoOutputs),  (varN->finalInp + varN->hidden + varN->VnoOutputs) );
		}

		nodes2delete = (int)(minmutateN + mutatednodes * rando());

		if(MYDEBUG_DelNode == 1) {
			cout << "Avaible nodes to delete " << endl;
			imprime(poshidden,varN->hidden);
			cout << "size hidden nodes = " << varN->hidden << endl;
		}


		while(nodes2delete >= varN->hidden)
			nodes2delete --;

		if(MYDEBUG_DelNode == 1)  			cout << "Nodes to delete = " << nodes2delete << endl;
		//Decide nodes to be deleted
		if( (varN->hidden >= 2)  && (nodes2delete < (varN->hidden) )  && ( nodes2delete > 0 )  ){  // This is the minimum size to enter here, cause it deletes 1 or two nodes

			// At random delete the node(s)
			for(i=0; i<nodes2delete; i++){
				//while(1){
				todelete = (int)(poshidden[0] + (poshidden[sizepos[1] - varN->VnoOutputs ] - poshidden[0] ) * rando());    			// a+(b-a)*rando() // select a hidden node. OK Checked
				//cout << todelete << endl;
				//if ( (todelete < varN->inputs)  ||  (todelete >= varN->inputs + varN->hidden )  ){ // if it is an input or if its an output stop
				//	cout << "out of bounds " << endl;
				//	exit(0);
				//}
				//}
				if(MYDEBUG_DelNode == 1) 	    	cout << "Position to delete (todelete) = " << todelete << endl;

				//cout << "W" << endl; imprime(W,allNodesNet,allNodesNet);
				// saveD("txtTemp/W",W,allNodesNet,allNodesNet);  	    	saveInt("txtTemp/CW",CW,allNodesNet,allNodesNet);  	    	saveInt("txtTemp/nodes",nodes,allNodesNet);  	    	saveInt("txtTemp/bias",bias,allNodesNet);

				// copy and resize the matrices and vector
				copyBeforeDelete(todelete);

				//recalculate the hidden nodes
				//poshidden = reallocate(poshidden, sizepos[1], sizepos[1]-1);
				sizepos[1] --;
				varN->hidden --;
				recalculateHNodes();

				if(MYDEBUG_DelNode == 1) { 			cout << "New hidden nodes " << endl; 	imprime(poshidden,sizepos[1]-1);}
				//imprime(CW, (varN->finalInp + varN->hidden + varN->VnoOutputs),  (varN->finalInp + varN->hidden + varN->VnoOutputs) );

				// saveD("txtTemp/W2",W,allNodesNet,allNodesNet);  	    	saveInt("txtTemp/CW2",CW,allNodesNet,allNodesNet);  	    	saveInt("txtTemp/nodes2",nodes,allNodesNet);  	    	saveInt("txtTemp/bias2",bias,allNodesNet);
			}

			// Check that after the deleteion the network is valid
			checkValidNet();


			if(MYDEBUG_DelNode == 1) cout << "Training using the MBP, deleteNode function" << endl;

			// Train all scales  - MBP or only one scale
			if(trainMultipleSets == ON){
				this->copyALLscales(&scalesNet[0]); 															// first copy into other networks
				this->trainScales(&scalesNet[0], epochsK[TRAIN_INSIDE], TRAIN_INSIDE);   // train all scales
			}
			else
				trainMBP(varN->Vepochs[0],TRAIN_INSIDE);

			validMutation = 1;
		}
		else
			if(MYDEBUG_DelNode == 1)  cout << "There is not enough nodes to delete... it was done nothing" << endl;

		evaluationsPrun ++;
		totalEval++;
		return(validMutation);

	}
	catch (...) {
		cout << "Something were wrong in the C_network::deleteNode" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
}////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


int C_network::deleteSharedNode(C_network **scalesNet){
	// function to delete hidden nodes (Looks ok)
	try{
		///////////////////////////////////////////////////////////////////////
		register int i;
		int nodes2delete=0,todelete;
		int *sharedNodes = NULL;
		int contSharedNodes = 0;
		int validMutation = -1;
		int idxTmp = 0;
		/////////////////////////////////////////////////////////////////////////

		sharedNodes = allocate(sharedNodes,varN->finalInp+varN->hidden+1);

		if(MYDEBUG_DelNode == 1) 	cout << " ******* Entering Delete Hidden shared Nodes function ***********" << endl;

		nodes2delete = (int)(minmutateN + mutatednodes * rando());
		//imprime(CW,varN->finalInp+ varN->hidden + varN->VnoOutputs,varN->finalInp+ varN->hidden + varN->VnoOutputs);
		//saveInt((char *)"res/CW", CW, varN->finalInp+ varN->hidden + varN->VnoOutputs, varN->finalInp+ varN->hidden + varN->VnoOutputs);
		//saveInt((char *)"res/nodesInmodule", sharedModule->nodesInModule, varN->finalInp+ varN->hidden + varN->VnoOutputs, 2);

		// Discover which nodes belong to the shared module :: nodes with -1 in nodesInModule
		contSharedNodes = obtaintSharedNodes(sharedNodes);


		if(MYDEBUG_DelNode == 1) { 			cout << "Avaible nodes to delete (shared Nodes) " << endl; 	imprime(sharedNodes,contSharedNodes); 		cout << "size hidden nodes = " << varN->hidden << endl; }

		// As it may be desirable that the shared nodes become zero, it will be allowed to delete all of them, even if that means to have no hidden nodes
		// I hope that does not happen, and there could be other pure nodes
		while(nodes2delete >= contSharedNodes)
			nodes2delete --;

		if(MYDEBUG_DelNode == 1)  			cout << "Nodes to delete = " << nodes2delete << endl;

		if (nodes2delete > 0){
		// At random delete the node(s)
		for(i=0; i<nodes2delete; i++){
			idxTmp = (int) ( 0 + (contSharedNodes-1 - 0) * rando() ); 				// a+(b-a)*rando()  ... obtain an index at random in that range
			todelete = sharedNodes[idxTmp];

			if(MYDEBUG_DelNode == 1) 	    	cout << "Position to delete (todelete) = " << todelete << endl;


			// copy and resize the matrices and vector
			copyBeforeDelete(todelete);

			//recalculate the hidden nodes
			//poshidden = reallocate(poshidden, sizepos[1], sizepos[1]-1);
			sizepos[1] --;
			varN->hidden --;
			recalculateHNodes();

			// As the deletion of one node may cause that other nodes become pure (previous nodes)
			// here it is calculated the sharedModularity
			sharedModule->clean();
			sharedModule->setup(this);
			sharedModule->isThereSharedModule();

			contSharedNodes = obtaintSharedNodes(sharedNodes);



			//saveInt((char *)"res/CW", CW, varN->finalInp+ varN->hidden + varN->VnoOutputs, varN->finalInp+ varN->hidden + varN->VnoOutputs);
			//saveInt((char *)"res/nodesInmodule", sharedModule->nodesInModule, varN->finalInp+ varN->hidden + varN->VnoOutputs, 2);

			//if(MYDEBUG_DelNode == 1) { 			cout << "New hidden nodes " << endl; 	imprime(poshidden,sizepos[1]-1);
			//cout << "Avaible nodes to delete (shared Nodes) " << endl; 	imprime(sharedNodes,contSharedNodes); 		cout << "size hidden nodes = " << varN->hidden << endl; }
			// saveD("txtTemp/W2",W,allNodesNet,allNodesNet);  	    	saveInt("txtTemp/CW2",CW,allNodesNet,allNodesNet);  	    	saveInt("txtTemp/nodes2",nodes,allNodesNet);  	    	saveInt("txtTemp/bias2",bias,allNodesNet);
		}

		// Check that after the deleteion the network is valid
		checkValidNet();

		if(MYDEBUG_DelNode == 1) cout << "Training using the MBP, deleteNode function" << endl;

		// Train all scales  - MBP or onlyone scale
		if(trainMultipleSets == ON){
			this->copyALLscales(&scalesNet[0]); 															// first copy into other networks
			this->trainScales(&scalesNet[0], epochsK[TRAIN_INSIDE], TRAIN_INSIDE);   // train all scales
		}
		else
			trainMBP(varN->Vepochs[0],TRAIN_INSIDE);

		validMutation = 9;
		}
		else
			cout << "There is not enough shared nodes to delete" << endl;

		evaluationsPrun ++;
		totalEval++;

		// liberate memory
		safefree(&sharedNodes);

		return(validMutation);

	}
	catch (...) {
		cout << "Something were wrong in the C_network::deleteNode" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
}////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



void C_network::deleteModule(int delMod, int initNode, int delUntil, string setOf ){
	/*!
	 * Method to delete a selected module
	 * Inputs:
	 * 		delMod 				Module to be selcted, it is related with the output partition, format 1,...
	 * 		initNode				initial node to test to be deleted, the deletion started backwards
	 * 		delUntil 				the last node that could be deleted
	 * 		PbelongTo 			if it belnogs to inputs, hidden or output nodes, this value is decremented in case it is deleted a nodes
	 * 		Psizepos				sizetpos is decremented for inputs or outputs
	 */

	// Local variables
	int node,cols, nodesNet;

	nodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;

	// move backwards from the node passed to the last one
	for (node = initNode; node >= delUntil; node-- ){
		//imprime(CW,nodesNet,nodesNet);
		//imprime(huskenModule->nodesInModule, nodesNet, 2 );
		if ( huskenModule->nodesInModule[node][1] == delMod  ){
			// delete the actual node becuase it does not belong the the module
			copyBeforeDelete(node);

			// determinate if it belongs to inputs, hidden or output nodes
			if ( strcmp(setOf.c_str(), "inputs") == 0 ){
				sizepos[0]--;
				cout << "I have not program the deletion of inputs in modules, exit funciton : C_network::deleteModule" << endl;
				exit(0);
				varN->inputs--;
				recalculateInputs();
			}
			else if ( strcmp(setOf.c_str(), "hidden") == 0 ){
				sizepos[1]--;
				varN->hidden--;
				recalculateHNodes();
			}
			else if ( strcmp(setOf.c_str(), "outputs") == 0 ){
				sizepos[1]--;
				varN->VnoOutputs --;
				recalculateHNodes();
			}

			// move positions in husken module->nodesInModule
			for(cols = node; cols < nodesNet ; cols++)
				huskenModule->nodesInModule[cols][1] = huskenModule->nodesInModule[cols+1][1];

			nodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;

		}
	}
}// End funciton to delete a module /////////////////////////////////////////////////////////////////////////////////////////////////////////////


void C_network::insertModule(C_network *module, int insertInMod){
	/*!
	 * Fuction to inser the modules passed into the actual network
	 * It is inserted in the last hidden node
	 * it is not done in the inputs because it means to move more nodes when copied
	 */

	// Local variables
	int nodesNet;
	int nodesModule;
	int i, j, initPosNet, initPosMod;
	int conInputs = 0;
	int conOutputs = 0;


	int firstOutNet = 0;
	int firstOutMod = 0;

	cout << "Module to insert : insertModule funciton from C_network.............................................." << endl;
	nodesModule = module->varN->finalInp + module->varN->hidden + module->varN->VnoOutputs;
	//imprime(module->CW,nodesModule,nodesModule);

	cout << "network" << endl;
	nodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;
	//imprime(CW,nodesNet,nodesNet); 	imprime(huskenModule->nodesInModule, nodesNet, 2 );

	// insert the number of nodes in the module (hidden nodes), only the spaces in this network

	initPosNet = varN->finalInp + varN->hidden; 				// initial node in 'this' that will contain the first nodes from the network
	initPosMod = module->varN->inputs;							// initial node from the module

	// count how many inputs will be considered
	while ( conInputs < module->varN->finalInp && conInputs < varN->finalInp)
		conInputs++;

	// insert nodes in 'this' blank spaces
	cout << "expand matrix" << endl;
	for (i = 0; i<module->varN->hidden; i++ ){
		sizepos[1] ++;
		varN->hidden ++;
		copyBeforeAddModule(varN->finalInp + varN->hidden-2); // alwasy the last hidden node is inserted
		//recalculate the hidden nodes
		recalculateHNodes();
	}
	nodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;
	//imprime(CW,nodesNet,nodesNet); 	//imprime(huskenModule->nodesInModule, nodesNet, 2 );

	// copied the information of the modules into the actual network

	// start with the IH
	cout << "IH" << endl;
	for(i=0; i<conInputs; i++){
		copy(&CW[i][initPosNet], &module->CW[i][ initPosMod ], module->varN->hidden);
		copy(&W[i][initPosNet], &module->W[i][ initPosMod ], module->varN->hidden);
		if (isDualWeights == ON)
			copy(&W2[i][initPosNet], &module->W2[i][ initPosMod ], module->varN->hidden);
		copy(&DeltaW[i][initPosNet], &module->DeltaW[i][ initPosMod ], module->varN->hidden);

		// lrate per node Check all this function to see if W2 and Clrate and ClrateB are correct, de pasada checar todo
		//int CHecaresto;
		//CHecaresto = 100000;


	}

	// IO
	conOutputs = module->varN->VnoOutputs; // by thefault is this value, but decrement if the module to wchich is conencted is smaller
	while ( conOutputs > NUM_OUT_Per_MOD[insertInMod-1])
		conOutputs--;


	// to which module it will be conencted
	firstOutNet = varN->finalInp + varN->hidden; 				// this value suits for the first module
	for (i = 0; i < insertInMod-1; i++)
		firstOutNet += NUM_OUT_Per_MOD[i];

	firstOutMod = module->varN->finalInp + module->varN->hidden ;

	cout << "IO" << endl;
	for(i=0; i<conInputs; i++){
		copy(&CW[i][firstOutNet], &module->CW[i][ firstOutMod ], conOutputs);
		copy(&W[i][firstOutNet], &module->W[i][ firstOutMod ], conOutputs);
		copy(&DeltaW[i][firstOutNet], &module->DeltaW[i][ firstOutMod ], conOutputs);
	}

	//HH
	cout << "HH" << endl;
	j = initPosMod;
	for(i=initPosNet; i< ( initPosNet + module->varN->hidden ); i++){
		copy(&CW[i][initPosNet], &module->CW[j][ initPosMod ], module->varN->hidden);
		copy(&W[i][initPosNet], &module->W[j][ initPosMod ], module->varN->hidden);
		copy(&DeltaW[i][initPosNet], &module->DeltaW[j][ initPosMod ], module->varN->hidden);
		j++;
	}

	//HO
	cout << "HO" << endl;
	j = initPosMod;
	for(i=initPosNet; i< ( initPosNet + module->varN->hidden ); i++){
		copy(&CW[i][firstOutNet], &module->CW[j][ firstOutMod ], conOutputs);
		copy(&W[i][firstOutNet], &module->W[j][ firstOutMod ], conOutputs);
		copy(&DeltaW[i][firstOutNet], &module->DeltaW[j][ firstOutMod ], conOutputs);
		j++;
	}

	//imprime(CW,nodesNet,nodesNet);

	// nodes
	cout << "The rest" << endl;
	copy(&nodes[initPosNet], &module->nodes[initPosMod], module->varN->hidden);
	copy(&bias[initPosNet], &module->bias[initPosMod], module->varN->hidden+conOutputs); // wheter the outputs have or not bias, they are copied from the module to the network

	// UPDATE THIS *****lrate[insertInMod-1] = module->lrate[0];
	//update_Lrate();   /// remember to copy the lrate per node and per bias

	huskenModule->loadModule[insertInMod-1] = module->varN->counterLoaded;

	/*cout << "History" << endl;
	huskenModule->history->copyClass(module->huskenModule->history);

	// now that the module has been inserted, add to the history the actual ds and number of module,
	// if this module arrives to the end and it is part of the best individual, it will be saved

	huskenModule->history->m[0][ huskenModule->loadModule[insertInMod] ] = DSnumber;
	huskenModule->history->m[1][ huskenModule->loadModule[insertInMod] ] = insertInMod;
	*/
}///////////////////////////////////////////////////////////////////////




int C_network::addNode(C_network ** scalesNet){
	// function to add hidden nodes
	try{
		/////////////////////////////////////////////////////////////////////////
		register int i;
		int nodes2add = 0,toadd;
		int validNetwork = -5;
		/////////////////////////////////////////////////////////////////////////

		if(MYDEBUG_AddNode == 1){

			cout << endl << " **************** Entering Add Hidden Node function *************************" << endl;
			//imprime(CW, (varN->finalInp + varN->hidden + varN->VnoOutputs),  (varN->finalInp + varN->hidden + varN->VnoOutputs) );
			cout << "AddNode Fun:: posHidden+output" << endl; 	imprime(poshidden, varN->hidden);
			cout << "March     = " << this->huskenModule->MarchTD << endl;
			cout << "Mweight = " << this->huskenModule->MweightTD << endl;
		}

		//Decide nodes to be added, limit : totalMaxInput
		nodes2add = (int)(minmutateN + mutatednodes * rando());
		if(MYDEBUG_AddNode == 1) cout << endl << "Nodes to add = " << nodes2add << endl << "----------------------" << endl;


		// At random add the node(s)
		for(i=0; i<nodes2add; i++){
			if(sizepos[1] + 1 <= totalMaxHidden+1){			//if it does not exceed the maximum size of the matrix

				if(MYDEBUG_AddNode == 1) { 			cout << "Aviable nodes to split (hidden nodes witout outputs)" << endl; 	imprime(poshidden,varN->hidden); 		cout << "size hidden nodes = " << varN->hidden << endl; }

				toadd = (int)(poshidden[0] + (poshidden[varN->hidden] - poshidden[0] ) * rando());  			// this generate a random number between the first hiiden node to the last, Ok checked

				if(MYDEBUG_AddNode == 1) 	    	cout << "Position to split = " << toadd << endl;

				//cout << "W" << endl; imprime(W,allNodesNet,allNodesNet); 		saveD("txtTemp/W",W,allNodesNet,allNodesNet); 		saveInt("txtTemp/CW",CW,allNodesNet,allNodesNet); 		saveInt("txtTemp/nodes",nodes,allNodesNet); 		saveInt("txtTemp/bias",bias,allNodesNet);


				//recalculate the hidden nodes
				//poshidden = reallocate(poshidden,sizepos[1],sizepos[1]+1);
				sizepos[1] ++;
				varN->hidden ++;

				// Resize,copy and split the columns and vector to create a new hidden node
				copyBeforeAdd(toadd); //looks ok

				//recalculate the hidden nodes
				recalculateHNodes();

				if(MYDEBUG_DelNode == 1) { 			cout << "New hidden nodes in the net" << endl; 	imprime(poshidden,sizepos[1] -1);}
				//imprime(CW, (varN->finalInp + varN->hidden + varN->VnoOutputs),  (varN->finalInp + varN->hidden + varN->VnoOutputs) );

			}
			else{
				cout << "The network grows too much, add node exeds the dimension, exit" << endl;
				throw -1;
			}

		}
		// Check that after the deleteion the network is valid
		checkValidNet();

		// Train it - MBP
		if(MYDEBUG_DelNode == 1) cout << "Training with MBP, deleteNode function" << endl;

		if(trainMultipleSets == ON){
			this->copyALLscales(&scalesNet[0]);															// first copy into other networks
			this->trainScales(&scalesNet[0], epochsK[TRAIN_INSIDE], TRAIN_INSIDE);	// train all scales
		}
		else
			trainMBP(varN->Vepochs[0],TRAIN_INSIDE);

		if(MYDEBUG_AddNode == 1){
			cout << "After node addition" << endl <<  "March     = " << this->huskenModule->MarchTD << endl;
			cout << "Mweight = " << this->huskenModule->MweightTD << endl;
		}

		validNetwork = 5;

		evaluationsPrun ++;
		totalEval++;
		return(validNetwork);
	}
	catch (...) {
		cout << "Something were wrong in the C_network::addNode" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
}////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



int C_network::deleteInput(C_network ** scalesNet){
	// Delete at randomn one Input.
	//There is no preference to delet the fisrt or last input
	try{
		/////////////////////////////////////////////////////////////////////////
		register int i,j;
		int nodes2delete=0,todelete;
		int validNetwork = -2;

		//C_network *emptyNet1;
		//emptyNet1 = (C_network *) new C_network;
		/////////////////////////////////////////////////////////////////////////

		if(MYDEBUG_DelInput == 1){ 	cout << endl << " //// ///// //// Entering Delete Input function //// ///// //// " << endl;  cout << endl << "DeleteInput Fun:: posInputs" << endl; 	imprime(posinputs, sizepos[0]);}

		nodes2delete = (int)(minmutateN + mutatedInputs * rando());

		//if ( task2solve == PREDICT ) 					// to delete same number of inputs for all entrances, change this in the future in the inputs of each TS are evovled separately
		//	nodes2delete *= varN->Vfilecol;

		if ( task2solve == CLASSIFY ) {
			cout << "A classificaiton task enter here, it suppose to be only for prediciton task, exit with code 0, function deleteInput" << endl;
			exit(0);
		}

		if(MYDEBUG_DelInput == 1){  cout << "Available inputs to delete " << endl; 	imprime(posinputs, sizepos[0]); 		cout << "size inputs= " << sizepos[0] << endl << "Inputs to delete = " << nodes2delete << endl; }

		while( (nodes2delete * varN->Vfilecol) >= sizepos[0])
			nodes2delete --;     //= varN->Vfilecol;  // devremnet with the same amount of columnsin the input file to mantain the simetry (for modules)

		//Decide nodes to be deleted
		if(sizepos[0] >= 2 && (nodes2delete *varN->Vfilecol) < sizepos[0]){  // This is the minimum size to enter here, cause it deletes 1 or two nodes

			// At random delete the node(s)
			for(i=0; i<nodes2delete; i++){
				// the fisrt input is never seleccted
				todelete = (int)(posinputs[sizepos[0]-1]  * rando());   // I have not consider if it is selected the last input node, i nthat case it is deleted plus the first hidden node
																	// for now I will leave in that way, correct later

				if(MYDEBUG_DelInput == 1) 	    	cout << "Position to delete (todelete) = " << todelete << endl;

				//cout << "W" << endl; imprime(W,allNodesNet,allNodesNet);
				//saveD("txtTemp/W",W,allNodesNet,allNodesNet); 			saveInt("txtTemp/CW",CW,allNodesNet,allNodesNet); 			saveInt("txtTemp/nodes",nodes,allNodesNet); 			saveInt("txtTemp/bias",bias,allNodesNet);

				// Copy and rezices the vector and matrices
				// just make sure that only prediction use this
				//if ( task2solve == PREDICT ){
					for (j = 0; j<varN->Vfilecol; j++)  //{  // delete the same position n times, that is not the best, it must be delet o and 1, or 2 and 3, ... in case of tow TS, as they are taken in that order
						copyBeforeDelete(todelete); 			// however for fast I will do in this was, it may not have any big effect in the network, if this message continue here it measn that it has nof a big effect
																				// however later it may be a good idea to improve it.
						//recalculate the hidden nodes
						//posinputs = reallocate(posinputs, sizepos[0], sizepos[0]-1);
						sizepos[0] -= varN->Vfilecol;
						varN->inputs --;
						recalculateInputs();   // in this moment if there a re modules for prediction tasks, and one input is deleted, then it measn that one input for each mdule is deleted too
																// in the future each task may evolved separately its own inputs. Note that the asymmetric code does not require that.
					//}
				//}
				if(MYDEBUG_DelInput == 1) {
					cout << "New input nodes " << endl; 	imprime(posinputs,sizepos[0]);
					cout << "New hidden nodes " << endl; 	imprime(poshidden,sizepos[1]);
				}
			}

			// Check that after the deleteion the network is valid
			checkValidNet();

			// rearrange data before train again the mutated network
			rearrangeData();

			// Train it - MBP
			if(MYDEBUG_DelInput == 1) cout << "Training with MBP in deleteInput function" << endl;

			if(trainMultipleSets == ON){
				this->copyALLscales(&scalesNet[0]);															// first copy into other networks
				this->trainScales(&scalesNet[0], epochsK[TRAIN_INSIDE], TRAIN_INSIDE);	// train all scales
			}
			else
				trainMBP(varN->Vepochs[0],TRAIN_INSIDE);

			validNetwork = 2;
		}
		else
			if(MYDEBUG_DelInput == 1) cout << "There is not enough nodes to delete..." << endl;


		evaluationsPrun ++;
		totalEval++;
		return(validNetwork);
	}
	catch (...) {
		cout << "Something were wrong in the C_network::deleteInput" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
} ////////////////////////////////////////////////////////////////////////////////////////////////////


int C_network::deleteInputAssymetric(C_network ** scalesNet){
	// Delete at randomn one Input.
	//There is no preference to delet the fisrt or last input
	try{
		/////////////////////////////////////////////////////////////////////////
		register int i;
		int cont;
		int nodes2delete=0,todelete;
		int validNetwork = -2;
		int *inputs2delete = NULL;
		//C_network *emptyNet1;
		//emptyNet1 = (C_network *) new C_network;
		/////////////////////////////////////////////////////////////////////////

		inputs2delete = allocate(inputs2delete,sizepos[0]);			// maximum nuber of inputs to delete

		if(MYDEBUG_DelInput == 1){ 	cout << endl << " //// ///// //// Entering Delete Input Assimetric function //// ///// //// " << endl;  cout << endl << "DeleteInput Fun:: posInputs" << endl; 	imprime(posinputs, sizepos[0]);}

		nodes2delete = (int)(minmutateN + mutatedInputs * rando());

		cont = obtainAllInputs(inputs2delete);

		while(nodes2delete >= cont)
			nodes2delete --;

		if(MYDEBUG_DelInput == 1){
			cout << "size inputs= " << sizepos[0] << endl << "Number of Inputs to delete = " << nodes2delete << endl;
			cout << "available inputs: " << endl;
			imprime(inputs2delete, cont);
		}



		//Decide nodes to be deleted
		if(sizepos[0] >= 2 && nodes2delete < cont ){  // This is the minimum size to enter here, cause it deletes 1 or two nodes

			// At random delete the node(s)
			for(i=0; i<nodes2delete; i++){
				// this line could cause errors, check in future that id doe snot give velaues outside the vector
				todelete = inputs2delete[ (int)(cont  * rando())];   	 //todelete = inputs2delete[ (int)(1 + (cont - 1)  * rando())];   			// to delete give the position in inputs2delete

				if(MYDEBUG_DelInput == 1) 	    	cout << "Position to delete (todelete) = " << todelete << endl;
				// delete posistions
				nodes[todelete] = 0;
				//posinputs[todelete] = -1;
				//sizepos[0] --;
				recalculateInputs();

				if(MYDEBUG_DelInput == 1) {
					cout << "New input nodes " << endl; 	imprime(posinputs,sizepos[0]);
					cout << "New hidden nodes " << endl; 	imprime(poshidden,sizepos[1]);
				}
			}

			// Check that after the deleteion the network is valid
			checkValidNet();



			// Train it - MBP
			if(MYDEBUG_DelInput == 1) cout << "Training with MBP in deleteInput Assimetric function" << endl;

			if(trainMultipleSets == ON){
				this->copyALLscales(&scalesNet[0]);															// first copy into other networks
				this->trainScales(&scalesNet[0], epochsK[TRAIN_INSIDE], TRAIN_INSIDE);	// train all scales
			}
			else
				trainMBP(varN->Vepochs[0],TRAIN_INSIDE);

			validNetwork = 2;
		}
		else
			if(MYDEBUG_DelInput == 1) cout << "There is not enough nodes to delete..." << endl;


		evaluationsPrun ++;
		totalEval++;

		// liberate mem
		safefree(&inputs2delete);

		return(validNetwork);
	}
	catch (...) {
		cout << "Something were wrong in the C_network::deleteInputAssimetric" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
} ////////////////////////////////////////////////////////////////////////////////////////////////////


int C_network::addInput(C_network ** scalesNet){
	// function to add inputs nodes

	try{
		//////////////////////////////////////////////////////////////////////////
		register int i,j;
		int nodes2add = 0, toadd;
		int allNodesNet;
		int validNetwork = -6;

		//C_network *emptyNet1;
		//emptyNet1 = (C_network *) new C_network;
		/////////////////////////////////////////////////////////////////////////

		//this->print();
		if(MYDEBUG_AddInput == 1)		cout << endl << " **************** Entering Add Inputs Node function *************************" << endl;

		//Decide nodes to be added, there is not a limit in the maximim number of inputs nodes
		nodes2add = (int)(minmutateN + mutatedInputs * rando());

		//if ( task2solve == PREDICT ) 					// to delete same number of inputs for all entrances, change this in the future in the inputs of each TS are evovled separately
		//	nodes2add *= varN->Vfilecol;

		if(MYDEBUG_AddInput == 1) cout << endl << "Input(s) to add = " << nodes2add << endl << "----------------------" << endl;

		// At random add the inputs(s)
		for(i=0; i<nodes2add; i++){
			if(sizepos[0] + varN->Vfilecol <= totalMaxInput){			//if it does not exceed the maximum size of the matrix
				if(MYDEBUG_AddInput == 1) { 			cout << "Aviable Inputs to split" << endl; 	imprime(posinputs, sizepos[0]); 		cout << "size inputs = " << sizepos[0] << endl; }

				// allnodes inp+hidd+oup
				allNodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;

				toadd = (int)(posinputs[ sizepos[0]-1 ]  * rando());  			// this generate a random number between the first input (0) to the last

				if(MYDEBUG_AddInput == 1) 	    	cout << "Position to split = " << toadd << endl;

				//cout << "W" << endl; imprime(W,allNodesNet,allNodesNet); 		saveD("txtTemp/W",W,allNodesNet,allNodesNet); 		saveInt("txtTemp/CW",CW,allNodesNet,allNodesNet); 		saveInt("txtTemp/nodes",nodes,allNodesNet); 		saveInt("txtTemp/bias",bias,allNodesNet);

				//recalculate the inputs + hidden nodes
				//posinputs = reallocate( posinputs, sizepos[0], sizepos[0]+1);
				//if ( task2solve == PREDICT ){
				//	for (j = 0; j<varN->Vfilecol; j++){
						sizepos[0] += varN->Vfilecol;
						varN->inputs ++;
						varN->finalInp =  varN->inputs * varN->Vfilecol;

						// Resize,copy and split the columns and vector to create a new hidden node
						for (j = 0; j<varN->Vfilecol; j++)
							copyBeforeAdd(toadd);
					//}
				//}

				//recalculate the hidden nodes
				recalculateInputs();

				if(MYDEBUG_AddInput == 1) { 			cout << "New Inputs in the net" << endl; 	imprime( posinputs, sizepos[0] ); }
			}
			else{
				cout << "addinput: try to increse inputs but htere is no space, exit" << endl;
				throw -1;
			}
		}

		// Check that after the addition the network is valid (it should be, but only in case)
		checkValidNet();

		// rearrange data before train again the mutated network
		rearrangeData();

		// Train it - MBP
		if(MYDEBUG_AddInput == 1) cout << "Training MBP, Add input function" << endl;

		if(trainMultipleSets == ON){
			this->copyALLscales(&scalesNet[0]);															// first copy into other networks
			this->trainScales(&scalesNet[0], epochsK[TRAIN_INSIDE], TRAIN_INSIDE);	// train all scales
		}
		else
			trainMBP(varN->Vepochs[0],TRAIN_INSIDE);

		validNetwork = 6;

		evaluationsPrun ++;
		totalEval++;
		return(validNetwork);
	}
	catch (...) {
		cout << "Something were wrong in the C_network::addInput" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}

} ////////////////////////////////////////////////////////////////////////////////////////////////////


int C_network::addInputAssymetric(C_network ** scalesNet){
	// Delete at randomn one Input.
	//There is no preference to delet the fisrt or last input
	try{
		/////////////////////////////////////////////////////////////////////////
		register int i;
		int cont;
		int nodes2add=0,toadd;
		int validNetwork = -6;
		int *inputs2add = NULL;
		//C_network *emptyNet1;
		//emptyNet1 = (C_network *) new C_network;
		/////////////////////////////////////////////////////////////////////////

		inputs2add = allocate(inputs2add,sizepos[0]);			// maximum nuber of inputs to delete

		if(MYDEBUG_DelInput == 1){ 	cout << endl << " //// ///// //// Entering Add Input Assimetric function //// ///// //// " << endl;  cout << endl << "Add Input Fun:: posInputs" << endl; 	imprime(posinputs, sizepos[0]);}

		nodes2add = (int)(minmutateN + mutatedInputs * rando());

		cont = obtainAllFreeInputs(inputs2add);

		while(nodes2add >= cont)
			nodes2add --;

		if(MYDEBUG_AddInput == 1){
			cout << "size inputs= " << sizepos[0] << endl << "Number of Inputs to add = " << nodes2add << endl;
			cout << "available inputs to add: " << endl;
			imprime(inputs2add, cont);
		}

		//Decide inputs to be added
		if(nodes2add >= 1){  // if at least it is going to be added one inputs

			// At random add the node(s)
			for(i=0; i<nodes2add; i++){
				// this line could cause errors, check in future that id does not give velaues outside the vector
				toadd = inputs2add[ (int)(cont  * rando())];  //toadd = inputs2add[ (int)(1 + (cont - 1)  * rando())];   			// to delete give the position in inputs2delete

				if(MYDEBUG_AddInput == 1) 	    	cout << "Position to add (toadd) = " << toadd << endl;
				// add posistions
				nodes[toadd] = 1;
				//posinputs[toadd] = toadd;
				//sizepos[0] ++;
				recalculateInputs();

				if(MYDEBUG_AddInput == 1) {
					cout << "New input nodes " << endl; 	imprime(posinputs,sizepos[0]);
					cout << "New hidden nodes " << endl; 	imprime(poshidden,sizepos[1]);
				}
			}

			// Check that after the deleteion the network is valid
			checkValidNet();


			// Train it - MBP
			if(MYDEBUG_DelInput == 1) cout << "Training with MBP in addInput Assimetric function" << endl;

			if(trainMultipleSets == ON){
				this->copyALLscales(&scalesNet[0]);															// first copy into other networks
				this->trainScales(&scalesNet[0], epochsK[TRAIN_INSIDE], TRAIN_INSIDE);	// train all scales
			}
			else
				trainMBP(varN->Vepochs[0],TRAIN_INSIDE);

			validNetwork = 6;
		}
		else
			if(MYDEBUG_DelInput == 1) cout << "There is not enough inputs to delete..." << endl;


		evaluationsPrun ++;
		totalEval++;

		// liberate mem
		safefree(&inputs2add);

		return(validNetwork);
	}
	catch (...) {
		cout << "Something were wrong in the C_network::addInputAssimetric" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
} ////////////////////////////////////////////////////////////////////////////////////////////////////




int C_network::deleteDelay(C_network ** scalesNet){
	// delete a delay from the network and recualculate again the fitness
	try{
		///////////////////////////////////////////////////////////////////////
		int delays2delete = 0;
		int validNetwork = -3;
		/////////////////////////////////////////////////////////////////////////
		if (varN->inputs > 1){ 													// Check not to evolve the delay if inputs are = 1

			if(MYDEBUG_DelDelay == 1) 	    	cout << endl << " ^ ^ ^ ^DeleteDelay function  ^ ^ ^ ^" << endl << endl;

			//Decide delays to be deleted
			delays2delete = (int)(minmutateN + mutatedDelays * rando());

			if(MYDEBUG_DelDelay == 1) cout << "Delays in the net: " << varN->delays << endl;

			// minimun delay == 1
			while(delays2delete >= varN->delays)
				delays2delete --;

			if( varN->delays >= 2 && delays2delete < varN->delays ){
				// delete the delays
				varN->delays = varN->delays - delays2delete;

				if(MYDEBUG_DelDelay == 1){ cout << "Delays to delete = " << delays2delete << endl << "New delays in the net = " << varN->delays << endl; }

				// rearrange data before train again the mutated network
				rearrangeData();

				// Train it - MBP
				if(MYDEBUG_DelDelay == 1) cout << "Training MBP in deleteDelay function" << endl;

				if(trainMultipleSets == ON){
					this->copyALLscales(&scalesNet[0]);															// first copy into other networks
					this->trainScales(&scalesNet[0], epochsK[TRAIN_INSIDE], TRAIN_INSIDE);	// train all scales
				}
				else
					trainMBP(varN->Vepochs[0],TRAIN_INSIDE);

				validNetwork = 3;
			}
			else
				cout << "There is not enough delays to delete..." << endl;

			evaluationsPrun ++;
			totalEval++;
		}
		return(validNetwork);
	}
	catch (...) {
		cout << "Something were wrong in the C_network::deleteDelay" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
} ////////////////////////////////////////////////////////////////////////////////////////////////


int C_network::addDelay(C_network ** scalesNet){
	try{
		/////////////////////////////////////////////////////////////////////////
		int delays2add = 0;
		int validNetwork = -7;
		/////////////////////////////////////////////////////////////////////////

		if (varN->inputs > 1){ 													// Check not to evolve the delay if inputs are = 1

			if(MYDEBUG_AddDelay == 1) 	    	cout << endl << " 8888888888888888--- Add Delay(s) function ---8888888888888" << endl << endl;

			//Decide delays to be added
			delays2add = (int)(minmutateN + mutatedDelays * rando());

			if(MYDEBUG_AddDelay == 1) cout << "Delays in the net: " << varN->delays << endl;

			// Add the delays
			varN->delays = varN->delays + delays2add;

			if(MYDEBUG_AddDelay == 1){ cout << "Delays to add = " << delays2add << endl << "New delays in the net = " << varN->delays << endl; }

			// rearrange data before train again the mutated network
			rearrangeData();

			// Train it - MBP
			if(MYDEBUG_AddDelay == 1) cout << "Training with MBP in add Delay function" << endl;

			if(trainMultipleSets == ON){
				this->copyALLscales(&scalesNet[0]);															// first copy into other networks
				this->trainScales(&scalesNet[0], epochsK[TRAIN_INSIDE], TRAIN_INSIDE);	// train all scales
			}
			else
				trainMBP(varN->Vepochs[0],TRAIN_INSIDE);

			validNetwork = 7;

			evaluationsPrun ++;
			totalEval++;
		}
		return(validNetwork);
	}
	catch (...) {
		cout << "Something were wrong in the C_network::addDelay" << endl;
	// Add delay(s) from the network and recualculate again the fitness
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
} ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



// Delete connection and train with MBP
int C_network::deleteCon(C_network ** scalesNet){
	try {

		// Locla variables
		register int i; //,cont,contii,contjj,colwijtodelete;
		int contConn = 0;
		int **Conn = NULL;
		int validNetwork = -4; 				// return a negative value in case nothing is done
		int todelete;
		int NumNodesNet = 0;
		/////////////////////////////////////////////////////////////////////////

		NumNodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;
		Conn = allocate(Conn,3,NumNodesNet * NumNodesNet);


		if( MYDEBUG_DelCon == 1) 			cout << endl << "-----------Fuction delete Connection ---------------" << endl;
		//imprime(CW,NumNodesNet,NumNodesNet);
		//imprime(bias,NumNodesNet);

		if ( useNonConvergentM == ON) 												// regardless if it is MLP or GMLP the connectinos are taken with the non convergent method
			contConn = obtaintConn2Del_NonConvergentM( Conn ); 	// use non convergent method
		else																								// take all available connections
			contConn = obtaintConn(Conn, 1);

		//imprime( Conn, 3,  contConn);

		if( contConn > 0){

			// calculate how many connections are going to be deleted
			int con2delete;
			con2delete =(int)(minmutateN + ( (mutatedcon - minmutateN) * rando() ) );

			// decrement the counter if more connections are going to be deleted than the actual connections
			while(con2delete >= contConn)
				con2delete --;

			if(MYDEBUG_DelCon == 1)                   cout << endl << "Connections to Delete **** --- con2delete = " << con2delete << endl;

			//delete connections
			for(i=0; i<con2delete; i++){
				todelete = (int) ( 0 + (contConn-1 - 0) * rando() ); 				// a+(b-a)*rando()  ... obtain an index at random in that range
				if(MYDEBUG_DelCon == 1)                   cout << endl << "index to delete = " << todelete << endl;


				if(Conn[1][todelete] == Conn[2][todelete])  //if it a bias connection
					bias[(int)(Conn[2][todelete])] = 0;
				else
					CW[(int)(Conn[1][todelete])][(int)(Conn[2][todelete])] = 0;

				W[(int)(Conn[1][todelete])][(int)(Conn[2][todelete])] = 0;
				if (isDualWeights == ON)
					W2[(int)(Conn[1][todelete])][(int)(Conn[2][todelete])] = 0;
				DeltaW[(int)(Conn[1][todelete])][(int)(Conn[2][todelete])] = 0;
				//test[(int)(sharedConn[0][todelete])][(int)(sharedConn[1][todelete])] = 0;

				 //imprime(CW,NumNodesNet,NumNodesNet);
			}

			// Check that after the deleteion the network is valid
			checkValidNet();

			// train the new offspring
			if(trainMultipleSets == ON){
				this->copyALLscales(&scalesNet[0]);// first copy into other networks
				this->trainScales(&scalesNet[0], epochsK[TRAIN_INSIDE], TRAIN_INSIDE);	// train all scales
			}
			else
				this->trainMBP(varN->Vepochs[0],TRAIN_INSIDE);

			validNetwork = 4;
		}
		else
			if( MYDEBUG_DelCon == 1) cout << "There are no connection to delete - No Modifications" << endl;

		// Liberate memory ////////////////////////
		safefree(&Conn, 3);
		///////////////////////////////////////////////////////


		evaluationsPrun ++;
		totalEval++;
		return(validNetwork);
	}
	catch (...) {
		cout << "Something were wrong in the C_network::deleteCon" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
}//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




int C_network::deleteSharedCon(C_network ** scalesNet){
	try {

		// Locla variables
		register int i; //,cont,contii,contjj,colwijtodelete;
		int contSharedConn = 0;
		int **sharedConn = NULL;
		int validNetwork = -10; 				// retunr a negative value in case nothing is done
		int todelete;
		int NumNodesNet = 0;

		/////////////////////////////////////////////////////////////////////////

		NumNodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;
		sharedConn = allocate(sharedConn,2,NumNodesNet * NumNodesNet);


		if( MYDEBUG_DelCon == 1) 			cout << endl << "-----------Fuction delete shared Connection ---------------" << endl;
		//imprime(CW,NumNodesNet,NumNodesNet);
		//imprime(huskenModule->tdw,NumNodesNet,huskenModule->noModules);
		//imprime(huskenModule->nodesInModule,NumNodesNet,2);


		// obtain Shared connections
		contSharedConn = obtaintSharedConn(sharedConn); 						//imprime( sharedConn, 2,  contSharedConn);

		//Decide number of connections to delete, I choose the connection form the 50% of connections with the lowest significance
		//printf("colwijtodelete =%d / 2 = %d\n",colwijtodelete,(int)(colwijtodelete/2));
		if( countConnNet( CW, NumNodesNet )  > 1 && contSharedConn > 0){			// if there is at least one connection

			// calculate how many connections are going to be deleted
			int con2delete;
			con2delete =(int)(minmutateN + mutatedcon * rando());

			// decrement the counter if more connections are going to be deleted than the actual shared connections
			while(con2delete >= contSharedConn)
				con2delete --;

			if(MYDEBUG_DelCon == 1)                   cout << endl << "Shared connections to Delete **** --- con2delete = " << con2delete << endl;


			//delete connections
			for(i=0; i<con2delete; i++){
				todelete = (int) ( 0 + (contSharedConn-1 - 0) * rando() ); 				// a+(b-a)*rando()  ... obtain an index at random in that range
				if(MYDEBUG_DelCon == 1)                   cout << endl << "index to delete = " << todelete << endl;

				CW[(int)(sharedConn[0][todelete])][(int)(sharedConn[1][todelete])] = 0;
				W[(int)(sharedConn[0][todelete])][(int)(sharedConn[1][todelete])] = 0;
				if (isDualWeights == ON)
					W2[(int)(sharedConn[0][todelete])][(int)(sharedConn[1][todelete])] = 0;
				DeltaW[(int)(sharedConn[0][todelete])][(int)(sharedConn[1][todelete])] = 0;
				//test[(int)(sharedConn[0][todelete])][(int)(sharedConn[1][todelete])] = 0;

				// recalculate the shared conenction, in case that the deletion of one deactiva others :: i have not check that, but just in case
				contSharedConn = obtaintSharedConn(sharedConn);

				// imprime( sharedConn, 2,  contSharedConn);
				// imprime(CW,NumNodesNet,NumNodesNet);
			}

			// Check that after the deleteion the network is valid
			checkValidNet();

			// train the new offspring
			if(trainMultipleSets == ON){
				this->copyALLscales(&scalesNet[0]);// first copy into other networks
			this->trainScales(&scalesNet[0], epochsK[TRAIN_INSIDE], TRAIN_INSIDE);	// train all scales
			}
			else
				this->trainMBP(varN->Vepochs[0],TRAIN_INSIDE);

			validNetwork = 10;
		}
		else
			if( MYDEBUG_DelCon == 1) cout << "The network is so small to delete connections - No Modifications" << endl;

		// Liberate memory ////////////////////////
		safefree(&sharedConn, 2);
		///////////////////////////////////////////////////////

		evaluationsPrun ++;
		totalEval++;
		return(validNetwork);
	}
	catch (...) {
		cout << "Something were wrong in the C_network::deleteCon" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
}//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




int C_network::addCon(C_network ** scalesNet)
{
	try{
		// Add connection(s), save the result in 'this'
		if( MYDEBUG_AddCon == 1) 			cout << endl << "----------- Fuction conAddition ---------------  " << endl;

		//Variable declaration
		int register i;

		int *allnodes = NULL;
		int **wijtoadd = NULL;
		//int *ii = NULL;
		//int *jj = NULL;

		int sizeallnodes,colwijtoadd;
		int con2add,toadd;

		int validNetwork = -8;

		int NumNodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;

		allnodes = (int *) malloc((NumNodesNet)*sizeof(int));
		sizeallnodes = obtainAllnodes(allnodes);     //printf("all nodes in delete connection\n"); imprimeVi(allnodes,sizeallnodes);

		wijtoadd = allocate(wijtoadd,3,NumNodesNet*NumNodesNet);

		// Extract the possible candidates to be added
		// consider if the addition are constrained

		//imprime(CW,NumNodesNet,NumNodesNet); 		//imprime(bias,NumNodesNet);
		colwijtoadd = obtaintConn(wijtoadd, 0); 	//imprime( wijtoadd, 3,  colwijtoadd);


		// change it at random
		randomMat(wijtoadd, 0, 3, 0, colwijtoadd); 		//imprime( wijtoadd, 3,  colwijtoadd);

		if(MYDEBUG_AddCon == 1){               cout << "wijtoadd ,,,, colwijtoadd = " << colwijtoadd << endl;  imprime(wijtoadd,3,colwijtoadd); }

		if((colwijtoadd) > 0){ 			//if there is at least three pos to add (maximum that could be added)
			//decide number of connections to be added
			con2add = (int)(minmutateN + mutatedcon * rando());

			// decrement the counter if more connections are going to be added than the actual connections available
			while(con2add >= colwijtoadd)
				con2add --;

			if(MYDEBUG_AddCon == 1)                   cout << "con2add = " << con2add << endl;

			//add connections
			for(i=0; i< con2add; i++){
				toadd = (int)(colwijtoadd * rando());

				if(wijtoadd[1][toadd] == wijtoadd[2][toadd]) 		//if it is a bias connection
					bias[wijtoadd[1][toadd]] = 1;
				else
					CW[wijtoadd[1][toadd]][wijtoadd[2][toadd]] = 1;

				//W[wijtoadd[0][toadd]][wijtoadd[1][toadd]] = (a + (b-a) * rando());
				W[wijtoadd[1][toadd]][wijtoadd[2][toadd]] = 2.0 * (rando() - 0.5) * smallW;
				if (isDualWeights == ON)
					W2[wijtoadd[1][toadd]][wijtoadd[2][toadd]] = 2.0 * (rando() - 0.5) * smallW;
				DeltaW[wijtoadd[1][toadd]][wijtoadd[2][toadd]] = 0;
			}

			if(trainMultipleSets == ON){
				this->copyALLscales(&scalesNet[0]);															// first copy into other networks
				this->trainScales(&scalesNet[0], epochsK[TRAIN_INSIDE], TRAIN_INSIDE);	// train all scales
			}
			else
				this->trainMBP(varN->Vepochs[0],TRAIN_INSIDE);

			validNetwork = 8;
		}

		// Liberate memory ///////////////////////////////
		//ii = NULL;
		//jj = NULL;

		safefree(&wijtoadd,3);
		safefree(&allnodes);
		/////////////////////////////////////////////////////////////

		evaluationsPrun ++;
		totalEval++;
		return(validNetwork);
	}
	catch (...) {
		cout << "Something were wrong in the C_network::addCon" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
}///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



int C_network::addStrongCon(C_network ** scalesNet){
	try {

		// Locla variables
		register int i;
		int contStrongConn = 0;
		int **strongConn = NULL;
		int validNetwork = -11; 				// retunr a negative value in case nothing is done
		int toadd;
		int NumNodesNet = 0;

		/////////////////////////////////////////////////////////////////////////

		NumNodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;
		strongConn = allocate(strongConn, 3, NumNodesNet * NumNodesNet);


		if( MYDEBUG_AddCon == 1) {
			cout << endl << "-----------Fuction  Strong Connection addition ---------------" << endl;
			cout << " March = " << huskenModule->MarchTD << endl;
		}
		//imprime(CW,NumNodesNet,NumNodesNet);
		//imprime(huskenModule->tdw,NumNodesNet,huskenModule->noModules);
		//imprime(huskenModule->nodesInModule,NumNodesNet,2);


		// obtain Strong connections
		contStrongConn = obtaintStrongConn(strongConn); 						//imprime( strongConn, 3,  contStrongConn);

		//Decide number of connections to add
		//printf("colwijtodelete =%d / 2 = %d\n",colwijtodelete,(int)(colwijtodelete/2));
		if( contStrongConn > 0){			// if there is at least one connection to add

			// calculate how many connections are going to be added
			int con2add;
			con2add =(int)(minmutateN + mutatedcon * rando());

			// decrement the counter if more connections are going to be added than the actual connections available
			while(con2add >= contStrongConn)
				con2add --;

			if(MYDEBUG_AddCon == 1)                   cout << endl << "Strong connections to be added **** --- con2add = " << con2add << endl;


			//add connections
			for(i=0; i<con2add; i++){
				toadd = (int) ( 0 + (contStrongConn-1 - 0) * rando() ); 				// a+(b-a)*rando()  ... obtain an index at random in that range
				if(MYDEBUG_AddCon == 1)                   cout << endl << "index to add = " << toadd << endl;

				CW[(int)(strongConn[1][toadd])][(int)(strongConn[2][toadd])] = 1;
				W[(int)(strongConn[1][toadd])][(int)(strongConn[2][toadd])] = 2.0 * (rando() - 0.5) * smallW;
				if (isDualWeights == ON)
					W2[(int)(strongConn[1][toadd])][(int)(strongConn[2][toadd])] = 2.0 * (rando() - 0.5) * smallW;
				DeltaW[(int)(strongConn[1][toadd])][(int)(strongConn[2][toadd])] = 0;
				//test[(int)(sharedConn[0][todelete])][(int)(sharedConn[1][todelete])] = 0;

				// recalculate the shared conenction, in case that the deletion of one deactiva others :: i have not check that, but just in case
				contStrongConn = obtaintStrongConn(strongConn);

				 //imprime( strongConn, 3,  contStrongConn);
				 //imprime(CW,NumNodesNet,NumNodesNet);
			}

			// Check that after the deleteion the network is valid
			//checkValidNet(); // not need to check because it is added a connection, so it will have more than before, there is no way to get worst the connectivity

			// train the new offspring
			if(trainMultipleSets == ON){
				this->copyALLscales(&scalesNet[0]);// first copy into other networks
			this->trainScales(&scalesNet[0], epochsK[TRAIN_INSIDE], TRAIN_INSIDE);	// train all scales
			}
			else
				this->trainMBP(varN->Vepochs[0],TRAIN_INSIDE);

			validNetwork = 11;
		}
		else
			if( MYDEBUG_AddCon == 1) cout << "There are not Strong connections to add --- No Modifications" << endl;

		// Liberate memory ////////////////////////
		safefree(&strongConn, 3);
		///////////////////////////////////////////////////////

		evaluationsPrun ++;
		totalEval++;
		return(validNetwork);
	}
	catch (...) {
		cout << "Something were wrong in the C_network::addStrongCon" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
}//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


int C_network::swapConn(C_network ** scalesNet){
	try{
		/*!
		 * Swap the connections
		 * They are only swapped betwwen the same sub-matrix, i.e. connection from IH are swapped only into IH
		 * It has been already calculated the matrix of active and deactivated connections (in C_network::obtainActive_and_deact_conn)
		 */

		if( MYDEBUG_AddCon == 1) 			cout << endl << "----------- Fuction Swap Connections ---------------  " << endl;

		//Variable declaration
		int register i,j;
		int tmp;
		int idxActive = 0;
		int idxInacti = 0;
		int subMat = 0;
		int con2swap;

		int validNetwork = -1;




		// Main algorithm
		// 1. Generat a random number to select an active connection
		// 2. Generate a second random number considering all inactive connections in the same submatrix of the selected connection
		// 3. Swap element, thus the inactive conenction now it is active, and the active now it is inactive
		// 4. Update the randomly of the new connection

		if ( contActiveConn > 0 && contDeactConn > 0 ){

			//decide number of connections to swap
			con2swap = (int)(minmutateN + mutatedcon * rando()); 		if(MYDEBUG_AddCon == 1)                   cout << "con2swap = " << con2swap << endl;

			for(j=0; j< con2swap; j++){
/*				int NumNodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;
				cout << "C W" << endl;     																		imprime(CW,NumNodesNet,NumNodesNet);
				///cout << "B i a s" << endl;     																	imprime(bias,NumNodesNet);
				cout << endl << "A c t i v e   c o n n e c t i o n s" << endl;     				imprime(activeConn,3,contActiveConn);
				cout << endl << "D e a c t i v a t e d   c o n n e c t i o n s" << endl;    	imprime(deactConn,3,contDeactConn);
				cout << endl << "rangeDeactivated conenctions" << endl;   				imprime(rangeDeact, 2, 6);
*/
				// 1. Select an "active connection" from any submatrix
				idxActive = (int) (contActiveConn * rando()); 		//(a + (b-a) * rando), because it start from zero to contActiveConn-1, generate a random number goes in the same range, contActiveConn is not considered

				// 2. random number in the selected submatrix for "deactivated connections", pos activeConn[0][idxActive] has the idx of the submatrix it belong 0-5
				subMat = activeConn[0][idxActive];
				idxInacti = (int) ( rangeDeact[0][subMat] + ( ( rangeDeact[1][subMat] - rangeDeact[0][subMat] )* rando() ) );
				// if(MYDEBUG_AddCon == 1){               cout << "wijtoadd ,,,, colwijtoadd = " << colwijtoadd << endl;  imprime(wijtoadd,2,colwijtoadd); }

				// 3. Swap
				// update CW, W, Delta

				if ( activeConn[ 1 ][ idxActive ] == activeConn[ 2 ][ idxActive ]  ){ 		//if it is a bias connection
					bias[ activeConn[ 1 ][ idxActive ] ] = 0;												// deactivate the actived connection
					bias[ deactConn[ 1 ][ idxInacti ] ] = 1;													// activate the deactived connection
				}
				else{
					CW[ activeConn[ 1 ][ idxActive ]    	][    	activeConn[ 2 ][ idxActive ] 	] = 0;
					CW[ deactConn[ 1 ][ idxInacti ] 		][ 		deactConn[ 2 ][ idxInacti ] 		] = 1;
				}

				W[ activeConn[ 1 ][ idxActive ]    ][    	activeConn[ 2 ][ idxActive ] 	] = 0;
				W[ deactConn[ 1 ][ idxInacti ] 		][ 		deactConn[ 2 ][ idxInacti ] 		] = 2.0 * (rando() - 0.5) * smallW;

				if (isDualWeights == ON){
					W2[ activeConn[ 1 ][ idxActive ]    ][    	activeConn[ 2 ][ idxActive ] 	] = 0;
					W2[ deactConn[ 1 ][ idxInacti ] 		][ 		deactConn[ 2 ][ idxInacti ] 		] = 2.0 * (rando() - 0.5) * smallW;

				}

				DeltaW[ activeConn[ 1 ][ idxActive ]    	][    	activeConn[ 2 ][ idxActive ] 	] = 0;
				DeltaW[ deactConn[ 1 ][ idxInacti ] 			][ 		deactConn[ 2 ][ idxInacti ] 		] = 1;


				// update active and deactive connections
				for (i = 1; i< 3; i++){
					tmp = activeConn[i][idxActive];
					activeConn[ i ][ idxActive ] = deactConn[ i ][ idxInacti ];
					deactConn[ i ][ idxInacti ] = tmp;
				}
/*
				cout << "C W" << endl;     																		imprime(CW,NumNodesNet,NumNodesNet);
				cout << endl << "A c t i v e   c o n n e c t i o n s" << endl;     				imprime(activeConn,3,contActiveConn);
				cout << endl << "D e a c t i v a t e d   c o n n e c t i o n s" << endl;    imprime(deactConn,3,contDeactConn);
				cout << endl << "rangeDeactivated conenctions" << endl;   				imprime(rangeDeact, 2, 6);
*/
				// change it at random
				randomMat(activeConn, 0, 3, 0, contActiveConn); 		//imprime( wijtoadd, 2,  cont);

			}
		}

		if(trainMultipleSets == ON){
			this->copyALLscales(&scalesNet[0]);															// first copy into other networks
			this->trainScales(&scalesNet[0], epochsK[TRAIN_INSIDE], TRAIN_INSIDE);	// train all scales
		}
		else
			this->trainMBP(varN->Vepochs[0],TRAIN_INSIDE);

		validNetwork = 8;


		evaluationsPrun ++;
		totalEval++;
		return(validNetwork);

	}
	catch (...) {
		cout << "Something were wrong in the C_network::addCon" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
}///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



int C_network::swapModule(int delMod, C_network *module2copy ){
	/*!
	 * Method to swap a module
	 * Inputs:
	 * 		delMod 				Module to be deleted format 0,1,...
	 * 		module2copy		netowrk with the information of the module to copy into the deleted module
	 */

	// Local variables
	int validNet = -1;
	string strHidden = "hidden";

	//int nodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;
	//imprime(CW,nodesNet,nodesNet); 	imprime(huskenModule->nodesInModule, nodesNet, 2 );

	// delete the selected module, delete all hidden nodes from it
	deleteModule(delMod+1, (varN->inputs + varN->hidden - 1), varN->inputs, strHidden );
	//nodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs; 	imprime(CW,nodesNet,nodesNet); 	imprime(huskenModule->nodesInModule, nodesNet, 2 );

	// Insert the module into the network, always it will be inserted after the last hidden node
	insertModule(module2copy, delMod+1);   // delMod format 0,1,... here

	// train it
	trainMBP(varN->Vepochs[0],TRAIN_INSIDE);
	validNet = 20;

	return( validNet );

}// End funciton to swap module /////////////////////////////////////////////////////////////////////////////////////////////////////////////



// funtion to add nodes or connections
int C_network::addNodeCon(C_network **net,C_network **newNet, C_network ** scalesNet){
	// This special funciton is called when the inputs are fixed, so only is tested if
	// nodes or connections are added. Inputs and delays remain the same.
try{

	// Local variables  ///////////////////////////////////////////////////////////
	//C_network *newNet [2]; //= NULL;
	double *min = NULL, *fitnessNN = NULL;
	int i;
	int numChild = 0;
	int validNetwork = -1;
	//int validNet[3];
	//////////////////////////////////////////////////////////////////////////////////////

	// How many nets will be
	if ( algoFeatures == MODULAR1 )
		numChild = 3;
	else
		numChild = 2;

	// declareta more vars
	int validNet[numChild];

	// init the local networks to be mutated
	// Mabe later I can improve this method, casue I create a complete network and then delete its contnet
	for(i=0; i<numChild; i++){
		//newNet[i] = NULL;
		//newNet[i] = (C_network *) new C_network;
		newNet[i]->copyCleanNet(*net);
	}

	validNet[0] = newNet[0]->addNode(&scalesNet[0]);
	if (algoFeatures == SWAP_CONN)
		validNet[1] = newNet[1]->swapConn(&scalesNet[0]);
	else{
		validNet[1] = newNet[1]->addCon(&scalesNet[0]);
		if ( algoFeatures == MODULAR1 )
			validNet[2] = newNet[2]->addStrongCon(&scalesNet[0]);
	}
	if(MYDEBUG_AddNodeCon == 1){
			cout << "Fitness after add Hnode = " << newNet[0]->fitness[0] << endl;
			cout << "Fitness after add connection = " << newNet[1]->fitness[0] << endl;
			if ( algoFeatures == MODULAR1 ) cout << "Fitness after add strong connection  = " << newNet[2]->fitness[0] << endl;
		}

		// select the best and copy it to 'this'
		fitnessNN = allocate(fitnessNN,numChild);

		for(i=0; i<numChild; i++)
			fitnessNN[i] = newNet[i]->fitness[0];

		// found the minimun
		min = minRow_Pos(fitnessNN, numChild);

		int pos = (int) min[1];

		if(pos == 0){
			if(MYDEBUG_AddNodeCon == 1) cout << "The network with node additions wins................. " << endl;
			validNetwork = validNet[0];

			// replace this with the winner
			if(validNetwork > 0){
				net[0]->copyCleanNet(newNet[pos]);
			}
		}
		else if(pos == 1)
		{
			if(MYDEBUG_AddNodeCon == 1)  cout << "The network with connection additions wins........................ " << endl;
			validNetwork = validNet[1];

			// replace this with the winner
			if(validNetwork > 0)
				net[0]->copyNet(newNet[pos]);
		}
		else if(pos == 2)
		{
			if(MYDEBUG_AddNodeCon == 1)  cout << "The network with strong connection additions wins........................ " << endl;
			validNetwork = validNet[2];

			// replace this with the winner
			if(validNetwork > 0)
				net[0]->copyNet(newNet[pos]);
		}
		else
		{
			cout << "There has been an error in add node or connection in the pos of the min, value out of range, exit..." << endl;
			exit(0);
		}

		// Liberate memory used /////////////////////////////////////////////
		safefree(&min);
		safefree(&fitnessNN);

		//////////////////////////////////////////////////////////////////////////////////

		return(validNetwork);
}
	catch (...) {
		cout << "Something were wrong in the C_network::addNodeCon" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
}
}///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// Function to delete Inpts, hidden nodes or delays
int C_network::deleteIDH(C_network **net, C_network **newNet, C_network ** scalesNet ){

	// Function to delete a input, dimension or hidden node
	// tournament selection, the winner is savde in 'net'
	// 'this' is empty, only used to perform the methods

try{

	// Local variables ////////////////////////////////////////////
	//C_network *newNet[3];// = NULL;
	double *min = NULL, *fitnessNN = NULL;
	int sizeChild = 3;							// settle the number of chhildren created
	int i;
	int validNetwork = -1;
	int validNet[sizeChild];
	/////////////////////////////////////////////////////////////////////////


	// Init the networks
	for(i=0; i<sizeChild; i++)
		newNet[i]->copyCleanNet(net[0]);

	validNet[0] = newNet[0]->deleteNode(&scalesNet[0]);

	if (fixedinputs != FIXED && task2solve == CLASSIFY)
		validNet[1] = newNet[1]->deleteInputAssymetric(&scalesNet[0]);
	else
		validNet[1] = newNet[1]->deleteInput(&scalesNet[0]);

	validNet[2] = newNet[2]->deleteDelay(&scalesNet[0]);

	if(MYDEBUG_DelIDH == 1){
		cout << "Fitness after delete Hnode = " << newNet[0]->fitness[0] << endl;
		cout << "Fitness after delete Input = " << newNet[1]->fitness[0] << endl;
		cout << "Fitness after delete Delay = " << newNet[2]->fitness[0] << endl;
	}

	// select the best and copy it to 'this'
	fitnessNN = allocate(fitnessNN,sizeChild);

	for(i=0; i<sizeChild; i++)
		fitnessNN[i] = newNet[i]->fitness[0];

	// found the minimun
	min = minRow_Pos(fitnessNN,sizeChild);
	//imprime(fitnessNN,3); cout << "min = " << min[0] << " Position = " << min[1] << endl; 	//getchar();

	int pos = (int) min[1];

	switch (pos){
		case 0:
			if(MYDEBUG_DelIDH == 1) cout << "the winner is delete Hidden node" << endl;
			validNetwork = validNet[0];
			break;
		case 1:
			if(MYDEBUG_DelIDH == 1) cout << "the winner is delete input" << endl;
			validNetwork = validNet[1];
			break;
		case 2:
			if(MYDEBUG_DelIDH == 1) cout << "the winner is delete delay" << endl;
			validNetwork = validNet[2];
			break;

		default:
			cout << "There has been an error in deleteIDH , the min pos is outside the range, exit.... " << endl << "pos = " << pos << endl;
			//getchar();
			exit(0);
	}

	// replace the actual individual with the winner,
	//only in case the winner is a validNet, i.e. a mutation was performed
	if(validNetwork > 0){
		net[0]->copyCleanNet(newNet[pos]);
	}

	// Liberate memory used /////////////////////////////////////////////
	safefree(&min);
	safefree(&fitnessNN);

	///////////////////////////////////////////////////////////////////////////////////

	return(validNetwork);
}
	catch (...) {
		cout << "Something were wrong in the C_network::deleteIDH" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
}
} /////////////////////////////////////////////////////////////////////////////////////


// Function to delete Inpts or hidden nodes for the assimetric case
int C_network::deleteIHAssymetric(C_network **net, C_network ** scalesNet ){
try{

	// Local variables ////////////////////////////////////////////
	//int i;
	int validNetwork = -1;
	//int validNet[2];
	int todelete;
	int nodes;
	/////////////////////////////////////////////////////////////////////////

	// determinate if it is a inputs or a hidden node to be deleted
	// Note that this is at random, other approach could be with a tournament approach

	// generate a random number
	nodes = net[0]->varN->finalInp + net[0]->varN->hidden;
	todelete = (int)  (1+ (nodes - 1) * rando() );

	// what to delete, input or hidden node
	// This code is not fair if one side is smaller. Thus if it is smaller it will have less probabilities to be selected
	if( todelete <=  net[0]->varN->finalInp)
		validNetwork = net[0]->deleteInputAssymetric(&scalesNet[0]);
	else
		validNetwork = net[0]->deleteNode(&scalesNet[0]);


	return(validNetwork);
}
	catch (...) {
		cout << "Something were wrong in the C_network::deleteIHAssimetric" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
}
} /////////////////////////////////////////////////////////////////////////////////////


// Function to delete Inpts, hidden nodes or delays
int C_network::addIDHC(C_network **net, C_network **newNet, C_network ** scalesNet){
	// Function to add an input, dimension or hidden node
	// tournament selection, the winner replace the last individual in the population
try{

	if(MYDEBUG_AddIDHC == 1)		cout << endl << " --------------- Function add Input / delay / Hidden / connection ---------------" << endl;

	// Local variables //////////////////////////////////////////////
	//C_network *newNet[4];// = NULL;
	double *min = NULL, *fitnessNN = NULL;
	int sizeChild = 4;							// settle the number of chhildren created
	int i;
	int validNetwork = -1;
	int validNet[sizeChild];
	/////////////////////////////////////////////////////////////////////////


	// create a copy of the actual network
	for(i=0; i<sizeChild; i++)
		newNet[i]->copyCleanNet(net[0]);

	// call specifict functions for each individual
	validNet[0] = newNet[0]->addNode(&scalesNet[0]);

	if (fixedinputs != FIXED && task2solve == CLASSIFY)
		validNet[1] = newNet[1]->addInputAssymetric(&scalesNet[0]);
	else
		validNet[1] = newNet[1]->addInput(&scalesNet[0]);

	validNet[2] = newNet[2]->addDelay(&scalesNet[0]);

	if (algoFeatures == SWAP_CONN)
		validNet[3] = newNet[3]->swapConn(&scalesNet[0]);
	else{
		validNet[3] = newNet[3]->addCon(&scalesNet[0]);
		//if ( algoFeatures == MODULAR1 )
		//	validNet[4] = newNet[4]->addStrongCon(&scalesNet[0]);
	}

	if(MYDEBUG_AddIDHC == 1){
		cout << endl << "Fitness after add Hnode = " << newNet[0]->fitness[0] << endl;
		cout << "Fitness after add Input = " << newNet[1]->fitness[0] << endl;
		cout << "Fitness after add Delay = " << newNet[2]->fitness[0] << endl;
		cout << "Fitness after add Conn = " << newNet[3]->fitness[0] << endl;
		//cout << "Fitness after add Strong Conn = " << newNet[4]->fitness[0] << endl;
	}

	// select the best and copy it to 'this'
	fitnessNN = allocate(fitnessNN,sizeChild);

	for(i=0; i<sizeChild; i++)
		fitnessNN[i] = newNet[i]->fitness[0];

	// found the minimun
	min = minRow_Pos(fitnessNN,sizeChild);

	//imprime(fitnessNN,3); cout << "min = " << min[0] << " Position = " << min[1] << endl; 	//getchar();
	int pos = (int) min[1];


	switch (pos){
	case 0:
		if(MYDEBUG_AddIDHC == 1) cout << "the winner is add Hidden node" << endl;
		validNetwork = validNet[0];
		break;

	case 1:
		if(MYDEBUG_AddIDHC == 1) cout << "the winner is add input" << endl;
		validNetwork = validNet[1];
		break;

	case 2:
		if(MYDEBUG_AddIDHC == 1) cout << "the winner is add delay" << endl;
		validNetwork = validNet[2];
		break;

	case 3:
		if(MYDEBUG_AddIDHC == 1) cout << "the winner is add connection" << endl;
		validNetwork = validNet[3];
		break;
	//case 4:
	//	if(MYDEBUG_AddIDHC == 1) cout << "the winner is add Strong connection" << endl;
	//	validNetwork = validNet[4];
	//	break;

	default:
		cout << "There has been an error in addIDHC, the min pos is outside the range " << endl << "pos = " << pos << endl;
		//exit(0);
	}

	//replace net with the winner
	if (validNetwork > 0){
		net[0]->copyCleanNet(newNet[pos]);
	}


	// Liberate memory used /////////////////////////////////////////////
	safefree(&min);
	safefree(&fitnessNN);
	////////////////////////////////////////////////////////////////////////////////////

	if(MYDEBUG_AddIDHC == 1) cout << "Mem liberated addIDHC" << endl;

	//emptyNet1 = NULL;

	return(validNetwork);
}
	catch (...) {
		cout << "Something were wrong in the C_network::addIDHC" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
}
} /////////////////////////////////////////////////////////////////////////////////////



int C_network::addIDC(C_network **net, C_network **newNet, C_network ** scalesNet){
	/*!
	 * Function to add an input, dimension or connection (not hidden nodes, they may be fixed)
	 * tournament selection, the winner replace the last individual in the population
	 */

	try{

		if(MYDEBUG_AddIDHC == 1)		cout << endl << " --------------- Function add Input / delay / connection ---------------" << endl;

		// Local variables //////////////////////////////////////////////
		//C_network *newNet[4];// = NULL;
		double *min = NULL, *fitnessNN = NULL;
		int sizeChild = 3;							// settle the number of chhildren created
		int i;
		int validNetwork = -1;
		int validNet[sizeChild];
		/////////////////////////////////////////////////////////////////////////


		// create a copy of the actual network
		for(i=0; i<sizeChild; i++)
			newNet[i]->copyCleanNet(net[0]);

		// call specifict functions for each individual
		if (fixedinputs != FIXED && task2solve == CLASSIFY)
			validNet[0] = newNet[0]->addInputAssymetric(&scalesNet[0]);
		else
			validNet[0] = newNet[0]->addInput(&scalesNet[0]);

		validNet[1] = newNet[1]->addDelay(&scalesNet[0]);

		if (algoFeatures == SWAP_CONN)
			validNet[2] = newNet[2]->swapConn(&scalesNet[0]);
		else{
			validNet[2] = newNet[2]->addCon(&scalesNet[0]);
			//if ( algoFeatures == MODULAR1 )
			//	validNet[3] = newNet[3]->addStrongCon(&scalesNet[0]);
		}

		if(MYDEBUG_AddIDHC == 1){
			cout << "Fitness after add Input = " << newNet[0]->fitness[0] << endl;
			cout << "Fitness after add Delay = " << newNet[1]->fitness[0] << endl;
			cout << "Fitness after add Conn = " << newNet[2]->fitness[0] << endl;
			//cout << "Fitness after Strong add Conn = " << newNet[3]->fitness[0] << endl;
		}

		// select the best and copy it to 'this'
		fitnessNN = allocate(fitnessNN,sizeChild);

		for(i=0; i<sizeChild; i++)
			fitnessNN[i] = newNet[i]->fitness[0];

		// found the minimun
		min = minRow_Pos(fitnessNN,sizeChild);

		//imprime(fitnessNN,3); cout << "min = " << min[0] << " Position = " << min[1] << endl; 	//getchar();
		int pos = (int) min[1];


		switch (pos){
		case 0:
			if(MYDEBUG_AddIDHC == 1) cout << "the winner is add input" << endl;
			validNetwork = validNet[0];
			break;
		case 1:
			if(MYDEBUG_AddIDHC == 1) cout << "the winner is add delay" << endl;
			validNetwork = validNet[1];
			break;
		case 2:
			if(MYDEBUG_AddIDHC == 1) cout << "the winner is add connection" << endl;
			validNetwork = validNet[2];
			break;

		//case 3:
		//	if(MYDEBUG_AddIDHC == 1) cout << "the winner is add Strong connection" << endl;
		//	validNetwork = validNet[3];
		//	break;
		default:
			cout << "There has been an error in addIDC, the min pos is outside the range " << endl << "pos = " << pos << endl;
		}

		//replace net with the winner
		if (validNetwork > 0){
			net[0]->copyCleanNet(newNet[pos]);
		}


		// Liberate memory used /////////////////////////////////////////////
		safefree(&min);
		safefree(&fitnessNN);
		////////////////////////////////////////////////////////////////////////////////////

		return(validNetwork);
	}
	catch (...) {
		cout << "Something were wrong in the C_network::addIDC" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
} /////////////////////////////////////////////////////////////////////////////////////


int C_network::addIHCAssymetric(C_network **net, C_network **newNet, C_network ** scalesNet){
	// Function to add an input, dimension or hidden node
	// tournament selection, the winner replace the last individual in the population
try{

	if(MYDEBUG_AddIDHC == 1)		cout << endl << " --------------- Function add Input / Hidden / connection  Assimetric (C_network::addIHCAssimetric)---------------" << endl;

	// Local variables //////////////////////////////////////////////
	double *min = NULL, *fitnessNN = NULL;
	int sizeChild = 3;							// settle the number of chhildren created
	int i;
	int validNetwork = -1;
	int validNet[sizeChild];
	/////////////////////////////////////////////////////////////////////////


	// create a copy of the actual network
	for(i=0; i<sizeChild; i++)
		newNet[i]->copyCleanNet(net[0]);

	// call specifict functions for each individual
	validNet[0] = newNet[0]->addNode(&scalesNet[0]);
	validNet[1] = newNet[1]->addInputAssymetric(&scalesNet[0]);

	if (algoFeatures == SWAP_CONN)
		validNet[2] = newNet[2]->swapConn(&scalesNet[0]);
	else{
		validNet[2] = newNet[2]->addCon(&scalesNet[0]);

		//if ( algoFeatures == MODULAR1 )
		//	validNet[3] = newNet[3]->addStrongCon(&scalesNet[0]);
	}
	if(MYDEBUG_AddIDHC == 1){
		cout << endl << "Fitness after add Hnode = " << newNet[0]->fitness[0] << endl;
		cout << "Fitness after add Input = " << newNet[1]->fitness[0] << endl;
		cout << "Fitness after add Conn = " << newNet[2]->fitness[0] << endl;
		//cout << "Fitness after add strong Conn = " << newNet[3]->fitness[0] << endl;
	}

	// select the best and copy it to 'this'
	fitnessNN = allocate(fitnessNN,sizeChild);

	for(i=0; i<sizeChild; i++)
		fitnessNN[i] = newNet[i]->fitness[0];

	// found the minimun
	min = minRow_Pos(fitnessNN,sizeChild);


	//imprime(fitnessNN,3); cout << "min = " << min[0] << " Position = " << min[1] << endl; 	//getchar();
	int pos = (int) min[1];


	switch (pos){
	case 0:
		if(MYDEBUG_AddIDHC == 1) cout << "the winner is add Hidden node" << endl;
		validNetwork = validNet[0];
		break;

	case 1:
		if(MYDEBUG_AddIDHC == 1) cout << "the winner is add input" << endl;
		validNetwork = validNet[1];
		break;

	case 2:
		if(MYDEBUG_AddIDHC == 1) cout << "the winner is add connection" << endl;
		validNetwork = validNet[2];
		break;
	//case 3:
	//	if(MYDEBUG_AddIDHC == 1) cout << "the winner is add strong connection" << endl;
	//	validNetwork = validNet[3];
	//	break;
	default:
		cout << "There has been an error in addIHCAssimetric, the min pos is outside the range " << endl << "pos = " << pos << endl;
		//exit(0);
	}

	//replace net with the winner
	if (validNetwork > 0){
		net[0]->copyCleanNet(newNet[pos]);
	}


	// Liberate memory used /////////////////////////////////////////////
	safefree(&min);
	safefree(&fitnessNN);
	if(MYDEBUG_AddIDHC == 1) cout << "Mem liberated addIHCAssimetric" << endl;
	////////////////////////////////////////////////////////////////////////////////////


	return(validNetwork);
}
	catch (...) {
		cout << "Something were wrong in the C_network::addIHCAssimetric" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
}
} /////////////////////////////////////////////////////////////////////////////////////



// Function to delete Inpts, hidden nodes or delays
int C_network::addInpDelay(C_network **net, C_network **newNet, C_network ** scalesNet){
	// Function to add an input or delay
	// tournament selection, the winner replace the last individual in the population
try{

		if(MYDEBUG_AddIDHC == 1)		cout << endl << " --------------- Function add Input / delay ---------------" << endl;

		// Local variables //////////////////////////////////////////////

		double *min = NULL, *fitnessNN = NULL;
		int sizeChild = 2;							// settle the number of chhildren created
		int i;
		int validNetwork = -1;
		int validNet[sizeChild];
		/////////////////////////////////////////////////////////////////////////


		// create a copy of the actual network
		for(i=0; i<sizeChild; i++)
			newNet[i]->copyCleanNet(net[0]);

		// call specifict functions for each individual
		if (fixedinputs != FIXED && task2solve == CLASSIFY)
			validNet[0] = newNet[0]->addInputAssymetric(&scalesNet[0]);
		else
			validNet[0] = newNet[0]->addInput(&scalesNet[0]);

		validNet[1] = newNet[1]->addDelay(&scalesNet[0]);


		if(MYDEBUG_AddIDHC == 1){
			cout << "Fitness after add Input = " << newNet[0]->fitness[0] << endl;
			cout << "Fitness after add Delay = " << newNet[1]->fitness[0] << endl;
		}

		// select the best and copy it to 'this'
		fitnessNN = allocate(fitnessNN,sizeChild);

		for(i=0; i<sizeChild; i++)
			fitnessNN[i] = newNet[i]->fitness[0];

		// foud the minimun
		min = minRow_Pos(fitnessNN,sizeChild);
		//imprime(fitnessNN,3); cout << "min = " << min[0] << " Position = " << min[1] << endl; 	//getchar();
		int pos = (int) min[1];


		switch (pos){
		case 0:
			if(MYDEBUG_AddIDHC == 1) cout << "the winner is add input" << endl;
			validNetwork = validNet[0];
			break;

		case 1:
			if(MYDEBUG_AddIDHC == 1) cout << "the winner is add delay" << endl;
			validNetwork = validNet[1];
			break;

		default:
			cout << "There has been an error in addInpdelay, the min pos is outside the range " << endl << "pos = " << pos << endl;
			//exit(0);
		}

		//replace net with the winner
		if (validNetwork >0){
			net[0]->copyCleanNet(newNet[pos]);
		}


		// Liberate memory used /////////////////////////////////////////////
		safefree(&min);
		safefree(&fitnessNN);
		////////////////////////////////////////////////////////////////////////////////////


		return(validNetwork);
	}
	catch (...) {
		cout << "Something were wrong in the C_network::addInpDelay" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}

} /////////////////////////////////////////////////////////////////////////////////////






void C_network::copyBeforeDelete(int deletePos){
	// delete a column/line from CW, W ,. ..
	// copy the next lines/cols to one line/col before, so it can be resize/delete the last line/col
try{

	// Before resize the variables, copy the positions that are after nodesNet[todelete]
	int lines, cols;
	int allNodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;

	// Copy values Cols (looks correct)
	for(lines = 0; lines < allNodesNet; lines ++){
		for(cols = deletePos; cols < allNodesNet -1 ; cols++){
			// replace the old column wih the next columsn
			CW[lines][cols] = CW[lines][cols+1];
			W[lines][cols] = W[lines][cols+1];
			DeltaW[lines][cols] = DeltaW[lines][cols+1];
		}
	}
	if (isDualWeights == ON){
		for(lines = 0; lines < allNodesNet; lines ++){
			for(cols = deletePos; cols < allNodesNet -1 ; cols++){
				W2[lines][cols] = W2[lines][cols+1];
			}
		}
	}


	// Copy values lines (looks correct)
	for(lines = deletePos; lines < allNodesNet - 1; lines ++){
		for(cols = 0; cols < allNodesNet; cols++){
			// replace the old line wih the next lines
			CW[lines][cols] = CW[lines+1][cols];
			W[lines][cols] = W[lines+1][cols];
			DeltaW[lines][cols] = DeltaW[lines+1][cols];
		}
	}
	if (isDualWeights == ON){
		for(lines = deletePos; lines < allNodesNet - 1; lines ++){
			for(cols = 0; cols < allNodesNet; cols++){
				W2[lines][cols] = W2[lines+1][cols];
			}
		}
	}


	// for the bias, nodes and learning rate per node (looks correct)
	for(cols = deletePos; cols < allNodesNet -1 ; cols++){
		nodes[cols] = nodes[cols+1];
		bias[cols] = bias[cols+1];
		lrate[cols] = lrate[cols+1];
		lrateB[cols] = lrateB[cols+1];
	}

// in this mometn I do not care if there is still garbage in the last position of the network
	// if the network grows this is deleted, if it is copied with copyCleanNet, only the
	// used variables are copies not the complete network with all the values allocated

	//resize the variables (looks correct)
	/*CW = reallocate(CW,allNodesNet,allNodesNet,allNodesNet-1,allNodesNet-1);
	W = reallocate(W,allNodesNet,allNodesNet,allNodesNet-1,allNodesNet-1);
	DeltaW = reallocate(DeltaW,allNodesNet,allNodesNet,allNodesNet-1,allNodesNet-1);
	nodes = reallocate(nodes,allNodesNet,allNodesNet-1);
	bias = reallocate(bias,allNodesNet,allNodesNet-1);
	*/

}
	catch (...) {
		cout << "Something were wrong in the C_network::copyBeforeDelete" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
}

} /////////////////////////////////////////////////////////////////////////////////////

void C_network::copyBeforeAdd(int addPos){
	// Add a column/line from CW, W ,. ..
	// copy the next lines/cols to one line/col after, so it can be resize/add
try{
	// Before copy, resize the variables
	int lines, cols, i;

	// just in case recalculate here too
	varN->finalInp = varN->inputs * varN->Vfilecol;

	int allNodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;


	//resize the variables (Looks that it works)
	//CW = reallocate(CW,allNodesNet-1,allNodesNet-1,allNodesNet,allNodesNet);
	//W = reallocate(W,allNodesNet-1,allNodesNet-1,allNodesNet,allNodesNet);
	//DeltaW = reallocate(DeltaW,allNodesNet-1,allNodesNet-1,allNodesNet,allNodesNet);
	//nodes = reallocate(nodes,allNodesNet-1,allNodesNet);
	//bias = reallocate(bias,allNodesNet-1,allNodesNet);

	// Copy values Cols
	for(lines = 0; lines < allNodesNet; lines ++){
		for(cols = allNodesNet -2; cols >= addPos; cols--){
			// replace the old column wih the next columsn
			CW[lines][cols+1] = CW[lines][cols];
			W[lines][cols+1] = W[lines][cols];
			DeltaW[lines][cols+1] = DeltaW[lines][cols];
		}
	}
	if (isDualWeights == ON){
		for(lines = 0; lines < allNodesNet; lines ++){
			for(cols = allNodesNet -2; cols >= addPos; cols--){
				W2[lines][cols+1] = W2[lines][cols];
			}
		}
	}


	// Copy values lines (looks correct)
	for(lines = allNodesNet - 2; lines >= addPos; lines --){
		for(cols = 0; cols < allNodesNet; cols++){
			// replace the old line wih the next lines
			CW[lines+1][cols] = CW[lines][cols];
			W[lines+1][cols] = W[lines][cols];
			DeltaW[lines+1][cols] = DeltaW[lines][cols];
		}
	}
	if (isDualWeights == ON){
		for(lines = allNodesNet - 2; lines >= addPos; lines --){
			for(cols = 0; cols < allNodesNet; cols++){
				W2[lines+1][cols] = W2[lines][cols];
			}
		}
	}


	// for the bias and nodes
	for(cols = allNodesNet -2; cols >= addPos; cols--){
		nodes[cols+1] = nodes[cols];
		bias[cols+1] = bias[cols];
		lrate[cols+1] = lrate[cols];
		lrateB[cols+1] = lrateB[cols];
	}


	//saveD("txtTemp/W1",W,allNodesNet,allNodesNet); 			saveInt("txtTemp/CW1",CW,allNodesNet,allNodesNet); 			saveInt("txtTemp/nodes1",nodes,allNodesNet); 			saveInt("txtTemp/bias1",bias,allNodesNet);

	//split the values
	// As the paper of Yao, the columns (inputs) remain the same in both nodes (the splitted and the new)
	// the outputs are splitted, e.i. the weights are divided with the next rule (for columns)

	double temprand = rando();
	// with the next for, the bias is divided too
	for(i=0; i<allNodesNet; i++){
		//row
		W[addPos][i] = W[addPos][i] * (1 + temprand); //w1
		W[addPos+1][i] = W[addPos+1][i] * -temprand; //w2
		if (isDualWeights == ON){
			W2[addPos][i] = W2[addPos][i] * (1 + temprand); //w1
			W2[addPos+1][i] = W2[addPos+1][i] * -temprand; //w2
		}
	}


	if(bias[addPos] == 1){ //(looks ok)
		// clean some values
		W[addPos][addPos+1] = 0;
		W[addPos+1][addPos] = 0;

		if (isDualWeights == ON){
			W2[addPos][addPos+1] = 0;
			W2[addPos+1][addPos] = 0;
		}
	}
	else{
		W[addPos][addPos] = 0;
		if (isDualWeights == ON)
			W2[addPos][addPos] = 0;
	}

	for(i=0; i<allNodesNet; i++){
		DeltaW[addPos][i] = 0;
		DeltaW[i][addPos] = 0;
	}

	//cout << "W after update" << endl; 	imprime(W,allNodesNet,allNodesNet); 	saveD("txtTemp/W2",W,allNodesNet,allNodesNet); 			saveInt("txtTemp/CW2",CW,allNodesNet,allNodesNet); 			saveInt("txtTemp/nodes2",nodes,allNodesNet); 			saveInt("txtTemp/bias2",bias,allNodesNet);
}
	catch (...) {
		cout << "Something were wrong in the C_network::copyBeforeAdd" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
}
} /////////////////////////////////////////////////////////////////////////////////////





void C_network::copyBeforeAddModule(int addPos){
	// Add a column/line from CW, W ,. ..
	// copy the next lines/cols to one line/col after, so it can be resize/add
try{
	// Before copy, resize the variables
	int lines, cols, i;

	// just in case recalculate here too
	varN->finalInp = varN->inputs * varN->Vfilecol;

	int allNodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;


	//resize the variables (Looks that it works)
	//CW = reallocate(CW,allNodesNet-1,allNodesNet-1,allNodesNet,allNodesNet);
	//W = reallocate(W,allNodesNet-1,allNodesNet-1,allNodesNet,allNodesNet);
	//DeltaW = reallocate(DeltaW,allNodesNet-1,allNodesNet-1,allNodesNet,allNodesNet);
	//nodes = reallocate(nodes,allNodesNet-1,allNodesNet);
	//bias = reallocate(bias,allNodesNet-1,allNodesNet);

	// Copy values Cols
	for(lines = 0; lines < allNodesNet; lines ++){
		for(cols = allNodesNet -2; cols >= addPos; cols--){
			// replace the old column wih the next columsn
			CW[lines][cols+1] = CW[lines][cols];
			W[lines][cols+1] = W[lines][cols];
			DeltaW[lines][cols+1] = DeltaW[lines][cols];
		}
	}
	if (isDualWeights == ON){
		for(lines = 0; lines < allNodesNet; lines ++){
			for(cols = allNodesNet -2; cols >= addPos; cols--){
				W2[lines][cols+1] = W2[lines][cols];
			}
		}
	}


	// Copy values lines (looks correct)
	for(lines = allNodesNet - 2; lines >= addPos; lines --){
		for(cols = 0; cols < allNodesNet; cols++){
			// replace the old line wih the next lines
			CW[lines+1][cols] = CW[lines][cols];
			W[lines+1][cols] = W[lines][cols];
			DeltaW[lines+1][cols] = DeltaW[lines][cols];
		}
	}
	if (isDualWeights == ON){
		for(lines = allNodesNet - 2; lines >= addPos; lines --){
			for(cols = 0; cols < allNodesNet; cols++){
				W2[lines+1][cols] = W2[lines][cols];
			}
		}
	}


	// for the bias and nodes
	for(cols = allNodesNet -2; cols >= addPos; cols--){
		nodes[cols+1] = nodes[cols];
		bias[cols+1] = bias[cols];
		lrate[cols+1] = lrate[cols];
		lrateB[cols+1] = lrateB[cols];
	}


	//saveD("txtTemp/W1",W,allNodesNet,allNodesNet); 			saveInt("txtTemp/CW1",CW,allNodesNet,allNodesNet); 			saveInt("txtTemp/nodes1",nodes,allNodesNet); 			saveInt("txtTemp/bias1",bias,allNodesNet);

	// set to zero the lines and cols just copied

	for(i=0; i<allNodesNet; i++){
		W[addPos+1][i] = 0;
		W[i][addPos+1] = 0;
		if (isDualWeights == ON){
			W2[addPos+1][i] = 0;
			W2[i][addPos+1] = 0;
		}
		CW[addPos+1][i] = 0;
		CW[i][addPos+1] = 0;
		DeltaW[addPos+1][i] = 0;
		DeltaW[i][addPos+1] = 0;
	}

}
	catch (...) {
		cout << "Something were wrong in the C_network::copyBeforeAddModule" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
}
} /////////////////////////////////////////////////////////////////////////////////////






/* Original function resizing the networ
void C_network::rearrangeData(void){
	// After deletion or addition of inputs or delays, this function is called
	// to recalculate the adecuate number of inputs
try{
	// Calculate again the data sets
	delete [] set2SSP;
	set2SSP = NULL;

	delete [] set2MSP;
	set2MSP = NULL;

	delete predictI;
	predictI = NULL;

	delete predictF;
	predictF = NULL;

	delete(sets);
	sets = NULL;


	// Allocate them again
	sets = new C_sets;												//allocate a few vars of the class
	set2SSP = (C_predParam *) new C_predParam [numDiffPredict];		//no allocate any var
	set2MSP = (C_predParam *) new C_predParam [numDiffPredict];		//no allocate any var
	predictI = new C_predParam;
	predictF = new C_predParam;

	// initialize the classes with the proper values
	//set set2SSP and set2MSP classes
	set_allPredictionsStruct(numDiffPredict, initialStepPred);

	// Set the structures where the predction inside and outside will be saved
	predictI->set_predParam(varN->Vsizetpos,varN->VPred_stepAhead,varN->finalInp,1);
	predictF->set_predParam(varN->Vsizetpos,varN->VPred_stepAhead,varN->finalInp,1);

	//set the data that will be used
	sets->prepo(varN, set2SSP, set2MSP, predictI, predictF);
}
	catch (...) {
		cout << "Something were wrong in the C_network::rearrangeData" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
}
}

*/

void C_network::rearrangeData(void){
	// After deletion or addition of inputs or delays, this function is called
	// to recalculate the adecuate number of inputs
try{
	// Clean values

	if(extraPredictions == ON)
		this->cleanAllPred();

	predictI->clean();
	predictF->clean();

	// Next for sets
	sets->clean();
	/////////////////////////////////

	// Re-calculate values
	// initialize the classes with the proper values
	//set set2SSP and set2MSP classes
	if(extraPredictions == ON)
		set_allPredictionsStruct(numDiffPredict, initialStepPred);

	// Set the structures where the predction inside and outside will be saved
	if ( kindPred == MSP ){
		predictI->set_predParam(sizetpos,Pred_stepAheadInside,varN->finalInp,1);																	/// chenged Pred_stepAhead by Pred_stepAheadInside
		predictF->set_predParam(sizetpos,Pred_stepAhead,varN->finalInp,1);
	}
	else{
		if( kindPred == SSP){
			// for classification and prediction it is the same configuration, in both cases the number of steps to predict are the same as the number of inputs/patterns
			predictI->set_predParam(sizetpos,Pred_stepAheadInside,varN->finalInp,Pred_stepAheadInside);
			predictF->set_predParam(sizetpos,Pred_stepAhead,varN->finalInp,Pred_stepAhead);
		}
	}

	//set the data that will be used
	if (task2solve == PREDICT )
		 sets->prepo(varN, set2SSP, set2MSP, predictI, predictF, INPUTF.c_str() ); 						// load the original data file
	 else if (task2solve == CLASSIFY && fitness_learnQuick2Genaralize == OFF)
		 sets->prepoClassification(varN, predictI, predictF, INPUTF.c_str() );								// load the original data file
	 else if (task2solve == CLASSIFY && fitness_learnQuick2Genaralize == ON)
		 sets->prepoClassification(varN, predictI, predictF, "GenerateDataSet");								// Generate a new data set

}
	catch (...) {
		cout << "Something were wrong in the C_network::rearrangeData" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
}
}

void C_network::rearrangeAndLoadData(const char Data2LoaD[]){
	// After deletion or addition of inputs or delays, this function is called
	// to recalculate the adecuate number of inputs
try{
	// The number of inputs, delays, ... have not changed, so there is not need to modified anything else, excep the data
	// to load, i.e. all 'sets'

	sets->clean();

	//set the data that will be used
	sets->prepo(varN, set2SSP, set2MSP, predictI, predictF, Data2LoaD);
}
	catch (...) {
		cout << "Something were wrong in the C_network::rearrangeAndLoadData" << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
}
}

void C_network::recalculateHNodes(void){
	// Recalculate the hidden nodes and output nodes (looks correct)


	//after deleteion recalculate the number of poshidden
	int cont1 = 0;
	set(poshidden,varN->hidden + varN->VnoOutputs, 0);
	for(int j = varN->finalInp; j<(varN->finalInp + varN->hidden + varN->VnoOutputs); j++){
		if(nodes[j] == 1){
			poshidden[cont1] = j;
			cont1++;
		}
	}
	// only to check error
	if(sizepos[1] != cont1){
		cout << "Somethig wrong with the recalculation of hidden nodes.... check it" << endl;
		exit (0);
	}
} //////////////////////////////////////////////////////////////////////////////////////////


void C_network::recalculateInputs(void){

	// Recalculate the Inpts and hidden nodes
	// the hidden nodes are recauculated too because if the inputs are mofified they affect the position of the hidden nodes and output nodes
	varN->finalInp = varN->inputs * varN->Vfilecol;

	//after deleteion recalculate the number of inputs and hidden nodes
	int cont = 0;
	int cont1 = 0;
	set(posinputs,varN->finalInp, 0);
	set(poshidden,varN->hidden + varN->VnoOutputs, 0);
	for(int j=0; j<(varN->finalInp + varN->hidden + varN->VnoOutputs); j++){
		if(nodes[j] == 1){
			if(j < varN->finalInp){
				posinputs[cont] = j;
				cont++;
			}
			else{
				poshidden[cont1] = j;
				cont1++;
			}
		}
	}
	// only to check error, I do not count inputs as they may be deleted so node[i] = 0 for inputs, even that the input is present in the datra set
	//if(sizepos[1] != cont1){
	//	cout << "Somethig wrong with the recalculation of inputs or hidden nodes.... check it, function C_network::recalculateInputs" << endl;
	//			exit (0);
	//}

} //////////////////////////////////////////////////////////////////////////////////////////



/// This section is for the case in which a network is trained in more that one data set

void C_network::trainScales(C_network **netScale, 	int epochs2Use, int where2train){
	// This fuction train the network in each scale and calculate the fitness

	/* Inputs:
	 *  netScales			is a copy of the networks where the scales is save, here this already was copied into netScales
	 */

	int size2Train = 0;
	int *i = NULL;
	int allnodes = 0;
	int conti = 0;
	int j = 0;
	double prevFit = fitness[0];

	// determinate how many scales will be used to train   "scale2Train" is a global variable
	size2Train = sizeof(scale2Train) / sizeof(scale2Train[0]);

	allnodes = varN->finalInp + varN->hidden + varN->VnoOutputs;

	// Before train change the vector of scales () in a random way to put in different posisiton the training every generation
	randomVec(&scale2Train[0], size2Train);

	// Train over all scales
	for (i=scale2Train; conti < size2Train; i++){											// move through the network to train

		// copy original weights into the correct network
		copy(netScale[*i-1]->W, W ,allnodes, allnodes);
		copy(netScale[*i-1]->DeltaW, DeltaW, allnodes, allnodes);

		// train
		netScale[*i-1]->trainMBP(epochs2Use,where2train);				// I do not need to save the fitnes here, ahead is evaluated over all
																							// scales the network and there it is saved the error at this scale
																							// I have check out it and it is correct the error given here and the one in the next for
		//cout << "fitness = " << netScale[*i-1]->fitness[0] << endl;

		// restore the weights to the original network
		copy(W, netScale[*i-1]->W, allnodes, allnodes);
		if (isDualWeights == ON)
			copy(W2, netScale[*i-1]->W2, allnodes, allnodes);
		copy(DeltaW, netScale[*i-1]->DeltaW, allnodes, allnodes);

		conti++;

		// if it was the last set to be used to train, save everytihng to the original network, so it is save
		// the information of set2MSP, predictI,F, ....

		if (conti ==  size2Train)
			this->copyNet(netScale[*i-1]);

	}

	// evaluate over all data sets
	for(j = 0; j<7; j++){
		//copy trained weights into each network
		copy(netScale[j]->W, W, allnodes, allnodes);
		if (isDualWeights == ON)
			copy(netScale[j]->W2, W2, allnodes, allnodes);
		copy(netScale[j]->DeltaW, DeltaW, allnodes, allnodes);

		// Evaluate
		if ( fitness_byEpochs == ON ){
			cout << "add zero at the end because I change the prototy of the function. Update this function when used again, function trainScales in addDelNet.hpp, update this function, exit..." << endl;
			exit (0);
		}
		netScale[j]->evaluateANN(where2train,0);    // XXXXXXXXXXX add zero at the end because I change the prototy of the function. Update this function when used again

		// copy the actual fitness to the Errori from the actual network (ind)
		Errori[j] = netScale[j]->fitness[0];

	}

	// Determinate the fitness of the actual network
	// The fitness is formed from all set, even if all were not used in the training
	// bibtex \cite{huesken2000} Eq = E = sqrt((sum(Error1)^2) / k);    // where k is the number of task plearned

	// clear previous fitners just in case
	fitness[0] = 0;


	/*for (j=0; j < 7 ; j++){											// move through the network used in the training
		fitness[0] += Errori[j] * Errori[j];										// the sum of all squared erros
	}
	fitness[0] = sqrt(fitness[0] / 7);*/

conti = 0;
	for (i=scale2Train; conti < size2Train; i++){											// move through the network used in the training
		fitness[0] += Errori[*i-1] * Errori[*i-1];										// the sum of all squared erros
		conti++;
	}

	fitness[0] = sqrt(fitness[0] / size2Train);

	// Just in case that the error diverge
	if(fitness[0] <0 || fitness[0] > 100)
		fitness[0] = 100;


	// determinate the STP
	status[0] = obtainSTP(fitness[0], prevFit);						// the STP is determinate by real predictions

}


// Function to copy one network to all scales, then update the data set
void C_network::copyALLscales(C_network **netScale){
/*!
 * netScale						is the set of networks that hold the other scales, here is copied 'this' into netScale
 * 										and the data sets are updated witht he new one
 * in the future simplify the functions if they are continue used
 */
	// declarate local variables
	char data2load[] = "txtFiles/dataInputN0.txt";	// final variable with all info
	string str1;														// temporal string to hold all the name to load
	string str2 = ".txt";											// variable with the extencion
	string strD = "txtFiles/dataInputN";					// the variable with the first part of the info
	char strTemp[3];												// save the conversion from int to char
	int i,n;

	// Copy the same network in each scaleNetwork
	for( i=0; i<7; i++){
		// set up the name of the file to load the data
		n = sprintf (strTemp, "%d", i+1); 					//cout << "strTemp = " << strTemp << endl;
		str1 = strD + strTemp + str2; 						//cout << "str1 = " << str1 << endl;
		// generate the correct data to load
		strcpy(data2load,str1.c_str());						//cout << "data2load= " << data2load << endl;


		// Copy the network
		netScale[i]->copyCleanNet(this);

		//Load the correct data set for each network and update set, set2MSP, ....
		netScale[i]->rearrangeAndLoadData(data2load);
	}

}/////////////////////////////////////////////////////////////////////////////////////////


int C_network::obtaintSharedNodes(int *sharedNodes){
	/*!
	 * Function to obtain the shared nodes from the structure sharedModule
	 */

	// Local var
	int cont = 0, i;

	//Method
	for (i=varN->finalInp; i < (varN->finalInp + varN->hidden); i++ ){
		if ( sharedModule->nodesInModule[i][1] == -1 ){
			sharedNodes[ cont ] = i; 				// save index of the nodes that can be deleted
			cont++;
		}
	}
	return ( cont );
}


int C_network::obtaintSharedConn(int **sharedConn){
	/*!
	 * Function to obtain the shared connections from the structure huskenModule
	 * NOTE that a connection to a isolated node will be consideres as a shared connection, even if it is a pure modular architecture
	 *
	 * Works for MLP and GMLP
	 */

	// Local var
	int cont = 0, i,j;
	int allNodes = 0;
	int node2count = 0;								// this variable is used for the condition when the inputs are considered or not in the modularity
	// Initialize var
	allNodes = varN->finalInp + varN->hidden + varN->VnoOutputs;

	// Method
	// Discover the shared connections :: when a node is selectec (lines) it is evaluated all connections (cols)
	// if the connection goes to a nodes in a different module, then it is a shared connection

	// count inputs or not
	if ( considerInputsInMod == ON )
		node2count = 0;
	else
		node2count = varN->finalInp;	// not count inputs, so the connection of inputs are not deleted

	for( i=node2count; i < allNodes - 1 ; i++){																	// for all lines except the last ::: count inputs
		for( j = varN->finalInp; j < allNodes; j++ ){ 															// for all the hidden nodes and outputs
			if ( j > i){
				if( CW[i][j] == 1 ){
					if( huskenModule->nodesInModule[i][1] != huskenModule->nodesInModule[j][1] ) {		// if the connection goes to another module
						// direct conenctions to outputs are treated as a normal conenction as the output belongs just to a single module
						sharedConn[0][cont] = i;
						sharedConn[1][cont] = j;
						cont ++;
					}
				}
			}
		}
	}

	return ( cont );
}


int C_network::obtaintStrongConn(int **Conn){
	/*!
	 * Function to obtain the strong connections from the structure huskenModule
	 * This function is quite similar to Cnetwork::obtainConn()
	 *
	 * Here it is considered if the connections are constrained, so take care that the correct values are configured in mainepnet.hpp
	 *
	 * Works for MLP and GMLP
	 */

	// Local var
	int cont = 0, *jj,*kk;
	int cont0 = 0;
	int cont1 = 0;
	int allNodes = 0;
	//int **tmpConn = NULL;
	int allowedConnIH = 0;
	int allowedConnHO = 0;

	int allowedConnIO = 0;
	int allowedConnHH = 0;
	int allowedConnOO = 0;

	int type = 0; 		// I am lokking for connection not activated

	// save the actual connection of each sub-matrix
	// this varibales plays two roles, first they contain the activated connection in each submatrix each one, second: they contain the connection from each submatrix in Conn (connections to add)
	int actualConn;
	int numConnTmp = 0;
	// Initialize var
	allNodes = varN->finalInp + varN->hidden + varN->VnoOutputs;

	// Method

	// First is obtained connections from IH and HO which are the common parts for MLP and GMLP

	if ( IS_CONSTRAINED_CONN == ON &&  type == 0 ){			//if constrained and look for connection to add
		//tmpConn = allocate(tmpConn,2,allNodes*allNodes);
		allowedConnIH = ( int ) ( ( varN->finalInp * varN->hidden ) * CONN_ALLOWED_IH );
		allowedConnHO = ( int ) ( ( varN->hidden * varN->VnoOutputs ) * CONN_ALLOWED_HO );

		if (  IS_MLP == OFF  ){
			allowedConnIO = ( int ) ( ( varN->finalInp * varN->VnoOutputs ) * CONN_ALLOWED_IO );
			allowedConnHH = ( int ) ( setupDivHidden( varN->hidden )  * CONN_ALLOWED_HH );
			allowedConnOO = ( int ) ( setupDivHidden( varN->VnoOutputs)  * CONN_ALLOWED_OO );
		}
	}


	// Discover the available connections in
	//  I H
	for(jj=posinputs; cont0<sizepos[0];jj++){
		cont0++;
		for (kk=poshidden; cont1<varN->hidden; kk++){ 		// for hidden only
			cont1++;
			if (  CW[*jj][*kk] == type){
				if( huskenModule->nodesInModule[*jj][1] == huskenModule->nodesInModule[*kk][1] ) { 					// nodes in the same module
					Conn[0][cont] = 0;						// indicate that this pattern is from IH
					Conn[1][cont] = *jj;
					Conn[2][cont] = *kk;
					cont ++;
				}
			}
		}
		cont1=0;
	}
	// Check if the connections to add do not exceed the maximum allowed in IH
	// if it exceed take at random just the required that do not excced and discard the rest
	if ( IS_CONSTRAINED_CONN == ON &&  type == 0 	&& algoFeatures != SWAP_CONN){
		actualConn = (varN->inputs*varN->hidden) - cont; 							// take the complement to know how many connections there are activated
		cont = limitConnection2Add(Conn, 0, cont, allowedConnIH, actualConn);   // save the connections that are used for this set // now it is not the actual connections active, now it is the actual connections in Conn for IH
		//actualConnIH = cont;
		numConnTmp = cont; // save the number of connecction until here
	}
	//imprime( Conn, 3,  cont);


	// Discover the available connections in
	//  H O
	cont0 = 0;
	cont1= 0;
	for(jj=poshidden; cont0< varN->hidden ; jj++){
		cont0++;
		for ( kk = &poshidden[varN->hidden]; cont1<varN->VnoOutputs; kk++){
			cont1++;
			if (  CW[*jj][*kk] == type){
				if( huskenModule->nodesInModule[*jj][1] == huskenModule->nodesInModule[*kk][1] ) { 					// nodes in the same module
					Conn[0][cont] = 1;						// indicate that this pattern is from HO
					Conn[1][cont] = *jj;
					Conn[2][cont] = *kk;
					cont ++;
				}
			}
		}
		cont1=0;
	}
	if ( IS_CONSTRAINED_CONN == ON &&  type == 0 && algoFeatures != SWAP_CONN){
		actualConn = ( varN->hidden * varN->VnoOutputs ) - cont + numConnTmp; //actualConnIH;   //actualConnIH is the conn from IH, so it is rest them from the total cont
		cont = limitConnection2Add(Conn, numConnTmp, cont, allowedConnHO, actualConn);
		numConnTmp = cont;
		//actualConnHO  = cont - actualConnIH;
	}
	//imprime( Conn, 3,  cont);


	// Second part
	// discover connection for GMLP

	if ( IS_MLP == OFF ){ 						// for the GMLP
		// functions for IO, HH and HO
/*
		// Discover the available connections in IO
		cont0 = 0;
		cont1= 0;
		for(jj=posinputs; cont0<sizepos[0];jj++){
			cont0++;
			for ( kk = &poshidden[varN->hidden]; cont1<varN->VnoOutputs; kk++){
				cont1++;
				if (  CW[*jj][*kk] == type){
					if( huskenModule->nodesInModule[*jj][1] == huskenModule->nodesInModule[*kk][1] ) { 					// nodes in the same module
						Conn[0][cont] = 2;						// indicate that this pattern is from IO
						Conn[1][cont] = *jj;
						Conn[2][cont] = *kk;
						cont ++;
					}
				}
			}
			cont1=0;
		}
		if ( IS_CONSTRAINED_CONN == ON &&  type == 0 && algoFeatures != SWAP_CONN){
			actualConn = ( varN->inputs * varN->VnoOutputs ) - cont + numConnTmp; // actualConnHO - actualConnIH;
			cont = limitConnection2Add(Conn, numConnTmp, cont, allowedConnIO, actualConn);
			numConnTmp = cont;
			//actualConnIO = cont - actualConnHO + actualConnIH;
		}
		//imprime( Conn, 3,  cont);
*/
		// Discover the available connections in HH
		cont0 = 0;
		cont1= 0;
		for(jj=poshidden; cont0<varN->hidden -1; jj++){
			cont0++;
			for ( kk = poshidden; cont1<varN->hidden; kk++){
				cont1++;
				if(*kk > *jj){
					if (  CW[*jj][*kk] == type){
						if( huskenModule->nodesInModule[*jj][1] == huskenModule->nodesInModule[*kk][1] ) { 					// nodes in the same module
							Conn[0][cont] = 3;						// indicate that this pattern is from HH
							Conn[1][cont] = *jj;
							Conn[2][cont] = *kk;
							cont ++;
						}
					}
				}
			}
			cont1=0;
		}
		if ( IS_CONSTRAINED_CONN == ON &&  type == 0 && algoFeatures != SWAP_CONN){
			actualConn =  setupDivHidden( varN->hidden ) - cont + numConnTmp; // actualConnHO - actualConnIH - actualConnIO;
			cont = limitConnection2Add(Conn, numConnTmp, cont, allowedConnHH, actualConn);
			numConnTmp = cont;
			//actualConnHH = cont - actualConnIO + actualConnHO + actualConnIH;
		}
		//imprime( Conn, 3,  cont);
/*
		// Discover the available connections in OO
		cont0 = 0;
		cont1= 0;
		for(jj= &poshidden[varN->hidden]; cont0<varN->VnoOutputs -1 ; jj++){
			cont0++;
			for ( kk = &poshidden[varN->hidden]; cont1<varN->VnoOutputs; kk++){
				cont1++;
				if(*kk > *jj){
					if (  CW[*jj][*kk] == type){
						if( huskenModule->nodesInModule[*jj][1] == huskenModule->nodesInModule[*kk][1] ) { 					// nodes in the same module
							Conn[0][cont] = 4;						// indicate that this pattern is from OO
							Conn[1][cont] = *jj;
							Conn[2][cont] = *kk;
							cont ++;
						}
					}
				}
			}
			cont1=0;
		}

		if ( IS_CONSTRAINED_CONN == ON &&  type == 0 && algoFeatures != SWAP_CONN){
			actualConn =  setupDivHidden( varN->VnoOutputs ) - cont + numConnTmp; //actualConnHO - actualConnIH - actualConnIO - actualConnHH;
			cont = limitConnection2Add(Conn, numConnTmp, cont, allowedConnOO, actualConn);
			//actualConnOO = cont - actualConnHH + actualConnIO + actualConnHO + actualConnIH;
		}
		//imprime( Conn, 3,  cont);
*/
	} /// finish if it is a GMLP



	// Third part
	// conections from bias
	if (algoFeatures != SWAP_CONN){ 								// only take into account the bias if the algorithm is not swap connections
		cont0 = 0 ;
		for(jj=poshidden; cont0<sizepos[1]; jj++){ 			// The bias is taken into account
			if(bias[*jj] == type){
				Conn[0][cont] = 5;						// indicate that this pattern is from bias
				Conn[1][cont] = *jj;
				Conn[2][cont] = *jj;
				cont++;
			}
			cont0 ++;
		}
		//imprime( Conn, 3,  cont);
	}
	// set to NULL
	jj = NULL;
	kk = NULL;

	return ( cont );
}

int C_network::obtaintNUMSharedConn( void ){
	/*!
	 * Function to obtain the number of shared connections from the structure huskenModule
	 * This is the same function as C_network::obtaintSharedConn, but here is only returned the number of them
	 * This was implemented only to have a faster precessing when it is colelcted the average number of shared connections in the population (ALLParam)
	 */

	// Local var
	int cont = 0, i,j;
	int allNodes = 0;
	int node2count = 0;								// this variable is used for the condition when the inputs are considered or not in the modularity
	// Initialize var
	allNodes = varN->finalInp + varN->hidden + varN->VnoOutputs;

	// Method
	// Discover the shared connections :: when a node is selectec (lines) it is evaluated all connections (cols)
	// if the connection goes to a nodes in a different module, then it is a shared connection

	// count inputs or not
	if ( considerInputsInMod == ON )
		node2count = 0;
	else
		node2count = varN->finalInp;	// not count inputs, so the connection of inputs are not deleted

	for( i=node2count; i < allNodes - 1 ; i++){																	// for all lines except the last ::: count inputs
		for( j = varN->finalInp; j < allNodes; j++ ){ 															// for all the hidden nodes and outputs
			if ( j > i){
				if( CW[i][j] == 1 ){
					if( huskenModule->nodesInModule[i][1] != huskenModule->nodesInModule[j][1] ) {		// if the connection goes to another module
						// direct conenctions to outputs are treated as a normal conenction as the output belongs just to a single module
						//sharedConn[0][cont] = i;
						//sharedConn[1][cont] = j;
						cont ++;
					}
				}
			}
		}
	}

	return ( cont );
}///////////////////////////////////


int C_network::obtaintConn2Del_NonConvergentM(int **Conn){
	/*!
	 * Obtain the 50% of all connection availables using the non convergent method used originaly in the EPNet algorithm (Yao 1997)
	 * Bias is taken into account to be deleted
	 */

		// Local var
		int cont = 0, i,j;
		int NumNodesNet = 0;


		register int contii,contjj,colwijtodelete;

		double **test = NULL;
		double **wijtodelete = NULL;
		double *maximum1 = NULL;

		int *allnodes = NULL;
		int sizeallnodes;
		int *ii = NULL;
		int *jj = NULL;
		/////////////////////////////////////////////////////////////////////////

		// Initialize var
		NumNodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;
		test = allocate(test,NumNodesNet,NumNodesNet);
		maximum1 = allocate(maximum1,3);
		allnodes = (int *) malloc((NumNodesNet)*sizeof(int));
		sizeallnodes = obtainAllnodes(allnodes); //     cout << "All nodes in delete connection" << endl;      imprime(allnodes,sizeallnodes);
		wijtodelete = allocate(wijtodelete,3,NumNodesNet*NumNodesNet);

		//Calculate importance of each connection Non convergent method
		if( MYDEBUG_DelCon == 1) 			cout << " calling importance function---" << endl;
		importance(test);


		// Extract the possible candidates to be eliminated  ///////////////////////////
		/// Check the bias here, it seems that it is not deleted, which means that it is only deleted in the case a node is deleted

		cont = 0;
		contii = 0;
		for(ii=poshidden; contii<sizepos[1]; ii++){
			contjj = 0;
			for(jj=allnodes; contjj<sizeallnodes; jj++){
				if(test[*jj][*ii] > 0){
					wijtodelete[0][cont] = test[*jj][*ii];
					wijtodelete[1][cont] = *jj;
					wijtodelete[2][cont] = *ii;
					cont++;
				}
				if(*jj > *ii)
					break;
				contjj++;
			}
			contii++;
		}

		colwijtodelete = cont; //////////////////////////////////////////////////////////////////////////////

		//Decide number of connections to delete, I choose the connection form the 50% of connections with the lowest significance
		//printf("colwijtodelete =%d / 2 = %d\n",colwijtodelete,(int)(colwijtodelete/2));

		for(i=0; i<(int)(colwijtodelete/2); i++){
			maxAndpos(wijtodelete,colwijtodelete,maximum1);   	    //printf("maximum\n"); imprimeVd(maximum1,3);
			//printf("indexes = [%d] [%d]\n",(int)maximum1[1],(int)maximum1[2]);
			test[(int)maximum1[1]][(int)maximum1[2]] = 0; 			//printf("-------------------wijtodelete \n\n"); imprimeMd(wijtodelete,3,colwijtodelete);
		}

		//After delete the most important connections / recalculate the nodes that can be deleted
		// Extract the possible candidates to be eliminated ///////////////////////////////////////////////////////////////////////////////////////////////////

		//printf("sizeallnodes = %d\n",sizeallnodes);
		set(wijtodelete,3,NumNodesNet*NumNodesNet, 0);
		cont = 0;
		contii = 0;
		for(ii=poshidden; contii<sizepos[1]; ii++){
			contjj = 0;
			for(jj=allnodes; contjj<sizeallnodes; jj++){
				if(test[*jj][*ii] > 0){
					wijtodelete[0][cont] = test[*jj][*ii];
					wijtodelete[1][cont] = *jj;
					wijtodelete[2][cont] = *ii;
					cont++;
				}
				if(*jj > *ii)
					break;
				contjj++;
			}
			contii++;
		}

		// copy to Conn, only line 1 and 2
		for ( i=1; i<3; i++ ){
			for ( j=0; j<cont; j++ ){
				Conn[i][j] = (int) wijtodelete[i][j];
			}
		}


		//imprime(wijtodelete, 3, cont);
		//imprime(Conn, 3, cont);



		// Liberate memory ////////////////////////
		jj = NULL;
		ii = NULL;
		safefree(&allnodes);
		safefree(&maximum1);
		safefree(&wijtodelete,3);
		safefree(&test,NumNodesNet);
		///////////////////////////////////////////////////////

		return ( cont );

	}///////////////////////////////////////




int C_network::obtaintConn(int **Conn, int type){
	/*!
	 * Discover all the possible connections to be deleted or Added in IH and HO ::: works only for a MLP with 1 hidden layer or GMLP
	 *
	 * if type is 0, then is looked for the conenctions to be added, if it is 1 the looks the connections to be removed
	 *
	 * Note that in the case for select connection to delete, it is not implemented any function to avoid the conenction slection to outputs in cases they only have one input
	 *
	 */

	// Local var
	int cont = 0, *jj,*kk;
	int cont0 = 0;
	int cont1 = 0;
	int allNodes = 0;
	//int **tmpConn = NULL;
	int allowedConnIH = 0;
	int allowedConnHO = 0;

	int allowedConnIO = 0;
	int allowedConnHH = 0;
	int allowedConnOO = 0;

	// save the actual connection of each sub-matrix
	// this varibales plays two roles, first they contain the activated connection in each submatrix each one, second: they contain the connection from each submatrix in Conn (connections to add)
	int actualConn;
	int numConnTmp = 0;
	// Initialize var
	allNodes = varN->finalInp + varN->hidden + varN->VnoOutputs;

	// Method

	// First is obtained connections from IH and HO which are the common parts for MLP and GMLP

	if ( IS_CONSTRAINED_CONN == ON &&  type == 0 ){			//if constrained and look for connection to add
		//tmpConn = allocate(tmpConn,2,allNodes*allNodes);
		allowedConnIH = ( int ) ( ( varN->finalInp * varN->hidden ) * CONN_ALLOWED_IH );
		allowedConnHO = ( int ) ( ( varN->hidden * varN->VnoOutputs ) * CONN_ALLOWED_HO );

		if (  IS_MLP == OFF  ){
			allowedConnIO = ( int ) ( ( varN->finalInp * varN->VnoOutputs ) * CONN_ALLOWED_IO );
			allowedConnHH = ( int ) ( setupDivHidden( varN->hidden )  * CONN_ALLOWED_HH );
			allowedConnOO = ( int ) ( setupDivHidden( varN->VnoOutputs)  * CONN_ALLOWED_OO );
		}
	}


	// Discover the available connections in
	//  I H
	for(jj=posinputs; cont0<sizepos[0];jj++){
		cont0++;
		for (kk=poshidden; cont1<varN->hidden; kk++){ 		// for hidden only
			cont1++;
			if (  CW[*jj][*kk] == type){
				Conn[0][cont] = 0;						// indicate that this pattern is from IH
				Conn[1][cont] = *jj;
				Conn[2][cont] = *kk;
				cont ++;
			}
		}
		cont1=0;
	}
	// Check if the connections to add do not exceed the maximum allowed in IH
	// if it exceed take at random just the required that do not excced and discard the rest
	if ( IS_CONSTRAINED_CONN == ON &&  type == 0 	&& algoFeatures != SWAP_CONN){
		actualConn = (varN->inputs*varN->hidden) - cont; 							// take the complement to know how many connections there are activated
		cont = limitConnection2Add(Conn, 0, cont, allowedConnIH, actualConn);   // save the connections that are used for this set // now it is not the actual connections active, now it is the actual connections in Conn for IH
		//actualConnIH = cont;
		numConnTmp = cont; // save the number of connecction until here

	}
	//imprime( Conn, 3,  cont);


	// Discover the available connections in
	//  H O
	cont0 = 0;
	cont1= 0;
	for(jj=poshidden; cont0< varN->hidden ; jj++){
		cont0++;
		for ( kk = &poshidden[varN->hidden]; cont1<varN->VnoOutputs; kk++){
			cont1++;
			if (  CW[*jj][*kk] == type){
				Conn[0][cont] = 1;						// indicate that this pattern is from HO
				Conn[1][cont] = *jj;
				Conn[2][cont] = *kk;
				cont ++;
			}
		}
		cont1=0;
	}

	if ( IS_CONSTRAINED_CONN == ON &&  type == 0 && algoFeatures != SWAP_CONN){
		actualConn = ( varN->hidden * varN->VnoOutputs ) - cont + numConnTmp; //actualConnIH;   //actualConnIH is the conn from IH, so it is rest them from the total cont
		cont = limitConnection2Add(Conn, numConnTmp, cont, allowedConnHO, actualConn);
		numConnTmp = cont;
		//actualConnHO  = cont - actualConnIH;
	}
	//imprime( Conn, 3,  cont);



	// Second part
	// discover connection for GMLP

	if ( IS_MLP == OFF ){ 						// for the GMLP
		// functions for IO, HH and HO

		// Discover the available connections in IO
		cont0 = 0;
		cont1= 0;
		for(jj=posinputs; cont0<sizepos[0];jj++){
			cont0++;
			for ( kk = &poshidden[varN->hidden]; cont1<varN->VnoOutputs; kk++){
				cont1++;
				if (  CW[*jj][*kk] == type){
					Conn[0][cont] = 2;						// indicate that this pattern is from IO
					Conn[1][cont] = *jj;
					Conn[2][cont] = *kk;
					cont ++;
				}
			}
			cont1=0;
		}

		if ( IS_CONSTRAINED_CONN == ON &&  type == 0 && algoFeatures != SWAP_CONN){
			actualConn = ( varN->inputs * varN->VnoOutputs ) - cont + numConnTmp; // actualConnHO - actualConnIH;
			cont = limitConnection2Add(Conn, numConnTmp, cont, allowedConnIO, actualConn);
			numConnTmp = cont;
			//actualConnIO = cont - actualConnHO + actualConnIH;

		}
		//imprime( Conn, 3,  cont);

		// Discover the available connections in HH
		cont0 = 0;
		cont1= 0;
		for(jj=poshidden; cont0<varN->hidden -1; jj++){
			cont0++;
			for ( kk = poshidden; cont1<varN->hidden; kk++){
				cont1++;
				if(*kk > *jj){
					if (  CW[*jj][*kk] == type){
						Conn[0][cont] = 3;						// indicate that this pattern is from HH
						Conn[1][cont] = *jj;
						Conn[2][cont] = *kk;
						cont ++;
					}
				}
			}
			cont1=0;
		}

		if ( IS_CONSTRAINED_CONN == ON &&  type == 0 && algoFeatures != SWAP_CONN){
			actualConn =  setupDivHidden( varN->hidden ) - cont + numConnTmp; // actualConnHO - actualConnIH - actualConnIO;
			cont = limitConnection2Add(Conn, numConnTmp, cont, allowedConnHH, actualConn);
			numConnTmp = cont;
			//actualConnHH = cont - actualConnIO + actualConnHO + actualConnIH;

		}
		//imprime( Conn, 3,  cont);

		// Discover the available connections in OO
		cont0 = 0;
		cont1= 0;
		for(jj= &poshidden[varN->hidden]; cont0<varN->VnoOutputs -1 ; jj++){
			cont0++;
			for ( kk = &poshidden[varN->hidden]; cont1<varN->VnoOutputs; kk++){
				cont1++;
				if(*kk > *jj){
					if (  CW[*jj][*kk] == type){
						Conn[0][cont] = 4;						// indicate that this pattern is from OO
						Conn[1][cont] = *jj;
						Conn[2][cont] = *kk;
						cont ++;
					}
				}
			}
			cont1=0;
		}

		if ( IS_CONSTRAINED_CONN == ON &&  type == 0 && algoFeatures != SWAP_CONN){
			actualConn =  setupDivHidden( varN->VnoOutputs ) - cont + numConnTmp; //actualConnHO - actualConnIH - actualConnIO - actualConnHH;
			cont = limitConnection2Add(Conn, numConnTmp, cont, allowedConnOO, actualConn);
			//actualConnOO = cont - actualConnHH + actualConnIO + actualConnHO + actualConnIH;

		}
		//imprime( Conn, 3,  cont);

	} /// finish if it is a GMLP



	// Third part
	// conections from bias
	if (algoFeatures != SWAP_CONN){ 								// only take into account the bias if the algorithm is not swap connections
		cont0 = 0 ;
		for(jj=poshidden; cont0<sizepos[1]; jj++){ 			// The bias is taken into account
			if(bias[*jj] == type){
				Conn[0][cont] = 5;						// indicate that this pattern is from bias
				Conn[1][cont] = *jj;
				Conn[2][cont] = *jj;
				cont++;
			}
			cont0 ++;
		}
		//imprime( Conn, 3,  cont);
	}
	// set to NULL
	jj = NULL;
	kk = NULL;

	return ( cont ); 				// return the number of connections

}///////////////////////////////////////


int C_network::limitConnection2Add(int **Conn, int initCol, int numConn, int allowedConn, int actualConn){
/*!
 * Here it is taken a matrix with connections and the maximum values it should have, if it is bigger at random take the maximum allowed
 */

	// Method
	if ( ( (numConn - initCol ) + actualConn ) > allowedConn ){
		// rearrange the vector randomly
		//imprime(Conn,3,numConn);
		randomMat(Conn, 0, 3, initCol, numConn);
		//imprime(Conn,3,numConn);

		// the new counter is set to the maximum, the connection that remains in Conn are overwritten ahead or not considered
		while ( ( ( (numConn - initCol ) + actualConn ) > allowedConn )  && numConn > 0 )
			numConn --;

	} // if the connection to add plus the actual connections are smaller thant the allowedConn, do nothing and retunr the same number of connections

	return (numConn);
}///////////////

#endif
