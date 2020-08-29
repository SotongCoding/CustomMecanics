using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour {
    // Start is called before the first frame update
    [Header ("Basic Data")]
    public KeyCode up;
    public KeyCode down, left, right;

    public float speed;

    private bool isMove;
    private Vector2 moveDir;
    [Header ("Top Down Data")]
    public Transform rotateObj;
    private void Update () {
        SetAimDir (rotateObj,
            Camera.main.ScreenToWorldPoint (Input.mousePosition));

        Move ();
    }
    void Move () {
        if (Input.GetKey (up)) {
            this.transform.Translate (Vector2.up * Time.fixedDeltaTime * speed);
            moveDir += Vector2.up;

        } else if (Input.GetKey (down)) {
            this.transform.Translate (Vector2.down * Time.fixedDeltaTime * speed);
            moveDir += Vector2.down;

        } else if (Input.GetKey (right)) {
            this.transform.Translate (Vector2.right * Time.fixedDeltaTime * speed);
            moveDir += Vector2.right;

        } else if (Input.GetKey (left)) {
            this.transform.Translate (Vector2.left * Time.fixedDeltaTime * speed);
            moveDir += Vector2.left;
        }

        if (Input.GetKey (up) || Input.GetKey (down) || Input.GetKey (right) || Input.GetKey (left)) {
            isMove = true;
        } else {
            moveDir = Vector2.zero;
            isMove = false;
        }
    }
    public bool GetMoveStatus () {
        return isMove;
    }
    public Vector2 GetMoveDiriction () {
        int x = moveDir.x > 0 ? 1 : moveDir.x < 0 ? -1 : 0;
        int y = moveDir.y > 0 ? 1 : moveDir.y < 0 ? -1 : 0;
        return new Vector2 (x, y); //moveDir.normalized;
    }

    void SetAimDir (Transform rotateObject, Vector2 targetPos) {
        if (rotateObj != null) {
            Vector2 objPos = rotateObject.position;
            Vector2 heading = targetPos - objPos;

            rotateObject.transform.up = heading;
        }
    }
}