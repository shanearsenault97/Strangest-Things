using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkShopPOS
{
    class UserAccess
    {
        private string EmpNum;
        private string Password;
        private int UserTypeCode;

        // instantiate a corresponding UserAccess data access object
        UserAccessDAO loginData;

        // this constructor ensures that a corresponding data access object is created for every UserAccess object
        public UserAccess()
        {
            loginData = new UserAccessDAO();
          
        }
 

        public string Emp_Num
        {
            get { return this.EmpNum; }
            set { this.EmpNum = value; }
        }
        public string password
        {
            get { return this.Password; }
            set { this.Password = value; }
        }

        public int User_Type_Code
        {
            get { return this.UserTypeCode; }
            set { this.UserTypeCode = value; }
        }

        // calls the login method from the data object layer
        public void Login()
        {
            loginData.Login(this);
        }

        // calls the Add method from the data object layer
        public void Add()
        {
            loginData.Add(this);
        }

    }
}

  