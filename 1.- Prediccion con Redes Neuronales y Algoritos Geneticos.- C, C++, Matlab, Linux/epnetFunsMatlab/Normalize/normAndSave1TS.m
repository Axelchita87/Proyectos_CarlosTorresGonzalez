%% Script to normalize and save the result
% add the path of this function and run it form the directory where is the
% TS

clear
clc

%load BD_Prueba1_DO.txt
datainput = load('BD_Prueba1_DO.txt');
inpNorm = mapminmax1(datainput',-0.9,0.9);
inpNorm = inpNorm';

%cd('txtFiles')
save ('dataInputN.txt', 'inpNorm', '-ascii', '-tabs');