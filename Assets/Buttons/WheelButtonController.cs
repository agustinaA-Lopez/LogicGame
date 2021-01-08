using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelButtonController : MonoBehaviour
{
    public static bool click, use;
    public Renderer rend;

    public GameObject ClickOnSoundObj;

    void Start()
    {
        rend = GetComponent<Renderer>(); // rend se usa para el fadeOff del boton al presionar
        use = false;
    }


    void OnMouseDown()
    {
        //sound on click
        if (!MainController.silenceGame) 
        {
            GameObject clickOnSound = Instantiate(ClickOnSoundObj);
            clickOnSound.GetComponent<AudioSource>().Play();
            Vibration1.Vibrate(1);
        }
        click = true;

    }

    //esta funcion chequea cuando entramos al area del boton
    void OnMouseEnter()
    {
        //cuando estamos sobre el boton avisamos que esta siendo usado
        use = true;
        //ya explicamos rend para el fadeOff
        rend.material.color = Color.white;
    }




    void OnMouseOver()
    {

        if (rend.material.color.r > .2) rend.material.color -= new Color(.01f, 0, 0) * Time.deltaTime * 120;

        // si ya hicimos click y se completo el proceso de fadeOff damos aviso a wheelButton que el boton fue presionado
       if (rend.material.color.r <= .5F && click)
        {


            MainController.instanciadorNivel = true;

            
            click = false;
            

        }


    }

    // esta funcion nos avisa cuando salimos del boton
    void OnMouseExit()
    {
        //transform.localScale = new Vector3()
        rend.material.color = Color.white;
        use = false;

    }




}



