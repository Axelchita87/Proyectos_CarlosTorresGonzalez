#!/bin/bash

# move one dir up, this is the base folder where the other folder exist to copy inside the file


# put '../' here in case it is needed, if the files to copy are outside (directly above) the destination, leave it empty 
isUp='../'


# copy the files to all with the same termination, 25 37 50, ... in the fisrst folder
for h in pLoxA pLoxBmspA pLoxBmspB pLoxBsspB pMG17A6 pMG17A84 pMG17Aa pMG30A
do
	for f in mainepnet.hpp mainepnet.cpp
	do
		cp -r $f "$isUp$h/"
		#echo "cp" "-r" $f "$isUp$h/"
	done
done




echo "Jod done :)"
