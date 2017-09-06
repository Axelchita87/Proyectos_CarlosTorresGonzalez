/*!
 * C_sets.hpp
 * Created: 26/11/09
 * Class to almacenate all the data sets, it uses another classes include in thsi file
 */

#ifndef C_SETS_HPP
#define C_SETS_HPP


//Section for the methods

//Constructor
C_sets::C_sets(){

	// allocate memory for the known size

	inputs = 0;
	finalInputs = 0;
	sizes = new C_sizesSets;

	//Set to NULL the rest of the vars that could vary in size
	input = NULL;
	inputF = NULL;            //input Final
	inputI= NULL;            //input inside epnet

	pnI= NULL;
	tnI= NULL;
	pnF= NULL;
	tnF= NULL;

	valI = NULL;
	valF = NULL;
	///////////////////////  for classification I do not use this variables (input), so it does not matter which values are used to init them
	input = allocate(input,maxdata+incremenInData, filecol);
	inputF = allocate(inputF,maxdata+incremenInData, filecol);
	inputI = allocate(inputI,maxdata+incremenInData, filecol);

	pnI = allocate( pnI, totalMaxInput * filecol, maxdata);
	tnI = allocate( tnI, sizetpos, maxdata);											// modifiying classification changed filecol by sizetpos, check if for prediction it works OK XXXXXXXXXXXXXXXXX

	pnF = allocate( pnF, totalMaxInput * filecol, maxdata);
	tnF = allocate( tnF, sizetpos, maxdata);												// modifiying classification changed filecol by sizetpos, check if for prediction it works OK XXXXXXXXXXXXXXXXX

	if (useValidation == ON){
		valI = new C_val;
		valF = new C_val;
	}



}

//Destructor
C_sets::~C_sets(){
	//check that the class is empty. debug purposes
	if(input != NULL && inputF != NULL && inputI != NULL){
		// only check the first, if they are allocated the rest must be too
		//clear some variables first

		if (useValidation == ON){
			delete valF;
			valF = NULL;
			delete valI;
			valI = NULL;
		}

		//safefree(&tnF,sizes->StnF[0]);
		safefree(&tnF, sizetpos);		// modifiying classification changed filecol by sizetpos, check if for prediction it works OK XXXXXXXXXXXXXXXXX


		//safefree(&pnF,sizes->SpnF[0]);
		safefree(&pnF,totalMaxInput * filecol);

		//safefree(&tnI,sizes->StnI[0]);
		safefree(&tnI, sizetpos);			// modifiying classification changed filecol by sizetpos, check if for prediction it works OK XXXXXXXXXXXXXXXXX


		//safefree(&pnI,sizes->SpnI[0]);
		safefree(&pnI, totalMaxInput * filecol);

		//safefree(&inputI,sizes->SinputI[0]);
		safefree(&inputI, maxdata + incremenInData );
		//safefree(&inputF,sizes->SinputF[0]);
		safefree(&inputF, maxdata + incremenInData );

		//safefree(&input,sizes->Sinput[0]);
		safefree(&input, maxdata + incremenInData );

		delete sizes;
		sizes = NULL;
	}
} //////////////////////////////////////////////////////////////////////////////

//to print it
void C_sets::print(void){
	//register int i;
	/*cout << endl;
	cout << " *** Class SETS ***" << endl;
	cout << "inputs = " << inputs[0] << endl;
	cout << "finalInputs = "<< finalInputs[0] << endl;
	cout << "inputFinal" << endl;
	//no imprimo input inside
	imprime(inputF,sizes->SinputF[0],sizes->SinputF[1]); cout << endl;

	cout << "toPredictIn" << endl;
	imprime(toPredictIn,sizetpos,Pred_stepAhead); cout << endl;

	cout << "toPredictFn" <<endl;
	imprime(toPredictFn,sizetpos,Pred_stepAhead); cout << endl;

	cout << "PnI" << endl;
	imprime(pnI,sizes->SpnI[0],sizes->SpnI[1]); cout << endl;

	cout << "TnI" << endl;
	imprime(tnI,sizes->StnI[0],sizes->StnI[1]); cout << endl;

	cout << "PnF" << endl;
	imprime(pnF,sizes->SpnF[0],sizes->SpnF[1]); cout << endl;

	cout << "TnF" << endl;
	imprime(tnF,sizes->StnF[0],sizes->StnF[1]); cout << endl;

	cout << "Set4predicnI" << endl;
	imprime(set4predicIn,sizes->SinputAnn[0],sizes->SinputAnn[1]); cout << endl;

	cout << "Set4predicFn" << endl;
	imprime(set4predicFn,sizes->SinputAnn[0],sizes->SinputAnn[1]); cout << endl;

	cout << " *** VALIDATION SETS ***" << endl;
	cout << "ValI" << endl;
	valI->print(sizes->SvalI,sizes->StnI);
	cout << "ValF" << endl;
	valF->print(sizes->SvalF,sizes->StnF);

	cout << " **** SIZES ****" << endl;
	sizes->print();

	//cout << endl << " **** PS ****" << endl;
	//ps->print(maxInputs*filecol);

	cout << endl; cout << " **** PSI ****" << endl;
	psI->print(maxInputs*filecol);
	cout << endl; cout << " **** PSF ****" << endl;
	psF->print(maxInputs*filecol);
	cout << endl; cout << " **** TSI ****" << endl;
	tsI->print(sizetpos);
	cout << endl; cout << " **** TSF ****" << endl;
	tsF->print(sizetpos);
	*/
}

