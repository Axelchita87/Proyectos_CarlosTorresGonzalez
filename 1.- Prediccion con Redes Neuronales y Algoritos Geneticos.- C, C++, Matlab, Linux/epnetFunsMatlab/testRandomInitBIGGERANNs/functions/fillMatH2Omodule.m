%% Fill the H2O matrix trying to create modules in the random
%% initialization
% This function fills first the diagonal matrix with the higer probability
% and then the rest of the matrix with lower probabilities in case of many
% outputs
% For one output the matrix is filled from lower prob to high probs
%
% Created       14 Oct 2010
% Modified at:
% Author:       Carlos Torres and Victor Landassuri

%% Function
function m = fillMatH2Omodule(m,vec1,vec2,initval,finalval, flagZero)
% it is expected that finalval is the max value introduced



inc = 0;   % col increment
x = 0;

if size(vec2,2) == 1   % just one output
    
    if initval < finalval
        inc = (finalval - initval) / (size(vec1,2)-1);
    else
        inc = (initval - finalval) / (size(vec1,2)-1);
    end
    x = initval;
    
    for j = vec2
        for i = vec1
            m(i,j) = x;
            if initval < finalval
                x = x + inc;
            else
                x = x - inc;
            end
        end
    end
    
else
    % First detect that the matrix is squared, if that is the case then it
    % is easy to fill it
    
    MAX = max([initval finalval]);
    MIN = min([initval finalval]);
    
    if size(vec1,2) == size(vec2,2)
        %% if it is squared
        
        % fill diagoanl matrix with the max probability
        conti = 1;
        contj = 1;
        for i = vec1
            contj = 1;
            for j = vec2
                if conti == contj
                    m(i,j) = MAX;
                end
                contj = contj + 1;
            end
            conti = conti + 1;
        end
        
        % fill the other corners with the min
        m(vec1(1,1), vec2(size(vec2,2))) = MIN;
        m(vec1(size(vec1,2)), vec2(1,1) ) = MIN;
        
        
        if nargin ~= 6
            
            
            % ready to fill the rest of the lines and columns
            
            % Fill the first line and the last
            % Then vertically it will be filled each colum from the initial
            % value to the MAX in the diagonal, and form the diagonla to the
            % bottom
            
            inc = (MAX - MIN) / (size(vec2,2)-1);
            x = MAX;
            
            % fill first line
            i = vec1(1,1);
            for j = vec2
                m(i,j) = x;
                x = x - inc;
            end
            
            % fill last line
            i = vec1(size(vec1,2));
            x = MIN;
            for j = vec2
                m(i,j) = x;
                x = x + inc;
            end
            
            % Fill by columns, the values in line 1 vec(1,:) are the min and
            % the max is MAX
            % first the upper right part of the matrix
            conti = 1;
            contj = 2;
            for j = vec2(1,1)+1:vec2(size(vec2,2))
                conti = 1;
                
                min1 = m(vec1(1,1), j);
                % I now that the max is MAX
                
                inc = (MAX - min1) / ( contj - 1);
                x = min1;
                
                for i = vec1
                    if conti < contj
                        if contj > 2            % only count after the third because the previous is already filled
                            m(i,j) = x;
                            x = x + inc;
                        end
                    else
                        break;
                    end
                    conti = conti + 1;
                end
                contj = contj + 1;
            end
            
            % first the lower left part of the matrix
            conti = 2;
            contj = 1;
            % it is a squared matrix so the lines to divided the inc the first
            % time is allways size(vec1,2) - 1
            contSpace = size(vec1,2) -1;
            for j = vec2(1,1):vec2(size(vec2,2) -1)
                %conti = 2;
                
                min1 = m(vec1(size(vec1,2)), j);
                % I now that the max is MAX
                
                inc = (MAX - min1) / ( contSpace);
                x = MAX - inc;
                
                for i = vec1(conti):vec1(size(vec1,2))
                    if conti > contj
                        if contj <= size(vec2,2) -2            % only count before the last 3 because the next are already filled
                            m(i,j) = x;
                            x = x - inc;
                        end
                    else
                        break;
                    end
                    
                end
                conti = conti + 1;
                contj = contj + 1;
                contSpace = contSpace -1;
            end
        end % end nargin
        
    else
        % if it is not squared
        
        
        
        
        % fill the corners with the max
        m(vec1(1,1), vec2(1,1)) = MAX;
        m(vec1(size(vec1,2)), vec2(size(vec2,2)) ) = MAX;
        
        % fill the other corners with the min
        m(vec1(1,1), vec2(size(vec2,2))) = MIN;
        m(vec1(size(vec1,2)), vec2(1,1) ) = MIN;
        
        
        if nargin ~= 6
            
            % ready to fill the rest of the lines and columns
            
            % Fill the first line and the last
            % Then vertically it will be filled each colum from the initial
            % value to the MAX in the diagonal, and form the diagonla to the
            % bottom
            
            inc = (MAX - MIN) / (size(vec2,2)-1);
            x = MAX-inc;
            
            % fill first line
            i = vec1(1,1);
            for j = vec2(1,2):vec2(size(vec2,2))
                m(i,j) = x;
                x = x - inc;
            end
            
            % fill last line
            i = vec1(size(vec1,2));
            x = MIN;
            for j = vec2(1,1):vec2(size(vec2,2)-1)
                m(i,j) = x;
                x = x + inc;
            end
            
        end
        
        % Find if it is bigger vertically or horizontally, i.e. grows more
        % to tye bottom or to the right
        if size(vec1,2) < size(vec2,2)
            % if it is bigger horizintally
            numONESper = ceil(size(vec2,2) / size(vec1,2));
            grow2 = 0;
            % accomodate the vector in a nre position having always the
            % bigger in b and the smaller in s
            smallV = vec1;
            bigV = vec2;
        else
            % if it is biggre vertically
            numONESper = ceil(size(vec1,2) / size(vec2,2));
            grow2 = 1;
            smallV = vec2;
            bigV = vec1;
        end
        
        
        % Do the next only if the smaller value is bigger than 2, because
        % if it is two all the mat is already filled, even not with the
        % most suitable values but it does not matter in this moment
        
        %if smallV > 1 % do not enter if there is only one hidden node
        
        %if (size(smallV,2) ~= 2 ) && grow2 ~= 0 % do not enter if it is horizontal and the small vec = 2
        if ~ ((size(smallV,2) == 2 ) && (grow2 == 0))
            
            
            
            
            % fill diagonal matrix with the max probability
            %conti = 1;
            contj = 1;
            contONES = 1;
            
            if grow2 == 1
                % If grows vetically
                for i = smallV
                    contONES = 1;
                    if contj <= size(bigV,2)
                        % to avoid go outside the matrix if the lines and
                        % cols are similar, e.g. 13,9
                        for j = bigV(contj): bigV(size(bigV,2))
                            if contONES <= numONESper
                                m(j,i) = MAX;
                                contj = contj + 1;
                                contONES = contONES +1;
                            else
                                break;
                            end
                        end
                    end
                end
                
                
            else
                % if grows horizontally
                
                for i = smallV
                    contONES = 1;
                    if contj <= size(bigV,2) % to not exceed the vector
                        for j = bigV(contj): bigV(size(bigV,2))
                            if contONES <= numONESper
                                m(i,j) = MAX;
                                contj = contj + 1;
                                contONES = contONES +1;
                            else
                                break;
                            end
                        end
                    end
                end
            end
            
            
            % Fill by columns, the values in line 1 vec(1,:) are the min and
            % the max is MAX
            
            if nargin ~= 6
                
                % first the lower left part of the matrix
                conti = 2;
                contj = 1;
                % the lines to divided the inc the first
                % time is allways size(vec1,2) - 1
                contSpace = 0;    %size(vec1,2) -1;
                for j = vec2(1,1):vec2(size(vec2,2) -1)
                    %conti = 2;
                    
                    min1 = m(vec1(size(vec1,2)), j);
                    % I now that the max is MAX
                    
                    % find where is the last one (or MAX) in the column, and then
                    % count the spaces to the last line
                    flagMAX = 0;
                    contSpace = 0;
                    contii = 0;
                    for i =  vec1(1,1):vec1(size(vec1,2) -1)
                        contii = contii + 1;
                        % the first must not count
                        %if contii > 1
                        if m(i,j) > 0
                            contSpace = 0;
                            flagMAX = 1;
                            initVec = contii+1;  % know where I will start to fill
                        end
                        %end
                        if flagMAX == 1
                            % count it with the max val
                            contSpace = contSpace + 1;
                        end
                    end
                    
                    
                    
                    inc = (MAX - min1) / ( contSpace);
                    x = MAX - inc;
                    
                    for i = vec1(initVec):vec1(size(vec1,2))
                        %if conti > contj
                        if contj <= size(vec2,2) -2            % only count before the last 3 because the next are already filled
                            m(i,j) = x;
                            x = x - inc;
                        end
                        %else
                        %    break;
                        %end
                        
                    end
                    conti = conti + 1;
                    contj = contj + 1;
                    contSpace = contSpace -1;
                end
                
                
                
                
                
                
                % first the upper right part of the matrix
                conti = 2;
                contj = 1;
                contSpace = 0;
                v = vec2(end:-1:1);
                
                for j = v(1,1):-1:v(size(v,2) -1)
                    %conti = 2;
                    
                    min1 = m(vec1(1,1), j);
                    % I now that the max is MAX
                    
                    % find where is the last one (or MAX) in the column, and then
                    % count the spaces to the lsat line
                    flagMAX = 0;
                    contSpace = 0;
                    contii = 0;
                    for i =  vec1(1,1):vec1(size(vec1,2) )
                        contii = contii + 1;
                        if contii > 1
                            if m(i,j)  == MAX  &&    flagMAX == 0                %       contSpace = 0;
                                flagMAX = 1;
                                stopVec = contii -1 ;  % know where I will start to fill
                            end
                        end
                        if flagMAX == 0
                            % count it with the max val
                            contSpace = contSpace + 1;
                        end
                    end
                    
                    if stopVec > 0
                        
                        inc = (MAX - min1) / ( contSpace );
                        x = min1;
                        
                        for i = vec1(1,1):vec1(stopVec)
                            %if conti > contj
                            if contj <= size(vec2,2) -1            % only count before the last 3 because the next are already filled
                                m(i,j) = x;
                                x = x + inc;
                            end
                            %else
                            %    break;
                            %end
                            
                        end
                        conti = conti + 1;
                        contj = contj + 1;
                        contSpace = contSpace -1;
                    end
                end  % end for the upper right part of the mat
                
            end % end of nargin to put all in zero if reuqired
            
        end % end if the smaller vector is > 2
        
    end % end squared or not
    
    
    
end % end if just one output
