function slash2use = isLinOrWin()
%Function to determinate the slash in windows or linux
if (isunix)
    slash2use = '/';
else
    slash2use = '\';
end