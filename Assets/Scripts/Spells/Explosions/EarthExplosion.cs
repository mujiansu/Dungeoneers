using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthExplosion : MonoBehaviour
{
    private ParticleSystem _ps;
    private Collider2D _collider;

    private void Awake()
    {
        _ps = GetComponent<ParticleSystem>();
        _collider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (!_ps.IsAlive())
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }

}
