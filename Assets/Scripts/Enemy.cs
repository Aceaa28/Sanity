using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //define variable and  
    public float moveRange = 19f;
    private Vector2 initialPosition;
    public GameObject player;
    //public bool inRange;
 
    // Start is called before the first frame update
    void Start()
    {
       //assign intial position for the enemy
       initialPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
    // Calculate the movement within the defined range
    float movement = Mathf.PingPong(Time.time, moveRange) - (moveRange / 2f);

    // Set the new position of the enemy
    transform.position = initialPosition + new Vector2(movement, 0f);
    }

   void OnTriggerEnter(Collider other)
	{
		Destroy(gameObject);
	}

    private void OnCollisionEnter(Collision other)
    {
        if(GameObject.Find("player"))
        {
          Destroy(GetComponent<Collider>());
        }
    }
}
