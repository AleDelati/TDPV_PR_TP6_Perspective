using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    [SerializeField] private bool tutorialA = true;

    private Canvas levelCompleted;
    private GameObject tutTextA_1;
    private GameObject tutTextA_2;

    private float tutATimer = 255.0f;

    private void Start() {
        levelCompleted = GameObject.Find("Level Completed UI").GetComponent<Canvas>();
        tutTextA_1 = GameObject.Find("tutTextA_1");
        tutTextA_2 = GameObject.Find("tutTextA_2");
    }

    private void Update() {
        if(tutorialA){ TutorialAManager(); }
    }

    private void TutorialAManager(){
        if(tutATimer > 1) {
            tutATimer = tutATimer - 50 * Time.deltaTime;
        }
        tutTextA_1.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, (byte)tutATimer);
        tutTextA_2.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, (byte)tutATimer);
    }

    public void WinCondition() {
        levelCompleted.enabled = true;
    }

    public void ResetUI() {
        levelCompleted.enabled = false;

        tutATimer = 255.0f;
    }

}
