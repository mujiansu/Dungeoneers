using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dungeoneer.Steamworks;
using Steamworks;
using UnityEngine;
using Zenject;

namespace Dungeoneer.Managers
{
    public class LobbyManager : IInitializable
    {
        public SteamLobby Lobby { get; private set; }
        public SignalBus _signalBus;
        private const int _maxLobbySize = 10;

        public class MembersUpdateSignal
        {
            public List<CSteamID> Members;
        }

        public class LobbyInviteReceivedSignal
        {
            public LobbyInvite LobbyInvite { get; set; }
        }

        [Inject]
        public void Constructor(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            SteamHelpers.RegisterCallback<LobbyCreated_t>(OnLobbyCreated);
            SteamHelpers.RegisterCallback<LobbyEnter_t>(OnLobbyEntered);
            SteamHelpers.RegisterCallback<LobbyChatUpdate_t>(OnLobbyChatUpdate);
            SteamHelpers.RegisterCallback<GameLobbyJoinRequested_t>(OnLobbyJoinRequested);
            SteamHelpers.RegisterCallback<LobbyInvite_t>(OnLobbyInvite);
            Lobby = new SteamLobby(_signalBus);
        }

        private void OnLobbyInvite(LobbyInvite_t param)
        {
            _signalBus.Fire<LobbyInviteReceivedSignal>(new LobbyInviteReceivedSignal
            {
                LobbyInvite = new LobbyInvite
                {
                    Username = SteamFriends.GetFriendPersonaName((CSteamID)param.m_ulSteamIDUser),
                    LobbyId = (CSteamID)param.m_ulSteamIDLobby
                }
            });
        }

        public async Task InviteToLobbyAsync(CSteamID userId)
        {
            if (!Lobby.IsInLobby)
            {
                var lobbyId = await SteamHelpers.CreateLobbyAsync(_maxLobbySize);
                if (lobbyId.HasValue)
                {
                    SteamMatchmaking.InviteUserToLobby(lobbyId.Value, userId);
                }
            }
            else
            {
                SteamMatchmaking.InviteUserToLobby(Lobby.Id, userId);
            }
        }

        public void JoinLobby(CSteamID lobbyId)
        {
            SteamMatchmaking.JoinLobby(lobbyId);
        }

        public void LeaveLobby()
        {
            Lobby.LeaveLobby();
        }

        private void OnLobbyJoinRequested(GameLobbyJoinRequested_t param)
        {
            SteamMatchmaking.JoinLobby(param.m_steamIDLobby);
        }

        private void OnLobbyChatUpdate(LobbyChatUpdate_t param)
        {
            switch ((EChatMemberStateChange)param.m_rgfChatMemberStateChange)
            {
                case EChatMemberStateChange.k_EChatMemberStateChangeBanned:
                case EChatMemberStateChange.k_EChatMemberStateChangeDisconnected:
                case EChatMemberStateChange.k_EChatMemberStateChangeKicked:
                case EChatMemberStateChange.k_EChatMemberStateChangeLeft:
                    Debug.Log($"{SteamFriends.GetFriendPersonaName((CSteamID)param.m_ulSteamIDUserChanged)} has left the game.");
                    if (param.m_ulSteamIDUserChanged != SteamHelpers.Me.m_SteamID)
                    {
                        Lobby.SyncMemebers();
                        //Closep2pSession
                    }
                    break;
                case EChatMemberStateChange.k_EChatMemberStateChangeEntered:
                    Debug.Log($"{SteamFriends.GetFriendPersonaName((CSteamID)param.m_ulSteamIDUserChanged)} has joined the game.");
                    Lobby.SyncMemebers();
                    break;
            }
        }

        private void OnLobbyEntered(LobbyEnter_t param)
        {
            if (param.m_EChatRoomEnterResponse == (uint)EChatRoomEnterResponse.k_EChatRoomEnterResponseSuccess)
            {
                Lobby.EnterLobby((CSteamID)param.m_ulSteamIDLobby);
            }
        }

        private void OnLobbyCreated(LobbyCreated_t param)
        {
            if (param.m_eResult != EResult.k_EResultOK)
            {
                Debug.LogError("Failed to create lobby.");
            }
        }
    }

    public class LobbyInvite
    {
        public string Username { get; set; }
        public CSteamID LobbyId { get; set; }
    }

    public class SteamLobby
    {
        public CSteamID Id { get; set; }
        public bool IsInLobby { get; set; }
        public bool IsOwnerMe { get; set; }
        public List<CSteamID> Members { get; set; }
        public CSteamID Owner { get; set; }

        private SignalBus _signalBus;

        public SteamLobby(SignalBus signalBus)
        {
            _signalBus = signalBus;
            IsInLobby = false;
            IsOwnerMe = true;
            Owner = SteamHelpers.Me;
            SyncMemebers();
        }

        public void LeaveLobby()
        {
            SteamMatchmaking.LeaveLobby(Id);
            Id = default(CSteamID);
            IsInLobby = false;
            Owner = SteamHelpers.Me;
            IsOwnerMe = true;
            SyncMemebers();
        }

        public void EnterLobby(CSteamID lobbyId)
        {
            Id = lobbyId;
            IsInLobby = true;
            Owner = SteamMatchmaking.GetLobbyOwner(lobbyId);
            IsOwnerMe = Owner == SteamHelpers.Me;
            SyncMemebers();
        }

        public void SyncMemebers()
        {
            var result = new List<CSteamID>();
            if (!IsInLobby)
            {
                result.Add(SteamHelpers.Me);
            }
            else
            {
                var lobbyMemberCount = SteamMatchmaking.GetNumLobbyMembers(Id);
                for (int i = 0; i < lobbyMemberCount; i++)
                {
                    result.Add(SteamMatchmaking.GetLobbyMemberByIndex(Id, i));
                }
            }
            Members = result;
            _signalBus.Fire<LobbyManager.MembersUpdateSignal>();
        }
    }
}

