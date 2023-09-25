using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VMSCore.WindowsForms
{
    public class WaitDialog
    {
        public static DevExpress.Utils.WaitDialogForm Dlg = null;
        public static void CreateWaitDialog(string Caption, string Title)
        {
            if (Dlg != null)
                CloseWaitDialog();

            if (Title == "")
            {
                Dlg = new DevExpress.Utils.WaitDialogForm(Caption);
            }
            else
            {
                Dlg = new DevExpress.Utils.WaitDialogForm(Caption, Title);

            }
        }

        public static void CreateWaitingDialog()
        {
            CreateWaitDialog("", "");
        }

        public static void CloseWaitDialog()
        {
            if (Dlg != null)
                Dlg.Close();
        }
        public static void SetWaitDialogCaption(string fCaption)
        {
            if (Dlg != null)
            {
                Dlg.Caption = fCaption;
            }
        }

    }

}
