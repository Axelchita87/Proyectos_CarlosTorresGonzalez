%% Obtain the smallest number of generations in all rus
%
% Author: Carlos Torres and Victor Landassuri
% Created: 27 Jul 2011
% Modified: 


%% Function
function [minGen tmpListGen] = obtainMinGen(allrun, corrida)

% find the smallest generation to make the comparison
tmpListGen = zeros(1,corrida);
for k=1:corrida
    tmpListGen(1,k) = allrun{1,k}.generation;
end
minGen = min(tmpListGen);
