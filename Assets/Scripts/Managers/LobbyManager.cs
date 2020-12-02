using System;
using System.Collections.Generic;
using Steamworks;
using Zenject;

public class LobbyManager : IInitializable
{
    private SteamLobby _lobby;
    public void Initialize()
    {
        SteamHelpers.RegisterCallback<LobbyCreated_t>(OnLobbyCreated);
        SteamHelpers.RegisterCallback<LobbyEnter_t>(OnLobbyEntered);
        SteamHelpers.RegisterCallback<LobbyChatUpdate_t>(OnLobbyChatUpdate);
        SteamHelpers.RegisterCallback<GameLobbyJoinRequested_t>(OnLobbyJoinRequested);
        _lobby = new SteamLobby();
    }

    private void OnLobbyJoinRequested(GameLobbyJoinRequested_t param)
    {
        throw new NotImplementedException();
    }

    private void OnLobbyChatUpdate(LobbyChatUpdate_t param)
    {
        throw new NotImplementedException();
    }

    private void OnLobbyEntered(LobbyEnter_t param)
    {
        throw new NotImplementedException();
    }

    private void OnLobbyCreated(LobbyCreated_t param)
    {
        throw new NotImplementedException();
    }
}

public class SteamLobby
{
    public CSteamID Id { get; set; }
    public bool IsInLobby { get; set; }
    public bool IsOwnerMe { get; set; }
    public List<CSteamID> Members { get; set; }
    public CSteamID Owner { get; set; }

    public SteamLobby()
    {
        IsInLobby = false;
        IsOwnerMe = true;
        Members = new List<CSteamID>();
        Owner = SteamHelpers.Me;
    }

    public void LeaveLobby()
    {
        SteamMatchmaking.LeaveLobby(Id);
        Id = default(CSteamID);
        IsInLobby = false;
        IsOwnerMe = true;

    }

    public void EnterLobby(CSteamID lobbyId)
    {
        Id = lobbyId;
        IsInLobby = true;
        SyncMemebers();
        Owner = SteamMatchmaking.GetLobbyOwner(lobbyId);
        IsOwnerMe = Owner == SteamHelpers.Me;
    }

    public void SyncMemebers()
    {
        var result = new List<CSteamID>();
        var lobbyMemberCount = SteamMatchmaking.GetNumLobbyMembers(Id);
        for (int i = 0; i < lobbyMemberCount; i++)
        {
            result.Add(SteamMatchmaking.GetLobbyMemberByIndex(Id, i));
        }
    }
}
