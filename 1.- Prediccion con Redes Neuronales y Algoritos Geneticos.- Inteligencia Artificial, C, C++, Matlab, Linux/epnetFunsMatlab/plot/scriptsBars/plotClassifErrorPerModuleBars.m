%% Plot the classification error per module Figure
% It is plotted the classification error per module figure in Av, std or ste
%
% Created:  10 Mar 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%
clf
hold all



if strcmp(typePlot, 'AV')
    hold off;
    h = bar(xVals, specialBar{1,exp}.AvClassifErrPerMod);
    set(gca,'XTickLabel',xTicksL);              % wroks for Av

        
elseif strcmp(typePlot, 'STD')
    h = errorb(specialBar{1,exp}.AvClassifErrPerMod,specialBar{1,exp}.stdClassifErrPerMod,'top');
    set(gca,'XTickLabel',xTicks);

elseif strcmp(typePlot, 'STE')
    h = errorb(specialBar{1,exp}.AvClassifErrPerMod,specialBar{1,exp}.steClassifErrPerMod,'top');
    set(gca,'XTickLabel',xTicks);
end

ylabel('Average Classification Error','FontSize',xylabeSize)
subname = 'ClassifErrorPerModule';




legend('Module 1','Module 2');



set(gca, 'fontsize',gcaFotnSize, 'box', 'on');


xlabel('Generations','FontSize',xylabeSize)

string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16');


if strcmp(typePlot, 'AV')
    saveas(h(1), ['specBar',SLASH, legendM{exp,1}, TSname, typePlot, subname,'.fig']);
else
    saveas(h.bars(1), ['specBar',SLASH, legendM{exp,1}, TSname, typePlot, subname,'.fig']);
end