# Nimbow .NET Client

This is the official C#/.NET client for the Nimbow API (http://www.nimbow.com).

You find the complete API documentation here: https://www.nimbow.com/sms-api/nimbow-api/

## Usage

1. Get a free Nimbow account
	1. Register: https://portal.nimbow.com/registration
	2. Grab your API Key: https://portal.nimbow.com/apisettings

2. Add the client to your project (e.g. via NuGet)
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
	```C#
	await Sms
		.CreateText()
		.From("MyApp")
		.To("+4917123456789")
		.Text("Hello World!")
		.SendAsync();
	```

## Usage with IoC container or UnitTest frameworks
You can also use the interface _INimbowApiClientAsync_ and the corresponding implementation _NimbowApiClientAsync_.
This allows you to integrate the Nimbow API client into your favourite IoC framework.
And you can easily mock any dependency to _INimbowApiClientAsync_ in your UnitTests.

## Notes
_Missing API calls and a synchronous client will be added soon!_
