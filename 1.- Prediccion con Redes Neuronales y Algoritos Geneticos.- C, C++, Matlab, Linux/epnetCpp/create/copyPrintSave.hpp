/*!
 *  copyPrintSave.hpp
 * Funtions to:
 * Copy, print into the screen, save into a file or load from a file
 * Matrices and vector (of any type)
 *
 * Created: 			around 2008
 * Modified at: 	1 Oct 2010
 * Author:				Carlos Torres and Victor Landassuri
 */

#include<iostream>
#include<iomanip>


#ifndef COPYPRINTSAVE_HPP
#define COPYPRINTSAVE_HPP

// SECTION FOR PRINTF FUNCTIONS

// print in screen a double vector
template <class T>
void imprime(T *m, int ROW)
{
    // print a (Double) vector in the screen
    register int i;
    for(i=0; i<ROW; i++) cout << i << "\t";
    cout << "\n";
    for(i=0; i<ROW; i++) cout << "-------" << "\t";
    cout << "\n";
    for (i=0; i<ROW; i++)
    {
        cout << m[i] << "\t";
    }
    cout << "\n";
}//////////////////////////////////////////////////////////////////////////


// print in screen a matrix of any type
template <class T>
void imprime(T **m, int ROW, int COL)
{
    // printf a matrix on screen
    register int i,j;
    cout << "\t";for(j=0; j<COL; j++) cout << j << "\t";
    cout << "\n";
    cout << "\t";for(j=0; j<COL; j++) cout << "---" << "\t";
    cout << "\n";
    for (i=0; i<ROW; i++)
    {
    	cout << i << "| \t";
        for(j=0; j<COL; j++)
        	cout << setprecision(3) << m[i][j] << "\t";
        cout << "\n";
    }
}//////////////////////////////////////////////////////////////////////////

// print in screen an array of 3 dimensions
template <class T>
void imprime(T ***m, int D3, int ROW, int COL)
{
    // printf a matrix of 3 dimension on screen
    register int i,j,k;
    for(k=0;k<D3;k++)
    {
    	cout << "Dim " << k << endl;
    
    	cout << "\t";for(j=0; j<COL; j++) cout << j << "\t";
    	cout << "\n";
    	for (i=0; i<ROW; i++)
    	{
    		cout << i << "\t";
    		for(j=0; j<COL; j++)
    			cout << m[k][i][j] << "\t";
    		cout << "\n";
    	}

    }
}//////////////////////////////////////////////////////////////////////////
// / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / /
/// / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / /
// / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / /
/// / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / /
///////////// \\\\\\\  SECTION FOR COPY   \\\\\\  ////////////////
// copy n on m;

//copy a matrix (any type), copy n on m and return m
//delete the original content of m because allocate space for it
//BE sure that the variale to be deleted does not have any memory allocated
template <class T>
T **copyAlloc(T **m,T **n,int line,int col){
   try{
	   register int i,j;

	   if(m != NULL)
		   throw  1;

	   m = (T **) malloc(sizeof(T *));			//ALLOCATE MEM
	   for(i=0; i<line; i++){
		   m = (T **) realloc(m,((i+1)*sizeof(T *)));
		   m[i] = (T *) malloc(col * sizeof(T));
		   //m[i] = (T *) malloc(sizeof(T));
		   for(j=0; j<col; j++){
			   //m[i] = (T *) realloc(m[i],(j+1)*sizeof(T));
			   m[i][j] = n[i][j];
		   }
	   }
   }
   catch(const int &e){
	    	processException(e);
   }

   return(m);
}//////////////////////////////////////////////////////////////////////////

//copy matrix n on m (any type) save in **m
template <class T>
void copy(T **m,T **n,int line,int col){
	/*!
	 * Copy n on m and return m automatically in the poitner passed
	 * That delete the original content of m
	 * Here is NOT ALLOCATE MEMORY
	 */
    register int i,j;
    for(i=0; i<line; i++){
        for(j=0; j<col; j++){
            m[i][j] = n[i][j];
        }
    }

}//////////////////////////////////////////////////////////////////////////


