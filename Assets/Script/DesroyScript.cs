using UnityEngine;
using UnityEngine.SceneManagement;

public class DesroyScript : MonoBehaviour
{
    public GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "asteroid")
        {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(other.gameObject);
            ScoreScript.score = 0;
        }
    }
}
