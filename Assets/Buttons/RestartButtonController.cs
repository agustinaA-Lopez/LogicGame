using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButtonController: MonoBehaviour
{
    bool click, answer;
    public Renderer rend;

    public GameObject ClickOnSoundObj;


    void Start()
    {
        rend = GetComponent<Renderer>(); // rend se usa para el fadeOff del boton al presionar

    }


    void OnMouseDown()
    {
        //sound on click
        if (!MainController.silenceGame) 
        {
            GameObject clickOnSound = Instantiate(ClickOnSoundObj);
            clickOnSound.GetComponent<AudioSource>().Play();
            Vibration.Vibrate(1);
            //para ir a juego nuevo
            PlayerPrefs.SetInt("NIVEL", 0);
            PlayerPrefs.SetInt("PUNTOS", 0);
            Text.points = 0;
            Text.tiempoRespuesta = 59;
        }

        click =true;
        
    }
    //esta funcion chequea cuando entramos al area del boton
    void OnMouseEnter()
    {

        //ya explicamos rend para el fadeOff
        rend.material.color = Color.white;

    }




    void OnMouseOver()
    {

        if (rend.material.color.r > .2) rend.material.color -= new Color(.01f, 0, 0) * Time.deltaTime * 120;     

        // si ya hicimos click y se completo el proceso de fadeOff damos aviso a play que el boton fue presionado
       if (rend.material.color.r <= .5F && click)
        {

            MainController.clickOn = true;
           if ((PlayerPrefs.GetInt("NIVEL", MainController.nivel)!= 0) )
           {
                MainController.nivel = PlayerPrefs.GetInt("NIVEL", MainController.nivel);
                Text.points = PlayerPrefs.GetInt("PUNTOS", Text.points);
           } 
           if (MainController.nivel == 32) {MainController.nivel =0; Text.points = 0;}
           else MainController.nivel =1;
            //MainController.nivel ++;
            click = false;

        }
    }

    // esta funcion nos avisa cuando salimos del boton
    void OnMouseExit()
    {
        //transform.localScale = new Vector3()
        rend.material.color = Color.white;
      

    }

}
