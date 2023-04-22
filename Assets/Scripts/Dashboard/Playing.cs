using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TapToStart(){
        gameObject.SetActive (false);
        GameManager.instance.SetGameState(GameManager.GameState.Game);
    }
    public void InAppPurchase(){
        
    }
    public void SkinShop(){
        
    }
    public void Leaderboard(){
        
    }
    public void Setting(){
        
    }
}
