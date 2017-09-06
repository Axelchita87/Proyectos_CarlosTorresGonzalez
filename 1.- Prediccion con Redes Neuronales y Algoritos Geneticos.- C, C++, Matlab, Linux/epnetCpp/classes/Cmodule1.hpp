/*!
 *  Cmodule1.hpp (Class module 1)
 *
 * This is the firat approximation to create modules for prediciton or classification tasks
 * using the arch and weight modularity of husken:
 * Husken, M., Igel, C., Toussaint, M.: Task-dependent evolution of
 * modularity in neural networks. Connection Science 14 (2002)
 *
 * This funtions are implemented after and based in the files: SmodularityHusken.m, modHusken.m
 * and all the funtions that they call
 *
 *
 *
 * Created: 			30 Sep 2010
 * Modified at:
 * Author: 			Carlos Torres and Victor Landassuri
 *
 */

#ifndef C_MODULE1_HPP
#define C_MODULE1_HPP



/*!
 * Functions / Methods for the class module1
 *
 */

// Constructor
C_module1::C_module1(){

	int maxNodesN = (totalMaxInput * filecol) + totalMaxHidden + noOutputs;
	int maxfinalInp = totalMaxInput * filecol;

	nameModule = NULL;
	nodesInModule = NULL;
	countNodesPerModule = NULL;


	nameModule = allocate(nameModule,maxNodesN);
	countNodesPerModule = allocate(countNodesPerModule, maxNodesN);
	nodesInModule = allocate(nodesInModule,maxNodesN,2);

	loadModule = NULL;
	loadModule = allocate(loadModule, NUM_MODULES);
	history = (C_matrixInt *) new C_matrixInt[NUM_MODULES]; 								// set the required pointers

	for (int i=0; i<NUM_MODULES; i++)
		history[i].setMat(2,1); 																					// in all modules, create a matrix of 2x1, to save only the required values

	// This is done only here !!!!!!!, of load a module, this will change
	// fill each matrix fo history indicating the task and module
	for (int i=0; i<NUM_MODULES; i++){
		history[i].m[0][0] = DSnumber; 				// put the data set this module belong
		history[i].m[1][0] = i+1;							// put the name of the module, if a module is loaded, and replace a module, this information wiill change
	}
	//for (int i=0; i<NUM_MODULES; i++)
	//	imprime(history[i].m, history[i].lines,history[i].cols);

	noModules = 0;
	noInp = 0;
	noHid = 0;
	noOut = 0;
	allnodes = 0;
	noIsolatedNodes = 0;

	CW = NULL;
	W = NULL;
	posinputs = NULL;
	poshidden = NULL;
	nodes = NULL;

	CW = allocate(CW,maxNodesN,maxNodesN);
	W = allocate(W,maxNodesN,maxNodesN);												// the same as above
	posinputs = allocate(posinputs, maxfinalInp);
	poshidden = allocate(poshidden, totalMaxHidden + noOutputs);
	nodes = allocate(nodes,maxNodesN);

	// for the dependency of each node to a module
	tdw = NULL;
	tda = NULL;
	tdw = allocate(tdw,maxNodesN,maxNodesN);
	tda = allocate(tda,maxNodesN,maxNodesN);

	// To measure the modularity
	MarchTD = 0;
	MweightTD = 0;

	// for module reuse
	nodesReusedPerMod = NULL;
	if (reuseModule == ON)
		nodesReusedPerMod = allocate(nodesReusedPerMod, maxNodesN);


} // End constructor



// Destructor
C_module1::~C_module1(){

	int maxNodesN = (totalMaxInput * filecol) + totalMaxHidden + noOutputs;

	if (reuseModule == ON)
		safefree(&nodesReusedPerMod);

	safefree(&tdw,maxNodesN);
	safefree(&tda,maxNodesN);

	safefree(&nodes);
	safefree(&poshidden);
	safefree(&posinputs);
	safefree(&W,maxNodesN);
	safefree(&CW,maxNodesN);


	safefree(&nameModule);
	safefree(&countNodesPerModule);
	safefree(&nodesInModule,maxNodesN);

	delete [] history;
	safefree(&loadModule);

} // End Destructor


void C_module1::copyClass(C_module1 *m2){

	int maxNodesN = (totalMaxInput * filecol) + totalMaxHidden + noOutputs;
	//int maxfinalInp = totalMaxInput * filecol;

	copy(nameModule, m2->nameModule,maxNodesN);
	copy(countNodesPerModule, m2->countNodesPerModule, maxNodesN);
	copy(nodesInModule, m2->nodesInModule,maxNodesN,2);

	copy(loadModule, m2->loadModule,NUM_MODULES );
	for (int i=0; i<NUM_MODULES; i++)
		history[i].copyClass(&m2->history[i]);

	noModules = m2->noModules;
	noIsolatedNodes = m2->noIsolatedNodes;

	// for the dependency of each node to a module
	copy(tdw, m2->tdw, maxNodesN, maxNodesN);
	copy(tda, tda, maxNodesN, maxNodesN);

	// To measure the modularity
	MarchTD = m2->MarchTD;
	MweightTD = m2->MweightTD;

	// module reuse
	if (reuseModule == ON)
		copy( nodesReusedPerMod, m2->nodesReusedPerMod, NUM_MODULES );

} // End method copyClass




