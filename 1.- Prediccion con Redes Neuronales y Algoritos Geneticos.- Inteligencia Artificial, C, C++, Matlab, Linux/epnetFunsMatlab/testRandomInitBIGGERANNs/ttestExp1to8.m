%% t-test for all experimnts until initializtion
% Here is meassure the t-test among all exp done in this section Exp 1:8
% 
% In another separate experiments are tested the t-test after evolution
%

%% scipt

clear
clc

% directories

dir{1,1} = 'resExp1';
dir{2,1} = 'resExp2';
dir{3,1} = 'resExp3';
dir{4,1} = 'resExp4';
dir{5,1} = 'resExp6';  

baseDir = pwd;

% adecuate slash
cd('..'); cd('LinuxOrWindows');
SLASH = isLinOrWin();
cd('..'); cd(baseDir);


for DIR = 1:size(dir,1)
    % enter in each directory to load values
    cd( [ baseDir,SLASH, dir{DIR,1} ] )
   
    res1 = load( ['resExp' dir{DIR,1}(1,7), '.mat' ]);
    res2 = load( ['resExp' dir{DIR,1}(1,7), 'manyOut.mat' ]);
 
    % put all in one variable, one for networks with one output, ...
    
    % transpose of each variable
    Exp1{DIR,1}.conn = res1.conn';
    Exp1{DIR,1}.March = res1.March';
    Exp1{DIR,1}.contnoNodes = res1.contnoNodes';
    Exp1{DIR,1}.contnoInputs = res1.contnoInputs';
    Exp1{DIR,1}.noNodes = res1.noNodes';
    % isolated nodes from outputs and inputs are put towether
    Exp1{DIR,1}.contnoNodes = Exp1{DIR,1}.contnoNodes + Exp1{DIR,1}.contnoInputs; 
    
    Exp2{DIR,1}.conn = res2.conn';
    Exp2{DIR,1}.March = res2.March';
    Exp2{DIR,1}.contnoNodes = res2.contnoNodes';
    Exp2{DIR,1}.contnoInputs = res2.contnoInputs';
    Exp2{DIR,1}.noNodes = res2.noNodes';
    % isolated nodes from outputs and inputs are put towether
    Exp2{DIR,1}.contnoNodes = Exp2{DIR,1}.contnoNodes + Exp2{DIR,1}.contnoInputs; 

    
    %% Obtain mean std from all var 1 output
    % Connections
    Exp1{DIR,1}.mCon = mean(Exp1{DIR,1}.conn);
    Exp1{DIR,1}.stdCon = std(Exp1{DIR,1}.conn);
    Exp1{DIR,1}.minCon = min(Exp1{DIR,1}.conn);
    Exp1{DIR,1}.maxCon = max(Exp1{DIR,1}.conn);
    
    % March
    Exp1{DIR,1}.mMarch = mean(Exp1{DIR,1}.March);
    Exp1{DIR,1}.stdMarch = std(Exp1{DIR,1}.March);
    Exp1{DIR,1}.minMarch= min(Exp1{DIR,1}.March);
    Exp1{DIR,1}.maxMarch = max(Exp1{DIR,1}.March);
    
    % isolated nodes
    Exp1{DIR,1}.mNoNodes = mean(Exp1{DIR,1}.contnoNodes);
    Exp1{DIR,1}.stdNoNodes = std(Exp1{DIR,1}.contnoNodes);
    Exp1{DIR,1}.minNoNodes = min(Exp1{DIR,1}.contnoNodes);
    Exp1{DIR,1}.maxNoNodes = max(Exp1{DIR,1}.contnoNodes);
    
    % isolated nodes form inputs
%     Exp1{DIR,1}.mNoInputs = mean(Exp1{DIR,1}.contnoInputs);
%     Exp1{DIR,1}.stdNoInputs = std(Exp1{DIR,1}.contnoInputs);
%     Exp1{DIR,1}.minNoInputs = min(Exp1{DIR,1}.contnoInputs);
%     Exp1{DIR,1}.maxNoInputs = max(Exp1{DIR,1}.contnoInputs);
    
    % number of nodes
    Exp1{DIR,1}.mNodes = mean(Exp1{DIR,1}.noNodes);
    Exp1{DIR,1}.stdNodes = std(Exp1{DIR,1}.noNodes);
    Exp1{DIR,1}.minNodes = min(Exp1{DIR,1}.noNodes);
    Exp1{DIR,1}.maxNodes = max(Exp1{DIR,1}.noNodes);
    
     
    
    %% Obtain mean std from all var n outputs
    % Connections
    Exp2{DIR,1}.mCon = mean(Exp2{DIR,1}.conn);
    Exp2{DIR,1}.stdCon = std(Exp2{DIR,1}.conn);
    Exp2{DIR,1}.minCon = min(Exp2{DIR,1}.conn);
    Exp2{DIR,1}.maxCon = max(Exp2{DIR,1}.conn);
    
    % March
    Exp2{DIR,1}.mMarch = mean(Exp2{DIR,1}.March);
    Exp2{DIR,1}.stdMarch = std(Exp2{DIR,1}.March);
    Exp2{DIR,1}.minMarch= min(Exp2{DIR,1}.March);
    Exp2{DIR,1}.maxMarch = max(Exp2{DIR,1}.March);
    
    % isolated nodes
    Exp2{DIR,1}.mNoNodes = mean(Exp2{DIR,1}.contnoNodes);
    Exp2{DIR,1}.stdNoNodes = std(Exp2{DIR,1}.contnoNodes);
    Exp2{DIR,1}.minNoNodes = min(Exp2{DIR,1}.contnoNodes);
    Exp2{DIR,1}.maxNoNodes = max(Exp2{DIR,1}.contnoNodes);
    
    % isolated nodes form inputs
