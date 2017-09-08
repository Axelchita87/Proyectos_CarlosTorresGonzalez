%% Modify ANN to allow modularity calculatin for networks with one output
% The networks is modified the allow appliy the husken modularity when the
% ANN only have one output
%
% Created:      20/09/2010
% Modified at:  
% Author:       Carlos Torres and Victor Landassuri
%
% Two variations
% 1) it matters the last weights from the hidden nodes (new outputs) to the
%       original output node
% 2) It does not matter the weights
%
% In fact one of this versions will be run only one time to see if there is
% a difference in the modularity measure.
%
% usage:
% [CW, outputs, noOutputs, hidden, noHidden] = modifyNet(CW, noInputs, ...
%        noHidden, noOutputs, inputs, hidden, outputs, nodesInMod, nameM,'no');

%% Function
function [CW, outputs, noOutputs, hidden, noHidden,W] = modifyNet(CW, noInputs, ...
    noHidden, noOutputs, hidden, outputs, nodesInMod, nameM, wMatter, W)
%
% Inputs:
%
% Outputs
%

allnodes = noInputs + noHidden + noOutputs;


% determinate if the weights matter or not
if strcmp(wMatter,'no')
    
    % I think here it does not matter the last node, so it can be deleted
    % and updated all the archiecture
    CW(allnodes,:) = [];
    CW(:,allnodes) = [];
    
    % update output nodes
    outputs = [];
    toRemove = 0;
    contOut = 0;
    contHid = 0;
    for i = hidden
        contHid = contHid + 1;
        if ismember(nodesInMod(i,2),nameM(:));
            contOut = contOut + 1;
            outputs(1,contOut) = i;
            toRemove(1,contOut) = contHid;          % obtain the index of the hidden ndoes to remove
        end
    end
    noOutputs = contOut;
    
    % update hidden nodes
    hidden(toRemove) = [];
    noHidden = noHidden - noOutputs;
    
elseif strcmp(wMatter,'yes') && ( nargin == 10 )
    % This part is to take into account the last weight from the last
    % hidden nodes that connect to the output
    
    % after found the number of modules
    % make a temporal change to the network
    % the new outputs are the nodes selected for modules
    
    % the connections that matther all are in the last hidden node in the
    % nodes to replicate
    nodeCopy = 0;
    cont = 0;
    for i = hidden
        if ismember(nodesInMod(i,2), nameM(:))
            cont = cont + 1;
            nodeCopy(1,cont) = i;
        end
    end
    
    % replicate the last node
    cont = allnodes + 1;
   
    for i = size(nameM,2) - 1
        % columns 
        CW(:,cont) = CW(:,cont-1);
        CW(cont,:) = CW(cont-1,:);
        
        W(:,cont) = W(:,cont-1);
        W(cont,:) = W(cont-1,:);
    end
    
    % update the rest of the var
    contM = 1;
    for i = allnodes:allnodes + (size(nameM,2) - 1)
        outputs(1, contM) = i;
        contM =  contM  + 1;
    end
    noOutputs = size(nameM,2);
    
    allnodes = allnodes + (size(nameM,2) - 1);  
    % delete the extra connections copied
    cont = outputs(1,1);
    for i = nodeCopy
        for j=outputs
            if j~= cont
                CW(i,j) = 0;
                W(i,j) = 0;
            end
        end
        cont = cont + 1;        % counter to link the output to the node2copy
    end
    
end

