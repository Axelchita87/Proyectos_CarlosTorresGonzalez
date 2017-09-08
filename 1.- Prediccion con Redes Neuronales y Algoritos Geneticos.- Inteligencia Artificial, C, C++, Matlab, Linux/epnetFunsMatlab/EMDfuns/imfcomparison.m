clear
clc

load datainput.txt

%limit the size of the TS
if size(datainput,1) > 5000
    datainput = datainput(1:5000,:);
end
IMF = emd(datainput);

%% Now what happend if the have more or less information in the TS, 
%The IMFs change in shape and number of them, the more informatin the more
%IMFs obtained

sizeTS = size(datainput);

%%take 70% of the information
newsize = int16(sizeTS(1,1) * .7);
data1 = datainput(1:newsize,:);

%calculate the new IMFs
IMF1 = emd(data1);

%%take 50% of the information
newsize = int16(sizeTS(1,1) / 2);
data2 = datainput(1:newsize,:);

%calculate the new IMFs
IMF2 = emd(data2);

fprintf('Here analyse the sizes of the IMFs')
%% now how can I compare
% I will take the a set of IMFs from the same size from all, IMF, IMF1 and
% IMF2, the smallest value is from IMF2, so this will be the saze of the
% new set, after that I will rest the correspondient IMF, between two sets,
% the result must be zero if they are similar

IMFnew = IMF(:,1:newsize);
s = size(IMFnew,1);

IMF1new = IMF1(:,1:newsize);
s1 = size(IMF1new,1);

IMF2new = IMF2(:,1:newsize);
s2 = size(IMF2new,1);

%plot them
for i=1:4 %only the firsts
    plot(IMFnew(i,:));
    hold all
    plot(IMF1new(i,:));
    plot(IMF2new(i,:)); 
    close Figure 1;
    
    %perfomr rest
    diffIMF_IMF1 = IMFnew(i,:) - IMF1new(i,:);
    diffIMF_IMF2 = IMFnew(i,:) - IMF2new(i,:);
    diffIMF_IMF3 = IMF1new(i,:) - IMF2new(i,:);
    
    plot(diffIMF_IMF1);
    hold all
    plot(diffIMF_IMF2);
    plot(diffIMF_IMF3);
    close Figure 1;
end
    %its quite similar the three, 
    %for MackeyRK


%Compare the residuo 
plot(IMFnew(s,:));
hold all
plot(IMF1new(s1,:));
plot(IMF2new(s2,:));
close Figure 1;


%% Now check that the sum of the IMFs gives the original
reconsturctedIMF = zeros(1,sizeTS(1,1));
for i=1:s
    reconsturctedIMF(1,:) = reconsturctedIMF(1,:) + IMF(i,:);
end
diff1 = reconsturctedIMF - datainput';
plot(diff1)
close Figure 1

% for 70%
reconsturctedIMF1 = zeros(1,int16(sizeTS(1,1) * .7));
for i=1:s1
    reconsturctedIMF1(1,:) = reconsturctedIMF1(1,:) + IMF1(i,:);
end
diff2 = reconsturctedIMF1 - data1';
plot(diff2)
close Figure 1

% for 30%
reconsturctedIMF2 = zeros(1,int16(sizeTS(1,1) / 2));
for i=1:s2
    reconsturctedIMF2(1,:) = reconsturctedIMF2(1,:) + IMF2(i,:);
end
diff3 = reconsturctedIMF2 - data2';
plot(diff3)
close Figure 1

%% Now check how much affect if the reconstruction does not take into
%% account the last IMF or residue
% reconsturctedIMF = zeros(1,sizeTS(1,1));
% for i=1:s-1
%     reconsturctedIMF(1,:) = reconsturctedIMF(1,:) + IMF(i,:);
% end
% diff1 = datainput' - reconsturctedIMF;
% plot(diff1)
% close Figure 1
% 
% % for 70%
% reconsturctedIMF1 = zeros(1,int16(sizeTS(1,1) * .7));
% for i=1:s1-1
%     reconsturctedIMF1(1,:) = reconsturctedIMF1(1,:) + IMF1(i,:);
% end
% diff2 = data1' - reconsturctedIMF1;
% plot(diff2)
% close Figure 1
% 
% % for 30%
% reconsturctedIMF2 = zeros(1,int16(sizeTS(1,1) / 2));
% for i=1:s2-1
%     reconsturctedIMF2(1,:) = reconsturctedIMF2(1,:) + IMF2(i,:);
% end
% diff3 = data2' - reconsturctedIMF2;
% plot(diff3)
% close Figure 1


