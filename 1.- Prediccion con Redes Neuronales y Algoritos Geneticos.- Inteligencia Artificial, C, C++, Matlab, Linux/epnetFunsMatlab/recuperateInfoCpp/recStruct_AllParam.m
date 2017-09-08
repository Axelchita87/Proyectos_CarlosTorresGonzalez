%function to recuperate the validation sets
function [Allp, counter] = recStruct_AllParam(Allp, counter, file, v, c, gen)
% Input arguments
% Allp  the allparam structure to save the values
% counter   the next position to save
% file      the fila that has all the information
% v         the var structure with varaiables of the experiment
% c         the constants of the program
% Outputs
% Allp      the allparam structure with all the information
% counter   the next positin to save from the file


% simplify some variables
%gen = v.generations;   % before was fixed, now it depends in the run
popNum = v.populationNum;


% 
% % Load some var for the case of classification tasks/module1
% Modules = 0;
% v.NUM_MODULES = 0;
% if v.task2solve == c.CLASSIFY
%     Modules = load('../txtFiles/nameModules.txt');
%     v.NUM_MODULES = size(Modules,2);
% else
%     v.NUM_MODULES = 1;
% end

%% Create the space for ALLParam before recuperate them
Allp.Selected = zeros(1, gen);
Allp.bestfitness = zeros(1, gen);
Allp.worstfitness = zeros(1, gen);
Allp.Avfitness = zeros(1, gen);
Allp.AvfitnessReal = zeros(1, gen);
%Allp.AllpopFitness = zeros(popNum, gen);

Allp.AvaccuracyValI = zeros(1,gen);
%Allp.AvIterateNRMS_I = zeros(1,gen);
Allp.Avinputs = zeros(1,gen);
Allp.Avhidden = zeros(1,gen);
Allp.Avconnections = zeros(1,gen);

Allp.Avlrate = zeros(v.NUM_MODULES,gen);

Allp.Avdelays = zeros(1,gen);
if (v.trainMultipleSets == c.ON)
    Allp.AvErrori = zeros(7,gen);
end

%    Allp.AvfitnessHalf = zeros(1,gen);
%    Allp.AvinputsHalf = zeros(1,gen);
%    Allp.AvhiddenHalf  = zeros(1,gen);
%    Allp.AvconnectionsHalf  = zeros(1,gen);
%    Allp.AvdelaysHalf  = zeros(1,gen);

Allp.EvalpRun  = zeros(1,gen);
Allp.totalEval = 0;

Allp.mutHT = zeros(1,gen);
Allp.mutMBP = zeros(1,gen);
Allp.mutSA = zeros(1,gen);

Allp.mutNodeDel = zeros(1,gen);
Allp.mutInputDel = zeros(1,gen);
Allp.mutDelayDel = zeros(1,gen);
Allp.mutConnDel = zeros(1,gen);

Allp.mutNodeAdd = zeros(1,gen);
Allp.mutInpAdd = zeros(1,gen);
Allp.mutDelayAdd = zeros(1,gen);
Allp.mutConnAdd = zeros(1,gen);

if ( v.algoFeatures == c.MODULAR1 )
    Allp.MutSharedNodeDel = zeros(1,gen);
    Allp.MutSharedConnDel = zeros(1,gen);
    Allp.MutStrongConnAdd = zeros(1,gen);
end

if (v.task2solve == c.CLASSIFY)
    Allp.AvClassifError = zeros(1,gen);
    Allp.bestClassifError = zeros(1,gen);
end

if (v.isModule1 == c.ON)
    Allp.AvMweight = zeros(1,gen);
    Allp.AvMarch = zeros(1,gen);
    Allp.AvNoSharedNodes = zeros(1,gen);
    Allp.AvIsolatedNodes = zeros(1,gen);
    
    Allp.AvNoSharedConn = zeros(1,gen);

    if v.task2solve == c.CLASSIFY 
       Allp.AvFitnessPerModule = zeros(v.NUM_MODULES, gen);
       Allp.AvClassErrPerModle = zeros(v.NUM_MODULES, gen);
       Allp.AvNodesPerModule = zeros(v.NUM_MODULES, gen);
    end
end


if ( v. reuseModule == c.ON)
     Allp.NodesReusedPerMod = zeros(v.NUM_MODULES, gen);
end

%% Recuperate info

%Selected
for j=1:gen
    Allp.Selected(j) = file(counter);                   counter = counter+1;
end
%bestfitness
for j=1:gen
    Allp.bestfitness(j) = file(counter);                counter = counter+1;
end
%worstfitness
for j=1:gen
    Allp.worstfitness(j) = file(counter);               counter = counter+1;
end
%Avfitness
for j=1:gen
    Allp.Avfitness(j) = file(counter);                  counter = counter+1;
end
for j=1:gen
    Allp.AvfitnessReal(j) = file(counter);                  counter = counter+1;
end

%recuperate AllpopFitness
%for j=1:popNum
%    for k=1:gen
%        Allp.AllpopFitness(j,k) = file(counter);        counter = counter+1;
%    end
%end

%AvaccuracyValI
for j=1:gen
    Allp.AvaccuracyValI(j) = file(counter);             counter = counter+1;
end
%AvIterateNRMS_I
% for j=1:gen
%     Allp.AvIterateNRMS_I(j) = file(counter);            counter = counter+1;
% end
%Avinputs
for j=1:gen
    Allp.Avinputs(j) = file(counter);                   counter = counter+1;
