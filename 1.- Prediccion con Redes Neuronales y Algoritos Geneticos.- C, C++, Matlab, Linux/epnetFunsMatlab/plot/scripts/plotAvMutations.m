%% Plot Fitness per module Figure
% It is plotted the FITNESS per module figure in Av, std or ste
%
% Created:  22 Feb 2011
% Modified: 15 Jul 2011
% Author:   Carlos Torres and Victor Landassuri

%%
clf
hold all
contLegend = 1;
strLegned{1} = '';

% I M P O R T A N T
% Change the three sections as required !!!!

if strcmp(typePlot, 'AV')
    
    %     h = plot(info{1,1}.avhybridtraining,lines{1,1},'LineWidth',1);
    
    h = plot(info{1,1}.avhybridtraining,'--k','LineWidth',1); strLegned{contLegend} = 'Training MBP'; contLegend = contLegend + 1;
    %h = plot(info{1,1}.avMBP,'--k','LineWidth',1); strLegned{contLegend} = 'Training MBP'; contLegend = contLegend + 1;
    %     h = plot(info{1,1}.avSA,'-<b','LineWidth',1);
    
    if allrun{1,1}.var.algoFeatures == allrun{1,1}.C.MODULAR1
        h = plot(info{1,1}.avSharedNodeDel,lines{1,2},'LineWidth',1);   strLegned{contLegend} = 'Shared node deletion'; contLegend = contLegend + 1;
        h = plot(info{1,1}.avSharedConnDel,lines{1,3},'LineWidth',1);   strLegned{contLegend} = 'Shared connection deletion'; contLegend = contLegend + 1;
        h = plot(info{1,1}.avStrongConnAdd,lines{1,4},'LineWidth',1);   strLegned{contLegend} = 'Strong connection addition'; contLegend = contLegend + 1;
    end
    
    h = plot(info{1,1}.avnodeDel,'og','LineWidth',2);             strLegned{contLegend} = 'Node deletion'; contLegend = contLegend + 1;
    h = plot(info{1,1}.avconnDel,'*b','LineWidth',1);             strLegned{contLegend} = 'Connection deletion'; contLegend = contLegend + 1;
    h = plot(info{1,1}.avnodeAdd,'-r','LineWidth',1);             strLegned{contLegend} = 'Node addition'; contLegend = contLegend + 1;
    h = plot(info{1,1}.avconnAdd,'xm','LineWidth',1);             strLegned{contLegend} = 'Connection addition'; contLegend = contLegend + 1;
    
    if (allrun{1,1}.var.fixedinputs == allrun{1,1}.C.EVOLVE) || (allrun{1,1}.var.fixedinputs == allrun{1,1}.C.FIX_EVOvra)
        h = plot(info{1,1}.avInpAdd,'->m','LineWidth',1);               strLegned{contLegend} = 'Input addition'; contLegend = contLegend + 1;
        h = plot(info{1,1}.avInpDel,'-+r','LineWidth',1);               strLegned{contLegend} = 'Input deletion'; contLegend = contLegend + 1;
        
        if allrun{1,1}.var.task2solve == allrun{1,1}.C.PREDICT
            h = plot(info{1,1}.avDelayAdd,'--.b','LineWidth',1);            strLegned{contLegend} = 'Delay addition'; contLegend = contLegend + 1;
            h = plot(info{1,1}.avDelayDel,'-xg','LineWidth',1);             strLegned{contLegend} = 'Delay deletion'; contLegend = contLegend + 1;
        end
    end
    
    
