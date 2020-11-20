using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject inicioObj, level1Obj, playButtonObj, circuloObj, checkObj, level2Obj,level3Obj,level4Obj, mask, fondoObj, MenuButtonObj, Menu, HelpButtonObj;
    public static bool playbutton, wheelButton, rightAnswer;
    public static int nivel, respuesta;
    public static float tiempo;
    //public static int nivel;
    private GameObject inicio, playButton, circulo, check, level, ventana, fondo, MenuButton;

    public static float tiempoRespuesta = 30;

    //public GameObject timeObj;
    public static int vidas=10;
    
    // Start is called before the first frame update
    void Start()
    {
        rightAnswer = true;
        nivel = 0;
        level = Instantiate(inicioObj);
        //circulo = Instantiate(circuloObj);
        playButton = Instantiate(playButtonObj);
        MenuButton = Instantiate(MenuButtonObj);
    }

    // Update is called once per frame
    void Update()
    {

        if (wheelButton && nivel == -1)
        {

            Destroy(level);
            Destroy(circulo);
            Destroy(playButton);
            Destroy(check);
            Destroy(MenuButton);
            Destroy(HelpButtonObj);
            //Destroy(inicioObj);
            //nivel++;
            // Level();

            //fondo = Instantiate(fondoObj);
            //ventana = Instantiate(mask);
            //circulo = Instantiate(circuloObj);
            //check = Instantiate(checkObj);

            Instantiate(Menu);
            wheelButton = false;
            rightAnswer = false;

        }


        // Controla los niveles. Destruye e instancia en funcion del nivel
        if ( wheelButton && rightAnswer) {
           
            Destroy(level);
            Destroy(circulo);
            Destroy(playButton);
            Destroy(check);
            Destroy(MenuButton);
            nivel ++;
            Level();

            Instantiate(HelpButtonObj);
            fondo = Instantiate(fondoObj);
            ventana = Instantiate(mask);
            circulo = Instantiate(circuloObj);
            check = Instantiate(checkObj); 
            wheelButton= false;
            rightAnswer = false; 

        } 

    

        // Timer (en proceso ...)

    /*    tiempoRespuesta -= Time.deltaTime;
       // scoreObj.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString(); 
        timeObj.GetComponent<TMPro.TextMeshProUGUI>().text = "Tiempo: " + ((int)tiempoRespuesta).ToString();
        if ((int)tiempoRespuesta == 0) tiempoRespuesta = 30;
        //if (Juego.respuesta != 0) tiempoRespuesta = 29;

        //hace que no empiece el tiempo hasta que salga del inicio
        //if (nivel < 1||Preg.tiempo<5)
        // {
        //     GetComponent<TextMesh>().text = "";
        //     tiempoRespuesta = 29;
        // }
        // if (nivel > 0)
        // {
        //     Credito.GetComponent<TextMesh>().text = "Credits: " + vidas;

        // }*/


    }

    //Controla los niveles
 void Level(){
 switch (nivel)
    {
        case 0:
            level = Instantiate(inicioObj);
            
            break;

        case 1: 
            level = Instantiate(level1Obj);
            break;

        case 2:
            level = Instantiate(level2Obj);
            break;

        case 3:
            level = Instantiate(level3Obj);
            break;

        case 4:
            level = Instantiate(level4Obj);
            break;   
    }
 }

}



