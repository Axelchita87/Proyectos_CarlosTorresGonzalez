/*!
 *  operationsVecMat.hpp
 * Created: 01/12/09
 * Here are all the funtions for operations with vector and matrices
 * set to zeros, min, max, ...
 * 
 */
#ifndef CGRALCLASSES_HPP
#define CGRALCLASSES_HPP

//////// Section for funtions to set to ZERO matrices and vector //////////
// Fill a vector with the given value
template <class T> // (correct)
void set(T *m,int line, int val)
{
    //put val in the vector
    register int i;

    for(i=0; i<line; i++)
        m[i] = val;
}
///////////////////////////////////////////////////////////////////////////
// Fill a matrix with the given value
template <class T>
void set(T **m, int line, int col, int val)
{
    register int i,j;
    for(i=0; i<line; i++)
    {
        for(j=0; j<col; j++)
        {
            m[i][j] = val;
        }
    }
}
///////////////////////////////////////////////////////////////////////////
// Fill a matrix of 3D with the given value
template <class T>
void set(T **m, int D3, int line, int col, int val)
{
	cout << "enter to set to 0 M 3D" << endl;
    register int i,j,k;
    for(k=0; k<D3; k++)
    {
    	for(i=0; i<line; i++)
    	{
    		for(j=0; j<col; j++)
    		{
    			m[k][i][j] = val;
    		}
    	}
    }
//    cout << "EDN enter to set to zero a 3D Matrix" << endl;
}
///////////////////////////////////////////////////////////////////////////


/* OLD CODE
 // found the minimum in a matrix and return a vector of min per row
 template <class T>
 T *minRow(T **m,int line, int col)
 {
 register int i,j;
 T temp;
 T *min  = NULL;
 
 min = allocate(min,line);
 //printf("line = %d, col = %d\n",line,col);
 //imprime(m,line,col);
 for(i=0;i<line;i++)
 {
 temp = m[i][0];
 for(j=1;j<col;j++)
 if(m[i][j] < temp)
 temp = m[i][j];
 
 min[i] = temp;
 //printf("min[%d] = %f\n",i,min[i]);
 }
 return(min);
 }//////////////////////////////////////////////////////////////////////////
 */


// found the minimum in a matrix and return a vector of min per row, NEW CODE
template <class T>
T *minRow(T **m,int line, int col)
{
    register int i;
    T *min  = NULL;
    min = allocate(min,line);
    
    for(i=0;i<line;i++)
        min[i] = *min_element(&m[i][0],&m[i][0]+col);
    
    return(min);
}//////////////////////////////////////////////////////////////////////////



// found the maximum in a matrix and return a vector with the max per row, new code
template <class T>
T *maxRow(T **m,int line, int col)
{
    register int i;
    T *max  = NULL;
    max = allocate(max,line);
    
    for(i=0;i<line;i++)
        max[i] = *max_element(&m[i][0],&m[i][0]+col);
    
    return(max);
}//////////////////////////////////////////////////////////////////////////


// found the maximum in a matrix line and cols and return the value
template <class T>
T maxMatrix(T **m,int line, int col)
{
    T *maxval = NULL;
    T maxfinal = 0;

    // obtain the max per row, where each row represent an output
    maxval = maxRow(m,line,col);

    // obtain the max from the previos row vectors, so they are the min and max of all the matrix
    maxfinal = *max_element(&maxval[0],&maxval[0]+line);

    safefree(&maxval);

    return(maxfinal);
}//////////////////////////////////////////////////////////////////////////

// found the maximum in a matrix line and cols and return the value
template <class T>
T minMatrix(T **m,int line, int col)
{

    T *minval = NULL;
    T minfinal = 0;

    // obtain the min per row, where each row represent an output
    minval = minRow(m,line,col);

    // obtain the min from the previos row vectors, so they are the min and max of all the matrix
    minfinal = *min_element(&minval[0],&minval[0]+line);

    safefree(&minval);

    return(minfinal);
}//////////////////////////////////////////////////////////////////////////

