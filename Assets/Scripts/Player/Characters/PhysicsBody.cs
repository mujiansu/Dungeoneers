using UnityEngine;

public class PhysicsBody : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    public Vector2 Pos => _rigidBody.position;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.velocity = new Vector2(0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(_rigidBody.velocity);
    }

    public void SetVelocity(Vector2 vel)
    {
        _rigidBody.velocity = vel;
    }

    public void SetPosition(Vector2 pos)
    {
        _rigidBody.MovePosition(pos);
    }


}
