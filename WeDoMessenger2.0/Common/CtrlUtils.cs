using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Client.Common
{
    class CtrlUtils
    {
        
    }

    public class ListViewItemComparerDe : System.Collections.IComparer
    {
        private int col;
        public ListViewItemComparerDe()
        {
            col = 0;
        }
        public ListViewItemComparerDe(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            return String.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);
        }
    }

    public class ListViewItemComparerAs : System.Collections.IComparer
    {
        private int col;
        public ListViewItemComparerAs()
        {
            col = 0;
        }
        public ListViewItemComparerAs(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
        }
    }
}
