/*!
 * connInit.hpp
 *
 * Continuation of the methods from the network class.
 * Especifically here are all the methos for the connection initializetion in the GML (connection scheme)
 *
 * Note that the matlab code has more method, but here are only implemented the mos representative to develop the exps
 *
 * Created: 	20 Nov 25010
 * Modified:
 * Author: 	Carlos Torres and Victor Landassuri
 *
 */

#ifndef CONNINIT_HPP
#define CONNINIT_HPP



void C_network::initNet(void){
	/*!
	 * Initialize the network with the internal variable of it ( varN-> )
	 * Variables initialized
	 * 	Inputs
	 * Hidden
	 * Connections 	Not here but is called another method
	 *
	 * Created:      somewhen in 2008
	 * Modified at:
	 * Author:       Carlos Torres and Victor Landassuri
	 */


	register int j,cont,cont1;
	int allnodes = varN->finalInp + varN->hidden + varN->VnoOutputs;
	cont = 1;
	cont1 = 0;


	// Initialize the Inputs and nodes//////////////////
	if(algoFeatures != ASYMMETRIC){
		for(j=0; j<varN->finalInp; j++){				//activate all the inputs
			posinputs[j] = j;
			nodes[j] = 1;
		}
	}
	else{							// for the assimetric case
		if (fixedinputs == FIX_EVOvra || fixedinputs == FIXED){
			for(j=0; j<varN->finalInp; j++){
				posinputs[j] = j;
				nodes[j] = 1;
			}
		}
		else if (fixedinputs == EVOLVE){
			for(j=0; j<varN->finalInp; j++){				//activate all the inputs
				if(rando() < sigmaInputAssym){
					posinputs[j] = j;
					nodes[j] = 1;
				}
				else{
					posinputs[j] = 0;				// indicate that there is not input, instead of -1 it will be zero and nodes[i] will indicate if there is input or not with 0 or 1
					nodes[j] = 0;
				}
			}
		}
	}

	// initialize the hidden nodes and nodes variable
	for(j=varN->finalInp; j < allnodes; j++){
		nodes[j] = 1;
		poshidden[cont1] = j;
		cont1++;
	}
	// update the values from sizepos
	sizepos[0] = varN->finalInp;
	sizepos[1] = varN->hidden + varN->VnoOutputs;

	// print into screen
	//cout << "posinputs = " << endl; imprime(posinputs,sizepos[0]); 	cout << "poshidden= " << endl; imprime(poshidden,sizepos[1]);

	// initialize connections between nodes


	// Decide wich method use to initialize the connection between nodes (Simple conn schme, sparse with lienal function or sparse conn scheme with exp function)
	switch (whichConnScheme){
	case 0:														// 0 = simple connection scheme
		initConnSCS();
		break;
	case 1:														// 1 = Improved connection scheme
		initConnImprovedCS();
		break;
	case 2: 														// 2 = sparse connection scheme linear functions
		initConnSpareCSlineal();
		break;
	case 3:														// 3 = sparse connection scheme exp functions
		initConnSpareCSexp();
		break;
	case 4:
		initConnModule();									// 4 = Modular. Init pure modular network
	case 5:
		initConnModularMLP_SCS();					// 5 = init MLP with the simple connection scheme
	}

	// to test
	//cout << "CW" << endl; imprime(CW,allnodes,allnodes);

	// initialize the bias, a nodes has a bias or not
	initBias();

	// initialize the weights from the active connections between nodes and the connections from bias
	initweights();

	// Check that the last layer (output layer) has at least one connection, if it has do nothing, if not
	// add one at random

	checkValidNet();




} // finish initNet //////////////////////////////////////////////////////////////////


void C_network::initweights(void)
	/*!
	 * initialize in a random way an existing Weight matrix + the weights of the bias
	 *
	 * Created:       somewhen in 2008
	 * Modified at:
	 * Author:       Carlos Torres and Victor Landassuri
	 */
{
	register int i,j;
	int nodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;

	for(i=0; i<nodesNet; i++){
		for(j=0; j<nodesNet; j++){
			if(CW[i][j] == 1)
				W[i][j] = 2.0 * (rando() - 0.5) * smallW;
		}
	}
	for(i=0; i<nodesNet; i++){
		if(bias[i] == 1)
			W[i][i] = 2.0 * (rando() - 0.5) * smallW;
	}
}//////////////////////////////////////////////////////////////////////////






void C_network::initConnSCS(void){
	/*!
	 * Initialize the connections with the Simple Connections Scheme
	 *
	 * Here there is only one value (sigmaSCS) that determinate the probability of existence of all available connections between nodes
	 *
	 * Note that bias connections are managed with a different sigma value (sigmaBias)
	 *
	 * Created:      20 Nov 2010
	 * Modified:		27 Feb 2011
	 * Author:       Carlos Torres and Victor Landassuri
	 *
	 */

	init_IH_SCS();

	if ( IS_MLP == OFF ){ 									// if it is GMLP
		init_IO_SCS();
		init_HH_SCS();
		init_OO_SCS();
	}

	init_HO_SCS();
	//imprime(CW, (varN->finalInp + varN->hidden + varN->VnoOutputs),  (varN->finalInp + varN->hidden + varN->VnoOutputs) );
}//////////////////////////////////////////////////////////////////////////


