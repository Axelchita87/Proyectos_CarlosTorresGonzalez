%function to recuperate sizes
function [sizes, counter] = recStruct_sizes(sizes, counter, file)

sizes.Sinput = zeros(1,2);
sizes.SinputF = zeros(1,2);
sizes.SinputI = zeros(1,2);
sizes.SpnI = zeros(1,2);
sizes.StnI = zeros(1,2);
sizes.SpnF = zeros(1,2);
sizes.StnF = zeros(1,2);
sizes.SinputAnn = zeros(1,2);  % the size of inputs for inside and outside
sizes.SvalI = zeros(1,2);
sizes.SvalF = zeros(1,2);

for j=1:2
    sizes.Sinput(j) = file(counter);
    counter = counter+1;
end

for j=1:2
    sizes.SinputF(j) = file(counter);
    counter = counter+1;
end
for j=1:2
    sizes.SinputI(j) = file(counter);
    counter = counter+1;
end
for j=1:2
    sizes.SpnI(j) = file(counter);
    counter = counter+1;
end
for j=1:2
    sizes.StnI(j) = file(counter);
    counter = counter+1;
end
for j=1:2
    sizes.SpnF(j) = file(counter);
    counter = counter+1;
end
for j=1:2
    sizes.StnF(j) = file(counter);
    counter = counter+1;
end
for j=1:2
    sizes.SinputAnn(j) = file(counter);
    counter = counter+1;
end
for j=1:2
    sizes.SvalI(j) = file(counter);
    counter = counter+1;
end
for j=1:2
    sizes.SvalF(j) = file(counter);
    counter = counter+1;
end

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%finish sizes from all runs, see band, look for errors
if(file(counter) ~= -1)
    'There is an error in RecStructureSizes, do not math the cases'
end
counter = counter+1;
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%