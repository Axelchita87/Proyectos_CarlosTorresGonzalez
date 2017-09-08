%% Plot Av Modularity weighted rate Error Figure
% It is plotted the Av Mweight figure in Av, std or ste
%
% Created:  21 Feb 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%

hold all
if strcmp(typePlot, 'AV')
    for alldir = 1:sizeDir
       h = plot(info{1,alldir}.avMweight,lines{1,alldir},'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STD')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avMweight,info{1,alldir}.stdMweight, lines{1,alldir}, 'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STE')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avMweight,info{1,alldir}.steMweight, lines{1,alldir}, 'LineWidth',1);
    end
end

ylabel('Average Modularity (M^{(weight)})','FontSize',xylabeSize)
subname = 'Mweight';