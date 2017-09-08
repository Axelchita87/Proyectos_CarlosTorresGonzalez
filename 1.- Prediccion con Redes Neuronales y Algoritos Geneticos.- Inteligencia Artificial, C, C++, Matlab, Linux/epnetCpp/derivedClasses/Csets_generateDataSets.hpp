/*!
 * Csets_generateDataSets.hpp
 *
 * Derived class from class sets to generate the data sets 001, 002, ... 0024 used in
 * quick learning to generalize as stated by (bibtex:Bullinaria:unders2007)
 * 		John A. Bullinaria. Understanding the Emergence of Modularity in Neural Systems. Cognitive Science. 2007
 * This class is generated if the variable fitness_learnQuick2Genaralize == ON, which meand that it is derived a class from network too for similar funcitons
 *
 * Maybe in the future there could be a class for each code, ie. 0021 0024 ...
 *
 * Created: 	17 Mar 2011
 * Modified:
 * Author:		Carlos Torres and Victor Landassuri
 *
 */

#ifndef C_SETS_GENERATE_DATA_SETS_HPP
#define C_SETS_GENERATE_DATA_SETS_HPP


class C_sets_generateDataSets: public C_sets{
private:
	double a,b;
	int lines;
	int noInp;
	int noOut;

	//int EPERYR;
	//int NUMPAT;

	double **TInp;
	double **TOut;

	// classes with 2 inputs, 2 output and 2 classes
	/*void genClass0003(double **, double **, int *, string *, double , double, int, int, int );
	void genClass0004(double **, double **, int *, string *, double , double, int, int, int );
	void genClass0005(double **, double **, int *, string *, double , double, int, int, int );

	// classes with 2 inputs, 2 output and 3 classes, here it is not possible to use winner take all for the classif Error, instead
	// it will only be used the percentage error
	void genClass0016(double **, double **, int *, string *, double , double, int, int, int );
	void genClass0017(double **, double **, int *, string *, double , double, int, int, int );
	void genClass0018(double **, double **, int *, string *, double , double, int, int, int );
*/

	// Clases alone, one class per file
	void genClass_A1(void);
	void genClass_B1(void);
	void genClass_C1(void);
	void genClass_D1(void);

	void genClass0021( void ); 									// classes with 2 inputs, 2 output and 4 classes
	void genClass0021a( void ); 								// 2 inp, 4 out, 4 classes, 1 output per class
	void genClass0021a1( void ); 								// 2 inp, 4 out, 4 classes, 1 output per class, same as 0021a, small space in calsses, for normal evolution
	//void genClass0022(double **, double **, int *, string *, double , double, int, int, int );
	void genClass0023( void );
	void genClass0023a( void );									// 2 inp, 4 out, 4 classes, 1 output per class
	void genClass0024( void );
	void genClass0024a( void );									// ready for winner takes all

	void genClass0031a( void ); 								// 2 inp, 6 out, 6 classes, 1 output per class
	void genClass0033a( void ); 								// 2 inp, 6 out, 6 classes, 1 output per class
	void genClass0034a( void ); 								// 2 inp, 7 out, 7 classes, 1 output per class

public:
	// methods

	//Constructor and destructor
	C_sets_generateDataSets(int Lines,  int noINP, int noOUT) :  C_sets( ){
		/*!
		 * The constructor is implemented here
		 */

		// Range to generate the inputs
		a = 0.01;
		b = 0.99;

		lines = Lines;
		noInp = noINP;
		noOut = noOUT;

		// variabels to hold the inputs and outputs
		TInp = NULL;
		TOut = NULL;
		TInp = allocate(TInp,lines, noInp);
		TOut = allocate(TOut,lines, noOut);

	}
	~C_sets_generateDataSets();

	// entry function, do all the job, class called whent eh enetworks is created
	void generateDataSet(double **, int, int, int);


};// end class declaration, here it is implemented the constructor //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// destructor
C_sets_generateDataSets::~C_sets_generateDataSets(){
	safefree(&TInp, lines);
	safefree(&TOut, lines);
}


/// Fuction called from another class. Enter POINT

void C_sets_generateDataSets::generateDataSet(double **p, int lineS, int noInP, int noOuT){
	/*!
	 * Function to generate different data sets for classification
	 *
	 * intput:
	 * p			matrix to save the data set
	 * lineS 	how many lines are generated (this value plus the next two are leaved here to discover error, they are compared with the variable from the class)
	 * noInP 	number of inputs previously settled
	 * noOuT	number of outputs in the network/task to solve
	 *
	 * It is assumed that the data set will be generated with the same number of inputs and output as the one that is running in the moment is called this method
	 * The new variable generated has the same size than the originale read from the disk (dataInputN.txt) and then is created again all sets variables (set Class)
	 *
	 * The code here it is quite similar as in workspace2 fo generateData set, the code that generate it is the same, only change the functions
	 *
	 * Here it is not introduced any function to balance the number of patterns per class, as preliminary exps. showed that all classes have patterns, the ones with small areas have less
	 * patterns than the others but they have enogh in proportion of its area, that is using 400 values per training set, maybe less could cause problems
	 */

	// check that the lines, inputs and outputs are correct with the information used when the class was generated. Possible error if inputs are evolved, for that is leave this code here
	if (lines != lineS || noInp != noInP || noOut != noOuT){
		cout << "Error: the variables 'lines', 'noInp' and 'noOut' are different to the values used when the class sets_generateDataSet was implemented, EXIT" << endl << "In function C_sets_generateDataSets::generateDataSet" << endl;
		exit (0);
	}

	// before generate the new data set, clean the variables
	set(TInp, lines, noInp, 0);
	set(TOut, lines, noOut, 0);


	// Which data set will be generated
	if ( strcmp( NAMETS.c_str(), "A1" ) == 0 )		// 2,2,4
			genClass_A1( ) ;
	else if ( strcmp( NAMETS.c_str(), "B1" ) == 0 )		// 2,2,4
				genClass_B1( ) ;
	else if ( strcmp( NAMETS.c_str(), "C1" ) == 0 )		// 2,2,4
				genClass_C1( ) ;
	else if ( strcmp( NAMETS.c_str(), "D1" ) == 0 )		// 2,2,4
				genClass_D1( ) ;
	else if ( strcmp( NAMETS.c_str(), "0021" ) == 0 )		// 2,2,4
		genClass0021( ) ;
	else if ( strcmp( NAMETS.c_str(), "0021a" ) == 0 )
		genClass0021a( ) ;
	else if ( strcmp( NAMETS.c_str(), "0021a1" ) == 0 )
			genClass0021a1( ) ;
	else if ( strcmp( NAMETS.c_str(), "0023" ) == 0 )
		genClass0023( ) ;
	else if ( strcmp( NAMETS.c_str(), "0023a" ) == 0 )
			genClass0023a( ) ;
	else if ( strcmp( NAMETS.c_str(), "0024" ) == 0 )
		genClass0024( ) ;
	else if ( strcmp( NAMETS.c_str(), "0024a" ) == 0 )
			genClass0024a( ) ;

	else if ( strcmp( NAMETS.c_str(), "0031a" ) == 0 )
				genClass0031a( ) ;
	else if ( strcmp( NAMETS.c_str(), "0033a" ) == 0 )
				genClass0033a( ) ;
	else if ( strcmp( NAMETS.c_str(), "0034a" ) == 0 )
				genClass0034a( ) ;

	else{
		cout << "incorrect option for the class to generate ..... function C_sets_generateDataSets::generateDataSet ........ exit" << endl;
		exit (0);
	}


	// save the data sets... // this vars are loaded with acript_plotClasses_plorBadPrediciton in workspace2\generateDS
	/*saveD( (char *)"../../workspace2/genDataSetModular/res/TInp.txt" , TInp, lines, noInp);
	saveD( (char *)"../../workspace2/genDataSetModular/res/TOut.txt" , TOut, lines , noOut);
*/
	// put TInp and TOut into p to save the values and return that
	copy(p, TInp, lines, noInp); 									  //saveD( (char *)"res/PInp.txt" , p, lines ,noInp);
	copyOffsetCol(p, TOut, lines, noOut, 0, noInp);  	  //saveD( (char *)"res/PInpyOut.txt" , p, lines ,noInp+noOut);

} //////////////////////////////////////////////////////////////////////////



