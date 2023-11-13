using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
   [SerializeField] private GameObject playerBullet;
    private float speedX;//velocidad en el eje X


    void Start()
    {
        speedX = 2f; //velocidad a la que se movera en el eje X
    }
    void Update()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal") * speedX * Time.deltaTime, 0, 0); //Se normaliza con deltaTime y se le asigna las teclas
        if (Input.GetKey(KeyCode.Space))
        {
            PlayerShoot();   
        }
    }

    private void PlayerShoot()
    {
        Instantiate(playerBullet, transform.position, transform.rotation);
    }
}
