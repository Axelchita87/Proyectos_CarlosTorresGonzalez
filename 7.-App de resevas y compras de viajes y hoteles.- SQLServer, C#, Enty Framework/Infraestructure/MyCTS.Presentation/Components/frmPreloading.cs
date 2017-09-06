using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.Remoting.Messaging;
using MyCTS.Presentation.Components;

namespace MyCTS.Presentation.Components
{
    public partial class frmPreloading : Form
    {
        private CustomUserControl m_frmReference;
        public frmPreloading(CustomUserControl sender)
        {
            InitializeComponent();
            m_frmReference = sender;
        }

        private Form _frmReference;
        public frmPreloading(Form sender)
        {
            InitializeComponent();
            _frmReference = sender;
        }

        private void frmPreloading_Load(object sender, EventArgs e)
        {

        }

        private delegate void SenderLoadControl();
        private void frmPreloading_Shown(object sender, EventArgs e)
        {
            try
            {
                if (m_frmReference != null)
                {
                    SenderLoadControl slc = new SenderLoadControl(((IProcessAsync)m_frmReference).InitProcess);
                    AsyncCallback async = new AsyncCallback(EndInvokeMethod);
                    slc.BeginInvoke(async, null);
                }
                else
                {
                    try
                    {
                        SenderLoadControl slc = new SenderLoadControl(((IProcessAsync)_frmReference).InitProcess);
                        AsyncCallback async = new AsyncCallback(EndInvokeMethod);
                        slc.BeginInvoke(async, null);
                    }
                    catch { CloseThisWin(); }
                }
            }
            catch { CloseThisWin(); }
        }

        private void EndInvokeMethod(System.IAsyncResult result)
        {
            SenderLoadControl slc = (SenderLoadControl)((AsyncResult)result).AsyncDelegate;
            slc.EndInvoke(result);
            CloseThisWin();
        }

        private void CloseThisWin()
        {
            if (this.InvokeRequired)
                this.Invoke(new SenderLoadControl(CloseThisWin));
            else
            {
                try
                {
                    this.Close();
                    ((IProcessAsync)m_frmReference).EndProcess();
                }
                catch { }
                finally
                {

                }
            }
        }


    }
}