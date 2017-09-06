%% Plot Both Modularities in one Figure
% It is plotted the March and Mweight in the same figure in Av, std or ste
%
% Created:  22 Feb 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%
clf
hold all



hold all
if strcmp(typePlot, 'AV')
    h = plot(info{1,1}.avMweight,lines{1,1},'LineWidth',1);
    h = plot(info{1,1}.avMarch,lines{1,2},'LineWidth',1);
    
elseif strcmp(typePlot, 'STD')
    h = errorbar(info{1,1}.avMweight,info{1,1}.stdMweight, lines{1,1}, 'LineWidth',1);
    h = errorbar(info{1,1}.avMarch,info{1,1}.stdMarch, lines{1,2}, 'LineWidth',1);
    
elseif strcmp(typePlot, 'STE')
    h = errorbar(info{1,1}.avMweight,info{1,1}.steMweight, lines{1,1}, 'LineWidth',1);
    h = errorbar(info{1,1}.avMarch,info{1,1}.steMarch, lines{1,2}, 'LineWidth',1);
end

ylabel('Average Modularity','FontSize',xylabeSize)
subname = 'ModularityBOTH';

legend('Av. M^{(weight)}', 'Av. M^{(arch.)}');

set(gca, 'fontsize',gcaFotnSize, 'box', 'on');


xlabel('Generations','FontSize',xylabeSize)
string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16');


saveas(h, [TSname, typePlot, subname,'.fig']);