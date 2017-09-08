%% Obtain outside values, Av, std, ste
%
%
% Created:  9 Agu 2011
% Modified:
% Author: Carlos Torres and Victor Landassuri
%

%% Script


% Allocate space
in.outside.fitness = zeros(corrida,1);
if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
    in.outside.ClassifE = zeros(corrida,1);
end
in.outside.inputs = zeros(corrida,1);
in.outside.delays = zeros(corrida,1);
in.outside.hidden = zeros(corrida,1);
in.outside.connections = zeros(corrida,1);

in.outside.generations = zeros(corrida,1);
in.outside.totalEval = zeros(corrida,1);            %allrun{1,1}.ALLParam.totalEval
in.outside.cpuTime = zeros(corrida,1);

for module = 1:in.noModules
    in.outside.lrate{module} = zeros(corrida,1);
end

if ( allrun{1,1}.var.isModule1 ==  allrun{1,1}.C.ON )
    in.outside.March = zeros(corrida,1);
    in.outside.Mweight = zeros(corrida,1);
    
    in.outside.NoShared = zeros(corrida,1);
    in.outside.NoSharedConn = zeros(corrida,1);
    in.outside.Isolated = zeros(corrida,1);
    
    for module = 1:in.noModules
        in.outside.FitnessPerModule{module,1} = zeros(corrida,1);
        in.outside.NodesPerModule{module,1} = zeros(corrida,1);
    end
    
    if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
        for module = 1:in.noModules
            in.outside.ClassifErrPerMod{module,1} = zeros(corrida,1);
        end
    end
    
end

% Module reuse
if (allrun{1,1}.var.reuseModule == allrun{1,1}.C.ON )
    for module = 1:in.noModules
        in.outside.NodesReusedPerMod{module,1} = zeros(corrida,1);
    end
end




%% Recuperate outside values per run

for i=1:corrida
    in.generations(i,1) = allrun{1,i}.generation;
    in.totalEval(i,1) = allrun{1,i}.ALLParam.totalEval;
    in.cpuTime(i,1) = allrun{1,i}.cpu_time_used;
end


if strcmp( bestORav, 'best') == 1
    % Here is taken the best values per run
    for i=1:corrida
        in.outside.fitness(i,1) = allrun{1,i}.Network{1,1}.fitness;
        if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
            in.outside.ClassifE(i,1) = allrun{1,i}.Network{1,1}.predictF.classifError;
        end
        in.outside.inputs(i,1) = sum( allrun{1,i}.Network{1,1}.nodes( 1:allrun{1,i}.Network{1,1}.varN.finalInp) );
        in.outside.delays(i,1) = allrun{1,i}.Network{1,1}.varN.delays;
        in.outside.hidden(i,1) = allrun{1,i}.Network{1,1}.varN.hidden;
        in.outside.connections(i,1) = countConnections(allrun{1,i}.Network{1,1}.CW, allrun{1,i}.Network{1,1}.bias);
        
        
        for module = 1:in.noModules
            in.outside.lrate{module}(i,1) = allrun{1,i}.Network{1,1}.lrate(module);
        end
        
        
        
        if ( allrun{1,1}.var.isModule1 ==  allrun{1,1}.C.ON )
            in.outside.March(i,1) = allrun{1,i}.Network{1,1}.huskenModule.MarchTD;
            in.outside.Mweight(i,1) = allrun{1,i}.Network{1,1}.huskenModule.MweightTD;
            
            in.outside.NoShared( i,1 ) =  nodesPerMod(allrun{1,i}.Network{1,1}.sharedModule.nodesInModule, ...
                -1,allrun{1,i}.Network{1,1}.varN.finalInp, allrun{1,i}.Network{1,1}.varN.hidden);
                        
            in.outside.NoSharedConn( i,1 ) =  connectionsPerMod(allrun{1,i}.Network{1,1}.huskenModule.nodesInModule,...
                -1, allrun{1,i}.Network{1,1}.varN.finalInp, allrun{1,i}.Network{1,1}.varN.hidden, ...
                allrun{1,i}.Network{1,1}.varN.VnoOutputs, allrun{1,i}.Network{1,1}.CW, ...
                allrun{1,1}.var.considerInputsInMod);  % -1 means look for shared connections 
                        
            in.outside.Isolated( i,1 ) =  allrun{1,i}.Network{1,1}.huskenModule.noIsolatedNodes;
            
            for j = 1:in.noModules
                in.outside.FitnessPerModule{j,1}( i,1 ) = allrun{1,i}.Network{1,1}.predictF.EpercentagePerModule(j,1); 
                                
                in.outside.NodesPerModule{j,1}( i,1 ) = nodesPerMod(allrun{1,i}.Network{1,1}.huskenModule.nodesInModule, j, ...
                    allrun{1,i}.Network{1,1}.varN.finalInp, allrun{1,i}.Network{1,1}.varN.hidden);
                
            end
            
            if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
                for j = 1:in.noModules
                    in.outside.ClassifErrPerMod{j,1}( i,1 ) = allrun{1,i}.Network{1,1}.predictF.classifErrorPerModule(j,1);
                end
            end
            
            
            % Module reuse
            if (allrun{1,1}.var.reuseModule == allrun{1,1}.C.ON )
                for j = 1:in.noModules
                    in.outside.NodesReusedPerMod{j,1}( i,1 ) = allrun{1,i}.Network{1,1}.huskenModule.nodesReusedPerMod(1,j);
                end
            end
            
            
        end
    end
    
    
    
    
