﻿namespace MDS.Infrastructure.Settings
{
    public interface IClientAppSettings
    {
        string ClientBaseUrl { get; }
        public string EmailConfirmationPath { get; }
        public string ResetPasswordPath { get; }
    }
}