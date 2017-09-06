function [ensemble] = create_str_ensemble(var)    
    
ensemble.Pred = zeros(1,var.Pred_stepAhead);
ensemble.NRMSE = 0;
% ensemble.accuracyPoint = zeros(1,var.Pred_stepAhead);
% ensemble.accuracy = 0; 