void C_module1::save2file(FILE *fwrite, char file[]){

	fprintf(fwrite, "%d\t",noModules);
	saveInt(nameModule,noModules,fwrite,file);
	saveInt(nodesInModule,allnodes,2,fwrite,file); 			// note, when saved, it could be possible to print an extra column for modules
																										// because if there is a shared module or a module with a node that is not connected
																										// to any output, so do not put attention in that column(s) if there are negative modules (in name)

	//saveInt(loadModule,NUM_MODULES, fwrite, file);
	//for (int i=0; i<NUM_MODULES; i++)
	//	history[i].save2file(fwrite, file);


	saveD(tdw, allnodes,noModules,fwrite,file);
	saveD(tda, allnodes,noModules,fwrite,file);
	fprintf(fwrite, "%d\t",noIsolatedNodes);


	fprintf(fwrite, "%g\t",MweightTD);
	fprintf(fwrite, "%g\t",MarchTD);


	 // Module reuse
	if (reuseModule == ON)
		saveInt(nodesReusedPerMod, noModules, fwrite, file);


	 if((fprintf(fwrite, "%d\t",BAND)) == EOF){
	    	printf("(module1) Error writing to file '%s'...\n",file); exit(0);
	    }

} // End Method save2File




void C_module1::clean(void){
	/*!
	 * Put everything ot zero
	 * Except the loadModule nad history variables
	 * They are just overwriten when it is loadded a module
	 */
	int maxNodesN = (totalMaxInput * filecol) + totalMaxHidden + noOutputs;
	int maxfinalInp = totalMaxInput * filecol;

	set(nameModule,maxNodesN,0);
	set(countNodesPerModule, maxNodesN,0);
	set(nodesInModule,maxNodesN,2,0);

	//set(loadModule, NUM_MODULES,0 );
	//for (int i=0; i<NUM_MODULES; i++)
	//	history[i].clean();


	noModules = 0;
	noInp = 0;
	noHid = 0;
	noOut = 0;
	allnodes = 0;
	noIsolatedNodes = 0;

	set(CW,maxNodesN,maxNodesN,0);
	set(W,maxNodesN,maxNodesN, 0);
	set(posinputs, maxfinalInp, 0);
	set(poshidden, totalMaxHidden + noOutputs,0);
	set(nodes,maxNodesN,0);

	// for the dependency of each node toa module
	set(tdw,maxNodesN,maxNodesN, 0);
	set(tda,maxNodesN,maxNodesN, 0);

	// To measure the modularity
	MarchTD = 0;
	MweightTD = 0;


	// module reuse
	if (reuseModule == ON)
		set( nodesReusedPerMod, NUM_MODULES, 0 );


} // End method clean





void C_module1::isThereModulesHuskenTopDown(void){ //C_network *n){
	/*!
	 * This function find how many modules there are, which nodes belong to each module
	 * and calculate the modularity of husken: arch and weight
	 *
	 * All the information it is saved in the same class
	 * Every time the function is called is overwrited all the class, because it could change inputs, hidden, output and modules
	 * after mutations
	 */



	int i;
	int initNode = 0;

	// Determinate if the network has one or more outputs (as prediction or classification)
	// As it is the top down, first it is needed to find which outputs belong to each module
	if( NUM_MODULES > 1) 			// in the past was noOut > 1											// bound each output to a module
		findMod(); 																														// net with many outputs
	else{
		findLastHidden4mod(); //CW, poshidden); 																// net with one output  *** not programmed jet ****
		if (noModules > 1)
			modifyNet();
	}
	// After it has been found which output belong to each module, it can be calulated the modularity
	// until here it is know hoe many modules are, their names and the bounding of the outputsnodes to each module

	double MAX;
	int POS;
	int contAddMod = 0;

	//imprime(CW,noInp+noHid+noOut, noInp+noHid+noOut);

	if (noModules > 1){
		MweightTD = modHusken("top-down", "weight");
		MarchTD = modHusken("top-down", "arch");
		if (flagDebug == ON){ 		cout << endl << "Mweight = " << MweightTD << endl;  		cout << endl << "March     = " << MarchTD << endl; }

		 // Determinate to which module each node belong give the dependency d for the weighted case, here it is not used the arch case because it is not possible to
		// say in some cases to which module the node belong

		if ( considerInputsInMod == ON )
			initNode = 0;
		else
			initNode = noInp;

		for (i = initNode; i<noInp+noHid; i++){ 								// not count outputs, here is assumed that I am running the top down version
			if (nodes[i] != 0 ){
				maxAndPosVec(tdw[i], noModules, &MAX, &POS);
				nodesInModule[i][1] = POS+1; 											// all modules start in 1-n
			}
			else {
		            nodesInModule[i][1] = -2;     // They are nodes not connected to anything or disabled, so they are out in another module
		                                        // if fall an input here, the module is deleted ahead because inputs are not considered to plot in
		                                        // modules, bu is leave here because ahead the inputs could be plotted inside the box of the module (just for the matlab code this)
		            contAddMod = 1;
			}
		}

		if ( contAddMod == 1 ){                 // update number of module and their name
			noModules++;
			nameModule[noModules-1] = -2;
		}



	}
	else{ 											// if there is just one module (it does not matter if inputs are used or not in the modularity)
		noModules = 1;
		nameModule[0] = 1;
		for (i = 0; i< allnodes-1; i++)					// put all nodes in module 1
			nodesInModule[i][1] = 1;
		//nodesInModule[allnodes-1][allnodes-1] = 0;				// just in case put them in 0 I do not know the effect, check it later

		MweightTD = 0;
		MarchTD = 0;
	}

	// count the nodes per module, it is assumed tha tit is used the weight dependency to determinate the nodesInModule
	howManyNodesPerModule();

	// count the reused nodes per module
	//cout << "tdw" << endl;  imprime(tdw,noInp+noHid+noOut, noModules);
	//cout << "CW" << endl; imprime(CW, noInp+noHid+noOut, noInp+noHid+noOut);
	if (reuseModule == ON)
		howManyReusedNodesPerMod();

} // End method isThereModulesHuskenTopDown




