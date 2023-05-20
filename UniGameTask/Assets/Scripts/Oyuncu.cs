using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oyuncu : MonoBehaviour
{
    [SerializeField] GameObject Sharig;
    [SerializeField] Transform gulleCixisNoqtesi;

    [SerializeField] float vertical;
    [SerializeField] float horizontal;
    [SerializeField] GameObject Player;
    [SerializeField] float speed = 6f;

    [SerializeField] int Puanlar;


    Vector3 Direction;
    float CurrentTurnAngle;
    float SmoothTurnTime = 0.04f;
    float Angle;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Sharig, gulleCixisNoqtesi.position, transform.rotation);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.rotation *= Quaternion.Euler(0f, -1f, 0f * speed* Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.rotation *= Quaternion.Euler(0f, 1f, 0f * speed* Time.deltaTime);
        }
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Direction = new Vector3(horizontal, 0f, vertical);
        if (Direction.magnitude > 0.01f)
        {
            float TargetAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg;
            Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref CurrentTurnAngle, SmoothTurnTime);
            transform.rotation = Quaternion.Euler(0f, Angle, 0f);
            rb.MovePosition(transform.position + (Direction.normalized * speed * Time.deltaTime));
        }




        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -12f, 14f), transform.position.y, Mathf.Clamp(transform.position.z, -10f, 10f));
        //float PosX = Mathf.Clamp(transform.position.x,-10f, 10f);
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -12f, 14f), transform.position.z, -12f, 19f);
        //transform.Translate(Mathf.Clamp(transform.position.x, -12f, 14f), transform.position.z, 19f);



    }

     
}
