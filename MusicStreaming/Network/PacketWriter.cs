using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingServer.Network;
public class PacketWriter : BinaryWriter
{
    private MemoryStream _ms;

	public PacketWriter()
		: base()
	{
		_ms = new MemoryStream();
		OutStream = _ms;
	}

	public byte[] GetBytes()
	{
		Close();

		byte[] data = _ms.ToArray();

		return data;
	}

	//write naudio stream
}
