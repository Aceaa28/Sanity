using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Vector2 startPos;
   float repeatWidth;
   public float scrollSpeed;
   

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    // // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * 10 * Time.deltaTime);
    //     // float x = Mathf.Repeat (Time.time * scrollSpeed, 1);
    //     // Vector2 offset = new Vector2 (x, 0);
    //     // renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);

        if (transform.position.x < startPos.x - repeatWidth)
		{
			transform.position = startPos;
		}
    }

    
}
