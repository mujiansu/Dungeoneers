using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeoneer.Spells.Projectiles
{
    public class Rock : MonoBehaviour
    {
        public Vector2 StartPos;
        public Vector2 EndPos;

        public float Speed;

        public
        void Start()
        {
            transform.position = StartPos;
            StartCoroutine(nameof(MoveCoroutine));
        }

        // Update is called once per frame
        void Update()
        {

        }

        public IEnumerator MoveCoroutine()
        {
            var velocity = Speed / Time.fixedDeltaTime;
            var totalDuration = (EndPos - StartPos).magnitude / velocity;
            var elapsed = 0f;
            var interval = 0f;
            while (interval < 1)
            {
                elapsed += Time.deltaTime;
                interval = elapsed / totalDuration;
                transform.position = Vector2.Lerp(StartPos, EndPos, interval);
                yield return null;
            }
            Destroy(gameObject);
            //Explode at end of coroutine.
        }
    }
}