/// Here put the function called from the same class, in this case there are private



//void C_sets_generateDataSets::genClass0003(double **TInp, double **TOut, int *NoOut, string *dsNum, double a, double b, int EPERYR, int NUMPAT, int NUMIN ){
	/*!
	 * Class 0003
	 * 2 inputs 2 outputs, 2 classes,
	 * A diagonal line that cross the plane
	 */
/*
	// Local variables
	register int i,j;

	// Setup variables to return
	*dsNum = "0003"; 			// number of data set
	*NoOut = 2;						// outputs in this data set

	for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		for( i = 0 ; i < NUMIN  ; i++ )
			TInp[j][i] = a + (b - a) * rando(); 						// TIn[j][i] = ran2(idum);



		if( (TInp[j][1] < TInp[j][0]) && (TInp[j][1] > (TInp[j][0] - 0.37)) ) {			// 0.37 is the x space used by the class in diagonal
			TOut[j][0] = 0;
			TOut[j][1] = 1;
		}
		else if( (TInp[j][1] > (TInp[j][0] + 0.0283)) || (TInp[j][1] < (TInp[j][0] - 0.3983)) ){		// 0.0283 is the space between classes in Y,
			TOut[j][0] = 1; 																									// empty space between 0.37 and 0.3983 in X
			TOut[j][1] = 0;
		}
		else
			j--;
	}
 //cout << "data set " << *dsNum << " generated " << endl;
} /// finish class 0003
*/

//void C_sets_generateDataSets::genClass0004(double **TInp, double **TOut, int *NoOut, string *dsNum, double a, double b, int EPERYR, int NUMPAT, int NUMIN ){
	/*!
	 * Class 0004
	 * 2 inputs, 2 output, 2  classes,
	 * one class in the half of a circle in the upper left-corner, the rest is the other class
	 */
/*
	// Local variables
	register int i,j;
	double r2;

	// Variables to control the position of the classes
	double circleCenterX = 0.0035;
	double circleCenterY = 0.0045;
	double circleSpaceMin = 0.6961; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circleSpaceMax = 0.7389; 		// there is no space between classes

	// Setup variables to return
	*dsNum = "0004"; 			// number of data set
	*NoOut = 2;						// outputs in this data set

	for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		for( i = 0 ; i < NUMIN  ; i++ )
			TInp[j][i] = a + (b - a) * rando(); 						// TIn[j][i] = ran2(idum);

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		if( (r2 = ( (TInp[j][0] - circleCenterX ) * (TInp[j][0] - circleCenterX ) + (TInp[j][1] - circleCenterY) * ( TInp[j][1] - circleCenterY) ) ) < circleSpaceMin){
			TOut[j][0] = 1;
			TOut[j][1] = 0;
		}
		else if( r2 > circleSpaceMax ){
			TOut[j][0] = 0;
			TOut[j][1] = 1;
		}
		else {
			j--;
			continue;
		}

	}
 // cout << "data set " << *dsNum << " generated " << endl;
}  // finish class 0004
*/




//void C_sets_generateDataSets::genClass0005(double **TInp, double **TOut, int *NoOut, string *dsNum, double a, double b, int EPERYR, int NUMPAT, int NUMIN ){
	/*!
	 * Class 0005
	 * 2 inputs, 2 output, 2  classes,
	 * one class is a circle, the rest is the other class
	 */
/*
	// Local variables
	register int i,j;
	double r2;

	// Variables to control the position of the classes
	double circleCenterX = 0.3;
	double circleCenterY = 0.7;
	double circleSpaceMin = 0.019961; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circleSpaceMax = 0.02589; 		// there is no space between classes

	// Setup variables to return
	*dsNum = "0005"; 			// number of data set
	*NoOut = 2;						// outputs in this data set

	for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		for( i = 0 ; i < NUMIN  ; i++ )
			TInp[j][i] = a + (b - a) * rando(); 						// TIn[j][i] = ran2(idum);

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		if( (r2 = ( (TInp[j][0] - circleCenterX ) * (TInp[j][0] - circleCenterX ) + (TInp[j][1] - circleCenterY) * ( TInp[j][1] - circleCenterY) ) ) < circleSpaceMin){
			TOut[j][0] = 1;
			TOut[j][1] = 0;
		}
		else if( r2 > circleSpaceMax ){
			TOut[j][0] = 0;
			TOut[j][1] = 1;
		}
		else {
			j--;
			continue;
		}

	}
 // cout << "data set " << *dsNum << " generated " << endl;
}  // finish class 0005
*/

//void C_sets_generateDataSets::genClass0016(double **TInp, double **TOut, int *NoOut, string *dsNum, double a, double b, int EPERYR, int NUMPAT, int NUMIN ){
	/*!
	 * Class 0016
	 * 2 inputs 2 outputs, 4 classes ::: 2 classes for the first output nad 2 for the second, when plot them do int in different figures, if not you will see the overlapping sections
	 * A diagonal line that cross the plane there is a circle but it is not cut by the diagonal line (Overlapping section)
	 * Output 1: CLass1: a circle class 1, and the rest class 0
	 * Output 2: a diagonal (class 1), the rest 0
	 */
/*
	// Local variables
	register int i,j;
	double r2;

	// Variables to control the position of the classes
	double circleCenterX = 0.25;
	double circleCenterY = 0.75;
	double circleSpaceMin = 0.0261; 		// this both is the limit of values not used, if the max starts where the min finish then
	double circleSpaceMax = 0.0389; 		// there is no space between classes

	// Setup variables to return
	*dsNum = "0016"; 			// number of data set
	*NoOut = 2;						// outputs in this data set

	for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		for( i = 0 ; i < NUMIN  ; i++ )
			TInp[j][i] = a + (b - a) * rando(); 						// TIn[j][i] = ran2(idum);

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		if( (r2 = ( (TInp[j][0] - circleCenterX ) * (TInp[j][0] - circleCenterX ) + (TInp[j][1] - circleCenterY) * ( TInp[j][1] - circleCenterY) ) ) < circleSpaceMin)
			TOut[j][0] = 1;
		else if( r2 > circleSpaceMax )
			TOut[j][0] = 0;
		else {
			j--;
			continue;
		}

		if( (TInp[j][1] < TInp[j][0]) && (TInp[j][1] > (TInp[j][0] - 0.37)) ) 			// 0.37 is the x space used by the class in diagonal
			TOut[j][1] = 1;
		else if( (TInp[j][1] > (TInp[j][0] + 0.0283)) || (TInp[j][1] < (TInp[j][0] - 0.3983)) )		// 0.0283 is the space between classes in Y,
			TOut[j][1] = 0; 																									// empty space between 0.37 and 0.3983 in X
		else
			j--;
		if (TOut[j][0] == 0 && TOut[j][1] == 0)
				int w = 10;

	}
 //cout << "data set " << *dsNum << " generated " << endl;
} /// finish class 0016
*/



