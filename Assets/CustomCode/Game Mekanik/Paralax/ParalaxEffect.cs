using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxEffect : MonoBehaviour {
    public List<ParalaxObject> paralaxObj;
    public bool onPlayerMove;
    BaseMovement movement;

    private void Awake () {
        movement = FindObjectOfType<BaseMovement> ();
    }

    private void FixedUpdate () {
        onPlayerMove = movement.GetMoveStatus ();

        if (onPlayerMove) {
            foreach (ParalaxObject item in paralaxObj) {
                item.Move (Vector2.left * movement.GetMoveDiriction().x);
            }
        }
    }
}

[System.Serializable]
public class ParalaxObject {
    public Transform obj;
    public float speed;

    public void Move (Vector2 direction) {
        obj.transform.Translate (direction * speed * Time.fixedDeltaTime);
    }
}