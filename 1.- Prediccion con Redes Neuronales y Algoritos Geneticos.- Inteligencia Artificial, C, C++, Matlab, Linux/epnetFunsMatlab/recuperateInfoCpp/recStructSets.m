function [sets, counter] = recStructSets(sets, counter, file)

%recuperate structure for sizes
sets.sizes = [];
[sets.sizes, counter] = recStruct_sizes(sets.sizes, counter, file);



%% recuperate variables from valF, valI ... val psI
%allocate Space
sets.valF.pn = zeros(sets.sizes.SvalF(1),sets.sizes.SvalF(2));
sets.valF.tn = zeros(sets.sizes.StnI(1),sets.sizes.SvalF(2));
sets.valI.pn = zeros(sets.sizes.SvalI(1),sets.sizes.SvalI(2));
sets.valI.tn = zeros(sets.sizes.StnI(1),sets.sizes.SvalI(2));

%recuperate structure for validation
%recuperate valF (pn and tn)
[sets.valF, counter] = recStruct_val(sets.valF, counter, file, ...
    sets.sizes.SvalF, sets.sizes.StnF);
%recuperate valI (pn and tn)
[sets.valI, counter] = recStruct_val(sets.valI, counter, file, ...
    sets.sizes.SvalI, sets.sizes.StnI);




%% Section for tnF, pnF tnI pn I
%allocate space
sets.tnF = zeros(sets.sizes.StnF(1),sets.sizes.StnF(2));
sets.pnF = zeros(sets.sizes.SpnF(1),sets.sizes.SpnF(2));
sets.tnI = zeros(sets.sizes.StnI(1),sets.sizes.StnI(2));
sets.pnI = zeros(sets.sizes.SpnI(1),sets.sizes.SpnI(2));

%recuperate tnF
for j=1:sets.sizes.StnF(1)
    for k=1:sets.sizes.StnF(2)
        sets.tnF(j,k) = file(counter);
        counter = counter+1;
    end
end
%recuperate pnF
for j=1:sets.sizes.SpnF(1)
    for k=1:sets.sizes.SpnF(2)
        sets.pnF(j,k) = file(counter);
        counter = counter+1;
    end
end
%recuperate tnI
for j=1:sets.sizes.StnI(1)
    for k=1:sets.sizes.StnI(2)
        sets.tnI(j,k) = file(counter);
        counter = counter+1;
    end
end
%recuperate pnI
for j=1:sets.sizes.SpnI(1)
    for k=1:sets.sizes.SpnI(2)
        sets.pnI(j,k) = file(counter);
        counter = counter+1;
    end
end



%section for inputI inputF nvarsnet nvars // with this finis sets
%allocate space
sets.inputI = zeros(sets.sizes.SinputI(1),sets.sizes.SinputI(2));
sets.inputF = zeros(sets.sizes.SinputF(1),sets.sizes.SinputF(2));
sets.input = zeros(sets.sizes.Sinput(1),sets.sizes.Sinput(2));



%recuperate inputI
for j=1:sets.sizes.SinputI(1)
    for k=1:sets.sizes.SinputI(2)
        sets.inputI(j,k) = file(counter);
        counter = counter+1;
    end
end
%recuperate inputF
for j=1:sets.sizes.SinputF(1)
    for k=1:sets.sizes.SinputF(2)
        sets.inputF(j,k) = file(counter);
        counter = counter+1;
    end
end
%recuperate input
for j=1:sets.sizes.Sinput(1)
    for k=1:sets.sizes.Sinput(2)
        sets.input(j,k) = file(counter);
        counter = counter+1;
    end
end
%recuperate nvarsnet and nvars

%nvarsnet
sets.finalInputs = file(counter);    counter = counter+1;

%recuperate nvars
sets.inputs = file(counter);   counter = counter+1;

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%finish -- from all runs, see band, look for errors
if(file(counter) ~= -1)
    'There is an error in nvars - sets, do not math the cases'
end
counter = counter+1;
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