/* OLD CODE
// found the maximum in a matrix and return a vector with the max per row
template <class T>
T *maxRow(T **m,int line, int col)
{
    register int i,j;
    T temp;
    T *max  = NULL;
    max = allocate(max,line);
    //printf("line = %d, col = %d\n",line,col);
    //imprime(m,line,col);
    for(i=0;i<line;i++)
    {
        temp = m[i][0];
        for(j=1;j<col;j++)
            if(m[i][j] > temp)
                temp = m[i][j];

        max[i] = temp;
        //printf("max[%d] = %f\n",i,max[i]);
    }
    return(max);
}//////////////////////////////////////////////////////////////////////////
*/





// found the maximum in a matrix and return a vector with the max per column
template <class T>
T *maxCol(T **m,int line, int col)
{
    register int i,j;
    T temp;
    T *max = allocate(max,col);
    //printf("line = %d, col = %d\n",line,col);
    //imprime(m,line,col);
    for(i=0;i<col;i++)
    {
        temp = m[0][i];
        for(j=1;j<line;j++)
            if(m[j][i] > temp)
                temp = m[j][i];

        max[i] = temp;
        //printf("max[%d] = %f\n",i,max[i]);
    }
    return((T *)max);
}//////////////////////////////////////////////////////////////////////////


// found the minimum in a vector and return the minimum and the position of it
template <class T>
T *minRow_Pos(T *m,int col)
{
	// Arguments:	///////////////////////////////////////////////
	//				m		input vector to look for the min
	//				col		columns in the vector
	// Output:
	//				min[2]	[0] the minimumn [1] the position of it
	///////////////////////////////////////////////////////////////

    register int j;
    int pos;
    T temp;
    T *min  = NULL;

    min = allocate(min,2);
    //printf("line = %d, col = %d\n",line,col);
    //imprime(m,line,col);
    temp = m[0];
    pos = 0;
    for(j=1;j<col;j++){
    	if(m[j] < temp){
    		temp = m[j];
    		pos = j;
    	}
    }

    min[0] = temp;
    min[1] = (int) pos;

    return(min);
}//////////////////////////////////////////////////////////////////////////



// found the minimum in a matrix and return a vector with the min per column
template <class T>
T *minCol(T **m,int line, int col)
{
    register int i,j;
    T temp;
    T *min = allocate(min,col);
    //printf("line = %d, col = %d\n",line,col);
    //imprime(m,line,col);
    for(i=0;i<col;i++)
    {
        temp = m[0][i];
        for(j=1;j<line;j++)
            if(m[j][i] < temp)
                temp = m[j][i];

        min[i] = temp;
        //printf("min[%d] = %f\n",i,min[i]);
    }
    return(min);
}//////////////////////////////////////////////////////////////////////////


// transpose a row vector (double) to a column vector, recives **m, return **m
template <class T>
T **transposeVec2Col(T **m,int ROW,int COL)
{
    register int i;
    for(i=0; i<COL; i++){
        if(i!=0){
            m = (T **) realloc(m,((i+1)*sizeof(T *)));
            m[i] = (T *) malloc(sizeof(T));
            m[i] = (T *) realloc(m[i],sizeof(T));
        }
        m[i][0] = m[0][i];
        if(i!=0)
            m[0][i] = 0; //clear the old values, but it continue using the memory
    }
    return(m);
}//////////////////////////////////////////////////////////////////////////

// transpose a row vector to a column vector, giving the number of columns, save it in **n
template <class T>
void transposeVec2Col(T **m, int col, T **n)
{
	register int i;
	   for(i=0; i<col; i++)
		   n[i][0] = m[0][i];
}//////////////////////////////////////////////////////////////////////////

