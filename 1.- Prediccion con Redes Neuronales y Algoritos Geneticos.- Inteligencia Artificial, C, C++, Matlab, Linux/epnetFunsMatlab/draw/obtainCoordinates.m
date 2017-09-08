%% Obtain coordinate to plot modules (ANN)
% obtain the coordinates, min max x and y values, number of rows per module
% and the center x and y of each module
%%


function [Module, coord, noModules] = obtainCoordinates(Module, noModules, ...
    nodesInMod, noInputs, noHidden, noOutputs, inputs, hidden, outputs, r, CW)
% function to accomodate each node into a module and create the coordinates
% to plot it
%
% inputs:
%   Module      cell array that contain the number of modules created
%   noModule    number of modules
%   nodesInMods all nodes indicating to which module they belong
%   noInputs    nunber of inputs in the network
%   noHidden    number of hidden nodes
%   noOutputs   number of outputs
% output
%   Module      All information updated for each module


spanM = 2;      % how much extra space from axis X the modules could take,
% e.g. 2 = twice as all space used by inputs, it looks that need to be 2
% allways to be simetrix with the center
dy = 10;        % distance between input to hidden nodes and hidden to outputs in y axis
xoffset = 5;    % horizontal space between hidden nodes, and space betwen outputs, inputs is 0.5 allways
xyOffset2plotMod = 5;       % form the min and max corner of the module (center) how much bigger will be the module ploted (rectangle)


% recalculate the spanM and xoffset in case there are
% more hidden nodes than inputs
if(noInputs <= noHidden/2)            % +1 is to give an extra offset
    if (noHidden / 2) > noInputs
        spanM = 4;
    end
    xoffset = 7.5;
end



% put nodes from the module inside the module
% Only take into account hidden nodes ***********
contDeleteMod = 0;
module2delete = 0;

for i=1:noModules
    cont = 0;
    for j=hidden                % for each module, pass over all the list of nodes
        if nodesInMod(j,2) == Module{i}.name
            cont = cont + 1;
            Module{i}.listNodes(1,cont) = nodesInMod(j,1);
        end
    end
    % update the number of modules
    Module{i}.numberNodes = cont;
    
    % Check that the module is not empty, if it is, they mark it to delete
    if cont == 0 ||  Module{i}.name == -2   % also delete the isolated modules
        contDeleteMod = contDeleteMod + 1;
        module2delete(1,contDeleteMod) = i;
    end
end

% delete the innecesary modules
if contDeleteMod > 0
    
    for i=1:contDeleteMod
         Module{module2delete(1,i)} = [];
    end
    
    % Now they are deleted, compact the complete cell
    safetyCont = 0;                     % this will be a second count to avoid a infinit loop
    flag = 0;
    contFlag = 0;
    for i=1:noModules -1
        i = i-contFlag;
                    
        if isempty(Module{1,i})
            % it this module is empty, copy the next one into here
            for j=i:noModules -1      % probabli I can improve this later, checking again if it is empty, by now it is faster to do that
                Module{1,j} = Module{1,j+1};
            end
            %flag = 1;  % to indicata that the next loop will stat in -1 position
            contFlag = contFlag +1;
        end
        
        safetyCont = safetyCont + 1;
        
        if safetyCont > noModules
            break; 
        end
    end
    
    % after all modules have been delete, update the indexes
    noModules = noModules - contDeleteMod;
end



% obtain an approx value to see if all hidden nodes could be plotted in one
% incremental line.
% The rule is that the maximum size used in the x axis of the hidden nodes
% To plot must not exceed tiwce  the number of inputs


xrange.min = ((noInputs - 1) * (r + (xoffset/2) )) * -1;     % (xoffset/2) is the space betwwen nodes before was 0.5
xrange.max = ( (r + (xoffset/2) ) * 2 ) * noInputs + xrange.min;



% mantain a list of center for each node, including inputs and outputs
coord = zeros(noInputs+noHidden+noOutputs,2);       %format: col1 = x, col2 = y (center(x,y) to draw the circle)

% inputs
x = xrange.min;
for i=1:noInputs
    coord(i,:) = [x, 0];
    x = x + ((r + (xoffset/2)) * 2);
