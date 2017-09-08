#!/bin/bash
#
#$ -cwd
#$ -j y
#$ -S /bin/bash
#
cd "$PBS_O_WORKDIR"
./mainepnet r8 8 > res/r8S.txt
