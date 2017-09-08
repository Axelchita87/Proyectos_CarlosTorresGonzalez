function isFieldResult = myIsField (inStruct, fieldName)
%Function to determinate is a field is member of a structure
% inStruct is the name of the structure or an array of structures to search
% fieldName is the name of the field for which the function searches

isFieldResult = 0;
f = fieldnames(inStruct(1));
for i=1:length(f)
    if(strcmp(f{i},strtrim(fieldName)))
        isFieldResult = 1;
        return;
    elseif isstruct(inStruct(1).(f{i}))
        isFieldResult = myIsField(inStruct(1).(f{i}), fieldName);
        if isFieldResult
            return;
        end
    end
end
% The function can be called as follows:
% % 'a' is a structure
% a.b.c=1;
% myIsField (a,'c')
% % 'a' is an array of structures
% a(1).b.c=1; a(2).b.c = 2;
% myIsField(a, 'c')