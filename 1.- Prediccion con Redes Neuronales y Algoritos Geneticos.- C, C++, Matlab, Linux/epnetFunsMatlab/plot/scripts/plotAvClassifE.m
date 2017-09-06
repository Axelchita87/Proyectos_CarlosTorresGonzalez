%% Plot Av Classification Error Figure
% It is plotted the Av Classification Error figure in Av, std or ste
%
% Created:  21 Feb 2011
% Modified: 23 Feb 2011
% Author:   Carlos Torres and Victor Landassuri

%%
clf
hold all
if strcmp(typePlot, 'AV')
    for alldir = 1:sizeDir
       h = plot(info{1,alldir}.avClassifE,lines{1,alldir},'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STD')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avClassifE, info{1,alldir}.stdClassifE,lines{1,alldir},'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STE')
    for alldir = 1:sizeDir
        h = errorbar(info{1,alldir}.avClassifE, info{1,alldir}.steClassifE,lines{1,alldir},'LineWidth',1);
    end
end

ylabel('Average Classification Error','FontSize',xylabeSize)
subname = 'ClassifError';

if sizeDir > 1
    legend(legendM, 'Orientation', 'horizontal');
end


set(gca, 'fontsize',gcaFotnSize, 'box', 'on');


xlabel('Generations','FontSize',xylabeSize)
string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16');


saveas(h, [TSname, typePlot, subname,'.fig']);
