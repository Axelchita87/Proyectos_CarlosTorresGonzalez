%% Plot nodes per module Figure with the total hidden nodes
% It is plotted the nodes per module figure in Av, std or ste
%
% Created:  22 Feb 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%
clf
hold all



if strcmp(typePlot, 'AV')
    
    for alldir = 1:info{1,1}.noModules + 1
        if alldir == 1                      % this 'if' is to use 'lines' correctly
            h = plot(info{1,1}.avHid, lines{1,alldir},'LineWidth',1);
        else
            % 'alldir-1' because I introduce the previous if, so the total
            % fitness uses the type line 1
            h = plot(info{1,1}.AvNodesPerModule{alldir-1,1}, lines{1,alldir},'LineWidth',1);
            %text(150,.1,'\leftarrow Strict value');
        end
    end
    
elseif strcmp(typePlot, 'STD')
    
    for alldir = 1:info{1,1}.noModules + 1
        if alldir == 1
            h = errorbar(info{1,1}.avHid,info{1,1}.stdHid,lines{1,alldir},'LineWidth',1);
        else
            h = errorbar(info{1,1}.AvNodesPerModule{alldir-1,1}, info{1,1}.stdNodesPerModule{alldir-1,1}, lines{1,alldir},'LineWidth',1);
        end
    end
    
elseif strcmp(typePlot, 'STE')
    
    for alldir = 1:info{1,1}.noModules + 1
        if alldir == 1
            h = errorbar(info{1,1}.avHid,info{1,1}.steHid,lines{1,alldir},'LineWidth',1);
        else
            h = errorbar(info{1,1}.AvNodesPerModule{alldir-1,1}, info{1,1}.steNodesPerModule{alldir-1,1}, lines{1,alldir},'LineWidth',1);
        end
    end
end

ylabel('Average Nodes','FontSize',xylabeSize)
subname = 'NodesPerModuleTOTAL';




legend('Total','Module 1','Module 2');



set(gca, 'fontsize',gcaFotnSize, 'box', 'on');


xlabel('Generations','FontSize',xylabeSize)
string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16');

foo = 'to make a pause put s break point here';

saveas(h, [TSname, typePlot, subname,'.fig']);