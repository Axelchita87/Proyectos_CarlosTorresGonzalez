%% Local connection scheme non-normalized
% It is generated a connectivity values (probability that a connection 
% exist) using an exponential function as used in \cite{nikkoStrom:1997}
%
%
% Created       12 Nov 2010
% Modified at:
% Author:       Carlos Torres and Victor Landassuri


%% function 
function connectivity = localConnSnoNorm2(n,m,SIGMA)

f = (1/SIGMA) * abs(n - m);
connectivity = exp(double(f));


