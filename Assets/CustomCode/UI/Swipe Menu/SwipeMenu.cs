using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour {
    public GameObject scrollbar, content;
    RectTransform content_rect;
    private float scroll_pos = 0;
    public float[] pos;

    //Zone Size 
    public float itemSize;
    public float contentSize;
    // Start is called before the first frame update
    void Start () {
        content_rect = content.GetComponent<RectTransform> ();

        Debug.LogWarning (content_rect.sizeDelta.x);
        itemSize = content.transform.GetChild (0).GetComponent<RectTransform> ().sizeDelta.x + content.GetComponent<HorizontalLayoutGroup> ().spacing; //size + spacing

        pos = new float[content.transform.childCount];
        for (int i = 0; i < pos.Length; i++) {
            pos[i] = itemSize * i * -1;
        }

    }

    // Update is called once per frame
    void Update () {
        contentSize = content_rect.sizeDelta.x;
        if (Input.GetMouseButton (0)) {
            scroll_pos = content_rect.anchoredPosition.x;
        } else {
            for (int i = 0; i < pos.Length; i++) {
                if (scroll_pos < pos[i] + (itemSize / 2) && scroll_pos > pos[i] - (itemSize / 2)) {
                    content_rect.anchoredPosition = new Vector2 (
                        Mathf.Lerp (content_rect.anchoredPosition.x, pos[i], 1f), 0);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++) {
            if (scroll_pos < pos[i] + (itemSize / 2) && scroll_pos > pos[i] - (itemSize / 2)) {
                content.transform.GetChild (i).localScale = Vector2.Lerp (content.transform.GetChild (i).localScale, new Vector2 (1.2f, 1.2f), 0.1f);
                for (int j = 0; j < pos.Length; j++) {
                    if (j != i) {
                        content.transform.GetChild (j).localScale = Vector2.Lerp (content.transform.GetChild (j).localScale, new Vector2 (0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }

    }
}