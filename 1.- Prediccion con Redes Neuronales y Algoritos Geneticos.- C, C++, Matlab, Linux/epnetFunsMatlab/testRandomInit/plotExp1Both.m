%% Plot results from Exp1 for the random initialization for 1 and n
%% outpouts
% in the same figure are plotted both experimnets
% Created:      11 Oct 2010
% Modified at:  13 Oct 2010
% Author:       Carlos Torres and Victor Landassuri 
%

%% script
clear
clc

path1 = pwd;

cd('resExp1');
res1 = load('resExp1.mat');
res2 = load('resExp1manyOut.mat');
% Setup this ::::::::::::: use std or stdError
useStde = 1;

% transpose of each variable
res1.conn = res1.conn';
res1.March = res1.March';
res1.contnoNodes = res1.contnoNodes';
res1.contnoInputs = res1.contnoInputs';
res1.noNodes = res1.noNodes';
% isolated nodes from outputs and inputs are put towether
res1.contnoNodes = res1.contnoNodes + res1.contnoInputs; 


res2.conn = res2.conn';
res2.March = res2.March';
res2.contnoNodes = res2.contnoNodes';
res2.contnoInputs = res2.contnoInputs';
res2.noNodes = res2.noNodes';
% isolated nodes from outputs and inputs are put towether
res2.contnoNodes = res2.contnoNodes + res2.contnoInputs; 

% any var has the number of repetitions
repetitions = size(res1.conn,1);

%% Obtain mean std from all var
% Connections
mCon = mean(res1.conn);
stdCon = std(res1.conn);
stdeCon = stdCon./sqrt(repetitions);
% minCon = min(res1.conn);
% maxCon = max(res1.conn);

% March
mMarch = mean(res1.March);
stdMarch = std(res1.March);
stdeMarch = stdMarch./sqrt(repetitions);

% isolated nodes from both inputs and outpus
mNoNodes = mean(res1.contnoNodes);
stdNoNodes = std(res1.contnoNodes);
stdeNoNodes = stdNoNodes./sqrt(repetitions);

% isolated nodes form inputs
% mNoInputs = mean(res1.contnoInputs);
% stdNoInputs = std(res1.contnoInputs);

% number of nodes
mNodes = mean(res1.noNodes);
stdNodes = std(res1.noNodes);
stdeNodes = stdNodes./sqrt(repetitions);





% for the networks with many outputs
% Connections
mCon2 = mean(res2.conn);
stdCon2 = std(res2.conn);
stdeCon2 = stdCon2./sqrt(repetitions);

% March
mMarch2 = mean(res2.March);
stdMarch2 = std(res2.March);
stdeMarch2 = stdMarch2./sqrt(repetitions);

% isolated nodes from both inputs and outpus
mNoNodes2 = mean(res2.contnoNodes);
stdNoNodes2 = std(res2.contnoNodes);
stdeNoNodes2 = stdNoNodes2./sqrt(repetitions);

% isolated nodes form inputs
% mNoInputs2 = mean(res2.contnoInputs);
% stdNoInputs2 = std(res2.contnoInputs);

% number of nodes
mNodes2 = mean(res2.noNodes);
stdNodes2 = std(res2.noNodes);
stdeNodes2 = stdNodes2./sqrt(repetitions);




%% Plot the results

xname = 'Probability';
gcaFotnSize = 12;           % size for the tick and legend
xylabeSize = 14;               % x and y labes size
xtick = 0:2:10;
xticks = {'','0.2', '0.4', '0.6', '0.8', '1'};



% Error bar: av Nodes & av isolated nodes

clf
if useStde == 0
    h = errorbar(mNodes2,stdNodes2,'.-','LineWidth',1);
    hold all
    h = errorbar(mNoNodes,stdNoNodes,'o--','LineWidth',1);
    %h = errorbar(mNoInputs,stdNoInputs,'.--','LineWidth',1);
    
    % now the networks with many conenctions
    %h = errorbar(mNodes2,stdNodes2,':o','LineWidth',1);
    h = errorbar(mNoNodes2,stdNoNodes2,'*:','LineWidth',1);
    %h = errorbar(mNoInputs2,stdNoInputs2,':x','LineWidth',1);
