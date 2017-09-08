%% Plot all figs
% Plot all average figures
%
% Created:  somewhen between 2008 and 2010
% Modified: 22 Feb 2011
% Author:   Carlos Torres and Victor Landassuri

%%


% select what to plot
% Calling scripts
for i= 1:12                         % actual runs from 1:12
    clf
    if i==1
        % A C U R A C Y
        plotAvAccuracy
        
    elseif i==2
        % F I T N E S S
        plotAvFitness
        
    elseif i==3
        % C O N N E C T I O N S
        plotAvConnections
        
    elseif i==4
        % I N P U T S
        plotAvInputs
        
    elseif i==5
        % D E L A Y S
        plotAvDelays
        
    elseif i==6
        % H I D D E N
        plotAvHidden
        
           
        % Part for Modules %
    elseif i==7
        % M w e i g h t
        plotMweight
        
    elseif i==8
        % M a r c h
        plotMarch
        
    elseif i==9
        % S H A R E D     N O D E S
        plotAvSharedNodes
        
    elseif i==10
        % S H A R E D     C O N N E C T I O N S
        plotSharedConn
        
    elseif i==11
        % I S O L A T E D    N O D E S
        plotIsolatedNodes
        
    elseif i==12
        %  F I T N E S S    R E A L
        plotFitnessReal
        
    end
    
    
    
    
    if sizeDir > 1
        legend(legendM, 'Orientation', 'horizontal');
        
    end
    
    set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
    
    
    xlabel('Generations','FontSize',xylabeSize)
    string2title = ['\it{',TSname,'}'];
    title(string2title,'FontSize',16');
    
    foo = 'to make a pause put s break point here';
    
    saveas(h, [TSname, typePlot, subname,'.fig']);
    
end

 % Plot learning rate, for one module or many
 plotLRate
    
% Classificaiton error
if info{1,1}.flagClass == 1
    plotAvClassifE
end
