using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ventanaController : MonoBehaviour
{

  
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
            
            if (mySR.bounds.Intersects(rightAnswerSR.bounds) && MainController.wheelButton)
            {
                MainController.rightAnswer = true;
                Text.tiempoRespuesta = 30;
                Text.points += 3;
        
            }
        } 

            foreach (GameObject wrongAnswer in GameObject.FindGameObjectsWithTag("wrongAnswer"))
            {
                //Debug.Log(wrongAnswer.name);
                
                SpriteRenderer wrongAnswerSR = wrongAnswer.GetComponent<SpriteRenderer>();
                
                //GameObject objClone = GameObject.Find(wrongAnswer.name);
                if (mySR.bounds.Intersects(wrongAnswerSR.bounds) && MainController.wheelButton) 
                {
                    for (int i = 0; i < 3; i++)
                    {
                       
                    //     GameObject destroy = GameObject.Find(wrongAnswer.name);
                    //     Debug.Log(destroy.transform);
                    //     Destroy(destroy);
                    
                        GameObject objClone = GameObject.Find(wrongAnswer.name);
                        if (objClone != null){
                        
                        Destroy(objClone);
                        Debug.Log(objClone);
                        }
                    }
                    
                    // destruye la respuesta errada si hacemos click en el wheelButton
                    
                    //Debug.Log(wrongAnswer.name); 
                    Destroy(wrongAnswer);
                    

                     
                    
                    
                    

                    
                    
                    //Destroy(GameObject.Find(wrongAnswer.name));
                    //GameObject destroy = GameObject.Find(wrongAnswer.name);
                    
                    MainController.rightAnswer = false;
                    Text.tiempoRespuesta = 30;
                    MainController.wheelButton = false;
                    MainController.rightAnswer = false;
                    Text.points -= 2;
        } 
        
        }
      
        
    }


}
