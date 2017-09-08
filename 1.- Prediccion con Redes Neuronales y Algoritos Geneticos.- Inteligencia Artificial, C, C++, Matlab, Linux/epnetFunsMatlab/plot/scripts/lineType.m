%% Figure Format (script)
% Declaration of the format of the type of lines, color, type, thick, ...
% from figures and size from the text 
%
% Created:  21 Feb 2011
% Modified: 
% Author:   Carlos Torres and Victor Landassuri

%% Declaration of variables
% Lines 
lines{1,1} = '-';           %default, not used
lines{1,2} = '--';
lines{1,3} = '.-';
lines{1,4} = ':';

lines{1,5} = '-+';           
lines{1,6} = '--o';
%lines{1,7} = '.-';
lines{1,7} = ':x';

lines{1,8} = '-.';           
lines{1,9} = '--s';
% lines{1,11} = '.-d';
lines{1,10} = ':^';

lines{1,11} = '-v';           
lines{1,12} = '--p';
% lines{1,15} = '.-h';
lines{1,13} = ':+';

lines{1,14} = '-o';           
lines{1,15} = '--*';
% lines{1,19} = '.-x';
lines{1,16} = ':s';

% Text
gcaFotnSize = 12;           % size for the tick and legend
xylabeSize = 14;               % x and y labes size