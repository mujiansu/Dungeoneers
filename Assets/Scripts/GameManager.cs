using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{

    private SteamManager _steamManager;
    [Inject]
    public void Construct(SteamManager steamManager)
    {
        _steamManager = steamManager;
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(_steamManager);
    }

    private void Update()
    {
        _steamManager.RunCallbacks();
    }
}