void C_module1::isThereSharedModule(void){ //C_network *n){
	/*!
		 * This function find how many modules there are, which nodes belong to each module
		 * taking into acocunt shared modules. i.e. if one neuron is connected directly or indirectly to more than one output
		 * then it is considered in the shared
		 *
		 * It is used the modularity of husken, i.e. d to determinate the dependency of each neuron to each module
		 * From there if the node is not pure then is put in the shared module
		 *
		 * All the information it is saved in the same class
		 * Every time the function is called is overwrited all the class, because it could change inputs, hidden, output and modules
		 * after mutations
		 */

		int i;
		int contShared = 0;
		int initNode = 0;
		int contModulesWhile = 0;
		// Determinate if the network has one or more outputs (as prediction or classification)
		// As it is the top down, first it is needed to find which outputs belong to each module
		if( noOut > 1) 																							// bound each output to a module
			findMod(); 																														// net with many outputs
		else{
			findLastHidden4mod(); //CW, poshidden); 																// net with one output  *** not programmed jet ****
			if (noModules > 0)
				modifyNet();
		}
		// After it has been found which output belong to each module, it can be calulated the modularity
		// until here it is known how many modules are, their names and the bounding of the outputsnodes to each module

		double MAX;
		int POS;

		//imprime(CW,noInp+noHid+noOut, noInp+noHid+noOut);

		// top-down arch, this can say if one neuron only contribute to one output
		MarchTD = modHusken("top-down", "arch"); //, CW, W, posinputs, poshidden);

		if ( considerInputsInMod == ON )
			initNode = 0;
		else
			initNode = noInp;


		// Final step, decide if it is a pure neuron or not. Here it does not matter if there is deactivated neurons, they fall in the shared case
		for (i = initNode; i<noInp+noHid; i++){ 								// not count outputs, here is assumed that I am running the top down version
			maxAndPosVec(tda[i], noModules, &MAX, &POS);
			if (MAX == 1)
				nodesInModule[i][1] = POS+1; 											// all modules start in 1-n
			else if (MAX > 0){																	// if MAX == 0 it is an isolated node
				nodesInModule[i][1] = -1;     // mark to say that is in the shared module
				contShared = 1;
			}
		}
		// The shared Module are allways in the last position of the vectors (nameModule, ...)
		if ( contShared == 1 ){                 // update number of module and their name
			noModules++;
			nameModule[noModules-1] = -1;
		}


		// Check that a module is not empty, if that is the case the module is deleted
		int contR = 0;
		int *toRemove = NULL;
		toRemove = allocate(toRemove,noModules);
		int flag = 1;

		for ( i=0; i<noModules; i++){										// count all modules
			flag = 1;
			for ( int j=initNode; j< noInp+noHid; j++){								// count all nodes or only the hidden
				if ( nameModule[i] == nodesInModule[j][1] ){ 		// if at least there is one node belonging to this module
					flag = 0;
					break;
				}
			}
			// save modules to be removed
			if (flag){
				toRemove[contR] = i;
				nameModule[i] = 0; 													// mark it to be removed
				contR++;
			}
		}

		// delete the modules that does not have any nodes, compact the vector, the positions in zero are copied with the next element
		if (contR != 0){
			contModulesWhile = 0;
			i = 0;
			while (contModulesWhile < noModules) {
				if (nameModule[i] == 0){
					for (int k = i; k< noModules-1; k++){ 					// move all the next positions one behinde
						nameModule[k] = nameModule[k+1];
					}
					i--; 				// decrement i to start in the same position because it is possible that the next elemnet was zero too
				}
				contModulesWhile ++;
				i ++;
			}

			// check the last position (Not sure why I do this here, delete this)
			//if (nameModule[noModules-1] == 0)
			//	nameModule[noModules-1] = 0;

			// update the final number of modules
			noModules -= contR;

		}

		// check how many nodes there are in each module
		howManyNodesPerModule();

			// liberate memory
			safefree(&toRemove);

} // End method isThereSharedModule








void C_module1::findMod(void){
/*!
 * This function bound the outputs with a module
 * If the task is the what and where, it is performed a different fucntion, that could be increased in case other data set are similar
 * Another data set is class 0024, two inputs, 5 outputs for 5 classes divided into two tasks
 *
 * Here is set up the nameModules and noModules variables
 * It is set up the first part of nodesInModule (just the outputs)
 * This fucntion takes values from global variables
 * NOTE: this function is similar to obtainModuleInfo called from main, if you modify that, check that this does not change
 */

	// Local variables
	//int maxNodesN = (totalMaxInput * filecol) + totalMaxHidden + noOutputs;
	int cont = 0;

	// Check special conditions for data set as the what and where, where a set of outputs belong to the same module
	if( 1) { /*strcmp( NAMETS.c_str(), "WhatAndWhere" ) == 0   || strcmp( NAMETS.c_str(), "0024" ) == 0 ||
			strcmp( NAMETS.c_str(), "0021a" ) == 0 ||
			strcmp( NAMETS.c_str(), "0021a1" ) == 0 ||
				strcmp( NAMETS.c_str(), "0023a" ) == 0
				|| strcmp( NAMETS.c_str(), "0024a" ) == 0
				|| strcmp( NAMETS.c_str(), "0031a")
						|| strcmp( NAMETS.c_str(), "0033a")
						|| strcmp( NAMETS.c_str(), "0034a") ){ 						// if it is the what and where data set        .............. For the moment always enter here becasue I configure this values outside*/

		noModules = NUM_MODULES; // noModules = loadVecInt("txtFiles/nameModules.txt", nameModule);
		copy(nameModule, NAME_MODULE, noModules);

		// bound each output to its module
		cont = 0;
		for(int i = noInp+noHid; i<noInp+noHid+noOut; i++  ){
			nodesInModule[i][1] = OUT_IN_MOD[cont];
			cont++;
		}
	}
	else{																								// any other  TS or data set
		// Default option, each output is bounded to a module
		// Thus, it is assumed that there is as much modules as outputs
		// decide later how to manage for example breast cancer, all output are bounded to a module, and then it is used findLastHidden4mod() like if were a prediction tasks (That sound logic)
		// study what emerge in both cases // however each output looks like a module, then maybe it could not have too much sence apply findLastHidden4mod()
		cont = 0;
		for(int i = noInp+noHid; i<noInp+noHid+noOut; i++  ){
			nodesInModule[i][1] = cont + 1; 											// all modules start in 1
			nameModule[cont] = cont + 1;
			cont++;
		}
		noModules = cont;

	}


} //End method findMod



