%% Average, STD, STE for all generations
% Here it is used the variable allrun and it is calculated
% The average per generations
% The STD
% The Standar error
% The last two are for error bars
%
% It is taken all values for all generation for each run
% runs with smaller generations than the one obtaining more are leave in
% the same way, i.e. it is not put a NaN value in the not used generations
% to later plot them, as in the plot we can specify until which value we
% want to plot

%   e.g. run as:
%   info = obtainAvStdSte(allrun,1,0,0);
%   where: obtainAvStdSte(allrun,av,std,ste);
%
% Created:  9 Dec 2010
% Modified: 28 Jul 2011
% Author:   Carlos Torres and Victor Landassuri

%% Fuction
function [in] = obtainAvStdSte(allrun, SLASH, bestORav, AV, STD, STE, BARS)
% function to obtain the average, or std, or ste
%
% Inputs:
%   allrun          variable with all the information
%   SLASH           slash
%   bestORav        for the values outside, it takes only the best per run,
%                   or the av per population from the values, fitnes,...
%   AV              variable to say if desired the average values
%   STD             desired standard deviation (for error bars)
%   STE             desired standard error (error bars)
%   BARS            means that this info will be used to plot bars figues,
%                   so not put NaN in values, if BARS = 'bars' or if it is
%                   passed that value, if it is not passed it is assume to
%                   be normal and NaN values are put
%
%
% If you add more input values to this functin, update the liens with
% nargin in the file

%% Declarate and allocate variables
corrida = size(allrun,2);
[generation gen] = obtainMinGen(allrun, corrida);
minGen = generation;

in.gen = gen;            % to have a copy of the list of generations when this fun finish
in.minGen = minGen;

generation = max(gen);  % to have the max size and allocate that space

% Var used outside this fun
in.flagClass = 0;
in.flagModule1 = 0;
if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
    in.flagClass = 1;
end

if ( allrun{1,1}.var.isModule1 ==  allrun{1,1}.C.ON )
    in.flagModule1 = 1;
end

in.typeDS = allrun{1,1}.var.typeDS;

% Load some var for the case of classification tasks/module1
in.Modules = 0;
in.noModules = 0;
%if allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY
if(exist(['..', SLASH, 'txtFiles', SLASH, 'nameModules'],'file') == 2)
    in.Modules = load('../txtFiles/nameModules');
    % if it is not is directory it means that I am callyng this file
    % from other location
    in.noModules = size(in.Modules,2);
elseif(exist(['txtFiles', SLASH, 'nameModules'],'file') == 2)
    in.Modules = load(['txtFiles', SLASH, 'nameModules']);
    in.noModules = size(in.Modules,2);
else
    in.noModules = 1;           % simple evolutionary algorithm
end

%else
%    in.noModules = 1;           % simple evolutionary algorithm
%end
%inModules = allrun{1,1}.var.NAME_MODULE;
%in.noModules = allrun{1,1}.var.NUM_MODULES;

% Allocate space for the variables
in.accuracy = zeros(corrida,generation);
in.nrms = zeros(corrida,generation);        % note that nrmse could be error percentage or rmse, have this name from the beginning
in.nrmsReal = zeros(corrida,generation);
in.con = zeros(corrida,generation);
in.input = zeros(corrida,generation);
in.hidden = zeros(corrida,generation);
in.delays = zeros(corrida,generation);

% bestWorst Fitness
in.bestFit = zeros(corrida,generation);
in.worstFit = zeros(corrida,generation);

for module = 1:in.noModules
    in.lRate{module} = zeros(corrida,generation);
end

% for the Average Mutations
in.hybridtraining = zeros(1,generation);
in.MBP = zeros(1,generation);
in.SA = zeros(1,generation);
in.InpAdd =zeros(1,generation);
in.InpDel =zeros(1,generation);
in.DelayAdd = zeros(1,generation);
in.DelayDel = zeros(1,generation);

in.nodeDel = zeros(1,generation);
in.connDel = zeros(1,generation);
in.nodeAdd = zeros(1,generation);
in.connAdd = zeros(1,generation);

if ( allrun{1,1}.var.algoFeatures ==  allrun{1,1}.C.MODULAR1 )
    in.SharedNodeDel = zeros(1,generation);
    in.SharedConnDel = zeros(1,generation);
    in.StrongConnAdd = zeros(1,generation);
