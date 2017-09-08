/*!
 * C_ALLParam.hpp
 *
 * Created: 	26 Nov 2009
 * Modified:	11 Mar 2011
 * Author:		Carlos Torres and Victor Landassuri
 *
 * Class to save the values per generation of the algorithm
 * In the future I could create derived classes for each algorithm/method used in which each one only have the code if its own to save the inned variables
 * I do not know if that is possible given the flow information in the algorithm
 */

#ifndef C_ALLPARAM_HPP
#define C_ALLPARAM_HPP

class C_ALLParam{
// Purpose: save the next variables in every generation of the algotihm
public:
	int *Selected;                                 //arrays[1][generations]
	double *bestfitness;
	double *worstfitness;
	double *Avfitness;						// This will be the compound error from all the evaluations
	double *AvfitnessReal;						// This will be the compound error from all the evaluations
	//double **AllpopFitness;
	double *AvaccuracyValI;
	//double *AvIterateNRMS_I;
	double *Avinputs;
	double *Avhidden;
	double *Avconnections;

	double *Avdelays;
	double **AvErrori;				// in this error is saved in each row the Av error for each scale evaluated

	double **Avlrate;

	/*double *AvfitnessHalf;
	double *AvinputsHalf;
	double *AvhiddenHalf;
	double *AvconnectionsHalf;
	double *AvdelaysHalf;
	*/


	int  *EvalpRun;

	// to measure the mutations
	int *MutHT;
	int *MutMBP;
	int *MutSA;

	// variables for the architectural mutations
	int *MutNodeDel;
	int *MutInputDel;
	int *MutDelayDel;
	int *MutConnDel;

	int *MutNodeAdd;
	int *MutInpAdd;
	int *MutDelayAdd;
	int *MutConnAdd;

	int *MutSharedNodeDel;
	int *MutSharedConnDel;
	int *MutStrongConnAdd;

	// for classification
	double *AvClassifError;
	double *bestClassifError;

	// for the module1
	double *AvMweight;
	double *AvMarch;
	double *AvNoSharedNodes;
	double *AvNoSharedConn;
	double *AvIsolatedNodes; 				// isolated nodes from outputs and inputs

	// Note that the fitness per module only could be applied to the classificaton tasks assuming that
	// it is well knonw the number of modules, so the modulas are always fixed
	// Modules created with shared nodes or isolated nodes does not affect as they are like internal modules created,
	// but the modules' outputs remain teh same (outputs of the network)
	// For perdiction is not possible to do this as the number of internal modules could vary from 1 to n
	double **AvFitnessPerModule;
	double **AvClassErrPerModle;
	double **AvNodesPerModule;							// shared and isolated nodes already saved, now it ihe turn for the number of nodes in each module

	double **NodesReusedPerMod;

    //Constructor
    C_ALLParam();
    //Destructor
    ~C_ALLParam();

    //to print
    void print(void);

    //To save into a file
    void save2file(FILE *, char [], int);

    //SAve all info per generaton
    void saveAllperGen(int , int , C_network * []);

};


