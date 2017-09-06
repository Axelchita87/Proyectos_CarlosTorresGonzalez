%% Plot Error bras for th average parameters
% The figures are plot in a separate directory
%
% Created: around 2008
% Modified at:  23/09/2010
% Author:       Carlos Torres and Victor Landassuri 



%% Obtain the average values per generation and obtain the average and
%% standar deviation

%clc

%Allocate memory to some variables
 avaccuracy = zeros(1,generation);
averageNRMS = zeros(1,generation);
averagecon = zeros(1,generation);
averageinput = zeros(1,generation);
averagehidden = zeros(1,generation);
averageDelays =  zeros(1,generation);
avClassifError = zeros(1,generation);

%Sum the values to obtain the averages
for i=1:corrida
   avaccuracy = avaccuracy + allrun{1,i}.ALLParam.AvaccuracyValI;
    averageNRMS = averageNRMS + allrun{1,i}.ALLParam.Avfitness;
    averagecon = averagecon + allrun{1,i}.ALLParam.Avconnections;
    averageinput = averageinput + allrun{1,i}.ALLParam.Avinputs;
    averagehidden = averagehidden + allrun{1,i}.ALLParam.Avhidden;
    averageDelays = averageDelays + allrun{1,i}.ALLParam.Avdelays;
    
end

if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
    for i=1:corrida
        avClassifError = avClassifError + allrun{1,i}.ALLParam.AvClassifError;
    end
end

%divide to average them 
avaccuracy = avaccuracy/corrida;
averageNRMS = averageNRMS/corrida;
averagecon = averagecon/corrida;
averageinput = averageinput/corrida;
averagehidden = averagehidden/corrida;
averageDelays = averageDelays/corrida;
avClassifError = avClassifError/corrida;

% %STD for the error bars

ErrorBaccuracy = zeros(corrida,generation);
ErrorBnrms = zeros(corrida,generation);
ErrorBcon = zeros(corrida,generation);
ErrorBinput = zeros(corrida,generation);
ErrorBhidden = zeros(corrida,generation);
ErrorBdelays = zeros(corrida,generation);
ErrorBClassifError = zeros(corrida,generation);

%put all of them (by runs) in a matrix
for i=1:corrida
    ErrorBaccuracy(i,:) = allrun{1,i}.ALLParam.AvaccuracyValI;
    ErrorBnrms(i,:) = allrun{1,i}.ALLParam.AvIterateNRMS_I;
    ErrorBcon(i,:) = allrun{1,i}.ALLParam.Avconnections;
    ErrorBinput(i,:) = allrun{1,i}.ALLParam.Avinputs;
    ErrorBhidden(i,:) = allrun{1,i}.ALLParam.Avhidden;
    ErrorBdelays(i,:) = allrun{1,i}.ALLParam.Avdelays;
    
end

if ( allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY )
    for i=1:corrida
        ErrorBClassifError(i,:) = allrun{1,i}.ALLParam.AvClassifError;
    end
end

accuracyErrorbar = std(ErrorBaccuracy);
NRMSErrorbar = std(ErrorBnrms);
conErrorbar  = std(ErrorBcon);
inputErrorbar = std(ErrorBinput);
hiddenErrorbar = std(ErrorBhidden);
delayErrorbar = std(ErrorBdelays);
classifErrorErrorbar = std(ErrorBClassifError);

if generation <= 500
    modulo = 10;
else
    modulo = 50;
end

for i=1:generation
    if mod(i,modulo) ~= 0
        accuracyErrorbar(1,i)=NaN;
        NRMSErrorbar(1,i)=NaN;
        conErrorbar(1,i)=NaN;
        inputErrorbar(1,i)=NaN;
        hiddenErrorbar(1,i)=NaN;
        delayErrorbar(1,i) = NaN;
        classifErrorErrorbar(1,i) = NaN;
    end
end

% Change tot he directory
if(exist('figsErrorB_fig', 'dir') ~= 7)
    mkdir('figsErrorB_fig')
end

cd('figsErrorB_fig');


%% Start to plot the values

for i=1:6
    if i==1
        h = errorbar(averageNRMS,NRMSErrorbar,'LineWidth',1); ylabel('Average NRMS','FontSize',12)
        
    elseif i==2
        h = errorbar(averagecon,conErrorbar,'LineWidth',1); ylabel('Average Connections','FontSize',12)
        
    elseif ( i==3 && allrun{1,1}.var.fixedinputs ~= allrun{1,1}.C.FIXED)      
        h =errorbar(averageinput,inputErrorbar,'LineWidth',1); ylabel('Average Inputs','FontSize',12)
        
    elseif i==4
        h = errorbar(averagehidden,hiddenErrorbar,'LineWidth',1); ylabel('Average Hidden Nodes','FontSize',12)
        
    elseif ( i==5 && allrun{1,1}.var.fixedinputs ~= allrun{1,1}.C.FIXED) 
        h = errorbar(averageDelays,delayErrorbar,'LineWidth',1); ylabel('Average Delays Nodes','FontSize',12)
        
    elseif (i==6 && allrun{1,1}.var.task2solve == allrun{1,1}.C.CLASSIFY)
        h = errorbar(avClassifError,classifErrorErrorbar,'LineWidth',1); ylabel('Average Classifcation Error','FontSize',12)
        
    end


xlabel('Generations','FontSize',12)
string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16)

    if i==1
        saveas(h, 'EbarAverageNRMS.fig');
        clf;
        clear h
    elseif i==2
        saveas(h, 'EbarAverageConn.fig');
        clf;
        clear h
    elseif (i==3 && allrun{1,1}.var.fixedinputs ~= allrun{1,1}.C.FIXED)    
       saveas(h, 'EbarAverageinput.fig');
        clf;
        clear h
    elseif i==4
        saveas(h, 'EbarAveragehidden.fig');
        clf;
        clear h
    elseif (i==5 && allrun{1,1}.var.fixedinputs ~= allrun{1,1}.C.FIXED)
        saveas(h, 'EbarAverageDelays.fig');
        clf;
        clear h
    elseif (i==6 && allrun{1,1}.var.task2solve == allrun{1,1}.C.CLASSIFY)
        saveas(h, 'EbarAverageClassifError.fig');
        clf;
        clear h
    end
end

cd('..');
clear ErrorBaccuracy ErrorBcon ErrorBhidden ErrorBinput ErrorBnrms
clear NRMSErrorbar accuracyErrorbar avaccuracy averageNRMS 
clear averagecon averagehidden averageinput conErrorbar hiddenErrorbar
clear avClassifError classifErrorErrorbar
clear inputErrorbar modulo i