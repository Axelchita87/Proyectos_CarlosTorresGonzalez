/*!
 * filePath.hpp
 *
 * File to setup the paths from files read
 *
 * The variable form this file are override by the function setPAthDirectories
 * If you do not want that, do not call this function from the main
 *
 *
 * Created: 	7 Agu 2011, before was all together into mainepnet.hpp
 * Modified:
 * Author: 	Carlos Torres and Victor Landassuri
 **/



#ifndef FILEPATH_HPP
#define FILEPATH_HPP

/// F i l e s
string INPUTF = 	"txtFiles/dataInputN";								// name of the file normalized, it is overwritten if dual weights is used
string VRAvals = "txtFiles/FixedInputsVals";
string inpClass = "txtFiles/numberInputsANDClasses";	// inputs and classes in the file
string TSName = "txtFiles/TSname";									// The name of the DS or TS
string TYPEDS = "txtFiles/typeDS";									// winner takes all or other method for classification, load in ::  loadNameTS
string NAMEMOD = "txtFiles/nameModules";
string OutputsInMod = "txtFiles/outputsInMod";
string toSavePop = "resPop/"; 										// dir to save the population to continue evolution
string reusePop = "resPop_2reuse/"; 								// dir of the population to be reuse in case it is the objective

#endif

