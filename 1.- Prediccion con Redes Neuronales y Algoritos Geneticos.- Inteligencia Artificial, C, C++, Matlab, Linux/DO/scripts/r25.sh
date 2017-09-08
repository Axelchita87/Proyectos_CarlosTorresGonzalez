#!/bin/bash
#
#$ -cwd
#$ -j y
#$ -S /bin/bash
#
cd "$PBS_O_WORKDIR"
./mainepnet r25 25 > res/r25S.txt
