function [ensembleBlank] = init_ensembleGA(var,populationNum)
    
ensembleBlank.Average = create_str_ensemble_GA(var,populationNum);
ensembleBlank.RBLC = create_str_ensemble_GA(var,populationNum);

ensembleBlank.RBLC.beta = 0;
ensembleBlank.RBLC.weights = zeros(1,populationNum);

%ensembleBlank.SRLS_alg = create_str_ensemble(var);
%ensembleBlank.GA = create_str_ensemble(var);
    