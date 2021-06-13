using UnityEngine;

public class InfinityMiddleground : MonoBehaviour
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
            speed = 1; // speed = 2
            Moves(); // каждый кадр вызывает функцию
        }
        else if (pc.moveInput < 0)
        {
            speed = -1;
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
