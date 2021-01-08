using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    public static float tiempoRespuesta = 30;

    public GameObject Puntos, Tiempo, dingObj;
    GameObject Ding;

    public static int points = 0;

    public static bool timeOut = false;


    // Update is called once per frame
    void Update()
    {




        //hace que no empiece el tiempo hasta que salga del inicio

        if (MainController.nivel > 0)
        {
            Puntos.GetComponent<TMPro.TextMeshProUGUI>().text = ((int)points).ToString();
            tiempoRespuesta -= Time.deltaTime;

            Tiempo.GetComponent<TMPro.TextMeshProUGUI>().text = ((int)tiempoRespuesta).ToString();

            if (!MainController.silenceGame) 
            {
                if (!GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Play();
            }



            if ((int)tiempoRespuesta == 0)
            {
                // sonido Ding
                if (!MainController.silenceGame)
                {
                    Ding = Instantiate(dingObj);
                    Ding.GetComponent<AudioSource>().Play();
                }


                points--;

               
                tiempoRespuesta = 30;

                // sucede lo mismo que cuando apretamos help
                timeOut = true;

                
        }
        }

    }
}
