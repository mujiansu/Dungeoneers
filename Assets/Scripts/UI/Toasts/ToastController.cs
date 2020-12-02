using UnityEngine;
using Zenject;

public class ToastController : MonoBehaviour
{
    public Toast Toast;

    [Inject]
    public void Constructor(LobbyManager lobbyManager)
    {
        lobbyManager.SignalBus.Subscribe<LobbyManager.LobbyInviteReceivedSignal>(OnInviteRecieved);
    }

    private void Start()
    {
        var toast = Instantiate(Toast);
        toast.transform.SetParent(transform, false);
        Destroy(gameObject, 5f);
    }

    private void OnInviteRecieved(LobbyManager.LobbyInviteReceivedSignal invite)
    {
        var toast = Instantiate(Toast);
        toast.SetData(invite.LobbyInvite.Username, invite.LobbyInvite.LobbyId);
        if (transform.childCount == 1)
        {
            Destroy(transform.GetChild(0).transform.gameObject);
        }
        Toast.transform.SetParent(transform);
    }
}
