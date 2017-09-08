/*!
 * CEnsemble.hpp
 * Created: 27/01/19
 * Class containing all the ensembles approaches
 */

#ifndef C_ENSEMBLE_HPP
#define C_ENSEMBLE_HPP

class C_ensemble{
public:
    C_predParam *Average;

    C_predParam *SRank_base_LCombination_05;
    double *weightsRankBase_05;

    C_predParam *SRank_base_LCombination_1;       //rank-base linear combination
    double *weightsRankBase_1;                              //size:populationNum

    C_predParam *SRank_base_LCombination_15;
    double *weightsRankBase_15;

    C_predParam *SRank_base_LCombination_2;
    double *weightsRankBase_2;

    C_predParam *SRank_base_LCombination_25;
    double *weightsRankBase_25;

    C_predParam *SRank_base_LCombination_3;
    double *weightsRankBase_3;

    C_predParam *SRank_base_LCombination_35;
    double *weightsRankBase_35;

    C_predParam *SRank_base_LCombination_4;
    double *weightsRankBase_4;

    C_predParam *SRank_base_LCombination_45;
    double *weightsRankBase_45;

    C_predParam *SRank_base_LCombination_5;
    double *weightsRankBase_5;

    C_predParam *SRank_base_LCombination_55;
    double *weightsRankBase_55;

    C_predParam *SRank_base_LCombination_6;
    double *weightsRankBase_6;

    C_predParam *SRank_base_LCombination_65;
    double *weightsRankBase_65;

    C_predParam *SRank_base_LCombination_7;
    double *weightsRankBase_7;

    C_predParam *SRank_base_LCombination_75;
    double *weightsRankBase_75;

    C_predParam *SRank_base_LCombination_8;
    double *weightsRankBase_8;

    C_predParam *SRank_base_LCombination_85;
    double *weightsRankBase_85;

    C_predParam *SRank_base_LCombination_9;
    double *weightsRankBase_9;

    C_predParam *SRank_base_LCombination_95;
    double *weightsRankBase_95;

    double *OutputBestSRBLC;

    //C_PredParam *SRLS_alg;
    //C_PredParam *GA;     */

    //Constructor
    C_ensemble();

    //Destructor
    ~C_ensemble();

    //Save to file Average ensemble
    void save2fileAv(FILE *, char []);

    //Save to file RBLC ensemble
    void save2fileRBLC(FILE *, char []);
};

//Constructor
C_ensemble::C_ensemble(){
	//// variables for ensemble ///////////////////////////////////////////
	Average = new C_predParam;

	SRank_base_LCombination_05 = new C_predParam;
	weightsRankBase_05 = allocate(weightsRankBase_05, populationNum);

	SRank_base_LCombination_1 = new C_predParam;
	weightsRankBase_1 = allocate(weightsRankBase_1, populationNum);

	SRank_base_LCombination_15 = new C_predParam;
	weightsRankBase_15 = allocate(weightsRankBase_15, populationNum);

	SRank_base_LCombination_2 = new C_predParam;
	weightsRankBase_2 = allocate(weightsRankBase_2, populationNum);

	SRank_base_LCombination_25 = new C_predParam;
	weightsRankBase_25 = allocate(weightsRankBase_25, populationNum);

	SRank_base_LCombination_3 = new C_predParam;
	weightsRankBase_3 = allocate(weightsRankBase_3, populationNum);

	SRank_base_LCombination_35 = new C_predParam;
	weightsRankBase_35 = allocate(weightsRankBase_35, populationNum);

	SRank_base_LCombination_4 = new C_predParam;
	weightsRankBase_4 = allocate(weightsRankBase_4, populationNum);

	SRank_base_LCombination_45 = new C_predParam;
	weightsRankBase_45 = allocate(weightsRankBase_45, populationNum);

	SRank_base_LCombination_5 = new C_predParam;
	weightsRankBase_5 = allocate(weightsRankBase_5, populationNum);

	SRank_base_LCombination_55 = new C_predParam;
	weightsRankBase_55 = allocate(weightsRankBase_55, populationNum);

	SRank_base_LCombination_6 = new C_predParam;
	weightsRankBase_6 = allocate(weightsRankBase_6, populationNum);

	SRank_base_LCombination_65 = new C_predParam;
	weightsRankBase_65 = allocate(weightsRankBase_65, populationNum);

	SRank_base_LCombination_7 = new C_predParam;
	weightsRankBase_7 = allocate(weightsRankBase_7, populationNum);

	SRank_base_LCombination_75 = new C_predParam;
	weightsRankBase_75 = allocate(weightsRankBase_75, populationNum);

	SRank_base_LCombination_8 = new C_predParam;
	weightsRankBase_8 = allocate(weightsRankBase_8, populationNum);

	SRank_base_LCombination_85 = new C_predParam;
	weightsRankBase_85 = allocate(weightsRankBase_85, populationNum);

	SRank_base_LCombination_9 = new C_predParam;
	weightsRankBase_9 = allocate(weightsRankBase_9, populationNum);

	SRank_base_LCombination_95 = new C_predParam;
	weightsRankBase_95 = allocate(weightsRankBase_95, populationNum);

	OutputBestSRBLC = (double *) malloc(sizeof(double));
	OutputBestSRBLC[0] = 0;

}

