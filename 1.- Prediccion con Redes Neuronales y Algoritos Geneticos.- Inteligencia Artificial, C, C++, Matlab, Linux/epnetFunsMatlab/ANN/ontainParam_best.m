%% Obtain parameters form the best individual of the best run
% Obtain inputs, hidden nodes, output, nodes, ... form the best of the best


%% Function
function n = ontainParam_best(allrun, pos)



% obtain the inputs, hidden nodes and outputs nodes
n.noInputs = allrun{1,pos}.Network{1,1}.varN.finalInp;
n.noHidden = allrun{1,pos}.Network{1,1}.varN.hidden;
n.noOutputs = allrun{1,pos}.Network{1,1}.varN.VnoOutputs;


n.nodes = allrun{1,pos}.Network{1,1}.nodes;
n.allnodes = n.noInputs + n.noHidden + n.noOutputs;

n.CW = allrun{1,pos}.Network{1,1}.CW;
n.bias = allrun{1,pos}.Network{1,1}.bias;
n.noConnections = countConnections(n.CW, n.bias);
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


% obtain initial the positions to plot the nodes
n.inputs = 1:n.noInputs; %allrun{1,pos}.Network{1,1}.posinputs;
%n.inputs = n.inputs + 1;            % sum 1 cause the indexes are in C, i.e. 0, 1 , ...correct 21/07/2011

% check that inputs with a value of ZERO are replaced with the correct
% number, so I will print all of them and when connectins are plotted it
% will be clear which inputs are not used if it was used the asymmetric
% code
%for i=1:size(n.inputs,2)
%    if n.inputs(1,i) == 0
%        n.inputs(1,i) = i;
%    end
%end

n.hidden = allrun{1,pos}.Network{1,1}.poshidden(1:n.noHidden);
n.hidden = n.hidden + 1;
n.outputs = allrun{1,pos}.Network{1,1}.poshidden(n.noHidden+1:n.noHidden+n.noOutputs);
n.outputs = n.outputs + 1;


% other paramters
n.C = allrun{1,1}.C;
n.var = allrun{1,1}.var;

