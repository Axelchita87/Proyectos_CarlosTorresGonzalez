%% Plot lrate per module Figure
% It is plotted the lrate per module figure in Av, std or ste
%
% Created:  27 Jun 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%
clf
hold all



if strcmp(typePlot, 'AV')
    
    for alldir = 1:info{1,1}.noModules
        h = plot(info{1,1}.avLrate{1,alldir}, lines{1,alldir},'LineWidth',1);    
    end
    
elseif strcmp(typePlot, 'STD')
    
    for alldir = 1:info{1,1}.noModules
        h = errorbar(info{1,1}.avLrate{1,alldir}, info{1,1}.stdLrate{1,alldir}, lines{1,alldir},'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STE')
    
    for alldir = 1:info{1,1}.noModules
        h = errorbar(info{1,1}.avLrate{1,alldir}, info{1,1}.steLrate{1,alldir}, lines{1,alldir},'LineWidth',1);
    end
end

 ylabel('Average Learning Rate','FontSize',xylabeSize)
subname = 'lrateALL';




legend(legendText);



set(gca, 'fontsize',gcaFotnSize, 'box', 'on');


xlabel('Generations','FontSize',xylabeSize)
string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16');


saveas(h, [TSname, typePlot, subname,'.fig']);