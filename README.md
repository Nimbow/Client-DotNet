# Nimbow .NET Client

This is the official C#/.NET client for the Nimbow API (http://www.nimbow.com).

You find the complete API documentation here: https://www.nimbow.com/sms-api/nimbow-api/

##Usage Example

```C#
await Sms
	.CreateText()
	.From("MyApp")
	.To("+4917123456789")
	.Text("Hello World!")
	.SendAsync();
```