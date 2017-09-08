function selected = rankSelection(selected, Pop, sizePop, type, toSelect)

%The population is already sorted
%range to select the individulas
a = 1;
b = sizePop;

for i=1:toSelect
    select_this = round(a + (b-a) * rand);
    selected.string(i,:) = Pop.string(select_this,:);
    if(strcmp(type,'RBLC'))
        selected.beta(i,1) = Pop.beta(select_this,1);
    end
end
