%% Script to normalize and save the result of a classification task
% add the path of this function and run it form the directory where is the
% TS
% run addpath pwd in this dir
clear
clc

% Values to set, only the inputs are normalized, the outputs are binary
% values
inputs = 64;
outputs = 10;            % they are the classes

datainput = load('datainput01.txt');

% range to normalize
maxNorm = 0.9;
minNorm = 0.1;

fileName2savfe = 'dataInputNp1p9.txt';

% Before here you do not need to modify anything, just check that you add
% this path to the path of matlab



%Check that the inputs + classes are the same as the number fo columns of
%the file
if(inputs + outputs ~= size(datainput,2))
    display('Error in the number of coulmns...')
end

% separate the data to normalize from the classes
x = datainput(:,1:inputs);

% The normalization will by by columns, so there is not needed this code %
% found min matrix and max matrix
%minM = min(x(:));
%maxM = max(x(:));
% create a temporal vector to normalize
%tempx = [minM, maxM];
%[tempxN, ps] = mapminmax1(tempx,-1,1);
% normalize line by line
%for i=1:size(x,1)
%    inpNorm(i,:) = mapminmax1('apply',x(i,:),ps);
%end

% code to normalize by columns
x = x';                 % because mapminmax1 accept lines to normalize
inpNorm = mapminmax1(x, minNorm,maxNorm);
inpNorm = inpNorm';


% Put the classes together with the normalized data
inpNorm(:,inputs+1:inputs + outputs) = datainput(:,inputs+1:inputs + outputs);

%cd('txtFiles')
save (fileName2savfe, 'inpNorm', '-ascii', '-tabs');