using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomUIText {
    public static string TextColor (string text, Color32 color) {
        string coloroHex = ColorUtility.ToHtmlStringRGB (color);
        return "<color=#" + coloroHex + ">" + text + "</color>";
    }
    public static string TextSize (string text, int size) {
        return "<size=" + size + ">" + text + "</size>";
    }
    public static string B_I_U_Text (string text, TextType type) {
        if (type == TextType.bold) {
            return "<b>" + text + "</b>";
        } else if (type == TextType.italic) {
            return "<i>" + text + "</i>";
        } else if (type == TextType.underline) {
            return "<u>" + text + "</u>";
        }
        return "";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <param name="fontAssetName">Look at TMPProSetting for Font asset Placement</param>
    /// <returns></returns>
    public static string ChangeText (string text, string fontAssetName) {
        return "<font=" + fontAssetName + ">" + text + "</font>";
    }

    public enum TextType {
        bold,
        italic,
        underline
    }
}