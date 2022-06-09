using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletShot : MonoBehaviour
{
	[SerializeField] float bulletLife;
	void Awake()
	{
		Destroy(gameObject,3);
	}


    private void OnCollisionEnter(Collision collision) {
        
        if(collision.gameObject.tag == "target")
            Destroy(collision.gameObject);
        
        Destroy(gameObject);
    }
}
