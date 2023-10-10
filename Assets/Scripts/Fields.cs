using UnityEngine;
using System.Collections.Generic;
using System.Transactions;
using System.Linq;

public class Fields : MonoBehaviour
{
    [SerializeField]private int fieldNumber;
    public GameObject currentObject, placedObject;
    public float contador;
    Maps mapa;
    float valorMax1;
    float valorMax2;
    float valorMin1;
    float valorMin2;
    int objNumerF;

    private void Start()
    {
        mapa = GameObject.Find("Map").GetComponent<Maps>();
    }
    private void Update()
    {
        if ( currentObject!=null&&currentObject.GetComponent<Rigidbody>().velocity.magnitude<0.1f)
        {
            contador += Time.deltaTime;
            if(contador > 3){
                if(placedObject!= null)
                {
                    if(objNumerF == 0)
                    {
                        mapa.player1Numbers[fieldNumber] = 0;
                    }
                    else
                    {
                        mapa.player2Numbers[fieldNumber] = 0;
                    }
                    Destroy(placedObject);
                    placedObject = currentObject;

                }
                objNumerF = currentObject.GetComponent<LanzarBola>().objNumber;
                Destroy(currentObject.GetComponent<LanzarBola>());
                currentObject.tag = "Out";
                currentObject.GetComponent<Rigidbody>().isKinematic = true;
                placedObject = currentObject;
                if (currentObject.GetComponent<LanzarBola>().objNumber ==0)
                {
                    mapa.player1Numbers[fieldNumber] = fieldNumber;
                    for (int i = 0;i< mapa.player1Numbers.Length; i++)
                    {
                        if (mapa.player1Numbers[i] > valorMax1)

                            valorMax1 = mapa.player1Numbers[i];


                        else if (mapa.player1Numbers[i] < valorMin1)

                            valorMin1 = mapa.player1Numbers[i];
                    }
                    for (int x = 0; x < mapa.player1Numbers.Length; x++)
                    {
                        if (mapa.player1Numbers[x] == (valorMax1 + valorMin1) / 2)

                            Debug.Log("Tres papi");

                    }
                }
                else
                {
                    mapa.player2Numbers[fieldNumber] = fieldNumber;
                    for (int i = 0; i < mapa.player2Numbers.Length; i++)
                    {
                        if (mapa.player2Numbers[i] > valorMax2)

                            valorMax2 = mapa.player2Numbers[i];


                        else if (mapa.player2Numbers[i] < valorMin2)

                            valorMin2 = mapa.player2Numbers[i];
                    }
                    for (int x = 0; x < mapa.player2Numbers.Length; x++)
                    {
                        if (mapa.player2Numbers[x] == (valorMax2 + valorMin2) / 2)

                            Debug.Log("Tres papi");

                    }
                }

                currentObject = null;
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