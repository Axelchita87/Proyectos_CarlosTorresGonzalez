%% Recursive function to see if a node is connected directly or indirectly
% recursive funtion to determinate which node belongs to
% each module with my metric (only a path from one node to only one output)
%
% returns the number of connections to output nodes 
% and the last output node found (connected)
% 
% It can be used too, to determinate if the node is isolated, i.e. not
% connected to any output, in that case it is returned zero in num variable
%
% Created around    Sep 2010
% Modified at:      7 Oct 2010
% Author:           Carlos Torres and Victor Landassuri
%


%% Main function that call another recursive
function [nodesInMod] = isConnected2Output(nodesInMod, CW,noHid, ...
    noOut, inputN, hiddenN, outputN, allnodes)

    vec = [inputN hiddenN];
    hiddenRev = vec(end:-1:1);
    for i=hiddenRev
        
        % recursive function to know if this node have a path to an output
        % node
        [noOutputConn, connectTo] = isConnected2OutputRec(CW,i,noHid, noOut, hiddenN, outputN);
        
        if noOutputConn == 1                            % if only is conencted to an output
            nodesInMod(i,:) = [i connectTo];
        elseif noOutputConn > 1                            % if conencted to more than one, shared node
            nodesInMod(i,:) = [i -1];
        elseif noOutputConn == 0                            % isolate node from here to outputs 
            nodesInMod(i,:) = [i -2];
        end
        %contMnode = contMnode + 1;
    end



%% Recirsive function
function [num, connTo] = isConnected2OutputRec(cw,node,noHidden, noOutputs, hidden, outputs)
% Recursive function to determinate if there is a path form node i to any
% output


%display(['node =', num2str(node) ]);

% for any hidden nodes check directly against the outputs
num = 0;
connTo = 0;
for i=outputs
    if cw(node, i) == 1
        num = num + 1;
        connTo = i;         % this value is useless if num > 1, but at least it is
    end                     % known that it is a shared neuron
end

if num > 1      % from the beginning, if it is connected to more that one output, mark it as shared neuron
    return
else
    % test other nodes where there is aconnection from this to them
    for i = node+1:hidden(size(hidden,2))
        if ( cw(node,i) == 1 ) %&& ( node ~= hidden(size(hidden,2)) )
            [numtmp connTo] = isConnected2OutputRec(cw,i,noHidden, noOutputs, hidden, outputs);
            num = num + numtmp;
        end
        if num > 1
            break
        end
    end
end
