%% Delete all txt files form the results given by C 
%run this script after the results are gatered in a mat file 'allrun.mat'

%%
% uncoment all this block if you want to run this file from its folder and
% not from the main experiment

% clear
% clc
% 
% %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% cd('..');   cd('LinuxOrWindows');
% %use adecuate paht
% SLASH = isLinOrWin();
% cd('..');  cd('..');
% %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% 
% load TS.mat
% sizeTS = size(TS,2);


for i=1:sizeTS
    cd([TS{1,i},SLASH,'res']);
        %to delete the matfiles
%       delete('*.mat')
        
        delete('*.txt')
        delete('*.TXT')
        [stat, mess]= rmdir('res1','s');
              
    cd('..');
    %delete ejecutable file
    delete('mainepnet')
    cd('..');
end
display('Deleted C and txt files from runs. Done :) ...');