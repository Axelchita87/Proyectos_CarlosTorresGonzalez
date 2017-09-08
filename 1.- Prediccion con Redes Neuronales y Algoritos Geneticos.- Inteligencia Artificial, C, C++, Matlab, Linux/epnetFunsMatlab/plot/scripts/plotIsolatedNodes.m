%% Plot Av Isolated Nodes Figure
% It is plotted the Av Isolated Nodes figure in Av, std or ste
%
% Created:  21 Feb 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%

hold all
if strcmp(typePlot, 'AV')
    for alldir = 1:sizeDir
       h = plot(info{1,alldir}.avIsolated, lines{1,alldir},'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STD')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avIsolated, info{1,alldir}.stdIsolated, lines{1,alldir}, 'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STE')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avIsolated, info{1,alldir}.steIsolated, lines{1,alldir}, 'LineWidth',1);
    end
end

ylabel('Average Isolated Nodes', 'FontSize', xylabeSize)
subname = 'IsolatedNodes';