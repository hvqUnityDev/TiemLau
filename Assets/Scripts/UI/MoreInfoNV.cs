using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoreInfoNV : MonoBehaviour
{
    public TextMeshProUGUI PointServicePlus;
    public TextMeshProUGUI Story;
    public TextMeshProUGUI NameSkin;
    public Image FullSkin;
    public TextMeshProUGUI TxtPrice;
    public List<SlotCoatHub> Coats = new List<SlotCoatHub>();

    [SerializeField] private GameObject contentCoat;
    [SerializeField] private Button btnX;
    

    private void Start()
    {
        btnX.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            Coats = new List<SlotCoatHub>();
        });

        
    }

    public void ResetColorCoats()
    {
        foreach (var item in Coats)
        {
            item.WhenNotClick();
        }
    }

    public GameObject ContentCoat => contentCoat;
}
