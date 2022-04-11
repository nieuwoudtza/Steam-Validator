using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steam_Validator
{
    public partial class CfrmMain : Form
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

        int MaxTries = 3;

        public CfrmMain()
        {
            InitializeComponent();

            Prepare();
        }

        void ToggleUI(bool enabled)
        {
            Invoke((Action)delegate
            {
                foreach (Control control in Controls)
                    control.Enabled = enabled;
            });
        }

        void UpdateText(string text = "")
        {
            Invoke((Action)delegate
            {
                if (!string.IsNullOrEmpty(text))
                    Text = "Steam Validator - " + text;
                else
                    Text = "Steam Validator";
            });
        }

        void Prepare()
        {
            string Letters = "CABDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int i = 0; i < Letters.Length; i++)
            {
                string Path = Letters[i] + @":\Program Files (x86)\Steam\steamapps\libraryfolders.vdf";
                
                if (File.Exists(Path))
                {
                    txtLibFoldersPath.Text = Path;
                    break;
                }

                Path = Letters[i] + @":\SteamLibrary\steamapps\libraryfolders.vdf";

                if (File.Exists(Path))
                {
                    txtLibFoldersPath.Text = Path;
                    break;
                }

                Path = Letters[i] + @":\Steam\steamapps\libraryfolders.vdf";

                if (File.Exists(Path))
                {
                    txtLibFoldersPath.Text = Path;
                    break;
                }
            }
        }

        void Verify()
        {
            string Path = txtLibFoldersPath.Text;
            MaxTries = (int)nuMaxTries.Value;

            List<string> Failures = new List<string>();

            Thread thread = new Thread(async () =>
            {
                ToggleUI(false);

                string[] libraryfolders = File.ReadAllLines(Path);
                List<string> AppIDs = new List<string>();

                for (int i = 0; i < libraryfolders.Length; i++)
                {
                    string line = libraryfolders[i];
                    if (line.StartsWith("\t\t\t"))
                        AppIDs.Add(line.Split(new string[] { "\t", "" }, StringSplitOptions.RemoveEmptyEntries)[0].Replace("\"", ""));
                }

                AppIDs.Sort();

                for (int i = 0; i < AppIDs.Count; i++)
                {
                    bool success = false;
                    int _try = 0;

                    while (!success && _try++ < MaxTries)
                    {
                        try
                        {
                            UpdateText("Verifying " + (i + 1) + "/" + AppIDs.Count + " (0%)...");

                            ProcessStartInfo psi = new ProcessStartInfo("steam://validate/" + AppIDs[i]);

                            Process verify = new Process();
                            verify.StartInfo = psi;
                            verify.Start();

                            Process verifyWindow = new Process();
                            bool assigned = false;

                            while (!assigned)
                            {
                                Process[] steams = Process.GetProcessesByName("steam");

                                for (int j = 0; j < steams.Length; j++)
                                {
                                    if (steams[j].MainWindowTitle.ToLower().StartsWith("validating steam files"))
                                    {
                                        //ShowWindow(steams[j].MainWindowHandle, ShowWindowEnum.ForceMinimized);
                                        verifyWindow = steams[j];
                                        assigned = true;
                                        break;
                                    }
                                }

                                await Task.Delay(50);
                            }


                            int Tries = 0;

                            string PreviousMainWindowTitle = "";

                            while (true)
                            {
                                string MainWindowTitle = verifyWindow.MainWindowTitle.ToLower();

                                string Percentage = "";

                                try
                                {
                                    Percentage = MainWindowTitle.Substring("validating steam files - ".Length);
                                    Percentage = Percentage.Substring(0, Percentage.IndexOf('%'));
                                    UpdateText("Verifying " + (i + 1) + "/" + AppIDs.Count + " ("+ Percentage + "%)...");
                                }
                                catch { }

                                if (MainWindowTitle == PreviousMainWindowTitle)
                                {
                                    if (++Tries == 120)
                                    {
                                        verifyWindow.CloseMainWindow();
                                        break;
                                    }
                                }
                                else
                                {
                                    PreviousMainWindowTitle = MainWindowTitle;
                                    Tries = 0;
                                }

                                if (MainWindowTitle.EndsWith(" 100% complete"))
                                {
                                    verifyWindow.CloseMainWindow();
                                    success = true;
                                    break;
                                }

                                await Task.Delay(500);
                                verifyWindow.Refresh();
                            }

                            await Task.Delay(5000);
                        }
                        catch { }
                    }

                    if (!success)
                        Failures.Add(AppIDs[i]);
                }

                UpdateText();
                ToggleUI(true);

                Invoke((Action)delegate
                {
                    WindowState = FormWindowState.Normal;
                    TopMost = true;
                    TopMost = false;

                    if (Failures.Count > 0)
                        MessageBox.Show("Validation Complete\n\nFailed AppIDs:\n" + string.Join("\n", Failures), "Steam Validator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Validation Complete", "Steam Validator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            });
            thread.Start();
        }

        private void BtnSelectLibFoldersPath_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
                txtLibFoldersPath.Text = dlgOpen.FileName;

            dlgOpen.FileName = string.Empty;
        }

        private void BtnVerify_Click(object sender, EventArgs e)
        {
            Verify();
        }
    }

    public enum ShowWindowEnum
    {
        Hide = 0,
        ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
        Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
        Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
        Restore = 9, ShowDefault = 10, ForceMinimized = 11
    };

}
