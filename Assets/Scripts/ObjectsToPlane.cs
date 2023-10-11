using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ARRaycastManager))]
public class ObjectsToPlane : MonoBehaviour
{
    bool haPuestoCastillo;

    [SerializeField]

    //Plano detectado
    GameObject placedPrefab;

    //Prefab a instanciar
    GameObject spawnedObject;

    //Variable control input Touch
    bool touch;
    ObjectsToPlane scriptADestruir;
    PlayerInput _input;
    public GameObject rotatione;

    ARRaycastManager aRRaycastManager;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Start()
    {
        SceneManager.UnloadSceneAsync("Menu");
        placedPrefab = MenuManager.instance.selectedMap;
        scriptADestruir = GetComponent < ObjectsToPlane > ();
        _input = GetComponent < PlayerInput > ();
    }
    void Update()
    {
        if (touch)
        {
            // Almacena la posición actual del input Touch
            var touchPosition = Pointer.current.position.ReadValue();

            //Instanciar solo un prefab
            ////Chequea el raycast hit si colisiona con un "TrackableType"
            //if (aRRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            //{
            //    //Los impactos de Raycast se ordenan por distancia, por lo que el primer impacto significa el más cercano
            //    var hitPose = hits[0].pose;

            //    //Comprueba si ya hay un objeto generado, si no hay ninguno, se crea una instancia del prefab
            //    if (spawnedObject == null)
            //    {
            //        spawnedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
            //    }
            //    else
            //    {
            //        //Cambia la posición del objeto generado y la rotación a la posición táctil.
            //        spawnedObject.transform.position = hitPose.position;
            //        spawnedObject.transform.rotation = hitPose.rotation;
            //    }

            //    //Para que el objeto generado siempre mire a la cámara. Eliminar si no es necesario
            //    Vector3 lookPos = Camera.main.transform.position - spawnedObject.transform.position;
            //    lookPos.y = 0;
            //    spawnedObject.transform.rotation = Quaternion.LookRotation(lookPos);
            //}

            //Instanciar en cada toque de pantalla
            //Chequea el raycast hit si colisiona con un "TrackableType"
            if (aRRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                //Los impactos de Raycast se ordenan por distancia, por lo que el primer impacto significa el más cercano
                var hitPose = hits[0].pose;

                //Guarda la instancia del prefab
                spawnedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
                float rotationi = hitPose.position.y - transform.position.y;
                spawnedObject.transform.Rotate(new Vector3(transform.rotation.x, rotationi, transform.rotation.z));
                spawnedObject.name = "Map";
                haPuestoCastillo = true;
            }
        }
        touch = false;
        if (haPuestoCastillo)
        {

            Destroy(scriptADestruir);
            Destroy(_input);

        }
        }
    public void Touch(InputAction.CallbackContext callbackContext)
    {
        if (!haPuestoCastillo)
        {
            if (callbackContext.performed)
            {
                touch = true;
            }
        }

    }
}
