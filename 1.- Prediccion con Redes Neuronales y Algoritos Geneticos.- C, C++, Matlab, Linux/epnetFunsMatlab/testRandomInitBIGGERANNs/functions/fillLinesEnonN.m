%% fill all columns of a line using e non-normalized distance
%
%
% Created       13 Oct 2010
% Modified at:
% Author:       Carlos Torres and Victor Landassuri

%% Function
function m = fillLinesEnonN(m,col,vec1,SIG)
% inputs
% m         probability matrix
% line      the acutla line to use to fill all columns (vec2)
% vec2      all the columns to fill 
% SIG       \sigma that determinate the overall connectivity

% note that here are not used the index of the vector

% Calculate a random position from vec2
% a + (b-a) * rand
unit = vec1(1,1) + (vec1(1,size(vec1,2)) - vec1(1,1) ) * rand; 
                
for i= vec1
    m(i,col) = localConnSnoNorm(unit,i, SIG);
end


