/*!
 * C_ps.hpp
 * Created: 			6 Dec 2009
 * Modified at: 	27 Sep 2010
 * Author: 			Carlos Torres and Victor Landassuri
 *
 * Class ps, contain information for the normalization and denormalization of the data set
 */

#ifndef C_PS_HPP
#define C_PS_HPP



//Constructor C_ps
C_ps::C_ps(){
    //Put them into the correct size
	// xrows = (int *) malloc(sizeof(int));
	//I can not allocate memory here because I do not know the lines that the data to normalize will have
	// I allocate the space in C_sets::normalize(double **m,int line, int col,double **pn,C_ps *ps)
	xmax = NULL;
	xmin = NULL;
	xrange = NULL;
    // yrows = (int *) malloc(sizeof(int));
    // ymax = (double *) malloc(sizeof(double));
    // ymin = (double *) malloc(sizeof(double));
    // yrange = (double *) malloc(sizeof(double));
}

C_ps::~C_ps(){
	//safefree(&yrange); 	//[1] <- 2
	//safefree(&ymin);   	//[1] <- -1
	//safefree(&ymax);   	//[1] <- 1
	//safefree(&yrows);    //[1]
	safefree(&xrange);
	safefree(&xmin);
	safefree(&xmax);
	//safefree(&xrows);     //[1]

}
// Print the Class into the screen
void C_ps::print(int line){
	cout << "ps" << endl;
	cout << "xrows  = " << xrows << endl;
	cout << "xmax = " << endl;
	imprime(xmax, line); cout << endl;
	cout << "xmin = " << endl; imprime(xmin, line); cout << endl;
	cout << "xmax = " << endl; imprime(xmax, line); cout << endl;
	cout << "xrange = " << endl; imprime(xrange, line); cout << endl;
	cout << "yrows  = " << yrows << endl;
	cout << "ymax  = " << ymax << endl;
	cout << "ymin  = " << ymin << endl;
	cout << "yrange  = " << yrange << endl;

}

//save the structure str_ps to a file
void C_ps::save2file(FILE *fwrite, char file[], int line)
{
    //xrows
    fprintf(fwrite, "%d\t",xrows);
    //xmax
    saveD(xmax, line, fwrite, file);
    //xmin
    saveD(xmin, line, fwrite, file);
    //xrange
    saveD(xrange, line, fwrite, file);
    //yrows
    fprintf(fwrite, "%d\t",yrows);
    //ymax
    fprintf(fwrite, "%f\t",ymax);
    //ymin
    fprintf(fwrite, "%f\t",ymin);
    //yrange
    fprintf(fwrite, "%f\t",yrange);
}//////////////////////////////////////////////////////////////////////////



/*!
 * Function to normalize and denormalize
 * They do not belong to the class ps, but they are settle here to be easy find them as a rezon that they work with this structure
 */



// Denormilze
void nor_reverse(double **pn, double **p, C_ps *ps,int line, int col)
{
	register int i,j;
	//cout << "C_sets::nor_reverse.......ps->xrows = " << ps->xrows[0] << endl;
	for(i=0; i<line; i++)
    {
        for(j=0; j<col; j++)
        {
            p[i][j] = ((ps->xrange[i]*( pn[i][j]-ps->ymin ))/ps->yrange)+ps->xmin[i];
            //printf("pn[%d][%d] = %f\n",i,j,pn[i][j]);
        }
    }
}//////////////////////////////////////////////////////////////////////////



void nor_apply(double **m, double **pn, C_ps *ps,int line, int col){
	/*!
	 * Apply the nomalization, normalize m and save the result in pn
	 * 		Input:
	 * 		**m 			Input matrix to normalize
	 * 		**pn 		matrix to save the normalized result
	 * 		*ps 			structure ps that contain the range to normalize
	 * 		line 			lines in the matrices
	 * 		col 			columns
	 * Output:
	 * 		**pn 		saved normalized results, it was passes as pointer, thus the result is atumatically returned
	 */

    register int i,j;

    //printf("ps->xrows = %d\n",ps->xrows[0]);
    for(i=0; i<line; i++)
    {
        for(j=0; j<col; j++)
        {
            if(ps->xrange[i]!=0)
            {
                pn[i][j] = ((ps->yrange*(m[i][j]-ps->xmin[i]))/ps->xrange[i])+ps->ymin;
                //printf("pn[%d][%d] = %f\n",i,j,pn[i][j]);
            }
            else
                printf("Error division by cero, nor_apply func ...");
        }
    }
}//////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////



//
void normalize(double **m,int line, int col,double **pn,C_ps *ps)
{
	/*!
	 * Function to normalize the first time, allocate memory for ps
	 * This funtion saves some parameters that allow the normalization/denoprmalization of vector/matrices after the first one has been ejecuted
	 * This funtion it is teh same as the matlab one mapmimax, so for copiright issues I am given credit to matlab for the creation of this funtion, here I implemented it for C/C++
	 *
	 * Input:
	 * 	**m 			normal vector/matrix to normalize (note that by construction it is allocated one matrix, i.e., double pointer **)
	 * line 			lines in m
	 * col 			cols in m
	 * pn 			Matrix already allocated, here is saved the normalized result
	 * ps 			strucure ps, here is allocated the remainig vector to save the parameters of the normalization
	 *
	 * Outputs:
	 * pn 			its a pointer so it is returned automatically
	 */

    register int i;

    // Allocate space for the rest of the variables
    ps->xmax = allocate(ps->xmax, line);
    ps->xmin = allocate(ps->xmin, line);
    ps->xrange = allocate(ps->xrange, line);
    ///////////////////////////////////////////////

    //initialize them with the correct value
    ps->ymax = YMAX;
    ps->ymin = YMIN;
    ps->yrange = YMAX-YMIN;
    ps->xrows = line;
    ps->yrows = line;


    //look for the maximum and minimum in every row of the matrix
    //they return a vector depending of the size of the data, target or data input
    // In the old code I did not use the next two line with the next for, because I did that at the beginning of prepo data, here I will use it
    ps->xmax = maxRow(m,line,col);
    ps->xmin = minRow(m,line,col); //original function

    //here it is going to replace  the original functions //////////////
    //normilize_max and min are global variables, set up in C_sets::prepo
    /*
     for(i=0; i<line; i++){
        ps->xmax[i] = normilize_max[0]; //only works for 1
        ps->xmin[i] = normilize_min[0];
    }//////////////////////////////////////////////////////////////////////
    */


    for(i=0; i<line; i++)
    {
        ps->xrange[i] = ps->xmax[i] - ps->xmin[i];
        if(ps->xrange[i] == 0)
            fprintf(stderr,"Warning normilizing, xmax = xmin (the same value in all the vector)");
    }

    //printf("ps->yrange[0] =%f\n",ps->yrange[0]);
    nor_apply(m,pn,ps,line,col);


}//////////////////////////////////////////////////////////////////////////


#endif
