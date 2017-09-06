%% Plot the best prediction / classification and the accuracy
% Script to plot the best results of the simulation, i.e. the best over all
% runs
%
% Created: around 2008
% Modified at:  22 June 2011
% Author:       Carlos Torres and Victor Landassuri


%% Obtain the best over all runs
% Obtain the fitness of all best networks per run, to see the best in all runs
% prediction and classification are the same, both save the best error
% NRMSE or Epercentage in fitness
[minimo, pos] = obtainBest_of_Best(allrun);
[minGen gen] = obtainMinGen(allrun, corrida);



%% Functions to plot prediciton/Classification

% enter to the dir to save figures
if(exist('figs','dir') ~= 7)
    mkdir('figs');
end
cd('figs')



if (allrun{1,1}.var.task2solve == allrun{1,1}.C.PREDICT || strcmp(allrun{1,1}.var.typeDS,'NRMSE'))
    
    % calculate lines in the final prediciton
    lineT = size(allrun{1,1}.toPredictI,1);
    
    %load the data of the best network
    tempI = zeros(lineT,allrun{1,1}.var.Pred_stepAheadInside);
    tempF = zeros(lineT,allrun{1,1}.var.Pred_stepAhead);
    
    tempI = allrun{1,pos}.Network{1,1}.predictI.Pred;
    tempF = allrun{1,pos}.Network{1,1}.predictF.Pred;
    
    errorI = allrun{1,pos}.Network{1,1}.predictI.NRMSE(1,1);
    errorF = allrun{1,pos}.Network{1,1}.predictF.NRMSE(1,1);
    
    
    %     correlationI = corr(allrun{1,pos}.Network{1,1}.predictI.Pred', allrun{1,1}.toPredictI');
    %     correlationF = corr(allrun{1,pos}.Network{1,1}.predictF.Pred', allrun{1,1}.toPredictF');
    
    
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %%%%%%%%%%%%%%%   Plot the Best Final prediction   %%%%%%%%%%%%%%%%%%%%%%%%
    % settle axis
    for i=1:lineT                           % repeat for all predictios
        strPred = num2str(i);
        
        maxY = max(allrun{1,1}.toPredictF(i,:));
        minY = min(allrun{1,1}.toPredictF(i,:));
        
        correlationF = corr(allrun{1,pos}.Network{1,1}.predictF.Pred(i,:)', allrun{1,1}.toPredictF(i,:)');
        errorFperMod = F_NRMSE(tempF(i,:), allrun{1,1}.toPredictF(i,:) );
        
        if lineT > 1
            textNRMSEyCorr{1,1} = ['NRMSE total = ', num2str(errorF)];
            textNRMSEyCorr{2,1} = ['NRMSE module ',strPred,' = ', num2str(errorFperMod)];
            textNRMSEyCorr{3,1} = ['Correlation = ', num2str(correlationF,'% 1.4f') ];
        elseif lineT == 1
            textNRMSEyCorr{1,1} = ['NRMSE = ', num2str(errorF)];
            textNRMSEyCorr{2,1} = ['Correlation = ', num2str(correlationF,'% 1.4f') ];
        end
        
        clf
        h = plot(tempF(i,:),'b--','LineWidth',1);
        hold all
        h = plot(allrun{1,1}.toPredictF(i,:),'r-','LineWidth',1);
        
        
        axis([0 (allrun{1,1}.var.Pred_stepAhead+5) (minY+(minY/3)) (maxY+(maxY/3))]);   % axes plus and offset in each side
        h = text(5,maxY,textNRMSEyCorr, 'FontSize',gcaFotnSize);            % text showing the eror and correlation
        
        
        xlabel('n','FontSize',xylabeSize)
        ylabel('X(n)','FontSize',xylabeSize)
        string2title = ['\it{',TSname,'}'];
        title(string2title,'FontSize',16)
        legend('Prediction','Original');
        
        % textsize
        set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
        saveas(h, ['BestPredFinal',strPred,'.fig'])
        clear h maxY maxX textNRMSEyCorr
        
    end
    
    
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %%%%%%%%%%%%%%%   Plot the Best Inside prediction   %%%%%%%%%%%%%%%%%%%%%%%
    for i=1:lineT                           % repeat for all predictios
        strPred = num2str(i);
        
        clf
        maxY = max(allrun{1,1}.toPredictI(i,:));
        minY = min(allrun{1,1}.toPredictI(i,:));
        
        
        correlationI = corr(allrun{1,pos}.Network{1,1}.predictI.Pred(i,:)', allrun{1,1}.toPredictI(i,:)');
        errorIperMod = F_NRMSE(tempI(i,:), allrun{1,1}.toPredictI(i,:) );
        
        if lineT > 1
            textNRMSEyCorr{1,1} = ['NRMSE total = ', num2str(errorI)];
            textNRMSEyCorr{2,1} = ['NRMSE module ',strPred,' = ', num2str(errorIperMod)];
            textNRMSEyCorr{3,1} = ['Correlation = ', num2str(correlationI,'% 1.4f') ];
        elseif lineT == 1
            textNRMSEyCorr{1,1} = ['NRMSE = ', num2str(errorI)];
            textNRMSEyCorr{2,1} = ['Correlation = ', num2str(correlationI,'% 1.4f') ];
        end
        
        h = plot(tempI(i,:),'b--','LineWidth',1);
        hold all
        h = plot(allrun{1,1}.toPredictI(i,:),'r-','LineWidth',1);
        
        axis([0 (allrun{1,1}.var.Pred_stepAheadInside+5) (minY+(minY/3)) (maxY+(maxY/3))]);   % axes plus and offset in each side
        h = text(5,maxY,textNRMSEyCorr, 'FontSize',gcaFotnSize);            % text showing the eror and correlation
        
        xlabel('n','FontSize',xylabeSize)
        ylabel('X(n)','FontSize',xylabeSize)
        string2title = ['\it{',TSname,', inside pred}'];
        title(string2title,'FontSize',16)
        legend('Prediction','Original');
        % textsize
        set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
        saveas(h, ['BestPredInside',strPred,'.fig'])
        clear h maxY minY textNRMSEyCorr
        
    end
    
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %%%%%%%%%%%%%%%%%% Plot the error per prediciton Final %%%%%%%%%%%%%%%%%%
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    
    % error
    for i=1:lineT                           % repeat for all predictios
        strPred = num2str(i);
        
        errorPred = allrun{1,1}.toPredictF(i,:) - tempF(i,:);
        
        
        clf
        h = plot(errorPred,'b-','LineWidth',1);
        
        
        xlabel('n','FontSize',xylabeSize)
        ylabel('Error','FontSize',xylabeSize)
        string2title = ['\it{',TSname,'}'];
        title(string2title,'FontSize',16)
        
        % textsize
        set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
        saveas(h, ['errorBestPredFinal',strPred,'.fig'])
        clear h
    end
    
    
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %%%%%%%%%%%%%%%%%% Plot the Accuracy final %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    
    for i=1:lineT                           % repeat for all predictios
        strPred = num2str(i);
        
        clf
        h = plot(allrun{1,pos}.Network{1,1}.predictF.accuracyPoint(i,:),'b--','LineWidth',1);
        xlabel('n','FontSize',xylabeSize)
        ylabel('Accuracy of Best Prediction','FontSize',xylabeSize)
        title(string2title,'FontSize',16)
        %legend('Accuracy of Best Prediction','Original');
        % textsize
        set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
        saveas(h, ['AccuracyFinalBestPred',strPred,'.fig'])
    end
    clf
    
