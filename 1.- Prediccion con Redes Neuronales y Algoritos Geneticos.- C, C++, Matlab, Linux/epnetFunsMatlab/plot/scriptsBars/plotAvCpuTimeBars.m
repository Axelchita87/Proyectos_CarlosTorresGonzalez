%% Plot Av CPUtime
% 
%
% Created:  28 Jul 2011
% Modified: 
% Author:   Carlos Torres and Victor Landassuri

%%

h = clf
hold all
if  size( infoBar.avFitness, 2 ) > 1
    % For the case with different exps and repettions of each one
    
    if strcmp(typePlot, 'AV')
        hold off;
        h = bar(xVals, infoBar.avCpuTime);
        set(gca,'XTickLabel',xTicksL);
    elseif strcmp(typePlot, 'STD')
        h = errorb(infoBar.avCpuTime,infoBar.stdCpuTime,'top');
        set(gca,'XTickLabel',xTicks);
    elseif strcmp(typePlot, 'STE')
        h = errorb(infoBar.avCpuTime,infoBar.steCpuTime,'top');
        set(gca,'XTickLabel',xTicks);
    end
    
    
else
    % in the case of just different exps without repetttions
    if strcmp(typePlot, 'AV')
        hold off;
        bar(xVals, infoBar.avCpuTime');
        set(gca,'XTickLabel',xTicksL);
    elseif strcmp(typePlot, 'STD')
        bar(xVals, infoBar.avCpuTime');
        errorb(infoBar.avCpuTime',infoBar.stdCpuTime','top');
        set(gca,'XTickLabel',xTicks);
    elseif strcmp(typePlot, 'STE')
        bar(xVals, infoBar.avCpuTime');
        errorb(infoBar.avCpuTime',infoBar.steCpuTime','top');
        set(gca,'XTickLabel',xTicks);
    end
    
    
end



ylabel('Average CPU Time (seconds)','FontSize',xylabeSize)
subname = 'CpuTime';

if sizeDir > 1 && size( infoBar.avFitness, 2 ) > 1
    legend(legendM, 'Orientation', 'horizontal');
end


set(gca, 'fontsize',gcaFotnSize, 'box', 'on');


xlabel(labelX,'FontSize',xylabeSize)

string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16');

if  size( infoBar.avFitness, 2 ) > 1                    % many repetions
    if strcmp(typePlot, 'AV')
        saveas(h(1), [TSname, typePlot, subname,'.fig']);
    else
        saveas(h.bars(1), [TSname, typePlot, subname,'.fig']);
    end
    
else                                                    % no repetionos
    saveas(h, [TSname, typePlot, subname,'.fig']);
end

