%script to plot the predictions from the ensemble formed from all the best
%individual from each run

%clear
clc


%this file is call form ../ensemblePerRun, so the required variables are
%there, not need to load files

%load allrun.mat

%corrida = size(allrun,2);

%%%%%%%%%%%%%%%%%%%%%%%%%%  First AVERAGE  %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


%load the data of the best network
temp = zeros(1,allrun{1,1}.var.Pred_stepAhead);
temp = ensemblePerRun.ensembleAv.Pred;
 


cd('figs_fig')
 
h = plot(temp,'b--');
hold all
h = plot(toPredictF,'r-');
xlabel('n','FontSize',10)
ylabel('X(n)','FontSize',10)
title('\it{Henon, Ensemble Average (Per run)}','FontSize',16)
legend('Prediction','Original');
saveas(h, 'BestPredEnsembleAveragePerRun.fig')
clf
clear h
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%% For the Accuracy final
h = plot(ensemblePerRun.ensembleAv.accuracyPoint,'b--');
xlabel('n','FontSize',10)
ylabel('Accuracy','FontSize',10)
title('\it{Henon, Ensemble Average (Per run)}','FontSize',16)
%legend('Accuracy of Best Prediction','Original');
saveas(h, 'AccuracyEnsembleAveragePerRun.fig')
clf




%%%%%%%%%%%%%%%%  Ensemble  S Rank base Linear Compbination %%%%%%%%%%%%%%%
 
temp = zeros(1,allrun{1,1}.var.Pred_stepAhead);
temp = ensemblePerRun.ensembleRBLC.Pred;
 


h = plot(temp,'b--');
hold all
h = plot(toPredictF,'r-');
xlabel('n','FontSize',10)
ylabel('X(n)','FontSize',10)
title('\it{Henon, Ensemble Rank-Base L.C. (Per run)}','FontSize',16)
legend('Prediction','Original');
saveas(h, 'BestPredEnsembleRBLCPerRrun.fig')
clf
clear h
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

 
h = plot(ensemblePerRun.ensembleRBLC.accuracyPoint,'b--');
xlabel('n','FontSize',10)
ylabel('Accuracy','FontSize',10)
title('\it{Henon, Ensemble Rank-Base L.C. (Per run)}','FontSize',16)
%legend('Accuracy of Best Prediction','Original');
saveas(h, 'AccuracyEnsembleRBLCPerRun.fig')
clf
 
 
 
clear h allrun temp pos minimo i Etestset EtempBeta MAxBeta arraytempbeta
clear posBeta structSRBLC tempB1 tempB25 tempB5 tempB75 MaxBeta
cd('..');
