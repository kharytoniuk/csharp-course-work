using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace ExplorerDesktop;

public class GoogleAuth
{
    public const string ApplicationName = "ExplorerDesktop";
    public const string CredentialsPath = "credentials.json";
    public const string TokenPath = "token.json";
        
    public static readonly string[] Scopes = { DriveService.Scope.DriveReadonly };

    private readonly GoogleServiceStore _store;
    
    public GoogleAuth(GoogleServiceStore store)
    {
        _store = store;
        
        using var stream = new FileStream(CredentialsPath, FileMode.Open, FileAccess.Read);

        UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.FromStream(stream).Secrets,
            Scopes,
            "user",
            CancellationToken.None,
            new FileDataStore(TokenPath, true)).Result;

        _store.DriveService = new DriveService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName
        });
    }
}