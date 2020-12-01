using UnityEngine;

public class Character : MonoBehaviour
{
    
    public float Speed = 1f;

    private PhysicsBody _physicsBody;
    private Renderer _renderer;
    
    


    // Start is called before the first frame update
    void Start()
    {
        _physicsBody = GetComponentInChildren<PhysicsBody>();
        _renderer = GetComponentInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = new Vector2();
        if(Input.GetKey(KeyCode.W))
        {
            vel.y += 1f;
        }
        if(Input.GetKey(KeyCode.A))
        {
            vel.x -= 1f;
        }
        if(Input.GetKey(KeyCode.S))
        {
            vel.y -= 1f;
        }
        if(Input.GetKey(KeyCode.D))
        {
            vel.x += 1f;
        }
        _physicsBody.SetVelocity(vel.normalized*Speed);
    }

    //
    private void FixedUpdate() 
    {
        
       /* 
        var pos = _transform.position;
        pos.x += 0.01f;
        _transform.position = pos;*/
    }
}
