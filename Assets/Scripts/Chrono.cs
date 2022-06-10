using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
        EndChrono();

        //Si user shot toute les cibles
        //flag = false;
    }

    public void EndChrono()
    {
    	string ActualScene = SceneManager.GetActiveScene().name;

    	if(ActualScene == "level1" && Score.compteur == 49){
    			flag = false;
    			SceneManager.LoadScene("level2", LoadSceneMode.Single);
    			Score.compteur = 0;
    
    	}else if(ActualScene == "level2" && Score.compteur == 99){
    			flag = false;
    			SceneManager.LoadScene("level3", LoadSceneMode.Single);
    			Score.compteur = 0;

    	}else if(ActualScene == "level3" && Score.compteur == 33){
    			flag = false;

    	}

    }
}
