#!/bin/bash
#
#$ -cwd
#$ -j y
#$ -S /bin/bash
#
cd "$PBS_O_WORKDIR"
./mainepnet r9 9 > res/r9S.txt
