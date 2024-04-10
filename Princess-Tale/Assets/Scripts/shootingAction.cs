using UnityEngine;
using UnityEngine.Events;

public class shootingAction : MonoBehaviour
{
    public UnityEvent action;
    public void Action()
    {
        action?.Invoke();
    }
}
