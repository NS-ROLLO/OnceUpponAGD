
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider cld)
    {
        if (cld.gameObject.tag == "Player")
        {
          SceneManager.LoadScene("DeathScene");
        }
       
    }
}
