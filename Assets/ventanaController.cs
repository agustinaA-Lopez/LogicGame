using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ventanaController : MonoBehaviour
{

    GameObject objClone, wrongAnswer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //La ventana chequea si el objeto con el que interactua es tag "rightAnswer" or "wrongAnswer"

        SpriteRenderer mySR = GetComponent<SpriteRenderer>();

        foreach (GameObject rigthAnswer in GameObject.FindGameObjectsWithTag("rightAnswer"))
        {
            SpriteRenderer rightAnswerSR = rigthAnswer.GetComponent<SpriteRenderer>();
            
            if (mySR.bounds.Intersects(rightAnswerSR.bounds) && MainController.instanciadorNivel)
            {
                MainController.rightAnswer = true;
                Text.tiempoRespuesta = 30;
                Text.points += 11;
                MainController.instanciadorNivel = false;
            }
        } 
         

        foreach (GameObject wrongAnswer in GameObject.FindGameObjectsWithTag("wrongAnswer"))
        {
             
            SpriteRenderer wrongAnswerSR = wrongAnswer.GetComponent<SpriteRenderer>();

            if (mySR.bounds.Intersects(wrongAnswerSR.bounds) && MainController.instanciadorNivel) 
            {
                respuestasController.paraDestruir = wrongAnswer;
                MainController.rightAnswer = false;
                MainController.clickOn = false;
                Text.tiempoRespuesta = 30;
                Text.points -= 2;
                MainController.instanciadorNivel = false;
            }
        }
    }
}
