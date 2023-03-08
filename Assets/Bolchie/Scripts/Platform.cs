using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
   [SerializeField] float speed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        if (transform.position.x < -5)
        {
            Destroy(gameObject); 
        }
    }
}
