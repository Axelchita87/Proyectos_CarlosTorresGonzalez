/*!
 * definition.hpp
 * Definicion of all Classes and funtions used in the program, except ALLParam class
 * I put all together to avoid to hae many files, but that can be modified in the future
 *
 * Created on: 22 Nov 2009
 * Modified at: 13/08/2101
 * Author: Carlos Torres and Victor Landassuri
 */

#ifndef DEFINITION_HPP
#define DEFINITION_HPP

// Functions in aditonal.hpp
static void arguments(int argum);										//Function in file main, check correct number of arguments
static void correctInputOutput(int, int);							//Function to check if the input and output are correct
static void SetSizeDatainput(void);									//Set filecol and filelines variables
static void updateMutation(int);										//unpdate the adecuate mutations
void checkDir(void);															// check that the directories needed exist, if not they are created, if it is not possible that
																								// then exit the program



void obtainModuleInfo(void);											// Function to set up the number of modules, name of them and other variables used for MODULE1



//*****************************************************************************************************//
// Funciton in files.hpp
bool FileExists(string );														// check is a file or dir exist
int countFiles(string );															// count files in one directory
static void load_FixedInputs_and_Delay(int *, int *);	// Function in main, load values to sut up maxinputs and delays from VRA
static void load_inputs_and_classes(int *, int *);			// Function to load inputs and classes for the classification task
string loadNameTS(void); 													// load the name of the TS

//*****************************************************************************************************//
//Functions inside of copyPrintSave
/* template <class T>
 * void imprime(T *, int )						//print into the screen a vector
 * void imprime(T **, int, int)					//in screen a matrix
 * void imprime(T ***, int, int, int) 			//in screen a 3d matrix
 * T **copyAlloc(T **m,T **,int,int)			//copy a matrix, delet original content allocating mem
 * void copy(T **,T **,int,int)					//copy a matrix
 * T *copyAlloc(T *,T *,int)					//copy a vector allocating mem
 * void copy(T *,T *,int)						//copy a vector
 *
 ****** FUNCTIONS ********* */
void saveInt(int **, int, int, FILE *, char []);	//save an integer matrix giving the file descriptor
void saveD(double **, int, int, FILE *, char []); 	//matrix double
void saveInt(int *, int, FILE *, char []);			//Vector Int
void saveD(double *, int, FILE *, char []);			//vector Double
/*
 * Passing the name of the file
 */
void saveInt(char [],int **, int, int);			//save an integer matrix in a given filename passed
void saveD(char [],double **, int, int);		//save a double matrix
void saveD(char [],double *, int);				//save a double vector
void saveInt(char [],int *, int);				//save a int vector

// to load passing the name of the file
int loadVecInt(string, int* ); 					// load a vector of any size and return the elements loaded






//*****************************************************************************************************//



//Functions inside of opVecMat: operations for vector and matrices
//Templates:
/* void zeros(T *,int)							//fill a vector with zeros
 * void zeros(T **, int, int)					//fill a matrix with zeros
 * T *maxRow(T **,int, int)						//found the maximum in a matrix and return a vector with the max per row
 * T *maxCol(T **,int, int)						//found the maximum in a matrix and return a vector with the max per column
 * T *minRow(T **,int, int)						//found the minimum in a matrix and return a vector of min per row
 * T *minCol(T **,int, int)						//found the minimum in a matrix and return a vector with the min per column
 * T **transpose(T **,int, int);				//Transpose a vector
 * void difference(T **, T **, int, int, T **)	//difference between m and n, m-n
 *
 *  There are more templates check the file to know all of them
 *
 */
void randomPT(double **,double **,int ,int ,int ); 	// change p and t in a random way
void fmean(double **,int, int, double *);			//calculate the mean of a matrix per row
void abs(double **, int, int, double **);			//abs of a double Matrix
void maxAndpos(double **, int, double *); 			// Find the max in the first row
int countConnNet(int **, int *, int);						// count the number fo connections the network
int countNodesVec(int *, int );								// count the number of inputs or hidden nodes in a vector passed as input parameter
//*****************************************************************************************************//