else
    % It means use standar error
    h = errorbar(mNodes2,stdeNodes2,'.-','LineWidth',1);
    hold all
    h = errorbar(mNoNodes,stdeNoNodes,'o--','LineWidth',1);
        
    % now the networks with many conenctions
    h = errorbar(mNoNodes2,stdeNoNodes2,'*:','LineWidth',1);
end

% lables, ...

set(gca,'XTick',xtick,'XTickLabel',xticks, 'fontsize',gcaFotnSize);
   
legend('n outpus: Av. number of nodes', '1 outpu: Av. isolated nodes',...
    'n outpus: Av. isolated nodes' );
xlabel('Percentage of initialization','FontSize',12);
ylabel('Average','FontSize',12);
title('Comparison for different percentage of initializaton','FontSize',16);

saveas(h,'Exp1BOTHNodesVSnonConNodes.fig')
% ------------------------------------------------------------------------%

% Av number of connections
clf
if useStde == 0
    h = errorbar(mCon,stdCon,'-','LineWidth',1);
    hold all
    h = errorbar(mCon2,stdCon2,'--','LineWidth',1);
else
    % use stde
    h = errorbar(mCon,stdeCon,'-','LineWidth',1);
    hold all
    h = errorbar(mCon2,stdeCon2,'--','LineWidth',1);
end

% lables, ...
set(gca,'XTick',xtick,'XTickLabel',xticks, 'fontsize',gcaFotnSize);
   
legend('1 output','n outputs')
xlabel('Percentage of initialization','FontSize',12);
ylabel('Average number of connections','FontSize',12);
title('Average number of connections','FontSize',16);

    
saveas(h,'Exp1BOTHAvNumConn.fig')
% ------------------------------------------------------------------------%



% Av modularity
clf
if useStde == 0
    h = errorbar(mMarch,stdMarch,'-','LineWidth',1);
    hold all
    h = errorbar(mMarch2,stdMarch2,'--','LineWidth',1);
else
    % use stde
    h = errorbar(mMarch,stdeMarch,'-','LineWidth',1);
    hold all
    h = errorbar(mMarch2,stdeMarch2,'--','LineWidth',1);
end
% lables, ...
set(gca,'XTick',xtick,'XTickLabel',xticks, 'fontsize',gcaFotnSize);
legend('1 output','n outputs')
xlabel('Percentage of initialization','FontSize',12);
ylabel('Average Modularity M^{(arch.)}','FontSize',12);
%title('Average March','FontSize',16);
%title('$\\displaylstyle\\frac{A-A(-1)}{Y}$','interpreter','latex')
title('Average M^{(arch.)}','FontSize',16)
saveas(h,'Exp1BOTHAvMarch.fig')
% ------------------------------------------------------------------------%







%% Plot Av connection and AV modularity in the same figure with subplot




% Av modularity

clf
h = subplot(1,2,1);
if useStde == 0
    h = errorbar(mMarch,stdMarch,'o-','LineWidth',1);
    hold all
    h = errorbar(mMarch2,stdMarch2,'*--','LineWidth',1);
else
    h = errorbar(mMarch,stdeMarch,'o-','LineWidth',1);
    hold all
    h = errorbar(mMarch2,stdeMarch2,'*--','LineWidth',1);
end
% lables, ...
set(gca,'XTick',xtick,'XTickLabel',xticks, 'fontsize',gcaFotnSize);
   legend('1 output','n outputs')
xlabel(xname,'FontSize',xylabeSize);
ylabel('Average Modularity M^{(arch.)}','FontSize',xylabeSize);
%title('Average March','FontSize',16);
%title('$\\displaylstyle\\frac{A-A(-1)}{Y}$','interpreter','latex')
%title('Average M^{(arch.)}','FontSize',16)
axis([0.5 11 -0.16 0.21])

% Av number of connections
h = subplot(1,2,2);
if useStde == 0
    h = errorbar(mCon,stdCon,'o-','LineWidth',1);
    hold all
    h = errorbar(mCon2,stdCon2,'*--','LineWidth',1);
