/*!
 * mainepnet.hpp
 *
 * File to setup many parameters before the evolution starts.
 * This file configure each experiment for a general purpose for all TS or data sets used
 *
 * Prediction
 *
 * You can use the Tournament mutations
 * 	Hierarquical mutations
 * Co-evo
 * Fixed inputs or evolved, fixed with the VRA or another values
 * Train a network with multiple data set
 *
 * INPUT FILE
 * The file to be read it is assumed to use all the information that it contais
 * if it has 1 column, this column is used to be predicted, check targetPpos in the main
 * if the file has 'n' columns, all the data is used and the value to be predicted depend
 * of targetPos variable.
 *
 *
 * RANGE OF NORMALIZATION
 * The data is normalized with Matlab, the data loaded here is already normalized
 * For prediciton could be any range between 1 to 7, i.e. [-0.1, 0.1] to [-0.7,0.7]
 * For classification [0,1] or [-1,1]
 *
 **/



#ifndef MAINEPNET_HPP
#define MAINEPNET_HPP

///////////////////////////////////////////////////////////////////////////
#include <sys/types.h>   // for stat, to chek if a file exist
#include <sys/stat.h>
#include <stdlib.h>


#include <stdio.h>
#include <cstdlib>
#include <time.h>
#include <math.h>
#include <string.h>
//includes from c++
#include <iostream>
#include <fstream>
#include <vector>
#include <sstream>
#include <string>
#include <exception>

#include <dirent.h> // to count files in a directory


#include <algorithm>						// to use *min_element(a,a+b);

//#include<limits.h>														// have Long_MAX and other variables, used fo Random.h
//#include "../epnetCpp/math/Random.h" 						// Library of random number and use a uniform, normal Lorenz distribution and more...

//Constants like strings
#include "../epnetCpp/CONS.hpp"


// include the configuration file for the experiment
#include "txtFiles/conf.hpp"

using namespace std;



///////////////////////////////////////////////////////////////////////////
//////// DEBUG the Code // Comment to no display each block //////

static const int flagDebug = OFF;

static const int MYDEBUG_LOADNET = flagDebug;
static const int MYDEBUG_MAIN = flagDebug;
static const int MYDEBUG_EPNET = flagDebug;
static const int MYDEBUG_MBP = flagDebug;
static const int MYDEBUG_SA = flagDebug;

static const int MYDEBUG_DelIDH = flagDebug;
static const int MYDEBUG_DelCon = flagDebug;
static const int MYDEBUG_DelNode = flagDebug;
static const int MYDEBUG_DelInput = flagDebug;
static const int MYDEBUG_DelDelay = flagDebug;

static const int MYDEBUG_AddIDHC = flagDebug;
static const int MYDEBUG_AddNodeCon = flagDebug;
static const int MYDEBUG_AddCon = flagDebug;
static const int MYDEBUG_AddInput = flagDebug;
static const int MYDEBUG_AddNode = flagDebug;
static const int MYDEBUG_AddDelay = flagDebug;

static const int MYDEBUG_FINAL_TRAIN = flagDebug;

//////////////////  What do you want to Run? ///////////////////////////
// ------------------------------------------------------------------//

/// Ensembles as in the GECCO 08 paper
static const int RUN_ENSEMBLE = OFF; 			// ON or OFF


/// Evolution of network for MULTIPLE scales		// determinate which scales are used to train the networks
static const int trainMultipleSets = OFF;
int scale2Train[] = {7, 5, 3};							// this are the real scales to train the net, could be {7,6,5,4,3,2,1}



/// EVOLUTION OF FEATURES OR NOT
static const int fixedinputs =  EVOLVE;				//(EVOLVE, FIXED, FIX_EVOvra),	for Classification only Fixed or Fix_EVOvra, where vra must be set to number of inputs used and delays = 1

/// Which algorithm to evolve features
static const int algoFeatures = HIERARQUICAL;		//(HIERARQUICAL, TOURNAMNET, CO_EVO, ASYMMETRIC, MODULAR1, SWAP_CONN, MR_EPNET )
																					// for classification only can be used the asymmetric if we want to evolve the inputs
																					// it is the same HIERARQUICAL, TOURNAMNET or CO_EVO, ASYMMETRIC for classification if the inputs are fixed
																				// MODULAR1 is to evolve MNN deleting shared nodes and shared connection before the hierarchical algorithm  is used
																					// SWAP_CONN : I think the hidden nodes must be fixed, check when this algorithm is used
																			// MRepnet --> It loads the pool of modules to be reused during evolution, this algorithms works only with the  MODULAR1 algorithm
