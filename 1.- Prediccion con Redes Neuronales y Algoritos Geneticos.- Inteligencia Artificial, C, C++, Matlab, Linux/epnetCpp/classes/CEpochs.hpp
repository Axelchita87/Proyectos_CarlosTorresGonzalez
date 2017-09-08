/*!
 * Clasess_Net.hpp
 * Created: 2/03/10
 * Modified: 21 Apr 2011
 * Author: 	Carlos Torres and Victor Landassuri
 *
 * Contain clases used by network, EPOCHS and sizesN, the class sets in in another file
 */

#ifndef CLASESS_EPOCHS_HPP
#define CLASESS_EPOCHS_HPP

//Constructor C_Epochs
C_Epochs::C_Epochs(){
	Etr = NULL;
	Eval = NULL;
	GL = NULL;
	Pk = NULL;
	PQalfa = NULL;
	//////////////////////////////////

	Etr = allocate(Etr, epochsK[1]);
	Eval = allocate(Eval,epochsK[1]);
	GL = allocate(GL, epochsK[1]);
	Pk = allocate(Pk, epochsK[1]);
	PQalfa = allocate(PQalfa, epochsK[1]);
}

C_Epochs::~C_Epochs(){

	safefree(&PQalfa);
	safefree(&Pk);
	safefree(&GL);
	safefree(&Eval);
	safefree(&Etr);

}
/*
//Set Epochs with the values of network->varN
void C_Epochs::set_Epochs(int cols){
}
*/

//Copy allocating Epochs
void C_Epochs::copyAllocClass(C_Epochs *E, C_varN *var){

		Etr = copyAlloc(Etr,E->Etr, var->Vepochs[1]);
		Eval = copyAlloc(Eval, E->Eval, var->Vepochs[1]);
		GL = copyAlloc(GL, E->GL, var->Vepochs[1]);
		Pk = copyAlloc(Pk, E->Pk, var->Vepochs[1]);
		PQalfa = copyAlloc(PQalfa, E->PQalfa, var->Vepochs[1]);

}


//Copy Class
void C_Epochs::copyClass(C_Epochs *E, C_varN *var){
	copy(Etr,E->Etr, var->Vepochs[1]);
	copy(Eval, E->Eval, var->Vepochs[1]);
	copy(GL, E->GL, var->Vepochs[1]);
	copy(Pk, E->Pk, var->Vepochs[1]);
	copy(PQalfa, E->PQalfa, var->Vepochs[1]);
}


//Clear Class
void C_Epochs::setClass2val(int cols,int value){
	set(Etr,cols, value);
	set(Eval,cols, value);
	set(GL,cols, value);
	set(Pk,cols, value);
	set(PQalfa,cols, value);
}

// Modifi this method, update to var-> , ..... as the previuo method
void C_Epochs::print(void){
	/*cout << "Etr" << endl; imprime(Etr,epochsK[1]);
	cout << "Eval" << endl; imprime(Eval,epochsK[1]);
	cout << "GL" << endl;	imprime(GL,epochsK[1]);
	cout << "Pk" << endl;	imprime(Pk,epochsK[1]);
	cout << "PQalfa" << endl;	imprime(PQalfa,epochsK[1]);*/

}



void C_Epochs::save2file(int cols, FILE *fwrite, char file[]){
    // save Etr
    saveD(Etr, cols, fwrite, file);
    // save Eval
    saveD(Eval, cols, fwrite, file);
    // save GL
    saveD(GL, cols, fwrite, file);
    // save Pk
    saveD(Pk, cols, fwrite, file);
    // save PQalfa
    saveD(PQalfa, cols, fwrite, file);
    ///////////////////////////////////////////////////////////////////////
    /// Put a band to look for error
    if((fprintf(fwrite, "%d\t",BAND)) == EOF){
    	printf("Error writing to file '%s'...\n",file); exit(0);
    }
    ///////////////////////////////////////////////////////////////////////
}//////////////////////////////////////////////////////////////////////////////


//Constructor C_Epochs
void C_Epochs::clean(void){

	set(Etr, epochsK[1],0);
	set(Eval,epochsK[1],0);
	set(GL, epochsK[1],0);
	set(Pk, epochsK[1],0);
	set(PQalfa, epochsK[1],0);
}


#endif
