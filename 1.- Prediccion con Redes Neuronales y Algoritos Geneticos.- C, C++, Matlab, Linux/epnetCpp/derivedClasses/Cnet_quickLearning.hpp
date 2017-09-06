/*!
 * Cnet_quickLearning.hpp
 *
 * Derived class from class network to implement the function to allow a fitness modificaton
 * quick learning to generalize as stated by (bibtex:Bullinaria:unders2007)
 * 		John A. Bullinaria. Understanding the Emergence of Modularity in Neural Systems. Cognitive Science. 2007
 *
 * Created: 	16 Mar 2011
 * Modified:
 * Author:		Carlos Torres and Victor Landassuri
 *
 */

#ifndef C_NET_QUICK_LEARNING_HPP
#define C_NET_QUICK_LEARNING_HPP


class C_net_quickLearning: public C_network{
public:
	//int s;
	// methods

	//Constructor and destructor
	C_net_quickLearning(int loadNet, char *file2load, const char Data2load[]) :  C_network( loadNet, (char*) file2load, Data2load ){

	}
	~C_net_quickLearning();

	// entry function, do all the job
	int evaluate_LearnQuick( void  );

};// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////





int C_net_quickLearning::evaluate_LearnQuick( void ){
	/*!
	 * Function to evaluate the classification error and generate the new data set for the next epoch
	 * The training finihs if the classification error is zero, i.e. if all patterns are correct.
	 * The fitness is evaluate over the next training set instead of the actual
	 * If it is not zero, the next training set replace the actual to allow the trainig of this data set.
	 * Thus, always there will be a new data set every epoch.
	 *
	 * Note that all this only works for classification for tasks 0021, ...
	 * IF MODIFY THIS CHANGE  C_network::evaluate_fitness_byEpochs AND C_network::obtainPerformanceNet
	 */



	// Generate new data set and repace actual data set with the new one
	rearrangeData();

	// evaluate error percentage
	obtainPredictions(sets->inputI,sets->sizes->SinputI,predictI, kindPred); 			  			// first calculate the predicitons with the test set inside which was passed to this function

	// Winner taks all method, in the first ocndition
	if(  strcmp(TYPEDS.c_str(), "wta") ) /*strcmp( NAMETS.c_str(), "0021a" ) == 0  ||
			strcmp( NAMETS.c_str(), "0021a1" ) == 0  ||
			strcmp( NAMETS.c_str(), "0023a" ) == 0  ||
			strcmp( NAMETS.c_str(), "0024a" ) == 0  ||
			strcmp( NAMETS.c_str(), "0031a" ) == 0  ||
			strcmp( NAMETS.c_str(), "0033a" ) == 0  ||
			strcmp( NAMETS.c_str(), "0034a" ) == 0  )*/
		predictI->classifError = classifEWinnerTakeAllMOD(predictI->pred, predictI->toPredict, predictI->linesT, predictI->colsT, varN->minClass, varN->maxClass, predictI->classifErrorPerModule, predictI->incorrectPred);
	// Normal Classification error
	else if( strcmp( NAMETS.c_str(), "0021" ) == 0 ||
			strcmp( NAMETS.c_str(), "0023" ) == 0 ||
			strcmp( NAMETS.c_str(), "0024" ) == 0){
		predictI->classifError = classificationError(predictI->pred, predictI->toPredict, predictI->linesT, predictI->colsT, varN->minClass, varN->maxClass);
		classifErrorPerModule(predictI->classifErrorPerModule, predictI->pred, predictI->toPredict, predictI->colsT, varN->minClass, varN->maxClass,predictI->incorrectPred);
	}
	else{
			cout << "incorrect option for the class ..... function C_net_quickLearning::evaluate_LearnQuick ........ exit" << endl;
			exit (0);
		}

	// this vars are loaded with acript_plotClasses_plorBadPrediciton in workspace2\generateDS
	/* saveD((char *)"../../workspace2/genDataSetModular/res/inputANN.txt", predictI->inputAnn, predictI->linesP, predictI->colsP);
	 saveD((char *)"../../workspace2/genDataSetModular/res/target.txt", predictI->toPredict, predictI->linesT, predictI->colsT);
	 saveD((char *)"../../workspace2/genDataSetModular/res/pred.txt", predictI->pred, predictI->linesT, predictI->colsP);
	 saveInt((char *)"../../workspace2/genDataSetModular/res/incorrect.txt",predictI->incorrectPred, NUM_MODULES, predictI->colsT);
*/
	 if ( flagDebug == ON ) cout << "Learn quick to generalize ::: classification Error = " << predictI->classifError << endl;


	// if error percentage is zero, finish (<= 1 so there may be very difficult patterns, I will not consider them in this moment)
	 if ( predictI->classifError <= minClassError_learnQ)
		 return ( 1 ); 								// finish epochs as all patterns where classify correctly
	 else{												// if it is not,  continue epochs
		 // copy the 'test set inside' over the actual trainig set
		 copy(sets->pnI, predictI->inputAnn, sets->sizes->SpnI[0], sets->sizes->SpnI[1]);
		 copy(sets->tnI, predictI->toPredict, sets->sizes->StnI[0], sets->sizes->SpnI[1]);
		 return( 0 );
	 }

}

#endif
