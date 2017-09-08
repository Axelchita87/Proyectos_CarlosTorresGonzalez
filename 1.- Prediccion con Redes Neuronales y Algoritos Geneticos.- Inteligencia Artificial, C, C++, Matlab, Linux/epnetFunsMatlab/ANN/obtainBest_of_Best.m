%% Obtain the best of the best run
% Go throught all run and taken the best individual, then is compared all
% of them and taken the best individual of the best run

%% Starts function
function [minimo, pos] = obtainBest_of_Best(allruns)

corrida = size(allruns,2);
Etestset = zeros(1,corrida);
for i=1:corrida
    Etestset(1,i) = allruns{1,i}.Network{1,1}.fitness;
end
[minimo, pos] = min(Etestset);