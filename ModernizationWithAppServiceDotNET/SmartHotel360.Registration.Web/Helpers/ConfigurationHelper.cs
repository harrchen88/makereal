using SmartHotel.Registration.AzureKeyVault.Concrete;
using SmartHotel.Registration.AzureKeyVault.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace SmartHotel.Registration.Configuration
{
    /// <summary>
    /// The configuration helper class
    /// </summary>
    public static class ConfigurationHelper
    {

        /// <summary>
        /// Key Vault manager instance
        /// </summary>
        private static IKeyVaultManager keyVaultManager;

        /// <summary>Gets the instrumentation key.</summary>
        /// <value>The instrumentation key.</value>
        public static string InstrumentationKey => Convert.ToString(ConfigurationManager.AppSettings["InstrumentationKey"], CultureInfo.InvariantCulture);

        /// <summary>Gets the authentication mode.</summary>
        /// <value>The authentication mode.</value>
        public static string AuthenticationMode => Convert.ToString(ConfigurationManager.AppSettings["AuthenticationMode"], CultureInfo.InvariantCulture).ToUpperInvariant();

        /// <summary>Gets the name of the SQL server.</summary>
        /// <value>The name of the SQL server.</value>
        public static string SqlServerName => Convert.ToString(ConfigurationManager.AppSettings["SqlServerName"], CultureInfo.InvariantCulture);

        /// <summary>Gets the name of the database.</summary>
        /// <value>The name of the database.</value>
        public static string DatabaseName => Convert.ToString(ConfigurationManager.AppSettings["DatabaseName"], CultureInfo.InvariantCulture);

        /// <summary>Gets the key vault URI.</summary>
        /// <value>The key vault URI.</value>
        public static string KeyVaultUri => Convert.ToString(ConfigurationManager.AppSettings["KeyVaultUri"], CultureInfo.InvariantCulture);

        public static string ServicePrincipalClientId => Convert.ToString(ConfigurationManager.AppSettings["ServicePrincipalClientId"], CultureInfo.InvariantCulture);

        public static string ServicePrincipalPassword => Convert.ToString(ConfigurationManager.AppSettings["ServicePrincipalPassword"], CultureInfo.InvariantCulture);

        public static string TenantId => Convert.ToString(ConfigurationManager.AppSettings["TenantId"], CultureInfo.InvariantCulture);

        public static IKeyVaultManager KeyVaultManager
        {
            get
            {
                if (keyVaultManager == null)
                {
                    keyVaultManager = new KeyVaultManager();
                }

                return keyVaultManager;
            }
        }
    }
}