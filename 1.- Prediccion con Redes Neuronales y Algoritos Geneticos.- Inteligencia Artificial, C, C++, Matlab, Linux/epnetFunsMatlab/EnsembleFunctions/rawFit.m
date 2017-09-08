function ensemble = rawFit(ensemble, var, populationNum, Network, toPredictF, Mean_toPredictF)

%Here is claculate the predictions, errors and accuracy form normilized
%data
%as a reason that it is not the RBLC, there is no beta


  
    %//calculate the output with the raw fitnes
    
    %%Calculte weights for the networks
    [ensemble.rawFit.Pred, ensemble.weightsRankBase_05] = ...
        calcWeights_And_Outputs_RawFit(ensemble.rawFit.Pred, ...
        ensemble.weightsRawFit, populationNum, Network);
    
    %%Calculate the Error and Accuracy
    ensemble.rawFit = NRMSError_Accuracy(ensemble.rawFit, ...
        toPredictF, Mean_toPredictF, var);
    
    
    
%     %// FOR 0.1 ////////////////////////////////////////////////////////////
%     
%     %//calculate the output with the Rank-base Linear Combination
%     
%     %%Calculte weights for the networks
%     
%     [ensemble.SRank_base_LCombination_1.Pred, ensemble.weightsRankBase_1] = ...
%         calcWeights_And_Outputs_given_Beta(ensemble.SRank_base_LCombination_1.Pred, ...
%         ensemble.weightsRankBase_1, populationNum, beta_1, Network);
%     %%Calculate the Error and Accuracy
%     ensemble.SRank_base_LCombination_1 = NRMSError_Accuracy(ensemble.SRank_base_LCombination_1, ...
%         toPredictF, Mean_toPredictF, var);
%     
%     if(ensemble.SRank_base_LCombination_1.NRMSE < nrmsMin)
%         minimo = 0.1;
%         nrmsMin = ensemble.SRank_base_LCombination_1.NRMSE;
%     end
%     
%     
%     %// FOR 0.15 ////////////////////////////////////////////////////////////
%     
%     %//calculate the output with the Rank-base Linear Combination
%     
%     %%Calculte weights for the networks
%     
%     [ensemble.SRank_base_LCombination_15.Pred, ensemble.weightsRankBase_15] = ...
%         calcWeights_And_Outputs_given_Beta(ensemble.SRank_base_LCombination_15.Pred, ...
%         ensemble.weightsRankBase_15, populationNum, beta_15, Network);
%     %%Calculate the Error and Accuracy
%     ensemble.SRank_base_LCombination_15 = NRMSError_Accuracy(ensemble.SRank_base_LCombination_15, ...
%         toPredictF, Mean_toPredictF, var);
%     
%     
%     if(ensemble.SRank_base_LCombination_15.NRMSE < nrmsMin)
%         minimo = 0.15;
%         nrmsMin = ensemble.SRank_base_LCombination_15.NRMSE;
%     end
%     
%     
%     %// FOR 0.2 ////////////////////////////////////////////////////////////
%     
%     %//calculate the output with the Rank-base Linear Combination
%     
%     %%Calculte weights for the networks
%     
%     [ensemble.SRank_base_LCombination_2.Pred, ensemble.weightsRankBase_2] = ...
%         calcWeights_And_Outputs_given_Beta(ensemble.SRank_base_LCombination_2.Pred, ...
%         ensemble.weightsRankBase_2, populationNum, beta_2, Network);
%     %%Calculate the Error and Accuracy
%     ensemble.SRank_base_LCombination_2 = NRMSError_Accuracy(ensemble.SRank_base_LCombination_2, ...
%         toPredictF, Mean_toPredictF, var);
%     
%     if(ensemble.SRank_base_LCombination_2.NRMSE < nrmsMin)
%         minimo = 0.2;
%         nrmsMin = ensemble.SRank_base_LCombination_2.NRMSE;
%     end
%     
%     
%     %// FOR 0.25 ////////////////////////////////////////////////////////////
%     
%     %//calculate the output with the Rank-base Linear Combination
%     
%     %%Calculte weights for the networks
%     
%     [ensemble.SRank_base_LCombination_25.Pred, ensemble.weightsRankBase_25] = ...
%         calcWeights_And_Outputs_given_Beta(ensemble.SRank_base_LCombination_25.Pred, ...
%         ensemble.weightsRankBase_25, populationNum, beta_25, Network);
%     %%Calculate the Error and Accuracy
%     ensemble.SRank_base_LCombination_25 = NRMSError_Accuracy(ensemble.SRank_base_LCombination_25, ...
%         toPredictF, Mean_toPredictF, var);
%     
%     if(ensemble.SRank_base_LCombination_25.NRMSE < nrmsMin)
%         minimo = 0.25;
%         nrmsMin = ensemble.SRank_base_LCombination_25.NRMSE;
%     end
%     
%     
%     %// FOR 0.3 ////////////////////////////////////////////////////////////
%     
%     %//calculate the output with the Rank-base Linear Combination
%     
%     %%Calculte weights for the networks
%     
%     [ensemble.SRank_base_LCombination_3.Pred, ensemble.weightsRankBase_3] = ...
%         calcWeights_And_Outputs_given_Beta(ensemble.SRank_base_LCombination_3.Pred, ...
%         ensemble.weightsRankBase_3, populationNum, beta_3, Network);
%     %%Calculate the Error and Accuracy
%     ensemble.SRank_base_LCombination_3 = NRMSError_Accuracy(ensemble.SRank_base_LCombination_3, ...
%         toPredictF, Mean_toPredictF, var);
%     
%     if(ensemble.SRank_base_LCombination_3.NRMSE < nrmsMin)
%         minimo = 0.3;
%         nrmsMin = ensemble.SRank_base_LCombination_3.NRMSE;
%     end
%     
%     
%     %// FOR 0.35 ////////////////////////////////////////////////////////////
%     
%     %//calculate the output with the Rank-base Linear Combination
%     
%     %%Calculte weights for the networks
%     
%     [ensemble.SRank_base_LCombination_35.Pred, ensemble.weightsRankBase_35] = ...
%         calcWeights_And_Outputs_given_Beta(ensemble.SRank_base_LCombination_35.Pred, ...
%         ensemble.weightsRankBase_35, populationNum, beta_35, Network);
%     %%Calculate the Error and Accuracy
%     ensemble.SRank_base_LCombination_35 = NRMSError_Accuracy(ensemble.SRank_base_LCombination_35, ...
%         toPredictF, Mean_toPredictF, var);
%     
%     if(ensemble.SRank_base_LCombination_35.NRMSE < nrmsMin)
%         minimo = 0.35;
%         nrmsMin = ensemble.SRank_base_LCombination_35.NRMSE;
%     end
%     
%     
%     %// FOR 0.4 ////////////////////////////////////////////////////////////
%     
%     %//calculate the output with the Rank-base Linear Combination
%     
%     %%Calculte weights for the networks
%     
%     [ensemble.SRank_base_LCombination_4.Pred, ensemble.weightsRankBase_4] = ...
%         calcWeights_And_Outputs_given_Beta(ensemble.SRank_base_LCombination_4.Pred, ...
%         ensemble.weightsRankBase_4, populationNum, beta_4, Network);
%     %%Calculate the Error and Accuracy
%     ensemble.SRank_base_LCombination_4 = NRMSError_Accuracy(ensemble.SRank_base_LCombination_4, ...
%         toPredictF, Mean_toPredictF, var);
%     
%     if(ensemble.SRank_base_LCombination_4.NRMSE < nrmsMin)
%         minimo = 0.4;
%         nrmsMin = ensemble.SRank_base_LCombination_4.NRMSE;
%     end
%     
%     
%     
%     %// FOR 0.45 ////////////////////////////////////////////////////////////
%     
%     %//calculate the output with the Rank-base Linear Combination
%     
%     %%Calculte weights for the networks
%     
%     [ensemble.SRank_base_LCombination_45.Pred, ensemble.weightsRankBase_45] = ...
%         calcWeights_And_Outputs_given_Beta(ensemble.SRank_base_LCombination_45.Pred, ...
%         ensemble.weightsRankBase_45, populationNum, beta_45, Network);
%     %%Calculate the Error and Accuracy
%     ensemble.SRank_base_LCombination_45 = NRMSError_Accuracy(ensemble.SRank_base_LCombination_45, ...
%         toPredictF, Mean_toPredictF, var);
%     
%     if(ensemble.SRank_base_LCombination_45.NRMSE < nrmsMin)
%         minimo = 0.45;
%         nrmsMin = ensemble.SRank_base_LCombination_45.NRMSE;
%     end
%     
%     
%     %// FOR 0.5 ////////////////////////////////////////////////////////////
%     
%     %//calculate the output with the Rank-base Linear Combination
%     
%     %%Calculte weights for the networks
%     
%     [ensemble.SRank_base_LCombination_5.Pred, ensemble.weightsRankBase_5] = ...
%         calcWeights_And_Outputs_given_Beta(ensemble.SRank_base_LCombination_5.Pred, ...
%         ensemble.weightsRankBase_5, populationNum, beta_5, Network);
%     %%Calculate the Error and Accuracy
%     ensemble.SRank_base_LCombination_5 = NRMSError_Accuracy(ensemble.SRank_base_LCombination_5, ...
%         toPredictF, Mean_toPredictF, var);
%     
%     if(ensemble.SRank_base_LCombination_5.NRMSE < nrmsMin)
%         minimo = 0.5;
%         nrmsMin = ensemble.SRank_base_LCombination_5.NRMSE;
%     end
%     
%     
%     %// FOR 0.55 ////////////////////////////////////////////////////////////
%     
%     %//calculate the output with the Rank-base Linear Combination
%     
%     %%Calculte weights for the networks
%     
%     [ensemble.SRank_base_LCombination_55.Pred, ensemble.weightsRankBase_55] = ...
%         calcWeights_And_Outputs_given_Beta(ensemble.SRank_base_LCombination_55.Pred, ...
%         ensemble.weightsRankBase_55, populationNum, beta_55, Network);
%     %%Calculate the Error and Accuracy
%     ensemble.SRank_base_LCombination_55 = NRMSError_Accuracy(ensemble.SRank_base_LCombination_55, ...
%         toPredictF, Mean_toPredictF, var);
%     
%     if(ensemble.SRank_base_LCombination_55.NRMSE < nrmsMin)
%         minimo = 0.55;
%         nrmsMin = ensemble.SRank_base_LCombination_55.NRMSE;
%     end
%     
%     
%     %// FOR 0.6 ////////////////////////////////////////////////////////////
%     
%     %//calculate the output with the Rank-base Linear Combination
%     
%     %%Calculte weights for the networks
%     
%     [ensemble.SRank_base_LCombination_6.Pred, ensemble.weightsRankBase_6] = ...
%         calcWeights_And_Outputs_given_Beta(ensemble.SRank_base_LCombination_6.Pred, ...
%         ensemble.weightsRankBase_6, populationNum, beta_6, Network);
%     %%Calculate the Error and Accuracy
%     ensemble.SRank_base_LCombination_6 = NRMSError_Accuracy(ensemble.SRank_base_LCombination_6, ...
%         toPredictF, Mean_toPredictF, var);
%     
%     if(ensemble.SRank_base_LCombination_6.NRMSE < nrmsMin)
%         minimo = 0.6;
%         nrmsMin = ensemble.SRank_base_LCombination_6.NRMSE;
%     end
%     
%     
%     %// FOR 0.65 ////////////////////////////////////////////////////////////
%     
%     %//calculate the output with the Rank-base Linear Combination
%     
%     %%Calculte weights for the networks
%     
%     [ensemble.SRank_base_LCombination_65.Pred, ensemble.weightsRankBase_65] = ...
%         calcWeights_And_Outputs_given_Beta(ensemble.SRank_base_LCombination_65.Pred, ...
%         ensemble.weightsRankBase_65, populationNum, beta_65, Network);
%     %%Calculate the Error and Accuracy
%     ensemble.SRank_base_LCombination_65 = NRMSError_Accuracy(ensemble.SRank_base_LCombination_65, ...
%         toPredictF, Mean_toPredictF, var);
%     
%     if(ensemble.SRank_base_LCombination_65.NRMSE < nrmsMin)
%         minimo = 0.65;
%         nrmsMin = ensemble.SRank_base_LCombination_65.NRMSE;
%     end
%     
%     
%     %// FOR 0.7 ////////////////////////////////////////////////////////////
%     
%     %//calculate the output with the Rank-base Linear Combination
%     
%     %%Calculte weights for the networks
%     
%     [ensemble.SRank_base_LCombination_7.Pred, ensemble.weightsRankBase_7] = ...
%         calcWeights_And_Outputs_given_Beta(ensemble.SRank_base_LCombination_7.Pred, ...
%         ensemble.weightsRankBase_7, populationNum, beta_7, Network);
%     %%Calculate the Error and Accuracy
%     ensemble.SRank_base_LCombination_7 = NRMSError_Accuracy(ensemble.SRank_base_LCombination_7, ...
%         toPredictF, Mean_toPredictF, var);
%     
%     if(ensemble.SRank_base_LCombination_7.NRMSE < nrmsMin)
%         minimo = 0.7;
%         nrmsMin = ensemble.SRank_base_LCombination_7.NRMSE;
%     end
%     
%     
%     
%     %// FOR 0.75 ////////////////////////////////////////////////////////////
%     
%     %//calculate the output with the Rank-base Linear Combination
%     
%     %%Calculte weights for the networks
%     
%     [ensemble.SRank_base_LCombination_75.Pred, ensemble.weightsRankBase_75] = ...
%         calcWeights_And_Outputs_given_Beta(ensemble.SRank_base_LCombination_75.Pred, ...
%         ensemble.weightsRankBase_75, populationNum, beta_75, Network);
%     %%Calculate the Error and Accuracy
%     ensemble.SRank_base_LCombination_75 = NRMSError_Accuracy(ensemble.SRank_base_LCombination_75, ...
%         toPredictF, Mean_toPredictF, var);
%     
%     if(ensemble.SRank_base_LCombination_75.NRMSE < nrmsMin)
%         minimo = 0.75;
%         nrmsMin = ensemble.SRank_base_LCombination_75.NRMSE;
%     end
%     
%     
%     %// FOR 0.8 ////////////////////////////////////////////////////////////
%     
%     %//calculate the output with the Rank-base Linear Combination
%     
%     %%Calculte weights for the networks
%     
%     [ensemble.SRank_base_LCombination_8.Pred, ensemble.weightsRankBase_8] = ...
%         calcWeights_And_Outputs_given_Beta(ensemble.SRank_base_LCombination_8.Pred, ...
%         ensemble.weightsRankBase_8, populationNum, beta_8, Network);
%     %%Calculate the Error and Accuracy
%     ensemble.SRank_base_LCombination_8 = NRMSError_Accuracy(ensemble.SRank_base_LCombination_8, ...
%         toPredictF, Mean_toPredictF, var);
%     
%     if(ensemble.SRank_base_LCombination_8.NRMSE < nrmsMin)
%         minimo = 0.8;
%         nrmsMin = ensemble.SRank_base_LCombination_8.NRMSE;
%     end
%     
%     
%     %// FOR 0.85 ////////////////////////////////////////////////////////////
%     
%     %//calculate the output with the Rank-base Linear Combination
%     
%     %%Calculte weights for the networks
%     
%     [ensemble.SRank_base_LCombination_85.Pred, ensemble.weightsRankBase_85] = ...
%         calcWeights_And_Outputs_given_Beta(ensemble.SRank_base_LCombination_85.Pred, ...
%         ensemble.weightsRankBase_85, populationNum, beta_85, Network);
%     %%Calculate the Error and Accuracy
%     ensemble.SRank_base_LCombination_85 = NRMSError_Accuracy(ensemble.SRank_base_LCombination_85, ...
%         toPredictF, Mean_toPredictF, var);
%     
%     if(ensemble.SRank_base_LCombination_85.NRMSE < nrmsMin)
%         minimo = 0.85;
%         nrmsMin = ensemble.SRank_base_LCombination_85.NRMSE;
%     end
%     
%     
%     %// FOR 0.9 ////////////////////////////////////////////////////////////
%     
%     %//calculate the output with the Rank-base Linear Combination
%     
%     %%Calculte weights for the networks
%     
%     [ensemble.SRank_base_LCombination_9.Pred, ensemble.weightsRankBase_9] = ...
%         calcWeights_And_Outputs_given_Beta(ensemble.SRank_base_LCombination_9.Pred, ...
%         ensemble.weightsRankBase_9, populationNum, beta_9, Network);
%     %%Calculate the Error and Accuracy
%     ensemble.SRank_base_LCombination_9 = NRMSError_Accuracy(ensemble.SRank_base_LCombination_9, ...
%         toPredictF, Mean_toPredictF, var);
%     
%     if(ensemble.SRank_base_LCombination_9.NRMSE < nrmsMin)
%         minimo = 0.9;
%         nrmsMin = ensemble.SRank_base_LCombination_9.NRMSE;
%     end
%     
%     
%     %// FOR 0.95 ////////////////////////////////////////////////////////////
%     
%     %//calculate the output with the Rank-base Linear Combination
%     
%     %%Calculte weights for the networks
%     
%     [ensemble.SRank_base_LCombination_95.Pred, ensemble.weightsRankBase_95] = ...
%         calcWeights_And_Outputs_given_Beta(ensemble.SRank_base_LCombination_95.Pred, ...
%         ensemble.weightsRankBase_95, populationNum, beta_95, Network);
%     %%Calculate the Error and Accuracy
%     ensemble.SRank_base_LCombination_95 = NRMSError_Accuracy(ensemble.SRank_base_LCombination_95, ...
%         toPredictF, Mean_toPredictF, var);
%     
%     if(ensemble.SRank_base_LCombination_95.NRMSE < nrmsMin)
%         minimo = 0.95;
%         nrmsMin = ensemble.SRank_base_LCombination_95.NRMSE;
%     end
%     
%     ensemble.OutputBestSRBLC = minimo;
    