//Functions in allocateMem
//Templates
/* T *allocate (T *, int)						// Allocate a vetor of any type, return (T *) m
 * T **allocate (T **,int, int)			 		// Allocate a Matrix of any type, return **m
 * T ***allocate(T ***,int ,int ,int)			// Allocate a matrix of 3d, return ***m3
 * T **reallocate (T **,int, int, int, int) 	// Reallocate a Matrix of any Type return **m
 * void free(T **,int );		 				// Free space for a matrix
 * void safefree(void **pp);					// safty free for a vector of any kind
 *
 */

//*****************************************************************************************************//



class C_varN{
	/*!
	 * Class C_varN
	 * Contain variables for each network, like inputs, hiden nodes, ...
	 */
public:

	int *Vepochs;
	int *VtargetPos;					//Which vector from the data input will be predicted / classified

	/*int VmaxInputs;
	int VmaxDelays;
	int VmaxHidden;*/
	int VnoOutputs;

	// This parameters will be evolved
	int inputs;
	int finalInp;						// (inputs * filecol) in the case that there is a multivariate TS and the other TS are used in the prediciton
	int delays;
	int hidden;
	///////////////////////////////////

	int Vfileline;
	int Vfilecol;

	int Vsizetpos;						// How many outputs will the network must have. In this moment only one
	int VPred_stepAhead;


	// for classifcation, the min and max of the classes -1, 0 or 1
	double minClass;
	double maxClass;

	int counterLoaded; 				// to know how many times the networks has been loaded

    //Constructor
	C_varN();

    //Destructor
    ~C_varN();

    //set values
    void set_values(int *, int *,int , int , int , int , int , int , int, int, int, int, int) ;

    // copy
    void copyClass(C_varN *);
    //print all the members
    //void print(void);

    //to save into a file
    void save2file(FILE *fwrite, char file[]);

    // clean class
    void clean(void);
};/////////////// finish class


/////////////////////////////
class C_Epochs{
	/*!
	 * Class C_Epochs
	 * Save the Error per generation, the validation error and variables for the ES
	 */

public:
	double *Etr;
	double *Eval;
	double *GL;
	double *Pk;
	double *PQalfa;

    //Constructor
    C_Epochs();

    //Destructor
    ~C_Epochs();

    // set up Epochs with given values
    //void set_Epochs(int);

    //Copy allocatng Epochs
    void copyAllocClass(C_Epochs *, C_varN *);

    //Copy Class
    void copyClass(C_Epochs *, C_varN *);

    //Clear the class to a given value
    void setClass2val(int , int);

    //print all the members
    void print(void);

    //to save into a file
    void save2file(int, FILE *fwrite, char file[]);

    // clean al the class to 0
    void clean(void);
};/////////////// finish class


/// Class C_ps ///
class C_ps{
public:
	//char *name;
	int xrows;     //[1]
	double *xmax;   //[linepn,1]
	double *xmin;   //[linepn,1]
	double *xrange; //[linepn,1]
	int yrows;     //[1]
	double ymax;   //[1] <- 1
	double ymin;   //[1] <- -1
	double yrange; //[1] <- 2

    //Constructor
    C_ps();
    ~C_ps();

    //print it into the screen
    void print(int line);
    //To save into a file
    void save2file(FILE *, char [], int);

};//////////////////////////////////////




/*!
 * Function inside class ps, they do not belong to the class
 */

void nor_reverse(double **, double **, C_ps *,int , int);		//denormalize the data
void nor_apply(double **, double **, C_ps *,int , int);			//apply the normalization
void normalize(double **,int, int,double **,C_ps *);			//to normalize








class C_predParam{
public:
	// Varibales to know the size of the variables this class holds
	int linesT;											// = sizetpos
	int colsT;											// = Pred_stepsAhead, how many patterns are predicted or classified
	int linesP;										// = maximum inputs, to setup the size of inputANN
	int colsP;											// columns for the input vector or matrix to the ANN, 1 for MSP, more than one for SSP. SSP could be used for classification or prediction

