%File to plot all figures for all TS in this Experiments

% uncoment all this block if you want to run this file from its folder and
% not from the main experiment

clear
%clc

cd('epnetFunsMatlab');  cd('LinuxOrWindows');
%use adecuate paht
SLASH = isLinOrWin();
cd('..');  cd('..');


% What to plot, 1 yes, 0 not to plot
run_drawANN = 1;            % first code to plot ANNs
run_drawANNmodules = 1;     % code for MNN (plot the ANN with shared modeules
% and plot it with the husken modularity)

run_averageParamHALF = 0;
run_averageParamErrorBarsHALF = 0;

% Enter to global dir of matlab functions

pathExp = pwd;        %main dir for this Exp.


%add local path for used funtions (specifict functions for each exp)
addpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'plotPerRun']);
addpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'plot', SLASH, 'scripts']);
addpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'draw']);
addpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'ANN']);
addpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'Error']);

%cd(pathExp);
load TS.mat
sizeTS = size(TS,2);


%% Set up variables
lineType


for TSdir = 1:sizeTS
    cd([pathExp,SLASH,TS{1,TSdir}]);
    display( TS{1,TSdir} );
    %enter to load data
    
    if(exist(['res', SLASH, 'allrun.mat'],'file') == 2)
        
        load (['res', SLASH, 'allrun.mat']);
        
        %load the name of the TS
        fid = fopen(['txtFiles', SLASH, 'TSname'], 'r');
        TSname = fgetl(fid);
        if (fclose(fid) ~= 0)
            display('error closing file');
        end
        
        corrida = size(allrun,2);
        generation = obtainMinGen(allrun, corrida);
        
        
        % obtain the av, std and ste for all values
        info{1,1} = obtainAvStdSte(allrun,SLASH, 'av',1, 1, 1);
        
        
        %% CALL PLOT FUCTIONS
        % Only is called and plotted the required figures given the
        % experiments
        
        %Best results from the last generation
        run plotBestPred_accuracy
        
        % Ensembles (GECCO 2009 paper)
        if allrun{1,1}.var.RunEnsemble == allrun{1,1}.C.ON
            run utileries2plotEnsemble
        end
        
        % Plot the Average parameters per generation is average, standard
        % deviation and standard error (Error bars)
        run averageParam
        
        if run_averageParamHALF == 1
            run averageParamHALF
        end
        
        if run_averageParamErrorBarsHALF == 1
            run averageParamErrorBarsHALF
        end
        
        %Plot the normal network
        if run_drawANN == 1 
            drawANN(allrun, corrida,pathExp,SLASH, TSname)
        end
        
        % Plot modules using the modularity, the modularity is calculated
        % with a matlab code, not from the C code but it is the same
        if run_drawANNmodules == 1
            run drawANNmodules      % Draw trhe ANN with husken modules and with shared module
        end
        
        clear allrun
        
        cd('..');
        close all
    end
end

% close all figures opened


% Remove the path added
rmpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'draw']);
rmpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'plotPerRun']);
rmpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'plot', SLASH, 'scripts']);
rmpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'ANN']);
rmpath([pathExp,SLASH,'epnetFunsMatlab',SLASH,'Error']);