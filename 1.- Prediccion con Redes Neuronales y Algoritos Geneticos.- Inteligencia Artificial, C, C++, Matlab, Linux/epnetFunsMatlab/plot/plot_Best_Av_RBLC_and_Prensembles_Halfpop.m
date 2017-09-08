%script to plot the predictions of Best Individula, ensemble Av, RBLC,
%Pr-AV and Pr-RBLC for one same Exp. e.g. 15C with teh half of the
%population

%funciona para 15 C con la info de half populatin, codigo matlab to
%generate the ensembles

%file place: matlab\plot\

clear
clc

%directory to work
dir1 = 'TSEPnet15C';
%TS to analyse / plot
%TS = 'ChaosMackey';

cd('..');           %exit plot
cd('..');           %exit matlab dir

path1 = pwd;        %I do not know if i need this

%load the TS
load TS.mat

cd(dir1);           %enter to dir

for w=7:21
    cd(TS{1,w});
    %obtain name of the TS
    fid = fopen('TSname.txt', 'r');
    TSname = fgetl(fid);


    cd('res');          %enter to load results
    load allrun.mat
    load ensemblePerRun.mat

    corrida = size(allrun,2);
    bestInds = zeros(1,corrida);
    ensembleAvs = zeros(1,corrida);
    ensembleRBLCs = zeros(1,corrida);

    

    %obtain the fitness of all per run
    for i=1:corrida
        bestInds(1,i) = allrun{1,i}.Network{1}.iterateNRMSE_F;
        ensembleAvs(1,i) = allrun{1,i}.ensemble.Average_half.NRMSE;
        ensembleRBLCs(1,i) = allrun{1,i}.ensemble.RBLC_half.NRMSE;
    end

    [min_best, pos_best] = min(bestInds);
    [min_Av, pos_Av] = min(ensembleAvs);
    [min_RBLC, pos_RBLC] = min(ensembleRBLCs);

    %load the correct data of for the best ind, best Av, RBLC
    bestInd = allrun{pos_best}.Network{1}.iteratePredF;
    bestAv = allrun{1,pos_Av}.ensemble.Average.Pred;
    bestRBLC = allrun{1,pos_RBLC}.ensemble.RBLC_half.Pred;
    EPr_Av = ensemblePerRun.ensembleAv.Pred;
    Epr_RBLC = ensemblePerRun.ensembleRBLC.Pred;

    cd('..');               %exit \res
    cd('figs_fig')
    %plot original data
    h = plot(allrun{1,1}.sets.toPredictF,'r-', 'LineWidth',1.5);
    hold all
    %plot best ind
    h = plot(bestInd,'b', 'LineWidth',1);
    h = plot(bestAv, 'k--.' ,'LineWidth',1);
    h = plot(bestRBLC, 'm-.', 'LineWidth',1);
    h = plot(EPr_Av, 'k:.', 'LineWidth',1);
    h = plot(Epr_RBLC, 'm' ,'LineWidth',1);


    xlabel('n','FontSize',12)
    ylabel('X(n)','FontSize',12)
    string2title = ['\it{',TSname,'}'];
    title(string2title,'FontSize',16')

    legend('Original','Best Ind.','Average', 'RBLC', 'Pr-Av', 'Pr-RBLC');
    
    
    saveas(h, 'ALLpred_best_and_ensembles.fig')
    
    clf
    clear h


    clear h allrun ensemblePerRun


    cd('..');       %exit fig
    cd('..');       %exit TS dir
end

