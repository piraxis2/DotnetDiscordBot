// This file is part of the DisCatSharp project, based off DSharpPlus.
//
// Copyright (c) 2021-2023 AITSYS
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;

using DisCatSharp.Enums;

using Newtonsoft.Json;

namespace DisCatSharp.Entities;

/// <summary>
/// Represents a parameter for a <see cref="DiscordApplicationCommand"/>.
/// </summary>
public sealed class DiscordApplicationCommandOption
{
	/// <summary>
	/// Gets the type of this command parameter.
	/// </summary>
	[JsonProperty("type")]
	public ApplicationCommandOptionType Type { get; internal set; }

	/// <summary>
	/// Gets the name of this command parameter.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; internal set; }

	/// <summary>
	/// Sets the name localizations.
	/// </summary>
	[JsonProperty("name_localizations", NullValueHandling = NullValueHandling.Ignore)]
	internal Dictionary<string, string> RawNameLocalizations { get; set; }

	/// <summary>
	/// Gets the name localizations.
	/// </summary>
	[JsonIgnore]
	public DiscordApplicationCommandLocalization NameLocalizations
		=> new(this.RawNameLocalizations);

	/// <summary>
	/// Gets the description of this command parameter.
	/// </summary>
	[JsonProperty("description")]
	public string Description { get; internal set; }

	/// <summary>
	/// Sets the description localizations.
	/// </summary>
	[JsonProperty("description_localizations", NullValueHandling = NullValueHandling.Ignore)]
	internal Dictionary<string, string> RawDescriptionLocalizations { get; set; }

	/// <summary>
	/// Gets the description localizations.
	/// </summary>
	[JsonIgnore]
	public DiscordApplicationCommandLocalization DescriptionLocalizations
		=> new(this.RawDescriptionLocalizations);

	/// <summary>
	/// Gets whether this command parameter is required.
	/// </summary>
	[JsonProperty("required", NullValueHandling = NullValueHandling.Ignore)]
	public bool Required { get; internal set; } = false;

	/// <summary>
	/// Gets the optional choices for this command parameter.
	/// Not applicable for auto-complete options.
	/// </summary>
	[JsonProperty("choices", NullValueHandling = NullValueHandling.Ignore)]
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
	public List<DiscordApplicationCommandOptionChoice>? Choices { get; internal set; } = null;
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

	/// <summary>
	/// Gets the optional subcommand parameters for this parameter.
	/// </summary>
	[JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
	public List<DiscordApplicationCommandOption>? Options { get; internal set; } = null;
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

	/// <summary>
	/// Gets the optional allowed channel types.
	/// </summary>
	[JsonProperty("channel_types", NullValueHandling = NullValueHandling.Ignore)]
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
	public List<ChannelType>? ChannelTypes { get; internal set; } = null;
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

	/// <summary>
	/// Gets whether this option provides autocompletion.
	/// </summary>
	[JsonProperty("autocomplete", NullValueHandling = NullValueHandling.Ignore)]
	public bool AutoComplete { get; internal set; } = false;

	/// <summary>
	/// Gets the minimum value for this slash command parameter.
	/// </summary>
	[JsonProperty("min_value", NullValueHandling = NullValueHandling.Ignore)]
	public object MinimumValue { get; internal set; }

	/// <summary>
	/// Gets the maximum value for this slash command parameter.
	/// </summary>
	[JsonProperty("max_value", NullValueHandling = NullValueHandling.Ignore)]
	public object MaximumValue { get; internal set; }

	/// <summary>
	/// Gets the maximum length for this slash command parameter.
	/// </summary>
	[JsonProperty("min_length", NullValueHandling = NullValueHandling.Ignore)]
	public int? MinimumLength { get; internal set; }

	/// <summary>
	/// Gets the minimum length for this slash command parameter.
	/// </summary>
	[JsonProperty("max_length", NullValueHandling = NullValueHandling.Ignore)]
	public int? MaximumLength { get; internal set; }

	/// <summary>
	/// Creates a new instance of a <see cref="DiscordApplicationCommandOption"/>.
	/// </summary>
	/// <param name="name">The name of this parameter.</param>
	/// <param name="description">The description of the parameter.</param>
	/// <param name="type">The type of this parameter.</param>
	/// <param name="required">Whether the parameter is required.</param>
	/// <param name="choices">The optional choice selection for this parameter.</param>
	/// <param name="options">The optional subcommands for this parameter.</param>
	/// <param name="channelTypes">If the option is a channel type, the channels shown will be restricted to these types.</param>
	/// <param name="autocomplete">Whether this option provides autocompletion.</param>
	/// <param name="minimumValue">The minimum value for this parameter. Only valid for types <see cref="ApplicationCommandOptionType.Integer"/> or <see cref="ApplicationCommandOptionType.Number"/>.</param>
	/// <param name="maximumValue">The maximum value for this parameter. Only valid for types <see cref="ApplicationCommandOptionType.Integer"/> or <see cref="ApplicationCommandOptionType.Number"/>.</param>
	/// <param name="nameLocalizations">The localizations of the parameter name.</param>
	/// <param name="descriptionLocalizations">The localizations of the parameter description.</param>
	/// <param name="minimumLength">The minimum allowed length of the string. (Min 0)</param>
	/// <param name="maximumLength">The maximum allowed length of the string. (Min 1)</param>
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
	public DiscordApplicationCommandOption(string name, string description, ApplicationCommandOptionType type, bool required = false, IEnumerable<DiscordApplicationCommandOptionChoice>? choices = null, IEnumerable<DiscordApplicationCommandOption>? options = null, IEnumerable<ChannelType>? channelTypes = null, bool autocomplete = false, object minimumValue = null, object maximumValue = null, DiscordApplicationCommandLocalization nameLocalizations = null, DiscordApplicationCommandLocalization descriptionLocalizations = null, int? minimumLength = null, int? maximumLength = null)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
	{
		if (!Utilities.IsValidSlashCommandName(name))
			throw new ArgumentException("Invalid application command option name specified. It must be below 32 characters and not contain any whitespace.", nameof(name));
		if (name.Any(char.IsUpper))
			throw new ArgumentException("Application command option name cannot have any upper case characters.", nameof(name));
		if (description.Length > 100)
			throw new ArgumentException("Application command option description cannot exceed 100 characters.", nameof(description));
		if (autocomplete && (choices?.Any() ?? false))
			throw new InvalidOperationException("Auto-complete slash command options cannot provide choices.");
		if (type == ApplicationCommandOptionType.SubCommand || type == ApplicationCommandOptionType.SubCommandGroup)
			if (string.IsNullOrWhiteSpace(description))
				throw new ArgumentException("Slash commands need a description.", nameof(description));

		this.Name = name;
		this.Description = description;
		this.Type = type;
		this.Required = required;
		this.Choices = choices != null && choices.Any() ? choices.ToList() : null;
		this.Options = options != null && options.Any() ? options.ToList() : null;
		this.ChannelTypes = channelTypes != null && channelTypes.Any() ? channelTypes.ToList() : null;
		this.AutoComplete = autocomplete;
		this.MinimumValue = minimumValue;
		this.MaximumValue = maximumValue;
		this.MinimumLength = minimumLength;
		this.MaximumLength = maximumLength;
		this.RawNameLocalizations = nameLocalizations?.GetKeyValuePairs();
		this.RawDescriptionLocalizations = descriptionLocalizations?.GetKeyValuePairs();
	}
}
