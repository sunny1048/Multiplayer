using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class BallController : NetworkBehaviour
{

    public Rigidbody myrb;
    public FixedJoystick myjoystick;
    public float speed;
    public GameObject GameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel = GameObject.Find("GameOver");
        GameOverPanel.SetActive(false);
        myrb = this.gameObject.GetComponent<Rigidbody>();
        myjoystick = FindObjectOfType<FixedJoystick>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myrb.velocity = new Vector3(myjoystick.Horizontal * speed, myrb.velocity.y, myjoystick.Vertical * speed);
    }


    public override void OnNetworkSpawn()
    {
        if (!IsOwner) Destroy(this);
    }


    private void OnTriggerEnter(Collider other)
    {
        GameOverPanel.SetActive(true);
        
    }
}
