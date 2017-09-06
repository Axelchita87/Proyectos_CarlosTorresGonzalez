%% Find moduels in ANNs
%
% This has an error, it was the first programmed, but it is better if the
% modules for prediciton are created with the husken metric
%
% Find if the are cluster of nodes that are connected to a single output
% This version looks for modules and shared modules (nodes that contribute
% to more than one output) 
%
% Created:  23/08/2010
% Modified: 16/09/2010
% Author:   Carlos Torres and Victor Landassuri
%
% inputs:
%   CW          The connectivity matrix
%   noInputs    number of inputs
%   noHiden     number of Hidden nodes
%   noOutputs   number of outputs
% outputs:
%   M           The modules created
%   noMod       number of modules
%   nodesMod         a list of nodes with the module they belong
%
% By default the module k is for otuput k, and module k+1 is for the shared
% module
%
% There may be many modules and shared modules
% A moduel is considered a node or a set of nodes that only have a
% connection to a sigle output (useful for classification)
%
% A shared module could be any set of nodes that are connected to more than
% one nodes/outputs
%
% Format of M: (1,2) vector, pos 1 = node, pos 2 = module that it belongs,
% it is represeted by the output number the module,
%
% usage
%   [M, noM, listM] = isThereModules(CW, noInputs, noHidden, noOutputs, ...
%    inputs, hidden, outputs)

function [noMod, nodesInMod, nameM] = isThereModules(CW, noInputs, noHidden, noOutputs, ...
    inputs, hidden, outputs, nodes)

%% Organize nodes by modules
% Check the connection from a hidden nodes to outputs nodes and acomodate them
% in a list, each list will be a module, that basic scenarion is to have
% three, 1) module A, b) module B and c) shared module, but there could be
% more or less.

contMnode = 1;
noMod = 0;
contShared = 0;
contNonConnected = 0;
allnodes = noInputs + noHidden + noOutputs;

% fill inital positions with the number of nodes
nodesInMod = zeros(allnodes,2);  % initial value, it may grow in rows

% Initialize the nodesInMod variable
for i=1:allnodes
    nodesInMod(i,1) = i;
end


% reverse the hidden vector
% hiddenRev = reverseVec(hidden);  % old line/function
%hiddenRev = hidden(end:-1:1);

if noOutputs > 1                            % for networks with clearly identifyed modules
    
    % Part to test if the husken modularity can be used to determinate the
    % modules in this part
    
    % First check spacial cases like the what and where, in this data set
    % the fisrt 9 outputs belong to the module 1 and trhe other 9 to the
    % module 2
    
   % outputs are bound to a module for the normal classification tasks (each output is assumed to be linlked to a module)
   [noMod, nameM, nodesInMod] = findMod(nodesInMod, outputs);
   

else                                    % for networks with only one output
    
    % Cause the network only have one output, I need to look for the hidden
    % nodes that only connect to the output to say that they will be last
    % nodes that connect to the module. This is my version to determinate /
    % associate (last) hidden nodes to modules
    
    [noMod, nameM, nodesInMod] = findLastHidden4mod(nodesInMod, hidden, CW, allnodes);
   
    % modify the ANN to allow the calculation of the modularity
    % Two possible versions
    if noMod > 0
        [CW, outputs, noOutputs, hidden, noHidden] = modifyNet(CW, noInputs, ...
            noHidden, noOutputs, hidden, outputs, nodesInMod, nameM, 'no');

%       [CW, outputs, noOutputs, hidden, noHidden] = modifyNet(CW, noInputs, ...
%           noHidden, noOutputs, hidden, outputs, nodesInMod, nameM, 'yes');
    end
    
end


