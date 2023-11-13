using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float SpeedZ;

    void Update()
    {
        transform.Translate(0, 0, SpeedZ * Time.deltaTime);
        if (transform.position.z < -4.80f || transform.position.z > 4.80f)
        {
            Destroy(this.gameObject);
        }
    }
}
