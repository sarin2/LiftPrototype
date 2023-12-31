using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyringeUI : MonoBehaviour
{
    [SerializeField]
    private Slider syringeSlider;
    [SerializeField]
    private GameObject fillObject;
    [SerializeField]
    private Image syringeFill;
    [SerializeField]
    private Syringe syringe;

    private void Awake()
    {
        syringeSlider = GetComponent<Slider>();
        syringeFill = fillObject.GetComponent<Image>();
    }

    public void FillUI(float Gage)
    {
        switch (syringe.syringeType)
        {
            case EElementType.Water:
                syringeFill.color = Color.blue;
                break;
            case EElementType.Fire:
                syringeFill.color = Color.red;
                break;
        }

        syringeSlider.value = Gage;
    }

    public void ClearFill()
    {
        syringeFill.color = Color.white;
        syringeSlider.value = 0f;
        syringe.syringeType = EElementType.None;
    }

    public float GetFillValue()
    {
        return syringeSlider.value;
    }
}
