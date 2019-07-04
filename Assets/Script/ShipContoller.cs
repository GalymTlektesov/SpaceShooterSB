using UnityEngine;

public class ShipContoller : MonoBehaviour
{
    public static Rigidbody ship;// корабль
    public float speed; // скорость

    public float tilt; // вращение при движении

    // максимальные и минимальные координаты
    public float xmin;
    public float xmax;
    public float zmin;
    public float zmax;
    // максимальные и минимальные координаты

    public float shotDelay; // задержка выстерла
    private float nextshot; //время когда можно стрелять

    public GameObject LazerShot;// Выстрел
    public Transform LazerGun;// Пушка

    void Start()
    {
        ship = GetComponent<Rigidbody>(); // добавляем компонент
    }

    private void Update()
    {
        bool canShoot = Time.time > nextshot;
        if (Input.GetButton("Fire1") && canShoot)// Выстрел
        {
            nextshot = Time.time + shotDelay;
            Instantiate(LazerShot, LazerGun.position, Quaternion.Euler(-90, 180, 0));
        }// Выстрел
    }

    private void FixedUpdate()
    { 
        float moveHorizontal = Input.GetAxis("Horizontal");// горизонтальное перемещение
        float moveVertical = Input.GetAxis("Vertical");// вертикальное перемещение 

        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed; // движение и скорость движение

        float xPosition = Mathf.Clamp(ship.position.x, xmin, xmax);// вращение по осм х
        float zPosition = Mathf.Clamp(ship.position.z, zmin, zmax);// вращение по оси z 

        ship.position = new Vector3(xPosition, 0, zPosition);// истиное перемещение 
        
        ship.rotation = Quaternion.Euler(ship.velocity.z * tilt, 0, -ship.velocity.x * tilt);// истиное вращение
    }
}
