using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Q2
{
    public class RotatingShipController : MonoBehaviour
    {
        // Start is called before the first frame update
        Rigidbody2D _rb;

        public float speed;
        public float rotationSpeed;
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _rb.AddTorque(rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                _rb.AddTorque(-rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                _rb.AddRelativeForce(Vector2.right * speed * Time.deltaTime);
            }

        }
    }
}