end

% to give more space between modules
if noModules == 1
    spaceMod = 0;
else
    spaceMod = 4;
end

% find coordinates for each module
if noInputs > 1
    xSpaceM = ( ( ( abs(coord(1,1)) + coord(noInputs,1) ) * spanM) / noModules) + xoffset;  % twice (spanM) the number of inputs
    halfSpace = xSpaceM / 2;
    %x = coord(1,1) - ( (abs(coord(1,1)) + coord(noInputs,1)) / spanM ) - spaceMod;  % spaceMod is to give extra space in x for the modules, not too much but hope this works
    if noModules > 1
        %x = ( (noModules - 1)  * ( (xSpaceM/2) +xoffset) * -1); % + (noModules * -xoffset) ;
        x = (noModules - 1) * (halfSpace + xoffset) * -1 - halfSpace;
    else
        x = halfSpace * -1;
    end
else
    xSpaceM = 80;
    x = coord(1,1) - xSpaceM;
end

% The shared module always will be plotted in the centre of the figure
% mitad = 0;
% if noModules > 2 && ismember(Module{1,noModules}.name, -1) % checl thsi line       % if there is a shered module
%     % in the list of modules, introduce it in the middle
%     mitad = int8((noModules -1) / 2);
%     mitad = mitad + 1;          % to move the next position
%     modTmp = Module{1,mitad};
%     %Module{1,mitad} = [];
%     Module{1,mitad} = Module{1,noModules};
%     %Module{1,noModules} = [];
%     Module{1,noModules} = modTmp;
% end

for i=1:noModules
    Module{i}.xrange.Min = x;
    Module{i}.xrange.Max = x + xSpaceM + xoffset;
    
    Module{i}.xrange.center = (Module{i}.xrange.Min + Module{i}.xrange.Max) / 2;
    
    x = x + xSpaceM + xoffset;
end

% Second attemp
% if node i is not conencted to node i+1,
%    then the y coordinate for node i+1 is the same as node i
% else
%   the coordinate of node y+1 is incremente by the given offse in the y axis
%   for each module

y = dy;
cont = 0;

% in fisrt place all nodes are at the same high (y), then they will be
% incresed from this base.
for i = [hidden ]
    coord(i,2) = y;
end

% now check if each node needs to be put in a higger possition
for i=[ hidden ]
    for j=[ hidden ]
        if j > i        % do not take into account the same node
            if ( CW(i,j) == 1 ) &&  ( coord(i,2) >= coord(j,2) )   % if they are conncted and have the same y poss
                coord(j,2) = coord(i,2) + ((r + (xoffset/2)) * 2);
            end
        end
    end
end


% in theory, the y position calculated will not change as it is the minimum
% position they could hold to not be in the same row as the previous nodes
% that is connected with the actual
%
% given those values, there will be as many rows as lines are in the y
% coordinate, and those rows will only be increase per module if they are
% sorted horizontally and do not fix in the given space

numberofRows = 1;
posLines = zeros(1,noHidden);         %There can be as many lines as outputs in principle
posLines(1,1) = coord(noInputs+1,2);            % this will hold where each lines starts


contNodesPerRow = zeros(noHidden,1);
nodesPerRow =  zeros(noHidden,1);

for i=noInputs+1:noInputs+noHidden
    idx = 0;
    if coord(i,2) ~= posLines(1,numberofRows)
        % it means that a new line has been found, but not sure if is a new
        % one or is a node that belong to a previous line
        if numberofRows == 1
            % then this is the second found, so we are sure it is the
            % second
            numberofRows = numberofRows + 1;
            posLines(1,numberofRows) = coord(i,2);
        else
            % if not we need to check if this new line has been found
            % before
            tmpPos = ( coord(i,2) == posLines(1,1:numberofRows) );
            
            % if it has been found previously, I need to find where is the
            % first occurence
            for j = 1:numberofRows
                if tmpPos(1,j) == 1
                    idx = j;
                    break;
                end
            end
            % if idx is different of zero, it belong to a previous row, if
            % not it is a new row
            if idx == 0
                % new row
                numberofRows = numberofRows + 1;
                posLines(1,numberofRows) = coord(i,2);
            else
                % it fits ain a previous row
                contNodesPerRow(idx,1) =  contNodesPerRow(idx,1) + 1; % increment
                nodesPerRow(idx, contNodesPerRow(idx,1) ) = i;% this node is save in the list
            end
        end
    end
    if idx == 0         % inly add the node if it appears in a new row or in the actual, but 
                        % if it was par of a previous line, it is added above
        contNodesPerRow(numberofRows,1) =  contNodesPerRow(numberofRows,1) + 1; % increment
        nodesPerRow(numberofRows, contNodesPerRow(numberofRows,1) ) = i;% this node is save in the list
    end