	// Varaibles used in the prediction
	double **inputAnn;						// size:maxInp x 1. Input to the ANN to predict the variable 'toPredict'
											// then inputs could be less than maxInputs, but this is the maxumin allowed, so this values
											// is used to initizlize the vector
	double **toPredict;						//size:sizetpos x Pred_stepAhead
    double **pred;                          //size:sizetpos x Pred_stepAhead
    int **incorrectPred;						// size no_modulesxPred_StepAhead  holds which pattern was incorrected classified / predicted, a value of 1 indicate a bad prediciton, 0 correct

    // Variables for prediction
    double *NRMSE;                          //size:sizetpos
    double *RMSE;

    // variables for classification
    double Epercentage;					//used in classification for the errorr in yao, and here too. it is not a pointer case it is designed to take into account more the onee output in the network
    double *EpercentagePerModule;
    double classifError;					// to save (f / n) * 100
    double *classifErrorPerModule;
    /////////////////////////

    double **accuracyPoint;                 //size:sizetpos x Pred_stepAhead
    double *accuracy;                       //size:sizetpos

    //Constructor
    C_predParam();

    //Destructor
    ~C_predParam();

    //Set the class to given parameters, allocate memory
    void set_predParam(int ,int, int, int);

	//Save to file the class
    void save2file(FILE *, char []);

    // copy Class allocating parameters
    void copyAllocClass(C_predParam *);

    //Copy class
    void copyClass(C_predParam *);

    // imprime class in the screen
    void imprime(void);

    // clean the class
    void clean(void);
};////////////////////////////////////////////////////////////////////////////////////////




class C_sizesSets{
public:
	int *Sinput;
	int *SinputF;
	int *SinputI;
	int *SpnI;
	int *StnI;
	int *SpnF;
	int *StnF;
	int *SinputAnn;					//contain the size of the inputs (inside and outside) in the network
	int *SvalI;
	int *SvalF;

    //Constructor
    C_sizesSets();
    ~C_sizesSets();

    void print(void);

    //Copy
    void copyClass(C_sizesSets *);

    //save to file
    void save2file(FILE *, char []);

    // clean
    void clean(void);
};/////////////////////////////////////////////////////////////////////////////////


// structure for the validation set
class C_val{
public:
	int linep;
	int colp;
	int linet;

    double **pn;
    double **tn;

    //Constructor
    C_val();
    ~C_val();

    // set the class, allocate mem
    void setVal(int, int, int);

    void print(int *, int *);

    //To copy allocating memory
    void copyAllocClass(C_val *);

    //To copy allocating memory
    void copyClass(C_val *);

    //To save into a file
    void save2file(FILE *, char []);

    //clean
    void clean(void);

};/////////////////////////////////////////////////////////////////////////////////

// file additional.hpp
//
// take the last points, which will be use to predict the test set, return **set4predic
void takeInputAnn(double **,double **,int, int *,C_varN *, int );
int calculateSizesP_T(int , int *, int *, C_varN *);															// claculate how many coumns pn and tn will have
int separateSetsClassify(double **, double **, double **, int , int, C_varN *);   		//obtain p and t for the classification
//*****************************************************************************************************//



/*!
 * Functions in error.hpp
 */
void mse(C_predParam *);
void rmse(C_predParam *);
void nrmse(C_predParam *);
void nrmse2(double **,double **,double *,double *,C_varN *);
void accuracy(C_predParam *);
int obtainSTP(double , double );
double errorPercentage(double **, double **, int, int );
double classificationError(double **, double , int, int, double, double, int *);
double classificationError(double **, double , int, int, double, double);
void classifErrorPerModule(double *, double **, double **, int ,  double, double, int ** );
double classifEWinnerTakeAll(double **, double , int, int, double, double, int**);
double classifEWinnerTakeAllMOD(double **, double **, int ,  int , double , double, double *, int ** );
double updateFitnessWithModularity(double, double);
double obtainClassificationError(double **, double **, int , int, int * );
double obtainClassificationError(double **, double **, int , int);
//*****************************************************************************************************//



