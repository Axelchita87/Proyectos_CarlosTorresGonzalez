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
	qsub scripts/r11.sh
	qsub scripts/r12.sh
	qsub scripts/r13.sh
	qsub scripts/r14.sh
	qsub scripts/r15.sh
	qsub scripts/r16.sh
	qsub scripts/r17.sh
	qsub scripts/r18.sh
	qsub scripts/r19.sh
	qsub scripts/r20.sh
	qsub scripts/r21.sh
	qsub scripts/r22.sh
	qsub scripts/r23.sh
	qsub scripts/r24.sh
	qsub scripts/r25.sh
	qsub scripts/r26.sh
	qsub scripts/r27.sh
	qsub scripts/r28.sh
	qsub scripts/r29.sh
	qsub scripts/r30.sh
else
    echo 'error compiling file'
fi
