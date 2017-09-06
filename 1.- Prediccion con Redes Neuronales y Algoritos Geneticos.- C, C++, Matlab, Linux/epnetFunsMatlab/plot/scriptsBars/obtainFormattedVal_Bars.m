%% Obtain Formatted values for bar figures
% Already was read statistical values and here are extracted and
% accomodated for each variable to plot bars figus with STD or STE
% 
% if just one exp, then all variables will be a column vector where each
% lines are the repetition
% if there are many exp, then they will be matrices where each column
% contain each repetition from other variable moved

%% Method
% Only it is needded the average value 

for i = 1:sizeDir
    for j = 1:sizeDirCol
        % generation
        infoBar.avGenerations(i,j) = info{i,j}.avGenerations;
        infoBar.stdGenerations(i,j) = info{i,j}.stdGenerations;
        infoBar.steGenerations(i,j) = info{i,j}.steGenerations;
        
        
        % total number of evaluation
        infoBar.avTotalEval(i,j) = info{i,j}.avTotalEval;
        infoBar.stdTotalEval(i,j) = info{i,j}.stdTotalEval;
        infoBar.steTotalEval(i,j) = info{i,j}.steTotalEval;
        
        % CPU time
        infoBar.avCpuTime(i,j) = info{i,j}.avCpuTime;
        infoBar.stdCpuTime(i,j) = info{i,j}.stdCpuTime;
        infoBar.steCpuTime(i,j) = info{i,j}.steCpuTime;
        
    end
end
if (strcmp(where2take, 'inside') == 1)
    for i = 1:sizeDir
        for j = 1:sizeDirCol
            % Accuracy
            infoBar.avAccuracy(i,j) = info{i,j}.avAccuracy(1,info{i,j}.minGen);
            infoBar.stdAccuracy(i,j) = info{i,j}.stdAccuracy(1,info{i,j}.minGen);
            infoBar.steAccuracy(i,j) = info{i,j}.steAccuracy(1,info{i,j}.minGen);
            
            % NRMSE/FITNESS
            infoBar.avFitness(i,j) = info{i,j}.avNRMSE(1,info{i,j}.minGen);
            infoBar.stdFitness(i,j) = info{i,j}.stdNRMSE(1,info{i,j}.minGen);
            infoBar.steFitness(i,j) = info{i,j}.steNRMSE(1,info{i,j}.minGen);
            
            % Connections
            infoBar.avCon(i,j) = info{i,j}.avCon(1,info{i,j}.minGen);
            infoBar.stdCon(i,j) = info{i,j}.stdCon(1,info{i,j}.minGen);
            infoBar.steCon(i,j) = info{i,j}.steCon(1,info{i,j}.minGen);
            
            % Inputs
            infoBar.avInp(i,j) = info{i,j}.avInp(1,info{i,j}.minGen);
            infoBar.stdInp(i,j) = info{i,j}.stdInp(1,info{i,j}.minGen);
            infoBar.steInp(i,j) = info{i,j}.steInp(1,info{i,j}.minGen);
            
            % Hidden
            infoBar.avHid(i,j) = info{i,j}.avHid(1,info{i,j}.minGen);
            infoBar.stdHid(i,j) = info{i,j}.stdHid(1,info{i,j}.minGen);
            infoBar.steHid(i,j) = info{i,j}.steHid(1,info{i,j}.minGen);
            
            % Delays
            infoBar.avDelays(i,j) = info{i,j}.avDelays(1,info{i,j}.minGen);
            infoBar.stdDelays(i,j) = info{i,j}.stdDelays(1,info{i,j}.minGen);
            infoBar.steDelays(i,j) = info{i,j}.steDelays(1,info{i,j}.minGen);
            
            % Lrate  --- For the moment I do not put attention in this
            % field
