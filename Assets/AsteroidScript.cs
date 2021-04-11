using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject AsteroidExplotion;
    public GameObject FireFlyExplosion;
    public Rigidbody asteroidBody;//сама модель астероида
    public float speed;
    public float rotationSpeed;

    float size;//размер астероида в процентах
    // Start is called before the first frame update
    void Start()
    {
        size = Random.Range(0.5f, 2.0f);//случайный размер
        Rigidbody Asteroid = GetComponent<Rigidbody>();
        asteroidBody.angularVelocity = Random.insideUnitSphere * rotationSpeed;

        float speedX = 0;
        if (Random.Range(0, 100) < 30)//срабатывает в 30% случаев
        {
            speedX = speed * Random.Range(-0.5f, 0.5f);
        }

        asteroidBody.velocity = new Vector3(speedX, 0, -speed) / size;
        Asteroid.velocity = new Vector3(speedX, 0, -speed) / size;
        Asteroid.transform.localScale *= size;//случайный размер астероида

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //метод вызывается при столкновении с другим коллайдером
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            return;
        }

        Instantiate(AsteroidExplotion, transform.position, Quaternion.identity);//показываем взрыв астероида

        if (other.tag == "Player")
        {
            Instantiate(FireFlyExplosion, other.transform.position, Quaternion.identity);
        }
        Controller.score += 10;//увеличиваем кол-во очков на 10
        Destroy(gameObject);//уничтожаем астероид
        Destroy(other.gameObject);//уничтожаем второй объект
        
        if (other.tag == "Player")
        {
            new WaitForSeconds(2);
            PauseSkript.LoseGame();
        }
    }
}

