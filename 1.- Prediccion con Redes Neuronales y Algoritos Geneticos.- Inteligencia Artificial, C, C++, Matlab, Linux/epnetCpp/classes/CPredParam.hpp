/*!
 * CPredParam.hpp
 * Created: 27/01/10
 * Class for Prediction parameters
 */

#ifndef C_PREDPARAM_HPP
#define C_PREDPARAM_HPP

////// now C_PredParam /////
//Constructor
C_predParam::C_predParam(){
	linesT = 0;
	colsT = 0;
	linesP = 0;
	colsP = 0;

	inputAnn = NULL;
	toPredict = NULL;
	pred = NULL;
	incorrectPred = NULL;

	// Metric to measure Errors
	// Prediction
	NRMSE = NULL;
	RMSE = NULL;

	// Classification
	Epercentage = 0;					//used in classification for the errorr in yao, and here too
	EpercentagePerModule = NULL;
	classifError = 0;
	classifErrorPerModule = NULL;

	accuracyPoint = NULL;
	accuracy = NULL;

	//////////////////////////////////// LATER MODIFY THIS FUNCTION, PREDICi AND PREDICRf SHOULD BE INITIALIZED DIFFERENTLY TO AVOID HAVING THE CONSTRAIN THAT Pred_stepAhead NEEDS TO BE BIGGER THAN Pred_stepAheadInside

	inputAnn = allocate(inputAnn, totalMaxInput * filecol, Pred_stepAhead + incremenInData);
	toPredict = allocate(toPredict, sizetpos , Pred_stepAhead + incremenInData);						// changed filecol by sizetpos for classificatin, check prediction works ok
	pred = allocate(pred, sizetpos, Pred_stepAhead + incremenInData);											// changed filecol by sizetpos for classificatin, check prediction works ok
	incorrectPred = allocate(incorrectPred, NUM_MODULES, Pred_stepAhead + incremenInData);
	NRMSE = allocate(NRMSE, sizetpos);												// changed filecol by sizetpos for classificatin, check prediction works ok

	// new values
	//MSE = allocate(MSE, sizetpos);				// changed filecol by sizetpos for classificatin, check prediction works ok
	RMSE = allocate(RMSE, sizetpos);			// changed filecol by sizetpos for classificatin, check prediction works ok

	EpercentagePerModule = allocate(EpercentagePerModule, NUM_MODULES); 				//	NUM_MODULES is a global var and was previously set up
	//initialize errors
	set(EpercentagePerModule, NUM_MODULES, 100);

	if ( task2solve == CLASSIFY  && isModule1 == ON)
		classifErrorPerModule = allocate(classifErrorPerModule, NUM_MODULES);

	accuracyPoint = allocate(accuracyPoint, sizetpos, Pred_stepAhead + incremenInData);		// changed filecol by sizetpos for classificatin, check prediction works ok
	accuracy = allocate(accuracy, sizetpos);			// changed filecol by sizetpos for classificatin, check prediction works ok

}

//Destructor
C_predParam::~C_predParam(){
	if(inputAnn != NULL && toPredict != NULL && pred != NULL && accuracyPoint && NRMSE != NULL
		&& accuracy !=NULL){

		//dealocate matrices
		safefree(&accuracy);

		//safefree(&accuracyPoint, linesT);
		safefree(&accuracyPoint, sizetpos);			// changed filecol by sizetpos for classificatin, check prediction works ok
		safefree(&EpercentagePerModule);

		if ( task2solve == CLASSIFY  && isModule1 == ON)
			safefree(&classifErrorPerModule);

		safefree(&RMSE);
		safefree(&NRMSE);

		//safefree(&pred, linesT);
		safefree(&pred, sizetpos);					// changed filecol by sizetpos for classificatin, check prediction works ok
		safefree(&incorrectPred, NUM_MODULES);

		//safefree(&toPredict,linesT);
		safefree(&toPredict,sizetpos);				// changed filecol by sizetpos for classificatin, check prediction works ok

		//safefree(&inputAnn,maxInp);
		safefree(&inputAnn, totalMaxInput * filecol);
	}
}


void C_predParam::set_predParam(int line,int col, int InputsNet, int numImpAnn){
	/*!
	 * Allocate space for the class
	 *
	 *   Inputs:
	 * 		line 							the lines of the target vector, toPredict or toClassify
	 * 		col							the columns of the target vector, pred_step_ahead, horizont to predict or classify
	 * 		InputsNet					the lines of the input vector, i.e. the number of inputs to the ANN
	 * 		numImpAnn				the number of patterns to feed into the network
	 */

	linesT = line;
	colsT = col;
	linesP = InputsNet;
	colsP = numImpAnn;

	/*inputAnn = allocate(inputAnn,maxInp,numImpAnn);
	toPredict = allocate(toPredict, linesT, stepsAhead);
	pred = allocate(pred, linesT, stepsAhead);
	NRMSE = allocate(NRMSE, linesT);
	accuracyPoint = allocate(accuracyPoint, linesT, stepsAhead);
	accuracy = allocate(accuracy, linesT);*/
}

