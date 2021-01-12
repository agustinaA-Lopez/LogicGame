using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silelenceGameButtonController : MonoBehaviour
{
    bool click, answer;
    public Renderer rend;
    public GameObject ClickOnSoundObj;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>(); // rend se usa para el fadeOff del boton al presionar

    }

    void OnMouseDown()
    {
        //sound on click
    
        GameObject clickOnSound = Instantiate(ClickOnSoundObj);
        clickOnSound.GetComponent<AudioSource>().Play();
        Vibration.Vibrate(1);

        click = true;
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
       

        // si ya hicimos click y se completo el proceso de fadeOff damos aviso a wheelButton que el boton fue presionado
       if (rend.material.color.r <= .5F && click)
        {
            if (!MainController.silenceGame){
                 MainController.silenceGame = true; 
            } else MainController.silenceGame = false;
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
