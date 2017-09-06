clear
clc

cd('/media/sdb1/DocMNNExps/MEPNet04a/ChaosLorenzRK/txtFiles');
x1 = load('dataInputN1.txt');
subplot(2,1,1); plot(x1(1:1000,1))


% cd('/media/sdb1/DocMNNExps/MEPNet04a/ChaosMackey1RK/txtFiles');
% x2 = load('dataInputN2.txt');
% subplot(3,1,2); plot(x2(1:1000,1))


cd('/media/sdb1/DocMNNExps/MEPNet04a/ChaosRossler/txtFiles');
x3 = load('dataInputN6.txt');
subplot(2,1,2); plot(x3(1:1000,1))
