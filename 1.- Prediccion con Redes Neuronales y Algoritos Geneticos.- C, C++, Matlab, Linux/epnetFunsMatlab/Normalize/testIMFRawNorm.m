%testIMFnorm.m
%Created: 11/02/10

%script to test if it is used raw data or normalized data generate the same
%IMFS

%The function used mapminmax1.m comes form the function programed in the
%EPNet6 over matlab

%Runt hte file from directory where is the TS, there must be the files not
%normalized from the data

clear
clc

load datainput.txt;
load dInputIMFin.txt;
load dInputIMFout.txt;

%now data input is not normalized, normailez it and obtain IMFs
%this fun accep a row vertor

%obtain IMF with 1940 and 1970 values to have a valid compariosn
datain = datainput(1:1940,:)';
dataout = datainput(1:1970,:)';

[dataINn, PSdataINn] = mapminmax1(datain);
[dataOUTn, PSdataOUTn] = mapminmax1(dataout);

IMFinn = emd(dataINn');
IMFoutn = emd(dataOUTn');

%accomodate with the same format as the dInputIMFin / out

dInputIMFinN(:,1) = dataINn';
dInputIMFinN(:,2:size(IMFinn,1)+1) = IMFinn';
%the same for the output
dInputIMFoutN(:,1) = dataOUTn';
dInputIMFoutN(:,2:size(IMFoutn,1)+1) = IMFoutn';


% now i is needed to normalize the original sets, and see if it is obtained
% the same values

Din = dInputIMFin;
%Dout = dInputIMFout;

for i = 1:size(Din,2)
    [DinN(i,:), PSDinN] = mapminmax1(Din(:,i)');
%    [DoutN(i,:), PSDoutN] = mapminmax1(Dout(:,i)');
end

DinN = DinN';
%DoutN = DoutN';

%Ihave seen the sets dInputIMFin and dInputIMFinN and they are the same
%plotted, now I am interested to plot dInputIMFinN and DinN


%now plot them, first the inside set
lines = size(dInputIMFinN,2)
col = 2;
clf
cont = 1;
for i=1:lines
    subplot(lines,col,cont), plot(DinN(:,i), 'LineWidth',1);
    if(i==1)
        title('Original raw','FontSize',12)
    elseif(i~=lines)
        string = ['IMF ', num2str(i-1)];
        ylabel(string,'FontSize',12)
    else
        string = ['Residuo'];
        ylabel(string,'FontSize',12)
    end
    cont = cont +2;
end

%now plot the normailez data in the second column
cont = 2;
for i=1:lines
    subplot(lines,col,cont), plot(dInputIMFinN(:,i), 'LineWidth',1);
    if(i==1)
        title('Original Normalized','FontSize',12)
    elseif(i~=lines)
        string = ['IMF ', num2str(i-1)];
        ylabel(string,'FontSize',12)
    else
        string = ['Residuo'];
        ylabel(string,'FontSize',12)
    end
    cont = cont +2;
end

%now what happen if it is caculated the origianl signal, is not any lost of
%information?
sumDinN = zeros(size(DinN,1),1);
sumdInputIMFinN = zeros(size(DinN,1),1);;
for i=2:lines
    sumDinN = sumDinN + DinN(:,i);
    sumdInputIMFinN = sumdInputIMFinN + dInputIMFinN(:,i);
end

%rest them
rest1 = sumDinN - DinN(:,1);
rest2 = sumdInputIMFinN - dInputIMFinN(:,1);



