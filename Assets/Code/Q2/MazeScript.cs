using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Q2
{
    public class MazeScript : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<RotatingShipController>())
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}

