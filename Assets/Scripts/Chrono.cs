using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chrono : MonoBehaviour
{
	var flag:boolean = false;
	var startTimer:int;
	[SerializeField] string temps;
    // Start is called before the first frame update
    void Start()
    {
        //eliott
    }

    // Update is called once per frame
    void Update()
    {
    	if(flag == true){
        var time = Time.time - startTimer;
        var minutes : int = time / 60;
        var seconds : int = time % 60;
        Debug.Log(String.Format ("{0:00}:{1:00}", minutes, seconds));
        Tostring(temps = seconds);
    }
        
    }
    function OnTriggerEnter(other : Collider) {
    startTimer = Time.time;
    flag = true;
}
 
	function OnTriggerExit (other : Collider) {
    flag = false;
}

}
