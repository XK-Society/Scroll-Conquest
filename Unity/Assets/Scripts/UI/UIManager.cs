using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

     private void Awake()
    {
        gameOverScreen.SetActive(false);
    }
    #region Game Over
    public void GameOver()
    {   
        
        gameOverScreen.SetActive(true);
        if (SoundManager.instance != null)
        {
            SoundManager.instance.PlaySound(gameOverSound);
        }
       
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    #endregion 
}
