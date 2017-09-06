%% Test the new exponential function non-normalized
% Script to see waht could be expected form it
%
% Small code to test how behavied the new exponential funtion
% Here is used just one input from 10 and simulate the connectivity for
% 1000 hidden nodes, analising the probabilities gives can gice
% a hint of waht it will be expected in a norma ANN
% for for sigma
%
% Created       11 Nov 2010
% Modified at:
% Author:       Carlos Torres and Victor Landassuri
%



clear
clc

p = 1;
for Sig = 0.1:0.1:1
    for i = 1:1000
        RES1(p,i) = localConnSnoNorm(1,i,Sig);
    end
    p = p + 1;
end

% check the input 5 from 10 nodes for 1000 hidden nodes
p = 1;
for Sig = 0.1:0.1:1
    for i = 1:1000
        RES5(p,i) = localConnSnoNorm(5,i,Sig);
    end
    p = p + 1;
end

% Plot all the pack in one plot, two plots at the end
clf

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

xlabel('Hidden nodes','FontSize',12);
ylabel('Connectivity','FontSize',12);
%title('','FontSize',16);

saveas(h,['ConnectiviyLocalConnShemeNoNorm.fig'])
