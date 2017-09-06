%% Plot Av Hidden Figure
% It is plotted the Av Hidden figure in Av, std or ste
%
% Created:  21 FEb 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%

hold all
if strcmp(typePlot, 'AV')
    for alldir = 1:sizeDir
       h = plot(info{1,alldir}.avHid,lines{1,alldir},'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STD')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avHid, info{1,alldir}.stdHid,lines{1,alldir},'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STE')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avHid, info{1,alldir}.steHid,lines{1,alldir},'LineWidth',1);
    end
end

ylabel('Average Hidden Nodes','FontSize',xylabeSize)
subname = 'Hidden';