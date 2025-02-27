using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer
{
    public class Projectile : MonoBehaviour
    {
        // Start is called before the first frame update
        Rigidbody2D _rigidbody2D;
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.velocity = transform.right * 10f;
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(gameObject);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

