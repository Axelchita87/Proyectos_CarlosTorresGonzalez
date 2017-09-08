function [Pred, weights] = calcWeights_And_Outputs_RawFit(Pred, weights, populationNum, Network)
    
% This fuction calculates the prediction given a value for Beta and return
% the weiths used to calculate the new prediction and the prediction (returned)
    
    sumFit = 0;        
    for i=1:populationNum 
        fitness(i) = 1/Network{1,i}.iterateNRMSE_F_norm;
        %sumBeta = sumBeta + exp(beta*(i));   %sum^{N}_{j=1}exp(beta*j)
    end
    sumFit = sum(fitness);
    
    for i=1:populationNum 
        weights(i) =  fitness(1,i) / sumFit;
    end
   
    %sum(weights)
    
    
    
   
    %// the prediction is taken from iteratePredF_norm
    
    for i=1:populationNum
        Pred = Pred +  (weights(i) * Network{1,i}.iteratePredF_norm); %1 in this moment only put the first line (1 pred)
    end