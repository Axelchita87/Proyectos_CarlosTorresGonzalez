%% Scritp to recuperate all the information saved by C epnet
% The information is saved in a structure allrun[i], where i is the corrida,
% that is different from c, where each run is saved in different files
% for the moment matlab do not read ALLChar.txt which is all the text from
% epnet
%
% File ejecuted from root directory
% this file only works from TSEPnet61 and ahead
%
% Created:      Sep 2008 (around)
% Modified at:  17 Nov 2010 
% Author:       Carlos Torres and Victor Landassuri


%% Create the basic strucuture to save all

counter = 0;


for i=1:1 %corrida      % in this moment only save this values for the first run           
    allrun{i} = [];
    
    %% declarations of the constant values used in the C++ code
    allrun{i}.C.PREDICT = 0;
    allrun{i}.C.CLASSIFY =  0;
        
    % Different algorithms implemnted to evolve the features
    allrun{i}.C.HIERARQUICAL =  0;
    allrun{i}.C.TOURNAMNET =  0;
    allrun{i}.C.CO_EVO =  0;
    allrun{i}.C.ASYMMETRIC =  0;
    allrun{i}.C.MODULAR1 =  0;
    allrun{i}.C.SWAP_CONN =  0;
    allrun{i}.C.MR_EPNET =  0;
    
    allrun{i}.C.MBP = 0;
    allrun{i}.C.SA =  0;
    allrun{i}.C.SUCCESS = 0;
    allrun{i}.C.FAILURE = 0;
    allrun{i}.C.TRAIN_INSIDE = 0;
    allrun{i}.C.TRAIN_OUTSIDE = 0;
    allrun{i}.C.BAND = -1;		%values to check for error when saving, related when is loaded into Matlab

    allrun{i}.C.ON = 0;
    allrun{i}.C.OFF = 0;

    % kind of prediction
    allrun{i}.C.MSP = 0;						% multi-step prediction
    allrun{i}.C.SSP = 0;						% single-step prediction

    % Evolution of features
    allrun{i}.C.EVOLVE = 0;
    allrun{i}.C.FIXED = 0;
    allrun{i}.C.FIX_EVOvra = 0;
    
    % transfer fucntion 
    allrun{i}.C.HTAN = 0;
    allrun{i}.C.SIGMOID = 0;
    allrun{i}.C.LINEAL = 0;
    
    % Modules
    allrun{i}.C.MODULES = 0;
    
    %% ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    
    % Variables the determinate the existance of other variables %%%%%%%%%%
    allrun{i}.var.task2solve = 0;
    allrun{i}.var.RunEnsemble = 0;
    allrun{i}.var.trainMultipleSets = 0;
    allrun{i}.var.extraPredictions = 0;
    allrun{i}.var.algoFeatures = 0;
    
    allrun{i}.var.outputDenormalized = 0;
    allrun{i}.var.saveNumIndividual = 0;
    allrun{i}.var.saveModulesINpool = 0;
     
    % module1
    allrun{i}.var.isModule1 = 0;
    allrun{i}.var.evolveLrate = 0;
    
    allrun{i}.var.isDualWeights = 0;
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    
    allrun{i}.var.epochsK = zeros(1,2);
    
    allrun{i}.var.transferFunOutput = 0;
    allrun{i}.var.transferFunHidden = 0;
    
    % validation set
    allrun{i}.var.useValidation = 0;
    allrun{i}.var.valiAuto = 0;
    allrun{i}.var.sizeValiAutoPercentage = 0;
    allrun{i}.var.sizeVali = 0;
    allrun{i}.var.useValidationOutside = 0;
        
    allrun{i}.var.sizetpos = 0;
    allrun{i}.var.successT = 0;
    %allrun{i}.var.kindPred = [];
    allrun{i}.var.fileline = 0;
    allrun{i}.var.filecol = 0;
    allrun{i}.var.fixedinputs = 0;
    allrun{i}.var.Corridas = 0;
    allrun{i}.var.populationNum = 0;
    allrun{i}.var.generations = 0;
    allrun{i}.var.maxdata = 0;
    allrun{i}.var.Pred_stepAhead =0;
    allrun{i}.var.Pred_stepAheadInside =0;
    allrun{i}.var.DeltaT =0;
    allrun{i}.var.kindPred =0;
    
    allrun{i}.var.minInp = 0;
    allrun{i}.var.minDelay= 0;
    allrun{i}.var.minHid = 0;
    allrun{i}.var.maxInputs = 0;
    allrun{i}.var.maxDelays= 0;
    allrun{i}.var.maxHidden = 0;
    
    allrun{i}.var.noOutputs = 0;
    allrun{i}.var.smallW = 0;
    allrun{i}.var.momentum1 = 0;
    allrun{i}.var.lrate1 = 0;
    
    allrun{i}.var.minmutateN = 0;
    allrun{i}.var.mutatednodes = 0;
    allrun{i}.var.mutatedcon = 0;
    allrun{i}.var.initDensity = 0;

    allrun{i}.var.temperature = 0;
    allrun{i}.var.mintemp = 0;
    allrun{i}.var.iterationTemp = 0;
    allrun{i}.var.YMIN = 0;
    allrun{i}.var.YMAX = 0;
    allrun{i}.var.stopAlpha = 0;
    allrun{i}.var.strip = 0;
    
      
   
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %the next sets cna be of different size, allocated ahead
    %int this sets/recuperated, first is saved pn and then tn
