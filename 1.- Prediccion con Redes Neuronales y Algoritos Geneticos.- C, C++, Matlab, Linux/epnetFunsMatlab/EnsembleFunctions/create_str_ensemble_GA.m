function [ensemble] = create_str_ensemble_GA(var,populationNum)    
    
ensemble.Pred = zeros(1,var.Pred_stepAhead);
ensemble.NRMSE = 0;
ensemble.individulas = zeros(1,populationNum);
ensemble.noInd = 0;