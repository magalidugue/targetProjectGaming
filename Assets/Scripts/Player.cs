using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Transform FirePoint;
    [SerializeField] GameObject BulletPrefab;

    Rigidbody playerRigidBody;

    //Decides how fast the bullet shoots
    [SerializeField] float bulletForce = 40f;
    [SerializeField] float playerSpeed = 1.5f;
    [SerializeField] float mouseSensitivity = 360.0f;
    [SerializeField] Transform CameraTransform;
    [SerializeField] GameObject Audio;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
    	if (Input.GetMouseButtonDown(0)){
            Shoot();
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
        float rotateHorizontal = Input.GetAxisRaw("Mouse X");
        float rotateVertical = Input.GetAxisRaw("Mouse Y");
        //input escape = Input.GetAxisRaw("Cancel");

        Debug.Log(rotateVertical);

        //MODE POSITIONNEL
        Vector3 moveVertical = zMove * transform.forward * playerSpeed * Time.fixedDeltaTime;
        Vector3 moveHorizontal = xMove * transform.right * playerSpeed * Time.fixedDeltaTime;
        Vector3 newPos = transform.position + moveVertical + moveHorizontal;

        playerRigidBody.MovePosition(newPos);

        float horizontalRotAngle = rotateHorizontal * mouseSensitivity * Time.fixedDeltaTime;

        Quaternion qHorizontalRot = Quaternion.AngleAxis(horizontalRotAngle, transform.up);
        Quaternion qNewHorizontalOrient = qHorizontalRot * transform.rotation;
        playerRigidBody.MoveRotation(qNewHorizontalOrient);
        playerRigidBody.AddForce(-playerRigidBody.velocity,ForceMode.VelocityChange);
        playerRigidBody.AddTorque(-playerRigidBody.angularVelocity,ForceMode.VelocityChange);

        float verticalRotAngle = -rotateVertical * mouseSensitivity * Time.fixedDeltaTime;

        Quaternion qVerticalRot = Quaternion.AngleAxis(verticalRotAngle, Vector3.right);
        Quaternion qNewVerticalLocalOrient = qVerticalRot * CameraTransform.localRotation;
        CameraTransform.localRotation = qNewVerticalLocalOrient;

        
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(FirePoint.forward * bulletForce, ForceMode.Impulse);
        
        Destroy(Instantiate(Audio), 1);
    }
}
