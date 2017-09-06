#!/bin/csh

# shows the directory
echo $PWD


if ( -e res )  then
	cd "res"
	
	foreach i (r1ALLNum.txt r2ALLNum.txt r3ALLNum.txt r4ALLNum.txt r5ALLNum.txt r6ALLNum.txt r7ALLNum.txt r8ALLNum.txt r9ALLNum.txt r10ALLNum.txt )
	
    		if !( -e $i ) then
    			echo 'Not finished' $i
    		endif 
    
	end
	
	
	cd ..
else
	echo 'the directori res does not exist'
endif

