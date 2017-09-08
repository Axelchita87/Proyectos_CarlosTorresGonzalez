function [ensembleBlank] = init_ensembleGARawFit(var,populationNum)
    
ensembleBlank.Average = create_str_ensemble_GA(var,populationNum);
ensembleBlank.RawFit = create_str_ensemble_GA(var,populationNum);

ensembleBlank.RawFit.weights = zeros(1,populationNum);