//void C_sets_generateDataSets::genClass0017(double **TInp, double **TOut, int *NoOut, string *dsNum, double a, double b, int EPERYR, int NUMPAT, int NUMIN ){
	/*!
	 * Class 0017
	 * 2 inputs, 2 output, 3  classes,
	 * one class in the half of a circle in the lower left-corner, another circle inside it, the rest is the other class
	 *
	 */
/*
	// Local variables
	register int i,j;
	double r2;

	// Variables to control the position of the classes
	double circleCenterX = 0.0035;
	double circleCenterY = 0.0045;
	double circleSpaceMin = 0.6961; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circleSpaceMax = 0.7389; 		// there is no space between classes

	// second circle
	double circle2CenterX = 0.3;
	double circle2CenterY = 0.3;
	double circle2SpaceMin = 0.019961; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circle2SpaceMax = 0.02689; 		// there is no space between classes

	// Setup variables to return
	*dsNum = "0017"; 			// number of data set
	*NoOut = 2;						// outputs in this data set

	for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		for( i = 0 ; i < NUMIN  ; i++ )
			TInp[j][i] = a + (b - a) * rando(); 						// TIn[j][i] = ran2(idum);

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		if( (r2 = ( (TInp[j][0] - circleCenterX ) * (TInp[j][0] - circleCenterX ) + (TInp[j][1] - circleCenterY) * ( TInp[j][1] - circleCenterY) ) ) < circleSpaceMin)
			TOut[j][0] = 1;
		else if( r2 > circleSpaceMax )
			TOut[j][0] = 0;
		else {
			j--;
			continue;
		}
		if( (r2 = ( (TInp[j][0] - circle2CenterX ) * (TInp[j][0] - circle2CenterX ) + (TInp[j][1] - circle2CenterY) * ( TInp[j][1] - circle2CenterY) ) ) < circle2SpaceMin)
			TOut[j][1] = 1;
		else if( r2 > circle2SpaceMax )
			TOut[j][1] = 0;
		else {
			j--;

		}

	}
 // cout << "data set " << *dsNum << " generated " << endl;
}  // finish class 0017
*/


//void C_sets_generateDataSets::genClass0018(double **TInp, double **TOut, int *NoOut, string *dsNum, double a, double b, int EPERYR, int NUMPAT, int NUMIN ){
	/*!
	 * Class 0018
	 * 2 inputs, 2 output, 3  classes,
	 * one class in the half of a circle in the upper left-corner, another circle inside it, the rest is the other class
	 *
	 */
/*
	// Local variables
	register int i,j;
	double r2;

		// Variables to control the position of the classes
	double circleCenterX = 0.035;
	double circleCenterY = 0.945;
	double circleSpaceMin = 0.6961; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circleSpaceMax = 0.7389; 		// there is no space between classes

	// second circle
	double circle2CenterX = 0.3;
	double circle2CenterY = 0.7;
	double circle2SpaceMin = 0.019961; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circle2SpaceMax = 0.02689; 		// there is no space between classes

	// Setup variables to return
	*dsNum = "0018"; 			// number of data set
	*NoOut = 2;						// outputs in this data set

	for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		for( i = 0 ; i < NUMIN  ; i++ )
			TInp[j][i] = a + (b - a) * rando(); 						// TIn[j][i] = ran2(idum);

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		if( (r2 = ( (TInp[j][0] - circleCenterX ) * (TInp[j][0] - circleCenterX ) + (TInp[j][1] - circleCenterY) * ( TInp[j][1] - circleCenterY) ) ) < circleSpaceMin)
			TOut[j][0] = 1;
		else if( r2 > circleSpaceMax )
			TOut[j][0] = 0;
		else {
			j--;
			continue;
		}
		if( (r2 = ( (TInp[j][0] - circle2CenterX ) * (TInp[j][0] - circle2CenterX ) + (TInp[j][1] - circle2CenterY) * ( TInp[j][1] - circle2CenterY) ) ) < circle2SpaceMin)
			TOut[j][1] = 1;
		else if( r2 > circle2SpaceMax )
			TOut[j][1] = 0;
		else {
			j--;

		}

	}
}  // finish class 0018
*/


void C_sets_generateDataSets::genClass_A1( void ){
	/*!
		 * Class a1
		 * 2 inputs 2, output in 2 classes 1 tasks (expected one module sovel it, or a single ANN)
		 * Circle in the bottom left side of the box
		 */

	// Local variables
	register int i,j;
	double r2;

	// Variables to control the position of the classes
	double circleCenterX = 0.35;
	double circleCenterY = 0.45;
	double circleSpaceMin = 0.0961; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circleSpaceMax = 0.1089; 		// there is no space between classes

	// fill only lines patterns
	j = -1;
	while ( j < lines - 1  ){ 			// original line --> for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		j++;

		for( i = 0 ; i < noInp  ; i++ )
			TInp[j][i] = a + (b - a) * rando(); 						// TIn[j][i] = ran2(idum);

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		if( (r2 = ( (TInp[j][0] - circleCenterX ) * (TInp[j][0] - circleCenterX ) + (TInp[j][1] - circleCenterY) * ( TInp[j][1] - circleCenterY) ) ) < circleSpaceMin){
			TOut[j][0] = YMAX;
			TOut[j][1] = YMIN;
		}
		else if( r2 > circleSpaceMax ){
			TOut[j][0] = YMIN;
			TOut[j][1] = YMAX;
		}
		else {
			j--;
			continue;
		}
	}
 // cout << "data set " << *dsNum << " generated " << endl;
}  // finish class A1

void C_sets_generateDataSets::genClass_B1( void ){
	/*!
		 * Class B1
		 * diagonal line with second class (inside diagonal) growing to the right bottom
		 */

	// Local variables
	register int i,j;

	// fill only lines patterns
	j = -1;
	while ( j < lines - 1  ){ 			// original line --> for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		j++;

		for( i = 0 ; i < noInp  ; i++ )
			TInp[j][i] = a + (b - a) * rando(); 						// TIn[j][i] = ran2(idum);


		if( (TInp[j][1] < TInp[j][0]) && (TInp[j][1] > (TInp[j][0] - 0.37)) ){ 			// 0.37 is the x space used by the class in diagonal
			TOut[j][0] = YMAX;
			TOut[j][1] = YMIN;
		}
		else if( (TInp[j][1] > (TInp[j][0] + 0.0493)) || (TInp[j][1] < (TInp[j][0] - 0.4383)) ){		// 0.0283 is the space between classes in Y,
			TOut[j][0] = YMIN; 																									// empty space between 0.37 and 0.3983 in X
			TOut[j][1] = YMAX;
		}
		else
			j--;
	}
 // cout << "data set " << *dsNum << " generated " << endl;
}  // finish class B1



