%% Find modules for networks with only one output
% This function determinates how many modules coluld be created taking into
% account the connectivity matrix and analysing if one hidden nodes is only
% connected to the output node
%
% Author:       Carlos Torres and Victor Landassuri
% Date:         20/09/2010
% Modified at: 
%
% Algorithm:
%   Repeat for all hidden nodes
%   if hidden node n is connected only with output node m then
%       create a new module m
%       node n belongs to module m
%
% Thast is the only that matters, if a hidden node is connected to another 
% hidden node it automatically falls inside one module.

%% Function
function [noMod, nameM, nodesInMod] = findLastHidden4mod(nodesInMod, ...
    hidden, CW, allnodes, inputs)

% Inputs
%   nodesInMod      Iinitial empty list in column 2 that says which node
%                   belong to a given module.
%   hidden          vector with the hidden nodes
%   CW              Connectivity matrix
%   allnodes        number of all nodes in the network.
%   inputs (optional)    If given, it indicates that the inputs are taken
%                   into account to be part of the nodes that can create a
%                   module. This could be useful for the case in wich one
%                   input is connected directly to one output.
% Outputs
%   noMod           number of modules that will be created.
%   nameM           name of the moduels, each possition has the name of
%                   each one, in principle they will strst in 1 to n, so
%                   the possition 1 has the name 1, nameM(1,2) = 2, ...
%   nodesInMod      Updated list with the final nodes that are bounded to a
%                   module. The list is sorted, so the first node found
%                   that create a module is assosiated witht he first
%                   module and so on

% Local variables
cont = 0;
nameM = 0;

% Determinate if the inputs are considered to take into account
if nargin == 5
    vec = [ inputs hidden ];
    % maybe it is not agood idea let an input be a module because it is
    % quite probable that this output has other nodes, so the input could
    % fall into this set without problem, instead of that there will be
    % many nodes. This is the problem commented in the pappers that used a
    % graph represntation to determinate subredes, where there should ba a
    % parameter to determinate the level of modules required (many modules or small amount)
else
    vec = hidden;
end

% Find the last nodes that can be bound to a module
for i = vec
   SUM = 0;        % sum to check that this node is only connected to the output
   
    if CW(i,allnodes) == 1
        % only cares about output connections from the actual node
        % (columns)
        SUM = sum(CW(i, i+1:allnodes-1 ) );
        
        if SUM == 0          % new module
            cont = cont + 1;
            nodesInMod(i,2) = cont;
            nameM(cont) = cont;
        end
    end
end
noMod = cont;
