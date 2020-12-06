using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    private const float _zPos = -5;

    public void SetPos(Vector2 pos)
    {
        transform.position = new Vector3(pos.x, pos.y, _zPos);
    }
}