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
    [SerializeField]
    private ObjectPoolManager solutionPoolManager;
    [SerializeField]
    private float syringeGage = 0f;

    [SerializeField]
    private Transform firePos;

    Player owner;

    void Start()
    {
        syringeRotateState = ESyringeRotateState.SyringeUp;
        syringeType = EElementType.None;
        solutionPoolManager = GameObject.FindGameObjectWithTag("SolutionPoolManager").GetComponent<ObjectPoolManager>();
        owner = GetComponentInParent<Player>();
        
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
        else
        {
            Fire();
        }

    }

    void Fire()
    {
        if(syringeGage>0)
        {
            var bulletGo = solutionPoolManager.Pool.Get();
            bulletGo.transform.position = firePos.transform.position;
            Vector2 direction = new Vector2(Mathf.Cos(nowAngle * Mathf.Deg2Rad), Mathf.Sin(nowAngle * Mathf.Deg2Rad));
            if (owner.isFacingLeft)
                direction *= -1;
            bulletGo.transform.right = direction;
            bulletGo.GetComponent<Rigidbody2D>().AddForce(direction * 25f, ForceMode2D.Impulse);

            syringeGage -= 10f * Time.deltaTime;
            syringeUI.FillUI(syringeGage * 0.01f);
        }
        else
        {
            return;
        }

    }

    public void FillGage(ElementFlask flask)
    {
        if (syringeType == EElementType.None)
        {
            syringeType = flask.elementType;
        }
        else if (syringeType == flask.elementType)
        {
            syringeGage += 10f * Time.deltaTime;
        }
        syringeUI.FillUI(syringeGage * 0.01f);
    }

    public void ClearGauge()
    {
        syringeGage = 0f;
    }
}
