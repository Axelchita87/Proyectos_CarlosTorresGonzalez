%test to try to plot an animation with frames

clear
clc


%dir to work

dir1 = 'D:\DoctoradoResultados\TSEPnet28C\ChaosHenon';
dir2 = 'D:\LIBROS\Matlab\Animations\mpgwrite';
cd(dir1);
cd('res');

load('allrun.mat');

minimo = min(allrun{1,1}.Network{1,1}.iteratePredF);
maximo = max(allrun{1,1}.Network{1,1}.iteratePredF);

%axis(gca, [-1 31 minimo+2 maximo+2])
set(gca,'xlim',[-1 31],'ylim',[minimo maximo],...
	   'NextPlot','replace','Visible','off')

x = [1:30];
y = allrun{1,1}.Network{1,1}.iteratePredF;
for j=1:29
    h = line([x(j) x(j+1)],[y(j) y(j+1)],[1 1],'Marker','.','LineStyle','-')
%    plot(x(j),allrun{1,1}.Network{1,1}.iteratePredF(j));
    
    M(j) = getframe;
end
movie(M);

movie2avi(M, 'salida', 'compression', 'None', 'fps', 60, 'quality', 100);

%after that use  
%cd(dir2);
%mpgwrite(M,colormap,'video',[1 1 1 1 20 31 31 31]) %to ceate the mpg movie



