%% Plot special figures for comparison
% This figures are for just one experiment (with several repetitions from
% the same variable)
%
% It is plotted in lines and columns with av, std and ste
%
% Created:  26 MAr 2011
% Modified:
% Author:   Carlos Torres and Victor Landassuri

%%

for exp = 1:sizeDirCol                      % for each exp with its repetitions
   %B o t h   m o d u l a r i t i e s 
   plotBothModularitiesLines
   plotBothModularitiesBars
   
   % Fitness per module
   plotFitnessPerModule_TotalLines
   plotFitnessPerModule_TotalBars
              
   if ( info{1,1}.flagClass )    
       % Classification error per module
       plotClassifErrorPerModuleLines
       plotClassifErrorPerModuleBars
   end
   
   % Nodes per module
   plotNodesPerModuleLines
   plotNodesPerModuleBars     

   % Learning rate per module
   plotLratePerModule_Lines
   plotLratePerModule_Bars
   
end


