%% Function to count the nodes of a module that could be
% Shared, strong or isolated
%
% Created: 9 Agu 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%% Fuction
function nodes = nodesPerMod(nodesInModule, lookFor, inp, hidden)
% inputs:
% nodesInModule  a list with all nodes and the module they belong, 1, 2,
%                   ..., -1 is shared and -2 is isolated
% lookFor       is the name of the module to llok for, -2,-1,1,2,...
% inp           the number of inputs
% hidden        the hidden nodes
%               Normally inpus and hiiden are not counted to this
%
% outputs:
% nodes          The number of nodes found in the network


toCount = inp+1 : inp+hidden;
nodes = size ( find( nodesInModule(toCount,2) == lookFor ), 1 );