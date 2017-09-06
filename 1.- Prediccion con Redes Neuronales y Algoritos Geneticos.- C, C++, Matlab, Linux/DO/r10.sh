#!/bin/bash
pwd

if [ -e res ]
then
	cd "res"
	rm -f *.*
	cd ..
else
	mkdir res
fi

if [ -e resPop ]
then
	echo "resPop Exist :)"
else
	mkdir resPop
fi


rm -f mainepnet
rm -f *.sh.o*
rm -f *.sh.e*

g++ mainepnet.cpp -O -lm -o mainepnet

if [ -e mainepnet ]
then
	qsub scripts/r1.sh
	qsub scripts/r2.sh
	qsub scripts/r3.sh
	qsub scripts/r4.sh
	qsub scripts/r5.sh
	qsub scripts/r6.sh
	qsub scripts/r7.sh
	qsub scripts/r8.sh
	qsub scripts/r9.sh
	qsub scripts/r10.sh
else
    echo 'error compiling file'
fi