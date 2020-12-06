using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CoreController : MonoBehaviour
{

    private PageController pageController;
    private SceneController sceneController;

    void Start()
    {
        pageController = GetComponent<PageController>();
        sceneController = GetComponent<SceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