end
% Form this last step I have
% numberofRows        % how many rows there are
% posLines            % where they start, y axis
% contNodesPerRow     % number of nodes per row
% nodesPerRow         % which nodes are in which row





% y position for outputs
% look for the maximum in y after the hidde nodes have been settle
maxPosY = max( coord(noInputs+1 : noInputs+noHidden,2) );

% All outputs start from the last highest hidden + an offset
coord(noInputs+noHidden+1 : noInputs+noHidden+noOutputs, 2) = maxPosY + dy;


% now check if each node needs to be put in a higger possition
for i=[ outputs]
    for j=[ outputs]
        if j > i        % do not take into account the same node
            if ( CW(i,j) == 1 ) &&  ( coord(i,2) >= coord(j,2) )   % if they are conncted and have the same y poss
                coord(j,2) = coord(i,2) + ((r + (xoffset/2)) * 2);
            end
        end
    end
end

% outputs x possition
xout = ((noOutputs - 1) * (r +xoffset)  ) * -1;
%yout = dy;
for i=outputs
    coord(i,1) = xout;
    coord(i,2) = coord(i,2) + dy/2;   % increment just a little bit the outputs
    xout = xout + ((r + xoffset) * 2);
end



% until here it is missing:

% Module{1,i}.yrange.Min
% Module{1,i}.yrange.Max
% Module{1,i}.yrange.center
% Module{1,i}.rows
% Module{i}.nodesPerRow
% Module{1,i}.coorNodes
% And the x coordinates for the hidden nodes for coord variable


%% Separate the nodes per module and fill the module structure

for i=1:noModules
    % copy the y coordinate already calculated into Module{1,i}.coorNodes
    % sort them
    %Module{1,i}.listNodes = sort(Module{1,i}.listNodes);
    for j = Module{1,i}.listNodes %1:Module{1,i}.numberNodes
        Module{1,i}.coorNodes(j,2) = coord( j , 2);
    end
    
    % Create a list indicating which node will be plotted in which row
    % In principle all modules will have the same number of rows, even if
    % all space is not used
    Module{1,i}.rows = numberofRows;
    Module{1,i}.nodesPerRow = zeros(numberofRows,1);
    Module{1,i}.listNodesPerRow = zeros(numberofRows, 1);
    
    
    % The nodes of this module are already inside the module, now I need to
    % take the nodes from nodesPerRow and accomodate in each row, only the
    % nodes of this module
    for j = 1 : numberofRows                % all the original rows
        
        Module{1,i}.contNodesPerRow(j,1) = 0; % init the counter of each line
        
        for k = 1:contNodesPerRow(j,1)      % all nodes in this row
            idx = 0;
            tmpPos =  (nodesPerRow(j,k) == Module{1,i}.listNodes(1,:));
            
            for l = 1:Module{1,i}.numberNodes
                if tmpPos(1,l) == 1
                    idx = l;
                    break;
                end
            end
            if idx ~= 0                 % if the node belongs to this module
                Module{1,i}.contNodesPerRow(j,1) =  Module{1,i}.contNodesPerRow(j,1) + 1;
                Module{1,i}.listNodesPerRow( j, Module{1,i}.contNodesPerRow(j,1) ) = nodesPerRow(j,k);
            end
        end
    end
end   % end the first pass through all modules





