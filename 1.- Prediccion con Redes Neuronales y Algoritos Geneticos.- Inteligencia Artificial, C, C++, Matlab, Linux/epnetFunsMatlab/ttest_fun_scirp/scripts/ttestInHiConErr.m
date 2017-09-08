%Script to save the values and perfor the ttest

%save to have all the values of all TS at the end
    
    ALLTSres{TSdir,1}.ErrorPerRun = ErrorPerRun';
    ALLTSres{TSdir,1}.InputsPerRun = InputsPerRun';
    ALLTSres{TSdir,1}.HiddenPerRun = HiddenPerRun';
    ALLTSres{TSdir,1}.ConnPerRun = ConnPerRun';
    
    ALLTSres{TSdir,1}.AvErrorPerRun = AvErrorPerRun;
    ALLTSres{TSdir,1}.AvInputsPerRun = AvInputsPerRun;
    ALLTSres{TSdir,1}.AvHiddenPerRun = AvHiddenPerRun;
    ALLTSres{TSdir,1}.AvConnPerRun = AvConnPerRun;
    
    %find the smaller average error
    [minerror,I] = min(AvErrorPerRun);
    [minInputs,Iinputs] = min(AvInputsPerRun);
    [minHid,Ihid] = min(AvHiddenPerRun);
    [minCon,Icon] = min(AvConnPerRun);
    
    
    ALLTSres{TSdir,1}.minerror = minerror;
    ALLTSres{TSdir,1}.minerrorPos = I;
    


%after it was found, see if there is statistical significance against all other experiment
    %Comment or uncomment this as required
    
    alpha = 0.05;
    tail='both';
    type='unequal';

    for itest=1:tamExps
        if itest ~= I    % not calculate the ttest against the same exp
            %error
            [h,p,ci] = ttest2(ALLTSres{TSdir,1}.ErrorPerRun(I,:),ALLTSres{TSdir,1}.ErrorPerRun(itest,:),alpha, tail, type);
            if p < 0.05
                ttestNRMSEAllTS(TSdir,itest) = 1;
            else
                ttestNRMSEAllTS(TSdir,itest) = -1;
            end 
        end
        
        if itest ~= Iinputs    % not calculate the ttest against the same exp
            %inputs
            [hI,pInput,ciI] = ttest2(ALLTSres{TSdir,1}.InputsPerRun(Iinputs,:),ALLTSres{TSdir,1}.InputsPerRun(itest,:),alpha, tail, type);  %tail is default to both, 2 in excel
            if pInput < 0.05
                ttestInputAllTS(TSdir,itest) = 1;
            else
                ttestInputAllTS(TSdir,itest) = -1;
            end
        end
        
        if itest ~= Ihid    % not calculate the ttest against the same exp
            %Hidden
            [hH,pHidden,ciH] = ttest2(ALLTSres{TSdir,1}.HiddenPerRun(Ihid,:),ALLTSres{TSdir,1}.HiddenPerRun(itest,:),alpha, tail, type);  %tail is default to both, 2 in excel
            if pHidden < 0.05
                ttestHiddenAllTS(TSdir,itest) = 1;
            else
                ttestHiddenAllTS(TSdir,itest) = -1;
            end
        end
        
        if itest ~= Icon    % not calculate the ttest against the same exp
            %Connections
            [hC,pConn,ciC] = ttest2(ALLTSres{TSdir,1}.ConnPerRun(Icon,:),ALLTSres{TSdir,1}.ConnPerRun(itest,:),alpha, tail, type);  %tail is default to both, 2 in excel
            if pConn < 0.05
                ttestConnAllTS(TSdir,itest) = 1;
            else
                ttestConnAllTS(TSdir,itest) = -1;
            end
        end
    end
    
    