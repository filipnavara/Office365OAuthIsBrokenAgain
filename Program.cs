using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Identity.Client;
using System.Windows.Forms;

var options = new PublicClientApplicationOptions
{
    ClientId = "e9a7fea1-1cc0-4cd9-a31b-9137ca5deedd",
    RedirectUri = "https://login.microsoftonline.com/common/oauth2/nativeclient"
};
 
var publicClientApplication = PublicClientApplicationBuilder.CreateWithApplicationOptions(options).Build();
var scopes = new[] { "email", "offline_access", "https://outlook.office.com/SMTP.Send" };
var authToken = await publicClientApplication.AcquireTokenInteractive(scopes).WithUseEmbeddedWebView(true).ExecuteAsync();
var oauth2 = new SaslMechanismOAuth2(authToken.Account.Username, authToken.AccessToken);

try
{
    using (var client = new SmtpClient())
    {
        await client.ConnectAsync("outlook.office365.com", 587, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(oauth2);
        await client.DisconnectAsync(true);
    }
    MessageBox.Show("Success");
}
catch (Exception e)
{
    MessageBox.Show(e.Message);
}