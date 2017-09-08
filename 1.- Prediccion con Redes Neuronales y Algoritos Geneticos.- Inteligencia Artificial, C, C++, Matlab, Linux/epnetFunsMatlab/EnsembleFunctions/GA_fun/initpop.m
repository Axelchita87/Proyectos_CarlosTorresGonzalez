function [Pop] = initpop(Pop,sizeInd,sizePop,type)
    %function to initialize the population and beta parameter
    %prototype
    %input:
        %Popr    Population
        %sizeInd    size of Individuals, genotpe
        %sizePop    No of individual in population
    for i=1:sizePop
        for j=1:sizeInd
            rand_temp = rand();
            if (rand_temp < 0.5)
                Pop.string(i,j) = 0;
            else
                Pop.string(i,j)  = 1;
            end
        end
        if(strcmp(type,'RBLC'))
            rand_temp = rand();
            Pop.beta(i,1) = rand_temp;
        end
    end


