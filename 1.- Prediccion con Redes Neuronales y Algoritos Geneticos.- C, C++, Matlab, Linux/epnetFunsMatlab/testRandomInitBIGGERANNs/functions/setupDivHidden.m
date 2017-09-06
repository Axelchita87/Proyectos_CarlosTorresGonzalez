%% function to calculate the number of places in a squared matrix for the
% upper left of righ section of the matrix without take into account the
% diagonal matrix
% 
% Rule to determinate how many slot there are
% 1 = 0                     = 0
% 2 = 1                     = 1
% 3 = 2 + 1                 = 3
% 4 = 3 + 2 +1              = 6
% 5 = 4 + 3 + 2 + 1         = 10
% 6 = 5 + 4 + 3 + 2 +1      = 15
% ...
%
%
% Created:      11 Oct 2010
% Modified at:  12 Oct 2010
% Author:       Carlos Torres and Victor Landassuri

function d = setupDivHidden(num)
% I only checked the function until the value 8 jeje hope it works for all
% natural numbers

d = 0;

if num > 1
    while num > 1
        num = num - 1;
        d = d + num;
    end
end
