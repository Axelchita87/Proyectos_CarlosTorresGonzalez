%% Plot Av Modularity architectures Figure
% It is plotted the Av March figure in Av, std or ste
%
% Created:  21 Feb 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%

hold all
if strcmp(typePlot, 'AV')
    for alldir = 1:sizeDir
       h = plot(info{1,alldir}.avMarch,lines{1,alldir},'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STD')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avMarch,info{1,alldir}.stdMarch, lines{1,alldir}, 'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STE')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avMarch,info{1,alldir}.steMarch, lines{1,alldir}, 'LineWidth',1);
    end
end

ylabel('Average Modularity (M^{(arch.)})','FontSize',xylabeSize)
subname = 'March';