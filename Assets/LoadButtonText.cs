using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class LoadButtonText : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TMPro.TextMeshProUGUI>();

        string loadpath = Application.persistentDataPath + "/QuickSave/Player.json";

        if (!System.IO.File.Exists(loadpath))
        {
            textMeshPro.faceColor = new Color32(255, 255, 255, 125);
        }
    }

}
