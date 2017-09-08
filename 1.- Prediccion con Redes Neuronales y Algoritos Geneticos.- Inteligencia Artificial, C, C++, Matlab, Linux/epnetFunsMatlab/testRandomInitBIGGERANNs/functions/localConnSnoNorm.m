%% Local connection scheme non-normalized
% It is generated a connectivity values (probability that a connection 
% exist) using an exponential function as used in \cite{nikkoStrom:1997}
%
%
% Created       12 Nov 2010
% Modified at:  13 Nov 2010
% Author:       Carlos Torres and Victor Landassuri


%% function 
function connectivity = localConnSnoNorm(n,m,SIGMA)
% n is the center where there will be the highest probability
% m are the target nodes, the far away, the less the probability

f = (-1/SIGMA) * abs(n - m);
connectivity = exp(double(f));


