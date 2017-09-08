%% Plot Both Modularities in one Figure
% It is plotted the March and Mweight in the same figure in Av, std or ste
%
% Created:  22 Feb 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%
clf


hold all
if strcmp(typePlot, 'AV')
    hold off;
    h = bar(xVals, specialBar{1,exp}.AvModularityBoth);
    set(gca,'XTickLabel',xTicksL); 
elseif strcmp(typePlot, 'STD')
    h = errorb(specialBar{1,exp}.AvModularityBoth,specialBar{1,exp}.stdModularityBoth,'top');
set(gca,'XTickLabel',xTicks); 
elseif strcmp(typePlot, 'STE')
    h = errorb(specialBar{1,exp}.AvModularityBoth,specialBar{1,exp}.steModularityBoth,'top');
    set(gca,'XTickLabel',xTicks);
end

ylabel('Average Modularity','FontSize',xylabeSize)
subname = 'ModularityBOTH';

legend('Av. M^{(weight)}', 'Av. M^{(arch.)}');

set(gca, 'fontsize',gcaFotnSize, 'box', 'on');


xlabel(labelX,'FontSize',xylabeSize)

    
string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16');

if strcmp(typePlot, 'AV')
    saveas(h(1), ['specBar',SLASH, legendM{exp,1}, TSname, typePlot, subname,'.fig']);
else
    saveas(h.bars(1), ['specBar',SLASH, legendM{exp,1}, TSname, typePlot, subname,'.fig']);
end

