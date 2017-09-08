%% Information for the module values for each class
% This information is teh same as in a normal experiment in files:
% nameModules.txt, numberInputsANDClasses.txt, outputsInMod.txt

%% Declaration
% even 0021T1 and T2 are not for modules, they are useful here in this way
if ( strcmp(numberDS,'a1a') == 1 || strcmp(numberDS,'a2') == 1 || strcmp(numberDS,'a3') == 1 ...
        || strcmp(numberDS,'a4') == 1  )
    m.outputsInMod = [1 1];
    m.nameMod = [1];
    m.outputsPerMod = [1 1];
    m.manyClass = 0;
elseif ( strcmp(numberDS,'b1') == 1 || strcmp(numberDS,'b2') == 1 || strcmp(numberDS,'b3') == 1 ...
        || strcmp(numberDS,'b4') == 1  )
    m.outputsInMod = [1 1];
    m.nameMod = [1];
    m.outputsPerMod = [1 1];
    m.manyClass = 0;
elseif ( strcmp(numberDS(1:2),'c1') == 1 || strcmp(numberDS(1:2),'c2') == 1 || strcmp(numberDS(1:2),'c3') == 1 ...
        || strcmp(numberDS(1:2),'c4') == 1  )
    m.outputsInMod = [1 1];
    m.nameMod = [1];
    m.outputsPerMod = [1 1];
    m.manyClass = 0;
elseif ( strcmp(numberDS,'d1') == 1 || strcmp(numberDS,'d2') == 1 || strcmp(numberDS,'d3') == 1 ...
        || strcmp(numberDS,'d4') == 1  )
    m.outputsInMod = [1 1 1];
    m.nameMod = [1];
    m.outputsPerMod = [1 1 1];
    m.manyClass = 0;

elseif ( strcmp(numberDS,'0021') == 1 || strcmp(numberDS,'0021T1') == 1 || strcmp(numberDS,'0021T2') == 1 ...
        || strcmp(numberDS,'0023') == 1  )
    m.outputsInMod = [1 2];
    m.nameMod = [1 2];
    m.outputsPerMod = [1 1];          % declate here to avoid extra computation
    m.manyClass = 1;
elseif ( strcmp(numberDS,'0021a') == 1 || strcmp(numberDS,'0023a') == 1 ...
        || strcmp(numberDS,'0021a1') == 1)
    m.outputsInMod = [1 1 2 2];
    m.nameMod = [1 2];
    m.outputsPerMod = [2 2];          % declate here to avoid extra computation
    m.manyClass = 1;
elseif ( strcmp(numberDS,'0024' ) == 1 ||  strcmp(numberDS,'0024a' ) == 1 || strcmp(numberDS,'0024b' ) == 1 )
    m.outputsInMod = [1 1 2 2 2];
    m.nameMod = [1 2];
    m.outputsPerMod = [2 3];          % declate here to avoid extra computation
    m.manyClass = 1;
    
elseif ( strcmp(numberDS,'0031a') == 1 || strcmp(numberDS,'0033a') == 1 )
    m.outputsInMod = [1 1 2 2 3 3];
    m.nameMod = [1 2 3];
    m.outputsPerMod = [2 2 2];          % declate here to avoid extra computation
    m.manyClass = 1;
elseif ( strcmp(numberDS,'0034a' ) == 1 )
    m.outputsInMod = [1 1 2 2 2 3 3];
    m.nameMod = [1 2 3];
    m.outputsPerMod = [2 3 2];          % declate here to avoid extra computation
    m.manyClass = 1;
    
else
     % if it is not found any thing, may I am calling this file from the
     % directory where the information is, so it is possible to read the
     % file info
    m.outputsInMod = load('outputsInMod');
    m.nameMod = load('nameModules');
    m.outputsPerMod = load('outputsPerMod');
    m.manyClass = 1;
    m.numberInpOut = load('numberInputsANDClasses');
end



