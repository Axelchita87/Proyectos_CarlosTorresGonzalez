/*!
 *  errors.hpp
 * Created: 			19 Jul 2010
 * Modified at: 	6 Oct 2010
 * Author: 			Carlos Torres and Victor Landassuri
 * Here are different funtions to meassure errors and for the STP (successful training parameter)
 * nrmse, rmse, mse, ...
 * 
 */
#ifndef ERRORS_HPP
#define ERRORS_HPP




//Calculate the MSE. Not in use this metric, intead the RMSE will be used
void mse(C_predParam *pred){
	// Input: ///////////////////////////////////////////////////////
	//			pred			structure with all the info, prediction, topredict, and accuracies
	// Output:
	//			pred->NRMSE		here is saved the finalMSE
	/////////////////////////////////////////////////////////////////
/*
    register int i,j;
    double *sum1 = NULL;

    // allocate memory and set to zero
    sum1 = allocate(sum1,pred->linesT);

	// calculate the MSE
    for(i=0; i<pred->linesT ; i++)
    {
        for(j=0; j < pred->colsT; j++)
            sum1[i]+= (pred->pred[i][j] - pred->toPredict[i][j]) * (pred->pred[i][j] - pred->toPredict[i][j]);

        pred->MSE[i] = sum1[i] / pred->colsT;

        if(pred->MSE[i] <0 || pred->MSE[i] > 100)
        	pred->MSE[i] = 100;
    }

    // Liberate memory
    safefree(&sum1);
    */
}//////////////////////////////////////////////////////////////////////////


void rmse(C_predParam *pred){
	/*!
	 * Calculate the RMSE
	 *
	 * Input: ///////////////////////////////////////////////////////
	*			pred			structure with all the info, prediction, topredict, rmse, and accuracies
	* Output:
	*			pred->NRMSE		here is saved the final RMSE
	*/

	/* Original used where there is an error per line in  the target
    register int i,j;
    double *sum1 = NULL;

    // allocate memory and set to zero
    sum1 = allocate(sum1,pred->linesT);

	// calculate the RMSE
    for(i=0; i<pred->linesT ; i++)
    {
        for(j=0; j < pred->colsT; j++)
            sum1[i]+= (pred->pred[i][j] - pred->toPredict[i][j]) * (pred->pred[i][j] - pred->toPredict[i][j]);

        pred->RMSE[i] = sqrt( sum1[i] / pred->colsT );

        if(pred->RMSE[i] <0 || pred->RMSE[i] > 100)
        	pred->RMSE[i] = 100;
    }

    // Liberate memory
    safefree(&sum1);
    */

	// New one where it is taken all row in the error calculation
	    register int i,j;
	    double sum1 = 0;


		// calculate the RMSE
	    for(i=0; i<pred->linesT ; i++){
	        for(j=0; j < pred->colsT; j++)
	            sum1 += (pred->pred[i][j] - pred->toPredict[i][j]) * (pred->pred[i][j] - pred->toPredict[i][j]);
	    }
	    pred->RMSE[0] = sqrt( sum1 / (pred->colsT * pred->linesT) );

	    if(pred->RMSE[0] < 0 || pred->RMSE[0] > 100)
	    	pred->RMSE[0] = 100;


}//////////////////////////////////////////////////////////////////////////




