using UnityEngine;

public class InfinityBackground : MonoBehaviour
{
    public float speed = 0; // ��������
    private Transform m_transform; // �������, ������� � ����� ����� �����������

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
            Moves(); // ������ ���� �������� �������
        }
        else if (pc.moveInput < 0)
        {
            speed = -0.6f;
            Moves(); // ������ ���� �������� �������
        }
        else
        {
            speed = 0;
        }
    }

    private void Moves()
    {
        m_transform.Translate(Vector3.right * speed * Time.deltaTime); // ���������� ������ ������� * 2 * TdT
    }
}
