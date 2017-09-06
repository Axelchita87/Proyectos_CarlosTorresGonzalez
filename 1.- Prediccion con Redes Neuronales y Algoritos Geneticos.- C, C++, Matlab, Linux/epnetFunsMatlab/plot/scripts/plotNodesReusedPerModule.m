%% Plot The average number of nodes reused per module
% 
%
% Created:  13 Sep 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%
clf
hold all



if strcmp(typePlot, 'AV')
    
    for alldir = 1:info{1,1}.noModules
        h = plot(info{1,1}.avNodesReusedPerMod{alldir,1}, lines{1,alldir},'LineWidth',1);    
    end
    
elseif strcmp(typePlot, 'STD')
    
    for alldir = 1:info{1,1}.noModules
        h = errorbar(info{1,1}.avNodesReusedPerMod{alldir,1}, info{1,1}.stdNodesReusedPerMod{alldir,1}, lines{1,alldir},'LineWidth',1);
    end
    
elseif strcmp(typePlot, 'STE')
    
    for alldir = 1:info{1,1}.noModules
        h = errorbar(info{1,1}.avNodesReusedPerMod{alldir,1}, info{1,1}.steNodesReusedPerMod{alldir,1}, lines{1,alldir},'LineWidth',1);
    end
end

ylabel('Average Number of Reused Nodes','FontSize',xylabeSize)
subname = 'ReusedNodesPerModule';




legend(legendText);



set(gca, 'fontsize',gcaFotnSize, 'box', 'on');


xlabel('Generations','FontSize',xylabeSize)
string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16');

foo = 'to make a pause put s break point here';

saveas(h, [TSname, typePlot, subname,'.fig']);