%% Script to test different ways to initialize the ANNs
% StestRandomExp1.m
% Here is generated randomly the networks with out modules and from 1 to n
% outputs to see how is better to initialize the networks to avoid non
% connected branches (isolated nodes or not connected directly or 
% indirectly to any output)
% 
% To run the first part ofthis exp put minOut and maxOut to 1, 
% in the second part put maxOut to n
%
% Saved:::
% There are generated results for a initDensity from 0.1:0.1:1
% 100 netowrks are generated to test the results statistically
%
% Format output::
% (cell) Exp1 column1 1 output, col2 n outputs
% lines: each one have a value 0.1:0.1:1, so there are 10 lines in the cell
%
%
% There is a nother files to test stsatistically and to plot the result in
% the same folder
% 
% Here is not taken into account the bias
%
% Check that here is only considered if there is a path from one node to an
% output, but there could be the case where there is apath from a node to
% an output but not a path from an input to the same node.
% That compariosn is not tested here
%
% Zones of the matrix to initialize
% I2H       inputs to hidden nodes
% I2O       inputs to Outputs nodes
% H2H
% H2O
% O2O       (in case there are more than one output)
%
% Created:      7 Oct 2007
% Modified at:  8 Oct 2010
% Author Carlos Torres and Victor Landassuri

%%
clear
clc

path1 = pwd;
%% Add paths
cd('..');  cd('LinuxOrWindows');
%use adecuate paht
SLASH = isLinOrWin();
cd('..');
pathExp = pwd;
addpath([pathExp,SLASH,'draw']);
addpath([pathExp,SLASH,'draw',SLASH,'basicShapes']);
addpath([pathExp,SLASH,'ANN']);

cd(path1);

% To replicate the results 
rand('state',37);


minInp = 1;
maxInp = 50;
        
minHid = 1;
maxHid = 100;
        
minOut = 1;

        
lines = 10;
cols = 1000;

% enter to the dir to save 
cd ('resExp1')

for M = 1:2
    %M
    % set up the maximum number of outputs
    if M == 1
        maxOut = 1;
        name2save = 'resExp';
    else
        minOut = 2;
        maxOut = 50;
        name2save = 'resExpmanyOut';
    end
    
    contInit = 0;
    
    % variables to save the results
    % each line has a value for initiaalization 0.1, 0.2, ..., 1
    % each colum has a repetion of the same values of initialization 1:100
    conn = zeros(lines,cols);
    March = zeros(lines,cols);
    contnoNodes = zeros(lines,cols);
    contnoInputs = zeros(lines,cols);    % number of nodes not conencted to inputs
    noNodes = zeros(lines,cols);
    
    
    %% setup var for the size and others
    for repInit = 0.1:0.1:1
        %repInit
        initDensity = repInit;
        contInit = contInit + 1;
        
        % repeat 100 times to obtain av. std. min and max values later
        for rep = 1:cols
            %rep
            % clear some variables
            allnodes = 0;
            nodes = 0;
            bias = 0;
            posinputs = 0;
            poshidden = 0;
            hiddenN = 0;
            outputN = 0;
            
            % Create the network randomly
            noInp = int16(minInp+ (maxInp - minInp) * rand());
            noHid = int16(minHid+ (maxHid - minHid) * rand());
            noOut = int16(minOut+ (maxOut - minOut) * rand());
            
            allnodes = noInp + noHid + noOut;
            nodes = ones(1,noInp + noHid + noOut);
            bias = zeros(1,noInp + noHid + noOut);
            
            posinputs = 1:noInp;
            poshidden = noInp+1:noInp+noHid+noOut;
            hiddenN = noInp+1:noInp+noHid;
            outputN = noInp+noHid+1:noInp+noHid+noOut;
            % Now create CW
            CW = zeros(allnodes,allnodes);
            
            % The initialization in this case is divided into different parts to optimiz it
            
            % init the connections
            % for the upper right triangle of the matrix, first part (I2h amd I2O)
            for i = posinputs
                for j = poshidden
                    if (rand() <= initDensity)
                        CW(i,j) = 1;
                    end
                end
            end
            
            % 2d part, H2H and H2O and O2O
            for i = poshidden
                for j = poshidden
                    if (j>i)
                        if (rand() <= initDensity)
                            CW(i,j) = 1;
                        end
                    end
                end
            end
            
            % bias just to include them even if they do not count
            % for i=poshidden
            %     if (rand() <= initDensity)
            %         bias(i) = 1;
            %     end
            % end
            
            %% measure variables to save
            
            % number of connections
            conn(contInit,rep) = countConnections(CW,bias);
            
            
            %% plot the ann just for me, to analize, comment it when run all exp
            % Plot into screen the ANN with my idea of modules (there is a shared module)
            % clf
            % h = plotANNmod(CW, noInp, noHid,noOut, posinputs, hiddenN, outputN, 2.5, nodes, bias, 1);
            
            
            %% check March of husken
            % note modify insode the function to use tdh to determiate the 
            [noModules, nodesInMod, nameMod, March(contInit,rep) ] = isThereModulesHuskenTopDown(CW, CW, noInp, noHid,noOut, ...
                posinputs, hiddenN, outputN, nodes); % introdece CW in the place of W cause is not ised Mweight here
            
            
            % if noModules = 1 I need to use another way to count the nodes that are
            % not connected to any output
            if noModules == 1
                [nodesInMod] = isConnected2Output(nodesInMod, CW,noHid, ...
                    noOut, posinputs, hiddenN, outputN, allnodes);
            end
            
            % nodes that do not connect to any output directly or indirectly
            %contnoNodes = 0;
            for i = 1:allnodes - noOut
                if nodesInMod(i,2) == -2
                    contnoNodes(contInit,rep) = contnoNodes(contInit,rep) +1;
                end
            end
            
            noNodes(contInit,rep) = allnodes;
            
            
            
            %% isolated nodes from inputs
            
            % Check that the hidden nodes and outputs are connected directly or
            % indirectly to an input, this is the other case that complement
            % the avobe case
            nodesInMod2 = zeros(allnodes,2);
            [nodesInMod2] = isConnected2Input(nodesInMod2, CW,noInp, noHid, ...
                noOut, posinputs, hiddenN, outputN, allnodes);
            
            for i = [hiddenN outputN]
                if nodesInMod2(i,2) == -2
                    contnoInputs(contInit,rep) = contnoInputs(contInit,rep) +1;
                end
            end
            
            
            
        end
        
    end
    % save the results    
    save( name2save, 'conn', 'March', 'contnoNodes', 'noNodes','contnoInputs' );
    
end

% delete paths
rmpath([pathExp,SLASH,'draw']);
rmpath([pathExp,SLASH,'draw',SLASH,'basicShapes']);
rmpath([pathExp,SLASH,'ANN']);