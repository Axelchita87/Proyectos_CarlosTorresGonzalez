%obtainIMFallTS.m
%7/02/10
%Carlos Torres and Victor Landassuri

%Information:
%This script works witht eh TSv1.m file in main dir of all TS.
% Run the file from the path of this file

%Here is obtain all IMFs of each TS, and put them in a same file and save
%all in the TS Directory

%This file can be run with different configurations
%to obtain experiments:
% 63v1a using all TS
% 63v1b 50%up
% 63v1c 50%down of the IMFs


clear
clc

%% ...........Parameters to set up at hand .................%
baseDir{1,1} = 'TSEPnet63v1';      %(A)

%How many TS to analyse 1:30
TS2analyse = 30;

%max data to calculate the IMFs
maxdata = 2000;
%steps to predict
predhoriz = 30;    %so I will create 2 sets to obtain the imf, one of size
                    %maxdata - predhoriz*2 (set inside) and
                    %maxdata - predhoriz (set out side epnet)
                    
NoIMFs = 'all';     % could be 'all' or '50up' or '50down'

%.......Finish parameters to set up at hand ..............%

%Section to determinate with OS is running 
cd('..');  cd('LinuxOrWindows')
%use adecuate paht
slash2use = isLinOrWin();
cd('..');  cd('..');

baseDir{1,2} = pwd;         %main dir for all exps
cd(baseDir{1,1});

load TSv1.mat;

%% Start to do the purpose of the file

for i=1:TS2analyse      %to enter in each TS
    cd(TS{1,i});
    
    %clear variables
    inIMF = [];
    outIMF = [];
    datainput = [];
    inSet = [];
    outSet = [];
    
    load txtFiles/datainput.txt      %I am assuming that the input is a column vector
    
    %limit to the maximum data that the epnet will use
    if (size(datainput,1) > maxdata)
        datainput = datainput(1:maxdata,:);
    end
    
    %Create both sets (inside and outside)
    inSet = datainput(1:size(datainput,1) -(predhoriz*2),:);
    outSet = datainput(1:size(datainput,1)-predhoriz,:);
       
    inIMF = emd(inSet);
    outIMF = emd(outSet);
    
    %accomodate all in a variable to save all this all in a file
    inSet(:,2:size(inIMF,1)+1) = inIMF';
    outSet(:,2:size(outIMF,1)+1) = outIMF';
    
    %obtain how many colums the file has
    columns(1,1) = size(inSet,2);
    columns(1,2) = size(outSet,2);
    
    %determinate the number of IMF to take
%     if (IMF == 'all')
%         if(columns(1,1) ~= columns(1,2))
%             %delete the fisrt IMF of the biger until they are of the same
%             %size
%             [C, I] = max(columns);  %index I form the bigger
%             
%     elseif (IMF == '50up')
%     elseif (IMF == '50down')
%     
%     
    
    %now save the files to be read by the epnet
    save ('txtFiles/dInputIMFin.txt', 'inSet', '-ascii', '-tabs');
    save ('txtFiles/dInputIMFout.txt', 'outSet', '-ascii', '-tabs');
    save ('txtFiles/columnsIMF.txt', 'columns', '-ascii', '-tabs');
    
    cd('..')    %exit TS dir
end

