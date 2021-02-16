using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvertenciaController: MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        if (MainController.nivel == 1) {GetComponent<TMPro.TextMeshProUGUI>().text = "move the wheel to find the missing piece\n & check on the right answer"; GetComponent<TMPro.TextMeshProUGUI>().fontSize = 155;}

        if (Text.points <= 3 && MainController.nivel != 1) {GetComponent<TMPro.TextMeshProUGUI>().text = "90% of people get 10 points"; MainController.noPaso= false;}

        if (Text.points >= 10 && Text.points <= 13) { GetComponent<TMPro.TextMeshProUGUI>().text = "80% of people get 20 points"; MainController.noPaso = false;}

        if (Text.points >= 20 && Text.points <= 23) { GetComponent<TMPro.TextMeshProUGUI>().text = "70% of people get 30 points"; MainController.noPaso = false;}

        if (Text.points >= 30 && Text.points <= 33) { GetComponent<TMPro.TextMeshProUGUI>().text = "60% of people get 40 points"; MainController.noPaso = false;}

        if (Text.points >= 40 && Text.points <= 43) { GetComponent<TMPro.TextMeshProUGUI>().text = "50% of people get 40 points"; MainController.noPaso = false;}
        if (Text.points >= 50 && Text.points <= 53) { GetComponent<TMPro.TextMeshProUGUI>().text = "40% of people get 60 points"; MainController.noPaso = false;}
        if (Text.points >= 60 && Text.points <= 63) { GetComponent<TMPro.TextMeshProUGUI>().text = "20% of people get 70 points"; MainController.noPaso = false;}
        if (Text.points >= 70 && Text.points <= 73) { GetComponent<TMPro.TextMeshProUGUI>().text = "10% of people get 80 points"; MainController.noPaso = false;}
        if (Text.points >= 80 && Text.points <= 83) { GetComponent<TMPro.TextMeshProUGUI>().text = "1% of people get 90 points"; MainController.noPaso = false;}
        if (Text.points >= 90 && Text.points <= 93) { GetComponent<TMPro.TextMeshProUGUI>().text = "You're a freaking genius!!"; MainController.noPaso = false;}
        
        if (MainController.nivel == 32){GetComponent<TMPro.TextMeshProUGUI>().text = "Congrats!! You've finished with "+ Text.points + " Points!";}

    }
}
