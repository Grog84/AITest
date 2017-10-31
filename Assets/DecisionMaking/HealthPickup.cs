using UnityEngine;
public class HealthPickup : MonoBehaviour
{
    public float bonusHealth = 5;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<HealthState>())
        {
            other.GetComponent<HealthState>().health += bonusHealth;
            Destroy(this.gameObject);
        }
    }

}
