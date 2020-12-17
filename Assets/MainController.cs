using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject inicioObj, level1Obj, circuloObj, level2Obj, level3Obj, level4Obj, fondoObj, MenuObj, AdvertenciaObj;
    public static bool clickOn, silenceMusic, rightAnswer, MenuButton, backButton, advertenciaBool;
    public static int nivel, respuesta;
    public static float tiempo;
    //public static int nivel;
    private GameObject circulo, fondo, menu, level, advertencia;


    public static float tiempoRespuesta = 30;
    public static bool instanciar = true;
    public static bool instanciadorNivel;
    static int puntosViejos=0;


    //public GameObject timeObj;
    //public static int vidas=10;

    // Start is called before the first frame update
    void Start()
    {
        //Lo de abajo sirve para seguir jugando en el nivel en que estaba
        nivel = PlayerPrefs.GetInt("NIVEL", nivel);
        Text.points = PlayerPrefs.GetInt("PUNTOS", Text.points);




        //rightAnswer = true;

        silenceMusic = false;
        instanciadorNivel = false;
        // Level();
        clickOn = true;
        MenuButton = false;
      
    }

    // Update is called once per frame
    void Update()
    {
       

        //lo de abajo guarda los puntos que tengo para cuando vuelva a jugar
        if (puntosViejos != Text.points)
        {
            PlayerPrefs.SetInt("PUNTOS", Text.points);
            PlayerPrefs.Save();
        }

        //DESCOMENTAR PARA JUGAR EL JUEGO DESDE EL PRINCIPIO
       /* PlayerPrefs.SetInt("NIVEL", 0);
        PlayerPrefs.SetInt("PUNTOS", 0);*/

        if (MenuButton)
        {
            if (nivel > 0)
            {
            circulo.SetActive(false);
            
            fondo.SetActive(false);
            }
        level.SetActive(false);
        menu = Instantiate(MenuObj);
                
        MenuButton = false;
        }
        
        
        if (backButton)
        {
            //Destroy(backButton);
            Destroy(menu);
            
            if (nivel > 0)
            {
                circulo.SetActive(true);
                fondo.SetActive(true);     
            } 

            level.SetActive(true);  
            backButton = false;

        }


        if (clickOn)
        {
            Level();

            clickOn = false;

            // rightAnswer = false;

        }


        if (rightAnswer)
        {
            Destroy(level);

            nivel++;
            Level();

            //esto guarda el nivel en que estoy para el proximo juego
            PlayerPrefs.SetInt("NIVEL", nivel);
            PlayerPrefs.Save();


            rightAnswer = false;

            instanciadorNivel = false;

        }


//Sonido de fondo
            if (nivel > 0)
        {
            if (!GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Play();
            if (GetComponent<AudioSource>().isPlaying && GetComponent<AudioSource>().volume < .7f && !silenceMusic) GetComponent<AudioSource>().volume +=.01f;

        if (GetComponent<AudioSource>().isPlaying)
        {
        if (silenceMusic) GetComponent<AudioSource>().volume = 0; 

        }


        }

        // advertencia Cartel
        if (Text.tiempoRespuesta < 27) Destroy(advertencia);
    }
    //Controla los niveles
    void Level()
    {

        {
            Destroy(level);
            Destroy(circulo);
            Destroy(menu);
            Destroy(fondo);

        }

        if (Text.points % 10 == 0) MainController.advertenciaBool = true;

        if (nivel >0)
        {
            fondo = Instantiate(fondoObj);
            circulo = Instantiate(circuloObj);
            
            if (advertenciaBool) {
                advertencia = Instantiate(AdvertenciaObj);
                advertenciaBool = false;
            }

        }

        switch (nivel)
        {

            case 0:
                level = Instantiate(inicioObj);

                break;

            case 1 :
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