//Preprocesamiento de los datos para prediccion
void C_sets::prepo(C_varN *var, C_predParam *oneS, C_predParam *pred,
					C_predParam *predI, C_predParam *predF, const char Data2Load[]){
	/*!
	 * Inputs
	 * 	oneS 					is the SSP variable
	 * pred						is the MSP variable
	 *
	 * Outputs
	 */

	//local variables
	double **input1 = NULL;
	double **p11 = NULL;
	int sizei=0, *fileLines; //, sizei2free = 0;


	//////////////////////////////////

    fileLines = &sizei;

    // load file //
    p11 = allocate(p11,fileline,var->Vfilecol);
    *fileLines = var->Vfileline; // I do this because the old code use fileLines

    // Load the file
    loadfile(p11, Data2Load);

    //Calculate the minimum and maximum////////////////////////////////////
    //This values are used inside of C_sets::normalize
    //normilize_max = allocate(normilize_max,*fileLines);
    //normilize_min= allocate(normilize_min,*fileLines);
    //normilize_max = maxCol(p11,*fileLines,filecol);
    //normilize_min = minCol(p11,*fileLines,filecol);
    //Normalize
    //saveD("txt/p11.txt", p11, *fileLines,filecol);
    //normalize(p11,*fileLines,filecol,p11,ps);
    //saveD("txt/p11norm.txt", p11, *fileLines,filecol);
    ///////////////////////////////////////////////////////////////////////

    // Fill the structures oneStep[] and predict[] for the toPredict field
    if (extraPredictions == ON && task2solve == PREDICT){
    	obtainSet2predicts(p11,*fileLines,maxdata,incremenInData,var,oneS, pred);
    }

    // Limit the size of the input vector //
    input1 = limitsize(input1,p11,fileLines,maxdata,0,var->Vfilecol);     //printf("input11\nsizei = %d, fileLines= %d\n",sizei,*fileLines); saveD((char *)"res/InputLimited.txt",input1,sizei,filecol);

    //copy the complete input (useful to predict oneStep and predict classes)
    copy(input,input1,*fileLines,var->Vfilecol);   																			//input = copyAlloc(input,input1,*fileLines,var->Vfilecol);

    sizes->Sinput[0] = *fileLines;     sizes->Sinput[1] = var->Vfilecol;

    /////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////
    // Separate different sets to forecast
    if ( isRealPredictionUsed == OFF ){
    	takeSets2Predic(predF->toPredict,input1,*fileLines, var, var->VPred_stepAhead);	    //saveD((char *)"res/toPredictF.txt",predF->toPredict,var->Vsizetpos,var->VPred_stepAhead);

    	// Delete this data (toPredict) from the original vector
    	sizei = sizei - var->VPred_stepAhead;
    }

    //inputF = copyAlloc(inputF,input1,sizei,var->Vfilecol); 	//imprime(inputF,sizei,filecol);
    copy(inputF,input1,sizei,var->Vfilecol); 	//imprime(inputF,sizei,filecol);

    //save the new size of the input into class sizes
    sizes->SinputF[0] = sizei;
    sizes->SinputF[1] = var->Vfilecol;     //saveD("res/inputF.txt",inputF,sizei,var->Vfilecol);

    // Create set for predict the final data set
    // if realPerdiction is used, here it is taken tha last pattern of dataInputN.txt
    if( kindPred == MSP )
    	takeInputAnn(predF->inputAnn,input1,*fileLines,sizes->SinputAnn,var,1);
    else if( kindPred == SSP )
    	takeInputAnn(predF->inputAnn,input1,*fileLines,sizes->SinputAnn,var, var->VPred_stepAhead);

    //saveD((char *)"res/Set4predictF.txt",predF->inputAnn,sizes->SinputAnn[0],sizes->SinputAnn[1]);

    //////////////////////////////////////////////////////////////
    // Repeat the same procedure to obtain the sets for the EA //
    //////////////////////////////////////////////////////////////

    // Separate different sets to forecast  for the inside set
    // Only in the case that it is not a real prediction
    if ( isRealPredictionUsed == OFF ){

    	takeSets2Predic(predI->toPredict,input1,*fileLines, var, predI->colsT);				// replaced  var->VPred_stepAhead by predI->coslT   check if it works for prediction

    	// Delete this data (toPredict) from the original vector //
    	sizei = sizei - predI->colsT;																					// changed too, same as before

    	//inputI = copyAlloc(inputI,input1,sizei,var->Vfilecol);
    	copy(inputI,input1,sizei,var->Vfilecol);

    	//save the new values of the input inside of the algorithm
    	sizes->SinputI[0] = sizei;
    	sizes->SinputI[1] = var->Vfilecol;     //saveD("res/inputI.txt",input1,sizei,var->Vfilecol);

    	// Create set for predict the inside data set //
    	if( kindPred == MSP )
    		takeInputAnn(predI->inputAnn,input1,*fileLines,sizes->SinputAnn,var, 1);
    	else   if( kindPred == SSP )
    		takeInputAnn(predI->inputAnn,input1,*fileLines,sizes->SinputAnn,var, predI->colsT); 			// same as before    var->VPred_stepAhead XXXXXXXXXXXXXXXXXX
    		//saveD("txtFiles/Set4predictI.txt",set4predicIn,sizes->SinputAnn[0],sizes->SinputAnn[1]);

    }
    /////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////

    // Final number of inputs //
    finalInputs = var->finalInp;
    inputs = var->inputs; //cout << "sets->inputs[0] = " << inputs[0] << "..." << "finalInputs = " << finalInputs[0] << endl;


    // Obtain p, t, pn, ps, tn, ts, for training, and p1 t1 pn1 ps1 tn1 ts1 for a
    // furter training when the EA finish

    if ( isRealPredictionUsed == OFF ){
    //firs alocate space for the matrices *********************************************************
    	//double **pI, **tI;
    	int sizep = 0;
    	sizep = calculateSizesP_T(sizes->SinputI[0], sizes->SpnI, sizes->StnI, var);

    	//pnI = allocate(pnI,var->finalInp,sizep);
    	//tnI = allocate(tnI,var->Vsizetpos,sizep);

    	diffsets(pnI,tnI,inputI,sizes->SinputI[0],var,sizep);
    	//saveD((char *)"res/pnI.txt",pnI,var->finalInp,sizep);    saveD((char * )"res/tnI.txt",tnI,sizetpos,sizep);  //saveD("res/pI.txt",pI,maxInputs*filecol,sizep);    saveD("res/tI.txt",tI,sizetpos,sizep);
    	//***********************************************************************************************
    }

    // Repeat the same for the last set //
    int sizepF = 0;
    sizepF = calculateSizesP_T(sizes->SinputF[0], sizes->SpnF, sizes->StnF, var);

    //pnF = allocate(pnF,var->finalInp,sizepF);
    //tnF = allocate(tnF,var->Vsizetpos,sizepF); //error here with more runs in the C code, check in c++

    diffsets(pnF,tnF,inputF,sizes->SinputF[0],var,sizepF);
    //saveD("txt/pnF.txt",pnF,maxInputs*filecol,sizepF);    saveD("txt/tnF.txt",tnF,sizetpos,sizepF);  saveD("txt/pF.txt",pF,maxInputs*filecol,sizepF);    saveD("txt/tF.txt",tF,sizetpos,sizepF);
    //***********************************************************************************************


    //***********************************************************************************************

    // Take validation sets //
    // calculate the new number in columns in pn tn and valpn valtn //
    if (useValidation == ON){
    	//Variables for the validation set
    	double **temppI = NULL;
    	double **temptI = NULL;
    	double **temppF = NULL;
    	double **temptF = NULL;

    	int sizevalI, sizevalF;
    	///////////////////////////////////////////////////////////////
    	// for ths inside set it is always set with a percentage value, for the outside set it is used the value at hand or not

    	if (valiAuto == ON){
    		if( useValidationOutside == ON){
    			randomPT(pnF,tnF,sizes->SpnF[0],sizes->SpnF[1],sizes->StnF[0]);							//Repeat for the final pn and tn sets
    			sizevalF = (int) (sizes->SpnF[1] * sizeValiAutoPercentage);											// Global variable indicating how many valuea are used for validation
    		}

    		// for the validation inside
    		randomPT(pnI,tnI,sizes->SpnI[0],sizes->SpnI[1],sizes->StnI[0]); 								//saveD("randompnI.txt", pnI, sizes->SpnI[0],sizes->SpnI[1]);
    		sizevalI = (int) (sizes->SpnI[1] * sizeValiAutoPercentage);
    	}
    	else{																																	// if it is set at hand
    		if( useValidationOutside == ON){
    			sizevalF = sizeValiOutside;
    		}

    		// for the val inside
    		sizevalI = sizeVali;																											// set to a value at hand, global variable
    	}

    	//set up the variables
    	sizes->SvalI[0] = sizes->SpnI[0];				// lines
    	sizes->SvalI[1] = sizevalI;							// cols

    	//Allocate space for the new sizes
    	temppI = allocate(temppI,sizes->SpnI[0],sizes->SpnI[1]-sizevalI);
    	temptI = allocate(temptI,sizes->StnI[0],sizes->StnI[1]-sizevalI);

    	// only set the number lines and cols, no allocate mem
    	valI->setVal(sizes->SvalI[0], sizes->SvalI[1],sizes->StnI[0]);

    	takevalidation(pnI,tnI,temppI,temptI,sizes->SpnI,sizes->StnI,sizevalI,valI);

    	// Replace pn tn with the new set //
    	set(pnI, totalMaxInput * filecol, maxdata,0);
    	set(tnI, sizetpos, maxdata,0);

    	sizes->SpnI[1] = sizes->SpnI[1]-sizevalI;
    	sizes->StnI[1] = sizes->StnI[1]-sizevalI;
    	   // not used this
    	   //pnI = copyAlloc(pnI,temppI,sizes->SpnI[0],sizes->SpnI[1]);
    	   //tnI = copyAlloc(tnI,temptI,sizes->StnI[0],sizes->StnI[1]);
    	copy(pnI,temppI,sizes->SpnI[0],sizes->SpnI[1]);
    	copy(tnI,temptI,sizes->StnI[0],sizes->StnI[1]);

    	if( useValidationOutside == ON){
    		sizes->SvalF[0] = sizes->SpnF[0];
    		sizes->SvalF[1] = sizevalF;

    		// allocate
    		temppF = allocate(temppF,sizes->SpnF[0],sizes->SpnF[1]-sizevalF);
    		temptF = allocate(temptF,sizes->StnF[0],sizes->StnF[1]-sizevalF);

    		// only set the number lines and cols, no allocate mem
    		valF->setVal(sizes->SvalF[0], sizes->SvalF[1],sizes->StnF[0]);

    		takevalidation(pnF,tnF,temppF,temptF,sizes->SpnF,sizes->StnF,sizevalF,valF);

    		// replace pn1 tn1 with the new set //
    		set(pnF, totalMaxInput * filecol, maxdata,0);
    		set(tnF, sizetpos, maxdata,0);

    		sizes->SpnF[1] = sizes->SpnF[1]-sizevalF;
    		sizes->StnF[1] = sizes->StnF[1]-sizevalF;
					//pnF = copyAlloc(pnF,temppF,sizes->SpnF[0],sizes->SpnF[1]);
					//tnF = copyAlloc(tnF,temptF,sizes->StnF[0],sizes->StnF[1]);
    		copy(pnF,temppF,sizes->SpnF[0],sizes->SpnF[1]);
    		copy(tnF,temptF,sizes->StnF[0],sizes->StnF[1]);

    		//liberate the memory allocated for the validation outside
    		safefree(&temptF,sizes->StnF[0]);
    		safefree(&temppF,sizes->SpnF[0]);
    	}

    	//liberate the memory allocated for the validation inside
    	safefree(&temptI,sizes->StnI[0]);
    	safefree(&temppI,sizes->SpnI[0]);
    }
    //***********************************************************************************************

    /////////////// Change the order of pn and tn in a RANDOM way /////////////////
    randomPT(pnI,tnI,sizes->SpnI[0],sizes->SpnI[1],sizes->StnI[0]); 								//saveD("randompnI.txt", pnI, sizes->SpnI[0],sizes->SpnI[1]);
    randomPT(pnF,tnF,sizes->SpnF[0],sizes->SpnF[1],sizes->StnF[0]);							//Repeat for the final pn and tn sets
    //saveD("txt/pnI.txt",pnI,maxInputs*filecol,sizep);    saveD("txt/tnI.txt",tnI,sizetpos,sizep);
    //saveD("txt/pnF.txt",pnF,maxInputs*filecol,sizepF);    saveD("txt/tnF.txt",tnF,sizetpos,sizepF);

    //liberate the memory allocated in this function
    safefree(&p11,var->Vfileline);
    safefree(&input1,sizes->Sinput[0]);

}//////////////////////// End prepo /////////////////////////////////////////////////////////////////



