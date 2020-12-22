using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardadorNivel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         Debug.Log(PlayerPrefs.GetInt("NIVEL", MainController.nivel));
        Debug.Log("paso por aca");
    }


    void Update()
    {

        PlayerPrefs.SetInt("NIVEL", MainController.nivel);
        PlayerPrefs.Save();
        Debug.Log("paso por aca1");
    }
}
