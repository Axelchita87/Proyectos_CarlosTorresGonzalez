%% Determinate modules in network for the husken modularity
% Found how many modules could be formed in the network based in the
% modularity of husken top-down version
% Find wich node belong to which node given the dependency d
% calculate top-down modularity (weight and arch.)
%
% Inputs
%   WCtmp
%   Wtmp
%   noInputs
%   noHidden
%   noOutputs
%   inputs
%   hidden
%   outputs
%   nodes
% Outputs
%   noMod           number of modules
%   nodesInMod      list of nodes and module it belongs
%   name            name of modules, 1, 2, ..., n


function [noMod, nodesInMod, nameM, mHustopDowArch] = isThereModulesHuskenTopDown(CWtmp, ...
    Wtmp, noInputs, noHidden,noOutputs, inputs, hidden, outputs, nodes)


allnodes = noInputs + noHidden + noOutputs;
mHustopDowArch = 0;

% fill inital positions with the number of nodes
nodesInMod = zeros(allnodes,2);  % initial value, it may grow in rows

% Initialize the nodesInMod variable
for i=1:allnodes
    nodesInMod(i,1) = i;
end

% for classification or prediction, assuming that classificattion has one
% output per class and predition only has one output, but that could not be
% mantained. So this are just general tags to identify one or other

cont = 0;                                               % count the modules

if noOutputs > 1
    % in this case each output is assigned one module
    % top-down code for assing first outputs to each module
    
    % outputs are bound to a module for the normal classification tasks (each output is assumed to be linlked to a module)
    [noMod, nameM, nodesInMod] = findMod(nodesInMod, outputs);
    
                     
else
    
    [noMod, nameM, nodesInMod] = findLastHidden4mod(nodesInMod, hidden, CWtmp, allnodes);
    
    % modify the ANN to allow the calculation of the modularity.
    % Only do it if there are more than one module
    if noMod > 1
        % Two possible versions
        [CWtmp, outputs, noOutputs, hidden, noHidden] = modifyNet(CWtmp, noInputs, ...
            noHidden, noOutputs, hidden, outputs, nodesInMod, nameM, 'no');

    % All this block is to take into account the weights (the modularity is increased if used this)
%     [CWtmp, outputs, noOutputs, hidden, noHidden, Wtmp] = modifyNet(CWtmp, noInputs, ...
%         noHidden, noOutputs, hidden, outputs, nodesInMod, nameM, 'yes', Wtmp);
%     
%     allnodes = noInputs + noHidden + noOutputs;
%     % Initialize the nodesInMod variable
%     for i=1:allnodes
%         nodesInMod(i,1) = i;
%     end
%     
%     % update nodes
%     nodes = ones(1,allnodes);
%     
%     % recalculate as it was an ANN with two more than one output
%     [noMod, nameM, nodesInMod] = findMod(nodesInMod, outputs);
    
    end
    
end


% Calculate the modularity


% In the top down version I do not in advance if it is classification or
% prediction, thus first I need to deterinate te nuumber of potential
% modules I could have

if noMod > 1
    % top-down weight (to test Exp1 2 and3 Inidensity I will not use this)
    % uncomment later
    [mHusTopDowWeight, tdw, nodes] = modHusken('top-down', CWtmp, noInputs, noHidden,noOutputs, ...
        inputs, hidden, outputs, nodes, noMod, nodesInMod, nameM, Wtmp)
    
    % top-down arch
    [mHustopDowArch, tdh, nodes] = modHusken('top-down',CWtmp, noInputs, noHidden,noOutputs, ...
        inputs, hidden, outputs, nodes, noMod, nodesInMod, nameM);
    
    
    % determinate to which module each node belong give the dependency d for
    % the weighted case
    
    
    contAddMod = 0;
    for i = 1:allnodes - noOutputs
        if nodes(1,i) ~= 0
            [MAX,pos] = max(tdw(i,:));      % NOTE originaly it was tdw, for exp1,2,3 initialization
            nodesInMod(i,2) = pos;          % I use tdh
        else
            nodesInMod(i,2) = -2;     % they are nodes not connected to nothid or disabled
                                        % so they are out in another module
                                        % if fall an input here, the module
                                        % is deleted ahead because inputs
                                        % are not considered to plot in
                                        % modules, bu is leave here because
                                        % ahead the inputs could be plotted
                                        % inside the box of the module
            contAddMod = 1;
        end    
    end
    
    if contAddMod == 1                  % update number of module and their name
        noMod = noMod + 1;
        nameM(1,noMod) = -2;
    end
    
    
else
    % I do this to allow the plot function plot all nodes into the screen
    % just note that there could be just a few connections
    noMod = 1;
    nameM = 1;
    for i = 1:allnodes
        nodesInMod(i,2) = 1;
    end
    nodesInMod(allnodes,2) = 0;
end
