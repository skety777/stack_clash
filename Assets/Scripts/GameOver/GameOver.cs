using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject LevelCompleted;
    public Image failedDiamonBG;
    public Image completedDiamonBG;
    public Slider bonusSlider;
    public GameObject LevelFailed;
    public TMP_Text failedDiamondText;
    public TMP_Text completedDiamondText;

    public float sliderSpeed = 1.0f;
    private float sliderCurrentTime;

    private int sliderInterval;
    private bool isSliderValueSelectedByUser;
Vector3 rotationEuler;
    private bool isFailed = false;
    // Start is called before the first frame update

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (GameManager.instance.gameState == GameManager.GameState.LevelFailed)
        {
            isFailed = true;
            LevelFailed.SetActive(true);
            LevelCompleted.SetActive(false);
        }
        else
        {
            isFailed = false;
            LevelFailed.SetActive(false);
            LevelCompleted.SetActive(true);
        }
    }
    void Start()
    {
        failedDiamondText.text = "22";
        completedDiamondText.text = "26";

    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (isFailed){
            rotationEuler += Vector3.forward*30*Time.deltaTime;
            failedDiamonBG.transform.rotation = Quaternion.Euler(rotationEuler);
        }else{
            rotationEuler += Vector3.forward*30*Time.deltaTime;
            completedDiamonBG.transform.rotation = Quaternion.Euler(rotationEuler);

             if (Time.time > sliderCurrentTime && isSliderValueSelectedByUser == false)
            {
                sliderCurrentTime = Time.time + sliderSpeed;
                sliderInterval += 1;

                if (sliderInterval == 5){
                    sliderInterval = 0;
                }
                bonusSlider.value = sliderInterval;

            }
        }
    }

    public void RetryGame()
    {
        GameManager.instance.SetGameState(GameManager.GameState.Dashboard);
    }
    public void GetIt()
    {
        isSliderValueSelectedByUser = true;
        Debug.Log("BONUS VALUE ==> " + bonusSlider.value);
        //GameManager.instance.SetGameState(GameManager.GameState.Game);
    }
    public void LoseIt()
    {
        GameManager.instance.SetGameState(GameManager.GameState.Dashboard);
    }
}
