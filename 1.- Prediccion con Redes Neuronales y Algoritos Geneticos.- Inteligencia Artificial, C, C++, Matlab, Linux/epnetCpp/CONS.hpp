/*!
 * CONS.hpp
 * All the constants values used in the program
 *  Created on: 	17 July 2010
 *  Modified at: 	21 Sep 2010
 *  Author: Carlos Torres and Victor Landassuri
 */

#ifndef CONS_HPP
#define CONS_HPP

// Prediction or Classification
static const int PREDICT = 0;
static const int CLASSIFY = 1;

// Different algorithms implemnted to evolve the features
static const int HIERARQUICAL = 0;
static const int TOURNAMNET = 1;
static const int CO_EVO = 2;
static const int ASYMMETRIC = 3;				//The delay are assymetric betweem them, the inputs are evovled like a binary vector
static const int MODULAR1 = 4; 				// Delete shared neuron and shared connections first in the EPNet, if not, the normal EPNet is called (hierarchical in this moment)
static const int SWAP_CONN = 5;				// Swap the connection only, not evolution of inputs, hidden or connections
static const int MR_EPNET = 6;					// Algorithm to deruse modules during evolution

static const int MBP = 1;
static const int SA =  2;
static const int SUCCESS = 1;
static const int FAILURE = 0;
static const int TRAIN_INSIDE = 0;
static const int TRAIN_OUTSIDE = 1;
static const int BAND = -1;		//values to check for error when saving, related when is loaded into Matlab

static const int ON = 1;
static const int OFF = 0;

// kind of prediction
static const int MSP = 0;						// multi-step prediction
static const int SSP = 1;						// single-step prediction

// Evolution of features
static const int EVOLVE = 0;
static const int FIXED = 1;
static const int FIX_EVOvra = 2;

// transfer functions
static const int HTAN = 0;
static const int SIGMOID = 1;
static const int LINEAL = 2;

// this two SSE and CE are not saved to matlab
static const int SSE = 0;
static const int CE = 1;

// Modules / modularity (to study any aspect of modules in all the variations)
static const int MODULES = 1; 			// basic variable to say that something is done with modules, in first place I only measure the modularity of husken




/*
 * Section to determinate the number of each data set or problem
 * This number is used when each module is saved or loaded to know from whic dataset/module it belongs
 * This ection is only to give information of each name and its number, the assigment is done in the conf.hpp file
 * which is a personalized file for each case
 *
 * Classification	Value
 * 0021a 				0
 * 0023a				1
 * 0024a				2
 *
 * 0031a				3
 * 0033a				4
 * 0034a				5
 */



#endif
