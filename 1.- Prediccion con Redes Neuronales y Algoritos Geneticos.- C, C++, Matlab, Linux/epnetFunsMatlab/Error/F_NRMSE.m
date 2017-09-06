function NRMSE = F_NRMSE(Pred, toPredictF)

Mean_toPredictF = mean(toPredictF);
%Function to calculate the NRMSE
NRMSE = sqrt( sum((Pred - toPredictF).^2)  /  sum((toPredictF - Mean_toPredictF).^2) );
        %sqrt( (sum((Pred - toPredictF).^2)) / size(Pred,2))  /  sqrt( (sum((toPredictF - Mean_toPredictF).^2)) / size(Pred,2));
        %sqrt( ((sum((Pred - toPredictF).^2)) / size(Pred,2)) /  ((sum((toPredictF - Mean_toPredictF).^2)) / size(Pred,2)));
        %this 3 expresions are the same