%% fill Matrix using e with the normalized idstance
%
%
% Created       13 Oct 2010
% Modified at:
% Author:       Carlos Torres and Victor Landassuri

%% Function
function m = fillMatE(m,vec1,vec2,SIG,normalized)

a = size(vec1,2);
b = size(vec2,2);

if b == 1   % just one output
    
    inc = calcInc(0.5, 1, ( (a * b) -1) );
    x = 0.5;
    
    for j = vec2
        for i = vec1
            m(i,j) = x;
            x = x + inc;
        end
    end
    
else
    
    
    if strcmp(normalized,'norm')
        % Use the e normalized distance to assing the connectivity
        idxConti = 1;
        for i = vec1
            idxContj = 1;
            for j = vec2
                m(i,j) = localConnS(idxConti,idxContj, a, b, SIG);
                idxContj = idxContj + 1;
            end
            idxConti = idxConti + 1;
        end
        
    else
        % use the non-normalized e distance
        idxConti = 1;
        for i = vec1
            idxContj = 1;
            for j = vec2
                m(i,j) = localConnSnoNorm(idxConti,idxContj, SIG);
                idxContj = idxContj + 1;
            end
            idxConti = idxConti + 1;
        end
        
    end
    
    
end