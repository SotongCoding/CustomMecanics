/*
The MIT License (MIT)

Copyright (c) 2016 GuyQuad

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

You can contact me by email at guyquad27@gmail.com or on Reddit at https://www.reddit.com/user/GuyQuad
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (EdgeCollider2D))]
[RequireComponent (typeof (MeshFilter))]
[RequireComponent (typeof (MeshRenderer))]
public class SearchLight : MonoBehaviour {
    [Header ("Basic Data")]
    [Range (1, 25)]
    public float radius = 3;
    [Range (10, 90)]
    public int smoothness = 24;

    [Range (10, 360)]
    public int totalAngle = 360;

    [Range (0, 360)]
    public float offsetRotation = 0;
    public LayerMask hitLayer;

    [Header ("Let there be Pizza")]
    public bool pizzaSlice;

    Vector2 origin, center;
    EdgeCollider2D edgeCollider;

    [Header ("Drawing Data")]
    Mesh mesh;
    private void Start () {
        mesh = new Mesh ();
        GetComponent<MeshFilter> ().mesh = mesh;
        origin = transform.localPosition;
    }
    private void Update () {

        edgeCollider = GetComponent<EdgeCollider2D> ();
        if (edgeCollider == null) {
            gameObject.AddComponent<EdgeCollider2D> ();
            edgeCollider = GetComponent<EdgeCollider2D> ();
        }
        edgeCollider.points = getPoints (edgeCollider.offset);

        Vector2 targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

        setAimDir (targetPos - (Vector2) transform.position);
        DarwMaterial ();

    }

    public Vector2[] getPoints (Vector2 off) {
        List<Vector2> points = new List<Vector2> ();

        origin = transform.localPosition;
        center = origin + off;

        float ang = offsetRotation;

        if (pizzaSlice && totalAngle % 360 != 0) points.Add (center);

        for (int i = 0; i <= smoothness; i++) {
            float x = center.x + radius * Mathf.Cos (ang * Mathf.Deg2Rad);
            float y = center.y + radius * Mathf.Sin (ang * Mathf.Deg2Rad);

            Vector2 target = new Vector2 (x, y) + (Vector2) transform.position;
            Vector2 dir = GetVectorFromAngle (ang);

            RaycastHit2D hit = Physics2D.Raycast (this.transform.position, dir, radius, hitLayer);
            if (hit.collider == null) {
                //Null
                points.Add (new Vector2 (x, y));
            } else {
                points.Add ((hit.point) - (Vector2) transform.position);
            }
            ang -= (float) totalAngle / smoothness;
        }

        if (pizzaSlice && totalAngle % 360 != 0) points.Add (center);

        return points.ToArray ();
    }
    void DarwMaterial () {
        float angle = offsetRotation;

        float angleIncrease = totalAngle / smoothness;

        Vector3[] vertices = new Vector3[smoothness + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[smoothness * 3];

        vertices[0] = origin;

        int vertexI = 1;
        int triangleI = 0;
        for (int i = 0; i <= smoothness; i++) {
            Vector2 vertex;

            RaycastHit2D hit2D = Physics2D.Raycast (transform.position, GetVectorFromAngle (angle), radius, hitLayer);

            if (hit2D.collider == null) {
                vertex = origin + (Vector2) GetVectorFromAngle (angle) * radius;
            } else {
                vertex = hit2D.point - (Vector2) transform.position;
            }
            vertices[vertexI] = vertex;

            if (i > 0) {
                triangles[triangleI + 0] = 0;
                triangles[triangleI + 1] = vertexI - 1;
                triangles[triangleI + 2] = vertexI;
                triangleI += 3;
            }
            vertexI++;

            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }
    Vector3 GetVectorFromAngle (float angle) {
        float angRad = angle * (Mathf.PI / 180f);
        return new Vector3 (
            Mathf.Cos (angRad),
            Mathf.Sin (angRad)
        );
    }
    float GetAngleFormVector (Vector2 input) {

        input = input.normalized;
        float n = Mathf.Atan2 (input.y, input.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;

    }
    public void setAimDir (Vector2 dir) {
        offsetRotation = GetAngleFormVector (dir) + (float) (totalAngle / 2);
    }
}