void C_module1::findLastHidden4mod(void){ //int ** CW,  int *poshidden){
	/*!
	 * Funtion to find the potinetial hidden nodes that could create a module
	 * Here is only considered the hidden nodes
	 * To rule to determinate this, is if the nodes is connected only to the output (there is just one output)
	 * If the node is connected to another node, then it is considered that this node is inside of a module and
	 * thus, it can not be considered as the last node to create a module
	 *
	 * Inputs
	 *   nodesInMod      Iinitial empty list in column 2 that says which node belong to a given module.
	 *   hidden          		vector with the hidden nodes
	 *	 CW              		Connectivity matrix
	 *  allnodes        		number of all nodes in the network.
	 *
	 * Outputs
	 *   noMod           number of modules that will be created.
	 *    nameM           name of the moduels, each possition has the name of each one, in principle they will start in 1 to n, so
	 * 			                   the possition 1 has the name 1, nameM(1,2) = 2, ...
	 *    nodesInMod      Updated list with the final nodes that are bounded to a module. The list is sorted, so the first node found
	 * 				                   that create a module is assosiated witht he first module and so on
	 */

	// local var
	int *i;
	int cont = 0;
	int conti = 0;
	int SUM = 0;
	// here is only taken into account the hidden nodes
	// Find the last(s) nodes that can be bound to a module
	for ( i = poshidden; conti < noHid; i++      ){
		SUM = 0; 														// sum to check that this node is only connected to the output

	    if (CW[*i][allnodes-1] == 1 ){							// only cares about output connections from the actual node (columns)
	    	SUM = SUMvec( &CW[*i][*i+1], allnodes - 2 - *i); // old line SUM = SUMvec( &CW[*i][*i+1], allnodes - 1  - *i );

	        if ( SUM == 0 ){											// new module
	            cont++;
	            nodesInModule[*i][1] = cont;
	            nameModule[cont -1] = cont;
	        }
	    }
	    conti++;
	}
	noModules = cont;

	i = NULL;
} //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


