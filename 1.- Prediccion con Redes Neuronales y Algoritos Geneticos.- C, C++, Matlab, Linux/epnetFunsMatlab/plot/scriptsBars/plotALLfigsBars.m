%% Plot all figs
% Plot all average figures
%
% Created:  somewhen between 2008 and 2010
% Modified: 22 Feb 2011
% Author:   Carlos Torres and Victor Landassuri

%%


% select what to plot
% Calling scripts
if info{1,1}.flagClass == 1 && ~strcmp(info{1,1}.typeDS,'NRMSE')
    vec2Plot = [2,3,4,6,8,9,10,11,12];  % include 7 for lrate
else
    vec2Plot = [1,2,3,4,5,6,8,9,10,11,12];
end

for i= vec2Plot%1:12                         % actual runs from 1:13
    clf
    if i==1
        % A C U R A C Y
        plotAvAccuracyBars  % not update for bars without repettion
        
    elseif i==2
        % F I T N E S S
        plotAvFitnessBars
        
    elseif i==3
        % C O N N E C T I O N S
        plotAvConnectionsBars
        
    elseif i==4
        % I N P U T S
        plotAvInputsBars
        
    elseif i==5
        % D E L A Y S
        plotAvDelaysBars
        
    elseif i==6
        % H I D D E N
        plotAvHiddenBars
        
    elseif i==7
        % L E A R N I N G     R A T E
        %plotLRateBars
        
        
        % Part for Modules %
    elseif i==8
        % M w e i g h t
        plotMweightBars
        
    elseif i==9
        % M a r c h
        plotMarchBars
        
    elseif i==10
        % S H A R E D     N O D E S
        plotAvSharedNodesBars
        
    elseif i==11
        % S H A R E D     C O N N E C T I O N S
        plotSharedConnBars
        
    elseif i==12
        % I S O L A T E D    N O D E S
        plotIsolatedNodesBars
        
        %     elseif i==13
        %         %  F I T N E S S    R E A L
        %         plotFitnessReal
        
    end
    
    
    
    
    if sizeDir > 1 && size( infoBar.avFitness, 2 ) > 1
        legend(legendM, 'Orientation', 'horizontal');
    end
    
    set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
    
    
    xlabel(labelX,'FontSize',xylabeSize)
    
    
    string2title = ['\it{',TSname,'}'];
    title(string2title,'FontSize',16');
    
    if  size( infoBar.avFitness, 2 ) > 1  % many repetions
        if strcmp(typePlot, 'AV')
            saveas(h(1), [TSname, typePlot, subname,'.fig']);
        else
            saveas(h.bars(1), [TSname, typePlot, subname,'.fig']);
        end
    else
        % no repetionos
        saveas(h, [TSname, typePlot, subname,'.fig']);
    end
end

% plt the Generation, evaluation and CPU time
plotAvGenerationsBars
plotAvTotalEvaluationsBars
plotAvCpuTimeBars

% Classificaiton error
if info{1,1}.flagClass == 1 && ~strcmp(info{1,1}.typeDS,'NRMSE')
    plotAvClassifEBars
end



