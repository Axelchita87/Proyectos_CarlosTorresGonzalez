function vars = saveVars(vars, Pop, generation, sizePop, type)
%function to save all the infor per generation

vars.AvFitness(1,generation) = mean(Pop.fitness(:,1));
vars.stdFitness(1,generation) = std(Pop.fitness(:,1));
vars.bestFitness(1,generation) = Pop.fitness(1,1);
vars.worstFitness(1,generation) = Pop.fitness(sizePop,1);

vars.AvNoInd(1,generation) = mean(sum(Pop.string,2));
vars.stdNoInd(1,generation) = std(sum(Pop.string,2));
vars.bestNoInd(1,generation) = sum(Pop.string(1,:));
vars.worstNoInd(1,generation) = sum(Pop.string(sizePop,:));

if(strcmp(type,'RBLC'))
    vars.AvBeta(1,generation) = mean(Pop.beta(:,1));
    vars.stdBeta(1,generation) = std(Pop.beta(:,1));
    vars.bestBeta(1,generation) = Pop.beta(1,1);
    vars.worstBeta(1,generation) = Pop.beta(sizePop,1);
end
vars.bestString{1,generation} = Pop.string(1,:);















