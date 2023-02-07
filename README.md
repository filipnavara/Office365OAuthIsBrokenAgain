# Test application showing the Office 365 OAuth2 SMTP.Send permission is broken

Usage:
- Run the app with `dotnet run`
- Login with Outlook.com / Hotmail consumer account
- Observe that the authentication to SMTP server fails

Expected result: Message box with "Success"

Actual result: SMTP authentication error (eg. "535: 5.7.3. Authentication unsuccessful")


Corporate account pass the test successfully.
