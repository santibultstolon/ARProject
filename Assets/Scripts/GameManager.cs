using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] string player1Name, player2Name;
    [SerializeField] TMP_Text player1NameR, player2NameR;
    [SerializeField] GameObject finishUI,names;
    void Start()
    {
        player1Name = MenuManager.playerOneName;
        player2Name = MenuManager.playerTwoName;
        player1NameR.text = player1Name;
        player2NameR.text = player2Name;
    }


public void FinishGame()
    {
        names.SetActive(false);
        LeanTween.scale(finishUI.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.5f);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MenuCopia");
    }
}