elseif strcmp(typePlot, 'STD')
    
    %     h = plot(info.avhybridtraining,info.stdhybridtraining, lines{1,1},'LineWidth',1);
    h = errorbar(info{1,1}.avhybridtraining, info{1,1}.stdMBP, '--k','LineWidth',1);                              strLegned{contLegend} = 'Training MBP'; contLegend = contLegend + 1;
    
    %     h = errorbar(info{1,1}.avSA, info{1,1}.stdSA, '-<b','LineWidth',1);
    
    if allrun{1,1}.var.algoFeatures == allrun{1,1}.C.MODULAR1
        h = errorbar(info{1,1}.avSharedNodeDel, info{1,1}.stdSharedNodeDel, lines{1,2},'LineWidth',1);      strLegned{contLegend} = 'Shared node deletion'; contLegend = contLegend + 1;
        h = errorbar(info{1,1}.avSharedConnDel, info{1,1}.stdSharedConnDel, lines{1,3},'LineWidth',1);      strLegned{contLegend} = 'Shared connection deletion'; contLegend = contLegend + 1;
        h = errorbar(info{1,1}.avStrongConnAdd, info{1,1}.stdStrongConnAdd, lines{1,4},'LineWidth',1);      strLegned{contLegend} = 'Strong connection addition'; contLegend = contLegend + 1;
    end
    
    h = errorbar(info{1,1}.avnodeDel, info{1,1}.stdnodeDel, 'og','LineWidth',2);                      strLegned{contLegend} = 'Node deletion'; contLegend = contLegend + 1;
    h = errorbar(info{1,1}.avconnDel, info{1,1}.stdconnDel, '*b','LineWidth',1);                      strLegned{contLegend} = 'Connection deletion'; contLegend = contLegend + 1;
    h = errorbar(info{1,1}.avnodeAdd, info{1,1}.stdnodeAdd, '-r','LineWidth',1);                      strLegned{contLegend} = 'Node addition'; contLegend = contLegend + 1;
    h = errorbar(info{1,1}.avconnAdd, info{1,1}.stdconnAdd, 'xm','LineWidth',1);                      strLegned{contLegend} = 'Connection addition'; contLegend = contLegend + 1;
    
    
    if allrun{1,1}.var.fixedinputs == allrun{1,1}.C.EVOLVE
        h = errorbar(info{1,1}.avInpAdd, info{1,1}.stdInpAdd, '->m','LineWidth',1);                         strLegned{contLegend} = 'Input addition'; contLegend = contLegend + 1;
        h = errorbar(info{1,1}.avInpDel, info{1,1}.stdInpDel, '-+r','LineWidth',1);                         strLegned{contLegend} = 'Input deletion'; contLegend = contLegend + 1;
        h = errorbar(info{1,1}.avDelayAdd, info{1,1}.stdDelayAdd,'--.b','LineWidth',1);                     strLegned{contLegend} = 'Delay addition'; contLegend = contLegend + 1;
        h = errorbar(info{1,1}.avDelayDel, info{1,1}.stdDelayDel, '-xg','LineWidth',1);                     strLegned{contLegend} = 'Delay deletion'; contLegend = contLegend + 1;
    end
    
    
