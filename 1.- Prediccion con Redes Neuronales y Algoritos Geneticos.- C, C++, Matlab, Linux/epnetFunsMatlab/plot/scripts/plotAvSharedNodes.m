%% Plot Av Shared Nodes Figure
% It is plotted the Av Shared Nodes March figure in Av, std or ste
%
% Created:  21 Feb 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%

hold all
if strcmp(typePlot, 'AV')
    for alldir = 1:sizeDir
       h = plot(info{1,alldir}.avNoShared,lines{1,alldir},'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STD')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avNoShared, info{1,alldir}.stdNoShared,lines{1,alldir},'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STE')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avNoShared, info{1,alldir}.steNoShared,lines{1,alldir},'LineWidth',1);
    end
end

ylabel('Average Shared Nodes', 'FontSize', xylabeSize)
subname = 'SharedNodes';