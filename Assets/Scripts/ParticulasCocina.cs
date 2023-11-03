using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulasCocina : MonoBehaviour
{
    public GameObject particulas;
    public void EfectoCocina()
    {
        particulas.SetActive(true);
    }
}