void C_network::initConnImprovedCS(void){
	/*!
	 * Improved connection scheme
	 * Avoid isolated nodes and increase the modularity a little bit
	 * Implemented only for GMLP non constrained connections
	 *
	 * The results shows that the isolated nodes may be increased after random architectural mutations
	 * So one importnat aspect is to avoid them at the beginning, another isto avoid them during evolution
	 *
	 * Similar to exp3 for the init networks
	 *
	 * Created:      20 Nov 2010
	 * Modified at:
	 * Author:       Carlos Torres and Victor Landassuri
	 */

	// Local variables
	double **probM = NULL; 					// just to test, normal running it is not needed
	int allnodes;

	// allocate/initialize var
	allnodes = varN->finalInp + varN->hidden + varN->VnoOutputs;
	probM = allocate(probM, allnodes, allnodes);


	/*!
	 * here there are different variations to fill the probability matrix
	 */

	if (  CSalgorithm.compare("A") == 0 ){
		// Like exp2A

		// variables for exp2A
		double IHinit = 1;
		double IHfinal = 0.1;

		double IOinit = 0.5;
		double IOfinal = 0.1;

		double HHinit = 0.1;
		double HHfinal = 0.5;

		double HOinit = 0.1;
		double HOfinal = 1;
		double OOval = 0.5;

		if (alternateCS == 1)
			init_IH_IO_SCS();
		else{
			// I2H
			fillMatline(probM,posinputs,varN->finalInp, poshidden,varN->hidden,IHinit, IHfinal);
			//imprime(probM,allnodes,allnodes);
			// IO
			fillMatline(probM,posinputs,varN->finalInp, &poshidden[varN->hidden],varN->VnoOutputs,IOinit, IOfinal);
			//imprime(probM,allnodes,allnodes);
		}
		// HH
		fillUpperRightMat(probM,poshidden,varN->hidden, HHinit, HHfinal);
		//imprime(probM,allnodes,allnodes);
		// HO
		fillMatDiag(probM,poshidden,varN->hidden, &poshidden[varN->hidden],varN->VnoOutputs,HOinit, HOfinal);
		//imprime(probM,allnodes,allnodes);
		// OO
		fillUpperRightMatSAMEprob(probM,&poshidden[varN->hidden],varN->VnoOutputs, OOval);
		//imprime(probM,allnodes,allnodes);
	}

	else if (  CSalgorithm.compare("G") == 0 ){

		// Like exp2G
		// variables for exp2G
		double IHinit = 1;
		double IHfinal = 0.1;
		double OOval = 0.5;

		if (alternateCS == 1)
			init_IH_IO_SCS();
		else{
			// IH and IO
			fillMatline(probM,posinputs,varN->finalInp, poshidden, varN->hidden + varN->VnoOutputs,IHinit, IHfinal);
			//imprime(probM,allnodes,allnodes);
		}
		// HH and HO
		//fillMatH2HO(probM,poshidden, varN->hidden, &poshidden[varN->hidden], varN->VnoOutputs,0.1, 1);
		// OO
		fillUpperRightMatSAMEprob(probM,&poshidden[varN->hidden],varN->VnoOutputs, OOval);
		//imprime(probM,allnodes,allnodes);
	}

	else if (  CSalgorithm.compare("L") == 0 ){

		// Like Exp2L
		// variables for exp2L
		double IHinit = 1;
		double IHfinal = 0.1;
		double OOval = 0.5;


		if (alternateCS == 1)
			init_IH_IO_SCS();
		else{
			// IH and IO
			fillMatDiag(probM,posinputs,varN->finalInp, poshidden, varN->hidden + varN->VnoOutputs,IHinit, IHfinal);
			//	imprime(probM,allnodes,allnodes);
		}
		// HH and HO
		fillMatH2HObyCols(probM,poshidden, varN->hidden, &poshidden[varN->hidden], varN->VnoOutputs,0.1, 1);
		//	imprime(probM,allnodes,allnodes);
		// OO
		fillUpperRightMatSAMEprob(probM,&poshidden[varN->hidden],varN->VnoOutputs, OOval);
		//	imprime(probM,allnodes,allnodes);

	}
	/*!
	 * Finish variations
	 */

	// Section to fill CW given the probability matrix
	fillCWfromProbM(probM);


	// free memory allocated
	safefree(&probM, allnodes);

}//////////////////////////////////////////////////////////////////////////




void C_network::initConnSpareCSlineal(void){
	/*!
	 * Sparse connection scheme
	 * Increment themodularity and avoid the isolated nodes, thus reduce the number of conenctions
	 * * Implemented only for GMLP non constrained connections
	 * Created:      		20 Nov 2010
	 * Modified at: 	21 Nov 2010
	 * Author:       		Carlos Torres and Victor Landassuri
	 */

	// Local variables
	double **probM = NULL; 					// just to test, normal running it is not needed
	int allnodes;
	int *i = NULL;


	// allocate/initialize var
	allnodes = varN->finalInp + varN->hidden + varN->VnoOutputs;
	probM = allocate(probM, allnodes, allnodes);


	/*!
	 * here there are different variations to fill the probability matrix,, comment the others not used
	 */

	if (  CSalgorithm.compare("M") == 0 ){
		// Like exp4M
		// variables for exp4M
		int cont, cont2, flag;
		double init = 1.0;
		double final = 0.0;

		if (alternateCS == 1)
			init_IH_IO_SCS();
		else{
			// I2H
			cont = 0;
			flag = 0;
			for( i=posinputs; cont<varN->finalInp; i++){
				cont++;
				if (flag == 0){ 			// one and one
					fillMatline(probM,i,1,poshidden,varN->hidden, init, final);
					flag = 1;
				}
				else{
					fillMatline(probM,i,1,poshidden,varN->hidden, final, init);
					flag = 0;
				}
			}
			//	imprime(probM,allnodes,allnodes);

			// IO
			// not in this moment
		}

		// HH
		cont = 0;
		cont2 = 1;
		flag = 0;
		for( i=poshidden; cont<varN->hidden-1; i++){
			cont++;
			if (flag == 0){ 			// one and one
				fillMatline(probM,i,1,&poshidden[cont2],varN->hidden-cont2, init, final);
				flag = 1;
			}
			else{
				fillMatline(probM,i,1,&poshidden[cont2],varN->hidden-cont2, final,init);
				flag = 0;
			}
			cont2++;
		}
		//	imprime(probM,allnodes,allnodes);

		// HO
		// In the matlab code here it was implemented a lineal funtion witht he diagonal in 1 and then the probability decrease as it approaches to the corner
		// It is not implementd here this function and instead it is used the eponential decaying function normalized distance.
		fillMatE(probM,poshidden,varN->hidden, &poshidden[varN->hidden],varN->VnoOutputs,1);
		//	imprime(probM,allnodes,allnodes);
		// OO
		// not in this moment
	}

	else if (  CSalgorithm.compare("S") == 0 ){


		// Like exp4S
		// variables for exp4S
		double IHinit = 1;
		double IHfinal = 0.1;
		double HHinit = 0.1;
		double HHfinal = 0.5;

		if (alternateCS == 1)
			init_IH_IO_SCS();
		else{
			// IH , int he matlab code I sue fillMAtline, here I use fillDiagMat, there is not a big difference for this sub-matrix
			fillMatDiag(probM,posinputs,varN->finalInp, poshidden, varN->hidden,IHinit, IHfinal);
			//	imprime(probM,allnodes,allnodes);
		}
		// HH
		fillUpperRightMat(probM,poshidden,varN->hidden, HHinit, HHfinal);
		//	imprime(probM,allnodes,allnodes);
		//HO
		fillMatE(probM,poshidden,varN->hidden, &poshidden[varN->hidden],varN->VnoOutputs,1);
		//	imprime(probM,allnodes,allnodes);
		// OO
		// not in this moment
	}

		/*!
		 * Finish variations
		 */

		// Section to fill CW given the probability matrix
		fillCWfromProbM(probM);


		// free memory allocated
		safefree(&probM, allnodes);
		i = NULL;


}//////////////////////////////////////////////////////////////////////////

