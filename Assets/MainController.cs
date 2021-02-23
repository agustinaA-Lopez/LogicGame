using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class MainController : MonoBehaviour
{
    public GameObject inicioObj, circuloObj, fondoObj, MenuObj, AdvertenciaObj, FireWorksObj, ContinuarObje, playAgainObj;
    public static bool clickOn, silenceMusic, silenceGame, rightAnswer, MenuButton, backButton, advertenciaBool;
    public static int nivel, respuesta;
    public static float tiempo, fireDelay, fireTimer;
    //public static int nivel;
    private GameObject circulo, fondo, menu, level, advertencia, panel, continuar, playAgain, fireWorks;


    public static float tiempoRespuesta = 30;
    public static bool instanciar= true;
    public static bool noPaso = true;
    public static bool instanciadorNivel;
    public static int puntosViejos=0;
    int number, asciiLetter;
    string pregunta;
   // bool paso; //MenuBool,

    // Ads Information
    string gameId = "4000239";
    bool testMode = false;

    //public GameObject timeObj;
    //public static int vidas=10;

    // Start is called before the first frame update
    void Start()
    {
        //Lo de abajo sirve para seguir jugando en el nivel en que estaba
       // fireTimer = 0;
        silenceMusic = false;
        instanciadorNivel = false;
        clickOn = true;
        MenuButton = false;

        // Inicializacion publicidad
        Advertisement.Initialize(gameId, testMode);
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
            Destroy(advertencia);
            if (continuar != null) continuar.SetActive(false);
            if (nivel > 0)
            {
                circulo.SetActive(false);
                fondo.SetActive(false);
            }

            level.SetActive(false);
            menu = Instantiate(MenuObj);
            MenuButton = false;
            //MenuBool = true;
        }

        //lo de abajo lo puse de tal forma que si lo apretas salta de nivel
        if (Input.GetKeyDown("n"))
        { clickOn = true;
            nivel++;
          Debug.Log(nivel);
                }
        //

        if (backButton)
        {
            Destroy(menu);
            if (continuar != null) continuar.SetActive(true);

            if (nivel > 0)
            {
                circulo.SetActive(true);
                fondo.SetActive(true);
            }

            level.SetActive(true);
            backButton = false;
            //MenuBool = false;
            //paso = false;
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

            // Mostrar publicidad
            if (Advertisement.IsReady() && nivel %3 == 0)
            {
                Advertisement.Show();
            } 
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
        if ((nivel != 1 && Text.tiempoRespuesta < 57) || nivel == 0) Destroy(advertencia);

        if (Text.points % 10 > 3 && Text.points % 10 <= 9) noPaso = true;


        //Controla el boton back del celular
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown("<"))
            
            {
                Vibration.Vibrate(1);
                // Insert Code Here (I.E. Load Scene, Etc)
                if (menu != null) backButton = true;
                else if (nivel != 0) {nivel = 0; Level();}
                else Application.Quit();
                if (advertencia != null) Destroy(advertencia);


                //return;
            }
         

        }
        if (Input.GetKeyDown("b"))
        {
                Vibration.Vibrate(1);
                // Insert Code Here (I.E. Load Scene, Etc)
                if (menu != null) backButton = true;
                else if (nivel != 0) { nivel = 0; Level(); }
                else Application.Quit();
                if (advertencia != null) Destroy(advertencia);


                //return;
            }


        if (fireTimer>0) fireTimer -= Time.deltaTime;
        if (fireTimer < 0) {fireWorks = Instantiate(FireWorksObj); fireTimer = Random.Range(.5f,1.5f);}
    }
    //Controla los niveles
    void Level()
    {
        fireTimer = 0;
        Destroy(level);
        Destroy(circulo);
        Destroy(menu);
        Destroy(fondo);
        Destroy (playAgain);
        Destroy(fireWorks);
        Destroy(continuar);

     


        if (nivel >0 && nivel < 32)
        {
            fondo = Instantiate(fondoObj);
            circulo = Instantiate(circuloObj);
            

        }
        if ((nivel > 0  && Text.points % 10 <= 3 == true && noPaso) || (nivel == 32 && advertencia == null))
            {
                advertencia = Instantiate(AdvertenciaObj);
                panel = GameObject.FindGameObjectWithTag("panel");
                if (nivel > 1 && nivel <32) panel.transform.localScale = new Vector3(1F, .5f, 0);
                advertenciaBool = false;
            }
            // INSTANCIAMOS PREGUNTA SEGUN NIVEL
            
            pregunta = "p" + nivel.ToString();
            if (nivel==0)
            {
                level = Instantiate(inicioObj); advertenciaBool = true;

                if ((PlayerPrefs.GetInt("NIVEL") > 0)) continuar = Instantiate(ContinuarObje);
            }

            else if (nivel == 32) 
            {
                if (playAgain == null) playAgain = Instantiate(playAgainObj);
                fireWorks = Instantiate (FireWorksObj); 
                fireTimer = Random.Range(.5f,1.5f);
            }

            else level = Instantiate(Resources.Load(pregunta, typeof(GameObject))) as GameObject;

 }


}



