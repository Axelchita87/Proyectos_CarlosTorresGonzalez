%% Plot two figures in one with subplot
% here you can plot any variable frm two or more experiments in one figue,
% and i nanother oenw ith subplot for other variables, e.g. in fig 1 the
% fitness form exp A, B, C in fig, 2 the modularity of these exps
%
% Created:  2 Dec 2010
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

gcaFotnSize = 12;           % size for the tick and legend
xylabeSize = 14;               % x and y labes size


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
        info{1,directory} = obtainAvStdSte(allrun,1,1,0);
        
        clear allrun
    end
    
    %Change to the dir to save figs
    if(exist(dir2save, 'dir') ~= 7)
        mkdir(dir2save)
    end
    
    cd(dir2save);
    % select what to plot
    
    
    
    %% Plot
    % Chenge here as you want them
    % for this, fig1 have fitness and figure 2 have modularity
    
    % classification error and modularity
    % text(150,.4,'\leftarrow Relaxed value');
    clf
    % Class error
    subplot(1,2,1)
    hold all
    for alldir = 1:sizeDir
        h = plot(info{1,alldir}.avClassifE, lines{1,alldir},'LineWidth',1);
    end
    ylabel('Average Classification Error','FontSize',xylabeSize)
    set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
    xlabel('Generations','FontSize',xylabeSize);
    legend('\sigma = 0.5','A','S'); 
     
    % March
    subplot(1,2,2)
       
    hold all
    for alldir = 1:sizeDir
        h = plot(info{1,alldir}.avMarch,lines{1,alldir},'LineWidth',1);
    end
    ylabel('Average M^{(arch.)}','FontSize',xylabeSize)
    set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
    xlabel('Generations','FontSize',xylabeSize)
   legend('\sigma = 0.5','A','S'); 
    
    saveas(h, [TSname,'ClassErrorMarch.fig']);
    
    