/// E v o l u t i o n

int epochsK[] =  {200,2000}; 							//1st val training inside, 2nd training outside EPNet, the second should be bigger always, if not there is an error
																	// for pred and normmal class 500 adn 3000 at the end, fro generated data sets 50 and 1000
/*		// error per epochs, global variables used, comment them if it is not used that
		double *lratePERepochs;  // allocate in EPNET::trainpop and fill it in netowrk::ES, no dealocate it, one per module, each line is a module
		double **lratePerModule;
		double **ErrorPerModule;
*/
static const int Corridas = 1;
static const int populationNum = 20;//32;
static const int expectedGenerations = 4000;//00;
static const int stopGenStrip = 4000;//0; 				// put this value = expectedGenerations to stop until all generations are reached

int baldwin = OFF; 														// Lamarkian or Baldwin evolution, OFF is Lamarking by default, this option is activated automatically if it is used learn quick to generalize

static const int generateDS_eachGen = OFF;									// only for 0024, 0023, ... every generation is generated a new data set, the size of the data set is from the same size as dataInputN.txt

// parameters for the co-evo algorithm
static const int migrationGen = 10; 			//( I do not save these values into a file)
int migrationInd = 5;

// After evolution finish
int restartWeight_afterEvolution = ON;												// Variable to create a copy of the network and restart weights and train again to see if reaches smaller errors (in case it get stuck in a local minima)



/// include the configuration file for the experiment
#include "connectivity.hpp"

/// include the configuration file for the experiment
#include "filePath.hpp"


//parameters epnet mutations
#define minmutateN      1
static const int mutatedInputs = 2;			// to only one input mutated
static const int mutatedDelays = 2;
static const int mutatednodes = 3;      		//1-2
static const int mutatedcon = 3;      			//1-3


//parameters of SA
static const int useSA = OFF;

static const int  temperature = 5;
#define mintemp         0.1
#define iterationTemp   100
static const double SAalfa = 0.66;					// how fast the temperature is decremented, the bigger the slower it is decremented (more time), the smaller less iterations are considered
//static const double SAalfa = 0.2;




/// E a r l y   S t o p p i n g   ( E S )
#define stopAlpha    100            					 //percentage 100 = 100%
#define strip           	5
const int stopStrip = 100;
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


/// L e a r n i n g   r a t e
// 4 different ways to settle the learning rate
///  (to evolve the lrate it is needed a validation set, if not, that is not possible with this code)

// 0) Fixed, all nodes have the same lrate during all the evolution
// 1) Evolve single lrate. It is evolved the learning rate in the normal scenario, just one for all the network, the module info. is not taken into account, all nodeshave the same lrate. ( Evolve single lrate per module if there is more than one)
// 2) Evolve per Node. Each node evolve independently a learning rate. If there are modules, it is applied the same criteria.
//		 At the beginning the lrate is settle in range [0.01, 0.5]

static const int evolveLrate =1;						// determinate which method is used for the lrate (0, 1 or 2)
																		// if it is used 2, it is used the number of modules to increase or decrement it during evolution
																		// e.g. lorenz there is only one module, then all are incremented/decremented in the same amount
																		// 0021a there are 2 modules, so the are inc/dec at different rates per module

static const double lrate1 = 0.153;				// base value, if 1: all nodes have this value, any other option (2,3 and 4) use this value as base and then evolve it
static const double minlrate = 0.01; 			// minimum value allowed
static const double maxlrate = 1.5;				// maximum value allowed
const double lrateMod = 0.021;  				// control how fast is incremented or decremented, for option 2 and 3
double lrateModRange[] = {-0.05, 0.05}; 					// min and max values to evolve the learning rate per node OPTION 2 MODIFIED IN MAIN
																			// this values are for classification, for prediction are -0.02, 0.02
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

static const double  momentum1= 0.0;


/// F i t n e s s

// discard last individuals to calculate the av. fitness
static const int avFitness_minus = 2; 					// e.g. 2 means that it is not considered the last 2 individuals

// Use the modularity March to bias the evolution of modules or not
static const int biasModularityFit = OFF;
static const double biasModMU = 0.8; 					// values close to one gives more importance to fitness


// Learn quickly to generalize
// Fitness declared as: the number of blocks required before a full block of items was classified correctly before training on each item
// Here it is generated a new data set every epoch
static const int fitness_learnQuick2Genaralize = OFF;								// this call a derived class form network, only implemented for generated classes 0021, 0023, ... not for the 'what where'
static const int patters_learnQuick2Gen = 400;											// how many patters are generated every epoch
static const int minClassError_learnQ = 10;													// which is the minum error allowed to stop the training, 0 -> quite strict, all patterns are classified, but it may take several epoch

