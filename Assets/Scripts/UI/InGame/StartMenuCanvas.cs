using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Dugeoneer.Ui.InGame
{
    public class StartMenuCanvas : MonoBehaviour
    {
        public Button InviteBtn;
        private CanvasController _canvasController;

        // Start is called before the first frame update
        void Start()
        {
            _canvasController = transform.parent.gameObject.GetComponent<CanvasController>();
            InviteBtn.onClick.AddListener(OnInviteBtnClick);
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

