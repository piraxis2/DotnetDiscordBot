﻿using System.Data;
using DisCatSharp.CommandsNext;
using DisCatSharp.Entities;
using MySqlConnector;
using Newtonsoft.Json;

namespace DiscordBot.Database;

public partial class DiscordBotDatabase
{
    public async Task<List<DatabaseUser>> GetDatabaseUsers(CommandContext ctx)
    {
        return await GetDatabaseUsers(ctx.Guild);
    }
    
    public async Task<List<DatabaseUser>> GetDatabaseUsers(DiscordGuild guild)
    {
        if (!await OpenASync()) return new List<DatabaseUser>();
        MySqlCommand command = _connection.CreateCommand();
        command.CommandText = $"select userid FROM USER where {guild.Id}";

        MySqlDataReader? rdr = null;
        Monitor.Enter(_lockObject);
        try
        {
            rdr = await command.ExecuteReaderAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            Monitor.Exit(_lockObject);
        }

        DataTable dataTable = new DataTable();
        if (rdr != null) dataTable.Load(rdr);
        string jsonString = JsonConvert.SerializeObject(dataTable);
        List<DatabaseUser>? users = JsonConvert.DeserializeObject<List<DatabaseUser>>(jsonString);
        return users ?? new List<DatabaseUser>();

    }

    public async Task<bool> UserRegister(CommandContext ctx)
    {
        return await UserRegister(ctx.Guild, ctx.User);
    }
    
    public async Task<bool> UserRegister(DiscordGuild guild, DiscordUser user)
    {
        if (!await OpenASync()) return false;

        MySqlCommand command = _connection.CreateCommand();
        command.CommandText = @"insert into USER (id, guildid, userid) values (@id, @guildid, @userid)";
        command.Parameters.AddWithValue("@id", GetSHA256(guild, user));
        command.Parameters.AddWithValue("@guildid", guild.Id);
        command.Parameters.AddWithValue("@userid", user.Id);

        bool result = false;
        Monitor.Enter(_lockObject);
        try
        {
            result = await command.ExecuteNonQueryAsync() == 1;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            Monitor.Exit(_lockObject);
        }

        return result;
    }
    
    public async Task<bool> UserDelete(CommandContext ctx)
    {
        return await UserDelete(ctx.Guild, ctx.User);
    }

    public async Task<bool> UserDelete(DiscordGuild guild, DiscordUser user)
    {
        if (!await OpenASync()) return false;
        
        // ReSharper disable once StringLiteralTypo
        MySqlCommand command = _connection.CreateCommand();
        command.CommandText = @"delete from USER where id=@id";
        command.Parameters.AddWithValue("@id", GetSHA256(guild, user));

        bool result = false;
        Monitor.Enter(_lockObject);
        try
        {
            result = await command.ExecuteNonQueryAsync() == 1;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            Monitor.Exit(_lockObject);
        }

        return result;
    }
    
}