using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{

    public static MenuManager instance; // La instancia del Singleton

    public GameObject selectedMap; // La variable que deseas hacer global

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Establece esta instancia como la instancia única
            DontDestroyOnLoad(gameObject); // Evita que el objeto se destruya al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Si ya hay una instancia, destruye esta
        }
    }
    public static string playerOneName, playerTwoName;
    [SerializeField] TMP_InputField playerOneField, playerTwoField;
    [SerializeField] GameObject mapSelector,nameSelector,menuSelector;
    public GameObject[] map;
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
