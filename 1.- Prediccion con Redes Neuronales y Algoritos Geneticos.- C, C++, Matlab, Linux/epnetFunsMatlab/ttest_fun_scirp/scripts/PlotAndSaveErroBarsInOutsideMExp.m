%Script to plot the error bar from exps, inside NRMSE nad outside (final test set)
%The figures are saved in a directory

% select what to plot

    for i=[2 3 4 5]                         %1:6
        clf
        if i==1
%             h = plot(avaccuracy{1,1},'LineWidth',1);
%             hold all
%             h = plot(avaccuracy{1,2},'-r','LineWidth',1);
%             ylabel('Average Accuracy','FontSize',12)
        elseif i==2
            h = errorbar(AvErrorPerRun,STDnrms,'s','LineWidth',2);
            hold all
            h = errorbar(InsideAvErrorPerRun,InsideSTDnrms,'o','LineWidth',1);
            ylabel('Average NRMS','FontSize',12)
        elseif i==3
            h = errorbar(AvConnPerRun,STDcon,'s','LineWidth',2);
            hold all
            h = errorbar(InsideAvConnPerRun,InsideSTDcon,'o','LineWidth',1);
            ylabel('Average Connections','FontSize',12)
        elseif i==4
            h = errorbar(AvInputsPerRun,STDinput,'s','LineWidth',2);
            hold all
            h = errorbar(InsideAvInputsPerRun,InsideSTDinput,'o','LineWidth',1);
            ylabel('Average Inputs','FontSize',12)
        elseif i==5
            h = errorbar(AvHiddenPerRun,STDhidden,'s','LineWidth',2);
            hold all
            h = errorbar(InsideAvHiddenPerRun,InsideSTDhidden,'o','LineWidth',1);
            ylabel('Average Hidden Nodes','FontSize',12)
        end

        legend('Final test set', 'Test set inside EPNet', 'FontSize', 12);
        xlabel('Experiments','FontSize',12);
        %xvectorVal = [0:tamExps];
        
        string2title = ['\it{',TSname,'}'];
        title(string2title,'FontSize',16');
        set(gca,'XTickLabel',TicksX);
        %set(gca,'XTick', xvectorVal);
        
        foo = 'to make a pause put s break point here';
        if i==1
%             saveas(h, [dir2save{2,1},TSname,'AverageAccuracy2plots.fig']);
%             clf;
%             clear h
        elseif i==2
            saveas(h, [dir2save{2,1},TSname,'AverageNRMS2plots.fig']);
            %saveas(h, [dir2save{2,1},TSname,'AverageNRMS.eps']); %works
            clf;
            clear h
        elseif i==3
            saveas(h, [dir2save{2,1},TSname,'AverageConn2plots.fig']);
            clf;
            clear h
        elseif i==4
            saveas(h, [dir2save{2,1},TSname,'Averageinputs2plots.fig']);
            clf;
            clear h
        elseif i==5
            saveas(h, [dir2save{2,1},TSname,'Averagehidden2plots.fig']);
            clf;
            clear h
        end
    end