void C_sets::prepoClassification(C_varN *var, C_predParam *predI, C_predParam *predF, const char Data2Load[]){
	/*!
	 * Preprocesamiento de los datos para Classificacion
	 *
	 *  Inputs
	 *
	 *
	 * Outputs
	 */

	//local variables
	double **input1 = NULL;
	double **p11 = NULL;
	int sizei=0, *fileLines; //, sizei2free = 0;
	int sizeiF = 0;
	int tmp = 0;

	//////////////////////////////////

    fileLines = &sizei;

    // load file //
    p11 = allocate(p11,var->Vfileline,FILECOL);
    input1 = allocate(input1, FILECOL, var->Vfileline );											// to save the transposed matrix of p11
    *fileLines = var->Vfileline; 																				// I do this because the old code use fileLines

    if ( strcmp( Data2Load , "GenerateDataSet") == 0 || fitness_learnQuick2Genaralize == ON || generateDS_eachGen == ON)
    	generateDataSet(p11, var->Vfileline, var->finalInp, var->VnoOutputs);		// function from extended class Csets, generate the new data set
    else
    	loadfile(p11, Data2Load); 																			// Load the file


    // Transpose the matrix, to accomodate p and t as a column vector, even if they are in the same matrix
   transposeMat(p11, FILECOL, var->Vfileline, input1);

    // Save some variables to test
    //saveD((char *)"res/p11", p11, var->Vfileline, FILECOL);
    //saveD("res/input1", input1, FILECOL,  var->Vfileline );


    //copy the complete input (in case it is needed ahead)
    //copy(input,input1,*fileLines,var->Vfilecol);   																			//input = copyAlloc(input,input1,*fileLines,var->Vfilecol);
    //sizes->Sinput[0] = *fileLines;     sizes->Sinput[1] = var->Vfilecol;

    /////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////
    // the columuns have each pattern, the last line(s) of the input1 have the class each pattern belong

    // Take different sets, p and t
    sizeiF = separateSetsClassify(input1,predF->inputAnn, predF->toPredict, predF->colsT , var->Vfileline, var);

    tmp = separateSetsClassify(input1,pnF, tnF, sizeiF, sizeiF, var);
    sizes->SpnF[0] =var->finalInp;
    sizes->SpnF[1] =sizeiF;
    sizes->StnF[0] = var->Vsizetpos;
    sizes->StnF[1] = sizeiF;

    // save to test
    //saveD((char *)"res/toPredictF.txt",predF->toPredict,var->Vsizetpos,var->VPred_stepAhead);
    //saveD((char *)"res/inputAnnF.txt",predF->inputAnn, var->inputs, var->VPred_stepAhead);
    //saveD((char *)"res/pnF",pnF,var->inputs,sizeiF);
    //saveD((char *)"res/tnF",tnF,sizetpos,sizeiF);


    // Check what is the minimum and maximum of each class, could be [0,1], [-1,1] or [0.1,0.9]
    var->minClass = minMatrix(predF->toPredict,predF->linesT, predF->colsT);  							//look in all the set because if it is like class 0024 in one patter it could be just one value, e.g. 0.9 0.9 thus is needed to look in all matrix
    var->maxClass = maxMatrix(predF->toPredict,predF->linesT,predF->colsT);
    // Check that they are the same values as the configures in conf.hpp
    if (YMIN != var->minClass || YMAX != var->maxClass){
    	cout << "Csets::preroCalssification method......" << endl;
    	cout << "YMIN and YMAX values are not correct configured, correct them or check the dataInputN.txt file, ... " << endl;
    	cout << " The values where overwritten to the min and max found ... " << endl;
    	cout << "YMIN and YMAX values are not correct configured, correct them or check the dataInputN.txt file, ... " << endl;
    }
    //////////////////////////////////////////////////////////////
    // Repeat the same procedure to obtain the sets for the EA //
    //////////////////////////////////////////////////////////////

    //take the test set inside which is used to calculate the error (Ep)
    sizei = separateSetsClassify(input1,predI->inputAnn, predI->toPredict, predI->colsT, sizeiF, var);

    tmp = separateSetsClassify(input1,pnI, tnI, sizei, sizei, var);
    sizes->SpnI[0] =var->finalInp;
    sizes->SpnI[1] =sizei;
    sizes->StnI[0] = var->Vsizetpos;
    sizes->StnI[1] = sizei;

    // save to test
   /*saveD("res/toPredictI",predI->toPredict,var->Vsizetpos,sizeVali);
    saveD("res/inputAnnI",predI->inputAnn, var->inputs, sizeVali);
    saveD("res/pnI",pnI,var->inputs,sizei);
    saveD("res/tnI",tnI,sizetpos,sizei);
*/

    // Final number of inputs //
    finalInputs = var->finalInp;
    inputs = var->inputs; //cout << "sets->inputs[0] = " << inputs[0] << "..." << "finalInputs = " << finalInputs[0] << endl;


    //***********************************************************************************************
    // Take validation sets //
    // calculate the new number in columns in pn tn and valpn valtn //
    if (useValidation == ON){

    	//set up the variables
    	sizes->SvalI[0] = sizes->SpnI[0];				// lines
    	sizes->SvalI[1] = sizeVali;							// cols

    	// only set the number lines and cols, no allocate mem
    	valI->setVal(sizes->SvalI[0], sizes->SvalI[1],sizes->StnI[0]);


    	// in the next blocks comment as required,
    	// first:  the test set inside the EA is the same as the validation set - > for calssification
    	// Second: validation and test set inside are different, therefore, more information is requered, or the training set is smaller


    	/// 1
    	/// The same set to determinate the fitness during evolution is used as validation set, so it can be said that if it is used
    	// Validaton set Early stopping, the training is stopeed with the test set inside of the EA, in prediction I do not do that as
    	// it is simulated real predictions (Works until Exp b for classification)
    	copy(valI->pn, predI->inputAnn, sizes->SvalI[0], sizes->SvalI[1]);
    	copy(valI->tn, predI->toPredict, var->Vsizetpos, sizes->SvalI[1]);



    	/// 2
    	// take a new set
    	//////////////////////////////////////////////////////////////
    	// Repeat the same procedure to obtain the validation set //
    	//////////////////////////////////////////////////////////////
    	//take the validation set which acts as a test set, like predictI
 //   	sizei = separateSetsClassify(input1,valI->pn,valI->tn, sizes->SvalI[1], sizei, var);
    	// update values for pn and tn inside
  //  	sizes->SpnI[1] =sizei;
  //  	sizes->StnI[1] = sizei;

    	// save
    	//saveD("res/valIpn",valI->pn,sizes->SvalI[0], sizes->SvalI[1]);
    	//saveD("res/valItn",valI->tn, var->Vsizetpos, sizes->SvalI[1]);
    }
    //***********************************************************************************************

    /////////////// Change the order of pn and tn in a RANDOM way /////////////////
    randomPT(pnI,tnI,sizes->SpnI[0],sizes->SpnI[1],sizes->StnI[0]); 								//saveD("randompnI.txt", pnI, sizes->SpnI[0],sizes->SpnI[1]);
    randomPT(pnF,tnF,sizes->SpnF[0],sizes->SpnF[1],sizes->StnF[0]);							//Repeat for the final pn and tn sets
    //saveD("txt/pnI.txt",pnI,maxInputs*filecol,sizep);    saveD("txt/tnI.txt",tnI,sizetpos,sizep);
    //saveD("txt/pnF.txt",pnF,maxInputs*filecol,sizepF);    saveD("txt/tnF.txt",tnF,sizetpos,sizepF);

    //liberate the memory allocated in this function
    safefree(&p11,var->Vfileline);
    safefree(&input1,FILECOL);

}//////////////////////// End prepo Classification /////////////////////////////////////////////////////////////////