elseif strcmp( bestORav, 'av') == 1
    % average values from the population
    for i=1:corrida
        for j = 1:allrun{1,1}.var.populationNum
            in.outside.fitness(i,1) = in.outside.fitness(i,1) + allrun{1,i}.Network{1,j}.fitness;
            
            in.outside.inputs(i,1) = in.outside.inputs(i,1) + sum( allrun{1,i}.Network{1,j}.nodes( 1:allrun{1,i}.Network{1,j}.varN.finalInp) );
            in.outside.delays(i,1) = in.outside.delays(i,1) + allrun{1,i}.Network{1,j}.varN.delays;
            in.outside.hidden(i,1) = in.outside.hidden(i,1) + allrun{1,i}.Network{1,j}.varN.hidden;
            in.outside.connections(i,1) = in.outside.connections(i,1) + ...
                countConnections(allrun{1,i}.Network{1,j}.CW, allrun{1,i}.Network{1,j}.bias);
            
            for module = 1:in.noModules
                in.outside.lrate{module}(i,1) = in.outside.lrate{module}(i,1) + allrun{1,i}.Network{1,j}.lrate(module);
            end
            
            if ( allrun{1,1}.var.isModule1 ==  allrun{1,1}.C.ON )
                in.outside.March(i,1) = in.outside.March(i,1) + allrun{1,i}.Network{1,j}.huskenModule.MarchTD;
                in.outside.Mweight(i,1) = in.outside.Mweight(i,1) + allrun{1,i}.Network{1,j}.huskenModule.MweightTD;
                
                % Shared nodes
                in.outside.NoShared( i,1 ) =  in.outside.NoShared( i,1 ) + nodesPerMod(allrun{1,i}.Network{1,j}.sharedModule.nodesInModule, ...
                    -1,allrun{1,i}.Network{1,j}.varN.finalInp, allrun{1,i}.Network{1,j}.varN.hidden);
                
                % Shared connections
                in.outside.NoSharedConn( i,1 ) =  in.outside.NoSharedConn( i,1 ) + connectionsPerMod(allrun{1,i}.Network{1,j}.huskenModule.nodesInModule,...
                    -1, allrun{1,i}.Network{1,j}.varN.finalInp, allrun{1,i}.Network{1,j}.varN.hidden, ...
                    allrun{1,i}.Network{1,j}.varN.VnoOutputs, allrun{1,i}.Network{1,j}.CW, ...
                    allrun{1,1}.var.considerInputsInMod);  % -1 means look for shared connections
                
                % Isolated nodes
                in.outside.Isolated( i,1 ) =  in.outside.Isolated( i,1 ) + allrun{1,i}.Network{1,j}.huskenModule.noIsolatedNodes;
                
                for module = 1:in.noModules
                    in.outside.FitnessPerModule{module,1}( i,1 ) = in.outside.FitnessPerModule{module,1}( i,1 ) + allrun{1,i}.Network{1,j}.predictF.EpercentagePerModule(module,1);
                    
                    in.outside.NodesPerModule{module,1}( i,1 ) = in.outside.NodesPerModule{module,1}( i,1 ) + nodesPerMod(allrun{1,i}.Network{1,j}.huskenModule.nodesInModule, module, ...
                        allrun{1,i}.Network{1,j}.varN.finalInp, allrun{1,i}.Network{1,j}.varN.hidden);
                    
                end
                
                
            end
            
            % Classification error
            if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
                    in.outside.ClassifE(i,1) = in.outside.ClassifE(i,1) + allrun{1,i}.Network{1,j}.predictF.classifError;
            end
            
            % Module reuse
            if (allrun{1,1}.var.reuseModule == allrun{1,1}.C.ON )
                for module = 1:in.noModules
                    in.outside.NodesReusedPerMod{module,1}( i,1 ) = allrun{1,i}.Network{1,j}.huskenModule.nodesReusedPerMod(1,module);
                end
            end
            
                
            
        end
        
        
        % average per population
        in.outside.fitness(i,1) = in.outside.fitness(i,1) / allrun{1,1}.var.populationNum;
        
        if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
            in.outside.ClassifE(i,1) = in.outside.ClassifE(i,1) / allrun{1,1}.var.populationNum;
        end
        in.outside.inputs(i,1) = in.outside.inputs(i,1) / allrun{1,1}.var.populationNum;
        in.outside.delays(i,1) = in.outside.delays(i,1) / allrun{1,1}.var.populationNum;
        in.outside.hidden(i,1) = in.outside.hidden(i,1) / allrun{1,1}.var.populationNum;
        in.outside.connections(i,1) = in.outside.connections(i,1) / allrun{1,1}.var.populationNum;
        
        for module = 1:in.noModules
            in.outside.lrate{module}(i,1) = in.outside.lrate{module}(i,1) / allrun{1,1}.var.populationNum;
             in.outside.Isolated( i,1 ) =  in.outside.Isolated( i,1 ) / allrun{1,1}.var.populationNum;
        end
        
        if ( allrun{1,1}.var.isModule1 ==  allrun{1,1}.C.ON )
            in.outside.March(i,1) = in.outside.March(i,1) / allrun{1,1}.var.populationNum;
            in.outside.Mweight(i,1) = in.outside.Mweight(i,1) / allrun{1,1}.var.populationNum;
            
            in.outside.NoShared(i,1) = in.outside.NoShared(i,1) / allrun{1,1}.var.populationNum;
            in.outside.NoSharedConn(i,1) = in.outside.NoSharedConn(i,1) / allrun{1,1}.var.populationNum;
            
            for module = 1:in.noModules
                in.outside.FitnessPerModule{module,1}( i,1 ) = in.outside.FitnessPerModule{module,1}( i,1 )  / allrun{1,1}.var.populationNum;
                in.outside.NodesPerModule{module,1}( i,1 ) = in.outside.NodesPerModule{module,1}( i,1 )  / allrun{1,1}.var.populationNum;
                
            end
        end
        
        % Module reuse
        if (allrun{1,1}.var.reuseModule == allrun{1,1}.C.ON )
            for module = 1:in.noModules
                in.outside.NodesReusedPerMod{module,1}( i,1 ) = in.outside.NodesReusedPerMod{module,1}( i,1 ) / allrun{1,1}.var.populationNum;
            end
        end
        
    end
