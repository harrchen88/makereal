namespace SmartHotel.Registration.DataAccessLayer
{
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Globalization;
    using SmartHotel.Registration.AzureKeyVault.Interface;
    using SmartHotel.Registration.Configuration;
    using SmartHotel.Registration.Models;
    using Constants = SmartHotel.Registration.Helpers.Constants;

    public class BookingsDbContext : DbContext
    {
        private IKeyVaultManager keyVaultManager;

        public BookingsDbContext()
            : base(GetConnectionString())
        {
            this.Database.CommandTimeout = 60 * 10;
            Database.SetInitializer(new BookingsDbContextInitializer());
        }

        public virtual DbSet<Booking> Bookings { get; set; }

        private static string GetConnectionString()
        {
            System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();

            builder.DataSource = ConfigurationHelper.AuthenticationMode == Constants.AzureSQL
                ? string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}:{1}{2},{3}",
                    "tcp",
                    ConfigurationHelper.SqlServerName,
                    ".database.windows.net",
                    "1433")
                : ConfigurationHelper.SqlServerName;

            builder.InitialCatalog = ConfigurationHelper.DatabaseName;

            if (ConfigurationHelper.AuthenticationMode == Constants.Sql)
            {
                builder.IntegratedSecurity = false;
            }
            else if (ConfigurationHelper.AuthenticationMode == Constants.Windows)
            {
                builder.IntegratedSecurity = true;
            }

            if (ConfigurationHelper.AuthenticationMode == Constants.Sql || ConfigurationHelper.AuthenticationMode == Constants.AzureSQL)
            {
                var sqlServerAdmin = string.Empty;
                var sqlServerAdministratorPassword = string.Empty;
                if (ConfigurationHelper.AuthenticationMode == Constants.Sql)
                {
                     sqlServerAdmin = Constants.LocalSqlServerAdmin;
                     sqlServerAdministratorPassword = Constants.LocalSqlServerAdministratorPassword;
                }
                else
                {
                     sqlServerAdmin = Constants.SqlServerAdmin;
                     sqlServerAdministratorPassword = Constants.SqlServerAdministratorPassword;
                }

                // Below code uses keyvault to fetch sql server username and password
                builder.UserID = ConfigurationHelper.KeyVaultManager.GetSecretValue(sqlServerAdmin);
                builder.Password = ConfigurationHelper.KeyVaultManager.GetSecretValue(sqlServerAdministratorPassword);

                //builder.UserID = ConfigurationManager.AppSettings["AdministratorLogin"];
                //builder.Password = ConfigurationManager.AppSettings["AdministratorLoginPassword"];

                if (ConfigurationHelper.AuthenticationMode == Constants.AzureSQL)
                {
                    builder.MultipleActiveResultSets = true;
                    builder.Encrypt = true;
                    builder.TrustServerCertificate = false;
                    builder.ConnectTimeout = Constants.ConnectionTimeout;
                    builder.PersistSecurityInfo = false;
                }
            }

            return builder.ConnectionString;
        }
    }
}
