using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose : MonoBehaviour
{
    private Player _player;
    private BoxCollider _boxCollider;

    private SFXPlayer _sfxPlayer;
    [SerializeField] private AudioClip laughSoundClip;

    private VFXPlayer _vfxPlayer;
    [SerializeField] private GameObject disappearVFX;
    private Vector3 _vfxPosition;
    
    void Awake()
    {
        GameObject playerGameObject = GameObject.Find("Player");

        if (playerGameObject != null)
        {
            _player = playerGameObject.GetComponent<Player>();
        }
        _boxCollider = GetComponent<BoxCollider>();
    }

    void Start()
    {
        _sfxPlayer = SFXPlayer.instance;
        _vfxPlayer = VFXPlayer.instance;

        _vfxPosition = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Disappear();
    }

    void Disappear()
    {
        _boxCollider.enabled = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        _sfxPlayer.PlaySFX(laughSoundClip, transform, 0.5f);
        _vfxPlayer.PlayVFX(disappearVFX, _vfxPosition, Quaternion.identity);
        Destroy(gameObject, 5);
    }
}
