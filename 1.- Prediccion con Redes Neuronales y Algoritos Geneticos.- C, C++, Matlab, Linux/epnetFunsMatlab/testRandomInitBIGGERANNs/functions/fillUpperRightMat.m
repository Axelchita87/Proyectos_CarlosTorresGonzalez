%% Fill the upper right matrix from min to max values
% This function fills the upper rights matrix horizontaly and then vertically
% form the initial value to the final
% 
%
% Created       12 Oct 2010
% Modified at:  
% Author:       Carlos Torres and Victor Landassuri

%% Function 
function m = fillUpperRightMat(m,vec1,initval, finalval,exp)
% vec1 is taken for lines and columns, so it is created a squared matrix
inc = 0;   % col increment
x = 0;
div = 1;
if size(vec1,2) > 1  % I think I do not need this as in setupDivHidden is evaluated this condition
    div = setupDivHidden(size(vec1,2));
end


inc = calcInc(initval, finalval, (div-1) );
x = initval;

if strcmp(exp,'h') == 1  % check if first are filled columns or lines
    % fil first columns
    for i = vec1
        for j = vec1
            if j>i
                m(i,j) = x;
                x = x + inc;
            end
        end
    end
else
    % fill first lines
    for j = vec1
        for i = vec1
            if i<j
                m(i,j) = x;
                x = x + inc;
            end
        end
    end
end
