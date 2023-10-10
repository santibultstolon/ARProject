using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public static int turn;
    [SerializeField] int mapNumber;
    public GameObject[] map;
    public GameObject[] objects;
    public GameObject[] fields;
    void Start()
    {
        turn = 0;
    }

    private void Update()
    {
        
    }
}
