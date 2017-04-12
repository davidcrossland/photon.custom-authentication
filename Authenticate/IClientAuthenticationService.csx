﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IClientAuthenticationService.cs" company="Exit Games GmbH">
//   Copyright (c) Exit Games GmbH.  All rights reserved.
// </copyright>
// <summary>
//   Defines the IClientAuthenticationService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

public interface IClientAuthenticationService
{
    bool Authenticate(string userName, string token);
}

