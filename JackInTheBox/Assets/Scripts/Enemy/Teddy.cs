using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teddy : MonoBehaviour
{
    //References

    private Rigidbody _rb;
    private Player _player;
    private BoxCollider _boxCollider;
    private MeshRenderer _meshRenderer;
    private Transform _transform;

    private float _timer = 1.9f;
    private Coroutine countdownCoroutine;

    private float explosionRadius = 0.6f;

    [SerializeField] private AudioClip explosionSoundClip;
    private SFXPlayer _sfxPlayer;

    void Awake()
    {
        GameObject playerGameObject = GameObject.Find("Player");

        if (playerGameObject != null)
        {
            _player = playerGameObject.GetComponent<Player>();
        }

        _rb = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _transform = GetComponent<Transform>();
    }

    void Start()
    {
        _sfxPlayer = SFXPlayer.instance;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartExplosion();
            _boxCollider.enabled = false;
        }
    }

    void StartExplosion()
    {
        countdownCoroutine = StartCoroutine(Countdown());
        _sfxPlayer.PlaySFX(explosionSoundClip, transform, 1f);
    }

    IEnumerator Countdown()
    {
        while (_timer > 0)
        {
            _timer -= Time.deltaTime;
            yield return null;
        }

        Explode();
    }

    void Explode()
    {
        CheckDistance();
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        _meshRenderer.enabled = false;
        Destroy(gameObject, 2);
    }

    void CheckDistance()
    {
        float distance = Vector3.Distance(_transform.position, _player.transform.position);
        
        if (distance <= explosionRadius)
        {
            _player.takeDamage(2);
        }
    }
}