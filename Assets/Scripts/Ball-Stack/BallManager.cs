using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject ball;

    private StackCreator stackCreator;

    public ConfettiAnimation confetti;

    public bool isThrow = true;
    private float nextFire;

    public float force = 5000;
    public float fireRate;

    public bool isAnimationPlayed = false;

    private bool isGameOver = false;

    private float currentIntervalTime;
    public float interval;
    private bool isGameStarted;

    // Start is called before the first frame update
    void Start()
    {
        confetti = GameObject.FindObjectOfType<ConfettiAnimation>();
        stackCreator = GameObject.FindObjectOfType<StackCreator>();
        GameManager.onGameStateChanged += GameStateChanged;
    } 
    void GameStateChanged(GameManager.GameState gameState){
        Debug.Log("started game ==> " + gameState);

        if (gameState == GameManager.GameState.Game)
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();
            rb.useGravity = true;
            isGameStarted = true;
        }
    }
    // Update is called once per frame
    void Update()
    {

       if (isGameStarted)
       {
         // Handle screen touches.
        if (transform.position.y < 2)
        {
            if (isGameOver == false){
                isGameOver = true;
            Debug.Log("GAME OVER");
            Debug.Log("Broken ==> " + stackCreator.GetBreakPercentage());
            }
            Rigidbody rb = this.GetComponent<Rigidbody>();
            rb.useGravity = false;
            if (isAnimationPlayed == false)
            {
                // isAnimationPlayed = true;
                // Debug.Log("Play Animation");
                // confetti.playAnimation();
                // gm.GameOver();

            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject newBall = Instantiate(ball, transform.position, Quaternion.identity);
                Rigidbody gameObjectsRigidBody = newBall.GetComponent<Rigidbody>();
                gameObjectsRigidBody.AddForce(new Vector3(5000, 0, 0), ForceMode.Force);
                gameObjectsRigidBody.mass = 1.0f;
            }

        }
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject newBall = Instantiate(ball, transform.position, Quaternion.identity);
            Rigidbody gameObjectsRigidBody = newBall.GetComponent<Rigidbody>();
            gameObjectsRigidBody.AddForce(new Vector3(force, 0, 0), ForceMode.Force);
            gameObjectsRigidBody.mass = 1.0f;
        }
       }
    }
}