%             for M = 1:info{i,j}.noModules
%                 infoBar.avLrate{1,M}(i,j) = info{i,j}.avLrate{1,M}(1,info{i,j}.minGen);
%                 infoBar.stdLrate{1,M}(i,j) = info{i,j}.stdLrate{1,M}(1,info{i,j}.minGen);
%                 infoBar.steLrate{1,M}(i,j) = info{i,j}.steLrate{1,M}(1,info{i,j}.minGen);
%             end
            
            % Mweight
            infoBar.avMweight(i,j) = info{i,j}.avMweight(1,info{i,j}.minGen);
            infoBar.stdMweight(i,j) = info{i,j}.stdMweight(1,info{i,j}.minGen);
            infoBar.steMweight(i,j) = info{i,j}.steMweight(1,info{i,j}.minGen);
            
            % March
            infoBar.avMarch(i,j) = info{i,j}.avMarch(1,info{i,j}.minGen);
            infoBar.stdMarch(i,j) = info{i,j}.stdMarch(1,info{i,j}.minGen);
            infoBar.steMarch(i,j) = info{i,j}.steMarch(1,info{i,j}.minGen);
            
            % NoShared
            infoBar.avNoShared(i,j) = info{i,j}.avNoShared(1,info{i,j}.minGen);
            infoBar.stdNoShared(i,j) = info{i,j}.stdNoShared(1,info{i,j}.minGen);
            infoBar.steNoShared(i,j) = info{i,j}.steNoShared(1,info{i,j}.minGen);
            
            % Shared Connecitons
            infoBar.avNoSharedConn(i,j) = info{i,j}.avNoSharedConn(1,info{i,j}.minGen);
            infoBar.stdNoSharedConn(i,j) = info{i,j}.stdNoSharedConn(1,info{i,j}.minGen);
            infoBar.steNoSharedConn(i,j) = info{i,j}.steNoSharedConn(1,info{i,j}.minGen);
            
            % Isolated ndoes
            infoBar.avIsolated(i,j) = info{i,j}.avIsolated(1,info{i,j}.minGen);
            infoBar.stdIsolated(i,j) = info{i,j}.stdIsolated(1,info{i,j}.minGen);
            infoBar.steIsolated(i,j) = info{i,j}.steIsolated(1,info{i,j}.minGen);
            
            if ( info{1,1}.flagClass )
                % Classification error
                infoBar.avClassifE(i,j) = info{i,j}.avClassifE(1,info{i,j}.minGen);
                infoBar.stdClassif(i,j) = info{i,j}.stdClassifE(1,info{i,j}.minGen);
                infoBar.steClassif(i,j) = info{i,j}.steClassifE(1,info{i,j}.minGen);
            end
            
            
            
            
        end
    end
    
    
    % For this figures there will be one figure per Exp with its
    % repettions, so if there where 3 epxs, there will be 3 figures
    
    for j = 1:sizeDirCol
        
        if ( info{1,1}.flagClass )
            
            for i = 1:sizeDir
                % Special figures where it is not possible to compare directly
                % with the others
                %
                % They have many lines for the repetitios and 2 or more columns
                % for the second variable tested, e.g. exp 0.1 0.2,...,1.0 in
                % lines and March in cole 1 and Mweigh in Col 2.
                
                for k = 1:info{i,j}.noModules
                    specialBar{1,j}.AvFitnessPerModule(i,k) = info{i,j}.AvFitnessPerModule{k,1}(1,info{i,j}.minGen);
                    specialBar{1,j}.stdFitnessPerModule(i,k) = info{i,j}.stdFitnessPerModule{k,1}(1,info{i,j}.minGen);
                    specialBar{1,j}.steFitnessPerModule(i,k) = info{i,j}.steFitnessPerModule{k,1}(1,info{i,j}.minGen);
                    
                    specialBar{1,j}.AvClassifErrPerMod(i,k) = info{i,j}.AvClassifErrPerMod{k,1}(1,info{i,j}.minGen);
                    specialBar{1,j}.stdClassifErrPerMod(i,k) = info{i,j}.stdClassifErrPerMod{k,1}(1,info{i,j}.minGen);
                    specialBar{1,j}.steClassifErrPerMod(i,k) = info{i,j}.steClassifErrPerMod{k,1}(1,info{i,j}.minGen);
                    
                    specialBar{1,j}.AvNodesPerModule(i,k) = info{i,j}.AvNodesPerModule{k,1}(1,info{i,j}.minGen);
                    specialBar{1,j}.stdNodesPerModule(i,k) = info{i,j}.stdNodesPerModule{k,1}(1,info{i,j}.minGen);
                    specialBar{1,j}.steNodesPerModule(i,k) = info{i,j}.steNodesPerModule{k,1}(1,info{i,j}.minGen);
                    
                    
                    specialBar{1,j}.AvLrate(i,k) = info{i,j}.avLrate{1,k}(1,info{i,j}.minGen);
                    specialBar{1,j}.stdLrate(i,k) = info{i,j}.stdLrate{1,k}(1,info{i,j}.minGen);
                    specialBar{1,j}.steLrate(i,k) = info{i,j}.steLrate{1,k}(1,info{i,j}.minGen);
                    
                    
                    
                end
                
            end
        end
        % the modularity is taken from infoBar when it is plotted            
        specialBar{1,j}.AvModularityBoth(:,1) = infoBar.avMweight(:,j);
        specialBar{1,j}.AvModularityBoth(:,2) = infoBar.avMarch(:,j);
        
        specialBar{1,j}.stdModularityBoth(:,1) = infoBar.stdMweight(:,j);
        specialBar{1,j}.stdModularityBoth(:,2) = infoBar.stdMarch(:,j);
        
        specialBar{1,j}.steModularityBoth(:,1) = infoBar.steMweight(:,j);
        specialBar{1,j}.steModularityBoth(:,2) = infoBar.steMarch(:,j);
        
        
    end
    
    
