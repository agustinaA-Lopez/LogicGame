using UnityEngine;

public class respuestasController : MonoBehaviour
{
    public static float z;

    public static bool move, firstDestroyed;


public Renderer rend;
public GameObject clickOnSound;
public GameObject  r1aObj, r1bObj, r1cObj, r1dObj;
public GameObject r2aObj, r2bObj, r2cObj, r2dObj; 


//GameObject r1a;
GameObject r1a, r1b, r1c, r1d;
GameObject r2a, r2b, r2c, r2d;
private GameObject respuesta;
public static GameObject paraDestruir;
string secondObj;

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
    
        if (!ButtonController.use) {startAngle = getAngle() - transform.rotation.eulerAngles.z;
      
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
        

        if (!ButtonController.use){
       
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
switch (MainController.nivel)
    {
        
        case 0:
            break;

        case 1: 
        for (int i = 0; i < 2; i++)
        {
            r1a = Instantiate(r1aObj);
            r1a.transform.SetParent(gameObject.transform);
            gameObject.transform.Rotate(0,0,45);
            r1b = Instantiate(r1bObj);
            r1b.transform.SetParent(gameObject.transform);
            gameObject.transform.Rotate(0,0,45);
            r1c = Instantiate(r1cObj);
            r1c.transform.SetParent(gameObject.transform);
            
            gameObject.transform.Rotate(0,0,45);
            r1d = Instantiate(r1dObj);
            r1d.transform.SetParent(gameObject.transform);
            gameObject.transform.Rotate(0,0,45);
        }
                        break;


        case 2:
        for (int i = 0; i < 2; i++)
        {
            r2a = Instantiate(r2aObj);
            r2a.transform.SetParent(gameObject.transform);
            gameObject.transform.Rotate(0,0,45f);
            r2b = Instantiate(r2bObj);
            r2b.transform.SetParent(gameObject.transform);
            gameObject.transform.Rotate(0,0,45f);
            r2c = Instantiate(r2cObj);
            r2c.transform.SetParent(gameObject.transform);
            gameObject.transform.Rotate(0,0,45f);
            
            r2d = Instantiate(r2dObj);
            r2d.transform.SetParent(gameObject.transform);
           gameObject.transform.Rotate(0,0,45f);
            
        }  
     

        break; 
  
    }
 }

}
