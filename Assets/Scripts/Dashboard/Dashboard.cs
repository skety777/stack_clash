using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dashboard : MonoBehaviour
{
    public LevelManager levelManager;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        
    }
    public void StartGame(){
        //SceneManager.LoadScene("GamePlay");
        GameManager.instance.SetGameState(GameManager.GameState.Dashboard) ;
    }
}
