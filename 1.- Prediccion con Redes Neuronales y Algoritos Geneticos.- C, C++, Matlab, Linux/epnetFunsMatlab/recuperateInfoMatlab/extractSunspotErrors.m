%extractSunspotErrors.m
%This file is used to load all runs for the sunspot TS and calculate two
%separate error as done in the literature

%ejecuted from root directory

%format
%                       MEAN / STD Dev / MIN / MAX
%erro on test set        %        %        %    %


clc

sizeSet1 = 32;
sizeSet2 = 36;

load (['sunspot', SLASH, 'res', SLASH, 'allrun.mat']);

corrida = size(allrun,2);
conLine = 1;

%Vector error trainig set
temp = [];
E1 = zeros(1,corrida);
E2 = zeros(1,corrida);
E1rmse = zeros(1,corrida);
E2rmse = zeros(1,corrida);


% load toPredictF
t = allrun{1,1}.toPredictF;
sizet = size(t,2);

% obtain the mean of the set to predict

% Check that the sizes are ok

if ((sizeSet1 + sizeSet2) ~= sizet )
    display('Error in the sizes of the sets and the set to predict, .... fun extractSunspotErrors.m')
    display('Exit manually ... :)') 
end

% load (nrms inside, final, accuracy and ,more)
for i=1:corrida
    
    E1(1,i) = F_NRMSE(allrun{1,i}.Network{1,1}.predictF.Pred(1:sizeSet1), t(1:sizeSet1));
    E2(1,i) = F_NRMSE(allrun{1,i}.Network{1,1}.predictF.Pred(sizeSet1 + 1:sizet), t(sizeSet1 + 1:sizet) );
    
    E1rmse(1,i) = F_RMSE(allrun{1,i}.Network{1,1}.predictF.Pred(1:sizeSet1), t(1:sizeSet1));
    E2rmse(1,i) = F_RMSE(allrun{1,i}.Network{1,1}.predictF.Pred(sizeSet1 + 1:sizet), t(sizeSet1 + 1:sizet) );
    
end



conLine = 1;
ALLTablesSunspot(conLine,1) = mean(E1);
ALLTablesSunspot(conLine,2) = std(E1);
ALLTablesSunspot(conLine,3) = min(E1);
ALLTablesSunspot(conLine,4) = max(E1);

ALLTablesSunspot(conLine,5) = mean(E2);
ALLTablesSunspot(conLine,6) = std(E2);
ALLTablesSunspot(conLine,7) = min(E2);
ALLTablesSunspot(conLine,8) = max(E2);


ALLTablesSunspotrmse(conLine,1) = mean(E1rmse);
ALLTablesSunspotrmse(conLine,2) = std(E1rmse);
ALLTablesSunspotrmse(conLine,3) = min(E1rmse);
ALLTablesSunspotrmse(conLine,4) = max(E1rmse);

ALLTablesSunspotrmse(conLine,5) = mean(E2rmse);
ALLTablesSunspotrmse(conLine,6) = std(E2rmse);
ALLTablesSunspotrmse(conLine,7) = min(E2rmse);
ALLTablesSunspotrmse(conLine,8) = max(E2rmse);
