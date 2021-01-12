using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButtonController : MonoBehaviour
{

    bool answer;
    public static bool click;

    private GameObject[] wrongAnswers;

    public GameObject ClickOnSoundObj;


    // Start is called before the first frame updatevoid OnMouseDown()
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>(); // rend se usa para el fadeOff del boton al presionar

    }
     void Update()
    {


        if (click)
        {




            
        }
    }
    void OnMouseDown()
    {

        click = true;
        // sonido click para saber que se elimino respuesta
        if (!MainController.silenceGame) 
        {
            GameObject clickOnSound = Instantiate(ClickOnSoundObj);
            clickOnSound.GetComponent<AudioSource>().Play();
           Vibration.Vibrate(1);
        }
        click = true;

    }


    //esta funcion chequea cuando entramos al area del boton
    void OnMouseEnter()
    {
        
        //ya explicamos rend para el fadeOff
        rend.material.color = Color.white;
    }



    // avisa cuando estamos sobre el collider(boton)
    void OnMouseOver()
    {

        if (rend.material.color.r > .2) rend.material.color -= new Color(.01f, 0, 0) * Time.deltaTime * 120;

                    //todas las "wrongAnswer"
            wrongAnswers = GameObject.FindGameObjectsWithTag("wrongAnswer");
     
     if ((rend.material.color.r <= .5F && click) || Text.timeOut)

        {
            // destruye random respuesta errada si hacemos click en el helpbutton
                int i = Random.Range(0,(wrongAnswers.Length-1));
                 
                if (wrongAnswers.Length >2) respuestasController.paraDestruir = wrongAnswers[i]; 
                else 
                {
                    MainController.clickOn = true;
                    MainController.nivel++;
                } 
      
                Text.points--;
                Text.tiempoRespuesta = 30;

                click = false;
                Text.timeOut = false;
        }

    }

    // esta funcion nos avisa cuando salimos del boton
    void OnMouseExit()
    {
        rend.material.color = Color.white;

    }

}


