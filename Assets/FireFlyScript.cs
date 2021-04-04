using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyScript : MonoBehaviour
{

    public GameObject LazerShot;//выстрел
    public Transform LazerGun;//центральная пушка
    public Transform LazerGun1;//крайняя левая пушка
    public Transform LazerGun2;//левая пушка
    public Transform LazerGun3;//правая пушка
    public Transform LazerGun4;//крайняя правая пушка
    public float speed;//коэф скорости
    public float tilt; //коэф поворота
    public float xMin, xMax, zMin, zMax;
    Rigidbody StarShip;


    // Start is called before the first frame update
    void Start()
    {
        StarShip = GetComponent<Rigidbody>();
        //StarShip.velocity = new Vector3(15,0,25);

        StartCoroutine(Countdown());//запуск корутины
    }

    // Update is called once per frame
    void Update()
    {
        if (!Controller.isStarted)
        {
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal"); //куда лететь по горизонтали
        float moveVertical = Input.GetAxis("Vertical"); //куда лететь по вертикали
        StarShip.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        float clampedx = Mathf.Clamp(StarShip.position.x, xMin, xMax);//наклон при движении влево
        float clampedz = Mathf.Clamp(StarShip.position.z, zMin, zMax);//наклон при движении вправо

        StarShip.position = new Vector3(clampedx, 0, clampedz);

        StarShip.rotation = Quaternion.Euler(StarShip.velocity.z * tilt, 0, -StarShip.velocity.x * tilt);      
    }

    private IEnumerator Countdown()
    {
        while (true)
        {
            if (Input.GetButton("Fire1"))//делаем выстрел
            {
                var go = Instantiate(LazerShot, LazerGun.position, Quaternion.identity);
                var go1 = Instantiate(LazerShot, LazerGun1.position, Quaternion.identity);
                var go2 = Instantiate(LazerShot, LazerGun2.position, Quaternion.identity);
                var go3 = Instantiate(LazerShot, LazerGun3.position, Quaternion.identity);
                var go4 = Instantiate(LazerShot, LazerGun4.position, Quaternion.identity);

                

                Destroy(go, 2f);//разрушаем выстрел через 2 секунды
                Destroy(go1, 2f);
                Destroy(go2, 2f);
                Destroy(go3, 2f);
                Destroy(go4, 2f);
            }
            yield return new WaitForSeconds(0.2f);//повторить выполнение через секунду

        }

    }
}
