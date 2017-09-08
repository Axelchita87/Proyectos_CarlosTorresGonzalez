%delete all the files from the results of C, figures and executable

clear
clc

%enter directory to work
%dir1 = 'MEPNet04a';

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
cd('..');   cd('LinuxOrWindows');
%use adecuate paht
slash2use = isLinOrWin();
cd('..');  cd('..');
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%path1 = pwd;        %main dir for Exps

%cd(dir1);
load TS.mat
sizeTS = size(TS,2);


for i=1:sizeTS
    cd([TS{1,i},slash2use,'res']);
    
    delete('*');
    delete('*.*');
    [stat, mess]= rmdir('res','s');
    
    cd('../');
    
    if (exist('resPop') == 7)
        cd('resPop')
        delete('*.*');
        cd('../');
    end
    
    
    % Section for the Figure directories
    if (exist('figs_fig') == 7)
        cd('figs_fig')
        delete('*.*');
        cd('../');
    else
        mkdir('figs_fig');
    end
    
    if (exist('figsErrorB_fig') == 7)
        cd('figsErrorB_fig')
        delete('*.*');
        cd('../');
    end
    
    if (exist('figsErrorB_HALF_fig') == 7)
        cd('figsErrorB_HALF_fig')
        delete('*.*');
        cd('../');
    end
    
    if (exist('figsHALF_fig') == 7)
        cd('figsHALF_fig')
        delete('*.*');
        cd('../');
    end
    
    if (exist('figs_module1') == 7)
        cd('figs_module1')
        delete('*.*');
        cd('../');
    end
    
    %delete ejecutable file
    delete('mainepnet')
    cd('../');
end