class C_sets{
	//ALL the values will be normalized, inputs, predictions, ...
public:
	int inputs;
	int finalInputs;

	C_sizesSets *sizes;

	double **input;				//the complete input
	double **inputF;            //input Final

	double **inputI;            //input inside epnet

	double **pnI;
	double **tnI;

	double **pnF;
	double **tnF;

    C_val *valI;
    C_val *valF;


   ///////////////////////////////////// Methods /////////////////////////////////////
    //Constructor
    C_sets();
    ~C_sets();

    //print all variables of sets, the subclasses too
    void print(void);

    //Preprocesamiento de los datos
    void prepo(C_varN *,C_predParam *, C_predParam *, C_predParam *, C_predParam *,  const char []);
    void prepoClassification(C_varN *, C_predParam *, C_predParam *,  const char []);


    double **limitsize(double **,double **,int *, int, int, int);					//limit the size of theinput vector
    //double **takeSets2Predic(double **, double **, int, C_varN *, int);				//take sets to predict
    void takeSets2Predic(double **, double **, int , C_varN *, int ); 		// the saem but not allocate memory
    //void takeInputAnn(double **,double **,int, int *, C_varN *);			//take the last point of the input vector to predict the next values
    void diffsets(double **,double **,double **,int ,C_varN *,int);//function to obtain p, t, ...

    void takevalidation(double **,double **,double **, double **,int *, int *, int ,C_val *);	//take validationsets

    // copy sets structure
    void copyAllocClass(C_sets *);

    // copy sets structure
    void copyClass(C_sets *);

    //To save into a file
    void save2file(FILE *, char []);

    // fill the oneStep and predcit structures
    void obtainSet2predicts(double **,int,int,int,C_varN *,C_predParam *,C_predParam *);

    //clean
    void clean(void);

    /// V i r t u a l
    // generate data set. In this moment only for classification
    virtual void generateDataSet(double **, int, int, int){
    	cout << "Enter in generateDataSet from sets class, do nothing ......................" << endl;
    }

};
//////////////////////////////////////////////////////


// Function inside sets
void loadfile(double **, const char []); 							//load file
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


class C_matrixInt{
	/*!
	 * Class to create matrices of integers, I did not use template classes as when I save I did not sour it out
	 *  some used streams to save, maybe in the future
	 * In this case I could create a vector/matrix  of matrices
	 *
	 *
	 *
	 */
public:
	int maxLines; 			// maximum number of lines and cols
	int maxCols;

	int lines;
	int cols;
	int **m;

	//Constructor
	C_matrixInt(void);

	//Destructor
	~C_matrixInt();

	// set, allocate memory for the matrix
	void setMat(int, int);

	// copy
	void copyAllocClassMatrix(C_matrixInt *);
	void copyClass(C_matrixInt *);

	//to save into a file
	void save2file(FILE *fwrite, char file[]);
	void loadMat(FILE *fread);


	// clean class
	void clean(void);
};////////////////////// End class matrix int


class C_matrixDouble{
	/*!
	 * Class to create matrices of doubles, I did not use template classes as when I save I did not sour it out
	 *  some used streams to save, maybe in the future
	 * In this case I could create a vector/matrix  of matrices
	 *
	 *
	 *
	 */
public:
	int maxLines; 			// maximum number of lines and cols
	int maxCols;

	int lines;
	int cols;
	double **m;

	//Constructor
	C_matrixDouble(void);

	//Destructor
	~C_matrixDouble();

	// set, allocate memory for the matrix
	void setMat(int, int);

	// copy
	//void copyAllocClassMatrix(C_matrixDouble *);
	void copyClass(C_matrixDouble *);

	//to save into a file
	void save2file(FILE *fwrite, char file[]);
	void loadMat(FILE *fread);


	// clean class
	void clean(void);
};////////////////////// End class matrix double


// I think I declareated this here to allow the use of class C_module1
class C_network;



