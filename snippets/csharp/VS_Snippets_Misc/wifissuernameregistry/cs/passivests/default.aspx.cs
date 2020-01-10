﻿//-----------------------------------------------------------------------------
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
//
//-----------------------------------------------------------------------------

using System;
using System.IdentityModel.Services;
using System.Security.Claims;

namespace PassiveSTS
{
    /// <summary>
    /// The Default Page Class
    /// </summary>
    public partial class _Default : System.Web.UI.Page
    {
        /// <summary>
        /// We perform the WS-Federation Passive Protocol processing in this method. 
        /// </summary>
        protected void Page_PreRender( object sender, EventArgs e )
        {
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(User);
            FederatedPassiveSecurityTokenServiceOperations.ProcessRequest(Request, claimsPrincipal, MySecurityTokenServiceConfiguration.Current.CreateSecurityTokenService(), Response);
        }
    }
}
