using UnityEngine;
using System.Collections;

public class StartGameGUI : MonoBehaviour
{
    void Start() {

    }

    void Update() {

    }
    
    void OnGUI () {
        if (GUI.Button(new Rect(Screen.width/2.0f - 150, Screen.height/2.0f - 50, 300, 100), "Start Game")) {
            Application.LoadLevel("MainScene");
        }
    }
}
