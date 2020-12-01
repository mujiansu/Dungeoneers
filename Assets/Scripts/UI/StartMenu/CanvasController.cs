using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public Canvas InviteMenuCanvas;
    public Canvas StartMenuCanvas;
    private CanvasType _currentCanvas;
    public enum CanvasType
    {
        Closed,
        StartMenu,
        InviteMenu
    }

    private Dictionary<CanvasType, Canvas> _canvases = new Dictionary<CanvasType, Canvas>();
    void Start()
    {
        _canvases.Add(CanvasType.StartMenu, StartMenuCanvas);
        _canvases.Add(CanvasType.InviteMenu, InviteMenuCanvas);
        SwitchCanvas(CanvasType.InviteMenu);
    }

    public void CloseCanvas()
    {
        foreach (var canvas in _canvases)
        {
            canvas.Value.transform.gameObject.SetActive(false);
        }
        _currentCanvas = CanvasType.Closed;
    }
    public void SwitchCanvas(CanvasType type)
    {
        if (type == CanvasType.Closed) throw new System.Exception("Cannot switch to closed canvas type.");
        if (type == _currentCanvas) return;
        _currentCanvas = type;
        foreach (var canvas in _canvases)
        {
            if (canvas.Key == type) canvas.Value.transform.gameObject.SetActive(true);
            else canvas.Value.transform.gameObject.SetActive(false);
        }
    }




}
