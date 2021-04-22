using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Player1;
    public Text Player2;

    public static int scoreValue1 = 0;
    public static int scoreValue2 = 0;

  

   
    void Update()
    {
        Player1.text = "PLAYER 01: " + scoreValue1;
        Player2.text = "PLAYER 02: " + scoreValue2;
    }
}
