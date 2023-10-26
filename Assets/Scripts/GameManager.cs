using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] string player1Name, player2Name;
    [SerializeField] TMP_Text player1NameR, player2NameR;
    [SerializeField] TMP_Text player1NameF, player2NameF;
    [SerializeField] GameObject finishUI,finishUI2,names;
    public GameObject[] x1, x2;
    public int winner;
    public GameObject confeti;

    public Maps mapa;
    void Start()
    {
        player1Name = MenuManager.playerOneName;
        player2Name = MenuManager.playerTwoName;
        player1NameR.text = player1Name;
        player1NameF.text = player1Name;
        player2NameR.text = player2Name;
        player2NameF.text = player2Name;
    }



    public void FinishGame()
    {
        names.SetActive(false);
        confeti.SetActive(true);
        if (winner == 1)
        {
            LeanTween.scale(finishUI.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.5f);
        }
        else if(winner == 2)
        {
            LeanTween.scale(finishUI2.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.5f);
        }


    }

    public void RestartScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MenuCopia");
    }

    public void UpdateMarkers()
    {
        for(int i = 1; i < mapa.player1Numbers.Length; i++)
        {
            if ((mapa.player1Numbers[i] == i))
            {
                x2[i].SetActive(true);
            }
            else if(mapa.player1Numbers[i] != i)
            {
                x2[i].SetActive(false);
            }
        }
        for(int i = 1; i < mapa.player2Numbers.Length; i++)
        {
            if ((mapa.player2Numbers[i] == i))
            {
                x1[i].SetActive(true);
            }
            else if(mapa.player2Numbers[i] != i)
            {
                x1[i].SetActive(false);
            }
        }
    }

}