class C_module1{
	/*!
	 * Class C_module1
	 * Contain variables for the husken modularity and information that idicate to which module belong each node
	 */
public:

	int *nameModule; 										// Vector:  1 x n, as much as nodes in the network + an offset in case in the future I implement another version
	int **nodesInModule; 								// Matrix:  noNodes x 2 		indicate which node belongs to which node
	int *countNodesPerModule;						// vector 1xn, each position holds howmany nodes there are in each module
	int noModules; 											// counter to know the number of modules
	int noIsolatedNodes; 										// isolated nodes from inputs and outputs

	int *loadModule;											// for valid modules, indicate how many times this module has been loaded to solve a task, this value indicate how many columns history[x] has
	C_matrixInt *history;										// mantain a history of the origin of the module, as well if this has been reused to solve another task,
																		// there is one structure per valid module, i.e. not for isolated or shared modules, thus, only huskenModule with weighted modularity has this structure

	// This block is to mantain a local copy of some variables of the network
	// This values are not copied when the network is copied
	int noInp;													// number of inputs
	int noHid;													// number of hidden nodes
	int noOut;													// number of outputs nodes
	int **CW;													// a copy of the real CW because this var can be modified
	double **W;												// the same as above
	int *posinputs;
	int *poshidden;
	int allnodes; 												// total number of nodes in the net finalInp + nohidden + noOutputs
	int *nodes; 													// a local copy of nodes in the net


	// To measure the modularity
	double MarchTD; 										// TD means top-down version for the architecture and weighted modularity of husken
	double MweightTD;

	// d is the degree of dependency of the neuron on the m different modules
	// Their sizes are: noNodes x noNodes
	double **tdw; 											// top down d for the weighted case, in matlab code it is tdw
	double **tda; 										 	// top-down d for the arch case, in matlab code it is tdh


	// for the module reuse
	int *nodesReusedPerMod; 		// each module counst how many nodes it has reused from other modules

    //Constructor
	C_module1();

    //Destructor
    ~C_module1();


    // copy
    void copyClass(C_module1 *);

    //to save into a file
    void save2file(FILE *fwrite, char file[]);

    // clean class
    void clean(void);

    // Determinate modules with the husken modularity (weighted and architecture modularity)
    void isThereModulesHuskenTopDown(void); //C_network *);
    void isThereSharedModule(void); //C_network *);

    void findMod(); 								// method to bound the outputs with the modules, find how many modules there are in case the network has more outputs

    void findLastHidden4mod(void); //int **, int *);    // function to boud the last hidden nodes found in a network  to a module

    double modHusken(string, string); //, int **, double **, int *, int *); 			 // calculate the modularity of husken

    void setup(C_network *); 																			// setup first variables

    void howManyNodesPerModule(void);							// count the nodes per module

    void howManyReusedNodesPerMod(void); 					// to measur ethe reused nodes per module

    void modifyNet(void); 														// for the case there is out output, the net needs to be modified to calculate the modularity


    void isolatedNodes(void); 												// obtain the isolated nodes from inputs and output using March

    void isConnected2Output(void);										// calculate 'nodes in module' looking only for isolated nodes form outputs
    void isConnected2Input(int **); 										// calculate isolated nodes from inputs

    int isConnected2OutputRec(int );				// Recursive function to determinate if there is a path form node i to any output
    int isConnected2InputRec(int);					// Recuriseve fun to determinate isolated nodes from inputs

};/////////////// finish class











//////////////////////////////
class C_network{
public:
	char tmpData2load[50];

	C_varN *varN;
	C_Epochs *Epochs;

	// strucure oneStep and predict: [0] 15steps, [1] 30steps (normal), [2] 60steps, [3] 120stesp, [4] 240 steps, [5] 480steps

	// With the actual kind of prediction (direct or multiple step) it is simulated a direct prediction
	// using the same trained network to predict a given steps ahead, e.g 30stespAhead
	C_predParam *set2SSP;					// it is SSP
	C_predParam *set2MSP;					// MSP

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	/// Dual weights set to test different batches of information
	 C_predParam *set4DualWeight;
	 C_matrixDouble *p;					// vector of matrices saving the input set for each batch
	 C_matrixDouble *t;					// vector of matrices saving the target set for each batch
	 //////////////////////////////////////////////////////

