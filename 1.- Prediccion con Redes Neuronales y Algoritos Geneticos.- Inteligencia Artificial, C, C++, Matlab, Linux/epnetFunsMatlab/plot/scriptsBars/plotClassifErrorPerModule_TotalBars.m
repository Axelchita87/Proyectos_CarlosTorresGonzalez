%% Plot Classification error per module Figure
% It is Classification error per module figure in Av, std or ste
%
% Created:  10 Mar 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%
clf
hold all



if strcmp(typePlot, 'AV')
    
    for alldir = 1:info{1,1}.noModules + 1
        if alldir == 1                      % this 'if' is to use 'lines' correctly
            h = plot(info{1,1}.avClassifE, lines{1,alldir},'LineWidth',1);
        else
            % 'alldir-1' because I introduce the previous if, so the total
            % fitness uses the type line 1
            h = plot(info{1,1}.AvClassifErrPerMod{alldir-1,1}, lines{1,alldir},'LineWidth',1);
            %text(150,.1,'\leftarrow Strict value');
        end
    end
    
elseif strcmp(typePlot, 'STD')
    
    for alldir = 1:info{1,1}.noModules + 1
        if alldir == 1
            h = errorbar(info{1,1}.avClassifE,info{1,1}.stdClassifE,lines{1,alldir},'LineWidth',1);
        else
            h = errorbar(info{1,1}.AvClassifErrPerMod{alldir-1,1}, info{1,1}.stdClassifErrPerMod{alldir-1,1}, lines{1,alldir},'LineWidth',1);
        end
    end
    
elseif strcmp(typePlot, 'STE')
    
    for alldir = 1:info{1,1}.noModules + 1
        if alldir == 1
            h = errorbar(info{1,1}.avClassifE,info{1,1}.steClassifE,lines{1,alldir},'LineWidth',1);
        else
            h = errorbar(info{1,1}.AvClassifErrPerMod{alldir-1,1}, info{1,1}.steClassifErrPerMod{alldir-1,1}, lines{1,alldir},'LineWidth',1);
        end
    end
end

ylabel('Average Classification Error','FontSize',xylabeSize)
subname = 'ClassifErrorPerModuleTOTAL';




legend('Total error','Module 1 error','Module 2 error');



set(gca, 'fontsize',gcaFotnSize, 'box', 'on');


xlabel('Generations','FontSize',xylabeSize)
string2title = ['\it{',TSname,'}'];
title(string2title,'FontSize',16');

foo = 'to make a pause put s break point here';

saveas(h, [TSname, typePlot, subname,'.fig']);