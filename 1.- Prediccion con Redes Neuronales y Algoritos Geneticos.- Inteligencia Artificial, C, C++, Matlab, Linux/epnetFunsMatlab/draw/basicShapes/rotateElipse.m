% otro codigo rotate an elipse
clear
clc

% the data
     xc=3; % <- x center of ellipse
     yc=3; % <- y center
     ma=2; % <- major
     mb=1; % <- minor
     ar=2; % <- resolution [deg]
     th=360:-10:0; % <- your rotation angles [deg]
% the engine
% - compute ellipse parameters
     ang=0:ar:360;
     cc=ma*cosd(ang); % <- note: SIND/COSD!
     sc=mb*sind(ang);
% the plot
     figure;
     set(gca,'xlim',[0,6],'ylim',[0,6]);
     lh=nan;
for cth=th(:).'
% - current tilt
     ct=cosd(cth);
     st=sind(cth);
% - current ellipse
     x=xc+cc*ct-sc*st;
     y=yc+cc*st+sc*ct;
if ishandle(lh)
     delete(lh);
end
     lh=line(x,y);
     title(sprintf('angle %g',cth));
     pause(.25);
end