elseif strcmp(typePlot, 'STE')
    
    %     h = plot(info.avhybridtraining,info.stehybridtraining, lines{1,1},'LineWidth',1);
    
    h = errorbar(info{1,1}.avhybridtraining, info{1,1}.steMBP, '--k','LineWidth',1);                              strLegned{contLegend} = 'Training MBP'; contLegend = contLegend + 1;
    %         h = errorbar(info{1,1}.avSA, info{1,1}.steSA, '-<b','LineWidth',1);
    
    if allrun{1,1}.var.algoFeatures == allrun{1,1}.C.MODULAR1
        h = errorbar(info{1,1}.avSharedNodeDel, info{1,1}.steSharedNodeDel, lines{1,2},'LineWidth',1);      strLegned{contLegend} = 'Shared node deletion'; contLegend = contLegend + 1;
        h = errorbar(info{1,1}.avSharedConnDel, info{1,1}.steSharedConnDel, lines{1,3},'LineWidth',1);      strLegned{contLegend} = 'Shared connection deletion'; contLegend = contLegend + 1;
        h = errorbar(info{1,1}.avStrongConnAdd, info{1,1}.steStrongConnAdd, lines{1,4},'LineWidth',1);      strLegned{contLegend} = 'Strong connection addition'; contLegend = contLegend + 1;
    end
    
    h = errorbar(info{1,1}.avnodeDel, info{1,1}.stenodeDel, 'og','LineWidth',2);                      strLegned{contLegend} = 'Node deletion'; contLegend = contLegend + 1;
    h = errorbar(info{1,1}.avconnDel, info{1,1}.steconnDel,'*b','LineWidth',1);                      strLegned{contLegend} = 'Connection deletion'; contLegend = contLegend + 1;
    h = errorbar(info{1,1}.avnodeAdd, info{1,1}.stenodeAdd, '-r','LineWidth',1);                      strLegned{contLegend} = 'Node addition'; contLegend = contLegend + 1;
    h = errorbar(info{1,1}.avconnAdd, info{1,1}.steconnAdd, 'xm','LineWidth',1);                      strLegned{contLegend} = 'Connection addition'; contLegend = contLegend + 1;
    
    
    if allrun{1,1}.var.fixedinputs == allrun{1,1}.C.EVOLVE
        h = errorbar(info{1,1}.avInpAdd, info{1,1}.steInpAdd, '->m','LineWidth',1);                         strLegned{contLegend} = 'Input addition'; contLegend = contLegend + 1;
        h = errorbar(info{1,1}.avInpDel, info{1,1}.steInpDel, '-+r','LineWidth',1);                         strLegned{contLegend} = 'Input deletion'; contLegend = contLegend + 1;
        h = errorbar(info{1,1}.avDelayAdd, info{1,1}.steDelayAdd,'--.b','LineWidth',1);                     strLegned{contLegend} = 'Delay addition'; contLegend = contLegend + 1;
        h = errorbar(info{1,1}.avDelayDel, info{1,1}.steDelayDel, '-xg','LineWidth',1);                     strLegned{contLegend} = 'Delay deletion'; contLegend = contLegend + 1;
    end
    
    
end

ylabel('Average Number of Mutations','FontSize',xylabeSize)
subname = 'NumberMutations';




%         legend('Hybrid training','Node deletion','Connection deletion','Node addition','Connection addition',...
%             'MBP', 'SA', 'Input addition', 'Input deletion', 'Delay addition', 'Delay deletion')
%
% if allrun{1,1}.var.algoFeatures == allrun{1,1}.C.MODULAR1  && allrun{1,1}.var.task2solve == allrun{1,1}.C.CLASSIFY
%     legend('TrainingMBP','Shared node deletion','Shared connection deletion','Node deletion','Connection deletion','Node addition','Connection addition')%,...
%     
% elseif allrun{1,1}.var.fixedinputs == allrun{1,1}.C.EVOLVE && allrun{1,1}.var.algoFeatures == allrun{1,1}.C.MODULAR1
%     legend('TrainingMBP','Shared node deletion','Shared connection deletion','Node deletion','Connection deletion','Node addition','Connection addition', ...
%         'Input addition', 'Input deletion', 'Delay addition', 'Delay deletion')
%     
% elseif allrun{1,1}.var.fixedinputs == allrun{1,1}.C.EVOLVE && allrun{1,1}.var.algoFeatures ~= allrun{1,1}.C.MODULAR1
%     legend('TrainingMBP','Node deletion','Connection deletion','Node addition','Connection addition', ...
%         'Input addition', 'Input deletion', 'Delay addition', 'Delay deletion')
%     
% elseif allrun{1,1}.var.task2solve == allrun{1,1}.C.CLASSIFY && allrun{1,1}.var.algoFeatures ~= allrun{1,1}.C.MODULAR1
%     legend('TrainingMBP','Node deletion','Connection deletion','Node addition','Connection addition')
%     
% end
%             'MBP', 'SA',
legend(strLegned);



set(gca, 'fontsize',gcaFotnSize, 'box', 'on');


xlabel('Generations','FontSize',xylabeSize)
string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16');

foo = 'to make a pause put s break point here';

saveas(h, [TSname, typePlot, subname,'.fig']);