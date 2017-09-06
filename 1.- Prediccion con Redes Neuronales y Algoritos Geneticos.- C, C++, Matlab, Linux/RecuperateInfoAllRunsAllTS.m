%File to Recuperate all the information from each run in C, the final file is 
%in res/ directory and contain a file called allrun.mat with contian all the 
%runs per TS 

clear
clc


ExpectedCorrida = 30;
file = 'r';
 
pathExp = pwd;        %main dir for this Exp.
cd('epnetFunsMatlab'); cd('LinuxOrWindows')
%use adecuate paht
SLASH = isLinOrWin();
cd('..');
cd('..');

path1 = pwd;        %main dir
cd(pathExp);
%add path for used funtions
addpath([pathExp, SLASH, 'epnetFunsMatlab',SLASH,'recuperateInfoCpp']);
addpath([pathExp, SLASH, 'epnetFunsMatlab',SLASH,'DeleteFiles']);

%load the file with the names of the TS to use
load TS.mat

sizeTS = size(TS,2);

% in case you do not want to run one exp 
%norun = 0;

for TSdir = 1:sizeTS
    % enter dir
    cd( [pathExp, SLASH, TS{1,TSdir} ] );
    
    % disp name dir
    display( TS{1,TSdir} );
    
    % recuperate infomariton
    run recuperateInfoCpp
    
end



%% Clean the directory
% after recuperate the information it is clean the directory, if there were
% error, e.g. is missing one run or bad formatting of the file, it is not
% reached this part, so anything is deleted.


  cd(pathExp)
   run deleteO_E_Cfiles
  
   run delete_Results_C_and_txt_files



%% Plot figures from this experiment only
% figure like two line of differetn exps is executed independently


cd(pathExp)
run PlotAllFigsAllTS



%% delete paths added

rmpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'recuperateInfoCpp']);
rmpath([pathExp, SLASH, 'epnetFunsMatlab',SLASH,'DeleteFiles']);
