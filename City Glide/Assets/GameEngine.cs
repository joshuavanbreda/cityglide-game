using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{
    public static GameEngine instance;

    public bool gameOver;

    public Rigidbody player;

    public Swipe swipeControls;

    public GameObject gameOverImage;
    public GameObject restartText;
    public GameObject initialBuildings;

    public GameObject scoreBackground;
    public Text scoreText;
    public float playerScore;

    public bool isStarted;

    public float scrollSpeed;

    public float adjustableGameSpeed;

    public GameObject gameSpeedText;
    public GameObject turnSpeedText;
    public GameObject windBoostText;
    public GameObject disableWindText;
    public GameObject godModeText;

    public Toggle disableWindToggle;
    public Toggle godModeToggle;

    public Text gameSpeedField;
    public Text turnSpeedField;
    public Text windBoostSpeedField;

    public Button debugButton;
    public Button exitDebug;
    public GameObject debugBackground;

    public GameObject windObject;
    public GameObject godModeBarrier;

    public GameObject plane1;
    public GameObject plane2;
    public GameObject plane3;

    public Button plane1Button;
    public Button plane2Button;
    public Button plane3Button;

    public Button cam1;
    public Button cam2;
    public Button cam3;

    public Rigidbody mainCam;

    public bool godMode = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)

            instance = this;

        else if (instance != this)

            Destroy(gameObject);
    }

    private void Start()
    {
        gameOver = false;
        gameOverImage.SetActive(false);
        restartText.SetActive(false);
        initialBuildings.SetActive(true);
        scoreBackground.SetActive(false);
        scoreText.text = "";

        gameSpeedText.SetActive(false);
        turnSpeedText.SetActive(false);
        windBoostText.SetActive(false);
        disableWindText.SetActive(false);
        godModeText.SetActive(false);

        debugButton.gameObject.SetActive(true);
        debugBackground.gameObject.SetActive(false);
        exitDebug.gameObject.SetActive(false);

        plane1.SetActive(true);
        plane2.SetActive(false);
        plane3.SetActive(false);

        plane1Button.gameObject.SetActive(false);
        plane2Button.gameObject.SetActive(false);
        plane3Button.gameObject.SetActive(false);

        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(false);

        godModeBarrier.SetActive(false);


        /*disableWindToggle = GetComponent<Toggle>();
        disableWindToggle.onValueChanged.AddListener(delegate {
            ToggleValueChangedOccured(disableWindToggle);
        });*/

    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y <= 1)
        {
            playerDied();
        }

        if (gameOver == true)
        {
            Time.timeScale = 0;
            if (swipeControls.SwipeDown)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (isStarted == true)
        {
            playerScore += 0.1f * adjustableGameSpeed;
            scoreText.text = "Score: " + Mathf.RoundToInt(playerScore);
        }

        if (isStarted == true)
        {
            Time.timeScale += adjustableGameSpeed / 1500f;
        }
        

        if (gameSpeedField != null)
        {
            adjustableGameSpeed = float.Parse(gameSpeedField.text);
        }
        else
        {
            adjustableGameSpeed = 1;
        }
    }

    public void playerDied()
    {
        gameOverImage.SetActive(true);
        restartText.SetActive(true);
        gameOver = true;
        isStarted = false;
    }

    public void DebugMenu()
    {
        debugButton.gameObject.SetActive(false);

        debugBackground.SetActive(true);
        exitDebug.gameObject.SetActive(true);

        gameSpeedText.SetActive(true);
        turnSpeedText.SetActive(true);
        windBoostText.SetActive(true);
        disableWindText.SetActive(true);
        godModeText.SetActive(true);

        plane1Button.gameObject.SetActive(true);
        plane2Button.gameObject.SetActive(true);
        plane3Button.gameObject.SetActive(true);

        cam1.gameObject.SetActive(true);
        cam2.gameObject.SetActive(true);
        cam3.gameObject.SetActive(true);
    }

    public void ExitDebug()
    {
        debugButton.gameObject.SetActive(true);

        debugBackground.SetActive(false);
        exitDebug.gameObject.SetActive(false);

        gameSpeedText.SetActive(false);
        turnSpeedText.SetActive(false);
        windBoostText.SetActive(false);
        disableWindText.SetActive(false);
        godModeText.SetActive(false);

        plane1Button.gameObject.SetActive(false);
        plane2Button.gameObject.SetActive(false);
        plane3Button.gameObject.SetActive(false);

        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(false);

        if (disableWindToggle.isOn)
        {
            windObject.SetActive(false);
        }
        else
        {
            windObject.SetActive(true);
        }

        if (godModeToggle.isOn)
        {
            godMode = true;
        }
        else
        {
            godMode = false;
        }
    }

    public void ActivateFirstPlane()
    {
        plane1.SetActive(true);
        plane2.SetActive(false);
        plane3.SetActive(false);
    }

    public void ActivateSecondPlane()
    {
        plane1.SetActive(false);
        plane2.SetActive(true);
        plane3.SetActive(false);
    }

    public void ActivateThirdPlane()
    {
        plane1.SetActive(false);
        plane2.SetActive(false);
        plane3.SetActive(true);
    }

    public void CameraOne()
    {
        CameraFollow.instance.offset = 0.2f;
        mainCam.rotation = Quaternion.Euler(new Vector3(34.453f, 90, 0));
        CameraFollow.instance.camHeight = 0.2f;
    }

    public void CameraTwo()
    {
        CameraFollow.instance.offset = 0.08f;
        mainCam.rotation = Quaternion.Euler(new Vector3(50f, 90, 0));
        CameraFollow.instance.camHeight = 0.2f;
    }

    public void CameraThree()
    {
        CameraFollow.instance.offset = 0.2f;
        mainCam.rotation = Quaternion.Euler(new Vector3(7f, 90, 0));
        CameraFollow.instance.camHeight = 0.1f;

    }

    /*void ToggleValueChangedOccured(Toggle tglValue)
    {
        godModeBarrier.SetActive(tglValue);
    }*/


    /*public void ActiveToggle()
    {
        if (godModeToggle.isOn)
        {
            godModeBarrier.SetActive(true);
        }
        else if (disableWindToggle.isOn)
        {
            windObject.SetActive(true);
        }
    }*/

}
