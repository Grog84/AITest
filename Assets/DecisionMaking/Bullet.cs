using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float maxTravelDistance = 15f;

    private float travelledDistance = 0f;

    public int team;

    public void SetTeam(int teamNbr)
    {
        team = teamNbr;
        if (team == 0)
            GetComponent<SpriteRenderer>().color = Color.red;
        if (team == 1)
            GetComponent<SpriteRenderer>().color = Color.blue;
        if (team == 2)
            GetComponent<SpriteRenderer>().color = Color.green;
    }

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
        travelledDistance += Time.deltaTime * speed;
        if (travelledDistance >= maxTravelDistance)
            Destroy(this.gameObject);
    }


}
