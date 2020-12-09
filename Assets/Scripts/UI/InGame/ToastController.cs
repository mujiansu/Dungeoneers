using Dungeoneer.Managers;
using UnityEngine;
using Zenject;
namespace Dungeoneer.Ui.InGame
{
    public class ToastController : MonoBehaviour
    {
        public Toast Toast;
        private Toast.Factory _toastFactory;
        private SignalBus _signalBus;

        [Inject]
        public void Constructor(SignalBus signalBus, Toast.Factory toastFactory)
        {
            _signalBus = signalBus;
            _toastFactory = toastFactory;
        }

        private void Start()
        {
            _signalBus.Subscribe<LobbyManager.LobbyInviteReceivedSignal>(OnInviteRecieved);
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

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<LobbyManager.LobbyInviteReceivedSignal>(OnInviteRecieved);
        }
    }

}

