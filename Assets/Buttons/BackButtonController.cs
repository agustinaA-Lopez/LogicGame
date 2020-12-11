using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonController : MonoBehaviour
{

    bool click, answer;

    public static bool PushButton;
    public GameObject ClickOnSoundObj;
    public static int NivelPrevio;

    // GameObject pressedButton;
    // Start is called before the first frame updatevoid OnMouseDown()
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>(); // rend se usa para el fadeOff del boton al presionar

    }

    void OnMouseDown()
    {
        //sound on click
        GameObject clickOnSound = Instantiate(ClickOnSoundObj);
        clickOnSound.GetComponent<AudioSource>().Play();
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

        if (rend.material.color.r <= .5F && click)
        {
            MainController.nivel = NivelPrevio;

            MainController.backButton = true;

            click = false;
        }


    }

    // esta funcion nos avisa cuando salimos del boton
    void OnMouseExit()
    {

        rend.material.color = Color.white;

    }


}