void C_network::initConnSpareCSexp(void){
	/*!
	 * Sparse connection scheme using exponential decaying functions
	 * Improve modularity avoid almost all isolated ndoes and reduce number of connections
	 * * Implemented only for GMLP non constrained connections
	 *
	 * Created:      20 Nov 2010
	 * Modified at:
	 * Author:       Carlos Torres and Victor Landassuri
	 */


	// Local variables
	double **probM = NULL; 					// just to test, normal running it is not needed
	int allnodes;
	int *i = NULL;


	// allocate/initialize var
	allnodes = varN->finalInp + varN->hidden + varN->VnoOutputs;
	probM = allocate(probM, allnodes, allnodes);


	/*!
	 * here there are different variations to fill the probability matrix,, comment the others not used
	 */

	if (  CSalgorithm.compare("M") == 0 ){
		// Like exp6M
		// variables for exp6M
		 int cont, cont2, flag;
		double init = 1.0;
		 double final = 0.0;

		 if (alternateCS == 1)
			 init_IH_IO_SCS();
		 else{
			 // I2H
			 //fillMatDiag(probM,posinputs,varN->finalInp, poshidden, varN->hidden,init, final);
			 fillMatE(probM,posinputs,varN->finalInp, poshidden,varN->hidden,1);
			 //		 imprime(probM,allnodes,allnodes);

			 // IO
			 // not in this moment
		 }

		 // HH
		 cont = 0;
		 cont2 = 1;
		 flag = 0;
		 for( i=poshidden; cont<varN->hidden-1; i++){
			 cont++;
			 if (flag == 0){ 			// one and one
				 fillMatline(probM,i,1,&poshidden[cont2],varN->hidden-cont2, init, final);
				 flag = 1;
			 }
			 else{
				 fillMatline(probM,i,1,&poshidden[cont2],varN->hidden-cont2, final,init);
				 flag = 0;
			 }
			 cont2++;
		 }
		 //	 imprime(probM,allnodes,allnodes);

		 // HO
		 fillMatE(probM,poshidden,varN->hidden, &poshidden[varN->hidden],varN->VnoOutputs,1);
		 //	 imprime(probM,allnodes,allnodes);
		 // OO
		 // not in this moment

	}
	else if (  CSalgorithm.compare("S") == 0 ){


			// Like exp6S
			// variables for exp6S
			double HHinit = 0.1;
			double HHfinal = 0.5;

			if (alternateCS == 1)
				init_IH_IO_SCS();
			else{
				// IH , int he matlab code I sue fillMAtline, here I use fillDiagMat, there is not a big difference for this sub-matrix
				fillMatE(probM,posinputs,varN->finalInp, poshidden,varN->hidden,1);
				//		imprime(probM,allnodes,allnodes);
			}

			// HH
			fillUpperRightMat(probM,poshidden,varN->hidden, HHinit, HHfinal);
			//		imprime(probM,allnodes,allnodes);
			//HO
			fillMatE(probM,poshidden,varN->hidden, &poshidden[varN->hidden],varN->VnoOutputs,1);
			//		imprime(probM,allnodes,allnodes);
			// OO
			// not in this moment

	}
			/*!
			 * Finish variations
			 */

			// Section to fill CW given the probability matrix
			fillCWfromProbM(probM);


			// free memory allocated
			safefree(&probM, allnodes);
			i = NULL;


}//////////////////////////////////////////////////////////////////////////



