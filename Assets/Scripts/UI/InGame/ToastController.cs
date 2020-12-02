using UnityEngine;
using Zenject;

public class ToastController : MonoBehaviour
{
    public Toast Toast;
    private Toast.Factory _toastFactory;

    [Inject]
    public void Constructor(LobbyManager lobbyManager, Toast.Factory toastFactory)
    {
        lobbyManager.SignalBus.Subscribe<LobbyManager.LobbyInviteReceivedSignal>(OnInviteRecieved);
        _toastFactory = toastFactory;
    }

    private void OnInviteRecieved(LobbyManager.LobbyInviteReceivedSignal invite)
    {
        var toast = _toastFactory.Create();
        toast.SetData(invite.LobbyInvite.Username, invite.LobbyInvite.LobbyId);
        if (transform.childCount == 1)
        {
            Destroy(transform.GetChild(0).transform.gameObject);
        }
        toast.transform.SetParent(transform, false);
    }
}
