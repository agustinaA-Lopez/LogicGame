﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvertenciaController: MonoBehaviour
{

    public GameObject advertencia;


    // Update is called once per frame
    void Update()
    {

        if (Text.points==0) GetComponent<TMPro.TextMeshProUGUI>().text = "The 90% of people fine 10 points";
        if (Text.points == 10) GetComponent<TMPro.TextMeshProUGUI>().text = "The 80% of people fine 20 points";
        if (Text.points == 20) GetComponent<TMPro.TextMeshProUGUI>().text = "The 70% of people fine 30 points";
        if (Text.points == 30) GetComponent<TMPro.TextMeshProUGUI>().text = "The 60% of people fine 40 points";
        if (Text.points == 40) GetComponent<TMPro.TextMeshProUGUI>().text = "The 50% of people fine 40 points";
        if (Text.points == 50) GetComponent<TMPro.TextMeshProUGUI>().text = "The 40% of people fine 60 points";
        if (Text.points == 60) GetComponent<TMPro.TextMeshProUGUI>().text = "The 20% of people fine 70 points";
        if (Text.points == 70) GetComponent<TMPro.TextMeshProUGUI>().text = "The 10% of people fine 80 points";
        if (Text.points == 80) GetComponent<TMPro.TextMeshProUGUI>().text = "The 1% of people fine 90 points";
        if (Text.points == 90) GetComponent<TMPro.TextMeshProUGUI>().text = "Your are de Best";

        if (Text.points % 10 == 0) MainController.advertenciaBool = true;
        Debug.Log(Text.points % 10);



    }
}
