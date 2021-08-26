using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;
    public GameObject player;
    public float offset;
    public float camHeight;

    void Awake()
    {
        if (instance == null)

            instance = this;

        else if (instance != this)

            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        camHeight = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(-offset, camHeight, 0);
    }
}