else
    h = errorbar(mCon,stdeCon,'o-','LineWidth',1);
    hold all
    h = errorbar(mCon2,stdeCon2,'*--','LineWidth',1);
end
% lables, ...
set(gca,'XTick',xtick,'XTickLabel',xticks, 'fontsize',gcaFotnSize);
   
legend('1 output','n outputs')
xlabel(xname,'FontSize',xylabeSize);
ylabel('Average number of connections','FontSize',xylabeSize);
%title('Average number of connections','FontSize',16);
axis([0.5 11 -1 390])

saveas(h,'Exp1AvConnAvModBOTH.fig')
% ------------------------------------------------------------------------%





% last method







%% Here aI plot the three figues in the same, so all are in a line


% Error bar: av Nodes & av isolated nodes

clf
h = subplot(1,3,1);
if useStde == 0
    
    h = errorbar(mNodes2,stdNodes2,'.-','LineWidth',1);
    hold all
    h = errorbar(mNoNodes,stdNoNodes,'o--','LineWidth',1);
    %h = errorbar(mNoInputs,stdNoInputs,'.--','LineWidth',1);
    
    % now the networks with many conenctions
    %h = errorbar(mNodes2,stdNodes2,':o','LineWidth',1);
    h = errorbar(mNoNodes2,stdNoNodes2,'*:','LineWidth',1);
    %h = errorbar(mNoInputs2,stdNoInputs2,':x','LineWidth',1);
else
    
    h = errorbar(mNodes2,stdeNodes2,'.-','LineWidth',1);
    hold all
    h = errorbar(mNoNodes,stdeNoNodes,'o--','LineWidth',1);
    
    h = errorbar(mNoNodes2,stdeNoNodes2,'*:','LineWidth',1);
end
% lables, ...

set(gca,'XTick',xtick,'XTickLabel',xticks, 'fontsize',gcaFotnSize);

   
legend('n outpus: Av. number of nodes', '1 outpu: Av. isolated nodes',...
    'n outpus: Av. isolated nodes' );
xlabel(xname,'FontSize',xylabeSize);
ylabel('Average','FontSize',xylabeSize);
%title('Comparison for different percentage of initializaton','FontSize',16);


% Av modularity


h = subplot(1,3,2);
if useStde == 0
    h = errorbar(mMarch,stdMarch,'o-','LineWidth',1);
    hold all
    h = errorbar(mMarch2,stdMarch2,'*--','LineWidth',1);
else
    % standard error
    h = errorbar(mMarch,stdeMarch,'o-','LineWidth',1);
    hold all
    h = errorbar(mMarch2,stdeMarch2,'*--','LineWidth',1);
end

% lables, ...
set(gca,'XTick',xtick,'XTickLabel',xticks, 'fontsize',gcaFotnSize);
   legend('1 output','n outputs')
xlabel(xname,'FontSize',xylabeSize);
ylabel('Average Modularity M^{(arch.)}','FontSize',xylabeSize);
%title('Average March','FontSize',16);
%title('$\\displaylstyle\\frac{A-A(-1)}{Y}$','interpreter','latex')
%title('Average M^{(arch.)}','FontSize',16)
axis([0.5 11 -0.16 0.21])

% Av number of connections
h = subplot(1,3,3)
if useStde == 0
    h = errorbar(mCon,stdCon,'o-g','LineWidth',1);
    hold all
    h = errorbar(mCon2,stdCon2,'*--r','LineWidth',1);
else
    % std error
    h = errorbar(mCon,stdeCon,'o-g','LineWidth',1);
    hold all
    h = errorbar(mCon2,stdeCon2,'*--r','LineWidth',1);
end

% lables, ...
set(gca,'XTick',xtick,'XTickLabel',xticks, 'fontsize',gcaFotnSize);
   
legend('1 output','n outputs')
xlabel(xname,'FontSize',xylabeSize);
ylabel('Average number of connections','FontSize',xylabeSize);
%title('Average number of connections','FontSize',16);
axis([0.5 11 -1 390])

saveas(h,'Exp1ALL.fig')
% ------------------------------------------------------------------------%



