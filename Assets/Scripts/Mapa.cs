using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    public GameObject objectToThrow;
    public GameObject puntoLanzamiento;
    void Start()
    {
        puntoLanzamiento = GameObject.Find("HuecoObjeto");
        StartCoroutine("InstanciarObjeto");
    }

    // Update is called once per frame

    IEnumerator InstanciarObjeto()
    {
        yield return new WaitForSeconds(10);
        GameObject nuevaPelota = Instantiate(objectToThrow, puntoLanzamiento.transform.transform.transform.position, puntoLanzamiento.transform.rotation, puntoLanzamiento.transform);
    }
}
