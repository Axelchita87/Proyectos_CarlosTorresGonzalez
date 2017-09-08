%File to extract all the information for al TS
% is extracted the small tables, all saves in row
%and separated by a line between TS

% variables to look for
% ALLTablesALLTS
% ALLTablesALLTSrmse
% ALLTablesSunspot
% ALLTablesSunspotrmse

clear
clc


extractTrainingError = 1;
extractGenerations = 1;
extractEvaluations = 1;

extractRMSE = 1;                %0 = not, 1 = yes, it is only for prediction
extractSunspotSplit = 0;        % take the error of the sunspot into two sets, during evolution is just one big set


pathExp = pwd;        %main dir for this Exp.
cd('epnetFunsMatlab');  cd('LinuxOrWindows');
%use adecuate paht
SLASH = isLinOrWin();
cd('..');  cd('..');

path1 = pwd;        %main dir for Exps


cd(pathExp);
load TS.mat
sizeTS = size(TS,2);

%add local path for used funtions (specifict functions for each exp)
addpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'recuperateInfoMatlab']);
addpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'ANN']);
addpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'Error']);

cont = 1;
for w=1:sizeTS
    cd(TS{1,w});
    run extractInformation
    
    ALLTablesALLTS(cont:(cont+conLine-1),:) = ALLtogeter(1:conLine,:);
    clear ALLtogeter;
        
    if( extractRMSE == 1 )
        ALLTablesALLTSrmse(cont:(cont+conLineRMSE-1),:) = ALLtogeterRMSE(1:conLineRMSE,:);
        clear ALLtogeterRMSE;
    end
    
    cont = cont + conLine + 2;
    
    cd('../');
end


% For the sunspot
if ( extractSunspotSplit == 1 ) 
    run extractSunspotErrors
    clear allrun
end

rmpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'recuperateInfoMatlab']);
rmpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'ANN'])
rmpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'Error']);