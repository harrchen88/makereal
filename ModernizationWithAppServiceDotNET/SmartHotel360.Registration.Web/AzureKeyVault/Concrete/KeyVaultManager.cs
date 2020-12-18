// <copyright file="KeyVaultManager.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace SmartHotel.Registration.AzureKeyVault.Concrete
{
    using Microsoft.Azure.KeyVault;
    using Microsoft.Azure.Services.AppAuthentication;
    using SmartHotel.Registration.AzureKeyVault.Interface;
    using SmartHotel.Registration.Configuration;

    public class KeyVaultManager: IKeyVaultManager
    {
        private KeyVaultClient keyVaultClient;

        public KeyVaultManager()
        {
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider($"RunAs=App;AppId={ConfigurationHelper.ServicePrincipalClientId}"
                + $";TenantId={ConfigurationHelper.TenantId};AppKey={ConfigurationHelper.ServicePrincipalPassword}");

            this.keyVaultClient = new KeyVaultClient(
            new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
        }

        public string GetSecretValue(string secretName)
        {
            var vaultAddress = ConfigurationHelper.KeyVaultUri;

            var secret = keyVaultClient.GetSecretAsync(vaultAddress, secretName).GetAwaiter().GetResult();

            return secret.Value;
        }
    }
}
