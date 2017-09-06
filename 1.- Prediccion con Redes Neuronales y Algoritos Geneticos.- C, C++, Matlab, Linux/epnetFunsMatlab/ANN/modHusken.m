%% Measure Modularity given by husken
% Here is calculated the modularity M^{arch.} and M^{weith} given in
% Husken, M., Igel, C., Toussaint, M.: Task-dependent evolution of
% modularity in neural networks. Connection Science 14 (2002)
%
%
%
%
% It is expected that listNodesMod have in descendent order the nodes,
% column 1 is for nodes, and column two for the module it belongs. The size
% of the variuable is for all nodes including the inputs. 
%
% usage
%
% for the weighted modularity, supply the weights (W)
% [mHusWeight, d] = modHusken('normal', CW, noInputs, noHidden,noOutputs, ...
%   inputs, hidden, outputs, nodes, noModules, listNodesMod, W);
%
% for the arch modularity top-down version
% [mHusArch, d] = modHusken('top-down',CW, noInputs, noHidden,noOutputs, ...
%   inputs, hidden, outputs, nodes, noModules, listNodesMod);
%
% I will not use this function anymore, as it was the first approach, the
% function in the C code amore complete, so to plot a network it is used
% the information obtained from C, I only enter to this funciton in case
% another network, e.g. not comming from the C code, is plotted.
%
% Author: Carlos Torres and Victor Landassuri
% Date: 03/09/2010
% Modified at: 03/09/2010 correct version 



function [modularity, d, nodes] = modHusken(whaT, CW,noInputs, noHidden,noOutputs, ...
    inputs, hidden, outputs, nodes, noModules, listNodesMod, nameM,W)



% check if it is asked for the weighted ot the arch modularity
if nargin == 12
    W = CW;
end

% Set up some variables
d = zeros( (noInputs + noHidden + noOutputs) , noModules);
noNodes = noInputs + noHidden + noOutputs;


% m-tuple (di(1), ..., di(m)) assigned to each neuron i. 
% d is the degree of dependency of the neuron on the m different modules


% assing the first set inputs/outputs to the given modules
vecTmp = 0;
if strcmp(whaT, 'normal')
    vecTmp = inputs;
    vec2Tmp = [hidden outputs];
    N = noHidden + noOutputs;
    
elseif strcmp(whaT, 'top-down')
    vecTmp = outputs;
    vec2Tmp = [inputs hidden];
    vec2Tmp = vec2Tmp(end:-1:1);
    %vec2Tmp = noNodes-noOutputs:-1:1;
    N = noInputs + noHidden; 
end

%Inputs or outputs, take into account at which set they belong
for i = vecTmp
    contM = 1;
    for mod = nameM %mod=(noNodes - noModules + 1) : noNodes
        if (listNodesMod(i,2) == mod )
            d(i,contM) = 1;
        else
            d(i,contM) = 0;
        end
        contM = contM + 1;
    end
end


% it is declared as the same as d to save the temporal values of d'(j)
dp = d;


% Calculate dependency of neurons (Hidden and output or input and hidden) for each module 
for i=vec2Tmp
    if (i ~= 0) && (nodes(1,i) == 1) && ( sum(CW(i,:)) > 0)  % check that the node is present and it connect to other
        % calculate d'(j)
        for j=1:noModules
            sumK = 0;
            
            if strcmp(whaT, 'normal')
                
                for k=1:i-1             % check all previous nodes, to see if there are conenctions to it
                    if(nodes(1,k) == 1 && CW(k,i) == 1)
                        sumK = sumK + ( abs(W(k,i)) * d(k,j) );
                    end
                end
            elseif strcmp(whaT, 'top-down')
                for k=i+1:noNodes             % check all the next nodes, to see if there are conenctions to it
                    if(nodes(1,k) == 1 && CW(i,k) == 1)
                        sumK = sumK + ( abs(W(i,k)) * d(k,j) );
                    end
                end
            end
            
            
            dp(i,j) = sumK;
        end
        
        % calculate d(j)
        
        sumK = sum(dp(i,:));
        if sumK ~= 0
            for j=1:noModules
                d(i,j) = dp(i,j) / sumK;
            end
        end
    else
        nodes(1,i) = 0;         %desactivate the node for any of the above reasons
        N = N - 1;              % Rest the nodes that does not count 

    end
end                                 % finish alll hidden and output nodes

% Cuantify the degree of pureness of each neuron i by means of the variance
Sigma2 = zeros(1,noNodes);

for i=1:noNodes
    if nodes(1,i) == 1
        sumK = sum( ( d(i,:) - (1/noModules) ).^2 );
        Sigma2(1,i) = sumK / noModules;
    end
end



% calculate the required modularity, taking into account the correc neurons
if noModules > 1
    if strcmp(whaT, 'normal')
        modularity = ( noModules^2  / ( noModules - 1) ) * (1/N) * sum(Sigma2(noInputs+1:noNodes));
    elseif strcmp(whaT, 'top-down')
        modularity = ( noModules^2  / ( noModules - 1) ) * (1/N) * sum(Sigma2(1:noInputs+noHidden));
    end
else
    modularity = 0;
end

% there are bugs that case that the networks gives a bigger modularity,
% like the case in which an input is connected to an isolate node, from
% there the node is detected to be connected with someting else ahead, but
% not directly to an output, so sumK gis a value of 0.25, and then at the
% end the modularity is encreased
if modularity > 1
    modularity = 1;
end
     