end






%% Av outside values


in.outside.avFitness = mean(in.outside.fitness);
if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
    in.outside.avClassifE = mean(in.outside.ClassifE);
end
in.outside.avInputs = mean(in.outside.inputs);
in.outside.avDelays = mean(in.outside.delays);
in.outside.avHidden = mean(in.outside.hidden);
in.outside.avConnections = mean(in.outside.connections);

for module = 1:in.noModules
    in.outside.AvLrate(module) = mean(in.outside.lrate{module});
end

in.avGenerations = mean(in.generations);
in.avTotalEval = mean(in.totalEval);
in.avCpuTime = mean(in.cpuTime);




if ( allrun{1,1}.var.isModule1 ==  allrun{1,1}.C.ON )
    in.outside.avMarch = mean(in.outside.March);
    in.outside.avMweight = mean(in.outside.Mweight);
    
    in.outside.avNoShared = mean( in.outside.NoShared);
    in.outside.avNoSharedConn = mean(in.outside.NoSharedConn );
    in.outside.avIsolated = mean(in.outside.Isolated);
    
    for j = 1:in.noModules
        in.outside.AvFitnessPerModule(j,1) = mean(in.outside.FitnessPerModule{j,1}( :, 1 ) );
        in.outside.AvNodesPerModule(j,1) = mean(in.outside.NodesPerModule{j,1}( :, 1 ) );
    end
    
    
    if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
        for j = 1:in.noModules
            in.outside.AvClassifErrPerMod(j,1) = mean(in.outside.ClassifErrPerMod{j,1}( :, 1 ) );
        end
    end
