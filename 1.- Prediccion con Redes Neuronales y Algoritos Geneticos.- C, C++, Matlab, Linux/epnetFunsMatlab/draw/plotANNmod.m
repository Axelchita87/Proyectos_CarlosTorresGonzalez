%% Plot the ANN into screen using module approach
% Thus function plot an ANN into the screen and separate automatically the
% number of modules inside the ANN.
% Here is not assumed any previous informatin of modules in the network
%
% Author:       Carlos Torres and Victor Landassuri
% Created:      20/08/2010
% Modified at:  20/09/2010
%
%
% It is used two different ways to plot them.
% 1) with the metric I created, i.e. one node belong to a module if this
%   node only contribute to the same module
%   If not, the module belong to a shared module marked as module -1 (name)
%
% 2) It is used the husken modularity to determinate the contribution of
%   each neuron to each work
%
% For classification, it is assumed that the number of modules are the
% number of n.outputs.
%
% For prediction it is used the last n.hidden n.nodes that connect only to the
% output node to create a module bounded to the given n.hidden node.
%
%
% The variable nodesInMod contain a list of all n.nodes in the network.
%   At the beginnig it only have the n.nodes that create a module, at the end
%   of the precces it has the module each node belong that could be from 1
%   to n, if it used a negative value, i.e. -1, it is assumed that this is
%   a shared module and therefore it is used my modularity funtion to plot
%   into the screen
%
% The husken modularity is used to plot the neurons inside the module
% accordingly the pureness of the neuron using the variable d formt he
% metric



%% Fuction to plot
function h = plotANNmod(n, plotModuleBox, type, noModules, nodesInMod, nameMod)
% Inputs
% If I do not pass noModules and the other two, it means that they were not assigned before
% so it can be over ridden to normal values

% Outputs
%



% detect modules and create them with my metric (shared modules)
if nargin == 3
    [noModules, nodesInMod, nameMod] = isThereModules(n.CW, n.noInputs, n.noHidden,n.noOutputs, ...
        n.inputs, n.hidden, n.outputs, n.nodes);
    
    % mantain a copy in network
    % this values will be only used in the 'module' option below to plot them
    n.noModules = noModules;
    n.nodesInMod = nodesInMod;
    n.nameMod =nameMod;
    % as I do not knwo if it was the weigted modularity or for the shared
    % nodes, I replace both
    n.noModulesSHARED = noModules;
    n.nodesInModSHARED = nodesInMod;
    n.nameModSHARED =nameMod;
end

% create the modules
if noModules > 0
    Module = createMod(noModules, n.r, nameMod);
    
    
    % obtain coordinates for each class: n.inputs, n.hidden (modules), n.outputs
    [Module, coord, noModules] = obtainCoordinates(Module,noModules, nodesInMod, ...
        n.noInputs, n.noHidden, n.noOutputs, n.inputs, n.hidden, n.outputs, n.r, n.CW);
    
    
    
    
    % create the figure
    %set(gcf, 'Visible', 'off')
    h = figure; %('Visible', 'off');
    
    
    
    
    % what kind of plot was selected
    
    if strcmp(type,'normal') || strcmp(type,'modulePlain')
        stiles = obtainNetStiles('normal');   % normal
        plotNormalANN(n,coord,stiles,plotModuleBox,noModules,Module,h);
        
        % leave it as a squered axis
        if noModules < 2
            minX = min(coord(:,1)) - n.r * 3;
        else
            minX = min(coord(:,1)) - n.r * 3;
        end
        
        maxX = max(coord(:,1)) + n.r *5 + n.r;
        minY = min(coord(:,2)) - n.r * 2;
        maxY = max(coord(:,2)) + n.r * 5 + n.r;
        
        disX = maxX - minX;
        disY = maxY - minY;
        
        axesSize = [minX maxX minY maxY];
        
        %     if disY < disX
        %         dif = (disX - disY) / 2;
        %         axesSize = [minX maxX (minY-dif) (maxY+dif)];
        %     else
        %         dif = (disY - disX) / 2;
        %         axesSize = [(minX-dif) (maxX+dif) minY maxY];
        %     end
        
        
        daspect([1,1,1])
        axis(axesSize);
        
        
    elseif strcmp(type,'module')
        stiles = obtainNetStiles('module',noModules);  % to have it repeated for modules
        plotModuleANN(n,coord,stiles,plotModuleBox,noModules,Module,h);
        % leave it as a squered axis
        if noModules < 2
            minX = min(coord(:,1)) - n.r * 5;
        else
            minX = min(coord(:,1)) - n.r * 5;
        end
        
        maxX = max(coord(:,1)) + n.r *10 + n.r;
        minY = min(coord(:,2)) - n.r * 2;
        maxY = max(coord(:,2)) + n.r * 5 + n.r;
        
        disX = maxX - minX;
        disY = maxY - minY;
        
        axesSize = [minX maxX minY maxY];
        
        %     if disY < disX
        %         dif = (disX - disY) / 2;
        %         axesSize = [minX maxX (minY-dif) (maxY+dif)];
        %     else
        %         dif = (disY - disX) / 2;
        %         axesSize = [(minX-dif) (maxX+dif) minY maxY];
        %     end
        
        
        daspect([1,1,1])
        axis(axesSize);
        
        
    elseif strcmp(type,'module3D1')
        
        
        stiles = obtainNetStiles('module3D1',noModules);  % to have it repeated for modules
        plotModuleANN3D1(n,coord,stiles,plotModuleBox,noModules,Module,h);
        
    end
    
    
    
    
    box on
    %Ycolor
    set(gca,'Color','white','XColor','white','YColor','white','ZColor','white')
else
    h = clf
end