//////// Section for general functions used by this class ////////////
// Load the input file, data to train and predict (support ultin two colums, modiffy is required more)
// this file does not belong to the class but is leave here as it was done at the beginning
void loadfile(double **p1, const char file2Load[])
{
	// Function to read the file of any size and save it into the intput arrray
	int lines = 0, cols = 0; //, cont = 0;
	string line;
	//stringstream is(line);

	ifstream myfile (file2Load);
	if (myfile.is_open())
	{
		while ( ! myfile.eof() )
		{
			getline (myfile,line);
			if (line.empty()){
				//cout << "Reading file to save into Matrix: Empty line at position: " << lines+1  << endl;
				break;
			}

			stringstream is(line);
			while (is >> p1[lines][cols]){
				cols++;					//Count the Cols
			}
			cols = 0;
			lines++;						//Count the Lines

			if  (lines >= maxdata)
				break;
		}
		myfile.close();
	}
	else{
		cout << "Unable to open file C_sets::loadfile(double **)";
		exit(1);
	}

}//// end C_sets::loadfile() ////////////////////////////////////////////////////////////


///Function to limit the size of the input vector
double ** C_sets::limitsize(double **input1,double **p1,int *lines, int VmaxDat, int VincDat, int fileCols){

	// This function allocate space for the new matrix with the new size ///////////////
	// Inputs: 	input1;			The new limited inputs
	//			p1;				The complete data read
	//			lines			lines in the matrix (file read)
	//	Output:	input1
	//			lines			the new size of the inputs (input1)
	////////////////////////////////////////////////////////////////////////////////////

	register int i,j;

    if(*lines > VmaxDat + VincDat){			//limit the size to maxdata, drop the rest values
        for(i=0; i < VmaxDat + VincDat; i++){
            input1 = (double **) realloc(input1,((i+1)*sizeof(double *)));
            input1[i] = (double *) malloc(sizeof(double));
            for(j=0; j < fileCols; j++){
                input1[i] = (double *) realloc(input1[i],(j+1)*sizeof(double));
                input1[i][j] = p1[i][j];
            }
        }
        *lines = VmaxDat + VincDat;
    }
    else{									//if it is not bigger only copy the values to the new input
    	//input1 = copyAlloc(input1,p1,*lines,fileCols);
    	input1 = copyAlloc(input1,p1,*lines,fileCols);
    }
    return(input1);
}//////////////////////////////////////////////////////////////////////////



