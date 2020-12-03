using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    
    public delegate void SceneLoadDelegate(SceneType _scene);
    public static SceneController instance;
    

    //private PageController _Menu;
    private SceneType _targetScene;
    private SceneLoadDelegate _sceneLoadDelegate;
    private bool _sceneIsLoading;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
#region Unity Functions
    private void Awake() 
    {
        

    }

    private void OnDisable() 
    {
        
    }
#endregion

#region Public Functions
    public void Load(SceneType _scene, 
        SceneLoadDelegate _sceneLoadDelegate=null,
        bool _reload=false,
        PageType _loadingPage=PageType.None)
    {
        
    }
#endregion

#region Private Functions
    private void Configure()
    {

    }

    private void Dispose()
    {

    }

    prvate async void 



#endregion

}
