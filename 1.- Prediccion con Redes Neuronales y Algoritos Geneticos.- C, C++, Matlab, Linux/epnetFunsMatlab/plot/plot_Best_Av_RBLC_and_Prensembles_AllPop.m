%script to plot the predictions of Best Individula, ensemble Av, RBLC,
%Pr-AV and Pr-RBLC for one same Exp. e.g. 15C

%funciona para 15 C con la info de toda la poblacion, codigo de C

%file place: matlab\plot\

clear
clc

%directory to work
dir1 = 'TSEPnet34C';
%TS to analyse / plot
%TS = 'ChaosMackey';

cd('..');           %exit plot
cd('..');           %exit matlab dir

path1 = pwd;        %I do not know if i need this

%load the TS
load TS.mat

cd(dir1);           %enter to dir

for w=1:21
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

    %%%%%%%%%%%%%%%%  Ensemble  S Rank base Linear Compbination %%%%%%%%%%%%%%%
    %determinate what is the best beta for the algorithm, for beta see paper:
    %MAking use of Population information in Evol ANN, Xin

    EtempBeta = zeros(1,corrida);
    tempB1 = 0;
    tempB25 = 0;
    tempB5 = 0;
    tempB75 = 0;

    for i=1:corrida
        EtempBeta(1,i) = allrun{1,i}.ensemble.OutputBestSRBLC;
        switch allrun{1,i}.ensemble.OutputBestSRBLC
            case 0.1
                tempB1 = tempB1+1;
            case 0.25
                tempB25 = tempB25 +1;
            case 0.5
                tempB5 = tempB5 +1;
            case 0.75
                tempB75 = tempB75 + 1;
        end
    end

    arraytempbeta(1,1) = tempB1;
    arraytempbeta(1,2) = tempB25;
    arraytempbeta(1,3) = tempB5;
    arraytempbeta(1,4) = tempB75;

    [MaxBeta, posBeta] = max(arraytempbeta);

    switch posBeta
        case 1
            structSRBLC = 'allrun{1,i}.ensemble.SRank_base_LCombination_1';
        case 2
            structSRBLC = 'allrun{1,i}.ensemble.SRank_base_LCombination_25';
        case 3
            structSRBLC = 'allrun{1,i}.ensemble.SRank_base_LCombination_5';
        case 4
            structSRBLC = 'allrun{1,i}.ensemble.SRank_base_LCombination_75';
    end
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%



    %obtain the fitness of all per run
    for i=1:corrida
        bestInds(1,i) = allrun{1,i}.Network{1}.iterateNRMSE_F;
        ensembleAvs(1,i) = allrun{1,i}.ensemble.Average.NRMSE;
        ensembleRBLCs(1,i) = eval([structSRBLC,'.NRMSE']);
    end

    [min_best, pos_best] = min(bestInds);
    [min_Av, pos_Av] = min(ensembleAvs);
    [min_RBLC, pos_RBLC] = min(ensembleRBLCs);

    %load the correct data of for the best ind, best Av, RBLC
    bestInd = allrun{pos_best}.Network{1}.iteratePredF;
    bestAv = allrun{1,pos_Av}.ensemble.Average.Pred;
    i = pos_RBLC;    %only to set i to the correct value in structSRBLC
    bestRBLC = eval([structSRBLC,'.Pred']);
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
    
    
    %saveas(h, 'ALLpred_best_and_ensembles.fig')
    
    clf
    clear h


    clear h allrun ensemblePerRun


    cd('..');       %exit fig
    cd('..');       %exit TS dir
end

