using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float initTime;
    [SerializeField] private float repeatTime;
    [SerializeField] private int generatorType;
    private int enemiesNumber;

    //velocidad del generador 2
    private float generator2speed = 2f;

    void Start()
    {
        InvokeRepeating("GenerateEnemies", initTime, repeatTime);

    }
        void Update()
        {
            MoveGenerator2();
        }
        public void GenerateEnemies()
        {
            //si el numero de enemigos es menor a 5, activa el instantiate
           if(enemiesNumber<5)
            {
                Instantiate(enemy, transform.position, transform.rotation);
                enemiesNumber++;
            }
        }

        public void MoveGenerator2()
        {
            //si el segundo generador, se movera hacia arriba y hacia abajo en un rango
            if (generatorType == 2)
            {
                if (transform.position.z < -4f || transform.position.z > 4f)
                {
                    generator2speed *= -1;
                }

                transform.Translate(0, 0, generator2speed * Time.deltaTime);
            }
        }
}