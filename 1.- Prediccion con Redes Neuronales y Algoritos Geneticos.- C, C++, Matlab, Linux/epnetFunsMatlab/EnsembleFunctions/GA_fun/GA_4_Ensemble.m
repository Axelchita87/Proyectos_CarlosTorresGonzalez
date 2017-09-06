function [ensemble] = GA_4_Ensemble(ensemble, Network, type, var, sets)
%Function to apply  a GA to evolve ensembles

rand('twister',sum(100*clock));               %initialize the random number

%%%%%% Variables %%%%%%
sizeInd = size(Network,2);         %that will be the size of the genotype
sizePop = 40;
maxGen  = 3;
EliteNo = 2;
%not used
rates.popCrossoverRate = 80;
rates.popMutationRate = 20;
rates.indCrossoverRate = 50;
rates.indMutationRate = 20;

%Change evalfitnes function if next values change
toPredict = sets.toPredictF_norm;       % set to use inside and outside the GA
texttoPredict = 'iteratePredF_norm';
%%%%
toSelect = sizePop*2;		%parents to select, almost twice even I will not use all of them
%%%%%%%%%%%%%%%%%%%%%%%

%set up space for some Variables set all to zero
[Population, Offspring, sortedPop, vars_per_gen, selected] = setUpVars(sizePop, ...
    sizeInd, type, maxGen, toSelect);

%generate initial population
Population = initpop(Population,sizeInd,sizePop,type);

%Main loop
generation = 1;
while(1)
    generation;

    %Eval fitness of each individual, this fitness is independent form the
    %fitness of the Networks
    Population.fitness = eval_fitness(Population,sizeInd,sizePop, ...
        Network, type, var, toPredict);
    
    %Sort the individuals to obtain the Elite and variables to save.
    sortedPop = initPop2zero(sortedPop, sizePop, sizeInd, type);  %delete var form previous generations
    sortedPop = sort_Pop(Population,type);
    
    %save variables to obtain behaviour of the EA.
    vars_per_gen = saveVars(vars_per_gen, sortedPop, generation, sizePop, type);
    
    %Condition to terminate the GA
    if (generation >= maxGen)
        break;
    end
    
    %Put in the Offspring the two best individulas
    Offspring = initPop2zero(Offspring, sizePop, sizeInd, type);  %put in blank
    Offspring = elite(Offspring, sortedPop, EliteNo, type);
    
    %Select the indiviudals    SELECTION
    selected = initPop2zero(selected, sizePop, sizeInd, type);  %put in blank
    selected = rankSelection(selected, sortedPop, sizePop, type, toSelect);
    
    %apply crossover between two parents until the percentange of
    %individual created with this mode is full
    percentage = round(((sizePop-EliteNo)*8)/10);
    pos = 3;                %record the new offspring after this index, due Elite
    for i=1:2:percentage*2
        [Offspring, pos] = UCrossOver(Offspring, pos, selected, i, type, sizeInd);
    end
    tempi=i+2;
    
    %apply Mutation
    for i=tempi:toSelect
        [Offspring, pos] = MutationReal(Offspring, pos, selected, i, type, sizeInd);
        if (pos > sizePop)
            break;
        end
    end
    
    %replace the current population
    Population = initPop2zero(Population, sizePop, sizeInd, type); 
    Population = Offspring;
    
    

    generation = generation + 1;
end



%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% check this code with iteratePredI_norm and iteratePredF_norm
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


%Evaluate the best individual, with the last test set.
%toPredict = toPredict;
Mean_toPredict = mean(toPredict);

%save the selected networks that form the ensemble in a new variable
NetworkEns = [];
cont =0;
for i = 1:sizeInd
    if (sortedPop.string(1,i) == 1)
        cont = cont + 1;
        NetworkEns{1,cont} = Network{1,i};
    end
end

if(strcmp(type,'RBLC'))             %If the GA is for RBLC
    %sort

    %In some cases they could be sorted, in others not (ensemble per run)
    NetworkEns = sort_Pop(NetworkEns);

    %calculate weights and outputs, form Iterate Pred I norm / and
    %PreF_norm
    [ensemble.Pred, ensemble.weights] = GA_calcWeights_And_Outputs_given_Beta(ensemble.Pred, ...
        ensemble.weights, cont, sortedPop.beta(1,1), NetworkEns, texttoPredict);

    %save this value in the ensemble
    ensemble.beta = sortedPop.beta(1,1);
    
elseif(strcmp(type,'Average'))
    for i=1:cont
        ensemble.Pred = ensemble.Pred + NetworkEns{1,i}.iteratePredF_norm;
    end
    %average
    ensemble.Pred = ensemble.Pred / cont;

end

%%Calculate the Error
ensemble.NRMSE = sqrt( sum((ensemble.Pred - toPredict).^2)  /  sum((toPredict - Mean_toPredict).^2) );


%Save the information form the GA into the ensemble structure
ensemble.individulas = sortedPop.string(1,:);
ensemble.noInd = sum(sortedPop.string(1,:));
ensemble.fitnessInsideGA = sortedPop.fitness(1,1);
ensemble.vars_per_gen = vars_per_gen;
 

