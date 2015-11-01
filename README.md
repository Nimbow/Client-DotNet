# Nimbow .NET Client

This is the official C#/.NET client for the Nimbow API (http://www.nimbow.com).
You find the complete API documentation here: https://www.nimbow.com/sms-api/nimbow-api/

##Usage Example

```C#
await Sms
&nbsp;&nbsp;&nbsp;&nbsp;.CreateText()
&nbsp;&nbsp;&nbsp;&nbsp;.From("MyApp")
&nbsp;&nbsp;&nbsp;&nbsp;.To("+4917123456789")
&nbsp;&nbsp;&nbsp;&nbsp;.Text("Hello World!")
&nbsp;&nbsp;&nbsp;&nbsp;.SendAsync();