end
%Avhidden
for j=1:gen
    Allp.Avhidden(j) = file(counter);                   counter = counter+1;
end
%Avconnections
for j=1:gen
    Allp.Avconnections(j) = file(counter);              counter = counter+1;
end

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%finish ALLParam from all runs, see band, look for errors
%values of counter until here must be 171
if(file(counter) ~= -1)
     error('There is an error in ALLparam, do not math the cases')
end
counter = counter+1;
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%Avlrate
for k=1:v.NUM_MODULES
    for j=1:gen
        Allp.Avlrate(k,j) = file(counter);                    counter = counter+1;
    end
end
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%finish ALLParam from all runs, see band, look for errors
%values of counter until here must be 171
if(file(counter) ~= -1)
     error('There is an error in ALLparam, do not math the cases')
end
counter = counter+1;
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


%Avdelays
for j=1:gen
    Allp.Avdelays(j) = file(counter);
    counter = counter+1;
end

% AvErrori    the error in all scales
if (v.trainMultipleSets == c.ON)
    for k = 1:7
        for j = 1:gen
            Allp.AvErrori(k,j) = file(counter);
            counter = counter+1;
        end
    end
end

% EvalpRun
for j=1:gen
    Allp.EvalpRun(j) = file(counter);
    counter = counter+1;
end

Allp.totalEval = file(counter);
counter = counter+1;
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%



for j=1:gen
    Allp.mutHT(j) = file(counter);
    counter = counter+1;
end

for j=1:gen
    Allp.mutMBP(j) = file(counter);
    counter = counter+1;
end

for j=1:gen
    Allp.mutSA(j) = file(counter);
    counter = counter+1;
end
%%%%%%%%%%%%%%%%%%%%%%

for j=1:gen
    Allp.mutNodeDel(j) = file(counter);
    counter = counter+1;
end

for j=1:gen
    Allp.mutInputDel(j) = file(counter);
    counter = counter+1;
end

for j=1:gen
    Allp.mutDelayDel(j) = file(counter);
    counter = counter+1;
end

for j=1:gen
    Allp.mutConnDel(j) = file(counter);
    counter = counter+1;
end
%%%%%%%%%%%%%%%%%%%%%%%%

for j=1:gen
    Allp.mutNodeAdd(j) = file(counter);
    counter = counter+1;
end

for j=1:gen
    Allp.mutInpAdd(j) = file(counter);
    counter = counter+1;
end

for j=1:gen
    Allp.mutDelayAdd(j) = file(counter);
    counter = counter+1;
end

for j=1:gen
    Allp.mutConnAdd(j) = file(counter);
    counter = counter+1;
end


% Var for modular evo
if ( v.algoFeatures == c.MODULAR1 )
    for j = 1:gen
        Allp.MutSharedNodeDel(j) = file(counter);          counter = counter+1;
    end
    
    for j = 1:gen
        Allp.MutSharedConnDel(j) = file(counter);          counter = counter+1;
    end
    
    for j = 1:gen
        Allp.MutStrongConnAdd(j) = file(counter);          counter = counter+1;
    end
    
end


if (v.task2solve == c.CLASSIFY)
    for j = 1:gen
        Allp.AvClassifError(j) = file(counter);             counter = counter+1;
    end
    
    for j = 1:gen
        Allp.bestClassifError(j) = file(counter);             counter = counter+1;
    end
end


% Module 1
if (v.isModule1 == c.ON)
    for j = 1:gen
        Allp.AvMweight(j) = file(counter);             counter = counter+1;
    end
    
    for j = 1:gen
        Allp.AvMarch(j) = file(counter);             counter = counter+1;
    end
    
    for j = 1:gen
        Allp.AvNoSharedNodes(j) = file(counter);             counter = counter+1;
    end
    
    %AvIsolatedNodes
     for j = 1:gen
        Allp.AvIsolatedNodes(j) = file(counter);             counter = counter+1;
     end
     
     %  AvNoSharedConn
     for j = 1:gen
         Allp.AvNoSharedConn(j) = file(counter);             counter = counter+1;
     end
     
     
     % AvFitnessPerModule
     for j=1:v.NUM_MODULES
         for k=1:gen
             Allp.AvFitnessPerModule(j,k) = file(counter);        counter = counter+1;
         end
     end
     
     % AvNodesPerModule
     for j=1:v.NUM_MODULES
         for k=1:gen
             Allp.AvNodesPerModule(j,k) = file(counter);        counter = counter+1;
         end
     end
     
     
     if v.task2solve == c.CLASSIFY
         % AvClassErrPerModle
         for j=1:v.NUM_MODULES
             for k=1:gen
                 Allp.AvClassErrPerModle(j,k) = file(counter);        counter = counter+1;
             end
         end
     end
     
     
     
end


if ( v. reuseModule == c.ON)
    for j=1:v.NUM_MODULES
        for k=1:gen
            Allp.NodesReusedPerMod(j,k) = file(counter);        counter = counter+1;
        end
    end
end



%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%finish ALLParam from all runs, see band, look for errors
%values of counter until here must be 171
if(file(counter) ~= -1)
     error('There is an error in ALLparam, do not math the cases')
end
counter = counter+1;
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