	 C_predParam *predictI;					// in this moment MSP, but in the future thsi variables should have SSP or MSP (Check)
	 C_predParam *predictF;

	 C_sets *sets;

	 int **CW;
	 double **W;
	 double **W2;							// second matrix for the dual weights. W is the fast weights and W2 the long term memory, W2 have smaller lrates
	 double **DeltaW;
	 int *nodes;
	 int *bias;
	 int *posinputs;
	 int *poshidden;
	 double *momentum;

	 double *singleLrate; 			// a single lrate for all the network or one for each module [0] module 1, [1] module 2, ...
	 double *lrate;						// learning rate per node
	 double *lrateB;					    // learning rate for the bias


	 double *fitness;                    //size:varN->Vsizetpos
	 double *fitnessReal;                    //size:varN->Vsizetpos  // When it is used a bias algorithm to evolve modules this holds the real error from the learning task without introduce the modularity peanlty
	 // if it is not used the bias modularity, then this error is te same as fitness

	 double *Errori;						// size: 1x7     to hold the errors from each scale for the training with multiple scales
	 int *status;								//success=1, failure=0
	 int *trainingWith;					//MBP=1, SA=2, ...
	 int *sizepos;                  		//size of inputs [0] and hidden nodes [1]

	 // Modules (module1)

	 C_module1 *huskenModule; 			// maintain information about the modules in the network
	 C_module1 *sharedModule; 			// determinate modules with my metric (as john do investigating the waht and where)
	 	 	 	 	 	 	 	 	 	 	 	 	 	 	 // here I am only interested in how many nodes there are per module




	 // variables for the swap connection, they are initialized in the init conneciton when the network are created, ranges are the same durign all the program live
	 // active and deactivated connection are only interchange between the same sub-matrices
	 int **activeConn;
	 int **deactConn;
	 // e.g. [0 1; 2 8;, ...] IH is ion range 0 to 1, HO in rnage 2 to 8 index, .... IO, HH and OO
	 int **rangeDeact;
	 int contActiveConn;
	 int contDeactConn;

	//Constructor
    C_network(int, char *, const char[]);

    //Destructor
    ~C_network();

    //Delete all the information in the Class (only the strcutures)
    void deleteAllStruct(void);

    // Setup the variables, allocate memory for them
    //void set_Net(int *, int *,int , int , int , int , int , int , int , int);

    //print it into the screen all the ANN
    void print();

    // To save into a file
    void save2file(FILE *, char []); 										// save all network
    void save2fileSingleNet(FILE *, char []);						// save in separated files each network, e.g. application : to be reloadded and continue evolution
    void save2fileModule(int, string, C_network**);			// save a module from the network to a file




    //Train the network
    void trainMBP(int ,int);

    //Train with SA
    void trainSA(C_network *, double, double);

    // Perform the prediciton, calculate the errors and set up the fitness
    void evaluateANN(int, int);

    // Early stopping, avolution of a single learning rate and learning rate per module
    void complexES(double **,int , double **, int, double **, double *, double *, int *,double *, int *, double**, int*);
    void update_Lrate(int *);
    void reset_lrate(void); 																				// reset the learning rates of the network
    void perturbateLratePerNode(void);

    //evaluate the ANN with an input vector
    void singleStepPred(double **pn, int colpn, double **prediction);

    //feed the network to obtain the iterate prediciton
    double **iteratepred(C_predParam *, double **, int *);

    // obtain the perfomance of the network for NRMSE, accuracy, ...
    void obtainPerformanceNet(double **, int *,C_predParam *, int);

    // obtain predciotn or classification, but at the end it is similar, classificaiton is SSP
    void obtainPredictions(double **, int *,C_predParam *, int );

    // obtain the net' performance for a vector/cell of predParam classes
    void obtainPerformanceNetCell(double **, int *);

