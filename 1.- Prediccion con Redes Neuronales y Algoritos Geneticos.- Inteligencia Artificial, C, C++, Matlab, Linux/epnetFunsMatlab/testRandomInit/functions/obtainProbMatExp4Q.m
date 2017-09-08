
%% Create probability matrix for Exp4 for module creations
% It is created and returned the probability matrix for the 4th
% experiment
% The probabilitis are just generated to avoid non-connected nodes and have
% a better way to initialize the matrices looking for modules or a higger
% modularity

%% Create the prob matrix in the upper right side of the matrix

function probM = obtainProbMatExp4Q(noInp, noHid, noOut, inputs, hidden, outputs,exp)

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
H2HlineI = 1;
H2HlineF = 0;
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

%% Fill the matrix with the prob

% I2H fill one line from 1 to 0 and other from 0 to 1 and so on
flag = 0;
for i = inputs
    if flag == 0    % one and one line
        probM = fillMatline(probM,i,hidden,I2HlineI, I2HlineF);
        flag = 1;
    else
        probM = fillMatline(probM,i,hidden,I2HlineF,I2HlineI);
        flag = 0;
    end
end

% I2O ceros in this moment
% probM = fillMatDiag(probM,inputs,outputs,I2OlineI, I2OcolF,exp);

% H2H
%flag = 0;
cont = 2;
if noHid > 1
    for i = hidden(1): (hidden(noHid-1))
        if flag == 0
            probM = fillMatline(probM,i,hidden(cont):hidden(noHid),H2HlineI,H2HlineF);
            flag = 1;
        else
            probM = fillMatline(probM,i,hidden(cont):hidden(noHid),H2HlineF,H2HlineI);
            flag = 0;
        end
        cont = cont +1;
    end
end

% H2O
probM = fillMatH2Omodule(probM,hidden,outputs,H2Omin, H2Omax,0);

% O2O
% for i = outputs
%     for j = outputs
%         if j>i
%             probM(i,j) = O2O;
%         end
%     end
% end


