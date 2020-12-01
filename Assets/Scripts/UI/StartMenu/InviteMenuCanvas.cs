using System.Collections.Generic;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;

public class InviteMenuCanvas : MonoBehaviour
{
    public VerticalLayoutGroup FriendGroup;
    public ScrollRect FriendScrollRect;
    public FriendElement FriendElementPrefab;

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
                var friendElement = Instantiate(FriendElementPrefab);
                friendElement.SetFriendMetadata(friend);
                friendElement.transform.SetParent(FriendGroup.transform);
            }
            FriendScrollRect.verticalNormalizedPosition = 1;
        }
    }

}
