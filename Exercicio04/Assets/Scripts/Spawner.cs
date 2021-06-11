using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] ball;

    private void Start()
    {
        InvokeRepeating("Atirar", 5, 5);
    }


    Vector3 PosicaoAleatorio()
    {
        float numX = transform.position.x + Random.Range(-5, 5);
        float numY = transform.position.y;
        float numZ = transform.position.z;

        Vector3 newPos = new Vector3(numX, numY, numZ);
        return newPos;

    }

    void Atirar()
    {
        Instantiate(ball[0], PosicaoAleatorio(), Quaternion.identity);
    }

}
