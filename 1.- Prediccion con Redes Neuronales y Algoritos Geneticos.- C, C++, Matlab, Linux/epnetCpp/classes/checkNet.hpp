/*!
 * checkNet.hpp
 *
 * Continuation of the methods from the network class
 * Here are the function that validate a network looking for isolated nodes (hidden and outputs)
 *
 * Created: 	27 Feb 2011
 * modified:
 * Author:  	Carlos Torres and Victor Landassuri
 *  *
 */

#ifndef 	CHECKNET_HPP
#define CHECKNET_HPP



void C_network::checkValidNet(void){
	/*!
	 *
	 * This function is called every time that is created the network or deleted an input or hidden node
	 * 	The purpose is to avoid to have invalid networks
	 *
	 * This works with GMLP and MLP ( 1 layer only)
	 * It does not matter that the connectivity is constrained, if one or two connections ae added it is not significant
	 *
	 *	Arguments			nothing
	*  Returned values		return a code error:
	* 						1 last layer empty
	*						2 there is no connection (path) from inputs to output node
	*/

	int O;
	int H;

	// Check isolated outputs GMLP or MLP
	O = checkNet_O();

	// Check isolated hidden nodes
	if ( IS_MLP == OFF ) 		// GMLP
		H = checkNet_H_GMLP();
	else
		H = checkNet_H(); 			// MLP



} /////////////////////////////////////////////////////////////////////////////////////////////////////


int C_network::checkNet_O(void){
	/*!
	 * Function to see if any output is isolated from hidden or inputs (GMLP or MLP)
	 * Only works for MLP with 1 hidden layer in this moment
	 */

	// Local variables
	int cont = 0, allnodesNet = 0, i = 0, j=0;
	int initNode = 0;											// initial node to count
	int lastNode = 0;
	int pos2add  =0;

	allnodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;
	//cout << "CW.... ==== **** >) >) :) :) ;)" << endl; imprime(CW,allnodesNet,allnodesNet);

	// Check that the last layer is not empty ///////////////////////
	//imprime(CW,allnodesNet,allnodesNet);

	if ( IS_MLP == OFF ){ 					//GMLP
		initNode = 0;
		lastNode = varN->finalInp + varN->hidden;
	}
	else{												// MLP ... works for 1 or n layers
		initNode = poshidden[0];
		lastNode = varN->finalInp + varN->hidden;
	}


	// Check isolated outputs
	for ( j = poshidden[varN->hidden] ; j <= poshidden[varN->hidden + varN->VnoOutputs -1] ; j ++){ 								// for all outputs
		cont = 0;
		for(i = initNode; i < lastNode ; i++){
			if(CW[i][j] == 1){ 								// if there is at least one inbound connection
				cont ++;
				break;
			}
		}
		if(cont == 0){  										// if this output does not have any connection
			// add at random one input

			if ( IS_MLP == OFF )											// GMLP
				pos2add  = (int) ( (varN->finalInp+varN->hidden)  * rando()); 									// add a possition only from inputs and hidden nodes to output nodes, OO is not considered
			else																		// MLP
				pos2add  = (int) ( varN->finalInp + (  (  (varN->finalInp+varN->hidden)  -  varN->finalInp)  *  rando() ) );

			CW[ pos2add ][ j ] = 1;
			W[ pos2add ][ j ] = 2.0 * (rando() - 0.5) * smallW;
			cout << "Fuction checkValidNet, layer : " << j << " did not have any inbound connection " << endl << "Pos added in : [  " << pos2add << " ][ " << j << " ]" << endl;
			// adding an input is not a rule to say that the network is valid as one hidden node may be isolated from inputs
			// in this moment is not validated that

			//imprime(CW,allnodesNet,allnodesNet);
		}

	}
	if (cont == 0)
		return 1;
	else
		return 0;

}/////////////////////////////////////////









int C_network::checkNet_H(void){
	/*!
	 * Function that check hidden nodes, here each hidden nodes should have at least one inboud connection from inputs
	 * Designed for 1 hidden layer only in MLP
	 */


	// Local variables
	int cont = 0, allnodesNet = 0, i = 0, j=0;
	int pos2add  =0;

	allnodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;

	// Until here it is sure that all outputs have at least one inbound connections
	// Do the same for hidden nodes, each one should have at least one connection from one input
	// This avoid isolated nodes
	// Comment this if you want to measure them

	//imprime(CW,allnodesNet,allnodesNet);

	// Check isolated outputs
	for ( j = varN->finalInp ; j < varN->finalInp + varN->hidden ; j ++){ 								// for all hidden nodes
		cont = 0;
		for(i = 0; i < varN->finalInp ; i++){
			if(CW[i][j] == 1){ 								// if there is at least one inbound connection
				cont ++;
				break;
			}
		}
		if(cont == 0){  										// if this hidden does not have any connection
			// add at random one inbound connection

			pos2add  = (int) ( (varN->finalInp  *  rando() ) );

			CW[ pos2add ][ j ] = 1;
			W[ pos2add ][ j ] = 2.0 * (rando() - 0.5) * smallW;
			cout << "Fuction checkValidNet, layer : " << j << " did not have any inbound connection " << endl << "Pos added in : [  " << pos2add << " ][ " << j << " ]" << endl;
			// adding an input is not a rule to say that the network is valid as one hidden node may be isolated from inputs
			// in this moment is not validated that

			//imprime(CW,allnodesNet,allnodesNet);
		}

	}

	return 0;
}///////////////////////////////


int C_network::checkNet_H_GMLP(void){
	/*!
	 *
	 * For the moment it is not used anything
	 */
/*
	// Local var
	int allnodesNet,i,j,k;
	int flag_IH = 1;
	int flag_HH = 1;
	int flag_HO = 1;

	allnodesNet = varN->finalInp + varN->hidden + varN->VnoOutputs;

	// Check that there is a path from at least one input to the last layer

	// check that one input is connected to a  hidden node and this node is connected to the output
	for(i = 0; i<sizepos[0]; i++){							// move through all inputs
		for( j = sizepos[0]; j< allnodesNet - 1 - varN->VnoOutputs; j++){
			if(CW[i][j] == 1){
				flag_IH = 0;
				//check that this node has a connection with at least one output
				for ( k = poshidden[varN->hidden] ; k < allnodesNet ; k++ ){					// all outputs
					if(CW[ j ][ k ] == 1)
						flag = 0;
					else{
						flag = 1;
					}
				}
			}
		}
	}


		// if the for(s) finish and arrive until here, means that there is not a direct path
		// from an input through hidden nodes to the output

		// then add one input at random to the final layer (simplest case)
		// add at random one input
		int pos2add  = (int) ( (posinputs[0]+1) * rando()); // all inputs
		CW[pos2add][allnodesNet - 1] = 1;
		W[pos2add][(allnodesNet - 1)] = 2.0 * (rando() - 0.5) * smallW;
		cout << "Fuction checkValidNet, no connection from input to output layer through hidden nodes, one connection added at random from input to last layer" << endl;
		cout << "Pos added in the line = " << pos2add << endl;
		//imprime(W,allnodesNet,allnodesNet);
		return 2;
*/
	return 0;

}

#endif
