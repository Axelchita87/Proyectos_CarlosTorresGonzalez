using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using MyCTS.Entities;
using DevExpress.XtraEditors;

namespace MyCTS.Presentation.Base
{
    public abstract class ErrorController
    {

        /// <summary>
        /// 
        /// </summary>
        private ErrorProvider _errorProvider;
        /// <summary>
        /// Gets the error provider.
        /// </summary>
        private ErrorProvider ErrorProvider
        {
            get { return _errorProvider ?? (_errorProvider = new ErrorProvider { }); }
        }

        /// <summary>
        /// 
        /// </summary>
        private DXErrorProvider _devErrorProvider;
        /// <summary>
        /// Gets the dev express error provider.
        /// </summary>
        private DXErrorProvider DevExpressErrorProvider
        {
            get { return _devErrorProvider ?? (_devErrorProvider = new DXErrorProvider { }); }
        }



        /// <summary>
        /// 
        /// </summary>
        private Dictionary<ErrorCode, Control> _errorDictonaryForDevExpress;

        /// <summary>
        /// Gets the error dictonary.
        /// </summary>
        private Dictionary<ErrorCode, Control> ErrorDictonaryDevExpress
        {

            get { return _errorDictonaryForDevExpress ?? (_errorDictonaryForDevExpress = new Dictionary<ErrorCode, Control>()); }
        }

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<ErrorCode, Control> _errorDictonary;

        /// <summary>
        /// Gets the error dictonary.
        /// </summary>
        private Dictionary<ErrorCode, Control> ErrorDictonary
        {

            get { return _errorDictonary ?? (_errorDictonary = new Dictionary<ErrorCode, Control>()); }
        }

        /// <summary>
        /// Registers the error with control.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="control">The control.</param>
        public void RegisterErrorWithControl(ErrorCode errorCode, Control control)
        {
            bool isControlFromDevExpress = control is BaseControl;
            if (isControlFromDevExpress)
            {
                RegisterDevExpressControl(errorCode, control);
            }
            else
            {

                RegisterDefaultControl(errorCode, control);
            }

        }

        /// <summary>
        /// Registers the dev express control.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="control">The control.</param>
        private void RegisterDevExpressControl(ErrorCode errorCode, Control control)
        {

            if (!ErrorDictonaryDevExpress.ContainsKey(errorCode))
            {
                control.GotFocus += (DevExpressControl_GotFocus);
                ErrorDictonaryDevExpress.Add(errorCode, control);
            }

        }

        /// <summary>
        /// Handles the GotFocus event of the DevExpressControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DevExpressControl_GotFocus(object sender, EventArgs e)
        {
            var control = sender as Control;

            if (control != null)
            {
                DevExpressErrorProvider.SetError(control, string.Empty);
            }
        }

        /// <summary>
        /// Registers the default control.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="control">The control.</param>
        private void RegisterDefaultControl(ErrorCode errorCode, Control control)
        {
            if (!this.ErrorDictonary.ContainsKey(errorCode))
            {
                control.GotFocus += (Control_GotFocus);
                ErrorDictonary.Add(errorCode, control);

            }

        }

        /// <summary>
        /// Handles the GotFocus event of the Control control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Control_GotFocus(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control != null)
            {
                ErrorProvider.SetError(control, string.Empty);
            }
        }

        /// <summary>
        /// Registers the error with dev express control as default.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="control">The control.</param>
        public void RegisterErrorWithDevExpressControlAsDefaultControl(ErrorCode errorCode, Control control)
        {

            RegisterDevExpressControl(errorCode, control);
        }


        /// <summary>
        /// Sets the error.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void HandleError(Exception exception)
        {
            if (exception.Data["ErrorCode"] != null)
            {
                var errorCode = (ErrorCode)exception.Data["ErrorCode"];

                HandleErrorDefaultControls(errorCode, exception.Message);
                HandleErrorDevExpressControls(errorCode, exception.Message);

            }
        }


        /// <summary>
        /// Becomes the handled.
        /// </summary>
        private void TurnOnErrorHandledStatus()
        {
            _wasHandled = true;
        }
        private bool _wasHandled = false;
        public bool ErrorWasHandled { get { return _wasHandled; } }

        public void TurnOffErrorHandledStatus()
        {
            _wasHandled = false;
        }

        /// <summary>
        /// Handles the error default controls.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="message">The message.</param>
        private void HandleErrorDefaultControls(ErrorCode errorCode, string message)
        {
            if (ErrorDictonary.ContainsKey(errorCode))
            {
                TurnOnErrorHandledStatus();
                var control = ErrorDictonary[errorCode];
                ErrorProvider.SetError(control, message.ToUpper());
                ErrorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);

            }
        }
        /// <summary>
        /// Handles the error dev express controls.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="message">The message.</param>
        private void HandleErrorDevExpressControls(ErrorCode errorCode, string message)
        {
            if (ErrorDictonaryDevExpress.ContainsKey(errorCode))
            {
                TurnOnErrorHandledStatus();
                var control = ErrorDictonaryDevExpress[errorCode];
                DevExpressErrorProvider.SetError(control, message.ToUpper());
                DevExpressErrorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
                DevExpressErrorProvider.SetErrorType(control, ErrorType.Critical);

            }
        }






    }
}
