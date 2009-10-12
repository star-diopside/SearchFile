using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SearchFile
{
    class FindFileList : List<FileInfo>
    {
        public FindFileList()
            : base()
        {
        }

        public FindFileList(IEnumerable<FileInfo> collection)
            : base(collection)
        {
        }

        public FindFileList(int capacity)
            : base(capacity)
        {
        }

        public IEnumerable<FileInfo> GetSelectedItems(ListView.SelectedIndexCollection collection)
        {
            foreach (int index in collection)
            {
                yield return this[index];
            }
        }
    }
}
