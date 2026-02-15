using UnityEngine;

public class SlowHealZone : MonoBehaviour
{
    public int heal;
    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(heal);
        }
       
       
    }
}