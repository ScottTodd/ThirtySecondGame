using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;

    public float timeForGame = 30.0f;
    private float startTime;

    public GameObject tileGrid;

    public bool gameStarted = false;
    public bool gameOver = false;
    private GUIText endText;

    // Use this for initialization
    void Start () {
        endText = gameObject.GetComponentInChildren<GUIText>();

        player1.SetActive(false);
        player2.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (gameOver || !gameStarted) {
            return;
        }

        PlayerController player1Controller = player1.GetComponent<PlayerController>();
        PlayerController player2Controller = player2.GetComponent<PlayerController>();

        if (!player1Controller.alive && !player2Controller.alive) {
            endText.text = "Double knockout!";
            gameOver = true;
            return;
        }

        if (player1Controller.alive && !player2Controller.alive) {
            endText.text = "Player 1 Wins!";
            gameOver = true;
            return;
        }

        if (player2Controller.alive && !player1Controller.alive) {
            endText.text = "Player 2 Wins!";
            gameOver = true;
            return;
        }

        if (Time.time - startTime > 30.0f) {
            endText.text = "It's a tie!";
            gameOver = true;
            return;
        }
    }

    void OnGUI () {
        if (!gameStarted) {
            if (GUI.Button(new Rect(Screen.width/2.0f - 150, Screen.height/2.0f - 50, 300, 100), "Start Game")) {
                gameStarted = true;
                startTime = Time.time;

                GridController gridControllerScript = (GridController) tileGrid.GetComponent<GridController>();
                gridControllerScript.StartGame();
                player1.SetActive(true);
                player2.SetActive(true);

                PlayerController player1Script = (PlayerController) player1.GetComponent<PlayerController>();
                PlayerController player2Script = (PlayerController) player2.GetComponent<PlayerController>();

                player1Script.alive = true;
                player2Script.alive = true;
            }
        }
    }
}
