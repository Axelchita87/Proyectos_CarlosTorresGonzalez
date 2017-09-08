%script to analyse the ttest for only one filed
%e.g. NRMSE at 30stpes ahead, 60,120, ...

%(A) 30C successful tainig 70%
%(B) 31C  "         "   `  30%

clear
clc
%this file si related with the platilla in excel, put in B the dir that
%must be improved to make the comparisons

%Linux
TSDIR{1,1} = 'TSEPnet66v1';      %(A) main directory where this file reside
TSDIR{1,2} = 'TSEPnet66b';      %(B)

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


TABLEnrms{1,1} = 'table_A_nrms';
TABLEnrms{1,2} = 'table_B_nrms';



for Exp=1:2         %to enter in the directories of TSEPNetxxC
    cd([path1,slash2use,TSDIR{1,Exp}]);
    TSDIR{1,Exp}    %To show in the screen the TS

    for i=1:TS2analyse      %to enter in each TS
        cd(TS{1,i});
        TS{1,i}

        cd('res');          %enter where is saved the reuslts
        load allrun.mat
        
        %declarate some variables
        ErrorPerRun = zeros(1,corrida);
        
        
        maximo=[];
        minimo=[];
        posMax=[];
        posMin=[];


        %All the errors, inputs, hidden and Connections per run in one vector
        %take the values from the best individual
        for j=1:corrida
            ErrorPerRun(1,j) = allrun{1,j}.Network{1,1}.predictF.NRMSE;
        end
        [minimo, posMin] = min(ErrorPerRun);
        [maximo, posMax] = max(ErrorPerRun);

        %cont the conne
rmpath([path1,slash2use,'FunsMatlab',slash2use,'ANN']);ctions of CW of the best of the run
        Connections = 0;
        Connections = ConnPerRun(1,posMin);

        %Save values in tables
        eval([TABLEnrms{1,Exp},'(i,1) = mean(ErrorPerRun);']);
        eval([TABLEnrms{1,Exp},'(i,2) = std(ErrorPerRun);']);
        eval([TABLEnrms{1,Exp},'(i,3) = minimo;']);
        eval([TABLEnrms{1,Exp},'(i,4) = maximo;']);
        eval([TABLEnrms{1,Exp},'(i,5) = allrun{1,posMin}.Network{1,1}.sizepos(1,1);']);
        eval([TABLEnrms{1,Exp},'(i,6) = allrun{1,posMin}.Network{1,1}.sizepos(1,2);']);
        eval([TABLEnrms{1,Exp},'(i,7) = Connections;']);
        eval([TABLEnrms{1,Exp},'(i,8) = allrun{1,posMin}.Network{1,1}.predictI.accuracy;']);
        eval([TABLEnrms{1,Exp},'(i,9) = allrun{1,posMin}.Network{1,1}.predictF.accuracy;']);
        eval([TABLEnrms{1,Exp},'(i,10) = posMin;']);

        
        
        %format cel{exp_A_ exp_B_ ...}(TS,:);
        tableNRMSE_Exp_TSaverage{1,Exp}(i,:) = ErrorPerRun;
               

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
    [h,p,ci] = ttest2(tableNRMSE_Exp_TSaverage{1,1}(i,:),tableNRMSE_Exp_TSaverage{1,2}(i,:),alpha, tail, type);  %tail is default to both, 2 in excel
    ttest_A__B(i,1) = p;

       
end
% save results_A_and_B table_A_nrms table_B_nrms ...
%     table_A_inputs table_B_inputs ...
%     table_A_hidden table_B_hidden ...
%     table_A_conn table_B_conn ...
%     tableNRMSE_Exp_TSaverage tableInputs_Exp_TSaverage tableHhidden_Exp_TSaverage...
%     tableConnec_Exp_TSaverage ...
%     ttest_A__B

