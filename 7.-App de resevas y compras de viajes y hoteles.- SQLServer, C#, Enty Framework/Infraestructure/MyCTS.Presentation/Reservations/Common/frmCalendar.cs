using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyCTS.Presentation.Components;
using MyCTS.Business;
using MyCTS.Entities;

namespace MyCTS.Presentation
{
   public partial class frmCalendar : Form
   {

       private string dateCalendar;
       private string day;
       private string month;
       private string year;
       private string date;
       public delegate void frmCalendarrEventHandler(object sender, UpdateEventArgs e);
       public event frmCalendarrEventHandler frmCalendarUpdate;

      public frmCalendar()
      {
         InitializeComponent();

      }

      private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
      {
         //Formateo de fecha seleccionada
         dateCalendar = String.Format("{0:ddMMyyyy}", monthCalendar.SelectionStart);  
         day = dateCalendar.Substring(0, 2);
         month = dateCalendar.Substring(2, 2);
         year = dateCalendar.Substring(4, 4);


         if (month == "01")
             month = "JAN";
         else if (month == "02")
             month = "FEB";
         else if (month == "03")
             month = "MAR";
         else if (month == "04")
             month = "APR";
         else if (month == "05")
             month = "MAY";
         else if (month == "06")
             month = "JUN";
         else if (month == "07")
             month = "JUL";
         else if (month == "08")
             month = "AUG";
         else if (month == "09")
             month = "SEP";
         else if (month == "10")
             month = "OCT";
         else if (month == "11")
             month = "NOV";
         else if (month == "12")
             month = "DEC";

         //Fecha a enviar
         date = day + month+ year;

         //LLamado a delegado
         UpdateEventArgs updateeventargs = new UpdateEventArgs(date);
         frmCalendarUpdate(this, updateeventargs);
         this.Close();

         
      }

       

   }
}