/*!
 * MLPconf.hpp
 * File to put the configuration for evolving MLPs instead of GMLP with the EPNet algorithm
 *
 * The inputs and outputs are determined by the task at hand
 *
 * Created:	24 Feb 2011
 * Modified:
 * Author: 	Carlos Torres and Victor Landassuri
 *
 */

#ifndef MLPCONF_HPP
#define MLPCONF_HPP

static const int IS_MLP = OFF;								// off means use the GMLP
static const int NUM_LAYERS = 1;
static const int FIXED_HIDDEN = OFF; 					// the hidden nodes are fixed, not evolved, if fixed it is used NUM_HIDDEN if not it is used the ranges from conf.hpp

// In case the hidden nodes are fixed
static const int NUM_HIDDEN[] ={10}; 						// hidden nodes per layer, e.g. {100,100}, both layers have hidden nodes


#endif
