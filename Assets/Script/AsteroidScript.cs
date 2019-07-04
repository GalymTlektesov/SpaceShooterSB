using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidScript : MonoBehaviour
{
    public float rotationSpeed;
    public float minspeed;
    public float maxspeed;

    public GameObject explosion;
    public GameObject playerExplosion;


    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;


        asteroid.velocity = Vector3.back * Random.Range(minspeed, maxspeed);
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
            ScoreScript.score = 0;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }


}
