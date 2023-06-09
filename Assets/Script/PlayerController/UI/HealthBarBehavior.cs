using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class HealthBarBehavior : MonoBehaviourPun
{

    PhotonView view;


    [SerializeField]
    private Slider slider;

    [SerializeField]
    private Color lowColor;
    [SerializeField]
    private Color hightColor;
    [SerializeField]
    private Vector3 Offset;


    [SerializeField]
    private GameObject Player;
    private PlayerController playerController;
    [SerializeField]
    private GameObject circle;

    [SerializeField]
    private float hightSlideUnderPlayer;
    private float maxHealth;
    private void Start()
    {
      //  Offset = new Vector3(0, hightSlideUnderPlayer, 0);
        playerController = Player.GetComponent<PlayerController>();
        maxHealth = playerController.maxHealth;

        view = GetComponent<PhotonView>();
    }

   
    // Update is called once per frame
    public void SetHealth()
    {
        slider.gameObject.SetActive(playerController.health < maxHealth);
        slider.value = playerController.health;
        slider.maxValue = maxHealth;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(lowColor, hightColor, slider.normalizedValue);

        if(slider.value == 0)
        {
            slider.gameObject.SetActive(false);
        }
    }

    void Update()
    {
       
        
    }
    private void LateUpdate()
    {
        if (playerController.health > 0)
        { //Debug.Log("health = " + playerController.health);
            if (view.IsMine)
            {


                SetHealth();
            }
        }
        else
        {
            slider.gameObject.SetActive(false);
        }
        // slider.transform.position = Camera.main.WorldToScreenPoint(circle.transform.position);
        slider.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
