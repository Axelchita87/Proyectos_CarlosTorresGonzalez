%% Plot Av Shared Connections Figure
% It is plotted the Av Shared Connections figure in Av, std or ste
%
% Created:  21 Feb 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%

hold all
if strcmp(typePlot, 'AV')
    for alldir = 1:sizeDir
       h = plot(info{1,alldir}.avNoSharedConn, lines{1,alldir},'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STD')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avNoSharedConn, info{1,alldir}.stdNoSharedConn,lines{1,alldir},'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STE')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avNoSharedConn, info{1,alldir}.steNoSharedConn,lines{1,alldir},'LineWidth',1);
    end
end

ylabel('Average Shared Connections', 'FontSize', xylabeSize)
subname = 'SharedConn';