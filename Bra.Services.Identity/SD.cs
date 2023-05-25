using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Bra.Services.Identity
{
    public class SD
    {
        public const string Admin = "Admin";
        public const string Customer = "Costumer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("bra", "Bra server"),
                new ApiScope(name: "read", displayName: "Read sua data"),
                new ApiScope(name: "write", displayName: "Write sua data"),
                new ApiScope(name: "delete", displayName: "Delete sua data")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes= {"read", "write","profile"}
                },
                new Client
                {
                    ClientId = "bra",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"https://localhost:7048/signin-oidc"},
                    PostLogoutRedirectUris = {"https://localhost:7048/signout-callback-oidc" },
                    AllowedScopes= new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "bra"
                    }
                },
            };

       
    }
}
