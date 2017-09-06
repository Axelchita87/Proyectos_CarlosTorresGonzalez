%Plot the average over all generations for:
%Accuracy
%NRMSE
%Connections
%Hidden nodes
%Inputs
%Mutations
%Worst Average and Best fitness

%The file is called form the main exp: PlotAllFigsAllTS.m

%clc

%Allocate memory to some variables
averageNRMS = zeros(1,generation);
averagecon = zeros(1,generation);
averageinput = zeros(1,generation);
averagehidden = zeros(1,generation);
averageDelays =  zeros(1,generation);


%Sum the values to obtain the averages
for i=1:corrida
    averageNRMS = averageNRMS + allrun{1,i}.ALLParam.AvfitnessHalf;
    averagecon = averagecon + allrun{1,i}.ALLParam.AvconnectionsHalf;
    averageinput = averageinput + allrun{1,i}.ALLParam.AvinputsHalf;
    averagehidden = averagehidden + allrun{1,i}.ALLParam.AvhiddenHalf;
    averageDelays = averageDelays + allrun{1,i}.ALLParam.AvdelaysHalf;
end

%divide to average them 
averageNRMS = averageNRMS/corrida;
averagecon = averagecon/corrida;
averageinput = averageinput/corrida;
averagehidden = averagehidden/corrida;
averageDelays = averageDelays/corrida;

if(exist('figsHALF_fig', 'dir') ~= 7)
    mkdir('figsHALF_fig')
end
cd('figsHALF_fig');

%For to plot
for i=1:9
    if i==1
        h = plot(averageNRMS,'LineWidth',1); ylabel('Average NRMS from half population','FontSize',12)
    elseif i==2    
        h = plot(averagecon,'LineWidth',1); ylabel('Average Connections from half population','FontSize',12)
    elseif i==3
        h = plot(averageinput,'LineWidth',1); ylabel('Average Inputs from half population','FontSize',12)
    elseif i==4
        h = plot(averagehidden,'LineWidth',1); ylabel('Average Hidden Nodes from half population','FontSize',12)
    elseif i==5
        h = plot(averageDelays,'LineWidth',1); ylabel('Average Delays from half population','FontSize',12)
    end

    xlabel('Generations','FontSize',12)
    string2title = ['\it{',TSname,'}'];
    title(string2title,'FontSize',16)

    if i==1
        saveas(h, 'AverageNRMS_half.fig');
        clf;
        clear h
    elseif i==2    
       saveas(h, 'AverageConn_half.fig');
        clf;
        clear h
    elseif i==3
        saveas(h, 'Averageinputs_half.fig');
        clf;
        clear h
    elseif i==4
        saveas(h, 'Averagehidden_half.fig');
        clf;
        clear h
    elseif i==5
        saveas(h, 'AverageDelays_half.fig');
        clf;
        clear h
    end
end
cd('..');

clear avaccuracy averageNRMS averagecon averagehidden averageinput
clear modulo AvnodeAdd AvconnAdd AvnodeDel Avhybridtraining AvconnDel
clear averageBestFit averageWorstFit averageAverageFit