void C_network::initConnModule(void){
	/*!
	 * initialize pure modular neural networks
	 *
	 * it is used sigmaSCS to initialize the connectivity among nodes in each module
	 *
	 * Note that bias connections are managed with a different sigma value (sigmaBias)
	 *
	 * The hidded nodes are only considered to be splitted into modules, the input are assumed to be connected to any module
	 * Created:      02 Feb 2011
	 * Modified at:
	 * Author:       Carlos Torres and Victor Landassuri
	 *
	 */

	// Local var
	int *jj,*kk;
	int i;
	int **nodesINmodule = NULL;
	int **inpINmodule = NULL;

	//int *module2 = NULL;
	int noModules = 0;
	int *nameModule = NULL;

	int *outputsInMod = NULL;
	int outputsLoaded = 0;
	int *nodesPerModule = NULL; 					// nodes per module

	int cont=0;
	int cont1=0;

	// allocate space

	//module2 = allocate(module2,varN->hidden + varN->VnoOutputs);
	nameModule = allocate(nameModule,varN->VnoOutputs * 2);
	outputsInMod = allocate(outputsInMod,varN->VnoOutputs * 2);


	// Initialize the Connections for the upper right triangle of the matrix, first part IH and IO
	//init_IH_IO_SCS();  		// old fun
	//init_IH_SCS();
	//init_IO_SCS();

	// initialize the inputs accoidingly to the module they belong
	// i.e. first input for the first module, secodn for the second, third for the fisrt ,...
	// this only works for thasl like LoxA-LoxB
	//init_IH_modular();
	//init_IO_modular(); not used in this moment

	//imprime(CW, (varN->finalInp + varN->hidden + varN->VnoOutputs),  (varN->finalInp + varN->hidden + varN->VnoOutputs) );

	// Para rapido solo voy a considerar dos modulos



	// Load the name of the modules and the outputs that belong to each module
	//if( strcmp( NAMETS.c_str(), "WhatAndWhere" ) == 0   || strcmp( NAMETS.c_str(), "0024" ) == 0 ){
		if (FileExists("txtFiles/nameModules") == true)						//  Load the name of the modules
			noModules = loadVecInt("txtFiles/nameModules", nameModule);

		if (FileExists("txtFiles/outputsInMod") == true ) 																// load the bounded modules
			outputsLoaded = loadVecInt("txtFiles/outputsInMod",  outputsInMod);
	//}

		nodesINmodule = allocate(nodesINmodule, noModules, varN->hidden + varN->VnoOutputs); 					// this is the max size that it could have // module1 before
		nodesPerModule = allocate(nodesPerModule,noModules);

		inpINmodule = allocate(inpINmodule, noModules, varN->finalInp);



	/// how many hidden nodes in each module ////////////////////////////////////////////////////////////////
	int nodesPerModuleTMP = ( int ) ( varN->hidden / noModules );
    // Fil each position
	for (i = 0; i<noModules; i++ )
		nodesPerModule[i] = nodesPerModuleTMP;
	// It is possible that reamin some module, they will be added to each module untill all of them are used
	int idx = 0;
	while( SUMvec(nodesPerModule, noModules) > varN->hidden){
		// delete if there are more than the allowed
		nodesPerModule[idx] --;
		idx ++;
		if (idx > noModules -1)
			idx = 0; 							// star from zero if it moved through all posisitons
	}
	// contrari case, if remain some hidden nodes to be assigned
	idx = 0;
	while( SUMvec(nodesPerModule, noModules) < varN->hidden){
		// add if there are less than the allowed
		nodesPerModule[idx] ++;
		idx ++;
		if (idx > noModules -1)
			idx = 0; 							// star from zero if it moved through all posisitons
	}
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	// create a lsit of nodes per module, so it is known which nodes belong to which node
	idx = 0;
	int module;
	int contt;
	int contt2;
	for (module = 0; module < noModules; module++){				// for all modules

		// hidden nodes
		for ( i = 0; i < nodesPerModule[module]; i++){ 				// count the nodes in the modules and assing them
			nodesINmodule[module][i] = poshidden[idx];
			idx ++;
		}

		// output nodes
		contt = varN->hidden; 								// start in the fisrt output
		contt2 = i;
		for ( i = 0; i < varN->VnoOutputs; i++){
			if (outputsInMod[i] == ( module + 1) ){
				nodesINmodule[module][contt2] = poshidden[contt];
				//cout << "nodeInMod [module [contt2]= "  << nodesINmodule[module][contt2] << endl;
				contt2 ++;
				nodesPerModule[module] ++;		// increment the number of nodes in this module
			}
			contt ++;
		}
	}

	//imprime(nodesINmodule,noModules,varN->hidden + varN->VnoOutputs);
	// inputs in module, create them

	int cnt = 0;
	for (i = 0; i<(int)(varN->finalInp/2); i++){
		for (module = 0; module < noModules; module ++){
			inpINmodule[module][i] = cnt;
			cnt++;
		}
	}
	//imprime(inpINmodule,noModules,varN->finalInp); //note that only this works for thask llike LoA-LoB !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
 int inputsPermod = (int)(varN->finalInp/2);
	// initialize the connection to create the modules

	int *initOutput = NULL;
	int countOut = 0;
	for (module = 0; module < noModules; module++){

		if ( IS_MLP == ON ){ 																					// MLP, 1 hidden layer
			// means that no connection in HH, thus init in the first output
			initOutput = &nodesINmodule[module][ nodesPerModule[module] - NUM_OUT_Per_MOD[module] ];
			countOut = NUM_OUT_Per_MOD[module];
		}
		else{																											// GMLP
			initOutput = &nodesINmodule[module][ 0 ];
			countOut = nodesPerModule[module];
		}

		cont=0;
		for(jj=nodesINmodule[module]; cont < nodesPerModule[module] - NUM_OUT_Per_MOD[module]; jj++){
			cont++;
			for (kk=initOutput; cont1<countOut ; kk++){ 			//count the last layer
				cont1++;
				if(*kk > *jj){
					if (rando() <= sigmaSCS){
						CW[*jj][*kk] = 1;
						//W[*jj][*kk] = 2.0 * (rando() - 0.5) * smallW;
					}
				}
			}
			cont1=0;
		}
		// print partial network
		//imprime(CW, (varN->finalInp + varN->hidden + varN->VnoOutputs),  (varN->finalInp + varN->hidden + varN->VnoOutputs) );
	}


	//now inputs to hidde nodes
	// Initialize the Connections for the upper right triangle of the matrix, first part IH and IO
	for (module = 0; module < noModules; module ++){
		cont = 0;
	for(jj=posinputs; cont<sizepos[0];jj++){
		cont++;
		cont1 = 0;
		for (kk=poshidden; cont1<varN->hidden; kk++){ 		// for hidden only
			cont1++;
			//if  ( rando() <= sigmaSCS ){
				//int f;
				//f = findNum(*jj, inpINmodule[module], inputsPermod);
				if ( (findNum( *jj, inpINmodule[module], inputsPermod)) && (findNum( *kk, nodesINmodule[module], nodesPerModule[module]) )  )
				//if (  ( findNum( *jj, inpINmodule[module], inputsPermod)  ) && ( findNum( *kk, nodesINmodule[module], nodesPerModule[module])  ) ){
					CW[*jj][*kk] = 1;
				//}
				//numConn ++;
				//W[*jj][*kk] = 2.0 * (rando() - 0.5) * smallW;
			//}
		}
	}
	}

	//imprime(CW, (varN->finalInp + varN->hidden + varN->VnoOutputs),  (varN->finalInp + varN->hidden + varN->VnoOutputs) );


	// print all conenctions
	//imprime(CW, (varN->finalInp + varN->hidden + varN->VnoOutputs),  (varN->finalInp + varN->hidden + varN->VnoOutputs) );

	// dealocate, set to null
	safefree(&outputsInMod);
	safefree(&nodesINmodule, noModules);
	//safefree(&module2);
	safefree(&nameModule);
	safefree(&nodesPerModule);
	safefree(&inpINmodule);

	jj = NULL;
	kk = NULL;
	initOutput = NULL;
}//////////////////////////////////////////////////////////////////////////


