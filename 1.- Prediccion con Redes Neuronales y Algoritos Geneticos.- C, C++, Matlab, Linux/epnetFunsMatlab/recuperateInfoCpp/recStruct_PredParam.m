function [PP, counter] = recStruct_PredParam(PP, c, v, counter, file)
% Function to recuperate the structure str_PredParam
% T represent the target
% P represent the inputs


% % Load some var for the case of classification tasks/module1
% Modules = 0;
% v.NUM_MODULES = 0;
% if v.task2solve == c.CLASSIFY
%     Modules = load('../txtFiles/nameModules.txt');
%     v.NUM_MODULES = size(Modules,2);
% end


PP.linesT = file(counter);                      counter = counter+1;
PP.colsT = file(counter);                       counter = counter+1;
PP.linesP = file(counter);                      counter = counter+1;
PP.colsP = file(counter);                       counter = counter+1;

%inputANN
% for j=1:PP.colsP
%     for k=1:numImpAnn
%         PP.inputAnn(j,k) = file(counter);     counter = counter+1;
%     end
% end
% 
% %toPredict
% for j=1:PP.linesT
%     for k=1:PP.colsT
%         PP.toPredict(j,k) = file(counter);    counter = counter+1;
%     end
% end

%Pred
for j=1:PP.linesT
    for k=1:PP.colsT
        PP.Pred(j,k) = file(counter);           counter = counter+1;
    end
end

% incorrect prediciton
for j=1:v.NUM_MODULES
    for k=1:PP.colsT
        PP.incorrectPred(j,k) = file(counter);           counter = counter+1;
    end
end


%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%finish sizes from all runs, see band, look for errors
if(file(counter) ~= -1)
    'There is an error in recStruct_PredParam, do not math the cases'
end
counter = counter+1;
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%



%NRMSE
for j=1:PP.linesT
    PP.NRMSE(j,1) = file(counter);              counter = counter+1;
end

%MSE
% for j=1:PP.linesT
%     PP.MSE(j,1) = file(counter);                counter = counter+1;
% end

%RMSE
for j=1:PP.linesT
    PP.RMSE(j,1) = file(counter);               counter = counter+1;
end


PP.Epercentage = file(counter);                 counter = counter+1;



 % EpercentagePerModule
    for j=1:v.NUM_MODULES
        PP.EpercentagePerModule(j,1) = file(counter);               counter = counter+1;
    end
    

if v.task2solve == c.CLASSIFY && v.isModule1 == c.ON
       
    % Classfication error per modulae
    for j=1:v.NUM_MODULES
        PP.classifErrorPerModule(j,1) = file(counter);               counter = counter+1;
    end
end



PP.classifError = file(counter);                 counter = counter+1;

%accuracyPoint
for j=1:PP.linesT
    for k=1:PP.colsT
        PP.accuracyPoint(j,k) = file(counter);  counter = counter+1;
    end
end


%accuracy
for j=1:PP.linesT
    PP.accuracy(j,1) = file(counter);           counter = counter+1;
end

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%finish sizes from all runs, see band, look for errors
if(file(counter) ~= -1)
    'There is an error in recStruct_PredParam, do not math the cases'
end
counter = counter+1;
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


