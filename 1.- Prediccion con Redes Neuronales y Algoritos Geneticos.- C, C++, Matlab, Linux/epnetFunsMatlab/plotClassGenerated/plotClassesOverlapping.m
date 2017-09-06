%% Plot classification areas
% It is taken the output of a c++ code (genDataSetModular) for inputs and
% output and it is plotted the reuslts to see the classes formed
% This is to understand the code from John
% and it can be considered as an example to understand all,
% to plot more classes it is used an extra code see below
%
% Created on:   11 Dec 2010
% Modified at:
% Author:       Carlos Torres and Victor Landassuri

%% function
function [h, patterns, classes] =  plotClassesOverlapping(TInp, TOut, classes, noClasses)
% Inputs
%   TInp    is the matrix of inputs. like P
%   TOut    is the matrix of output, like T, the number of them represent
%   the classes
% Outputs:
%   h               handler for the figure plotted
%   patterns        how many patterns used for each class
%   classes         the classes that exist
%   contDiffClass   the number of classes that exist

%% Example to plot two classes

gcaFotnSize = 12;           % size for the tick and legend
lines = size(TInp,1);

clf
hold all

%if (size(TOut,2) == 2)  % this code is an example to understan how to dela
%with two output with 4 classes

%     patterns = zeros(4,1);
%
%     for i = 1:lines             % all lines
%         % which class
%         if TOut(i,1) == 1 && TOut(i,2) == 0
%             h = plot( TInp(i,1),TInp(i,2),'+r','LineWidth',1);
%             patterns(1,1) = patterns(1,1) + 1;
%
%         elseif TOut(i,1) == 1 && TOut(i,2) == 1
%             h = plot( TInp(i,1),TInp(i,2),'ok','LineWidth',1);
%             patterns(2,1) = patterns(2,1) +1;
%
%         elseif TOut(i,1) == 0 && TOut(i,2) == 1
%             h = plot( TInp(i,1),TInp(i,2),'*b','LineWidth',1);
%             patterns(3,1) = patterns(3,1) +1;
%
%         elseif TOut(i,1) == 0 && TOut(i,2) == 0
%             h = plot( TInp(i,1),TInp(i,2),'.m','LineWidth',1);
%             patterns(4,1) = patterns(4,1) + 1;
%         end
%     end
%
%
% elseif (size(TOut,2) > 2)
% If there are more classes, plot them

sizeInp = size(TInp,2);
sizeOut = size(TOut,2);

stileL{1,1} = '+r';
stileL{2,1} = 'ob';
stileL{3,1} = '*c';
stileL{4,1} = '.m';
stileL{5,1} = 'xg';
stileL{6,1} = 'sy';
stileL{7,1} = 'dk';
stileL{8,1} = '^r';
stileL{9,1} = 'vg';
stileL{10,1} = '>b';
stileL{11,1} = '<c';
stileL{12,1} = 'pm';
stileL{13,1} = 'hy';

stileL{14,1} = '+k';
stileL{15,1} = 'or';
stileL{16,1} = '*b';
stileL{17,1} = '.c';
stileL{18,1} = 'xn';
stileL{19,1} = 'sg';
stileL{20,1} = 'dy';
stileL{21,1} = '^k';
stileL{22,1} = 'vr';
stileL{23,1} = '>g';
stileL{24,1} = '<b';
stileL{25,1} = 'pc';
stileL{26,1} = 'hm';

patterns = zeros(noClasses,1);  % each line represent a class,
% I consider all combinations, even they mab be less

for i = 1:lines             % all lines
    for j = 1 : noClasses
        if TOut(i,:) == classes(j,:)
            Class = j;
            %flagClassFound = 1;
            break;
        end
    end
    
    
    % plot
    h = plot( TInp(i,1),TInp(i,2), stileL{Class,1},'LineWidth',1);
    patterns(Class,1) = patterns(Class,1) + 1;
    
end
% To has a square in the figure, if not it looks like oval
daspect([1,1,1])

display('code line'); 
for i = 1:noClasses
    disp(['class ', num2str(i), stileL(i,:), num2str(classes(i,:)) ]);
end
%end

daspect([1,1,1])
set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
