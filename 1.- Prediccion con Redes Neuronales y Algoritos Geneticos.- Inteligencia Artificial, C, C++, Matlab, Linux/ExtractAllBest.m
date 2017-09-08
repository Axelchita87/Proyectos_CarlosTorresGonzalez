%Extract the Mean std Dev Min and Max form all the best networks form each
%independent run
%also put the inputs, hidden nodes and connections of the best network
%found (Min value NRMS), and put the posmin (position of the minimum) which
%is the best network of a given run

%the fisrt colum (TS) is not put in the table, but is is in the excel file

%format
% TS    Mean    Std Dev     Min     Max     Inputs   delays   hidden  connections

% posmin

clear
clc
% corrida = 30;
%file = 'r';


pathExp = pwd;        %main dir for this Exp.
cd('epnetFunsMatlab');  cd('LinuxOrWindows');
%use adecuate paht
SLASH = isLinOrWin();


%add path for used funtions
addpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'ANN']);


cd(pathExp);
load TS.mat
sizeTS = size(TS,2);

contLine=1;
table = zeros(sizeTS,9);

for i=1:sizeTS
    cd(TS{1,i});
    
    %code to extract the values of each TS
    load (['res', SLASH, 'allrun.mat']);
    corrida = size(allrun,2);
    
    Etestset = zeros(1,corrida);
    maximo=[];
    minimo=[];
    posMax=[];
    posMin=[];
    temp=[];
    % load (nrms inside, final, accuracy and ,more)
    
    
     
    for j=1:corrida
       Etestset(1,j) = allrun{1,j}.Network{1,1}.fitness;  
    end
    temp=[];
    [minimo, posMin] = min(Etestset);
    [maximo, posMax] = max(Etestset);
    
           
    %obtain connections of the best
    Connections = 0;
    inputs = 0;
    Connections = countConnections(allrun{1,posMin}.Network{1,1}.CW, allrun{1,posMin}.Network{1,1}.bias);
    inputs =  sum( allrun{1,posMin}.Network{1,1}.nodes( 1:allrun{1,posMin}.Network{1,1}.varN.finalInp) );
    
    
     
    table(i,1) = mean(Etestset);
    table(i,2) = std(Etestset);
    table(i,3) = minimo;
    table(i,4) = maximo;
    table(i,5) = inputs; 
    table(i,6) = allrun{1,posMin}.Network{1,1}.varN.delays;
    table(i,7) = allrun{1,posMin}.Network{1,1}.varN.hidden;
    table(i,8) = Connections;
    table(i,9) = posMin;
    
    
    
    % section for classification
    if allrun{1,1}.var.task2solve ==  allrun{1,1}.C.CLASSIFY
        % repeat the same from above for the classifcation error, wituho
        % inputs and oter vars
        Etestset = zeros(1,corrida);
        maximo=[];
        minimo=[];
        posMax=[];
        posMin=[];
        for j=1:corrida
            Etestset(1,j) = allrun{1,j}.Network{1,1}.predictF.classifError;
        end
        temp=[];
        [minimo, posMin] = min(Etestset);
        [maximo, posMax] = max(Etestset);
        
        tableClassError(i,1) = mean(Etestset);
        tableClassError(i,2) = std(Etestset);
        tableClassError(i,3) = minimo;
        tableClassError(i,4) = maximo;
        tableClassError(i,5) = posMin;
    end
    
    
    %section for the March 
    Etestset = zeros(1,corrida);
    maximo=[];
    minimo=[];
    posMax=[];
    posMin=[];
    for j=1:corrida
        Etestset(1,j) = allrun{1,j}.Network{1,1}.huskenModule.MarchTD; 
    end
    temp=[];
    [minimo, posMin] = min(Etestset);
    [maximo, posMax] = max(Etestset);
    
    tableMarch(i,1) = mean(Etestset);
    tableMarch(i,2) = std(Etestset);
    tableMarch(i,3) = minimo;
    tableMarch(i,4) = maximo;
    tableMarch(i,5) = posMin;
    
    
    % Mweight
    Etestset = zeros(1,corrida);
    maximo=[];
    minimo=[];
    posMax=[];
    posMin=[];
    for j=1:corrida
        Etestset(1,j) = allrun{1,j}.Network{1,1}.huskenModule.MweightTD; 
    end
    temp=[];
    [minimo, posMin] = min(Etestset);
    [maximo, posMax] = max(Etestset);
    
    tableMweight(i,1) = mean(Etestset);
    tableMweight(i,2) = std(Etestset);
    tableMweight(i,3) = minimo;
    tableMweight(i,4) = maximo;
    tableMweight(i,5) = posMin;
    
    
    tempNode=[];
    tempConn=[];
    Connections=[];
    tempConnBias=[];
    clear allrun
        
    cd('../');
end

rmpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'ANN']);