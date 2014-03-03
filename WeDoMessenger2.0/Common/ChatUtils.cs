using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
//using CRMmanager;
using System.Collections;
using System.Drawing;
using Client.Common;
using System.ComponentModel;
using WeDoCommon;
using System.Globalization;

namespace Client
{
    public class ChatUtils
    {
        /// <summary>
        /// 채팅장 트리노드에서 로그인/로그아웃정보를 뺀 사용자id목록을 구함
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        [Obsolete("Not used anymore", false)]
        public static string GetIdFromNodeTag(string tag)
        {
            string[] tempArr = tag.Split(':');
            if (tempArr.Length > 1)
            {
                return tempArr[0];
            }
            else
            {
                return tag;
            }
        }

        /// <summary>
        /// 채팅창 트리노드에서 로그인상태인 사용자 id만 구함
        /// </summary>
        /// <param name="Nodes"></param>
        /// <returns></returns>
        //public static List<string> GetLoggedInIdFromNodeTag(TreeNodeCollection nodes)
        //{
        //    List<string> chatterList = new List<string>();

        //    for (int i = 0; i < nodes.Count; i++) {
        //        MemberObj userObj = (MemberObj)nodes[i].Tag;

        //        if (userObj == null)
        //            continue;
        //        if (userObj.Status != MsgrUserStatus.LOGOUT) {
        //            chatterList.Add(userObj.Id);
        //        }
        //    }
        //    return chatterList;
        //}


        public static List<MemberObj> GetLoggedInMemberFromNodeTag(TreeNodeCollection nodes)
        {
            List<MemberObj> memberList = new List<MemberObj>();
            foreach (TreeNode node in nodes)
            {
                MemberObj userObj = (MemberObj)node.Tag;
                if (userObj == null)
                    continue;
                if (!ConfigHelper.Id.Equals(userObj.Id) && userObj.Status != MsgrUserStatus.LOGOUT)
                { //자신 빼고 전송
                    memberList.Add(userObj);
                }
            }
            return memberList;
        }

        public static string GetLoggedInMemberList(List<MemberObj> joinedChatterList)
        {
            string idList = "";
            foreach (MemberObj item in joinedChatterList)
                idList += "/" + item.Id;

            if (idList.Length >= 1) idList = idList.Substring(1);// "/"를 제거
            return idList;
        }

        [Obsolete("Not used anymore", false)]
        public static string TagAsLoggedInId(string id)
        {
            return (id + CommonDef.CHAT_USER_LOG_IN);
        }

        [Obsolete("Not used anymore", false)]
        public static string TagAsLoggedOutId(string id)
        {
            return (id + CommonDef.CHAT_USER_LOG_OUT);
        }

        public static bool ContainsFormKeyInChatForm(string formKey, string idInMsg)
        {
            string[] formKeyArr = formKey.Split('/');
            string[] idInMsgArr = idInMsg.Split('/');

            if (formKeyArr.Length == 0 || formKeyArr.Length != idInMsg.Length)
            {
                return false;
            }

            for (int i = 0; i < formKeyArr.Length; i++)
            {
                if (!idInMsg.Contains(formKeyArr[i])) return false;
            }
            return true;
        }

        public static MemberObj FindMemberObjTagFromTreeNodes(TreeNodeCollection nodeCollection, string findId) {
            TreeNode[] nodes = nodeCollection.Find(findId, true);

            foreach (TreeNode node in nodes) {
                MemberObj userObj = (MemberObj)node.Tag;
                if (userObj == null)
                    continue;
                if (userObj.Id == findId) {
                    return userObj;
                }
            }
            return null;
        }


        /// <summary>
        /// 자기 id를 앞으로 하고, id들를 문자열순으로 formkey 생성 : myid/id1/id2...
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="myId"></param>
        /// <returns></returns>
        public static string GetFormKey(string ids, string myId)
        {
            SortedList aList = GetFormKeySortedList(ids);

            string formKey = myId;
            ICollection keys = aList.Keys;
            foreach (string key in keys) {
                if (key != myId)
                    formKey += "/" + key;
            }
            return formKey;
        }

        /// <summary>
        /// 자기 id를 앞으로 하고, id들를 문자열순으로 formkey 생성 : myid/id1/id2...
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="myId"></param>
        /// <returns></returns>
        public static string GetFormKey(List<string> ids, string myId)
        {
            SortedList aList = GetFormKeySortedList(ids);

            string formKey = myId;
            ICollection keys = aList.Keys;
            foreach (string key in keys)
            {
                if (key != myId)
                    formKey += "/" + key;
            }
            return formKey;
        }

        /// <summary>
        /// 로그인한 id가 채팅창에 이미 있는 경우, {userid}_out -> {userid}로 변경해준다.
        /// 없는 경우 기존처럼 처리
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="myId"></param>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public static string GetFormKeyWithUserAdded(string ids, string myId, string addedId) {
            
            SortedList aList = GetFormKeySortedList(ids);
            
            if (!ids.Contains(addedId)) { //존재하지 않는 경우 추가
                aList.Add(addedId, addedId);
            }
    
            string formKey = myId;
            ICollection keys = aList.Keys;
            foreach (string key in keys) {
                if (key == myId)
                    continue;
                //기존 logout, quit처리된 경우 복원해줌.
                if (key == addedId + "_out"
                    || key == addedId + "_quit") {
                    formKey += "/" + addedId;
                } else {
                    formKey += "/" + key;
                }
            }
            return formKey;
        }

