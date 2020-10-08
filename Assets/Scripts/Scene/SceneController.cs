using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Player player;

    private void OnEnable()
    {
        player.isDead += ReloadScene;
    }
    
    private void OnDisable()
    {
        player.isDead -= ReloadScene;
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
