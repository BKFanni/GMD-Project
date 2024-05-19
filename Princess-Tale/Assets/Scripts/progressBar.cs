using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    public Image fillBar;
    public Transform levelFinishPoint;
    public TMP_Text levelNumberTextLeft;
    public TMP_Text levelNumberTextRight;

    private Transform player;


    void Awake()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }



    void Update()
    {
        // Check if the left level number text is '2'
        if (levelNumberTextLeft.text == "2")
        {
            fillBar.fillAmount = 0;
        }

        if (player != null && fillBar != null && levelFinishPoint != null)
        {
            float distanceToFinish = Vector3.Distance(player.position, levelFinishPoint.position);
            float totalDistance = Vector3.Distance(transform.position, levelFinishPoint.position);
            float progressPercentage = 1f - (distanceToFinish / totalDistance);

            fillBar.fillAmount = progressPercentage;
        }

    }


}
