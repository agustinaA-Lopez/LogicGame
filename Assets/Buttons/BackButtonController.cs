using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonController : MonoBehaviour
{

    bool click, answer;
    public GameObject clickOnSound;
    public static bool use, PushButton;
    public static int NivelPrevio;

    // GameObject pressedButton;
    // Start is called before the first frame updatevoid OnMouseDown()
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>(); // rend se usa para el fadeOff del boton al presionar
        use = false;


    }
    void Update()
    {


    }
    void OnMouseDown()
    {

        //sound on click
        GameObject clickSound;
        clickSound = Instantiate(clickOnSound);
        clickSound.GetComponent<AudioSource>().Play();

        //te devuelve al nivel donde estabas apretando Back
        MainController.nivel = NivelPrevio;
        MainController.instanciar = true;
        PushButton = true;

        if (NivelPrevio > 0)
        {
            MainController.instanciadorNivel = true;
            MainController.nivel--;
            MainController.rightAnswer = true;
        }


        //click = true;

        SpriteRenderer mySR = GetComponent<SpriteRenderer>();


    }
    //esta funcion chequea cuando entramos al area del boton
    void OnMouseEnter()
    {
        //cuando estamos sobre el boton avisamos que esta siendo usado

        //ya explicamos rend para el fadeOff
        rend.material.color = Color.white;
    }




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


