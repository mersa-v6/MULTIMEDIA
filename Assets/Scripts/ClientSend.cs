using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    private static void SendUDPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);
    }

    #region Packets
    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            string name = LoginScript.playerName;
            _packet.Write(Client.instance.myId);
            //_packet.Write("TEST");
            _packet.Write(name);

            SendTCPData(_packet);
        }
    }

    public static void UDPTestReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.updTestReceived))
        {
            _packet.Write("I am a client powered by UDP");

            SendUDPData(_packet);
        }
    }

    public static void UdpMyPlayerMoved(Vector3 _position)
    {
        using (Packet _packet = new Packet((int)ClientPackets.udpPlayerMovement))
        {
            //_packet.Write("I MOVED");
            _packet.Write(_position.x);
            _packet.Write(_position.y);
            _packet.Write(_position.z);

            SendUDPData(_packet);
        }

    }
    #endregion
}