void nrmse(C_predParam *pred){
	/*!
	 *  Calculate the NRMS, save in *iterateNRMS, constrain it to 0<=NRMS<=100
	 *
	 *	 Input: ///////////////////////////////////////////////////////
	 *			pred			structure with all the info, prediction, topredict, nrmse, and accuracies
	 * Output:
	 *			pred->NRMSE		here is saved the final NRMSE
	 */

	/* Old way to do that using an error per line

    register int i,j;
    double *sum1 = NULL;
    double *sum2 = NULL;
    double *mean1 = NULL;


    // allocate memory and set to zero
    mean1 = allocate(mean1, pred->linesT);
    sum1 = allocate(sum1, pred->linesT);
    sum2 = allocate(sum2, pred->linesT);

    // obtain the mean of the values
    fmean(pred->toPredict,pred->linesT,pred->colsT,mean1);
    //cout << "Mean = " << mean1[0] << endl;

	// calculate the NRMSE
    for(i=0; i<pred->linesT; i++)
    {
        for(j=0; j < pred->colsT; j++){
            sum1[i]+= (pred->pred[i][j] - pred->toPredict[i][j]) * (pred->pred[i][j] - pred->toPredict[i][j]);
            sum2[i]+= (pred->toPredict[i][j] - mean1[i]) * (pred->toPredict[i][j] - mean1[i]);
        }
        pred->NRMSE[i] = sqrt(sum1[i]/sum2[i]);        //printf("in function ---- nrmse[%d] %f ------ mean[%d] =%f,  --- sum1[%d] = %f, ----- sum2[%d] = %f \n",i,nrmse[i],i,mean[i],i,sum1[i],i,sum2[i]);

        if(pred->NRMSE[i] <0 || pred->NRMSE[i] > 100)
        	pred->NRMSE[i] = 100;
    }

    // Liberate memory
    safefree(&mean1);
    safefree(&sum2);
    safefree(&sum1);
    */

	/// New way, just one error for all lines

	 register int i,j;
	 double sum1 = 0;
	 double sum2 = 0;
	 double mean1 = 0;


	 // allocate memory and set to zero
	 mean1 = 0;
	 sum1 = 0;
	 sum2 = 0;

	 // obtain the mean of the values
	 mean1 = fmean(pred->toPredict,pred->linesT,pred->colsT);
	 //cout << "Mean = " << mean1[0] << endl;

	 // calculate the NRMSE
	 for(i=0; i<pred->linesT; i++)
	 {
		 for(j=0; j < pred->colsT; j++){
			 sum1 += (pred->pred[i][j] - pred->toPredict[i][j]) * (pred->pred[i][j] - pred->toPredict[i][j]);
			 sum2 += (pred->toPredict[i][j] - mean1 ) * (pred->toPredict[i][j] - mean1);
		 }
	 }
	 pred->NRMSE[0] = sqrt( sum1 / sum2 );        //printf("in function ---- nrmse[%d] %f ------ mean[%d] =%f,  --- sum1[%d] = %f, ----- sum2[%d] = %f \n",i,nrmse[i],i,mean[i],i,sum1[i],i,sum2[i]);

	 if(pred->NRMSE[0] <0 || pred->NRMSE[0] > 100)
		 pred->NRMSE[0] = 100;

}//////////////////////////////////////////////////////////////////////////



double nrmse(double **pred, double **orig, int lines,  int cols){
	/*!
	 *  Calculate the NRMS passing where to save with lines and cols
	 *
	 */

	 register int i,j;
	 double sum1 = 0;
	 double sum2 = 0;
	 double mean1 = 0;
	 double E = 0;

	 // allocate memory and set to zero
	 mean1 = 0;
	 sum1 = 0;
	 sum2 = 0;

	 // obtain the mean of the values
	 mean1 = fmean(orig,lines,cols);
	 //cout << "Mean = " << mean1[0] << endl;

	 // calculate the NRMSE
	 for(i=0; i<lines; i++){
		 for(j=0; j < cols; j++){
			 sum1 += (pred[i][j] - orig[i][j]) * (pred[i][j] -orig[i][j]);
			 sum2 += (orig[i][j] - mean1 ) * (orig[i][j] - mean1);
		 }
	 }
	E = sqrt( sum1 / sum2 );        //printf("in function ---- nrmse[%d] %f ------ mean[%d] =%f,  --- sum1[%d] = %f, ----- sum2[%d] = %f \n",i,nrmse[i],i,mean[i],i,sum1[i],i,sum2[i]);

	 if(E <0 || E  > 100)
		 E  = 100;

	 return (E);

}//////////////////////////////////////////////////////////////////////////




