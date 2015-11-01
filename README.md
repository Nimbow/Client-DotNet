# Nimbow .NET Client

This is the official C#/.NET client for the Nimbow API (<http://www.nimbow.com>).

You find the complete API documentation here: <https://www.nimbow.com/sms-api/nimbow-api/>

NuGet-Package: <https://www.nuget.org/packages/Nimbow.Api.Client/>

## Usage

1. Get a free Nimbow account
	1. Register: https://portal.nimbow.com/registration
	2. Grab your API Key: https://portal.nimbow.com/apisettings

2. Add the client to your project (e.g. via NuGet Package Manager Console)
	```PowerShell
	Install-Package Nimbow.Api.Client
	```

3. Adjust the configuration (web.config / app.config)
	```XML
    <add key="Nimbow.Api.Url" value="https://api.nimbow.com/" />
    <add key="Nimbow.Api.Key" value="PASTE YOUR API KEY HERE" />
    <!-- 	Optional default sender, 
	    	will be used when you don't specify a sender in your code -->
    <add key="Nimbow.Api.Default.From" value="YourSender" />
	```

4. Start sending SMS
	* asynchronous
	```C#
	await Sms
	    .CreateText()
	    .From("MyApp")
	    .To("+4917123456789")
	    .Text("Hello World!")
	    .SendAsync();
	```
	* synchronous
	```C#
	Sms.CreateText()
	    .From("MyApp")
	    .To("+4917123456789")
	    .Text("Hello World!")
	    .Send();
	```

## Usage with IoC container or UnitTest frameworks
You can also use the interface `INimbowApiClientAsync` (or `INimbowApiClient`) and the corresponding implementation `NimbowApiClientAsync` (or `NimbowApiClient`).
This allows you to integrate the Nimbow API client into your favourite IoC framework.
And you can easily mock any dependency to the Nimbow API client in your UnitTests.

## Notes
*Missing API calls will be added soon!*

## Samples

### ASP.NET MVC integrated Multi-Factor Authentication
*Nimbow.Samples.AspNetMvcMfa.csproj*

This project shows you how easy you can achieve Two-Factor Authentication when you combine the standard ASP.NET MVC project template with the *Nimbow API Client*.

#### Prerequisites
Before you start the example, at first put your API key into the web.config.

You don't have an API Key, yet?

* **No problem**, get a Nimbow account for **free**: <https://portal.nimbow.com/registration>
* After registration copy your API key from here: <https://portal.nimbow.com/apisettings>
```XML
<add key="Nimbow.Api.Key" value="PASTE YOUR API KEY HERE" />
```

#### Try it
1. Start the project
2. Register an account in the sample application
3. Login with that account
4. Click on your account name to navigate to your profile
5. Add a phone number (a verification code will be sent to this number)
6. Enable Two-Factor Authentication
7. Logout
8. Login again with your credentials
9. A verfification code will be sent to your configured phone number
10. Only if you enter correct verfication code, you get logged in

#### Where is the magic?
In the sample project, look in the file *App_Start/IdentityConfig.cs*.
There you find the class `SmsService`. Inside the method `SendAsync` you can see few lines which are required to make it happen.
