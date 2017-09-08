%% Plot Av Learning rate Error Figure
% It is plotted the Av Learning rate Error figure in Av, std or ste
%
% Created:  21 Feb 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%

h = clf
hold all
if  size( infoBar.avFitness, 2 ) > 1
    % For the case with different exps and repettions of each one
    
    if strcmp(typePlot, 'AV')
        hold off;
        h = bar(xVals, infoBar.avLrate);
         set(gca,'XTickLabel',xTicksL);
    elseif strcmp(typePlot, 'STD')
        h = errorb(infoBar.avLrate,infoBar.stdLrate,'top');
         set(gca,'XTickLabel',xTicks);
    elseif strcmp(typePlot, 'STE')
        h = errorb(infoBar.avLrate,infoBar.steLrate,'top');
         set(gca,'XTickLabel',xTicks);
    end
    
    
else
    % in the case of just different exps without repetttions
    
    if strcmp(typePlot, 'AV')
        hold off;
        bar(xVals, infoBar.avLrate');
         set(gca,'XTickLabel',xTicksL);
    elseif strcmp(typePlot, 'STD')
        bar(xVals, infoBar.avLrate');
        errorb(infoBar.avLrate',infoBar.stdLrate','top');
         set(gca,'XTickLabel',xTicks);
    elseif strcmp(typePlot, 'STE')
        bar(xVals, infoBar.avLrate');
        errorb(infoBar.avLrate',infoBar.steLrate','top');
         set(gca,'XTickLabel',xTicks);
    end
end

ylabel('Average Learning Rate','FontSize',xylabeSize)
subname = 'LRate';