/* User: Heather Watterson and Jonathan Deschene
* Date: 2017-01-20
* Time: 2:45 PM
* Purpose: Business layer class for UserAccess object
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PorkShopPOS
{
    class UserAccess
    {
        private int accountId;
        private string empNum;
        private string password;
        private int type;

        // instantiate a corresponding UserAccess data access object
        UserAccessDAO loginData;

        // this constructor ensures that a corresponding data access object is created for every UserAccess object
        public UserAccess()
        {
            loginData = new UserAccessDAO();
          
        }

        public int AccountId
        {
            get { return this.accountId; }
            set { this.accountId = value; }
        }
        public string EmpNum
        {
            get { return this.empNum; }
            set { this.empNum = value; }
        }
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public int Type
        {
            get { return this.type; }
            set { this.type = value; }
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

        // calls the Update method from the data object layer
        public void Update()
        {
            loginData.Update(this);
        }

        // calls the Search method from the data object layer
        public void Search()
        {
            loginData.Search(this);
        }

        // calls the Delete method from the data object layer
        public void Delete()
        {
            loginData.Delete(this);
        }

        // calls the showAllUserAccess from the data layer
        public void showAllUserAccess(DataGridView dgv)
        {
            loginData.showAllUserAccess(dgv);
        }
    }
}

  