elseif (strcmp(where2take, 'outside') == 1)
    % Not all the same values have been used for the outside data set, the
    % values not used are put to zero to avoid error in function taht call
    % this data set
    
   for i = 1:sizeDir
        for j = 1:sizeDirCol
            % Accuracy
            infoBar.avAccuracy(i,j) = 0; %info{i,j}.avAccuracy(1,info{i,j}.minGen);
            infoBar.stdAccuracy(i,j) = 0; %info{i,j}.stdAccuracy(1,info{i,j}.minGen);
            infoBar.steAccuracy(i,j) = 0; %info{i,j}.steAccuracy(1,info{i,j}.minGen);
            
            % NRMSE/FITNESS
            infoBar.avFitness(i,j) = info{i,j}.outside.avFitness;
            infoBar.stdFitness(i,j) = info{i,j}.outside.stdFitness;
            infoBar.steFitness(i,j) = info{i,j}.outside.steFitness;
            
            % Connections
            infoBar.avCon(i,j) = info{i,j}.outside.avConnections;
            infoBar.stdCon(i,j) = info{i,j}.outside.stdConnections;
            infoBar.steCon(i,j) = info{i,j}.outside.steConnections;
            
            % Inputs
            infoBar.avInp(i,j) = info{i,j}.outside.avInputs;
            infoBar.stdInp(i,j) = info{i,j}.outside.stdInputs;
            infoBar.steInp(i,j) = info{i,j}.outside.steInputs;
            
            % Hidden
            infoBar.avHid(i,j) = info{i,j}.outside.avHidden;
            infoBar.stdHid(i,j) = info{i,j}.outside.stdHidden;
            infoBar.steHid(i,j) = info{i,j}.outside.steHidden;
            
            % Delays
            infoBar.avDelays(i,j) = info{i,j}.outside.avDelays;
            infoBar.stdDelays(i,j) = info{i,j}.outside.stdDelays;
            infoBar.steDelays(i,j) = info{i,j}.outside.steDelays;
            
            % Lrate
