%% T-tes between all parameters all experiments
%
% Script to read experiments and save in a file the some parameter. Then is 
% analsed with the ttest from the best (minimum av nrmse) agaisnt all other
%
% coment the directories that are not required
%
% Useful tables
% TableAvXXXX   -> tha av values form all exps
% ttestXXXAllTS -> the -1 0 1 matrix form ttes form all exps
% ttestXXXAllTSval -> the matrix with the p values from all exps
% ALLTSres       -> all the values from exps organized by TS
%
% Author: Carlos Torres and Victor Landassuri 
% Created: 20 Jan 2008 (Aprox)
% Modified: 31 Jul 2011


%% Start script
clear
clc

AddExp = 0; %1-> add experiment to the actual file. 0->create file with all the experiments listed


% Not modify this ---------------------------------------------------------
cd('..'); 
cd('LinuxOrWindows')
%use adecuate paht
slash2use = isLinOrWin();
cd('..');cd('..');
path0 = pwd;        %main dir for Exps

%add path for used funtions
addpath([path0,slash2use,'epnetFunsMatlab',slash2use,'ANN']);

cd('..');
path1 = pwd;        %main dir for Exps

if AddExp == 0
    %load the TS
    load([path0,slash2use,'TS.mat'])
    tamTS = size(TS,2);
    Dir2start = 1;
elseif AddExp == 1
    %TO ADD MORE EXPE TO THE ACTUAL ONE
    cd(path1)
    load allExps.mat
    Dir2start = lastdir + 1;
end

% finish this bloc, modify next block -------------------------------------



%Directories to compare, the posistion to enter them is the position to plot 
dirExp{1,1} = 'fixD';   
dirExp{1,2} = 'fixD2plus1';   
dirExp{1,3} = 'fixEvoD';   
dirExp{1,4} = 'fixEvoD2plus1';
dirExp{1,5} = 'hierar';
dirExp{1,6} = 'asymm';
% dirExp{1,7} = 'EPNet68d1000';
% dirExp{1,8} = 'EPNet68e1000';
% dirExp{1,9} = 'EPNet69'; 
% dirExp{1,10} = 'EPNet69a'; 
% dirExp{1,11} = 'EPNet69b1'; 
% dirExp{1,12} = 'EPNet69b2'; 
% dirExp{1,13} = 'EPNet69b3'; 
% dirExp{1,14} = 'EPNet69b4'; 
% dirExp{1,15} = 'EPNet69c1'; 
% dirExp{1,16} = 'EPNet69c2'; 
% dirExp{1,17} = 'EPNet69c3'; 
% dirExp{1,18} = 'EPNet69c4'; 
% dirExp{1,19} = 'EPNet69aa'; 
% dirExp{1,20} = 'TSEPnet55C'; 
% dirExp{1,21} = 'TSEPnet56C'; 
% dirExp{1,22} = 'TSEPnet57Ca'; 
% dirExp{1,23} = 'TSEPnet58Ca'; 
% dirExp{1,24} = 'TSEPnet57Cb'; 
% dirExp{1,25} = 'TSEPnet58Cb'; 
% dirExp{1,26} = 'TSEPnet57Cc'; 
% dirExp{1,27} = 'TSEPnet58Cc'; 
% dirExp{1,28} = 'TSEPnet30C'; 
% dirExp{1,29} = 'TSEPnet31C'; 
% dirExp{1,} = 'TSEPnetC'; 
% dirExp{1,} = 'TSEPnetC'; 
% dirExp{1,} = 'TSEPnetC'; 
% dirExp{1,} = 'TSEPnetC'; 
% dirExp{1,} = 'TSEPnetC'; 

%Modify Tikcs in the figure, or/and the experiment
TicksX = {' ';'68a';'68c';'68d';'68e'};
%'37C';'38C';'40C';'42C';'43C';'44C';'45C';'46C';'47C';'48';'50C';'51Ca';...
%    '52Ca';'53C';'54C';'55C';'56C';'57Ca';'58Ca';'57Cb';'58Cb';'57Cc';'58Cc''30C';'31C'};%;'';''};


tamExps = size(dirExp,2);
lastdir = tamExps; %save the last dir for the next run