// transpose column vector to a row vector, giving the input and output, save it in **n
template <class T>
void transposeMatSqu(T **m, int line,int col, T **n)
{
    register int i,j;
    for(i=0; i<line; i++){
    	for(j=0; j<col; j++){
    		n[i][j] = m[j][i];
    	}
    }
}//////////////////////////////////////////////////////////////////////////


template <class T>
void transposeMat(T **m, int line,int col, T **n){
	/*!
	 * Transpose a matrix non squared, save it in **n
	 * line and col are the indexes from n
	 */
    register int i,j;
    for(i=0; i<line; i++){
    	for(j=0; j<col; j++){
    		n[i][j] = m[j][i];
    	}
    }
}//////////////////////////////////////////////////////////////////////////

// transpose a column vector to a row vector, giving the input and output, save it in **n
template <class T>
void transposeCol2Vec(T **m, int col, T **n)
{
	register int i;
	   for(i=0; i<col; i++)
		   n[0][i] = m[i][0];
}//////////////////////////////////////////////////////////////////////////




// change p and t in a random way
void randomPT(double **pn,double **tn,int linep,int col,int linet)
{
    register int p,j,np;
    register float op;
    for( p = 0 ; p < col ; p++) {         /* swap random elements into each position */
        np = (int) (p + rando() * ( col - p )) ;
        for(j=0; j<linep; j++){
            op = pn[j][p];
            pn[j][p] = pn[j][np] ;
            pn[j][np] = op ;
            //cout << "randomPT in p, np , p , j = " << np << ", " << p << ", " << j << endl;
        }
        for(j=0; j<linet; j++){
        	//cout << "randomPT in t, pn , j = " << np << ", "<< j << endl;
            op = tn[j][p];
            tn[j][p] = tn[j][np] ;
            tn[j][np] = op ;
        }
    }
}//////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////

template <class T>
void randomMat(T **pn,int linep,int col)
{
	/*!
	 * Change a Matrix randomly
	 * here it is assumed that the indexes start in zero until linep and col
	 */

	// Local var
    register int p,j,np;
    T op;

    // Method
    for( p = 0 ; p < col ; p++) {         				// swap random elements into each position
        np = (int) (p + rando() * ( col - p )) ;
        for(j=0; j<linep; j++){
            op = pn[j][p];
            pn[j][p] = pn[j][np] ;
            pn[j][np] = op ;
            //cout << "randomPT in p, np , p , j = " << np << ", " << p << ", " << j << endl;
        }
    }
}//////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////

template <class T>
void randomMat(T **pn,int initLine, int finalLine,int initCol, int finalCol)
{
	/*!
	 * Change a Matrix randomly
	 * here it is say only which lines and coles will be randomly swapped
	 */

	// Local var
    register int p,j,np;
    T op;

    // Method
    for( p = initCol ; p < finalCol ; p++) {         				// swap random elements into each position
        np = (int) (p + rando() * ( finalCol - p )) ;
        for(j=initLine; j<finalLine; j++){
            op = pn[j][p];
            pn[j][p] = pn[j][np] ;
            pn[j][np] = op ;
            //cout << "randomPT in p, np , p , j = " << np << ", " << p << ", " << j << endl;
        }
    }
}//////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////

// change any vector into a random position of any type
//template <class T>
void randomVec(int  *vec, int col)
{
    register int p,np;
    register int op;
    for( p = 0 ; p < col ; p++) {      					   /* swap random elements into each position */
    	np = (int) (p + rando() * ( col - p )) ;
    	op = vec[p];
    	vec[p] = vec[np] ;
    	vec[np] = op ;
    	//cout << "randomPT in p, np , p , j = " << np << ", " << p << ", " << j << endl;
    }
}//////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////

//Funtion meanMd, the mean of a matrix per row, save in *mean
void fmean(double **m,int line,int col,double *mean){

    register int i,j;
    register double sum;

    for(i=0; i<line; i++){
        sum=0;
        for(j=0; j<col; j++)
            sum+= m[i][j];
        mean[i] = sum/col;
    }
    //printf("in function Mean ====\n"); imprimeVd(mean,sizetpos);
}//////////////////////////////////////////////////////////////////////////

