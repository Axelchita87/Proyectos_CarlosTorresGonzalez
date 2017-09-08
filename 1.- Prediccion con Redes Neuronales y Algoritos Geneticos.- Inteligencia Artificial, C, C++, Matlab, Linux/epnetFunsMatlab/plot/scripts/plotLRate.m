%% Plot Av Learning rate Error Figure
% It is plotted the Av Learning rate Error figure in Av, std or ste
%
% Created:  21 Feb 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%

for module = 1:info{1,1}.noModules
    
    stringTmp = num2str(module);
    clf
    
    hold all
    if strcmp(typePlot, 'AV')
        for alldir = 1:sizeDir
            h = plot(info{1,alldir}.avLrate{module},lines{1,alldir},'LineWidth',1);
        end
        
    elseif strcmp(typePlot, 'STD')
        for alldir = 1:sizeDir
            h = errorbar(info{1,alldir}.avLrate{module},info{1,alldir}.stdLrate{module},lines{1,alldir},'LineWidth',1);
        end
        
    elseif strcmp(typePlot, 'STE')
        for alldir = 1:sizeDir
            h = errorbar(info{1,alldir}.avLrate{module},info{1,alldir}.steLrate{module},lines{1,alldir},'LineWidth',1);
        end
    end
    
    ylabel(['Average Learning Rate for Module ', stringTmp],'FontSize',xylabeSize)
    subname = ['LRate_task_',stringTmp];
    
    
    if sizeDir > 1
        legend(legendM, 'Orientation', 'horizontal');
        
    end
    
    set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
    
    
    xlabel('Generations','FontSize',xylabeSize)
    string2title = ['\it{',TSname,'}'];
    title(string2title,'FontSize',16');
    
    %foo = 'to make a pause put s break point here';
    
    saveas(h, [TSname, typePlot, subname,'.fig']);
    
end