%% Fill a matrix in a diagonal way with the probabilities
% This function fills first columns and then lines in a diagonal (decreasing
% the values) until is areached the final lower right value of the matrix.
%
% Created       12 Oct 2010
% Modified at:
% Author:       Carlos Torres and Victor Landassuri

%% Function
function m = fillMatDiag(m,vec1,vec2,initval, finalval,exp)
% vec1 is taken for lines and columns, so it is created a squared matrix
inc = 0;   % col increment
x = 0;
inc = calcInc(initval, finalval, ( size(vec1,2) * size(vec2,2) -1) );

x = initval;
if strcmp(exp,'h') == 1  % check if first are filled columns or lines
    % fil first columns
    for i = vec1
        for j = vec2
            m(i,j) = x;
            x = x + inc;
        end
    end
else
    % first the lines (vertical)
    for j = vec2
        for i = vec1
            m(i,j) = x;
            x = x + inc;
        end
    end
end