%     5) allrun->sets->valF-> pn tn...
% //  *6) allrun->sets->valI->...
    
% //  *7) allrun->sets->tsF->...
% //  *8) allrun->sets->tsI->...
% //  *9) allrun->sets->psF->...
% //  *10) allrun->sets->psI->...
    
     
    % for variables of ensemble
%     allrun{i}.ensemble.SRank_base_lin_combination = [];
%     allrun{i}.ensemble.weightsRankBase = [];
%     allrun{i}.ensemble.SRLS_alg = [];
%     allrun{i}.ensemble.GA = [];
    
end




%load file
cd('res');
file = 'r';


%% load the config file that has all the previous information before each run

if(exist('config.txt','file') == 2)
    load config.txt
else
    display('error, config files does not exist, finish all...')
    return
end

counter = 1;
i = 1;



%if(i==1) % recuperate the sets structure only for the first run

%% declarations of the constant values use din the C++ code
allrun{i}.C.PREDICT = config(counter); counter = counter+1;
allrun{i}.C.CLASSIFY =  config(counter); counter = counter+1;

allrun{i}.C.HIERARQUICAL =  config(counter); counter = counter+1;
allrun{i}.C.TOURNAMNET =    config(counter); counter = counter+1;
allrun{i}.C.CO_EVO =        config(counter); counter = counter+1;
allrun{i}.C.ASYMMETRIC =    config(counter); counter = counter+1;
allrun{i}.C.MODULAR1 =      config(counter); counter = counter+1;
allrun{i}.C.SWAP_CONN =      config(counter); counter = counter+1;
allrun{i}.C.MR_EPNET =      config(counter); counter = counter+1;
 
allrun{i}.C.MBP = config(counter); counter = counter+1;
allrun{i}.C.SA =  config(counter); counter = counter+1;
allrun{i}.C.SUCCESS = config(counter); counter = counter+1;
allrun{i}.C.FAILURE = config(counter); counter = counter+1;
allrun{i}.C.TRAIN_INSIDE = config(counter); counter = counter+1;
allrun{i}.C.TRAIN_OUTSIDE = config(counter); counter = counter+1;
allrun{i}.C.BAND = config(counter); counter = counter+1;		%values to check for error when saving, related when is loaded into Matlab

allrun{i}.C.ON = config(counter); counter = counter+1;
allrun{i}.C.OFF = config(counter); counter = counter+1;

% kind of prediction
allrun{i}.C.MSP = config(counter); counter = counter+1;						% multi-step prediction
allrun{i}.C.SSP = config(counter); counter = counter+1;						% single-step prediction

% Evolution of features
allrun{i}.C.EVOLVE = config(counter); counter = counter+1;
allrun{i}.C.FIXED = config(counter); counter = counter+1;
allrun{i}.C.FIX_EVOvra = config(counter); counter = counter+1;

