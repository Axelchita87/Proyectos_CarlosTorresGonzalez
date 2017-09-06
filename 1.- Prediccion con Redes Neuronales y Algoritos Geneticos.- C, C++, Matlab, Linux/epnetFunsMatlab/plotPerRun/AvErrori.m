%Plot the average error per generation for all scales in the same plot 

%The file is called form the main exp: PlotAllFigsAllTS.m

clc

%Allocate memory to some variables
AVErrori = zeros(7,generation);
%variables for the eror bars
E1 = zeros(30,generation);
E2 = zeros(30,generation);
E3 = zeros(30,generation);
E4 = zeros(30,generation);
E5 = zeros(30,generation);
E6 = zeros(30,generation);
E7 = zeros(30,generation);

linesP{1,1} = '-<';
linesP{1,2} = '-->';
linesP{1,3} = ':^';
linesP{1,4} = '-.d';
linesP{1,5} = '-o';
linesP{1,6} = '--+';
linesP{1,7} = ':p';

%Sum the values to obtain the averages
for i=1:corrida
    AVErrori = AVErrori + allrun{1,i}.ALLParam.AvErrori;
    E1(i,:) = allrun{1,i}.ALLParam.AvErrori(1,:);
    E2(i,:) = allrun{1,i}.ALLParam.AvErrori(2,:);
    E3(i,:) = allrun{1,i}.ALLParam.AvErrori(3,:);
    E4(i,:) = allrun{1,i}.ALLParam.AvErrori(4,:);
    E5(i,:) = allrun{1,i}.ALLParam.AvErrori(5,:);
    E6(i,:) = allrun{1,i}.ALLParam.AvErrori(6,:);
    E7(i,:) = allrun{1,i}.ALLParam.AvErrori(7,:);
end

%divide to average them 
AVErrori = AVErrori/corrida;
SDTE(1,:) = std(E1);
SDTE(2,:) = std(E2);
SDTE(3,:) = std(E3);
SDTE(4,:) = std(E4);
SDTE(5,:) = std(E5);
SDTE(6,:) = std(E6);
SDTE(7,:) = std(E7);

%delete some point to make the grapihc more clear
if generation <= 500
    modulo = 10;
else
    modulo = 50;
end
for i=1:generation
    if mod(i,modulo) ~= 0
        AVErrori(:,i) = NaN;
        STDE(:,i) = NaN;
    end
end

cd('figs_fig');

%For the errpr and the error bars, tow figures

clf
h = axes('YScale','log')
box('on');
hold all
for i=1:7
    h = plot(AVErrori(i,:),linesP{1,i},'LineWidth',1)
end
ylabel('Average NRMS','FontSize',12)
xlabel('Generations','FontSize',12)
legend('Scale 1','Scale 2','Scale 3','Scale 4','Scale 5','Scale 6','Scale 7');
saveas(h, 'Errori.fig');


clf
h = axes('YScale','log')
box('on');
hold all
for i=1:7
     h =errorbar(AVErrori(i,:),SDTE(i,:),'LineWidth',1);
end
ylabel('Average NRMS','FontSize',12)
xlabel('Generations','FontSize',12)
legend('Scale 1','Scale 2','Scale 3','Scale 4','Scale 5','Scale 6','Scale 7');
saveas(h, 'ErroriEbars.fig');

cd('..');


