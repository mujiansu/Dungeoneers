using System;
using Steamworks;
using Zenject;

public class LobbyManager : IInitializable
{
    public void Initialize()
    {
        SteamHelpers.RegisterCallback<LobbyCreated_t>(OnLobbyCreated);
        SteamHelpers.RegisterCallback<LobbyEnter_t>(OnLobbyEntered);
        SteamHelpers.RegisterCallback<LobbyChatUpdate_t>(OnLobbyChatUpdate);
        SteamHelpers.RegisterCallback<GameLobbyJoinRequested_t>(OnLobbyJoinRequested);
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
