using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    public Image fillBar;
    public Transform player;
    public Transform levelFinishPoint;
    public TMP_Text levelNumberTextLeft;
    public TMP_Text levelNumberTextRight;

    private int currentLevel = 1;

    void Update()
    {if(player != null){
        float distanceToFinish = Vector3.Distance(player.position, levelFinishPoint.position);
        float totalDistance = Vector3.Distance(transform.position, levelFinishPoint.position);
        float progressPercentage = 1f - (distanceToFinish / totalDistance);

        fillBar.fillAmount = progressPercentage;

        levelNumberTextLeft.text = currentLevel.ToString();
        levelNumberTextRight.text = (currentLevel + 1).ToString();
    }
    }

    public void SetCurrentLevel(int level)
    {
        currentLevel = level;
    }
}
