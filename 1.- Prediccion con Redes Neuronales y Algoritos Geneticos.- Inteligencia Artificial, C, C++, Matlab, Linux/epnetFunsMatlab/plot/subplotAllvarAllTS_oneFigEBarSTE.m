%% Plot all figures in one with subplot for all TS with error bars using
%% sterror
% 
%
% Created:  9 Dec 2010
% Modified:
% Author:   Carlos Torres and Victor Landassuri



clear
clc

% add path ANN
cd('..'); cd('ANN'); path1 = pwd; addpath(path1);



% Directories to compare

dir0{1,1} = 'classEPNetinitAb';   %blue line -put here the Exp that mut be better
dir0{2,1} = 'classEPNetinitBa';   %Red line
%dir0{1,1} = 'classEPNetinitCb';
dir0{3,1} = 'classEPNetinitEcb';
% dir0{3,1} = 'classEPNetinitEcb';
% dir0{4,1} = 'classEPNetinitFdb';
% dir0{7,1} = 'classEPNetinitCa';
% dir0{8,1} = 'classEPNetinitCb';
% dir0{9,1} = 'classEPNetinitDa';
% dir0{10,1} = 'classEPNetinitDb';

% legendTxt = ['\sigma = 0.5','A','S'];  look for this tag and replace
% automatically all for the new one

% Dir to save
dir2save = '/media/dat/DocEPNetClassExps/initialization/figsABE2figin1';


lines{1,1} = '-';           %default, not used
lines{1,2} = '--';
lines{1,3} = '.-';
lines{1,4} = ':';
lines{1,5} = '-*';
lines{1,6} = '-o';
lines{1,7} = '-b';
lines{1,8} = '--g';
lines{1,9} = '.-k';
lines{1,10} = '.r';

cd('..');
cd('LinuxOrWindows')
%use adecuate paht
slash2use = isLinOrWin();
cd('..');
cd('..');

%load the TS
load TS.mat

cd('..');
path1 = pwd;        %main dir for Exps

gcaFotnSize = 8;           % size for the tick and legend 12
xylabeSize = 8;               % x and y labes size 14


sizeDir = size(dir0,1);


