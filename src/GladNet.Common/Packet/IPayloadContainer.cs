﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladNet.Common.Packet
{
	public interface IPayloadContainer
	{
		bool isAvailable { get; }

		PacketPayload Payload { get; }

		IPayloadContainer Encrypt(IEncryptor encryptor);

		bool Decrypt(IDecryptor decryptor);
	}
}