//Take the sets that will be predicted, test set, save in **m, no allocate memory as in takeSets2Predic
void C_sets::takeSets2Predic(double **m, double **input1, int fLines, C_varN *var, int VPred_stepAhead){
	// Input:
	//			m			where the new set is saved
	//			input1		original input
	//			fLines		lines of original input
	//			var			class varN, only to use the parameters stored there
	//			VPred_stepAhead			steps to predict, this value is not taken from var because in the SSP and MSP the values to predcit are different that the normal pred in the EA
	// Output:
	//			m			the set to be predicted

	// Local variables
    register int i,j,n;

    //m = (double **) malloc(sizeof(double *));
    for( i = 0; i < var->Vsizetpos; i++){
        //m = (double **) realloc(m,((i+1)*sizeof(double *)));
        //m[i] = (double *) malloc(sizeof(double));
        n=0;
        for(j = (fLines-VPred_stepAhead);j < fLines; j++){
            //m[i] = (double *) realloc(m[i],(n+1)*sizeof(double));
            m[i][n] = input1[j][var->VtargetPos[i]];
            //printf("targetPos[%d] = %d\n",i,targetPos[i]);
            //printf("**m[%d][%d] = %f \n",i,n,m[i][n]);
            n++;
        }
    }
}//////////////////////////////////////////////////////////////////////////



