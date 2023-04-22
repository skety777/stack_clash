using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgress : MonoBehaviour {
	public Image LoadingBar;
	float currentValue;
	public float speed;
    public bool isStart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isStart){
            if (currentValue < 100) {
			currentValue += speed * Time.deltaTime;
		} else {
		}

		LoadingBar.fillAmount = currentValue / 100;
        }
	}
    public void startAnimation(){
        isStart = true;
        Debug.Log("Start animation");
    }
}
