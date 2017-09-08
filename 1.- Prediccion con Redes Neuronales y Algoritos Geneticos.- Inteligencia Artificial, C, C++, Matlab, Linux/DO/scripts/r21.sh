#!/bin/bash
#
#$ -cwd
#$ -j y
#$ -S /bin/bash
#
cd "$PBS_O_WORKDIR"
./mainepnet r21 21 > res/r21S.txt
