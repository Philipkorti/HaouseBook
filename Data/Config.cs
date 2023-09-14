using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Config
    {
        #region ------------------------- Fields, Constants, Delegates, Events --------------------------------------------
        private string country;
        private string curentcy;
        private string income;
        private string banckBalance;
        private bool forthmonthsalary;
        private bool monthsalary;
        private DateTime forthmonthsalaryDate;
        private DateTime monthsalaryDate;
        private string path;
        #endregion
        #region ------------------------- Properties, Indexers ------------------------------------------------------------
        public string Country { get { return this.country; } set { if (this.country != value) { this.country = value; } } }
        public string Curentcy { get { return this.curentcy; } set { if (this.curentcy != value) { this.curentcy = value; } } }
        public string Income { get { return this.income; } set { if(this.income != value) { this.income = value;} } }
        public string BanckBalance { get { return this.banckBalance; } set { if(this.banckBalance != value) { this.banckBalance = value; } } }
        public bool Forthmonthsalary { get { return this.forthmonthsalary; } set { if(this.forthmonthsalary != value) { this.forthmonthsalary = value;} } }
        public bool Monthsalary { get { return this.monthsalary; } set { if(this.monthsalary != value) { this.monthsalary = value; } } }
        public DateTime ForthmonthsalaryDate { get { return this.forthmonthsalaryDate;} set { if(this.forthmonthsalaryDate != value) { this.forthmonthsalaryDate = value; }} }
        public DateTime MonthsalaryDate { get { return this.monthsalaryDate;} set { if(this.monthsalaryDate != value) { this.monthsalaryDate = value; }} }
        public string Path { get { return this.path; } set { if(this.path != value) { this.path = value; }} }
        #endregion
    }
}
