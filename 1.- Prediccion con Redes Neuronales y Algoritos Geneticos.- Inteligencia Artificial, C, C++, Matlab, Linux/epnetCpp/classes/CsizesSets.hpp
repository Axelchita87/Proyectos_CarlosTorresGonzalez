/*!
 * C_sizesSets.hpp
 * Created: 6/12/09
 * Class sizesSets, contain information for the sizes of the different vector and matrices of sets
 */

#ifndef C_SIZESSETS_HPP
#define C_SIZESSETS_HPP


//Constructor
C_sizesSets::C_sizesSets(){
 	//Put them into the correct size
	Sinput = NULL;
	SinputF = NULL;
	SinputI = NULL;
	SpnI = NULL;
	StnI = NULL;
	SpnF = NULL;
	StnF = NULL;
	SinputAnn = NULL;
	SvalI = NULL;
	SvalF = NULL;

	Sinput = allocate(Sinput, 2);
	SinputF = allocate(SinputF, 2);
	SinputI = allocate(SinputI,2);
	SpnI = allocate(SpnI,2);
	StnI = allocate(StnI,2);
	SpnF = allocate(SpnF,2);
	StnF = allocate(StnF,2);
	SinputAnn = allocate(SinputAnn,2);
	SvalI = allocate(SvalI,2);
	SvalF = allocate(SvalF,2);
}


//Destructor for C_sizesSets
C_sizesSets::~C_sizesSets(){
	safefree(&SvalF);
	safefree(&SvalI);
	safefree(&SinputAnn);
	safefree(&StnF);
	safefree(&SpnF);
	safefree(&StnI);
	safefree(&SpnI);
	safefree(&SinputI);
	safefree(&SinputF);
	safefree(&Sinput);
}

void C_sizesSets::print(void){
/*	cout << "SinputF [" << SinputF[0] << "] [" << SinputF[1]<< "]" << endl;
	cout << "SinputI [" << SinputI[0] << "] [" << SinputI[1] << "]" << endl;
	cout << "SpnI [" << SpnI[0] << "] [" << SpnI[1] << "]" << endl;
	cout << "StnI [" << StnI[0] << "] [" << StnI[1] << "]" << endl;
	cout << "SpnF [" << SpnF[0] << "] [" << SpnF[1] << "]" << endl;
	cout << "StnF [" << StnF[0] << "] [" << StnF[1] << "]" << endl;
	cout << "SinputAnn [" << SinputAnn[0] << "] [" << SinputAnn[1] << "]" << endl;
	cout << "SvalI [" << SvalI[0] << "] [" << SvalI[1] << "]" << endl;
	cout << "SvalF [" << SvalF[0] << "] [" << SvalF[1] << "]" << endl;*/
}

//Function to save the Class sizes
void C_sizesSets::save2file(FILE *fwrite, char file[]){
	saveInt(Sinput, 2, fwrite, file);
	saveInt(SinputF, 2, fwrite, file);
    saveInt(SinputI, 2, fwrite, file);
    saveInt(SpnI, 2, fwrite, file);
    saveInt(StnI, 2, fwrite, file);
    saveInt(SpnF, 2, fwrite, file);
    saveInt(StnF, 2, fwrite, file);
    saveInt(SinputAnn, 2, fwrite, file);
    saveInt(SvalI, 2, fwrite, file);
    saveInt(SvalF, 2, fwrite, file);
    /// Put a band to look for error
    if((fprintf(fwrite, "%d\t",BAND)) == EOF){ printf("(Saving Calss sizes) Error writing to file '%s'...\n",file); exit(0);
    }
}

void C_sizesSets::copyClass(C_sizesSets *sizes1){
	copy(Sinput,sizes1->Sinput,2);
	copy(SinputF,sizes1->SinputF,2);
	copy(SinputI,sizes1->SinputI,2);
	copy(SpnI,sizes1->SpnI,2);
	copy(StnI,sizes1->StnI,2);
	copy(SpnF,sizes1->SpnF,2);
	copy(StnF,sizes1->StnF,2);
	copy(SinputAnn,sizes1->SinputAnn,2);
	copy(SvalI,sizes1->SvalI,2);
	copy(SvalF,sizes1->SvalF,2);
}

void C_sizesSets::clean(void){
	set(Sinput, 2,0);
	set(SinputF, 2,0);
	set(SinputI,2,0);
	set(SpnI,2,0);
	set(StnI,2,0);
	set(SpnF,2,0);
	set(StnF,2,0);
	set(SinputAnn,2,0);
	set(SvalI,2,0);
	set(SvalF,2,0);
}


#endif
