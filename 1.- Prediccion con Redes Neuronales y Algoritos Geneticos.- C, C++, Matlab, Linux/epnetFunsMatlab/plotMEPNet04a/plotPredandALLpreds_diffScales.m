% Script to polt the result from testNetwork

%average over all generations
% run two times for log and normal results, change variables logFigs XXXXXX

clear
clc

%Directory to work
dir{1,1} = 'MEPNet04a';  % every thing is save in this direcory
logFigs = 0;               % for log figs 1 = log ... 0 = no logaritmic
    
dir1{1,1} = 'MEPNet04a';  
dir1{1,2} = 'MEPNet04b';
dir1{1,3} = 'MEPNet04c';
dir1{1,4} = 'MEPNet04d';
dir1{1,5} = 'MEPNet04e';
dir1{1,6} = 'MEPNet04f';

lines1{1,1} = '-';
lines1{1,2} = '--';
lines1{1,3} = '-.';
lines1{1,4} = '-o';
lines1{1,5} = '--+';
lines1{1,6} = '-.^';


cd('..');           %exit plot
cd('LinuxOrWindows')
%use adecuate paht
SLASH = isLinOrWin();
cd('..');
cd('..');
cd('..');
path1 = pwd;        %main dir for Exps
cd(dir{1,1});

%load the TS
load TS.mat

% Dir to save
if logFigs == 1
    dir2saveComb = 'figAllLOG';
else
    dir2saveComb = 'figAll';
end
% dir2save{1,1} = 'figRes1';
% dir2save{1,2} = 'figRes2';
% dir2save{1,3} = 'figRes3';

% var for the different predictions lapses
filePreds = 'predictScale';
filePredsOneStep = 'oneStepScale';
%fileMSE = 'mse';

%other variables
NRMSE = [];
MEAN = [];
STD = [];

NRMSE15 = [];
MEAN15 = [];
STD15 = [];

NRMSE30 = [];
MEAN30 = [];
STD30 = [];

NRMSE60 = [];
MEAN60 = [];
STD60 = [];

NRMSE120 = [];
MEAN120 = [];
STD120 = [];

NRMSE240 = [];
MEAN240 = [];
STD240 = [];

NRMSE480 = [];
MEAN480 = [];
STD480 = [];

% For oneStep prediction

NRMSEoneS15 = [];
MEANoneS15 = [];
STDoneS15 = [];

NRMSEoneS30 = [];
MEANoneS30 = [];
STDoneS30 = [];

NRMSEoneS60 = [];
MEANoneS60 = [];
STDoneS60 = [];

NRMSEoneS120 = [];
MEANoneS120 = [];
STDoneS120 = [];

NRMSEoneS240 = [];
MEANoneS240 = [];
STDoneS240 = [];

NRMSEoneS480 = [];
MEANoneS480 = [];
STDoneS480 = [];


%variables for the mse


% MSE = [];
% MEANmse = [];
% STDmse = [];



