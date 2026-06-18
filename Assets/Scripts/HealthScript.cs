using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int health = 10;
    [SerializeField] private Slider healthBarValue;

    private void Start()
    {
        healthBarValue.value = health;
    }

    public void TakeDamage()
    {
        health--;
        healthBarValue.value = health;
    }
}
