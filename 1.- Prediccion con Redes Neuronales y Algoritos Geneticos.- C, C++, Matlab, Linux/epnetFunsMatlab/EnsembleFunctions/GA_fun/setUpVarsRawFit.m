function [Pop, Off, tempPop, vars, selected] = setUpVarsRawFit(sizePop, ...
    sizeInd, type, maxGen, toSelect)

%variables for Pop and Off

Pop = [];
Off = [];
tempPop = [];

Pop = initPop2zero(Pop, sizePop, sizeInd, type);
Off = initPop2zero(Off, sizePop, sizeInd, type);
tempPop = initPop2zero(tempPop, sizePop, sizeInd, type);

%Variables to save info per generation
vars.AvFitness = zeros(1,maxGen);
vars.stdFitness = zeros(1,maxGen);
vars.bestFitness = zeros(1,maxGen);
vars.worstFitness = zeros(1,maxGen);

vars.AvNoInd = zeros(1,maxGen);
vars.stdNoInd = zeros(1,maxGen);
vars.bestNoInd = zeros(1,maxGen);
vars.worstNoInd = zeros(1,maxGen);


selected.string = zeros(toSelect,sizeInd);

for i=1:maxGen
    vars.bestString{1,i} = zeros(1,sizeInd);
end


