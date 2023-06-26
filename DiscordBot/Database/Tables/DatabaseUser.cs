﻿using Newtonsoft.Json;

namespace DiscordBot.Database.Tables;

public class DatabaseUser
{
    [JsonProperty] public ulong userid;
    [JsonProperty] public bool aram;
    [JsonProperty] public int bosskillcount;
    [JsonProperty] public ulong bosstotaldamage;
    [JsonProperty] public int gold;
    [JsonProperty] public int combatcount;
    [JsonProperty] public int equipvalue;
}