% What happe if there are many nodes in a row, and they do not fit it
% the allowed space assigned
% increment the rows in all modules and move the nodes that do not fit
% in the actual to the new line, just that.
for i=1:noModules
    % Check that al nodes fit in the space assigned
    % [Module{1,i}.rows, Module{i}.nodesPerRow ] = calculateRowsPerMod(Module{1,i}, xoffset);
    
    % calculate the x coordinate per row
    
    for j=1:Module{1,i}.rows
                
        % inital coordinate per row
        x = Module{1,i}.xrange.center - ((Module{1,i}.contNodesPerRow(j,1) - 1) * (r + xoffset));
        
        for k=1:Module{1,i}.contNodesPerRow(j,1)
            Module{1,i}.coorNodes(Module{1,i}.listNodesPerRow(j,k), 1) = x;
            x = x + ( (r + xoffset) * 2);
        end
    end
    
    % if the module is for non conencted nodes, check that they do not have
    % the same coordinate
    if Module{1,i}.name == -2
        for k=1:Module{1,i}.numberNodes % scan all nodes
            tmp(1,:) = Module{1,i}.coorNodes(k,:);
            for j=k+1:Module{1,i}.numberNodes
                if tmp(1,1) == Module{1,i}.coorNodes(j,1) && ...
                        tmp(1,2) == Module{1,i}.coorNodes(j,2)
                    % if they have the same coordinate, increase the node j
                    Module{1,i}.coorNodes(j,2) = Module{1,i}.coorNodes(j,2) + ((r + 0.5) * 2);
                end
            end
        end
    end
    
    
    % update the coord variable with the new x and y coordinates
    for j = Module{1,i}.listNodes %1:Module{1,i}.numberNodes
         coord( j , :) = Module{1,i}.coorNodes(j,:);
    end
    
%     for j = 1:Module{1,i}.numberNodes
%         coord( Module{1,i}.listNodes(1,j), :) = Module{1,i}.coorNodes(j,:);
%     end
    
    
    % it remains to calculate the min and max in the y axis for each
    % module, in case it is desired to draw a box for the module
    
    
    %find min/max of x/y
    tmpCoord = zeros(Module{1,i}.numberNodes,2);
    cont = 0;
    for j = Module{1,i}.listNodes
        cont = cont +1;
        tmpCoord(cont,:) = Module{1,i}.coorNodes(j,:);
    end
    
    minX = min(tmpCoord(:,1));
    minY = min(tmpCoord(:,2));
    maxX = max(tmpCoord(:,1));
    maxY = max(tmpCoord(:,2));
    
    rangeX = maxX - minX;
    rangeY = maxY - minY;
    Module{i}.drawMod.x = minX - xyOffset2plotMod;
    Module{i}.drawMod.y = minY - xyOffset2plotMod;
    Module{i}.drawMod.w = rangeX + xyOffset2plotMod * 2;
    Module{i}.drawMod.h = rangeY + xyOffset2plotMod * 2;
    
end
% --------------- End Main function  ---------------------------




%% Calculate Rows per Module
% given the gap for the module, it is calculate how many rows must be
% in the module and how many nodes in each row at maximum

function [rows, nPerRow]= calculateRowsPerMod(m, offset)
% m is the module

% set initial values
rows = 1;                                         % default value
nPerRow = m.numberNodes;
spaceNedded = nPerRow * ( (m.r + offset) * 2 );

while ((m.xrange.Min + spaceNedded ) > m.xrange.Max +1 )  % if I do not put the +1 never get out if there
    % there is
    % only one
    % unit
    rows = rows +1;                                 % increment a row
    nPerRow = ceil(nPerRow / 2); % double ( int8(nPerRow / 2) );                          % split at the half the nodes
    
    % this while because in the division it is possible to lost nodes
    while ((nPerRow * rows) < m.numberNodes)
        rows = rows + 1;
    end
    
    spaceNedded = nPerRow * ( (m.r + offset) * 2 );
end

% check that any node is not lost in the row, e.g. for 5 nodes in two
% rows, the last one in not accomodate into the last 3rd row
if nPerRow * rows < m.numberNodes
    rows = rows +1;
end
