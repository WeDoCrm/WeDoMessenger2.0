using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using WeDoCommon;
using System.Windows.Forms;
using WeDoCommon.Sockets;

namespace Client
{

    public class AbstractForms<T> where T : class 
    {
        protected static readonly object lockObject = new object();
        protected static Dictionary<string, T> formTable = new Dictionary<string, T>();
        protected static string curVisibleFormKey = "";

        public static void AddForm(string key, T form)
        {
            lock (lockObject)
            {
                formTable[key] = form;
                Logger.info(typeof(T).Name + " AddForm key=" + key);
            }
        }

        public static int Count { get { return formTable.Count;  } }

        public static void AddForm(string key)
        {
            lock (lockObject)
            {
                //Func<string, T> del = new del<string, T>();
                T form = (T)Activator.CreateInstance(typeof(T), key);
                //T form = (T)Activator.CreateInstance(typeof(T),key);//new T(key);
                formTable[key] = form;
            }
        }

        public static bool Contain(string key)
        {
            return (formTable.ContainsKey(key) && formTable[key] != null);
        }

        public static void ActivateForm(string key, Form owner)
        {
            lock (lockObject)
            {
                T curForm = GetForm(curVisibleFormKey);
                if (curForm != null)
                    (curForm as Form).Hide();
                T nextForm = GetForm(key);
                if (nextForm != null)
                {
                    (nextForm as Form).ShowDialog(owner);
                    curVisibleFormKey = key;
                }
            }
        }

        public static T GetForm(string key)
        {
            T result = null;
            lock (lockObject)
            {
                if (formTable.ContainsKey(key) && formTable[key] != null)
                    result = formTable[key];
            }
            return result;
        }

        public static void RemoveForm(string key)
        {
            lock (lockObject)
            {
                formTable.Remove(key);
                Logger.info(typeof(T).Name + " Remove key=" + key);
            }
        }
        
        public static void Dispose()
        {
            lock (lockObject)
            {
                List<string> keyList = formTable.Keys.ToList();
                foreach (string key in keyList)
                {
                    if (formTable.ContainsKey(key))
                    {
                        try
                        {
                            T form = (T)formTable[key];
                            if (form != null && !(form as Form).IsDisposed)
                            {
                                (form as Form).Close();
                                (form as Form).Dispose();
                            }
                        }
                        catch (Exception e)
                        {
                            Logger.error(typeof(T).Name +":form.Dispose() 에러 : " + e.ToString());
                        }
                    }
                }
                formTable.Clear();
                Logger.error(typeof(T).Name + " Clear!");
            }
        }
    }

    public class ChatForms : AbstractForms<ChatForm>
    {
        /// <summary>
        /// 1. 채팅창에 user상태 변경
        /// 2. login: user가 속한 채팅창의 user정보 활성화.
        /// 3. logout: 반대로 처리
        /// </summary>
        /// <param name="newFormKey"></param>
        /// <param name="oldFormKey"></param>
        public static void UpdateFormKey(string newFormKey, string oldFormKey)
        {
            ChatForm result = null;
            lock (lockObject)
            {
                if (formTable.ContainsKey(oldFormKey) && formTable[oldFormKey] != null)
                    result = formTable[oldFormKey];
                formTable.Remove(oldFormKey);
                result.SetFormKey(newFormKey);
                formTable.Add(newFormKey, result);
            }
        }


        public static ChatForm FindSingleChatForm(string findId)
        {
            ChatForm result = null;
            lock (lockObject)
            {

                foreach (var de in formTable)
                {
                    if (de.Value != null)
                    {
                        try
                        {
                            ChatForm form = (ChatForm)de.Value;
                            if (form.ContainsId(findId) && form.HasSingleChatter())
                            {
                                result = form;
                            }
                        }
                        catch (Exception e)
                        {
                            Logger.error("FindChatForm 에러 : " + e.ToString());
                        }
                    }
                }
            }
            return result;

        }
    }

    public class DownloadForms : AbstractForms<DownloadForm>
    {
    }

    public class FileSendDetailListViews : AbstractForms<FileSendDetailListView>
    {
    }

    public class MemoForms
    {
        private static readonly object lockObject = new object();
        private static List<MemoForm> formTable = new List<MemoForm>();

        public static void AddForm(MemoForm form)
        {
            lock (lockObject)
            {
                formTable.Add(form);
            }
        }

        public static void Dispose()
        {
            lock (lockObject)
            {
                if (formTable.Count != 0) return;

                foreach (MemoForm frm in formTable)
                {
                    if (frm != null)
                    {
                        try
                        {
                            frm.Close();
                            frm.Dispose();
                        }
                        catch (Exception e)
                        {
                            Logger.error("form.Dispose() 에러 : " + e.ToString());
                        }
                    }
                }
                formTable.Clear();
                Logger.info("MemoForm Clear!");
            }
        }
    }

    public class NoticeDetailForms : AbstractForms<NoticeDetailResultForm>
    {
        public static void AddForm(string key, List<string> unReadersList)
        {
            NoticeDetailResultForm form = new NoticeDetailResultForm(key, unReadersList);
            formTable[key] = form;
        }

        public static void UpdateNoticeRead(string key, string readerId)
        {
            NoticeDetailResultForm frm = GetForm(key);
            frm.SetNoticeRead(readerId);
        }
    }

