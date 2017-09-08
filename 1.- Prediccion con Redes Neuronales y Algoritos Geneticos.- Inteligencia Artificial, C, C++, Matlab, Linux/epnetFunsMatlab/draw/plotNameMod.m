%% Plot the name of the module above the module 
% Tha the info from the module structure to know the position of the box
% and then plot it
%
% Author: Carlos Torres and Victor Landassuri
% Created: 25 Jul 2011
% Modified: 
% 


%% Function
function plotNameMod(m, colorM)

if nargin == 1
    colorM = [0 0 0];
end
strMod = num2str(m.name);
text( m.drawMod.x+m.drawMod.w, m.drawMod.y + m.drawMod.h, ['M ', strMod], 'FontSize',14, 'FontWeight', 'bold','Color', colorM );