//Constructor
C_ALLParam::C_ALLParam(){

	// first clear the values to be sure that they do not point to anywhere, to mantain consistency
	Selected = NULL;
	bestfitness = NULL;
	worstfitness = NULL;
	Avfitness = NULL;
	AvfitnessReal = NULL;
	//AllpopFitness = NULL;
	AvaccuracyValI = NULL;
	//AvIterateNRMS_I = NULL;
	Avinputs = NULL;
	Avhidden = NULL;
	Avconnections = NULL;

	Avdelays = NULL;
	AvErrori = NULL;

	Avlrate = NULL;

	/*AvfitnessHalf = NULL;
	AvinputsHalf = NULL;
	AvhiddenHalf = NULL;
	AvconnectionsHalf = NULL;
	AvdelaysHalf = NULL;*/
	EvalpRun = NULL;

	MutHT= NULL;
	MutMBP= NULL;
	MutSA= NULL;

	// variables for the architectural mutations
	MutNodeDel= NULL;
	MutInputDel= NULL;
	MutDelayDel= NULL;
	MutConnDel= NULL;

	MutNodeAdd= NULL;
	MutInpAdd= NULL;
	MutDelayAdd= NULL;
	MutConnAdd= NULL;

	MutSharedNodeDel = NULL;
	MutSharedConnDel = NULL;
	MutStrongConnAdd = NULL;

	// for classification
	AvClassifError = NULL;
	bestClassifError = NULL;

	// for the module1
	AvMweight = NULL;
	AvMarch = NULL;
	AvNoSharedNodes = NULL;
	AvIsolatedNodes = NULL;


	AvNoSharedConn = NULL;
	AvFitnessPerModule = NULL;
	AvClassErrPerModle = NULL;
	AvNodesPerModule = NULL;

	// reuse modules
	NodesReusedPerMod = NULL;
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	//Initialize the vectors to the adecuate size, all filled with zeros
	Selected = allocate(Selected, expectedGenerations);
	bestfitness = allocate(bestfitness, expectedGenerations);
	worstfitness = allocate(worstfitness, expectedGenerations);
	Avfitness = allocate(Avfitness, expectedGenerations);
	AvfitnessReal = allocate(AvfitnessReal, expectedGenerations);
	//AllpopFitness = allocate(AllpopFitness, populationNum, expectedGenerations);
	AvaccuracyValI = allocate(AvaccuracyValI, expectedGenerations);
	//AvIterateNRMS_I = allocate(AvIterateNRMS_I, expectedGenerations);
	Avinputs = allocate(Avinputs, expectedGenerations);
	Avhidden = allocate(Avhidden, expectedGenerations);
	Avconnections = allocate(Avconnections, expectedGenerations);

	Avlrate = allocate(Avlrate, NUM_MODULES, expectedGenerations);

	Avdelays = allocate(Avdelays, expectedGenerations);

	if(trainMultipleSets == ON)
		AvErrori = allocate(AvErrori,7,expectedGenerations);							// & because there are seven scales tested

	/*AvfitnessHalf = allocate(AvfitnessHalf, expectedGenerations);
	AvinputsHalf = allocate(AvinputsHalf, expectedGenerations);
	AvhiddenHalf = allocate(AvhiddenHalf, expectedGenerations);
	AvconnectionsHalf = allocate(AvconnectionsHalf, expectedGenerations);
	AvdelaysHalf = allocate(AvdelaysHalf, expectedGenerations);*/

	EvalpRun = allocate(EvalpRun,expectedGenerations);

	MutHT= allocate(MutHT, expectedGenerations);
	MutMBP= allocate(MutMBP, expectedGenerations);
	MutSA= allocate(MutSA, expectedGenerations);

	// variables for the architectural mutations
	MutNodeDel= allocate(MutNodeDel, expectedGenerations);
	MutInputDel= allocate(MutInputDel, expectedGenerations);
	MutDelayDel= allocate(MutDelayDel, expectedGenerations);
	MutConnDel= allocate(MutConnDel, expectedGenerations);

	MutNodeAdd= allocate(MutNodeAdd, expectedGenerations);
	MutInpAdd= allocate(MutInpAdd, expectedGenerations);
	MutDelayAdd= allocate(MutDelayAdd, expectedGenerations);
	MutConnAdd= allocate(MutConnAdd, expectedGenerations);

	// For evolution of modules using MODULAR1 algorithm
	if ( algoFeatures == MODULAR1 ){
		MutSharedNodeDel = allocate(MutSharedNodeDel, expectedGenerations);
		MutSharedConnDel = allocate(MutSharedConnDel, expectedGenerations);
		MutStrongConnAdd = allocate(MutStrongConnAdd, expectedGenerations);
	}

	// for classification
	if ( task2solve == CLASSIFY ){
		AvClassifError = allocate(AvClassifError, expectedGenerations);
		bestClassifError = allocate(bestClassifError, expectedGenerations);
	}

	// for the module1
	if (isModule1 == ON){
		AvMweight =  allocate(AvMweight, expectedGenerations);
		AvMarch =  allocate(AvMarch, expectedGenerations);
		AvNoSharedNodes =  allocate(AvNoSharedNodes, expectedGenerations);
		AvIsolatedNodes = allocate(AvIsolatedNodes, expectedGenerations);

		AvNoSharedConn =  allocate(AvNoSharedConn, expectedGenerations);

		//if ( NUM_MODULES > 1 ){
			AvFitnessPerModule =  allocate(AvFitnessPerModule, NUM_MODULES, expectedGenerations);
			AvNodesPerModule = allocate(AvNodesPerModule, NUM_MODULES, expectedGenerations);
		//}
		// The fitness of each module
		if ( task2solve == CLASSIFY ){
			AvClassErrPerModle = allocate(AvClassErrPerModle, NUM_MODULES, expectedGenerations);
		}
	}


	if ( reuseModule == ON)
		NodesReusedPerMod = allocate(NodesReusedPerMod, NUM_MODULES,expectedGenerations);    // note that in the husken module there may be moere, update this if used for predicitn tasks with nets with one output

} // End Constructur ALLParam



