using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour {
    // Start is called before the first frame update
    [Header ("Basic Data")]
    public KeyCode up;
    public KeyCode down, left, right;

    public float speed;
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    protected virtual void Move () {

    }

    protected virtual void SetAimDir (Transform rotateObject, Vector2 targetPos) {

    }
}