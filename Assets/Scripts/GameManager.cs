using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] string player1Name, player2Name;
    [SerializeField] TMP_Text player1NameR, player2NameR;
    void Start()
    {
        player1Name = MenuManager.playerOneName;
        player2Name = MenuManager.playerTwoName;
        player1NameR.text = player1Name;
        player2NameR.text = player2Name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
