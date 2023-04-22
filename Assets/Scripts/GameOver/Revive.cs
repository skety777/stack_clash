using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Revive : MonoBehaviour
{
    public Button skipButton;
    public RadialProgress progressBar;
    // Start is called before the first frame update
    
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        //progressBar = GameObject.FindObjectOfType<RadialProgress>();
    }
    public void reviveEnable(){
        Debug.Log("Show Skip Call");
        showSkipButton();
        gameObject.SetActive(true);
        progressBar.startAnimation();
    }
    public void skip(){

    }
    public IEnumerator showSkipButton()
    {
        Debug.Log("Show Skip 1");
        yield return new WaitForSeconds(5.0f);
        Debug.Log("Show Skip 2");
        skipButton.gameObject.SetActive(true);
    }
}
