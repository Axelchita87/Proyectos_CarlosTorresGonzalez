%% Plot fitnees Real Figure
% It is plotted the FITNESS Real figure in Av, std or ste
% Fitness rela is the fitness that does not use the modularity penalty 
% if the algorithm is biased to evolve modules
%
% Created:  21 FEb 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%

hold all
if strcmp(typePlot, 'AV')
    for alldir = 1:sizeDir
        h = plot(info{1,alldir}.avNRMSEReal, lines{1,alldir},'LineWidth',1);
        %text(150,.1,'\leftarrow Strict value');
    end
    
elseif strcmp(typePlot, 'STD')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avNRMSEReal,info{1,alldir}.stdNRMSEReal,lines{1,alldir},'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STE')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avNRMSEReal,info{1,alldir}.steNRMSEReal,lines{1,alldir},'LineWidth',1);
    end
end

ylabel('Average Error Non Biased','FontSize',xylabeSize)
subname = 'FitnessReal';