using System;
using System.Collections;
using System.Collections.Generic;
using Dungeoneer.Managers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using static Dungeoneer.Managers.SceneChangingManager;

namespace Dungeoneer.Ui.InGame
{
    public class StartMenuCanvas : MonoBehaviour
    {
        public Button InviteBtn;

        public Button RestartLevelBtn;
        public Button ReturnToHubBtn;
        private CanvasController _canvasController;

        private SceneChangingManager _sceneManager;

        [Inject]
        public void Constructor(SceneChangingManager sceneManger)
        {
            _sceneManager = sceneManger;
        }

        // Start is called before the first frame update
        void Start()
        {
            _canvasController = transform.parent.gameObject.GetComponent<CanvasController>();
            InviteBtn.onClick.AddListener(OnInviteBtnClick);
            RestartLevelBtn.onClick.AddListener(OnRestartBtnClick);
            ReturnToHubBtn.onClick.AddListener(OnReturnToHubBtnClick);
        }

        private void OnReturnToHubBtnClick()
        {
            _sceneManager.ChangeScene(Scene.Hub);
        }

        private void OnRestartBtnClick()
        {
            _sceneManager.RestartScene();
        }

        private void OnInviteBtnClick()
        {
            _canvasController.SwitchCanvas(CanvasController.CanvasType.InviteMenu);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

