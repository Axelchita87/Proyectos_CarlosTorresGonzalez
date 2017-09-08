%% Test the new exponential function
% Script to see waht could be expected form it
%
% Small code to test how behavied the new exponential funtion
% Here is used just one input from 10 and simulate the connectivity for
% 1000 hidden nodes, analising the probabilities gives can gice
% a hint of waht it will be expected in a norma ANN
% for for sigma
%
% In this case I will test what happend if there are 10 inputs and 10
% hidden nodes
%
%
% Created       11 Nov 2010
% Modified at:
% Author:       Carlos Torres and Victor Landassuri
%



clear
clc

p = 1;
for Sig = 0.1:0.1:1
    for i = 1:10
        RES1(p,i) = localConnS(1,i,10, 10,Sig);
    end
    p = p + 1;
end

% check the input 5 from 10 nodes for 1000 hidden nodes
p = 1;
for Sig = 0.1:0.1:1
    for i = 1:10
        RES5(p,i) = localConnS(5,i,10, 10,Sig);
    end
    p = p + 1;
end

% Plot all the pack in one plot, two plots at the end
clf
vecStile{1,1} = '-';
vecStile{2,1} = '--';
vecStile{3,1} = '.';
vecStile{4,1} = '-';
vecStile{5,1} = '-';
vecStile{6,1} = '-';
vecStile{7,1} = '-';
vecStile{8,1} = '-';
vecStile{9,1} = '-';
vecStile{10,1} = '-';

%for the  forst input
for i = 1:10
    h = plot(RES1(i,:),'-b','LineWidth',1);
    hold all
end

% for the input 5
for i = 1:10
    h = plot(RES5(i,:), '--k','LineWidth',1);
    hold all
end

% 
% legend(...
% '\sigma_{inp} = 0.1', ...
% '\sigma_{inp} = 0.2', ...
% '\sigma_{inp} = 0.3', ...
% '\sigma_{inp} = 0.4', ...
% '\sigma_{inp} = 0.5', ...
% '\sigma_{inp} = 0.6', ...
% '\sigma_{inp} = 0.7', ...
% '\sigma_{inp} = 0.8', ...
% '\sigma_{inp} = 0.9', ...
% '\sigma_{inp} = 1.0');
xlabel('Hidden nodes','FontSize',12);
ylabel('Connectivity','FontSize',12);
%title('','FontSize',16);

saveas(h,['ConnectiviyLocalConnSheme10y10.fig'])
