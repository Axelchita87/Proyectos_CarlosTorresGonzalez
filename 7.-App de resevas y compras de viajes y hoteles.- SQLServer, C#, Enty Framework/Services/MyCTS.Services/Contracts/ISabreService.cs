using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Services.Contracts
{
    public interface ISabreService<T> : IService<T> where T : class
    {

        string SecurityToken { get; set; }
        string ConversationID { get; set; }
        bool Success { get; set; }
        string ErrorMessage { get; set; }
    }

    public interface ISabreService : IService
    {
        string SecurityToken { get; set; }
        string ConversationID { get; set; }
        bool Success { get; set; }
        string ErrorMessage { get; set; }
    }
}
