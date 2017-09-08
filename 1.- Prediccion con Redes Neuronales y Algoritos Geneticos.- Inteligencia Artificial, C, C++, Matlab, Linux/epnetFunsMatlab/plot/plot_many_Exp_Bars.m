%% Plot Bar figures with error bars
% Script to plot the bar figures for 1 expeirments with many repetitions or
% many experiments with many repetitions, e.g. exp repeated with 0.1, 0.2,
% ..., 1.0 in the connectivity.
%
% Or
% Exp 1: 0.1:1.0 for conenctiviry
% Exp 2: 0.1:1.0 for conenctivity
% ,..., and so on
%
% plot av, std or ste as selected 
%
% If there is only one Exp with many repetitions, then it could be plotted
% with lines too.
%
% Defenition:
%   Experiment: Any experiment that was repeated with different values.
%   each of this repettions will be the x axis
%   Many Exp: an 'Experiment' that was tested with another vaiable. Those
%   values indicate how many columns will be in each element of the x axis.
%
% Created:  25 Mar 2011
% Modified: 26 Jul 2011
% Author:   Carlos Torres and Victor Landassuri


clear
clc



%% Set up Variable


% Directories for the same kind of experiment whit their repetition
% Those values are put in each row
% The number of rows determinate the number of elements in x
% The number of blocks indicate how many elements pers element in x is
% compared
dir0{1,1} = 'epnet_025';   
dir0{2,1} = 'epnet_037';   
dir0{3,1} = 'epnet_050';
dir0{4,1} = 'epnet_062';
dir0{5,1} = 'epnet_075';
dir0{6,1} = 'epnet_087';
dir0{7,1} = 'epnet_100';

% dir0{8,1} = 'GMLP_ICS';
% dir0{9,1} = 'classEPNetinitDa';
% dir0{10,1} = 'classEPNetinitDb';

% directories for second repetitions with other parameters
% Those correspond to each column
dir0{1,2} = 'Mepnet_025';   
dir0{2,2} = 'Mepnet_037';   
dir0{3,2} = 'Mepnet_050';
dir0{4,2} = 'Mepnet_062';
dir0{5,2} = 'Mepnet_075';
dir0{6,2} = 'Mepnet_087';
dir0{7,2} = 'Mepnet_100';

% third Block
% dir0{1,3} = 'GMLP_87';
% dir0{2,3} = 'GMLP_100';
% dir0{3,3} = 'GMLP_ICS';

% Dir to save
dir2save = '/media/dat/DocthesisPhDExps/MNN/similarTasks2/class/connNOConstrained/figs_BarsInside_STD_All';

% What to plot, Average, Error bar with STD or STE
typePlot = 'STD';                 % options:: AV, STD, STE

% Plot lines or columns (only for one exp)
%plotLines = 0;                      % 1 use it
                                    % 0 not use it

% Take the values from the test set inside or the final test set.
% If it is inside it takes the values from the last generation
where2take = 'outside';              % inside or outside
                                    % nat that if the generations were not
                                    % fixed it does not have too much sense
                                    % to look for the fig inside as it will
                                    % be misleading, i.e. some runs finish
                                    % before than others
                                    
bestORav = 'best';                     % 'best' or 'av' --> take the best values or the average per population
                                       % only for outside, in theory only I should use the best, to take the mean of the best as done in tables
                                       
% Leyend (for each Experiment, columns in each block)
legendM{1,1} = 'EPNet';
legendM{2,1} = 'M-EPNet';
% legendM{3,1} = 'C';

% X ticks (for each repetition)
% X ticks (for each repetition)
xTicksL = {'','0.25','0.37','0.50','0.62','0.75','0.87','1.0'}; % for lines
%xTicksL = {'','30','50','70'}; % for lines

% xTicks = {'','0.25','','0.37','','0.50','','0.62','','0.75','','0.87','','1.0'}; % for bars
% xTicksL2 = {'0.25','','0.37','','0.50','','0.62','','0.75','','0.87','','1.0'};% used for special figs with lines
 xTicks = {'','0.25','0.37','0.50','0.62','0.75','0.87','1.0'}; % for lines
 xTicksL2 = {'','0.25','0.37','0.50','0.62','0.75','0.87','1.0'}; % for lines
%xTicks = {'','30','','50','','70'}; % for lines
%xTicksL2 = {'','30','50','70'}; % for lines
%xTicksTMP = {'','0.25','0.37','0.50','0.62','0.75','0.87','1.0'}; 

labelX = 'Connectivity';


% F i n i s h   t h e   v a r i a b l e s   t o   c o n f i g u r e 






%% Add required paths

% add path ANN
cd('..'); cd('ANN'); pathA = pwd; addpath(pathA);

cd('..');
cd('LinuxOrWindows')
%use adecuate paht
SLASH = isLinOrWin();
cd('..');
% For the individual scripts to plot
cd( [ 'plot', SLASH, 'scriptsBars' ] );
pathB = pwd; addpath(pathB);
cd('..'); cd('..'); cd('..');


%load the TS
load TS.mat

cd('..');
path1 = pwd;        %main dir for Exps


%% Set up variables
lineType                                    % script

sizeDir = size(dir0,1);
sizeDirCol = size(dir0,2);

% create a vector to for the x values of plots (repettions)
xVals = 1:sizeDir;
% flag to determinate if it is classification or not
%flagClass = 0;


for TSdir = 1:size(TS,2)         %for all TS
    
    %accomodate the directories
    for i = 1:sizeDir
        for j = 1:sizeDirCol
            dir{i,j} = [path1,SLASH,dir0{i,j},SLASH,TS{1,TSdir}];
        end
    end
    
    for i = 1:sizeDir           %directory = 1:sizeDir %for all exp.
        for j = 1:sizeDirCol
            cd(dir{i,j});
        
            %obtain name of the TS
            if i == 1
                fid = fopen('txtFiles/TSname', 'r');
                TSname = fgetl(fid);
                if (fclose(fid) ~= 0)
                    'error closing file'
                end
            end
            cd('res');
            %load file
            load allrun.mat
            
            corrida = size(allrun,2);
            generation = obtainMinGen(allrun, corrida);
            
            % Obtain the average param with Av, std and ste
            info{i,j} = obtainAvStdSte(allrun, SLASH,bestORav, 1,1,1,'bars');
            
            
            clear allrun
        end
    end
    
    %% obtain the values to plot
    obtainFormattedVal_Bars
    
    %Change to the dir to save figs
    if(exist(dir2save, 'dir') ~= 7)
        mkdir(dir2save)
    end
    cd(dir2save);
    
    % select what to plot in
     plotALLfigsBars
    
    
    
    
    
    %% Seciton for spacial functions
    % MArch and Mweight
    % fitness per module
    % classfication error per module
    % nodes per module
    
    
    % New directory to save them, inside of the actual
    if(exist('specLine', 'dir') ~= 7)
        mkdir('specLine')
    end
    
    if(exist('specBar', 'dir') ~= 7)
        mkdir('specBar')
    end

    plotALLfigsSpecialBars

    
    
    

    clear TSname
end

close all

rmpath(pathA);
rmpath(pathB);

display ( 'Finisgh to plot bar figures :) ' )
