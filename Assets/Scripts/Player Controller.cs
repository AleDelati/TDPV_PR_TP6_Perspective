using UnityEngine;

public class PlayerController : MonoBehaviour {

    private GameManager GM;
    private GameObject map;

    private Vector3 initialPos;
    private Quaternion mapInitialRot;

    private GameObject parentA;
    private GameObject parentB;

    private bool winCondition = false;

    private void Start() {
        GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
        map = GameObject.Find("Level");

        parentA = map;
        parentB = GameObject.Find("---- | Map | ----");

        initialPos = transform.position;
        mapInitialRot = map.transform.rotation;
    }

    private void Update() {
        CheckInput();
        CheckPlayerFall();
        CheckCollisions();
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    private void CheckInput() {
        if(winCondition == false) {
            //Move R
            if (Input.GetKeyDown(KeyCode.D)) {
                if (CheckMove(new Vector3(0, 0, -1)) == true) {
                    transform.position = transform.position + new Vector3(0, 0, -1);
                } else if (CheckClimb(new Vector3(0, 0, -1)) == true) {
                    transform.position = transform.position + new Vector3(0, 1, -1);
                }
            }
            if (Input.GetKeyUp(KeyCode.D)) {

            }
            //Move L
            if (Input.GetKeyDown(KeyCode.A)) {
                if (CheckMove(new Vector3(0, 0, 1)) == true) {
                    transform.position = transform.position + new Vector3(0, 0, 1);
                } else if (CheckClimb(new Vector3(0, 0, 1)) == true) {
                    transform.position = transform.position + new Vector3(0, 1, 1);
                }
            }
            if (Input.GetKeyUp(KeyCode.A)) {

            }
        }
        //Rotate Map
        if (Input.GetKeyDown(KeyCode.E)) {
            map.transform.Rotate(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            map.transform.Rotate(0, -90, 0);
        }
        //
        if (Input.GetKeyDown(KeyCode.R)) {
            ResetLevel();
        }
    }

    private bool CheckMove(Vector3 pos) {
        bool clear = true;
        foreach (Collider collider in Physics.OverlapBox(transform.position + pos, new Vector3(0.25f, 0.25f, 0.25f))) {
            if (collider.CompareTag("Platform") == true || collider.CompareTag("Platform Fixed") == true) {
                clear = false;
            }
        }
        return clear;
    }

    private bool CheckClimb(Vector3 pos) {
        bool clear = true;
        foreach (Collider collider in Physics.OverlapBox(transform.position + pos + new Vector3(0, 1, 0), new Vector3(0.25f, 0.25f, 0.25f))){
            if (collider.CompareTag("Platform") == true || collider.CompareTag("Platform Fixed") == true) {
                clear = false;
            }
        }
        return clear;
    }

    private void CheckPlayerFall() {
        if(transform.position.y <= -10) {
            ResetLevel();
        }
    }

    private void CheckCollisions() {
        foreach(Collider collider in Physics.OverlapBox(transform.position, transform.localScale)) {
            if(collider.CompareTag("Finish Block") == true) { GM.WinCondition(); winCondition = true; }
            if(collider.CompareTag("Platform") == true){ gameObject.transform.parent = parentA.transform; }
            if(collider.CompareTag("Platform Fixed") == true){ gameObject.transform.parent = parentB.transform; }
        }
    }

    private void ResetLevel() {
        transform.position = initialPos;
        map.transform.rotation = mapInitialRot;
        winCondition = false;
        GM.ResetLevel();
    }

}
