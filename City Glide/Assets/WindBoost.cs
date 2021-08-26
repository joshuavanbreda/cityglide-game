using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBoost : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GameEngine.instance.windBoostSpeedField.text != null)
            {
                other.transform.GetComponent<Rigidbody>().AddForce((Vector3.up * 500) * float.Parse(GameEngine.instance.windBoostSpeedField.text));
            }
            else
            {
                other.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 1000);
            }
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.GetChild(0).rotation = Quaternion.Lerp(other.transform.GetChild(0).rotation, Quaternion.Euler(new Vector3(other.transform.GetChild(0).rotation.x, 90, -15f)), 0.5f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.GetChild(0).rotation = Quaternion.Lerp(other.gameObject.transform.GetChild(0).rotation, Quaternion.Euler(new Vector3(-90, 90, 0f)), 0.5f);
        }
    }*/
}