//copy matrix n on m (any type) save in **m
void convertInt2DoubleMat(double **m, int **n,int line,int col){
	/*!
	 * Copy n on m and return m automatically in the poitner passe, the int value is converted to double
	 * That delete the original content of m
	 * Here is NOT ALLOCATE MEMORY
	 */
    register int i,j;
    for(i=0; i<line; i++){
        for(j=0; j<col; j++){
            m[i][j] = (double) n[i][j];
        }
    }
}//////////////////////////////////////////////////////////////////////////


//copy matrix n on m (any type) save in **m with an offset
template <class T>
void copyOffsetCol(T **m,T **n,int line,int col, int offsetCol, int initCol_m)
{
	/*!
	 * Copy n on m and return m, delete the original content of m, NO ALLOCATE MEM
	 * inputs:
	 * 		m					place to save the info
	 * 		n					origin
	 * 		line				how many lines, both matrices must have the same number of lines at least
	 * 		col				columns from matrix n
	 * 		offsetCol		first column to copy from n
	 * 		initCol_m		first colum from m to pase the values copied
	 */

    register int i,j,cont = initCol_m;
    for(i=0; i<line; i++){
        for(j=offsetCol; j<col; j++){
            m[i][cont] = n[i][j];
            cont ++;
        }
        cont = initCol_m;		// reset the cont
    }

}//////////////////////////////////////////////////////////////////////////


//copy n on m (vector any type) and return m, allocate space for m
//BE sure that the variale to be deleted does snot have any memory allocated
template <class T>
T *copyAlloc(T *m,T *n,int line){
	try{

	    register int i;

	    if (m != NULL)
	    	throw 2;

	    m = (T *)malloc(sizeof(T));			//ALLOCATE MEM
	    for(i=0; i<line; i++){
	    	m = (T*) realloc(m,(i+1)*sizeof(T));
	    	m[i] = n[i];
	    }

	}
	catch(const int &e){
		processException(e);
	}
	return(m);
}//////////////////////////////////////////////////////////////////////////

//copy n on m (vector double) and return m
template <class T>
void copy(T *m,T *n,int line){
    register int i;
    for(i=0; i<line; i++){
        m[i] = n[i];
    }
}//////////////////////////////////////////////////////////////////////////




///////////////////////////////////////////////////////////////////////////
//////////// Section for functions to save into a file/////////////////////
///////// The file descriptor is passed to the functions//////////////////
///MatrixInt
void saveInt(int **m, int line, int col, FILE *fwrite, char file[]){
	//save and integer Matrix to a file
    register int i,j;
    for(i=0; i<line; i++){
        for(j=0; j<col; j++){
            if((fprintf(fwrite, "%d\t",m[i][j])) == EOF){
                printf("Error writing to file '%s'...\n",file); exit(0);
            }
        }
    }
}//////////////////////////////////////////////////////////////////////////
///MatrixDouble
void saveD(double **m, int line, int col, FILE *fwrite, char file[]){
	// save a double matrix to a file
    register int i,j;
    for(i=0; i<line; i++){
        for(j=0; j<col; j++){
            if((fprintf(fwrite, "%e\t",m[i][j])) == EOF){
                printf("Error writing to file '%s'...\n",file); exit(0);
            }
        }
    }
}//////////////////////////////////////////////////////////////////////////
///VectorInt
void saveInt(int *v, int line, FILE *fwrite, char file[]){
	//save an integer vector to a file
    register int i;
    for(i=0; i<line; i++){
        if((fprintf(fwrite, "%d\t",v[i])) == EOF){
            printf("Error writing to file '%s'...\n",file); exit(0);
        }
    }
}//////////////////////////////////////////////////////////////////////////
///VectorDouble
void saveD(double *v, int line, FILE *fwrite, char file[]){
	//save a double vector to a file
    register int i;
    for(i=0; i<line; i++){
        if((fprintf(fwrite, "%e\t",v[i])) == EOF){
            printf("Error writing to file '%s'...\n",file); exit(0);
        }
    }
}//////////////////////////////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////

