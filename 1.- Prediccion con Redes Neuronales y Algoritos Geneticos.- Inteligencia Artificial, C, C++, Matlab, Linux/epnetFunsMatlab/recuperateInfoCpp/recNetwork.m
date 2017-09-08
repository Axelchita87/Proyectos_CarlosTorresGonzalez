%% Funtion to recuperate each network
%
%
% Created:  some day of 2008 
% Modified: 17 Nov 2010
% Author:   Carlos Torres and Victor Landassuri

%% Function
function [Net, counter] = recNetwork(Net, allrun, counter, file, C, v)

% recuperate sizes structure if activate, modify, cause validation set
% could be or not saved
% [Net.sets, counter] = recStructSets(Net.sets, counter, file);


% % Load some v for the case of classification tasks/module1
% Modules = 0;
% v.NUM_MODULES = 0;
% if v.task2solve == C.CLASSIFY
%     Modules = load('../txtFiles/nameModules.txt');
%     v.NUM_MODULES = size(Modules,2);
% else
%     v.NUM_MODULES = 1;
% end




%recuperate all variables from Epochs
[Net.Epochs, counter] = recEpochs(Net.Epochs, allrun, counter, file, v);

%recuperate varN
[Net.varN, counter] = recVarN(Net.varN, file, counter, size(v.epochsK,2),v.sizetpos);

allnodes = Net.varN.finalInp + Net.varN.hidden + Net.varN.VnoOutputs;


% Allocate space before read for performance
Net.CW = zeros(allnodes,allnodes);
Net.W = zeros(allnodes,allnodes);
if v.isDualWeights == 1
    Net.W2 = zeros(allnodes,allnodes);
end
Net.DeltaW = zeros(allnodes,allnodes);
Net.bias = zeros(1,allnodes);
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


%recuperate CW
for i=1:allnodes
    for j=1:allnodes
        Net.CW(i,j) = file(counter);
        counter = counter+1;
    end
end

%recuperate W
for i=1:allnodes
    for j=1:allnodes
        Net.W(i,j) = file(counter);
        counter = counter+1;
    end
end

% W2
if v.isDualWeights == 1
    for i=1:allnodes
        for j=1:allnodes
            Net.W2(i,j) = file(counter);
            counter = counter+1;
        end
    end
end

%recuperate DeltaW
for i=1:allnodes
    for j=1:allnodes
        Net.DeltaW(i,j) = file(counter);
        counter = counter+1;
    end
end

%recuperate nodes
for i=1:allnodes
    Net.nodes(i) = file(counter);
    counter = counter+1;
end

% Bias
for i=1:allnodes
    Net.bias(1,i) = file(counter);
    counter = counter+1;
end

%recuperate posinputs
for i=1:Net.varN.finalInp
    Net.posinputs(1,i) = file(counter);
    counter = counter+1;
end

%recuperate poshidden
for i=1:Net.varN.hidden + Net.varN.VnoOutputs
    Net.poshidden(1,i) = file(counter);
    counter = counter+1;
end

%recuperate sizepos
for i=1:2
    Net.sizepos(1,i) = file(counter);
    counter = counter+1;
end

%recuperate momentum
Net.momentum = file(counter);
counter = counter+1;

%singleLrate one for the whole network or one for each module
for i=1:v.NUM_MODULES
    Net.lrate(1,i) =  file(counter); counter = counter+1;
end

%lrate per node
for i=1:allnodes
    Net.lratePnode(1,i) =  file(counter); counter = counter+1;
end

%lrateB (for the bias)
for i=1:allnodes
    Net.lrateBias(1,i) =  file(counter); counter = counter+1;
end 


%status
Net.status = file(counter);
counter = counter+1;

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% look for errors
if(file(counter) ~= -1)
    'There is an error before net.status in recNet, do not math the cases'
end
counter = counter+1;
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


%recuperate predParam predict (MSP) and oneStep (SSP)
if(v.extraPredictions == C.ON && v.task2solve == C.PREDICT)
    cont = v.initialStepPred;
    for i=1:v.numDiffPredict
        Net.set2SSP{i} = [];
        Net.set2MSP{i} = [];
        
        [Net.set2SSP{i},counter] = recStruct_PredParam(Net.set2SSP{i}, C, v, counter, file);
        [Net.set2MSP{i},counter] = recStruct_PredParam(Net.set2MSP{i}, C, v, counter, file);
        cont = cont *2;
    end
end
[Net.predictI, counter] = recStruct_PredParam(Net.predictI, C, v, counter, file);
[Net.predictF, counter] = recStruct_PredParam(Net.predictF, C, v, counter, file);


%recuperate fitness
Net.fitness = file(counter); counter = counter+1;
Net.fitnessReal = file(counter); counter = counter+1;



