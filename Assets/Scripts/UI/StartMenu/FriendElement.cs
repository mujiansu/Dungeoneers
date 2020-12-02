using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendElement : MonoBehaviour
{
    [SerializeField]
    private Image _imgAvatar;
    [SerializeField]
    private Text _txtUsername;
    [SerializeField]
    private Text _txtGameState;

    public void SetFriendMetadata(SteamFriendMetadata metadata)
    {
        _imgAvatar.sprite = Sprite.Create(metadata.Avatar, new Rect(0, 0, metadata.Avatar.width, metadata.Avatar.height), Vector2.zero);
        _txtUsername.text = metadata.Name;
        _txtGameState.text = metadata.GameId.ToString();
    }
}
