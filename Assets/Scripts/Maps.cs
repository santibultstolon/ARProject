using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maps : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject puntoLanzamiento;
    public int turn;
    [SerializeField] int mapNumber;
    public GameObject[] fields;
    public int[] player2Numbers = new int[10];
    public int[] player1Numbers = new int[10];
    public float valorMax1;
    public float valorMax2;
    public float valorMin1;
    public float valorMin2;
    public int primera1, primera2;
    void Start()
    {
        primera1 = 1;
        primera2 = 1;
        puntoLanzamiento = GameObject.Find("HuecoObjeto");
        StartCoroutine("InstanciarObjeto");
        turn = 0;
        Debug.Log("Funsiona");
    }

    IEnumerator InstanciarObjeto()
    {
        yield return new WaitForSeconds(3);
        GameObject nuevaPelota = Instantiate(objects[PlayManager.turn], puntoLanzamiento.transform.transform.transform.position, puntoLanzamiento.transform.rotation, puntoLanzamiento.transform);
    }

    public void ChangeTurn()
    {
        if (puntoLanzamiento.transform.childCount == 0)
        {
            turn++;
            if (turn > 1)
            {
                turn = 0;
            }
            GameObject nuevaPelota = Instantiate(objects[turn], puntoLanzamiento.transform.transform.transform.position, puntoLanzamiento.transform.rotation, puntoLanzamiento.transform);
        }

    }
}