void C_network::initBias(void){
	/*!
	 * Initialize if a node has bias or not
	 *
	 * Created:      20 Nov 2010
	 * Modified at:
	 * Author:       Carlos Torres and Victor Landassuri
	 */

	// Local var
	int *kk;
	int cont1=0;

	// initialize the bias
	for (kk=poshidden; cont1<sizepos[1]; kk++){
		if (rando() <= sigmaBias){
			bias[*kk] = 1;
		}
		cont1++;
	}
	// dealocate, set to null
	kk = NULL;
}//////////////////////////////////////////////////////////////////////////






void C_network::initConnModularMLP_SCS(void){

}////////////////////////




void C_network::fillCWfromProbM(double **m){
	/*!
	 * It is filled CW taking the probability matrix previously create with a given method
	 *
	 * Inputs
	 * 		m 		probability matrix
	 *
	 * Outputs
	 * 		CW		variable from the class
	 *
	 * Created:      20 Nov 2010
	 * Modified at:
	 * Author:       Carlos Torres and Victor Landassuri
	 */

	// Local var
	int *jj,*kk;

	// Initialize the Connections for the upper right triangle of the matrix, first part IH and IO
	int cont=0;
	int cont1=0;
	for(jj=posinputs; cont<sizepos[0];jj++){
		cont++;
		for (kk=poshidden; cont1<sizepos[1]; kk++){ //count the last layer
			cont1++;
			if (rando() <= m[*jj][*kk] && *jj >= 0 ){
				CW[*jj][*kk] = 1;
				//W[*jj][*kk] = 2.0 * (rando() - 0.5) * smallW;
			}
		}
		cont1=0;
	}
	// for the second part HH, HO and OO
	cont=0;
	cont1=0;
	for(jj=poshidden; cont<sizepos[1]-1;jj++){
		cont++;
		for (kk=poshidden; cont1<sizepos[1]; kk++){ //count the last layer
			cont1++;
			if(*kk > *jj){
				if (rando() <= m[*jj][*kk]){
					CW[*jj][*kk] = 1;
					//W[*jj][*kk] = 2.0 * (rando() - 0.5) * smallW;
				}
			}
		}
		cont1=0;
	}

	// dealocate, set to null
	jj = NULL;
	kk = NULL;
}//////////////////////////////////////////////////////////////////////////


void C_network::fillMatline(double **m,int *vec1, int vec1cols, int *vec2, int vec2cols, double initial, double final){
	/*!
	 * Fill the submatrix passed (vec1 and vec2) with a lineal decaying function from the inital to final value.
	 * Each line will be the same probability
	 *
	 * This function could be outside the class, nevertheless for the moment is left here
	 *
	 * Inputs:
	 * 		m			probability matrix to fill
	 * 		vec1		vector representing the inputs, lines
	 * 		vec1cols	positions in t his vector
	 * 		vec2 	vector representing the target nodes, columns
	 * 		vec2cols 	positions in this vector
	 * 		initial	the initial value to fill the line
	 * 		final 	the value to finish the line
	 *
	 * Outputs:
	 * 		m			filled
	 *
	 * Created:      20 Nov 2010
	 * Modified at:
	 * Author:       Carlos Torres and Victor Landassuri
	 */

	// local var
	int *i,*j, cont, cont1;
	double inc = 0.0;
	double x = 0.0;

	cont = 0;
	cont1 = 0;
	for( i=vec1; cont<vec1cols; i++){
		cont++;
		inc = calcInc(initial, final, vec2cols-1);
		x = initial;
		for ( j=vec2; cont1<vec2cols; j++){
			cont1++;
			m[*i][*j] = x;
			x += inc;
		}
		cont1=0;
	}
}/////////////////////////////////////////////////////////////////////////////////


void C_network::fillUpperRightMat(double **m,int *vec, int veccols, double initial, double final){
	/*!
	 *  Fill the upper right matrix from min to max values
	 *  In the matlab code it was tested two version, fill by lines or columns.
	 *  Here is only used by lines, i.e. fill first all columns and then increment the lines counter
	 *
	 * Inputs:
	 * 		m			probability matrix to fill
	 * 		vec		vector representing the hidden nodes
	 * 		veccols	positions in this vector
	 * 		initial	the initial value to fill the line
	 * 		final 	the value to finish the line
	 *
	 * Outputs:
	 * 		m			filled
	 *
	 * Created:      21 Nov 2010
	 * Modified at:
	 * Author:       Carlos Torres and Victor Landassuri
	 */

	// Local var
	int *i,*j;
	int cont, cont1;
	double inc = 0.0;
	double x = 0.0;
	int div = 1;

	// vec is taken for lines and columns, so it is created a squared matrix
	div = setupDivHidden(veccols);

	inc = calcInc(initial, final, div-1 );
	x = initial;

	// Only fill by lines, i.e. all columns are filled first and then increment line
	cont=0;
	cont1=0;
	for(i=vec; cont<veccols-1; i++){
		cont++;
		for ( j=vec; cont1<veccols; j++){
			cont1++;
			if(*j > *i){
				m[*i][*j] = x;
				x += inc;
			}
		}
		cont1=0;
	}

}/////////////////////////////////////////////////////////////////

void C_network::fillUpperRightMatSAMEprob(double **m,int *vec, int veccols, double initial){
	/*!
	 *  Fill the upper right matrix OO or HH.
	 *  All slots with the same probability
	 *
	 * Inputs:
	 * 		m			probability matrix to fill
	 * 		vec		vector representing the hidden nodes
	 * 		veccols	positions in this vector
	 * 		initial	the value to be put in all sub-matrix
	 *
	 * Outputs:
	 * 		m			filled
	 *
	 * Created:      21 Nov 2010
	 * Modified at:
	 * Author:       Carlos Torres and Victor Landassuri
	 */

	// Local var
	int *i,*j;
	int cont, cont1;
	double x = 0.0;
	int div = 1;

	// vec is taken for lines and columns, so it is created a squared matrix
	div = setupDivHidden(veccols);

	x = initial;

	cont=0;
	cont1=0;
	for(i=vec; cont<veccols-1; i++){
		cont++;
		for ( j=vec; cont1<veccols; j++){
			cont1++;
			if(*j > *i){
				m[*i][*j] = x;
			}
		}
		cont1=0;
	}

}/////////////////////////////////////////////////////////////////



