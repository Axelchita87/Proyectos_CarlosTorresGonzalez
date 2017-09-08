function Off = elite(Off, Pop, Elite, type)
%function to save the best individuals in offspring

if(strcmp(type,'Average') || strcmp(type,'RawFit') )
    for i=1:Elite
        Off.string(i,:) = Pop.string(i,:);
        Off.fitness(i,1) = Pop.fitness(i,1);
    end
elseif(strcmp(type,'RBLC'))
    for i=1:Elite
        Off.string(i,:) = Pop.string(i,:);
        Off.fitness(i,1) = Pop.fitness(i,1);
        Off.beta(i,1) = Pop.beta(i,1);
    end
end