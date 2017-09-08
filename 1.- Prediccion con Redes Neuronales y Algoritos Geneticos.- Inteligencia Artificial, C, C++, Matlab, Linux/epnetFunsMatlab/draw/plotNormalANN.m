%% Plot normal ANN
% normal plot where just the inputs hidden nodes and output are fomr
% different color and no modulea re plotted

%% Function
function plotNormalANN(n,coord,stiles,plotModuleBox,noModules,Module,h)


% first print the n.inputs at the bottom
for i=1:n.noInputs
    noNode = i;                                     % obtain the node number
    if n.nodes(1,i) == 1
        % print normal n.nodes
        h = circle([coord(i,1),coord(i,2)],n.r,200,stiles.colorInp,h,noNode);
    else
        % print deactivated node
        h = circle([coord(i,1),coord(i,2)],n.r,200,stiles.colorNoInp,h,noNode);
    end
end

% I put separately in case I want to print then in differet color, ...

% print the n.hidden n.nodes
for i=n.hidden
    noNode = i;
    h = circle([coord(i,1),coord(i,2)],n.r,200,stiles.colorHid,h,noNode);
end


% finally print the output(s)
for i=n.outputs
    noNode = i;
    h = circle([coord(i,1),coord(i,2)],n.r,200,stiles.colorOut,h,noNode);
end


% then draw the connectins for inputs for each module
for i=n.inputs
    for j = [n.hidden n.outputs]
        if ( (n.nodes(1,j) == 1) && (n.nodes(1,i) == 1) )
            if n.CW(i,j) == 1
                Line(coord(i,:), coord(j,:), '-', [0 0 0], n.r); % z = [1,1]
            end
        end
    end
end


% draw connections n.hidden n.nodes
for i= [n.hidden n.outputs]
    for j = [n.hidden n.outputs]
        if ( (n.nodes(1,j) == 1) && (n.nodes(1,i) == 1) )
            if n.CW(i,j) == 1
                Line(coord(i,:), coord(j,:), '-', [0 0 0], n.r); % z = [1,1]
            end
        end
    end
end

% draw connectins for n.bias
for i= [n.hidden n.outputs]
    if n.nodes(1,i) == 1
        if n.bias(i) == 1
            LineBias(coord(i,:), [.24 .116 .205], n.r); % z = [1,1]
        end
    end
end


% plot the box of the module
if plotModuleBox == 1 && noModules > 1
    for i=1:noModules
        rectangle('Position',[Module{1,i}.drawMod.x,Module{1,i}.drawMod.y, ...
            Module{1,i}.drawMod.w,Module{1,i}.drawMod.h],...
            'Curvature',[0.4],...
            'LineWidth',2,'LineStyle','--');
        plotNameMod( Module{1,i} )
    end
end
