using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuCopiass : MonoBehaviour
{
 // La instancia del Singleton
    public int mapNumber;

    public GameObject selectedMap; // La variable que deseas hacer global
    public Button playButton;
    private void Start()
    {
        playButton.enabled = false;
        playerOneField.onValueChanged.AddListener(OnInputFieldValueChanged);
        playerTwoField.onValueChanged.AddListener(OnInputFieldValueChanged);
    }
    [SerializeField] TMP_InputField playerOneField, playerTwoField;
    [SerializeField] GameObject mapSelector,nameSelector,menuSelector;
    public GameObject[] map;
    public void Exit()
    {
        Application.Quit();
    }

    public void Play()
    {
        LeanTween.moveLocal(menuSelector, new Vector3(-1185, -170, 0), 0.5f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.scale(nameSelector.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.5f);
    }

    public void NameOK()
    {
        LeanTween.moveLocal(nameSelector, new Vector3(1099, 0, 0), 0.5f).setEase(LeanTweenType.easeInOutCubic);
        MenuManager.playerOneName = playerOneField.text;
        MenuManager.playerTwoName = playerTwoField.text;
        LeanTween.scale(mapSelector.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.5f);
    }
    public void MapSelOK()
    {
        LeanTween.scale(mapSelector.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.5f);
        SceneManager.LoadScene("Game");
    }

    public void MapSelect1()
    {
        MenuManager.instance.mapNumber = 0;
        MenuManager.instance.selectedMap = MenuManager.instance.map[MenuManager.instance.mapNumber];
        playButton.enabled = true;
    }   
    public void MapSelect2()
    {
        MenuManager.instance.mapNumber = 1;
        MenuManager.instance.selectedMap = MenuManager.instance.map[MenuManager.instance.mapNumber];
        playButton.enabled = true;
    }
    private void OnInputFieldValueChanged(string newValue)
    {
        // Verifica la longitud del texto actual y lo ajusta si es necesario.
        if (newValue.Length > 7)
        {
            // Verifica cuál de los dos InputFields desencadenó el evento y ajusta su valor.
            if (playerOneField.isFocused)
            {
                playerOneField.text = newValue.Substring(0, 7);
            }
            else if (playerTwoField.isFocused)
            {
                playerTwoField.text = newValue.Substring(0, 7);
            }
        }
    }
}
