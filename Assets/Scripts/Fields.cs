using UnityEngine;
using System.Collections.Generic;
using System.Transactions;
using System.Linq;
using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine.UIElements;

public class Fields : MonoBehaviour
{
    [SerializeField]private int fieldNumber;
    public GameObject currentObject, placedObject;
    public float contador;
    GameObject[] sensore = new GameObject[10];
    Maps mapa;
    
    int objNumerF;
    GameManager manager;

    private void Start()
    {
        sensore[1] = GameObject.Find("1");
        sensore[2] = GameObject.Find("2");
        sensore[3] = GameObject.Find("3");
        sensore[4] = GameObject.Find("4");
        sensore[5] = GameObject.Find("5");
        sensore[6] = GameObject.Find("6");
        sensore[7] = GameObject.Find("7");
        sensore[8] = GameObject.Find("8");
        sensore[9] = GameObject.Find("9");
        
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        mapa = GameObject.Find("Map").GetComponent<Maps>();
    }
    public IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(2f);
        manager.FinishGame();
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
                if (objNumerF ==0)
                {

                    
                    mapa.player1Numbers[fieldNumber] = fieldNumber;
                        if(mapa.primera1 !=1)
                        {
                            if (fieldNumber > mapa.valorMax1)

                                mapa.valorMax1 = fieldNumber;


                            else if (fieldNumber < mapa.valorMin1)

                                mapa.valorMin1 = fieldNumber;
                        }
                        else if(mapa.primera1 ==1)
                        {
                            mapa.valorMax1 = fieldNumber;
                            mapa.valorMin1 = fieldNumber;
                            mapa.primera1 = 0;
                        }
                    /*for (int x = 0; x < mapa.player1Numbers.Length; x++)
                    {
                        if ((mapa.player1Numbers[x] == (mapa.valorMax1 + mapa.valorMin1) / 2)&&mapa.valorMax1!=mapa.valorMin1)
                        {
                            Debug.Log("Player1");
                            StartCoroutine("FinishGame");
                        }



                    }*/
                    CheckWinner();
                }
                else
                {
                    mapa.player2Numbers[fieldNumber] = fieldNumber;
                    if (mapa.primera2 != 1)
                    {
                        if (fieldNumber > mapa.valorMax2)

                            mapa.valorMax2 = fieldNumber;


                        else if (fieldNumber < mapa.valorMin2)

                            mapa.valorMin2 = fieldNumber;
                    }
                    else if (mapa.primera2 == 1)
                    {
                        mapa.valorMax2 = fieldNumber;
                        mapa.valorMin2 = fieldNumber;
                        mapa.primera2 = 0;
                    }

                    for (int x = 0; x < mapa.player2Numbers.Length; x++)
                    {
                        if ((mapa.player2Numbers[x] == (mapa.valorMax2 + mapa.valorMin2) / 2) && mapa.valorMax2 != mapa.valorMin2)
                        {
                            Debug.Log("Player2");
                            StartCoroutine("FinishGame");
                        }


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

    public void CheckWinner()
    {

        for (int i =0;i< mapa.player1Numbers.Length;i++)
        {
            if (mapa.player1Numbers[i] != 0)
            {
                RaycastHit hitInfo;
                Vector3 direction =sensore[i].transform.position- sensore[fieldNumber].transform.position;

                Debug.Log("[" + fieldNumber + "-" + i + "]");
                if (Physics.Raycast(sensore[fieldNumber].transform.position, direction, out hitInfo, direction.magnitude))
                {
                    if(hitInfo.collider.gameObject != sensore[fieldNumber] && hitInfo.collider.gameObject != sensore[i].gameObject)
                    {
                        Debug.Log(hitInfo.collider.gameObject.name);
                        if (mapa.player1Numbers.Contains(int.Parse(hitInfo.collider.gameObject.name)))
                        {
                            StartCoroutine("FinishGame");
                        }

                    }
                   
                }
            }
        }

    }
}