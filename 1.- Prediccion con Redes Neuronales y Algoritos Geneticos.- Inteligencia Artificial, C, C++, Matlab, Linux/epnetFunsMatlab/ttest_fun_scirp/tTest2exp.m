%% New t-test function to evaluate the ttest of many variables
% script to analyse the results of both experimets for NRMSE, inputs, hidden
% Connections, delays and time (if exist),...
% e.g.
% (A) 30C successful tainig 70%
% (B) 31C  "         "   `  30%

clear
clc



%% Set up Variable

dir0{1,1} = 'epnetGMLP_25';   %blue line -put here the Exp that mut be better
dir0{2,1} = 'MepnetGMLP_25';   %Red line
%dir0{1,1} = 'classEPNetinitCb';
%dir0{3,1} = 'classEPNetinitEcb';
% dir0{3,1} = 'classEPNetinitEcb';
% dir0{4,1} = 'classEPNetinitFdb';
% dir0{7,1} = 'classEPNetinitCa';
% dir0{8,1} = 'classEPNetinitCb';
% dir0{9,1} = 'classEPNetinitDa';
% dir0{10,1} = 'classEPNetinitDb';


% What to plot, Average, Error bar with STD or STE
% typePlot = 'STD';                 % options:: AV, STD, STE

% Take the av or best values per generaiton for the ttest
bestORav = 'av';                     % 'best' or 'av' --> take the best values or the average per population
                                       % only for outside

% F i n i s h   t h e   v a r i a b l e s   t o   c o n f i g u r e




%% Add required paths

% add path ANN
cd('..'); cd('ANN'); pathA = pwd; addpath(pathA);

cd('..');
cd('LinuxOrWindows')
%use adecuate paht
SLASH = isLinOrWin();
cd('..');
% For the individual scripts to plot
cd( [ 'plot', SLASH, 'scripts' ] );
pathB = pwd; addpath(pathB);
cd('..'); cd('..'); cd('..');


%load the TS
load TS.mat

cd('..');
path1 = pwd;        %main dir for Exps


%% Set up variables
lineType                                    % script

sizeDir = size(dir0,1);

% flag to determinate if it is classification or not
%flagClass = 0;


for TSdir = 1:size(TS,2)         %for all TS
    
    %accomodate the directories
    for alldir=1:sizeDir
        dir{1,alldir} = [path1,SLASH,dir0{alldir,1},SLASH,TS{1,TSdir}];
    end
    
    
    for directory = 1:sizeDir %for all exp.
        cd(dir{1,directory});
        
        %obtain name of the TS
        if directory == 1
            fid = fopen('txtFiles/TSname.txt', 'r');
            TSname = fgetl(fid);
            if (fclose(fid) ~= 0)
                'error closing file'
            end
        end
        cd('res');
        %load file
        load allrun.mat
        
        corrida = size(allrun,2);
        generation = allrun{1,1}.var.generations;
        
        % Obtain the average param
       info{1,directory} = obtainAvStdSte(allrun, SLASH,bestORav, 1,1,1);
       
        
        clear allrun
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
    
    %error
    [h,p,ci] = ttest2(info{1,1}.outside.fitness, info{1,2}.outside.fitness,alpha, tail, type);  %tail is default to both, 2 in excel
    ttest_A__B(TSdir,1) = p;
    
%     %Inputs
%     [h,p,ci] = ttest2(info{1,1}.outside.inputs,info{1,2}.outside.inputs,alpha, tail, type);  %tail is default to both, 2 in excel
%     ttest_A__B(TSdir,2) = p;
%     
%     %delays
%     [h,p,ci] = ttest2(info{1,1}.outside.delays,info{1,2}.outside.delays,alpha, tail, type);  %tail is default to both, 2 in excel
%     ttest_A__B(TSdir,3) = p;
%     
%     %Hidden
%     [h,p,ci] = ttest2(info{1,1}.outside.hidden,info{1,2}.outside.hidden,alpha, tail, type);  %tail is default to both, 2 in excel
%     ttest_A__B(TSdir,4) = p;
%     
%     %Connections
%     [h,p,ci] = ttest2(info{1,1}.outside.connections,info{1,2}.outside.connections,alpha, tail, type);  %tail is default to both, 2 in excel
%     ttest_A__B(TSdir,5) = p;
%     
%     %CPU_Time
%     [h,p,ci] = ttest2(info{1,1}.outside.cpuTime,info{1,2}.outside.cpuTime,alpha, tail, type);  %tail is default to both, 2 in excel
%     ttest_A__B(TSdir,6) = p;
    
    %Classification error
    [h,p,ci] = ttest2(info{1,1}.outside.ClassifE,info{1,2}.outside.ClassifE,alpha, tail, type);  %tail is default to both, 2 in excel
    ttest_A__B(TSdir,2) = p;
    
    % M arch
    [h,p,ci] = ttest2(info{1,1}.outside.March,info{1,2}.outside.March,alpha, tail, type);  %tail is default to both, 2 in excel
    ttest_A__B(TSdir,3) = p;
    
    
    
    clear TSname
    
    
end

close all

rmpath(pathA);
rmpath(pathB);

display ( 'Finisgh to evaluate ttest :) ' )


