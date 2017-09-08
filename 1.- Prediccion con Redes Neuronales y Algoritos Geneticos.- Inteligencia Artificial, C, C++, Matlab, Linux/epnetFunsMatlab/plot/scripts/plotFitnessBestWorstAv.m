%% Plot Av, best and worst fitness 
% 
%
% Created:  20 June 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%
clf
hold all



if strcmp(typePlot, 'AV')
    h = plot(info{1,1}.avWorstFit, lines{1,1},'LineWidth',1);
    h = plot(info{1,1}.avNRMSE,    lines{1,2},'LineWidth',1);
    h = plot(info{1,1}.avBestFit, lines{1,3},'LineWidth',1);
    
elseif strcmp(typePlot, 'STD')
    h = errorbar(info{1,1}.avWorstFit, info{1,1}.stdWorstFit, lines{1,1},'LineWidth',1);
    h = errorbar(info{1,1}.avNRMSE,    info{1,1}.stdNRMSE,   lines{1,alldir},'LineWidth',2);
    h = errorbar(info{1,1}.avBestFit, info{1,1}.stdBestFit, lines{1,3},'LineWidth',1);
    
elseif strcmp(typePlot, 'STE')
    h = errorbar(info{1,1}.avWorstFit, info{1,1}.steWorstFit, lines{1,1},'LineWidth',1);
    h = errorbar(info{1,1}.avNRMSE,    info{1,1}.steNRMSE,    lines{1,2},'LineWidth',2);
    h = errorbar(info{1,1}.avBestFit,  info{1,1}.steBestFit, lines{1,3},'LineWidth',1);
end

ylabel('Fitness','FontSize',xylabeSize)
subname = 'FitnessAvBestWorst';


 legend('Worst','Average','Best');


set(gca, 'fontsize',gcaFotnSize, 'box', 'on');


xlabel('Generations','FontSize',xylabeSize)
string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16');

%foo = 'to make a pause put s break point here';

saveas(h, [TSname, typePlot, subname,'.fig']);