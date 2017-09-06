%script to analyse the results of both experimets omly for the NRMSE
% for 15 steps, 30, 60, 120, 240, 480 stpes

%NOTE THAT THIS SCRIPT TAKE THE MINIMUM FOR EACH ERROR,
% IT IS NOT THE MINIMUM OF THE FIRST ERROR, AND USED THIS POSITION TO TAKE
% THE REST


%e.g.
%(A) 30C successful tainig 70%
%(B) 31C  "         "   `  30%

clear
clc
%this file si related with the platilla in excel, put in B the dir that
%must be improved to make the comparisons

%Linux
TSDIR{1,1} = 'TSEPnet66v1';      %(A) main directory where this file reside
TSDIR{1,2} = 'TSEPnet66c';      %(B)

%How many TS to analyse 1:21
TS2analyse = 7;

corrida = 30;

%Section to determinate with OS is running 
cd('..'); cd('..'); cd('..'); cd('FunsMatlab');  cd('LinuxOrWindows')
%use adecuate paht
slash2use = isLinOrWin();
cd('..');  cd('..');

eval(['load ', TSDIR{1,1}, slash2use, 'TS.mat']);
path1 = pwd;        %main dir for Exps


TABLEnrms15{1,1} = 'table_A_nrms15';
TABLEnrms15{1,2} = 'table_B_nrms15';

TABLEnrms30{1,1} = 'table_A_nrms30';
TABLEnrms30{1,2} = 'table_B_nrms30';

TABLEnrms60{1,1} = 'table_A_nrms60';
TABLEnrms60{1,2} = 'table_B_nrms60';

TABLEnrms120{1,1} = 'table_A_nrms120';
TABLEnrms120{1,2} = 'table_B_nrms120';

TABLEnrms240{1,1} = 'table_A_nrms240';
TABLEnrms240{1,2} = 'table_B_nrms240';

TABLEnrms480{1,1} = 'table_A_nrms480';
TABLEnrms480{1,2} = 'table_B_nrms480';



for Exp=1:2         %to enter in the directories of TSEPNetxxC
    cd([path1,slash2use,TSDIR{1,Exp}]);
    TSDIR{1,Exp}    %To show in the screen the TS

    for i=1:TS2analyse      %to enter in each TS
        cd(TS{1,i});
        TS{1,i}

        cd('res');          %enter where is saved the reuslts
        load allrun.mat
        
        %declarate some variables
        ErrorPerRun15 = zeros(1,corrida);
        ErrorPerRun30 = zeros(1,corrida);
        ErrorPerRun60 = zeros(1,corrida);
        ErrorPerRun120 = zeros(1,corrida);
        ErrorPerRun240 = zeros(1,corrida);
        ErrorPerRun480 = zeros(1,corrida);
             
        
        
        maximo=[];
        minimo=[];
        posMax=[];
        posMin=[];


        %All the errors, inputs, hidden and Connections per run in one vector
        %take the values from the best individual
        for j=1:corrida
            ErrorPerRun15(1,j) = allrun{1,j}.Network{1,1}.predict{1,1}.NRMSE;
            ErrorPerRun30(1,j) = allrun{1,j}.Network{1,1}.predict{1,2}.NRMSE;
            ErrorPerRun60(1,j) = allrun{1,j}.Network{1,1}.predict{1,3}.NRMSE;
            ErrorPerRun120(1,j) = allrun{1,j}.Network{1,1}.predict{1,4}.NRMSE;
            ErrorPerRun240(1,j) = allrun{1,j}.Network{1,1}.predict{1,5}.NRMSE;
            ErrorPerRun480(1,j) = allrun{1,j}.Network{1,1}.predict{1,6}.NRMSE;
        end
        
        
        [minimo, posMin] = min(ErrorPerRun15);
        [maximo, posMax] = max(ErrorPerRun15);

        %Save values in tables
        eval([TABLEnrms15{1,Exp},'(i,1) = mean(ErrorPerRun15);']);
        eval([TABLEnrms15{1,Exp},'(i,2) = std(ErrorPerRun15);']);
        eval([TABLEnrms15{1,Exp},'(i,3) = minimo;']);
        eval([TABLEnrms15{1,Exp},'(i,4) = maximo;']);
        eval([TABLEnrms15{1,Exp},'(i,5) = posMin;']);


        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        %%%% Now calculate 30

        [minimo, posMin] = min(ErrorPerRun30);
        [maximo, posMax] = max(ErrorPerRun30);

        %Save values in tables
        eval([TABLEnrms30{1,Exp},'(i,1) = mean(ErrorPerRun30);']);
        eval([TABLEnrms30{1,Exp},'(i,2) = std(ErrorPerRun30);']);
        eval([TABLEnrms30{1,Exp},'(i,3) = minimo;']);
        eval([TABLEnrms30{1,Exp},'(i,4) = maximo;']);
        eval([TABLEnrms30{1,Exp},'(i,5) = posMin;']);

        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        %%%% Now calculate 60

        [minimo, posMin] = min(ErrorPerRun60);
        [maximo, posMax] = max(ErrorPerRun60);

        %Save values in tables
        eval([TABLEnrms60{1,Exp},'(i,1) = mean(ErrorPerRun60);']);
        eval([TABLEnrms60{1,Exp},'(i,2) = std(ErrorPerRun60);']);
        eval([TABLEnrms60{1,Exp},'(i,3) = minimo;']);
        eval([TABLEnrms60{1,Exp},'(i,4) = maximo;']);
        eval([TABLEnrms60{1,Exp},'(i,5) = posMin;']);

        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        %%%% Now calculate 120
       [minimo, posMin] = min(ErrorPerRun120);
        [maximo, posMax] = max(ErrorPerRun120);

        %Save values in tables
        eval([TABLEnrms120{1,Exp},'(i,1) = mean(ErrorPerRun120);']);
        eval([TABLEnrms120{1,Exp},'(i,2) = std(ErrorPerRun120);']);
        eval([TABLEnrms120{1,Exp},'(i,3) = minimo;']);
        eval([TABLEnrms120{1,Exp},'(i,4) = maximo;']);
        eval([TABLEnrms120{1,Exp},'(i,5) = posMin;']);


        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        %%%% Now calculate 240
        
        [minimo, posMin] = min(ErrorPerRun240);
        [maximo, posMax] = max(ErrorPerRun240);

        %Save values in tables
        eval([TABLEnrms240{1,Exp},'(i,1) = mean(ErrorPerRun240);']);
        eval([TABLEnrms240{1,Exp},'(i,2) = std(ErrorPerRun240);']);
        eval([TABLEnrms240{1,Exp},'(i,3) = minimo;']);
        eval([TABLEnrms240{1,Exp},'(i,4) = maximo;']);
        eval([TABLEnrms240{1,Exp},'(i,5) = posMin;']);
            
        
         %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        %%%% Now calculate 480
        
        [minimo, posMin] = min(ErrorPerRun480);
        [maximo, posMax] = max(ErrorPerRun480);

        %Save values in tables
        eval([TABLEnrms480{1,Exp},'(i,1) = mean(ErrorPerRun480);']);
        eval([TABLEnrms480{1,Exp},'(i,2) = std(ErrorPerRun480);']);
        eval([TABLEnrms480{1,Exp},'(i,3) = minimo;']);
        eval([TABLEnrms480{1,Exp},'(i,4) = maximo;']);
        eval([TABLEnrms480{1,Exp},'(i,5) = posMin;']);
        
        
            %format cel{exp_A_ exp_B_ ...}(TS,:);
            tableNRMSE15_Exp_TSaverage{1,Exp}(i,:) = ErrorPerRun15;
            tableNRMSE30_Exp_TSaverage{1,Exp}(i,:) = ErrorPerRun30;
            tableNRMSE60_Exp_TSaverage{1,Exp}(i,:) = ErrorPerRun60;
            tableNRMSE120_Exp_TSaverage{1,Exp}(i,:) = ErrorPerRun120;
            tableNRMSE240_Exp_TSaverage{1,Exp}(i,:) = ErrorPerRun240;
            tableNRMSE480_Exp_TSaverage{1,Exp}(i,:) = ErrorPerRun480;

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


for i=1:TS2analyse

    %error
    [h,p,ci] = ttest2(tableNRMSE15_Exp_TSaverage{1,1}(i,:),tableNRMSE15_Exp_TSaverage{1,2}(i,:),alpha, tail, type);  %tail is default to both, 2 in excel
    ttest_A__B(i,1) = p;

    [h,p,ci] = ttest2(tableNRMSE30_Exp_TSaverage{1,1}(i,:),tableNRMSE30_Exp_TSaverage{1,2}(i,:),alpha, tail, type);  %tail is default to both, 2 in excel
    ttest_A__B(i,2) = p;
    
    [h,p,ci] = ttest2(tableNRMSE60_Exp_TSaverage{1,1}(i,:),tableNRMSE60_Exp_TSaverage{1,2}(i,:),alpha, tail, type);  %tail is default to both, 2 in excel
    ttest_A__B(i,3) = p;
    
    [h,p,ci] = ttest2(tableNRMSE120_Exp_TSaverage{1,1}(i,:),tableNRMSE120_Exp_TSaverage{1,2}(i,:),alpha, tail, type);  %tail is default to both, 2 in excel
    ttest_A__B(i,4) = p;
    
    [h,p,ci] = ttest2(tableNRMSE240_Exp_TSaverage{1,1}(i,:),tableNRMSE240_Exp_TSaverage{1,2}(i,:),alpha, tail, type);  %tail is default to both, 2 in excel
    ttest_A__B(i,5) = p;
    
    [h,p,ci] = ttest2(tableNRMSE480_Exp_TSaverage{1,1}(i,:),tableNRMSE480_Exp_TSaverage{1,2}(i,:),alpha, tail, type);  %tail is default to both, 2 in excel
    ttest_A__B(i,6) = p;
    
    
    

   
    
end
% save results_A_and_B table_A_nrms table_B_nrms ...
%     table_A_inputs table_B_inputs ...
%     table_A_hidden table_B_hidden ...
%     table_A_conn table_B_conn ...
%     tableNRMSE_Exp_TSaverage tableInputs_Exp_TSaverage tableHhidden_Exp_TSaverage...
%     tableConnec_Exp_TSaverage ...
%     ttest_A__B
