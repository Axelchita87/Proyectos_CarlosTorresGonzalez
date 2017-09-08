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


%% Obtain mean std from all var
% Connections
mCon = mean(res1.conn);
stdCon = std(res1.conn);
% minCon = min(res1.conn);
% maxCon = max(res1.conn);

% March
mMarch = mean(res1.March);
stdMarch = std(res1.March);

% isolated nodes from both inputs and outpus
mNoNodes = mean(res1.contnoNodes);
stdNoNodes = std(res1.contnoNodes);

% isolated nodes form inputs
% mNoInputs = mean(res1.contnoInputs);
% stdNoInputs = std(res1.contnoInputs);

% number of nodes
mNodes = mean(res1.noNodes);
stdNodes = std(res1.noNodes);






% for the networks with many outputs
% Connections
mCon2 = mean(res2.conn);
stdCon2 = std(res2.conn);

% March
mMarch2 = mean(res2.March);
stdMarch2 = std(res2.March);

% isolated nodes from both inputs and outpus
mNoNodes2 = mean(res2.contnoNodes);
stdNoNodes2 = std(res2.contnoNodes);

% isolated nodes form inputs
% mNoInputs2 = mean(res2.contnoInputs);
% stdNoInputs2 = std(res2.contnoInputs);

% number of nodes
mNodes2 = mean(res2.noNodes);
stdNodes2 = std(res2.noNodes);


%% Plot the results


% Error bar: av Nodes & av isolated nodes

clf
h = errorbar(mNodes2,stdNodes2,'.-','LineWidth',1);
hold all
h = errorbar(mNoNodes,stdNoNodes,'o--','LineWidth',1);
%h = errorbar(mNoInputs,stdNoInputs,'.--','LineWidth',1);

% now the networks with many conenctions
%h = errorbar(mNodes2,stdNodes2,':o','LineWidth',1);
h = errorbar(mNoNodes2,stdNoNodes2,'*:','LineWidth',1);
%h = errorbar(mNoInputs2,stdNoInputs2,':x','LineWidth',1);

% lables, ...

xtick = 0:2:10;
xticks = {'','0.2', '0.4', '0.6', '0.8', '1'};
%xticks = {'0.1', '0.2', '0.3', '0.4', '0.5', '0.6', '0.7', '0.8', '0.9', '1'};
set(gca,'XTick',xtick,'XTickLabel',xticks);


%set(gca,'XTickLabel',xticks);
   
legend('n outpus: Av. number of nodes', '1 outpu: Av. isolated nodes',...
    'n outpus: Av. isolated nodes' );
xlabel('Percentage of initialization','FontSize',12);
ylabel('Average','FontSize',12);
title('Comparison for different percentage of initializaton','FontSize',16);

saveas(h,'Exp1BOTHNodesVSnonConNodes.fig')
% ------------------------------------------------------------------------%

% Av number of connections
clf
h = errorbar(mCon,stdCon,'-','LineWidth',1);
hold all
h = errorbar(mCon2,stdCon2,'--','LineWidth',1);

% lables, ...
set(gca,'XTick',xtick,'XTickLabel',xticks);
   
legend('1 output','n outputs')
xlabel('Percentage of initialization','FontSize',12);
ylabel('Average number of connections','FontSize',12);
title('Average number of connections','FontSize',16);

saveas(h,'Exp1BOTHAvNumConn.fig')
% ------------------------------------------------------------------------%



% Av modularity
clf
h = errorbar(mMarch,stdMarch,'o-','LineWidth',1);
hold all
h = errorbar(mMarch2,stdMarch2,'*--','LineWidth',1);

% lables, ...
set(gca,'XTick',xtick,'XTickLabel',xticks);
   legend('1 output','n outputs')
xlabel('Percentage of initialization','FontSize',12);
ylabel('Average Modularity M^{(arch.)}','FontSize',12);
%title('Average March','FontSize',16);
%title('$\\displaylstyle\\frac{A-A(-1)}{Y}$','interpreter','latex')
title('Average M^{(arch.)}','FontSize',16)
saveas(h,'Exp1BOTHAvMarch.fig')
% ------------------------------------------------------------------------%








%% Plot Av connection and AV modularity in the same figure qith subplot




% Av modularity

clf
h = subplot(1,2,1)
h = errorbar(mMarch,stdMarch,'o-','LineWidth',1);
hold all
h = errorbar(mMarch2,stdMarch2,'*--','LineWidth',1);

% lables, ...
set(gca,'XTick',xtick,'XTickLabel',xticks);
   legend('1 output','n outputs')
xlabel('Percentage of initialization','FontSize',12);
ylabel('Average Modularity M^{(arch.)}','FontSize',12);
%title('Average March','FontSize',16);
%title('$\\displaylstyle\\frac{A-A(-1)}{Y}$','interpreter','latex')
%title('Average M^{(arch.)}','FontSize',16)
axis([0.5 11 -0.16 0.21])

% Av number of connections
h = subplot(1,2,2)
h = errorbar(mCon,stdCon,'o-g','LineWidth',1);
hold all
h = errorbar(mCon2,stdCon2,'*--r','LineWidth',1);

% lables, ...
set(gca,'XTick',xtick,'XTickLabel',xticks);
   
legend('1 output','n outputs')
xlabel('Percentage of initialization','FontSize',12);
ylabel('Average number of connections','FontSize',12);
%title('Average number of connections','FontSize',16);
axis([0.5 11 -1 390])

saveas(h,'Exp1AvConnAvModBOTH.fig')
% ------------------------------------------------------------------------%





