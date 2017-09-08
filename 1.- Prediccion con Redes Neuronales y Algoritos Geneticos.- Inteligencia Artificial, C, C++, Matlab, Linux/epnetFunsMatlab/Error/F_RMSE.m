function RMSE = F_RMSE(Pred, toPredictF)


%Function to calculate the NRMSE
RMSE = sqrt( sum((Pred - toPredictF).^2)  /  size(Pred,2) );
        