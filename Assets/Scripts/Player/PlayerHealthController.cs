using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    //Sử dụng Singleton để quản lý PlayerHealth, lưu lại qua các scene;
    public static PlayerHealthController Instane { get; private set; }

    [SerializeField] private int _playerHealth;
    [SerializeField] private Image _head1;
    [SerializeField] private Image _head2;
    [SerializeField] private Image _head3;
    [SerializeField] private Sprite _head;
    [SerializeField] private Sprite _nullHead;

    public int PlayerHealth { get => _playerHealth; set => _playerHealth = value; }
    public Image Head1 { get => _head1; set => _head1 = value; }
    public Image Head2 { get => _head2; set => _head2 = value; }
    public Image Head3 { get => _head3; set => _head3 = value; }
    public Sprite Head { get => _head; set => _head = value; }
    public Sprite NullHead { get => _nullHead; set => _nullHead = value; }

    private void Awake()
    {
        Debug.Log("Awake of PlayerHealthController");
        //Đảm bảo chỉ có Duy nhất 1 Singleton cho gameObject;
        if (Instane == null)
        {
            Instane = this;
            // Đảm  bảo game object không bị Destroy khi load lại hoặc chuyển scene;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GotHit()
    {
        PlayerHealth -= 1;
        Debug.Log(PlayerHealth);
    }

    public void UpdatePlayerHealthUI()
    {
        switch (PlayerHealth)
        {
            case 3:
                Head1.sprite = Head;
                Head2.sprite = Head;
                Head3.sprite = Head;
                break;
            case 2:
                Head1.sprite = Head;
                Head2.sprite = Head;
                Head3.sprite = NullHead;
                break;
            case 1:
                Head1.sprite = Head;
                Head2.sprite = NullHead;
                Head3.sprite = NullHead;
                break;
            case 0:
                Head1.sprite = NullHead;
                Head2.sprite = NullHead;
                Head3.sprite = NullHead;
                break;
        }
    }
}
