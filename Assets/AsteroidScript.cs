using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject AsteroidExplotion;
    public GameObject FireFlyExplosion;
    public Rigidbody asteroidBody;//���� ������ ���������
    public float speed;
    public float rotationSpeed;

    float size;//������ ��������� � ���������
    // Start is called before the first frame update
    void Start()
    {
        size = Random.Range(0.5f, 2.0f);//��������� ������
        Rigidbody Asteroid = GetComponent<Rigidbody>();
        asteroidBody.angularVelocity = Random.insideUnitSphere * rotationSpeed;

        float speedX = 0;
        if (Random.Range(0, 100) < 30)//����������� � 30% �������
        {
            speedX = speed * Random.Range(-0.5f, 0.5f);
        }

        asteroidBody.velocity = new Vector3(speedX, 0, -speed) / size;
        Asteroid.velocity = new Vector3(speedX, 0, -speed) / size;
        Asteroid.transform.localScale *= size;//��������� ������ ���������

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //����� ���������� ��� ������������ � ������ �����������
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            return;
        }

        Instantiate(AsteroidExplotion, transform.position, Quaternion.identity);//���������� ����� ���������

        if (other.tag == "Player")
        {
            Instantiate(FireFlyExplosion, other.transform.position, Quaternion.identity);
        }
        Controller.score += 10;//����������� ���-�� ����� �� 10
        Destroy(gameObject);//���������� ��������
        Destroy(other.gameObject);//���������� ������ ������
        
        if (other.tag == "Player")
        {
            new WaitForSeconds(2);
            PauseSkript.LoseGame();
        }
    }
}

