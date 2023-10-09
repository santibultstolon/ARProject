using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{

    public static string playerOneName, playerTwoName;
    [SerializeField] TMP_InputField playerOneField, playerTwoField;
    [SerializeField] GameObject mapSelector,nameSelector,menuSelector;
public void Exit()
    {
        Application.Quit();
    }

    public void Play()
    {
        LeanTween.scale(menuSelector.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.5f);
        LeanTween.scale(nameSelector.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.5f);
    }

    public void NameOK()
    {
        LeanTween.scale(nameSelector.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.5f);
        playerOneName = playerOneField.text;
        playerTwoName = playerTwoField.text;
        LeanTween.scale(mapSelector.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.5f);
    }
    public void MapSelOK()
    {
        LeanTween.scale(mapSelector.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.5f);
        SceneManager.LoadScene("Game");
    }
}
