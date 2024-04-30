using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpoint;
    private Transform currentCheckpoint;
    private Health playerHealth;
    private UIManager uiManager;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void CheckRespawn()
    {   
        // Check if checkpoint is available
        if (currentCheckpoint == null)
        {
            // Show game over screen only when the player dies
            if (playerHealth.IsDead())
            {
                uiManager.GameOver();
            }
            return; // Don't execute the rest of this function 
        }

        // Restore player health and reset animation
        playerHealth.Respawn(); 
        // Move player to checkpoint location
        transform.position = currentCheckpoint.position; 

        // Move the camera to the checkpoint's room
        Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            if (SoundManager.instance != null)
            {
                SoundManager.instance.PlaySound(checkpoint);
            }
            
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
}
