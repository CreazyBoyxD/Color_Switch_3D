using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] AudioSource FinishSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FinishSound.Play();
            Invoke("Next", 2f);
        }
    }

    public void Next()
    {
        FindObjectOfType<DistanceScore>().SaveDistanceScore();
        FindObjectOfType<GameManager>().SavePointsScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
