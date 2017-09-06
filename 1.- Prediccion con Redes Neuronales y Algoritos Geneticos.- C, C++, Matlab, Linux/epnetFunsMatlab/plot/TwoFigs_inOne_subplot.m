% Script to plot two figures no in diff boxes using subplot

%average over all generations
clear
clc

%both directories to compare LINUX
% dir1 = '/data/private/vlm/DoctoradoResultados/TSEPnet48C/';   %blue line -put here the Exp that mut be better
% dir2 = '/data/private/vlm/DoctoradoResultados/TSEPnet22C/';   %Red line
% dir2save = '/data/private/vlm/DoctoradoResultados/AnalyseRes/Analysis SuccessfulTP/Figs_AvMut_48C_22C'

%both directories to compare Windows
dir1 = 'D:\DoctoradoResultados/TSEPnet34C/';   %blue line -put here the Exp that mut be better
dir2 = 'D:\DoctoradoResultados/TSEPnet39C/';   %Red line
%dir2save = 'D:\DoctoradoResultados/AnalyseRes/Analysis SuccessfulTP/Figs_AvMut_48C_22C'



cd('..');           %exit plot
cd('..');           %exit matlab dir

path1 = pwd;        %I do not know if i need this

%load the TS
load TS.mat

for TSdir =1:21         %for all TS
    dir{1,1} = [dir1,TS{1,TSdir}];
    dir{1,2} = [dir2,TS{1,TSdir}];
    
    for directory=1:2  %for  both exp.
        cd(dir{1,directory});

        %obtain name of the TS
        if directory == 1
            fid = fopen('TSname.txt', 'r');
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
        averageinput{1,directory} = zeros(1,generaverageNRMSation);
        averagehidden{1,directory} = zeros(1,generation);
        
        Avhybridtraining{1,directory} = zeros(1,generation);
        AvnodeDel{1,directory} = zeros(1,generation);
        AvconnDel{1,directory} = zeros(1,generation);
        AvnodeAdd{1,directory} = zeros(1,generation);
        AvconnAdd{1,directory} = zeros(1,generation);

        %Sum the values to obtain the averages
        for i=1:corrida

            avaccuracy{1,directory} = avaccuracy{1,directory} + allrun{1,i}.ALLParam.AvaccuracyValI;
            
            averageNRMS{1,directory} = averageNRMS{1,directory} + allrun{1,i}.ALLParam.AvIterateNRMS_I;
                        
            averagecon{1,directory} = averagecon{1,directory} + allrun{1,i}.ALLParam.Avconnections;
            averageinput{1,directory} = averageinput{1,directory} + allrun{1,i}.ALLParam.Avinputs;
            averagehidden{1,directory} = averagehidden{1,directory} + allrun{1,i}.ALLParam.Avhidden;

            Avhybridtraining{1,directory} = Avhybridtraining{1,directory} + allrun{1,i}.ALLParam.Avhybridtraining;
            AvnodeDel{1,directory} = AvnodeDel{1,directory} + allrun{1,i}.ALLParam.AvnodeDel;
            AvconnDel{1,directory} = AvconnDel{1,directory} + allrun{1,i}.ALLParam.AvconnDel;
            AvnodeAdd{1,directory} = AvnodeAdd{1,directory} + allrun{1,i}.ALLParam.AvnodeAdd;
            AvconnAdd{1,directory} = AvconnAdd{1,directory} + allrun{1,i}.ALLParam.AvconnAdd;
            
        end

        %divide to average them
        avaccuracy{1,directory} = avaccuracy{1,directory}/corrida;
        averageNRMS{1,directory} = averageNRMS{1,directory}/corrida;
        averagecon{1,directory} = averagecon{1,directory}/corrida;
        averageinput{1,directory} = averageinput{1,directory}/corrida;
        averagehidden{1,directory} = averagehidden{1,directory}/corrida;


        Avhybridtraining{1,directory} = Avhybridtraining{1,directory}/corrida;
        AvnodeDel{1,directory} = AvnodeDel{1,directory}/corrida;
        AvconnDel{1,directory} = AvconnDel{1,directory}/corrida;
        AvnodeAdd{1,directory} = AvnodeAdd{1,directory}/corrida;
        AvconnAdd{1,directory} = AvconnAdd{1,directory}/corrida;
        
        %     if directory == 2
        %         if generation <= 500
        %             modulo = 10;
        %         else
        %             modulo = 10;
        %         end
        %         for i=1:generation
        %             if mod(i,modulo) ~= 0
        %                 avaccuracy{1,directory}(1,i) = NaN;
        %                 averageNRMS{1,directory}(1,i) = NaN;
        %                 averagecon{1,directory}(1,i) = NaN;
        %                 averageinput{1,directory}(1,i) = NaN;
        %                 averagehidden{1,directory}(1,i) = NaN;
        %             end
        %         end
        %     end
        %
        
        %delete some point to make the grapihc more clear
        if generation <= 500
            modulo = 10;
        else
            modulo = 50;
        end
        for i=1:generation
            if mod(i,modulo) ~= 0
                %Avhybridtraining{1,directory}(1,i)=NaN;
                AvnodeDel{1,directory}(1,i)=NaN;
                AvconnDel{1,directory}(1,i)=NaN;
                %AvnodeAdd{1,directory}(1,i)=NaN;
                AvconnAdd{1,directory}(1,i)=NaN;
            end
        end

        clear allrun
    end



    % select what to plot

    for i=[7]                         %1:6
        clf
        if i==1
            h = plot(avaccuracy{1,1},'LineWidth',1);
            hold all
            h = plot(avaccuracy{1,2},'-r','LineWidth',1);
            ylabel('Average Accuracy','FontSize',12)
        elseif i==2
            subplot(2,1,1); plot(averageNRMS{1,1},'LineWidth',1);
            %text(150,.4,'\leftarrow Relaxed value');
            %hold all
            subplot(2,1,2); plot(averageNRMS{1,2},'-r','LineWidth',1);
            %text(150,.1,'\leftarrow Strict value');
            ylabel('Average NRMS','FontSize',12)
        elseif i==3
            h = plot(averagecon{1,1},'LineWidth',1);
            %text(150,.4,'\leftarrow Relaxed value');
            hold all
            h = plot(averagecon{1,2},'-r','LineWidth',1);
            %text(150,.1,'\leftarrow Strict value');
            ylabel('Average Connections','FontSize',12)
        elseif i==4
            h = plot(averageinput{1,1},'LineWidth',1);
            %text(150,.4,'\leftarrow Relaxed value');
            hold all
            h = plot(averageinput{1,2},'-r','LineWidth',1);
            %text(150,.1,'\leftarrow Strict value');
            ylabel('Average Inputs','FontSize',12)
        elseif i==5
            h = plot(averagehidden{1,1},'LineWidth',1);
            %text(150,.4,'\leftarrow Relaxed value');
            hold all
            h = plot(averagehidden{1,2},'-r','LineWidth',1);
            %text(150,.1,'\leftarrow Strict value');
            ylabel('Average Hidden Nodes','FontSize',12)
            %         %------------------------------------
            
        elseif i==7
            %cd(dir2save);
            
            h = gca
            xlabel('Generations','FontSize',12)
            
            %to plot the average evolution of mutations
            subplot(1,2,1);
            ylabel('Average Number of Mutations') 
            
            h = plot(Avhybridtraining{1,1},'--k')
            hold all
            h = plot(AvnodeDel{1,1},'-og')
            h = plot(AvconnDel{1,1},'-*b')
            h = plot(AvnodeAdd{1,1},'r')
            h = plot(AvconnAdd{1,1},'-xm')
            
            legend('Hybrid training','Node deletion','Connection deletion','Node addition','Connection addition')
            %------------------------------------
            
           
            string2title = ['\it{',TSname,'1%STP','}'];
            title(string2title,'FontSize',16');
        
            
            subplot(1,2,2);
            %ylabel('Average Number of Mutations')
            %xlabel('Generations','FontSize',12)
            
            h = plot(Avhybridtraining{1,2},'--k')
            hold all
            h = plot(AvnodeDel{1,2},'-og')
            h = plot(AvconnDel{1,2},'-*b')
            h = plot(AvnodeAdd{1,2},'r')
            h = plot(AvconnAdd{1,2},'-xm')
            
            %legend('Hybrid training','Node deletion','Connection deletion','Node addition','Connection addition')
            %------------------------------------
            
            string2title = ['\it{',TSname,'70%STP','}'];
            title(string2title,'FontSize',16');
            
                
                
                
           %saveas(h, [TSname,'AverageMutations.fig']);
                    clf;
                    clear h
        end

        
        
        
        
        foo = 'to make a pause put s break point here';
        %     if i==1
        %         saveas(h, 'AverageAccuracy.fig');
        %         clf;
        %         clear h
        %     elseif i==2
        %         saveas(h, 'AverageNRMS.fig');
        %         clf;
        %         clear h
        %     elseif i==3
        %        saveas(h, 'AverageConn.fig');
        %         clf;
        %         clear h
        %     elseif i==4
        %         saveas(h, 'Averageinputs.fig');
        %         clf;
        %         clear h
        %     elseif i==5
        %         saveas(h, 'Averagehidden.fig');
        %         clf;
        %         clear h
        %     elseif i==6
        %         saveas(h, 'AverageMutations.fig');
        %         clf;
        %         clear h
        %     end
    end
    clear TSname
    %cd('..');  %exit dir TS

end