void nrmsePerModule(double *EperMod, double **pred, double **orig, int lines,  int cols){
	/*!
	 * Function to determinate the nrmse per module
	 * In case there are several modules in prediction
	 *
	 * Inputs:
	 *  EperMod 			place to save the erros per module
	 *  pred 					the prediction
	 *  orig						the original values
	 *  lines					lines in the two matrices, i.e. outputs in the network
	 *  cols						how many steps where predicted, or classified
	 *
	 *  Outputs:
	 *  nrmse into EperMod
	 */

	//int line,i;
	int module;
	//double maxval = 0, minval =0, sumpred=0;


	// Obtain max and min from the matrix
	// Even in this case it may be possible that the max and min of a matrix for the first partition could be different
	// to the second partition, here is not considered that case. CHECK in the future, maybe there are differences

	//maxval = maxMatrix(orig,lines,cols);
	//minval = minMatrix(orig,lines,cols);

	 int outputInitCont = 0;
	 //int outputLastCont = NUM_OUT_Per_MOD[0];

	 for (module = 0 ; module < NUM_MODULES ; module ++){ 					// measure the error for each module

		 EperMod[module] = nrmse(&pred[outputInitCont],  &orig[outputInitCont],  NUM_OUT_Per_MOD[module], cols);   // correct at 29 Jul 2011

		 if ( module+1 >= NUM_MODULES)
			 break; 																				// chack that I do not read invalid memory addres

		 outputInitCont += NUM_OUT_Per_MOD[module];				// have the first output of the next module
		 //outputLastCont += NUM_OUT_Per_MOD[module+1];			// have the last output of the next module (it does nto matter that in the last module it is added a value outside NUM_OUT_Per_MOD)
	 }


	 // second way to do that, I will obtain the NRMSE per output, assuming that each line belong to each module
	// this was the firt function implemnetd for the NRMSE taking the error per line
	/* if(1){  // with this method I cehck that the code from above is correct 29 Jul 2011
	     register int i,j;
	     double *sum1 = NULL; //sum 1 nad 2 are per line, as done above with the nrsme () function
	     double *sum2 = NULL;
	     double *mean1 = NULL;


	     // allocate memory and set to zero
	     mean1 = allocate(mean1, lines);
	     sum1 = allocate(sum1, lines);
	     sum2 = allocate(sum2, lines);

	     // obtain the mean of the values, per line
	     fmean(orig, lines , cols, mean1);

	 	// calculate the NRMSE
	     for(i=0; i<lines; i++){
	         for(j=0; j < cols; j++){
	             sum1[i]+= (pred[i][j] - orig[i][j]) * (pred[i][j] - orig[i][j]);
	             sum2[i]+= (orig[i][j] - mean1[i]) * (orig[i][j] - mean1[i]);
	         }
	         EperMod[i] = sqrt(sum1[i]/sum2[i]);        //printf("in function ---- nrmse[%d] %f ------ mean[%d] =%f,  --- sum1[%d] = %f, ----- sum2[%d] = %f \n",i,nrmse[i],i,mean[i],i,sum1[i],i,sum2[i]);

	         if( EperMod[module]  <0 || EperMod[module]  > 100)
	        	 EperMod[module]  = 100;
	     }

	     // Liberate memory
	     safefree(&mean1);
	     safefree(&sum2);
	     safefree(&sum1);
	}
*/



} ////////////////////////////////////////


//Calculate the , save in *iterateNRMS, constrain it to 0<=NRMS<=100
// I have not updated this function for the code for classiication, probabli it does not work ok for the values taken from varN
/*void nrmse2(double **output,double **original,double *nrmse,C_varN *var){
	//this errror and nrmse are the same
	// Input: ///////////////////////////////////////////////////////
	//			output			the prediciton
	//			original		original data (toPredict)
	//			nrmse			to save the error, size:sizetpos x 1
	//			var				variables from the network
	// Output:
	//			nrmse			here is saved the final NRMSE
	/////////////////////////////////////////////////////////////////

	register int i,j;
    double *sum1 = NULL;
    double *sum2 = NULL;
    double *mean2 = NULL;
    int sizeVec = 0;

    sizeVec = var->Vsizetpos;

    // allocate memory and set to zero
    mean2 = allocate(mean2,sizeVec);
    sum1 = allocate(sum1,sizeVec);
    sum2 = allocate(sum2,sizeVec);

    fmean(original,var->Vsizetpos,var->VPred_stepAhead,mean2);
    //cout << "Mean = " << mean2[0] << endl;

    for(i=0; i<sizeVec; i++)
    {
        for(j=0; j<var->VPred_stepAhead; j++){
            sum1[i]+= (output[i][j]-original[i][j])*(output[i][j]-original[i][j]);
            sum2[i]+= (original[i][j]-mean2[i])*(original[i][j]-mean2[i]);
        }
        sum1[i] /=  var->VPred_stepAhead;
        sum2[i] /=  var->VPred_stepAhead;
        nrmse[i] = sqrt(sum1[i]/sum2[i]);

        if(nrmse[i] <0 || nrmse[i] > 100)
        	nrmse[i] = 100;
    }

    ///////////
    safefree(&mean2);
    safefree(&sum2);
    safefree(&sum1);
}//////////////////////////////////////////////////////////////////////////
*/


