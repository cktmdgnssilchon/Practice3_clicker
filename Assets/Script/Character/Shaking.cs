using UnityEngine;
using System.Collections;

//정해진 시간 동안 정해진 흔들림대로 8방향
public class Shaking : FFMonoBehaviour
{
    public void Init(GameObject owner)
    {
        m_transform = owner.transform;
    }
 
    public void SetShaking(int power, float time)
    {
        m_shakingPower = power;
        m_shakingTime = time;
        m_shaking = true;
    }
 
    public void Update()
    {
        if (m_shaking == false)
            return;
 
        m_shakingTime -= Time.deltaTime;
        if (m_shakingTime <= 0)
        {
            m_shaking = false;
            m_transform.localPosition = Vector3.zero;
            return;
        }
 
        m_shakingApply = !m_shakingApply;
        if (m_shakingApply == false)
        {
            int random = UnityEngine.Random.Range(0, 8);
            float power = (float)UnityEngine.Random.Range(0, m_shakingPower * 10);
            power /= 100;
 
            Vector3 pos = m_transform.localPosition;
            switch (random)
            {
                case 0:
                    pos.x -= power;
                    pos.y -= power;
                    break;
                case 1:
                    pos.x -= power;
                    break;
                case 2:
                    pos.x -= power;
                    pos.y += power;
                    break;
                case 3:
                    pos.y -= power;
                    break;
                case 4:
                    pos.y += power;
                    break;
                case 5:
                    pos.x += power;
                    pos.y += power;
                    break;
                case 6:
                    pos.x += power;
                    break;
                case 7:
                    pos.x += power;
                    pos.y -= power;
                    break;
            }
            m_transform.localPosition = pos;
        }
        else
        {
            m_transform.localPosition = Vector3.zero;
        }
    }
 
    Transform m_transform;
 
    bool m_shaking;
    int m_shakingPower;
    float m_shakingTime;
    bool m_shakingApply;
}