/*!
 *  Cmatrix.hpp
 *
 * Create matrices with classes
 * Useful in this cases:
 * 	create a vector with a matrix in each position
 *
 * example usage:
 *
 * history = (C_matrix *) new C_matrix[NUM_MODULES];
 *
 *
 *	mat[0] = new C_matrix(5,5);
 *	mat[1] = new C_matrix(3,3);
 *	A[0] = new C_matrix(4,4);
 *
 *	set(mat[0]->m, mat[0]->lines, mat[0]->cols,1);
 *	set(mat[1]->m, mat[1]->lines, mat[1]->cols,2);
 *
 *	imprime(mat[0]->m, mat[0]->lines, mat[0]->cols);
 *	imprime(mat[1]->m, mat[1]->lines, mat[1]->cols);
 *
 *	A[0]->copyAllocClassMatrix(mat[1]);
 *	imprime(A[0]->m, A[0]->lines, A[0]->cols);
 *
 *	A[0]->copyClass(mat[0]);
 *	imprime(A[0]->m, A[0]->lines, A[0]->cols);
 *
 *
 *	delete mat[1];
 *	delete mat[0];
 *	delete A[0];
 *
 * Created: 			7 May 2011
 * Modified at:
 * Author: 			Carlos Torres and Victor Landassuri
 *
 */

#ifndef C_MATRIX_HPP
#define C_MATRIX_HPP



/*!
 * Functions / Methods for the class matrix
 *
 */

// Constructor for ints
C_matrixInt::C_matrixInt(void){//int mLines, int mCols){
	maxLines = 0;//mLines;
	maxCols = 0;// mCols;

	lines = 0;//mLines;
	cols = 0;//mCols;

	m = NULL;

	//m = allocate(m,maxLines,maxCols);
} // End constructor



// Constructor for doubles
C_matrixDouble::C_matrixDouble(void){//int mLines, int mCols){
	maxLines = 0;//mLines;
	maxCols = 0;// mCols;

	lines = 0;//mLines;
	cols = 0;//mCols;

	m = NULL;

	//m = allocate(m,maxLines,maxCols);
} // End constructor



// Destructor int
C_matrixInt::~C_matrixInt(){
	safefree(&m,maxLines);
} // End Destructor


// Destructor double
C_matrixDouble::~C_matrixDouble(){
	safefree(&m,maxLines);
} // End Destructor



// set, allocate memory for the matrix and set the rest of the values
void C_matrixInt::setMat(int mLines, int mCols){
	maxLines = mLines+2;
	maxCols =  mCols+2;

	lines = mLines;
	cols = mCols;

	m = NULL;

	m = allocate(m,maxLines,maxCols);
} // End set

// set, allocate memory for the matrix and set the rest of the values
void C_matrixDouble::setMat(int mLines, int mCols){
	maxLines = mLines+2;
	maxCols =  mCols+2;

	lines = mLines;
	cols = mCols;

	m = NULL;

	m = allocate(m,maxLines,maxCols);
} // End set



void C_matrixInt::copyClass(C_matrixInt *m2){

	// check that m2 is not bigger than this
	if (m2->maxLines > maxLines || m2->maxCols > maxCols){			// In the future improve this fucntion, only expanding the matrix may work, but check carrefully that the method work
		//copyAllocClassMatrix(m2);
		cout << "Error different sizes of matrix, fun matrixInt::copyClass" << endl;
	}
	else{
		lines = m2->lines;
		cols = m2->cols;
		copy( m, m2->m, m2->lines, m2->cols);
	}
} // End method copyClass


void C_matrixDouble::copyClass(C_matrixDouble *m2){

	// check that m2 is not bigger than this
	if (m2->maxLines > maxLines || m2->maxCols > maxCols){			// In the future improve this fucntion, only expanding the matrix may work, but check carrefully that the method work
		//copyAllocClassMatrix(m2);
		cout << "Error different sizes of matrix, fun matrixInt::copyClass" << endl;
	}
	else{
		lines = m2->lines;
		cols = m2->cols;
		copy( m, m2->m, m2->lines, m2->cols);
	}
} // End method copyClass Double



void C_matrixInt::copyAllocClassMatrix(C_matrixInt *m2){
/*!
 * Be sure that 'this' was allocated before call this function, error in other case
 * Not sure that it works, if I change the size of m maybe I need to return the pointer of the new class, if that is valid... check later if needed
 */
/*	if(m != NULL)
		safefree(&m,maxLines);

	m = copyAlloc(m, m2->m, m2->lines, m2->cols);

	maxLines = m2->lines+2;
	maxCols = m2->cols+2;

	lines = m2->lines;
	cols = m2->cols;
*/
} // End method copyClass


void C_matrixInt::save2file(FILE *fwrite, char file[]){
	fprintf(fwrite, "%d\t",lines);
	fprintf(fwrite, "%d\t",cols);
	saveInt(m, lines, cols, fwrite,file);
} // End Method save2File

void C_matrixDouble::save2file(FILE *fwrite, char file[]){
	fprintf(fwrite, "%d\t",lines);
	fprintf(fwrite, "%d\t",cols);
	saveD(m, lines, cols, fwrite,file);
} // End Method save2File



void C_matrixInt::loadMat(FILE *fread){
	/*!
	 * Load a matrix class from a file
	 * If the matrix was allocated, delete its conten and allocate to the new space
	 */
	float svalue;

	if (m != NULL)
		safefree(&m, maxLines);


	if(fscanf(fread,"%f",&svalue)!= EOF)
		lines = (int) svalue;

	if(fscanf(fread,"%f",&svalue)!= EOF)
		cols = (int) svalue;

	// setup the rest or the parameters
	maxLines = lines+2;
	maxCols =  cols+2; 			// plus one to have space to add the actual calss that is solved

	// allocate memory
	m = allocate(m,maxLines,maxCols);

	 // recuperate matrix
	 for (int i=0; i<lines; i++){
		 for(int j=0; j<cols; j++){
			 if(fscanf(fread,"%f",&svalue)!= EOF)
				 m[i][j] = (int) svalue;
		 }
	 }

} // End Method Load matrix



void C_matrixDouble::loadMat(FILE *fread){
	/*!
	 * Load a matrix class from a file
	 * If the matrix was allocated, delete its conten and allocate to the new space
	 */
	float svalue;

	if (m != NULL)
		safefree(&m, maxLines);


	if(fscanf(fread,"%f",&svalue)!= EOF)
		lines = (int) svalue;

	if(fscanf(fread,"%f",&svalue)!= EOF)
		cols = (int) svalue;

	// setup the rest or the parameters
	maxLines = lines+2;
	maxCols =  cols+2; 			// plus one to have space to add the actual calss that is solved

	// allocate memory
	m = allocate(m,maxLines,maxCols);

	 // recuperate matrix
	 for (int i=0; i<lines; i++){
		 for(int j=0; j<cols; j++){
			 if(fscanf(fread,"%f",&svalue)!= EOF)
				 m[i][j] = svalue;
		 }
	 }

} // End Method Load matrix


void C_matrixInt::clean(void){
	set(m,lines,cols,0);
	lines = 0;
	cols = 0;
} // End method clean

void C_matrixDouble::clean(void){
	set(m,lines,cols,0);
	lines = 0;
	cols = 0;
} // End method clean Double

#endif