// Obtain p, t, pn, tn, ...
void C_sets::diffsets(double **p,double **t,double **input,int sizeinput,C_varN *var,int sizep)
{
	//Funtion to accomodate pn and tn

    //printf("sinput[0] = %d, sinpu[1]=%d",Sinput[0],Sinput[1]);
    register int i,j,k,con=0,con2=0;
    //int sizeinput = Sinput[0];

    // Acomodate p and t
    //p
    for (i = 0; i < sizep; i++)  //%recorro todas las columnas de pn
    {
        for (j = i; j <= i+((var->inputs * (var->delays))-var->delays); j+=var->delays)  //numero de noInputs de la red
        {
            for(k=0; k<var->Vfilecol; k++)
            {
                p[con][i] = input[j][k];
                //printf("i=%d j=%d, k=%d\t",i,j,k);
                //printf("p[%d][%d] = %f\n",con,i,p[con][i]);
                con++;
            }
        }
        con = 0;
        //t
        j = i+(( var->inputs  * (var->delays)) - var->delays) + DeltaT;
        for(k=0; k<sizetpos; k++)
        {
            t[con2][i] = input[j][var->VtargetPos[k]];						//in this way only could be one target to predict, modify if the network is suppoose to have more than one output for the prediction task
            //printf("i=%d j=%d, k=%d\t",i,j,k);
            //printf("t[%d][%d] = %f\n",con2,i,t[con2][i]);
            con2++;
        }
        con2 = 0;
    }

    //preprocessing to normalize the data
    //normalize(p,maxInputs*filecol,sizep,pn,ps);
    //normalize(t,sizetpos,sizep,tn,ts);
    //imprime(tn,sizetpos,sizep);
}//////////////////////////////////////////////////////////////////////////




