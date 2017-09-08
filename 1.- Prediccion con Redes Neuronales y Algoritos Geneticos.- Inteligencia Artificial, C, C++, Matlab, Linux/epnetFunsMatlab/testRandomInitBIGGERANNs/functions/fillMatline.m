%% Fill a matrix in a horizontal line with probabilities
% This function fills a matrix horizontali form the initial value to the
% final
% For squared a non sqaures matrices
%
% Created       12 Oct 2010
% Modified at:  9 Nov 2010
% Author:       Carlos Torres and Victor Landassuri

%% Function 
function m = fillMatline(m,vec1,vec2,initval, finalval)
inc = 0;   % col increment
x = 0;

for i = vec1
    % Calculate the increment, it does not matter if initial is < or > than
    % final, automatically it is calculated the increment as positive or
    % negative with the *-1 at the end
    inc = calcInc(initval, finalval, size(vec2,2) - 1);
    x = initval;
    for j = vec2
        m(i,j) = x;
        x = x + inc;      
    end
end