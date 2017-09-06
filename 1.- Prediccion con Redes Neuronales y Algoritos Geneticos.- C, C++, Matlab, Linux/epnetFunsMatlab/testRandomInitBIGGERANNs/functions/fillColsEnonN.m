%% fill all columns of a line using e non-normalized distance
%
%
% Created       13 Oct 2010
% Modified at:
% Author:       Carlos Torres and Victor Landassuri

%% Function
function m = fillColsEnonN(m,line,vec2,SIG)
% inputs
% m         probability matrix
% line      the acutla line to use to fill all columns (vec2)
% vec2      all the columns to fill 
% SIG       \sigma that determinate the overall connectivity

% note that here are not used the index of the vector

% Calculate a random position from vec2
% a + (b-a) * rand
unit =vec2(1,1) + (vec2(1,size(vec2,2)) - vec2(1,1) ) * rand; 
                
for j= vec2
    m(line,j) = localConnSnoNorm(unit,j, SIG);
end


