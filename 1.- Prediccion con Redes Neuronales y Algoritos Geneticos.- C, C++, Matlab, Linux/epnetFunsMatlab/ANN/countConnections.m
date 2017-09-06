function [Connections] = countConnections(m, bias)
%Function to count the connections in an ANN
%Inputs
%m          matrix where is the conectivity matrix
%bias       a vector containing the bias

%Return
%Connections    the number of connections with bias

Connections = (sum(sum(m))) + sum(bias);


%old code
% for a=1:sizeCW(1,1)
%     for b=1:sizeCW(1,2)
%         if m(a,b) == 1
%             Connections = Connections + 1;
%         end
%     end
%     if bias(1,a) == 1
%         Connections = Connections + 1;
%     end
% end