///Section for save into a file, with the difference that here is passed//
//////////the name of the file, the vector or matrix and the size/////////


// Create a file with a passed matrix (integer)
void saveInt(char file[],int **m, int line, int col){
    FILE *fwrite;
    register int j,k;

    /* write to a file */
    if ((fwrite =fopen(file , "w")) == NULL){
        printf("Error can not open the file '%s' for writing...\n",file);
    }

    for (j=0; j<line; j++){
        for (k=0; k<col; k++){
            if((fprintf(fwrite, "%d\t",m[j][k])) == EOF){
                printf("Error writing to file '%s'...\n",file);
                exit(0);
            }
        }
        fprintf(fwrite, "\n");
    }
    fclose(fwrite);
}//////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////

//save a double matrix to a file
void saveD(char file[],double **m, int line, int col){
    FILE *fwrite;
    register int j,k;

    /* write to a file */
    if ((fwrite =fopen(file , "w")) == NULL){
        printf("Error can not open the file '%s' for writing...\n",file);
    }

    for (j=0; j<line; j++){
        for (k=0; k<col; k++){
            if((fprintf(fwrite, "%e\t",m[j][k])) == EOF){
                printf("Error writing to file '%s'...\n",file);
                exit(0);
            }
        }
        fprintf(fwrite, "\n");
    }
    fclose(fwrite);
}//////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////

// Create a file with a passed vector (double)
void saveD(char file[],double *m, int line){
    FILE *fwrite;
    register int j;

    /* write to a file */
    if ((fwrite =fopen(file , "w")) == NULL){
        printf("Error can not open the file '%s' for writing...\n",file);
    }

    for (j=0; j<line; j++){
        if((fprintf(fwrite, "%e\t",m[j])) == EOF){
            printf("Error writing to file '%s'...\n",file);
            exit(0);
        }
    }
    fclose(fwrite);
}//////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////

// Create a file with a passed vector (int)
void saveInt(char file[],int *m, int line){
    FILE *fwrite;
    register int j;

    /* write to a file */
    if ((fwrite =fopen(file , "w")) == NULL){
        printf("Error can not open the file '%s' for writing...\n",file);
    }

    for (j=0; j<line; j++){
        if((fprintf(fwrite, "%d\t",m[j])) == EOF){
            printf("Error writing to file '%s'...\n",file);
            exit(0);
        }
    }
    fclose(fwrite);
}//////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////


int loadVecInt(string file2read, int *vec ){
	/*!
	 * Load a vector stored in a file and save the value in the vector passed
	 * Be sure that the vector is long enogh to hold all the information
	 * It is returned the number of elements loaded and saved them into the vector
	 */

	FILE *ff;

	//open file//
	if((ff = fopen( file2read.c_str() ,"r")) == NULL){
		cerr << " Error cannot open" << file2read << " for reading" << endl;
		exit(0);
	}
    //copy values
	int cont = 0;

	while ( fscanf(ff,"%d",&vec[cont]) != EOF)
		cont++;

	fclose(ff);

	//cout << "values loaded = " << endl;
    //imprime(vec,cont);

    return(cont);

}//////////////////////////////////////////////////////////////////////////


int loadVecInt(string file2read){
	/*!
	 * Load a vector stored in a file and only return the number of classes there are (for the specifict case it only read how many element are read)
	 * This is different to the same function where it is returnes which output belong to wchich module
	 */

	FILE *ff;
	int tmp;

	//open file//
	if((ff = fopen( file2read.c_str() ,"r")) == NULL){
		cerr << " Error cannot open" << file2read << " for reading" << endl;
		exit(0);
	}
    //copy values
	int cont = 0;

	while ( fscanf(ff,"%d",&tmp) != EOF) 		// always save int he same var, s only it is interested in the number of elements read
		cont++;

	fclose(ff);

	//cout << "values loaded = " << endl;
    //imprime(vec,cont);

    return(cont);

}//////////////////////////////////////////////////////////////////////////






#endif
