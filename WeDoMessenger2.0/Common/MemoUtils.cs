using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using WeDoCommon;

namespace Client.Common
{
    class MemoUtils
    {
        /// <summary>
        /// </summary>
        /// <param name="myId"></param>
        /// <param name="memo">메모는 메시지 형식:m|senderName|senderId|content|receiverId|timeKey</param>
        public static void MemoFileWrite(string myId, MemoObj obj)
        {
            StreamWriter sw = null;
            try
            {
                FileInfo memofile = new FileInfo(string.Format(ConstDef.MSGR_DATA_MEMO_DIR,myId) + Utils.LogFileName() + ".mem");
                if (!memofile.Exists)
                    MemoFileCheck(myId);
                sw = memofile.AppendText();
                sw.WriteLine(obj.MsgStr);
                sw.Close();
                Logger.info("메모저장");
            }
            catch (Exception e)
            {
                Logger.error("메모저장 에러 : " + e.ToString());
                throw new Exception("메모저장 에러");
            }
        }

        public static List<MemoObj> MemoFileRead(string myId)
        {
            StreamReader sr = null;
            List<MemoObj> list = new List<MemoObj>(); ;
            try
            {
                DirectoryInfo info = new DirectoryInfo(string.Format(ConstDef.MSGR_DATA_MEMO_DIR, myId));
                if (!info.Exists)
                    MemoFileCheck(myId);
                else
                {
                    FileInfo[] files = info.GetFiles("*.mem");
                    foreach (FileInfo file in files)
                    {
                        sr = new StreamReader(file.FullName);
                        while (!sr.EndOfStream)
                        {
                            string memoitem = sr.ReadLine();
                            list.Add(new MemoObj(memoitem));
                        }
                        sr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.error("메모읽기 에러 : " + ex.ToString());
                throw new Exception("메모읽기 에러");
            }
            return list;
        }

        public static void MemoFileCheck(string myId)
        {
            string strMemoDir = string.Format(ConstDef.MSGR_DATA_MEMO_DIR, myId);
            DirectoryInfo memoDir = new DirectoryInfo(strMemoDir);
            try
            {
                if (!memoDir.Exists)
                {
                    memoDir.Create();
                    Logger.info(string.Format("Memo 저장 폴더 생성[{0}]",strMemoDir));
                }
                FileInfo memoFile = new FileInfo(strMemoDir + Utils.LogFileName() + ".mem");
                if (!memoFile.Exists)
                {
                    memoFile.Create();
                    Logger.info(Utils.LogFileName() + ".mem 파일 생성");
                }
            }
            catch (Exception ex) {
                Logger.error("메모파일검사 에러 : " + ex.ToString());
                throw new Exception("메모파일검사 에러");
            };
        }

        public static bool DelMemo(string myId, MemoObj obj)
        {
            string strMemoDir = string.Format(ConstDef.MSGR_DATA_MEMO_DIR, myId);
            DirectoryInfo info = new DirectoryInfo(strMemoDir);
            StreamReader sr = null;
            bool isFind = false;
            if (!info.Exists)
                MemoUtils.MemoFileCheck(myId);
            else
            {
                FileInfo[] files = info.GetFiles("*.mem");
                string memo = obj.MsgStr;
                foreach (FileInfo file in files)
                {
                    Logger.info(file.Name);
                    sr = new StreamReader(file.FullName);
                    string str = sr.ReadToEnd();
                    sr.Close();
                    if (str.Contains(memo))
                    {
                        str = str.Remove(str.IndexOf(memo), memo.Length);
                        StreamWriter sw = new StreamWriter(file.FullName);
                        sw.Write(str);
                        sw.Close();
                        break;
                    }
                }
            }
            return isFind;
        }

    }
}