end


% For the modules
if ( allrun{1,1}.var.isModule1 ==  allrun{1,1}.C.ON )
    in.Mweight = zeros(corrida,generation);
    in.March = zeros(corrida,generation);
    in.NoShared = zeros(corrida,generation);
    in.NoSharedConn = zeros(corrida,generation);
    in.Isolated = zeros(corrida,generation);
    
    % even those values could not be used every time this function is
    % called, they are calculated
    if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
        for j = 1:in.noModules
            in.FitnessPerModule{j,1} = zeros(corrida,generation); % Note that hey are the average from the pupulation
            in.ClassifErrPerMod{j,1} = zeros(corrida,generation);
            in.NodesPerModule{j,1} = zeros(corrida,generation);
        end
        
    end
    
end

if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
    in.ClassifE = zeros(corrida,generation);
end


% Module reuse
if (allrun{1,1}.var.reuseModule == allrun{1,1}.C.ON )
    for j = 1:in.noModules
        in.NodesReusedPerMod{j,1} = zeros(corrida,generation);
    end
end





%% Recupare them from allrun (inside values per generation)
% Every line is a run
for i=1:corrida
    in.accuracy( i, 1:gen(1,i) ) = allrun{1,i}.ALLParam.AvaccuracyValI( 1:gen(1,i) );
    in.nrms( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.Avfitness( 1:gen(1,i) );
    in.nrmsReal( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.AvfitnessReal( 1:gen(1,i) );
    in.con( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.Avconnections( 1:gen(1,i) );
    in.input( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.Avinputs( 1:gen(1,i) );
    in.hidden( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.Avhidden( 1:gen(1,i) );
    in.delays( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.Avdelays( 1:gen(1,i) );
    
    
    % bestWorst Fitness
    in.bestFit( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.bestfitness( 1:gen(1,i) );
    in.worstFit( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.worstfitness( 1:gen(1,i) );
    
    for module = 1:in.noModules
        in.lRate{module}( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.Avlrate(module, 1:gen(1,i) );
    end
    
    % Section for the mutations
    in.hybridtraining( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.mutHT( 1:gen(1,i) );
    in.nodeDel( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.mutNodeDel( 1:gen(1,i) );
    in.connDel( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.mutConnDel( 1:gen(1,i) );
    in.nodeAdd( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.mutNodeAdd( 1:gen(1,i) );
    in.connAdd( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.mutConnAdd( 1:gen(1,i) );
    
    in.MBP( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.mutMBP( 1:gen(1,i) );
    in.SA( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.mutSA( 1:gen(1,i) );
    in.InpAdd( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.mutInpAdd( 1:gen(1,i) );
    in.InpDel( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.mutInputDel( 1:gen(1,i) );
    in.DelayAdd( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.mutDelayAdd( 1:gen(1,i) );
    in.DelayDel( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.mutDelayDel( 1:gen(1,i) );
    
    % section for evolution of modules 1
    if ( allrun{1,1}.var.algoFeatures ==  allrun{1,1}.C.MODULAR1 )
        in.SharedNodeDel( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.MutSharedNodeDel( 1:gen(1,i) );
        in.SharedConnDel( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.MutSharedConnDel( 1:gen(1,i) );
        in.StrongConnAdd( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.MutStrongConnAdd( 1:gen(1,i) );
    end
    
    
    if ( allrun{1,1}.var.isModule1 ==  allrun{1,1}.C.ON )
        in.Mweight( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.AvMweight( 1:gen(1,i) );
        in.March( i,1:gen(1,i) ) =  allrun{1,i}.ALLParam.AvMarch( 1:gen(1,i) );
        in.NoShared( i,1:gen(1,i) ) =  allrun{1,i}.ALLParam.AvNoSharedNodes( 1:gen(1,i) );
        in.NoSharedConn( i,1:gen(1,i) ) =  allrun{1,i}.ALLParam.AvNoSharedConn( 1:gen(1,i) );
        in.Isolated( i,1:gen(1,i) ) =  allrun{1,i}.ALLParam.AvIsolatedNodes( 1:gen(1,i) );
        
        for j = 1:in.noModules
            in.FitnessPerModule{j,1}( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.AvFitnessPerModule(j,1:gen(1,i));
            in.NodesPerModule{j,1}( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.AvNodesPerModule(j,1:gen(1,i));
        end
        
        if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
            for j = 1:in.noModules
                in.ClassifErrPerMod{j,1}( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.AvClassErrPerModle(j,1:gen(1,i));
            end
        end
        
    end
    
    if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
        in.ClassifE( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.AvClassifError( 1:gen(1,i) );
    end
    
    
    % Module reuse
    if (allrun{1,1}.var.reuseModule == allrun{1,1}.C.ON )
        for j = 1:in.noModules
            in.NodesReusedPerMod{j,1}( i,1:gen(1,i) ) = allrun{1,i}.ALLParam.NodesReusedPerMod(j,1:gen(1,i));
        end
    end
    
end

















%% obtain average. Only up to the minim number fo generations per run
if AV == 1
    % delacara/ allocate space/ assing value
    in.avAccuracy = mean(in.accuracy( :, 1:minGen ) );
    in.avNRMSE = mean(in.nrms( :, 1:minGen ) );
    in.avNRMSEReal = mean(in.nrmsReal( :, 1:minGen ) );
    in.avCon = mean(in.con( :, 1:minGen ) );
    in.avInp = mean(in.input( :, 1:minGen ) );
    in.avHid = mean(in.hidden( :, 1:minGen ) );
    in.avDelays = mean(in.delays( :, 1:minGen ) );
    
    % bestWorst Fitness
    in.avBestFit = mean(in.bestFit( :, 1:minGen ) );
    in.avWorstFit = mean(in.worstFit( :, 1:minGen ) );
    
    for module = 1:in.noModules
        in.avLrate{module} = mean(in.lRate{module}( :, 1:minGen ) );
    end
    
    
    % Section for the mutations
    in.avhybridtraining = mean(in.hybridtraining( :, 1:minGen ) );
    in.avnodeDel = mean(in.nodeDel( :, 1:minGen ) );
    in.avconnDel = mean(in.connDel( :, 1:minGen ) );
    in.avnodeAdd = mean(in.nodeAdd( :, 1:minGen ) );
    in.avconnAdd = mean(in.connAdd( :, 1:minGen ) );
    
    in.avMBP = mean(in.MBP( :, 1:minGen ) );
    in.avSA = mean(in.SA( :, 1:minGen ) );
    in.avInpAdd = mean(in.InpAdd( :, 1:minGen ) );
    in.avInpDel = mean(in.InpDel( :, 1:minGen ) );
    in.avDelayAdd = mean(in.DelayAdd( :, 1:minGen ) );
    in.avDelayDel = mean(in.DelayDel( :, 1:minGen ) );
    
    % section for evolution of modules 1
    if ( allrun{1,1}.var.algoFeatures ==  allrun{1,1}.C.MODULAR1 )
        in.avSharedNodeDel = mean(in.SharedNodeDel( :, 1:minGen ) );
        in.avSharedConnDel = mean(in.SharedConnDel( :, 1:minGen ) );
        in.avStrongConnAdd = mean(in.StrongConnAdd( :, 1:minGen ) );
    end
    
    
    
    
    if ( allrun{1,1}.var.isModule1 ==  allrun{1,1}.C.ON )
        in.avMweight = mean(in.Mweight( :, 1:minGen ) );
        in.avMarch = mean(in.March( :, 1:minGen ) );
        in.avNoShared = mean(in.NoShared( :, 1:minGen ) );
        in.avNoSharedConn = mean(in.NoSharedConn( :, 1:minGen ) );
        in.avIsolated = mean(in.Isolated( :, 1:minGen ) );
        
        for j = 1:in.noModules
            in.AvFitnessPerModule{j,1} = mean(in.FitnessPerModule{j,1}( :, 1:minGen ) );
            in.AvNodesPerModule{j,1} = mean(in.NodesPerModule{j,1}( :, 1:minGen ) );
        end
        
        
        if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
            for j = 1:in.noModules
                in.AvClassifErrPerMod{j,1} = mean(in.ClassifErrPerMod{j,1}( :, 1:minGen ) );
            end
        end
    end
    
    if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
        in.avClassifE = mean(in.ClassifE( :, 1:minGen ) );
    end
    
    
    
    % Module reuse
    if (allrun{1,1}.var.reuseModule == allrun{1,1}.C.ON )
        for j = 1:in.noModules
            in.avNodesReusedPerMod{j,1} = mean(in.NodesReusedPerMod{j,1}( :, 1:minGen ) ); 
        end
    end
    
    
    
    
    % Eliminate some values  to allow clear figures
    if nargin == 6
        if minGen <= 100
            modulo = 5;
        elseif minGen <= 500
            modulo = 10;
        elseif minGen <= 2000
            modulo = 50;
        elseif minGen <= 5000
            modulo = 100;
        elseif minGen <= 10000
            modulo = 500;
        end
        
        
        for i=1:minGen
            if mod(i,modulo) ~= 0
                %             in.avAccuracy(1,i) = NaN;
                %             in.avNRMSE(1,i) = NaN;
                %             in.avNRMSEReal(1,i) = NaN;
                %             in.avCon(1,i) = NaN;
                %             in.avInp(1,i) = NaN;
                %             in.avHid(1,i) = NaN;
                %             in.avDelays(1,i) = NaN;
                %             % bestWorst Fitness
                %             in.avBestFit(1,i) = NaN;
                %             in.avWorstFit(1,i) = NaN;
                %
                %             for module = 1:in.noModules
                %                 in.avLrate{module}(1,i) = NaN;
                %             end
                %
                
                % Section for the mutations
                %in.avhybridtraining(1,i) = NaN;
                in.avnodeDel(1,i) = NaN;
                in.avconnDel(1,i) = NaN;
                %in.avnodeAdd(1,i) = NaN;
                in.avconnAdd(1,i) = NaN;
                
                in.avMBP(1,i) = NaN;
                in.avSA(1,i) = NaN;
                in.avInpAdd(1,i) = NaN;
                in.avInpDel(1,i) = NaN;
                in.avDelayAdd(1,i) = NaN;
                in.avDelayDel(1,i) = NaN;
                
                
                % section for evolution of modules 1
                if ( allrun{1,1}.var.algoFeatures ==  allrun{1,1}.C.MODULAR1 )
                    in.avSharedNodeDel(1,i) = NaN;
                    in.avSharedConnDel(1,i) = NaN;
                    in.avStrongConnAdd(1,i) = NaN;
                end
                
                
                
                %             if ( allrun{1,1}.var.isModule1 ==  allrun{1,1}.C.ON )
                %                 in.stdMweight(1,i) = NaN;
                %                 in.stdMarch(1,i) = NaN;
                %                 in.stdNoShared(1,i) = NaN;
                %                 in.stdNoSharedConn(1,i) = NaN;
                %                 in.stdIsolated(1,i) = NaN;
                %
                %                 if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
                %                     for j = 1:in.noModules
                %                         in.stdFitnessPerModule{j,1}(1,i) = NaN;
                %                         in.stdClassifErrPerMod{j,1}(1,i) = NaN;
                %                         in.stdNodesPerModule{j,1}(1,i) = NaN;
                %                     end
                %                 end
                %             end
                
                %             if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
                %                 in.stdClassifE(1,i) = NaN;
                %             end
                
                  
                % Module reuse (maybe only if it has more than 4 lines apply this to the 4th and so on)
%                 if (allrun{1,1}.var.reuseModule == allrun{1,1}.C.ON )
%                     for j = 1:in.noModules
%                         in.avNodesReusedPerMod{j,1} ( i,1:gen(1,i) ) = mean(in.NodesReusedPerMod{j,1}( :, 1:minGen ) ); 
%                     end
%                 end
    
                
            end
        end
        
        
    end
    
    
    
    
    
    
    
end





%% obtain standard deviation
if STD == 1 || STE == 1
    % delacara/ allocate space/ assing value
    in.stdAccuracy = std(in.accuracy( :, 1:minGen ));
    in.stdNRMSE = std(in.nrms( :, 1:minGen ));
    in.stdNRMSEReal = std(in.nrmsReal( :, 1:minGen ));
    in.stdCon = std(in.con( :, 1:minGen ));
    in.stdInp = std(in.input( :, 1:minGen ));
    in.stdHid = std(in.hidden( :, 1:minGen ));
    in.stdDelays = std(in.delays( :, 1:minGen ));
    
    % bestWorst Fitness
    in.stdBestFit = std(in.bestFit( :, 1:minGen ));
    in.stdWorstFit = std(in.worstFit( :, 1:minGen ));
    
    for module = 1:in.noModules
        in.stdLrate{module} = std(in.lRate{module}( :, 1:minGen ));
    end
    
    
    
    
    
    % Section for the mutations
    in.stdhybridtraining = std(in.hybridtraining( :, 1:minGen ));
    in.stdnodeDel = std(in.nodeDel( :, 1:minGen ));
    in.stdconnDel = std(in.connDel( :, 1:minGen ));
    in.stdnodeAdd = std(in.nodeAdd( :, 1:minGen ));
    in.stdconnAdd = std(in.connAdd( :, 1:minGen ));
    
    in.stdMBP = std(in.MBP( :, 1:minGen ));
    in.stdSA = std(in.SA( :, 1:minGen ));
    in.stdInpAdd = std(in.InpAdd( :, 1:minGen ));
    in.stdInpDel = std(in.InpDel( :, 1:minGen ));
    in.stdDelayAdd = std(in.DelayAdd( :, 1:minGen ));
    in.stdDelayDel = std(in.DelayDel( :, 1:minGen ));
    
    % section for evolution of modules 1
    if ( allrun{1,1}.var.algoFeatures ==  allrun{1,1}.C.MODULAR1 )
        in.stdSharedNodeDel = std(in.SharedNodeDel( :, 1:minGen ));
        in.stdSharedConnDel = std(in.SharedConnDel( :, 1:minGen ));
        in.stdStrongConnAdd = std(in.StrongConnAdd( :, 1:minGen ));
    end
    
    
    
    
    
    
    
    
    if ( allrun{1,1}.var.isModule1 ==  allrun{1,1}.C.ON )
        in.stdMweight = std(in.Mweight( :, 1:minGen ));
        in.stdMarch = std(in.March( :, 1:minGen ));
        in.stdNoShared = std(in.NoShared( :, 1:minGen ));
        in.stdNoSharedConn = std(in.NoSharedConn( :, 1:minGen ));
        in.stdIsolated = std(in.Isolated( :, 1:minGen ));
        
        for j = 1:in.noModules
            in.stdFitnessPerModule{j,1} = std(in.FitnessPerModule{j,1}( :, 1:minGen ));
            in.stdNodesPerModule{j,1} = mean(in.NodesPerModule{j,1}( :, 1:minGen ));
        end
        
        
        if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
            for j = 1:in.noModules
                in.stdClassifErrPerMod{j,1} = std(in.ClassifErrPerMod{j,1}( :, 1:minGen ));
            end
        end
    end
    
    if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
        in.stdClassifE = std(in.ClassifE( :, 1:minGen ));
    end
    
    
      
    % Module reuse
    if (allrun{1,1}.var.reuseModule == allrun{1,1}.C.ON )
        for j = 1:in.noModules
            in.stdNodesReusedPerMod{j,1} = std(in.NodesReusedPerMod{j,1}( :, 1:minGen ));
        end
    end
    
    
    
    
    
    % Eliminate some bars to allow clear figures
    if nargin == 6
        if minGen <= 100
            modulo = 5;
        elseif minGen <= 500
            modulo = 10;
        elseif minGen <= 2000
            modulo = 50;
        elseif minGen <= 5000
            modulo = 100;
        elseif minGen <= 10000
            modulo = 500;
        end
        
        
        for i=1:minGen
            if mod(i,modulo) ~= 0
                in.stdAccuracy(1,i) = NaN;
                in.stdNRMSE(1,i) = NaN;
                in.stdNRMSEReal(1,i) = NaN;
                in.stdCon(1,i) = NaN;
                in.stdInp(1,i) = NaN;
                in.stdHid(1,i) = NaN;
                in.stdDelays(1,i) = NaN;
                % bestWorst Fitness
                in.stdBestFit(1,i) = NaN;
                in.stdWorstFit(1,i) = NaN;
                
                for module = 1:in.noModules
                    in.stdLrate{module}(1,i) = NaN;
                end
                
                
                % Section for the mutations
                in.stdhybridtraining(1,i) = NaN;
                in.stdnodeDel(1,i) = NaN;
                in.stdconnDel(1,i) = NaN;
                in.stdnodeAdd(1,i) = NaN;
                in.stdconnAdd(1,i) = NaN;
                
                in.stdMBP(1,i) = NaN;
                in.stdSA(1,i) = NaN;
                in.stdInpAdd(1,i) = NaN;
                in.stdInpDel(1,i) = NaN;
                in.stdDelayAdd(1,i) = NaN;
                in.stdDelayDel(1,i) = NaN;
                
                
                
                % for the average values XXXX
                
                
                
                % section for evolution of modules 1
                if ( allrun{1,1}.var.algoFeatures ==  allrun{1,1}.C.MODULAR1 )
                    in.stdSharedNodeDel(1,i) = NaN;
                    in.stdSharedConnDel(1,i) = NaN;
                    in.stdStrongConnAdd(1,i) = NaN;
                end
                
                
                
                if ( allrun{1,1}.var.isModule1 ==  allrun{1,1}.C.ON )
                    in.stdMweight(1,i) = NaN;
                    in.stdMarch(1,i) = NaN;
                    in.stdNoShared(1,i) = NaN;
                    in.stdNoSharedConn(1,i) = NaN;
                    in.stdIsolated(1,i) = NaN;
                    
                    for j = 1:in.noModules
                        in.stdFitnessPerModule{j,1}(1,i) = NaN;
                        in.stdNodesPerModule{j,1}(1,i) = NaN;
                    end
                    
                    
                    if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
                        for j = 1:in.noModules
                            in.stdClassifErrPerMod{j,1}(1,i) = NaN;
                        end
                    end
                end
                
                if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
                    in.stdClassifE(1,i) = NaN;
                end
                
                
                
                % Module reuse
                if (allrun{1,1}.var.reuseModule == allrun{1,1}.C.ON )
                    for j = 1:in.noModules
                        in.stdNodesReusedPerMod{j,1}(1,i) = NaN;
                    end
                end
    
                
            end
        end
    end
    
    
    
    
    
    
    
    
    
    
end

% obtain standard error ste = std/sqrt(n)
if STE == 1
    % delacara/ allocate space/ assing value
    in.steAccuracy = in.stdAccuracy./sqrt(corrida);
    in.steNRMSE = in.stdNRMSE./sqrt(corrida);
    in.steNRMSEReal = in.stdNRMSEReal./sqrt(corrida);
    in.steCon = in.stdCon./sqrt(corrida);
    in.steInp = in.stdInp./sqrt(corrida);
    in.steHid = in.stdHid./sqrt(corrida);
    in.steDelays = in.stdDelays./sqrt(corrida);
    
    in.steBestFit = in.stdBestFit./sqrt(corrida);
    in.steWorstFit = in.stdWorstFit./sqrt(corrida);
    
    for module = 1:in.noModules
        in.steLrate{module} = in.stdLrate{module}./sqrt(corrida);
    end
    
    
    
    
    % Section for the mutations
    in.stehybridtraining = in.stdhybridtraining./sqrt(corrida);
    in.stenodeDel = in.stdnodeDel./sqrt(corrida);
    in.steconnDel = in.stdconnDel./sqrt(corrida);
    in.stenodeAdd = in.stdnodeAdd./sqrt(corrida);
    in.steconnAdd = in.stdconnAdd./sqrt(corrida);
    
    in.steMBP = in.stdMBP./sqrt(corrida);
    in.steSA = in.stdSA./sqrt(corrida);
    in.steInpAdd = in.stdInpAdd./sqrt(corrida);
    in.steInpDel = in.stdInpDel./sqrt(corrida);
    in.steDelayAdd = in.stdDelayAdd./sqrt(corrida);
    in.steDelayDel = in.stdDelayDel./sqrt(corrida);
    
    % section for evolution of modules 1
    if ( allrun{1,1}.var.algoFeatures ==  allrun{1,1}.C.MODULAR1 )
        in.steSharedNodeDel = in.stdSharedNodeDel./sqrt(corrida);
        in.steSharedConnDel = in.stdSharedConnDel./sqrt(corrida);
        in.steStrongConnAdd = in.stdStrongConnAdd./sqrt(corrida);
    end
    
    
    
    
    
    
    if ( allrun{1,1}.var.isModule1 ==  allrun{1,1}.C.ON )
        in.steMweight = in.stdMweight./sqrt(corrida);
        in.steMarch = in.stdMarch./sqrt(corrida);
        in.steNoShared = in.stdNoShared./sqrt(corrida);
        in.steNoSharedConn = in.stdNoSharedConn./sqrt(corrida);
        in.steIsolated = in.stdIsolated./sqrt(corrida);
        
        for j = 1:in.noModules
            in.steFitnessPerModule{j,1} = in.stdFitnessPerModule{j,1}./sqrt(corrida);
            in.steNodesPerModule{j,1} = in.stdNodesPerModule{j,1}./sqrt(corrida);
        end
        
        
        if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
            for j = 1:in.noModules
                in.steClassifErrPerMod{j,1} = in.stdClassifErrPerMod{j,1}./sqrt(corrida);
            end
        end
        
    end
    
    if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
        in.steClassifE = in.stdClassifE./sqrt(corrida);
    end
    
    
    
    % Module reuse
    if (allrun{1,1}.var.reuseModule == allrun{1,1}.C.ON )
        for j = 1:in.noModules
            in.steNodesReusedPerMod{j,1} = in.stdNodesReusedPerMod{j,1}./sqrt(corrida);
        end
    end
    
    
    
    % Eliminate some bars to allow clear figures
    if nargin == 6
        for i=1:minGen
            if mod(i,modulo) ~= 0
                in.steAccuracy(1,i) = NaN;
                in.steNRMSE(1,i) = NaN;
                in.steNRMSEReal(1,i) = NaN;
                in.steCon(1,i) = NaN;
                in.steInp(1,i) = NaN;
                in.steHid(1,i) = NaN;
                in.steDelays(1,i) = NaN;
                
                in.steBestFit(1,i) = NaN;
                in.steWorstFit(1,i) = NaN;
                
                for module = 1:in.noModules
                    in.steLrate{module}(1,i) = NaN;
                end
                
                
                % Section for the mutations
                in.stehybridtraining(1,i) = NaN;
                in.stenodeDel(1,i) = NaN;
                in.steconnDel(1,i) = NaN;
                in.stenodeAdd(1,i) = NaN;
                in.steconnAdd(1,i) = NaN;
                
                in.steMBP(1,i) = NaN;
                in.steSA(1,i) = NaN; 
                in.steInpAdd(1,i) = NaN;
                in.steInpDel(1,i) = NaN;
                in.steDelayAdd(1,i) = NaN;
                in.steDelayDel(1,i) = NaN;
                
                % section for evolution of modules 1
                if ( allrun{1,1}.var.algoFeatures ==  allrun{1,1}.C.MODULAR1 )
                    in.steSharedNodeDel(1,i) = NaN;
                    in.steSharedConnDel(1,i) = NaN;
                    in.steStrongConnAdd(1,i) = NaN;
                end
                
                
                
                
                
                if ( allrun{1,1}.var.isModule1 ==  allrun{1,1}.C.ON )
                    in.steMweight(1,i) = NaN;
                    in.steMarch(1,i) = NaN;
                    in.steNoShared(1,i) = NaN;
                    in.steNoSharedConn(1,i) = NaN;
                    in.steIsolated(1,i) = NaN;
                    
                    if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
                        for j = 1:in.noModules
                            in.steFitnessPerModule{j,1}(1,i) = NaN;
                            in.steClassifErrPerMod{j,1}(1,i) = NaN;
                            in.steNodesPerModule{j,1}(1,i) = NaN;
                        end
                    end
                    
                end
                
                if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
                    in.steClassifE(1,i) = NaN;
                end
                
                % Module reuse
                if (allrun{1,1}.var.reuseModule == allrun{1,1}.C.ON )
                    for j = 1:in.noModules
                        in.steNodesReusedPerMod{j,1}(1,i) = NaN;
                    end
                end
                
    
                
            end
        end
    end
   
    
end






%% Section for the average parameters for the final test set

obtainOutsideVals;



