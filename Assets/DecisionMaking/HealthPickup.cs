using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour
{
    public float bonusHealth = 5;
    public bool isEnabled = true;
    private SpriteRenderer m_Renderer;

    private void Awake()
    {
        m_Renderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<HealthState>())
        {
            other.GetComponent<HealthState>().health += bonusHealth;
            isEnabled = false;
            ChangeColor();
            StartCoroutine(ReEnable());
        }
    }

    public IEnumerator ReEnable()
    {
        yield return new WaitForSeconds(20);
        isEnabled = true;
        yield return null;
        ChangeColor();
    }

    private void ChangeColor()
    {
        if (isEnabled)
            m_Renderer.color = Color.green;
        else
            m_Renderer.color = Color.red;
    }

}