void accuracy(C_predParam *pred){
	/*!
	 * Meassure the acuracy of the network, save in **accuracyPoint and  *accuracy
	 *
	 * Input:
	 *			pred									structure will all the informaiton
	 * Output
	 *			pred->accuracyPint
	 *			pred->accuracy
	 */


	register int i,j;
	double **abspred = NULL;
	double **abso = NULL;
	double **diff = NULL;
	double *sum = NULL;

	abspred = allocate(abspred, pred->linesT, pred->colsT);
	abso = allocate(abso, pred->linesT, pred->colsT);
	diff = allocate(diff, pred->linesT, pred->colsT);
	sum = allocate(sum,pred->linesT);

	abs(pred->pred, pred->linesT, pred->colsT, abspred);
	abs(pred->toPredict, pred->linesT, pred->colsT, abso);

	// Obtain the accuracy and accuracy Point
	for(i=0; i<pred->linesT; i++){
		for(j=0; j<pred->colsT; j++){
			if(abso[i][j] >= abspred[i][j])
				pred->accuracyPoint[i][j] = (abspred[i][j]*100)/abso[i][j];
			else{
				diff[i][j] = (abspred[i][j] - abso[i][j]) * 2;
				pred->accuracyPoint[i][j] = (((abspred[i][j]-diff[i][j])*100)/abso[i][j]);
			}
			if(pred->accuracyPoint[i][j] <0)
				pred->accuracyPoint[i][j] = 0;
			sum[i] += pred->accuracyPoint[i][j];
		}

		pred->accuracy[i] = sum[i]/pred->colsT;
	}
	//////////////////////////
	safefree(&sum);
	safefree(&diff,pred->linesT);
	safefree(&abso,pred->linesT);
	safefree(&abspred,pred->linesT);

}//////////////////////////////////////////////////////////////////////////


int obtainSTP(double numerator, double denomi){
	int x = 0;
	if (denomi != 0){
		if (( (numerator * 100) / denomi ) <= STP)				//STP is the successful training parameter
			x = SUCCESS;
		else
			x = FAILURE;
	}
	else
		cout << " Errro, Calculating the STP, the denominator is ZERO" << endl;

	return x;
}

double errorPercentage(double **pred, double **orig, int lines,  int cols){
	/*!
	 * Function to determinate the error percentage, found in \cite{Prechelt94c} and \cite{YaoLiu:1997}, this error is used for the fitness of ANNs and for the error in classification
	 * The error in thos refeences seems to be grwon because it should divide by (Omax-Omin)^2 instead to multiply: John figure it out.
	 * That does not affect what is evolved but is more suitable for times series, even more it is taken the max and min from the target matrix, which makes constant the difference.
	 * At the beginning of the research I remember that I had probelms if those values are taken form the prediction for TS. Posted: 9 Apr 2011
	 *
	 * Inputs:
	 *  pred 					the prediction
	 *  orig						the original values
	 *  lines					lines in the two matrices, i.e. outputs in the network
	 *  cols						how many steps where predicted, or classified
	 *
	 *  Outputs:
	 *  errorPercentage
	 */

	int line,i;
	double maxval = 0;
	double minval =0;
	double E,sumpred=0;

	// Obtain max and min from the target
	maxval = maxMatrix(orig,lines,cols);
	minval = minMatrix(orig,lines,cols);


	 for (line = 0; line < lines; line++){
		 for(i=0; i<cols; i++){
			 sumpred += (pred[line][i] - orig[line][i])*(pred[line][i] - orig[line][i]);
		 }
	 }
	 // 	E = 100 * ( (maxval-minval) / (lines * cols) ) * sumpred; 				// previous version
	 E = ( 100 / ( (lines * cols) * ( (maxval-minval) * (maxval-minval) ) ) ) * sumpred;

	 return E;
} ////////////////////////////////////////



void errorPercentagePerModule(double *EperMod, double **pred, double **orig, int lines,  int cols){
	/*!
	 * Function to determinate the error percentage, found in \cite{Prechelt94c} and \cite{YaoLiu:1997},
	 * this error is used for the fitness of ANNs and for the error in classification
	 * Here is calculated the error from the different output partitions (modules)
	 * First implemented for classification tasks, not done for predictio because here it is used the error
	 * from outputs, in prediction there always is one output even it is discover modules inside the sctructure
	 *
	 * Inputs:
	 *  EperMod 			place to save the erros per module
	 *  pred 					the prediction
	 *  orig						the original values
	 *  lines					lines in the two matrices, i.e. outputs in the network
	 *  cols						how many steps where predicted, or classified
	 *
	 *  Outputs:
	 *  errorPercentage
	 */

	//int line,i;
	int module;
	//double maxval = 0, minval =0, sumpred=0;


	// Obtain max and min from the matrix
	// Even in this case it may be possible that the max and min of a matrix for the first partition could be different
	// to the second partition, here is not considered that case. CHECK in the future, maybe there are differences

	//maxval = maxMatrix(orig,lines,cols);
	//minval = minMatrix(orig,lines,cols);

	 int outputInitCont = 0;
	 //int outputLastCont = NUM_OUT_Per_MOD[0];

	 for (module = 0 ; module < NUM_MODULES ; module ++){ 					// measure the error for each module

		 EperMod[module] =errorPercentage(&pred[outputInitCont],  &orig[outputInitCont],  NUM_OUT_Per_MOD[module], cols);

		 if (flagDebug == ON) 		cout << "Error Percentage module " << module << " = " << EperMod[module] << endl;

		 if ( module+1 >= NUM_MODULES)
			 break; 																				// chack that I do not read invalid memory addres

		 outputInitCont += NUM_OUT_Per_MOD[module];				// have the first output of the next module
		 //outputLastCont += NUM_OUT_Per_MOD[module+1];			// have the last output of the next module (it does nto matter that in the last module it is added a value outside NUM_OUT_Per_MOD)
	 }
} ////////////////////////////////////////




