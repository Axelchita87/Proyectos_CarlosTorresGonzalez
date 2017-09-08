%% Plot classification areas fro combined data set
% This file is similar to plotClases but with the different that it is
% consider that the input is not just one input for all classes in all
% different task, instead it is considered that each task has its own
% inputs
%
% Created on:   11 July 2011
% Modified at:
% Author:       Carlos Torres and Victor Landassuri

%% function
function [h] =  plotClasses(TInp, TOut, classes, noClasses, m, incorrect)
% Inputs
%   TInp    is the matrix of inputs. like P
%   TOut    is the matrix of output, like T, 
%   classes is the different patterns found
%   noClasses   the number of different patterns found
%   m           structure with information of modules, i.e. number of output pre module, ...
%   incorrect   optional parameter, if it is passed it menas that it is
                %   reauired to plot the incorrect classifications
% Outputs:
%   h               handler for the figure plotted
%   patterns        how many patterns used for each class
%   classes         the classes that exist
%   contDiffClass   the number of classes that exist

%% Example to plot two classes
stileL{1,1} = '+r';
stileL{2,1} = 'ob';
stileL{3,1} = '*c';
stileL{4,1} = '.m';
stileL{5,1} = 'xg';
stileL{6,1} = 'sy';
stileL{7,1} = 'dk';
stileL{8,1} = '^r';
stileL{9,1} = 'vg';
stileL{10,1} = '>b';
stileL{11,1} = '<c';
stileL{12,1} = 'pm';
stileL{13,1} = 'hy';

stileL{14,1} = '+k';
stileL{15,1} = 'or';
stileL{16,1} = '*b';
stileL{17,1} = '.c';
stileL{18,1} = 'xn';
stileL{19,1} = 'sg';
stileL{20,1} = 'dy';
stileL{21,1} = '^k';
stileL{22,1} = 'vr';
stileL{23,1} = '>g';
stileL{24,1} = '<b';
stileL{25,1} = 'pc';
stileL{26,1} = 'hm';

% take too much care here, if there are more than two outputs, how are they
% reoganized, code plotClassesManyOutput consider only 2 output tasks 1 and
% the next three output in tasks 2
if nargin == 5
    
    if size(TOut,2) > 2
        h = plotClassesManyOutput(TInp,TOut,stileL, classes,m, noClasses);
    else
        h = plotClasses2Output(TInp,TOut,stileL);
    end
    
elseif nargin == 6              % for incorrect classifications
    
    if size(TOut,2) > 2
        h = plotClassesManyOutput(TInp,TOut,stileL, classes, noClasses,m, incorrect);
    else
        h = plotClasses2Output(TInp,TOut,stileL, incorrect);
    end
end


function h = plotClasses2Output(TInp,TOut,stileL, incorrect)
% This function is designed to plot tasks with two outputs, thus it is
% possible that in the task 1 there are two sclasses and two in the second
% class or output


gcaFotnSize = 12;           % size for the tick and legend
lines = size(TInp,1);

clf

% plot the first output
sizeInp = size(TInp,2);
sizeOut = size(TOut,2);



%patterns = zeros(noClasses,1);  % each line represent two classes,
% I consider all combinations, even they mab be less

subplot(1,2,1);
hold all

for i = 1:lines             % all lines
    % for j = 1 : noClasses
    if TOut(i,1) == 0.9     % 1 or 0.9
        Class = 1;
    else
        Class = 2;
        %flagClassFound = 1;
        %       break;
    end
    %end
    
    
    % plot
    if nargin == 3
        h = plot( TInp(i,1),TInp(i,2), stileL{Class,1},'LineWidth',1);
    else
        if incorrect(1,i) == 1
            h = plot( TInp(i,1),TInp(i,2), 'sg','LineWidth',2);
        else
            h = plot( TInp(i,1),TInp(i,2), stileL{Class,1},'LineWidth',1);
        end
    end
    %    patterns(Class,1) = patterns(Class,1) + 1;
    
end
% To has a square in the figure, if not it looks like oval
daspect([1,1,1])

% display('code line');
% for i = 1:noClasses
%     disp(['class ', num2str(i), stileL(i,:), num2str(classes(i,:)) ]);
% end
%end
set(gca, 'fontsize',gcaFotnSize, 'box', 'on');



%% repeat the same for the se% To has a square in the figure, if not it looks like oval
daspect([1,1,1])
set(gca, 'fontsize',gcaFotnSize, 'box', 'on');
cond output
subplot(1,2,2);
hold all

