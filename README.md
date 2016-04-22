[![Build Status](https://build.terradue.com/buildStatus/icon?job=DotNet4One)](https://build.terradue.com/job/DotNet4One/)

# DotNet4One - .Net Library to Access XML-RPC API of Opennebula 

DotNet4One (Terradue.OpenNebula) is a library targeting .NET 4.0 and above providing an easy way to perform requests on any XML-RPC method exposed by an OpenNebula server.

XML-RPC API documentation: http://docs.opennebula.org/4.6/integration/system_interfaces/api.html

## Usage examples

```c#
// First create the client
string proxyUrl = "<YOUR_SERVER_URL>"; //XML-RPC url, e,g http://localhost:2633/RPC2
string adminUser = "<YOUR_ADMIN_USERNAME>"; //should be user with driver server_* to allow requests delegation
string adminPwd = "<YOUR_ADMIN_PASSWORD>"; //SHA1 password
var one = new OneClient(proxyUrl,adminUser,adminPwd);

// Do a request as admin
USER_POOL pool = one.UserGetPoolInfo();

// Do a request on behalf of a normal user
string targetUser = "<YOUR_TARGET_USERNAME>";
one.StartDelegate(targetUser);
int RemoteId = one.TemplateInstanciateVM(idTemplate, vmName, false, "");
one.EndDelegate();
```

## Supported Platforms

* .NET 4.0 (Desktop / Server)
* Xamarin.iOS / Xamarin.Android / Xamarin.Mac
* Mono 2.10+

## Getting Started

Terradue.OpenNebula is available as [NuGet package](https://www.nuget.org/packages/Terradue.OpenNebula) in releases

```
Install-Package Terradue.OpenNebula
```

## Build

Terradue.OpenNebula is a single assembly designed to be easily deployed anywhere. 

To compile it yourself, you’ll need:

* Visual Studio 2012 or later, or Xamarin Studio

To clone it locally click the "Clone in Desktop" button above or run the 
following git commands.

```
git clone git@github.com:Terradue/Terradue.OpenNebula.git Terradue.OpenNebula
```

## TODO

* Following commands are missing
  * one.acl.*
  * one.vmpool.accounting
  * one.document.*
  * one.documentpool.info
* Testing!

## Copyright and License

Copyright (c) 2014 Terradue

Licensed under the [GPL v3 License](https://github.com/Terradue/DotNet4One/blob/master/LICENSE)

## Thanks

This library is inspired from [OpenNebula-CSharp-Adapter](https://github.com/Neuralab/OpenNebula-CSharp-Adapter) and uses the excellent .NET framework [xml-rpc.net](http://xml-rpc.net).

## Questions, bugs, and suggestions

Please file any bugs or questions as [issues](https://github.com/Terradue/DotNet4One/issues/new) 

## Want to contribute?

Fork the repository [here](https://github.com/Terradue/DotNet4One/fork) and send us pull requests.
