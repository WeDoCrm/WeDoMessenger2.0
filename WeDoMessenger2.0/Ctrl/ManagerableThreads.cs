using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using WeDoCommon;
using System.Threading;
using WeDoCommon.Sockets;

namespace Client
{
    public class AbstractItems<T> where T : class 
    {
        protected static readonly object lockObject = new object();
        protected static Dictionary<string, T> mTable = new Dictionary<string, T>();
        protected static string curVisibleFormKey = "";

        public static void Add(string key, T item)
        {
            lock (lockObject)
            {
                mTable[key] = item;
            }
        }

        public static bool Contain(string key)
        {
            return (mTable.ContainsKey(key) && mTable[key] != null);
        }

        public static T Get(string key)
        {
            T result = null;
            lock (lockObject)
            {
                if (mTable.ContainsKey(key) && mTable[key] != null)
                    result = mTable[key];
            }
            return result;
        }

        public static void Remove(string key)
        {
            lock (lockObject)
            {
                mTable.Remove(key);
            }
        }
        
        public static void Close()
        {
            lock (lockObject)
            {
                foreach (var de in mTable)
                {
                    if (de.Value != null)
                    {
                        try
                        {
                            T item = (T)de.Value;
                            (item as Thread).Abort();
                        }
                        catch (Exception e)
                        {
                            Logger.error("item.Close() 에러 : " + e.ToString());
                        }
                    }
                }
                mTable.Clear();
                Logger.error(typeof(T).Name +" Cleared.");
            }
        }
    }

    //public class FileSendThreads : AbstractItems<Thread>
    //{

    //}

    public class FtpClientManagers : AbstractItems<FtpClientManager>
    {
        public new static void Close()
        {
            lock (lockObject)
            {
                foreach (var de in mTable)
                {
                    if (de.Value != null)
                    {
                        try
                        {
                            FtpClientManager item = (FtpClientManager)de.Value;
                            (item as FtpClientManager).Close();
                        }
                        catch (Exception e)
                        {
                            Logger.error("FtpClientManagers.Dispose() 에러 : " + e.ToString());
                        }
                    }
                }
                mTable.Clear();
                Logger.error("FtpClientManagers 종료");
            }
        }
    }
}
