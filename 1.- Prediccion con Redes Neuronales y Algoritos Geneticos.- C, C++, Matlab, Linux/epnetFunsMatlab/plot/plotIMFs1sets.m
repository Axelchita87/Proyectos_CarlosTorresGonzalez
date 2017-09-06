%plotIMF1sets.m
%script to load the imfs form a set and print them out with the raw data
%Created: 10/02/10


clear
clc

cd('..')
%obtain name of the TS
fid = fopen('TSname.txt', 'r');
TSname = fgetl(fid);

cd('txtFiles')

load datainput.txt;
load dInputIMFin.txt;
load dInputIMFout.txt;
load columnsIMF.txt

%plot only the output set.

lines = columnsIMF(1,2);
col = 1;
clf;

for i=1:columnsIMF(1,2)
    subplot(lines,col,i), plot(dInputIMFout(:,i), 'LineWidth',1);
    if(i==1)
        ylabel(TSname,'FontSize',12)
    elseif(i~=columnsIMF(1,2))
        string = ['IMF ', num2str(i-1)];
        ylabel(string,'FontSize',12)
    else
        string = ['Residuo'];
        ylabel(string,'FontSize',12)
    end
end
'foo';