using System.Collections.Generic;
using Client.Common;
namespace Client
{
    public delegate void ShowTransferInfoHandler(TransferObj obj);
    public delegate void ShowCustomerPopUpHandler(string ani, string callType);

    //스레드에서 폼 호출용 델리게이트
    public delegate void WriteLog(string m);
    public delegate void PanelCtrlDelegate(bool l);
    public delegate void FormTextCtrlDelegate(string c);
    public delegate void ArrangeCtrlDelegate(string[] ar);
    public delegate void AddChatMsgDelegate(string senderId, string sendername, string sendermsg);
    public delegate void ChangeStat(string name, string team);
    public delegate void LogOutDelegate();
    //public delegate int onFlashWindow(ChatForm form);
    public delegate void DelChatterDelegate(string id, string name);
    public delegate List<string> GetChattersDelegate();
    public delegate void SetChatterStatusDelegate(string userId, string userName, string status);
    //public delegate void AddChatterDelegate(string id, string name);
    public delegate void AddChatterDelegate(MemberObj userObj);
    public delegate void NoticeListSorting(int index);
    public delegate void ShowTransInfoDele(string ani, string senderid, string date, string time);

    public delegate void SendMessageHandler(string message);

    public delegate void stringDele(string ani);
    public delegate void doublestringDele(string ani, string calltype);
    public delegate void objectDele(object obj);
    public delegate void RingingDele(string ani, string name, string server_type);
    public delegate void AbandonDele();
    public delegate void NoParamDele();
    public delegate void intParamDele(int i);
    public delegate void ctrlParamDel();
    public delegate void SetMemberListHandler(List<MemberObj> list);

    #region FTP관련
    public delegate void ShowFileSendStatDelegate(string stat, int idx, SendFileForm form);
    public delegate void ShowFileSendStatExDelegate(int status, string desc, int idx, SendFileForm form);
    public delegate void ShowFileSendDetailDelegate(string key, string detail, FileSendDetailListView view);
    public delegate bool ShowCloseButtonDelegate(FileSendDetailListView view);
    public delegate string SaveFileDialogDelegate(string filename);

    #endregion
}