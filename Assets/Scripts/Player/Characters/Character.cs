using UnityEngine;

public class Character : MonoBehaviour
{

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("Test_Idle");
    }

    // Update is called once per frame
    void Update()
    {
        _animator.Play("Test_Running");
        _animator.SetFloat("x_vel", .9f);
        _animator.SetFloat("y_vel", -1f);
    }
}
