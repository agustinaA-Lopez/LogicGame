using UnityEngine;

public class respuestasController : MonoBehaviour
{

public Renderer rend;
public GameObject  a1, b1, c1, d1;
public GameObject r2aObj, r2bObj, r2cObj, r2dObj; 


//GameObject r1a;
GameObject r1a, r1b, r1c, r1d, r;
GameObject r2a, r2b, r2c, r2d;
private GameObject respuesta;
public static GameObject paraDestruir;
string secondObj, answer;
int number, asciiLetter;

bool click;

    void Start()
    {

        rend = GetComponent<Renderer>();
        Respuesta();
        
    }
Vector3 control;
    //The mesh fades of when the mouse is over it...
    void OnMouseDown()
    {
         // para no confundir boton con rueda usamos  ButtonControoller.use
         // ubica la posicion del angulo de la rueda
    
        if (!WheelButtonController.use) {startAngle = getAngle() - transform.rotation.eulerAngles.z;
      
       }
    }

    void Update ()
    {

        Destroy(GameObject.Find(secondObj));
     
        if (paraDestruir != null)
        {

            Destroy(paraDestruir); 
            secondObj = paraDestruir.name;  

        }
    }


    void OnMouseDrag()
    {

        // mueve la rueda llamando a la funcion getAngle().
        

        if (!WheelButtonController.use){
       
        //play sound on turning weel
        if (!GetComponent<AudioSource>().isPlaying && Input.mousePosition!=control) GetComponent<AudioSource>().Play();
             

        //move the wheel
        float angle;
        angle = getAngle();
       
        float dif = angle - transform.rotation.eulerAngles.z- startAngle;
        angle = transform.rotation.eulerAngles.z + dif;
        
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        control  = Input.mousePosition;

        }
    }

    private Vector3 worldMouse;
 
    private float startAngle;
 

// funcion para rotacion de la rueda
float getAngle(){
        worldMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        float xDif;
        if(transform.position.x < -1.6F ) xDif = transform.position.x+worldMouse.x; 
        
        else xDif = worldMouse.x-transform.position.x;

        float yDif = worldMouse.y-transform.position.y;
        float angle =  Mathf.Atan2(yDif, xDif)*Mathf.Rad2Deg;
        return angle;
    }



//Instancia las respuestas segun Maincontroller.nivel
void Respuesta()
{
    number = MainController.nivel;
    asciiLetter = 97;


        for (int i = 0; i < 8; i++)
        {

            answer = char.ConvertFromUtf32(asciiLetter);
            answer += number.ToString();

            r = Instantiate(Resources.Load(answer, typeof(GameObject))) as GameObject;
            r.transform.SetParent(gameObject.transform);
            gameObject.transform.Rotate(0,0,45);

            if (asciiLetter < 100) asciiLetter++; else asciiLetter = 97;

        }

 }

}