//Funtion meanMd, the mean of a matrix per row, save in *mean
double fmean(double *m,int col){

    register int j;
    double sum;
    double mean = 0;

    sum=0;
    for(j=0; j<col; j++)
    	sum+= m[j];

    mean = sum/col;
    return (mean);

    //printf("in function Mean ====\n"); imprimeVd(mean,sizetpos);
}//////////////////////////////////////////////////////////////////////////


//Funtion meanMd, the mean of a matrix per rows and cols, retunr one value only
double fmean(double **m,int lines, int cols){

    register int i,j;
    double sum;
    double mean = 0;

    sum=0;
    for ( i = 0; i<lines; i++){
    	for(j=0; j<cols; j++)
    		sum+= m[i][j];
    }
    mean = sum / ( lines * cols ) ;
    return (mean);

    //printf("in function Mean ====\n"); imprimeVd(mean,sizetpos);
}//////////////////////////////////////////////////////////////////////////

//abs of a Matrix double, save in **n of the same size
void abs(double **m, int line, int col, double **n){
	register int i,j;

	for(i=0; i<line; i++)
		for(j=0; j<col; j++)
			n[i][j] = fabs(m[i][j]);
}/////////////////////////////////////////////////////////////////////////////

//difference between m and n, m-n, save a Matix of the same size in **diff
template <class T>
void difference(T **m, T **n, int line, int col, T **diff)
{
	register int i,j;

	for(i=0; i<line; i++){
		for(j=0; j<col; j++)
			diff[i][j] =  m[i][j] - n[i][j];
    }
}/////////////////////////////////////////////////////////////////////////////



// find the max in the first row, and save the line[1][] and col[2][] in max
void maxAndpos(double **m, int col, double *maxi)
 {
     register int j,pos;

     maxi[0] = m[0][0];
     maxi[1] = m[1][0];
     maxi[2] = m[2][0];
     pos = 0;
     for(j=1;j<col;j++){
    	 if(m[0][j] > maxi[0]){
    		 maxi[0] = m[0][j];
    		 maxi[1] = m[1][j];
    		 maxi[2] = m[2][j];
    		 pos = j;
    	 }
     }
     m[0][pos] = 0; // clear the value here, save more operation in the future
     //m[1][pos] = 0;
     //m[2][pos] = 0;
     //printf("max[%d] = %f\n",i,max[i]);

}//////////////////////////////////////////////////////////////////////////

template <class T>
void maxAndPosVec(T *vec, int cols, T *max, int *pos){
	/*!
	 * Function to fins the maximum and the position of a vector of any type
	 *
	 * Input:
	 * 		vec 				the vector to look for
	 * 		cols				how many cols does it have
	 * 		max				where is saved the maximum.  *** it shuold be the same type as vec ***
	 * 		pos 				where is savec thenposition where it was found the maximumn
	 *
	 * Outouts
	 * 		max
	 * 		pos 				the position is returnes in format 0-n
	 */

	max[0] = vec[0];
	pos[0] = 0;
	for (int i=1; i<cols; i++){
		if (max[0] < vec[i]){
			max[0] = vec[i];
			pos[0] = i;
		}
	}
}  //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


int countConnNet(int **m, int *b, int tam){
	// Function to calculate the number of connections

	// Arguments:  //////////////////////////////////////////////////////////
	//			m		the CW matrix that have the connections
	//			b		the bias vector
	//			tam	the size of m and b
	// Output
	//			cont 	number of connections counted
	////////////////////////////////////////////////////////////////////////////////

	int j, k, cont = 0;
	for(j=0; j<tam; j++){
		for(k=0; k<tam; k++){
			if(m[j][k] == 1)
				cont++;
		}
		if(b[j] == 1)
			cont++;
	}
	return (cont);
}///////////////////////////////////////////////////////////////////////////////////////


