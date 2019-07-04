using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody shipenemy;// корабль

    public float minspeed;
    public float maxspeed;


    public float shotDelay; // задержка выстерла
    private float nextshot; //время когда можно стрелять

    public GameObject LazerShot;// Выстрел
    public Transform LazerGun;// Пушка

    public GameObject explosion;
    public GameObject playerExplosion;

    void Start()
    {
        shipenemy = GetComponent<Rigidbody>(); // добавляем компонент
        shipenemy.velocity = Vector3.back * Random.Range(minspeed, maxspeed);
    }

    //Интелект вражеского коробля
    private void Update()
    {
        //преследование игрока
        shipenemy.position = Vector3.MoveTowards(shipenemy.position,
            new Vector3(ShipContoller.ship.transform.position.x, 0, shipenemy.position.z),
            0.1f);
        shipenemy.rotation = Quaternion.Euler(shipenemy.velocity.z * 5, 0, -shipenemy.velocity.x * 5);// истиное вращение

        //выстрел
        bool canShoot = Time.time > nextshot;
        if ((System.Math.Abs(shipenemy.position.x - ShipContoller.ship.transform.position.x) < 0.3f) && canShoot)// Выстрел
        {
            nextshot = Time.time + shotDelay;
            Instantiate(LazerShot, LazerGun.position, Quaternion.identity);
        }// Выстрел
    }


    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "gameArea") || (other.tag == "asteroid"))
        {
            return;
        }

        if (other.tag == "Player")
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
