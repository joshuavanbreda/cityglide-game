using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    //private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //rb.velocity = new Vector3(GameEngine.instance.scrollSpeed, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameEngine.instance.gameOver == true)
        {
            transform.position += Vector3.zero;
        }
        else if (GameEngine.instance.isStarted == true)
        {
            //transform.position += new Vector3(GameEngine.instance.scrollSpeed, 0, 0);
            transform.position += new Vector3(((Time.deltaTime * GameEngine.instance.scrollSpeed) / 1f), 0, 0);
        }
    }
}