// Take the sets for the validation set
// the sets are taken from the end of the set
void C_sets::takevalidation(double **pn,double **tn,double **tempp, double **tempt,int *Spn, int *Stn, int sizeval,C_val *val)
{
    register int i,j,cont=0;
    int line = Spn[0], col = Spn[1],linet = Stn[0];
    //int valcol = Spn[1]-sizeval;
    //printf("line %d, col %d valcol %d\n",line,col,valcol);
    //create tempn,temptn
    for(i=0; i<line; i++)
    {
        for(j=0; j<col-sizeval; j++)
        {
            tempp[i][j] = pn[i][j];
        }
    }
    for(i=0; i<linet; i++)
    {
        for(j=0; j<col-sizeval; j++)
        {
            tempt[i][j] = tn[i][j];
        }
    }
    // val
    for(i=0; i<line; i++)
    {
        for(j=col-sizeval; j<col; j++)
        {
            val->pn[i][cont] = pn[i][j];
            //printf("val %f",val->pn[i][j]);
            cont++;
        }
        cont=0;
    }
    cont=0;
    for(i=0; i<linet; i++)
    {
        for(j=col-sizeval; j<col; j++)
        {
            val->tn[i][cont] = tn[i][j];
            //printf("val %f",val->tn[i][j]);
            cont++;
        }
        cont=0;
    }
 }/////////////////////////////////////////////////////////////////////////
 //////////////////////////////////////////////////////////////////////////

void C_sets::save2file(FILE *fwrite, char file[]){
	//Save in reverse order as they were declared, first sizes, ....
	//save sizes
	sizes->save2file(fwrite, file);

	if (useValidation == ON){
		//valF (pn and tn)
		valF->save2file(fwrite, file);
		//valI (pn and tn)
		valI->save2file(fwrite, file);
	}

	///////////////////// Section for tnF, pnF tnI pn I /////
	//tnF
	saveD(tnF, sizes->StnF[0], sizes->StnF[1], fwrite, file);
	//pnF
	saveD(pnF, sizes->SpnF[0], sizes->SpnF[1], fwrite, file);
	//tnI
	saveD(tnI, sizes->StnI[0], sizes->StnI[1], fwrite, file);
	//pnI
	saveD(pnI, sizes->SpnI[0], sizes->SpnI[1], fwrite, file);

	// section for inputI inputF finalInputs inputs // with this finis sets
	//inputI
	saveD(inputI, sizes->SinputI[0], sizes->SinputI[1], fwrite, file);
	//inputF
	saveD(inputF, sizes->SinputF[0], sizes->SinputF[1], fwrite, file);
	//input
	saveD(input, sizes->Sinput[0], sizes->Sinput[1], fwrite, file);

	//finalInputs
	fprintf(fwrite, "%d\t",finalInputs);
	//inputs
	fprintf(fwrite, "%d\t",inputs);
	///////////////////////////////////////////////////////////////////////
	/// Put a band to look for error
	if((fprintf(fwrite, "%d\t",BAND)) == EOF){
		printf("Error writing to file '%s'...\n",file); exit(0);
	}
	///////////////////////////////////////////////////////////////////////

}



void C_sets::copyAllocClass(C_sets *sets1){
	// Copy sets1 into the actual set (this) allocating memory

	inputs = sets1->inputs;
	finalInputs = sets1->finalInputs;

	sizes->copyClass(sets1->sizes);

	input = copyAlloc(input, sets1->input, sets1->sizes->Sinput[0], sets1->sizes->Sinput[1]);
 	inputF = copyAlloc(inputF, sets1->inputF, sets1->sizes->SinputF[0], sets1->sizes->SinputF[1]);
	inputI = copyAlloc(inputI, sets1->inputI, sets1->sizes->SinputI[0], sets1->sizes->SinputI[1]);

	pnI = copyAlloc(pnI, sets1->pnI, sets1->sizes->SpnI[0], sets1->sizes->SpnI[1]);
	tnI = copyAlloc(tnI, sets1->tnI, sets1->sizes->StnI[0], sets1->sizes->StnI[1]);
	pnF = copyAlloc(pnF, sets1->pnF, sets1->sizes->SpnF[0], sets1->sizes->SpnF[1]);
	tnF = copyAlloc(tnF, sets1->tnF, sets1->sizes->StnF[0], sets1->sizes->StnF[1]);

	if (useValidation == ON){
		valI->copyAllocClass(sets1->valI);
		valF->copyAllocClass(sets1->valF);
	}

}

void C_sets::copyClass(C_sets *sets1){
	// Copy sets1 into the actual set (this)

	inputs = sets1->inputs;
	finalInputs = sets1->finalInputs;

	sizes->copyClass(sets1->sizes);

	copy(input, sets1->input, sets1->sizes->Sinput[0], sets1->sizes->Sinput[1]);
 	copy(inputF, sets1->inputF, sets1->sizes->SinputF[0], sets1->sizes->SinputF[1]);
	copy(inputI, sets1->inputI, sets1->sizes->SinputI[0], sets1->sizes->SinputI[1]);

	copy(pnI, sets1->pnI, sets1->sizes->SpnI[0], sets1->sizes->SpnI[1]);
	copy(tnI, sets1->tnI, sets1->sizes->StnI[0], sets1->sizes->StnI[1]);
	copy(pnF, sets1->pnF, sets1->sizes->SpnF[0], sets1->sizes->SpnF[1]);
	copy(tnF, sets1->tnF, sets1->sizes->StnF[0], sets1->sizes->StnF[1]);

	if (useValidation == ON){
		valI->copyClass(sets1->valI);
		valF->copyClass(sets1->valF);
	}

}

