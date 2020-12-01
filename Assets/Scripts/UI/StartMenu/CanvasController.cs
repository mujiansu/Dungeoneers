using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public Canvas InviteMenuCanvas;
    void Start()
    {
        InviteMenuCanvas.transform.gameObject.SetActive(true);
    }


}