elseif (allrun{1,1}.var.task2solve == allrun{1,1}.C.CLASSIFY && ~strcmp(allrun{1,1}.var.typeDS,'NRMSE') )
    % Classification
    %
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    % plot the Av and best Classification error per generation of the best individual %
    clf
    h = plot(allrun{1,pos}.ALLParam.AvClassifError( 1:minGen ),'b--','LineWidth',1);
    hold all
    h = plot(allrun{1,pos}.ALLParam.bestClassifError( 1:minGen ),'r-','LineWidth',1);
    
    
    xlabel('Generations','FontSize',xylabeSize)
    ylabel('Fitness','FontSize',xylabeSize)
    string2title = ['\it{',TSname,'. ClassifError','}'];
    title(string2title,'FontSize',16)
    legend('Average','Best');
    % textsize
    set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
    saveas(h, 'AvBest_ClassifError.fig')
    clf
    clear h
    
    
end





if ( allrun{1,1}.var.extraPredictions == allrun{1,1}.C.ON )
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %%%%%%%%%%%%%%%   Plot mores steps ahead %%%%%%%%%%%%%%%%%%%%%%%
    %One step
    %15, 30, 60, 120, 240, 480 steps
    con = allrun{1,1}.var.initialStepPred;
    for i=1:allrun{1,1}.var.numDiffPredict
        
        h = plot(allrun{1,pos}.Network{1,1}.set2SSP{1,i}.Pred,'b--','LineWidth',1);
        hold all
        h = plot(allrun{1,1}.toPredict{1,i}(1,:),'r-','LineWidth',1);
        xlabel('n','FontSize',xylabeSize)
        ylabel('X(n)','FontSize',xylabeSize)
        string2title = ['\it{',TSname,'. One Step Prediction}'];
        title(string2title,'FontSize',16)
        legend('Prediction','Original');
        % textsize
        set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
        saveas(h, ['set2SSP', num2str(con),'.fig'])
        con = con * 2;
        clf
        clear h
    end
    
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %%%%%%%%%%%%%%%   Plot Iterate Predicitonmore steps %%%%%%%%%%%%%%%%%%%%%%%
    %Iterate pred
    %
    con = allrun{1,1}.var.initialStepPred;
    for i=1:allrun{1,1}.var.numDiffPredict
        
        h = plot(allrun{1,pos}.Network{1,1}.set2MSP{1,i}.Pred,'b--','LineWidth',1);
        hold all
        h = plot(allrun{1,1}.toPredict{1,i}(1,:),'r-','LineWidth',1);
        xlabel('n','FontSize',xylabeSize)
        ylabel('X(n)','FontSize',xylabeSize)
        string2title = ['\it{',TSname,'. Iterate Predcition}'];
        title(string2title,'FontSize',16)
        legend('Prediction','Original');
        % textsize
        set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
        saveas(h, ['set2MSP', num2str(con),'.fig'])
        con = con * 2;
        clf
        clear h
    end
    