double classificationError(double **pred, double **orig, int lines,  int cols, double minClass, double maxClass, int *incorrect){
	/*!
	 * This is the first metric though
	 *  Function to determinate the classification Error
	 *  Different to the classfication error winner takes all because here one pattern may have activated/deactivated (1/0) more than one output, so the normal winner take all cannot be applied.
	 *  Here each output is rounded to the maximum or minimum to create the new prediction.
	 *  It works fine for classification classes 0021, 0023 and 0024 where there are two modules and each output could produce any of the two values to classify
	 *
	 * Inputs:
	 *  pred 					the prediction
	 *  orig						the original values
	 *   lines					lines in the two matrices, i.e. outputs in the network
	 *  cols						how many steps where predicted, or classified
	 *  minClass				the min values of the clases, could be -1 or 0
	 * maxClass				the max value in classes, always expected 1;
	 *
	 *  Outputs:
	 *  errorPercentage
	 *
	 *  Comments: the min and max values of the class are not calculated here to optimize the performance, they are obtained in sets.
	 */
	int i, j; //, cont = 0;
	//int cont2 = 0;
	//int incorrectClass = 0;											// f is the number of incorrect classifications
	double **newPred = NULL;
	int **undefPred = NULL;
	double cError = 0;
	//double thresMin, thresMax;
	double Mean;

	// alloc variables
	newPred = allocate(newPred, lines, cols);
	undefPred = allocate(undefPred, lines, cols);

	// threshold
	// set this value fo cases that it is not defined the classification, e.g. for tow class in range [0,1], if the prediciton are 0.45 and 0.55, then it is marked as a bad classification
	if (minClass == 0 || minClass == 0.1){
		//thresMin = 0.49; 		thresMax = 0.51;
		Mean = 0.5;
	}
	else{  // case for min = -1 and max = 1
		//thresMin = -0.01; 		thresMax = 0.01;
		Mean = 0;
	}


	// convert the prediciton (real values) to integer values.
	for ( i=0; i<lines; i++ ){
		for ( j=0; j<cols; j++ ){
			if ( pred[i][j] <= Mean )
				newPred[i][j] = minClass;
			else
				newPred[i][j] = maxClass;
		}
	}

	// obtain the classification error given the new prediction
	cError = obtainClassificationError(newPred, orig, lines, cols, incorrect);



	// liberate memory
	safefree(&newPred, lines);
	safefree(&undefPred, lines);

	 return (cError);
} //////////////////////////////////////////////



