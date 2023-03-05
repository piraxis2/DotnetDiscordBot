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

namespace DisCatSharp.Enums;

/// <summary>
/// Represents a channel's type.
/// </summary>
public enum ChannelType : int
{
	/// <summary>
	/// Indicates that this is a text channel.
	/// </summary>
	Text = 0,

	/// <summary>
	/// Indicates that this is a private channel.
	/// </summary>
	Private = 1,

	/// <summary>
	/// Indicates that this is a voice channel.
	/// </summary>
	Voice = 2,

	/// <summary>
	/// Indicates that this is a group direct message channel.
	/// </summary>
	Group = 3,

	/// <summary>
	/// Indicates that this is a channel category.
	/// </summary>
	Category = 4,

	/// <summary>
	/// Indicates that this is a news channel.
	/// </summary>
	News = 5,

	/// <summary>
	/// Indicates that this is a store channel.
	/// </summary>
	Store = 6,

	/// <summary>
	/// Indicates that this is a temporary sub-channel within a news channel.
	/// </summary>
	NewsThread = 10,

	/// <summary>
	/// Indicates that this is a temporary sub-channel within a text channel.
	/// </summary>
	PublicThread = 11,

	/// <summary>
	/// Indicates that this is a temporary sub-channel within a text channel that is only viewable
	/// by those invited and those with the MANAGE_THREADS permission.
	/// </summary>
	PrivateThread = 12,

	/// <summary>
	/// Indicates that this is a stage channel.
	/// </summary>
	Stage = 13,

	/// <summary>
	/// Indicates that this is a guild directory channel.
	/// This is used for hub guilds (feature for schools).
	/// </summary>
	GuildDirectory = 14,

	/// <summary>
	/// Indicates that this is a guild forum channel (Threads only channel).
	/// </summary>
	Forum = 15,

	/// <summary>
	/// Indicates unknown channel type.
	/// </summary>
	Unknown = int.MaxValue
}
