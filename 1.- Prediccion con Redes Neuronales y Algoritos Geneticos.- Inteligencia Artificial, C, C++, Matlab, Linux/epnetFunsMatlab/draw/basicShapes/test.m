clear
clc

% offset control how much is modifid the circle
offset = 1;

x = [-10 5];
y = [0 10];

disX = x(1,2) - x(1,1);
disY = y(1,2) - y(1,1);

% the factor to create a line will be 100 points, so

incX = disX / 100;
incY = disY / 100;

X = x(1,1) : incX : x(1,2);
Y = y(1,1) : incY : y(1,2);

% create a vector that changes the shape of vector x, to make the effect of
% a parabola
Xmod = zeros(1,size(X,2));
% modified it to the right, find the middle
mod = 0.1
theHalf = int8(size(Xmod,2) / 2);
for i=1:theHalf
    Xmod(1,i) = mod;
    mod = (mod + 0.1)^2;
end

for i=theHalf+1:size(X,2)
    Xmod(1,i) = mod;
    mod = sqrt(mod - 0.1);
end

  
% sum Xmod and X to change X
X = X + Xmod;

plot(X,Y)

% create a spline
xx = x(1,1) : (incX/100) : x(1,2);
yy = spline(X,Y,xx);
plot(X,Y,xx,yy)


% example of interpolation
x = [1.0 1.8 4.0 4.8 6.8 7.6 8.8 9.4];
y = [1.5 2.0 2.1 2.5 2.5 2.2 2.0 1.5];
plot(x, y)
axis([0 10 0 4])

xx = 1 : 0.2 : 9.4;
yy = spline(x, y, xx);
plot(x, y, 'o' , xx, yy);
%%%%%%%%%%%%%%%%%%%

% plot a semi circle
clear
X = -2:0.1:2;
Y = sqrt(4-(X.^2));
%%%%%%%%%%%%%%%%%%%%%%


plot(X,Y) 