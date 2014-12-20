DreamHost API for .NET
======================

A .NET library for accessing the [DreamHost API][api].

This library was developed to allow me to use the DreamHost API to manage my DNS
records using my [DNS Manager][dnsmanager], but I also tried to expand it to
include the various other requests that exist in the API (for use by other 
people/apps).

It is written in C# and is able to be used from any language that runs on the 
.NET Framework. It is likely to be incomplete, so if there's a particular
request that's missing feel free to send me a pull request (or create an issue
and I may get round to it eventually).

Mono Compatibility
------------------

This library has previously been tested with Mono and there will probably be 
connection issues as Mono does not trust anybody by default. More information 
can be found [here][monosecurity].

[api]: http://wiki.dreamhost.com/API
[dnsmanager]: http://software.clempaul.me.uk/apps/dreamhostdns/
[monosecurity]: http://www.mono-project.com/docs/faq/security/