//Destructor
C_ensemble::~C_ensemble(){
	delete(Average);
	delete(SRank_base_LCombination_05);
	safefree(&weightsRankBase_05);

	delete(SRank_base_LCombination_1);
	safefree(&weightsRankBase_1);

	delete(SRank_base_LCombination_15);
	safefree(&weightsRankBase_15);

	delete(SRank_base_LCombination_2);
	safefree(&weightsRankBase_2);

	delete(SRank_base_LCombination_25);
	safefree(&weightsRankBase_25);

	delete(SRank_base_LCombination_3);
	safefree(&weightsRankBase_3);

	delete(SRank_base_LCombination_35);
	safefree(&weightsRankBase_35);

	delete(SRank_base_LCombination_4);
	safefree(&weightsRankBase_4);

	delete(SRank_base_LCombination_45);
	safefree(&weightsRankBase_45);

	delete(SRank_base_LCombination_5);
	safefree(&weightsRankBase_5);

	delete(SRank_base_LCombination_55);
	safefree(&weightsRankBase_55);

	delete(SRank_base_LCombination_6);
	safefree(&weightsRankBase_6);

	delete(SRank_base_LCombination_65);
	safefree(&weightsRankBase_65);

	delete(SRank_base_LCombination_7);
	safefree(&weightsRankBase_7);

	delete(SRank_base_LCombination_75);
	safefree(&weightsRankBase_75);

	delete(SRank_base_LCombination_8);
	safefree(&weightsRankBase_8);

	delete(SRank_base_LCombination_85);
	safefree(&weightsRankBase_85);

	delete(SRank_base_LCombination_9);
	safefree(&weightsRankBase_9);

	delete(SRank_base_LCombination_95);
	safefree(&weightsRankBase_95);

	safefree(&OutputBestSRBLC);

}

void C_ensemble::save2fileAv(FILE *fwrite, char file[]){
	//save Average
	Average->save2file( fwrite, file);
}

void C_ensemble::save2fileRBLC(FILE *fwrite, char file[]){

	SRank_base_LCombination_05->save2file(fwrite, file);
	saveD(weightsRankBase_05, populationNum, fwrite, file);

    SRank_base_LCombination_1->save2file(fwrite, file);
    saveD(weightsRankBase_1, populationNum, fwrite, file);

    SRank_base_LCombination_15->save2file(fwrite, file);
    saveD(weightsRankBase_15, populationNum, fwrite, file);

    SRank_base_LCombination_2->save2file(fwrite, file);
    saveD(weightsRankBase_2, populationNum, fwrite, file);

    SRank_base_LCombination_25->save2file(fwrite, file);
    saveD(weightsRankBase_25, populationNum, fwrite, file);

    SRank_base_LCombination_3->save2file(fwrite, file);
    saveD(weightsRankBase_3, populationNum, fwrite, file);

    SRank_base_LCombination_35->save2file(fwrite, file);
    saveD(weightsRankBase_35, populationNum, fwrite, file);

    SRank_base_LCombination_4->save2file( fwrite, file);
    saveD(weightsRankBase_4, populationNum, fwrite, file);

    SRank_base_LCombination_45->save2file( fwrite, file);
    saveD(weightsRankBase_45, populationNum, fwrite, file);

    SRank_base_LCombination_5->save2file( fwrite, file);
    saveD(weightsRankBase_5, populationNum, fwrite, file);

    SRank_base_LCombination_55->save2file( fwrite, file);
    saveD(weightsRankBase_55, populationNum, fwrite, file);

    SRank_base_LCombination_6->save2file( fwrite, file);
    saveD(weightsRankBase_6, populationNum, fwrite, file);

    SRank_base_LCombination_65->save2file( fwrite, file);
    saveD(weightsRankBase_65, populationNum, fwrite, file);

    SRank_base_LCombination_7->save2file( fwrite, file);
    saveD(weightsRankBase_7, populationNum, fwrite, file);

    SRank_base_LCombination_75->save2file( fwrite, file);
    saveD(weightsRankBase_75, populationNum, fwrite, file);

    SRank_base_LCombination_8->save2file( fwrite, file);
    saveD(weightsRankBase_8, populationNum, fwrite, file);

    SRank_base_LCombination_85->save2file( fwrite, file);
    saveD(weightsRankBase_85, populationNum, fwrite, file);

    SRank_base_LCombination_9->save2file( fwrite, file);
    saveD(weightsRankBase_9, populationNum, fwrite, file);

    SRank_base_LCombination_95->save2file( fwrite, file);
    saveD(weightsRankBase_95, populationNum, fwrite, file);

    //OutputBestSRBLC
    if((fprintf(fwrite, "%g\t",OutputBestSRBLC[0])) == EOF){
        printf("Error writing to file '%s'...\n",file); exit(0);

    }
}


#endif
