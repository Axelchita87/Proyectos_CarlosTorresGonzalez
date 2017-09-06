% Script to plot to average figures form many different experiments for all
% TS
% the experiments are in the same folder and they are repreented at
% differen scales.


%to generate the figure of mackey and rossler I delet tremproraly the
%folder of lorenz or mackey and then run this

%average over all generations
clear
clc


%both directories to compare 

dir0{1,1} = 'MEPNet01';   %blue line -put here the Exp that mut be better
%dir0{2,1} = 'TSEPnet66a';   %Red line
%dir0{3,1} = 'TSEPnet66b';
%dir0{4,1} = 'TSEPnet66c';
%dir0{5,1} = 'TSEPnet66d';
%dir0{6,1} = 'TSEPnet66f';

% Dir to save
dir2save = '/bb/cca/vml714/work/Experiments/MEPNet01/figuresConver';


lines{1,1} = '-og';           %default, not used
lines{1,2} = '-*b';
lines{1,3} = 'xr';
lines{1,4} = '-^m';
lines{1,5} = '-pc';
lines{1,6} = '-<b';
lines{1,7} = '->m';
lines{1,8} = '-+r';
lines{1,9} = '--.b';
 
        


cd('..'); 
cd('LinuxOrWindows')
%use adecuate paht
slash2use = isLinOrWin();
cd('..');
cd('..');

path1 = pwd;        %main dir for Exps


%load the TS
load TS.mat

sizeDir = size(dir0,1);

%modify the TS vector to chose lorenz, makey or rossler

cont = 1;

%lorenz
% for c=1:9
%     TS2{1,cont} =TS{1,c};
%     cont = cont +1;
% end

%MAckey
% for c=10:15
%     TS2{1,cont} =TS{1,c};
%     cont = cont +1;
% end

%Rossler
for c=16:18
    TS2{1,cont} =TS{1,c};
    cont = cont +1;
end


