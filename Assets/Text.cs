using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    public static float tiempoRespuesta = 30;

    public GameObject Puntos, Tiempo;
    public static int points=0;


    // Update is called once per frame
    void Update()
    {


        

        //hace que no empiece el tiempo hasta que salga del inicio
       
        if (MainController.nivel > 0)
        {
            Puntos.GetComponent<TMPro.TextMeshProUGUI>().text = ((int)points). ToString();
            tiempoRespuesta -= Time.deltaTime;
            
            Tiempo.GetComponent<TMPro.TextMeshProUGUI>().text = ((int)tiempoRespuesta).ToString();
            if ((int)tiempoRespuesta == 0) tiempoRespuesta = 30;
            if (MainController.respuesta != 0) tiempoRespuesta = 29;
        }



    }
}
