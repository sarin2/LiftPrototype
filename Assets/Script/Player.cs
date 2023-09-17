using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum EPlayerState
    {
        Idle,
        Running,
        Jumping
    }

    [SerializeField]
    private float speed = 7f;

    [SerializeField]
    private Rigidbody2D rigid;

    [SerializeField]
    private EPlayerState playerState;

    private float horizontal;
    [SerializeField]
    private Syringe syringe;

    private void OnValidate()
    {
        if (!rigid)
            rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Application.targetFrameRate = 180;
        playerState = EPlayerState.Idle;
        rigid.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0f)
            TryMove();
        else if (horizontal == 0f && playerState != EPlayerState.Jumping)
        {
            playerState = EPlayerState.Idle;
            Vector3 pos = new Vector3(0f, rigid.velocity.y, 0);
            rigid.velocity = pos;
        }

        if(Input.GetButton("Jump"))
            TryJump();

        if (Input.GetKeyDown(KeyCode.Q))
            syringe.gameObject.SetActive(!syringe.gameObject.activeSelf);

        if (Input.GetKeyDown(KeyCode.E))
            syringe.TryClearFill();

    }

    void TryMove()
    {
        if (horizontal != 0f)
        {
            if(playerState != EPlayerState.Jumping)
                playerState = EPlayerState.Running;
            transform.localScale = new Vector3(horizontal, 1, 1);
            Vector3 pos = new Vector3(horizontal * speed, rigid.velocity.y, 0);
            rigid.velocity = pos;
        }
    }

    void TryJump()
    {
        rigid = GetComponent<Rigidbody2D>();
        if (playerState != EPlayerState.Jumping)
        {
            StartCoroutine(StartJump());
        }
    }

    IEnumerator StartJump()
    {
        rigid.AddForce(new Vector2(0, 20f), ForceMode2D.Impulse);
        playerState = EPlayerState.Jumping;
        yield return new WaitForSeconds(0.5f);

        while(true)
        {
            if (rigid.velocity.y == 0f)
            {
                playerState = EPlayerState.Idle;
                break;
            }
            yield return null;
        }
    }
}
