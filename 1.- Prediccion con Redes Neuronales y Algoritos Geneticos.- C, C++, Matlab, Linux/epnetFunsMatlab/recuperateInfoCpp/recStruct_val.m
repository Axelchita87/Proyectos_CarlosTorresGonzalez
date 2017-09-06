%function to recuperate the validation sets
function [val, counter] = recStruct_val(val, counter, file, Sval, Stn)

%recuperate valF.pn
for j=1:Sval(1)
    for k=1:Sval(2)
        val.pn(j,k) = file(counter);
        counter = counter+1;
    end
end
%recuperate valF.tn
for j=1:Stn(1)
    for k=1:Sval(2)
        val.tn(j,k) = file(counter);
        counter = counter+1;
    end
end
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%finish sizes from all runs, see band, look for errors
if(file(counter) ~= -1)
    'There is an error in RecStruct_val, do not math the cases'
end
counter = counter+1;
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
