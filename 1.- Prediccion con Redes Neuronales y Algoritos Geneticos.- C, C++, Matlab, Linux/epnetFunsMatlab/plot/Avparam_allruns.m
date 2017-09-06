% Script to plot to average figures form one exp. e.g. Avhybrid trainig
% plot one figure per run

%average over all generations
clear
clc

%Directory to work
dir1 = 'TSEPnet57Cb';

cd('..');           %exit plot
cd('LinuxOrWindows')
%use adecuate paht
slash2use = isLinOrWin();
cd('..');
cd('..');
path1 = pwd;        %main dir for Exps

%load the TS
load TS.mat


sizeTS = size(TS,2);
%format HybridT(1-2) Error(3-4) Inp(5-6) Conn(7-8) Hidden(9-10)
Variables{sizeTS,1} = zeros(1,10);
VarIsNan = zeros(sizeTS,1);

for TSdir =[1:21]         %for all TS
% for TSdir =[1:10 12:21]         %for all TS
    dir{1,1} = [path1,slash2use,dir1,slash2use,TS{1,TSdir}];
    
    
    cd(dir{1,1});
    
    %obtain name of the TS
    fid = fopen('TSname.txt', 'r');
    TSname = fgetl(fid);
    if (fclose(fid) ~= 0)
        'error closing file'
    end
    
    cd('res');
    %load file
    load allrun.mat
    
    for i=1:30
        
        %Code to plot
        
        plot(allrun{1,i}.ALLParam.Avhybridtraining, 'DisplayName', 'allrun{1,1}.ALLParam.Avhybridtraining', 'YDataSource', 'allrun{1,1}.ALLParam.Avhybridtraining'); figure(gcf)
        ylabel('Average Hybrid Training','FontSize',12)
        
        xlabel('Generations','FontSize',12)
        string2title = ['\it{',TSname, ' run', num2str(i),'}'];
        title(string2title,'FontSize',16');
        
        clf %put the break here
                
    end
    clear allrun
    
   clear TSname 
end






