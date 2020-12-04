using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButtonController : MonoBehaviour
{

    bool click, answer;
    public GameObject clickOnSound;
    private GameObject[] wrongAnswers;
    private GameObject clickSound;


    // Start is called before the first frame updatevoid OnMouseDown()
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>(); // rend se usa para el fadeOff del boton al presionar

    }
     void Update()
    {


        if ((int)Text.tiempoRespuesta == 0 || click)
        {
            // sonido click para saber que se elimino respuesta
            clickSound = Instantiate(clickOnSound);
            clickSound.GetComponent<AudioSource>().Play();


            //todas las "wrongAnswer"
            wrongAnswers = GameObject.FindGameObjectsWithTag("wrongAnswer");
     
            // destruye random respuesta errada si hacemos click en el helpbutton
                int i = Random.Range(0,(wrongAnswers.Length));
                respuestasController.paraDestruir = wrongAnswers[i];
      
                Text.points--;
                Text.tiempoRespuesta = 30;

                click = false;
            
        }
    }
    void OnMouseDown()
    {

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

    }

    // esta funcion nos avisa cuando salimos del boton
    void OnMouseExit()
    {
        rend.material.color = Color.white;

    }

}


