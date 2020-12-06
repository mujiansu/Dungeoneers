using System.Collections.Generic;
using Dungeoneer.Steamworks;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using static Dugeoneer.Ui.InGame.CanvasController;

namespace Dugeoneer.Ui.InGame
{
    public class InviteMenuCanvas : MonoBehaviour
    {
        public VerticalLayoutGroup FriendGroup;
        public ScrollRect FriendScrollRect;
        public FriendElement FriendElementPrefab;
        public Button BackBtn;

        private CanvasController CanvasController;
        private FriendElement.Factory _friendFactory;

        [Inject]
        public void Constructor(FriendElement.Factory friendFactory)
        {
            _friendFactory = friendFactory;
        }

        private void Start()
        {
            CanvasController = transform.parent.gameObject.GetComponent<CanvasController>();
            BackBtn.onClick.AddListener(OnBackBtnClick);
        }

        private void OnBackBtnClick()
        {
            CanvasController.SwitchCanvas(CanvasType.StartMenu);
        }

        private void OnEnable()
        {
            foreach (Transform child in FriendGroup.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            if (SteamHelpers.TryGetFriendsMetadata(out List<SteamFriendMetadata> friends))
            {
                friends.Sort(delegate (SteamFriendMetadata a, SteamFriendMetadata b)
                {
                    var aMatchesGameId = a.GameId == SteamHelpers.GameId;
                    var bMatchesGameId = b.GameId == SteamHelpers.GameId;
                    var aIsOnline = a.State == EPersonaState.k_EPersonaStateOnline;
                    var bIsOnline = b.State == EPersonaState.k_EPersonaStateOnline;
                    if (aMatchesGameId && bMatchesGameId)
                    {
                        return a.Name.CompareTo(b.Name);
                    }
                    else if (aMatchesGameId)
                    {
                        return -1;
                    }
                    else if (bMatchesGameId)
                    {
                        return 1;
                    }
                    else if (aIsOnline && bIsOnline)
                    {
                        return a.Name.CompareTo(b.Name);
                    }
                    else if (aIsOnline)
                    {
                        return -1;
                    }
                    else if (bIsOnline)
                    {
                        return 1;
                    }
                    return a.Name.CompareTo(b.Name);
                });
                foreach (var friend in friends)
                {
                    var friendElement = _friendFactory.Create();
                    friendElement.SetFriendMetadata(friend);
                    friendElement.transform.SetParent(FriendGroup.transform, false);
                }
                FriendScrollRect.verticalNormalizedPosition = 1;
            }
        }

    }

}

