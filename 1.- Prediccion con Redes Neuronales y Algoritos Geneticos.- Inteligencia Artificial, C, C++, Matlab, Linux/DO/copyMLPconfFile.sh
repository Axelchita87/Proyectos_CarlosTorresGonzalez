#!/bin/bash

# move one dir up, this is the base folder where the other folder exist to copy inside the file


# put '../' here in case it is needed, if the files to copy are outside (directly above) the destination, leave it empty 
isUp='../'


# copy the files to all with the same termination, 50 nodes 100 nodes , ...
for h in H50_MLP_37 H50_MLP_50 H50_MLP_62 H50_MLP_75 H50_MLP_87 H50_MLP_100  M50_MLP_25 M50_MLP_37 M50_MLP_50 M50_MLP_62 M50_MLP_75 M50_MLP_87 M50_MLP_100
do
	for f in MLPconf.hpp copyMLPconfFile.sh
	do
		cp -r $f "$isUp$isUp$h/class0021a/"
		#echo "cp" "-r" $f "$isUp$isUp$h/class0021a/"
	done
done

# copy the files to the repetitions
for h in H50_MLP_25 H50_MLP_37 H50_MLP_50 H50_MLP_62 H50_MLP_75 H50_MLP_87 H50_MLP_100  M50_MLP_25 M50_MLP_37 M50_MLP_50 M50_MLP_62 M50_MLP_75 M50_MLP_87 M50_MLP_100
do
	cd "$isUp$isUp$h/class0021a/"
	#pwd
	for f in  MLPconf.hpp copyMLPconfFile.sh
	do
		# directories to copy the files
		for g in class0031a class0033a class0034a
		do
			cp -r $f "$isUp$g/"
			#echo "cp" "-r" "-i" $f "$isUp$g/"
		done
	done
	
done


echo "Jod done :)"