void C_network::fillMatDiag(double **m,int *vec1, int vec1cols, int *vec2, int vec2cols, double initial, double final){
	/*!
	 * Fill the submatrix passed (vec1 and vec2) with a lineal decaying function from the inital to final value.
	 * The initial is suppose to represent the upper-left corner if the matrix and the final the lower-right corner of it.
	 *
	 * This function could be outside the class, nevertheless for the moment is left here as many other functions in this file
	 *
	 * Inputs:
	 * 		m			probability matrix to fill
	 * 		vec1		vector representing the inputs, lines
	 * 		vec1cols	positions in t his vector
	 * 		vec2 	vector representing the target nodes, columns
	 * 		vec2cols 	positions in this vector
	 * 		initial	the initial value to fill the line
	 * 		final 	the value to finish the line
	 *
	 * Outputs:
	 * 		m			filled
	 *
	 * Created:      21 Nov 2010
	 * Modified at:
	 * Author:       Carlos Torres and Victor Landassuri
	 */

	// local var
	int *i,*j, cont, cont1;
	double inc = 0.0;
	double x = 0.0;

	inc = calcInc(initial, final, (vec1cols * vec2cols)-1 );
	x = initial;

	cont = 0;
	cont1 = 0;
	for( i=vec1; cont<vec1cols; i++){
		cont++;
		for ( j=vec2; cont1<vec2cols; j++){
			cont1++;
			m[*i][*j] = x;
			x += inc;
		}
		cont1=0;
	}
}/////////////////////////////////////////////////////////////////////////////////


void C_network::fillMatH2HO(double **m, int *vec1, int vec1cols, int *vec2, int vec2cols, double initial, double final){
	/*!
	 * Function to fill first HH and then HO
	 *	The probability is decremented in both matrices, thus it is different to the previous methods
	 *
	 * Fill by lines, i.e. fors all columns then lines
	 *
	 * Created:	21 Nov 2010
	 * Modified:
	 * Author:		Carlos Torres and Victor Landassuri
	 */

	// Local var
	int *i,*j;
	int cont, cont1;
	double inc = 0.0;
	double x = 0.0;
	int div = 1;


	div = setupDivHidden(vec1cols);

	inc = calcInc(initial, final, ( (div-1) + (vec1cols * vec2cols) ) );
	x = initial;

	// fill HH
	// Only fill by lines, i.e. all columns are filled first and then increment line
	cont=0;
	cont1=0;
	for(i=vec1; cont<vec1cols-1; i++){
		cont++;
		for ( j=vec1; cont1<vec1cols; j++){
			cont1++;
			if(*j > *i){
				m[*i][*j] = x;
				x += inc;
			}
		}
		cont1=0;
	}

	// to test
	// int allnodes = varN->finalInp + varN->hidden + varN->VnoOutputs;
	// imprime(m,allnodes,allnodes);
	//////////////

	// fill HO
	cont=0;
	cont1=0;
	for(i=vec1; cont<vec1cols; i++){
			cont++;
			for ( j=vec2; cont1<vec2cols; j++){
				cont1++;
				m[*i][*j] = x;
				x += inc;
			}
			cont1=0;
		}
}////////////////////////////////////////////////////////////////////////////////////////////




void C_network::fillMatH2HObyCols(double **m, int *vec1, int vec1cols, int *vec2, int vec2cols, double initial, double final){
	/*!
	 * Function to fill HH and HO as if they were a single matrix
	 *
	 * Fill by lines, i.e. firs all columns then lines
	 *
	 * Created:	21 Nov 2010
	 * Modified:
	 * Author:		Carlos Torres and Victor Landassuri
	 */

	// Local var
	int *i,*j;
	int cont, cont1;
	double inc = 0.0;
	double x = 0.0;
	int div = 1;


	div = setupDivHidden(vec1cols);

	inc = calcInc(initial, final, ( (div-1) + (vec1cols * vec2cols) ) );
	x = initial;

	// fill HH
	// Only fill by lines, i.e. all columns are filled first and then increment line
	cont=0;
	cont1=0;
	for(i=vec1; cont<vec1cols; i++){
		cont++;
		for ( j=vec1; cont1<vec1cols + vec2cols; j++){ 		// This is a trick becase vec1 is poshidden which have hidden and outputs, thus it can be used as the concatenation of them
			cont1++;
			if(*j > *i){
				m[*i][*j] = x;
				x += inc;
			}
		}
		cont1=0;
	}

}////////////////////////////////////////////////////////////////////////////////////////////


void C_network::fillMatE(double **m,int *vec1, int vec1cols, int *vec2, int vec2cols, double sigma){
	/*!
	 * Fill the paseed matrix witht he exponential decaying function using the distance normalized between nodes
	 */

	// local var
	int *i,*j, cont, cont1;
	double inc = 0.0;
	double x = 0.0;

	if (vec2cols == 1){
		// Networks with just one output
		// here is used this routine because the contrary gives bad results for HO, thus slow modularity values

		inc = calcInc(0.5 , 1 , (vec1cols * vec2cols)-1 );
		x = 0.5;
		cont = 0;
		cont1 = 0;
		for( i=vec1; cont<vec1cols; i++){
			cont++;
			for ( j=vec2; cont1<vec2cols; j++){
				cont1++;
				m[*i][*j] = x;
				x += inc;
			}
			cont1=0;
		}
	}
	else{
		// Networks with many outputs, here it is used the exponential function
		// Used the e normalized distance to assing the connectivity
		cont = 0;
		cont1 = 0;
		for( i=vec1; cont<vec1cols; i++){
			for ( j=vec2; cont1<vec2cols; j++){
				m[*i][*j] = localConnS(cont+1,cont1+1, vec1cols, vec2cols, sigma); // the index of x and y are put in format 1,2,... instead of 0,1,...
				cont1++;
			}
			cont1=0;
			cont++;
		}
	}

}//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




