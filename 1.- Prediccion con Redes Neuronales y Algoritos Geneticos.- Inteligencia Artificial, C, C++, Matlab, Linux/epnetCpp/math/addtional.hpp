/*!
 *  operationsVecMat.hpp
 * Created: 01/12/09
 * Here are all the funtions for operations with vector and matrices
 * set to zeros, min, max, ...
 * 
 */
#ifndef ADITIONAL_HPP
#define ADITIONAL_HPP

// take the last points, which will be use to predict the test set, return **set4predic
void takeInputAnn(double **inAnn,double **input1,int sizei, int *sizeInp, C_varN *var, int cols){
	// Inputs: ////////////////////////////////////////////////////////////////
	//			inAnn			place to save the new inputs to the ann
	//			input1			comple input file loaded, from here is taken the inputs to ann
	//			sizei			the last value taken in input1, is the last value in inANN
	//			sizeInp			it is save the sizes of the inANN[0:lines][1:cols]
	//			cols				number of colums in the input of the ANN, if it is 1 then probably was set up for MSP (but it couls be SSP), if it is >1 then was designed for SSM
	// Output	inAnn
	///////////////////////////////////////////////////////////////////////////

    register int i, j, k, cont = 0;
    int menos = var->delays;
    int inputs2count = 0;


    //here is ok var->inputs, it is taken a input vector from each coumn in the input vector in case it is a multivariable TS

    for(k = 0; k < cols; k++){																																					// number of patterns to take
    	for(i=k + (sizei-DeltaT)-((var->inputs * var->delays - menos));    inputs2count < var->inputs;     i+=var->delays){
    		for(j=0; j < var->Vfilecol; j++){
    			inAnn[cont][k] = input1[i][j]; //printf("i=%d , j=%d \n",i,j);
    			cont++;
    		}
    		inputs2count++;
    	}
    	sizeInp[0] = cont; 					// this variable is overwriten several times, but all with the same values,  change in the future
    	cont = 0;
    	inputs2count = 0;
    }


    sizeInp[1] = cols;

}//////////////////////////////////////////////////////////////////////////



// Function for predictin
int calculateSizesP_T(int sizeData, int *Spn, int *Stn, C_varN *var){

	int sizep;

	sizep = sizeData - var->VnoOutputs - DeltaT - ((var->inputs * (var->delays)) - var->delays) + 1;	//eq. correct rev.25/03/2010
	Spn[0] = var->finalInp;
	Spn[1] = sizep;
	Stn[0] = var->Vsizetpos;
	Stn[1] = sizep;
	return (sizep);
}

///////////////////////////////////////////////////////////////////////////


int separateSetsClassify(double **inp, double **p, double **t, int patterns, int sizeinp, C_varN *var){
	/*!
	 *  Inputs
	 *   inp					is the complete matrix with inputs and outputs, the columns are the patterns, the fisrt lines are the inputs and the last lines are the outputs
	 *   p						place to save the inputs
	 *   t 					place to save the targets
	 *   patterns			number of patterns to obtain (for p and t)
	 *   sizeinp			how many patterns there are in the file, i.e. columns
	 *   var					varaiables of the network, values used from here: how many inputs there are, so it can be separated the inputs and classes
	 *Outputs
	 * 		sizeinp			the new size to take in the future from inp, like size reduction, but inp is not touch
	 */
	int i,j,k,con,con2,contJ;

	con =0;				//count the columns
	con2 = 0;				// count the lines for t

	for(k =  sizeinp - patterns;  k < sizeinp; k++ ){
		for(i = 0; i < var->inputs; i++){
			p[i][con] = inp[i][k];
		}
		for(j = i; j < i+var->VnoOutputs; j++){
			t[con2][con] = inp[j][k];
			con2++;
		}
		contJ = j;
		con ++;
		con2 = 0;
	}

	// condition that check that everything was configured ok
	if( contJ != var->inputs + var->Vsizetpos){
		cout << "j = " << j << " var->inputs + var->Vsizetpos = " << var->inputs + var->Vsizetpos << endl;
		cout << "Error, there is not configured all right the variables, fun: separateSetsClassify in additional.hpp" << endl;
	}
	return (sizeinp - patterns);

}




// some functions that before where inside the main



///////// Section For Functions of the main ////////////////
//Determinate correct number of arguments
static void arguments(int argum)
{
	if(argum == 1){
        fprintf(stderr,"Error, You only write the name of the program, more parameters are required, e.g. mainepnet r1 > res/r1S.txt \n");
        exit(0);
	}
}


