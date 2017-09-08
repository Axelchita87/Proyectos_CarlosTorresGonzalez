%% script to Measure Modularity given by husken
% Here is calculated the modularity M^{arch.} and M^{weith} given in
% Husken, M., Igel, C., Toussaint, M.: Task-dependent evolution of
% modularity in neural networks. Connection Science 14 (2002)
%
% Created:      20/08/2010
% Modified at:  20/09/2010
% Author:       Carlos Torres and Victor Landassuri


clear
clc

cd('..');  cd('LinuxOrWindows');
%use adecuate paht
SLASH = isLinOrWin();
cd('..');
pathExp = pwd;
addpath([pathExp,SLASH,'draw']);
addpath([pathExp,SLASH,'draw',SLASH,'basicShapes']);
addpath([pathExp,SLASH,'ANN']);


% To test the metric for Classification
% noInputs = 6;
% noHidden = 4;
% noOutputs = 2;
% CW and W are the same as husken
% CW2 and W2 are pure modular
% CW3 and W3 are homogeneous non modular completely
%
% for prediciton it is used
% noInputs = 6;
% noHidden = 6;
% noOutputs = 1;
% CWp and Wp similar CW and W (not pure modular)
% CWp2 and Wp2 pure modular
% CWp3 and Wp3 homogeneuos non modular completely


%% Variables to set up before run

task = 'prediction';        % 'prediction' or 'classification'
network = 1;                % 1 not pure modular
                            % 2 pure modular
                            % 3 homoganeuos non modular

plotModuleBox = 1;

%% Section to not modified
% here is loaded the variables

if strcmp(task, 'classification')
    load CWandWtestModularity.mat
    noModules = noOutputs;
else
    load CWandWtestModularityPred.mat               % to test the prediction
    noModules = noOutputs;
end

% which network is studied
switch network
    case 1
        CWtmp = CW;
        Wtmp = W;
    case 2
        CWtmp = CW2;
        Wtmp = W2;  
    case 3
        CWtmp = CW3;
        Wtmp = W3;     
end

% radious
r = 2.5;


nodes = ones(1,noInputs + noHidden + noOutputs);
noNodes = size(nodes,2);
bias = zeros(1,noInputs + noHidden + noOutputs);

inputs = 1:noInputs;
hidden = noInputs+1:(noInputs+noHidden);
outputs = (noInputs+noHidden+1):(noInputs+noHidden+noOutputs);

% following my nomenclature, the fisrt module is with the next number of
% nodes, ...

% even the figure could show something different, here the inputs
% are partitioned into two sets


% list of nodes belonging to each module, only inputs in this moment
% normal or down-top version
% in this case it is required to know in advance tha input partition
listNodesMod = [
    1 1;
    2 1;
    3 1;
    4 2;
    5 2;
    6 2];
nameMod = [1 2];




% plot it with my actual metric a shared module
h = plotANNmod(CWtmp, noInputs, noHidden,noOutputs, inputs, hidden, ...
   outputs, r, nodes, bias, plotModuleBox);


% Here the number fo modules are determinated by the inputs partition or
% the number of outputs (top-down version) for calssification.
% For prediciton, it is used the last hidden nodes that are conencted to
% the output but not connected to other hidden neurons. They are used to
% create the modules

% only for classification, because I do not know how many modules there are
%  for prediction and how are partitionned the inputs for prediciton.
if strcmp(task, 'classification')
    % normal weight
    [mHusWeight, dw] = modHusken('normal', CWtmp, noInputs, noHidden,noOutputs, ...
        inputs, hidden, outputs, nodes, noModules, listNodesMod,nameMod, Wtmp)
    
    % normal arch
    [mHusArch, dh] = modHusken('normal',CWtmp, noInputs, noHidden,noOutputs, ...
        inputs, hidden, outputs, nodes, noModules, listNodesMod, nameMod)
    
end



% determinate the number of modules, which nodes are in which module, the
% name of modules and the modularity of husken (top-down)
[noModules, nodesInMod, nameMod, March] = isThereModulesHuskenTopDown(CWtmp, Wtmp, noInputs, noHidden,noOutputs, ...
    inputs, hidden, outputs, nodes);

% This are inside the previous function
% % top-down weight
% [mHusTopDowWeight, tdw] = modHusken('top-down', CWtmp, noInputs, noHidden,noOutputs, ...
%     inputs, hidden, outputs, nodes, noModules, listNodesMod2,Wtmp)
% 
% % top-down arch
% [mHustopDowArch, tdh] = modHusken('top-down',CWtmp, noInputs, noHidden,noOutputs, ...
%     inputs, hidden, outputs, nodes, noModules, listNodesMod2)


% plot it with modules formed as husken (top-down) 
h = plotANNmod(CWtmp, noInputs, noHidden,noOutputs, inputs, hidden, ...
    outputs, r, nodes, bias, plotModuleBox, noModules, nodesInMod, nameMod);



%% normal plot 
noModules = 1;
nameMod = 1;
nodesInMod = zeros(noNodes,2);
% Initialize the nodesInMod variable
for i=1:noNodes
    nodesInMod(i,:) = [i 1];
end
nodesInMod(noNodes,2) = 0; % in case it is prediction

% plot it
h = plotANNmod(CW, noInputs, noHidden,noOutputs, inputs, hidden, ...
    outputs, r, nodes, bias, plotModuleBox, noModules, nodesInMod, nameMod);


rmpath([pathExp,SLASH,'draw']);
rmpath([pathExp,SLASH,'draw',SLASH,'basicShapes']);
rmpath([pathExp,SLASH,'ANN']);
