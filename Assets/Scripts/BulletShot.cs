using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletShot : MonoBehaviour
{
	[SerializeField] float bulletLife;
	[SerializeField] string score;
	
	void Awake()
	{
		Destroy(gameObject,3);
		score = 0;
	}

    private void OnCollisionEnter(Collision collision) {
        
        if(collision.gameObject.tag == "target")
            Destroy(collision.gameObject);
            score = score++;
            Tostring(score);

        
        Destroy(gameObject);
    }
}
