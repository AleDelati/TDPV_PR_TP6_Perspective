using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField] private int targetFPS = 60;

    private UIManager UIM;

    private bool winCondition = false;

    private void Start() {
        Application.targetFrameRate = targetFPS;

        UIM = GameObject.Find("---- |   UI   | ----").GetComponent<UIManager>();
    }

    public void WinCondition() {
        winCondition = true;
        UIM.WinCondition();
        Debug.Log("Win Condition");
    }

    public void ResetLevel() {
        winCondition = false;
        UIM.ResetUI();
    }

    public void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
