using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ClipboardExtension
{
    //copies a string to clipboard
    public static void CopyToClipboard(this string str)
    {
        GUIUtility.systemCopyBuffer = str;
    }
}
