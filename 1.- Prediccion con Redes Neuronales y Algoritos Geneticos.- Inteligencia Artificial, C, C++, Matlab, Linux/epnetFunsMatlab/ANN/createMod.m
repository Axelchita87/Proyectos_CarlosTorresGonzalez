%% Module Creation
% Create the structure for each module

function M = createMod(noMod, r, name)
% set up the radious nad name of the module in this function

% create modules
if isempty(noMod);
    M{1,1} = 0;
else
    for i=1:noMod
        M{i}.name = name(1,i);                 % name of the module which in fact is the number of the output it belogns
        M{i}.r = r;                    % radious
        M{i}.xrange.Min = 0;           % min value for the x axis
        M{i}.xrange.Max = 0;           % max value for the x axis
        M{i}.xrange.center = 0;        % center of the module for the x axis
        
        M{i}.drawMod.x = 0;
        M{i}.drawMod.y = 0;
        M{i}.drawMod.w = 0;
        M{i}.drawMod.h = 0;
        
        M{i}.rows = 0;
        M{i}.nodesPerRow = 0;
        M{i}.listNodesPerRow = 0;                % matrix indicating which node will be ploted in which  row
        
        M{i}.numberNodes = 0;                 % number of nodes inside this module
        M{i}.listNodes = 0;   % nodes inside this module
        M{i}.coorNodes = zeros(1,2);   % coordinate for each node (ceter (x,y) to plot)
        
    end
end