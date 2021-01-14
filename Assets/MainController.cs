using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject inicioObj, circuloObj, fondoObj, MenuObj, AdvertenciaObj;
    public static bool clickOn, silenceMusic, silenceGame, rightAnswer, MenuButton, backButton, advertenciaBool;
    public static int nivel, respuesta;
    public static float tiempo;
    //public static int nivel;
    private GameObject circulo, fondo, menu, level, advertencia, panel;


    public static float tiempoRespuesta = 30;
    public static bool instanciar = true;
    public static bool noPaso = true;
    public static bool instanciadorNivel;
    static int puntosViejos=0;
    int number, asciiLetter;
    string pregunta;


    //public GameObject timeObj;
    //public static int vidas=10;

    // Start is called before the first frame update
    void Start()
    {
        //Lo de abajo sirve para seguir jugando en el nivel en que estaba
        nivel = PlayerPrefs.GetInt("NIVEL", nivel);
        Text.points = PlayerPrefs.GetInt("PUNTOS", Text.points);

        silenceMusic = false;
        instanciadorNivel = false;
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
        /*PlayerPrefs.SetInt("NIVEL", 0);
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


        //Sonido musica
        if (nivel > 0)
        {
            if (!GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Play();
            if (GetComponent<AudioSource>().isPlaying && GetComponent<AudioSource>().volume < .7f && (!silenceMusic || !silenceGame)) GetComponent<AudioSource>().volume += .01f;

            if (GetComponent<AudioSource>().isPlaying)
            {
                if (silenceMusic || silenceGame) GetComponent<AudioSource>().volume = 0;

            }
        }

        // advertencia Cartel
        if (nivel == 1 && Text.tiempoRespuesta < 55 || respuestasController.click) { Destroy(advertencia); respuestasController.click = false; }
        else if (nivel != 1 && Text.tiempoRespuesta < 57) Destroy(advertencia);

        if (Text.points % 10 > 3 && Text.points % 10 <= 9) MainController.noPaso = true;


        //Controla el boton back del celular
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                // Insert Code Here (I.E. Load Scene, Etc)
                Application.Quit();

                //return;
            }

        }
    }
    //Controla los niveles
    void Level()
    {

        Destroy(level);
        Destroy(circulo);
        Destroy(menu);
        Destroy(fondo);

        if (Text.points % 10 <= 3 && noPaso)
        {
            MainController.advertenciaBool = true;
        }


        if (nivel >0)
        {
            fondo = Instantiate(fondoObj);
            circulo = Instantiate(circuloObj);
            
            if (advertenciaBool) 
            {
                advertencia = Instantiate(AdvertenciaObj);
                panel = GameObject.FindGameObjectWithTag("panel");
                if (nivel > 1) panel.transform.localScale = new Vector3(1F, .5f, 0);
                advertenciaBool = false;
            }

        }
            // INSTANCIAMOS PREGUNTA SEGUN NIVEL
            
            pregunta = "p" + nivel.ToString();
            if (nivel==0) {level = Instantiate(inicioObj); advertenciaBool = true;}
            else level = Instantiate(Resources.Load(pregunta, typeof(GameObject))) as GameObject;

 }

}



