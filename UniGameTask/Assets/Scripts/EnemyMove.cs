using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Oyuncu oyuncu;
    void Start()
    {
        oyuncu = FindObjectOfType<Oyuncu>();
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,oyuncu.transform.position,.2f*Time.deltaTime);
       // transform.Translate(oyuncu.transform.position*Time.deltaTime, Space.World);
    }
}