double classificationError(double **pred, double **orig, int lines,  int cols, double minClass, double maxClass){
	/*!
	 * This is the first metric though
	 *  Function to determinate the classification Error
	 *  Different to the classfication error winner takes all because here one pattern may have activated/deactivated (1/0) more than one output, so the normal winner take all cannot be applied.
	 *  Here each output is rounded to the maximum or minimum to create the new prediction.
	 *  It works fine for classification classes 0021, 0023 and 0024 where there are two modules and each output could produce any of the two values to classify
	 *
	 * Inputs:
	 *  pred 					the prediction
	 *  orig						the original values
	 *   lines					lines in the two matrices, i.e. outputs in the network
	 *  cols						how many steps where predicted, or classified
	 *  minClass				the min values of the clases, could be -1 or 0
	 * maxClass				the max value in classes, always expected 1;
	 *
	 *  Outputs:
	 *  errorPercentage
	 *
	 *  Comments: the min and max values of the class are not calculated here to optimize the performance, they are obtained in sets.
	 */
	int i, j; //, cont = 0;
	//int cont2 = 0;
	//int incorrectClass = 0;											// f is the number of incorrect classifications
	double **newPred = NULL;
	int **undefPred = NULL;
	double cError = 0;
	//double thresMin, thresMax;
	double Mean;

	// alloc variables
	newPred = allocate(newPred, lines, cols);
	undefPred = allocate(undefPred, lines, cols);

	// threshold
	// set this value fo cases that it is not defined the classification, e.g. for tow class in range [0,1], if the prediciton are 0.45 and 0.55, then it is marked as a bad classification
	if (minClass == 0 || minClass == 0.1){
		//thresMin = 0.49; 		thresMax = 0.51;
		Mean = 0.5;
	}
	else{  // case for min = -1 and max = 1
		//thresMin = -0.01; 		thresMax = 0.01;
		Mean = 0;
	}


	// convert the prediciton (real values) to integer values.
	for ( i=0; i<lines; i++ ){
		for ( j=0; j<cols; j++ ){
			if ( pred[i][j] <= Mean )
				newPred[i][j] = minClass;
			else
				newPred[i][j] = maxClass;
		}
	}

	// obtain the classification error given the new prediction
	cError = obtainClassificationError(newPred, orig, lines, cols);



	// liberate memory
	safefree(&newPred, lines);
	safefree(&undefPred, lines);

	 return (cError);
} //////////////////////////////////////////////

void classifErrorPerModule(double *cEperMod, double **pred, double **orig, int cols, double minClass, double maxClass, int **incorrect){
	/*!
	 * Function to determinate the classfication error per module
	 * Here is calculated the error from the different output partitions (modules)
	 * First implemented for classification tasks, not done for predictio because here it is used the error
	 * from outputs, in prediction there always is one output even it is discover modules inside the sctructure
	 *
	 * Inputs:
	 *  cEperMod 			place to save the classification erros per module
	 *  pred 					the prediction
	 *  orig						the original values
	 *  lines					lines in the two matrices, i.e. outputs in the network
	 *  cols						how many steps where predicted, or classified
	 *
	 *  Outputs:
	 *  classification errro
	 */


	int module;
	int outputInitCont = 0;

	 for (module = 0 ; module < NUM_MODULES ; module ++){ 					// measure the error for each module

		 cEperMod[module] =classificationError(&pred[outputInitCont],  &orig[outputInitCont],  NUM_OUT_Per_MOD[module], cols, minClass, maxClass, incorrect[module]);

		 if ( module+1 >= NUM_MODULES)
			 break; 																				// chack that I do not read invalid memory addres

		 outputInitCont += NUM_OUT_Per_MOD[module];				// have the first output of the next module
	 }
} ////////////////////////////////////////





double classifEWinnerTakeAll(double **pred, double **orig, int lines,  int cols, double minClass, double maxClass, int **incorrect){
	/*!
	 *  Function to determinate the classification Error,  \cite{Prechelt94c}, yao divide Classif.Erro / 100 to put the testing error rate.
	 * Thius works onl;y for data sets that do not have modules in the output partition (several outputs but taken as a single module or task)
	 *
	 * This is like the used by Yao
	 * The winner-takes-all method was used in EPNet, i.e., the output with the highest activation designates the class.
	 *
	 * Inputs:
	 *  pred 					the prediction
	 *  orig						the original values
	 *   lines					lines in the two matrices, i.e. outputs in the network
	 *  cols						how many steps where predicted, or classified
	 *  minClass				the min values of the clases, could be -1, 0 or 0.1
	 * maxClass				the max value in classes, .9 or 1 it depend how is sampled/generated the data
	 *
	 *  Outputs:
	 *  errorPercentage
	 *
	 *  Comments: the min and max values of the class are not calculated here to optimize the performance, they are obtained in sets.
	 */

	int i,j;
	//int cont2 = 0;
	//int incorrectClass = 0;											// f is the number of incorrect classifications
	double **newPred = NULL;
	double cError = 0;
	double tmp = 0;
	int pos = 0;

	// alloc variables
	newPred = allocate(newPred, lines, cols);


	// Find Maximum and save index of the maximum
	for( j=0; j<cols; j++){ 												// move over all columns
		tmp = pred[0][j];
		pos = 0;
		for( i=1; i<lines; i++ ){											// find max over all lines of this column
			// find the max value
			if ( tmp < pred[i][j] ){
				tmp = pred[i][j];
				pos = i;
			}
		}

		// after it was fount the maximum, create a new matrix changing the values predicted fot the max and min values of the class [0,1], [-1,1], [0.1,0.9], or other
		for( i=0; i<lines; i++ ){
			if ( i == pos )
				newPred[i][j] = maxClass;
			else
				newPred[i][j] = minClass;
		}
	}

	// obtain the classification error given the new prediction
	cError = obtainClassificationError(newPred, orig, lines, cols, incorrect[0]);  // as this function only works for the whole outpus, i.e. no modules, thus only it is paseed the fisrt line of incorrect

	// liberate memory
	safefree(&newPred, lines);

	 return (cError);
} //////////////////////////////////////////////



