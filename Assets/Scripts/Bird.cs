using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public AudioClip JumpAudio;
    public AudioClip DeathAudio;
    public float ForceAmount = 10;

    private Rigidbody2D _rigidBody2D;
    private AudioSource _audioSource;

    private bool _jump = true;
    private bool _dead = false;

    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(_jump && Input.GetKeyDown(KeyCode.Space)){
            _rigidBody2D.velocity = Vector2.zero;
            _rigidBody2D.AddForce(new Vector2(0, ForceAmount));
            _audioSource.PlayOneShot(JumpAudio);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.name.Equals("Tree top") || collision.gameObject.name.Equals("Tree bottom"))
        {
            if (!_dead)
            {
                _audioSource.PlayOneShot(DeathAudio);
                _dead = true;
            }
            _jump = false;
        }

        else
            Score.ScoreCounter += 1;

    }

    void OnBecameInvisible()
    {
        if(!_dead)
            _audioSource.PlayOneShot(DeathAudio);
        Restart();
    }

    private void Restart(){
        transform.position = new Vector3(transform.position.x, 0, 0);
        Game.Instance.Restart();
        _rigidBody2D.velocity = Vector2.zero;
        Score.ScoreCounter = 0;
        _jump = true;
        _dead = false;
    }
}
