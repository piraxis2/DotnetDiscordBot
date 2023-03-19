﻿
using Newtonsoft.Json;

namespace DiscordBot;

[JsonObject(MemberSerialization.OptIn)]
public class Config
{
    public Config(string token, string hostname, string authorization, ushort port, string locale, string prefix, string openAIAPIKey)
    {
        Token = token;
        Hostname = hostname;
        Authorization = authorization;
        Port = port;
        Locale = locale;
        Prefix = prefix;
        OpenAIAPIKey = openAIAPIKey;
    }

    [JsonProperty] public string Token { get; set; }
    [JsonProperty] public string Hostname{ get; set; }
    [JsonProperty] public string Authorization{ get; set; }
    [JsonProperty] public ushort Port{ get; set; }
    [JsonProperty] public string Locale{ get; set; }
    [JsonProperty] public string Prefix{ get; set; }
    [JsonProperty] public string OpenAIAPIKey{ get; set; }
}