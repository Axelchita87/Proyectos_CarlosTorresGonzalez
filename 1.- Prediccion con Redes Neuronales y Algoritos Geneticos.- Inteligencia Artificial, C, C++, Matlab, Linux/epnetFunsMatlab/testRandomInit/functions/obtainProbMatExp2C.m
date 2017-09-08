
%% Create probability matrix for Exp2
% It is created and returned the probability matrix for the second
% experiment
% The probabilitis are just generated to avoid non-connected nodes and have
% a better way to initialize the matrices

%% Create the prob matrix in the upper right side of the matrix

function probM = obtainProbMatExp2C(noInp, noHid, noOut, inputs, hidden, outputs,exp)

allnodes =  noInp + noHid + noOut;

probM = zeros(allnodes,allnodes);

%% initial and final values per line and col for each block
% I2H
I2HlineI = 1;
I2HlineF = 0.1;
I2HcolI = 1;
I2HcolF = 1;

% I2O
I2OlineI = 0.5;
% I2OlineF = 0.1;
% I2OcolI = 0.5;
I2OcolF = 0.1;

% H2H
H2HlineI = 0.1;
% H2HlineF = 1;
% H2HcolI = 0.5;
H2HcolF = 0.5;

% H2O
H2OlineI = 0.1;
%H2OlineF = 0.1;
%H2OcolI = 0.5;
H2OcolF = 1;

% O2O
O2O = 0.5;

%% Fill the matrix with the prob

% I2H and I2O in ahorizontal line
probM = fillMatline(probM,inputs,[hidden outputs],I2HlineI, I2HlineF);

% H2H
probM = fillUpperRightMat(probM,hidden,H2HlineI, H2HcolF,exp);

% H2O
probM = fillMatDiag(probM,hidden,outputs,H2OlineI, H2OcolF,exp);


% O2O
% for i = outputs
%     for j = outputs
%         if j>i
%             probM(i,j) = O2O;
%         end
%     end
% end