void C_predParam::save2file(FILE *fwrite, char file[]){
// save all variables from Class PredParam

	fprintf(fwrite, "%d\t",linesT);
	fprintf(fwrite, "%d\t",colsT);
	fprintf(fwrite, "%d\t",linesP);
	fprintf(fwrite, "%d\t",colsP);

	// save inputAnn
	//saveD(inputAnn, linesP, colsP, fwrite, file);

	//toPredict
	//saveD(toPredict, linesT, colsT, fwrite, file);

	// save prediciton
	saveD(pred, linesT, colsT, fwrite, file);
	saveInt(incorrectPred, NUM_MODULES, colsT, fwrite, file);

	/// Put a band to look for error
	if((fprintf(fwrite, "%d\t",BAND)) == EOF){ printf("(Saving Calss sizes) Error writing to file '%s'...\n",file); exit(0); }


	// save NRMSE
	saveD(NRMSE, linesT, fwrite, file);
	saveD(RMSE, linesT, fwrite, file);

	fprintf(fwrite, "%g\t",Epercentage);

	saveD(EpercentagePerModule, NUM_MODULES, fwrite, file);

	if ( task2solve == CLASSIFY  && isModule1 == ON){
		saveD(classifErrorPerModule,NUM_MODULES, fwrite, file);
	}


	fprintf(fwrite, "%g\t",classifError);

	// save accuracyPoint
	saveD(accuracyPoint, linesT, colsT, fwrite, file);

	// save accuracy
	saveD(accuracy, linesT, fwrite, file);

	/// Put a band to look for error
	if((fprintf(fwrite, "%d\t",BAND)) == EOF){ printf("(Saving Calss sizes) Error writing to file '%s'...\n",file); exit(0);	}
}


// Allocate space for the class
void C_predParam::copyAllocClass(C_predParam *pp){
	// line is sizetpos and col is Pred_stepAhead
	linesT = pp->linesT;
	colsT = pp->colsT;
	linesP = pp->linesP;
	colsP = pp->colsP;

	inputAnn = copyAlloc(inputAnn,pp->inputAnn,linesP,colsP);
	toPredict = copyAlloc(toPredict, pp->toPredict, linesT, colsT);
	pred = copyAlloc(pred, pp->pred, linesT, colsT);
	incorrectPred = copyAlloc(incorrectPred, pp->incorrectPred, NUM_MODULES, colsT);

	NRMSE = copyAlloc(NRMSE, pp->NRMSE, linesT);
	RMSE = copyAlloc(RMSE, pp->RMSE, linesT);
	Epercentage = pp->Epercentage;

	EpercentagePerModule = copyAlloc( EpercentagePerModule, pp->EpercentagePerModule, NUM_MODULES);

	if ( task2solve == CLASSIFY  && isModule1 == ON){
		classifErrorPerModule = copyAlloc(classifErrorPerModule, pp->classifErrorPerModule, NUM_MODULES);
	}

	classifError = pp->classifError;


	accuracyPoint = copyAlloc(accuracyPoint, pp->accuracyPoint,linesT, colsT);
	accuracy = copyAlloc(accuracy, pp->accuracy, linesT);
}



void C_predParam::copyClass(C_predParam *pp){
	// Method to copy the class
	// no memory allocation

	linesT = pp->linesT;
	colsT = pp->colsT;
	linesP = pp->linesP;
	colsP = pp->colsP;

	copy(inputAnn,pp->inputAnn,linesP,colsP);
	copy(toPredict, pp->toPredict, linesT, colsT);
	copy(pred, pp->pred, linesT, colsT);
	copy(incorrectPred, pp->incorrectPred, NUM_MODULES, colsT);

	// Errors
	copy(NRMSE, pp->NRMSE, linesT);
	copy(RMSE, pp->RMSE, linesT);
	Epercentage = pp->Epercentage;

	copy( EpercentagePerModule, pp->EpercentagePerModule, NUM_MODULES);

	if ( task2solve == CLASSIFY  && isModule1 == ON){

		copy(classifErrorPerModule, pp->classifErrorPerModule, NUM_MODULES);
	}

	classifError = pp->classifError;


	copy(accuracyPoint, pp->accuracyPoint, linesT, colsT);
	copy(accuracy, pp->accuracy, linesT);

}

void C_predParam::imprime(void){
	cout << "Lines = " << linesT << endl;
	cout << "colsT = " << colsT << endl;
	cout << "linesP " << linesP << endl;
	cout << "colsP" << colsP << endl;
/*
		inputAnn = allocate(inputAnn,linesP,colsP);
		toPredict = allocate(toPredict, linesT, colsT);
		pred = allocate(pred, linesT, colsT);
		NRMSE = allocate(NRMSE, linesT);
		accuracyPoint = allocate(accuracyPoint, linesT, colsT);
		accuracy = allocate(accuracy, linesT);
		*/
}

void C_predParam::clean(void){
	linesT = 0;
	colsT = 0;
	linesP = 0;
	colsP = 0;

	set(inputAnn, totalMaxInput * filecol, Pred_stepAhead + incremenInData,0);
	set(toPredict, filecol , Pred_stepAhead + incremenInData,0);
	set(pred, filecol, Pred_stepAhead + incremenInData,0);
	set(incorrectPred, NUM_MODULES, Pred_stepAhead + incremenInData,0);

	set(NRMSE, filecol,0);
	set(RMSE, filecol,0);
	Epercentage = 0;

	set( EpercentagePerModule, NUM_MODULES, 0);

	if ( task2solve == CLASSIFY  && isModule1 == ON)
		set(classifErrorPerModule, NUM_MODULES, 0);


	classifError = 0;


	set(accuracyPoint, filecol, Pred_stepAhead + incremenInData,0);
	set(accuracy, filecol,0);

}


#endif
