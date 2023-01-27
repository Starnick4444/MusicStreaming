using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingServer.Network;
public class PacketReader : BinaryReader
{
	public PacketReader(byte[] data)
		: base(new MemoryStream(data))
	{
		
	}

	//read naudio stream
}
