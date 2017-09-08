% plot average over all generations using error bar
%clear
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

% %STD for the error bars
ErrorBnrms = zeros(corrida,generation);
ErrorBcon = zeros(corrida,generation);
ErrorBinput = zeros(corrida,generation);
ErrorBhidden = zeros(corrida,generation);
ErrorBdelays = zeros(corrida,generation);

%put all of them (by runs) in a matrix
for i=1:corrida
    ErrorBnrms(i,:) = allrun{1,i}.ALLParam.AvIterateNRMS_I;
    ErrorBcon(i,:) = allrun{1,i}.ALLParam.Avconnections;
    ErrorBinput(i,:) = allrun{1,i}.ALLParam.Avinputs;
    ErrorBhidden(i,:) = allrun{1,i}.ALLParam.Avhidden;
    ErrorBdelays(i,:) = allrun{1,i}.ALLParam.Avdelays;
end

NRMSErrorbar = std(ErrorBnrms);
conErrorbar  = std(ErrorBcon);
inputErrorbar = std(ErrorBinput);
hiddenErrorbar = std(ErrorBhidden);
delayErrorbar = std(ErrorBdelays);

if generation <= 500
    modulo = 10;
else
    modulo = 50;
end

for i=1:generation
    if mod(i,modulo) ~= 0
        NRMSErrorbar(1,i)=NaN;
        conErrorbar(1,i)=NaN;
        inputErrorbar(1,i)=NaN;
        hiddenErrorbar(1,i)=NaN;
        delayErrorbar(1,i) = NaN;
    end
end

if(exist('figsErrorB_HALF_fig', 'dir') ~= 7)
    mkdir('figsErrorB_HALF_fig');
end

cd('figsErrorB_HALF_fig');



for i=1:5
    if i==1
        h = errorbar(averageNRMS,NRMSErrorbar,'LineWidth',1); ylabel('Average NRMS','FontSize',12)
    elseif i==2
        h = errorbar(averagecon,conErrorbar,'LineWidth',1); ylabel('Average Connections','FontSize',12)
    elseif i==3    
        h =errorbar(averageinput,inputErrorbar,'LineWidth',1); ylabel('Average Inputs','FontSize',12)
    elseif i==4
        h = errorbar(averagehidden,hiddenErrorbar,'LineWidth',1); ylabel('Average Hidden Nodes','FontSize',12)
    elseif i==5
        h = errorbar(averageDelays,delayErrorbar,'LineWidth',1); ylabel('Average delays Nodes','FontSize',12)
    end


xlabel('Generations','FontSize',12)
string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16)

    if i==1
        saveas(h, 'EbarAverageNRMS_half.fig');
        clf;
        clear h
    elseif i==2
        saveas(h, 'EbarAverageConn_half.fig');
        clf;
        clear h
    elseif i==3    
       saveas(h, 'EbarAverageinput_half.fig');
        clf;
        clear h
    elseif i==4
        saveas(h, 'EbarAveragehidden_half.fig');
        clf;
        clear h
    elseif i==5
        saveas(h, 'EbarAverageDelays_half.fig');
        clf;
        clear h
    end
end

cd('..');
clear ErrorBaccuracy ErrorBcon ErrorBhidden ErrorBinput ErrorBnrms
clear NRMSErrorbar accuracyErrorbar avaccuracy averageNRMS 
clear averagecon averagehidden averageinput conErrorbar hiddenErrorbar
clear inputErrorbar modulo i