for TSdir = [1 2 3 5]%1:size(TS,2)         %for all TS
    
    %accomodate the directories
    for alldir=1:sizeDir
        dir{1,alldir} = [path1,slash2use,dir0{alldir,1},slash2use,TS{1,TSdir}];
    end
    
    
    for directory=1:sizeDir %for all exp.
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
        info{1,directory} = obtainAvStdSte(allrun,1,1,1);
        
        clear allrun
    end
    
    %Change to the dir to save figs
    if(exist(dir2save, 'dir') ~= 7)
        mkdir(dir2save)
    end
    
    cd(dir2save);
    % select what to plot
    
    
    
    %% Plot
    % Format nx2
    % fitness Accuracy or Fitness classifError
    % Hid Con
    % Inp Delay
    % Mw March
    % Isolated noshared
    
    % Setup size of the subplot
    cols = 2;
    if info{1,1}.flagModule1 == 1
        linesSub = 5;
    else
        linesSub = 3;
    end
    clf
    
     
    %% First Line   
    subplot(linesSub,cols,1)
    
   hold all
            for alldir = 1:sizeDir
                h = errorbar(info{1,alldir}.avNRMSE,info{1,alldir}.steNRMSE,lines{1,alldir},'LineWidth',1);
                %text(150,.1,'\leftarrow Strict value');
            end
                ylabel('Average NRMS','FontSize',xylabeSize)
    xlabel('Generations','FontSize',xylabeSize)
    legend('\sigma = 0.5','A','S');
    set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
    
    
    subplot(linesSub,cols,2)
    if info{1,1}.flagClass == 1
        
        hold all
        for alldir = 1:sizeDir
            h = errorbar(info{1,alldir}.avClassifE, info{1,alldir}.steClassifE,lines{1,alldir},'LineWidth',1);
            %text(150,.1,'\leftarrow Strict value');
        end
        ylabel('Average Classification Error','FontSize',xylabeSize)
        xlabel('Generations','FontSize',xylabeSize)
        %legend('\sigma = 0.5','A','S');
        set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
    else
        hold all
        for alldir = 1:sizeDir
            h = errorbar(info{1,alldir}.avAccuracy,info{1,alldir}.steAccuracy,lines{1,alldir},'LineWidth',1);
        end
        ylabel('Average Accuracy','FontSize',xylabeSize)
        xlabel('Generations','FontSize',xylabeSize)
        %legend('\sigma = 0.5','A','S');
        set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
    end
    
    
    
    
    %% Second line 
    subplot(linesSub,cols,3)
    hold all
    for alldir = 1:sizeDir
         h = errorbar(info{1,alldir}.avHid, info{1,alldir}.steHid,lines{1,alldir},'LineWidth',1);
        %text(150,.1,'\leftarrow Strict value');
    end
    ylabel('Average Hidden Nodes','FontSize',xylabeSize)
    xlabel('Generations','FontSize',xylabeSize)
    %legend('\sigma = 0.5','A','S');
    set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
    
    
    subplot(linesSub,cols,4)
    hold all
    for alldir = 1:sizeDir
       h = errorbar(info{1,alldir}.avCon,info{1,alldir}.steCon,lines{1,alldir},'LineWidth',1);
        %text(150,.1,'\leftarrow Strict value');
    end
    ylabel('Average Connections','FontSize',xylabeSize)
    xlabel('Generations','FontSize',xylabeSize)
    %legend('\sigma = 0.5','A','S');
    set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
    
        
        
    %% 3d line
    
    subplot(linesSub,cols,5)
    hold all
    for alldir = 1:sizeDir
       h = errorbar(info{1,alldir}.avInp,info{1,alldir}.steInp,lines{1,alldir},'LineWidth',1);
        %text(150,.1,'\leftarrow Strict value');
    end
    ylabel('Average Inputs','FontSize',xylabeSize)
    xlabel('Generations','FontSize',xylabeSize)
    %legend('\sigma = 0.5','A','S');
    set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
    
    
    subplot(linesSub,cols,6)
    hold all
    for alldir = 1:sizeDir
         h = errorbar(info{1,alldir}.avDelays,info{1,alldir}.steDelays,lines{1,alldir},'LineWidth',1);
        %text(150,.1,'\leftarrow Strict value');
    end
    ylabel('Average Delays','FontSize',xylabeSize)
    xlabel('Generations','FontSize',xylabeSize)
    %legend('\sigma = 0.5','A','S');
    set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
    
    
    
    if info{1,1}.flagModule1 == 1
        %% 4th line
        subplot(linesSub,cols,7)
        hold all
        for alldir = 1:sizeDir
           h = errorbar(info{1,alldir}.avMweight,info{1,alldir}.steMweight,'LineWidth',1);
            %text(150,.1,'\leftarrow Strict value');
        end
        ylabel('Average M^{(weight)}','FontSize',xylabeSize)
        xlabel('Generations','FontSize',xylabeSize)
        %legend('\sigma = 0.5','A','S');
        set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
        
        subplot(linesSub,cols,8)
        hold all
        for alldir = 1:sizeDir
             h = errorbar(info{1,alldir}.avMarch,info{1,alldir}.steMarch,'LineWidth',1);
            %text(150,.1,'\leftarrow Strict value');
        end
        ylabel('Average M^{(arch.)}','FontSize',xylabeSize)
        xlabel('Generations','FontSize',xylabeSize)
        %legend('\sigma = 0.5','A','S');
        set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
        
        
        
        %% 5th line
        subplot(linesSub,cols,9)
        hold all
        for alldir = 1:sizeDir
             h = errorbar(info{1,alldir}.avNoShared, info{1,alldir}.steNoShared,lines{1,alldir},'LineWidth',1);
            %text(150,.1,'\leftarrow Strict value');
        end
        ylabel('Average Shared nodes','FontSize',xylabeSize)
        xlabel('Generations','FontSize',xylabeSize)
        %legend('\sigma = 0.5','A','S');
        set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
        
        
        subplot(linesSub,cols,10)
        hold all
        for alldir = 1:sizeDir
           h = errorbar(info{1,alldir}.avIsolated, info{1,alldir}.steIsolated, 'LineWidth',1);
            %text(150,.1,'\leftarrow Strict value');
        end
        ylabel('Average Isolated nodes','FontSize',xylabeSize)
        xlabel('Generations','FontSize',xylabeSize)
        %legend('\sigma = 0.5','A','S');
        set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
    end
   
    saveas(h, [TSname,'ALLfigsIn1.fig']);
    
        
    %end
    clear TSname
    %cd('..');  %exit dir TS
    
end


