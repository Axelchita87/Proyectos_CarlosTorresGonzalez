function [ensembleBlank] = init_ensembleRawFit(var,populationNum)
    
ensembleBlank.Average = create_str_ensemble(var);
ensembleBlank.rawFit = create_str_ensemble(var);
ensembleBlank.weightsRawFit  = zeros(1,populationNum);
