%% Plot a line between two point
% General function to plot a line between 2 points.
% they can be in 2D or 3D
%
% function Line(p1, p2, typeLine, colorL, r)
%
% p1 = (x,y,z)
% p1 is origin
% p2 is destine
% r is an offset to plt the lines, to not plot them from the center of the coordenate
%
%
% Author: Carlos Torres and Victor Landassuri
% Created: 12 Aug 2010
% Modified: 26 Jul 2011

%% Start scritp

function Line(p1, p2, typeLine, colorL, r)

if (nargin == 4)
    r = 1;
end

% rearrange the coordinates to submit them, in this way p1 is decomposed
% into its 2 or 3 components: x,y,z
XX(1,1) = p1(1,1);
XX(1,2) = p2(1,1);

YY(1,1) = p1(1,2)+r;
YY(1,2) = p2(1,2)-r;



if size(p1,2) == 2
   ZZ = [1 1];  % defalut option, to plot in 2D
    
elseif size(p1,2) == 3
    % if we are dealing with 3d coordeantes
    ZZ(1,1) = p1(1,3);
    ZZ(1,2) = p2(1,3);    
end


hold all
if (nargin == 5)  % if == 5 means that the module plot call this function
    line(XX, YY, ZZ, 'LineStyle',typeLine, 'Color', colorL, 'Marker','.', 'LineWidth',1);
elseif (nargin == 4)
    % for modules with colors and diff shapes in nodes, so no marker is used
    if size(p1,2) == 2
        line(XX, YY, ZZ, 'LineStyle', typeLine, 'Color', colorL, 'LineWidth',1);
    elseif size(p1,2) == 3
        line(ZZ, XX, YY, 'LineStyle', typeLine, 'Color', colorL, 'LineWidth',1);
    end
end
%H = line([-10 0], [-10 10], [1 1]), [0 0 0], 'Marker','.', 'LineWidth',1);


%H=plot(p1,p2,style,'LineWidth',1);
%text(center(1)-offsetX, center(2)-offsetY, num2str(node) );
%axis square;