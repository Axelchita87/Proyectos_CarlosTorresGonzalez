/*!
 * C_val.hpp
 * Created: 6/12/09
 * Class val, contain the validation set for the ANN, val.p and val.t
 */

#ifndef C_VAL_HPP
#define C_VAL_HPP

////////// Now for C_val  ////////////

//Constructor
C_val::C_val(){
	linep = 0;
	colp = 0;
	linet = 0;

	pn = NULL;
	tn = NULL;

	pn = allocate(pn, totalMaxInput * filecol, maxdata);
	tn = allocate(tn, sizetpos, maxdata);															// changed for classification   filecol by sizetpos, Check Predc works XXXXXXXXXXXXXXXXXXXXXXxxxxx


}

//Destructor
C_val::~C_val(){

	//safefree(&tn,linet);
	safefree(&tn,sizetpos);																						// changed for classification   filecol by sizetpos, Check Predc works XXXXXXXXXXXXXXXXXXXXXXxxxxx

	//safefree(&pn,linep);
	safefree(&pn,totalMaxInput * filecol);
}

void C_val::setVal(int lp, int cp, int lt){
	linep = lp;
	colp = cp;
	linet = lt;

	//pn = allocate(pn,linep, colp);
	//tn = allocate(tn,linet , colp);

}



//to print it
void C_val::print(int *Sval, int *Stn){
/*	cout << "Val.pn" << endl;
	imprime(pn,Sval[0],Sval[1]); cout << endl;
	cout << "Val.tn" << endl;
	imprime(tn,Stn[0],Sval[1]); cout << endl;*/
}

void C_val::copyAllocClass(C_val *val1){
	linep = val1->linep;
	colp = val1->colp;
	linet = val1->linet;

	pn = copyAlloc(pn,val1->pn,val1->linep,val1->colp);
	tn = copyAlloc(tn,val1->tn, val1->linet,val1->colp);
}

void C_val::copyClass(C_val *val1){
	linep = val1->linep;
	colp = val1->colp;
	linet = val1->linet;
	copy(pn, val1->pn, val1->linep, val1->colp);
	copy(tn,  val1->tn,  val1->linet, val1->colp);
}

//Function to save the Class sizes
void C_val::save2file(FILE *fwrite, char file[]){
	saveD(pn, linep, colp, fwrite, file);
	saveD(tn, linet, colp, fwrite, file);
	/// Put a band to look for error
	if((fprintf(fwrite, "%d\t",BAND)) == EOF){ printf("(Saving Calss val) Error writing to file '%s'...\n",file); exit(0);
	}
}


//Constructor
void C_val::clean(void){
	linep = 0; /// XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX error here no validation
	colp = 0;
	linet = 0;

	set(pn, totalMaxInput * filecol, maxdata,0);
	set(tn, sizetpos, maxdata,0);									// changed for classification   filecol by sizetpos, Check Predc works XXXXXXXXXXXXXXXXXXXXXXxxxxx
}


#endif
