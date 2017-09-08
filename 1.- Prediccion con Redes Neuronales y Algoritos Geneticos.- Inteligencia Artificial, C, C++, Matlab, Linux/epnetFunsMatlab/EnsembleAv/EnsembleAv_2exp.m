%Scriot to check the t-test between to experiments, e.g. 15c and 20C
%this part is for the mean values of the NRMSE with the average method

%Each row has the values per run for each directory/experiment

clear
clc
corrida = 30;
populationNum = 10;     %[2 3 4 5 10 15 20];

%parameter for the t-test
alpha = 0.05;           %significance
tail='both';
type='unequal';

%directories to comapre
dir1 = 'D:\DoctoradoResultados\TSEPnet15C';
dir2 = 'D:\DoctoradoResultados\TSEPnet20C';

TS{1,1} = 'ChaosHenon';
TS{1,2} = 'ChaosIkeda';
TS{1,3} = 'ChaosLogistic';
TS{1,4} = 'ChaosLorenz';
TS{1,5} = 'ChaosMackey';
TS{1,6} = 'ChaosQp2';
TS{1,7} = 'ChaosQp3';
TS{1,8} = 'ChaosRossler';
TS{1,9} = 'DemBirhtsQuebec';
TS{1,10} = 'FinDowJones';
TS{1,11} = 'MicroGoldprices';
TS{1,12} = 'FinIBMstock';
TS{1,13} = 'FinSP500';
TS{1,14} = 'HydroColorado';
TS{1,15} = 'HydroEriel';
TS{1,16} = 'PhyEquipTemp';
TS{1,17} = 'PhyKobe';
TS{1,18} = 'PhyStar';
TS{1,19} = 'PhySunspot';
TS{1,20} = 'SantaFeD1';
TS{1,21} = 'SantaFeLaser';

%exit the actual directory of the function
cd('..');               %exit ttest_fun_scirp

%Add path to have the functions of matlab for ensemble
cd('Error');
pathFun_matlab = pwd;
addpath(pathFun_matlab);
cd('..')
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

cd('..');               %exit FunsMatlab

%enter first dir
cd(dir1);

%extract values for the first dir
for i=1:21
    cd(TS{1,i});
    
    %code to extract the values of each TS
    cd('res');
    load allrun.mat
    
    %calculate the mean of toPredicfinal
    toPredictF = allrun{1,1}.sets.toPredictF; 
    Mean_toPredictF = mean(toPredictF);
    
    %this part is for the NRMSE, omit or delet if it is not needed
    for j=1:corrida
       NRMSEperRun{1,i}(1,j) = allrun{1,j}.Network{1,1}.iterateNRMSE_F;  
    end

    
    for j=1:corrida
        %Allocate space for each var, AV, RBLC, ...
        allrun{j}.ensemble_subset = init_ensemble(allrun{1,1}.var,populationNum);
        
        %now calculate the ensemble with the given number of individulas in
        %the populaiton
        for k=1:populationNum
            allrun{j}.ensemble_subset.Average.Pred = allrun{j}.ensemble_subset.Average.Pred + allrun{1,j}.Network{1,k}.iteratePredF;
        end
        allrun{j}.ensemble_subset.Average.Pred = allrun{j}.ensemble_subset.Average.Pred / populationNum;
               
        
        %Calculate NRMS error   **** NRMS2 is a bad function, deleted, only
        %to test the reuslt agians 15C
        allrun{j}.ensemble_subset.Average.NRMSE = F_NRMSE(allrun{j}.ensemble_subset.Average.Pred, ...
            toPredictF, Mean_toPredictF);
    end

    %save values
    
    Etestset = zeros(1,corrida);
    maximo=[];
    minimo=[];
    posMax=[];
    posMin=[];
    temp=[];
    
    % load (nrms inside, final, accuracy and ,more)
        
    for j=1:corrida
        Etestset(1,j) = allrun{1,j}.ensemble_subset.Average.NRMSE;
    end
    temp=[];
    [minimo, posMin] = min(Etestset);
    [maximo, posMax] = max(Etestset);
    
        
    table(i,12) = mean(Etestset);
    table(i,13) = std(Etestset);
    table(i,14) = minimo;
    table(i,15) = maximo;
    table(i,16) = posMin;
    table(i,17) = 0;     %space to not get confuse
  
    EensembleAve{1,i}(1,:) = Etestset;
    
        
    cd('../');          %exit res
    cd('../');          %exit TS
    clear allrun toPredictF Mean_toPredictF
end

cd('../');          %exit dir1

%enter second dir
cd(dir2);

%extract values for the first dir
for i=1:21
    cd(TS{1,i});
    
    %code to extract the values of each TS
    cd('res');
    load allrun.mat
    
    %calculate the mean of toPredicfinal
    toPredictF = allrun{1,1}.sets.toPredictF; 
    Mean_toPredictF = mean(toPredictF);
    
    %this part is for the NRMSE, omit or delet if it is not needed
    for j=1:corrida
       NRMSEperRun{1,i}(2,j) = allrun{1,j}.Network{1,1}.iterateNRMSE_F;  
    end

    
    for j=1:corrida
        %Allocate space for each var, AV, RBLC, ...
        allrun{j}.ensemble_subset = init_ensemble(allrun{1,1}.var,populationNum);
        
        %now calculate the ensemble with the given number of individulas in
        %the populaiton
        for k=1:populationNum
            allrun{j}.ensemble_subset.Average.Pred = allrun{j}.ensemble_subset.Average.Pred + allrun{1,j}.Network{1,k}.iteratePredF;
        end
        allrun{j}.ensemble_subset.Average.Pred = allrun{j}.ensemble_subset.Average.Pred / populationNum;
               
        
        %Calculate NRMS error
        allrun{j}.ensemble_subset.Average.NRMSE = F_NRMSE(allrun{j}.ensemble_subset.Average.Pred, ...
            toPredictF, Mean_toPredictF);
    end

    %save values
    
    Etestset = zeros(1,corrida);
    maximo=[];
    minimo=[];
    posMax=[];
    posMin=[];
    temp=[];
    
    % load (nrms inside, final, accuracy and ,more)
        
    for j=1:corrida
        Etestset(1,j) = allrun{1,j}.ensemble_subset.Average.NRMSE;
    end
    temp=[];
    [minimo, posMin] = min(Etestset);
    [maximo, posMax] = max(Etestset);
    
        
    table2(i,12) = mean(Etestset);
    table2(i,13) = std(Etestset);
    table2(i,14) = minimo;
    table2(i,15) = maximo;
    table2(i,16) = posMin;
    table2(i,17) = 0;     %space to not get confuse
  
    EensembleAve{1,i}(2,:) = Etestset;
    
    cd('../');          %exit res
    cd('../');          %exit TS
    clear allrun
end

cd('../');          %exit dir2

%%%%% after the values have been extracted, the t-test is calculated


for i=1:21
    
    %T-test dir1 & dir2
    [h,p,ci] = ttest2(EensembleAve{1,i}(1,:),EensembleAve{1,i}(2,:),alpha, tail, type);
    Table_ttest_dir1_dir2(i,1) = p;
    
    h = [];
    p = [];
    ci = [];
     
end


%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%In this part is the same with the code form 15C to create the ensemble





