%% Take the same number of patterns from each calss for the final input
%% file to the EA
%
% Independently of the size of the file here, it is just considered 1000 for
% trinig set, 100 for validation set (test set innside EA) and 100 for
% final test set
%
% Created on:   11 Dec 2010
% Modified at:  14 Apr 2011
% Author:       Carlos Torres and Victor Landassuri

%% function
function [nInp, nOut] = takeSamePatternsPerClass(Inp,Out,classes, noClasses,n)
% Inputs
%   TInp    is the matrix of inputs. like P
%   TOut    is the matrix of output, like T
%   classes     the classes that exist
%   noClasses   number of them
%   n           number of patterns for training, val and test set
%   n.isBalanced indicate if it is balanced each data set ir not, if it is
%                   not then it is take the patterns as they were generated
%
% Outputs:
%   nInp, nOut  the new sets of inputs and output with the same nuber of
%   pattersn per class per set (training, val, test)


% counters that will be used to  know how many patterns of each class has
% been taken, used to stop the loops
sizeOut = size(Out,2);

allpatterns = n.numberTraining + n.numberVal + n.numberTest;

% allocate space
nInp = zeros(allpatterns,2);
nOut = zeros(allpatterns,sizeOut);


% Balanced or not
if n.isBalanced == 1
    
    trainEach = int16(n.numberTraining/noClasses);
    valEach = int16(n.numberVal/noClasses);
    testEach = int16(n.numberTest/noClasses);
    
    % allocate space
    train = zeros(noClasses,1);
    val = zeros(noClasses,1);
    test = zeros(noClasses,1);
    
    % put how many of each one, as the division and then the sum of them may
    % not be exact, it is used an ofsset to be sure that all the patter are
    % formed correctly and do not have ceros at then end
    % that may cause that there wiull be more patterns from one than from
    % another when it is taken the final set, but it is not significant
    
    for i = 1 : noClasses
        % each line is a class
        train(i,1) = trainEach + 2; % class1,
        val(i,1) = valEach + 2 ;
        test(i,1) = testEach + 2;
    end
    
    
    
    
    
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
    
    
    % this was added later, I will count how many 1 and ceros there are in
    % output 1, then in output two and so on
    
    suma = sum(nOut);
    
elseif  n.isBalanced == 0
    % not balanced
    nInp = Inp(1:allpatterns,:);
    nOut = Out(1:allpatterns,:);
    
end

% counter = zeros(1,)
% for i = 1:size(nInp,2)
%     for j = 1:size(nOut,1)
%
%     end
% end





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
% line          have in which line start to save and to read
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
