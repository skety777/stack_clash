using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class StackCreator : MonoBehaviour
{
    public MainCube comonPrefab;
    public MainCube dangerPrefab;
    public GameObject diamond;
    List<GameObject> allCubes;

    public Level currentLevelObj;
    private int[] stackArrangement = new int[200];

    private static int cc = 0;
    private static int dc = 1;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Application.targetFrameRate = 60;

        currentLevelObj = LevelManager.instance.currentLevelObj;
    }
    // Start is called before the first frame update
    void Start()
    {
        //     Vector3 cubePosition = Vector2.zero;
        //    for (int i = 0; i < 5; i++)
        //    {
        //         MainCube cube = Instantiate(comonPrefab, cubePosition, Quaternion.identity, transform);
        //         cubePosition.y += cube.GetLength();
        //    }
        CreateStack();
    }
    void CreateStack()
    {
        int minRange = currentLevelObj.minRange;
        int maxRange = currentLevelObj.minRange;
        float diamondRatio = currentLevelObj.minRange;
        int dangerCubeMin = currentLevelObj.minRange;
        int dangerCubeMax = currentLevelObj.minRange;


        int indexCounter = 0;
        do
        {

            float randomCommonCube = Random.Range(currentLevelObj.minRange, (currentLevelObj.maxRange + 1));
            for (int i = 0; i < randomCommonCube; i++)
            {
                stackArrangement[indexCounter] = cc;
                indexCounter = indexCounter + 1;
            }
            float randomDangerCube = 1;
            if (currentLevelObj.dangerCubeMin == currentLevelObj.dangerCubeMax)
            {
                randomDangerCube = currentLevelObj.dangerCubeMax;
            }
            else
            {
                randomDangerCube = Random.Range(currentLevelObj.dangerCubeMin, (currentLevelObj.dangerCubeMax + 1));
            }

            for (int i = 0; i < randomDangerCube; i++)
            {
                stackArrangement[indexCounter] = dc;
                indexCounter = indexCounter + 1;
            }
        } while (indexCounter <= 100);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < stackArrangement.Length; i++)
        {
            sb.Append(stackArrangement[i]);
            sb.Append(" ");
        }
        Debug.Log(sb.ToString());
        Vector3 cubePosition = Vector2.zero;
        for (int i = 1; i < 100; i++)
        {
            float randomNumber = Random.Range(0, 10);
            int type = stackArrangement[i];
            if (type == dc)
            {

                MainCube cube = Instantiate(dangerPrefab, cubePosition, Quaternion.Euler(90, 0, 0), transform);

                cubePosition.y += cube.GetLength() + 0;
                //Instantiate(diamond, diamPos, Quaternion.Euler(0, 0, 0));

            }
            else
            {
                MainCube cube = Instantiate(comonPrefab, cubePosition, Quaternion.Euler(90, 0, 0), transform);
                cubePosition.y += cube.GetLength() + 0;

            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void removeCubeFromArray(GameObject obj)
    {
        allCubes.Remove(obj);
        Debug.Log(allCubes.Count);
    }
    public bool GetBreakPercentage()
    {
        int totalCommonCube = 0;
        int remainingCube = 0;
        for (int i = 0; i < stackArrangement.Length; i++)
        {
            if (i == 100)
            {
                break;
            }
            int val = stackArrangement[i];
            if (val == cc)
            {
                totalCommonCube += 1;
            }
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform stack = transform.GetChild(i);
            if (stack.gameObject.tag == "red")
            {
                remainingCube += 1;
            }
        }
        Debug.Log("Total ==> " + totalCommonCube);
        Debug.Log("Remaining ==> " + remainingCube);
        int brokenCube = totalCommonCube - remainingCube;
        int percentage = brokenCube * 100 / totalCommonCube;
        GameManager.instance.levelCompletion = percentage;
        if (currentLevelObj.completion <= percentage){
            GameManager.instance.SetGameState(GameManager.GameState.LevelCompleted);
            return true;
        }else{
            GameManager.instance.SetGameState(GameManager.GameState.LevelFailed);
            return false;
        }
    }
}
