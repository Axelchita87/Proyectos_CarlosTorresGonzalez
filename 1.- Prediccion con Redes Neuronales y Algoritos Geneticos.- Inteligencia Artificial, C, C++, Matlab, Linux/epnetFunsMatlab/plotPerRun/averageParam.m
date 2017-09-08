%% Plot the average parameters for each generation 
% It is plotted the av, std and ste
%
% Accuracy
% NRMSE
% Connections
% Hidden nodes
% Inputs
% Mutations
% Worst Average and Best fitness
%
% Created:  around 2008
% Modified: 22 Feb 2011
% Author:   Carlos Torres and Victor Landassuri 
 


%% First part plot Av, std and ste in a different directory each group

for i = 1:3
    % repeat for the three cases
    if i == 1
        typePlot = 'AV';
        dir2save = 'figs_av';
    elseif i == 2
        typePlot = 'STD';
        dir2save = 'fig_STD';
    elseif i == 3
        typePlot = 'STE';
        dir2save = 'fig_STE';
    end
    
    %Change to the dir to save figs
    if(exist(dir2save, 'dir') ~= 7)
        mkdir(dir2save)
    end
    cd(dir2save);
    
    sizeDir = 1;   % variable used for many dir in plotAllFigs, here is set to 1
    
    % Plot all figures, here select what to plot
    % here is a single line per figure
    plotALLfigs
    
    
    %% Special figures where there are more lines per figure
    
    % setup the Legend
    for module = 1:info{1,1}.noModules
        tmp = num2str(module);
        legendText{module,1} = ['Module ', tmp];
    end
    % plot the fitness per module in av, std and ste
    % and classification error per module
    
    if info{1,1}.noModules > 1  % later change this, maybe the number of modules is not
%         given by the task, if the improved modularity is applied or if we want to consider share
%             nodes or isolated nodes, this number may be bigger
        plotFitnessPerModule
        plotFitnessPerModule_Total
        
        plotNodesPerModule
        plotNodesPerModule_Total
        
        % Plot learning rate, for one module or many
        plotLRateAll
        
        
        
    end
    
    
    if ( allrun{1,1}.var.task2solve == allrun{1,1}.C.CLASSIFY ) && ...
        ( allrun{1,1}.var.isModule1 == allrun{1,1}.C.ON )
        
        
        plotClassifErrorPerModule
        plotClassifErrorPerModule_Total
        
                       
    end
    
    % Plot both modularities together
    if (allrun{1,1}.var.isModule1 == allrun{1,1}.C.ON)
        plotBothModularities
    end
    
    
    
    % plot the number of nodes reused per module
    if( allrun{1,1}.var.reuseModule == allrun{1,1}.C.ON )
        plotNodesReusedPerModule
    end
    
    
    
    % Plot the best, av and worst fitness from the population
    plotFitnessBestWorstAv
    
    
    % Average Mutations
    % I M P O R T A N T
    % Change the three sections as required !!!!
    plotAvMutations
    
    cd('..');
end