    public class SendFileForms : AbstractForms<SendFileForm>
    {
        //key는 Utils.GenerateClientKey의 리턴값
        private static Dictionary<string, string> mKeyMap = new Dictionary<string, string>();
        public static void AddClientKey(string fileName, long fileSize, string receiverId, string formKey)
        {
            string key = WeDoCommon.Sockets.SocUtils.GenerateFTPClientKey(ConfigHelper.Id, SocUtils.GetFileName(fileName), fileSize, receiverId);
            lock (lockObject)
            {
                mKeyMap[key] = formKey;
                Logger.info(string.Format("SendFileForm AddClientKey key[{0}]formkey[{1}]", key, formKey));
            }
        }

        public static void AddClientKey(string key, string formKey)
        {
            lock (lockObject)
            {
                mKeyMap[key] = formKey;
            }
        }

        public static bool ContainClientKey(string key)
        {
            bool result = false;
            lock (lockObject)
            {
                result = mKeyMap.ContainsKey(key);
            }
            return result;
        }

        public static bool ContainClientKey(SendFileForm frm, string key)
        {
            bool result = false;
            lock (lockObject)
            {
                if (mKeyMap.ContainsKey(key))
                {
                    string formKey = mKeyMap[key];
                    if (formKey.Equals(frm.FormKey)) result = true;
                }
            }
            return result;
        }
        
        public static SendFileForm GetFormByClientKey(string key)
        {
            SendFileForm form;
            lock (lockObject)
            {
                string formKey = mKeyMap[key];
                form = formTable[formKey];
            }
            return form;
        }

        public static void RemoveForm(string key)
        {
            SendFileForm form;
            lock (lockObject)
            {
                if (mKeyMap.ContainsValue(key))
                {
                    List<string> clientKeys = new List<string>();
                    foreach (var de in formTable)
                    {
                        if (key.Equals(de.Key)) clientKeys.Add(de.Key);
                    }
                    foreach (string item in clientKeys)
                    {
                        mKeyMap.Remove(item);
                        Logger.info(string.Format("SendFileForm RemoveForm key[{0}]formkey[{1}]", item, key));
                    }
                }
                formTable.Remove(key);
            }
        }

        public static void Dispose()
        {
            AbstractForms<SendFileForm>.Dispose();
            mKeyMap.Clear();
        }

    }
    
    public class SendMemoForms : AbstractForms<SendMemoForm>
    {
    }

    public class TransferNotiForms
    {
        private static readonly object lockObject = new object();
        private static Dictionary<int, AreaToUse> transferAreas = new Dictionary<int, AreaToUse>();
        private static List<TransferNotiForm> notiForms = new List<TransferNotiForm>();

        private enum AreaToUse
        {
            EMPTY = 0,
            USED = 1
        }

        private TransferNotiForms()
        {
        }

        /// <summary>
        /// 이관알림창띄울 위치정보설정
        /// </summary>
        public static void Initialize()
        {
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int end = screenHeight - 48;

            transferAreas[end] = AreaToUse.EMPTY;
            for (int i = 1; i < 5; i++)
            {
                end -= 48;
                transferAreas[end] = AreaToUse.EMPTY;
                Logger.info("transferAreas[" + end + "] 추가");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        public static void AddForm(TransferObj obj)
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            lock (lockObject)
            {
                int availableTop = GetAvailableTop();

                TransferNotiForm miniform = new TransferNotiForm(obj);
                miniform.SetBounds(screenWidth - miniform.Width, availableTop, miniform.Width, miniform.Height);
                miniform.TopLevel = true;
                miniform.Show();

                transferAreas[availableTop] = AreaToUse.USED;
                notiForms.Add(miniform);
            }

        }

        public static void AddForm(string ani, string name)
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            lock (lockObject)
            {
                int availableTop = GetAvailableTop();

                TransferNotiForm miniform = new TransferNotiForm(ani, name);
                miniform.SetBounds(screenWidth - miniform.Width, availableTop, miniform.Width, miniform.Height);
                miniform.TopLevel = true;
                miniform.Show();

                transferAreas[availableTop] = AreaToUse.USED;
                notiForms.Add(miniform);
            }

        }

        private static int GetAvailableTop()
        {
            int resultTop = 0;
            if (transferAreas.Count > 0)
            {
                foreach (var de in transferAreas)
                {
                    //value=0 사용가능 1이면 사용중/ 이면 해당 key는 top이 된
                    if (de.Value == AreaToUse.EMPTY)
                    {
                        int temp = de.Key;
                        if (temp > resultTop)
                        {
                            resultTop = temp;
                        }
                    }
                    else
                    {
                        Logger.info("transferAreas[" + de.Key + "]사용중");
                    }
                }
                if (resultTop == 0)
                {
                    //가장 오래된 태그폼 삭제
                    RemoveFirst();
                    resultTop = GetAvailableTop();
                }

            }
            return resultTop;
        }

        private static void RemoveFirst()
        {
            try
            {
                Logger.info("TransferNotiForm 가장 오래된 것 삭제");
                lock (lockObject)
                {
                    TransferNotiForm miniform = (TransferNotiForm)notiForms[0];
                    if (transferAreas.ContainsKey(miniform.Top))
                    {
                        transferAreas[miniform.Top] = AreaToUse.EMPTY;
                    }
                    miniform.Close();
                    notiForms.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }


        public static void CloseForm(TransferNotiForm form)
        {
            try
            {
                Logger.info("CloseForm:TransferNotiForm 닫기");
                lock (lockObject)
                {
                    if (transferAreas.ContainsKey(form.Top))
                    {
                        transferAreas[form.Top] = AreaToUse.EMPTY;
                    }

                    bool result = notiForms.Remove(form);
                    if (result)
                        Logger.info("CloseForm: notiForms에서 form삭제");
                    else
                        Logger.info("CloseForm: notiForms에서 form삭제실패-Not found.");

                    form.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }
    }
}