if AddExp == 0
    %Initialize the Tables to show resutls
    TableAvNRMSE = zeros(tamTS,tamExps);
    TableAvINPUT = zeros(tamTS,tamExps);
    TableAvHID = zeros(tamTS,tamExps);
    TableAvCON = zeros(tamTS,tamExps);
end


Filexist=0;

for TSdir = 1:tamTS         %for all TS
    
    
        for temp=1:tamExps                  %for to set up the directories for each TS
            dir{1,temp} = [path1,slash2use,dirExp{1,temp},slash2use,TS{1,TSdir}];
        end

        %Enter to the directories and load each exp.
        for directory = Dir2start:tamExps      %for all exp.

            cd(dir{1,directory});


            cd('res');
            %load file
            Filexist = exist('allrun.mat');
            if Filexist == 2                  % if it is a file in the dir
                load allrun.mat
                
                %obtain name of the TS
                if directory == 1
                    cd('..')
                    fid = fopen(['txtFiles',slash2use,'TSname'], 'r');
                    TSname{TSdir,1} = fgetl(fid);
                    if (fclose(fid) ~= 0)
                        'error closing file'
                    end
                    
                    %Allocate memory to some variables, they could be for the best or
                    %the average over the final population
                    % check inthe futuere if I run more corridas
                    ErrorPerRun = zeros(30,tamExps);
                    InputsPerRun = zeros(30,tamExps);
                    HiddenPerRun = zeros(30,tamExps);
                    ConnPerRun = zeros(30,tamExps);
                    
                end

                 corrida = size(allrun,2);
                    % considereing to be differet sizes, only too the
                    % smnallest
                    if directory == 1
                        smallestCorrida = corrida;
                    elseif corrida < smallestCorrida
                         smallestCorrida = corrida;                        
                    end
                    %generation = allrun{1,1}.var.generations;
                    
                    
                    

            end
            
            % Is classification or Prediction
             if allrun{1,1}.var.task2solve == allrun{1,1}.C.CLASSIFY
                 flagClass = 1;
             else
                 flagClass = 0;
             end 
            
            %Sum the values to obtain the averages
            for i=1:smallestCorrida
                %for the best individual (Final test set)
                if Filexist == 2  
                    ALLTSres{TSdir,1}.ErrorPerRun(i,directory) = allrun{1,i}.Network{1,1}.fitness;
                    ALLTSres{TSdir,1}.InputsPerRun(i,directory) = sum( allrun{1,i}.Network{1,1}.nodes( 1:allrun{1,i}.Network{1,1}.varN.finalInp) ); 
                    ALLTSres{TSdir,1}.HiddenPerRun(i,directory) = allrun{1,i}.Network{1,1}.varN.hidden;
                    %this part is for the conenctions
                    ALLTSres{TSdir,1}.ConnPerRun(i,directory) = countConnections(allrun{1,i}.Network{1,1}.CW, allrun{1,i}.Network{1,1}.bias);
                    
                    %for the average values, comment as required (inside test set)
                    %             ErrorPerRun(i,directory) = allrun{1,i}.ALLParam.AvIterateNRMS_I(1,generation);
                    %             InputsPerRun(i,directory) = allrun{1,i}.ALLParam.Avinputs(1,generation);
                    %             HiddenPerRun(i,directory) = allrun{1,i}.ALLParam.Avhidden(1,generation);
                    %             ConnPerRun(i,directory) = allrun{1,i}.ALLParam.Avconnections(1,generation);
                    %
                    if isnan(ALLTSres{TSdir,1}.ErrorPerRun(i,directory)) && i~=1
                        ALLTSres{TSdir,1}.ErrorPerRun(i,directory) = ALLTSres{TSdir,1}.ErrorPerRun(i-1,directory);
                    end
                    
                    if isnan(ALLTSres{TSdir,1}.InputsPerRun(i,directory)) && i~=1
                        ALLTSres{TSdir,1}.InputsPerRun(i,directory) = ALLTSres{TSdir,1}.InputsPerRun(i-1,directory);
                    end
                    
                    if isnan(ALLTSres{TSdir,1}.HiddenPerRun(i,directory)) && i~=1
                        ALLTSres{TSdir,1}.HiddenPerRun(i,directory) = ALLTSres{TSdir,1}.HiddenPerRun(i-1,directory);
                    end
                    
                    if isnan(ALLTSres{TSdir,1}.ConnPerRun(i,directory)) && i~=1
                        ALLTSres{TSdir,1}.ConnPerRun(i,directory) = ALLTSres{TSdir,1}.ConnPerRun(i-1,directory);
                    end
                    
                else
                    ALLTSres{TSdir,1}.ErrorPerRun(i,directory) = NaN;
                    ALLTSres{TSdir,1}.InputsPerRun(i,directory) = NaN;
                    ALLTSres{TSdir,1}.HiddenPerRun(i,directory) = NaN;
                    %this part is for the conenctions
                    ALLTSres{TSdir,1}.ConnPerRun(i,directory) = NaN;
                    
                end


            end

            % For classification tasks
            if flagClass == 1
             for i=1:smallestCorrida
                %for the best individual (Final test set)
                if Filexist == 2
                    ALLTSres{TSdir,1}.ClassErrorPerRun(i,directory) = allrun{1,i}.Network{1,1}.predictF.classifError;
                end
             end
            end
            
            clear allrun
        end
    
    
        
    %divide to average them, only take the smallest number of runs to make
    %the copariosns
    ALLTSres{TSdir,1}.AvErrorPerRun = (sum(ALLTSres{TSdir,1}.ErrorPerRun(1:smallestCorrida, :)))/smallestCorrida;
    ALLTSres{TSdir,1}.AvInputsPerRun = (sum(ALLTSres{TSdir,1}.InputsPerRun(1:smallestCorrida, :)))/smallestCorrida;
    ALLTSres{TSdir,1}.AvHiddenPerRun = (sum(ALLTSres{TSdir,1}.HiddenPerRun(1:smallestCorrida, :)))/smallestCorrida;
    ALLTSres{TSdir,1}.AvConnPerRun = (sum(ALLTSres{TSdir,1}.ConnPerRun(1:smallestCorrida, :)))/smallestCorrida;
    
    if flagClass == 1
        ALLTSres{TSdir,1}.AvClassErrorPerRun = (sum( ALLTSres{TSdir,1}.ClassErrorPerRun(1:smallestCorrida, :))) / smallestCorrida;
    end

    %error bars
    STDnrms = std(ALLTSres{TSdir,1}.ErrorPerRun(1:smallestCorrida, :));
    STDcon = std(ALLTSres{TSdir,1}.ConnPerRun(1:smallestCorrida, :));
    STDinput = std(ALLTSres{TSdir,1}.InputsPerRun(1:smallestCorrida, :));
    STDhidden = std(ALLTSres{TSdir,1}.HiddenPerRun(1:smallestCorrida, :));
        
     
   
    %find the smaller average error
    [minerror,I] = min(ALLTSres{TSdir,1}.AvErrorPerRun);
    [minInputs,Iinputs] = min(ALLTSres{TSdir,1}.AvInputsPerRun);
    [minHid,Ihid] = min(ALLTSres{TSdir,1}.AvHiddenPerRun);
    [minCon,Icon] = min(ALLTSres{TSdir,1}.AvConnPerRun);
    
    if flagClass == 1
        [minClassError,IclassE] = min(ALLTSres{TSdir,1}.AvClassErrorPerRun);
        ALLTSres{TSdir,1}.minClassError = minClassError;
        ALLTSres{TSdir,1}.minClassErrorPos = IclassE;
    end
    
    ALLTSres{TSdir,1}.minerror = minerror;
    ALLTSres{TSdir,1}.minerrorPos = I;
    
    
    %Section to format the output of the results to past them in
    %excel/openoffice
       
    TableAvNRMSE(TSdir,1:tamExps) = ALLTSres{TSdir,1}.AvErrorPerRun(1,:);
    TableAvINPUT(TSdir,1:tamExps) = ALLTSres{TSdir,1}.AvInputsPerRun(1,:);
    TableAvHID(TSdir,1:tamExps) = ALLTSres{TSdir,1}.AvHiddenPerRun(1,:);
    TableAvCON(TSdir,1:tamExps) = ALLTSres{TSdir,1}.AvConnPerRun(1,:);
    
    %Tha last two col of TableXXXX are the minimum and the position of min
    TableAvNRMSE(TSdir,tamExps+1) = 0;
    TableAvNRMSE(TSdir,tamExps+2) = ALLTSres{TSdir,1}.minerror;
    TableAvNRMSE(TSdir,tamExps+3) = ALLTSres{TSdir,1}.minerrorPos;
    
    if flagClass == 1           % for class
        TableAvClassE(TSdir,1:tamExps) = ALLTSres{TSdir,1}.AvClassErrorPerRun(1,:);
        TableAvClassE(TSdir,tamExps+1) = 0;
        TableAvClassE(TSdir,tamExps+2) = ALLTSres{TSdir,1}.minClassError;
        TableAvClassE(TSdir,tamExps+3) = ALLTSres{TSdir,1}.minClassErrorPos;
    end
    
    %after it was found, see if there is statistical significance against all other experiment
    
    alpha = 0.05;
    tail='both';
    type='unequal';
    
    %Clear values before save the pvales
    for itest=1:tamExps
        if itest ~= I    % not calculate the ttest against the same exp
            %error
            p = 100; %put another values to clean it
            [h,p,ci] = ttest2(ALLTSres{TSdir,1}.ErrorPerRun(:,I),ALLTSres{TSdir,1}.ErrorPerRun(:,itest),alpha, tail, type);
            ttestNRMSEAllTSpval(TSdir,itest) = p; %save the pvalue
            if p < 0.05
                ttestNRMSEAllTS05(TSdir,itest) = 1;
            else
                ttestNRMSEAllTS05(TSdir,itest) = -1;
            end 
            
            % test 0.01
             if p < 0.01
                ttestNRMSEAllTS01(TSdir,itest) = 1;
            else
                ttestNRMSEAllTS01(TSdir,itest) = -1;
            end 
            
            % test 0.001
             if p < 0.001
                ttestNRMSEAllTS001(TSdir,itest) = 1;
            else
                ttestNRMSEAllTS001(TSdir,itest) = -1;
             end 
            
        end
        
        % For classification errro
        if flagClass == 1
            if itest ~= IclassE    % not calculate the ttest against the same exp
                %error
                p = 100; %put another values to clean it
                [h,p,ci] = ttest2(ALLTSres{TSdir,1}.ClassErrorPerRun(:,IclassE),ALLTSres{TSdir,1}.ClassErrorPerRun(:,itest),alpha, tail, type);
                ttestClassErrorALLTSpval(TSdir,itest) = p; %save the pvalue
                if p < 0.05
                    ttestClassErrorAllTS05(TSdir,itest) = 1;
                else
                    ttestClassErrorAllTS05(TSdir,itest) = -1;
                end
                
                % test 0.01
                if p < 0.01
                    ttestClassErrorAllTS01(TSdir,itest) = 1;
                else
                    ttestClassErrorAllTS01(TSdir,itest) = -1;
                end
                
                % test 0.001
                if p < 0.001
                    ttestClassErrorAllTS001(TSdir,itest) = 1;
                else
                    ttestClassErrorAllTS001(TSdir,itest) = -1;
                end
                
            end
        end
        
        
        if itest ~= Iinputs    % not calculate the ttest against the same exp
            %inputs
            p = 100;
            [h,p,ci] = ttest2(ALLTSres{TSdir,1}.InputsPerRun(:,Iinputs),ALLTSres{TSdir,1}.InputsPerRun(:,itest),alpha, tail, type);  %tail is default to both, 2 in excel
            ttestInputAllTSpval(TSdir,itest) = p; %save the pvalue
            if p < 0.05
                ttestInputAllTS05(TSdir,itest) = 1;
            else
                ttestInputAllTS05(TSdir,itest) = -1;
            end
            
            % test 0.01
             if p < 0.01
                ttestInputAllTS01(TSdir,itest) = 1;
            else
                ttestInputAllTS01(TSdir,itest) = -1;
             end
            
            % test 0.001
             if p < 0.001
                ttestInputAllTS001(TSdir,itest) = 1;
            else
                ttestInputAllTS001(TSdir,itest) = -1;
             end
            
        end
        
        if itest ~= Ihid    % not calculate the ttest against the same exp
            %Hidden
            p = 100;
            [h,p,ci] = ttest2(ALLTSres{TSdir,1}.HiddenPerRun(:,Ihid),ALLTSres{TSdir,1}.HiddenPerRun(:,itest),alpha, tail, type);  %tail is default to both, 2 in excel
            ttestHiddenAllTSpval(TSdir,itest) = p; %save the pvalue
            if p < 0.05
                ttestHiddenAllTS05(TSdir,itest) = 1;
            else
                ttestHiddenAllTS05(TSdir,itest) = -1;
            end
            
            
             % test 0.01
             if p < 0.01
                ttestHiddenAllTS01(TSdir,itest) = 1;
            else
                ttestHiddenAllTS01(TSdir,itest) = -1;
            end
              % test 0.001
            if p < 0.001
                ttestHiddenAllTS001(TSdir,itest) = 1;
            else
                ttestHiddenAllTS001(TSdir,itest) = -1;
            end
        end
        
        if itest ~= Icon    % not calculate the ttest against the same exp
            %Connections
            p = 100;
            [h,p,ci] = ttest2(ALLTSres{TSdir,1}.ConnPerRun(:,Icon),ALLTSres{TSdir,1}.ConnPerRun(:,itest),alpha, tail, type);  %tail is default to both, 2 in excel
            ttestConnAllTSpval(TSdir,itest) = p; %save the pvalue
            if p < 0.05
                ttestConnAllTS05(TSdir,itest) = 1;
            else
                ttestConnAllTS05(TSdir,itest) = -1;
            end
            % test 0.01
             if p < 0.01
                ttestConnAllTS01(TSdir,itest) = 1;
            else
                ttestConnAllTS01(TSdir,itest) = -1;
            end
            % test 0.001
             if p < 0.001
                ttestConnAllTS001(TSdir,itest) = 1;
            else
                ttestConnAllTS001(TSdir,itest) = -1;
            end
        end
    end
    
    
    
    % select what to plot

