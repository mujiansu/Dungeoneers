using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class FriendElement : MonoBehaviour
{
    [SerializeField]
    private Image _imgAvatar;
    [SerializeField]
    private Text _txtUsername;
    [SerializeField]
    private Text _txtGameState;

    private Button _button;

    private static LobbyManager _lobbyManager;

    private SteamFriendMetadata _metadata;

    public class Factory : PlaceholderFactory<FriendElement> { }


    [Inject]
    public void Constructor(LobbyManager lobbyManager)
    {
        _lobbyManager = lobbyManager;
    }

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnBtnClick);
    }

    private async void OnBtnClick()
    {
        await _lobbyManager.InviteToLobbyAsync(_metadata.UserId);
        _button.interactable = false;
    }

    public void SetFriendMetadata(SteamFriendMetadata metadata)
    {
        _imgAvatar.sprite = Sprite.Create(metadata.Avatar, new Rect(0, 0, metadata.Avatar.width, metadata.Avatar.height), Vector2.zero);
        _txtUsername.text = metadata.Name;
        _txtGameState.text = metadata.GameId.ToString();
        _metadata = metadata;
    }
}
