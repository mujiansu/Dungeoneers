using System;
using System.Collections;
using System.Collections.Generic;
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
