%% Take the same number of patterns from each calss for the final input
%% file to the EA
%
% Independently of the size of the file here isjust considered 1000 for
% trinig set, 100 for validation set (test set innside EA) and 100 for
% final test set
%
% The difference with the other file with a similar name is taht here each
% output can represent two classes, then two output means tow tasks like
% the what and where
%
% Created on:   16 Dec 2010
% Modified at:
% Author:       Carlos Torres and Victor Landassuri

%% function
function [nInp, nOut] = takePatterns(Inp,Out)
% Inputs
%   TInp    is the matrix of inputs. like P
%   TOut    is the matrix of output, like T
%   classes     the classes that exist
%   noClasses   number of them
%
% Outputs:
%   nInp, nOut  the new sets of inputs and output with the same nuber of
%   pattersn per class per set (training, val, test)


% counters that will be used to  know how many patterns of each class has
% been taken, used to stop the loops
% sizeOut = size(Out,2);
% noClassesPerOutput = 2; % means 0,1 per output

% I will set up this values at hand here

% how many for each one in each set
% trainEach = int16(1000/noClasses);
% valEach = int16(100/noClasses);
% testEach = int16(100/noClasses);

trainEach = int16(1000/noClasses);
valEach = int16(100/noClasses);
testEach = int16(100/noClasses);


% allocate space
train = zeros(noClasses,1);
val = zeros(noClasses,1);
test = zeros(noClasses,1);

% put how many of each one
for i = 1 : noClasses
    % each line is a class
    train(i,1) = trainEach; % class1,
    val(i,1) = valEach;
    test(i,1) = testEach;
end



% allocate space
nInp = zeros(1200,2);
nOut = zeros(1200,sizeOut);

contLine.save = 1;   % increment lines
contLine.mat = 1;    % the index of the last line used to create the sets

% First the training set
[nInp nOut, contLine ] = takePat(Inp,Out, nInp, nOut, train, contLine, ...
    classes, noClasses);

% Then the validation set
[nInp nOut, contLine ] = takePat(Inp,Out, nInp, nOut, val, contLine, ...
    classes, noClasses);

% Then the final set
[nInp nOut, contLine ] = takePat(Inp,Out, nInp, nOut, test, contLine, ...
    classes, noClasses);




function [newInp newOut, line ] = takePat(Inp,Out, newInp, newOut, SET, line, ...
    classes, noClasses)
% Function to take the patterns
%
% Inputs:
% Inp           Inputs
% Out           Outputs
% nInp          Where is saved the new inputs
% nOut          where is saved the new outputs
% SET           it can be the counters from training, val of final test set
%
% Outputs:

lines = size(Inp,1);


flag = 0;       % to know if the patterns was saved in the new matrix
for i = line.mat :lines             % all lines
    flag = 0;
    for j = 1 : noClasses
        if Out(i,:) == classes(j,:)
            if SET(j,1) > 0
                Class = j;
                SET(j,1) = SET(j,1) - 1;
                flag = 1;
                break;
            end
        end
    end
    
    % save the value only if is not used more than the allowed for any
    % class
    if flag
        newInp(line.save,:) = Inp(i,:);
        newOut(line.save,:) = Out(i,:);
        line.save = line.save + 1;
    end
    
    % finish loop if all are filled
    if SET(:,1) == 0
        line.mat = i + 1;       % to started to use the next line
        break;
    end
    
    % example to see if it works
    %     x(1,1) = 0;
    %     x(2,1) = 0;
    %     x(3,1) = 0;
    %     if x(:,1) == 0
    %         display('enter')
    %     else
    %         display('enter 2')
    %     end
end

% Original code from the function :: easy to understand
% for i = line.mat : lines             % all lines
%     flag = 0;
%     % which class
%     if Out(i,1) == 1 && Out(i,2) == 0 && SET(1,1) > 0
%         flag = 1;
%         SET(1,1) = SET(1,1) - 1;
% 
%     elseif Out(i,1) == 1 && Out(i,2) == 1 && SET(2,1) > 0
%         flag = 1;
%         SET(2,1) = SET(2,1) - 1;
% 
%     elseif Out(i,1) == 0 && Out(i,2) == 1 && SET(3,1) > 0
%         flag = 1;
%         SET(3,1) = SET(3,1) - 1;
% 
%     elseif Out(i,1) == 0 && Out(i,2) == 0 && SET(4,1) > 0
%         flag = 1;
%         SET(4,1) = SET(4,1) - 1;
% 
%     end
% 
%     % save the value only if is not used more than the allowed for any
%     % class
%     if flag
%         newInp(line.save,:) = Inp(i,:);
%         newOut(line.save,:) = Out(i,:);
%         line.save = line.save + 1;
%     end
% 
%     % finish loop if all are filled
%     if SET(1,1) == 0 && SET(2,1) == 0 && SET(3,1) == 0 && SET(4,1) == 0
%         line.mat = i + 1;       % to started to use the next line
%         break;
%     end
% end