% tranfer function
allrun{i}.C.HTAN = config(counter);                   counter = counter+1;
allrun{i}.C.SIGMOID = config(counter);                counter = counter+1;
allrun{i}.C.LINEAL = config(counter);                 counter = counter+1;

% modules
allrun{i}.C.MODULES = config(counter);                counter = counter+1;

% flag
if(config(counter) ~= -1)
    error('There is an error in constants, do not math the cases')
end
counter = counter+1;
%% ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++



%% Variables the determinate the existance of other variables

% task2solve
allrun{i}.var.task2solve = config(counter);             counter = counter+1;

allrun{i}.var.RunEnsemble = config(counter);            counter = counter+1;

% trainMultipleSets
allrun{i}.var.trainMultipleSets = config(counter);      counter = counter+1;

% extraPredictions
allrun{i}.var.extraPredictions = config(counter);       counter = counter+1;

% algoFeatures
allrun{i}.var.algoFeatures = config(counter);           counter = counter+1;



% output denormalized or not
allrun{i}.var.outputDenormalized = config(counter);     counter = counter+1;

% How many individual are saved
allrun{i}.var.saveNumIndividual = config(counter);      counter = counter+1;

% Save in a separate directory all the population to be reloadded in the
% future
% This variable does not affect to load more data here, just it is save to
% infor of this fact here
allrun{i}.var.saveNets2beReloaded = config(counter);    counter = counter+1;

% Save each module in a pool
allrun{i}.var.saveModulesINpool = config(counter);    counter = counter+1;

% Load modularity
allrun{i}.var.isModule1 = config(counter);    counter = counter+1;

% To indicate if the inputs are considered into the modularity
allrun{i}.var.considerInputsInMod = config(counter);    counter = counter+1;

% Load learning rate per module (to see if it is evolved or not)
allrun{i}.var.evolveLrate = config(counter);    counter = counter+1;

% Dual weights
allrun{i}.var.isDualWeights = config(counter);    counter = counter+1;

% Reuse modules
allrun{i}.var.reuseModule = config(counter);    counter = counter+1;


if(config(counter) ~= -1)
    error('There is an error in constants, do not math the cases')
end
counter = counter+1;



% Special case, I will load the number of NUM_MODULES and NAME_MODULE from
% files....
% From now (29 Jul 2011) I will consider that all task have at least the
% next file

%if allrun{i}.var.task2solve == allrun{i}.C.CLASSIFY
    allrun{i}.var.NAME_MODULE = load('../txtFiles/nameModules');
    allrun{i}.var.NUM_MODULES = size( allrun{i}.var.NAME_MODULE, 2 );
%else
%    allrun{i}.var.NUM_MODULES = 1;
%end

%also the type of task, wta, NRMSE
%if allrun{i}.var.task2solve == allrun{i}.C.ON
    % this variable will help to know if a tsk like LoA1,5,10,15,20 is a
    % prediction task used like a classification, so i can plot the preds.
    fid = fopen(['..',SLASH,'txtFiles', SLASH, 'typeDS'], 'r');
    allrun{i}.var.typeDS = fgetl(fid);
    if (fclose(fid) ~= 0)
        display('error closing file');
    end
%end

 %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
 %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%% CONTINUE WITH THE NORMAL VARIABLES
%recuperate epochsK[2]
for j=1:2
    allrun{i}.var.epochsK(j) = config(counter);
    counter = counter+1;
end

allrun{i}.var.transferFunOutput = config(counter);          counter = counter+1;
allrun{i}.var.transferFunHidden = config(counter);          counter = counter+1;

% Validation set
allrun{i}.var.useValidation = config(counter);        counter = counter+1;
allrun{i}.var.valiAuto = config(counter);             counter = counter+1;
allrun{i}.var.sizeValiAutoPercentage = config(counter); counter = counter+1;
allrun{i}.var.sizeVali = config(counter);             counter = counter+1;
allrun{i}.var.useValidationOutside = config(counter); counter = counter+1;

%recuperate sizetpos
allrun{i}.var.sizetpos = config(counter);             counter = counter+1;

