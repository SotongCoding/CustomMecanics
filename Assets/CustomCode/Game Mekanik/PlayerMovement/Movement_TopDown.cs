using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_TopDown : BaseMovement {
    [Header ("Top Down Data")]
    public Transform rotateObj;

    private void Update () {
        SetAimDir (rotateObj,
            Camera.main.ScreenToWorldPoint (Input.mousePosition));

        Move();
    }
    protected override void Move () {
        if (Input.GetKey (up)) this.transform.Translate (Vector2.up * Time.fixedDeltaTime * speed);

        else if (Input.GetKey (down)) this.transform.Translate (Vector2.down * Time.fixedDeltaTime * speed);

        else if (Input.GetKey (right)) this.transform.Translate (Vector2.right * Time.fixedDeltaTime * speed);

        else if (Input.GetKey (left)) this.transform.Translate (Vector2.left * Time.fixedDeltaTime * speed);
    }

    protected override void SetAimDir (Transform rotateObject, Vector2 targetPos) {
        Vector2 objPos = rotateObject.position;
        Vector2 heading = targetPos - objPos;

        rotateObject.transform.up = heading;
    }
}