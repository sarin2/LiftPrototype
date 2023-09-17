using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EElementType
{
    None,
    Water,
    Fire
}

public class Syringe : MonoBehaviour
{
    // Start is called before the first frame update


    enum ESyringeRotateState
    {
        SyringeUp,
        SyringeDown
    }

    private ESyringeRotateState syringeRotateState;
    [SerializeField]
    public EElementType syringeType { get; set; }
    [SerializeField]
    private float maxAngle = 45f;
    [SerializeField]
    private float minAngle = -25f;
    [SerializeField]
    private float nowAngle = 0f;
    [SerializeField]
    private float rotationSpeed = 75f;

    [SerializeField]
    private SyringeUI syringeUI;

    void Start()
    {
        syringeRotateState = ESyringeRotateState.SyringeUp;
        syringeType = EElementType.None;
    }

    public void TryClearFill()
    {
        if (syringeUI.GetFillValue() > 0f && syringeType != EElementType.None)
        {
            syringeUI.ClearFill();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float attackButton = Input.GetAxisRaw("Fire1");

        if (attackButton == 0f)
        {
            switch (syringeRotateState)
            {
                case ESyringeRotateState.SyringeUp:
                    nowAngle += rotationSpeed * Time.deltaTime;
                    break;
                case ESyringeRotateState.SyringeDown:
                    nowAngle -= rotationSpeed * Time.deltaTime;
                    break;
            }

            if (nowAngle > maxAngle)
                syringeRotateState = ESyringeRotateState.SyringeDown;
            else if (nowAngle < minAngle)
                syringeRotateState = ESyringeRotateState.SyringeUp;

            transform.rotation = Quaternion.Euler(0, 0, nowAngle);
        }

    }
}
