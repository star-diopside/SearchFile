using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SearchFile
{
    /// <summary>
    /// ���X�g�r���[�̃A�C�e���̕��בւ��̂��߂Ɏg�p���� IComparer �C���^�[�t�F�C�X�����������N���X
    /// </summary>
    class ListViewItemSorter : IComparer, IComparer<ListViewItem>
    {
        private int _column = 0;
        private SortOrder _sortOrder = SortOrder.Ascending;
        private readonly IList<IComparer<string>> _comparers = new List<IComparer<string>>();

        /// <summary>
        /// ListViewItemSorter �N���X�̐V�����C���X�^���X������������
        /// </summary>
        public ListViewItemSorter()
        {
        }

        /// <summary>
        /// �\�[�g�����̃C���f�b�N�X�ԍ����擾�܂��͐ݒ肷��
        /// </summary>
        public int Column
        {
            get
            {
                return this._column;
            }
            set
            {
                if (this._column == value)
                {
                    // �ȑO�Ɠ����񂪎w�肳�ꂽ�ꍇ�͕��בւ����������ւ���
                    if (this._sortOrder == SortOrder.Ascending)
                    {
                        this._sortOrder = SortOrder.Descending;
                    }
                    else if (this._sortOrder == SortOrder.Descending)
                    {
                        this._sortOrder = SortOrder.Ascending;
                    }
                    else
                    {
                        this._sortOrder = SortOrder.Ascending;
                    }
                }
                else
                {
                    // �ȑO�ƈႤ�񂪎w�肳�ꂽ�ꍇ�͕��בւ����@�������ɐݒ肷��
                    this._sortOrder = SortOrder.Ascending;
                }

                this._column = value;
            }
        }

        /// <summary>
        /// �\�[�g�̕��בւ����@���擾�܂��͐ݒ肷��
        /// </summary>
        public SortOrder SortOrder
        {
            get
            {
                return this._sortOrder;
            }
            set
            {
                this._sortOrder = value;
            }
        }

        /// <summary>
        /// �񍀖ڂ̃\�[�g���ɕ������r���s�� IComparer&lt;string&gt; ���i�[����R���N�V����
        /// </summary>
        public IList<IComparer<string>> Comparers
        {
            get
            {
                return this._comparers;
            }
        }

        public int Compare(ListViewItem x, ListViewItem y)
        {
            // ���בւ����s��Ȃ��ꍇ�� 0 ��Ԃ�
            if (_sortOrder == SortOrder.None)
            {
                return 0;
            }

            // ��C���f�b�N�X�������̏ꍇ
            if (_column < 0)
            {
                return 0;
            }

            // �w���C���f�b�N�X�������Ŏw�肳�ꂽ ListViewItem �̗�͈͊O�̏ꍇ
            if (x.SubItems.Count <= _column || y.SubItems.Count <= _column)
            {
                return 0;
            }

            // �������r�I�u�W�F�N�g���w�肳��Ă��Ȃ��ꍇ
            if (_comparers.Count <= _column)
            {
                return 0;
            }

            // ���ڂ̑召���r����
            int result = _comparers[_column].Compare(x.SubItems[_column].Text, y.SubItems[_column].Text);

            // ���בւ����@���~���̏ꍇ�͔�r���ʂ𔽓]������
            if (_sortOrder == SortOrder.Descending)
            {
                result = -result;
            }

            return result;
        }

        int IComparer.Compare(object x, object y)
        {
            return Compare((ListViewItem)x, (ListViewItem)y);
        }
    }
}
