using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private TextMeshProUGUI textMeshPro;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject winParticles;
    [SerializeField] private GameObject looseParticles;

    [SerializeField] private Transform winParticlesPos;

    void Start()
    {
        textMeshPro = GameObject.Find("ScoreHud").GetComponent<TextMeshProUGUI>();
        winParticlesPos = GameObject.Find("CubePos").transform;
    }

    void Update()
    {
        Move();        
    }

    private void Move()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
        {   
            Instantiate(looseParticles, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            gameManager=FindAnyObjectByType<GameManager>();
            gameManager.GameOver();
        }
        if (collision.gameObject.name == "Out")
        {
            Instantiate(winParticles, winParticlesPos.position, Quaternion.identity);
            int newScore = int.Parse(textMeshPro.text) +1;
            textMeshPro.text = newScore.ToString();
            Destroy(gameObject);
        }
    }
}
