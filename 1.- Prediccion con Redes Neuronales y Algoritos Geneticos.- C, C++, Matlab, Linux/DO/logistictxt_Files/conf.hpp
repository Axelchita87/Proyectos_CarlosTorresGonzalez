/* headers.hpp
 *
 * File to setup many parameters before the evolution starts.
 * This file configure each expeirment
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

/* Configuration for logictic TS
 * train			100
 * test 			100 ,  all this values are consecutives
 * inputs 1
 * delays 1 in the literature
 *
 * epochs    	500, 1000 I think it is ok
 * generations		200
 */


#ifndef CONF_HPP
#define CONF_HPP

// Number of data ser
static const int DSnumber = 0;					// each data set have a specifict number, check CONS.hpp to see if the correct data set if for the file

// Prediction or Classification
static const int task2solve = PREDICT;		// (PREDICT, CLASSIFY)
																		// For classification ...

// Kind of prediction
int kindPred = SSP;						// ( MSP , SSP)    for classification always use SSP cause predI is setup for SSP
static const int DeltaT = 1;								// This is the step size to predict, it is independent of the MSP or SSP
int Pred_stepAhead = 100;			// How many steps to predict / Classify in the final data set. This values should be bigger than Pre_stepAheadInside, if not there is an error in predParam in the initialization or manipulation
int Pred_stepAheadInside = 20;							// How many steps to predict in the inside set for the EA, it is in function of the size of the data
																			// for Classification this variable is overwritten by the size of the validation inside


/* Extra prediction sets SSP and MSP for the forecasting task only
 * Important, the file must have more than maxdata + incremenIcout
 */
static const int extraPredictions = OFF;			// calculate the one step and multiple step for a second test set. Only Prediction
static const int numDiffPredict = 6;					//[0] 15steps, [1] 30steps, [2] 60steps, ...
static const int initialStepPred = 15;				// the value in predParam ([0])
static const int incremenInData = 480;			// 480 points more will be allowed to perform the predictions



// Transfer function
static const int transferFunOutput = LINEAL;							// (HTAN, SIGMOID, LINEAL), for prediction htan in hidden and lineal in output nodes
static const int transferFunHidden= HTAN;
static const int SSEoCE = SSE;

// Validation set
int useValidation = ON;
static const int valiAuto = OFF;									// determinate if the validation set is created automatically, if it is ON, the val set its taken randomly for the INSIDE DATA, not that in the past I sue validation set inside and outside the EPNET, here only is used inside
static const float sizeValiAutoPercentage = 0.25;		// determinate the percentage of data to take for the validation set in case it is set automatically
int sizeVali = 20;										// determinate the number of values to use as validation in case it is not set automatically,
																						// this value is used for the inside data set, For classification it is the set that determinate the fitness (= predictI)
																						// for classification, predI is the same as vali
int useValidationOutside = OFF;				// says if ti is used the validation set in the outside sets.
static const int sizeValiOutside = 0; 							// determinate the number of values to use as validation outside in case it is not set automatically, note that the number of patterns could be smaller

int maxdata = 220;														// all the information used, training + validation + test (for the outside set, i.e. after the evolution finish)
																						// Only for prediction, for classification it is used all information (usually), change in the future if that changes
																						// this values is overwritten for classification with the number of total patterns in the file loaded



// Network initialization //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Standard Values for the maximum size of the networks
static const int totalMaxInput = 49;				// so I have a maximum of 49 inputs 50 hidden and 1 output = a matrix of 100x100 of fixed size
																				// to optimise for Classification use the number of inputs here
static const int totalMaxHidden = 100;

// Random initialization range
 // min values
static const int minInp = 1;
static const int minDelay = 1;
static const int minHid = 1;

// max values
static const int maxInputs = 3;				// the range to init at random is 1 to maxInputs, this value must not be bigger that totalMaxInp
static const int maxDelays = 5;				//START IN 1 delay, 1 is equal a delay of 0 in matlab code
static const int maxHidden = 10;			//maximum number of hidden nodes
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



int targetPos[] = {0};		// for prediciton
//int targetPos[] = {21, 22, 23}; 		//for multi-variable inputs, start in 0 = to one column,
													//the value you put here indicate which inputs are to be predicted/classified, so this represent the number of outputs in the network,
													// For prediction usually is 0, univariate TS
													// For classification is the last columns of the file loaded (number of classes), I do not use this values, but it is used the size if the vector

//Range to normalize 
static const double YMIN= -1;
static const double YMAX = 1;

#endif