inline double C_network::calcInc(double initial, double final, int slots){
	/*!
	 * Function to caculate the increment for the probability that a connection exist given the initial, final values and the number of positions to fill
	 *
	 * It does not matter if initial is < or > than final, automatically it is calculated the increment as positive or negative with the *-1 at the end
     *
	 * It is inline to improve performace as it is only one line
	 *
	 * Created:      20 Nov 2010
	 * Modified at:
	 * Author:       Carlos Torres and Victor Landassuri
	 */
	// local var
	double increment = 0;
	increment = ( (initial - final) / slots) * -1;
	return( increment );

}


inline int C_network::setupDivHidden(int num){
	/*!
	 * function to calculate the number of places in a squared matrix for the
	 * upper left of righ section of the matrix without take into account the
	 * diagonal matrix
	 *
	 * Rule to determinate how many slots there are
	 * 1 = 0                     = 0
	 * 2 = 1                     = 1
	 * 3 = 2 + 1                 = 3
	 * 4 = 3 + 2 +1              = 6
	 * 5 = 4 + 3 + 2 + 1         = 10
	 * 6 = 5 + 4 + 3 + 2 +1      = 15
	 * ...
	 *
	 * Created:      21 Nov 2010
	 * Modified at:
	 * Author:       Carlos Torres and Victor Landassuri
	 */

	// Local var
	int d = 0;

	if ( num > 1 ){
		while ( num > 1 ){
	        num -= 1;
	        d += num;
		}
	}

	return(d);
}////////////////////////////////////////////////////////////////////////


inline double C_network::localConnS(int n, int m, int N, int M, double sigma){
	/*!
	 * Caculate the local connection scheme with the exponential function using the normalized distance
	 */

	return ( exp( (-1/sigma) * abs(n - ( (N*m)/M ) ) ) );

}


void C_network::init_IH_IO_SCS(void){
	/*!
	 * Initialize the IH and IO submatrices witht the simple connecitons scheme
	 *  FIRST FUNTION PROGRAMMED, NOT USED ALMOST IN THIS MOMENT, DESIGNED FOR ALLOWED ALL SLOTS TO BE FILLED
	 */

	// Local Var
	int *jj,*kk;
	int cont=0;
	int cont1=0;

	// Check that the IH and IO submatrices are not constrained in the number of connections

		// Initialize the Connections for the upper right triangle of the matrix, first part IH and IO
		for(jj=posinputs; cont<sizepos[0];jj++){
			cont++;
			for (kk=poshidden; cont1<sizepos[1]; kk++){ 		// for hidden and output(s)
				cont1++;
				if (rando() <= sigmaSCS && *jj >= 0 ){
					CW[*jj][*kk] = 1;
					//W[*jj][*kk] = 2.0 * (rando() - 0.5) * smallW;
				}
			}
			cont1=0;
		}


// dealocate, set to null
jj = NULL;
kk = NULL;

}///////////////////////////


void C_network::init_IH_SCS(void){
	/*!
	 * Initialize the IH submatrice witht the simple connecitons scheme
	 * IF the connections are limited, it is take that into account
	 *
	 */

	// Local Var
	int *jj,*kk;
	int cont=0;
	int cont1=0;
	int allowedConn = 0;
	int numConn = 0;
	int flagExit = 0;

	// Check that the IH submatrix is not constrained in the number of connections
	allowedConn = ( int ) ( ( varN->finalInp * varN->hidden ) * CONN_ALLOWED_IH );

	if ( allowedConn > 0 ){

		// Initialize the Connections for the upper right triangle of the matrix, first part IH and IO
		for(jj=posinputs; cont<sizepos[0];jj++){
			cont++;
			for (kk=poshidden; cont1<varN->hidden; kk++){ 		// for hidden only
				cont1++;
				if (  ( rando() <= sigmaSCS )  &&  ( *jj >= 0 )  ){
					CW[*jj][*kk] = 1;
					numConn ++;
					//W[*jj][*kk] = 2.0 * (rando() - 0.5) * smallW;
				}
				if (numConn >= allowedConn){
					flagExit = 1;
					break;
				}

			}
			if ( flagExit )
				break;
			cont1=0;
		}

	}
	// dealocate, set to null
	jj = NULL;
	kk = NULL;
}///////////////////////////


void C_network::init_IO_SCS(void){
	/*!
	 * Initialize the IO submatrice witht the simple connecitons scheme
	 * IF the connections are limited, it is take that into account
	 *
	 */

	// Local Var
	int *jj,*kk;
	int cont=0;
	int cont1=0;
	int allowedConn = 0;
	int numConn = 0;
	int flagExit = 0;

	// Check that the IH submatrix is not constrained in the number of connections
	allowedConn = ( int ) ( ( varN->finalInp * varN->VnoOutputs ) * CONN_ALLOWED_IO );

	if ( allowedConn > 0 ){
		// Initialize the Connections for the upper right triangle of the matrix, first part IH and IO
		for(jj=posinputs; cont<sizepos[0];jj++){
			cont++;
			for ( kk = &poshidden[varN->hidden]; cont1<varN->VnoOutputs; kk++){ 		// for hidden only
				cont1++;
				if (  ( rando() <= sigmaSCS )  &&  ( *jj >= 0 )  ){
					CW[*jj][*kk] = 1;
					numConn ++;
					//W[*jj][*kk] = 2.0 * (rando() - 0.5) * smallW;
				}
				if (numConn >= allowedConn){
					flagExit = 1;
					break;
				}

			}
			if ( flagExit )
				break;
			cont1=0;
		}

	}
	// dealocate, set to null
	jj = NULL;
	kk = NULL;
}///////////////////////////



void C_network::init_IH_modular(void){
	/*!
	 * Initialize the IH submatrice for pure modular archs.
	 * IF the connections are limited, it is take that into account
	 *
	 */

	// Local Var
	int *jj,*kk;
	int cont=0;
	int cont1=0;
	int allowedConn = 0;
	int numConn = 0;
	int flagExit = 0;

	// Check that the IH submatrix is not constrained in the number of connections
	allowedConn = ( int ) ( ( varN->finalInp * varN->hidden ) * CONN_ALLOWED_IH );

	if ( allowedConn > 0 ){

		// Initialize the Connections for the upper right triangle of the matrix, first part IH and IO
		for(jj=posinputs; cont<sizepos[0];jj++){
			cont++;
			for (kk=poshidden; cont1<varN->hidden; kk++){ 		// for hidden only
				cont1++;
				if (  ( rando() <= sigmaSCS )  &&  ( *jj >= 0 )  ){
					CW[*jj][*kk] = 1;
					numConn ++;
					//W[*jj][*kk] = 2.0 * (rando() - 0.5) * smallW;
				}
				if (numConn >= allowedConn){
					flagExit = 1;
					break;
				}

			}
			if ( flagExit )
				break;
			cont1=0;
		}

	}
	// dealocate, set to null
	jj = NULL;
	kk = NULL;
}/////////////////////////// modular end




