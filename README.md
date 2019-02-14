# Cachet.NET
C# client library for the open-source Cachet status page system.

Rewritten library from https://github.com/BerkanYildiz/Cachet.NET

Added all write/update/delete operations of Cachet 2.4.0-dev version
Added Newtownsoft.Json as a serializer.

Covers 95% of Cachet API 

# Example

```csharp
using Cachet.NET;

var Cachet = new Cachet("https://demo.cachethq.io/api/v1/", "aegrHARGrgsfhryae"); // Token
var Cachet = new Cachet("https://demo.cachethq.io/api/v1/", "demo@cachethq.io", "password"); // Account

var ComponentsResult = Cachet.GetComponents();
var ComponentsResult = await Cachet.GetComponentsAsync();

foreach (var Component in ComponentsResult.Components)
{
    // Component.Id
    // Component.Name
    // Component.Status
    // Component.Tags
    // ...
}

bool isPingValid  = Cachet.Ping();
bool isPingValid  = await Cachet.PingAsync();

string CachetVer  = Cachet.GetVersion();
string CachetVer  = await Cachet.GetVersion();

if (CachetVersion.Meta.OnLatest)
{
    Console.WriteLine("Cachet is up to date!");
}
```

# Licence
This work is licensed under the MIT License.
