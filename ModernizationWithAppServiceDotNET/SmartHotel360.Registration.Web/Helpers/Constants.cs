using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHotel.Registration.Helpers
{
    //The Constants Class
    public class Constants
    {
        #region Authentication Mode for Database

        public const string Sql = "SQL";

        public const string AzureSQL = "AZURESQL";

        public const string Windows = "WINDOWS";

        #endregion

        #region Connection String Properties

        public const int ConnectionTimeout = 60;

        public const string SqlServerAdmin = "sqlserveradmin";

        public const string SqlServerAdministratorPassword = "sqlserveradministratorpassword";

        public const string LocalSqlServerAdmin = "localsqlserveradmin";

        public const string LocalSqlServerAdministratorPassword = "localsqlserveradministratorpassword";

        #endregion
    }
}