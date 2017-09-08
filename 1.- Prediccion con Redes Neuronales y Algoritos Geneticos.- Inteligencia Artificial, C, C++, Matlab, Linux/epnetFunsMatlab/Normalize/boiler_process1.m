% PROCESS FUNCTION BOILERPLATE CODE

% Copyright 2005 The MathWorks, Inc.

% TODO - Add size checking for X and Y

%function modificated 24 / 01 / 2008

if isstr(in1)
  switch lower(in1)
    case 'apply'
      if (nargin < 3), error('NNET:Arguments','Not enough input arguments for ''apply'' action.'); end
      if (nargin > 3), error('NNET:Arguments','Too many input arguments for ''apply'' action'), end
      if (nargout > 1), error('NNET:Arguments','Too many output arguments for ''apply'' action'), end
      
      out1 = apply_process(in2,in3);
      
    case 'reverse'
      if (nargin < 3), error('NNET:Arguments','Not enough input arguments for ''reverse'' action.'); end
      if (nargin > 3), error('NNET:Arguments','Too many input arguments for ''reverse'' action'), end
      if (nargout > 1), error('NNET:Arguments','Too many output arguments for ''reverse'' action'), end
      
      out1 = reverse_process(in2,in3);
      
      out2 = in3;
    otherwise
 %     error('NNET:Arguments',['First argument is an unrecognized action string: ' in1]);
  end
  return
end

if (nargin < 2)
  in2 = param_defaults({});
elseif isa(in2,'struct')
  if (nargin > 2),error('NNET:Arguments','Too many input arguments when second argument is parameter structure FP'), end
else
  numFields = length(fieldnames(param_defaults({})));
  if (nargin > 1 + numFields), error('Too many input argument'), end
  values = {in2};
  if (nargin > 2), values{2} = in3; end
  if (nargin > 3), values = [values varargin]; end
  in2 = param_defaults(values);
end
%err = param_check(in2);

[out1,out2] = new_process(in1,in2); y =[]; % MATLAB BUG if [out1,y] =...