%recuperate STP (successful training parameter)
allrun{i}.var.successT = config(counter);
counter = counter+1;

% recuperate fileline, filecol, fixedinputs
allrun{i}.var.fileline = config(counter);          counter = counter+1;
allrun{i}.var.filecol = config(counter);           counter = counter+1;
allrun{i}.var.fixedinputs = config(counter);       counter = counter+1;

%recuperate Corridas, populationNum, generations, maxdata,Pred_stepAhead
allrun{i}.var.Corridas = config(counter);         counter = counter+1;
allrun{i}.var.populationNum = config(counter);    counter = counter+1;
allrun{i}.var.expectedGenerations = config(counter);      counter = counter+1;
allrun{i}.var.maxdata = config(counter);          counter = counter+1;
allrun{i}.var.Pred_stepAhead = config(counter);   counter = counter+1;
allrun{i}.var.Pred_stepAheadInside = config(counter);   counter = counter+1;
allrun{i}.var.DeltaT = config(counter);           counter = counter+1;
allrun{i}.var.kindPred = config(counter);         counter = counter+1;

allrun{i}.var.numDiffPredict = config(counter);   counter = counter+1;
allrun{i}.var.initialStepPred = config(counter);  counter = counter+1;
allrun{i}.var.incremenInData = config(counter);   counter = counter+1;

%recuperate maxInputs noInputsDelay maxHidden noOutputs smallW momentum1
%lrate1
allrun{i}.var.minInp = config(counter);           counter = counter+1;
allrun{i}.var.minDelay= config(counter);          counter = counter+1;
allrun{i}.var.minHid = config(counter);           counter = counter+1;

allrun{i}.var.maxInputs = config(counter);        counter = counter+1;
allrun{i}.var.maxDelays = config(counter);        counter = counter+1;
allrun{i}.var.maxHidden = config(counter);        counter = counter+1;
allrun{i}.var.noOutputs = config(counter);        counter = counter+1;
allrun{i}.var.smallW = config(counter);           counter = counter+1;
allrun{i}.var.momentum1 = config(counter);        counter = counter+1;
allrun{i}.var.lrate1 = config(counter);           counter = counter+1;


%recuperate minmutateN mutatednodes mutatedcon initDensity
%    allrun{i}.var.minmutateN= config(counter);         counter = counter+1;
%     allrun{i}.var.mutatednodes= config(counter);      counter = counter+1;
%     allrun{i}.var.mutatedcon= config(counter);        counter = counter+1;
%     allrun{i}.var.initDensity = config(counter);      counter = counter+1;


%recuperate temperature mintemp iterationTemp ....
allrun{i}.var.temperature = config(counter);       counter = counter+1;
allrun{i}.var.mintemp = config(counter);          counter = counter+1;
allrun{i}.var.iterationTemp = config(counter);    counter = counter+1;
allrun{i}.var.YMIN = config(counter);             counter = counter+1;
allrun{i}.var.YMAX = config(counter);             counter = counter+1;
allrun{i}.var.stopAlpha = config(counter);        counter = counter+1;
allrun{i}.var.strip = config(counter);            counter = counter+1;

%finish headers, see band, look for errors
if(config(counter) ~= -1)
     error('There is an error in headers, do not math the cases')
end
counter = counter+1;



%% recuperate the sets to predict only, from predparam are not
%% recuperated

if(allrun{1,1}.var.extraPredictions == allrun{1,1}.C.ON)        % if there are extraPred
    allrun{i}.toPredict{1}(1:15) = zeros(1,15);
    cont = allrun{i}.var.initialStepPred;
    for j=1:allrun{i}.var.numDiffPredict
        for k=1:cont
            allrun{i}.toPredict{j}(1,k) = config(counter);    counter = counter+1;
        end
        cont = cont * 2;
    end
    
end

% toPredictI
for j = 1:allrun{i}.var.sizetpos
    for k=1:allrun{i}.var.Pred_stepAheadInside
        allrun{i}.toPredictI(j,k) = config(counter);
        counter = counter+1;
    end
