function [Off, posOff] = UCrossOver(Off, posOff, Pop, posPop, type, sizeInd)
%Combine two parent with uniform crossover to form an offspring
%input
    %Off        offspring
    %posOff     possition to start record the new individulas
    %Pop        Population
    %posPop     possition to start reading the parents
    %type       type of GA, Average or RBLC
    %sizeInd    the size of genotype


%if rand < 0.5 take bit form parent 1, else parent 2
% Disperse crossover - segun matlab scattered crossover
% but it must create tow offspring not only one, the sencond one is the
% complement or the inverse of the random vector created.
for i=1:sizeInd
    if(rand < 0.5)
        Off.string(posOff,i) = Pop.string(posPop,i);
    else
        Off.string(posOff,i) = Pop.string(posPop+1,i);
    end
end

%section to apply crossover between the numeric part
% Intermediate recombination
if(strcmp(type,'RBLC'))
    randTmp = rand;
    Off.beta(posOff,1) = (randTmp * Pop.beta(posPop,1)) + ...
        ((1-randTmp)*Pop.beta(posPop+1,1)); 
end

posOff = posOff + 1;
