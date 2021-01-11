using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvertenciaController: MonoBehaviour
{

    public GameObject advertencia;


    // Update is called once per frame
    void Update()
    {
        if (MainController.nivel == 1) {GetComponent<TMPro.TextMeshProUGUI>().text = "move the wheel to find the missing piece\n & check on the right answer"; GetComponent<TMPro.TextMeshProUGUI>().fontSize = 140;}

        if (Text.points <= 3 && MainController.nivel != 1) {GetComponent<TMPro.TextMeshProUGUI>().text = "The 90% of people get 10 points"; MainController.noPaso= false;}

        if (Text.points >= 10 && Text.points <= 13) { GetComponent<TMPro.TextMeshProUGUI>().text = "The 80% of people get 20 points"; MainController.noPaso = false;}

        if (Text.points >= 20 && Text.points <= 23) { GetComponent<TMPro.TextMeshProUGUI>().text = "The 70% of people get 30 points"; MainController.noPaso = false;}

        if (Text.points >= 30 && Text.points <= 33) { GetComponent<TMPro.TextMeshProUGUI>().text = "The 60% of people get 40 points"; MainController.noPaso = false;}

        if (Text.points == 40) GetComponent<TMPro.TextMeshProUGUI>().text = "The 50% of people get 40 points";
        if (Text.points == 50) GetComponent<TMPro.TextMeshProUGUI>().text = "The 40% of people get 60 points";
        if (Text.points == 60) GetComponent<TMPro.TextMeshProUGUI>().text = "The 20% of people get 70 points";
        if (Text.points == 70) GetComponent<TMPro.TextMeshProUGUI>().text = "The 10% of people get 80 points";
        if (Text.points == 80) GetComponent<TMPro.TextMeshProUGUI>().text = "The 1% of people get 90 points";
        if (Text.points == 90) GetComponent<TMPro.TextMeshProUGUI>().text = "You're a freaking genius!!";

      //  if (Text.points % 10 > 3 && Text.points % 10 <= 9) MainController.noPaso = true;




    }
}
