
%% Create probability matrix for Exp4 for module creations
% It is created and returned the probability matrix for the 4th
% experiment
% The probabilitis are just generated to avoid non-connected nodes and have
% a better way to initialize the matrices looking for modules or a higger
% modularity

%% Create the prob matrix in the upper right side of the matrix

function probM = obtainProbMatExp8L(noInp, noHid, noOut, inputs, hidden, outputs,eSIG,eSIGnoNorm,exp)

allnodes =  noInp + noHid + noOut;

probM = zeros(allnodes,allnodes);

%% initial and final values per line and col for each block
% I2H
I2HlineI = 1;
I2HlineF = 0;
%I2HcolI = 1;
%I2HcolF = 1;

% I2O
I2OlineI = 0;
% I2OlineF = 0.1;
% I2OcolI = 0.5;
I2OcolF = 0;

% H2H
H2HlineI = 0.1;
H2HlineF = .5;
% H2HcolI = 0.5;
%H2HcolF = 0;

% H2O
if noOut > 1
    H2Omax = 1;
    H2Omin = 0;
else
    H2Omax = 1;
    H2Omin = 0.6;
end
%H2OlineF = 0.1;
%H2OcolI = 0.5;
%H2OcolF = 1;

% O2O
O2O = 0.0;

% eSIG = 1;
% eSIGnoNorm = 1;

%% Fill the matrix with the prob

% I2H fill one line from 1 to 0 and other from 0 to 1 and so on
%probM = fillMatE(probM,inputs,hidden, eSIG,'norm');
for i = hidden
    probM = fillLinesEnonN(probM,i,inputs,eSIGnoNorm);
end


% I2O ceros in this moment
% probM = fillMatDiag(probM,inputs,outputs,I2OlineI, I2OcolF,exp);

% H2H
probM = fillUpperRightMat(probM,hidden,H2HlineI, H2HlineF,exp);

% H2O
probM = fillMatE(probM,hidden,outputs, eSIG,'norm');
% for i = outputs
%     probM = fillLinesEnonN(probM,i,hidden,eSIGnoNorm);
% end

% O2O
% for i = outputs
%     for j = outputs
%         if j>i
%             probM(i,j) = O2O;
%         end
%     end
% end


