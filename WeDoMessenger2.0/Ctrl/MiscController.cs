using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WeDoCommon;
using System.Windows.Forms;
using System.Collections;

namespace Client
{
    public class MiscController
    {
        public void DisplayDialogList()
        {
            DialogListForm mDialogListForm = null;
            try
            {
                ArrayList list = new ArrayList();

                CheckDialogSaveFolder();
                DirectoryInfo dialogDirInfo = new DirectoryInfo(string.Format(WeDoCommon.ConstDef.MSGR_DATA_DLOG_DIR, ConfigHelper.Id));
                DirectoryInfo[] dirArray = dialogDirInfo.GetDirectories(); //월별폴더 검색

                foreach (DirectoryInfo tempDir in dirArray)
                {
                    DirectoryInfo[] subDirArray = tempDir.GetDirectories();    //일별폴더 검색
                    foreach (DirectoryInfo subDir in subDirArray)
                    {
                        FileInfo[] fileArray = subDir.GetFiles("*.dlg");
                        foreach (FileInfo tempFile in fileArray)
                        {
                            list.Add(tempFile);
                        }
                    }

                }

                if (list.Count == 0)
                {
                    MessageBox.Show("저장된 대화기록이 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogListForm frm = new DialogListForm(list);
                    
                    mDialogListForm.Show();
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        public void CheckDialogSaveFolder()
        {
            string today = "";
            string month = "";
            string dialogDir = "";
            DirectoryInfo resultDirInfo = null;
            try
            {
                today = DateTime.Now.ToShortDateString();
                month = today.Substring(0, 7);
                dialogDir = string.Format(WeDoCommon.ConstDef.MSGR_DATA_DLOG_DIR, ConfigHelper.Id)
                     + month + "\\" + today;

                resultDirInfo = new DirectoryInfo(dialogDir);
                if (!resultDirInfo.Exists)
                {
                    resultDirInfo.Create();
                    Logger.info(string.Format(" 대화저장폴더[{0}] 생성", dialogDir));
                }
            }
            catch (Exception e)
            {
                Logger.error(string.Format(" 대화저장폴더[{0}] 생성 실패:", dialogDir) + e.ToString());
            };
            
        }

        public void WriteDialogSaveFile(string dialogkey, string dialog, string person)
        {
            string today = "";
            string month = "";
            string dialogDir = "";
            string dialogFile = "";
            try
            {
                today = DateTime.Now.ToShortDateString();
                month = today.Substring(0, 7);
                dialogDir = string.Format(WeDoCommon.ConstDef.MSGR_DATA_DLOG_DIR, ConfigHelper.Id)
                     + month + "\\" + today;

                if (dialog.Length < 1) return;

                string[] array = dialogkey.Split('!');
                StreamWriter sw = null;

                CheckDialogSaveFolder();

                string now = DateTime.Now.Hour.ToString() + "시_" + DateTime.Now.Minute.ToString() + "분_" + DateTime.Now.Second.ToString() + "초";
                string dkey = now + "!" + person;

                dialogFile = dialogDir + "\\" + dkey + ".dlg";
                Logger.info("DialogFileWrite dkey = " + dkey);

                FileInfo path = new FileInfo(dialogFile);

                sw = new StreamWriter(path.FullName, false);
                try
                {
                    sw.Write(dialog);
                    sw.Flush();
                    Logger.info("DialogFileWrite 대화저장");
                }
                finally
                {
                    if (sw != null) sw.Close();
                }
            }
            catch (Exception e)
            {
                Logger.error(string.Format("대화저장[{0}{1}] 에러 : ", dialogFile, dialog) + e.ToString());
            }
        }

        /// <summary>
        /// 전송파일폴더 생성
        /// </summary>
        public void CheckFileSaveFolder()
        {
            
            DirectoryInfo fileDir = null;
            try
            {
                fileDir = new DirectoryInfo(string.Format(WeDoCommon.ConstDef.MSGR_DATA_FILE_DIR, ConfigHelper.Id));

                if (!fileDir.Exists)
                {
                    fileDir.Create();
                    Logger.info(string.Format("전송파일 폴더 생성[{0}]", fileDir.FullName));
                }
            }
            catch (Exception e)
            {
                Logger.error(string.Format("전송파일 폴더 생성 실패[{0}]:", fileDir.FullName) + e.ToString());
            };
        }

        public void DisplaySetServerForm()
        {
            SetServer_Form frm = null;
            try
            {
                frm = new SetServer_Form();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Logger.info("서버 IP 설정 변경");
                }

            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
            finally
            {
                if (frm != null) frm.Dispose();
            }
        }

        public void DisplayAboutForm()
        {
            try
            {
                AboutForm aboutform = new AboutForm();
                aboutform.lbl_version.Text = CommonDef.APP_VERSION;
                if (aboutform.ShowDialog() == DialogResult.OK)
                {
                    Logger.info("About 창 닫기");
                }
                aboutform.Dispose();
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        public void DisplaySetAutoStartForm()
        {
            try
            {
                SetAutoStartForm frm = new SetAutoStartForm();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Logger.info("환경설정 변경");
                }
                frm.Dispose();

            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

    }
}
