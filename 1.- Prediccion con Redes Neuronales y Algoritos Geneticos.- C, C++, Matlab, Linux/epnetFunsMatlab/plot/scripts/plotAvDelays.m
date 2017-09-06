%% Plot Av Delays Figure
% It is plotted the Av Delays figure in Av, std or ste
%
% Created:  21 FEb 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%

hold all
if strcmp(typePlot, 'AV')
    for alldir = 1:sizeDir
       h = plot(info{1,alldir}.avDelays,lines{1,alldir},'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STD')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avDelays,info{1,alldir}.stdDelays,lines{1,alldir},'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STE')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avDelays,info{1,alldir}.steDelays,lines{1,alldir},'LineWidth',1);
    end
end

ylabel('Average Delays','FontSize',xylabeSize)
subname = 'Delays';