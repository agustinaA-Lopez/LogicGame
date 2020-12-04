using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject inicioObj, level1Obj, playButtonObj, circuloObj, checkObj, level2Obj, level3Obj, level4Obj, mask, fondoObj, MenuButtonObj, Menu, HelpButtonObj, BackButton, pantallaPrincipalObj, pantallaTiempoObj, pantallaPuntosObj;
    public static bool playbutton, wheelButton, rightAnswer;
    public static int nivel, respuesta;
    public static float tiempo;
    //public static int nivel;
    private GameObject inicio, playButton, backButton, circulo, check, level, ventana, fondo, MenuButton, pantallaPrincipal, pantallaTiempo, pantallaPuntos, helpButton, menu;

    public static float tiempoRespuesta = 30;
    public static bool instanciar = true;
    public static bool instanciadorNivel;

    //public GameObject timeObj;
    //public static int vidas=10;

    // Start is called before the first frame update
    void Start()
    {
        rightAnswer = true;
        nivel = 0;
        //level = Instantiate(inicioObj);
        //circulo = Instantiate(circuloObj);
        // playButton = Instantiate(playButtonObj);
        //MenuButton = Instantiate(MenuButtonObj);

    }

    // Update is called once per frame
    void Update()
    {

        if (nivel == 0 && instanciar)
        {
            level = Instantiate(inicioObj);
            playButton = Instantiate(playButtonObj);
            MenuButton = Instantiate(MenuButtonObj);
            instanciar = false;
            BackButtonController.NivelPrevio = nivel;

        }

        if (wheelButton && nivel == -1)
        {
            //destruccion cosas de inicio

            Destroy(level);
            Destroy(circulo);
            Destroy(playButton);
            Destroy(check);
            Destroy(MenuButton);
            Destroy(helpButton);


            //destruccion cosas de nivel mayor a 0

            Destroy(helpButton);
            Destroy(pantallaPrincipal);
            Destroy(fondo);
            Destroy(ventana);
            Destroy(check);
            Destroy(pantallaTiempo);
            Destroy(pantallaPuntos);



            //instancia cosas del nivel -1
            menu = Instantiate(Menu);
            backButton = Instantiate(BackButton);
            wheelButton = false;

        }
        if (BackButtonController.PushButton)
        {
            Destroy(backButton);
            Destroy(menu);
            //Destroy(MenuButton);
            BackButtonController.PushButton = false;

        }



        // Controla los niveles. Destruye e instancia en funcion del nivel
        // if ( wheelButton && rightAnswer) {
        if (instanciadorNivel && rightAnswer)
        {

            Destroy(level);
            Destroy(circulo);
            Destroy(playButton);
            Destroy(check);
            Destroy(pantallaPrincipal);
            Destroy(pantallaTiempo);
            Destroy(pantallaPuntos);
            Destroy(ventana);
            Destroy(MenuButton);

            MenuButton = Instantiate(MenuButtonObj);

            nivel++;
            Level();


            BackButtonController.NivelPrevio = nivel;
            MenuButton.transform.position = new Vector3(1.8f, -4.3f, 0);



            helpButton = Instantiate(HelpButtonObj);
            pantallaPrincipal = Instantiate(pantallaPrincipalObj);
            fondo = Instantiate(fondoObj);
            ventana = Instantiate(mask);
            circulo = Instantiate(circuloObj);
            check = Instantiate(checkObj);
            wheelButton = false;
            rightAnswer = false;
            pantallaTiempo = Instantiate(pantallaTiempoObj);
            pantallaPuntos = Instantiate(pantallaPuntosObj);

            instanciadorNivel = false;

        }



    }

    //Controla los niveles
    void Level()
    {
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



