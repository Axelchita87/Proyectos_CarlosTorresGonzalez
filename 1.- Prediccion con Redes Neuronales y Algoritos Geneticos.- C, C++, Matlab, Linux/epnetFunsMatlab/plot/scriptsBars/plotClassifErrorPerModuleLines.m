%% Plot the classification error per module Figure
% It is plotted the classification error per module figure in Av, std or ste
%
% Created:  10 Mar 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%
clf
hold all
set(gca, 'fontsize',gcaFotnSize, 'box', 'on');



if strcmp(typePlot, 'AV')
    
    for k = 1:info{1,1}.noModules
        h = plot(xVals, specialBar{1,exp}.AvClassifErrPerMod(:,k), lines{1,k},'LineWidth',1 );
    end
    set(gca,'XTickLabel',xTicksL2);
    
elseif strcmp(typePlot, 'STD')
    for k = 1:info{1,1}.noModules
        h = errorbar(xVals, specialBar{1,exp}.AvClassifErrPerMod(:,k), specialBar{1,exp}.stdClassifErrPerMod(:,k), lines{1,k},'LineWidth',1 );
    end
    set(gca,'XTickLabel',xTicks);
    
    
elseif strcmp(typePlot, 'STE')
    for k = 1:info{1,1}.noModules
        h = errorbar(xVals, specialBar{1,exp}.AvClassifErrPerMod(:,k), specialBar{1,exp}.steClassifErrPerMod(:,k), lines{1,k},'LineWidth',1 );
    end
    set(gca,'XTickLabel',xTicks);
end

ylabel('Average Classification Error','FontSize',xylabeSize)
subname = 'ClassifErrorPerModule';


legend('Module 1','Module 2');


xlabel(labelX,'FontSize',xylabeSize)


string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16');


saveas(h, ['specLine',SLASH, legendM{exp,1}, TSname, typePlot, subname,'.fig']);
