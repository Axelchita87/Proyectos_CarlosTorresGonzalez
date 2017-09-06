#!/bin/csh

# shows the directory
echo $PWD


if ( -e res )  then
	cd "res"
	
	foreach i (r1ALLNum.txt r2ALLNum.txt r3ALLNum.txt r4ALLNum.txt r5ALLNum.txt r6ALLNum.txt r7ALLNum.txt r8ALLNum.txt r9ALLNum.txt r10ALLNum.txt r11ALLNum.txt r12ALLNum.txt r13ALLNum.txt r14ALLNum.txt r15ALLNum.txt r16ALLNum.txt r17ALLNum.txt r18ALLNum.txt r19ALLNum.txt r20ALLNum.txt r21ALLNum.txt r22ALLNum.txt r23ALLNum.txt r24ALLNum.txt r25ALLNum.txt r26ALLNum.txt r27ALLNum.txt r28ALLNum.txt r29ALLNum.txt  r30ALLNum.txt)
	
    		if !( -e $i ) then
    			echo 'Not finished' $i
    		endif 
    
	end
	
	
	cd ..
else
	echo 'the directori res does not exist'
endif

