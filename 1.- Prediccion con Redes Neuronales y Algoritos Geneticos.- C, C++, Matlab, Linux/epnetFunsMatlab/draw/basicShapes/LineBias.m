function LineBias(p1, colorB, r)
%---------------------------------------------------------------------------------------------
% H=LINE(CENTER,DEST,NOP,STYLE)
% This routine draws a line for the bias for a single node
%
%
% H is the opened figure
%
% Since the handle of the object is returned, you use routine SET to get the best result.
%
%   Usage Examples,
%
%   line([1,3],h);
%
%   Carlos Torres and Victor Landassuri
%   Version 0.1
%   August 2010
%   Revised at:
%---------------------------------------------------------------------------------------------

% The bias is drawn to the left, around 45 degrees

% rearrange the coordinates to submit them

% check in which side is put the bias

if (nargin == 2)
    r = 1;
end


XX(1,1) = p1(1,1);
YY(1,1) = p1(1,2) + r;
YY(1,2) = p1(1,2) + r * 3;


if size(p1,2) == 2
    ZZ = [1 1];
elseif size(p1,2) == 3
    ZZ = [p1(1,3) p1(1,3)];
end



if XX(1,1) < 0                         % chose left
    side = 0;
elseif XX(1,1) > 0
    side = 1;                           % chose right
else                                    % at random
    if (rand(1) < 0.5) ;
        side = 0;
    else
        side = 1;
    end
end




if size(p1,2) == 2
    
    switch side
        case 0
            XX(1,2) = p1(1,1) - r;
            text(XX(1,2) - r , YY(1,2), 'b', 'FontSize',12,'Color', colorB );
        case 1
            XX(1,2) = p1(1,1) + r;
            text(XX(1,2) + 0.3, YY(1,2), 'b', 'FontSize',12,'Color', colorB );
    end
    line(XX, YY, ZZ, 'Color', colorB, 'Marker','.', 'LineWidth',1);
    
    
elseif size(p1,2) == 3
    switch side
        case 0
            XX(1,2) = p1(1,1) - r;
            text(ZZ(1,1), XX(1,2) - r , YY(1,2), 'b', 'FontSize',12,'Color', colorB );
        case 1
            XX(1,2) = p1(1,1) + r;
            text(ZZ(1,1), XX(1,2) + 0.3, YY(1,2), 'b', 'FontSize',12,'Color', colorB );
    end
    line(ZZ, XX, YY, 'Color', colorB, 'Marker','.', 'LineWidth',1);
end







%H=plot(p1,Y,style,'LineWidth',1);
%text(center(1)-offsetX, center(2)-offsetY, num2str(node) );
%axis square;