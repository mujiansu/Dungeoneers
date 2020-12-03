using Steamworks;
using UnityEngine;
using Zenject;

public class NetworkingManager : ITickable
{

    private LobbyManager _lobbyManager;
    public SignalBus SignalBus;

    public class PacketSignal<T>
    {
        public CSteamID Sender { get; set; }
        public T Packet { get; set; }
    }


    public NetworkingManager(SignalBus signalBus, LobbyManager lobbyManager)
    {
        SignalBus = signalBus;
        SteamHelpers.RegisterCallback<P2PSessionRequest_t>(OnP2PSessionRequest);
        SteamHelpers.RegisterCallback<P2PSessionConnectFail_t>(OnP2PSessionFailed);
        _lobbyManager = lobbyManager;
    }

    private void OnP2PSessionFailed(P2PSessionConnectFail_t param)
    {
        Debug.LogError($"P2P session failed. Error Code: {param.m_eP2PSessionError}");
        if (param.m_steamIDRemote == _lobbyManager.Lobby.Owner)
        {
            _lobbyManager.LeaveLobby();
        }
    }

    private void OnP2PSessionRequest(P2PSessionRequest_t param)
    {
        if (_lobbyManager.Lobby.Members.Contains(param.m_steamIDRemote))
        {
            SteamNetworking.AcceptP2PSessionWithUser(param.m_steamIDRemote);
        }
    }

    public void CloseP2PSessionWithUser(CSteamID memberId)
    {
        SteamNetworking.CloseP2PSessionWithUser(memberId);
    }

    public void SendPacketToAllPlayers<T>(T data, PacketChannel channel, EP2PSend protocol = EP2PSend.k_EP2PSendUnreliable)
    {
        foreach (var member in _lobbyManager.Lobby.Members)
        {
            SendPacketToPlayer(member, data, channel, protocol);
        }
    }

    public void SendPacketToPlayer<T>(CSteamID member, T data, PacketChannel channel, EP2PSend protocol = EP2PSend.k_EP2PSendUnreliable)
    {
        if (member != SteamHelpers.Me) SteamHelpers.SendPacket(member, data, channel, protocol);
    }

    public void SendPacketToHost<T>(T data, PacketChannel channel, EP2PSend protocol = EP2PSend.k_EP2PSendUnreliable)
    {
        if (_lobbyManager.Lobby.IsOwnerMe) SendPacketToPlayer(_lobbyManager.Lobby.Owner, data, channel, protocol);
    }

    public void Tick()
    {
        while (SteamHelpers.GetPacket(out string test, out var memberId, PacketChannel.Test))
        {
            SignalBus.Fire<PacketSignal<string>>(new PacketSignal<string>
            {
                Sender = memberId,
                Packet = test
            });
        }
    }
}


public enum PacketChannel
{
    Test
}
