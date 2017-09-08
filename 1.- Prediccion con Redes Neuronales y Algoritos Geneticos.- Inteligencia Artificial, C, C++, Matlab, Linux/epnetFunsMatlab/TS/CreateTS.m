%
%script to create the TS file, useful to load all the directories 
clear
clc

d = dir;

for k=3:length(d)-5
    TS{1,k} = d(k).name;
end