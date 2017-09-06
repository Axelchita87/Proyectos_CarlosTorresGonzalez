/*!
 * dualWeights.hpp
 * File to put the configuration for the incremental learning with dual weights
 *
 *
 *
 * Created:	6 July 2011
 * Modified:
 * Author: 	Carlos Torres and Victor Landassuri
 *
 */

#ifndef DUALW_HPP
#define DUALW_HPP
// In this moment standard parameters:
// Classification and prediciton with SSP
// 6 batches 1200 train
// 1423 val
// 1200 test in 6 batches

// for prediciton with MSP
// 6 batches 1200 train
// val 500 or less
// test inside depends
// 		SSP 1000 coule be the same size as 1200
// 		MSP 30 60 90, ... segun la tarea
// test set final
//		same as test inside

static const int isDualWeights = OFF;
static const int numBatches = 6; 					// in the Lamarkian evo, all the generations are divided into numBatches partrs,
																		// e.g. numBatches = 6 with 3000 generations: batch 1 used from gen 0 to 499, batch 2 from gen 500 to 999, ...

// Classification
static const int sizeBatch = 200;
//static const int sizeVal_dualW =1423;			// should be the same as sizeVali in config file

// prediction
// The sizes of the test set iside and final are determined from the conf file

#endif
