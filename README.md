# Birdhouse
Birdhouse is a .NET Portable Class Library which provides a convenient wrapper around the Nest REST API which is used for interacting with Nest thermostats and smoke detectors.

## Getting Started
Birdhouse uses the Nest REST API. That means before you can use it you need to first register a client over at the [Nest developer site](http://developer.nest.com). Nest uses *OAuth 2.0* to authenticate user requests. The Birdhouse library uses an *access token* which is received by the client after successfully negotiating the protocol. How you work with OAuth 2.0 will depend on what target platform you are working and isn't implemented by Birdhouse. That said, it is pretty simple, so here is a quick overview on how to get started (you can read more in the [Nest developer documentation](https://developer.nest.com/documentation/cloud/how-to-auth).

The first step is the client application redirecting to Nest's authorization endpoint with an application specific client ID. You can get the client ID by [registering your client at the Nest developer site](https://developer.nest.com/clients). Once you've got that your client needs to redirect to the following URL.

    https://home.nest.com/login/oauth2?client_id=YOUR_CLIENT_ID&state=STATE
  
This results in an *authorization code* being returned. The Nest REST API currently returns this code in one of two ways depending on how you've registered your client. If you are building a web-application then you specify a return URL to receive this code, if you are building a mobile application you can opt not to provide a return URL, and instead extract a *pin-code* (the equivalent of an *authorization code*) from HTML DOM in an embedded web-browser within your application. Some platforms like Windows 8.x, Windows Phone 8.1 or higher have built in support for this flow. You might like to check out the [WebAuthenticationBroker class](https://msdn.microsoft.com/en-us/library/windows/apps/windows.security.authentication.web.webauthenticationbroker.aspx). If you are using Xamarin to target iOS and Android then [Xamarin.Auth might be useful](http://components.xamarin.com/view/xamarin.auth/).

The *authorization code* can then be exchanged for an *access token*. By sending the *authorization code* that you just received, along with your *client ID* and *client secret* to the following URL.

    https://api.home.nest.com/oauth2/access_token?code=AUTHORIZATION_CODE&client_id=YOUR_CLIENT_ID&client_secret=YOUR_CLIENT_SECRET&grant_type=authorization_code

The response to this request will contain a JSON result that looks something like the following.

```javascript
{
"access_token": "c.FmDPkzyzaQe...",
"expires_in": 315569260
}
```

You are after the *access token*. Most applications will store this in some kind durable way so that they can make subsequent requests without requiring user authorization. Note that you can ignore the expiry for now, from my research it doesn't appear that the Nest REST API supports another *OAuth 2.0* concept of *refresh tokens* where a client can request a new *access token*.

Now that you have the *access token* you are ready to go ahead and use the Birdhouse library. Just install the Birdhouse library via NuGet.

```powershell
Install-Package Birdhouse
```

The central class in the library is the ```NestClient```. All you have to do is construct an instance of this class, passing in the *access token* and you can start getting data back from your nest.

```csharp
var client = new NestClient(accessToken);
var thermostats = await client.GetThermostatsAsync();
```

As you can see the library is built around async principals so anything that makes a request to the server is implemented as an async method. If you want to get a specific thermostat and set its temperature you might use something like the following.

```csharp
var client = new NestClient(accessToken);
var thermostat = await client.GetNestThermostat(thermostatID);
await thermostat.UpdateTargetTemperatureAsync(21, TemperatureScale.Celsius);
```

The library current applies the changes to entities (thermostats, smoke detectors, and structures) after a successful request, however it doesn't support the streaming API so updates from other clients won't be reflected in this release. See the **Futures** section below for what I am planning to add down the track.

That pretty much covers how to use the library. Hope it works for you and if you encounter any problems then [log an issue](https://github.com/mitchdenny/birdhouse/issues) or submit a pull request.

## Futures
The current 1.0.0 release of the Birdhouse library is functionally complete. However I am planning future enhancements.

- **Event Streaming**; support for receiving updates from the server so that updates from the thermostat can be represented without having to make another request (necessarily).
- **INotifyPropertyChanged**; support so that clients that support data-binding can take advantage of updates coming back from the server.
- **Samples and Documentation**; to be progressively added so folks know how to use the library with practical examples for various platforms.

## Contributing
All contributors are welcome. If you want to contribute the best way is to raise an issue for what you are working on so I've got some visibility, and then fork the code base and do your implementation. You can then do a pull request to land your code in this library.

![](https://mitchdenny.visualstudio.com/DefaultCollection/_apis/public/build/definitions/23bb555d-4b71-4a32-b9d0-37075e19cbfc/16/badge)
