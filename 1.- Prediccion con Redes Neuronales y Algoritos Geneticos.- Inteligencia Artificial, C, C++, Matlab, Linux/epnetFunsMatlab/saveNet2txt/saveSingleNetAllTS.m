% Scritp to save a single network for all TS in a directory
% saveSingleNetAllTS.m
% Created: 15/02/10
% Updated 20/05/10
% Carlos Torres and Victor Landassuri

% the best network from each run is saved in an independetn file
% later, it will be recuperated with the c++ code to do another experiments
% with this evolved networks

% BE aware that the file to recuperate the information need the header file
% mainepnet.hpp to setuop all previous variables, then is read this info
% over the networks created

%Order to save the variables
%Input, final input, delays, hidden, outputs, CW, W, nodes, bias, posinputs, poshidden, sizepos,
%momentum, lrate and Flag = -1

% the Flag is used to detect error when reading

clear
clc

%file to save
dir2save = 'resBestNet';


% It is assumed that the directory to work is the one that holds this file
cd('..'); cd('..'); 
dir = pwd;      
name2save = 'bestN';

%Section to determinate with OS is running 
cd('epnetFunsMatlab'); 
cd('LinuxOrWindows')
%use adecuate paht
slash2use = isLinOrWin();

cd(dir);
load TS.mat
sizeTS = size(TS,2);

for Exp=1:sizeTS
    
    allrun = [];
    cd([TS{1,Exp},slash2use,'res'])
    load allrun
        
    for corrida=1:size(allrun,2)
        
       if(exist(['..', slash2use, dir2save], 'dir') ~= 7)
            mkdir(['..', slash2use, dir2save])
       end
        
       filename = ['..', slash2use,dir2save,slash2use,name2save,int2str(corrida),'.txt'];
       
       % call function 
       
       saveSingleNet2file(filename, allrun{1,corrida}.Network);     % I have not check that this script work, check it
        
    end %end corrida
    cd('..'); cd('..')
end
