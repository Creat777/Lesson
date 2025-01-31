using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // ���μ��� ���� ���� �ϳ��� �����ϴ� ��ü == �̱���  : 0���� �ƴϰ� 2�� �̻� �ƴϰ� ���� 1��
    // ��? �����?
    //  -> 1�� �޸� ����ȭ ����
    //  -> 2�� ���ν��� ó�� �ߺ� ����
    //  -> 3�� Ŭ�����̸����� ���ν����� ������ �� ����

    // static ����  : Ŭ������ ��������� ��ü�� ������ ���� �Ѱ��� �����ϴ� ����
    //              : Ŭ���� �̸����� ������ �� ����
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogWarning($"{typeof(T).Name}�� �̱����� �������� ����");
            }

            // null�� �ƴϸ� �״�� ����
            return instance;
        }

        private set
        {
            instance = value;
        }
    }

    protected void MakeSingleTone()
    {
        // �̱��� �ν��Ͻ� ���� �� �ߺ� ����
        if (instance == null)
        {
            instance = this as T; // this ��ü�� Ÿ�� T�� ��ȯ�Ϸ��� �õ��ϸ�, ��ȯ�� �����ϸ� ���ܸ� ������ �ʰ� null�� ��ȯ
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject); // �ߺ��� �̱��� �ı�
        }
    }

    protected virtual void Awake()
    {
        MakeSingleTone();
    }
}