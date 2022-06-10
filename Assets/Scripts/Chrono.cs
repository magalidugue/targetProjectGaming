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
    static public float time;
    string ActualScene;

    // Start is called before the first frame update
    void Start()
    {
        ActualScene = SceneManager.GetActiveScene().name;
        startTimer = Time.time;
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
    	if(flag == true){
            time = Time.time - startTimer;
            
            temps.text = time.ToString("N02");
        }
        EndChronoIfLevelFinished();
    }

    public void EndChronoIfLevelFinished()
    {
        //49 target
    	if(ActualScene == "level1" && Score.compteur == 49)
        {
    		flag = false;
            Score.compteur = 0;
            SceneManager.LoadScene("ScoreDisplayer1", LoadSceneMode.Single);
        }
        //99 target
        else if(ActualScene == "level2" && Score.compteur == 99)
        {
    		flag = false;
            Score.compteur = 0;
            SceneManager.LoadScene("ScoreDisplayer2", LoadSceneMode.Single);
        }
        //33 target
        else if(ActualScene == "level3" && Score.compteur == 33)
        {
    		flag = false;
            Score.compteur = 0;
            SceneManager.LoadScene("ScoreDisplayer2", LoadSceneMode.Single);
        }
    }
}
