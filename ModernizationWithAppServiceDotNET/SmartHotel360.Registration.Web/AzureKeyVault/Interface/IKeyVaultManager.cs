// <copyright file="IKeyVaultManager.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace SmartHotel.Registration.AzureKeyVault.Interface
{
    public interface IKeyVaultManager
    {
        string GetSecretValue(string secretName);
    }
}