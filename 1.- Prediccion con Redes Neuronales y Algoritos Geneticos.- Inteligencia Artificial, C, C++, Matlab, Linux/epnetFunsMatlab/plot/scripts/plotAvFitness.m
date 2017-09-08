%% Plot Accuracy Figure
% It is plotted the FITNESS figure in Av, std or ste
%
% Created:  21 FEb 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%

hold all
if strcmp(typePlot, 'AV')
    for alldir = 1:sizeDir
        h = plot(info{1,alldir}.avNRMSE, lines{1,alldir},'LineWidth',1);
        %text(150,.1,'\leftarrow Strict value');
    end
    
elseif strcmp(typePlot, 'STD')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avNRMSE,info{1,alldir}.stdNRMSE,lines{1,alldir},'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STE')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avNRMSE,info{1,alldir}.steNRMSE,lines{1,alldir},'LineWidth',1);
    end
end

ylabel('Average Error','FontSize',xylabeSize)
subname = 'Fitness';