void C_sets::clean(){

	inputs = 0;
	finalInputs = 0;
	sizes->clean();

	set(input,maxdata+incremenInData, filecol,0);
	set(inputF,maxdata+incremenInData, filecol,0);
	set(inputI,maxdata+incremenInData, filecol,0);

	set( pnI, totalMaxInput * filecol, maxdata,0);
	set( tnI, filecol, maxdata,0);

	set( pnF, totalMaxInput * filecol, maxdata,0);
	set( tnF, sizetpos, maxdata,0);							// changed for classification filecol for sizetpos Check fot prediciton XXXXXXXXXXXXXXXXXXXXXXXXXXXXx

	if (useValidation == ON){
		valI->clean();
		valF->clean();
	}
}



void C_sets::obtainSet2predicts(double **input,int fLines,int VmaxDat, int VincData,
		C_varN *var, C_predParam *oneS, C_predParam *pred){
	//Inputs: //////////////////////////////////////////////////////////
	// 			input			inputfile complete
	//			flines			lines in the file
	//			Vmaxdat			to limit the size to a maximum
	//			VincDat			increment in the allowed inputs to extract the sets to be predicted
	//			var				class with the network information
	//			oneS			set oneStep
	//			pred			set predcit
	// Output:
	//			inputAnn and toPredict	this two filed are saved in the classes
	/////////////////////////////////////////////////////////////////////

	// local var
	int i, *fileLines = NULL;
	double **Input = NULL;	//temporal copy to no modify the original
	double **newInput = NULL;

	// variables for the iterate prediction
	double **inputsANN = NULL;
	int *tempSinputsANN = NULL;


	int *Spn = NULL, *Stn = NULL;					// temporal, cause the funtion return the size
	double **p = NULL, **t = NULL;
	int sizep = 0;

	double ** inputsAnnOneStep = NULL;
	//////////////////////////////////////////////


	fileLines = &fLines;
	int tempFlines = fLines;		// to liberate memory for Input

	// copy to temporal input
	Input = copyAlloc(Input,input,fLines,var->Vfilecol);

	//limit size
	newInput = limitsize(newInput,Input,fileLines,VmaxDat,VincData,var->Vfilecol);

	//Obtain the inputs for the ANN to predict the sets for the predcit class (iterate prediction)
	inputsANN = allocate(inputsANN,var->finalInp,1);
	tempSinputsANN = allocate(tempSinputsANN,2);
	takeInputAnn(inputsANN,newInput,(*fileLines - VincData),tempSinputsANN,var, 1);     					//one becasue it is MSP
	//saveD("txtFiles/inputsANNXXX.txt",inputsANN,var->VmaxInputs,1); ////////////////////////////

	// Now obtain the sets for the prediciton with oneStep ahead predicntong 'n' steps
	Spn = allocate(Spn,2);
	Stn = allocate(Stn,2);

	//calculate the columns in pn and tn
	sizep = calculateSizesP_T(*fileLines, Spn, Stn, var);

	p = allocate(p,var->finalInp,sizep);
	t = allocate(t,var->Vsizetpos,sizep);

	// obtain p and t form the input
	diffsets(p,t,newInput,*fileLines,var,sizep);

	// now take only 'incremenInData' (global variable) values of the last part of the columns to have the required inputs
	int start2take = sizep - incremenInData;

	inputsAnnOneStep = allocate(inputsAnnOneStep,var->finalInp,incremenInData);
	copyOffsetCol(inputsAnnOneStep, p, var->finalInp, sizep, start2take, 0); // change here the zero, it was added to the function, in case of error check this
	//saveD("txtFiles/pnOffset.txt",inputsAnnOneStep,var->VmaxInputs*var->Vfilecol,incremenInData);    //saveD("txt/tnI.txt",tnI,sizetpos,sizep);  saveD("txt/pI.txt",pI,maxInputs*filecol,sizep);    saveD("txt/tI.txt",tI,sizetpos,sizep);
	//***********************************************************************************************


	// Fill all the fileds of toPredict in oneStep and predict structures
	int cont = *fileLines;
	int contCols = VincData;
	for(i = numDiffPredict-1; i>=0; i--){
		// copy the sets to be predict by the ANN
		takeSets2Predic(oneS[i].toPredict,newInput,cont, var, contCols);
		takeSets2Predic(pred[i].toPredict,newInput,cont, var, contCols);

		// copy the inputs to predict 'toPredict' for the iterate case
		copy(pred[i].inputAnn,inputsANN,var->finalInp,1);

		cont -= contCols/2;
		contCols /= 2;
	}

	// copy the inputs of the ANN for the oneStep prediction for all classes in the vector/cell
	cont = initialStepPred;
	for(i = 0; i < numDiffPredict; i++){
		// copy the inputs to predict 'toPredict' for the one step case
		copy(oneS[i].inputAnn, inputsAnnOneStep, var->finalInp, cont);
		cont *= 2;
	}


	//////////////////////////////////////////////////////////////////////////
	// deallocate mem
	safefree(&inputsAnnOneStep,var->finalInp);

	safefree(&t,var->Vsizetpos);
	safefree(&p,var->finalInp);

	safefree(&Stn);
	safefree(&Spn);

	safefree(&tempSinputsANN);
	safefree(&inputsANN,var->finalInp);

	safefree(&newInput,fLines);
	safefree(&Input, tempFlines);

	fileLines = NULL;

}////////////////////////////////////////////////////////////////////////////////////////////////////


#endif
