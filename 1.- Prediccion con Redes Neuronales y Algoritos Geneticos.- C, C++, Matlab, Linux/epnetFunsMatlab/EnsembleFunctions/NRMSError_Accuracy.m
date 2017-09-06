function ensemble = NRMSError_Accuracy(ensemble, toPredictF, Mean_toPredictF, var)

ensemble.NRMSE = sqrt( sum((ensemble.Pred - toPredictF).^2)  /  sum((toPredictF - Mean_toPredictF).^2) );
        
        %Calculate AccuracyPoint and accuracy
    
        %claulate the abs of prediction and toPredic
    
        abspred = abs(ensemble.Pred);
        abso = abs(toPredictF);
        sumVal = zeros(var.sizetpos,var.Pred_stepAhead);
        for l=1:var.sizetpos
            for m=1:var.Pred_stepAhead
                if( abso(l,m) >= abspred(l,m) )
                    ensemble.accuracyPoint(l,m) = (abspred(l,m)*100)/abso(l,m);
                else
                    diff(l,m) = (abspred(l,m) - abso(l,m)) * 2;
                    ensemble.accuracyPoint(l,m) = ((abspred(l,m)-diff(l,m))*100) / abso(l,m);
                end
                if(ensemble.accuracyPoint(l,m) < 0)
                    ensemble.accuracyPoint(l,m) = 0;
                end
                sumVal(l) = sumVal(l) + ensemble.accuracyPoint(l,m);
            end
        end
        %obtain the final accuracy, in general over the prediction
        ensemble.accuracy = sumVal(l)/var.Pred_stepAhead;