// To evolve a normal algorithm with the same data sets during all evolution but using the fitness as the epochs required to solve it
static const int fitness_byEpochs = OFF;
static const int minClassError_fitByEpochs = 0;
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////








//Successful Training parameter
//Determinate the strength to say if the training is successful or not, e.g. 30 -> successful if the  error is reduced in 70%
double STP = 30;


// Give the output denormalized, i.e. the original values   (en este momento no lo use pero lo salvo)
static const int outputDenormalized = ON;




///  S A V E ... Part to determinate what it is saved

// Save all the population or only save the best of each run
// 1 = just the best individual
// populationNum = all the population
static const int saveNumIndividual = populationNum;



// Save each network from the population in a separate file
// Used to reload all the population and continue the training, or for the MNN for different scales (first code used)
// All population its saved in directory: "resPop", you need to be sure that this directory exist !!!!!!!!
// This does not interfere with the normal file ALLNum saved where it is saved all the information of the run
static const int saveNets2beReloaded = ON;

// Load all the population to continue the evolution of them
int loadNets2continueEvo = OFF;
int counterLoaded = 0; 														// counter to know how many times the networks have been loaded
																							// this values in not saved as general var, instead in varN-> is saved


// Save modules into the pool
static const int saveModulesINpool = OFF;						// only the modules of the best individual in the population is saved
static const int saveMod_ind 	= 1; 									// number of individulas that save their modules, normaly 1

/*!
 * Section for modules
 */

// Use the modularity of husken
static const int isModule1 = ON;

// Use the inputs to measure the modularity or not
// if not, the shared connection only are counted from the hidden nodes
static const int considerInputsInMod = ON;

// If this flag is on and flag loadNets2continueEvo, then it is read the previous networks
// and continue evolution, if there are more output it means that the previous network
// will be reused to help in the solution of the new tasks.
static const int reuseModule = OFF;   // automatically activates flag loadNets2continueEvo




/////////////////// Variables to not modify, they are setup after //////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

///////// This variables are configured in the main ////////////////////////////////////
unsigned int seedRand = 0;
int noOutputs = 1;    				//default 1, if targetPos is bigger then there will be more outputs

int isRealPredictionUsed = OFF; 					// This variable is only modified (main) if the file realPred.cpp is executed
string NAMETS = ""; 										// The name of the TS
string typeDS = "";											// used for the classification error, winner takes all, ..., only for classification tasks for the moment

// Section for Modules, MODULE1, in this moment this only apply for classification tasks
int NUM_MODULES = 0;
int *NAME_MODULE;
int *OUT_IN_MOD;									// which output is bounded to a module
int *NUM_OUT_Per_MOD;
////////////////////////////////////////////////////////////////////////////////////////

// Variables to save the current mutation per generation

int mutHT = 0;
int mutMBP = 0;
int mutSA = 0;

// variables for the architectural mutations
// The is a code to know with mutation was successful and which one need to be incremented
// the code is in from of the next variables as a comment
int mutNodeDel 	= 0;					// 1
int mutInputDel 	= 0;					// 2
int mutDelayDel 	= 0; 					// 3
int mutConnDel 	= 0;					// 4

int mutNodeAdd 	= 0;				// 5
int mutInpAdd 		= 0;				// 6
int mutDelayAdd 	= 0;				// 7
int mutConnAdd 	= 0; 					// 8
int mutStrongConnAdd = 0; 			// 11
// Variables for the deletion of shared nodes and connection // added 22 Jan 2011
int mutSharedNodeDel = 0;
int mutSharedConnDel = 0;


// Variables to measure the number of evaluations
int evaluationsPrun = 0;
int totalEval = 0;							// saved to file in ALLPARAM
/////////////////////////////////////////////////////////////////////////////////////

//Variables to save the Min and Max of the TS, they are saved in ps structure / class
double *normilize_max;
double *normilize_min;

//For the time
clock_t startTime, endTime;

// save how many values are going to be predicted, or for classification how many classes there are, set up in main
int sizetpos = 0;

// For the size of the file to be loaded
int filecol = 0;					//Columns in the file, 1 = univariable prediction, >1 = multivariable pred
int fileline = 0;					//Lines in the file
int FILECOL = 0;				// columns in the file for the calssification, the filecol variable is set to 1 for classification to avoid put too much extra code