void C_sets_generateDataSets::genClass_C1( void ){
	/*
	 * big circle with center around -1,-1
	 */

	// Local variables
	register int i,j;
	double r2;

	// Variables to control the position of the classes
	double circleCenterX = 0.0035;
	double circleCenterY = 0.0045;
	double circleSpaceMin = 0.6561;     //0.6961; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circleSpaceMax = 0.7389; 		// there is no space between classes

	// fill only lines patterns
	j = -1;
	while ( j < lines - 1){ 			// original line --> for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		j++;

		for( i = 0 ; i < noInp  ; i++ )
			TInp[j][i] = a + (b - a) * rando(); 						// TIn[j][i] = ran2(idum);

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		if( (r2 = ( (TInp[j][0] - circleCenterX ) * (TInp[j][0] - circleCenterX ) + (TInp[j][1] - circleCenterY) * ( TInp[j][1] - circleCenterY) ) ) < circleSpaceMin){
			TOut[j][0] = YMAX;
			TOut[j][1] = YMIN;
		}
		else if( r2 > circleSpaceMax ){
			TOut[j][0] = YMIN;
			TOut[j][1] = YMAX;
		}
		else {
			j--;
			continue;
		}
	}
 // cout << "data set " << *dsNum << " generated " << endl;
}  // finish class C1



void C_sets_generateDataSets::genClass_D1( void ){
	/*!
	* Class d1
	* big cicle with center around 0,2 and small circle with center in 0.035,0.945
	*/

	// Local variables
	register int i,j;
	double r2;

	int k;


	// Variables to control the position of the classes
	/*double circleCenterX = 0.0035;
	double circleCenterY = 0.0045;
	double circleSpaceMin = 0.6561; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circleSpaceMax = 0.7389; 		// there is no space between classes
*/
	// Variables to control the position of the classes
	double circle2CenterX = 0.035;
	double circle2CenterY = 0.945;
	double circle2SpaceMin = 0.6561; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circle2SpaceMax = 0.7389; 		// there is no space between classes

	// second circle
	double circle3CenterX = 0.35;
	double circle3CenterY = 0.65;
	double circle3SpaceMin = 0.0461; //0.015961; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circle3SpaceMax = 0.0684; //0.02689; 		// there is no space between classes


	// 5 classes
	// fill only lines patterns
	j = -1;
	while ( j < lines-1 ){ 			// original line --> for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		j++;

		for( i = 0 ; i < noInp  ; i++ )
			TInp[j][i] = a + (b - a) * rando();  								// TInp[j][i] = ran2(idum);

		for( k = 0 ; k < noOut ; k++ ) 								// fill outputs
			TOut[j][k] = YMIN;

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		// Class 1 y 2, Module 1
		/*if( (r2 = ( (TInp[j][0] - circleCenterX ) * (TInp[j][0] - circleCenterX ) + (TInp[j][1] - circleCenterY) * ( TInp[j][1] - circleCenterY) ) ) < circleSpaceMin){
			TOut[j][0] = YMAX;
			//TOut[j][1] = 0;
		}
		else if( r2 > circleSpaceMax ){
			//TOut[j][0] = 0;
			TOut[j][1] = YMAX;
		}
		else {
			j--;
			continue;
		}
*/
		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		// class 3 4 and 5, Module 2 or tasks 2
		if( (r2 = ( (TInp[j][0] - circle2CenterX ) * (TInp[j][0] - circle2CenterX ) + (TInp[j][1] - circle2CenterY) * ( TInp[j][1] - circle2CenterY) ) ) < circle2SpaceMin){
			TOut[j][0] = YMAX;
			//TOut[j][3] = 0;
			//TOut[j][4] = 0;
		}
		else if( r2 > circle2SpaceMax ){
			//TOut[j][2] = 0;
			TOut[j][1] = YMAX;
			//TOut[j][4] = 0;
		}
		else {
			j--;
			continue;
		}

		if( (r2 = ( (TInp[j][0] - circle3CenterX ) * (TInp[j][0] - circle3CenterX ) + (TInp[j][1] - circle3CenterY) * ( TInp[j][1] - circle3CenterY) ) ) < circle3SpaceMin){
			TOut[j][0] = YMIN;
			TOut[j][1] = YMIN;
			TOut[j][2] = YMAX;
		}
		else if( r2 > circle3SpaceMax ){
			//TOut[j][2] = 0;
			//TOut[j][3] = 0;
			TOut[j][2] = YMIN;
		}
		else {
			j--;
		}

	}
} /// finish class D1




void C_sets_generateDataSets::genClass0021( void ){
	/*!
	 * Class 0021
	 * 2 inputs 2, output and 4 classes,
	 * i.e. 2 inputs 2 outputs using all combinations
	 * Circle with coordinates in circleCenterX, circleCenterY, it is cut by a diagonal or not, depend of the coordinate x,y
	 */

	// Local variables
	register int i,j;
	double r2;

	// Variables to control the position of the classes
	double circleCenterX = 0.35;
	double circleCenterY = 0.45;
	double circleSpaceMin = 0.0961; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circleSpaceMax = 0.1089; 		// there is no space between classes

	// Setup variables to return
	//*dsNum = "0021"; 			// number of data set
	//*NoOut = 2;						// outputs in this data set

	// fill only lines patterns
	j = -1;
	while ( j < lines - 1  ){ 			// original line --> for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		j++;

		for( i = 0 ; i < noInp  ; i++ )
			TInp[j][i] = a + (b - a) * rando(); 						// TIn[j][i] = ran2(idum);

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		if( (r2 = ( (TInp[j][0] - circleCenterX ) * (TInp[j][0] - circleCenterX ) + (TInp[j][1] - circleCenterY) * ( TInp[j][1] - circleCenterY) ) ) < circleSpaceMin)
			TOut[j][0] = YMAX;
		else if( r2 > circleSpaceMax )
			TOut[j][0] = YMIN;
		else {
			j--;
			continue;
		}

		if( (TInp[j][1] < TInp[j][0]) && (TInp[j][1] > (TInp[j][0] - 0.37)) ) 			// 0.37 is the x space used by the class in diagonal
			TOut[j][1] = YMAX;
		else if( (TInp[j][1] > (TInp[j][0] + 0.0283)) || (TInp[j][1] < (TInp[j][0] - 0.3983)) )		// 0.0283 is the space between classes in Y,
			TOut[j][1] = YMIN; 																									// empty space between 0.37 and 0.3983 in X
		else
			j--;
	}
 // cout << "data set " << *dsNum << " generated " << endl;
}  // finish class 0021