end
% toPredictF
for j = 1:allrun{i}.var.sizetpos
    for k=1:allrun{i}.var.Pred_stepAhead
        allrun{i}.toPredictF(j,k) = config(counter);
        counter = counter+1;
    end
end

if(config(counter) ~= -1)
    error('There is an error in topredict section, do not math the cases')
end
counter = counter+1;


%end % End the values of the first run
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%








%% Section to recuperate ALLParam, and networks


% Determinate how many files (corridas there are)
corrida = 0;
idxCorrida = zeros(1,ExpectedCorrida);

for i=1:ExpectedCorrida
    filetempExt = [file,num2str(i),'ALLNum.txt'];  % file
    
    if(exist(filetempExt,'file') == 2)      % exist
        corrida = corrida + 1;
        idxCorrida(1,corrida) = i;
    end
end



for i=1:corrida
    % Original code in which I read several times one file it ohter doe
    % snot exist, the problem is that the std will be smaller as the same
    % run is added more than one, whit the new code avoid that
    
%     filetempExt = [file,num2str(i),'ALLNum.txt'];
%     
%     % check if the file exist, if it does not, then load the previous
%     % This is to replace runs that did not finish
%     if(exist(filetempExt,'file') ~= 2)
%         % if it does not exist
%         if i == 1
%             % look for the next that exist
%             for fileTmp=2:corrida
%                 if(exist([file,num2str(fileTmp),'ALLNum.txt'],'file') == 2)
%                     filetempExt = [file,num2str(fileTmp),'ALLNum.txt'];
%                     break;
%                 else
%                     filetempExt = 'noFile';
%                 end
%             end
%         elseif i>1
%             % if a file does not exist and it is not the first
%             % look for any other file 
%             for fileTmp=1:corrida    % to avoid extra condition I allow to look for the same that does not exist
%                 if(exist([file,num2str(fileTmp),'ALLNum.txt'],'file') == 2)
%                     filetempExt = [file,num2str(fileTmp),'ALLNum.txt'];
%                     break;
%                 else
%                     filetempExt = 'noFile';
%                 end
%             end
%         end
%         
%         if strcmp(filetempExt,'noFile')
%             display('Error it seems that there are no files to load, exit')
%             return
%         end
%     end
%     


    % load the file
    filetempExt = [file,num2str( idxCorrida(i) ),'ALLNum.txt'];
    
    fileTNum = load(filetempExt);
    % fileTNum = eval([file,num2str(i),'ALLNum']); %copy the origianl array
    % clear ([file,num2str(i),'ALLNum']);          % only to liberate mem
    
    counter = 1;                               %ready for the next possition
        
    %recuperate the generations used
    allrun{i}.generation = fileTNum(counter);
    counter = counter+1;
    
    %recuperate the time
    allrun{i}.cpu_time_used = fileTNum(counter);
    counter = counter+1;
    
        
    
    %% Create the space for ALLParam
    allrun{i}.ALLParam = [];
    % recuperate structure
    [allrun{i}.ALLParam, counter] = recStruct_AllParam(allrun{i}.ALLParam,...
        counter, fileTNum, allrun{1,1}.var, allrun{1,1}.C, allrun{i}.generation);
    
    % If COEVO is used
    if(allrun{1,1}.var.algoFeatures == allrun{1,1}.C.CO_EVO)
        allrun{i}.ALLParam2 = [];
        % recuperate structure
        [allrun{i}.ALLParam2, counter] = recStruct_AllParam(allrun{i}.ALLParam,...
            counter, fileTNum, allrun{1,1}.var, allrun{1,1}.C, allrun{i}.generation);
    end
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    
    
    %% recuperate varibles of Network, bestnetwork, bestnetwork1
    % Because it is the last structure saved, it does not matter if in the
    % C code it is saved all the population, here can be recuperated only
    % the best individual if it is desired !!!!
    
    
    
     %for j=1:allrun{1,1}.var.populationNum
     for j = 1:allrun{1,1}.var.saveNumIndividual 
        % allocate space for Network% ony the best of each run
        allrun{i}.Network{j}.sets = [];
        allrun{i}.Network{j}.Epochs = [];
        if(allrun{1,1}.var.extraPredictions == allrun{1,1}.C.ON)
            allrun{i}.Network{j}.set2SSP = {};
            allrun{i}.Network{j}.set2MSP = {};
       end
       allrun{i}.Network{j}.predictI = [];
       allrun{i}.Network{j}.predictF = [];
       allrun{i}.Network{j}.varN = [];
       
       % Recuperate the information
       [allrun{i}.Network{j}, counter] = recNetwork(allrun{i}.Network{j}, ...
           allrun{i}, counter, fileTNum, allrun{1,1}.C ,allrun{1,1}.var);  
   end
      
   %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
   %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
   %finish -- from all runs, see band, look for errors
   %values of counter until here must be ????
    if(fileTNum(counter) ~= -1)
        'There is an error after all netwroks have been recuperated, do not math the cases'
        return
    end
    counter = counter+1;
   %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
   %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
   
    
