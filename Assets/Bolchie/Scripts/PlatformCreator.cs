using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject[] referencePoint;
    private GameObject lastCreatedPlatform;
    int randomPlatform;

    // Start is called before the first frame update
    void Start()
    {
        randomPlatform = Random.Range(0, referencePoint.Length);
        Debug.Log(referencePoint.Length);
       lastCreatedPlatform = Instantiate(platformPrefab, referencePoint[randomPlatform].transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (lastCreatedPlatform.transform.position.x < 0)
        {
            randomPlatform = Random.Range(0, referencePoint.Length);
            lastCreatedPlatform = Instantiate(platformPrefab, referencePoint[randomPlatform].transform.position, Quaternion.identity);
        }
    }
}
