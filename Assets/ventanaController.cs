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
        SpriteRenderer mySR = GetComponent<SpriteRenderer>();

        foreach (GameObject rigthAnswer in GameObject.FindGameObjectsWithTag("rightAnswer"))
            {
            SpriteRenderer rightAnswerSR = rigthAnswer.GetComponent<SpriteRenderer>();
            
            if (mySR.bounds.Intersects(rightAnswerSR.bounds) && MainController.wheelButton)
            {
                MainController.rightAnswer = true;
        
            }
        } 

       

            foreach (GameObject wrongAnswer in GameObject.FindGameObjectsWithTag("wrongAnswer"))
            {
                SpriteRenderer wrongAnswerSR = wrongAnswer.GetComponent<SpriteRenderer>();
                

                if (mySR.bounds.Intersects(wrongAnswerSR.bounds) && MainController.wheelButton)
                {
                    Debug.Log("wrong Answer");
                    Destroy(wrongAnswer);
                    MainController.wheelButton = false;
                    MainController.rightAnswer = false;
        } 
        }
      
        
    }


}
