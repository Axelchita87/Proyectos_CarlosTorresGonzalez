% Script to plot a TS in different scales
% run with f9

clear
clc


load dataInputN1.txt
load dataInputN2.txt
load dataInputN3.txt
load dataInputN4.txt
load dataInputN5.txt
load dataInputN6.txt
load dataInputN7.txt

plot(dataInputN1(1:2000,1))
hold all
plot(dataInputN7(1:2000,1))


%plot(dataInputN5(1:2000,1))
%plot(dataInputN3(1:2000,1))

%% This part is used to calculate the correlation  betwwen the scales

for i=1:7
    for j=1:7
        Correla(i,j) = eval(['corr2(dataInputN', num2str(i),',dataInputN',num2str(j),')']);
    end
end
% as expected, the correlation is 1 compared against any other scale