C_ALLParam::~C_ALLParam(){

	if ( reuseModule == ON)
			safefree(&NodesReusedPerMod,  NUM_MODULES);

	// for the module1
	if (isModule1 == ON){
		safefree(&AvFitnessPerModule, NUM_MODULES);
		safefree(&AvNodesPerModule, NUM_MODULES);

		if ( task2solve == CLASSIFY  )
			safefree(&AvClassErrPerModle, NUM_MODULES);



		safefree(&AvNoSharedConn);

		safefree(&AvMweight);
		safefree(&AvMarch);
		safefree(&AvNoSharedNodes);
		safefree(&AvIsolatedNodes);
	}

	// for classification
	if ( task2solve == CLASSIFY ){
		safefree(&bestClassifError);
		safefree(&AvClassifError);
	}

	/// variables for the architectural mutations

	// Evoluiton of modules 1
	if ( algoFeatures == MODULAR1 ){
		safefree(&MutSharedNodeDel);
		safefree(&MutSharedConnDel);
		safefree(&MutStrongConnAdd);
	}

	// normal variables
	safefree(&MutConnAdd);
	safefree(&MutDelayAdd);
	safefree(&MutInpAdd);
	safefree(&MutNodeAdd);

	safefree(&Avlrate,NUM_MODULES);

	safefree(&MutConnDel);
	safefree(&MutDelayDel);
	safefree(&MutInputDel);
	safefree(&MutNodeDel);



	safefree(&Avdelays);

	if(trainMultipleSets == ON)
		safefree(&AvErrori,7);

	/*safefree(&AvfitnessHalf);
	safefree(&AvinputsHalf);
	safefree(&AvhiddenHalf);
	safefree(&AvconnectionsHalf);
	safefree(&AvdelaysHalf);*/
	safefree(&EvalpRun);

	safefree(&MutSA);
	safefree(&MutMBP);
	safefree(&MutHT);

	safefree(&Avconnections);
	safefree(&Avhidden);
	safefree(&Avinputs);

	//safefree(&AvIterateNRMS_I);
	safefree(&AvaccuracyValI);
	//safefree(&AllpopFitness,populationNum);
	safefree(&Avfitness);
	safefree(&AvfitnessReal);
	safefree(&worstfitness);
	safefree(&bestfitness);

	safefree(&Selected);
}


