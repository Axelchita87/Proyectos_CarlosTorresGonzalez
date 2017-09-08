%% Fill a matrix in a diagonal way for H2H and H2O
% First is filled the H2H and then the H2O
%
%
% Created       12 Oct 2010
% Modified at:
% Author:       Carlos Torres and Victor Landassuri

%% Function
function m = fillMatH2HObyCols(m,vec1,vec2,initval, finalval,exp)
% vec1 is suppose to be the hidden nodes here
inc = 0;   % col increment
x = 0;
div = 1;

div = setupDivHidden(size(vec1,2));


inc = calcInc(initval, finalval, ( (div-1) + ( size(vec1,2) * size(vec2,2) ) ) );
x = initval;
% H2H and H2H filled first the columsn and then lines
if strcmp(exp,'h') == 1  % check if first are filled columns or lines
    % fill first columns
    for i = vec1
        for j = [ vec1 vec2 ]
            if j>i
                m(i,j) = x;
                x = x + inc;
            end
        end
    end
else
    % fill first lines
    for j = [ vec1 vec2 ]
        for i = vec1 
            if i<j
                m(i,j) = x;
                x = x + inc;
            end
        end
    end
end
