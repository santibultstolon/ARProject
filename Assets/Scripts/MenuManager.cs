using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{

    public static MenuManager instance; // La instancia del Singleton
    public int mapNumber;

    public GameObject selectedMap; // La variable que deseas hacer global
    public Button playButton;
    private void Start()
    {
        playButton.enabled = false;
        playerOneField.onValueChanged.AddListener(OnInputFieldValueChanged);
        playerTwoField.onValueChanged.AddListener(OnInputFieldValueChanged);
    }

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
        LeanTween.moveLocal(menuSelector, new Vector3(-1185, -170, 0), 0.5f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.scale(nameSelector.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.5f);
    }

    public void NameOK()
    {
        LeanTween.moveLocal(nameSelector, new Vector3(1099, 0, 0), 0.5f).setEase(LeanTweenType.easeInOutCubic);
        playerOneName = playerOneField.text;
        playerTwoName = playerTwoField.text;
        LeanTween.scale(mapSelector.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.5f);
    }
    public void MapSelOK()
    {
        LeanTween.scale(mapSelector.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.5f);
        SceneManager.LoadScene("Game");
    }

    public void MapSelect1()
    {
        mapNumber = 0;
        selectedMap = map[mapNumber];
        playButton.enabled = true;
    }   
    public void MapSelect2()
    {
        mapNumber = 1;
        selectedMap = map[mapNumber];
        playButton.enabled = true;
    }  
    public void MapSelect3()
    {
        mapNumber = 2;
        selectedMap = map[mapNumber];
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