int countConnNet(int **m, int tam){
	// Function to calculate the number of connections without use the bias vector

	// Arguments:  //////////////////////////////////////////////////////////
	//			m		the CW matrix that have the connections
	//			tam	the size of m and b
	// Output
	//			cont 	number of connections counted
	////////////////////////////////////////////////////////////////////////////////

	int j, k, cont = 0;
	for(j=0; j<tam; j++){
		for(k=0; k<tam; k++){
			if(m[j][k] == 1)
				cont++;
		}
	}
	return (cont);
}///////////////////////////////////////////////////////////////////////////////////////


// count the number of inputs or hidden nodes in a vector passed as input parameter
int countNodesVec(int *vec, int line){
	int i,cont = 0;

	for( i=0; i<line; i++){
		if(vec[i] == 1)
			cont++;
	}
	return cont;
}///////////////////////////////////////////////////////////////////////////////////////



template <class T>
void concatenateVec(T *a,int colA,T *b, int colB, T *saveHere){
	/*!
	 * Template to concatenate two vectors of any type
	 *
	 * At the end savehere = [ a b ]
	 *
	 * The result is saved in the variable saveHere
	 *You should be sure that there is space enough in saveHere, if not there is error or memory override
	 */

	// Copy the first
	int i;
	int cont = 0;

	for ( i=0; i< colA; i++){
			saveHere[cont] = a[i];
			cont++;
		}

	for ( i=0; i<colB; i++){
			saveHere[cont] = b[i];
			cont++;
		}

} //////////////////////////////////////////////////////////////////////////////////




template <class T>
void concatenateVecInverse(T *a,int colA,T *b, int colB, T *saveHere){
	/*!
	 * Template to concatenate two vectors of any type in an inverse order, this is like to
	 * concatenate two vector and then inverse it
	 *
	 * At the end savehere = [ b  a] putting then inreverse order
	 *
	 * The result is saved in the variable saveHere
	 *You should be sure that there is space enough in saveHere, if not there is error or memory override
	 */

	// Copy the first
	int i;
	int cont = 0;

	for ( i=colB- 1; i>= 0 ; i--){
			saveHere[cont] = b[i];
			cont++;
		}

	for ( i=colA-1; i>= 0; i--){
		saveHere[cont] = a[i];
		cont++;
	}

} //////////////////////////////////////////////////////////////////////////////////



template <class T>
void inverseVec(T *a,int colA, T *saveHere){
	/*!
	 * Template to inverse a vector of any type
	 *
	 * The result is saved in the variable saveHere
	 *You should be sure that there is space enough in saveHere, if not there is error or memory override
	 */

	// Copy the first
	int i;
	int cont = 0;

	for ( i=colA-1; i>= 0; i--){
		saveHere[cont] = a[i];
		cont++;
	}

} //////////////////////////////////////////////////////////////////////////////////



template <class T>
T SUMvec(T * vec, int cols){
	/*!
	 * Sum the values given in a vector of any type
	 * The sum is value is returned
	 */
	T sum = 0;
	int i;
	for (i = 0; i < cols; i++)
		sum+= vec[i];

	return ((T) sum);
} ////////////////////////////////////////////////////////////////////////////////


template <class T>
T SUMmat(T **mat, int lines, int cols){
	/*!
	 * Sum the values given in a matrix of any type
	 * The sum is returned
	 */
	T sum = 0;
	int i,j;

	for (i = 0; i < lines; i++){
		for (j=0; j<cols; j++)
			sum+= mat[i][j];
	}

	return ((T) sum);
} ////////////////////////////////////////////////////////////////////////////////



template <class T>
int findNum(T num, T *vec, int cols){
	/*!
	 * Find a number in a vector, if it exist retunr 1 else 0
	 *
	 */
	int i;
	for (i=0; i<cols; i++){
		if (vec[i] == num)
			return(1);
	}
	return(0);  // if it was not found

} ////////////////////////////////////////////////////////////////////////////////

#endif
