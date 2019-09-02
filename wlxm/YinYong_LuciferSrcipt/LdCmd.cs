using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace LuciferSrcipt
{
    /// <summary>
    /// 雷电模拟器命令大全【使用的dnconsole和ld命令超稳定】
    /// </summary>
    public class LdCmd
    {
        /// <summary>
        /// 模拟器路径
        /// </summary>
        public string SimulatorPath { get; set; }
        #region 单例模式变量
        private static readonly object obj = new object();
        private static LdCmd ldCmd = null;
        #endregion

        private LdCmd()
        {

        }
        /// <summary>
        /// 单例模式====双层互锁
        /// </summary>
        /// <returns></returns>
        public static LdCmd GetObject()
        {
            if (ldCmd == null)
            {
                lock (obj)
                {
                    if (ldCmd == null)
                    {
                        ldCmd = new LdCmd();
                    }
                }
            }
            return ldCmd;
        }
        /// <summary>
        /// 执行CMD窗口信息
        /// </summary>
        /// <param name="value">模拟器命令</param>
        /// <returns>执行后的信息</returns>
        private string ImplementCmd(string value)
        {
            Process p = new Process();
            //设置要启动的应用程序
            p.StartInfo.FileName = "cmd.exe";
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = true;
            // 输出错误
            p.StartInfo.RedirectStandardError = true;
            //不显示程序窗口
            p.StartInfo.CreateNoWindow = true;
            //启动程序
            p.Start();
            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(value);
            p.StandardInput.WriteLine("exit");
            p.StandardInput.AutoFlush = true;
            //获取输出信息
            string strOuput = p.StandardOutput.ReadToEnd();
            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();
            return strOuput;
        }
        /// <summary>
        /// 输出模拟器所有包名
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <returns></returns>
        public string OutputAllPackages(int index)
        {
            return ImplementCmd(
                string.Format("{0}ld -s {1} pm list packages", SimulatorPath, index));
        }
        /// <summary>
        /// 获取模拟器所有包名并且包括APK路径
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <returns></returns>
        public string OutputAllPackagesPath(int index)
        {
            return ImplementCmd(
                string.Format("{0}ld -s {1} pm list packages -f", SimulatorPath, index));
        }
        /// <summary>
        /// 获取包名对应的APK路径
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <param name="packageName">App包名</param>
        /// <returns></returns>
        public string OutputPackagesPath(int index, string packageName)
        {
            return ImplementCmd(
                string.Format("{0}ld -s {1} pm path {2}", SimulatorPath, index, packageName));
        }
        /// <summary>
        /// 清理应用数据
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <param name="packageName">App包名</param>
        /// <returns></returns>
        public string ClearAppData(int index, string packageName)
        {
            MyUtil.WriteLog.WriteLogFile("", SimulatorPath+" " + index + " " + packageName);
            return ImplementCmd(
                string.Format("{0}ld -s {1} pm clear {2}", SimulatorPath, index, packageName));
        }
        /// <summary>
        /// 安装应用
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <param name="packagePath">模拟器路径</param>
        /// <returns></returns>
        public string InstallAPP(int index, string packagePath)
        {
            //return ImplementCmd(
            //    string.Format("{0}ld -s {1} pm install {2}", SimulatorPath, index, packagePath));

            return ImplementCmd(
                string.Format("{0}dnconsole.exe installapp --index {1} --filename {2}", SimulatorPath, index, packagePath));

        }
        /// <summary>
        /// 卸载应用
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <param name="packageName">APP包名</param>
        /// <returns></returns>
        public string UnInstallApp(int index, string packageName)
        {
            return ImplementCmd(
                string.Format("{0}ld -s {1} pm uninstall {2}", SimulatorPath, index, packageName));
        }
        /// <summary>
        /// 输入字母数字字符等 PS：不支持输入中文
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <param name="value">字母数字字符等字符串</param>
        /// <returns></returns>
        public string InputText(int index, string value)
        {
            return ImplementCmd(
                string.Format("{0}ld -s {1} input text {2}", SimulatorPath, index, value));
        }
        /// <summary>
        /// 输入中文
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value">中文字符串</param>
        /// <returns></returns>
        public string InputChinese(int index, string value)
        {
            lock (obj)
            {
                return ImplementCmd(
                    string.Format("{0}dnconsole action --index {1} --key call.input --value {2}", SimulatorPath, index, value));
            }
        }
        /// <summary>
        /// 输入键盘值  PS：自行百度找键盘值
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <param name="key">keycode</param>
        /// <returns></returns>
        public string InputKeyevent(int index, string key)
        {
            return ImplementCmd(
                string.Format("{0}ld -s {1} input keyevent {2}", SimulatorPath, index, key));
        }
        /// <summary>
        /// 模拟鼠标点击
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <param name="position">坐标PS：X Y</param>
        /// <returns></returns>
        public string InputPosition(int index, string position)
        {
            return ImplementCmd(
                string.Format("{0}ld -s {1} input tap {2}", SimulatorPath, index, position));
        }
        /// <summary>
        /// 模拟鼠标滑动
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <param name="position">滑动坐标 PS：X1 Y1 X2 Y2</param>
        /// <returns></returns>
        public string InputSwipt(int index, string position)
        {
            return ImplementCmd(
                string.Format("{0}ld -s {1} input swipe {2}", SimulatorPath, index, position));
        }
        /// <summary>
        /// 启动应用
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <param name="value">包名/Activity类名</param>
        /// <returns></returns>
        public string StartApp(int index, string value)
        {
            return ImplementCmd(
                string.Format("{0}ld -s {1} am start -n {2}", SimulatorPath, index, value));
        }
        /// <summary>
        /// 关闭应用
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <param name="packageName">包名</param>
        /// <returns></returns>
        public string StopApp(int index, string packageName)
        {
            return ImplementCmd(
                string.Format("{0}ld -s {1} am force-stop {2}", SimulatorPath, index, packageName));
        }
        /// <summary>
        /// 截屏
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <param name="path">截屏保存路径  PS：建议保存共享路径</param>
        /// <returns></returns>
        public string Screencap(int index, string path)
        {
            return ImplementCmd(
                string.Format("{0}ld -s {1} screencap -p {2}", SimulatorPath, index, path));
        }
        /// <summary>
        /// 打开模拟器
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <returns></returns>
        public string Launch(int index)
        {
            lock (obj)
            {
                return ImplementCmd(
                    string.Format("{0}dnconsole launch --index {1}", SimulatorPath, index));
            }
        }
        /// <summary>
        /// 退出指定模拟器
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <returns></returns>
        public string Quit(int index)
        {
            lock (obj)
            {
                return ImplementCmd(
                    string.Format("{0}dnconsole quit --index {1}", SimulatorPath, index));
            }
        }
        /// <summary>
        /// 退出所有正在打开的模拟器
        /// </summary>
        /// <returns></returns>
        public string QuitAll()
        {
            lock (obj)
            {
                return ImplementCmd(
                    string.Format("{0}dnconsole quitall", SimulatorPath));
            }
        }
        /// <summary>
        /// 重启模拟器
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <param name="packageName">启动后并打开 packagename 应用, null 表示不打开任何应用</param>
        /// <returns></returns>
        public string Reboot(int index, string packageName = null)
        {
            lock (obj)
            {
                return ImplementCmd(
                    string.Format("{0}dnconsole action --index {1} --key call.reboot --value {2}", 
                    SimulatorPath, index, packageName));
            }
        }
        /// <summary>
        /// 设置地点，经度，维度
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <param name="locate">经度,维度 PS：12.3,45.6</param>
        /// <returns></returns>
        public string Locate(int index, string locate)
        {
            lock (obj)
            {
                return ImplementCmd(
                    string.Format("{0}dnconsole action --index {1} --key call.locate --value {2}",
                    SimulatorPath, index, locate));
            }
        }
        /// <summary>
        /// 查看已创建的模拟器状态 PS：依次是：索引,标题,顶层窗口句柄,绑定窗口句柄,是否进入android,进程PID,VBox进程PID
        /// </summary>
        /// <returns>返回List集合</returns>
        public List<string> ListSimulator()
        {
            lock (obj)
            {
                List<string> list = new List<string>();
                string[] str = Regex.Split(ImplementCmd(
                    string.Format("{0}dnconsole list2",
                    SimulatorPath)), "\r\n", RegexOptions.IgnoreCase);
                for (int i = 4; i < (str.Length - 3); i++)
                {
                    list.Add(str[i]);
                }
                return list;
            }
        }
        /// <summary>
        /// CPU优化
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <param name="rate">0~100</param>
        /// <returns></returns>
        public string Downcpu(int index,int rate)
        {
            lock (obj)
            {
                return ImplementCmd(
                    string.Format("{0}dnconsole downcpu {1} --rate {2}",
                    SimulatorPath, index, rate));
            }
        }
        /// <summary>
        /// 新增模拟器
        /// </summary>
        /// <param name="name">模拟器名字 默认为NULL</param>
        /// <returns></returns>
        public string AddSimulator(string name = null)
        {
            lock (obj)
            {
                if (name == null)
                {
                    return ImplementCmd(string.Format("{0}dnconsole add", SimulatorPath));
                }
                return ImplementCmd(string.Format("{0}dnconsole add --name {1}", SimulatorPath, name));
            }
        }
        /// <summary>
        /// 复制模拟器
        /// </summary>
        /// <param name="index">要复制的模拟器序号</param>
        /// <param name="name">模拟器名字  默认为NULL</param>
        /// <returns></returns>
        public string CopySimulator(int index, string name = null)
        {
            lock (obj)
            {
                if (name == null)
                {
                    return ImplementCmd(string.Format("{0}dnconsole copy --from {1}", SimulatorPath, index));
                }
                return ImplementCmd(string.Format("{0}dnconsole copy --name {1} --from {2}", SimulatorPath, name, index));
            }
        }
        /// <summary>
        /// 删除模拟器
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <returns></returns>
        public string RemoveSimulator(int index)
        {
            lock (obj)
            {
                return ImplementCmd(string.Format("{0}dnconsole remove --index {1}", SimulatorPath, index));
            }
        }
        /// <summary>
        /// 模拟器一件排序,在模拟器自带的多开器配置排序规则
        /// </summary>
        /// <returns></returns>
        public string SortWnd()
        {
            lock (obj)
            {
                return ImplementCmd(string.Format("{0}dnconsole sortWnd", SimulatorPath));
            }
        }
        /// <summary>
        /// 模拟器二维码扫描 PS：3.18版本以上版本支持, 需要app先启动扫描,再调用这个命令
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <param name="codePath">二维码文件路径</param>
        /// <returns></returns>
        public string Scan(int index, string codePath)
        {
            lock (obj)
            {
                return ImplementCmd(string.Format("{0}dnconsole scan --index {1} --file {2}", SimulatorPath, index, codePath));
            }
        }
        /// <summary>
        /// 获取界面控件类名
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <param name="filePath">模文件保存路径【注意这里是模拟器内的路径】 PS：/sdcard/Pictures/android{1}.txt</param>
        /// <returns></returns>
        public string GetAndroidClass(int index, string filePath)
        {
            return ImplementCmd(string.Format("{0}ld -s {1} uiautomator dump {2}", SimulatorPath, index, filePath));
        }
        /// <summary>
        /// 唤起QQ群
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <param name="number">QQ群号</param>
        /// <returns></returns>
        public string EvokeQQFlock(int index, string number)
        {
            return ImplementCmd(string.Format("{0}ld -s {1} am start -a android.intent.action.VIEW -d \"mqqapi://card/show_pslcard?src_type=internal\\&version=1\\&uin={2}\\&card_type=group\\&source=qrcode\"",
                SimulatorPath,
                index,
                number));
        }
        /// <summary>
        /// 唤起QQ好友
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <param name="number">好友QQ号</param>
        /// <returns></returns>
        public string EvokeQQ(int index, string number)
        {
            return ImplementCmd(string.Format("{0}ld -s {1} am start -a android.intent.action.VIEW -d \"mqqwpa://im/chat?chat_type=wpa\\&uin={2}\"",
                SimulatorPath,
                index,
                number));
        }
        /// <summary>
        /// 模拟器内移动文件
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <param name="sourcePath">文件路径 PS：/sdcard/Pictures/image.png</param>
        /// <param name="destPath">文件夹路径 PS：/sdcard/DCIM</param>
        /// <returns></returns>
        public string MoveImage(int index, string sourcePath, string destPath)
        {
            return string.Format("{0}ld -s {1} cp -f {2} {3}", SimulatorPath, index, sourcePath, destPath);
        }

    }
}
