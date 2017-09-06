using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MyCTS.Presentation.Components
{
   public class ValidateRegularExpression
    {
       public static bool ValidateDateFormat(String DateToValidate)
       {
           string Patron = @"^\d{2}[a-zA-Z]{3}$";
           Regex RegularExpression = new Regex(Patron);
           return RegularExpression.IsMatch(DateToValidate);
       }

       public static bool ValidateDateFormatComplete(String DateToValidate)
       {
           string Patron = @"\d{2}[- /.]\d{2}[- /.]\d{4}";
           Regex RegularExpression = new Regex(Patron);
           return RegularExpression.IsMatch(DateToValidate);
       }

       public static bool ValidatePNR(String PNRToValidate)
       {
           string Patron = @"^[A-Z]{6}$";
           Regex RegularExpression = new Regex(Patron);
           return RegularExpression.IsMatch(PNRToValidate);
       }

       public static bool ValidateBirthDateFormat(String DateToValidate)
       {
           string Patron = @"^\d{2}[a-zA-Z]{3}\d{2}$";
           Regex RegularExpression = new Regex(Patron);
           return RegularExpression.IsMatch(DateToValidate);
       }

       public static bool ValidateCorporateIdFormat(String CorporateIdToValidate)
       {
           string Patron = @"^[a-zA-Z]{3}\d{2}$";
           Regex RegularExpression = new Regex(Patron);
           return RegularExpression.IsMatch(CorporateIdToValidate);
       }

       public static bool ValidateTwoDecimalNumbers(String NumbertoValidate)
       {
           string Patron = @"^[0-9]{1,5}[.]{1}[0-9]{2}$";
           Regex RegularExpression = new Regex(Patron);
           return RegularExpression.IsMatch(NumbertoValidate);
       }

       public static bool ValidateSixDecimalNumbers(String NumbertoValidate)
       {
           string Patron = @"^[0-9]{1,5}[.]{1}[0-9]{6}$";
           Regex RegularExpression = new Regex(Patron);
           return RegularExpression.IsMatch(NumbertoValidate);
       }

       public static bool ValidateFourDecimalNumbers(String NumbertoValidate)
       {
           string Patron = @"^[0-9]{1,5}[.]{1}[0-9]{4}$";
           Regex RegularExpression = new Regex(Patron);
           return RegularExpression.IsMatch(NumbertoValidate);
       }

       public static bool ValidateThirteenNumbers(String NumbertoValidate)
       {
           string Patron = @"^[0-9]{13}";
           Regex RegularExpression = new Regex(Patron);
           return RegularExpression.IsMatch(NumbertoValidate);
       }

       public static bool ValidateTenNumbers(String NumbertoValidate)
       {
           string Patron = @"^[0-9]{10}";
           Regex RegularExpression = new Regex(Patron);
           return RegularExpression.IsMatch(NumbertoValidate);
       }

       public static bool ValidateOneDecimalNumber(String NumberValidate)
       {
           string Patron = @"^[0-9]{1}[.]{1}[0-9]{1}$";
           Regex RegularExpression = new Regex(Patron);
           return RegularExpression.IsMatch(NumberValidate);
       }


       public static bool ValidateOneorTwoPlusDecimalNumber(String NumberValidate)
       {
           string Patron = @"^[0-9]{1,2}[.]{1}[0-9]{1}$";
           Regex RegularExpression = new Regex(Patron);
           return RegularExpression.IsMatch(NumberValidate);
       }

       public static bool ValidateNumberandLetters(String NumberValidate)
       {
           string Patron = @"^([0-9a-zA-Z])*$";
           Regex RegularExpression = new Regex(Patron);
           return RegularExpression.IsMatch(NumberValidate);

       }

       public static bool ValidateTwoDecimals(String NumberValidate)
       {
           string Patron = @"^\d{1,8}[.]{1}\d{2}$";
           Regex RegularExpression = new Regex(Patron);
           bool value = RegularExpression.IsMatch(NumberValidate);
           return value;
       }

       public static bool ValidateTwoDecimalsPhaseIV(String NumberValidate)
       {
           string Patron = @"^\d{1,5}[.]{1}\d{2}$";
           Regex RegularExpression = new Regex(Patron);
           bool value = RegularExpression.IsMatch(NumberValidate);
           return value;
       }

       public static bool ValidateCharPerService(String NumbertoValidate)
       {
           string Patron = @"^[0-9]{1,4}[.]{1}[0-9]{2}$";
           Regex RegularExpression = new Regex(Patron);
           return RegularExpression.IsMatch(NumbertoValidate);
       }

       /// <summary>
       /// Valida que la cadena contexta solamente letras
       /// </summary>
       /// <param name="PNR">cadena</param>
       /// <param name="num">Número de letras permitidas</param>
       /// <returns></returns>
       public static bool ValidateNumLetters(string value, int num)
       {
           if (string.IsNullOrEmpty(value))
               return false;

           string pattern = @"^[a-zA-Z]{" + num.ToString() + "}";
           Regex RegularExpression = new Regex(pattern);
           return RegularExpression.IsMatch(value);
       }

       /// <summary>
       /// Valida que la cadena contexta solamente 6 letras
       /// </summary>
       /// <param name="PNR">cadena</param>
       /// <returns></returns>
       public static bool ValidateNumLetters(string value)
       {
           if (string.IsNullOrEmpty(value))
               return false;

           string pattern = @"^[a-zA-Z]{6}";
           Regex RegularExpression = new Regex(pattern);
           return RegularExpression.IsMatch(value);
       }

       public static bool ValidateDateFormatYear(String DateToValidate)
       {
           string Patron = @"^\d{2}[a-zA-Z]{3}\d{2}$";
           Regex RegularExpression = new Regex(Patron);
           return RegularExpression.IsMatch(DateToValidate);
       }

       public static bool ValidateEmailFormat(String MailToValidate)
       {

           //string Patron = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
           //Regex RegularExpression = new Regex(Patron);
           //bool value = RegularExpression.IsMatch(MailToValidate);
           //return value;
           
           string Patron = @"^[A-Za-z0-9_\-\.]+@[A-Za-z0-9_\-]+\.[A-Za-z]{2,3}$"; 
           Regex RegularExpression = new Regex(Patron);
           bool value = RegularExpression.IsMatch(MailToValidate);
           if (!value)
           {
               Patron = @"^[A-Za-z0-9_\-\.]+@[A-Za-z0-9_\-]+\.[A-Za-z]{2,3}.[A-Za-z]{2,3}$";
               RegularExpression = new Regex(Patron);
               value = RegularExpression.IsMatch(MailToValidate);
               if(!value)
               {
                   Patron = @"^[A-Za-z0-9_\-\.]+@[A-Za-z0-9_\-]+\.[A-Za-z]{2,20}.[A-Za-z]{2,20}$";
                   RegularExpression = new Regex(Patron);
                   value = RegularExpression.IsMatch(MailToValidate);
               }
           }
           if (MailToValidate.Contains(",") || MailToValidate.Contains("..") || MailToValidate.Contains(".@") 
               || MailToValidate.Contains("´") || MailToValidate.Contains(" "))
               value = false;
           
           return value;
       }

       public static bool ValidateRFCFormat(String StringToValidate)
       {
           string Patron = @"^([A-Z\s]{3,4})\d{6}([A-Z\w]{3})$";
           Regex RegularExpression = new Regex(Patron);
           return RegularExpression.IsMatch(StringToValidate);

       }

       public static bool ValidateProfile2ndLevelNameFormat(String NameToValidate)
       {
           string Patron = @"^[a-zA-Z]{1,20}[/]{1}[a-zA-Z]{1,20}$";
           Regex RegularExpression = new Regex(Patron);
           return RegularExpression.IsMatch(NameToValidate);
       }

       public static bool ValidateCharacter(string charater)
       {
           string patron = @"^([0-9.,-/ a-zA-Z])*$";
           Regex RegularExpression = new Regex(patron);
           return RegularExpression.IsMatch(charater);
       }

       public static bool ValidateNumbers(String NumberValidate)
       {
           string Patron = @"^([0-9])*$";
           Regex RegularExpression = new Regex(Patron);
           return RegularExpression.IsMatch(NumberValidate);

       }

       /// <summary>
       /// Valida que la cadena contexta solamente letras
       /// </summary>
       /// <param name="PNR">cadena</param>
       /// <returns></returns>
       public static bool ValidateOnlyLetters(string value)
       {
           if (string.IsNullOrEmpty(value))
               return false;

           string pattern = @"^[a-zA-Z]*$";
           Regex RegularExpression = new Regex(pattern);
           return RegularExpression.IsMatch(value);
       }

       /// <summary>
       /// Valida el formato de telefono a 10 digitos
       /// </summary>
       /// <param name="NumberValidate"></param>
       /// <returns></returns>
       public static bool ValidatePhoneNumber(String NumberValidate)
       {
           string Patron = @"^([0-9]{10})*$";
           Regex RegularExpression = new Regex(Patron);
           return RegularExpression.IsMatch(NumberValidate);

       }
    }
}
