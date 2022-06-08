using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "target"){
            Destroy(gameObject);
        }
    }
}
