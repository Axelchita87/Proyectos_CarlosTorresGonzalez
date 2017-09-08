%% Change outputs tranges
% Script to change the values of the output
%%

% run addpath( pwd ) in this dir

clear
clc

% load data set
datainput = load('dataInputN0024.txt');
fileName2savfe = 'dataInputN0024_0.1to0.9.txt';

output = load('outputsInMod.txt');

sizeDat = size(datainput);
sizeOut = size(output,2);

for i=1:sizeDat(1,1)        
    for j = ( sizeDat(1,2) - sizeOut +1): sizeDat(1,2)
        if datainput(i,j) == 0
            datainput(i,j) = 0.1;
        else
            datainput(i,j) = 0.9;
        end
    end
end


%cd('txtFiles')
save (fileName2savfe, 'datainput', '-ascii', '-tabs');