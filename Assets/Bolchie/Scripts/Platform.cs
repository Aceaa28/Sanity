using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    float maxY = 0;
    float minY = -9;
    [SerializeField] GameObject platform;
    [SerializeField] GameObject player; 
    Vector2 playerPosition; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GeneratePlatform());
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
        //StartCoroutine(GeneratePlatform());
    }

    IEnumerator GeneratePlatform ()
    {
        yield return new WaitForSeconds (5);
        Instantiate (platform, new Vector2 (playerPosition.x + 5, Random.Range(minY, maxY)), Quaternion.identity);
        Debug.Log("works");

    }
}
