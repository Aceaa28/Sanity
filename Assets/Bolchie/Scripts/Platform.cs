using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    float maxY = 0;
    float minY = -9;
   // [SerializeField] GameObject platform;
  //  [SerializeField] GameObject player; 
    Vector2 playerPosition; 
<<<<<<< Updated upstream
   [SerializeField] float speed = 1;
=======
    [SerializeField] float speed = 1;
>>>>>>> Stashed changes


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GeneratePlatform());
        InvokeRepeating("GeneratePlatform", 10.0f, 5.0f);
        
    }
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        //playerPosition = player.transform.position;

        transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        if (transform.position.x < -10)
        {
            Destroy(gameObject); 
        }
=======

        playerPosition = player.transform.position;
>>>>>>> Stashed changes
      
     
        //StartCoroutine(GeneratePlatform());
    }

    void GeneratePlatform ()
    {
        
<<<<<<< Updated upstream
       // Instantiate (platform, new Vector2 (playerPosition.x + 5, Random.Range(minY, maxY)), Quaternion.identity);
       // Debug.Log("works");

        
=======
        Instantiate (platform, new Vector2 (playerPosition.x + 5, Random.Range(minY, maxY)), Quaternion.identity);
        Debug.Log("works");
        transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        if (transform.position.x < -10)
        {
            Destroy(gameObject); 
        }
>>>>>>> Stashed changes
    }
}
