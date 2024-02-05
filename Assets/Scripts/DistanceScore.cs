using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DistanceScore : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public Transform startPoint;
    public float scoreMultiplier = 1.0f;
    private float maxDistance;
    private int distance;

    void Update()
    {
        float currentDistance = Vector3.Distance(startPoint.position, transform.position);

        if (currentDistance > maxDistance)
        {
            maxDistance = currentDistance;
            distance = Mathf.RoundToInt(maxDistance * scoreMultiplier);
        }

        distanceText.text = "Distance: " + distance;
    }

    public void SaveDistanceScore()
    {
        int previousDistance = PlayerPrefs.GetInt("TotalDistance");
        PlayerPrefs.SetInt("TotalDistance", previousDistance + distance);
        PlayerPrefs.Save();
    }
}
