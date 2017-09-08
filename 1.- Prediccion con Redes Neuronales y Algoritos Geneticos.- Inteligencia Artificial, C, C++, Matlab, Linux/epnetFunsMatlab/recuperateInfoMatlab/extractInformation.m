%extrasctInformation.m
%Script to real all the files cretade by C and obtain
%the values in a table
% the file is the same for all TS

%ejecuted from root directory

%format
%                       MEAN / STD Dev / MIN / MAX
%number of connections   %        %        %    %
%No. of inputs           %                      %
%No. of hidden nodes     %                      %
%Error on training set   %                      %
%error on validation set %                      %
%erro on test set        %        %        %    %


%read file /res/allrun.mat, previously it must have been run the file
% "recuperateInfoC.m"

%clear
clc

load (['res', SLASH, 'allrun.mat']);

corrida = size(allrun,2);
conLine = 1;


%% Load parameters from file
%Vector number of connections from the best network obtained per run
%initialize var
Nconnect = zeros(1,corrida);
for i=1:corrida
    %obtain connections
    ConnPerRun(1,i) = countConnections(allrun{1,i}.Network{1,1}.CW, allrun{1,i}.Network{1,1}.bias);
end

% load inputs, delays and hidden per run of the best from the population
% also the generations and evaluations
for i=1:corrida
    Ninputs(1,i) = sum( allrun{1,i}.Network{1,1}.nodes( 1:allrun{1,i}.Network{1,1}.varN.finalInp) );
    Ndelays(1,i) = allrun{1,i}.Network{1,1}.varN.delays;
    Nhidden(1,i) = allrun{1,i}.Network{1,1}.varN.hidden;
    gen(1,i) = allrun{1,i}.generation;
    evaluations(1,i) = allrun{1,i}.ALLParam.totalEval;
end




%Vector error trainig set
temp = [];
Etrainingset = zeros(1,corrida);
EtestInside = zeros(1,corrida);
Etestset = zeros(1,corrida);



if ( allrun{1,1}.var.task2solve == allrun{1,1}.C.PREDICT || strcmp(allrun{1,1}.var.typeDS,'NRMSE'))
    % load (nrms inside, final, accuracy and ,more)
    for i=1:corrida
        Etrainingset(1,i) = allrun{1,i}.Network{1,1}.Epochs.Etr(allrun{1,1}.var.epochsK(1,2));
        EtestInside(1,i) = allrun{1,i}.Network{1,1}.predictI.NRMSE(1,1); % change latter the c code to have
        Etestset(1,i) = allrun{1,i}.Network{1,1}.predictF.NRMSE(1,1); % only one value here, and another variable
        % to hold the error per output
        EtestInsideRMSE(1,i) = allrun{1,i}.Network{1,1}.predictI.RMSE(1,1);
        EtestsetRMSE(1,i) = allrun{1,i}.Network{1,1}.predictF.RMSE(1,1);
        
    end
    
    
elseif ( allrun{1,1}.var.task2solve == allrun{1,1}.C.CLASSIFY && ~strcmp(allrun{1,1}.var.typeDS,'NRMSE') )
    
    classifEInside = zeros(1,corrida);
    classifEOutside = zeros(1,corrida);
    
    % load (nrms inside, final, accuracy and ,more)
    for i=1:corrida
        Etrainingset(1,i) = allrun{1,i}.Network{1,1}.Epochs.Etr(allrun{1,1}.var.epochsK(1,2));
        EtestInside(1,i) = allrun{1,i}.Network{1,1}.predictI.Epercentage;
        Etestset(1,i) = allrun{1,i}.Network{1,1}.predictF.Epercentage;
        
        classifEInside(1,i) = allrun{1,i}.Network{1,1}.predictI.classifError;
        classifEOutside(1,i) = allrun{1,i}.Network{1,1}.predictF.classifError;
    end
    
    
end






%% Start to fill the table
% Order
% Inputs
% Delays                - optional Assymetric EPNet does not use it
% Hidden
% Connections
% E training set        - optional
% E validation
% Classif Error Validation   - for classification
% Error test set
% Classif E. test set       - for classification


conLine = 1;
conLineRMSE = 1;

% I n p u t s 1
ALLtogeter(conLine,1) = mean(Ninputs);
ALLtogeter(conLine,2) = std(Ninputs);
ALLtogeter(conLine,3) = min(Ninputs);
ALLtogeter(conLine,4) = max(Ninputs);
conLine = conLine + 1;
conLineRMSE = conLineRMSE + 1;

% D e l a y s 2
if allrun{1,1}.var.task2solve == allrun{1,1}.C.PREDICT || strcmp(allrun{1,1}.var.typeDS,'NRMSE')
    % Even Asymmetric does not use them I read them
    ALLtogeter(conLine,1) = mean(Ndelays);
    ALLtogeter(conLine,2) = std(Ndelays);
    ALLtogeter(conLine,3) = min(Ndelays);
    ALLtogeter(conLine,4) = max(Ndelays);
    conLine = conLine + 1;
    conLineRMSE = conLineRMSE + 1;
end


