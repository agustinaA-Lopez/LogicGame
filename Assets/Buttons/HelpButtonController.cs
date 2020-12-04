using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButtonController : MonoBehaviour
{

    bool click, answer;
    public GameObject clickOnSound, wrongAnswer;
    private GameObject[] wrongAnswers;
    public static bool use;

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


        if ((int)Text.tiempoRespuesta == 0)
        {

            wrongAnswer = GameObject.FindGameObjectWithTag("wrongAnswer");
      
                Destroy(wrongAnswer);
                Text.points--;
                Text.tiempoRespuesta = 30;
            
        }
    }
    void OnMouseDown()
    {

        //sound on click
        GameObject clickSound;
        clickSound = Instantiate(clickOnSound);
        clickSound.GetComponent<AudioSource>().Play();

        //click = true;

        SpriteRenderer mySR = GetComponent<SpriteRenderer>();


        wrongAnswers = GameObject.FindGameObjectsWithTag("wrongAnswer");
     
            // destruye la respuesta errada si hacemos click en el wheelButton
                int i = Random.Range(0,(wrongAnswers.Length));
                respuestasController.paraDestruir = wrongAnswers[i];

                Text.tiempoRespuesta = 30;
                Text.points--;
                // MainController.wheelButton = false;
                // MainController.rightAnswer = false;
                // Text.points--;
                // break;

            
            //}
        // }



    }
    //esta funcion chequea cuando entramos al area del boton
    void OnMouseEnter()
    {
        //cuando estamos sobre el boton avisamos que esta siendo usado
        //use = true;
        //ya explicamos rend para el fadeOff
        rend.material.color = Color.white;
    }




    void OnMouseOver()
    {

        if (rend.material.color.r > .2) rend.material.color -= new Color(.01f, 0, 0) * Time.deltaTime * 120;

        // si ya hicimos click y se completo el proceso de fadeOff damos aviso a wheelButton que el boton fue presionado
       // if (rend.material.color.r <= .5F && click)
        //{

           // MainController.wheelButton = true;
            //click = false;

        //}


    }

    // esta funcion nos avisa cuando salimos del boton
    void OnMouseExit()
    {
        rend.material.color = Color.white;
        //use = false;

    }


        }


