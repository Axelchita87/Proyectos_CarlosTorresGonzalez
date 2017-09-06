%% Plot Average values per generation
% Script to plot the average values per generation for all TS
% plot av, std or ste as selected for 1 or many directories
%
% Created:  somewhen between 2008 and 2010
% Modified: 21 Feb 2011
% Author:   Carlos Torres and Victor Landassuri

%average over all generations
clear
clc



%% Set up Variable

dir0{1,1} = 'workspace';   %blue line -put here the Exp that mut be better
dir0{2,1} = 'workspace';   %Red line
% dir0{3,1} = 'stp70';
% dir0{4,1} = 'stp30SA';
% dir0{5,1} = 'stp50SA';
% dir0{6,1} = 'stp70SA';
% dir0{4,1} = 'classEPNetinitFdb';
% dir0{7,1} = 'classEPNetinitCa';
% dir0{8,1} = 'classEPNetinitCb';
% dir0{9,1} = 'classEPNetinitDa';
% dir0{10,1} = 'classEPNetinitDb';


% Dir to save
dir2save = '/media/dat/workspace/figsDELETE';

% What to plot, Average, Error bar with STD or STE
typePlot = 'STD';                 % options:: AV, STD, STE

% Leyend
legendM{1,1} = 'STP = 30';
legendM{2,1} = 'STP = 50 ';
% legendM{3,1} = 'STP = 70';
% legendM{4,1} = 'STP = 30 SA';
% legendM{5,1} = 'STP = 50 SA';
% legendM{6,1} = 'STP = 70 SA';

% legendM{3,1} = 'C';


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
cd( [ 'plot', SLASH, 'scripts' ] );
pathB = pwd; addpath(pathB);
cd('..'); cd('..'); cd('..');


%load the TS
load TS.mat

cd('..');
path1 = pwd;        %main dir for Exps


%% Set up variables
lineType                                    % script

sizeDir = size(dir0,1);

% flag to determinate if it is classification or not
%flagClass = 0;


for TSdir = 1:size(TS,2)         %for all TS
    
    %accomodate the directories
    for alldir=1:sizeDir
        dir{1,alldir} = [path1,SLASH,dir0{alldir,1},SLASH,TS{1,TSdir}];
    end
    
    
    for directory = 1:sizeDir %for all exp.
        cd(dir{1,directory});
        
        %obtain name of the TS
        if directory == 1
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
        
        % Obtain the average param
        if strcmp(typePlot, 'AV')
            info{1,directory} = obtainAvStdSte(allrun,SLASH,'av', 1,0,0);
        elseif strcmp(typePlot, 'STD')
            info{1,directory} = obtainAvStdSte(allrun, SLASH,'av',1,1,0);
        elseif strcmp(typePlot, 'STE')
            info{1,directory} = obtainAvStdSte(allrun, SLASH,'av',1,1,1);
        end
        
        clear allrun
    end
    
    
    %Change to the dir to save figs
    if(exist(dir2save, 'dir') ~= 7)
        mkdir(dir2save)
    end
    cd(dir2save);
    
    
    
    % select what to plot in 
    plotALLfigs 
    

    clear TSname
    
    
end

close all

rmpath(pathA);
rmpath(pathB);

display ( 'Finisgh to plot average figures per generation :) ' )