double C_module1::modHusken(string a, string b){ //, int **CW, double **W, int *posinputs, int *poshidden){
	/*!
	 * Calulate the modularity as husken:
	 * Husken, M., Igel, C., Toussaint, M.: Task-dependent evolution of
	 * modularity in neural networks. Connection Science 14 (2002)
	 *
	 * Input:
	 * 		a 					To determinate if it is top-down or normal, 		in this moment the normal is not programmed
	 * 		b 					To determinate if it is weighted or arch modularity
	 * 		CW 				The connctivity matrix
	 * 		W					The weights matrix, this is only used in the case that it is calculated the weighted modularity
	 * 		posinputs 	Tthe inputs of the network
	 * 		poshidden 	The hidden and outputs nodes
	 * Inputs taken from the class
	 * 		nameModule			It is assumed that they have been already set up,
	 * 		noModule  				the name as the number of modules in previous funtions
	 *
	 * Outputs:
	 * 		modularity 	The calculated modularity, returned as a normal value
	 * 		d 					The dependency matrix of each node to each module
	 */

	// Local variables
	double **tmpW = NULL; 															// temp matrix to hold the weights or the connectivity matrix
	double **d = NULL;
	double **dp = NULL; 																// values d'(j)
	double modularity = 0;
	double *Sigma2 = NULL;

	// var for the normal or top-down version
	int *vecTmp;
	int *vec2Tmp;
	int *vec3Tmp = NULL;
	vec3Tmp = allocate(vec3Tmp,noInp +noHid);
	int N = 0; 																						// to hold the number of nodes to count to measure the modularity
	int tamVec = 0;
	int tamVec2 = 0;

	int *i = NULL;

	// Allocate some var
	tmpW = allocate(tmpW, allnodes,allnodes);
	dp = allocate(dp,allnodes,noModules);
	Sigma2 = allocate(Sigma2,allnodes);

	// Check if it was asked for the weighted or ach modularity
	if ( strcmp( b.c_str(), "weight") == 0 ){
		copy(tmpW,W, allnodes, allnodes);
		d = tdw; 																						// init the pointer to point to tdw
	}
	else if ( strcmp( b.c_str(), "arch") == 0 ){
		convertInt2DoubleMat(tmpW, CW, allnodes, allnodes);
		d = tda;
	}

	// be sure that d is in zeros, only the nodes used
	set(d,allnodes,noModules,0);

	// m-tuple (di(1), ..., di(m)) assigned to each neuron i.
	// d is the degree of dependency of the neuron on the m different modules

	// First set up other variables


	// Is it the normal or the top-down modularity
	if ( strcmp( a.c_str(), "normal" ) == 0 ){ 						// normal modularity not tested *************
		vecTmp = posinputs;
		vec2Tmp = poshidden; 												// hidden and output nodes
		tamVec = noInp;
		tamVec2 = noHid+noOut;
		N = noHid + noOut;
	}
	else if ( strcmp( a.c_str(), "top-down" ) == 0 ){
		vecTmp = &poshidden[noHid]; 									// point to the outputs only

		// count inputs or not
		if ( considerInputsInMod == ON ){
			concatenateVecInverse(posinputs,noInp,poshidden,noHid, vec3Tmp);
			tamVec2 = noInp+noHid;
			N = noInp + noHid;
		}
		else{
			inverseVec(poshidden,noHid, vec3Tmp);
			tamVec2 = noHid;
			N = noHid;
		}

		vec2Tmp = vec3Tmp;
		tamVec = noOut;

	}


	// Inputs or outputs, take into account at which set they belong
	// Set up the first values of d for inputs or outputs
	// Check if the data set is the what and where or is a normal data set
	int contVec = 0;
	int contM = 0;

	// Previously it has ben loadad which output belong to each module, if not, then it is like a prediciton tasks, and then it is expected that each output is a module
	for ( i = vecTmp; contVec < tamVec; i++){
		contM = 0;
		for (int *mod = nameModule; contM <  noModules; mod++){
			if ( nodesInModule[*i][1] == *mod )
				d[*i][contM] = 1;
	        else
	            d[*i][contM] = 0;
	        contM++;
	    }
	    contVec++;
	}

	// It is declared as the same as d to save the temporal values of d'(j)
	copy(dp,d, allnodes, noModules);


	// Calculate dependency of neurons (Hidden and output or input and hidden) for each module
	contVec = 0;
	double sumK;
	double div;
	int j;
	int k;

	for ( i = vec2Tmp; contVec < tamVec2; i++){
		//summ = SUMvec( CW[*i], allnodes );
		if (  nodes[*i] == 1 &&  ( SUMvec( CW[*i], allnodes ) > 0  ) ){  																					// check that the node is present and it connect to other
			// calculate d'(j)
			for ( j = 0; j< noModules; j++){
				sumK = 0;
				if ( strcmp(a.c_str(), "normal") == 0 ){
					for ( k = 0; k< *i-1; k++){ 													// check all previous nodes, to see if there are conenctions to it
						if(nodes[k] == 1 && CW[k][*i] == 1)
							sumK += fabs(tmpW[k][*i]) * d[k][j];
	                }
	            }
	            else if ( strcmp(a.c_str(), "top-down") == 0 ){
	                for (k = *i+1; k < allnodes; k++){										// check all the next nodes, to see if there are conenctions to it
	                    if(nodes[k] == 1 && CW[*i][k] == 1)
	                    	sumK += fabs(tmpW[*i][k]) * d[k][j];
	                }
	            }
	            dp[*i][j] = sumK;
	        }
	        // calculate d(j)

	        sumK = SUMvec(dp[*i], noModules);
	        if (sumK != 0){
	        	for (j = 0; j< noModules; j++) 														// not check divisoin by zero, if error maybe it could be here chck just in case in the future
	        		d[*i][j] = dp[*i][j] / sumK;
	        }

	    }
	    else{
	        nodes[*i] = 0;         // desactivate the node because it does not connect to an outputs so it is useless and can cause error if it is taken into account
	        N--;               			// Rest the nodes that does not count

	    }
		contVec++;
	}                                 //finish all hidden and output nodes or inputs and hidden



	// Cuantify the degree of pureness of each neuron i by means of the variance
	sumK = 0;
	div = (double) 1/noModules;   																						/// I need to cast because it seems that C take noModuels and 1 as int, thus return an int
	for (int ii = 0; ii < allnodes; ii++){
	    if ( nodes[ii] == 1 ){
	    	sumK = 0;
	    	for (j = 0; j< noModules; j++)
	    		sumK += ( d[ii][j] - div  ) * ( d[ii][j] - div );

	        Sigma2[ii] = sumK / noModules;
	    }
	}

	// calculate the required modularity, taking into account the correc neurons
	double x,y;
	int node2count = 0;

	if (N > 0)		x = (double) 1/N;

	if ( considerInputsInMod == ON )
		node2count = noInp+noHid;
	else
		node2count = noHid;	// not count inputs, so the connection of inputs are not deleted

	if ( strcmp(a.c_str(), "normal") == 0)
		y = SUMvec(&Sigma2[noInp], noHid+noOut); 						// not tested // upate if used for the case in wich the inputs are not used
	 else if ( strcmp( a.c_str(), "top-down") == 0){
		 if  ( considerInputsInMod == ON )
			 y = SUMvec(Sigma2, node2count);
		 else
			 y = SUMvec(&Sigma2[noInp], node2count); 							// here is passed Sigma2 where the hidden nodes start as the inputs are not considered
	 }																											// with this it must be avoided that the modularity gets bigger than 1


	if ( ( noModules > 1)  &&  ( x > 0 )  &&  ( y > 0 ) )
		modularity =  (  (double) ( noModules * noModules )  /  (noModules - 1) )  *  x * y;
	else
		modularity = 0;

	/*
	 *  there are bugs that case that the networks gives a bigger modularity,
	 like the case in which an input is connected to an isolate node, from
	 there the node is detected to be connected with someting else ahead, but
	 not directly to an output, so sumK gis a value of 0.25, and then at the
	 end the modularity is encreased
	 */
	if (modularity > 1)
		modularity = 1.0;



	// free memory
	safefree(&vec3Tmp);
	safefree(&dp,allnodes);
	safefree(&Sigma2);
	//tmpW = NULL;
	safefree(&tmpW,allnodes);
	i = NULL;

	return (modularity);
}////////////////////////////////////////////////////////////////////////


