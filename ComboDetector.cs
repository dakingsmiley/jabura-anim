using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ComboNode = System.Collections.Generic.Dictionary<uint, uint>;

public class ComboDetector : MonoBehaviour
{
    enum BUTTONS
    {
        UP = 0x01,
        DOWN = 0x02,
        LEFT = 0x04,
        RIGHT = 0x08,

        Z = 0x10,
        X = 0X20,

        COMBO_END = 0xFFFFFFF,
    };

    public TextMesh tm;
    uint buttons = 0;

    uint preButtons = 0;
    uint comboIndex = 0;

    uint[] combo;

    // Start is called before the first frame update
    void Start()
    {
        combo = new uint[] { (uint)BUTTONS.RIGHT, 0, (uint)BUTTONS.RIGHT, 0, (uint)BUTTONS.RIGHT, 0, (uint)BUTTONS.COMBO_END };
    }


    void UpdateButtons()
    {
        preButtons = buttons;
        buttons = 0;

        buttons |= Input.GetKey(KeyCode.UpArrow) == true ? (uint)(BUTTONS.UP) : 0;
        buttons |= Input.GetKey(KeyCode.DownArrow) == true ? (uint)(BUTTONS.DOWN) : 0;
        buttons |= Input.GetKey(KeyCode.LeftArrow) == true ? (uint)(BUTTONS.LEFT) : 0;
        buttons |= Input.GetKey(KeyCode.RightArrow) == true ? (uint)(BUTTONS.RIGHT) : 0;

        buttons |= Input.GetKey(KeyCode.Z) == true ? (uint)(BUTTONS.Z) : 0;
        buttons |= Input.GetKey(KeyCode.X) == true ? (uint)(BUTTONS.X) : 0;

        tm.text = System.Convert.ToString(buttons, 2).PadLeft(6, '0');
    }
    // Update is called once per frame
    void Update()
    {
        UpdateButtons();
        DetectCombo();
    }

    bool DidButtonChange()
    {
        if (preButtons != buttons)
        {
            return true;
        }
        return false;
    }

    void DetectCombo()
    {
        if (DidButtonChange())
        {
            if (buttons == combo[comboIndex])
            {
                comboIndex += 1;
                
                if ((uint)BUTTONS.COMBO_END == combo[comboIndex])
                {
                    Debug.Log("HA DO KEN!!!");
                    comboIndex = 0;
                }
            }
            else
            {
                Debug.Log("Error!!!");
                comboIndex = 0;
            }
        }
    }
}