        /// <summary>
        /// 2개이상의 사용자가 폼키에 추가됨
        /// </summary>
        /// <param name="ids">기존폼키</param>
        /// <param name="myId">나의아이디</param>
        /// <param name="addedIds">추가아이디리스트(xxx/vvv/bbb)</param>
        /// <returns></returns>
        public static string GetFormKeyWithMultiUsersAdded(string ids, string myId, string addedIds) {
            SortedList aList = GetFormKeySortedList(addedIds);
            
            ICollection keys = aList.Keys;
            string resultKey = ids;
            foreach (string key in keys) {
                resultKey = GetFormKeyWithUserAdded(resultKey, myId, key);
            }
            return resultKey;
        }

        public static string GetFormKeyWithMultiUsersAdded(string ids, string myId, List<MemberObj> addedIds)
        {
            SortedList aList = new SortedList();
            foreach (MemberObj obj in addedIds)
                aList.Add(obj.Id, obj.Id);

            ICollection keys = aList.Keys;
            string resultKey = ids;
            foreach (string key in keys)
            {
                resultKey = GetFormKeyWithUserAdded(resultKey, myId, key);
            }
            return resultKey;
        }
        
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="myId"></param>
        /// <param name="logoutId"></param>
        /// <returns></returns>
        public static string GetFormKeyWithUserLogOut(string ids, string myId, string logoutId) {
            return GetFormKeyWithUserRemoved(ids, myId, logoutId, "_out");
        }

        public static string GetFormKeyWithUserQuit(string ids, string myId, string quitId) {
            return GetFormKeyWithUserRemoved(ids, myId, quitId, "_quit");
        }

        /// <summary>
        /// 채팅창 폼키에 특정사용자를 quit 또는 out처리함.
        /// id를 빼지는 않고, (id)_out or (id)_quit으로 문자열변경함.
        /// 
        /// 다자 채팅창에서 이미 "_quit"인 경우 로그아웃때 "_out"처리하지 않음.
        /// </summary>
        /// <param name="ids">폼키</param>
        /// <param name="myId"></param>
        /// <param name="outId">대상사용자id</param>
        /// <param name="tag"> "_out" or "_quit" </param>
        /// <returns></returns>
        public static string GetFormKeyWithUserRemoved(string ids, string myId, string outId, string tag) {
            if (ids.Contains(outId)) { //
                SortedList aList = GetFormKeySortedList(ids);

                string formKey = myId;
                ICollection keys = aList.Keys;
                foreach (string key in keys) {
                    if (key == myId)
                        continue;
                    if (key == outId) {
                        formKey += "/" + outId + tag;
                    } else {
                        formKey += "/" + key;
                    }
                }
                return formKey;
            } else {
                return GetFormKey(ids, myId);
            }
        }


        /// <summary>
        /// 폼키내의 id를 순차정렬리스트로 재구성
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static SortedList GetFormKeySortedList(string ids) {

            SortedList aList = new SortedList();
            string[] idsArr = ids.Split('/');
            foreach (string item in idsArr) {
                aList.Add(item, item);
            }
            return aList;
        }

        /// <summary>
        /// 폼키내의 id를 순차정렬리스트로 재구성
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static SortedList GetFormKeySortedList(List<string> ids)
        {
            SortedList aList = new SortedList();
            foreach (string item in ids)
            {
                aList.Add(item, item);
            }
            return aList;
        }

        public static string RemoveFromTitle(string title, string name) {
            string result = "";
            string[] titleArr = title.Split('/');
            foreach (string item in titleArr) {
                if (item == name)
                    continue;
                if (result.Length > 1)
                    result += "/";
                result += item;
            }
            return result;
        }

        public static ChatForm GetParentChatForm(Control ctrl) {
           
            Control parent = ctrl.Parent;
        
            while (! (parent is ChatForm))
            {
                parent = parent.Parent;
            }
            return (ChatForm)parent;
        }

        public static AddMemberForm GetParentAddMemberForm(Control ctrl)
        {
            Control parent = ctrl.Parent;

            while (!(parent is AddMemberForm))
            {
                parent = parent.Parent;
            }
            return (AddMemberForm)parent;
        }

        public static NoticeListForm GetParentNoticeListForm(Control ctrl) {
            Control parent = ctrl.Parent;

            while (!(parent is NoticeListForm)) {
                parent = parent.Parent;
            }
            return (NoticeListForm)parent;
        }

        public static SendMemoForm GetParentSendMemoForm(Control ctrl) {
            Control parent = ctrl.Parent;

            while (!(parent is SendMemoForm)) {
                parent = parent.Parent;
            }
            return (SendMemoForm)parent;
        }

        public static SendFileForm GetParentSendFileForm(Control ctrl) {
            Control parent = ctrl.Parent;

            while (!(parent is SendFileForm)) {
                parent = parent.Parent;
            }
            return (SendFileForm)parent;
        }

        public static Color GetCustomColor(string customColor)
        {
            Color c = System.Drawing.Color.Black;
            try
            {
                if (customColor != null && customColor.Length > 0)
                {
                    Logger.info("customColor = " + customColor);
                    c = Color.FromName(customColor);
                }
            }
            catch (Exception ex)
            {
                Logger.error(string.Format("GetCustomColor({0}) Error : {1}",customColor, ex.ToString()));
            }
            return c;
        }

        public static Font GetCustomFont(string customFont)
        {
            System.Drawing.Font f = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            try
            {
                if (customFont != null && customFont.Length > 0)
                {
                    TypeConverter fontConverter = TypeDescriptor.GetConverter(typeof(Font));
                    Logger.info("customFont = " + customFont);
                    f = (Font)fontConverter.ConvertFromString(customFont);
                }
            }
            catch (Exception ex)
            {
                Logger.error(string.Format("GetCustomFont({0}) Error : {1}", customFont, ex.ToString()));
            }
            return f;
        }
    }



}
