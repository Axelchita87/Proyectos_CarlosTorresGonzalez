% delete all txt files form the results given by C 
%run this script after the results are gatered in a mat file 'allrun.mat'
clear
clc
%enter dorectory to work
dir1 = 'MEPNet02e';

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

cd('..');   cd('LinuxOrWindows');
%use adecuate paht
slash2use = isLinOrWin();
cd('..');  cd('..');
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

path1 = pwd;        %main dir for Exps


cd(dir1);
load TS.mat
sizeTS = size(TS,2);
for i=1:sizeTS
    cd([TS{1,i},slash2use,'res']);
    %to delete the matfiles
    %       delete('*.mat')
    
    delete('*.txt*')
    delete('*.TXT')
    [stat, mess]= rmdir('res1','s');
    
    cd('..');
    
    % res2
    cd('res2');
    delete('*.txt*')
    delete('*.TXT')
    [stat, mess]= rmdir('res1','s');
    cd('..');
    
    % res3
    cd('res3');
    delete('*.txt*')
    delete('*.TXT')
    [stat, mess]= rmdir('res1','s');
    cd('..');
    
    
    cd('..');
end
'Done :) ...'