void C_sets_generateDataSets::genClass0021a( void ){
	/*!
	 * Class 0021
	 * 2 inputs 4 output and 4 classes one output pper class
	 * first 2 outputs for task one and second two for task 2
	 * Circle with coordinates in circleCenterX, circleCenterY, it is cut by a diagonal or not, depend of the coordinate x,y
	 */

	// Local variables
	register int i,j;
	double r2;

	// Variables to control the position of the classes
	double circleCenterX = 0.35;
	double circleCenterY = 0.45;
	double circleSpaceMin = 0.0961; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circleSpaceMax = 0.1089; 		// there is no space between classes

	// Setup variables to return
	//*dsNum = "0021"; 			// number of data set
	//*NoOut = 2;						// outputs in this data set

	// fill only lines patterns
	j = -1;
	while ( j < lines - 1  ){ 			// original line --> for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		j++;

		for( i = 0 ; i < noInp  ; i++ )
			TInp[j][i] = a + (b - a) * rando(); 						// TIn[j][i] = ran2(idum);

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		if( (r2 = ( (TInp[j][0] - circleCenterX ) * (TInp[j][0] - circleCenterX ) + (TInp[j][1] - circleCenterY) * ( TInp[j][1] - circleCenterY) ) ) < circleSpaceMin){
			TOut[j][0] = YMAX;
			TOut[j][1] = YMIN;
		}
		else if( r2 > circleSpaceMax ){
			TOut[j][0] = YMIN;
			TOut[j][1] = YMAX;
		}
		else {
			j--;
			continue;
		}

		if( (TInp[j][1] < TInp[j][0]) && (TInp[j][1] > (TInp[j][0] - 0.37)) ){ 			// 0.37 is the x space used by the class in diagonal
			TOut[j][2] = YMAX;
			TOut[j][3] = YMIN;
		}
		else if( (TInp[j][1] > (TInp[j][0] + 0.0493)) || (TInp[j][1] < (TInp[j][0] - 0.4383)) ){		// 0.0283 is the space between classes in Y,
			TOut[j][2] = YMIN; 																									// empty space between 0.37 and 0.3983 in X
			TOut[j][3] = YMAX;
		}
		else
			j--;
	}
 // cout << "data set " << *dsNum << " generated " << endl;
}  // finish class 0021a


void C_sets_generateDataSets::genClass0021a1( void ){
	/*!
	 * Class 0021a1
	 * 2 inputs 4 output and 4 classes one output pper class
	 * first 2 outputs for task one and second two for task 2
	 * Circle with coordinates in circleCenterX, circleCenterY, it is cut by a diagonal or not, depend of the coordinate x,y
	 */

	// Local variables
	register int i,j;
	double r2;

	// Variables to control the position of the classes
	double circleCenterX = 0.35;
	double circleCenterY = 0.45;
	double circleSpaceMin = 0.0981; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circleSpaceMax = 0.1089; 		// there is no space between classes

	// Setup variables to return
	//*dsNum = "0021"; 			// number of data set
	//*NoOut = 2;						// outputs in this data set

	// fill only lines patterns
	j = -1;
	while ( j < lines - 1  ){ 			// original line --> for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		j++;

		for( i = 0 ; i < noInp  ; i++ )
			TInp[j][i] = a + (b - a) * rando(); 						// TIn[j][i] = ran2(idum);

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		if( (r2 = ( (TInp[j][0] - circleCenterX ) * (TInp[j][0] - circleCenterX ) + (TInp[j][1] - circleCenterY) * ( TInp[j][1] - circleCenterY) ) ) < circleSpaceMin){
			TOut[j][0] = YMAX;
			TOut[j][1] = YMIN;
		}
		else if( r2 > circleSpaceMax ){
			TOut[j][0] = YMIN;
			TOut[j][1] = YMAX;
		}
		else {
			j--;
			continue;
		}

		if( (TInp[j][1] < TInp[j][0]) && (TInp[j][1] > (TInp[j][0] - 0.37)) ){ 			// 0.37 is the x space used by the class in diagonal
			TOut[j][2] = YMAX;
			TOut[j][3] = YMIN;
		}
		else if( (TInp[j][1] > (TInp[j][0] + 0.0283)) || (TInp[j][1] < (TInp[j][0] - 0.3983)) ){		// 0.0283 is the space between classes in Y,
			TOut[j][2] = YMIN; 																									// empty space between 0.37 and 0.3983 in X
			TOut[j][3] = YMAX;
		}
		else
			j--;
	}
 // cout << "data set " << *dsNum << " generated " << endl;
}  // finish class 0021a1



//void C_sets_generateDataSets::genClass0022( double **TInp, double **TOut, int *NoOut, string *dsNum, double a, double b, int EPERYR, int NUMPAT, int NUMIN ){
	/*!
		 * Class 0022
		 * Check all the combinaiton form with this code
		 * 1	0	0	0	1   			// class 1
		 * 0	0	1	0	1 				// class 2, ...
	 	 * 0	0	1	1	0
		 * 1	0	0	1	0
		 * Note that some of the are overlapping in columns, probably it may be easier another distribution of them for the ANNs to learn, or maybe not !!
		 */
/*
	// Local variables
		register int i,j;
		double r2;

		double h = 0.0;
		int k;
		int NUMOUT = 5;
		double circleCenterX = 0.3;
		double circleCenterY = 0.7;


		// Setup variables to return
		*dsNum = "0022"; 			// number of data set
		*NoOut = NUMOUT;						// outputs in this data set

		// 5 classes
		for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
				for( i = 0 ; i < NUMIN  ; i++ )
					TInp[j][i] = a + (b - a) * rando();  								// TInp[j][i] = ran2(idum);

				for( k = 0 ; k < NUMOUT ; k++ ) 								// fill outputs
					TOut[j][k] = 0;

				if( (h = ( TInp[j][1] - TInp[j][0] * TInp[j][0])) < 0.12666667 )
					TOut[j][0] = 1;
				else if( ( r2 = (( TInp[j][0] - circleCenterX ) * ( TInp[j][0] - circleCenterX ) + ( TInp[j][0] - circleCenterY ) * (TInp[j][1] - circleCenterY ) ) )  < 0.012732395)
					TOut[j][2] = 1;
				else if( r2 < 0.023359429 )
					j--;
				else if ( h < 0.16666667 )
					j--;
				else
					TOut[j][2] = 1;
				if( ( TInp[j][1] * TInp[j][1] + TInp[j][0] * TInp[j][0]) > 0.65 )
					TOut[j][3] = 1;
				else if( ( TInp[j][1] * TInp[j][1] + TInp[j][0] * TInp[j][0]) < 0.624 )
					TOut[j][4] = 1;
				else
					j-- ;
		}
} /// finish class 0022
*/



