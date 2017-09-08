%set up space for the population and set all to zero
function [Pop] = initPop2zero(Pop, sizePop, sizeInd, type)

%population, is split into two variables, for networks and beta
Pop.string = zeros(sizePop,sizeInd);
Pop.fitness = zeros(sizePop,1);     %to save the fitness of each ind

if(strcmp(type,'RBLC'));
    Pop.beta = zeros(sizePop,1);
end
