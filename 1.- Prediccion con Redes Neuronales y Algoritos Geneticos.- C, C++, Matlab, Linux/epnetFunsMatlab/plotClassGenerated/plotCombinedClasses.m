%% Plot data set combined, where the inputs are not mixed
% Script
% Probably it could works for another kind of data set where teh inputs are
% mixed, like DS 0021a.
%
% The calsses where generated with the file genModularDS.cpp in the
% workspace2, then they were put together with the file createCombinedDS.m
%
% 
% This file only works to disple both clases, nothing is saved
%
% 
% 

%% Script

clear
clc

% configure this
% if it is used another validation set inside the EA, you can split this
% value and add it to val and test set
n.numberTraining = 1000;%3000;  % I used this only to have 5000 values
n.numberVal = 200;%1000;
n.numberTest = 200;%1000;
n.isBalanced = 0;           % 1 is ON or YES 0 is OFF or NOT

path1 = '/media/dat/workspace/epnet/dataSets/txtFilesC1-D1-A2';

%% Start method

allpatterns = n.numberTraining + n.numberVal + n.numberTest;

cd('..');
pathBase = pwd;

% SLAHS
%cd('epnetFunsMatlab');
cd('LinuxOrWindows'); 
%use adecuate paht
SLASH = isLinOrWin();

cd(path1);
addpath([pathBase,SLASH,'plotClassGenerated']); %UPDATE
% WITH NEW PATH in WROKSPACE

%cd('res');

% setup this var
numberDS = 'C1-D2'; %'0003';  % XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX <<--

obtainModleInfo;                % script containing, number of modules, outputs per module, ... per class,  fro a new class add its info  here

% load the data set
dataset = load('dataInputN');

TInp = dataset(:, 1:m.numberInpOut(1,1) );
TOut = dataset(:, m.numberInpOut(1,1)+1 : m.numberInpOut(1,1)+m.numberInpOut(1,2) );


% find how many number of classes and what classes there are in TOut
% In this moment each output can represent up to two classes
% Bu I use it to later use the same number of patterns per class
[classes, noClasses,p0] = findClassesOverlapping(TOut);


% Plot the classes, p is the number of patterns per class
%[h] = plotClasses(TInp, TOut);%, classes, noClasses);


%% take the same number of patters per class
% they will at random, but it is going to be 3 blocks
% 1st first 1000 values for training
% 2nd 100 for validation (obtain fitness inside EA)
% 3rd 100 final test set 
%
% if there are 4 classes, in set 1 there will be 250 patterns of each class
% set 2 25 from each class and set 3 the same(1:1200,:);

% Probabily if there are errors or somthing does not work, maybe I could
% put more values to one set or another XXXXXXX in case one set has a small
% area, thus in proportion formt he area there will be many patterns
% Not done here

% original function to generate the data set
[newTInp, newTOut] = takeSamePatternsPerClass(TInp,TOut, classes, noClasses,n);


% figure % trraining set
%  [hTraining] = plotClasses(newTInp(1 : n.numberTraining, :), ...
%      newTOut(1 : n.numberTraining, :), ...
%      classes, m, noClasses ); 
% plot then new training, val and test set 1200 values in total

% Comment this block if the data set only have one class
if(m.manyClass == 1)
figure
 [hTVT] = plotClassesCombined(newTInp, newTOut, classes, noClasses, m); % all data sets
 
 figure
 [hVal] = plotClassesCombined(newTInp(n.numberTraining+1 : n.numberTraining + n.numberVal, :), ...
     newTOut(n.numberTraining+1 : n.numberTraining + n.numberVal, :), ...
     classes, noClasses, m ); % validation, test set indside
 
 figure
 [hTest] = plotClassesCombined(newTInp(n.numberTraining + n.numberVal + 1 : n.numberTraining + n.numberVal + n.numberTest, :), ...
     newTOut(n.numberTraining + n.numberVal + 1 : n.numberTraining + n.numberVal + n.numberTest, :), ...
     classes, noClasses, m); % test set outside
end

% use this instead if you want to test something, e.g. 400 for traing 400
%for test and 400 for test outside, in the same order as they appear in
%the files

%     newTInp = TInp;
%     newTOut = TOut;
%     figure
%     [hTVT] = plotClasses(newTInp(1:400,:), newTOut(1:400,:), classes, noClasses);
%     figure
%     [hVal] = plotClasses(newTInp(401:800,:), newTOut(401:800,:), classes, noClasses ); % Trainig Validatio and test set
%     figure
%     [hTest] = plotClasses(newTInp(801:1200,:), newTOut(801:1200,:) , classes, noClasses );

% aditional figure to know the bad predictions



%% Save data sets and figures

% DATA SETS
% save the final data sets, just one matrix [Inp,Out]
% noInp = size(TInp,2);
% noOut = size(TOut,2);
% 
% dataInputN = zeros(allpatterns,noInp+noOut);
% 
% % copy inputs
% dataInputN(1:allpatterns,1:noInp) = newTInp(1:allpatterns,:);
% dataInputN(1:allpatterns,noInp+1:noInp+noOut) = newTOut(1:allpatterns,:);
% 
% save (['dataInputN5000val_noBalanced',numberDS,'.txt'], 'dataInputN', '-ascii', '-tabs');
% 
% % FIGURES
% if(m.manyClass == 1)
%     cd([path1,SLASH,'plotClassGen2Fgis'])
%     %saveas(h, ['dsAll',numberDS,'.fig']);
%     saveas(hTVT, ['dsTVT',numberDS,'.fig']);
%     saveas(hVal, ['dsVal',numberDS,'.fig']);
%     saveas(hTest, ['dsTest',numberDS,'.fig']);
%     
%     close all
% end
rmpath([pathBase,SLASH,'plotClassGenerated']);