%         
%    
%    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%    
%    if (allrun{i}.var.RunEnsemble == 1)
%        % for variables of ensemble
%        
%        %Allocate space Average
%        allrun{i}.ensemble.Average.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.Average.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.Average.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.Average.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.Average, counter] = recStruct_PredParam(allrun{i}.ensemble.Average, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        %Allocate space SRank_base_LCombination...
%        allrun{i}.ensemble.SRank_base_LCombination_05.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_05.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.SRank_base_LCombination_05.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_05.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        allrun{i}.ensemble.SRank_base_LCombination_1.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_1.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.SRank_base_LCombination_1.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_1.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        allrun{i}.ensemble.SRank_base_LCombination_15.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_15.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.SRank_base_LCombination_15.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_15.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        allrun{i}.ensemble.SRank_base_LCombination_2.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_2.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.SRank_base_LCombination_2.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_2.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        allrun{i}.ensemble.SRank_base_LCombination_25.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_25.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.SRank_base_LCombination_25.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_25.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        allrun{i}.ensemble.SRank_base_LCombination_3.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_3.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.SRank_base_LCombination_3.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_3.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        allrun{i}.ensemble.SRank_base_LCombination_35.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_35.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.SRank_base_LCombination_35.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_35.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        allrun{i}.ensemble.SRank_base_LCombination_4.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_4.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.SRank_base_LCombination_4.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_4.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        allrun{i}.ensemble.SRank_base_LCombination_45.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_45.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.SRank_base_LCombination_45.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_45.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        allrun{i}.ensemble.SRank_base_LCombination_5.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_5.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.SRank_base_LCombination_5.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_5.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        allrun{i}.ensemble.SRank_base_LCombination_55.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_55.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.SRank_base_LCombination_55.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_55.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        allrun{i}.ensemble.SRank_base_LCombination_6.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_6.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.SRank_base_LCombination_6.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_6.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        allrun{i}.ensemble.SRank_base_LCombination_65.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_65.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.SRank_base_LCombination_65.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_65.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        allrun{i}.ensemble.SRank_base_LCombination_7.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_7.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.SRank_base_LCombination_7.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_7.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        allrun{i}.ensemble.SRank_base_LCombination_75.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_75.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.SRank_base_LCombination_75.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_75.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        allrun{i}.ensemble.SRank_base_LCombination_8.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_8.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.SRank_base_LCombination_8.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_8.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        allrun{i}.ensemble.SRank_base_LCombination_85.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_85.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.SRank_base_LCombination_85.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_85.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        allrun{i}.ensemble.SRank_base_LCombination_9.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_9.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.SRank_base_LCombination_9.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_9.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        allrun{i}.ensemble.SRank_base_LCombination_95.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_95.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        allrun{i}.ensemble.SRank_base_LCombination_95.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        allrun{i}.ensemble.SRank_base_LCombination_95.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.SRank_base_LCombination_05, counter] = recStruct_PredParam(allrun{i}.ensemble.SRank_base_LCombination_05, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        %weightsRankBase_05
%        for j=1:allrun{i}.var.populationNum
%            allrun{i}.ensemble.weightsRankBase_05(j) = fileTNum(counter);
%            counter = counter+1;
%        end
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.SRank_base_LCombination_1, counter] = recStruct_PredParam(allrun{i}.ensemble.SRank_base_LCombination_1, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        %weightsRankBase_1
%        for j=1:allrun{i}.var.populationNum
%            allrun{i}.ensemble.weightsRankBase_1(j) = fileTNum(counter);
%            counter = counter+1;
%        end
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.SRank_base_LCombination_15, counter] = recStruct_PredParam(allrun{i}.ensemble.SRank_base_LCombination_15, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        %weightsRankBase_15
%        for j=1:allrun{i}.var.populationNum
%            allrun{i}.ensemble.weightsRankBase_15(j) = fileTNum(counter);
%            counter = counter+1;
%        end
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.SRank_base_LCombination_2, counter] = recStruct_PredParam(allrun{i}.ensemble.SRank_base_LCombination_2, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        %weightsRankBase_2
%        for j=1:allrun{i}.var.populationNum
%            allrun{i}.ensemble.weightsRankBase_2(j) = fileTNum(counter);
%            counter = counter+1;
%        end
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.SRank_base_LCombination_25, counter] = recStruct_PredParam(allrun{i}.ensemble.SRank_base_LCombination_25, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        %weightsRankBase_25
%        for j=1:allrun{i}.var.populationNum
%            allrun{i}.ensemble.weightsRankBase_25(j) = fileTNum(counter);
%            counter = counter+1;
%        end
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.SRank_base_LCombination_3, counter] = recStruct_PredParam(allrun{i}.ensemble.SRank_base_LCombination_3, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        %weightsRankBase_3
%        for j=1:allrun{i}.var.populationNum
%            allrun{i}.ensemble.weightsRankBase_3(j) = fileTNum(counter);
%            counter = counter+1;
%        end
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.SRank_base_LCombination_35, counter] = recStruct_PredParam(allrun{i}.ensemble.SRank_base_LCombination_35, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        %weightsRankBase_35
%        for j=1:allrun{i}.var.populationNum
%            allrun{i}.ensemble.weightsRankBase_35(j) = fileTNum(counter);
%            counter = counter+1;
%        end
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.SRank_base_LCombination_4, counter] = recStruct_PredParam(allrun{i}.ensemble.SRank_base_LCombination_4, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        %weightsRankBase_4
%        for j=1:allrun{i}.var.populationNum
%            allrun{i}.ensemble.weightsRankBase_4(j) = fileTNum(counter);
%            counter = counter+1;
%        end
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.SRank_base_LCombination_45, counter] = recStruct_PredParam(allrun{i}.ensemble.SRank_base_LCombination_45, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        %weightsRankBase_45
%        for j=1:allrun{i}.var.populationNum
%            allrun{i}.ensemble.weightsRankBase_45(j) = fileTNum(counter);
%            counter = counter+1;
%        end
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.SRank_base_LCombination_5, counter] = recStruct_PredParam(allrun{i}.ensemble.SRank_base_LCombination_5, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        %weightsRankBase_5
%        for j=1:allrun{i}.var.populationNum
%            allrun{i}.ensemble.weightsRankBase_5(j) = fileTNum(counter);
%            counter = counter+1;
%        end
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.SRank_base_LCombination_55, counter] = recStruct_PredParam(allrun{i}.ensemble.SRank_base_LCombination_55, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        %weightsRankBase_55
%        for j=1:allrun{i}.var.populationNum
%            allrun{i}.ensemble.weightsRankBase_55(j) = fileTNum(counter);
%            counter = counter+1;
%        end
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.SRank_base_LCombination_6, counter] = recStruct_PredParam(allrun{i}.ensemble.SRank_base_LCombination_6, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        %weightsRankBase_6
%        for j=1:allrun{i}.var.populationNum
%            allrun{i}.ensemble.weightsRankBase_6(j) = fileTNum(counter);
%            counter = counter+1;
%        end
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.SRank_base_LCombination_65, counter] = recStruct_PredParam(allrun{i}.ensemble.SRank_base_LCombination_65, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        %weightsRankBase_65
%        for j=1:allrun{i}.var.populationNum
%            allrun{i}.ensemble.weightsRankBase_65(j) = fileTNum(counter);
%            counter = counter+1;
%        end
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.SRank_base_LCombination_7, counter] = recStruct_PredParam(allrun{i}.ensemble.SRank_base_LCombination_7, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        
%        %weightsRankBase_7
%        for j=1:allrun{i}.var.populationNum
%            allrun{i}.ensemble.weightsRankBase_7(j) = fileTNum(counter);
%            counter = counter+1;
%        end
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.SRank_base_LCombination_75, counter] = recStruct_PredParam(allrun{i}.ensemble.SRank_base_LCombination_75, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        
%        %weightsRankBase_75
%        for j=1:allrun{i}.var.populationNum
%            allrun{i}.ensemble.weightsRankBase_75(j) = fileTNum(counter);
%            counter = counter+1;
%        end
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.SRank_base_LCombination_8, counter] = recStruct_PredParam(allrun{i}.ensemble.SRank_base_LCombination_8, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        
%        %weightsRankBase_8
%        for j=1:allrun{i}.var.populationNum
%            allrun{i}.ensemble.weightsRankBase_8(j) = fileTNum(counter);
%            counter = counter+1;
%        end
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.SRank_base_LCombination_85, counter] = recStruct_PredParam(allrun{i}.ensemble.SRank_base_LCombination_85, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        
%        %weightsRankBase_85
%        for j=1:allrun{i}.var.populationNum
%            allrun{i}.ensemble.weightsRankBase_85(j) = fileTNum(counter);
%            counter = counter+1;
%        end
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.SRank_base_LCombination_9, counter] = recStruct_PredParam(allrun{i}.ensemble.SRank_base_LCombination_9, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        
%        %weightsRankBase_9
%        for j=1:allrun{i}.var.populationNum
%            allrun{i}.ensemble.weightsRankBase_9(j) = fileTNum(counter);
%            counter = counter+1;
%        end
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        %recuperate values Average
%        [allrun{i}.ensemble.SRank_base_LCombination_95, counter] = recStruct_PredParam(allrun{i}.ensemble.SRank_base_LCombination_95, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        
%        %weightsRankBase_95
%        for j=1:allrun{i}.var.populationNum
%            allrun{i}.ensemble.weightsRankBase_95(j) = fileTNum(counter);
%            counter = counter+1;
%        end
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        
%        
%        
%        %recuperate OutputBestSRBLC
%        allrun{i}.ensemble.OutputBestSRBLC = fileTNum(counter);
%        counter = counter+1;
%        
%        
%        %
%        %    %Allocate space SRLS_alg
%        %    allrun{i}.ensemble.SRLS_alg.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        %    allrun{i}.ensemble.SRLS_alg.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        %    allrun{i}.ensemble.SRLS_alg.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        %    allrun{i}.ensemble.SRLS_alg.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        %
%        %    %recuperate values Average
%        %    [allrun{i}.ensemble.SRLS_alg, counter] = recStruct_PredParam(allrun{i}.ensemble.SRLS_alg, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        %
%        %     %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %
%        %     %Allocate space GA
%        %    allrun{i}.ensemble.GA.Pred = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        %    allrun{i}.ensemble.GA.NRMSE = zeros(allrun{i}.var.sizetpos,1);
%        %    allrun{i}.ensemble.GA.accuracyPoint = zeros(allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead);
%        %    allrun{i}.ensemble.GA.accuracy = zeros(allrun{i}.var.sizetpos,1);
%        %
%        %    %recuperate values Average
%        %    [allrun{i}.ensemble.GA, counter] = recStruct_PredParam(allrun{i}.ensemble.GA, counter, allrun{i}.var.sizetpos, allrun{i}.var.Pred_stepAhead, fileTNum);
%        %
%        %     %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %
%        %
%        %
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %see band, look for errors
%        if(fileTNum(counter) ~= -1)
%            'There is an error in nvars - sets, do not math the cases'
%        end
%        counter = counter+1;
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%    end
   ['Run = ', num2str(i), ' Values read = ', num2str(counter)]
 
   
end

save allrun allrun   
 
%cd('..');

clear allrun counter file fileTNum filetempExt i j k

