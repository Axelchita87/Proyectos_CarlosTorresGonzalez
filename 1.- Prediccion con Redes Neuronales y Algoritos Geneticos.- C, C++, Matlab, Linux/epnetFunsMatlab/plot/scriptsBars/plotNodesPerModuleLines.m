%% Plot nodes per module Figure
% It is plotted the Nodes per module figure in Av, std or ste
%
% Created:  22 Feb 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%
clf
hold all



if strcmp(typePlot, 'AV')
    
    for k = 1:info{1,1}.noModules
        h = plot(xVals, specialBar{1,exp}.AvNodesPerModule(:,k), lines{1,k},'LineWidth',1 );
    end
    set(gca,'XTickLabel',xTicksL2);
    
elseif strcmp(typePlot, 'STD')
    for k = 1:info{1,1}.noModules
        h = errorbar(xVals, specialBar{1,exp}.AvNodesPerModule(:,k), specialBar{1,exp}.stdNodesPerModule(:,k), lines{1,k},'LineWidth',1 );
    end
    set(gca,'XTickLabel',xTicks);
    
    
elseif strcmp(typePlot, 'STE')
    for k = 1:info{1,1}.noModules
        h = errorbar(xVals, specialBar{1,exp}.AvNodesPerModule(:,k), specialBar{1,exp}.steNodesPerModule(:,k), lines{1,k},'LineWidth',1 );
    end
    set(gca,'XTickLabel',xTicks);
end
ylabel('Average Nodes','FontSize',xylabeSize)
subname = 'NodesPerModule';



% create automatically this
if sizeDir > 1
    legend(legendM, 'Orientation', 'horizontal');
end
%legend('Module 1','Module 2');



set(gca, 'fontsize',gcaFotnSize, 'box', 'on');


xlabel('Generations','FontSize',xylabeSize)
string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16');

saveas(h, ['specLine',SLASH, legendM{exp,1}, TSname, typePlot, subname,'.fig']);
