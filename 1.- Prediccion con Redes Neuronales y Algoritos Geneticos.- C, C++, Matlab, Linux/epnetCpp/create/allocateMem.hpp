/*!
 *  alocateMem.hpp
 * funtions to allocate memory
 * to deallocate
 * and to fill vector and matrices with zeros
 * */

#ifndef ALLOCATEMEM_HPP
#define ALLOCATEMEM_HPP

//// Section for allocation of memory, here is used templates ////


// The definition of the template cannot be put in the definition.hpp, becuse they are generated at run time
//Note that here we use templates to perform the same operation with any type, and we use funtion overloading to allocate vector and matrices, even matrices of 3d with the same name

// Allocate a vetor of any type, return (T *) m
template <class T>
T *allocate(T *m, int tam) {
	try{
		if(m != NULL)
			throw 4;

		register int j;

		m = (T *) malloc(tam * sizeof(T));
		for(j=0; j<tam; j++)
			m[j] = 0;
	}
	catch(const int &e){
		processException(e);
	}

      /* original functions that works
       m = (T *) malloc(sizeof(T));
       for(j=0; j<tam; j++)
      {
          m = (T *) realloc(m,(j+1)*sizeof(T));
          m[j] = 0;
      }*/

      return((T *) m);
}


// Allocate a Matrix of any type, return **m
template <class T>
T **allocate(T **m,int line,int col){
	try{
		register int i,j;

		if(m != NULL){
			throw 3;
		}

		m = (T **) malloc(sizeof(T *));
		for(i=0; i<line; i++)
		{
			m = (T **) realloc(m,((i+1)*sizeof(T *)));
			m[i] = (T *) malloc( col * sizeof(T));
			for(j=0; j<col; j++)
				m[i][j] = 0;
		}
	}
	catch(const int &e){
		processException(e);
	}
		return((T **) m);

		/* original function that works
		 * register int i,j;
		m = (T **) malloc(sizeof(T *));
		for(i=0; i<line; i++)
		{
        m = (T **) realloc(m,((i+1)*sizeof(T *)));
        m[i] = (T *) malloc(sizeof(T));
        for(j=0; j<col; j++)
        {
            m[i] = (T *) realloc(m[i],(j+1)*sizeof(T));
            m[i][j] = 0;
        }
    }
    return((T **) m);*/

}//////////////////////////////////////////////////////////////////////////

// Allocate a matrix of 3d, return ***m3
template <class T>
T ***allocate(T ***m3,int D3,int line,int col)
{
	try{
		if(m3 != NULL)
		throw 5;

		register int i,j,k;
		m3 = (T ***) malloc(sizeof(T **));
		for(i=0; i<D3; i++)
		{
			m3 = (T ***) realloc(m3,((i+1)*sizeof(T **)));
			m3[i] = (T **) malloc(sizeof(T *));
			for(j=0; j<line; j++)
			{
				m3[i] = (T **) realloc(m3[i],(j+1)*sizeof(T*));
				m3[i][j] = (T *) malloc(sizeof(T));
				for(k=0; k<col; k++)
				{
					m3[i][j] = (T *) realloc(m3[i][j],(k+1)*sizeof(T));
					m3[i][j][k] = 0;
				}
			}
		}
	}
	catch(const int &e){
		processException(e);
	}
    return(m3);
}//////////////////////////////////////////////////////////////////////////



/////// Section for realocation, until now only matrices, is missing vector ////////
//THIS SECTION IS NOT TESTED WITH REALLOC FOR NON SQUARED MATRICES E.G. FROM 3X3 TO 2X5 ,...


// Reallocate a Matrix of any Type return **m
template <class T>
T **reallocate(T **m,int line,int col,int newline, int newcol)
{
	if(newline > line || newcol > col)
		m = reallocateMore(m,line,col,newline,newcol);
	else
		m = reallocateLess(m,line,col,newline,newcol);

	return((T **) m);
}//////////////////////////////////////////////////////////////////////////

template <class T>
T *reallocate(T *m,int col,int newcol)
{
	if(newcol > col)
		m = reallocateMore(m,col,newcol);
	else
		m = reallocateLess(m,newcol);

	return((T *) m);
}//////////////////////////////////////////////////////////////////////////