//this method form C_ALLParam is fro test onlym dlete if needed
void C_ALLParam::print(void){
	// not updated
	// .....

	/*cout << "Selected" << endl;
    imprime(Selected, expectedGenerations);
    
    cout << "bestfitness" << endl;
    imprime(bestfitness, expectedGenerations);
    
    cout << "worstfitness" << endl;
    imprime(worstfitness, expectedGenerations);
    
    cout << "Avfitness" << endl;
    imprime(Avfitness, expectedGenerations);

    cout << "AllpopFitness" << endl;
    imprime(AllpopFitness, populationNum, expectedGenerations);
    
	cout << "AvaccuracyValI" << endl;
	imprime(AvaccuracyValI, expectedGenerations);
        
	cout << "AvIterateNRMS_I" << endl;
	imprime (AvIterateNRMS_I, expectedGenerations);
        
	cout << "Selected" << endl;
	imprime(Avinputs, expectedGenerations);
    
	cout << "Selected" << endl;
	imprime(Avhidden, expectedGenerations);
    
	cout << "Selected" << endl;
	imprime(Avconnections, expectedGenerations);
    
	cout << "Selected" << endl;
	imprime(Avhybridtraining, expectedGenerations);
    
	cout << "AvconnDel" << endl;
	imprime(AvconnDel, expectedGenerations);
    
	cout << "AvnodeAdd" << endl;
	imprime(AvnodeAdd, expectedGenerations);
		
	cout << "AvconnAdd" << endl;
	imprime(AvconnAdd, expectedGenerations);*/
    }




void C_ALLParam::save2file(FILE *fwrite, char file[], int gen){
	///// Selected  ///////////////////////////////////////////////////////
    saveInt(Selected, gen, fwrite, file);
    // bestfitness ///////////////////////////////////////////////////////
    saveD(bestfitness, gen, fwrite, file);
    // worstfitness ///////////////////////////////////////////////////////
    saveD(worstfitness, gen, fwrite, file);
    // Avfitness ///////////////////////////////////////////////////////
    saveD(Avfitness, gen, fwrite, file);
    saveD(AvfitnessReal, gen, fwrite, file);
    // AllpopFitness;
    //saveD(AllpopFitness, populationNum, gen, fwrite, file);
    // AvaccuracyVal ///////////////////////////////////////////////////////
    saveD(AvaccuracyValI, gen, fwrite, file);
    // AvIterateNRMSE_I ///////////////////////////////////////////////////////
    //saveD(AvIterateNRMS_I, gen, fwrite, file);
    // Avinputs ///////////////////////////////////////////////////////
    saveD(Avinputs, gen, fwrite, file);
    // Avhidden ///////////////////////////////////////////////////////
    saveD(Avhidden, gen, fwrite, file);
    // Avconnections ///////////////////////////////////////////////////////
    saveD(Avconnections, gen, fwrite, file);

    ///////////////////////////////////////////////////////////////////////
            /// Put a band to look for error  //finish ALLparam
            if((fprintf(fwrite, "%d\t",BAND)) == EOF){
                printf("Error writing to file '%s' in C_ALLParam::save2file...\n",file); exit(0);
             }
            ///////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////

    saveD(Avlrate, NUM_MODULES, gen, fwrite, file);

    ///////////////////////////////////////////////////////////////////////
    /// Put a band to look for error  //finish ALLparam
               if((fprintf(fwrite, "%d\t",BAND)) == EOF){
                   printf("Error writing to file '%s' in C_ALLParam::save2file...\n",file); exit(0);
                }
               ///////////////////////////////////////////////////////////////////////
               ///////////////////////////////////////////////////////////////////////


    // new variables inserted
    saveD(Avdelays, gen, fwrite, file);

    if(trainMultipleSets == ON)
    	saveD(AvErrori,7,gen,fwrite,file);

    /*saveD(AvfitnessHalf,gen, fwrite, file);
    saveD(AvinputsHalf, gen, fwrite, file);
    saveD(AvhiddenHalf, gen, fwrite, file);
    saveD(AvconnectionsHalf, gen, fwrite, file);
    saveD(AvdelaysHalf, gen, fwrite, file);*/



    saveInt(EvalpRun,gen,fwrite,file);

    // Even this param in not from this calls, it is saved to a file here
    fprintf(fwrite, "%d\t",totalEval);


    // MutHT ///////////////////////////////////////////////////////
    saveInt(MutHT, gen, fwrite, file);
    // MutMBP ///////////////////////////////////////////////////////
    saveInt(MutMBP, gen, fwrite, file);
    // MutSA ///////////////////////////////////////////////////////
    saveInt(MutSA, gen, fwrite, file);

    // MutNodeDel ///////////////////////////////////////////////////////
    saveInt(MutNodeDel, gen, fwrite, file);
    // MutInputDel ///////////////////////////////////////////////////////
    saveInt(MutInputDel, gen, fwrite, file);
    // MutDelayDel ///////////////////////////////////////////////////////
    saveInt(MutDelayDel, gen, fwrite, file);
    // MutConnDel ///////////////////////////////////////////////////////
    saveInt(MutConnDel, gen, fwrite, file);

    // MutNodeAdd ///////////////////////////////////////////////////////
    saveInt(MutNodeAdd, gen, fwrite, file);
    // MutInpAdd ///////////////////////////////////////////////////////
    saveInt(MutInpAdd, gen, fwrite, file);
    // MutDelayAdd ///////////////////////////////////////////////////////
    saveInt(MutDelayAdd, gen, fwrite, file);
    // MutConnAdd ///////////////////////////////////////////////////////
    saveInt(MutConnAdd, gen, fwrite, file);

    if ( algoFeatures == MODULAR1 ){
    	// Mut shared node deletion ///////////////////////////////////////////////////////
    	saveInt(MutSharedNodeDel, gen, fwrite, file);
    	// Mut shared connection deletion ///////////////////////////////////////////////////////
    	saveInt(MutSharedConnDel, gen, fwrite, file);

    	// Mut strong connection addition ///////////////////////////////////////////////////////
    	saveInt(MutStrongConnAdd, gen, fwrite, file);

    }



    if (task2solve == CLASSIFY){
    	saveD(AvClassifError, gen, fwrite, file);
    	saveD(bestClassifError, gen, fwrite, file);
    }

    if ( isModule1 == ON){
    	saveD(AvMweight, gen, fwrite, file);
    	saveD(AvMarch, gen, fwrite, file);
    	saveD(AvNoSharedNodes, gen, fwrite, file);
    	saveD(AvIsolatedNodes,gen,fwrite,file);

    	saveD(AvNoSharedConn, gen,fwrite,file);

    	saveD(AvFitnessPerModule, NUM_MODULES, gen,fwrite,file);
    	saveD(AvNodesPerModule, NUM_MODULES, gen,fwrite,file);

    	if ( task2solve == CLASSIFY  )
    		saveD(AvClassErrPerModle, NUM_MODULES, gen,fwrite,file);

    }


    if ( reuseModule == ON)
    		saveD(NodesReusedPerMod, NUM_MODULES, gen,fwrite,file);

    ///////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////
    /// Put a band to look for error  //finish ALLparam
    if((fprintf(fwrite, "%d\t",BAND)) == EOF){
        printf("Error writing to file '%s' in C_ALLParam::save2file...\n",file); exit(0);
     }
    ///////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////
}