end




%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Plot the Wost, Av and best fitness per generation of the best individual %

h = plot(allrun{1,pos}.ALLParam.worstfitness( 1:minGen ),'b--','LineWidth',1);
hold all
h = plot(allrun{1,pos}.ALLParam.Avfitness( 1:minGen ),'r-','LineWidth',1);
h = plot(allrun{1,pos}.ALLParam.bestfitness( 1:minGen ),'k','LineWidth',1);

% if the TS iscd('figs_fig'): Logistic, Lorenz, Rossler or start put Yaxes in log scale
%if (TSdir == 3) || (TSdir == 4) || (TSdir == 8 ) || (TSdir == 18)
%    set(gca, 'YScale', 'log')
%end

xlabel('Generations','FontSize',xylabeSize)
ylabel('Fitness','FontSize',xylabeSize)
string2title = ['\it{',TSname,'. Fitness of the best individual','}'];
title(string2title,'FontSize',16)
legend('Worst','Average','Best');
% textsize
set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
%set(gcf, 'Visible', 'on')
saveas(h, 'WorstAvBest_fitness.fig')
clf
clear h

% %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% % Plot the Wost Av and best fitness per generation of the best individual %
% % with all the population fitness %
%
% h = plot(allrun{1,pos}.ALLParam.worstfitness,'b--','LineWidth',1);
% hold all
% h = plot(allrun{1,pos}.ALLParam.Avfitness,'r-','LineWidth',1);
% h = plot(allrun{1,pos}.ALLParam.bestfitness,'k','LineWidth',1);
%
% for i=1:allrun{1,1}.var.populationNum
%     h = plot(allrun{1,pos}.ALLParam.AllpopFitness(i,:),':k','LineWidth',1);
% end
%
% % if the TS is: Logistic, Lorenz, Rossler or start put Yaxes in log scale
% %if (TSdir == 3) || (TSdir == 4) || (TSdir == 8 ) || (TSdir == 18)
% %    set(gca, 'YScale', 'log')
% %end
%
% xlabel('Generations','FontSize',12)
% ylabel('Fitness','FontSize',12)
% string2title = ['\it{',TSname,'. Fitness All Pop., best individual','}'];
% title(string2title,'FontSize',16)
% %legend('Worst','Average','Best');
% saveas(h, 'FitnessAllPop_bestInd.fig')
% clf
% clear h







clear h tempI tempF pos minimo i string2title
cd('..');
