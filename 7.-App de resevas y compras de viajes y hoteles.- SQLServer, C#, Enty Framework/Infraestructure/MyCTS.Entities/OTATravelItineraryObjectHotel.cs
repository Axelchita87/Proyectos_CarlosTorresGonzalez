using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class OTATravelItineraryObjectHotel
    {
        private string record;
        public string Record {
            get { return record; }
            set { record = value; }
        }

        private string confirmation_number;
        public string Confirmation_Number {
            get { return confirmation_number; }
            set { confirmation_number = value; }
        }

        private string hotel;
        public string Hotel { get; set; }


        private bool prov_direct_pay;
        public bool Prov_Direct_Pay
        {
            get { return prov_direct_pay; }
            set { prov_direct_pay = value; }
        }

        private string dk;
        public string DK
        {
            get { return dk; }
            set { dk = value; }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private string rfc;
        public string RFC
        {
            get { return rfc; }
            set { rfc = value; }
        }
        private string mail;
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        private string request;
        public string Request
        {
            get { return request; }
            set { request = value; }
        }

        private string payment_form;
        public string Payment_Form
        {
            get { return payment_form; }
            set { payment_form = value; }
        }
        private int car_number;
        public int Car_Number
        {
            get { return car_number; }
            set { car_number = value; }
        }
        private string sales_source;
        public string Sales_Source
        {
            get { return sales_source; }
            set { sales_source = value; }
        }
        private string operational_unit;
        public string Operational_Unit
        {
            get { return operational_unit; }
            set { operational_unit = value; }
        }
        private string user;
        public string User
        {
            get { return user; }
            set { user = value; }
        }
        private string service_type;
        public string Service_Type {
            get { return service_type; }
            set {service_type=value; }
        }
        private string provider;
        public string Provider
        {
            get { return provider; }
            set { provider = value; }
        }
        private string site;
        public string Site {
            get { return site; }
            set { site = value; }
        
        }
        private DateTime in_date;
        public DateTime In_Date
        {
            get { return in_date; }
            set { in_date = value; }
        }
        private DateTime out_date;
        public DateTime Out_Date
        {
            get {return out_date; }
            set { out_date = value; }
        }

        private string room;
        public string Room {
            get { return room; }
            set { room = value; }
        }
        private string room_type;
        public string Room_Type {
            get { return room_type; }
            set { room_type = value; }
        }
        private string meal_plan;
        public string Meal_Plan {
            get { return meal_plan; }
            set { meal_plan = value; }
        }
        private double number_nights;
        public double Number_Nights {
            get { return number_nights; }
            set { number_nights = value; }
        }
        private string passenger_name;
        public string Passenger_Name {
            get { return passenger_name; }
            set { passenger_name = value; }
        }
        private int passenger_num;
        public int Passenger_Num
        {
            get { return passenger_num; }
            set { passenger_num = value; }
        }

        private string surname;
        public string Surname {
            get { return surname; }
            set { surname = value; }
        }
        private string title;
        public string Title {
            get { return title; }
            set { title = value; }
        }
        private string passenger_type;
        public string Passenger_Type {
            get { return passenger_type; }
            set { passenger_type = value; }
        }
        private string rate;
        public string Rate {
            get { return rate; }
            set { rate = value; }
        
        }
        private string currency;
        public string Currency {
            get { return currency; }
            set { currency = value; }
        }
        private string provider_commission;
        public string Provider_Commission {
            get { return provider_commission; }
            set{provider_commission=value;}
        }
        private double cost;
        public double Cost {
            get { return cost; }
            set { cost = value; }
        }
        private double price;
        public double Price {
            get { return price; }
            set { price = value; }
        }
        private double iva;
        public double IVA {
            get { return iva; }
            set { iva = value; }
        }
        private double total_s_taxes;
        public double Total_S_Taxes {
            get { return total_s_taxes; }
            set { total_s_taxes = value; }
        }
        private double total_c_taxes;
        public double Total_C_Taxes {
            get { return total_c_taxes; }
            set { total_c_taxes = value; }
        }
        private double total_mn;
        public double Total_MN {
            get { return total_mn; }
            set { total_mn = value; }
        }
        private string p_rate;
        public string P_Rate {
            get { return p_rate; }
            set { p_rate = value; }
        }
        private string p_currency;
        public string P_Currency {
            get { return p_currency; }
            set { p_currency = value; }
        }

        private string p_iva;
        public string P_IVA {
            get { return p_iva; }
            set { p_iva = value; }
        }
        private string p_ish;
        public string P_ISH {
            get { return p_ish; }
            set { p_ish = value; }
        }
        private string p_total;
        public string P_Total {
            get { return p_total; }
            set { p_total = value; }
        }
        private DateTime c_date;
        public DateTime C_Date
        {
            get { return c_date; }
            set { c_date = value; }
        
        }
        private int c_key;
        public int C_Key {
            get { return c_key; }
            set { c_key = value; }
        
        }
        private string c_confirmated_by;
        public string C_Confirmated_By {
            get { return c_confirmated_by; }
            set { c_confirmated_by = value; }
        }
        private string c_responsible;
        public string C_Responsible {
            get { return c_responsible; }
            set{c_responsible=value;}
        }
        private DateTime time_limit;
        public DateTime Time_Limit {
            get { return time_limit; }
            set { time_limit = value; }
        }
        private string city;
        public string City {
            get { return city; }
            set { city = value; }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        private string cancel_number;
        public string Cancel_Number
        {
            get { return cancel_number; }
            set { cancel_number = value; }
        }

        private List<string> cancelnumberList = new List<string>();
        public List<string> CancelNumberList
        {
            get { return cancelnumberList; }
            set { cancelnumberList = value; }
        }

        private string chaincode;
        public string ChainCode {
            get { return chaincode; }
            set { chaincode = value; }
        }

        private List<string> commission = new List<string>();
        public List<string> Commission
        {
            get { return commission; }
            set { commission = value; }
        }


        private double changeType;
        public double ChangeType
        {
            get { return changeType; }
            set { changeType = value; }
        }

        private int orgid;
        public int OrgId { get; set; }

        private string firm;
        public string Firm { get; set; }

        private string pcc;
        public string Pcc { get; set; }

        private string remarks;
        public string Remarks { get; set; }

        private string username;
        public string UserName { get; set; }

        private string errorwssabre;
        public string errorWSSabre { get; set; }

        private string description;
        public string Description { get { return description; } set { description = value; } }

        private string in_City;
        public string In_City { get { return in_City; } set { in_City = value; } }

        private string out_City;
        public string Out_City { get { return out_City; } set { out_City = value; } }

        private string statusSabre;
        public string StatusSabre { get { return statusSabre; } set { statusSabre = value; } }
       
    }

}
