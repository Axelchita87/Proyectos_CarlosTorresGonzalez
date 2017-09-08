function [Pred, weights] = GA_calcWeightsRawFit(Pred, ...
    weights, populationNum, Network, from)
    
% This fuction calculates the prediction given a value for Beta and return
% the weiths used to calculate the new prediction and the prediction (returned)

%prototype
%Input
    %Pred               variable where is saved the prediction
    %weights            variable where is save the weighs
    %populationNum      No ind in the population
    %beta               The beta needed to calculate the weights
    %Network            The Population
    %from               the set to obtain prediction and calculate the
                        %output of the ensemble:
                            %iteratePredI_norm or
                            %iteratePredF_norm
    
    Net = ['Network{1,i}.',from];                        
                            
        
    sumFit = 0;  
    fitness = 0;
    for i=1:populationNum 
        fitness(i) = 1 / Network{1,i}.iterateNRMSE_F_norm;
    end
    sumFit = sum(fitness);
    
    for i=1:populationNum 
        weights(i) =  fitness(1,i) / sumFit;
    end

   
    %// the prediction is taken from iteratePredI_norm
    %Net = ['Network{1,i}.',from];
    for i=1:populationNum
        Pred = Pred +  (weights(i) * eval(Net)); %1 in this moment only put the first line (1 pred)
    end