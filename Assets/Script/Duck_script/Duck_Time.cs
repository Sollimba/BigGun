using UnityEngine;

public class Duck_Time : Duck
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GameStarter gameStarter = FindObjectOfType<GameStarter>();
            if (gameStarter != null)
            {
                gameStarter.AddTime(10f); // ����������� ����� ���� �� 10 ������
            }
            Destroy(gameObject);
        }
    }
}