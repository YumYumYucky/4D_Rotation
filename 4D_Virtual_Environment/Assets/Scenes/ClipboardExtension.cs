using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class ClipboardExtension{
    //copied string to clipboard
    public static void CopyToClipboard(this string str)
    {
        GUIUtility.systemCopyBuffer=str;
    }
}
