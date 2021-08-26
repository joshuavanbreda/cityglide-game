using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
    //public float scrollSpeed;
    private float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameEngine.instance.isStarted == true)
        {
            if (transform.name == "WalkWay 5")
            {
                offset += (Time.deltaTime * -60f) / 10f;

                transform.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector3(offset, 0, 0));
            }
            else if(transform.name == "street")
            {
                offset += (Time.deltaTime * -30f) / 10f;

                transform.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector3(offset, 0, 0));
            }
            else
            {
                offset += (Time.deltaTime * GameEngine.instance.scrollSpeed) / 10f;

                transform.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector3(offset, 0, 0));
            }
        }
    }
}