// Determinate what will be run, ensemble, modular approach, co-evolutionary alg, ...
// The are the fist variables to be saved in the file, they are set up in the main
int RunEnsemble = 0;

// golval var for the number of the run
string isRun;
/////////////////////////////////////////////////////////////////////////////////////////



/// parameters for ensemble///////
#define beta_05           0.05
#define beta_1            0.1
#define beta_15             0.15
#define beta_2              0.2
#define beta_25           0.25
#define beta_3              0.3
#define beta_35             0.35
#define beta_4              0.4
#define beta_45             0.45
#define beta_5            0.5
#define beta_55             0.55
#define beta_6              0.6
#define beta_65             0.65
#define beta_7              0.7
#define beta_75           0.75
#define beta_8              0.8
#define beta_85             0.85
#define beta_9              0.9
#define beta_95             0.95
/////////////////////////////////


/// Macro for the Random number generator
#define rando() ((double)rand()/RAND_MAX)
//( value % 100 )  is in the range 0 to 99
//( value % 100 + 1 ) is in the range 1 to 100
//( value % 30 + 1985 ) is in the range 1985 to 2014
#define cpu_time_used() ((double)(endTime - startTime)) / CLOCKS_PER_SEC
//end Macros

// For other random numbers
//Random rv;  								 // a random number of Random.h



/// Include the hpp files....

// Include for the MLP
#include "MLPconf.hpp"					// it it is used the MLP algorithm

// Dual weights variables
#include "dualWeights.hpp"

//FUNCTION FOR GENERAL EXEPTIONS
#include "../epnetCpp/exeptionsFun.hpp"


//Start include files needed
#include "../epnetCpp/definition.hpp"							// All the definition of the functions



#include "../epnetCpp/create/allocateMem.hpp"			// Allocate vector and matrices of any type, deallocate too

#include "../epnetCpp/files/files.hpp"							// File operations

#include "../epnetCpp/math/opVecMat.hpp"					// zeros, min, max, mathematical operations
#include "../epnetCpp/math/errors.hpp"						// different errosr

#include "../epnetCpp/create/copyPrintSave.hpp"		// Instructions to copy, print into the screen and save into a file
#include "../epnetCpp/classes/Cmatrix.hpp" 				// to create matrices, e.g. a vector with a matrix in each position

/////////////////////// Start Classes //////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#include "../epnetCpp/classes/CPredParam.hpp"		//Class for prediction parameters

//Classes used by Csets
#include "../epnetCpp/classes/Cps.hpp"
#include "../epnetCpp/classes/CsizesSets.hpp"
#include "../epnetCpp/classes/Cval.hpp"
#include "../epnetCpp/classes/CEpochs.hpp"		//Classes used in Network and sets
#include "../epnetCpp/classes/CvarN.hpp"
#include "../epnetCpp/classes/Csets.hpp"			//Class sets with definition and implementation
#include "../epnetCpp/derivedClasses/Csets_generateDataSets.hpp"

//More classes
#include "../epnetCpp/classes/CALLParam.hpp"		//Class ALLParam
#include "../epnetCpp/classes/addDelNet.hpp"			//Class Network
#include "../epnetCpp/classes/Cnetwork.hpp"			//Class Network
#include "../epnetCpp/derivedClasses/Cnet_quickLearning.hpp" 				// for the MLP1 fixed arch and only evolve connections
#include "../epnetCpp/classes/CEnsemble.hpp"		//Class Ensemble
#include "../epnetCpp/classes/CEPNet.hpp"			//Class EPNet, this class contain all the others

// derived classes form EPNet
#include "../epnetCpp/derivedClasses/CepnetAsymmetric.hpp"
#include "../epnetCpp/derivedClasses/CepnetCoEvo.hpp"
#include "../epnetCpp/derivedClasses/CepnetHierarchical.hpp"			//Class hierarchical EPNet, class derived from EPNet
#include "../epnetCpp/derivedClasses/CepnetTournament.hpp"
#include "../epnetCpp/derivedClasses/CepnetModular1.hpp" 		// First class to develop modules (bias modularity) first delete shared nodes/connections
#include "../epnetCpp/derivedClasses/CepnetSwap_Conn.hpp" 				// for the MLP1 fixed arch and only evolve connections





// Files that contain information from classes but that was put in aseparate file
#include "../epnetCpp/math/addtional.hpp"
#include "../epnetCpp/classes/connInit.hpp"
#include "../epnetCpp/classes/checkNet.hpp"
// Include the files for the modules
#include "../epnetCpp/classes/Cmodule1.hpp" 						// this one is to measure modularity



#endif

