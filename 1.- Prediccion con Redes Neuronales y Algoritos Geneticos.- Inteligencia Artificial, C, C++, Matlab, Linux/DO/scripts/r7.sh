#!/bin/bash
#
#$ -cwd
#$ -j y
#$ -S /bin/bash
#
cd "$PBS_O_WORKDIR"
./mainepnet r7 7 > res/r7S.txt
