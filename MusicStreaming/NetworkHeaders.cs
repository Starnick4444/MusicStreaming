using MusicStreamingServer.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingServer;

public enum NetworkHeaders : ushort
{
    Request
}

public enum NetworkRequestHeaders : ushort
{

}


//EXAMPLE DELETE LATER
//PacketWriter pw = new PacketWriter();
//pw.Write((ushort) NetworkHeaders.Request);
//        PacketReader pr = new PacketReader(pw.GetBytes());
//pr.ReadInt16();