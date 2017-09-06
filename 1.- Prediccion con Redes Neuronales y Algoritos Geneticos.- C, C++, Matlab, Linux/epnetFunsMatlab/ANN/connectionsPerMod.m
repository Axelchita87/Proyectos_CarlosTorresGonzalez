%% Function to count the connections in a network 
% Shared, strong and taking into account if the inputs are considered or
% not into themodularity
%
% Created: 9 Agu 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%% Fuction
function conn = connectionsPerMod(nodesInModule, lookFor, inp, hidden, ...
                output, CW, considerInputsInMod)
% inputs:
% nodesInModule  a list with all nodes and the module they belong, 1, 2,
%                   ..., -1 is shared and -2 is isolated
% lookFor       is the name of the module to look for, -1 = shared connections
%                % 1 = module 1, 2 = module 2,...
% inp           the number of inputs
% hidden        the hidden nodes
% output        the output nodes
% CW            connectivity matrix
% considerInputsInMod   to know if th inputs are taken into acocunt or not
%
% outputs:
% connections   The number of connecitons 

if considerInputsInMod == 1
    vec = 1:inp+hidden+output;
elseif considerInputsInMod == 0
    vec = inp+1:inp+hidden+output;
end

conn = 0;

if lookFor == -1
    % shared connections
    for i = 1:inp+hidden+output
        for j = vec
            if CW(i,j) == 1
                if nodesInModule(i,2) ~= nodesInModule(j,2) &&  nodesInModule(i,2) ~= -2 &&  nodesInModule(j,2) ~= -2
                    % if they from different module and not consider shared
                    % conenction to isolated nodes
                    conn = conn + 1;
                end
            end
        end
    end
    
else
    % case in which we are looking for the nodes per module, lookfor has
    % the module to look for
    for i = 1:inp+hidden+output
        for j = vec
            if CW(i,j) == 1
                if (  ( nodesInModule(i,2) == nodesInModule(j,2) ) && ( nodesInModule(i,2) == lookFor ) ) 
                    % if it is strog connection and is from the same module
                    % we are looking for 
                    conn = conn + 1;
                end
            end
        end
    end
    
    
end