% top-down arch, this can say if one neuron only contribute to one
    % output
    [mHustopDowArch, tdh, nodes] = modHusken('top-down',CW, noInputs, noHidden,noOutputs, ...
        inputs, hidden, outputs, nodes, noMod, nodesInMod, nameM);
    
    % Final step, decide if it is a pure neuron or not
    % Here it does not matter if there is deactivated neurons, they fall
    % in the shared case
    for i = 1:allnodes - noOutputs
        [MAX,pos] = max(tdh(i,:));
        if MAX == 1
            nodesInMod(i,2) = pos;
        else
            nodesInMod(i,2) = -1;       % mark to say that is in the shared module
            contShared = 1;
        end
        if nodes(1,i) == 0
            nodesInMod(i,2) = -2;            % nodes note connected
            contNonConnected = 1;
        end
    end

    % determinate if there is a shared module
    if contShared == 1
        noMod = noMod + 1;
        nameM(1,noMod) = -1;
    end
    
    % determinate if there is a non connected module 
    if contNonConnected == 1
        noMod = noMod + 1;
        nameM(1,noMod) = -2;
    end
    
    % Check that a module is not empty, if that is the case the module is
    % deleted
    contR = 0;
    toRemove = 0;
    
    for i = 1:noMod
        if ~ismember(nodesInMod(1:(noInputs + noHidden),2), nameM(1,i))
            noMod = noMod -1;  % there could be an errro here, decrement this while is used in the for
            contR = contR + 1;
            toRemove(1,contR) = i;
        end
    end
    if toRemove ~= 0
        nameM(toRemove) = [];  % delete from the vector
    end


    
    
    
    
    
    
    
    
    
            
    
    
    
% Old code using a recursive funtion to determinate which node belongs to
% each module with my metric (only a path from one node to only one output)
%
%     for i=hiddenRev
%         
%         % recursive function to know if this node have a path to an output node
%         % Maybe I can now if there is a path to more than two output nodes
%         % witht he husken modularity. Check it....
%         [noOutputConn, connectTo] = isConnected2Output(CW,i,noHidden, noOutputs, hidden, outputs);
%         
%         if noOutputConn == 1
%             nodesInMod2(contMnode,:) = [i connectTo];
%         else
%             nodesInMod2(contMnode,:) = [i outputs(noOutputs)+1];
%         end
%         contMnode = contMnode + 1;
%         
%         
%     end
%     
%     
%     
%     %% Determinate the number of modules used
%     %
%     % check outputs
%     for i=outputs
%         if ismember(i,nodesInMod2(:,2))
%             noMod2 = noMod2 + 1;
%             nameMod2(1,noMod2) = i;
%         end
%     end
%     
%     % Check sheared modules
%     if ismember(outputs(size(outputs,2))+1, nodesInMod2(:,2))
%         noMod2 = noMod2 + 1;
%         nameMod2(1,noMod2) = outputs(size(outputs,2))+1;
%     end
    
    
    
    
% %% Reverse a vector
% % Take a vector and put it in reverse order
% 
% function vecRev = reverseVec(vec)
% 
% % like a c code
% sizeVec = size(vec,2);
% cont = 1;
% 
% vecRev = zeros(1,sizeVec);
% 
% 
% for i = sizeVec:-1:1
%     vecRev(1,cont) = vec(1,i);
%     cont = cont + 1;
% end
% 
% % in matlab format 
% % hidden2 = hidden(end:-1:1)






%%% Is a path to an output node
% % Check if from this node there is path to an output node, returns the
% % number of connections to output nodes and the last output node found (connected)
% 
% 
% function [num, connTo] = isConnected2Output(cw,node,noHidden, noOutputs, hidden, outputs)
% % Recursive function to determinate if there is a path form node i to any
% % output
% 
% 
% display(['node =', num2str(node) ]);
% 
% % for any hidden nodes check directly against the outputs
% num = 0;
% connTo = 0;
% for i=outputs
%     if cw(node, i) == 1
%         num = num + 1;
%         connTo = i;         % this value is useless if num > 1, but at least it is
%     end                     % known that it is a shared neuron
% end
% 
% if num > 1      % from the beginning, if it is connected to more that one output, mark it as shared neuron
%     return
% else
%     % test other nodes where there is aconnection from this to them
%     for i = node+1:hidden(size(hidden,2))
%         if ( cw(node,i) == 1 ) %&& ( node ~= hidden(size(hidden,2)) )
%             [numtmp connTo] = isConnected2Output(cw,i,noHidden, noOutputs, hidden, outputs);
%             num = num + numtmp;
%         end
%         if num > 1
%             break
%         end
%     end
% end





