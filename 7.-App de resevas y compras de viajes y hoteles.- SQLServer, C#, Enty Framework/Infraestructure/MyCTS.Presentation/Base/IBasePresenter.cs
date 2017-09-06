using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Presentation.Base
{
    public interface IBasePresenter<TView,TRepository>
        where TView : IBaseView
        where TRepository: IBaseRepository
    {

           TView View { get; set; }
           TRepository Repository { get; set; }
         
        void InitializeView();
        void UpdateView(object modelObject);

    }
}
