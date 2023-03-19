﻿using System.Reflection;
using DisCatSharp;
using DisCatSharp.CommandsNext;
using DisCatSharp.CommandsNext.Attributes;
using DisCatSharp.Entities;
using DiscordBot.Resource;
using OpenAI_API;
using OpenAI_API.Chat;

namespace DiscordBot.Commands
{
    public sealed class UtilityModules : BaseCommandModule
    {
        public UtilityModules(DiscordClient client, Config config, OpenAIAPI openAIAPI)
        {
            _client = client;
            _config = config;
            _openAiApi = openAIAPI;
        }

        private readonly DiscordClient _client;
        private readonly Config _config;
        private readonly OpenAIAPI _openAiApi;
        
        [Command, Aliases("h")]
        public async Task Help(CommandContext ctx)
        {
            CommandsNextExtension? commandNext = _client.GetCommandsNext();
            if (commandNext == null)
            {
                return;
            }

            var copyCommands =
                (from pair in commandNext.RegisteredCommands
                    where pair.Key == pair.Value.Name
                    select pair.Value)
                .OrderBy((command => command.Name)).ToList();

            DiscordEmbedBuilder embedBuilder = new DiscordEmbedBuilder();
            embedBuilder.WithColor(DiscordColor.Azure);
            embedBuilder.WithFooter("footer");

            string FindLocal(string name)
            {
                TypeInfo typeinfo = typeof(Localization).GetTypeInfo();
                foreach (PropertyInfo propertyInfo in typeinfo.DeclaredProperties)
                {
                    if (propertyInfo.Name == name && propertyInfo.GetValue(typeinfo) is string)
                    {
                        return (string)propertyInfo.GetValue(typeinfo)!;
                    }
                }

                return "";
            }

            var commandsString = string.Join("\n", copyCommands.Select(x => $"`{x.Name}`{(x.Aliases.Count == 0 ? "" : $"(**{string.Join(", ", x.Aliases.Select((alias => alias)))}**)")}: {FindLocal(x.Name + "_Description")}"));
            embedBuilder.WithDescription(commandsString);
            await ctx.Channel.SendMessageAsync(embedBuilder.Build());
        }

        [Command, Aliases("g")]
        public async Task Gpt(CommandContext ctx, [RemainingText] string chatMessage)
        {
            var result = await _openAiApi.Chat.CreateChatCompletionAsync(new OpenAI_API.Chat.ChatRequest()
            {
                Model = OpenAI_API.Models.Model.ChatGPTTurbo,
                Temperature = 0.1,
                MaxTokens = 2048,
                Messages = new ChatMessage[]
                {
                    new ChatMessage(ChatMessageRole.User, chatMessage)
                }
            });

            var reply = result.Choices[0].Message;
            await ctx.RespondAsync($"{reply.Content.Trim()}");
        }
    }
}