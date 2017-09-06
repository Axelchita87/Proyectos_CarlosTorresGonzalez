%% Function to save a network to a  file
% saveSingleNet.m
% 
%
% Then you can use the function in the files to recuperate it and test an
% training algorithm
%
% To save a network first you should have read a previous file like
% allrun.mat
%
% Order to save the variables
% Input, finalInp, delays, hidden, outputs, CW, W, DeltaW, nodes, bias, 
% sizepos, posinputs, poshidden, momentum, lrate, countloaded and band = -1
%
% the band is used to detect error when reading
%
% Created:      27 Jan 2010
% Modified at:  30 Sep 2010
% Author:       Carlos Torres and Victor Landassuri

function saveSingleNet2file(name2save, Network)


%% Star to save
%init variable, the extra values are deleted, if they are overcome then it
%is added more columns ott he vector

initcolNet = 100000;
network = zeros(1,initcolNet);


network(1,1) = Network.varN.inputs;
network(1,2) = Network.varN.finalInp;
network(1,3) = Network.varN.delays;
network(1,4) = Network.varN.hidden;
network(1,5) = Network.varN.VnoOutputs;

allnodes = network(1,2) + network(1,4) + network(1,5);

%CW
cont =6; %always have the next position to be saved
for i=1:allnodes
    for j=1:allnodes
        network(1,cont) = Network.CW(i,j);
        cont = cont + 1;
    end
end

%W
for i=1:allnodes
    for j=1:allnodes
        network(1,cont) = Network.W(i,j);
        cont = cont + 1;
    end
end

%DeltaW
for i=1:allnodes
    for j=1:allnodes
        network(1,cont) = Network.DeltaW(i,j);
        cont = cont + 1;
    end
end

%nodes
for i=1:allnodes
    network(1,cont) = Network.nodes(1,i);
    cont = cont + 1;
end

%bias
for i=1:allnodes
    network(1,cont) = Network.bias(1,i);
    cont = cont + 1;
end

%sizepos
for i=1:2
    network(1,cont) = Network.sizepos(1,i);
    cont = cont + 1;
end

%posinputs
for i=1:network(1,2)
    network(1,cont) = Network.posinputs(1,i);
    cont = cont + 1;
end

%poshidden
for i=1:Network.sizepos(1,2);
    network(1,cont) = Network.poshidden(1,i);
    cont = cont + 1;
end

network(1,cont) = Network.momentum;
cont = cont + 1;

network(1,cont) = Network.lrate;
cont = cont + 1;

% counter to know how many times has been loaded
network(1,cont) = Network.varN.counterLoaded;
cont = cont + 1;


network(1,cont) = -1;
cont = cont + 1;

%delete extra columns
if cont < initcolNet
    network(:,cont:initcolNet) = [];
end

% save the network
save (name2save, 'network', '-ascii', '-tabs');


