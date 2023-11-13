using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   //Bala enemiga que va a disparar 
   [SerializeField] private GameObject EnemyBullet; 
   //Velocidad en X
    [SerializeField] private float SpeedX; 
     //Velocidad en Z
    [SerializeField] private float SpeedZ;
     //Tipo de enemigo (1 o 2)
    [SerializeField] private int enemyTipe;
    //velocidad en X del enemigo 2
    private float Enemy02SpeedX =2f; 
    //tiempo aleatorio entre cada bala
    private float randomTime=0;  

    void Start()
    {
        switch (enemyTipe)
        {
            // si es el enemigo de tipo 1, dispara de forma ordenada cada 2 segundos
            case 1: 
                {
                    InvokeRepeating("Shoot", 0, 2f);  //invoca a shoot constantemente, cada 2 segundos
                    break;
                }
             //si el enemigo es de tipo 2, dispara balas al azar 
            case 2:
                {
                   //Invoca el metodo de disparo y lo hace aleatorio
                    Invoke("Shoot", randomTime);
                    break;
                }
        }
    }

        void Update()
        {
            Move();
        }
 
        public void Shoot()  
        {
            //Instancia la bala y le cambia la posicion y la rotacion
            Instantiate(EnemyBullet, transform.position, transform.rotation);
            //si el enemigo es de tipo2, crea un rango entre cada disparo
            if (enemyTipe == 2)
            {
                randomTime = Random.Range(1, 4);
                Invoke("Shoot", randomTime);
            }
        }

        public void Move()
        {
            switch (enemyTipe)
            {
                //el enemigo de tipo 1 se mueve en los ejes Z y X a la vez
                case 1:
                    {
                        transform.Translate(SpeedX * Time.deltaTime, 0, SpeedZ * Time.deltaTime);
                        if (transform.position.x < -4.45f)
                        {
                          Destroy(this.gameObject);
                        }
                        break;

                    }
                 //el enemigo de tipo 2 se mueve en el eje X y rebota contra los limites   
                case 2:
                    {
                        if (transform.position.x < -4f || transform.position.x > 4f)
                        {
                            Enemy02SpeedX *= -1;
                        }

                        transform.Translate(Enemy02SpeedX * Time.deltaTime, 0, 0);
                        break;
                    }

            }
        }

    }
