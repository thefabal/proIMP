using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class ListViewColumnSorter : IComparer {
    private int ColumnToSort;
    private SortOrder OrderOfSort;

    public ListViewColumnSorter() {
        ColumnToSort = -1;
        OrderOfSort = SortOrder.None;
    }

    public int Compare( object x, object y ) {
        if( ColumnToSort == -1 )
            return 0;
        
        int returnVal;
        string tag;
        
        string listviewX, listviewY;

        tag = ( ( ListViewItem )x ).ListView.Columns[ ColumnToSort ].Tag.ToString();

        listviewX = (( ListViewItem )x).SubItems[ ColumnToSort ].Text;
        listviewY = (( ListViewItem )y).SubItems[ ColumnToSort ].Text;

        switch( tag ) {
            case "int": {
                returnVal = Convert.ToInt32( ( listviewX == "" ) ? "0" : listviewX ).CompareTo( Convert.ToInt32( ( listviewY == "" ) ? "0" : listviewY ) );
            }
            break;

            case "double": {
                returnVal = Convert.ToDouble( ( listviewX == "" ) ? "0" : listviewX ).CompareTo( Convert.ToDouble( ( listviewY == "" ) ? "0" : listviewY ) );
            }
            break;

            case "currency": {
                returnVal = Convert.ToDouble( ( listviewX == "" ) ? "0" : ( listviewX.Substring( 0, listviewX.IndexOf( " " ) ) ) ).CompareTo( Convert.ToDouble( ( listviewY == "" ) ? "0" : ( listviewY.Substring( 0, listviewY.IndexOf( " " ) ) ) ) );
            }
            break;

            case "string": {
                returnVal = String.Compare( listviewX, listviewY );
            }
            break;

            case "DateTime": {
                returnVal = DateTime.Parse( ( listviewX == "" ) ? "1900-01-01" : listviewX ).CompareTo( DateTime.Parse( ( listviewY == "" ) ? "1900-01-01" : listviewY ) );
            }
            break;

            default: {
                MessageBox.Show( tag );

                return 0;
            }
        }

        if( OrderOfSort == SortOrder.Ascending ) {
            return returnVal;
        } else if( OrderOfSort == SortOrder.Descending ) {
            return ( -returnVal );
        } else {
            return 0;
        }
    }

    public int SortColumn {
        set {
            ColumnToSort = value;
        }
        get {
            return ColumnToSort;
        }
    }

    public SortOrder Order {
        set {
            OrderOfSort = value;
        }
        get {
            return OrderOfSort;
        }
    }
}

[EditorBrowsable( EditorBrowsableState.Never )]
public static class ListViewExtensions {
    [StructLayout( LayoutKind.Sequential )]
    public struct HDITEM {
        public Mask mask;
        public int cxy;
        [MarshalAs(UnmanagedType.LPTStr)] public string pszText;
        public IntPtr hbm;
        public int cchTextMax;
        public Format fmt;
        public IntPtr lParam;
        // _WIN32_IE >= 0x0300 
        public int iImage;
        public int iOrder;
        // _WIN32_IE >= 0x0500
        public uint type;
        public IntPtr pvFilter;
        // _WIN32_WINNT >= 0x0600
        public uint state;

        [Flags]
        public enum Mask {
            Format = 0x4,       // HDI_FORMAT
        };

        [Flags]
        public enum Format {
            SortDown = 0x200,   // HDF_SORTDOWN
            SortUp = 0x400,     // HDF_SORTUP
        };
    };

    public const int LVM_FIRST = 0x1000;
    public const int LVM_GETHEADER = LVM_FIRST + 31;

    public const int HDM_FIRST = 0x1200;
    public const int HDM_GETITEM = HDM_FIRST + 11;
    public const int HDM_SETITEM = HDM_FIRST + 12;

    [DllImport( "user32.dll", CharSet = CharSet.Auto, SetLastError = true )]
    public static extern IntPtr SendMessage( IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam );

    [DllImport( "user32.dll", CharSet = CharSet.Auto, SetLastError = true )]
    public static extern IntPtr SendMessage( IntPtr hWnd, UInt32 msg, IntPtr wParam, ref HDITEM lParam );

    public static void SetSortIcon( this ListView listViewControl, int columnIndex, SortOrder order ) {
        IntPtr columnHeader = SendMessage(listViewControl.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
        for( int columnNumber = 0; columnNumber <= listViewControl.Columns.Count - 1; columnNumber++ ) {
            var columnPtr = new IntPtr(columnNumber);
            var item = new HDITEM
                {
                mask = HDITEM.Mask.Format
            };

            if( SendMessage( columnHeader, HDM_GETITEM, columnPtr, ref item ) == IntPtr.Zero ) {
                throw new Win32Exception();
            }

            if( order != SortOrder.None && columnNumber == columnIndex ) {
                switch( order ) {
                    case SortOrder.Ascending:
                        item.fmt &= ~HDITEM.Format.SortDown;
                        item.fmt |= HDITEM.Format.SortUp;
                        break;
                    case SortOrder.Descending:
                        item.fmt &= ~HDITEM.Format.SortUp;
                        item.fmt |= HDITEM.Format.SortDown;
                        break;
                }
            } else {
                item.fmt &= ~HDITEM.Format.SortDown & ~HDITEM.Format.SortUp;
            }

            if( SendMessage( columnHeader, HDM_SETITEM, columnPtr, ref item ) == IntPtr.Zero ) {
                throw new Win32Exception();
            }
        }
    }
}