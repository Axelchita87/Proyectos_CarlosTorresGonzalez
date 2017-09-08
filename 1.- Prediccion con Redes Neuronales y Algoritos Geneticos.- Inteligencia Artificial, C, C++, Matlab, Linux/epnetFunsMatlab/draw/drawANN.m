%% Draw a normal ANN (no modules)
% Plot into the scren all nodes of an ANN with its connections
%
% Created:      Sep 2010
% Modified at:  23 Sep 2010
% Author:       Carlos Torres and Victor Landassuri 




function drawANN(allrun,corrida,pathExp,SLASH,TSname)

plotModuleBox = 0;



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

% obtain stiles
% determinate colors for each object in the figure:
%stiles = obtainNetStiles('normal');   % normal, module



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



% use the same function to plot the ANNs modules but all is put in one
% module

noModules = 1;
nameMod = 1;
nodesInMod = zeros(n.allnodes,2);
% Initialize the nodesInMod variable
for i=1:n.allnodes
    nodesInMod(i,:) = [i 1];
end
nodesInMod(n.allnodes-n.noOutputs+1:n.allnodes,2) = 0; % put outputs to module zero

% plot it
h = plotANNmod(n, plotModuleBox, 'normal',noModules, nodesInMod, nameMod);




% put title to the figure
string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16);

% save
saveas(h, 'architectureANNBest.fig');

clf
% delete added paths
cd('..')
%rmpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'ANN']);
rmpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'draw',SLASH,'basicShapes']);