%for TSdir = 1:size(TS2,2)        
    
    %accomodate the directories
    for alldir=1:size(TS2,2)
        dir{1,alldir} = [path1,slash2use,TS2{1,alldir}];
    end
    
       
    for directory=1:size(TS2,2)  %for all exp.
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


        %Allocate memory to some variables
        avaccuracy{1,directory} = zeros(1,generation);
        averageNRMS{1,directory} = zeros(1,generation);
        averagecon{1,directory} = zeros(1,generation);
        averageinput{1,directory} = zeros(1,generation);
         averagedelays{1,directory} = zeros(1,generation);
        averagehidden{1,directory} = zeros(1,generation);



        %Sum the values to obtain the averages
        for i=1:corrida

            avaccuracy{1,directory} = avaccuracy{1,directory} + allrun{1,i}.ALLParam.AvaccuracyValI;
            averageNRMS{1,directory} = averageNRMS{1,directory} + allrun{1,i}.ALLParam.AvIterateNRMS_I;
            averagecon{1,directory} = averagecon{1,directory} + allrun{1,i}.ALLParam.Avconnections;
            averageinput{1,directory} = averageinput{1,directory} + allrun{1,i}.ALLParam.Avinputs;
             averagedelays{1,directory} = averagedelays{1,directory} + allrun{1,i}.ALLParam.Avdelays;
            averagehidden{1,directory} = averagehidden{1,directory} + allrun{1,i}.ALLParam.Avhidden;

        end

        %divide to average them
        avaccuracy{1,directory} = avaccuracy{1,directory}/corrida;
        averageNRMS{1,directory} = averageNRMS{1,directory}/corrida;
        averagecon{1,directory} = averagecon{1,directory}/corrida;
        averageinput{1,directory} = averageinput{1,directory}/corrida;
        averagedelays{1,directory} = averagedelays{1,directory}/corrida;
        averagehidden{1,directory} = averagehidden{1,directory}/corrida;


            if directory ~= 1
                if generation <= 500
                    modulo = 10;
                else
                    modulo = 50;
                end
                for i=1:generation
                    if mod(i,modulo) ~= 0
                        avaccuracy{1,directory}(1,i) = NaN;
                        averageNRMS{1,directory}(1,i) = NaN;
                        averagecon{1,directory}(1,i) = NaN;
                        averageinput{1,directory}(1,i) = NaN;
                        averagedelays{1,directory}(1,i) = NaN;
                        averagehidden{1,directory}(1,i) = NaN;
                    end
                end
            end
        

        clear allrun
    end

    %Change to the dir to save figs
    cd(dir2save);
    % select what to plot

    for i=[2 3 4 5 6]                         %1:6
        clf
        if i==1
            h = plot(avaccuracy{1,1},'LineWidth',1);
            hold all
            h = plot(avaccuracy{1,2},'-r','LineWidth',1);
            ylabel('Average Accuracy','FontSize',12)
        
        elseif i==2
            clf
        h = axes('YScale','log')
        hold all 
            h = plot(averageNRMS{1,1},'LineWidth',1);
            %text(150,.4,'\leftarrow Relaxed value');
          
            for alldir = 2:size(TS2,2)
                h = plot(averageNRMS{1,alldir},lines{1,alldir},'LineWidth',1);
                 %text(150,.1,'\leftarrow Strict value');
            end
                ylabel('Average NRMS','FontSize',12)
                subname = 'AvNRMS';
       
        elseif i==3
            h = plot(averagecon{1,1},'LineWidth',1);
            %text(150,.4,'\leftarrow Relaxed value');
            hold all
            for alldir = 2:size(TS2,2)
                h = plot(averagecon{1,alldir},lines{1,alldir},'LineWidth',1);
                %text(150,.1,'\leftarrow Strict value');
            end
            ylabel('Average Connections','FontSize',12)
            subname = 'AvCon';
       
        elseif i==4
            h = plot(averageinput{1,1},'LineWidth',1);
            %text(150,.4,'\leftarrow Relaxed value');
            hold all
            for alldir = 2:size(TS2,2)
                h = plot(averageinput{1,alldir},lines{1,alldir},'LineWidth',1);
                %text(150,.1,'\leftarrow Strict value');
            end
            ylabel('Average Inputs','FontSize',12)
            subname = 'AvInp';
        
        elseif i==5
            h = plot(averagedelays{1,1},'LineWidth',1);
            %text(150,.4,'\leftarrow Relaxed value');
            hold all
            for alldir = 2:size(TS2,2)
                h = plot(averagedelays{1,alldir},lines{1,alldir},'LineWidth',1);
                %text(150,.1,'\leftarrow Strict value');
            end
            ylabel('Average Delays','FontSize',12)
            subname = 'AvDelays';
        
        elseif i==6
            h = plot(averagehidden{1,1},'LineWidth',1);
            %text(150,.4,'\leftarrow Relaxed value');
            hold all
            for alldir = 2:size(TS2,2)
                h = plot(averagehidden{1,alldir},lines{1,alldir},'LineWidth',1);
                %text(150,.1,'\leftarrow Strict value');
            end
            ylabel('Average Hidden Nodes','FontSize',12)
            subname = 'AvHid';
            %         %------------------------------------
        end
        %legned Lorenz
%         legend('Lorenz1 s1','Lorenz1 s2','Lorenz1 s3','Lorenz2 s1','Lorenz2 s2','Lorenz2 s3',...
%             'Lorenz3 s1','Lorenz1 s3','Lorenz3 s3','FontSize', 12);
        
        %Legend Mackey
        legend('MG1 s1','MG1 s2','MG1 s3','MG2 s1','MG2 s2','MG2 s3','FontSize', 12);
        
        %Legend Rossler
        legend('Rossler s1','Rossler s2','Rossler s3','FontSize', 12);
        
        xlabel('Generations','FontSize',12)
        string2title = ['\it{',TSname,'}'];
        title(string2title,'FontSize',16');
        
        foo = 'to make a pause put s break point here';
        
        saveas(h, [TSname,subname,'.fig']);
      
    end
    clear TSname
    %cd('..');  %exit dir TS

%end


