using UnityEngine;

public class InfinityBackground : MonoBehaviour
{
    public float speed = 0; // скорость
    private Transform m_transform; // позиция, ротация и скейл обоих бекграундов

    public PlayerController pc;
    void Start()
    {
        m_transform = GetComponent<Transform>(); 
    }

    void Update()
    {
        if (pc.moveInput > 0)
        {
            speed = 0.6f; // speed = 2
            Moves(); // каждый кадр вызывает функцию
        }
        else if (pc.moveInput < 0)
        {
            speed = -0.6f;
            Moves(); // каждый кадр вызывает функцию
        }
        else
        {
            speed = 0;
        }
    }

    private void Moves()
    {
        m_transform.Translate(Vector3.right * speed * Time.deltaTime); // перемешает обьект направо * 2 * TdT
    }
}
