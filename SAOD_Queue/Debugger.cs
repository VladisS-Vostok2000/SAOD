using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.IO;

namespace SAOD_Queue {
    public static class Debugger {
        private static string path = @"C:\SAOD_Queue.log";
        private static StreamWriter streamWriter = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write)) { AutoFlush = true};
        private static string text = "";
        internal static bool Enabled { set; get; }



        public static void Log(string log) {
            if (Enabled) {
                text += log + "\r\n";
            }
        }
        public static void Write() {
            streamWriter.Write(text);
            text = "";
        }
        public static void Write(string str) {
            streamWriter.WriteLine(str);
        }
        public static void Clear() {
            text = "";
        }
        public static void Stop() {
            streamWriter.Write(text);
            streamWriter.Close();
        }

        #region Это затратный режим (хз как сделать переключение)
        //private static bool hard;
        //public static string path { get; } = @"C:\OOP_PaintLog.log";
        //static Debugger() {
        //    using (var file = File.Create(path));
        //}



        //public static void Log(string log) {
        //    if (hard) {
        //        using (var streamWriter = new StreamWriter(path, true)) {
        //            streamWriter.WriteLine(log);
        //        }
        //    }
        //}
        #endregion

    }
}