end


% Module reuse
if (allrun{1,1}.var.reuseModule == allrun{1,1}.C.ON )
    for j = 1:in.noModules
        in.outside.avNodesReusedPerMod(j,1) = mean(in.outside.NodesReusedPerMod{j,1}( :, 1 ) );
    end
end

    

%% STD outside values

in.outside.stdFitness = std(in.outside.fitness);
if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
    in.outside.stdClassifE = std(in.outside.ClassifE);
end
in.outside.stdInputs = std(in.outside.inputs);
in.outside.stdDelays = std(in.outside.delays);
in.outside.stdHidden = std(in.outside.hidden);
in.outside.stdConnections = std(in.outside.connections);

for module = 1:in.noModules
    in.outside.stdLrate(module) = std(in.outside.lrate{module});
end

in.stdGenerations = std(in.generations);
in.stdTotalEval = std(in.totalEval);
in.stdCpuTime = std(in.cpuTime);


if ( allrun{1,1}.var.isModule1 ==  allrun{1,1}.C.ON )
    in.outside.stdMarch = std(in.outside.March);
    in.outside.stdMweight = std(in.outside.Mweight);
    
    in.outside.stdNoShared = std( in.outside.NoShared);
    in.outside.stdNoSharedConn = std(in.outside.NoSharedConn );
    in.outside.stdIsolated = std(in.outside.Isolated);
    
    for j = 1:in.noModules
        in.outside.stdFitnessPerModule(j,1) = std(in.outside.FitnessPerModule{j,1}( :, 1));
        in.outside.stdNodesPerModule(j,1) = std(in.outside.NodesPerModule{j,1}( :, 1));
    end
    
    
    if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
        for j = 1:in.noModules
            in.outside.stdClassifErrPerMod(j,1) = std(in.outside.ClassifErrPerMod{j,1}( :, 1));
        end
    end
    
end

% Module reuse
if (allrun{1,1}.var.reuseModule == allrun{1,1}.C.ON )
    for j = 1:in.noModules
        in.outside.stdNodesReusedPerMod(j,1) = std(in.outside.NodesReusedPerMod{j,1}( :, 1 ) );
    end
end



%% STE outside values

in.outside.steFitness = in.outside.stdFitness / sqrt(corrida);
if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
    in.outside.steClassifE = in.outside.stdClassifE / sqrt(corrida);
end
in.outside.steInputs = in.outside.stdInputs / sqrt(corrida);
in.outside.steDelays = in.outside.stdDelays / sqrt(corrida);
in.outside.steHidden = in.outside.stdHidden / sqrt(corrida);
in.outside.steConnections = in.outside.stdConnections / sqrt(corrida);

for module = 1:in.noModules
    in.outside.steLrate(module) = in.outside.stdLrate(module) / sqrt(corrida);
end

in.steGenerations = in.stdGenerations / sqrt(corrida);
in.steTotalEval = in.stdTotalEval / sqrt(corrida);
in.steCpuTime = in.stdCpuTime / sqrt(corrida);

if ( allrun{1,1}.var.isModule1 ==  allrun{1,1}.C.ON )
    in.outside.steMarch = in.outside.stdMarch / sqrt(corrida);
    in.outside.steMweight = in.outside.stdMweight / sqrt(corrida);
    
    in.outside.steNoShared = in.outside.stdNoShared/ sqrt(corrida);
    in.outside.steNoSharedConn = in.outside.stdNoSharedConn/ sqrt(corrida);
    in.outside.steIsolated = in.outside.stdIsolated/ sqrt(corrida);
    
    
    for j = 1:in.noModules
        in.outside.steFitnessPerModule(j,1) = in.outside.stdFitnessPerModule(j,1)./sqrt(corrida);
        in.outside.steNodesPerModule(j,1) = in.outside.stdNodesPerModule(j,1)./sqrt(corrida);
    end
    
    
    if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
        for j = 1:in.noModules
            in.outside.steClassifErrPerMod(j,1) = in.outside.stdClassifErrPerMod(j,1)./sqrt(corrida);
        end
    end
    
end

% Module reuse
if (allrun{1,1}.var.reuseModule == allrun{1,1}.C.ON )
    for j = 1:in.noModules
        in.outside.steNodesReusedPerMod(j,1) = in.outside.stdNodesReusedPerMod(j,1)./sqrt(corrida);
    end
end

