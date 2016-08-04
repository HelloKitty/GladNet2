﻿using GladNet.Engine.Common;
using GladNet.Payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GladNet.Message.Handlers
{
	/// <summary>
	/// Event payload handler service that handles events based on the
	/// strategy provided.
	/// </summary>
	/// <typeparam name="TSessionType">Type of the session</typeparam>
	public class EventPayloadHandlerService<TSessionType> : IEventPayloadHandlerService<TSessionType>
		where TSessionType : INetPeer
	{
		/// <summary>
		/// Strategy for how to handle incoming <see cref="PacketPayload"/>s.
		/// </summary>
		private IPayloadHandlerStrategy<TSessionType> handlerStrat { get; }

		public EventPayloadHandlerService(IPayloadHandlerStrategy<TSessionType> strat)
		{
			handlerStrat = strat;
		}

		/// <summary>
		/// Attempts to handle the <see cref="PacketPayload"/> with static parameters.
		/// </summary>
		/// <param name="payload">Payload instance.</param>
		/// <param name="parameters">Parameters the message was sent with.</param>
		/// <param name="peer">Peer that is involved with the message.</param>
		/// <returns>True if the handler can handle the type of packet.</returns>
		public bool TryProcessPayload(PacketPayload payload, IMessageParameters parameters, TSessionType peer)
		{
			return handlerStrat.TryProcessPayload(payload, parameters, peer);
		}
	}
}