for TSdir =1:size(TS,2)         %for all TS
    for TSres = 1:size(dir1,2)        
        
        %obtain name of the TS
        if TSres== 1
            fid = fopen([path1,SLASH,dir{1,1},SLASH,TS{1,TSdir},SLASH,'txtFiles/TSname.txt'], 'r');
            TSname = fgetl(fid);
            if (fclose(fid) ~= 0)
                'error closing file'
            end
        end
        %clear 
        predAllscales = [];
       
        
        cd([path1,SLASH,dir1{1,TSres},SLASH,TS{1,TSdir},SLASH,'res']);
        
        %% Load
        % lines are scales, columns are the NRMSE of each network
        % for the fisrt test set
        load predAllscales.txt
               
        NRMSE{1,TSres} = predAllscales';
        MEAN{1,TSres} = mean(NRMSE{1,TSres});
        STD{1,TSres} = std(NRMSE{1,TSres});
        
        %load the predict files (15, 30, 60, ...)
        % The Lines are the prediction lapses and the columns are the
        % neworks
        for scale = 1:7
            load ([filePreds,num2str(scale)]); %,'.txt']);
            NRMSE15{1,TSres}(:,scale) = eval([filePreds,num2str(scale),'(1,:)']);
            NRMSE30{1,TSres}(:,scale) = eval([filePreds,num2str(scale),'(2,:)']);
            NRMSE60{1,TSres}(:,scale) = eval([filePreds,num2str(scale),'(3,:)']);
            NRMSE120{1,TSres}(:,scale) = eval([filePreds,num2str(scale),'(4,:)']);
            NRMSE240{1,TSres}(:,scale) = eval([filePreds,num2str(scale),'(5,:)']);
            NRMSE480{1,TSres}(:,scale) = eval([filePreds,num2str(scale),'(6,:)']);
            
            % for oneStep
            load ([filePredsOneStep,num2str(scale)]); %,'.txt']);
            NRMSEoneS15{1,TSres}(:,scale) = eval([filePredsOneStep,num2str(scale),'(1,:)']);
            NRMSEoneS30{1,TSres}(:,scale) = eval([filePredsOneStep,num2str(scale),'(2,:)']);
            NRMSEoneS60{1,TSres}(:,scale) = eval([filePredsOneStep,num2str(scale),'(3,:)']);
            NRMSEoneS120{1,TSres}(:,scale) = eval([filePredsOneStep,num2str(scale),'(4,:)']);
            NRMSEoneS240{1,TSres}(:,scale) = eval([filePredsOneStep,num2str(scale),'(5,:)']);
            NRMSEoneS480{1,TSres}(:,scale) = eval([filePredsOneStep,num2str(scale),'(6,:)']);
            
            
        end
        
        MEAN15{1,TSres} = mean(NRMSE15{1,TSres});
        MEAN30{1,TSres} = mean(NRMSE30{1,TSres});
        MEAN60{1,TSres} = mean(NRMSE60{1,TSres});
        MEAN120{1,TSres} = mean(NRMSE120{1,TSres});
        MEAN240{1,TSres} = mean(NRMSE240{1,TSres});
        MEAN480{1,TSres} = mean(NRMSE480{1,TSres});
        
        STD15{1,TSres} = std(NRMSE15{1,TSres});
        STD30{1,TSres} = std(NRMSE30{1,TSres});
        STD60{1,TSres} = std(NRMSE60{1,TSres});
        STD120{1,TSres} = std(NRMSE120{1,TSres});
        STD240{1,TSres} = std(NRMSE240{1,TSres});
        STD480{1,TSres} = std(NRMSE480{1,TSres});
        
        
        % For the oneStep
        MEANoneS15{1,TSres} = mean(NRMSEoneS15{1,TSres});
        MEANoneS30{1,TSres} = mean(NRMSEoneS30{1,TSres});
        MEANoneS60{1,TSres} = mean(NRMSEoneS60{1,TSres});
        MEANoneS120{1,TSres} = mean(NRMSEoneS120{1,TSres});
        MEANoneS240{1,TSres} = mean(NRMSEoneS240{1,TSres});
        MEANoneS480{1,TSres} = mean(NRMSEoneS480{1,TSres});
        
        STDoneS15{1,TSres} = std(NRMSEoneS15{1,TSres});
        STDoneS30{1,TSres} = std(NRMSEoneS30{1,TSres});
        STDoneS60{1,TSres} = std(NRMSEoneS60{1,TSres});
        STDoneS120{1,TSres} = std(NRMSEoneS120{1,TSres});
        STDoneS240{1,TSres} = std(NRMSEoneS240{1,TSres});
        STDoneS480{1,TSres} = std(NRMSEoneS480{1,TSres});
        
        
        % Load the mse for each networks after training
