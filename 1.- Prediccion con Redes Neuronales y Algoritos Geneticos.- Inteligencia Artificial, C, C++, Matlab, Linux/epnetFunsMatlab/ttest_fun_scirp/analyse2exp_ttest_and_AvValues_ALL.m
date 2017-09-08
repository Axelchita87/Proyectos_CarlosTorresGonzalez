%% T-test between two experiments 
% script to analyse the results of both experimets for NRMSE, inputs, hidden
% Connections, delays and time (if exist)
% e.g.
% (A) 30C successful tainig 70%
% (B) 31C  "         "   `  30%
%
% Author: Carlos Torres and Victor Landassuri 
% Created: 20 Jan 2008 (Aprox)
% Modified: 26 Jul 2011

%% Start script
clear
clc

% this file is related with the platilla in excel, put in B the dir that
% must be improved to make the comparisons

%Linux
TSDIR{1,1} = 'workspace';      %(A) main directory where this file reside
TSDIR{1,2} = 'workspace';      %(B)

%is delays
thereIsdelays = 1;



% ---- Not modify after here ----------------------------------------------


%Section to determinate with OS is running 
cd('..'); cd('LinuxOrWindows')
%use adecuate paht
slash2use = isLinOrWin();
cd('..');  cd('..'); cd('..'); 
path1 = pwd;        %main dir for Exps

cd(TSDIR{1,1});
load TS.mat;



%add path for used funtions
addpath([path1,slash2use,TSDIR{1,1},slash2use,'epnetFunsMatlab',slash2use,'ANN']);



TABLEnrms{1,1} = 'table_A_nrms';
TABLEnrms{1,2} = 'table_B_nrms';
% TABLEnrms{1,3} = 'table24Cnrms';
% TABLEnrms{1,4} = 'table25Cnrms';


TABLEinputs{1,1} = 'table_A_inputs';
TABLEinputs{1,2} = 'table_B_inputs';
% TABLEinputs{1,3} = 'table24Cinputs';
% TABLEinputs{1,4} = 'table25Cinputs';

TABLEdelay{1,1} = 'table_A_delay';
TABLEdelay{1,2} = 'table_B_delay';

TABLEhidden{1,1} = 'table_A_hidden';
TABLEhidden{1,2} = 'table_B_hidden';
% TABLEhidden{1,3} = 'table24Chidden';
% TABLEhidden{1,4} = 'table25Chidden';


TABLEconn{1,1} = 'table_A_conn';
TABLEconn{1,2} = 'table_B_conn';
% TABLEconn{1,3} = 'table24Cconn';
% TABLEconn{1,4} = 'table25Cconn';

TABLEtime{1,1} = 'table_A_time';
TABLEtime{1,2} = 'table_B_time';



for Exp=1:2         %to enter in the directories of TSEPNetxxC
    cd([path1,slash2use,TSDIR{1,Exp}]);
    TSDIR{1,Exp}    %To show in the screen the TS

    for i=1:size(TS,2) %TS2analyse      %to enter in each TS
        cd(TS{1,i});
        TS{1,i}

        cd('res');          %enter where is saved the reuslts
        load allrun.mat
        corrida = size(allrun,2);
        
        %declarate some variables
        ErrorPerRun = zeros(1,corrida);
        InputsPerRun = zeros(1,corrida);
        delaysPerRun = zeros(1,corrida);
        HiddenPerRun = zeros(1,corrida);
        ConnPerRun = zeros(1,corrida);
        CPU_time = zeros(1,corrida);
        
        maximo=[];
        minimo=[];
        posMax=[];
        posMin=[];


        %All the errors, inputs, hidden and Connections per run in one vector
        %take the values from the best individual
        for j=1:corrida
            ErrorPerRun(1,j) = allrun{1,j}.Network{1,1}.fitness; %alrun{1,j}.Network{1,1}.predictF.NRMSE;
            InputsPerRun(1,j) = sum( allrun{1,j}.Network{1,1}.nodes( 1:allrun{1,j}.Network{1,1}.varN.finalInp) ); % allrun{1,j}.Network{1,1}.varN.finalInp;
            delaysPerRun(1,j) = allrun{1,j}.Network{1,1}.varN.delays;
            HiddenPerRun(1,j) = allrun{1,j}.Network{1,1}.varN.hidden;
            %this part is for the conenctions
            ConnPerRun(1,j) = countConnections(allrun{1,j}.Network{1,1}.CW, allrun{1,j}.Network{1,1}.bias);
            CPU_time(1,j) = allrun{1,j}.cpu_time_used;
            
        end
        [minimo, posMin] = min(ErrorPerRun);
        [maximo, posMax] = max(ErrorPerRun);

        %cont the connections of CW of the best of the run
        Connections = 0;
        Connections = ConnPerRun(1,posMin);

        %Save values in tables
        eval([TABLEnrms{1,Exp},'(i,1) = mean(ErrorPerRun);']);
        eval([TABLEnrms{1,Exp},'(i,2) = std(ErrorPerRun);']);
        eval([TABLEnrms{1,Exp},'(i,3) = minimo;']);
        eval([TABLEnrms{1,Exp},'(i,4) = maximo;']);
        eval([TABLEnrms{1,Exp},'(i,5) = sum( allrun{1,posMin}.Network{1,1}.nodes( 1:allrun{1,posMin}.Network{1,1}.varN.finalInp) ); ']); 
        eval([TABLEnrms{1,Exp},'(i,6) = allrun{1,posMin}.Network{1,1}.varN.delays;']);
        eval([TABLEnrms{1,Exp},'(i,7) = allrun{1,posMin}.Network{1,1}.varN.hidden;']);
        eval([TABLEnrms{1,Exp},'(i,8) = Connections;']);
        if ( allrun{1,1}.var.task2solve == allrun{1,1}.C.PREDICT )
            eval([TABLEnrms{1,Exp},'(i,9) = allrun{1,posMin}.Network{1,1}.predictI.accuracy;']);
            eval([TABLEnrms{1,Exp},'(i,10) = allrun{1,posMin}.Network{1,1}.predictF.accuracy;']);
        end
        eval([TABLEnrms{1,Exp},'(i,11) = posMin;']);



        Connections=[];
        tempConnBias=[];

        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        %%%% Now calculate the same tables for the Inputs  %%%%
        %Average values

        [minimo, posMin] = min(InputsPerRun);
        [maximo, posMax] = max(InputsPerRun);

        %Save values in tables
        eval([TABLEinputs{1,Exp},'(i,1) = mean(InputsPerRun);']);
        eval([TABLEinputs{1,Exp},'(i,2) = std(InputsPerRun);']);
        eval([TABLEinputs{1,Exp},'(i,3) = minimo;']);
        eval([TABLEinputs{1,Exp},'(i,4) = maximo;']);

        
         %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        %%%% Now calculate the same tables for the delays  %%%%
        %Average values

        [minimo, posMin] = min(delaysPerRun);
        [maximo, posMax] = max(delaysPerRun);

        %Save values in tables
        eval([TABLEdelay{1,Exp},'(i,1) = mean(delaysPerRun);']);
        eval([TABLEdelay{1,Exp},'(i,2) = std(delaysPerRun);']);
        eval([TABLEdelay{1,Exp},'(i,3) = minimo;']);
        eval([TABLEdelay{1,Exp},'(i,4) = maximo;']);
        
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        %%%% Now calculate the same tables for the Hidden  %%%%
        %Average values

        [minimo, posMin] = min(HiddenPerRun);
        [maximo, posMax] = max(HiddenPerRun);

        %Save values in tables
        eval([TABLEhidden{1,Exp},'(i,1) = mean(HiddenPerRun);']);
        eval([TABLEhidden{1,Exp},'(i,2) = std(HiddenPerRun);']);
        eval([TABLEhidden{1,Exp},'(i,3) = minimo;']);
        eval([TABLEhidden{1,Exp},'(i,4) = maximo;']);

        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        %%%% Now calculate the same tables for the Connections  %%%%
        %Average values

        [minimo, posMin] = min(ConnPerRun);
        [maximo, posMax] = max(ConnPerRun);

        %Save values in tables
        eval([TABLEconn{1,Exp},'(i,1) = mean(ConnPerRun);']);
        eval([TABLEconn{1,Exp},'(i,2) = std(ConnPerRun);']);
        eval([TABLEconn{1,Exp},'(i,3) = minimo;']);
        eval([TABLEconn{1,Exp},'(i,4) = maximo;']);
        
        
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        %%%% Now calculate the same tables for the CPU Time  %%%%
        %Average values
        
        [minimo, posMin] = min(CPU_time);
        [maximo, posMax] = max(CPU_time);
        
        %Save values in tables
        eval([TABLEtime{1,Exp},'(i,1) = mean(CPU_time);']);
        eval([TABLEtime{1,Exp},'(i,2) = std(CPU_time);']);
        eval([TABLEtime{1,Exp},'(i,3) = minimo;']);
        eval([TABLEtime{1,Exp},'(i,4) = maximo;']);
        
        
        %format cel{exp_A_ exp_B_ ...}(TS,:);
        tableNRMSE_Exp_TSaverage{1,Exp}(i,:) = ErrorPerRun;
        tableInputs_Exp_TSaverage{1,Exp}(i,:) = InputsPerRun;
        tabledelays_Exp_TSaverage{1,Exp}(i,:) = delaysPerRun;
        tableHhidden_Exp_TSaverage{1,Exp}(i,:) = HiddenPerRun;
        tableConnec_Exp_TSaverage{1,Exp}(i,:) = ConnPerRun;
        
        tableTime_Exp_TSaverage{1,Exp}(i,:) = CPU_time;
        



        %clear some variables, to not overlap with new ones
        clear allrun
        cd('..');           %exit dir results
        cd('..');           %exit dir TS
    end

    cd('..')                %exit dir Exp
end


%%% Section to calculate the t-test %%%

%h = 1 indicates a rejection of the null hypothesis at the 5% significance level
%h = 0 indicates a failure to reject the null hypothesis at the 5% significance level

%p = p-value = is the probability, under the null hypothesis, of
%observing a value as extreme or more extreme of the test statistic

%ci 100*(1 � alpha)% confidence interval on the difference of population means.

% h     p   c1  c2  myFromula
alpha = 0.05;
tail='both';
type='unequal';

%T-test A-B


for i=1:size(TS,2)   %TS2analyse

    %error
    [h,p,ci] = ttest2(tableNRMSE_Exp_TSaverage{1,1}(i,:),tableNRMSE_Exp_TSaverage{1,2}(i,:),alpha, tail, type);  %tail is default to both, 2 in excel
    ttest_A__B(i,1) = p;

    %Inputs
    [h,p,ci] = ttest2(tableInputs_Exp_TSaverage{1,1}(i,:),tableInputs_Exp_TSaverage{1,2}(i,:),alpha, tail, type);  %tail is default to both, 2 in excel
    ttest_A__B(i,2) = p;

     %delays
    [h,p,ci] = ttest2(tabledelays_Exp_TSaverage{1,1}(i,:),tabledelays_Exp_TSaverage{1,2}(i,:),alpha, tail, type);  %tail is default to both, 2 in excel
    ttest_A__B(i,3) = p;
    
    %Hidden
    [h,p,ci] = ttest2(tableHhidden_Exp_TSaverage{1,1}(i,:),tableHhidden_Exp_TSaverage{1,2}(i,:),alpha, tail, type);  %tail is default to both, 2 in excel
    ttest_A__B(i,4) = p;

    %Connections
    [h,p,ci] = ttest2(tableConnec_Exp_TSaverage{1,1}(i,:),tableConnec_Exp_TSaverage{1,2}(i,:),alpha, tail, type);  %tail is default to both, 2 in excel
    ttest_A__B(i,5) = p;

    %CPU_Time
    [h,p,ci] = ttest2(tableTime_Exp_TSaverage{1,1}(i,:),tableTime_Exp_TSaverage{1,2}(i,:),alpha, tail, type);  %tail is default to both, 2 in excel
    ttest_A__B(i,6) = p;
    

   
    
end
% save results_A_and_B table_A_nrms table_B_nrms ...
%     table_A_inputs table_B_inputs ...
%     table_A_hidden table_B_hidden ...
%     table_A_conn table_B_conn ...
%     tableNRMSE_Exp_TSaverage tableInputs_Exp_TSaverage tableHhidden_Exp_TSaverage...
%     tableConnec_Exp_TSaverage ...
%     ttest_A__B

rmpath([path1,slash2use,TSDIR{1,1},slash2use,'epnetFunsMatlab',slash2use,'ANN']);

