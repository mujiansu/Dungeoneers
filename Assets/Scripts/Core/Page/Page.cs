using System.Collections;
using UnityEngine;

public class Page : MonoBehaviour
{
    public enum PageState
    {
        TURN_ON,
        TURN_OFF,
        IDLE
    }
    public PageType type;
    public bool useAnimation;
    public PageState targetState
    {
        get;
        private set;
    }

#if UNITY_EDITOR
    public bool debugEnabled = true;
#else
    public bool debugEnabled = false;
#endif

    private Animator _animator;

#region Unity Functions
    private void OnEnable() 
    {
        checkAnimatorIntegrity();
    }
#endregion

#region Public Functions
    public void Animate(bool _on)
    {
        if(useAnimation)
        {
            _animator.SetBool("on",_on);
            StopCoroutine("AwaitAnimation");
            StartCoroutine("AwaitAnimation",_on);
        }
        else
        {
            if(!_on)
            {
                gameObject.SetActive(false);
            }
        }

    }
#endregion

#region Private Functions
    private IEnumerator AwaitAnimation(bool _on)
    {
        targetState = _on ? PageState.TURN_ON : PageState.TURN_OFF;
        while(!_animator.GetCurrentAnimatorStateInfo(0).IsName(targetState.ToString()))
        {
            yield return null;
        }
        
        while(_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
           yield return null; 
        }

        targetState = Page.PageState.IDLE;
        Log("Page ["+type+"] finished transitioning to "+(_on ? "on" : "off")+".");

        if(!_on)
        {
            gameObject.SetActive(false);
        }
    }

    private void checkAnimatorIntegrity()
    {
        if(useAnimation)
        {
            _animator = GetComponent<Animator>();
            if(!_animator)
            {
                LogWarning("You opted to animate a page ["+type+"], but no Animator component exists on the object.");
            }
        }
    }

    private void Log( string _msg)
    {
        if(!debugEnabled)
            return;
        Debug.Log("[Page]:"+_msg);
    }

    private void LogWarning(string _msg)
    {
        if(!debugEnabled)
            return;
        Debug.LogWarning("[Page]:"+_msg);
    }
#endregion

}
