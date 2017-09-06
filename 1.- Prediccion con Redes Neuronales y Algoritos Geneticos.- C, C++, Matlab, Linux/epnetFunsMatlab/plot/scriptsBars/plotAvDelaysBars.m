%% Plot Av Delays Figure
% It is plotted the Av Delays figure in Av, std or ste
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
        h = bar(xVals, infoBar.avDelays);
        set(gca,'XTickLabel',xTicksL);
    elseif strcmp(typePlot, 'STD')
        h = errorb(infoBar.avDelays,infoBar.stdDelays,'top');
        set(gca,'XTickLabel',xTicks);
    elseif strcmp(typePlot, 'STE')
        h = errorb(infoBar.avDelays,infoBar.steDelays,'top');
        set(gca,'XTickLabel',xTicks);
    end
    
else
    % in the case of just different exps without repetttions
    if strcmp(typePlot, 'AV')
        hold off;
        bar(xVals, infoBar.avDelays');
        set(gca,'XTickLabel',xTicksL);
    elseif strcmp(typePlot, 'STD')
        bar(xVals, infoBar.avDelays');
        errorb(infoBar.avDelays',infoBar.stdDelays','top');
        set(gca,'XTickLabel',xTicks);
    elseif strcmp(typePlot, 'STE')
        bar(xVals, infoBar.avDelays');
        errorb(infoBar.avDelays',infoBar.steDelays','top');
        set(gca,'XTickLabel',xTicks);
    end
    
end

ylabel('Average Delays','FontSize',xylabeSize)
subname = 'Delays';