/*!
 * definition.hpp
 * All the funtions used in the program
 *  Created on: 22 Nov 2009
 *      Author: victor
 */
#ifndef EXEPTIONFUN_HPP
#define EXEPTIONFUN_HPP

void processException()
{
    try {
    	std::cout << "Seed used = " << seedRand << std::endl;
        throw;    // rethrow the exception again so that it
                  // can be handled here
    }
    catch (const std::bad_alloc& e) {
        // special exception: no more memory
        std::cerr << "no more memory" << std::endl;
    }
    catch (const std::exception& e) {
        // other standard exception
        std::cerr << "standard exception: " << e.what() << std::endl;
    }
    catch (...) {
        // all other exceptions
        std::cerr << "other exception" << std::endl;
    }
}


void processException(const int &e)
{

    try {
    	cerr << "Seed used = " << seedRand << endl;
        throw;    // rethrow the exception again so that it
                  // can be handled here
    }
    catch (const int &e) {
        // special exception
        cerr << "Something is not correct, code : " << e << endl;
        switch(e){
        case 1:
        	cerr << "Warning at copyAlloc m is not null before copy, exit : copyAlloc(T **m,T **n,int line,int col)" << endl;
        	break;
        case 2:
        	cerr << "Warning at copyAlloc m is not null before copy, exit : copyAlloc(T *m,T *n,int line)" << endl;
        	break;
        case 3:
        	cerr << "WARNING fun : allocate(T **m,int line,int col) , error the variable is not equal to NULL"<< endl;
        	break;
        case 4:
        	cerr << "WARNING fun : allocate(T *m, int tam) , error the variable is not equal to NULL"<< endl;
        	break;
        case 5:
        	cerr << "WARNING fun : allocate(T ***m3,int D3,int line,int col) , error the variable is not equal to NULL"<< endl;
        	break;
        case 6:
        	cerr << "Both neworks are not equal: copyNet method"<< endl;
        	break;
        default:
        	cerr << "Invalid erro code for a function, check, exit" << endl;

        }

        exit(EXIT_FAILURE);
    }
}



#endif