%     for i=[2 3 4 5]                         %1:6
%         clf
%         if i==1
% %             h = plot(avaccuracy{1,1},'LineWidth',1);
% %             hold all
% %             h = plot(avaccuracy{1,2},'-r','LineWidth',1);
% %             ylabel('Average Accuracy','FontSize',12)
%         elseif i==2
%             h = errorbar(AvErrorPerRun,STDnrms,'s','LineWidth',1);
%             ylabel('Average NRMS','FontSize',12)
%         elseif i==3
%             h = errorbar(AvConnPerRun,STDcon,'s','LineWidth',1);
%             ylabel('Average Connections','FontSize',12)
%         elseif i==4
%             h = errorbar(AvInputsPerRun,STDinput,'s','LineWidth',1);
%             ylabel('Average Inputs','FontSize',12)
%         elseif i==5
%             h = errorbar(AvHiddenPerRun,STDhidden,'s','LineWidth',1);
%             ylabel('Average Hidden Nodes','FontSize',12)
%         end
% 
%         %legend('30% Successful T.P.', '70% Successful T.P.', 'FontSize', 12)
%         xlabel('Experiments','FontSize',12)
%         %xvectorVal = [0:tamExps];
%         
%         string2title = ['\it{',TSname{TSdir,1},'}'];
%         title(string2title,'FontSize',16');
%         set(gca,'XTickLabel',TicksX);
%         %set(gca,'XTick', xvectorVal);
%         
%         foo = 'to make a pause put s break point here';
%         if i==1
%             saveas(h, [dir2save,TSname,'AverageAccuracy.fig']);
%             clf;
%             clear h
%         elseif i==2
%             saveas(h, [dir2save,TSname,'AverageNRMS.fig']);
%             %saveas(h, [dir2save,TSname,'AverageNRMS.eps']); %works
%             clf;
%             clear h
%         elseif i==3
%             saveas(h, [dir2save,TSname,'AverageConn.fig']);
%             clf;
%             clear h
%         elseif i==4
%             saveas(h, [dir2save,TSname,'Averageinputs.fig']);
%             clf;
%             clear h
%         elseif i==5
%             saveas(h, [dir2save,TSname,'Averagehidden.fig']);
%             clf;
%             clear h
%         end
%     end
    %clear TSname
    %cd('..');  %exit dir TS

end

cd(path0)
clear AddExp %dirExp %not save this variable
save allExpsFeatureClass %ErrorPerRun InputsPerRun HiddenPerRun ConnPerRun TSname corrida generation TicksX
rmpath([path0,slash2use,'epnetFunsMatlab',slash2use,'ANN']);
    

