using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentLevel = 1;
    private LevelList allLevels;
    public Level currentLevelObj;
    public static LevelManager instance{ get; private set; }
    void Awake()
    {
         

        getLevels();
        int levelValue = PlayerPrefs.GetInt("level");
        if (levelValue == 0)
        {
            PlayerPrefs.SetInt("levels", currentLevel);
        }
        else
        {
            currentLevel = levelValue;
        }
       currentLevel = 1;
        foreach (Level lv in allLevels.Levels)
        {
            if (lv.maxLevel >= currentLevel)
            {
                currentLevelObj = lv;
                break;
            }
        }
        Debug.Log("Current Level: " + currentLevelObj.maxLevel + "  Current DiamonRatio: " + currentLevelObj.diamondRatio);
        if (instance != null && instance != this) 
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void getLevels()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("level");

        LevelList employeesInJson = JsonUtility.FromJson<LevelList>(textAsset.text);
        allLevels = employeesInJson;
        foreach (Level lv in employeesInJson.Levels)
        {
            Debug.Log("Level: " + lv.maxLevel + "  DiamonRatio: " + lv.diamondRatio);
        }
    }
}
[System.Serializable]
public class Level
{
    public int maxLevel;
    public int name;
    public int minRange;
    public int maxRange;
    public float diamondRatio;
    public int dangerCubeMin;
    public int dangerCubeMax;

    public int completion;
}

[System.Serializable]

public class LevelList
{
    public List<Level> Levels;
}
