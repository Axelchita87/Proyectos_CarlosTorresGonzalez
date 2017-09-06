/*!
 * Clasess_Net.hpp
 * Created: 2/03/10
 * Contain clases used by network, EPOCHS and sizesN, the class sets in in another file
 */

#ifndef CLASESS_VARN_HPP
#define CLASESS_VARN_HPP


//Constructor for sizesN
C_varN::C_varN(){
	// Variables that I need to allocate
	Vepochs = NULL;
	VtargetPos = NULL;


	Vepochs = allocate(Vepochs, 2);
	VtargetPos = allocate(VtargetPos, sizetpos);		// defined to work with one output, change this if you want to predict more than one value at the same time
																				// changed for classification from 1 to sizetpos
	//Normal variables
	/*VmaxInputs = 0;
	VmaxDelays = 0;
	VmaxHidden = 0;
	*/
	VnoOutputs = 0;												// for classification it indicate how many classes there are

	inputs = 0;
	finalInp = 0;
	delays = 0;
	hidden = 0;

	Vfileline = 0;
	Vfilecol = 0;

	Vsizetpos = 0;
	VPred_stepAhead = 0;

	minClass = 0; 				// Thay are set up in the sets->prepoClassificaton
	maxClass = 0;

	counterLoaded = 0;

}

C_varN::~C_varN(){

	safefree(&VtargetPos);
	safefree(&Vepochs);

}

void C_varN::set_values(int *epochs1, int *targetPos1,int maxInputs1, int maxHidden1,
						int noOutputs1, int fileline1, int filecol1, int sizetpos1,
						int Pred_stepAhead1, int input,int finput, int delay, int hidden1){

	copy(Vepochs,epochs1,2);
	copy(VtargetPos,targetPos1, sizetpos);					// changed for classification from 1 to sizetpos

	/*VmaxInputs = maxInputs1;
	VmaxDelays = maxDelays;
	VmaxHidden = maxHidden1;
	*/
	VnoOutputs = noOutputs1;

	inputs = input;
	finalInp = finput;
	delays = delay;
	hidden = hidden1;

	Vfileline = fileline1;
	Vfilecol = filecol1;

	Vsizetpos = sizetpos1;
	VPred_stepAhead = Pred_stepAhead1;

}


// Copy from var to ( this )
void C_varN::copyClass(C_varN *var){

	try{

		copy(Vepochs,var->Vepochs,2);
		copy(VtargetPos,var->VtargetPos,1);

		/*VmaxInputs = var->VmaxInputs;
		VmaxDelays = var->VmaxDelays;
		VmaxHidden = var->VmaxHidden;*/
		VnoOutputs = var->VnoOutputs;

		inputs = var->inputs;
		finalInp = var->finalInp;
		delays = var->delays;
		hidden = var->hidden;

		Vfileline = var->Vfileline;
		Vfilecol = var->Vfilecol;

		Vsizetpos = var->Vsizetpos;
		VPred_stepAhead = var->VPred_stepAhead;

		minClass = var->minClass;
		maxClass = var->maxClass;

		counterLoaded = var->counterLoaded;
	}
	catch (...) {
		cout << "Something were wrong copying the VarN class: C_varN::copyClass " << endl;
		processException();
		exit(EXIT_FAILURE);    // exit main() with error status
	}
}

void C_varN::save2file(FILE *fwrite, char file[]){
	/*!
	 *  Method to save all the class to a file
	 */
    // save Vepochs
    saveInt(Vepochs, 2, fwrite, file);
    // targetpos
    saveInt(VtargetPos, sizetpos, fwrite, file);

    /*fprintf(fwrite, "%d\t",VmaxInputs);
    fprintf(fwrite, "%d\t",VmaxDelays);
    fprintf(fwrite, "%d\t",VmaxHidden);*/
    fprintf(fwrite, "%d\t",VnoOutputs);

    // not that for the assymetric algorithm of the evolution of inputs for classification tasks
    // this value only represent the total number of inputs but there may be less than that
    fprintf(fwrite, "%d\t",inputs);

    fprintf(fwrite, "%d\t",finalInp);
    fprintf(fwrite, "%d\t",delays);
    fprintf(fwrite, "%d\t",hidden);


    fprintf(fwrite, "%d\t",Vfileline);
    fprintf(fwrite, "%d\t",Vfilecol);

    fprintf(fwrite, "%d\t",Vsizetpos);
    fprintf(fwrite, "%d\t",VPred_stepAhead);

    // this var are not declared in the class, theya re global, in case it is needed inclde in the class
    fprintf(fwrite, "%d\t",Pred_stepAheadInside);
    fprintf(fwrite, "%d\t",FILECOL);							// have the number of columns in the file for classification, filecol = 1 for this case

    fprintf(fwrite, "%f\t",minClass);
    fprintf(fwrite, "%f\t",maxClass);

    fprintf(fwrite, "%d\t",counterLoaded);

    ///////////////////////////////////////////////////////////////////////
    /// Put a band to look for error
    if((fprintf(fwrite, "%d\t",BAND)) == EOF){
    	printf("Error writing to file '%s'...\n",file); exit(0);
    }
    ///////////////////////////////////////////////////////////////////////
}
//////////////////////////////////////////////////////////////////////////////

//Constructor for sizesN
void C_varN::clean(void){

	set(Vepochs, 2,0);
	set(VtargetPos, 1,0);

	//Normal variables
	/*VmaxInputs = 0;
	VmaxDelays = 0;
	VmaxHidden = 0;*/
	VnoOutputs = 0;

	inputs = 0;
	finalInp = 0;
	delays = 0;
	hidden = 0;

	Vfileline = 0;
	Vfilecol = 0;

	Vsizetpos = 0;
	VPred_stepAhead = 0;

	minClass = 0;
	maxClass = 0;

	counterLoaded = 0;

}


#endif
