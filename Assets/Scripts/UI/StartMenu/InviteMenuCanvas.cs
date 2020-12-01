using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InviteMenuCanvas : MonoBehaviour
{
    public VerticalLayoutGroup FriendGroup;
    public FriendElement FriendElementPrefab;

    private void OnEnable()
    {
        foreach (Transform child in FriendGroup.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        if (SteamHelpers.TryGetFriendsMetadata(out List<SteamFriendMetadata> friends))
        {
            foreach (var friend in friends)
            {
                var friendElement = Instantiate(FriendElementPrefab);
                friendElement.SetFriendMetadata(friend);
                friendElement.transform.SetParent(FriendGroup.transform);
            }
        }
    }

}
