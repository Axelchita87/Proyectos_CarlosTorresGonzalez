%% Draw the ANN with modules
% Plot the best ANN as a graph traying to determinate modules in the
% ANN
%
% Tthis scritp could be converted to a derived class form the script drawANN
% Created:  23 Aug 2010
% Modified: 23 Sep 2010
% Author:   Carlos Torres and Victor Landassuri

%% Set up fisrt parameters and obtain the best over all runs


plotModuleBox = 1;



addpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'draw',SLASH,'basicShapes']);
%addpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'ANN']);

% enter to the dir to save figures
if(exist('figs','dir') ~= 7)
    mkdir('figs');
end
cd('figs')


% obtain who is the best of all runs
[minimo, pos] = obtainBest_of_Best(allrun);

% obtain parameters of best individual form all runs
n = ontainParam_best(allrun, pos);
n.r = 2.5;      % radious of nodes




% organization
% 1) all inputs are in the bottom of the figure
%
% 2) hidden nodes are plot in diagonal (incrementing to the right)
%       distributed in one or more rows
%   2.1) The hiden nodes are sorted in modules
%   2.2) Maximum number of modules = noOutputs + 1; plus 1 cause there
%   could be the nodes that share a module (my verision with shared modules)
%       2.2.1) using the husken metric (top-down), for classification it is
%       used the number of outputs as modules there shuld be, and for
%       prediction it is used the last hidden nodes that connect to the
%       last node but not connected to another node.
%   2.3) If there are many hidden neurons in the ANN or module, the are
%   split in rows, so they are divided into 2, 3, ..., untill the fit in
%   the given space allocated for the module/ANN
%
% 3) outputs nodes are at the top of the figure, if there are more than one
% output and previous outputs are connected to actual output, then plot
% them in a diagonal incrementing to the right.



% This is my algorithm to deterct module
% if modules are detected then the node will be printed in the same side
% of the outputs it belongs
% Pseudocode
% 1) for node m to m+l-1
%   2)  check that node m is connected with output n
%   3)  if node m does not have a connection with output n+k then
%           node m belongs to module Mm
%       else
%           node m belongs to shared module Mshared
%
% else (no modules detected)


% Other algorithm to detect modules as husken do (top-down version):
%
% 1) for classification, each output will represent a module
% 2) for prediciton, the last hidden nodes that connect to the output node 
% if it doues not connect to another hidden node, then it is associated to
% a module such node.
% 3) Having the number of modules and the nodes (last or not) that belong
% to them start to determinate the dependency of each neuron to each module
% (d) with the weighted modularity of husken



% initial coordinate to start drawing the fisrt node
% all nodes will be centered in (0,0) to have a reference
% rule  node    offset  formula
%       1       0       2.5 x 0 = 0;  center - offest
%       2       2.5     2.5 x 1 = 1;
%       3       5       2.5 x 2 = 5;
%       4       7.5     2.5 x 3 = 7.5;
% . . .
% so, final formula = -1 * (2.5 * Nonode-1);  // * -1 to make it negative


% obtain information from the allrun for noModules, nodesInMod, nameMod
% So I do not calculate here the Mweight neither the dependency d to plot
% the modules

% normal modules from the weighted modularity
n.nodesInMod = allrun{1,pos}.Network{1,1}.huskenModule.nodesInModule;
n.nameMod = allrun{1,pos}.Network{1,1}.huskenModule.nameModule;
n.noModules = size( n.nameMod, 2);

% modules focusing only in shared nodes
n.nodesInModSHARED = allrun{1,pos}.Network{1,1}.sharedModule.nodesInModule;
n.nameModSHARED = allrun{1,pos}.Network{1,1}.sharedModule.nameModule;
n.noModulesSHARED = size( n.nameModSHARED, 2);


% sum one to the node to start in 1
% this values will also be only used in the 'module' option when print them
n.nodesInMod(:,1) = n.nodesInMod(:,1) + 1;
n.nodesInModSHARED(:,1) = n.nodesInModSHARED(:,1) + 1;

%% Plot into screen the ANN with SHARED modules 

h = plotANNmod(n, plotModuleBox, 'normal', n.noModulesSHARED, n.nodesInModSHARED, n.nameModSHARED);
% put title to the figure
string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16);
% save
saveas(h, 'archANNSharedModuBest.fig');
clf


%% Plot the ANN with the modules formed as the modularity of husken
%plot into screen the ANN with husken modularity top-down
% determinate the number of modules, which nodes are in whci module, the
% name of modules and the modularity of husken (top-down)
%[noModules, nodesInMod, nameMod] = isThereModulesHuskenTopDown(CW, W, noInputs, noHidden,noOutputs, ...
%     inputs, hidden, outputs, nodes);

h = plotANNmod(n, plotModuleBox, 'normal',n.noModules, n.nodesInMod, n.nameMod);
% put title to the figure
string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16);
% save
saveas(h, 'archANNmoduleBestTopDown.fig');
clf



%% New way to plot the ANNs
% Each module have a different color, the shared conn are remarked and
% other reatures
h = plotANNmod(n, plotModuleBox, 'module',n.noModules, n.nodesInMod, n.nameMod);
% put title to the figure
string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16);
% save
saveas(h, 'archANNmoduleBestTopDown2.fig');
clf




%% Another way to plot the ANNs, using 3D ver1
% Each module have a different color, the shared conn are remarked and
% other reatures, also it is used the 3D fature to separate layers

% % % comment to avoid errors in some runs 26 Feb 2012
%h = plotANNmod(n, plotModuleBox, 'module3D1',n.noModules, n.nodesInMod, n.nameMod);

% put title to the figure
string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16);
% save
saveas(h, 'archANNmoduleBestTopDown3Dv1.fig');
clf


% exit directory
cd('..')


% delete added paths
%rmpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'ANN']);
rmpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'draw',SLASH,'basicShapes']);


% Clear some variables
clear Module



