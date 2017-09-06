% Script to plot tow average figures form tow different experiments for 1 TS

%average over all generations
clear
clc

%both directories to compare 
dir{1,1} = 'D:\DoctoradoResultados\TSEPnet34C\DemBirhtsQuebec'; %the first dir is the first to plot
dir{1,2} = 'D:\DoctoradoResultados\TSEPnet35C\DemBirhtsQuebec';



for directory=1:2  %for  both exp.
    cd(dir{1,directory});

    %obtain name of the TS
    fid = fopen('TSname.txt', 'r');
    TSname = fgetl(fid);
    
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
    averagehidden{1,directory} = zeros(1,generation);



    %Sum the values to obtain the averages
    for i=1:corrida
        
        avaccuracy{1,directory} = avaccuracy{1,directory} + allrun{1,i}.ALLParam.AvaccuracyValI;
%         if i ~=24
         averageNRMS{1,directory} = averageNRMS{1,directory} + allrun{1,i}.ALLParam.AvIterateNRMS_I;
%         end
        averagecon{1,directory} = averagecon{1,directory} + allrun{1,i}.ALLParam.Avconnections;
        averageinput{1,directory} = averageinput{1,directory} + allrun{1,i}.ALLParam.Avinputs;
        averagehidden{1,directory} = averagehidden{1,directory} + allrun{1,i}.ALLParam.Avhidden;

    end

    %divide to average them
    avaccuracy{1,directory} = avaccuracy{1,directory}/corrida;
    averageNRMS{1,directory} = averageNRMS{1,directory}/corrida;
    averagecon{1,directory} = averagecon{1,directory}/corrida;
    averageinput{1,directory} = averageinput{1,directory}/corrida;
    averagehidden{1,directory} = averagehidden{1,directory}/corrida;

    
%     if directory == 2
%         if generation <= 500
%             modulo = 10;
%         elseif generation <= 2000
%             modulo = 50;
%         else
%             modulo = 100;
%         end
%         for i=1:generation
%             if mod(i,modulo) ~= 0
%                 %avaccuracy{1,directory}(1,i) = NaN;
%                 averageNRMS{1,directory}(1,i) = NaN;
%                 averagecon{1,directory}(1,i) = NaN;
%                 averageinput{1,directory}(1,i) = NaN;
%                 averagehidden{1,directory}(1,i) = NaN;
%             end
%         end
%     end
    
    
    clear allrun
end






% select what to plot

for i=[2 3 4 5]                         %1:6  
    clf
    if i==1
        h = plot(avaccuracy{1,1},'LineWidth',1); 
        hold all
        h = plot(avaccuracy{1,2},'-r','LineWidth',1);
        ylabel('Average Accuracy','FontSize',12)
    elseif i==2
        h = plot(averageNRMS{1,1},'LineWidth',1); 
        %text(150,.4,'\leftarrow Relaxed value');
        hold all
        h = plot(averageNRMS{1,2},'-r','LineWidth',1);
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
    end

    legend('30% Successful T.P.', '70% Successful T.P.', 'FontSize', 12)
    xlabel('Generations','FontSize',12)
    string2title = ['\it{',TSname,'}'];
    title(string2title,'FontSize',16');
    foo = 0;    %to make a pause
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
%cd('..');