% Recuperate variables from module1
if v.isModule1 == C.ON
    % create the structure
    Net.huskenModule = [];
    Net.sharedModule = [];
    [Net.huskenModule, counter ] = recStruc_module1(Net.huskenModule, ...
        allnodes,C, v, counter, file);
    [Net.sharedModule, counter ] = recStruc_module1(Net.sharedModule,...
        allnodes, C,v, counter, file);
    
    if v.evolveLrate == 2
        
        % Check how many modules, not count isolated nodes
        noModulesValid = Net.huskenModule.v.NUM_MODULES;
        for i=1:Net.huskenModule.v.NUM_MODULES
            if Net.huskenModule.nameModule(1,i) <= 0
                noModulesValid = noModulesValid - 1;
            end
        end
        
               
        
    end
end


   

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%finish sizes from all runs, see band, look for errors
if(file(counter) ~= -1)
    'There is an error in recNetwork, do not math the cases'
end
counter = counter+1;
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%








%% fucntion to recuperate all variables from Epochs
function [Epochs, counter] = recEpochs(Epochs, allrun, counter, file, v)
%Etr
for i=1:v.epochsK(2)
    Epochs.Etr(i) = file(counter);
    counter = counter+1;
end
%Eval
for i=1:v.epochsK(2)
    Epochs.Eval(i) = file(counter);
    counter = counter+1;
end
%GL
for i=1:v.epochsK(2)
    Epochs.GL(i) = file(counter);
    counter = counter+1;
end
%Pk
for i=1:v.epochsK(2)
    Epochs.Pk(i) = file(counter);
    counter = counter+1;
end
%PQalfa
for i=1:v.epochsK(2)
    Epochs.PQalfa(i) = file(counter);
    counter = counter+1;
end
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%finish sizes from all runs, see band, look for errors
if(file(counter) ~= -1)
    'There is an error in recEpochs (inside recNetwork), do not math the cases'
end
counter = counter+1;
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%




%% function to recuperate the varN that contain specific values of the
% network
function [v, counter] = recVarN(v, file, counter, sizeEpochs, sizetpos)


% load Vepochs
for j=1:sizeEpochs
    v.Vepochs(j) = file(counter);
    counter = counter+1;
end

%targetpos
for j=1:sizetpos
    v.VtargetPos(j) = file(counter);
    counter = counter+1;
end

% v.VmaxInputs = file(counter);         counter = counter+1;
% v.VmaxDelays = file(counter);         counter = counter+1;
% v.VmaxHidden = file(counter);         counter = counter+1;
v.VnoOutputs = file(counter);         counter = counter+1;

v.inputs = file(counter);                 counter = counter+1;
v.finalInp = file(counter);               counter = counter+1;
v.delays = file(counter);                 counter = counter+1;
v.hidden = file(counter);                 counter = counter+1;

v.Vfileline = file(counter);                  counter = counter+1;
v.Vfilecol = file(counter);                   counter = counter+1;

v.Vsizetpos = file(counter);                  counter = counter+1;
v.VPred_stepAhead = file(counter);            counter = counter+1;

% Global v in C++
v.Pred_stepAheadInside = file(counter);       counter = counter+1;
v.FILECOL = file(counter);                    counter = counter+1;

% min and max of the classes
v.minClass = file(counter);                   counter = counter+1;
v.maxClass = file(counter);                   counter = counter+1;

% to know how many times has been loaded
v.counterLoaded = file(counter);              counter = counter+1;


%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%finish sizes from all runs, see band, look for errors
if(file(counter) ~= -1)
    'There is an error in recVarN (inside recNetwork), do not math the cases'
end
counter = counter+1;
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%








function [module, counter ] = recStruc_module1(module, allnodes, C,v, counter, file)


% number of Modules
%module.noModule = 0;
module.v.NUM_MODULES = file(counter);                           counter = counter+1;


% Create the rest of the structures
module.nameModule = zeros(1,module.v.NUM_MODULES);
module.nodesInModule = zeros(allnodes,2);
module.tdw = zeros(allnodes,module.v.NUM_MODULES);
module.tda = zeros(allnodes,module.v.NUM_MODULES);
module.noIsolatedNodes = 0;

% Name ofModules
for i=1:module.v.NUM_MODULES
    module.nameModule(1,i) = file(counter);                   counter = counter+1;
end

% nodesInModule
for i=1:allnodes
    for j=1:2
        module.nodesInModule(i,j) = file(counter);          counter = counter+1;
    end
end


% tdw
for i=1:allnodes
    for j=1:module.v.NUM_MODULES
        module.tdw(i,j) = file(counter);        counter = counter+1;
    end
end

% tda
for i=1:allnodes
    for j=1:module.v.NUM_MODULES
        module.tda(i,j) = file(counter);        counter = counter+1;
    end
end

% isolated ndoes
module.noIsolatedNodes = file(counter);         counter = counter+1;

% Modularity
module.MweightTD = file(counter);               counter = counter+1;
module.MarchTD = file(counter);                 counter = counter+1;


% Reuse modules
if v.reuseModule == C.ON
    for i=1:module.v.NUM_MODULES
        module.nodesReusedPerMod(1,i) =  file(counter); counter = counter+1;
    end
end

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%finish ,,, look for errors
if(file(counter) ~= -1)
    'There is an error in module1 (inside recNetwork), do not math the cases'
end
counter = counter+1;
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