    /// Section for deletion ////

    // Delete input or hidden node or delay
    int deleteIDH(C_network **, C_network **, C_network **);
    // Delete input or hidden node for the assimetric code
    int deleteIHAssymetric(C_network **, C_network **);

    // Delete inputs
    int deleteInput(C_network **);
    int addInputAssymetric(C_network **); 					// for the assymetric code

    // Delete
    // input for the assimetric case
    int deleteInputAssymetric(C_network **);
    int deleteDelay(C_network **);
    int deleteNode(C_network **);
    int deleteSharedNode(C_network **);
    void deleteModule(int, int, int, string);
    void insertModule(C_network *, int );

    //Copy values into the same variables (matrices or vector) before delete an input or hidden node
    void copyBeforeDelete(int);

    // Delete Connections
    int deleteCon(C_network **);
    // related funs
    int obtaintConn2Del_NonConvergentM(int **);
    int obtaintConn(int **, int); 						// Obtain connection to add or delete
    int limitConnection2Add(int **, int , int,  int, int );


    int deleteSharedCon(C_network **);

    //// Section for adding /////
    // add Inputs or delays or hidden nodes
    int addIDHC(C_network **, C_network **, C_network **);
    int addIDC(C_network **, C_network **, C_network **);											// when the hidden nodes are fixed
    int addIHCAssymetric(C_network **, C_network **, C_network **); 						// for the assimetric code

    int addInpDelay(C_network **, C_network **, C_network **);

    // Swap Connection
    int swapConn(C_network ** ); 								// here the algorithm does not evolve anything, the connection are only swapped
    int swapModule(int, C_network *); 					// swap modules, pass only one pointer because I am not interested to modify it

    //Add Connection(s)
    int addCon(C_network **);
    // add strong connections
    int addStrongCon(C_network ** );
    //add input(s)
    int addInput(C_network **);
    //void nodeAddition();
    int addNode(C_network **);
    // funtion to add nodes or connections
    int addNodeCon(C_network **, C_network **, C_network **);
    // add delay
    int addDelay(C_network **);
    // resize and copy the varibles when adding
    void copyBeforeAdd(int);
    void copyBeforeAddModule(int);


    // Rearrange data after an input or delay is added or deleted
    void rearrangeData(void);

    // Rearrange the set to be able to load another scale into the current network
    void rearrangeAndLoadData(const char []);

    // recauculate hidden nodes
    void recalculateHNodes(void);

    // Recalculate inputs
    void recalculateInputs(void);


    //copy network n2 into this, no allocate space
    void copyNet(C_network *);

    //copy network n2 into this, allocate space
    void copyAllocNet(C_network *);

    //copy a network but first clean the target (the nets are thsame size (max values used))
    void copyCleanNet(C_network *);

    // clean the actual network, put all to zeros, fitness to -100
    void cleanNet(void);

    // Obtain all nodes in the Network
    int obtainAllnodes(int *);
    int obtainAllInputs(int *);   // for the assimetric case, obtain inputs availables
    int obtainAllFreeInputs(int *);   // for the assimetric case, obtain inputs available to add, i.e. inputs with -1 in posinptus

    // Calculate the importance of the conections before delete it
    void importance(double **);


    //Load a network to read the inputs, hidden and output nodes, used to setup the network
    void loadNet2setup(int *, int *, int *, int*,  char *file);

    //Load a network to read CW, W, ...
    void loadNetAll(char *file);
    int loadModule( int, int, int);

        // set predParam structures (set2SSP[] and set2MSP[])
    void set_allPredictionsStruct(int, int);

    // copy predParam structures (set2SSP[] and set2MSP[]) Allocating memory
    void copyAllocAllPred(C_network *n2);

    // copy predParam structures (set2SSP[] and set2MSP[])
    void copyAllPredictionsStruct(C_network *);

    // clean all predictions structure/class
    void cleanAllPred(void);

    // Check valid configuration in the network
    void checkValidNet(void);
    int checkNet_O(void); 				//Check output nodes (isolated)
    int checkNet_H(void);
    int checkNet_H_GMLP(void);

