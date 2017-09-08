%% Plot Av evaluations 
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
        h = bar(xVals, infoBar.avTotalEval);
        set(gca,'XTickLabel',xTicksL);
    elseif strcmp(typePlot, 'STD')
        h = errorb(infoBar.avTotalEval,infoBar.stdTotalEval,'top');
        set(gca,'XTickLabel',xTicks);
    elseif strcmp(typePlot, 'STE')
        h = errorb(infoBar.avTotalEval,infoBar.steTotalEval,'top');
        set(gca,'XTickLabel',xTicks);
    end
    
    
else
    % in the case of just different exps without repetttions
    if strcmp(typePlot, 'AV')
        hold off;
        bar(xVals, infoBar.avTotalEval');
        set(gca,'XTickLabel',xTicksL);
    elseif strcmp(typePlot, 'STD')
        bar(xVals, infoBar.avTotalEval');
        errorb(infoBar.avTotalEval',infoBar.stdTotalEval','top');
        set(gca,'XTickLabel',xTicks);
    elseif strcmp(typePlot, 'STE')
        bar(xVals, infoBar.avTotalEval');
        errorb(infoBar.avTotalEval',infoBar.steTotalEval','top');
        set(gca,'XTickLabel',xTicks);
    end
    
    
end



ylabel('Average Evaluations','FontSize',xylabeSize)
subname = 'TotalEval';

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

