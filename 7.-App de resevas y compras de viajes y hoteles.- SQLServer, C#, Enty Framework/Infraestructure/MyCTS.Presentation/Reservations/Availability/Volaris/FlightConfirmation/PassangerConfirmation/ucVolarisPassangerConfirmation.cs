using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCTS.Entities;
using MyCTS.Presentation.Components;
using MyCTS.Presentation.Reservations.Availability.Volaris.FlightConfirmation.PassangerConfirmation;

namespace MyCTS.Presentation
{
    public partial class ucVolarisPassangerConfirmation : CustomUserControl, IVolarisPassangerConfirmationView
    {
        public ucVolarisPassangerConfirmation()
        {
            InitializeComponent();
            _layoutPanel = new TableLayoutPanel
                               {
                                   
                                  
                                   AutoSize = true,
                                   AutoSizeMode =  AutoSizeMode.GrowOnly
                                   
                               };
            _layoutPanel.ColumnStyles.Add(new ColumnStyle
            {
                SizeType = SizeType.AutoSize,
            });
        }

        #region Miembros de IVolarisPassangerConfirmationView

        public VolarisPassangers Passangers { get; set; }
        private VolarisPassangerConfirmationPresenter _presenter;

        private void SetPassangers()
        {
            

            if(Passangers != null && Passangers.GetAll().Any())
            {
                var passsangers = Passangers.GetAll();
                int h = 0;
                foreach (var volarisPassanger in passsangers)
                {
                    int rowIndex = AddRow();
                    _layoutPanel.Controls.Add(new ucVolarisPasssangerName
                                                  {
                                                      PassangerName = volarisPassanger.FullName,
                                                      
                                                      
                                                  },
                                              0,
                                              rowIndex);
                    
                        h += 30;
                    _layoutPanel.RowStyles[rowIndex].Height = 30;
                     _layoutPanel.RowStyles[rowIndex].SizeType = SizeType.Absolute;




                }
                _layoutPanel.Height = h;


            }
        }

        private int AddRow()
        {
            return _layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute));
        }

        private  readonly TableLayoutPanel _layoutPanel;

        #endregion

        #region Miembros de IBaseView


        public void ValidateInput()
        {
            
        }

        public bool IsValid { get; set; }

        #endregion

        private void ucVolarisPassangerConfirmation_Load(object sender, EventArgs e)
        {
            _presenter = new VolarisPassangerConfirmationPresenter
                             {
                                 View = this,
                                 Repository = new VolarisPassangerConfirmationRepository()
                             };
            SetPassangers();
            container.Controls.Add(_layoutPanel);
        }
    }
}
