#!/bin/bash
if [ -e res ]
then
	cd "res"
	rm -f *.*
	cd ..
else
	mkdir res
fi

rm -f mainepnet

g++ mainepnet.cpp -O -lm -o mainepnet

if [ -e mainepnet ]
then
	qsub r1.sh
	qsub r2.sh
	qsub r3.sh
	qsub r4.sh
	qsub r5.sh
	qsub r6.sh
	qsub r7.sh
	qsub r8.sh
	qsub r9.sh
	qsub r10.sh
	qsub r11.sh
	qsub r12.sh
	qsub r13.sh
	qsub r14.sh
	qsub r15.sh
	qsub r16.sh
	qsub r17.sh
	qsub r18.sh
	qsub r19.sh
	qsub r20.sh
	qsub r21.sh
	qsub r22.sh
	qsub r23.sh
	qsub r24.sh
	qsub r25.sh
	qsub r26.sh
	qsub r27.sh
	qsub r28.sh
	qsub r29.sh
	qsub r30.sh
else
    echo 'error compiling file'
fi