%     
%     for i=[2:12]                         %1:7
%         clf
%         if i==1
%             h = plot(avaccuracy{1,1},'LineWidth',1);
%             hold all
%             h = plot(avaccuracy{1,2},'-r','LineWidth',1);
%             ylabel('Average Accuracy','FontSize',xylabeSize)
%             
%         elseif i==2
%             h = plot(averageNRMS{1,1},'LineWidth',1);
%             %text(150,.4,'\leftarrow Relaxed value');
%             hold all
%             for alldir = 2:sizeDir
%                 h = plot(averageNRMS{1,alldir},lines{1,alldir},'LineWidth',1);
%                 %text(150,.1,'\leftarrow Strict value');
%             end
%             ylabel('Average NRMS','FontSize',xylabeSize)
%             subname = 'AvNRMS';
%             
%             
%         elseif i==3
%             h = plot(averagecon{1,1},'LineWidth',1);
%             %text(150,.4,'\leftarrow Relaxed value');
%             hold all
%             for alldir = 2:sizeDir
%                 h = plot(averagecon{1,alldir},lines{1,alldir},'LineWidth',1);
%                 %text(150,.1,'\leftarrow Strict value');
%             end
%             ylabel('Average Connections','FontSize',xylabeSize)
%             subname = 'AvCon';
%             
%         elseif i==4
%             h = plot(averageinput{1,1},'LineWidth',1);
%             %text(150,.4,'\leftarrow Relaxed value');
%             hold all
%             for alldir = 2:sizeDir
%                 h = plot(averageinput{1,alldir},lines{1,alldir},'LineWidth',1);
%                 %text(150,.1,'\leftarrow Strict value');
%             end
%             ylabel('Average Inputs','FontSize',xylabeSize)
%             subname = 'AvInp';
%             
%         elseif i==5
%             h = plot(averagedelays{1,1},'LineWidth',1);
%             %text(150,.4,'\leftarrow Relaxed value');
%             hold all
%             for alldir = 2:sizeDir
%                 h = plot(averagedelays{1,alldir},lines{1,alldir},'LineWidth',1);
%                 %text(150,.1,'\leftarrow Strict value');
%             end
%             ylabel('Average Delays','FontSize',xylabeSize)
%             subname = 'AvDelays';
%             
%         elseif i==6
%             h = plot(averagehidden{1,1},'LineWidth',1);
%             %text(150,.4,'\leftarrow Relaxed value');
%             hold all
%             for alldir = 2:sizeDir
%                 h = plot(averagehidden{1,alldir},lines{1,alldir},'LineWidth',1);
%                 %text(150,.1,'\leftarrow Strict value');
%             end
%             ylabel('Average Hidden Nodes','FontSize',xylabeSize)
%             subname = 'AvHid';
%             
%         elseif i==7 && allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY
%             h = plot(averageClassifE{1,1},'LineWidth',1);
%             %text(150,.4,'\leftarrow Relaxed value');
%             hold all
%             for alldir = 2:sizeDir
%                 h = plot(averageClassifE{1,alldir},lines{1,alldir},'LineWidth',1);
%                 %text(150,.1,'\leftarrow Strict value');
%             end
%             ylabel('Average Classification Error','FontSize',xylabeSize)
%             subname = 'AvClassifE';
%         elseif i==8
%             h = plot(averagelRate{1,1},'LineWidth',1);
%             %text(150,.4,'\leftarrow Relaxed value');
%             hold all
%             for alldir = 2:sizeDir
%                 h = plot(averagelRate{1,alldir},lines{1,alldir},'LineWidth',1);
%                 %text(150,.1,'\leftarrow Strict value');
%             end
%             ylabel('Average learning rate','FontSize',xylabeSize)
%             subname = 'Avlrate';
%             
%         elseif i==9
%             h = plot(avMweight{1,1},'LineWidth',1);
%             %text(150,.4,'\leftarrow Relaxed value');
%             hold all
%             for alldir = 2:sizeDir
%                 h = plot(avMweight{1,alldir},lines{1,alldir},'LineWidth',1);
%                 %text(150,.1,'\leftarrow Strict value');
%             end
%             ylabel('Average M^{(weight)}','FontSize',xylabeSize)
%             subname = 'AvWeightModularity';
%             
%         elseif i==10
%             h = plot(avMarch{1,1},'LineWidth',1);
%             %text(150,.4,'\leftarrow Relaxed value');
%             hold all
%             for alldir = 2:sizeDir
%                 h = plot(avMarch{1,alldir},lines{1,alldir},'LineWidth',1);
%                 %text(150,.1,'\leftarrow Strict value');
%             end
%             ylabel('Average M^{(arch.)}','FontSize',xylabeSize)
%             subname = 'AvArchModularity';
%             
%             
%             
%         elseif i==11
%             h = plot(avNoShared{1,1},'LineWidth',1);
%             %text(150,.4,'\leftarrow Relaxed value');
%             hold all
%             for alldir = 2:sizeDir
%                 h = plot(avNoShared{1,alldir},lines{1,alldir},'LineWidth',1);
%                 %text(150,.1,'\leftarrow Strict value');
%             end
%             ylabel('Average Shared nodes','FontSize',xylabeSize)
%             subname = 'AvSharedNodes';
%             
%             
%             
%         elseif i==12
%             h = plot(avIsolated{1,1},'LineWidth',1);
%             %text(150,.4,'\leftarrow Relaxed value');
%             hold all
%             for alldir = 2:sizeDir
%                 h = plot(avIsolated{1,alldir},lines{1,alldir},'LineWidth',1);
%                 %text(150,.1,'\leftarrow Strict value');
%             end
%             ylabel('Average Isolated nodes','FontSize',xylabeSize)
%             subname = 'AvIsolatedNodes';
%             
%             
%             
%             
%         end
        
        
        % exp ABCD
        %         legend('S', '6S','Ecb','Fdb');
        
        % exp ABCD
        %         legend('\sigma = 0.5','A','S', '6S','Ecb','Fdb');
        
       % legend('\sigma = 0.5','A','S');  % A B E(S)
        
        %         % exp ABCD
        %         legend('\sigma = 0.1','\sigma = 0.5', '\sigma = 1', ...
        %             'A','G', 'L', 'M','S','6M', '6S');
        
        
        %         % exp ABC
        %         legend('\sigma = 0.1','\sigma = 0.5', '\sigma = 1', ...
        %             'A','G', 'L', 'M','S');
        %
        %legend('6M','6S');  % Exp 6M and 6S
        %legend('M','S');  % Exp 4M and 4S
        %legend('A','G', 'L');  % Exp 3
        %legend('\sigma = 0.1','\sigma = 0.5', '\sigma = 1'); % Exp simple
        %connections schme
        %legend('Tournament','Random','Co-evo','EPNet','Fix&evolve T.','Hierarchical')
        
%         set(gca, 'fontsize',gcaFotnSize);
%         
%         xlabel('Generations','FontSize',xylabeSize)
%         string2title = ['\it{',TSname,'}'];
%         title(string2title,'FontSize',16');
%         
%         foo = 'to make a pause put s break point here';
%         
%         saveas(h, [TSname,subname,'.fig']);
        
    %end
    clear TSname
    %cd('..');  %exit dir TS
    
end


