% Script to determinate if there are NaN values in the experiments

%average over all generations
clear
clc

%Directory to work
dir1 = 'TSEPnet57Cb';

cd('..'); 
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
              
        %code to analyse in numeric format the minimim and maximum
        
        %Hybrid training
        Variables{TSdir,1}(i,1) = min(allrun{1,i}.ALLParam.Avhybridtraining);
        Variables{TSdir,1}(i,2) = max(allrun{1,i}.ALLParam.Avhybridtraining);
        %Error
        Variables{TSdir,1}(i,3) = min(allrun{1,i}.ALLParam.AvIterateNRMS_I);
        Variables{TSdir,1}(i,4) = max(allrun{1,i}.ALLParam.AvIterateNRMS_I);
        %Inputs
        Variables{TSdir,1}(i,5) = min(allrun{1,i}.ALLParam.Avinputs);
        Variables{TSdir,1}(i,6) = max(allrun{1,i}.ALLParam.Avinputs);
        %Connec
        Variables{TSdir,1}(i,7) = min(allrun{1,i}.ALLParam.Avconnections);
        Variables{TSdir,1}(i,8) = max(allrun{1,i}.ALLParam.Avconnections);
        %Hidden
        Variables{TSdir,1}(i,9) = min(allrun{1,i}.ALLParam.Avhidden);
        Variables{TSdir,1}(i,10) = max(allrun{1,i}.ALLParam.Avhidden);
        
        VarIsNan(TSdir) = sum(sum(isnan(Variables{TSdir,1})));
        
        
    end
    clear allrun
    
   clear TSname 
end






