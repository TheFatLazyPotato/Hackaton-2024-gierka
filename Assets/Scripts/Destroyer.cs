using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object has the tag "NPC"
        if (other.CompareTag("NPC"))
        {
            // Destroy the NPC object
            Destroy(other.gameObject);
            Debug.Log("NPC destroyed: " + other.name);
        }
    }
}
