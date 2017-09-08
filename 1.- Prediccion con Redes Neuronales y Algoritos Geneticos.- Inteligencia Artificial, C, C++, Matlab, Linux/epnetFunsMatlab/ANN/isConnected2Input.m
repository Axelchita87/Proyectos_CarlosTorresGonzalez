%% Recursive function to see if a node is connected directly or indirectly
%% to an input
% recursive funtion to determinate which node belongs to an input this is
% the complement to the funtion isConnected2Output
% 
% This function only works to say if the nodes is isolated, because it
% finish in the fisrt input is connected, inppreve it if yopu want to know
% how many connectios there are to inputs fron the actual node
% 
% It can be used too, to determinate if the node is isolated, i.e. not
% connected to any inputs, in that case it is returned 0 in num variable
%
% Created around    12 Oct 2010
% Modified at:      
% Author:           Carlos Torres and Victor Landassuri
%


%% Main function that call another recursive
function [nodesInMod] = isConnected2input(nodesInMod, CW,noInp, noHid, ...
    noOut, inputs, hidden, outputs, allnodes)

    vec = [hidden outputs];
    %hiddenRev = vec(end:-1:1);
    for i=vec %hiddenRev
        
        % recursive function to know if this node have a path to an output
        % node
        [noOutputConn, connectTo] = isConnected2InputRec(CW,i,noInp,noHid, noOut, inputs, hidden, outputs);
        
        if noOutputConn == 1                            % if only is conencted to an output
            nodesInMod(i,:) = [i connectTo];
        elseif noOutputConn > 1                            % if conencted to more than one, shared node
            nodesInMod(i,:) = [i -1];
        elseif noOutputConn == 0                            % isolate node from here to inputs 
            nodesInMod(i,:) = [i -2];
        end
        %contMnode = contMnode + 1;
    end



%% Recirsive function
function [num, connTo] = isConnected2InputRec(cw,node,noInput, noHidden, noOutputs, inputs, hidden, outputs)
% Recursive function to determinate if there is a path form node i to any
% input

% display(['node =', num2str(node) ]);

% for any [hidden output] nodes check directly against the inputs
num = 0;
connTo = 0;
for i=inputs
    if cw(i,node) == 1
        num = num + 1;
        connTo = i;         
    end                     
end

if num >= 1      % from the beginning, if it is connected to more that one output, mark it as shared neuron
    return
else
    % test other nodes where there is aconnection from this to them
    for i = hidden(1,1):node-1
        if ( cw(i,node) == 1 ) %&& ( node ~= hidden(size(hidden,2)) )
            [numtmp connTo] = isConnected2InputRec(cw,i,noInput,noHidden, noOutputs, inputs, hidden, outputs);
            num = num + numtmp;
        end
        if num >= 1
            break
        end
    end
end
