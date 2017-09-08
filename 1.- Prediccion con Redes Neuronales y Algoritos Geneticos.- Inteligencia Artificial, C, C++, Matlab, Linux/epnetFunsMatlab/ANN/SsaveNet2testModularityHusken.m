%% script to save the netowrs used to test the Modularity given by husken
%
% Created:      30/09/2010
% Modified at:  
% Author:       Carlos Torres and Victor Landassuri


clear
clc

path1 = pwd;
cd('..');  cd('LinuxOrWindows');
%use adecuate paht
SLASH = isLinOrWin();
cd('..');
pathExp = pwd;
addpath([pathExp,SLASH,'saveNet2txt']);
cd(path1);

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


nodes = ones(1,noInputs + noHidden + noOutputs);
noNodes = size(nodes,2);
bias = zeros(1,noInputs + noHidden + noOutputs);

inputs = 1:noInputs;
hidden = noInputs+1:(noInputs+noHidden);
outputs = (noInputs+noHidden+1):(noInputs+noHidden+noOutputs);


% it is suppose to read this info in C so the vector are put from zero to n
inputs = inputs - 1;
hidden = hidden - 1;
outputs = outputs -1;

% until here I have the same information as the file SmodularityHusken

% create the strucure to call the funtino to save
Network.varN.inputs = noInputs;
Network.varN.finalInp = noInputs;
Network.varN.delays = 1 ;
Network.varN.hidden = noHidden;
Network.varN.VnoOutputs = noOutputs;
% CW
Network.CW = CWtmp;
% W
Network.W = Wtmp;
% DeltaW,  I invent this variable, is not importnat here, so it will be W
Network.DeltaW = Wtmp;

% nodes
Network.nodes = nodes;

% bias
Network.bias = bias;

% sizepos
Network.sizepos = [ noInputs  (noHidden + noOutputs)];

% posinputs
Network.posinputs = inputs;

% poshidden
Network.poshidden = [hidden outputs];

Network.momentum = 0;

Network.lrate = 0.1;

% counter to know how many times has been loaded
Network.varN.counterLoaded = 0;



% call save funtion
name2save = [ path1, SLASH, 'savedTestANNs/r1Net1.txt'];
saveSingleNet2file(name2save, Network);

% savef other times to load  as population and test in the C code, delete
% this if not nedded

name2save = [ path1, SLASH, 'savedTestANNs/r1Net2.txt'];
saveSingleNet2file(name2save, Network);


name2save = [ path1, SLASH, 'savedTestANNs/r1Net3.txt'];
saveSingleNet2file(name2save, Network);

name2save = [ path1, SLASH, 'savedTestANNs/r1Net4.txt'];
saveSingleNet2file(name2save, Network);

name2save = [ path1, SLASH, 'savedTestANNs/r1Net5.txt'];
saveSingleNet2file(name2save, Network);

display('Netwroks saved :)');
rmpath([pathExp,SLASH,'saveNet2txt']);
