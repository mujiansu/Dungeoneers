using UnityEngine;
using Zenject;

public class ToastController : MonoBehaviour
{
    public Toast Toast;

    [Inject]
    public void Constructor(LobbyManager lobbyManager)
    {
        lobbyManager.SubscribeOnLobbyInviteReceived(OnInviteRecieved);
    }

    private void Start()
    {
        var toast = Instantiate(Toast);
        toast.transform.SetParent(transform, false);
        Destroy(gameObject, 5f);
    }

    private void OnInviteRecieved(LobbyInvite invite)
    {
        var toast = Instantiate(Toast);
        toast.SetData(invite.Username, invite.LobbyId);
        if (transform.childCount == 1)
        {
            Destroy(transform.GetChild(0).transform.gameObject);
        }
        Toast.transform.SetParent(transform);
    }
}
