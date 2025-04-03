using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Projectile : MonoBehaviour
    {
        // Outlets
        Rigidbody2D _rb;
        // State Tracking
        Transform target;
        // Methods
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            // TODO: Make these dynamic
            float acceleration = GameController.instance.missileSpeed / 2f;
            float maxSpeed = GameController.instance.missileSpeed;
            // Home in on target
            ChooseNearestTarget();
            if (target != null)
            {
                // Rotate towards target
                Vector2 directionToTarget = target.position - transform.position;
                float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
                _rb.MoveRotation(angle);
            }
            // Accelerate forward
            _rb.AddForce(transform.right * acceleration);
            // Cap max speed
            _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, maxSpeed);
        }

        void ChooseNearestTarget()
        {
            // High default means first asteroid will always count as closest
            float closestDistance = 9999f;
            // Expensive function. Correct approach would be object pooling.
            Asteroid[] asteroids = FindObjectsOfType<Asteroid>();
            // Check each asteroid to see if it's the closest
            for (int i = 0; i < asteroids.Length; i++)
            {
                Asteroid asteroid = asteroids[i];
                if (asteroid.transform.position.x > transform.position.x)
                {
                    Vector2 directionToTarget = asteroid.transform.position - transform.position;
                    // Filter for the closest target we've seen so far
                    if (directionToTarget.sqrMagnitude < closestDistance)
                    {
                        // Update closest distance for future comparisons
                        closestDistance = directionToTarget.sqrMagnitude;
                        target = asteroid.transform;

                    }

                }
            }
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            // Only explode on Asteroids
            if (other.gameObject.GetComponent<Asteroid>())
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                // Create an explosion and destroy it soon after
                GameObject explosion = Instantiate(GameController.instance.explosionPrefab, transform.position, Quaternion.identity);
                Destroy(explosion, 0.25f);
                GameController.instance.EarnPoints(10);
            }
        }
    }

}

