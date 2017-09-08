%% Plot Accuracy Figure
% It is plotted the accuracy figure in Av, std or ste
%
% Created:  21 FEb 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%

h = clf
hold all
if  size( infoBar.avFitness, 2 ) > 1
    % For the case with different exps and repettions of each one
    
    if strcmp(typePlot, 'AV')
        hold off;
        h = bar(xVals, infoBar.avAccuracy);
        set(gca,'XTickLabel',xTicksL);
        
    elseif strcmp(typePlot, 'STD')
        h = errorb(infoBar.avAccuracy,infoBar.stdAccuracy,'top');
        set(gca,'XTickLabel',xTicks);
    elseif strcmp(typePlot, 'STE')
        h = errorb(infoBar.avAccuracy,infoBar.steAccuracy,'top');
        set(gca,'XTickLabel',xTicks);
    end
    
else
    % in the case of just different exps without repetttions
    if strcmp(typePlot, 'AV')
        hold off;
        bar(xVals, infoBar.avAccuracy');
        set(gca,'XTickLabel',xTicksL);
    elseif strcmp(typePlot, 'STD')
        bar(xVals,infoBar.avAccuracy');
        errorb(infoBar.avAccuracy',infoBar.stdAccuracy','top');
        set(gca,'XTickLabel',xTicks);
    elseif strcmp(typePlot, 'STE')
        bar(xVals,infoBar.avAccuracy');
        errorb(infoBar.avAccuracy',infoBar.steAccuracy','top');
        set(gca,'XTickLabel',xTicks);
    end
end

ylabel('Average Accuracy','FontSize',xylabeSize)
subname = 'Accuracy';


