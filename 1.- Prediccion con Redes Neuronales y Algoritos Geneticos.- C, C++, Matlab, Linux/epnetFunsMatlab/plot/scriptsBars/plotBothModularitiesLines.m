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
    h = plot(xVals, infoBar.avMweight(:,exp), lines{1,1},'LineWidth',1);
    h = plot(xVals, infoBar.avMarch(:,exp), lines{1,1},'LineWidth',1);
    set(gca,'XTickLabel', xTicksL2 );
       
elseif strcmp(typePlot, 'STD')
    h = errorbar(xVals, infoBar.avMweight(:,exp),infoBar.stdMweight(:,exp), lines{1,1}, 'LineWidth',1);
    h = errorbar(xVals, infoBar.avMarch(:,exp),infoBar.stdMarch(:,exp), lines{1,2}, 'LineWidth',1);
    set(gca,'XTickLabel',xTicks);
    
elseif strcmp(typePlot, 'STE')
    h = errorbar(xVals, infoBar.avMweight(:,exp),infoBar.steMweight(:,exp), lines{1,1}, 'LineWidth',1);
    h = errorbar(xVals, infoBar.avMarch(:,exp),infoBar.steMarch(:,exp), lines{1,2}, 'LineWidth',1);
    set(gca,'XTickLabel',xTicks);
end

ylabel('Average Modularity','FontSize',xylabeSize)
subname = 'ModularityBOTH';

legend('Av. M^{(weight)}', 'Av. M^{(arch.)}');

set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
%set(gca,'XTickLabel',xTicks);

xlabel(labelX,'FontSize',xylabeSize)

string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16');


saveas(h, ['specLine',SLASH, legendM{exp,1}, TSname, typePlot, subname,'.fig']);