%     Exp2{DIR,1}.mNoInputs = mean(Exp2{DIR,1}.contnoInputs);
%     Exp2{DIR,1}.stdNoInputs = std(Exp2{DIR,1}.contnoInputs);
%     Exp2{DIR,1}.minNoInputs = min(Exp2{DIR,1}.contnoInputs);
%     Exp2{DIR,1}.maxNoInputs = max(Exp2{DIR,1}.contnoInputs);
    
    % number of nodes
    Exp2{DIR,1}.mNodes = mean(Exp2{DIR,1}.noNodes);
    Exp2{DIR,1}.stdNodes = std(Exp2{DIR,1}.noNodes);
    Exp2{DIR,1}.minNodes = min(Exp2{DIR,1}.noNodes);
    Exp2{DIR,1}.maxNodes = max(Exp2{DIR,1}.noNodes);
    
    
    
end

alpha = 0.05;
tail='both';
type='unequal';

% ttest against expe 1 
% 1 output comparison \sigma = 0.1 y \sigma = 1 in isolated nodes

[h,p,ci] = ttest2(Exp1{1,1}.contnoNodes(:,9),Exp1{1,1}.contnoNodes(:,10),alpha, tail, type);  %tail is default to both, 2 in excel
p


% test Exp 3 against it self
% isolated nodes
exp = 3;
for i = 1:12
    for j = 1:12
        col1 =i;
        col2 =j;
        % all against all
        [h,p,ci] = ttest2(Exp2{exp,1}.contnoNodes(:,col1),Exp2{exp,1}.contnoNodes(:,col2),alpha, tail, type);  %tail is default to both, 2 in excel
        Exp3Isolated(i,j) = p;
        
    end
end

% modularity
exp = 3;
for i = 1:12
    for j = 1:12
        col1 =i;
        col2 =j;
        % all against all
        [h,p,ci] = ttest2(Exp2{exp,1}.March(:,col1),Exp2{exp,1}.March(:,col2),alpha, tail, type);  %tail is default to both, 2 in excel
        Exp3March(i,j) = p;
        
    end
end



%% Exp 3 against exp 1

% isolated nodes
exp1 = 1;
exp2 = 3;
for i = 1:10
    for j = 1:12
        col1 =i;
        col2 =j;
        % all against all
        [h,p,ci] = ttest2(Exp2{exp1,1}.contnoNodes(:,col1),Exp2{exp2,1}.contnoNodes(:,col2),alpha, tail, type);  %tail is default to both, 2 in excel
        Exp1y3Isolated(i,j) = p;
        
    end
end

% modularity
exp1 = 1;
exp2 = 3;
for i = 1:10
    for j = 1:12
        col1 =i;
        col2 =j;
        % all against all
        [h,p,ci] = ttest2(Exp2{exp1,1}.March(:,col1),Exp2{exp2,1}.March(:,col2),alpha, tail, type);  %tail is default to both, 2 in excel
        Exp1y3Isolated(i,j) = p;
        
    end
end






% test Exp 4 against it self
% isolated nodes
exp = 4;  
for i = 1:12
    for j = 1:12
        col1 =i;
        col2 =j;
        % all against all
        [h,p,ci] = ttest2(Exp1{exp,1}.contnoNodes(:,col1),Exp1{exp,1}.contnoNodes(:,col2),alpha, tail, type);  %tail is default to both, 2 in excel
        Exp4Isolated(i,j) = p;
        
    end
end

% modularity
exp = 4;
for i = 1:12
    for j = 1:12
        col1 =i;
        col2 =j;
        % all against all
        [h,p,ci] = ttest2(Exp2{exp,1}.March(:,col1),Exp2{exp,1}.March(:,col2),alpha, tail, type);  %tail is default to both, 2 in excel
        Exp4March(i,j) = p;
        
    end
end



%% Exp 4 against exp 3

% isolated nodes
exp1 = 3;
exp2 = 4;
for i = 1:12
    for j = 1:12
        col1 =i;
        col2 =j;
        % all against all
        [h,p,ci] = ttest2(Exp2{exp1,1}.contnoNodes(:,col1),Exp2{exp2,1}.contnoNodes(:,col2),alpha, tail, type);  %tail is default to both, 2 in excel
        Exp3y4Isolated(i,j) = p;
        
    end
