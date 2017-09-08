%
% Script to plot the IMF from 2 different TS
%Created 10/02/10

%you should be in the main directory of the experiment, e.g 63v1
clear
clc

direxp{1,1} = 'ChaosMGLOaverage';
direxp{1,2} = 'ChaosMGLOdiff';

basePath = pwd;

cd('..'); cd('FunsMatlab');

%Section to determinate with OS is running 
cd('LinuxOrWindows')
%use adecuate paht
slash2use = isLinOrWin();
cd('..');  cd('..');

cd(basePath);
clf;

for exp = 1:2     
    cd(direxp{1,exp})
    
    %obtain name of the TS
    fid = fopen('TSname.txt', 'r');
    TSname = fgetl(fid);
    
    cd('txtFiles');
    dInputIMFout = [];
    
    load dInputIMFout.txt;
    load columnsIMF.txt
    
    eval(['IMF', num2str(exp), '= dInputIMFout;']);
    eval(['colum' num2str(exp), '= columnsIMF;']);
    eval(['TSname' num2str(exp), '= TSname;']);
    
    cd('..')
    cd('..')

end

    %discover how many lines and cols, will have the subplot, I plot IMFs
    %inside and outside in the same plot

    col2sets = [colum1(1,2), colum2(1,2)];
    [C,I] = max(col2sets);
    
    
    lines = C;
    col = 2;
    cont = 1;
        
    for i=1:colum1(1,1)
        subplot(lines,col,cont), plot(IMF1(:,i),'LineWidth',1);
        cont = cont + 2;
        if(i==1)
            title(TSname1,'FontSize',12)
        elseif(i~=colum1(1,2))
            string = ['IMF ', num2str(i-1)];
            ylabel(string,'FontSize',12)
        else
            string = ['Residuo'];
            ylabel(string,'FontSize',12)
        end
    end
    
    
    cont = 2;
        
    for i=1:colum2(1,1)
        subplot(lines,col,cont), plot(IMF2(:,i),'LineWidth',1);
        cont = cont + 2;
        if(i==1)
            title(TSname2,'FontSize',12)
        elseif(i~=colum2(1,2))
            string = ['IMF ', num2str(i-1)];
            ylabel(string,'FontSize',12)
        else
            string = ['Residuo'];
            ylabel(string,'FontSize',12)
        end
    end
    