double classifEWinnerTakeAllMOD(double **pred, double **orig, int lines,  int cols, double minClass, double maxClass, double *EclassPerMod, int **incorrect){
	/*!
	 *  Function to determinate the classification Error for the what and where data set,  \cite{Prechelt94c}, yao divide Classif.Erro / 100 to put the testing error rate.
	 *  In this moment I do not implement a function for the Waht and where, so the accuracy for this TS is incorrect (in the future do that)
	 *
	 * This is like the used by Yao
	 * The winner-takes-all method was used in EPNet, i.e., the output with the highest activation designates the class.
	 *
	 * Inputs:
	 *  pred 					the prediction
	 *  orig						the original values
	 *   lines					lines in the two matrices, i.e. outputs in the network
	 *  cols						how many steps where predicted, or classified
	 *  minClass				the min values of the clases, could be -1, 0 or 0.1
	 * maxClass				the max value in classes, .9 or 1 it depend how is sampled/generated the data
	 * EclassPerMod 		place to save the classfication error per module if the variable  isModule1 == ON
	 *
	 *  Outputs:
	 *  errorPercentage
	 *
	 *  Comments: the min and max values of the class are not calculated here to optimize the performance, they are obtained in sets.
	 *
	 *  NOTE: in the furure if there are more data set like this I could generalize this funtion to apply it to any
	 *  data set, for fast I will put it only for the what and where data set
	 */

	int i,j;
	//int cont2 = 0;
	//int incorrectClass = 0;											// f is the number of incorrect classifications
	double **newPred = NULL;
	double cError = 0;
	double tmp1 = 0;				// for the first 9
	//double tmp2 = 0;				// for the 10-18
	int pos1 = 0;
	//int pos2 = 0;

	// alloc variables
	newPred = allocate(newPred, lines, cols);

/* OLD CODE WORKS
	// Find Maximum and save index of the maximum
	// for the fisrt 9 putputs and for the other 9: the first 9 represent the where and the next nine the what
	for( j=0; j<cols; j++){ 												// move over all columns
		// First 9
		tmp1 = pred[0][j];
		pos1 = 0;
		for( i=1; i<9; i++ ){											// find max over all lines of this column
			// find the max value
			if ( tmp1 < pred[i][j] ){
				tmp1 = pred[i][j];
				pos1 = i;
			}
		}
		// Second 9's
		tmp2 = pred[9][j];
		pos2 = 9;
		for( i=10; i<18; i++ ){											// find max over all lines of this column
			// find the max value
			if ( tmp2 < pred[i][j] ){
				tmp2= pred[i][j];
				pos2 = i;
			}
		}
		// after it was fount the maximum, create a new matrix changing the values predicted fot the max and min values of the class [0,1], [-1,1], [0.1,0.9], or other
		// First 9
		for( i=0; i<9; i++ ){
			if ( i == pos1 )
				newPred[i][j] = maxClass;
			else
				newPred[i][j] = minClass;
		}
		// Second 9's
		for( i=9; i<18; i++ ){
			if ( i == pos2 )
				newPred[i][j] = maxClass;
			else
				newPred[i][j] = minClass;
		}
	}
	// obtain the classification error given the new prediction
	cError = obtainClassificationError(newPred, orig, lines, cols);
	//set(newPred, lines,cols,0);
*/
	/// NEW CODE


	int module;
	int outputInitCont = 0;
	int outputLastCont = NUM_OUT_Per_MOD[0];

	for (module = 0 ; module < NUM_MODULES ; module ++){ 					// measure the error for each module

		for( j=0; j<cols; j++){ 												// move over all columns
			tmp1 = pred[outputInitCont][j];
			pos1 = outputInitCont;
			for( i=outputInitCont+1; i<outputLastCont; i++ ){											// find max over all lines of this column
				// find the max value
				if ( tmp1 < pred[i][j] ){
					tmp1 = pred[i][j];
					pos1 = i;
				}
			}
			// after it was found the maximum, create a new matrix changing the values predicted fot the max and min values of the class [0,1], [-1,1], [0.1,0.9], or other
			for( i=outputInitCont; i<outputLastCont; i++ ){
				if ( i == pos1 )
					newPred[i][j] = maxClass;
				else
					newPred[i][j] = minClass;
			}
		}

		// as the new vector for all this module is ok, now it is possible to calculate the classification error per module
		if(isModule1 == ON)
			EclassPerMod[module] = obtainClassificationError(&newPred[outputInitCont], &orig[outputInitCont], NUM_OUT_Per_MOD[module], cols, incorrect[module] );


		if ( module+1 >= NUM_MODULES)
			break; 																				// chack that I do not read invalid memory addres

		outputInitCont += NUM_OUT_Per_MOD[module];				// have the first output of the next module
		outputLastCont += NUM_OUT_Per_MOD[module+1];			// have the last output of the next module (it does nto matter that in the last module it is added a value outside NUM_OUT_Per_MOD)
	}

	// obtain the classification error given the new prediction
	cError = obtainClassificationError(newPred, orig, lines, cols);


	// liberate memory
	safefree(&newPred, lines);

	 return (cError);
} //////////////////////////////////////////////




