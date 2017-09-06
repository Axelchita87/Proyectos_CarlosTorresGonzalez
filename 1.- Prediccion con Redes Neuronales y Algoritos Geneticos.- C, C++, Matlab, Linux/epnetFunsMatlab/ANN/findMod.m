%% Find Modules for networks with more than one output
% Funtion to obtain the number of modules/outputs in the network
% top-down code for assing first outputs to each module
% 
% In special cases (what and where, ...) the outputs nodes could be
% partitioned, so it those cases it is load such partition
%
% Created:      Sep 2010
% Modified at:  23 Sep 2010
% Author:       Carlos Torres and Victor Landassuri
%



%% Function
function [noMod, nameM, nodesInMod] = findMod(nodesInMod, outputs)

cont = 0;
nameM = 0;


% load file, just for the what and where case, in the other
% classification tasks it canbbe calculated with the function findMod
%load the name of the TS

if(exist('../txtFiles/TSname', 'file') == 2)   % Check if the file exist
    
    fid = fopen('../txtFiles/TSname', 'r');
    TSname = fgetl(fid);
    if (fclose(fid) ~= 0)
        display('error closing file');
    end
    
else
    TSname = '';
end


% in the first case only is tested the what and where
if(exist(['../txtFiles/nameModules'],'file') == 2) % old lineif strcmp(TSname, 'WhatAndWhere') == 1
    nameM = load('../txtFiles/nameModules');
    noMod = size(nameM,2);
    tmp = load('../txtFiles/outputsInMod');
    
    sizetmp = size(tmp,2);
    sizeNodesInM = size(nodesInMod,1);
    
    % update the outputs
    nodesInMod(sizeNodesInM-sizetmp +1 : sizeNodesInM ,2) = tmp;
    

    
else % default option if the files do not exist
    % each output is assigned to a module, so there is
    % many modules and outputs nodes
    
    for i = outputs
        cont = cont + 1;
        nodesInMod(i,2) = cont;         % update list of nodes
        nameM(cont) = cont;             % save name of module
    end
    noMod = size(outputs,2);                  % how many modules
    
end