//obtain and save averages values per generation
void C_ALLParam::saveAllperGen(int gen, int selec, C_network *pop[]  )
{
    register int i, ii, tam = 0;


    // take average for fitness values and accuracies, not take into account the last individuals, at lesat the last two,
    // because they make bigger the Av values as the are always the worst
    for(i=0; i<populationNum - avFitness_minus; i++){
    	//AvIterateNRMS_I[gen] += pop[i]->fitness[0];  // it is the same a the fitness, leave for now, it could be removed in the future
    	Avfitness[gen] += pop[i]->fitness[0];
    	AvfitnessReal[gen] += pop[i]->fitnessReal[0];
    	AvaccuracyValI[gen] += pop[i]->predictI->accuracy[0];

    	// save the AvErrori
    	if(trainMultipleSets == ON){
    		for( ii=0; ii< 7; ii++){
    			AvErrori[ii][gen] += pop[i]->Errori[ii];
    		}
    	}

    	// For classification
    	if ( task2solve == CLASSIFY )
    		AvClassifError[gen] += pop[i]->predictI->classifError;

    	// Save values related to the outputs or modules, not there there may be more modules (isolated nodes and shared nodes) but they are not considered here
    	// as it is done for classification tasks, it is ensure that the number of modules is the number declarated in files: nameModules.txt and outputsInMod.txt
    	for (ii = 0; ii < NUM_MODULES; ii ++)
    			AvFitnessPerModule[ii][gen] += pop[i]->predictI->EpercentagePerModule[ii] ; 			// take the av error per module for each network


    	if ( task2solve == CLASSIFY  )
    		for (ii = 0; ii < NUM_MODULES; ii ++)
    			AvClassErrPerModle[ii][gen] += pop[i]->predictI->classifErrorPerModule[ii];


    }



    // Take averages for the complete population
    for(i=0; i<populationNum- avFitness_minus; i++){


        // Special case to count the inputs if they a re fixed and evolved with the asymmetric algorithm
        Avinputs[gen] += countNodesVec(pop[i]->nodes, pop[i]->sizepos[0] );    // I can implement this too summing all the values of the vector
        //Avinputs[gen] += pop[i]->sizepos[0];

        Avhidden[gen] += pop[i]->varN->hidden;
        Avdelays[gen] += pop[i]->varN->delays;

        //to obtain average of connections
        tam = pop[i]->varN->finalInp + pop[i]->varN->hidden + pop[i]->varN->VnoOutputs;
        Avconnections[gen] += countConnNet(pop[i]->CW, pop[i]->bias, tam);

        // for the average learning rate, normal or per modules
       for (ii = 0; ii<NUM_MODULES; ii++)
    	   Avlrate[ii][gen] += pop[i]->singleLrate[ii];

        //Save the fitness from all individual in the population
        //AllpopFitness[i][gen] = pop[i]->fitness[0];




        // For the module1
        if( isModule1 == ON){
        	AvMweight[gen] += pop[i]->huskenModule->MweightTD;
        	AvMarch[gen] += pop[i]->huskenModule->MarchTD;

        	// Check if there is a shared Module, look for the shared module
        	for ( ii = 0; ii < pop[i]->sharedModule->noModules; ii++){
        		if (pop[i]->sharedModule->nameModule[ii] == -1){
        			// index ii has the shared module
        			AvNoSharedNodes[gen] += pop[i]->sharedModule->countNodesPerModule[ii];
        			break;
        		}
        	}

        	// Take the shared connections
        	AvNoSharedConn[gen] += pop[i]->obtaintNUMSharedConn();

        	 // Save values related to the outputs or modules, not there there may be more modules (isolated nodes and shared nodes) but they are not considered here
        	// as it is done for classification tasks, it is ensure that the number of modules is the number declarated in files: nameModules.txt and outputsInMod.txt
        	//if ( task2solve == CLASSIFY  ){
        		for (ii = 0; ii < NUM_MODULES; ii ++)
        			AvNodesPerModule[ii][gen] += pop[i]->huskenModule->countNodesPerModule[ii];
        	//}

        	// For the isolated nodes
        	AvIsolatedNodes[gen] += pop[i]->huskenModule->noIsolatedNodes;

        } // End if module1


        if ( reuseModule == ON){
        	for (ii = 0; ii < NUM_MODULES; ii ++)
        		NodesReusedPerMod[ii][gen] +=  pop[i]->huskenModule->nodesReusedPerMod[ii];
        }

    } // End the sum of all varibales from all the population



    // T a k e    t h e    a v e r a g e

    //AvIterateNRMS_I[gen] /= populationNum;

    Avfitness[gen] /= populationNum - avFitness_minus;
    AvfitnessReal[gen] /= populationNum - avFitness_minus;
    AvaccuracyValI[gen] /= populationNum - avFitness_minus;
    Avinputs[gen] /= populationNum - avFitness_minus;
    Avhidden[gen] /= populationNum - avFitness_minus;
    Avdelays[gen] /= populationNum - avFitness_minus;
    Avconnections[gen] /= populationNum - avFitness_minus;

    for (ii = 0; ii<NUM_MODULES; ii++)
    	Avlrate[ii][gen] /= populationNum - avFitness_minus;

    if(trainMultipleSets == ON){
    	for(int ii=0; ii< 7; ii++){
    		AvErrori[ii][gen] /= populationNum - avFitness_minus;
    	}
    }

    // Classification
    if ( task2solve == CLASSIFY )
    	AvClassifError[gen] /= populationNum - avFitness_minus;

    // Module1
    if( isModule1 == ON){
    	AvMweight[gen] /= populationNum - avFitness_minus;
    	AvMarch[gen] /= populationNum - avFitness_minus;
    	AvNoSharedNodes[gen] /= populationNum - avFitness_minus;

    	AvNoSharedConn[gen] /= populationNum - avFitness_minus;

    	for (ii = 0; ii < NUM_MODULES; ii ++){
    		AvFitnessPerModule[ii][gen] /= populationNum - avFitness_minus;
    		AvNodesPerModule[ii][gen] /= populationNum - avFitness_minus;
    	}

    	// The fitness / error per module
    	if ( task2solve == CLASSIFY  ){
    		for (ii = 0; ii < NUM_MODULES; ii ++)
    			AvClassErrPerModle[ii][gen] /= populationNum - avFitness_minus;
    	}

    	AvIsolatedNodes[gen] /= populationNum - avFitness_minus;
    }


    if ( reuseModule == ON){
    	for (ii = 0; ii < NUM_MODULES; ii ++)
    		NodesReusedPerMod[ii][gen] /= populationNum - avFitness_minus;
    }

    ///////////////////////////////////////////////////////////////////////////////////



    // Take averages for the FIRST 5 IND
   /* for(i=0; i< 5; i++){
    	AvfitnessHalf[gen] += pop[i]->fitness[0];
    	AvinputsHalf[gen] += pop[i]->sizepos[0];
    	AvhiddenHalf[gen] += pop[i]->sizepos[1];
    	AvdelaysHalf[gen] += pop[i]->varN->delays;

    	//to obtain average of connections
    	tam = pop[i]->varN->finalInp + pop[i]->varN->hidden + pop[i]->varN->VnoOutputs;
    	AvconnectionsHalf[gen] += countConnNet(pop[i]->CW, pop[i]->bias, tam);
    }
    AvfitnessHalf[gen] /= 5;
    AvinputsHalf[gen] /= 5;
    AvhiddenHalf[gen] /= 5;
    AvdelaysHalf[gen] /= 5;
    AvconnectionsHalf[gen] /= 5;*/
    //////////////////////////////////////////////////////////////////////////////////

    /// Save the Mutations ////////////////////////////////
    MutHT[gen] = mutHT;
    MutMBP[gen] = mutMBP;
    MutSA[gen] = mutSA;

    // variables for the architectural mutations
    MutNodeDel[gen] = mutNodeDel;
    MutInputDel[gen] = mutInputDel;
    MutDelayDel[gen]  = mutDelayDel;
    MutConnDel[gen]  = mutConnDel;

    MutNodeAdd[gen]  = mutNodeAdd;
    MutInpAdd[gen] = mutInpAdd ;
    MutDelayAdd[gen] = mutDelayAdd;
    MutConnAdd[gen] = mutConnAdd;

    // Evoluiton of modules 1
    if ( algoFeatures == MODULAR1 ){
    	MutSharedNodeDel[gen] = mutSharedNodeDel;
    	MutSharedConnDel[gen] = mutSharedConnDel;
    	MutStrongConnAdd[gen] = mutStrongConnAdd;
    }
    /////////////////////////////////////////////////////////////////////

    Selected[gen] = selec;
    bestfitness[gen] = pop[0]->fitness[0];
    worstfitness[gen] = pop[populationNum-1 - avFitness_minus]->fitness[0];

    EvalpRun[gen] = evaluationsPrun;
    // clean the varibale to start a new count in the next gen
    evaluationsPrun = 0;

    if ( task2solve == CLASSIFY )
    	bestClassifError[gen] = pop[0]->predictI->classifError;

}//////////////////////////////////////////////////////////////////////////


#endif