%             infoBar.avLrate(i,j) = info{i,j}.outside.avLrate;
%             infoBar.stdLrate(i,j) = info{i,j}.outside.stdLrate;
%             infoBar.steLrate(i,j) = info{i,j}.outside.steLrate;
            
            % Mweight
            infoBar.avMweight(i,j) = info{i,j}.outside.avMweight;
            infoBar.stdMweight(i,j) = info{i,j}.outside.stdMweight;
            infoBar.steMweight(i,j) = info{i,j}.outside.steMweight;
            
            % March
            infoBar.avMarch(i,j) = info{i,j}.outside.avMarch;
            infoBar.stdMarch(i,j) = info{i,j}.outside.stdMarch;
            infoBar.steMarch(i,j) = info{i,j}.outside.steMarch;
            
            % NoShared
            infoBar.avNoShared(i,j) = info{i,j}.outside.avNoShared;
            infoBar.stdNoShared(i,j) = info{i,j}.outside.stdNoShared;
            infoBar.steNoShared(i,j) = info{i,j}.outside.steNoShared;
            
            % Shared Connecitons
            infoBar.avNoSharedConn(i,j) = info{i,j}.outside.avNoSharedConn;
            infoBar.stdNoSharedConn(i,j) = info{i,j}.outside.stdNoSharedConn;
            infoBar.steNoSharedConn(i,j) = info{i,j}.outside.steNoSharedConn;
            
            % Isolated ndoes
            infoBar.avIsolated(i,j) = info{i,j}.outside.avIsolated;
            infoBar.stdIsolated(i,j) = info{i,j}.outside.stdIsolated;
            infoBar.steIsolated(i,j) = info{i,j}.outside.steIsolated;
            
            if ( info{1,1}.flagClass)
            % Classification error
                infoBar.avClassifE(i,j) = info{i,j}.outside.avClassifE;
                infoBar.stdClassif(i,j) = info{i,j}.outside.stdClassifE;
                infoBar.steClassif(i,j) = info{i,j}.outside.steClassifE;
            end
            
            
        end
    end
    
    
    % For this figures there will be one figure per Exp with its
    % repettions, so if there where 3 epxs, there will be 3 figures
    
    for j = 1:sizeDirCol
        
        if ( info{1,1}.flagClass )
            
            for i = 1:sizeDir
                % Special figures where it is not possible to compare directly
                % with the others
                %
                % They have many lines for the repetitios and 2 or more columns
                % for the second variable tested, e.g. exp 0.1 0.2,...,1.0 in
                % lines and March in cole 1 and Mweigh in Col 2.
                
                for k = 1:info{i,j}.noModules
                    
                    % Lrate
                    specialBar{1,j}.AvLrate(i,k) = info{i,j}.outside.AvLrate(1,k);
                    specialBar{1,j}.stdLrate(i,k) = info{i,j}.outside.stdLrate(1,k);
                    specialBar{1,j}.steLrate(i,k) = info{i,j}.outside.steLrate(1,k);
                    
                    
                    specialBar{1,j}.AvFitnessPerModule(i,k) = info{i,j}.outside.AvFitnessPerModule(k,1);
                    specialBar{1,j}.stdFitnessPerModule(i,k) = info{i,j}.outside.stdFitnessPerModule(k,1);
                    specialBar{1,j}.steFitnessPerModule(i,k) = info{i,j}.outside.steFitnessPerModule(k,1);
                    
                    specialBar{1,j}.AvClassifErrPerMod(i,k) = info{i,j}.outside.AvClassifErrPerMod(k,1);
                    specialBar{1,j}.stdClassifErrPerMod(i,k) = info{i,j}.outside.stdClassifErrPerMod(k,1);
                    specialBar{1,j}.steClassifErrPerMod(i,k) = info{i,j}.outside.steClassifErrPerMod(k,1);
                    
                    specialBar{1,j}.AvNodesPerModule(i,k) = info{i,j}.outside.AvNodesPerModule(k,1);
                    specialBar{1,j}.stdNodesPerModule(i,k) = info{i,j}.outside.stdNodesPerModule(k,1);
                    specialBar{1,j}.steNodesPerModule(i,k) = info{i,j}.outside.steNodesPerModule(k,1);
                end
                
            end
            
        end
        % the modularity is taken from infoBar when it is plotted
        specialBar{1,j}.AvModularityBoth(:,1) = infoBar.avMweight(:,j);
        specialBar{1,j}.AvModularityBoth(:,2) = infoBar.avMarch(:,j);
        
        specialBar{1,j}.stdModularityBoth(:,1) = infoBar.stdMweight(:,j);
        specialBar{1,j}.stdModularityBoth(:,2) = infoBar.stdMarch(:,j);
        
        specialBar{1,j}.steModularityBoth(:,1) = infoBar.steMweight(:,j);
        specialBar{1,j}.steModularityBoth(:,2) = infoBar.steMarch(:,j);
        
        
    end
end




