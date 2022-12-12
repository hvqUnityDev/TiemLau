using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NhanVien_", menuName = "NhanVien/Create New NhanVien")]
public class NhanVien : ScriptableObject
{
    [SerializeField] private Sprite avatar;
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private int pointService;

    public Sprite Avatar => avatar;
    public string Name => name;
    public string Description => description;
    public int PointService => pointService;
}
