using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    public static float tiempoRespuesta = 30;

    public GameObject Puntos, Tiempo, dingObj;
    GameObject Ding;

    public static int points = 0;


    // Update is called once per frame
    void Update()
    {




        //hace que no empiece el tiempo hasta que salga del inicio

        if (MainController.nivel > 0)
        {
            Puntos.GetComponent<TMPro.TextMeshProUGUI>().text = ((int)points).ToString();
            tiempoRespuesta -= Time.deltaTime;

            Tiempo.GetComponent<TMPro.TextMeshProUGUI>().text = ((int)tiempoRespuesta).ToString();
            if ((int)tiempoRespuesta == 0)
            {
                // sonido Ding
                Ding = Instantiate(dingObj);
                Ding.GetComponent<AudioSource>().Play();

               
                tiempoRespuesta = 30;

                // sucede lo mismo que cuando apretamos help
                HelpButtonController.click = true;
                
        }
        }
        if (MainController.nivel == -1)
        {
            Puntos.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            Tiempo.GetComponent<TMPro.TextMeshProUGUI>().text = "";

        }



    }
}
