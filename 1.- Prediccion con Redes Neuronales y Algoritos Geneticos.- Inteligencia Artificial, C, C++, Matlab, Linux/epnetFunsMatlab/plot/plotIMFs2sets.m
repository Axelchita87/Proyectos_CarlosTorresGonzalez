%plotIMF2sets.m
%script to load the imfs form the inside and outside set and plot them in a
%figure
%Created: 9/02/10


clear
clc

load dataInputN.txt;
load dInputIMFinN.txt;
load dInputIMFoutN.txt;
load columnsIMFN.txt

datainput = dataInputN;
dInputIMFin = dInputIMFinN;
dInputIMFout = dInputIMFoutN;
columnsIMF = columnsIMFN;

%discover how many lines and cols, will have the subplot, I plot IMFs
%inside and outside in the same plot
[C,I] = max(columnsIMF);

lines = C;
col = 2;
cont = 1;
clf;
%Not print the original data
for i=2:columnsIMF(1,1)
    %first IMFinside
    subplot(lines,col,cont), plot(dInputIMFin(:,i));
    cont = cont + 2;
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
cont = 2;
for i=2:columnsIMF(1,2)
    %first IMFinside
    subplot(lines,col,cont), plot(dInputIMFout(:,i));
    cont = cont + 2;
end

%% the next part can be commented (rune each block with F9)
%  To plot the last IMFs form one set, and the last from the bigger set and
%  the sum of the two lst from the bigger set. Used to see if there is too
%  much difference in when two IMFs are put together

% when the in set is bigger

plot(dInputIMFout(1:1970,size(dInputIMFout,2)-1), 'DisplayName', 'dInputIMFin(1:1940,size(dInputIMFin,2)-1)', 'YDataSource', 'dInputIMFin(1:1940,11)'); figure(gcf)
figure
plot(dInputIMFout(1:1970,size(dInputIMFout,2)), 'DisplayName', 'dInputIMFin(1:1940,12)', 'YDataSource', 'dInputIMFin(1:1940,12)'); figure(gcf)
figure
plot(dInputIMFin(1:1940,size(dInputIMFin,2)), 'DisplayName', 'dInputIMFout(1:1970,13)', 'YDataSource', 'dInputIMFout(1:1970,13)'); figure(gcf)
figure
newfig = dInputIMFin(:,size(dInputIMFin,2)-1) + dInputIMFin(:,size(dInputIMFin,2));
plot(newfig, 'DisplayName', 'ans', 'YDataSource', 'ans'); figure(gcf)
close Figure 1
close Figure 2
close Figure 3
close Figure 4

% when the out set is bigger
plot(dInputIMFin(1:1940,size(dInputIMFin,2)-1), 'DisplayName', 'dInputIMFin(1:1940,11)', 'YDataSource', 'dInputIMFin(1:1940,11)'); figure(gcf)
figure
plot(dInputIMFin(1:1940,size(dInputIMFin,2)), 'DisplayName', 'dInputIMFin(1:1940,12)', 'YDataSource', 'dInputIMFin(1:1940,12)'); figure(gcf)
figure
plot(dInputIMFout(1:1970,size(dInputIMFout,2)), 'DisplayName', 'dInputIMFout(1:1970,13)', 'YDataSource', 'dInputIMFout(1:1970,13)'); figure(gcf)
figure
ans = dInputIMFout(:,size(dInputIMFout,2)-1) + dInputIMFout(:,size(dInputIMFout,2));
plot(ans, 'DisplayName', 'ans', 'YDataSource', 'ans'); figure(gcf)
close Figure 1
close Figure 2
close Figure 3
close Figure 4

