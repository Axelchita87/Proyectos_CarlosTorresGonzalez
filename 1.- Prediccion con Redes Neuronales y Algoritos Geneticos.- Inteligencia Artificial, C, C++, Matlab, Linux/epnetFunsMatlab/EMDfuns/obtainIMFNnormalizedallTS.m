% obtainIMFNnormalizedallTS.m
% This script will be used to load the data, normalize it and then
% calculate the IMFs. 
%Created: 11/02/10


% The output will be separated in different folders and the predicted with
% the EPNet64 separately

%% the first part is to normalize, then IMF
% clear
% clc
% 
% load datainput.txt
% 
% data = datainput(1:2000,:)';
% [datan,ps] = mapminmax1(data);
% 
% IMFn = emd(datan');
% 
% %save at hand each IMf in each directory
% file = [];
% file = IMFn(7,:); 
% save ('dataInputN.txt', 'file', '-ascii', '-tabs');


%% This part it to obtain IMFs then normalize
% clear
% clc
% 
% load datainput.txt     %data no normalized
% 
% data = datainput(1:2000,:)';
% IMF = emd(data');
% 
% for i=1:size(IMF,1)
%     [IMFn(i,:), PSDinN] = mapminmax1(IMF(i,:));
% end
% 
% 
% 
% 
% 
% %save at hand each IMf in each directory
% file = [];
% file = IMFn(7,:); 
% save ('dataInputN.txt', 'file', '-ascii', '-tabs');


%% Run the file from the path of this file 
% In this seccion is the complete code that allows calculet all IMF for all
% TS


clear
clc

%% ...........Parameters to set up at hand .................%
baseDir{1,1} = 'TSEPnet63v1';      %(A)

%range to normalize
rmin = -0.7;
rmax = 0.7;

%How many TS to analyse 1:30
TS2analyse = 20;        %20 is Births in Quebec

%max data to calculate the IMFs
maxdata = 2000;
%steps to predict
predhoriz = 30;    %so I will create 2 sets to obtain the imf, one of size
                    %maxdata - predhoriz*2 (set inside) and
                    %maxdata - predhoriz (set out side epnet)
                    
NoIMFs = '50up';     % could be 'all' or '50up' or '50down'

%.......Finish parameters to set up at hand ..............%

%% Section to determinate with OS is running 
cd('..');  cd('LinuxOrWindows')
%use adecuate paht
slash2use = isLinOrWin();
cd('..');
cd('Normalize');
path1 = pwd;
addpath(path1);

cd('..'); cd('..');

baseDir{1,2} = pwd;         %main dir for all exps
cd(baseDir{1,1});

load TSv1.mat;

%% Start to do the purpose of the file

for i=1:TS2analyse      %to enter in each TS
    cd(TS{1,i});
    
    %clear variables
    datainput = [];
    dataInputN = [];
    inSetN = [];
    outSetN = [];
    Cmin = 0;
    Ipos = 0;
    IMFcol = zeros(1,2);
   
    cd('txtFiles')
    load datainput.txt      %I am assuming that the input is a column vector
    
    %limit to the maximum data that the epnet will use
    if (size(datainput,1) > maxdata)
        datainput = datainput(1:maxdata,:);
    end
    
    %Normalize the data
    dataInputN = mapminmax1(datainput', rmin, rmax);
    dataInputN = dataInputN';
    
    %Create both sets (inside and outside)
    inSetN = dataInputN(1:size(dataInputN,1) -(predhoriz*2),:);
    outSetN = dataInputN(1:size(dataInputN,1)-predhoriz,:);
          
    %Obtain IMFs from the normalized data
    inIMFn = emd(inSetN);
    outIMFn = emd(outSetN);
    
    % Determinate how many and which IMF will be used
    
    if (strcmp(NoIMFs,'all'))
%         %If there are more IMFs in one or in other, calculate the energy and
%         %then left them of the same size
%         
%         %only to test
%         outSetN(:,4) = ones(size(outSetN,1),1);
%         cols(1,2) = size(outSetN,2);
%         %delet before here
%         
%         if( cols(1,1) ~= cols(1,2) )
%             cont = 1;
%             for j=2:cols(1,1)
%                 Ein(cont,1) = sum((inSetN(:,j)).^2);
%                 cont = cont + 1;
%             end
%             % for the second
%             cont = 1;
%             for j=2:cols(1,2)
%                 Eout(cont,1) = sum((outSetN(:,j)).^2);
%                 cont = cont + 1;
%             end
%         end

    elseif (strcmp(NoIMFs,'50up'))
        
        % How many IMF there are in both sets
        IMFcol(1,1) = size(inIMFn,1);
        IMFcol(1,2) = size(outIMFn,1);
        
        %if two sets are equal, do nothing and take the 50%, othercase take
        %the 50% of the smallest set.
        if(IMFcol(1,1) == IMFcol(1,2))
            IMF2take = int8(IMFcol(1,1) * 0.5);
        else
            [Cmin,Ipos] = min(IMFcol);
            IMF2take = int8(IMFcol(1,Ipos) * 0.5);
        end
        
        % Take the 50up%
         %accomodate all in a variable to save all this all in a file
        inSetN(:,2:IMF2take+1) = inIMFn(1:IMF2take,:)';
        outSetN(:,2:IMF2take+1) = outIMFn(1:IMF2take,:)';
        
    elseif (strcmp(NoIMFs,'50down'))
    
    end
    
    
    
    
    %obtain how many colums the file has
    cols(1,1) = size(inSetN,2);
    cols(1,2) = size(outSetN,2);
    
        
    
    %now save the files to be read by the epnet
    save ('dataInputN.txt', 'dataInputN', '-ascii', '-tabs');
    save ('dInputIMFinN.txt', 'inSetN', '-ascii', '-tabs');
    save ('dInputIMFoutN.txt', 'outSetN', '-ascii', '-tabs');
    save ('columnsIMFN.txt', 'cols', '-ascii', '-tabs');
    cd('..')      %exit txtFiles
    cd('..')    %exit TS dir
end