    // Function to train all scales and calculate the fitness of the individual
        void trainScales(C_network **, int , int );

        // copy the original network to all scales and update the scale for each network
        void copyALLscales(C_network **);


        // To obtain the shared Nodes and shared connections
        int obtaintSharedNodes(int *);

        int obtaintSharedConn(int **);
        int obtaintStrongConn(int **);

        int obtaintNUMSharedConn( void );
        // Firand classes
       // friend class C_module1; 			// here I use friend class even it is not nedded because network have all public, just to play



        /*!
         * Section for the method of initializtion
         * Those methods are in file connInt.hpp
         */

        // initialize the population
        void initNet(void);

        //init the weigts at random
        void initweights(void);


        // init connections
        void initConnSCS(void); 						// simple connections scheme, one value to all
        void init_IH_IO_SCS(void); 																					// init the IH and IO with the simple connection scheme
        void init_IH_SCS(void); 																					// init the IH with the simple connection scheme
        void init_IO_SCS(void);
        void init_IH_modular(void); 																					// init the IH with the simple connection scheme
        void init_IO_modular(void);
        void init_HH_SCS(void);
        void init_HO_SCS(void);
        void init_OO_SCS(void);

        void initConnImprovedCS(void);			// Improved connection scheme, avoid isolated nodes and increae the modularity a little bit
        void initConnSpareCSlineal(void); 	// sparse connection scheme, increment themodularity and avoid the isolated nodes, thus reduce the number of conenctions
        void initConnSpareCSexp(void);			// sparse connection scheme using exponential decaying functions, inprove modularity avoid almost all isolated ndoes and reduce number of connections
        							// It is  missing to check how they perform after ecvoluiton, the best in initialization is he best after evolution
        void initConnModule(void); 					// 4 = Modular. Init pure modular network, the total number of nodes is splitted into the required modules, then it is applied
																			// 			the simple connection scheme using the value of sigmaSCS

        void initConnMLP_SCS(void);					// 5 = init MLP with the simple connection scheme
        void initConnModularMLP_SCS(void);	// 6 = init MLP with the simple connection scheme

        // init bias
        void initBias(void);

        // Fill CW given the probability matrix
        void fillCWfromProbM(double **);


        // method to fill each submatrix
        // Inline functions
        inline double calcInc(double, double, int); 					// caculate the increment of the lineal decayinf function for probability of connection exist
        inline int setupDivHidden(int); 										// obtain the number of slot in the upper-right corner of the matrix to fill
        inline double localConnS(int, int, int, int, double); 		// exponential decayinf function with distance normalized between nodes
        // methods
        void fillMatline(double **,int *, int , int *, int , double , double );
        void fillUpperRightMat(double **,int *, int, double, double);
        void fillUpperRightMatSAMEprob(double **,int *, int, double); 					// designid for OO and fill all slots with the same prob, but can be applied to HH
        void fillMatDiag(double **,int *, int, int *, int, double, double);					// fill a rectangular or squared matrix decremented the prob form one corner to the other by lines
        void fillMatH2HO(double **, int *, int, int *, int, double, double);				// fill HH and then HO, the initial to final is decremented through both matrices, but the are filled separatelly
        void fillMatH2HObyCols(double **, int *, int, int *, int, double, double);	// fill HH and HO as if they were a single matrix, note that it is diffent than the previous
        void fillMatE(double **,int *, int, int *, int, double); 										// fill the sub-matrix with the eponential decaying function with distance normalized between nodes





        // Function for sapt connection
        void obtainActive_and_deact_conn(void); 														// all is fixed and the connections are swapped

        // used when the fitness is settle by the eopcs used to learn the task
        int evaluate_fitness_byEpochs( void );

        /// Virtual functions
        virtual int evaluate_LearnQuick ( void  ){
        	cout << "Enter in evaluate_LearnQuick from C_network. Do Nothing ....." << endl;
        	return 0;
        }



};///////////////////////finish class C_network /////////////////////////////////////









#endif