void C_sets_generateDataSets::genClass0023( void ){
	/*!
	 * Class 0023
	 * 2 inputs, 2 output, 4  classes,
	 * one class in the half of a circle in the lower left-corner, there is a diagonal that
	 * split it into two and the rest is the other class too
	 * creatring 4 classes
	 */

	// Local variables
	register int i,j;
	double r2;

	// Variables to control the position of the classes
	double circleCenterX = 0.0035;
	double circleCenterY = 0.0045;
	double circleSpaceMin = 0.6561;     //0.6961; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circleSpaceMax = 0.7389; 		// there is no space between classes


	// Setup variables to return
	//*dsNum = "0023"; 			// number of data set
	//*NoOut = 2;						// outputs in this data set

	// fill only lines patterns
	j = -1;
	while ( j < lines - 1){ 			// original line --> for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		j++;

		for( i = 0 ; i < noInp  ; i++ )
			TInp[j][i] = a + (b - a) * rando(); 						// TIn[j][i] = ran2(idum);

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		if( (r2 = ( (TInp[j][0] - circleCenterX ) * (TInp[j][0] - circleCenterX ) + (TInp[j][1] - circleCenterY) * ( TInp[j][1] - circleCenterY) ) ) < circleSpaceMin)
			TOut[j][0] = YMAX;
		else if( r2 > circleSpaceMax )
			TOut[j][0] = YMIN;
		else {
			j--;
			continue;
		}

		if( (TInp[j][1] < TInp[j][0] ) && (TInp[j][1] > (TInp[j][0] - 0.37)) ) 			// 0.37 is the x space used by the class in diagonal
			TOut[j][1] = YMAX;
		else if( (TInp[j][1] > (TInp[j][0] + 0.0283)) || (TInp[j][1] < (TInp[j][0] - 0.3983)) )		// 0.0283 is the space between classes in Y,
			TOut[j][1] = YMIN; 																									// empty space between 0.37 and 0.3983 in X
		else
			j--;
	}
 // cout << "data set " << *dsNum << " generated " << endl;
}  // finish class 0023




void C_sets_generateDataSets::genClass0023a( void ){
	/*!
	 * Class 0023
	 * 2 inputs, 4 output, 4  classes,
	 * one class in the half of a circle in the lower left-corner, there is a diagonal that
	 * split it into two and the rest is the other class too
	 * creatring 4 classes
	 */

	// Local variables
	register int i,j;
	double r2;

	// Variables to control the position of the classes
	double circleCenterX = 0.0035;
	double circleCenterY = 0.0045;
	double circleSpaceMin = 0.6561;     //0.6961; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circleSpaceMax = 0.7389; 		// there is no space between classes


	// Setup variables to return
	//*dsNum = "0023"; 			// number of data set
	//*NoOut = 2;						// outputs in this data set

	// fill only lines patterns
	j = -1;
	while ( j < lines - 1){ 			// original line --> for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		j++;

		for( i = 0 ; i < noInp  ; i++ )
			TInp[j][i] = a + (b - a) * rando(); 						// TIn[j][i] = ran2(idum);

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		if( (r2 = ( (TInp[j][0] - circleCenterX ) * (TInp[j][0] - circleCenterX ) + (TInp[j][1] - circleCenterY) * ( TInp[j][1] - circleCenterY) ) ) < circleSpaceMin){
			TOut[j][0] = YMAX;
			TOut[j][1] = YMIN;
		}
		else if( r2 > circleSpaceMax ){
			TOut[j][0] = YMIN;
			TOut[j][1] = YMAX;
		}
		else {
			j--;
			continue;
		}

		if( (TInp[j][1] < TInp[j][0] ) && (TInp[j][1] > (TInp[j][0] - 0.37)) ) {			// 0.37 is the x space used by the class in diagonal
			TOut[j][2] = YMAX;
			TOut[j][3] = YMIN;
		}
		else if( (TInp[j][1] > (TInp[j][0] + 0.0493)) || (TInp[j][1] < (TInp[j][0] - 0.4383)) ){		// 0.0283 is the space between classes in Y,
			TOut[j][2] = YMIN; 																									// empty space between 0.37 and 0.3983 in X
			TOut[j][3] = YMAX;
		}
		else
			j--;
	}
 // cout << "data set " << *dsNum << " generated " << endl;
}  // finish class 0023a








void C_sets_generateDataSets::genClass0024( void ){
	/*!
	 * Class 0024
	 * Check all the combinaiton form with this code, this is like fig 9 from John paper (Cognitive since, outpu 1 and 2 are for one task) the rest are for the second
	 * 1	0	0	0	0   			// class 1
	 * 0	1	0	0	0 				// class 2, ...
	 * 0	0	1	0	0
	 * 0  0	0	1	0
	 * Note that another experiment could be done::: when the modularity is calculated it can be used one output one module, or input 1 y 2 one module and 3-5 module 2
	 */

	// Local variables
	register int i,j;
	double r2;

	//double h = 0.0;
	int k;
	//int NUMOUT = 5;



	// Variables to control the position of the classes
	double circleCenterX = 0.0035;
	double circleCenterY = 0.0045;
	double circleSpaceMin = 0.6561; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circleSpaceMax = 0.7389; 		// there is no space between classes

	// Variables to control the position of the classes
	double circle2CenterX = 0.035;
	double circle2CenterY = 0.945;
	double circle2SpaceMin = 0.6561; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circle2SpaceMax = 0.7389; 		// there is no space between classes

	// second circle
	double circle3CenterX = 0.35;
	double circle3CenterY = 0.65;
	double circle3SpaceMin = 0.0461; //0.015961; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circle3SpaceMax = 0.0684; //0.02689; 		// there is no space between classes


	// Setup variables to return
	//*dsNum = "0024"; 			// number of data set
	//*NoOut = NUMOUT;						// outputs in this data set

	// 5 classes
	// fill only lines patterns
	j = -1;
	while ( j < lines-1 ){ 			// original line --> for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		j++;

		for( i = 0 ; i < noInp  ; i++ )
			TInp[j][i] = a + (b - a) * rando();  								// TInp[j][i] = ran2(idum);

		for( k = 0 ; k < noOut ; k++ ) 								// fill outputs
			TOut[j][k] = YMIN;

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		// Class 1 y 2, Module 1
		if( (r2 = ( (TInp[j][0] - circleCenterX ) * (TInp[j][0] - circleCenterX ) + (TInp[j][1] - circleCenterY) * ( TInp[j][1] - circleCenterY) ) ) < circleSpaceMin){
			TOut[j][0] = YMAX;
			//TOut[j][1] = 0;
		}
		else if( r2 > circleSpaceMax ){
			//TOut[j][0] = 0;
			TOut[j][1] = YMAX;
		}
		else {
			j--;
			continue;
		}

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		// class 3 4 and 5, Module 2 or tasks 2
		if( (r2 = ( (TInp[j][0] - circle2CenterX ) * (TInp[j][0] - circle2CenterX ) + (TInp[j][1] - circle2CenterY) * ( TInp[j][1] - circle2CenterY) ) ) < circle2SpaceMin){
			TOut[j][2] = YMAX;
			//TOut[j][3] = 0;
			//TOut[j][4] = 0;
		}
		else if( r2 > circle2SpaceMax ){
			//TOut[j][2] = 0;
			TOut[j][3] = YMAX;
			//TOut[j][4] = 0;
		}
		else {
			j--;
			continue;
		}

		if( (r2 = ( (TInp[j][0] - circle3CenterX ) * (TInp[j][0] - circle3CenterX ) + (TInp[j][1] - circle3CenterY) * ( TInp[j][1] - circle3CenterY) ) ) < circle3SpaceMin){
			//TOut[j][1] = 1;
			//TOut[j][3] = 0;
			TOut[j][4] = YMAX;
		}
		else if( r2 > circle3SpaceMax ){
			//TOut[j][1] = 0;
			//TOut[j][3] = 0;
			TOut[j][4] = YMIN;
		}
		else {
			j--;
		}

	}
} /// finish class 0024




