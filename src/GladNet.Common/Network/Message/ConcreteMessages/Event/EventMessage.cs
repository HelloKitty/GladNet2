﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladNet.Common
{
	/// <summary>
	/// <see cref="EventMessage"/>s are <see cref="NetworkMessage"/>s that are unexpected responses to network events.
	/// Generally these are messages that are the result of other-client/server state changes that require 'unexpected' network messages
	/// to sync.
	/// </summary>
	public class EventMessage : NetworkMessage, IEventMessage
	{
		/// <summary>
		/// Constructor for <see cref="EventMessage"/> that calls <see cref="NetworkMessage"/>.ctor
		/// </summary>
		/// <param name="payload"><see cref="PacketPayload"/> of the <see cref="NetworkMessage"/>.</param>
		public EventMessage(PacketPayload payload)
			: base(payload)
		{

		}

		/// <summary>
		/// Dispatches the <see cref="EventMessage"/> (this) to the supplied <see cref="INetworkMessageReceiver"/>.
		/// </summary>
		/// <param name="receiver">The target <see cref="INetworkMessageReceiver"/>.</param>
		/// <exception cref="ArgumentNullException">Throws if either parameters are null.</exception>
		/// <param name="mParams">The <see cref="IMessageParameters"/> of the <see cref="EventMessage"/>.</param>
		public override void Dispatch(INetworkMessageReceiver receiver, IMessageParameters mParams)
		{
#if DEBUG || DEBUGBUILD
			if(receiver == null)
				throw new ArgumentNullException("receiver", typeof(INetworkMessageReceiver).ToString() + " parameter is null in " + GetType().ToString());

			if(mParams == null)
				throw new ArgumentNullException("mParams", typeof(IMessageParameters).ToString() + " parameter is null in " + GetType().ToString());
#endif

			receiver.OnNetworkMessageRecieve(this, mParams);
		}
	}
}