% H i d d e n   n o d e s 3
ALLtogeter(conLine,1) = mean(Nhidden);
ALLtogeter(conLine,2) = std(Nhidden);
ALLtogeter(conLine,3) = min(Nhidden);
ALLtogeter(conLine,4) = max(Nhidden);
conLine = conLine + 1;
conLineRMSE = conLineRMSE + 1;


% C o n n e c t i o n s 4
ALLtogeter(conLine,1) = mean(ConnPerRun);
ALLtogeter(conLine,2) = std(ConnPerRun);
ALLtogeter(conLine,3) = min(ConnPerRun);
ALLtogeter(conLine,4) = max(ConnPerRun);
conLine = conLine + 1;
conLineRMSE = conLineRMSE + 1;




% E r r o r   t r a i n i n g   s e t 5
if ( extractTrainingError == 1)
    ALLtogeter(conLine,1) = mean(Etrainingset);
    ALLtogeter(conLine,2) = std(Etrainingset);
    ALLtogeter(conLine,3) = min(Etrainingset);
    ALLtogeter(conLine,4) = max(Etrainingset);
    conLine = conLine + 1;
    conLineRMSE = conLineRMSE + 1;
end


%  E r r o r   i n s i d e   ( V a l i d a t i o n   s e t ) 6
ALLtogeter(conLine,1) = mean(EtestInside);
ALLtogeter(conLine,2) = std(EtestInside);
ALLtogeter(conLine,3) = min(EtestInside);
ALLtogeter(conLine,4) = max(EtestInside);
conLine = conLine + 1;
conLineRMSE = conLineRMSE + 1;



% If RMSE is required 7
if( extractRMSE == 1 )
    %ALLtogeterRMSE(1,1) = 0;
    ALLtogeterRMSE(conLineRMSE,1) = mean(EtestInsideRMSE);
    ALLtogeterRMSE(conLineRMSE,2) = std(EtestInsideRMSE);
    ALLtogeterRMSE(conLineRMSE,3) = min(EtestInsideRMSE);
    ALLtogeterRMSE(conLineRMSE,4) = max(EtestInsideRMSE);
    % not increment line as it is in another table, at the same level
end



% Classification error Validation set 8
if ( allrun{1,1}.var.task2solve == allrun{1,1}.C.CLASSIFY && ~strcmp(allrun{1,1}.var.typeDS,'NRMSE') )
    ALLtogeter(conLine,1) = mean(classifEInside);
    ALLtogeter(conLine,2) = std(classifEInside);
    ALLtogeter(conLine,3) = min(classifEInside);
    ALLtogeter(conLine,4) = max(classifEInside);
    conLine = conLine + 1;
end

% E r r o r   t e s t   s e t 9
ALLtogeter(conLine,1) = mean(Etestset);
ALLtogeter(conLine,2) = std(Etestset);
ALLtogeter(conLine,3) = min(Etestset);
ALLtogeter(conLine,4) = max(Etestset);
%conLine = conLine + 1;  % here normally finish, if class erro is added it
%increaases the counter for lines before add its values


% RMSE
if( extractRMSE == 1 )
    conLineRMSE = conLineRMSE + 1;
    ALLtogeterRMSE(conLineRMSE,1) = mean(EtestsetRMSE);
    ALLtogeterRMSE(conLineRMSE,2) = std(EtestsetRMSE);
    ALLtogeterRMSE(conLineRMSE,3) = min(EtestsetRMSE);
    ALLtogeterRMSE(conLineRMSE,4) = max(EtestsetRMSE);
    % not increment line as it is in another table, at the same level
end


% Classification error test set
if ( allrun{1,1}.var.task2solve == allrun{1,1}.C.CLASSIFY && ~strcmp(allrun{1,1}.var.typeDS,'NRMSE'))
    conLine = conLine + 1;
    ALLtogeter(conLine,1) = mean(classifEOutside);
    ALLtogeter(conLine,2) = std(classifEOutside);
    ALLtogeter(conLine,3) = min(classifEOutside);
    ALLtogeter(conLine,4) = max(classifEOutside);
    
end





% if extractGenerations == 1;
if (extractGenerations == 1)
    conLine = conLine + 1;
    ALLtogeter(conLine,1) = mean(gen);
    ALLtogeter(conLine,2) = std(gen);
    ALLtogeter(conLine,3) = min(gen);
    ALLtogeter(conLine,4) = max(gen);
    
end

% if extractEvaluations == 1;
if (extractEvaluations == 1)
    conLine = conLine + 1;
    ALLtogeter(conLine,1) = mean(evaluations);
    ALLtogeter(conLine,2) = std(evaluations);
    ALLtogeter(conLine,3) = min(evaluations);
    ALLtogeter(conLine,4) = max(evaluations);
    
end





%% put together the final error form al TS in a table
ALLTSfinalTestSet(w,1) = mean(Etestset);
ALLTSfinalTestSet(w,2) = std(Etestset);
ALLTSfinalTestSet(w,3) = min(Etestset);
ALLTSfinalTestSet(w,4) = max(Etestset);

%save ALLtogeter ALLtogeter

