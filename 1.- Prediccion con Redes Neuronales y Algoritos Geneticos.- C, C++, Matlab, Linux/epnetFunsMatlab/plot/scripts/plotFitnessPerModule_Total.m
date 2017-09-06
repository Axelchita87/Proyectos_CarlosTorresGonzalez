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
    
    for alldir = 1:info{1,1}.noModules + 1
        if alldir == 1                      % this 'if' is to use 'lines' correctly
            h = plot(info{1,1}.avNRMSE, lines{1,alldir},'LineWidth',1);
        else
            % 'alldir-1' because I introduce the previous if, so the total
            % fitness uses the type line 1
            h = plot(info{1,1}.AvFitnessPerModule{alldir-1,1}, lines{1,alldir},'LineWidth',1);
            %text(150,.1,'\leftarrow Strict value');
        end
    end
    
elseif strcmp(typePlot, 'STD')
    
    for alldir = 1:info{1,1}.noModules + 1
        if alldir == 1
            h = errorbar(info{1,1}.avNRMSE,info{1,1}.stdNRMSE,lines{1,alldir},'LineWidth',1);
        else
            h = errorbar(info{1,1}.AvFitnessPerModule{alldir-1,1}, info{1,1}.stdFitnessPerModule{alldir-1,1}, lines{1,alldir},'LineWidth',1);
        end
    end
    
elseif strcmp(typePlot, 'STE')
    
    for alldir = 1:info{1,1}.noModules + 1
        if alldir == 1
            h = errorbar(info{1,1}.avNRMSE,info{1,1}.steNRMSE,lines{1,alldir},'LineWidth',1);
        else
            h = errorbar(info{1,1}.AvFitnessPerModule{alldir-1,1}, info{1,1}.steFitnessPerModule{alldir-1,1}, lines{1,alldir},'LineWidth',1);
        end
    end
end

ylabel('Average Error','FontSize',xylabeSize)
subname = 'FitnessPerModuleTOTAL';


% configure the new legend
for k =1:info{1,1}.noModules + 1
    if k == 1
        newLegend{k,1} = 'Total';
    else
        newLegend{k,1} = legendText{k-1,1};
    end
end
legend(newLegend);

set(gca, 'fontsize',gcaFotnSize, 'box', 'on');


xlabel('Generations','FontSize',xylabeSize)
string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16');

foo = 'to make a pause put s break point here';

saveas(h, [TSname, typePlot, subname,'.fig']);