void C_sets_generateDataSets::genClass0024a( void ){
	/*!
	 * Class 0024
	 * Check all the combinaiton form with this code, this is like fig 9 from John paper (Cognitive since, outpu 1 and 2 are for one task) the rest are for the second
	 * This fuction is ready for the winner takes all for the classification error
	 */

	// Local variables
	register int i,j;
	double r2;

	//double h = 0.0;
	int k;
	//int NUMOUT = 5;



	// Variables to control the position of the classes
	double circleCenterX = 0.0035;
	double circleCenterY = 0.0045;
	double circleSpaceMin = 0.6561; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circleSpaceMax = 0.7389; 		// there is no space between classes

	// Variables to control the position of the classes
	double circle2CenterX = 0.035;
	double circle2CenterY = 0.945;
	double circle2SpaceMin = 0.6561; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circle2SpaceMax = 0.7389; 		// there is no space between classes

	// second circle
	double circle3CenterX = 0.35;
	double circle3CenterY = 0.65;
	double circle3SpaceMin = 0.0461; //0.015961; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circle3SpaceMax = 0.0684; //0.02689; 		// there is no space between classes


	// 5 classes
	// fill only lines patterns
	j = -1;
	while ( j < lines-1 ){ 			// original line --> for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		j++;

		for( i = 0 ; i < noInp  ; i++ )
			TInp[j][i] = a + (b - a) * rando();  								// TInp[j][i] = ran2(idum);

		for( k = 0 ; k < noOut ; k++ ) 								// fill outputs
			TOut[j][k] = YMIN;

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		// Class 1 y 2, Module 1
		if( (r2 = ( (TInp[j][0] - circleCenterX ) * (TInp[j][0] - circleCenterX ) + (TInp[j][1] - circleCenterY) * ( TInp[j][1] - circleCenterY) ) ) < circleSpaceMin){
			TOut[j][0] = YMAX;
			//TOut[j][1] = 0;
		}
		else if( r2 > circleSpaceMax ){
			//TOut[j][0] = 0;
			TOut[j][1] = YMAX;
		}
		else {
			j--;
			continue;
		}

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		// class 3 4 and 5, Module 2 or tasks 2
		if( (r2 = ( (TInp[j][0] - circle2CenterX ) * (TInp[j][0] - circle2CenterX ) + (TInp[j][1] - circle2CenterY) * ( TInp[j][1] - circle2CenterY) ) ) < circle2SpaceMin){
			TOut[j][2] = YMAX;
			//TOut[j][3] = 0;
			//TOut[j][4] = 0;
		}
		else if( r2 > circle2SpaceMax ){
			//TOut[j][2] = 0;
			TOut[j][3] = YMAX;
			//TOut[j][4] = 0;
		}
		else {
			j--;
			continue;
		}

		if( (r2 = ( (TInp[j][0] - circle3CenterX ) * (TInp[j][0] - circle3CenterX ) + (TInp[j][1] - circle3CenterY) * ( TInp[j][1] - circle3CenterY) ) ) < circle3SpaceMin){
			TOut[j][2] = YMIN;
			TOut[j][3] = YMIN;
			TOut[j][4] = YMAX;
		}
		else if( r2 > circle3SpaceMax ){
			//TOut[j][2] = 0;
			//TOut[j][3] = 0;
			TOut[j][4] = YMIN;
		}
		else {
			j--;
		}

	}
} /// finish class 0024a




void C_sets_generateDataSets::genClass0031a( void ){
	/*!
	 * Class 0031
	 * 2 inputs 6 output and 6 classes one output pper class
	 * first 2 outputs for task one and second two for task 2, last 2 for the last
	 * Circle with coordinates in circleCenterX, circleCenterY, it is cut by a diagonal or not, depend of the coordinate x,y
	 */

	// Local variables
	register int i,j;
	double r2;

	// Variables to control the position of the classes
	double circleCenterX = 0.35;
	double circleCenterY = 0.45;
	double circleSpaceMin = 0.0961; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circleSpaceMax = 0.1089; 		// there is no space between classes

	// Setup variables to return
	//*dsNum = "0021"; 			// number of data set
	//*NoOut = 2;						// outputs in this data set

	// fill only lines patterns
	j = -1;
	while ( j < lines - 1  ){ 			// original line --> for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		j++;

		for( i = 0 ; i < noInp  ; i++ )
			TInp[j][i] = a + (b - a) * rando(); 						// TIn[j][i] = ran2(idum);

		// Task 1

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		if( (r2 = ( (TInp[j][0] - circleCenterX ) * (TInp[j][0] - circleCenterX ) + (TInp[j][1] - circleCenterY) * ( TInp[j][1] - circleCenterY) ) ) < circleSpaceMin){
			TOut[j][0] = YMAX;
			TOut[j][1] = YMIN;
		}
		else if( r2 > circleSpaceMax ){
			TOut[j][0] = YMIN;
			TOut[j][1] = YMAX;
		}
		else {
			j--;
			continue;
		}

		// Task 2
		if( (TInp[j][1] < TInp[j][0]) && (TInp[j][1] > (TInp[j][0] - 0.37)) ){ 			// 0.37 is the x space used by the class in diagonal
			TOut[j][2] = YMAX;
			TOut[j][3] = YMIN;
		}
		else if( (TInp[j][1] > (TInp[j][0] + 0.0493)) || (TInp[j][1] < (TInp[j][0] - 0.4383)) ){		// 0.0283 is the space between classes in Y,
			TOut[j][2] = YMIN; 																									// empty space between 0.37 and 0.3983 in X
			TOut[j][3] = YMAX;
		}
		else{
			j--;
			continue;
		}


		// Task 3
		// Big circle, center to the right bottom
		double circleCenterX3 = 1.0035;
		double circleCenterY3 = 0.0045;
		double circleSpaceMin3 = 0.60561; 		// this both is the limit of values not used, if the max start where the min finish then,
		double circleSpaceMax3 = 0.689; 		// there is no space between classes


		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		if( (r2 = ( (TInp[j][0] - circleCenterX3 ) * (TInp[j][0] - circleCenterX3 ) + (TInp[j][1] - circleCenterY3) * ( TInp[j][1] - circleCenterY3) ) ) < circleSpaceMin3){
			TOut[j][4] = YMAX;
			TOut[j][5] = YMIN;
		}
		else if( r2 > circleSpaceMax3 ){
			TOut[j][4] = YMIN;
			TOut[j][5] = YMAX;
		}
		else {
			j--;
			continue;
		}

	}
 // cout << "data set " << *dsNum << " generated " << endl;
}  // finish class 0031a


