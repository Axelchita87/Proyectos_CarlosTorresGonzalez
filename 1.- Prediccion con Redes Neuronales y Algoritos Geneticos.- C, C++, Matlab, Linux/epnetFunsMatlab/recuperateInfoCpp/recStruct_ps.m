function [ps, counter] = recStruct_ps(ps, counter, line, file)
% Function to recuperat the structure str_ps
    %xrows
    ps.xrows = file(counter);
    counter = counter+1;
    %xmax
    for j=1:line
        ps.xmax(j,1) = file(counter);
        counter = counter+1;
    end
   %xmin
   for j=1:line
        ps.xmin(j,1) = file(counter);
       counter = counter+1;
   end
   %xrange
   for j=1:line
        ps.xrange(j,1) = file(counter);
       counter = counter+1;
   end
   %yrows
    ps.yrows = file(counter);
    counter = counter+1;
   %ymax
    ps.ymax = file(counter);
    counter = counter+1;
    %ymin
    ps.ymin = file(counter);
    counter = counter+1;
    %yrange
    ps.yrange = file(counter);
    counter = counter+1;
    