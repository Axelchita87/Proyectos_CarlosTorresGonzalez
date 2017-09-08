#ifndef TESTNETWORK_HPP
#define TESTNETWORK_HPP

#include <stdio.h>
#include <cstdlib> //or <stdlib.h> in C
#include <time.h>
#include <math.h>
//#include <fcntl.h>
#include <string.h>

//includes form c++
#include <iostream>
#include <vector>

///// Global variables ///////

int epochsK[] =  {10, 10};

//For the time
clock_t startTime, endTime;


int sizetpos;
char kindPred[] = "Iterate";  //Iterate, Direct, Both

double STP = 0.1;      //Successful Training parameter
						//Determinate the strength to say if the training is
                        //successful or not, e.g. 30 -> successful if the 
                        //error is reduced in 70%

// Variables to save the current mutation per generation
int Avhybridtraining = 0;
int AvnodeDel = 0;
int AvconnDel = 0;
int AvnodeAdd = 0;
int AvconnAdd = 0;

//To depurate the Code
#define MYDEBUG  	//var to allow the print in the screen
                    //omith to no debug

//Determinate the Size of Inputs and Outputs Nodes, the hidden nodes are added at random
///////// This variables are configured in the main ////////////////////////////////////

int maxInputs = 0;
int noInputsDelay = 0;

////////////////////////////////////////////////////////////////////////////////////////

//Variables to save the Min and Max of the TS, they are saved in ps structure / class
double normilize_max = 0;
double normilize_min = 0;

//Standard Values
#define maxHidden       	20              //maximum number of hidden nodes
#define STDmaxInputs 		18				// //always >=2 these values are copied in main
#define STDnoInputsDelay    1   			//START IN 1 delay 1 is equal a delay of 0 in matlab code

#define INPUTF          "datainput.txt"		//name of the file
#define filecol         1					//1 = univariable prediction, >1 = multivariable pred
#define fixedinputs     0       			// 0-> not (0 means evolve inputs with random initialization)
											// 1-> yes (values from VRA)
											// 2-> not (evolve inputs but the ANNs are initialized with the VRA inputs, no take inetermediate inputs between delays
											// 3-> not (evolve inputs, VRA values to set up inputs and taken all intermediate inputs (not programmed)

//parameters of ANNs EPNET
#define Corridas        1
#define populationNum   5
#define generations     3
#define maxdata         2000

//How many steps to predict
#define Pred_stepAhead  30
    

#define noOutputs       1
#define smallW          0.5
#define momentum1       0
#define lrate1          0.1


//parameters epnet
#define minmutateN      1
#define mutatednodes    1      //1-2
#define mutatedcon      3      //1-3
#define initDensity     0.6    //0.9 -> 10%, 0.8 -> 20%,...


//parameters of SA
#define temperature     5
#define mintemp         0.1
#define iterationTemp   100


//Range to normilize
#define YMIN            -1
#define YMAX            1

//parameters of Early Stopping (ES)
#define stopAlpha       100             //percentage 100 = 100%
#define strip           10

//parameters for ensemble///////
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


// Macro for the Random number generator
#define rando() ((double)rand()/RAND_MAX)
//( value % 100 )  is in the range 0 to 99
//( value % 100 + 1 ) is in the range 1 to 100
//( value % 30 + 1985 ) is in the range 1985 to 2014

#define cpu_time_used() ((double)(end - start)) / CLOCKS_PER_SEC

/*

#include "../create/copyprint.hpp"
#include "../create/alocateMem.hpp"
#include "../create/classes.hpp"			//All the clases that i will use, netowrk, ...



*/


#endif
