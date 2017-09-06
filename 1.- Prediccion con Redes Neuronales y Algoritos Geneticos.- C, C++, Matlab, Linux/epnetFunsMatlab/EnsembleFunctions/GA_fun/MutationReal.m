function [Off, pos] = MutationReal(Off, pos, selected, tempi, type, sizeInd)

%function to mutate a value

a = -0.5;
b = 0.5;
     % Bit flip, but in theory must be only one bot not all
for i=1:sizeInd
    temp_rand = rand;
    if(temp_rand <= 0.5)            % 50% of probability to change a bit
        if(selected.string(tempi,i) == 0)
            Off.string(pos,i) = 1;
        else
            Off.string(pos,i) = 0;
        end
    else
        Off.string(pos,i) = selected.string(tempi,i);
    end
end

if(strcmp(type,'RBLC'))
    %Gaussian Mutation
    %Gaussian mutation consists in adding a random value from a Gaussian 
    %distribution to each element of an individual’s vector to create a new offspring
    
    temp_rand = a + (b-a) * rand;
    %take care that the beta parameter is not outside of the allow bounds
    %(0,1)
    if(selected.beta(tempi,1) + temp_rand > 1)
        Off.beta(pos,1) = (selected.beta(tempi,1) + temp_rand) - 1;
    elseif (selected.beta(tempi,1) + temp_rand < 0)
        Off.beta(pos,1) = (selected.beta(tempi,1) + temp_rand) + 1;
    elseif (selected.beta(tempi,1) + temp_rand == 0)
        Off.beta(pos,1) = (selected.beta(tempi,1) + temp_rand) + rand;
    else
        Off.beta(pos,1) = selected.beta(tempi,1) + temp_rand;
    end
end

pos = pos + 1;