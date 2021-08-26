using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeTest : MonoBehaviour
{
    public float speedMultiplier;
    public float airSpeed;
    public Swipe swipeControls;
    public Transform player;
    private Vector3 desiredPosition;
    public Rigidbody rb;
    public Text playSwipe;
    public GameObject CityGlide;

    public Transform playerModel;

    private void Start()
    {
        CityGlide.SetActive(true);
        playSwipe.text = "Swipe up to throw a plane!";
        desiredPosition = player.transform.position;

    }
    private void Update()
    {
        if (swipeControls.SwipeLeft && GameEngine.instance.isStarted == true)
        {
            if (rb.velocity.z > 0)
            {
                rb.AddForce(transform.forward * speedMultiplier);
            }
            else
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(transform.forward * speedMultiplier);
                //rb.AddForce(-transform.up * airSpeed);
            }
        }
            
        if (swipeControls.SwipeRight && GameEngine.instance.isStarted == true)
        {
            if (rb.velocity.z < 0)
            {
                rb.AddForce(-transform.forward * speedMultiplier);
            }
            else
            {
                rb.velocity = new Vector3 (0, rb.velocity.y, 0);
                rb.AddForce(-transform.forward * speedMultiplier);
                //rb.AddForce(-transform.up * airSpeed);
            }
        }

        if (swipeControls.SwipeUp && GameEngine.instance.isStarted == false && GameEngine.instance.gameOver == false)
        {
            CityGlide.SetActive(false);
            GameEngine.instance.isStarted = true;
            playSwipe.text = "";
            //rb.velocity = -transform.up * 1f;
            //GameEngine.instance.initialBuildings.SetActive(false);

            GameEngine.instance.scoreBackground.SetActive(true);
            GameEngine.instance.scoreText.text = "Score: 0";
        }

        if (GameEngine.instance.isStarted == true)
        {
            //rb.velocity = -transform.up * 1f;
            if (GameEngine.instance.godMode == true)
            {
                rb.velocity = new Vector3(0, 0, rb.velocity.z);
            }
            else if (GameEngine.instance.godMode == false)
            {
                rb.velocity = new Vector3(0, -1, rb.velocity.z);
            }
        }

        player.rotation = Quaternion.Euler(new Vector3(rb.velocity.z * 2f, 0, 0));


        if (GameEngine.instance.turnSpeedField != null)
        {
            speedMultiplier = float.Parse(GameEngine.instance.turnSpeedField.text) * 15;
        }
        else
        {
            speedMultiplier = 40;
        }

    }
}