void C_module1::setup(C_network *n){
	/*!
	 * Method to set up the first variables from the class
	 * Except the indormatin for the data set and the module for the case to save modules (history and loadModules)
	 *
	 */
	// obtain information from the net to not modify the parameters of net
	allnodes = n->varN->finalInp + n->varN->hidden + n->varN->VnoOutputs;

		noInp = n->varN->finalInp;
		noHid = n->varN->hidden;
		noOut = n->varN->VnoOutputs;
		copy(posinputs,n->posinputs,noInp);
		copy(poshidden, n->poshidden, noHid+noOut);
		copy(CW,n->CW, allnodes, allnodes);
		copy(W,n->W, allnodes, allnodes);

		int i;

		// mantain a local copy of nodes, i.e. which node is active or not
		copy(nodes, n->nodes, allnodes);


		// set up the first column of nodesInModule
		for( i = 0; i<allnodes; i++)
			nodesInModule[i][0] = i; 					// the nodes strat in zero


		if (reuseModule == ON)
			set(nodesReusedPerMod, NUM_MODULES,0);


}////////////////////////////////////////////////////////////////////////


void C_module1::howManyNodesPerModule(void){

	int initNode = 0;

	if ( considerInputsInMod == ON )
		initNode = 0;
	else
		initNode = noInp;

	for ( int i=0; i<noModules; i++){										// count all modules
		for ( int j=initNode; j< noInp+noHid; j++){								// count inputs and hidden nodes or just hidden nodes
			if ( nameModule[i] == nodesInModule[j][1] ){ 		// if at least there is one node belonging to this module
				countNodesPerModule[i]++;
			}
		}
	}
} /////////////////////////////////////////////////////////////////////////////////////////////


void C_module1::howManyReusedNodesPerMod(void){
	/*
	 * Count how many nodes are reued por module
	 * By defaul it is used the Mweight modularity and the inputs are not taken into account, nor the output becasue they do not figure i nthe dependency
	 */

	int initNode = 0;

	//if ( considerInputsInMod == ON )
	//	initNode = 0;
	//else
		initNode = noInp;


	for ( int j=initNode; j< noInp+noHid+noOut; j++){								// count inputs and hidden nodes or just hidden nodes
		for ( int i=0; i<noModules; i++){										// count all modules
			if ( nameModule[i] != nodesInModule[j][1] ){ 		// if is a node from another module (for which we are interested)
				// if node j does not belong to this module, check if it connects directly or indirectly to module i using the dependency tdw
				if (tdw[j][i] > 0)
					nodesReusedPerMod[i]++;
			}
		}
	}
} /////////////////////////////////////////////////////////////////////////////////////////////