%         MSE{1,TSres} = load('mse.txt');
%         MSEmean{1,TSres} = mean(MSE{1,TSres});
%         MSEstd{1,TSres} = std(MSE{1,TSres});
    end
   
    %% Plot the error bars, the 5 lines are plot in the same figure with
    % error bars (each dir 'res,1,2,3,4,5')
    
    %Change to the dir to save figs
    
    if(exist([path1,SLASH,dir{1,1},SLASH,TS{1,TSdir},SLASH,dir2saveComb], 'dir') ~= 7)
        mkdir([path1,SLASH,dir{1,1},SLASH,TS{1,TSdir},SLASH,dir2saveComb])
    end
    cd([path1,SLASH,dir{1,1},SLASH,TS{1,TSdir},SLASH,dir2saveComb])
    
    % Plot the figure for the fisrt final test set
    clf
    if logFigs == 1
        h = axes('YScale','log')
        box('on');
        hold all
    end
    for TSres = 1:size(dir1,2)
        h = errorbar(MEAN{1,TSres},STD{1,TSres},lines1{1,TSres},'LineWidth',1);
         hold all
    end
    ylabel('Average NRMS','FontSize',12)
    xlabel('Sclaes','FontSize',12);
    set(gca,'XTickLabel',{'','[-0.1,0.1]','[-0.2,0.2]','[-0.3,0.3]','[-0.4,0.4]','[-0.5,0.5]' ...
        ,'[-0.6,0.6]','[-0.7,0.7]'})
    
    string2title = ['\it{',TSname,' First test set 30 steps ahead','}'];
    title(string2title,'FontSize',16');
    
    %legend('Scales: 0.7 and 0.5','Scales: 0.7, 0.5 and 0.3', 'Scales: 0.7 and 0.1', 'Scales: 0.7, 0.5, 0.3 and 0.1', 'Scales: 0.7, 0.5, 0.4, 0.3, 0.2 and 0.1');
    legend('Scales: 7 and 5','Scales: 7, 5 and 3', 'Scales: 7 and 1', 'Scales: 7, 5, 3 and 1', ...
        'Scales: 7, 5, 4, 3, 2 and 1', 'Scales: all');
    subname = 'AvNRMS';
    
    %section to save the figure
    saveas(h, ['ErrBarPerScale',subname,'.fig']);
    
    
    %% Plot the predictions at 15, 30, 60, ...
    
    %% 15 steps ahead
    
    clf
     if logFigs == 1
        h = axes('YScale','log')
        box('on');
        hold all
    end
    
    for TSres = 1:size(dir1,2)
        h = errorbar(MEAN15{1,TSres},STD15{1,TSres},lines1{1,TSres},'LineWidth',1);
        hold all
    end
    ylabel('Average NRMS','FontSize',12)
    xlabel('Sclaes','FontSize',12);
    set(gca,'XTickLabel',{'','[-0.1,0.1]','[-0.2,0.2]','[-0.3,0.3]','[-0.4,0.4]','[-0.5,0.5]' ...
        ,'[-0.6,0.6]','[-0.7,0.7]'})
    
    string2title = ['\it{',TSname,' Second test set 15 steps ahead','}'];
    title(string2title,'FontSize',16');
    
    
     %legend('Scales: 0.7 and 0.5','Scales: 0.7, 0.5 and 0.3', 'Scales:
    %0.7 and 0.1', 'Scales: 0.7, 0.5, 0.3 and 0.1', 'Scales: 0.7, 0.5, 0.4, 0.3, 0.2 and 0.1');
   legend('Scales: 7 and 5','Scales: 7, 5 and 3', 'Scales: 7 and 1', 'Scales: 7, 5, 3 and 1', ...
        'Scales: 7, 5, 4, 3, 2 and 1', 'Scales: all');
    subname = 'AvNRMS';
    
    %section to save the figure
    saveas(h, ['ErrBarPerScale15',subname,'.fig']);
    
    
    %% %%%% One step hdead 15
    
    clf
     if logFigs == 1
        h = axes('YScale','log')
        box('on');
        hold all
    end
    
    for TSres = 1:size(dir1,2)
        h = errorbar(MEANoneS15{1,TSres},STDoneS15{1,TSres},lines1{1,TSres},'LineWidth',1);
        hold all
    end
    ylabel('Average NRMS','FontSize',12)
    xlabel('Sclaes','FontSize',12);
    set(gca,'XTickLabel',{'','[-0.1,0.1]','[-0.2,0.2]','[-0.3,0.3]','[-0.4,0.4]','[-0.5,0.5]' ...
        ,'[-0.6,0.6]','[-0.7,0.7]'})
    
    string2title = ['\it{',TSname,' Second test set, one step predcition','}'];
    title(string2title,'FontSize',16');
    
    
     %legend('Scales: 0.7 and 0.5','Scales: 0.7, 0.5 and 0.3', 'Scales:
    %0.7 and 0.1', 'Scales: 0.7, 0.5, 0.3 and 0.1', 'Scales: 0.7, 0.5, 0.4, 0.3, 0.2 and 0.1');
    legend('Scales: 7 and 5','Scales: 7, 5 and 3', 'Scales: 7 and 1', 'Scales: 7, 5, 3 and 1', ...
        'Scales: 7, 5, 4, 3, 2 and 1', 'Scales: all');
    subname = 'AvNRMS';
    
    %section to save the figure
    saveas(h, ['OneStepErrBarPerScale15',subname,'.fig']);
    
    
    
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    %%%
    %% 30 steps ahead
    
    clf
     if logFigs == 1
        h = axes('YScale','log')
        box('on');
        hold all
    end
   
    for TSres = 1:size(dir1,2)
        h = errorbar(MEAN30{1,TSres},STD30{1,TSres},lines1{1,TSres},'LineWidth',1);
         hold all
    end
    ylabel('Average NRMS','FontSize',12)
    xlabel('Sclaes','FontSize',12);
    set(gca,'XTickLabel',{'','[-0.1,0.1]','[-0.2,0.2]','[-0.3,0.3]','[-0.4,0.4]','[-0.5,0.5]' ...
        ,'[-0.6,0.6]','[-0.7,0.7]'})
    
    string2title = ['\it{',TSname,' Second test set 30 steps ahead','}'];
    title(string2title,'FontSize',16');
    
    
     %legend('Scales: 0.7 and 0.5','Scales: 0.7, 0.5 and 0.3', 'Scales:
    %0.7 and 0.1', 'Scales: 0.7, 0.5, 0.3 and 0.1', 'Scales: 0.7, 0.5, 0.4, 0.3, 0.2 and 0.1');
    legend('Scales: 7 and 5','Scales: 7, 5 and 3', 'Scales: 7 and 1', 'Scales: 7, 5, 3 and 1', ...
        'Scales: 7, 5, 4, 3, 2 and 1', 'Scales: all');
    subname = 'AvNRMS';
    
    %section to save the figure
    saveas(h, ['ErrBarPerScale30',subname,'.fig']);
    
    
    %% 30 steps ahead One step prediction
    
    clf
     if logFigs == 1
        h = axes('YScale','log')
        box('on');
        hold all
    end
    for TSres = 1:size(dir1,2)
        h = errorbar(MEANoneS30{1,TSres},STDoneS30{1,TSres},lines1{1,TSres},'LineWidth',1);
         hold all
    end
    ylabel('Average NRMS','FontSize',12)
    xlabel('Sclaes','FontSize',12);
    set(gca,'XTickLabel',{'','[-0.1,0.1]','[-0.2,0.2]','[-0.3,0.3]','[-0.4,0.4]','[-0.5,0.5]' ...
        ,'[-0.6,0.6]','[-0.7,0.7]'})
    
    string2title = ['\it{',TSname,' Second test set 30, one step prediction','}'];
    title(string2title,'FontSize',16');
    
    
     %legend('Scales: 0.7 and 0.5','Scales: 0.7, 0.5 and 0.3', 'Scales:
    %0.7 and 0.1', 'Scales: 0.7, 0.5, 0.3 and 0.1', 'Scales: 0.7, 0.5, 0.4, 0.3, 0.2 and 0.1');
   legend('Scales: 7 and 5','Scales: 7, 5 and 3', 'Scales: 7 and 1', 'Scales: 7, 5, 3 and 1', ...
        'Scales: 7, 5, 4, 3, 2 and 1', 'Scales: all');
    subname = 'AvNRMS';
    
    %section to save the figure
    saveas(h, ['oneStepErrBarPerScale30',subname,'.fig']);
    
    
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    %%%
    %60 steps ahead
    
    clf
    if logFigs == 1
        h = axes('YScale','log')
        box('on');
        hold all
    end
   
    for TSres = 1:size(dir1,2)
        h = errorbar(MEAN60{1,TSres},STD60{1,TSres},lines1{1,TSres},'LineWidth',1);
         hold all
    end
    ylabel('Average NRMS','FontSize',12)
    xlabel('Sclaes','FontSize',12);
    set(gca,'XTickLabel',{'','[-0.1,0.1]','[-0.2,0.2]','[-0.3,0.3]','[-0.4,0.4]','[-0.5,0.5]' ...
        ,'[-0.6,0.6]','[-0.7,0.7]'})
    
    string2title = ['\it{',TSname,' Second test set 60 steps ahead','}'];
    title(string2title,'FontSize',16');
    
    
      %legend('Scales: 0.7 and 0.5','Scales: 0.7, 0.5 and 0.3', 'Scales:
    %0.7 and 0.1', 'Scales: 0.7, 0.5, 0.3 and 0.1', 'Scales: 0.7, 0.5, 0.4, 0.3, 0.2 and 0.1');
   legend('Scales: 7 and 5','Scales: 7, 5 and 3', 'Scales: 7 and 1', 'Scales: 7, 5, 3 and 1', ...
        'Scales: 7, 5, 4, 3, 2 and 1', 'Scales: all');
    subname = 'AvNRMS';
    
    %section to save the figure
    saveas(h, ['ErrBarPerScale60',subname,'.fig']);
    
    
    
    %% 60 steps ahead One step predicton
    
    clf
     if logFigs == 1
        h = axes('YScale','log')
        box('on');
        hold all
    end
   
    for TSres = 1:size(dir1,2)
        h = errorbar(MEANoneS60{1,TSres},STDoneS60{1,TSres},lines1{1,TSres},'LineWidth',1);
         hold all
    end
    ylabel('Average NRMS','FontSize',12)
    xlabel('Sclaes','FontSize',12);
    set(gca,'XTickLabel',{'','[-0.1,0.1]','[-0.2,0.2]','[-0.3,0.3]','[-0.4,0.4]','[-0.5,0.5]' ...
        ,'[-0.6,0.6]','[-0.7,0.7]'})
    
    string2title = ['\it{',TSname,' Second test set, one step prediction','}'];
    title(string2title,'FontSize',16');
    
    
     %legend('Scales: 0.7 and 0.5','Scales: 0.7, 0.5 and 0.3', 'Scales:
    %0.7 and 0.1', 'Scales: 0.7, 0.5, 0.3 and 0.1', 'Scales: 0.7, 0.5, 0.4, 0.3, 0.2 and 0.1');
   legend('Scales: 7 and 5','Scales: 7, 5 and 3', 'Scales: 7 and 1', 'Scales: 7, 5, 3 and 1', ...
        'Scales: 7, 5, 4, 3, 2 and 1', 'Scales: all');
    subname = 'AvNRMS';
    
    %section to save the figure
    saveas(h, ['oneStepErrBarPerScale60',subname,'.fig']);
    
    
    
    
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    %%%
    % 120 steps ahead
    
    clf
     if logFigs == 1
        h = axes('YScale','log')
        box('on');
        hold all
    end
    for TSres = 1:size(dir1,2)
        h = errorbar(MEAN120{1,TSres},STD120{1,TSres},lines1{1,TSres},'LineWidth',1);
        hold all
    end
    ylabel('Average NRMS','FontSize',12)
    xlabel('Sclaes','FontSize',12);
    set(gca,'XTickLabel',{'','[-0.1,0.1]','[-0.2,0.2]','[-0.3,0.3]','[-0.4,0.4]','[-0.5,0.5]' ...
        ,'[-0.6,0.6]','[-0.7,0.7]'})
    
    string2title = ['\it{',TSname,' Second test set 120 steps ahead','}'];
    title(string2title,'FontSize',16');
    
    
    %legend('Scales: 0.7 and 0.5','Scales: 0.7, 0.5 and 0.3', 'Scales:
    %0.7 and 0.1', 'Scales: 0.7, 0.5, 0.3 and 0.1', 'Scales: 0.7, 0.5, 0.4, 0.3, 0.2 and 0.1');
   legend('Scales: 7 and 5','Scales: 7, 5 and 3', 'Scales: 7 and 1', 'Scales: 7, 5, 3 and 1', ...
        'Scales: 7, 5, 4, 3, 2 and 1', 'Scales: all');
    subname = 'AvNRMS';
    
    %section to save the figure
    saveas(h, ['ErrBarPerScale120',subname,'.fig']);
    
    
     %% 120 steps ahead ONE STEP PREDICTION
    
    clf
    if logFigs == 1
        h = axes('YScale','log')
        box('on');
        hold all
    end
    
    for TSres = 1:size(dir1,2)
        h = errorbar(MEANoneS120{1,TSres},STDoneS120{1,TSres},lines1{1,TSres},'LineWidth',1);
        hold all
    end
    ylabel('Average NRMS','FontSize',12)
    xlabel('Sclaes','FontSize',12);
    set(gca,'XTickLabel',{'','[-0.1,0.1]','[-0.2,0.2]','[-0.3,0.3]','[-0.4,0.4]','[-0.5,0.5]' ...
        ,'[-0.6,0.6]','[-0.7,0.7]'})
    
    string2title = ['\it{',TSname,' Second test set, one step prediciton','}'];
    title(string2title,'FontSize',16');
    
    
     %legend('Scales: 0.7 and 0.5','Scales: 0.7, 0.5 and 0.3', 'Scales:
    %0.7 and 0.1', 'Scales: 0.7, 0.5, 0.3 and 0.1', 'Scales: 0.7, 0.5, 0.4, 0.3, 0.2 and 0.1');
   legend('Scales: 7 and 5','Scales: 7, 5 and 3', 'Scales: 7 and 1', 'Scales: 7, 5, 3 and 1', ...
        'Scales: 7, 5, 4, 3, 2 and 1', 'Scales: all');
    subname = 'AvNRMS';
    
    %section to save the figure
    saveas(h, ['oneStepErrBarPerScale120',subname,'.fig']);
    
    
    
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    %%%
    % 240 steps ahead
    
    clf
    if logFigs == 1
        h = axes('YScale','log')
        box('on');
        hold all
    end
   
    for TSres = 1:size(dir1,2)
        h = errorbar(MEAN240{1,TSres},STD240{1,TSres},lines1{1,TSres},'LineWidth',1);
         hold all
    end
    ylabel('Average NRMS','FontSize',12)
    xlabel('Sclaes','FontSize',12);
    set(gca,'XTickLabel',{'','[-0.1,0.1]','[-0.2,0.2]','[-0.3,0.3]','[-0.4,0.4]','[-0.5,0.5]' ...
        ,'[-0.6,0.6]','[-0.7,0.7]'})
    
    string2title = ['\it{',TSname,' Second test set 240 steps ahead','}'];
    title(string2title,'FontSize',16');
    
    
      %legend('Scales: 0.7 and 0.5','Scales: 0.7, 0.5 and 0.3', 'Scales:
    %0.7 and 0.1', 'Scales: 0.7, 0.5, 0.3 and 0.1', 'Scales: 0.7, 0.5, 0.4, 0.3, 0.2 and 0.1');
    legend('Scales: 7 and 5','Scales: 7, 5 and 3', 'Scales: 7 and 1', 'Scales: 7, 5, 3 and 1', ...
        'Scales: 7, 5, 4, 3, 2 and 1', 'Scales: all');
    subname = 'AvNRMS';
    
    %section to save the figure
    saveas(h, ['ErrBarPerScale240',subname,'.fig']);
    
    
    %% 240 steps ahead ONE STEP
    
    clf
     if logFigs == 1
        h = axes('YScale','log')
        box('on');
        hold all
    end
   
    for TSres = 1:size(dir1,2)
        h = errorbar(MEANoneS240{1,TSres},STDoneS240{1,TSres},lines1{1,TSres},'LineWidth',1);
         hold all
    end
    ylabel('Average NRMS','FontSize',12)
    xlabel('Sclaes','FontSize',12);
    set(gca,'XTickLabel',{'','[-0.1,0.1]','[-0.2,0.2]','[-0.3,0.3]','[-0.4,0.4]','[-0.5,0.5]' ...
        ,'[-0.6,0.6]','[-0.7,0.7]'})
    
    string2title = ['\it{',TSname,' Second test set, one step prediction','}'];
    title(string2title,'FontSize',16');
    
    
       %legend('Scales: 0.7 and 0.5','Scales: 0.7, 0.5 and 0.3', 'Scales:
    %0.7 and 0.1', 'Scales: 0.7, 0.5, 0.3 and 0.1', 'Scales: 0.7, 0.5, 0.4, 0.3, 0.2 and 0.1');
    legend('Scales: 7 and 5','Scales: 7, 5 and 3', 'Scales: 7 and 1', 'Scales: 7, 5, 3 and 1', ...
        'Scales: 7, 5, 4, 3, 2 and 1', 'Scales: all');
    subname = 'AvNRMS';
    
    %section to save the figure
    saveas(h, ['oneStepErrBarPerScale240',subname,'.fig']);
    
    
    
    
    
    
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    %%%
    
    
    clf
     if logFigs == 1
        h = axes('YScale','log')
        box('on');
        hold all
    end
    for TSres = 1:size(dir1,2)
        h = errorbar(MEAN480{1,TSres},STD480{1,TSres},lines1{1,TSres},'LineWidth',1);
         hold all
    end
    ylabel('Average NRMS','FontSize',12)
    xlabel('Sclaes','FontSize',12);
    set(gca,'XTickLabel',{'','[-0.1,0.1]','[-0.2,0.2]','[-0.3,0.3]','[-0.4,0.4]','[-0.5,0.5]' ...
        ,'[-0.6,0.6]','[-0.7,0.7]'})
    
    string2title = ['\it{',TSname,' Second test set 480 steps ahead','}'];
    title(string2title,'FontSize',16');
    
    
      %legend('Scales: 0.7 and 0.5','Scales: 0.7, 0.5 and 0.3', 'Scales:
    %0.7 and 0.1', 'Scales: 0.7, 0.5, 0.3 and 0.1', 'Scales: 0.7, 0.5, 0.4, 0.3, 0.2 and 0.1');
    legend('Scales: 7 and 5','Scales: 7, 5 and 3', 'Scales: 7 and 1', 'Scales: 7, 5, 3 and 1', ...
        'Scales: 7, 5, 4, 3, 2 and 1', 'Scales: all');
    subname = 'AvNRMS';
    
    %section to save the figure
    saveas(h, ['ErrBarPerScale480',subname,'.fig']);
    
   
    %% 480 steps ahead ONE STEP
    
    clf
    if logFigs == 1
        h = axes('YScale','log')
        box('on');
        hold all
    end
    for TSres = 1:size(dir1,2)
        h = errorbar(MEANoneS480{1,TSres},STDoneS480{1,TSres},lines1{1,TSres},'LineWidth',1);
         hold all
    end
    ylabel('Average NRMS','FontSize',12)
    xlabel('Sclaes','FontSize',12);
    set(gca,'XTickLabel',{'','[-0.1,0.1]','[-0.2,0.2]','[-0.3,0.3]','[-0.4,0.4]','[-0.5,0.5]' ...
        ,'[-0.6,0.6]','[-0.7,0.7]'})
    
    string2title = ['\it{',TSname,' Second test set, one step prediciton','}'];
    title(string2title,'FontSize',16');
    
    
     %legend('Scales: 0.7 and 0.5','Scales: 0.7, 0.5 and 0.3', 'Scales:
    %0.7 and 0.1', 'Scales: 0.7, 0.5, 0.3 and 0.1', 'Scales: 0.7, 0.5, 0.4, 0.3, 0.2 and 0.1');
   legend('Scales: 7 and 5','Scales: 7, 5 and 3', 'Scales: 7 and 1', 'Scales: 7, 5, 3 and 1', ...
        'Scales: 7, 5, 4, 3, 2 and 1', 'Scales: all');
    subname = 'AvNRMS';
    
    %section to save the figure
    saveas(h, ['oneStepErrBarPerScale480',subname,'.fig']);
    
    
    
    %% Plot the MSE
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %%%%%%%%%%%%%%
    %%%%
    
    %plot all MSE fig in one figure
%     clf
%     h = axes('YScale','log');
%     box('on');
%     hold all
%     for TSres = size(dir1,2):-1:1
%         h = plot(MSEmean{1,TSres},'LineWidth',1);
%     end
%     ylabel('Average MSE','FontSize',12)
%     xlabel('Epochs','FontSize',12);
%     %set(gca,'XTickLabel',{'','[-0.1,0.1]','[-0.2,0.2]','[-0.3,0.3]','[-0.4,0.4]','[-0.5,0.5]' ...
%     %    ,'[-0.6,0.6]','[-0.7,0.7]'})
%     
%     string2title = ['\it{',TSname,' MSE','}'];
%     title(string2title,'FontSize',16');
%     
%     
%     legend('Training 0.7, 0.5, 0.4, 0.3, 0.2 and 0.1',...
%         'Training 0.7, 0.5, 0.3 and 0.1', ...
%         'Training 0.7 and 0.1',...
%         'Training 0.7, 0.5 and 0.3',...
%         'Training 0.7 and 0.5');
%     
%     subname = '2lines';
%     
%     %section to save the figure
%     saveas(h, ['AvMSEALLres.fig']);
%     
%     %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%     %plot all MSE fig in one figure ERROR BARS
%     clf
%     %h = axes('YScale','log');
%     box('on');
%     hold all
%     for TSres = size(dir1,2):-1:1
%         h = errorbar(MSEmean{1,TSres},MSEstd{1,TSres},'LineWidth',1);
%     end
%     ylabel('Average MSE','FontSize',12)
%     xlabel('Epochs','FontSize',12);
%     %set(gca,'XTickLabel',{'','[-0.1,0.1]','[-0.2,0.2]','[-0.3,0.3]','[-0.4,0.4]','[-0.5,0.5]' ...
%     %    ,'[-0.6,0.6]','[-0.7,0.7]'})
%     
%     string2title = ['\it{',TSname,' MSE','}'];
%     title(string2title,'FontSize',16');
%     
%     
%     legend('Training 0.7, 0.5, 0.4, 0.3, 0.2 and 0.1',...
%         'Training 0.7, 0.5, 0.3 and 0.1', ...
%         'Training 0.7 and 0.1',...
%         'Training 0.7, 0.5 and 0.3',...
%         'Training 0.7 and 0.5');
%     
%        
%     %section to save the figure
%     saveas(h, ['AvMSEALLresEbar.fig']);
%         
%         %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%  %% Plot each MSE independently
%       
%     for TSres =1:size(dir1,2)
%         clf
%         h = axes('YScale','log');
%         box('on');
%         hold all
%         h = plot(MSEmean{1,TSres},'LineWidth',1);
%        
%         % for the error bars
%         %h = errorbar(MSEmean{1,TSres},MSEstd{1,TSres},'LineWidth',1);
%         
%         ylabel('Average MSE','FontSize',12)
%         xlabel('Epochs','FontSize',12);
%         %set(gca,'XTickLabel',{'','[-0.1,0.1]','[-0.2,0.2]','[-0.3,0.3]','[-0.4,0.4]','[-0.5,0.5]' ...
%         %    ,'[-0.6,0.6]','[-0.7,0.7]'})
%         
%         string2title = ['\it{',TSname,' MSE','}'];
%         title(string2title,'FontSize',16');
%         
%         
%         %legend('Training','Weights restart & training')
%               
%         %section to save the figure
%         saveas(h, ['AvMSE','SetUsed',num2str(TSres),'.fig']);
%         
%     end
%     
%     %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%  %% Plot each MSE independently WITH ERROR BARS   
%     
%   for TSres =1:size(dir1,2)
%         clf
%         %h = axes('YScale','log');
%         %box('on');
%         %hold all
%         h = errorbar(MSEmean{1,TSres},MSEstd{1,TSres},'LineWidth',1);
%        
%         % for the error bars
%         %h = errorbar(MSEmean{1,TSres},MSEstd{1,TSres},'LineWidth',1);
%         
%         ylabel('Average MSE','FontSize',12)
%         xlabel('Epochs','FontSize',12);
%         %set(gca,'XTickLabel',{'','[-0.1,0.1]','[-0.2,0.2]','[-0.3,0.3]','[-0.4,0.4]','[-0.5,0.5]' ...
%         %    ,'[-0.6,0.6]','[-0.7,0.7]'})
%         
%         string2title = ['\it{',TSname,' MSE','}'];
%         title(string2title,'FontSize',16');
%         
%         
%         %legend('Training','Weights restart & training')
%               
%         %section to save the figure
%         saveas(h, ['AvMSEeBar','SetUsed',num2str(TSres),'.fig']);
%         
%     end
    
    
    
     
    
    
end  % end TS