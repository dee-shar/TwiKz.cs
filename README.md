# TwiKz.cs
Web-API for [twi.kz](https://twi.kz/) website that serves as an url shortening tool

## Example
```cs
using System;
using TwiKzApi;

namespace Application
{
    internal class Program
    {
        static async Task Main()
        {
            var api = new TwiKz();
            string shortUrl = await api.ShortenUrl("https://google.com");
            Console.WriteLine(shortUrl);
        }
    }
}
```
