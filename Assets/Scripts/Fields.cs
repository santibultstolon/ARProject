using UnityEngine;
using System.Collections.Generic;

public class Fields : MonoBehaviour
{

    public GameObject currentObject, placedObject;
    public float contador;


    private void Update()
    {
        if ( currentObject!=null&&currentObject.GetComponent<Rigidbody>().velocity.magnitude<0.1f)
        {
            contador += Time.deltaTime;
            if(contador > 3){
                if(placedObject!= null)
                {
                    Destroy(placedObject);
                    placedObject = currentObject;

                }
                Destroy(currentObject.GetComponent<LanzarBola>());
                currentObject.tag = "Out";
                currentObject.GetComponent<Rigidbody>().isKinematic = true;
                placedObject = currentObject;
                currentObject = null;
                Maps mapa = GameObject.Find("Map").GetComponent<Maps>();
                mapa.ChangeTurn();
                contador= 0;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (placedObject != null)
        {
            currentObject = collision.gameObject;
        }
        if (collision.gameObject.CompareTag("Object"))
        {
            
            currentObject = collision.gameObject;

            Debug.Log(currentObject.name);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            currentObject = null;

            contador = 0;
        }
    }
}