void C_network::init_IO_modular(void){
	/*!
	 * Initialize the IO submatrice witht the simple connecitons scheme
	 * IF the connections are limited, it is take that into account
	 *
	 */

	// Local Var
	int *jj,*kk;
	int cont=0;
	int cont1=0;
	int allowedConn = 0;
	int numConn = 0;
	int flagExit = 0;

	// Check that the IH submatrix is not constrained in the number of connections
	allowedConn = ( int ) ( ( varN->finalInp * varN->VnoOutputs ) * CONN_ALLOWED_IO );

	if ( allowedConn > 0 ){
		// Initialize the Connections for the upper right triangle of the matrix, first part IH and IO
		for(jj=posinputs; cont<sizepos[0];jj++){
			cont++;
			for ( kk = &poshidden[varN->hidden]; cont1<varN->VnoOutputs; kk++){ 		// for hidden only
				cont1++;
				if (  ( rando() <= sigmaSCS )  &&  ( *jj >= 0 )  ){
					CW[*jj][*kk] = 1;
					numConn ++;
					//W[*jj][*kk] = 2.0 * (rando() - 0.5) * smallW;
				}
				if (numConn >= allowedConn){
					flagExit = 1;
					break;
				}

			}
			if ( flagExit )
				break;
			cont1=0;
		}

	}
	// dealocate, set to null
	jj = NULL;
	kk = NULL;
}/////////////////////////// modular ends




void C_network::init_HH_SCS(void){
	/*!
	 * Initialize the HH submatrice witht the simple connecitons scheme
	 * IF the connections are limited, it is take that into account
	 *
	 */

	// Local Var
	int *jj,*kk;
	int cont=0;
	int cont1=0;
	int allowedConn = 0;
	int numConn = 0;
	int flagExit = 0;

	// Check that the IH submatrix is not constrained in the number of connections
	//int places = 0;
//places = setupDivHidden();
	allowedConn = ( int ) ( setupDivHidden( varN->hidden )  * CONN_ALLOWED_HH );

	if ( allowedConn > 0 ){

		// Initialize the Connections for the upper right triangle of the matrix, first part IH and IO
		for(jj=poshidden; cont<varN->hidden -1; jj++){
			cont++;
			for ( kk = poshidden; cont1<varN->hidden; kk++){ 		// for hidden only
				cont1++;
				if(*kk > *jj){
					if (  ( rando() <= sigmaSCS )  &&  ( *jj >= 0 )  ){
						CW[*jj][*kk] = 1;
						numConn ++;
						//W[*jj][*kk] = 2.0 * (rando() - 0.5) * smallW;
					}
					if (numConn >= allowedConn){
						flagExit = 1;
						break;
					}
				}
			}
			if ( flagExit )
				break;
			cont1=0;
		}

	}
	// dealocate, set to null
	jj = NULL;
	kk = NULL;
}///////////////////////////




void C_network::init_HO_SCS(void){
	/*!
	 * Initialize the HO submatrice witht the simple connecitons scheme
	 * IF the connections are limited, it is take that into account
	 *
	 */

	// Local Var
	int *jj,*kk;
	int cont=0;
	int cont1=0;
	int allowedConn = 0;
	int numConn = 0;
	int flagExit = 0;

	// Check that the IH submatrix is not constrained in the number of connections
	allowedConn = ( int ) ( ( varN->hidden * varN->VnoOutputs ) * CONN_ALLOWED_HO );

	if ( allowedConn > 0 ){

		// Initialize the Connections for the upper right triangle of the matrix, first part IH and IO
		for(jj=poshidden; cont < varN->hidden; jj++){
			cont++;
			for ( kk = &poshidden[varN->hidden]; cont1<varN->VnoOutputs; kk++){
				cont1++;
				if (  ( rando() <= sigmaSCS )  &&  ( *jj >= 0 )  ){
					CW[*jj][*kk] = 1;
					numConn ++;
					//W[*jj][*kk] = 2.0 * (rando() - 0.5) * smallW;
				}
				if (numConn >= allowedConn){
					flagExit = 1;
					break;
				}

			}
			if ( flagExit )
				break;
			cont1=0;
		}

	}
	// dealocate, set to null
	jj = NULL;
	kk = NULL;
}///////////////////////////


void C_network::init_OO_SCS(void){
	/*!
	 * Initialize the OO submatrice witht the simple connecitons scheme
	 * IF the connections are limited, it is take that into account
	 *
	 */

	// Local Var
	int *jj,*kk;
	int cont=0;
	int cont1=0;
	int allowedConn = 0;
	int numConn = 0;
	int flagExit = 0;


	allowedConn = ( int ) ( setupDivHidden( varN->VnoOutputs)  * CONN_ALLOWED_OO );

	if ( allowedConn > 0 ){

		// Initialize the Connections for the upper right triangle of the matrix, first part IH and IO
		for(jj= &poshidden[varN->hidden]; cont<varN->VnoOutputs -1 ; jj++){
			cont++;
			for ( kk = &poshidden[varN->hidden]; cont1<varN->VnoOutputs; kk++){ 		// for hidden only
				cont1++;
				if(*kk > *jj){
					if (  ( rando() <= sigmaSCS )  &&  ( *jj >= 0 )  ){
						CW[*jj][*kk] = 1;
						numConn ++;
						//W[*jj][*kk] = 2.0 * (rando() - 0.5) * smallW;
					}
					if (numConn >= allowedConn){
						flagExit = 1;
						break;
					}
				}
			}
			if ( flagExit )
				break;
			cont1=0;
		}

	}
	// dealocate, set to null
	jj = NULL;
	kk = NULL;
}///////////////////////////


#endif