// Reallocate a Matrix of any Type return **m
template <class T>
T **reallocateMore(T **m,int line,int col,int newline, int newcol)
{
    register int i = 0, j= 0;
    //cout << "entering to reallocate more fun :) good luck" << endl;
    //m = malloc(sizeof(double *));
    for(i=line; i<newline; i++)
    {
        m = (T **) realloc(m,((i+1)*sizeof(T *)));
        m[i] = (T *) malloc(sizeof(T));
        for(j=0; j<col; j++)
        {
            m[i] = (T *) realloc(m[i],(j+1)*sizeof(T));
            m[i][j] = 0;
        }
    }

    // allocate space for the rest of the columns in the fisrt lines
    for(i = 0; i< newline; i++){
    	m[i] = (T *) realloc(m[i], newcol * sizeof(T));
    	m[i][newcol -1] = 0;
    }

    return((T **) m);
}//////////////////////////////////////////////////////////////////////////



// Reallocate a Matrix of any Type return **m (tested, no memory leack no errors)
template <class T>
T **reallocateLess(T **m,int line,int col,int newline, int newcol)
{
	//cout << "Line = " << line << " col = " << col << " newline = " << newline << " newcol = " << newcol << endl;
	// delete the last lines
	for(int i = (line -1); i>= newline; i--)
		free(m[i]);

	// delete the second pointer to the rest of the lines
	m = (T **) realloc(m,(newline*sizeof(T *)));

	// readjust the number of columns of the remain lines
	for(int i = 0; i< newline; i++)
		m[i] = (T *) realloc(m[i], newcol * sizeof(T));

    return((T **) m);
}//////////////////////////////////////////////////////////////////////////

// Increment the size of a vector. (tested, no memory leack, no errors)
template <class T>
T *reallocateMore(T *m, int tam, int newTam) {
  register int j;
      //m = (T *) malloc(sizeof(T));
      for(j=tam; j<newTam; j++)
      {
          m = (T *) realloc(m,(j+1)*sizeof(T));
          m[j] = 0;
      }
      return((T *) m);
}

// reallocate with a smaller size vector  (tested, no memory leack, no errors)
template <class T>
T *reallocateLess(T *m, int tam) {
	m = (T *) realloc(m,(tam)*sizeof(T));
	return((T *) m);
}


///////   SECTION FOR DEALLOCATE MEMORY --  FREE ( ) ////////////////////////

// Free space for a squared matrix
template <class T>
void safefree(T ***m, int line){
	// recive a matrx (** T) and make the matrix to null at the end
	// cause it is used (***) it is not needed to return the null value to the matrix
	 register int i;

	if(m != NULL && *m != NULL){					// check that is valid
		for(i=line -1; i>=0 ;i--){						// delete in reverse order
			if(m[0][i] != NULL){							// test that the line to be deleted is not = null
				//cout << "M = " << m[0][i][0] << endl;
				free(m[0][i]);
				m[0][i] = NULL;
			}
		}
		free(*m);
		*m = NULL;
	}
	else{
		cout << "WARNING fun : safefree(T **m,int line) , error the variable is equal to NULL" << endl;
		cout << "It could be a good idea to depurate the code, Seed used = " << seedRand << endl;
		//exit(1);
	}
}//////////////////////////////////////////////////



// Free space for a matrix of 3 dimensions
template <class T>
void safefree(T ****m,int line, int col){
	 register int i,j;

	if(m != NULL && *m != NULL && **m != NULL){
		for(i=line -1; i>=0 ;i--){
			for(j=col-1; j>= 0; j--){
				if(m[0][i][j] != NULL){
					//cout << "M3 = " << m[0][i][j][0] << endl;
					free(m[0][i][j]);
					m[0][i][j] = NULL;
				}
			}
			free(m[0][i]);
			m[0][i] = NULL;
		}
	}
	else{
		cout << "WARNING fun : free(T **m,int line) , error the variable is equal to NULL" << endl;
		cout << "Seed used = " << seedRand << endl;
		exit(EXIT_FAILURE);
	}

    free(*m);
    *m = NULL;
}//////////////////////////////////////////////////



// Safty free for a vector
template <class T>
void safefree(T **pp)
{
    if ((pp != NULL) && (*pp != NULL))    // safety check
    {
    	//cout << "V = " << pp[0][0] << endl;
        free(*pp);    // deallocate chunk
        *pp = NULL;   // reset original pointer
    }
    else{
    	cout << "safefree(T **pp)" << endl;
    	cout << "Seed used = " << seedRand << endl;
    	exit(EXIT_FAILURE);
    }
}



#endif