double updateFitnessWithModularity(double fitness, double March){
	/*!
	 * Fuction to bias the evolution of modules adding the modularity to the fitness
	 *
	 * It is taken the inverse of the modularity to have a factor to add to the fitness, so a bigger modularity add a smaller penalty to the fitness
	 * The inverse is limited to a value of 50 which equals to March = 0.02, March below that is taken as the same to avoid an uncontroled grow of the penalty
	 *
	 * MU (biasModMU, global var) is used to give the importance to fitness and to modularity
	 * a value close to 1 or one gives more importance to the fitness, close to zero gives more importance to the modularity
	 *
	 */

	// Local var
	double tmp, maxAllowed = 50;
	//
	// check div by cero
	if ( March != 0 )
		tmp = 1 / March;
	else
		tmp = maxAllowed;

	// maximum allowed
	if (tmp > maxAllowed)
		tmp = maxAllowed;

	// calculate the new fitness
	fitness = ( ( 1 - biasModMU ) *  tmp ) + ( biasModMU * fitness );

	return ( fitness );

} ///////////////////////////////////////////



double obtainClassificationError(double **newPred, double **orig, int lines, int cols, int *incorrect){
	/*!
	 * Function to calculate the classification error based in the target matrix and the new prediction obtained (transformed to max and min values)
	 */

	int i, j, incorrectClass, cont2;
	double cError;

	// after the new prediciton was obtained, it is calculated the errror, it is count the number of bad classifications
	incorrectClass = 0;
	cont2 = 0;
	for( j=0; j<cols; j++){
		for( i=0; i<lines; i++ ){
			if( newPred[i][j] != orig[i][j] ){
				cont2++;
				break; 					// if one par tof the pattern is not correct, not count the rest
			}
		}
		if ( cont2 > 0 ){ 				// if there is at least one that does not match it is marked as an incorrect classification
			incorrectClass++;
			incorrect[j] = 1;
		}
		else
			incorrect[j] = 0; 				// on the contray clean the position, in case there is garbage

		cont2=0;
	}

	//saveInt((char *)"../../workspace2/genDataSetModular/res/incorrect.txt",tmp,cols);
	//saveD((char *)"../../workspace2/genDataSetModular/res/NewPred.txt", newPred, lines, cols);

	// calculate the error
	cError = ( (double) incorrectClass / (double) cols) * 100;
	return (cError);

} // End function


double obtainClassificationError(double **newPred, double **orig, int lines, int cols ){
	/*!
	 * Function to calculate the classification error based in the target matrix and the new prediction obtained (transformed to max and min values)
	 */

	int i, j, incorrectClass, cont2;
	double cError;

	// after the new prediciton was obtained, it is calculated the errror, it is count the number of bad classifications
	incorrectClass = 0;
	cont2 = 0;
	for( j=0; j<cols; j++){
		for( i=0; i<lines; i++ ){
			if( newPred[i][j] != orig[i][j] ){
				cont2++;
				break; 					// if one par tof the pattern is not correct, not count the rest
			}
		}
		if ( cont2 > 0 ){ 				// if there is at least one that does not match it is marked as an incorrect classification
			incorrectClass++;
			//incorrect[j] = 1;
		}
		cont2=0;
	}

	//saveInt((char *)"../../workspace2/genDataSetModular/res/incorrect.txt",tmp,cols);
	//saveD((char *)"../../workspace2/genDataSetModular/res/NewPred.txt", newPred, lines, cols);

	// calculate the error
	cError = ( (double) incorrectClass / (double) cols) * 100;
	return (cError);

} // End function

#endif
