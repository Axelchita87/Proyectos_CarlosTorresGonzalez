function fitness = eval_fitnessRawFit(Pop,sizeInd,sizePop,Net,type,val, toPredict)
%Function to evaluate the fitness

%Prototype
%input      
            %Pop        Population
            %sizeInd    size genotype
            %sizePop    No. Ind in the population
            %Net        Networks per run
            %RBLC       if is a GA for RBLC or not
            
%Given the string I will obtain the ensemble

%First I will create another variable with all the networks required
Mean_toPredict = mean(toPredict);

for individual = 1:sizePop             %to evaluate all individuals
    Network = [];
    %obtain the selected networks by the genotype to form the ensemble
    cont =0;
    for i = 1:sizeInd
        if (Pop.string(individual,i) == 1)
            cont = cont + 1;
            Network{1,cont} = Net{1,i};
        end
    end
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    
    if(strcmp(type,'RawFit'))             %If the GA is for RBLC
        %sort
        
        %In some cases they could be sorted, in others not (ensemble per run)       
        Network = sort_Pop(Network);
        
        %calculate weights and outputs, form Iterate Pred I norm
        Pred = zeros(1, val.Pred_stepAhead);
        weights = zeros(1, cont);
        
        [Pred, weights] = GA_calcWeightsRawFit(Pred, ...
            weights, cont, Network, 'iteratePredF_norm');
        
             
        
    elseif(strcmp(type,'Average'))
        Pred = zeros(1, val.Pred_stepAhead);
        
        for i=1:cont
            Pred = Pred + Network{1,i}.iteratePredF_norm;
        end
        %average
        Pred = Pred / cont;
    
    
    
    end
    
    %%Calculate the Error
    fitness(individual,1) = sqrt( sum((Pred - toPredict).^2)  /  sum((toPredict - Mean_toPredict).^2) );
        
    
end






