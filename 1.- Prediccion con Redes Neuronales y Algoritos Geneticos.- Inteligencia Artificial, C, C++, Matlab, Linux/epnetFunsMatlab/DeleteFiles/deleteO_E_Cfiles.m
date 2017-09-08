%delete files created by C - qsub e and o

% uncoment all this block if you want to run this file from its folder and
% not from the main experiment

% clear
% clc
% cd('..')
% cd('..')
% load TS.mat
% sizeTS = size(TS,2);

for i=1:sizeTS
    cd(TS{1,i});
    
    delete('*.e*')
    delete('*.o*')
    cd('..');
end

display('Deleted *.e and *.o files :)');