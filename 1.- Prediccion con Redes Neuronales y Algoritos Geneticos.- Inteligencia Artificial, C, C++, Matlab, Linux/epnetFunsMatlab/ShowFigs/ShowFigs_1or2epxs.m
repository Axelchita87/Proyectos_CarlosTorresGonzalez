%scrip to open the figues of a given experiment, for 1 or more exps
%first is opne all the figuers form all TS for one exp and then the other
%exp.

%comment 1 directory and the figuers not required

clear
clc


dir{1,1} = 'classEPNetinitAa';
% dir{1,2} = 'TSEPnet22C';
%dir{1,3} = 'TSEPnet35C';


%figures to show, UNCOMENT THE NEXY IF YOU WANT SELECTED FIGURES

%They are divided into two blocks to facilitate the analysis
% figure{1,1} = 'WorstAvBest_fitness.fig';
% figure{1,2} = 'AverageWorstAvBest_fit.fig';
% figure{1,3} = 'FitnessAllPop_bestInd.fig';
% figure{1,4} = 'AveragePopulationFitness.fig';

% figure{1,1} = 'AverageMutations.fig';
% figure{1,2} = 'AverageNRMS.fig';
% figure{1,3} = 'Averageinputs.fig';
% figure{1,4} = 'Averagehidden.fig';
% figure{1,5} = 'AverageConn.fig';

figure{1,1} = 'BestPred.fig';

cd('..'); 
cd('LinuxOrWindows')
%use adecuate paht
slash2use = isLinOrWin();
cd('..');cd('..');

path1 = pwd;        %main dir for Exps
cd(dir{1,1});
load TS.mat;

sizeFig = size(figure,2);
sizeDir = size(dir,2);
sizeTS = size(TS,2);

for exp=1:sizeDir
    cd([path1,slash2use,dir{1,exp}]);
    
    % Comment this if you do nto want all figures
    s = dir;
    s(1) = [];
    s(1) = [];
    sizeTS = size(s);
    
    for TSdir=1:sizeTS
        cd([TS{1,TSdir}, slash2use, 'figs_fig']);        %enter TS
        for Fig=1:sizeFig
            file = eval(['figure{1,',num2str(Fig),'}']); 
            eval(['open',' ',file]);
            close Figure 1;  % to put a break here
        end
        cd('..');
        cd('..');
    end
end