void C_sets_generateDataSets::genClass0033a( void ){
	/*!
	 * Class 0033a
	 * 2 inputs, 6 output, 6  classes,
	 * one class in the half of a circle in the lower left-corner, there is a diagonal that
	 * split it into two and the rest is the other class too
	 * creatring 4 classes, the last two are ... check files...
	 */

	// Local variables
	register int i,j;
	double r2;

	// Variables to control the position of the classes
	double circleCenterX = 0.0035;
	double circleCenterY = 0.0045;
	double circleSpaceMin = 0.6561;     //0.6961; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circleSpaceMax = 0.7389; 		// there is no space between classes


	// Setup variables to return
	//*dsNum = "0023"; 			// number of data set
	//*NoOut = 2;						// outputs in this data set

	// fill only lines patterns
	j = -1;
	while ( j < lines - 1){ 			// original line --> for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		j++;

		for( i = 0 ; i < noInp  ; i++ )
			TInp[j][i] = a + (b - a) * rando(); 						// TIn[j][i] = ran2(idum);

		// Task 1

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		if( (r2 = ( (TInp[j][0] - circleCenterX ) * (TInp[j][0] - circleCenterX ) + (TInp[j][1] - circleCenterY) * ( TInp[j][1] - circleCenterY) ) ) < circleSpaceMin){
			TOut[j][0] = YMAX;
			TOut[j][1] = YMIN;
		}
		else if( r2 > circleSpaceMax ){
			TOut[j][0] = YMIN;
			TOut[j][1] = YMAX;
		}
		else {
			j--;
			continue;
		}

		// Task 2

		if( (TInp[j][1] < TInp[j][0] ) && (TInp[j][1] > (TInp[j][0] - 0.37)) ) {			// 0.37 is the x space used by the class in diagonal
			TOut[j][2] = YMAX;
			TOut[j][3] = YMIN;
		}
		else if( (TInp[j][1] > (TInp[j][0] + 0.0493)) || (TInp[j][1] < (TInp[j][0] - 0.4383)) ){		// 0.0283 is the space between classes in Y,
			TOut[j][2] = YMIN; 																									// empty space between 0.37 and 0.3983 in X
			TOut[j][3] = YMAX;
		}
		else{
			j--;
			continue;
		}

		// Task 3

		// Variables to control the position of the classes
		double circleCenterX3 = 0.63;
		double circleCenterY3 = 0.63;
		double circleSpaceMin3 = 0.0961; 		// this both is the limit of values not used, if the max start where the min finish then,
		double circleSpaceMax3 = 0.1089; 		// there is no space between classes


		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		if( (r2 = ( (TInp[j][0] - circleCenterX3 ) * (TInp[j][0] - circleCenterX3 ) + (TInp[j][1] - circleCenterY3) * ( TInp[j][1] - circleCenterY3) ) ) < circleSpaceMin3){
			TOut[j][4] = YMAX;
			TOut[j][5] = YMIN;
		}
		else if( r2 > circleSpaceMax3 ){
			TOut[j][4] = YMIN;
			TOut[j][5] = YMAX;
		}
		else {
			j--;
			continue;
		}

	}
 // cout << "data set " << *dsNum << " generated " << endl;
}  // finish class 0033a



void C_sets_generateDataSets::genClass0034a( void ){
	/*!
	 * Class 0034
	 * Check all the combinaiton form with this code, this is like fig 9 from John paper (Cognitive since, outpu 1 and 2 are for one task) the rest are for the second
	 * This fuction is ready for the winner takes all for the classification error
	 */

	// Local variables
	register int i,j;
	double r2;

	//double h = 0.0;
	int k;
	//int NUMOUT = 5;



	// Variables to control the position of the classes
	double circleCenterX = 0.0035;
	double circleCenterY = 0.0045;
	double circleSpaceMin = 0.6561; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circleSpaceMax = 0.7389; 		// there is no space between classes

	// Variables to control the position of the classes
	double circle2CenterX = 0.035;
	double circle2CenterY = 0.945;
	double circle2SpaceMin = 0.6561; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circle2SpaceMax = 0.7389; 		// there is no space between classes

	// second circle
	double circle3CenterX = 0.35;
	double circle3CenterY = 0.65;
	double circle3SpaceMin = 0.0461; //0.015961; 		// this both is the limit of values not used, if the max start where the min finish then,
	double circle3SpaceMax = 0.0684; //0.02689; 		// there is no space between classes


	// 5 classes
	// fill only lines patterns
	j = -1;
	while ( j < lines-1 ){ 			// original line --> for( j = 0 ; j < EPERYR*NUMPAT ; j++ ) {
		j++;

		for( i = 0 ; i < noInp  ; i++ )
			TInp[j][i] = a + (b - a) * rando();  								// TInp[j][i] = ran2(idum);

		for( k = 0 ; k < noOut ; k++ ) 								// fill outputs
			TOut[j][k] = YMIN;

		// Task 1

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		// Class 1 y 2, Module 1
		if( (r2 = ( (TInp[j][0] - circleCenterX ) * (TInp[j][0] - circleCenterX ) + (TInp[j][1] - circleCenterY) * ( TInp[j][1] - circleCenterY) ) ) < circleSpaceMin){
			TOut[j][0] = YMAX;
			//TOut[j][1] = 0;
		}
		else if( r2 > circleSpaceMax ){
			//TOut[j][0] = 0;
			TOut[j][1] = YMAX;
		}
		else {
			j--;
			continue;
		}

		// Task 2

		// Pythagorean Theorem where x^2 + y^2 = r^2, thus r2 is the diameter of the circle
		// class 3 4 and 5, Module 2 or tasks 2
		if( (r2 = ( (TInp[j][0] - circle2CenterX ) * (TInp[j][0] - circle2CenterX ) + (TInp[j][1] - circle2CenterY) * ( TInp[j][1] - circle2CenterY) ) ) < circle2SpaceMin){
			TOut[j][2] = YMAX;
			//TOut[j][3] = 0;
			//TOut[j][4] = 0;
		}
		else if( r2 > circle2SpaceMax ){
			//TOut[j][2] = 0;
			TOut[j][3] = YMAX;
			//TOut[j][4] = 0;
		}
		else {
			j--;
			continue;
		}

		if( (r2 = ( (TInp[j][0] - circle3CenterX ) * (TInp[j][0] - circle3CenterX ) + (TInp[j][1] - circle3CenterY) * ( TInp[j][1] - circle3CenterY) ) ) < circle3SpaceMin){
			TOut[j][2] = YMIN;
			TOut[j][3] = YMIN;
			TOut[j][4] = YMAX;
		}
		else if( r2 > circle3SpaceMax ){
			//TOut[j][2] = 0;
			//TOut[j][3] = 0;
			TOut[j][4] = YMIN;
		}
		else {
			j--;
			continue;
		}

		// Task 3
		if( (TInp[j][1] < TInp[j][0]) && (TInp[j][1] > (TInp[j][0] - 0.37)) ){ 			// 0.37 is the x space used by the class in diagonal
			TOut[j][5] = YMAX;
			TOut[j][6] = YMIN;
		}
		else if( (TInp[j][1] > (TInp[j][0] + 0.0493)) || (TInp[j][1] < (TInp[j][0] - 0.4383)) ){		// 0.0283 is the space between classes in Y,
			TOut[j][5] = YMIN; 																									// empty space between 0.37 and 0.3983 in X
			TOut[j][6] = YMAX;
		}
		else
			j--;

	}
} /// finish class 0034a


#endif
