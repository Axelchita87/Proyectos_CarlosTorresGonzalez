%% Find how many classes there are
% Code to find how many different calsses there were generated,
% e.g. in tow output could be 2 or 4 classes
% another example of jhon 0002, there a re 5 output and it only generate 4
% classes, 5 outputs 4 classes
%
%
%
% Created on:   11 Dec 2010
% Modified at:
% Author:       Carlos Torres and Victor Landassuri

%% function
function [classes, noClasses,patterns] = findClassesOverlapping(TOut);

% Inputs
%   TOut    is the matrix of output, like T,
%
% Outputs:
%   classes         the classes that exist
%   noClasses       the number of classes that exist

lines = size(TOut,1);
cols = size(TOut,2);

patterns = zeros(cols*cols,1);  % each line represent a class,
% I consider all combinations, even they may be less

noClasses = 1;
classes = zeros(cols*cols, cols);  % variable to save ecah different class

for i = 1:lines             % all lines
    % which class
    % in 5 output there may be 25 different combinations, thus 25
    % classes for this case as jhon generate them
    
    % as I do not know how many clasese there are, I will save the
    % classes here every time I find one that is different to the
    % previous saved
    if i == 1               % save the first
        classes(i,:) = TOut(i,:);
        Class = 1;
        
    else
        % if it is not the first, compare against all previous, if it
        % is the same as one previously saved, then do not save it ,
        % and plot the x,y values with the correct line and color for
        % the class
        for j = 1 : noClasses
            if TOut(i,:) == classes(j,:)
                Class = j;
                flagClassFound = 1;
                break;          % if no breack and there another class diferent ahead, this is override and increment for ever the calsses
            else
                flagClassFound = 0;
            end
        end
        if ~flagClassFound
            noClasses = noClasses + 1;
            classes(noClasses,:) = TOut(i,:);
            Class = noClasses;
        end
    end
    
    %       % Code that show that and 'if' copmaring vectors works :)
    %       % bunt only with ==, it does not work with ~=
    %         if [1 1 1] == [1 1 1]
    %             display('it is equal')
    %         else
    %             display('it is not equal')
    %         end
    patterns(Class,1) = patterns(Class,1) + 1;
end

