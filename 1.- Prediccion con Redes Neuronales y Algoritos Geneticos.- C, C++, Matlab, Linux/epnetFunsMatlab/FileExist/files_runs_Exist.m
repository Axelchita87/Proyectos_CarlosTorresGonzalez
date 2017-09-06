%script to determinate if the files form runs exis
clear
clc

%directori to work
dir1 = 'TSEPnet62';

%how many runs there must be
exps = 35;
cd('..');
cd('..');
load TS
cd(dir1);
existfiles = zeros(21,exps);

for i=1:21
    cd(TS{1,i})
    cd('res')
    for j=1:exps
        file = ['r',num2str(j),'ALLNum.txt'];
        if (exist(file,'file'))
            existfiles(i,j) = 1;
        end
    end
    cd('..');
    cd('..');
end