void C_module1::modifyNet(void){
	/*!
	 * Function to modigy a network with one output to allow the calculation of the modularity
	 * as husken
	 *
	 * In the original version of matlab it was programmed two variations:
	 * A) the weights form the hidden nodes that connect the output node matters,
	 * B) those connecitons does not matter
	 * In this implementation I will use the apporach in which it does not matter the weights.
	 *
	 * If the weights matter the modularity in increased, becuase the hidden node is connected with a new virtual output and then used that weight to measure the modularity
	 * For that reaosn it is increase the modularity.
	 */

	// Code for the case in which the last weights does not matter
	if ( noHid > 1 ){
		int *i = NULL;
		int ii, j;


		int *outputs = NULL;
		int contHid = 0;
		int contOut = 0;
		int *toRemove = NULL;

		int allNodess = noInp+noHid+noOut;

		outputs = allocate(outputs,allNodess); 		// I could not exced this value
		toRemove = allocate(toRemove, allNodess);

		// clear the outputs
		noOut = 0;

		// update hidden nodes, just will move the index to the correspondient vector


		// the nodes to remove from the hidden are the same as the new inputs
		// Becasue the matrix will not grow in size, after it has been found an output, this is copy at the end and then all the nodes after the one deleted
		// are copied one position back
		for (i = poshidden; contHid < noHid; i++){
			// check if this node is member of a module
			for ( int j=0; j< noModules; j++){
				if ( nameModule[j] == nodesInModule[*i][1] ){
					outputs[contOut] = *i;
					toRemove[contOut] = contHid; 				// index to remove
					contOut++;
					break; 													// cause the node only colud belong to one module, so there is no need to test the others
				}
			}
			contHid++;
		}



		 /*!
		  * Note, If the last hidden node is not the last output, it means thar
		  * there are more hidden nodes between the last output and the output
		  * that has been omitted, those nodes need to be deleted, if not they
		  * cause an index error in the modularity calculation as more nodes are
		  * thought to be in a matrix smaller
		  */
		// CHECK THAT THIS WORK RUNNING, IN THE FIRST ATTEMP IT WORKS, IF ERRO REFER HERE....., it runs ok after this modification
		//cout << "inputs: " << endl; imprime(posinputs,noInp);
		//cout << "hidden nodes: " << endl; imprime(poshidden,noHid);

		int tmp2Remove = contOut;
		if ( poshidden[ toRemove[ contOut-1] ]  < poshidden[ noHid-1] ){
			for (ii = toRemove[contOut-1] +1 ; ii < noHid; ii++){ 					// move over the indexes
				//use the same conture to put more positions  not that here it has been updated  noOutputs
				toRemove[tmp2Remove] = ii;
				tmp2Remove += 1;
			}
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



		// remove elements from hidden nodes and copy the outputs at the end 		// The first elements in toRemove are ordered from low index nodes to higer, so we can start in the same order to move them to the end
		contHid = 0;
		for ( ii = 0; ii < noHid ; ii++){ // there is a bug here, if the last new output is not the last hidden nodes, however, ahead it is removed the bad copies performed, so at the end it seems that it works
			if ( ii == toRemove[contHid] ){
				// copy all one position back until the end of the vector
				for (  j = ii; j<noHid-1; j++)
					poshidden[j] = poshidden[j+1];
				ii--;
				contHid++;
				// the indexes to remove has move one position back, so it is needed to rest one position to all of them
				for ( j = contHid; j<contOut; j++ )
					toRemove[j] --;
			}

			// check if I have used all the nodes required, if that I can exit
			if (contHid >= noHid)
				break;

		}

		noOut = contOut;
		noHid -= tmp2Remove;

		// copy the outputs at the end of pos hidden
		contOut = 0;
		for ( ii = noHid; ii < noHid+noOut; ii++){
			poshidden[ii] = outputs[contOut];
			contOut++;
		}


		// liberate mem
		safefree(&toRemove);
		safefree(&outputs);
	} // if there is more that one hidden node

}


void C_module1::isolatedNodes(void){
	/*! Function to calculate how many isolated nodes form inputs and outputs there are
	 *
	 * The result is saved in variable:::::: noIsolatedNodes
	 *
	 * Created around    17 Nov 2010
	 * Modified at:
	 * Author:           Carlos Torres and Victor Landassuri
	 *
	 */

	// local var
	int **nodesInMod2 = NULL; 				// temp var to save the isolated nodes from inputs
	int i;

	// allocate var
	nodesInMod2 = copyAlloc(nodesInMod2,nodesInModule, allnodes,2);

	// If there are just one module I need another method to determinate isolated nodes from outputs
	if (noModules == 1)
		 isConnected2Output(); 						// fill nodes in mode with another recursive method

	for (i = 0; i< noInp+noHid; i++){
		if ( nodesInModule[i][1] == -2 )
			noIsolatedNodes++;
}


	// Check that the hidden nodes and outputs are connected directly or indirectly to an input
	// this is the other case that complement the above case

	isConnected2Input(nodesInMod2);

	// Check all hidden and output ot see if they are not isolated from inputs
	for(i = noInp; i< noInp+noHid+noOut; i++){
		if( nodesInMod2[i][1] == -2)
			noIsolatedNodes++;
	}

	// Liberate memory form the funtion
	safefree(&nodesInMod2, allnodes);

}


void C_module1::isConnected2Output(void){
	/*! Function to see if a node is connected directly or indirectly to an output
	 *
	 * recursive funtion to determinate which node belongs to
	 * each module with my metric (only a path from one node to only one output)
	 * returns the number of connections to output nodes
	 * and the last output node found (connected)
	 *
	 * it is saved in nosInModule if they are isolated
	 *
	 * It can be used too, to determinate if the node is isolated, i.e. not
	 * connected to any output, in that case it is returned zero in num variable
	 *
	 * This function is baces in the matlab function with the same name
	 * Different to the matlab code, here is used Mweight to determinate if the node boleng to one or other module. or if it is isolated
	 *
	 * Created:     17 Nov 2010
	 * Modified:
	 * Author:       Carlos Torres and Victor Landassuri
	 */

	// Local variables
	int *vec = NULL;
	int *i,*j;
	int conti, contj;
	int noOutputConn = 0;  // here is saved the number of connections to output nodes
	//int *connectTo = NULL; 		// here is saved to wich output is connected, if there are many I think it is the last one returned or the first one, no hay pierde una de esas dos, para el caso no importa

	// allocate space for pointers
	vec = allocate(vec,allnodes);					// Put all nodes in size, su I am sure there is enogh space


	// Main function that call another recursive

	// concatenate inputs and hidden nodes in one vector

	concatenateVecInverse(posinputs, noInp, poshidden, noHid, vec);



	// code to avoid infinit recursion in case the output node does not have any input
    int cont = 0;
    conti = 0;
    contj = 0;
    // imprime(CW, allnodes, allnodes );

    for (i = vec; conti < noInp+noHid; i++){
    	//if (*i >= 0 ){
    	contj = 0;
    	 for (j = &poshidden[noHid]; contj < noOut; j++){
            if ( CW[*i][*j] == 1)
                cont ++;
            contj++;
    	 }
    	//}
    	 conti++;
    }

    if (cont > 0){
	conti = 0;
	    for (i = vec; conti < noInp+noHid; i++){


	        // Call recursive function to know if this node have a path to an output node
	    	noOutputConn = isConnected2OutputRec(*i);

	        if( noOutputConn == 1){	                            // if only is conencted to an output
	        	nodesInModule[*i][0] = *i; 							// I do not know whay I fill again the forst position, but it is used ful if the nodesInMode is empty
	        	nodesInModule[*i][1] =  0; 						// here zero will menas that it is conencted to something
	        }
	        else if ( noOutputConn > 1){                        // if conencted to more than one, shared node
	        	nodesInModule[*i][0] = *i;
	        	nodesInModule[*i][1] =  -1;
	        }
	        else if ( noOutputConn == 0 ){                            // isolate node from here to outputs
	        	nodesInModule[*i][0] = *i;
	        	nodesInModule[*i][1] =  -2;
	        }

	        conti++; 				// counter to stop the for
	    }
    }
    else{
    	// Put all to isolated nodes
    	 for (i = vec; conti < noInp+noHid; i++){
    		 nodesInModule[*i][0] = *i;
    		 nodesInModule[*i][1] =  -2;
    		 conti++; 				// counter to stop the for
    	 }


    }

	// liberate mem
	free(vec);

}

void C_module1::isConnected2Input(int **nodesInMod2){
/*!
 * Recursive function to see if a node is connected directly or indirectly to an input
 *
 * Recursive funtion to determinate which node belongs to an input this is
 * the complement to the funtion isConnected2Output
 *
 * This function only works to say if the nodes is isolated, because it
 * finish in the fisrt input is connected, improve it if you want to know
 * how many connectios there are to inputs fron the actual node
 *
 * It can be used too, to determinate if the node is isolated, i.e. not
 * connected to any inputs, in that case it is returned 0 in num variable
 *
 * Created around    18 Nov 2010
 * Modified at:
 * Author:           Carlos Torres and Victor Landassuri
 *
 */

	// Local variables
	int *i;
	int conti;
	int noOutputConn = 0;  // here is saved the number of connections to input nodes
	//int *connectTo = NULL; 		// here is saved to wich output is connected, if there are many I think it is the last one returned or the first one, no hay pierde una de esas dos, para el caso no importa

	// Main function that call another recursive

	// concatenate hidden and outputs nodes in one vector

	conti = 0;
	for (i = poshidden; conti < noHid+noOut; i++){

		// Call recursive function to know if this node have a path to an output node
		noOutputConn = isConnected2InputRec(*i);

		if( noOutputConn == 1){	                            // if only is conencted to an output
			nodesInMod2[*i][0] = *i; 							// I do not know whay I fill again the forst position, but it is used ful if the nodesInMode is empty
			nodesInMod2[*i][1] =  0; 						// here zero will menas that it is conencted to something
		}
		else if ( noOutputConn > 1){                        // if conencted to more than one, shared node
			nodesInMod2[*i][0] = *i;
			nodesInMod2[*i][1] =  -1;
		}
		else if ( noOutputConn == 0 ){                            // isolate node from here to outputs
			nodesInMod2[*i][0] = *i;
			nodesInMod2[*i][1] =  -2;
		}

		conti++; 				// counter to stop the for
	}
}


int C_module1::isConnected2OutputRec(int node){
/*!
 * Recirsive function to look for a path from one node to the output
 *
 * Inputs:
 * 			node 		is the actual node to analyse and to see if it has a connection to an output or other nodes ahed of it
 *
 *
 * Note that the matlab function retunr the number of conenction and the node that it is connected, but here I did not spend time how to return two values that are not pointers
 *  becasue it is a recursive function, so just one is returned
 *
 * Outputs:
 * 			num it is returned the number of conenctions found to output nodes
 *
 * Created around    18 Nov 2010
 * Modified at:
 * Author:           Carlos Torres and Victor Landassuri
 *
 */

	// Local variables
	int Num = 0;
	int numTmp = 0;
	int *i = NULL;
	int ii;
	int conti = 0;
	//int *p = NULL; 					// pointer to look index in poshidden

	// display the actual nodes, for debigging
	//cout << "node = " << node << endl;

	// Take the actual node and test if it is directly connecto to the output(s)
	for (i = &poshidden[noHid]; conti < noOut; i++){ 							// poshidden[noHid] is the first output
	    if (CW[node][*i] == 1)
	        Num++;
	    conti++;
	}

	if (Num > 1)       // from the beginning, if it is connected to more that one output, mark it as shared neuron
	    return (Num);
	else{
	    // Test other nodes where there is aconnection from this to them, only hidden nodes
		conti = 0;
	    for(ii = node+1; ii < noInp+noHid; ii++){
	        if ( CW[node][ii] == 1 ){
	            numTmp = isConnected2OutputRec(ii);
	            Num = Num + numTmp;
	        }
	        if (Num > 1)
	            break;
	     }
	}

	return (Num);
}


int C_module1::isConnected2InputRec(int node){
/*!
 * Recirsive function to look for a path from one node to the inputs
 *
 * Inputs:
 * 			node 		is the actual node to analyse and to see if it has a connection to an input or other nodes before it that conenc to an input
 *
 *
 *
 * Outputs:
 * 			num it is returned the number of conenctions found to inputs nodes
 *
 * Created around    18 Nov 2010
 * Modified at:
 * Author:           Carlos Torres and Victor Landassuri
 *
 */

	// Local variables
	int Num = 0;
	int numTmp = 0;
	int *i = NULL;
	int ii;
	int conti = 0;
	//int *p = NULL; 					// pointer to look index in poshidden

	// display the actual nodes, for debigging
	//cout << "node = " << node << endl;

	// Take the actual node and test if it is directly connecto to the output(s)
	for (i = posinputs; conti < noInp; i++){ 							// poshidden[noHid] is the first output
	    if (CW[*i][node] == 1)
	        Num++;
	    conti++;
	}

	if (Num > 1)       // from the beginning, if it is connected to more that one output, mark it as shared neuron
	    return (Num);
	else{
	    // Test other nodes where there is aconnection from them to this, only hidden nodes
		conti = 0;
	    for(ii = poshidden[0]; ii < node; ii++){
	        if ( CW[ii][node] == 1 ){
	            numTmp = isConnected2InputRec(ii);
	            Num = Num + numTmp;
	        }
	        if (Num > 1)
	            break;
	     }
	}

	return (Num);
}


#endif
