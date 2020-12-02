using System;
using UnityEngine;
using Zenject;

public class ToastController : MonoBehaviour
{

    [Inject]
    public void Constructor(LobbyManager lobbyManager)
    {
        lobbyManager.SubscribeOnLobbyInviteReceived(OnInviteRecieved);
    }

    private void OnInviteRecieved(LobbyInvite arg0)
    {

    }
}
