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

% I use this to make small test varing the number and seen if it the same
% that I obtain using the normal code

clear
clc

% 3 - 8
noInp = 20;
noHid = 10;

posinputs = 1:noInp;
poshidden = 1:noHid;

% analyse 1
p = 1;
for Sig = 0.1:0.1:1
    for i = poshidden
        RES1(p,i) = localConnS(1,i,noInp,noHid,Sig);
    end
    p = p + 1;
end

% analyse 2
p = 1;
for Sig = 0.1:0.1:1
    for i = poshidden
        RES2(p,i) = localConnS(5,i,noInp,noHid,Sig);
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
    h = plot(RES2(i,:), '--k','LineWidth',1);
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

%saveas(h,['ConnectiviyLocalConnSheme10y10.fig'])



%% test a normal mat

for i= posinputs
    for j = poshidden
        RES(i,j) = localConnS(i,j,noInp,noHid,1);
    end
end

% plot it
figure
for i = 1:10
    h = plot(RES(i,:), '--k','LineWidth',1);
    hold all
end


%%

%% Implement on the contrary if there are more inputs than hidden nodes

if noInp > noHid
    
    % analyse 1
    p = 1;
    for Sig = 0.1:0.1:1
        for i = posinputs
            RES1a(p,i) = localConnS(1,i,noHid,noInp,Sig);
        end
        p = p + 1;
    end
    
    % analyse 2
    p = 1;
    for Sig = 0.1:0.1:1
        for i = posinputs
            RES2a(p,i) = localConnS(5,i,noHid,noInp,Sig);
        end
        p = p + 1;
    end
    
    % Plot all the pack in one plot, two plots at the end
    figure
    %for the  forst input
    for i = 1:10
        h = plot(RES1a(i,:),'-b','LineWidth',1);
        hold all
    end
    
    % for the input 5
    for i = 1:10
        h = plot(RES2a(i,:), '--k','LineWidth',1);
        hold all
    end
    
    
    xlabel('Hidden nodes','FontSize',12);
    ylabel('Connectivity','FontSize',12);
    %title('','FontSize',16);
    
    %saveas(h,['ConnectiviyLocalConnSheme10y10.fig'])
    
    
    
    %% test a normal mat
    
    for i= poshidden
        for j = posinputs
            RESa(j,i) = localConnS(j,i,noHid,noInp,1);
        end
    end
    
    % plot it
    figure
    for i = 1:10
        h = plot(RESa(i,:), '--k','LineWidth',1);
        hold all
    end
    
end

