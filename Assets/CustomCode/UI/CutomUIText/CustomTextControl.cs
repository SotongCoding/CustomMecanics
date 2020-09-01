using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomTextControl : MonoBehaviour {
    public TextMeshProUGUI targetText;
    // Start is called before the first frame update
    void Start () {
        targetText.text =
            CustomUIText.TextColor ("This Color text", Color.green) + "\n" +
            CustomUIText.TextSize ("Change size Text", 200) + "\n" +
            CustomUIText.B_I_U_Text ("this Bold", CustomUIText.TextType.bold) + "\n" +
            CustomUIText.B_I_U_Text ("this Italic", CustomUIText.TextType.italic) + "\n" +
            CustomUIText.B_I_U_Text ("this UnderLine", CustomUIText.TextType.underline) + "\n\n" +
            CustomUIText.ChangeText ("this ALGERIAN Text", "ALGER SDF") + "\n" +
            CustomUIText.ChangeText ("this ITECDSCR", "ITCEDSCR SDF") + "\n";

    }

    // Update is called once per frame
    void Update () {

    }
}