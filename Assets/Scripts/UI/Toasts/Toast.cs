
using Steamworks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Toast : MonoBehaviour
{
    public Text Text;
    public Button DeclineBtn;
    public Button AcceptBtn;

    private CSteamID _lobbyId;

    public class Factory : PlaceholderFactory<Toast> { }

    private LobbyManager _lobbyManager;

    [Inject]
    public void Constructor(LobbyManager lobbyManager)
    {
        _lobbyManager = lobbyManager;
    }

    private void Start()
    {
        DeclineBtn.onClick.AddListener(OnDeclineBtnClicked);
        AcceptBtn.onClick.AddListener(OnAcceptBtnClicked);
        Destroy(gameObject, 5f);
    }

    private void OnAcceptBtnClicked()
    {
        _lobbyManager.JoinLobby(_lobbyId);
    }

    private void OnDeclineBtnClicked()
    {
        Destroy(gameObject);
    }

    public void SetData(string username, CSteamID lobbyId)
    {
        _lobbyId = lobbyId;
        Text.text += username;
    }
}
