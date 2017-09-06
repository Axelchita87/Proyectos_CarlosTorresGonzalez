%% Plot results from Exp1 for the random initialization
% Here it can be plotted both experiment from exp1, with 1 output and with
% many outputs
%
% usage:
% plotExp1('resExp1')
% plotExp1('resExp1manyOut')
%
% Created:      11 Oct 2010
% Modified at:  13 Oct 2010
% Author:       Carlos Torres and Victor Landassuri 
%

%% function
function plotExp1y5(dirName)

path1 = pwd;

cd(dirName);                 
res1 = load('resExp');

% transpose of each variable
res1.conn = res1.conn';
res1.March = res1.March';
res1.contnoNodes = res1.contnoNodes';
res1.contnoInputs = res1.contnoInputs';
res1.noNodes = res1.noNodes';

%% Obtain mean std from all var
% Connections
mCon = mean(res1.conn);
stdCon = std(res1.conn);
% minCon = min(res1.conn);
% maxCon = max(res1.conn);

% March
mMarch = mean(res1.March);
stdMarch = std(res1.March);

% isolated nodes
mNoNodes = mean(res1.contnoNodes);
stdNoNodes = std(res1.contnoNodes);

% isolated nodes form inputs
mNoInputs = mean(res1.contnoInputs);
stdNoInputs = std(res1.contnoInputs);

% number of nodes
mNodes = mean(res1.noNodes);
stdNodes = std(res1.noNodes);


%% Plot the results


% Error bar: av Nodes & av isolated nodes

clf
h = errorbar(mNodes,stdNodes,'.-','LineWidth',1);
hold all
h = errorbar(mNoNodes,stdNoNodes,'o--','LineWidth',1);
h = errorbar(mNoInputs,stdNoInputs,'*:','LineWidth',1);
% lables, ...
%xticks = {'','0.1', '0.2', '0.3', '0.4', '0.5', '0.6', '0.7', '0.8', '0.9', '1'};
xticks = {'','0.2', '0.4', '0.6', '0.8', '1'};
set(gca,'XTickLabel',xticks);
   
legend('Av. number of nodes', 'Av. number of non-connected nodes to outputs', ...
    'Av. number of non-connected nodes to inputs');
xlabel('Percentage of initialization','FontSize',12);
ylabel('Average','FontSize',12);
%title('Comparison for different percentage of initializaton','FontSize',16);

saveas(h,[dirName,'NodesVSnonConNodes.fig'])
% ------------------------------------------------------------------------%

% Av number of connections
clf
h = errorbar(mCon,stdCon,'LineWidth',1);

% lables, ...
set(gca,'XTickLabel',xticks);
   
xlabel('Percentage of initialization','FontSize',12);
ylabel('Average number of connections','FontSize',12);
%title('Average number of connections','FontSize',16);

saveas(h,[dirName,'AvNumConn.fig'])
% ------------------------------------------------------------------------%



% Av modularity
clf
h = errorbar(mMarch,stdMarch,'LineWidth',1);

% lables, ...
set(gca,'XTickLabel',xticks);
   
xlabel('Percentage of initialization','FontSize',12);
ylabel('Average Modularity (arch)','FontSize',12);
%title('Average March','FontSize',16);
%title('$\\displaylstyle\\frac{A-A(-1)}{Y}$','interpreter','latex')
%title('Average M^{(arch.)}','FontSize',16)
saveas(h,[dirName,'AvMarch.fig'])
% ------------------------------------------------------------------------%
cd ('..')

