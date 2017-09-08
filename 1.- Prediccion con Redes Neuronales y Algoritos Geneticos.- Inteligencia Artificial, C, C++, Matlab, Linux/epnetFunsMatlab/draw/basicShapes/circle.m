function H=circle(center,r,NOP,style,H,node)
%---------------------------------------------------------------------------------------------
% H=CIRCLE(CENTER,r,NOP,STYLE)
% This routine draws a circle with center defined as
% a vector CENTER, r as a scaler RADIS. 
%
% NOP is the number of points on the circle. 
%
% As to STYLE, use it the same way as you use the rountine PLOT.
%
% H is the opened figure
%
% Since the handle of the object is returned, you use routine SET to get the best result.
%
%   Usage Examples,
%
%   circle([1,3],3,1000,':'); 
%   circle([2,4],2,1000,'--');
%
%   Zhenhai Wang <zhenhai@ieee.org>
%   Version 1.00
%   December, 2002
%   Modified version at 20/08/2010, by Carlos Torres and Victor Landassuri
%---------------------------------------------------------------------------------------------

% if (nargin <3),
%  error('Please see help for INPUT DATA.');
% elseif (nargin==3)
%     style='b-';
% end;

% set up the offst to print the node number inside the node
offsetX = 0.5 * (r/2);
offsetY = 0.5 * (r/2);
if node > 9
    offsetX = 1.5 * (r/2);
elseif node > 99
    offsetX = 2.2 * (r/2);
end


THETA=linspace(0,2*pi,NOP);
RHO=ones(1,NOP)*r;
[X,Y] = pol2cart(THETA,RHO);
X = X + center(1);
Y = Y + center(2);
hold all
H = plot(X,Y,style,'LineWidth',1.5);
text(center(1)-offsetX, center(2)-offsetY, num2str(node),'FontSize',14,'Color', 'blue' );
%axis square;