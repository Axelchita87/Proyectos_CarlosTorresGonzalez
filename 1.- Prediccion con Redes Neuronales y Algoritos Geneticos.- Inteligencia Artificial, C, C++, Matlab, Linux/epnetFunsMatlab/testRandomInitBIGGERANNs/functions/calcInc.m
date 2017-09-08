%% Calculate increment
% It is calculated the incremnet given the initial and final values and the
% number of slots to fill
%
% Created       9 Nov 2010
% Modified at:  
% Author:       Carlos Torres and Victor Landassuri


%% Function
function incremet = calcInc(init, final, slots)
incremet = ( (init - final) / slots) * -1;
