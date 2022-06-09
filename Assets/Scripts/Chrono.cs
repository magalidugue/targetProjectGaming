using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chrono : MonoBehaviour
{
	bool flag = false;
	float startTimer;
	[SerializeField] TMP_Text temps;
    // Start is called before the first frame update
    void Start()
    {
        startTimer = Time.time;
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
    	if(flag == true){
            float time = Time.time - startTimer;
            
            temps.text = time.ToString("N02");
        }

        //Si user shot toute les cibles
        //flag = false;
    }
}
