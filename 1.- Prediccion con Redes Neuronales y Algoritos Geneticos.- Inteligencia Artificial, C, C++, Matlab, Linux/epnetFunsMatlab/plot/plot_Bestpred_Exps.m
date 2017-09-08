%script to plot the Best predictions from two diff experimnts or more for
%all TS

% run this file from the main exp that contain this file

clear
clc

%Directories to compare 
dir0{1,1} = 'TSEPnet66v1';   %blue line -put here the Exp that mut be better
dir0{2,1} = 'TSEPnet66a';   %Red line
dir0{3,1} = 'TSEPnet66b';
dir0{4,1} = 'TSEPnet66c';
dir0{5,1} = 'TSEPnet66d';
dir0{6,1} = 'TSEPnet66f';

% Select what prediciton lapse do you want
%stepsAhead = 1;         % 1 = 15, 2 =30, 3 = 60, 4=120, 5=240, 6 =480

% Dir to save
dir2save = '/data/private/vlm/DoctoradoResultados/TSEPnet66f/figuresDiffExpPreds66';


lines{1,1} = 'r';
lines{1,2} = 'g';
lines{1,3} = 'c';
lines{1,4} = 'm';
lines{1,5} = 'k';
lines{1,6} = 'b';

%gruesoL = 'LineWidth';

%Use adecuate slash in Linux or Windows
cd('..');  cd('LinuxOrWindows');
%use adecuate paht
slash2use = isLinOrWin();
cd('..');  cd('..');
cd('..');
path1 = pwd;        %main dir for Exps
cd (dir0{1,1});
load TS.mat

sizeTS = size(TS,2);

sizeDir = size(dir0,1);
for stepsAhead = 2:6
    for TSdir = 1:sizeTS         %for all TS
        
        %accomodate the directories
        for alldir=1:sizeDir
            dir{1,alldir} = [path1,slash2use,dir0{alldir,1},slash2use,TS{1,TSdir}];
        end
        
        
        for directory = 1:sizeDir  %for all exp.
            cd(dir{1,directory});
            
            %obtain name of the TS
            if directory == 1
                fid = fopen(['txtFiles',slash2use,'TSname.txt'], 'r');
                TSname = fgetl(fid);
                if (fclose(fid) ~= 0)
                    'error closing file'
                end
            end
            cd('res');
            %load file
            load allrun.mat
            
            corrida = size(allrun,2);
            Etestset = zeros(1,corrida);
            generation = allrun{1,1}.var.generations;
            
            %obtain the fitness of all best networks per run, to see the best in all runs
            for i=1:corrida
                % Chose which criteria you want to use to select the best
                % individual
                
                %Etestset(1,i) = allrun{1,i}.Network{1,1}.predictF.NRMSE;
                Etestset(1,i) = allrun{1,i}.Network{1,1}.predict{1,stepsAhead}.NRMSE;
                %Etestset(1,i) = allrun{1,i}.Network{1,1}.oneStep{1,stepsAhead}.NRMSE;
            end
            
            [minimo, pos] = min(Etestset);
            
            %load the data of the best network
            %Chose the variable, likend with the previos decision ^
            
            %temp = zeros(1,allrun{1}.var.Pred_stepAhead);
            temp{1,directory} = allrun{pos}.Network{1,1}.predict{1,stepsAhead}.Pred;
            %temp{1,directory} = allrun{pos}.Network{1,1}.oneStep{1,stepsAhead}.Pred;
            
            if directory ~=  sizeDir
                clear allrun
            end
        end
        
        
        
        %Change to the dir to save figs
        if(exist(dir2save, 'dir') ~= 7)
            mkdir(dir2save)
        end
        
        cd(dir2save);
        % select what to plot
        
        clf
        h = plot(allrun{1,1}.toPredict{1,stepsAhead}(1,:),'r.','LineWidth',1.5,'Markersize',16);
        hold all
        for alldir=1:sizeDir
            h = plot(temp{1,alldir},lines{1,alldir},'LineWidth',1);
        end
        
        legend('Original', 'Tournament', 'Random','CoEPNet','Fixed Inp','Fixed and evolve', 'Hierarchical');
        
        xlabel('n','FontSize',12)
        ylabel('X(n)','FontSize',12)
        string2title = ['\it{',TSname,'}'];
        title(string2title,'FontSize',16');
        
        foo = 'to make a pause put s break point here';
        saveas(h, [TSname,'BestPred',num2str(stepsAhead),'.fig']);
        clf
        clear h
        clear TSname
        %cd('..');  %exit dir TS
        
    end
end

