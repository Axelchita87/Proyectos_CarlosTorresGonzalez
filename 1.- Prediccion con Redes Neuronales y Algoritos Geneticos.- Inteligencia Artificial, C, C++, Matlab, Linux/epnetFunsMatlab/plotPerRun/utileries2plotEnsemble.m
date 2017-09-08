% %script to plot Ensembles check.....
% UPDATE FILE TO THE REQUIRED
% %clear
% %clc
% 
% cd('res');
% load allrun.mat
% 
% corrida = size(allrun,2);
% 
% %%%%%%%%%%%%%%%%%%%%%%%%%%  First AVERAGE  %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% 
% Etestset = zeros(1,corrida);
% 
% %obtain the fitness of all ensemble per run, to see the best in all runs 
% for i=1:corrida
%    Etestset(1,i) = allrun{1,i}.ensemble.Average.NRMSE;
% end
% 
% [minimo, pos] = min(Etestset);
% 
% %load the data of the best network
% temp = zeros(1,allrun{1,1}.var.Pred_stepAhead);
% temp = allrun{1,pos}.ensemble.Average.Pred;
%  
%   
% cd('..');
% cd('figs_fig')
%  
% h = plot(temp,'b--');
% hold all
% h = plot(allrun{pos}.sets.toPredictF,'r-');
% xlabel('n','FontSize',10)
% ylabel('X(n)','FontSize',10)
% title('\it{Henon, Ensemble Average}','FontSize',16)
% legend('Prediction','Original');
% saveas(h, 'BestPredEnsembleAverage.fig')
% clf
% clear h
% %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% %%% For the Accuracy final
% h = plot(allrun{1,pos}.ensemble.Average.accuracyPoint,'b--');
% xlabel('n','FontSize',10)
% ylabel('Accuracy','FontSize',10)
% title('\it{Henon, Ensemble Average}','FontSize',16)
% %legend('Accuracy of Best Prediction','Original');
% saveas(h, 'AccuracyEnsembleAverage.fig')
% clf
% 
% 
% 
% 
% %%%%%%%%%%%%%%%%  Ensemble  S Rank base Linear Compbination %%%%%%%%%%%%%%%
% 
% 
% 
% Etestset = zeros(1,corrida);
% 
% %determinate what is the best beta for the algorithm, for beta see paper: 
% %MAking use of Population information in Evol ANN, Xin
% 
% EtempBeta = zeros(1,corrida);
% tempB1 = 0;
% tempB25 = 0;
% tempB5 = 0;
% tempB75 = 0;
% 
% for i=1:corrida
%    EtempBeta(1,i) = allrun{1,i}.ensemble.OutputBestSRBLC;
%    switch allrun{1,i}.ensemble.OutputBestSRBLC
%        case 0.1
%            tempB1 = tempB1+1;
%        case 0.25
%            tempB25 = tempB25 +1;
%        case 0.5
%            tempB5 = tempB5 +1;
%        case 0.75
%            tempB75 = tempB75 + 1;
%    end
% end
% 
% arraytempbeta(1,1) = tempB1;
% arraytempbeta(1,2) = tempB25;
% arraytempbeta(1,3) = tempB5;
% arraytempbeta(1,4) = tempB75;
% 
% [MaxBeta, posBeta] = max(arraytempbeta);
% 
% switch posBeta
%     case 1
%         structSRBLC = 'allrun{1,i}.ensemble.SRank_base_LCombination_1';
%     case 2  
%         structSRBLC = 'allrun{1,i}.ensemble.SRank_base_LCombination_25';
%     case 3
%         structSRBLC = 'allrun{1,i}.ensemble.SRank_base_LCombination_5';
%     case 4
%         structSRBLC = 'allrun{1,i}.ensemble.SRank_base_LCombination_75';
% end
% %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% 
% 
% 
% %obtain the fitness of all ensemble per run, to see the best in all runs 
% for i=1:corrida
%    Etestset(1,i) = eval([structSRBLC,'.NRMSE']);
% end
%  
% [minimo, pos] = min(Etestset);
%  
% %load the data of the best network
% temp = zeros(1,allrun{1}.var.Pred_stepAhead);
% for i=pos:pos                %only to set i to the correct value in structSRBLC
%     temp = eval([structSRBLC,'.Pred']);
% end
% 
% h = plot(temp,'b--');
% hold all
% h = plot(allrun{pos}.sets.toPredictF,'r-');
% xlabel('n','FontSize',10)
% ylabel('X(n)','FontSize',10)
% title('\it{Henon, Ensemble Rank-Base L.C.}','FontSize',16)
% legend('Prediction','Original');
% saveas(h, 'BestPredEnsembleRBLC.fig')
% clf
% clear h
% %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% %%% For the Accuracy final
% for i=pos:pos                %only to set i to the correct value in structSRBLC
%     temp = eval([structSRBLC,'.accuracyPoint']);
% end
% 
% h = plot(temp,'b--');
% xlabel('n','FontSize',10)
% ylabel('Accuracy','FontSize',10)
% title('\it{Henon, Ensemble Rank-Base L.C.}','FontSize',16)
% %legend('Accuracy of Best Prediction','Original');
% saveas(h, 'AccuracyEnsembleRBLC.fig')
% clf
%  
%  
%  
% clear h allrun temp pos minimo i Etestset EtempBeta MAxBeta arraytempbeta
% clear posBeta structSRBLC tempB1 tempB25 tempB5 tempB75 MaxBeta
% %cd('..');
