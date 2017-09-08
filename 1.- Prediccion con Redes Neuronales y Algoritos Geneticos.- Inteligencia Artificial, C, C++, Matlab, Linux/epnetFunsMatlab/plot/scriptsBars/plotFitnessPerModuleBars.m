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
    
    for alldir = 1:info{1,1}.noModules
        h = plot(info{1,1}.AvFitnessPerModule{alldir,1}, lines{1,alldir},'LineWidth',1);    
    end
    
elseif strcmp(typePlot, 'STD')
    
    for alldir = 1:info{1,1}.noModules
        h = errorbar(info{1,1}.AvFitnessPerModule{alldir,1}, info{1,1}.stdFitnessPerModule{alldir,1}, lines{1,alldir},'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STE')
    
    for alldir = 1:info{1,1}.noModules
        h = errorbar(info{1,1}.AvFitnessPerModule{alldir,1}, info{1,1}.steFitnessPerModule{alldir,1}, lines{1,alldir},'LineWidth',1);
    end
end

ylabel('Average Error','FontSize',xylabeSize)
subname = 'FitnessPerModule';




legend('Module 1 error','Module 2 error');



set(gca, 'fontsize',gcaFotnSize, 'box', 'on');


xlabel('Generations','FontSize',xylabeSize)
string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16');

foo = 'to make a pause put s break point here';

saveas(h, [TSname, typePlot, subname,'.fig']);