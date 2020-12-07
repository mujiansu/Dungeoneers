using System;
using System.Collections.Generic;
using Dungeoneer.Netowrking.Packets;
using Dungeoneer.Steamworks;
using Steamworks;
using UnityEngine;
using Zenject;

namespace Dungeoneer.Managers
{
    public class NetworkingManager : ITickable
    {

        private LobbyManager _lobbyManager;
        private SignalBus _signalBus;

        private Dictionary<Type, PacketChannel> _packetDictionary = new Dictionary<Type, PacketChannel>();

        public class PacketSignal<T>
        {
            public CSteamID Sender { get; set; }
            public T Data { get; set; }
        }

        [Inject]
        public void Constructor(SignalBus signalBus, LobbyManager lobbyManager)
        {
            _signalBus = signalBus;
            SteamHelpers.RegisterCallback<P2PSessionRequest_t>(OnP2PSessionRequest);
            SteamHelpers.RegisterCallback<P2PSessionConnectFail_t>(OnP2PSessionFailed);
            _lobbyManager = lobbyManager;
            _packetDictionary.Add(typeof(CharacterPacket), PacketChannel.Test);
            _packetDictionary.Add(typeof(SceneChangePacket), PacketChannel.SceneChange);
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

        public void SendPacketToAllPlayers<T>(T data, EP2PSend protocol = EP2PSend.k_EP2PSendUnreliable)
        {
            foreach (var member in _lobbyManager.Lobby.Members)
            {
                SendPacketToPlayer(member, data, protocol);
            }
        }

        public void SendPacketToPlayer<T>(CSteamID member, T data, EP2PSend protocol = EP2PSend.k_EP2PSendUnreliable)
        {
            if (member != SteamHelpers.Me) SteamHelpers.SendPacket(member, data, _packetDictionary[typeof(T)], protocol);
        }

        public void SendPacketToHost<T>(T data, EP2PSend protocol = EP2PSend.k_EP2PSendUnreliable)
        {
            if (_lobbyManager.Lobby.IsOwnerMe) SendPacketToPlayer(_lobbyManager.Lobby.Owner, data, protocol);
        }

        public void Tick()
        {

            while (RetrievePacket<CharacterPacket>()) { }
            while (RetrievePacket<SceneChangePacket>()) { }
        }

        private bool RetrievePacket<T>()
        {
            var result = SteamHelpers.GetPacket(out T packet, out var memberId, _packetDictionary[typeof(T)]);
            if (result)
            {
                _signalBus.Fire<PacketSignal<T>>(new PacketSignal<T>
                {
                    Sender = memberId,
                    Data = packet
                });
            }
            return result;
        }
    }


    public enum PacketChannel
    {
        SceneChange,
        Test
    }

}
