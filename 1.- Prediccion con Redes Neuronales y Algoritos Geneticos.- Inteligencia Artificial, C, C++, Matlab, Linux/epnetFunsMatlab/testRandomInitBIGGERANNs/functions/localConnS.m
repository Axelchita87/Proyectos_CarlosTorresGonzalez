%% Local connection scheme
% It is generated a connectivity values (probability that a connection 
% exist) using an exponential function as used in \cite{nikkoStrom:1997}
%
% The funtion is
% \begin{equation}
% \phi(i_{n},h_{m}) = e^{- \frac{1}{\sigma_{input}} | n - \frac{N * m}{M} |}
% \end{equation}
%
% where $n$ is the number of the input, $m$ is the hidden, $N$ is the total
% number of inputs, $M$ is the total number of hidden nodes and 
% $\sigma_{input}$ is a parameter controlling the overall connectivity.
%
%
% Created       11 Nov 2010
% Modified at:
% Author:       Carlos Torres and Victor Landassuri


%% function 
function connectivity = localConnS(n,m,N, M,SIGMA)

f = (-1/SIGMA) * abs(n - ( (N*m)/M ) );
connectivity = exp(double(f));


