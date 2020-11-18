using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    bool click, answer;
    public GameObject clickOnSound;
    public static bool use;

   // GameObject pressedButton;
    // Start is called before the first frame updatevoid OnMouseDown()
    void OnMouseDown(){

        //sound on click
        GameObject clickSound;
        clickSound = Instantiate(clickOnSound);
        clickSound.GetComponent<AudioSource>().Play();
        
        click = true;
        // }
        
    }
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        use = false;
        
    }


    void OnMouseEnter()
    {
        use = true;
        rend.material.color = Color.white;
    }



    //public static bool use;
    void OnMouseOver()
    {
        
        if (rend.material.color.r >.2) rend.material.color -= new Color(.01f, 0, 0) * Time.deltaTime*120;
       
        if (rend.material.color.r <=.5F && click){
        //GetComponent<AudioSource>().Play();
        MainController.wheelButton = true;
        click = false;
        Debug.Log("wheelbutton "+ MainController.wheelButton);
        } 

         
    }


    void OnMouseExit()
    {
        rend.material.color = Color.white;
        use = false;

    }




}



