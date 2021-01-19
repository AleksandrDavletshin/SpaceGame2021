using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject asteroid;
    public float minDelay, maxDelay;//задержка между запусками астероида

    float nextLaunchTime;//время след. запуска
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextLaunchTime)
        {
            //пора запускать астероид
            //выбираем случайную точку по оси Х(слева или справа)
            float left = -transform.localScale.x / 2;
            float right = transform.localScale.x / 2;

            float posX = Random.Range(left, right);
            float posY = transform.position.y;
            float posZ = transform.position.z;

            //создаем астероид
            Instantiate(asteroid, new Vector3(posX, posY, posZ), Quaternion.identity);

            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
