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

g++ mainepnet.cpp -O -lm -o mainepnet

if [ -e mainepnet ]
then
	./mainepnet r1 
	
else
    echo 'error compiling file'
fi
