using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAOD_Hash {
    internal sealed partial class MainForm : Form {
        internal MyHashTable<object> hashTable;



        public MainForm() {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e) {
            hashTable = new MyHashTable<object>(20);
            hashTable.Changed += HashTable_Changed;
        }

        private void HashTable_Changed(object sender, EventArgs e) {
            // Тут используем поле вместо sender, но я не знаю, как это исправить.
            object[] array = hashTable.ToArray();
            ListBox listBox = MainFormLstbx;
            listBox.Items.Clear();
            listBox.Items.AddRange(array);
        }

        private void MainFormBttnAdd_Click(object sender, EventArgs e) {
            TextBox sourse = MainFormTxtbxAdd;
            string target = sourse.Text;
            bool checkResultOk = CheckInput(target);
            if (!checkResultOk) {
                MessageBox.Show("Невозможно добавить.");
                return;
            }

            hashTable.Add(target);
            sourse.Text = "";
        }
        private bool CheckInput(string target) => target != null && target.Length != 0;

        private void MainFormBttnFind_Click(object sender, EventArgs e) {
            TextBox sourse = MainFormTxtbxFind;
            string target = sourse.Text;
            bool inputCorrect = CheckInput(target);
            if (!inputCorrect) {
                MessageBox.Show("Невозможно произвести поиск.");
                return;
            }

            bool contains = hashTable.Contains(target);
            string message = contains ? "Содержится." : "Не содержится.";
            MessageBox.Show(message);
            sourse.Text = "";
        }

        private void MainFormBttnRemove_Click(object sender, EventArgs e) {
            TextBox sourse = MainFormTxtbxRemove;
            string target = sourse.Text;
            var inputCorrect = CheckInput(target);
            if (!inputCorrect) {
                MessageBox.Show("Невозможно удалить.");
                return;
            }

            hashTable.Remove(target);
            sourse.Text = "";
        }

    }
}
