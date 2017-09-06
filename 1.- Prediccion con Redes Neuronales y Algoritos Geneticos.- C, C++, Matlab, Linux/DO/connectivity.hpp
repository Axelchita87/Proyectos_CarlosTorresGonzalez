/*!
 * connectivity.hpp
 *
 * File to setup the parmeter for the connectivity
 * 1) Initialization in the connectin schem
 * 2 ) The connection echeme
 *
 *
 * Created: 	7 Agu 2011, before was all together into mainepnet.hpp
 * Modified:
 * Author: 	Carlos Torres and Victor Landassuri
 **/



#ifndef CONNECTIVITY_HPP
#define CONNECTIVITY_HPP

/*!
 * Section to declare the variables for the network INITIALIZATION
 * 1 		is 100%,
 * 0.5 	is 50%, ...
 *
 * This variables are not saved
 */
// Not that every time a run a different experiments it is changed sigmaSCS, sigma,...
static const int whichConnScheme = 0; 	// 0 = simple connection scheme         					works for GMLP and MLP whether the connections are constrained or not
																		// 1 = Improved connection scheme
																		// 2 = sparse connection scheme linear functions
																		// 3 = sparse connection scheme exp functions
																		// 4 = Modular. Init pure modular network (MLP or GMLP), the total number of nodes is splitted into the required modules, then it is applied
																		// 			the simple connection scheme using the value of sigmaSCS works only for 2 modules in this moment


// I will not use too many this value as in preliminary exps it was not so succesful, check more a detail if you want to use it
static const int alternateCS = 0;					// here the IH and IO are filled with the SCS, use sigmaSCS in this case, this option is used for Improved and sparse connection scheme


// Percentage of connectivity (is constrained the number of connections, in percentage). BIAS does not count
// sigmaSCS control how is filled and the next values control the total number of connections allowed
// if sigmaSCS = 1.0 and CONN_ALLOWED_IH = 1.0, then all connections are settle
// if sigmaSCS = 1.0 and CONN_ALLOWED_IH = 0.5, only the first 50% of connections are settle
// if sigmaSCS = 0.5 and CONN_ALLOWED_IH = 1.0, it is considered all slots to fill and the connection are distributed with 50% of connectivity
static const int IS_CONSTRAINED_CONN = ON;
static const double CONN_ALLOWED_IH = 1.0;						// percentage of maximum connections allowed from inputs to hidden
static const double CONN_ALLOWED_IO = 1.0;
static const double CONN_ALLOWED_HH = 1.0;						// percentage of maximum connections allowed when there are more than one hidden layer
static const double CONN_ALLOWED_HO = 1.0;						// percentage of maximum connections allowed between hidden nodes to output nodes
static const double CONN_ALLOWED_OO = 0.0;
// in principle the sub-matrices must be balanced in number of connections, from whole connectivity constrained:


static const double sigmaSCS =1.0; 											// sigma for simple connection scheme .... if used "alternateCS" set up this value as used for IH and IO
static const double sigmaInputAssym = 0.8; 							// for the asymmetric code, this var determinate the probability that an input exist
static const double sigmaBias = 0.5;										// this value determinate if a node has bias or not

/// For improved and Sparse connection Scheme
// if is is used the improved, sparse (lineal) or sparse exp connection scheme, it needs to be indicate which algorithm it is required to perform the experiment
// in this moment only is implemented:
// Improved connection scheme exps: 					A (best of exp2,3), G, L
// sparse CS linear exps: 										M and  S (best of exp 4)
// sparse exp: 															M and S (best of exp 6)
static const string CSalgorithm ( "S");					// options: A, G, L, M or S

static const double smallW = 0.5; 			// range to initialize the weights
static const int useNonConvergentM = ON; 			// use non convergent method to obtain connection to delete or select them at random
/////////////////////////////////////////////////////////////////////////////////////////////////////////////




#endif

