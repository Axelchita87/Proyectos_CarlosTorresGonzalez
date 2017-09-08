%% Plot Fitness per module Figure
% It is plotted the FITNESS per module figure in Av, std or ste
%
% Created:  22 Feb 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%
clf
hold all
set(gca, 'fontsize',gcaFotnSize, 'box', 'on');



if strcmp(typePlot, 'AV')
    
    for k = 1:info{1,1}.noModules
        h = plot(xVals, specialBar{1,exp}.AvFitnessPerModule(:,k), lines{1,k},'LineWidth',1 );
    end
    set(gca,'XTickLabel',xTicksL2);
    
elseif strcmp(typePlot, 'STD')
    for k = 1:info{1,1}.noModules
        h = errorbar(xVals, specialBar{1,exp}.AvFitnessPerModule(:,k), specialBar{1,exp}.stdFitnessPerModule(:,k), lines{1,k},'LineWidth',1 );
    end
    set(gca,'XTickLabel',xTicks);
    
    
elseif strcmp(typePlot, 'STE')
    for k = 1:info{1,1}.noModules
        h = errorbar(xVals, specialBar{1,exp}.AvFitnessPerModule(:,k), specialBar{1,exp}.steFitnessPerModule(:,k), lines{1,k},'LineWidth',1 );
    end
    set(gca,'XTickLabel',xTicks);
end

ylabel('Average Error','FontSize',xylabeSize)
subname = 'FitnessPerModuleTOTAL';


legend('Module 1 error','Module 2 error');


xlabel(labelX,'FontSize',xylabeSize)


string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16');


saveas(h, ['specLine',SLASH, legendM{exp,1}, TSname, typePlot, subname,'.fig']);
