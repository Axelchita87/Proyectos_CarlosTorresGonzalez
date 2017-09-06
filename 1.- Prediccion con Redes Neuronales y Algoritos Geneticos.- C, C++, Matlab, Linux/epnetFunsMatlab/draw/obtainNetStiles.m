%% Stiles to plot a network
% Here are defined the stiles to plot a network or modular neural netowrk
%
% until now:
% normal: stiles, for a plain network
% module: to plot modules
%

%% Function
function stiles = obtainNetStiles(stile, noModules)

if strcmp(stile,'normal')
    stiles.colorInp = 'b-';
    stiles.colorHid = 'm-';
    stiles.colorOut = 'k-';
    stiles.colorNoInp = 'r--';         %deactivated n.inputs
elseif strcmp(stile,'module') || strcmp(stile,'module3D1')
    % patterns for all modules
%     stiles.colorNoInp = 'r--';         %deactivated n.inputs
    stiles.sharedConn = '--';
    stiles.sharedConnColor = [162 205 90]/255; %DarkOliveGreen3
    
    
    % color used for unsued inputs
    % BlueViolet	138;43;226	8A2BE2	
    % other list obtained form http://web.njit.edu/~kevin/rgb.txt.html
    
    maxdef = 13; % if required more, strop program and tell user
    if noModules > maxdef
        error('I have not declared as many color as modules you have, declare more and run again \n %s',...
            'exit, function obtainNetStiles');
    end
    
    % create a lits with different colors
    rgbColor{1,1} = [0 0 255];          % blue
    rgbColor{1,2} = [0 0 0];          % black
    rgbColor{1,3} = [0 255 255];          % cian
    rgbColor{1,4} = [255 0 255];          % magenta
    rgbColor{1,5} = [255 0 0];           % red
    rgbColor{1,6} = [0 255 0];          % green, until here the matlab colors
    rgbColor{1,7} = [30 144 255];          % DodgerBlue
    rgbColor{1,8} = [112 219 147];          %  Aquamarine
    rgbColor{1,9} = [205 127 50 ];          % Light Blue 
    rgbColor{1,10} = [165 42 42 ];          % brown
    rgbColor{1,11} = [135 206 250];          % LightSkyBlue
    rgbColor{1,12} = [139 69 19 ];          % chocolate4
    rgbColor{1,13} = [106 90 205 ];          % SlateBlue
    
    % obtain something matlab can understand
    for i=1:maxdef
        rgbColor{1,i} = rgbColor{1,i}/255;
    end
    
    % fill the shape for each color of the module
    mark{1,1} = 'o';
    mark{1,2} = 's';
    mark{1,3} = 'd';
    mark{1,4} = 'o';
    mark{1,5} = 's';
    mark{1,6} = 'd';
    mark{1,7} = 'o';
    mark{1,8} = 's';
    mark{1,9} = 'd';
    mark{1,10} = 'o';
    mark{1,11} = 's';
    mark{1,12} = 'd';
    mark{1,13} = 'o';
    
    % create to complete configuration for the module
    
    for i=1:maxdef
        stiles.m{1,i}.nodeSize = 5;
        stiles.m{1,i}.color =  rgbColor{1,i};
        stiles.m{1,i}.inp = mark{1,i};
        stiles.m{1,i}.hid = mark{1,i};
        stiles.m{1,i}.out = mark{1,i};
        stiles.m{1,i}.strongConn = '-';
        stiles.m{1,i}.sharedConn= '--';
        stiles.m{1,i}.modLine = '--';
    end
    
    
    
    
end



