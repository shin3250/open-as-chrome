using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace open_as_chrome {
    internal class Program {

        private static readonly string caption = "Chromeで開く";

        [STAThread]
        private static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if DEBUG
            args = new string[] { @"d:\temp\shin3250.url", "--new-window", "--save-page-as-mhtml" };
#endif
            if(args.Length < 1) {
                MessageBox.Show("対象を指定してください。", caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try {
                var url = GetUrl(args[0]);
                for(var i = 1; i < args.Length; i++) { url += " " + args[i]; }
                var startInfo = new ProcessStartInfo("chrome") { Arguments = url };
                var process = new Process { StartInfo = startInfo };
                process.Start();
            } catch {
                MessageBox.Show("Google Chromeの起動に失敗しました。", caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string GetUrl(string str) {
            if(Path.GetExtension(str) == ".url" && File.Exists(str)) {
                try {
                    using(var sr = new StreamReader(str)) {
                        if(!sr.EndOfStream && sr.ReadLine() == "[InternetShortcut]" && !sr.EndOfStream) {
                            var buff = sr.ReadLine();
                            if(Regex.IsMatch(buff, @"^url=http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$", RegexOptions.IgnoreCase)) { return buff.Substring(4); }
                        }
                    }
                } catch { }
            }
            return str;
        }
    }
}
