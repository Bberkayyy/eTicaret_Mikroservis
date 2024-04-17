﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace e_Ticaret.IdentityServer;

public static class Config
{
    public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
    {
        new ApiResource("CatalogResource"){Scopes={"CatalogFullPermission","CatalogReadPermission"}},
        new ApiResource("DiscountResource"){Scopes={"DiscountFullPermission"}},
        new ApiResource("OrderResource"){Scopes={"OrderFullPermission"}},
        new ApiResource("CargoResource"){Scopes={"CargoFullPermission"}},
        new ApiResource("BasketResource"){Scopes={"BasketFullPermission"}},
        new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
    };
    public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Email(),
        new IdentityResources.Profile(),
    };
    public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
    {
        new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
        new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
        new ApiScope("DiscountFullPermission","Full authority for discount operations"),
        new ApiScope("OrderFullPermission","Full authority for order operations"),
        new ApiScope("CargoFullPermission","Full authority for cargo operations"),
        new ApiScope("BasketFullPermission","Full authority for basket operations"),
        new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
    };
    public static IEnumerable<Client> Clients => new Client[]
    {
        new Client
        {
            ClientId="e_TicaretVisitorId",
            ClientName="e_Ticaret Visitor User",
            AllowedGrantTypes=GrantTypes.ClientCredentials,
            ClientSecrets={new Secret("e_ticaretsecret".Sha256())},
            AllowedScopes={ "DiscountFullPermission" }
        },
        new Client
        {
            ClientId="e_TicaretManagerId",
            ClientName="e_Ticaret Manager User",
            AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
            ClientSecrets={new Secret("e_ticaretsecret".Sha256())},
            AllowedScopes={ "CatalogFullPermission" }
        },
        new Client
        {
            ClientId="e_TicaretAdminId",
            ClientName="e_Ticaret Admin User",
            AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
            ClientSecrets={new Secret("e_ticaretsecret".Sha256())},
            AllowedScopes={ "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission","CatalogReadPermission","CargoFullPermission","BasketFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile },
            AccessTokenLifetime=600
        }
    };
}