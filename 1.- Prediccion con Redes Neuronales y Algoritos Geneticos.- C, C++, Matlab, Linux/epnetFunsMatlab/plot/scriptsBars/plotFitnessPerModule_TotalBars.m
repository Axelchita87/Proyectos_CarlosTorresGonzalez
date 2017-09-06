%% Plot Fitness per module Figure
% It is plotted the FITNESS per module figure in Av, std or ste
%
% Created:  22 Feb 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%
clf
hold all



if strcmp(typePlot, 'AV')
    hold off;
    h = bar(xVals, specialBar{1,exp}.AvFitnessPerModule);
    set(gca,'XTickLabel',xTicksL);  % works for Av
        
elseif strcmp(typePlot, 'STD')
    h = errorb(specialBar{1,exp}.AvFitnessPerModule,specialBar{1,exp}.stdFitnessPerModule,'top');
    set(gca,'XTickLabel',xTicks);  
elseif strcmp(typePlot, 'STE')
    h = errorb(specialBar{1,exp}.AvFitnessPerModule,specialBar{1,exp}.steFitnessPerModule,'top');
    set(gca,'XTickLabel',xTicks);
end

ylabel('Average Error','FontSize',xylabeSize)
subname = 'FitnessPerModuleTOTAL';




legend('Module 1 error','Module 2 error');



set(gca, 'fontsize',gcaFotnSize, 'box', 'on');


xlabel('Generations','FontSize',xylabeSize)


string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16');


if strcmp(typePlot, 'AV')
    saveas(h(1), ['specBar',SLASH, legendM{exp,1}, TSname, typePlot, subname,'.fig']);
else
    saveas(h.bars(1), ['specBar',SLASH, legendM{exp,1}, TSname, typePlot, subname,'.fig']);
end
