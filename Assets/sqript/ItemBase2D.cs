using UnityEngine;

/// <summary>
/// �A�C�e���𐧌䂷����N���X
/// �A�C�e���̋��ʋ@�\����������
/// </summary>
[RequireComponent(typeof(Collider2D))]
public abstract class ItemBase2D : MonoBehaviour
{
    /// <summary>�A�C�e������������ɖ���ʉ�</summary>
    [Tooltip("�A�C�e������������ɖ炷���ʉ�")]
    [SerializeField] AudioClip _sound = default;
    /// <summary>�A�C�e���̌��ʂ����������邩</summary>
    [Tooltip("Get ��I�ԂƁA��������Ɍ��ʂ���������BUse ��I�ԂƁA�A�C�e�����g�������ɔ�������")]
    [SerializeField] ActivateTiming _whenActivated = ActivateTiming.Get;

    /// <summary>
    /// �A�C�e��������������ʂ���������
    /// </summary>
    public abstract void Activate();
    //{
    //    Debug.LogError("�h���N���X�Ń��\�b�h���I�[�o�[���C�h�i�㏑���j���Ă��������B");
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (_sound)
            {
                AudioSource.PlayClipAtPoint(_sound, Camera.main.transform.position);
            }

            // �A�C�e�������^�C�~���O�ɂ���ď����𕪂���
            if (_whenActivated == ActivateTiming.Get)
            {
                Activate();
                Destroy(this.gameObject);
            }
            else if (_whenActivated == ActivateTiming.Use)
            {
                // �����Ȃ����Ɉړ�����
                this.transform.position = Camera.main.transform.position;
                // �R���C�_�[�𖳌��ɂ���
                GetComponent<Collider2D>().enabled = false;

            }
        }
    }

    /// <summary>
    /// �A�C�e�������A�N�e�B�x�[�g���邩
    /// </summary>
    enum ActivateTiming
    {
        /// <summary>��������ɂ����g��</summary>
        Get,
        /// <summary>�u�g���v�R�}���h�Ŏg��</summary>
        Use,
    }
}