end

% modularity
exp1 = 3;
exp2 = 4;
for i = 1:12
    for j = 1:12
        col1 =i;
        col2 =j;
        % all against all
        [h,p,ci] = ttest2(Exp2{exp1,1}.March(:,col1),Exp2{exp2,1}.March(:,col2),alpha, tail, type);  %tail is default to both, 2 in excel
        Exp3y4Modularity(i,j) = p;
        
    end
end


%% Exp 4 against exp 1

% isolated nodes
exp1 = 1;
exp2 = 4;
for i = 1:10
    for j = 1:12
        col1 =i;
        col2 =j;
        % all against all
        [h,p,ci] = ttest2(Exp2{exp1,1}.contnoNodes(:,col1),Exp2{exp2,1}.contnoNodes(:,col2),alpha, tail, type);  %tail is default to both, 2 in excel
        Exp1y4Isolated(i,j) = p;
        
    end
end

% modularity
exp1 = 1;
exp2 = 4;
for i = 1:10
    for j = 1:12
        col1 =i;
        col2 =j;
        % all against all
        [h,p,ci] = ttest2(Exp2{exp1,1}.March(:,col1),Exp2{exp2,1}.March(:,col2),alpha, tail, type);  %tail is default to both, 2 in excel
        Exp14yMarch(i,j) = p;
        
    end
end










% test Exp 6 against it self
% isolated nodes
exp = 5;    % 5 is the exp 5
for i = 1:12
    for j = 1:12
        col1 =i;
        col2 =j;
        % all against all
        [h,p,ci] = ttest2(Exp2{exp,1}.contnoNodes(:,col1),Exp2{exp,1}.contnoNodes(:,col2),alpha, tail, type);  %tail is default to both, 2 in excel
        Exp6Isolated(i,j) = p;
        
    end
end

% modularity
exp = 5;
for i = 1:12
    for j = 1:12
        col1 =i;
        col2 =j;
        % all against all
        [h,p,ci] = ttest2(Exp2{exp,1}.March(:,col1),Exp2{exp,1}.March(:,col2),alpha, tail, type);  %tail is default to both, 2 in excel
        Exp6March(i,j) = p;
        
    end
end





%% Exp 6 against exp 4

% isolated nodes
% exp1 = 4;
% exp2 = 5;
% for i = 1:12
%     for j = 1:12
%         col1 =i;
%         col2 =j;
%         % all against all
%         [h,p,ci] = ttest2(Exp2{exp2,1}.contnoNodes(:,col1),Exp2{exp2,1}.contnoNodes(:,col2),alpha, tail, type);  %tail is default to both, 2 in excel
%         Exp4y6Isolated(i,j) = p;
%         
%     end
% end

% modularity
exp1 = 4;
exp2 = 5;
for i = 1:12
    for j = 1:12
        col1 =i;
        col2 =j;
        % all against all
        [h,p,ci] = ttest2(Exp2{exp1,1}.March(:,col1),Exp2{exp1,1}.March(:,col2),alpha, tail, type);  %tail is default to both, 2 in excel
        Exp4y6Modularity(i,j) = p;
     
    end
end

% isolated nodes
% exp1 = 5;
% exp2 = 4;
% for i = 1:12
%     for j = 1:12
%         col1 =i;
%         col2 =j;
%         % all against all
%         [h,p,ci] = ttest2(Exp2{exp1,1}.contnoNodes(:,col1),Exp2{exp2,1}.contnoNodes(:,col2),alpha, tail, type);  %tail is default to both, 2 in excel
%         Exp3y4Isolated(i,j) = p;
%         
%     end
% end

% modularity
exp1 = 5;
exp2 = 4;
for i = 1:12
    for j = 1:12
        col1 =i;
        col2 =j;
        % all against all
        [h,p,ci] = ttest2(Exp2{exp1,1}.March(:,col1),Exp2{exp2,1}.March(:,col2),alpha, tail, type);  %tail is default to both, 2 in excel
        Exp3y4Modularity(i,j) = p;
        
    end
end


%% Exp 4 against exp 1

% isolated nodes
exp1 = 1;
exp2 = 5;
for i = 1:10
    for j = 1:12
        col1 =i;
        col2 =j;
        % all against all
        [h,p,ci] = ttest2(Exp2{exp1,1}.contnoNodes(:,col1),Exp2{exp2,1}.contnoNodes(:,col2),alpha, tail, type);  %tail is default to both, 2 in excel
        Exp1y4Isolated(i,j) = p;
        
    end
end

% modularity
exp1 = 1;
exp2 = 5;
for i = 1:10
    for j = 1:12
        col1 =i;
        col2 =j;
        % all against all
        [h,p,ci] = ttest2(Exp2{exp1,1}.March(:,col1),Exp2{exp2,1}.March(:,col2),alpha, tail, type);  %tail is default to both, 2 in excel
        Exp14yMarch(i,j) = p;
        
    end
end