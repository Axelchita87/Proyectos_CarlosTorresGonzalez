/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   main.c
 * Author: CARLOS
 *
 * Created on 8 de marzo de 2017, 17:21
 */

#include <stdio.h>
#include <stdlib.h> 
#include <time.h>
#include <math.h>
#include <fcntl.h>

#define NUMPAT 4
#define NUMIN  2
#define NUMHID 20
#define NUMHID2 20
#define NUMOUT 1

#define rando() ((double)rand()/(RAND_MAX))

/*
 * 
 */
int main(int argc, char** argv) {

    int    i, j, jk, k, p, np, op, ranpat[NUMPAT+1], epoch;
    int    NumPattern = NUMPAT, NumInput = NUMIN, NumHidden = NUMHID, NumHidden2 = NUMHID2 /*CO2*/, NumOutput = NUMOUT;
    double Input[NUMPAT+1][NUMIN+1] = { 0, 0, 0,  0, 0, 0,  0, 1, 0,  0, 0, 1,  0, 1, 1 };
    double Target[NUMPAT+1][NUMOUT+1] = { 0, 0,  0, 0,  0, 1,  0, 1,  0, 0 };
    double SumH[NUMPAT+1][NUMHID+1], WeightIH[NUMIN+1][NUMHID+1], Hidden[NUMPAT+1][NUMHID+1];
    double SumH2[NUMPAT+1][NUMHID2+1], WeightHH2[NUMHID+1][NUMHID2+1], Hidden2[NUMPAT+1][NUMHID2+1];   //DECLARACION DE ARREGLOS CO2
 // double SumO[NUMPAT+1][NUMOUT+1], WeightHO[NUMHID+1][NUMOUT+1], Output[NUMPAT+1][NUMOUT+1];
    double SumO[NUMPAT+1][NUMOUT+1], WeightH2O[NUMHID2+1][NUMOUT+1], Output[NUMPAT+1][NUMOUT+1];
    double SumDOW[NUMHID+1], DeltaH[NUMHID+1]; //Lo de HID
    double DeltaO[NUMOUT+1], SumDOW2[NUMHID2+1], DeltaH2[NUMHID2+1];  //se puso HID2 CO2
    double DeltaWeightIH[NUMIN+1][NUMHID+1], DeltaWeightHH2[NUMHID+1][NUMHID2+1], DeltaWeightH2O[NUMHID2+1][NUMOUT+1];
    double Error, eta = 0.5, alpha = 0.9, smallwt = 0.5;
  
    for( j = 1 ; j <= NumHidden ; j++ ) {    /* initialize WeightIH and DeltaWeightIH */
        for( i = 0 ; i <= NumInput ; i++ ) { 
            DeltaWeightIH[i][j] = 0.0 ;
            WeightIH[i][j] = (double)(2.0 * ( rando() - 0.5 ) * smallwt) ;
        }
    }
    for( jk = 1 ; jk <= NumHidden2 ; jk ++ ) {    /* initialize WeightHH2 and DeltaWeightHH2 */
        for( j = 0 ; j <= NumHidden ; j++ ) {
            DeltaWeightHH2[j][jk] = 0.0 ;              
            WeightHH2[j][jk] = 2.0 * ( rando() - 0.5 ) * smallwt ;
        }
    }
    for( k = 1 ; k <= NumOutput ; k ++ ) {    /* initialize WeightH2O and DeltaWeightH2O */
        for( jk = 0 ; jk <= NumHidden2 ; jk++ ) {
            DeltaWeightH2O[jk][k] = 0.0 ;              
            WeightH2O[jk][k] = 2.0 * ( rando() - 0.5 ) * smallwt ;
        }
    }
     
    for( epoch = 0 ; epoch < 100000 ; epoch++) {    /* iterate weight updates */
        for( p = 1 ; p <= NumPattern ; p++ ) {    /* randomize order of individuals */
            ranpat[p] = p ;
        }
        for( p = 1 ; p <= NumPattern ; p++) {
            np = p + rando() * ( NumPattern + 1 - p ) ;
            op = ranpat[p] ; ranpat[p] = ranpat[np] ; ranpat[np] = op ;
        }
        Error = 0.0 ;
        for( np = 1 ; np <= NumPattern ; np++ ) {    /* repeat for all the training patterns */
            p = ranpat[np];   
            for( j = 1 ; j <= NumHidden ; j++ ) {    /* compute hidden unit activations */
                SumH[p][j] = WeightIH[0][j] ;         /*Hidden Unit 1*/
                for( i = 1 ; i <= NumInput ; i++ ) {
                    SumH[p][j] += Input[p][i] * WeightIH[i][j] ;
                }
                Hidden[p][j] = 1.0/(1.0 + exp(-SumH[p][j])) ;
            }
            for( jk = 1 ; jk <= NumHidden2 ; jk++ ) {    /* compute hidden unit activations */
                SumH2[p][jk] = WeightHH2[0][jk] ;        /* Hidden Unit 2*/
                for( j = 1 ; j <= NumHidden ; j++ ) {
                    SumH2[p][jk] += Hidden[p][j] * WeightHH2[j][jk] ;
                }
                Hidden2[p][jk] = 1.0/(1.0 + exp(-SumH2[p][jk])) ;
            }
            for( k = 1 ; k <= NumOutput ; k++ ) {    /* compute output unit activations and errors */
                SumO[p][k] = WeightH2O[0][k] ;
                for( jk = 1 ; jk <= NumHidden2 ; jk++ ) {
                    SumO[p][k] += Hidden2[p][jk] * WeightH2O[jk][k] ;
                }
                Output[p][k] = 1.0/(1.0 + exp(-SumO[p][k])) ;   /* Sigmoidal Outputs */
/*              Output[p][k] = SumO[p][k];      Linear Outputs */
                Error += 0.5 * (Target[p][k] - Output[p][k]) * (Target[p][k] - Output[p][k]) ;   /* SSE */
/*              Error -= ( Target[p][k] * log( Output[p][k] ) + ( 1.0 - Target[p][k] ) * log( 1.0 - Output[p][k] ) ) ;    Cross-Entropy Error */
                DeltaO[k] = (Target[p][k] - Output[p][k]) * Output[p][k] * (1.0 - Output[p][k]) ;   /* Sigmoidal Outputs, SSE */
/*              DeltaO[k] = Target[p][k] - Output[p][k];     Sigmoidal Outputs, Cross-Entropy Error */
/*              DeltaO[k] = Target[p][k] - Output[p][k];     Linear Outputs, SSE */
            }
            for( jk = 1 ; jk <= NumHidden2 ; jk++ ) {    /* 'back-propagate' errors to hidden layer */
                SumDOW2[jk] = 0.0 ;                       /*to Hidden 2*/
                for( k = 1 ; k <= NumOutput ; k++ ) {
                    SumDOW2[jk] += WeightH2O[jk][k] * DeltaO[k] ;
                }
                DeltaH2[jk] = SumDOW2[jk] * Hidden2[p][jk] * (1.0 - Hidden2[p][jk]) ;
            }
            for( j = 1 ; j <= NumHidden ; j++ ) {    /* 'back-propagate' errors to hidden layer */
                SumDOW[j] = 0.0 ;
                for( jk = 1 ; jk <= NumHidden2 ; jk++ ) {        
                    SumDOW[j] += WeightHH2[j][jk] * DeltaH2[jk] ;
                }
                DeltaH[j] = SumDOW[j] * Hidden[p][j] * (1.0 - Hidden[p][j]) ;
            }
            for( j = 1 ; j <= NumHidden ; j++ ) {     /* update weights WeightIH */
                DeltaWeightIH[0][j] = eta * DeltaH[j] + alpha * DeltaWeightIH[0][j] ;
                WeightIH[0][j] += DeltaWeightIH[0][j] ;
                for( i = 1 ; i <= NumInput ; i++ ) { 
                    DeltaWeightIH[i][j] = eta * Input[p][i] * DeltaH[j] + alpha * DeltaWeightIH[i][j];
                    WeightIH[i][j] += DeltaWeightIH[i][j] ;
                }
            }
            for( jk = 1 ; jk <= NumHidden2 ; jk++ ) {     /* update weights WeightHH2 */
                DeltaWeightHH2[0][jk] = eta * DeltaH2[jk] + alpha * DeltaWeightHH2[0][jk] ;
                WeightHH2[0][jk] += DeltaWeightHH2[0][jk] ;
                for( j = 1 ; j <= NumHidden ; j++ ) { 
                    DeltaWeightHH2[j][jk] = eta * Hidden[p][j] * DeltaH2[jk] + alpha * DeltaWeightHH2[j][jk];
                    WeightHH2[j][jk] += DeltaWeightHH2[j][jk] ;
                }
            }
            for( k = 1 ; k <= NumOutput ; k ++ ) {    /* update weights WeightH2O */
                DeltaWeightH2O[0][k] = eta * DeltaO[k] + alpha * DeltaWeightH2O[0][k] ;
                WeightH2O[0][k] += DeltaWeightH2O[0][k] ;
                for( jk = 1 ; jk <= NumHidden2 ; jk++ ) {
                    DeltaWeightH2O[jk][k] = eta * Hidden2[p][jk] * DeltaO[k] + alpha * DeltaWeightH2O[jk][k] ;
                    WeightH2O[jk][k] += DeltaWeightH2O[jk][k] ;
                }
            }
        }
        if( epoch%100 == 0 ) fprintf(stdout, "\nEpoch %-5d :   Error = %f", epoch, Error) ;
        if( Error < 0.00004 ) break ;  /* stop learning when 'near enough' */
    }
    
    fprintf(stdout, "\n\nNETWORK DATA - EPOCH %d\n\nPat\t", epoch) ;   /* print network outputs */
    for( i = 1 ; i <= NumInput ; i++ ) {
        fprintf(stdout, "Input%-4d\t", i) ;
    }
    for( k = 1 ; k <= NumOutput ; k++ ) {
        fprintf(stdout, "Target%-4d\tOutput%-4d\t", k, k) ;
    }
    for( p = 1 ; p <= NumPattern ; p++ ) {        
    fprintf(stdout, "\n%d\t", p) ;
        for( i = 1 ; i <= NumInput ; i++ ) {
            fprintf(stdout, "%f\t", Input[p][i]) ;
        }
        for( k = 1 ; k <= NumOutput ; k++ ) {
            fprintf(stdout, "%f\t%f\t", Target[p][k], Output[p][k]) ;
        }
    }
    fprintf(stdout, "\n\nGoodbye!\n\n") ;
    return 1 ;
}