static void updateMutation(int Netwinner){
	switch(Netwinner){
	case 1:
		mutNodeDel ++;
		if(MYDEBUG_MAIN == 1)                         cout << "Replace the worst individual by the new offspring created with Delete hidden node" << endl;
		break;
	case 2:
		mutInputDel++;
		if(MYDEBUG_MAIN == 1)                         cout << "Replace the worst individual by the new offspring created with Delete input" << endl;
		break;
	case 3:
		mutDelayDel ++;
		if(MYDEBUG_MAIN == 1)                         cout << "Replace the worst individual by the new offspring created with Delete delay" << endl;
		break;
	case 4:
		mutConnDel++;
		if(MYDEBUG_MAIN == 1 ) 						cout << "Last network replaced by mutated network with delete connections" << endl;
		break;
	case 5:
		mutNodeAdd ++;
		if(MYDEBUG_MAIN == 1)                         cout << "Replace the worst individual by the new offspring created with Add hidden node" << endl;
		break;
	case 6:
		mutInpAdd++;
		if(MYDEBUG_MAIN == 1)                         cout << "Replace the worst individual by the new offspring created with Add input" << endl;
		break;
	case 7:
		mutDelayAdd ++;
		if(MYDEBUG_MAIN == 1)                         cout << "Replace the worst individual by the new offspring created with Add delay" << endl;
		break;
	case 8:
		mutConnAdd ++;
		if(MYDEBUG_MAIN == 1)                         cout << "Replace the worst individual by the new offspring created with Connection delay" << endl;
		break;
	case 9:
		mutSharedNodeDel ++;
		if(MYDEBUG_MAIN == 1)                         cout << "Replace the worst individual by the new offspring created with shared node deleted" << endl;
		break;

	case 10:
		mutSharedConnDel ++;
		if(MYDEBUG_MAIN == 1)                         cout << "Replace the worst individual by the new offspring created with shared Connection deletion" << endl;
		break;

	case 11:
		mutStrongConnAdd ++;
		if(MYDEBUG_MAIN == 1)                         cout << "Replace the worst individual by the new offspring created with Strong Connection addition" << endl;
			break;


	default:
		if(MYDEBUG_MAIN == 1) {
			cout << "There was not replaced any network in this generation, no mutaitons were preformed" << endl << " *** *** ** The selected network was only better than the last but it was not possible to perform any mutation" << endl;
			cout << "maybe you should check what happed, becuase it is suppose that aditions are accepted" << endl;
		}

	}
}////////////////////////////////////////////////////////////////////////////





static void correctInputOutput(int Outputs, int sizefile){
	if(Outputs > sizefile){
		cout << "Error, you are putting more outputs (targetPos) than the number of inputs" << endl << "Program Finished" << endl;
		exit(0);
	}
}
///////////////////////////////////////////////////////////////////////////










void obtainModuleInfo(void){
	/*!
	 * Fuction to obtain the Number of modules, name, outputs bounded to modules and the number of nodes per module
	 * All is saved in gloval variables and these values are used in class MODULE1 and probably MODULAR1
	 * In the constructor of network too, to initialize the number of learning rates per module
	 *
	 * NOTE: this fun is similar to  C_module1::findMod in file Cmodule1.hpp, any of both you modify check the other to see if all is working ok
	 */

	int i, j, cont;

	// Load the number of modules to be able to allocate space
	if (FileExists( NAMEMOD.c_str() ) == true)
		NUM_MODULES = loadVecInt( NAMEMOD.c_str() );
	else
		NUM_MODULES = 1;					// if the file does not exist, by default it is considered a normal evolution and there is only one module as a simple ANN

	// allocate variables as I know the number of modules
	NAME_MODULE = NULL;
	OUT_IN_MOD = NULL;									// which output is bounded to a module
	NUM_OUT_Per_MOD = NULL;

	NAME_MODULE = allocate(NAME_MODULE, NUM_MODULES);
	OUT_IN_MOD = allocate(OUT_IN_MOD, noOutputs); 					// noOutputs is a global var setuped in the main, until here it is not overwritten and it is valid
	NUM_OUT_Per_MOD = allocate(NUM_OUT_Per_MOD, NUM_MODULES);


	// Load the name of the modules and the outputs that belong to each module
	if (FileExists(  NAMEMOD.c_str() ) == true)						//  Load the name of the modules
		NUM_MODULES = loadVecInt( NAMEMOD.c_str() , NAME_MODULE); 											// it does not matter that NUM_MODULES gets overwritten
	else{
		NUM_MODULES = 1;
		NAME_MODULE[0] = 1;
	}

	// Load which output is linked to each module
	if (FileExists( OutputsInMod.c_str() ) == true ) {																// load the bounded modules
		int outputsLoaded = 0;

		outputsLoaded = loadVecInt( OutputsInMod.c_str() ,  OUT_IN_MOD);

		// Check that the outputs (bounded to a module) loaded are the same as the number of outputs in the nertwork
		if (outputsLoaded != noOutputs){
			cerr << "There is an error readind" << OutputsInMod.c_str() << "   function:   obtainModuleInfo called from main, exit " << endl;
			exit(0);
		}
	}
	else{
		// It is assumed that each output is boundded to a module, like breast data set and others
		// to avoid possibles error if there are several calssificaiton tasks, it could be possible to avoid this section and introduce always a file
		// describing which output are bounded to a module
		//cerr << " The file 'txtFiles/outputsInMod.txt' should exist and it was not found, exit with error code. Fun:  obtainModuleInfo called from main" << endl;
		//exit(0);

		// check the cases later and decide how it will be manage this values, for prediciton TS and breast cancer for example

		cout << " The file 'txtFiles/outputsInMod' does not exit. It will consider that each output is bounded to a different module " << endl;
		// all modules start in 1, execpt shared and isolated
		for ( j = 0; j < noOutputs; j++)
			OUT_IN_MOD[j] = j+1;

	}


	// Find how many outputs belong to each module
	for( i = 0; i < NUM_MODULES; i ++ ){ 							// for each module, they start in 1
		cont = 0;
		for ( j = 0; j < noOutputs; j++){									// check all outputs bounded to each module (for every module) to know how many outputs are in each module
			if ( NAME_MODULE[i] ==  OUT_IN_MOD[j] )
				cont++;
		}
		NUM_OUT_Per_MOD[i] =  cont;
	}


}

#endif
