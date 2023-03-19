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

using DisCatSharp.Entities;

namespace DisCatSharp.EventArgs;

/// <summary>
/// Represents arguments for <see cref="DiscordClient.GuildScheduledEventUpdated"/> event.
/// </summary>
public class GuildScheduledEventUpdateEventArgs : DiscordEventArgs
{
	/// <summary>
	/// Gets the scheduled event that was updated.
	/// </summary>
	public DiscordScheduledEvent ScheduledEventAfter { get; internal set; }

	/// <summary>
	/// Gets the old scheduled event that was updated.
	/// </summary>
	public DiscordScheduledEvent ScheduledEventBefore { get; internal set; }

	/// <summary>
	/// Gets the guild in which the scheduled event was updated.
	/// </summary>
	public DiscordGuild Guild { get; internal set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="GuildScheduledEventUpdateEventArgs"/> class.
	/// </summary>
	internal GuildScheduledEventUpdateEventArgs(IServiceProvider provider) : base(provider) { }
}