for i = 1:lines             % all lines
    if TOut(i,2) == 0.9        % 1 or 0.9
        Class = 1;
    else
        Class = 2;
    end
    
    
    
    % plot
    if nargin == 3
        h = plot( TInp(i,1),TInp(i,2), stileL{Class,1},'LineWidth',1);
    else
        if incorrect(2,i) == 1
            h = plot( TInp(i,1),TInp(i,2), 'sg','LineWidth',2);
        else
            h = plot( TInp(i,1),TInp(i,2), stileL{Class,1},'LineWidth',1);
        end
    end
    %patterns(Class,1) = patterns(Class,1) + 1;
    
end
% To has a square in the figure, if not it looks like oval
daspect([1,1,1])

% display('code line');
% for i = 1:noClasses
%     disp(['class ', num2str(i), stileL(i,:), num2str(classes(i,:)) ]);
% end
%end
set(gca, 'fontsize',gcaFotnSize, 'box', 'on');












function h = plotClassesManyOutput(TInp,TOut,stileL, classes, m, noClasses, incorrect)
% This function is designed to plot tasks with many outputs
% Here it is assumed that each ouput has the postion N of the class set to
% 1 and the rest to zero, thus there are classes as output. That means that
% it is not used all the possible combinations in the number of outputs

gcaFotnSize = 12;           % size for the tick and legend
lines = size(TInp,1);

clf

% plot the first output

sizeInp = size(TInp,2);
sizeOut = size(TOut,2);

% classes = zeros(sizeOut,sizeOut);
% for i=1:sizeOut
%     classes(i,i) = 1;
% end
% noClasses = sizeOut;

%patterns = zeros(noClasses,1);  % each line represent two classes,
% I consider all combinations, even they mab be less

% plot the fisrt figure, in this case I am only considering the first 2 two classes
% here

% Number of modules
noModule = size(m.nameMod,2);
 contx=-1;
      conty=0;
    
for module = 1:noModule
    subplot(1,noModule,module);
    hold all
    contx=contx+2;
    conty=conty+2;  % I put this values because I know that for this kind of tasks, there is only 2 inputs per module
    
    % to mantain whcih outputs are next
    if module == 1
        posInit = 1;
        posFinal = m.outputsPerMod(1);
    else
        posInit = posFinal + 1;
        posFinal = posFinal + m.outputsPerMod(module);
    end

    for i = 1:lines             % all lines
        for j = 1 : noClasses
            if TOut(i,posInit:posFinal) == classes(j,posInit:posFinal)
                Class = j;
                %flagClassFound = 1;
                break;
            end
        end
        %         if TOut(i,2) == 1
        %             Class = 1;
        %         else
        %             Class = 2;
        %         end
        %
        
        % plot
    
        if nargin == 6
            h = plot( TInp(i,contx),TInp(i,conty), stileL{Class,1},'LineWidth',1);
        elseif nargin == 7
            if incorrect(module,i) == 1
                h = plot( TInp(i,contx),TInp(i,conty), 'sg','LineWidth',2);
            else
                h = plot( TInp(i,contx),TInp(i,conty), stileL{Class,1},'LineWidth',1);
            end
        end
    
     %    patterns(Class,1) = patterns(Class,1) + 1;
    
    end
    
    % To has a square in the figure, if not it looks like oval
    daspect([1,1,1])
    set(gca, 'fontsize',gcaFotnSize, 'box', 'on');


end



%% OLD code when I did it without the for to repeat for any number of
%% modules

% %% repeat the same for the second output
% subplot(1,2,2);
% hold all
% 
% % to mantain whcih outputs are next
% posInit = posFinal + 1;
% posFinal = posFinal + m.outputsPerMod(2);
% 
% % this code is similar to the overlapping plot
% for i = 1:lines             % all lines
%     for j = 1 : noClasses
%         if TOut(i,posInit:posFinal) == classes(j,posInit:posFinal)
%             Class = j;
%             %flagClassFound = 1;
%             break;
%         end
%     end
%     
%     
%     % plot
%     
%     if nargin == 6
%         h = plot( TInp(i,1),TInp(i,2), stileL{Class,1},'LineWidth',1);
%     elseif nargin == 7
%         if incorrect(2,i) == 1
%             h = plot( TInp(i,1),TInp(i,2), 'sg','LineWidth',2);
%         else
%             h = plot( TInp(i,1),TInp(i,2), stileL{Class,1},'LineWidth',1);
%         end
%     end
%     
% end
% 
% % To has a square in the figure, if not it looks like oval
% daspect([1,1,1])
% set(gca, 'fontsize',gcaFotnSize, 'box', 'on');







