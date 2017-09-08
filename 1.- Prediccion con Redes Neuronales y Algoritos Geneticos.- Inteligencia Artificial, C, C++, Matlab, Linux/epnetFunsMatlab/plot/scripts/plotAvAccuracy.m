%% Plot Accuracy Figure 
% It is plotted the accuracy figure in Av, std or ste
% 
% Created:  21 FEb 2011
% Modified: 
% Author:   Carlos Torres and Victor Landassuri

%%

hold all
if strcmp(typePlot, 'AV')
    for alldir = 1:sizeDir
        h = plot(info{1,alldir}.avAccuracy, lines{1,alldir} ,'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STD')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avAccuracy,info{1,alldir}.stdAccuracy,lines{1,alldir},'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STE')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avAccuracy,info{1,alldir}.steAccuracy,lines{1,alldir},'LineWidth',1);
    end
end

ylabel('Average Accuracy','FontSize',xylabeSize)
subname = 'Accuracy';