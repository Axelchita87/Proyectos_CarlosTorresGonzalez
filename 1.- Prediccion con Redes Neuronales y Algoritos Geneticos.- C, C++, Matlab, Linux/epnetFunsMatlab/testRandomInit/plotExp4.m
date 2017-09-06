%% Plot results from Exp2 for the random initialization
% Here it can be plotted both experiment from exp1, with 1 output and with
% many outputs
%
% usage:
% plotExp4('resExp4','resExp4')
% plotExp2('resExp4','resExp4manyOut')
%
% Created:      13 Oct 2010
% Modified at:  
% Author:       Carlos Torres and Victor Landassuri 
%

%% function
function plotExp4(EXP,filename)

path1 = pwd;

cd(EXP);                 
%filename = 'resExp2manyOut';
res1 = load(filename);

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

xtick = 1:6;
xticks = {'A', 'B', 'C', 'D', 'E', 'F'};%, 'G', 'H', 'I', 'J','K','L'};
set(gca,'XTick',xtick,'XTickLabel',xticks);
   
legend('Av. number of nodes', 'Av. number of non-connected nodes to outputs', ...
    'Av. number of non-connected nodes to inputs');
xlabel('Percentage of initialization','FontSize',12);
ylabel('Average','FontSize',12);
title('Comparison for different percentage of initializaton','FontSize',16);

saveas(h,[filename,'NodesVSnonConNodes.fig'])
% ------------------------------------------------------------------------%

% Av number of connections
clf
h = errorbar(mCon,stdCon,'LineWidth',1);

% lables, ...
set(gca,'XTick',xtick,'XTickLabel',xticks);
   
xlabel('Percentage of initialization','FontSize',12);
ylabel('Average number of connections','FontSize',12);
title('Average number of connections','FontSize',16);

saveas(h,[filename,'AvNumConn.fig'])
% ------------------------------------------------------------------------%



% Av modularity
clf
h = errorbar(mMarch,stdMarch,'LineWidth',1);

% lables, ...
set(gca,'XTick',xtick,'XTickLabel',xticks);
   
xlabel('Percentage of initialization','FontSize',12);
ylabel('Average Modularity (arch)','FontSize',12);
%title('Average March','FontSize',16);
%title('$\\displaylstyle\\frac{A-A(-1)}{Y}$','interpreter','latex')
title('Average M^{(arch.)}','FontSize',16)
saveas(h,[filename,'AvMarch.fig'])
% ------------------------------------------------------------------------%
cd ('..')

