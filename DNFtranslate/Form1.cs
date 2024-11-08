using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace DNFtranslate
{
    public partial class Form1 : Form
    {
        struct TextItem
        {
            public string ID;
            public int offset;
            public string text;
        };

        struct FileData
        {
            public int secondBlockAddress;
            public int textItemCount;
            public List<TextItem> items;
        };

        int convert4(ref byte[] file, int offset)
        {
            return (file[offset + 3] << 24) + (file[offset + 2] << 16) + (file[offset +1] << 8) + file[offset];
        }

        string convert4toID(ref byte[] file, int offset)
        {
            string ret = "";
            int id = convert4(ref file, offset);
            ret = id.ToString("x8");
            return ret;
        }

        void ReadLangFile(ref byte[] file, ref FileData data)
        {
            data.secondBlockAddress = convert4(ref file, 4);
            data.textItemCount = convert4(ref file, 0x7c);

            data.items = new List<TextItem>();
            int offset = 0x80;
            for (int i = 0; i < data.textItemCount; i++)
            {
                TextItem item = new TextItem();
                item.ID = convert4toID(ref file, offset);
                offset += 4;
                item.offset = convert4(ref file, offset);
                int textOffset = offset + item.offset;
                int textLength = 0;
                for (int j = textOffset; file[j] != 0; j++) { textLength++; }
                item.text = System.Text.Encoding.UTF8.GetString(file, textOffset, textLength);
                offset += 4;
                data.items.Add(item);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            progressBar1.Value = 0;
            label2.Visible = false;

            FileData fileInData = new FileData();
            FileData fileJapData = new FileData();

            // \jap\global.lxb
            string fileJapPath = "text\\jap\\global.lxb";
            string fileJapPathBak = "text\\jap\\global.lxb.bak";
            if (checkBoxCF.Checked && File.Exists(fileJapPathBak))
            {
                MessageBox.Show(fileJapPathBak + " - already exists." + Environment.NewLine + "Fix/Rename it so you do not overwrite your original backup and try again.");
                return;
            }
            if (!File.Exists(fileJapPath))
            {
                MessageBox.Show(fileJapPath + " - does not exist.");
                return;
            }
            byte[] fileJap = File.ReadAllBytes(fileJapPath);
            if (fileJap == null)
            {
                MessageBox.Show("Failed to read - " + fileJapPath);
                return;
            }
            // read jap file
            ReadLangFile(ref fileJap, ref fileJapData);
            progressBar1.Maximum = fileJapData.textItemCount;

            if (!radioButtonTT.Checked)
            {
                // text\xxx\global.lxb
                string inLang = radioButtonLangENG.Checked ? "eng" : "cht";
                string fileInPath = "text\\" + inLang + "\\global.lxb";
                if (!File.Exists(fileInPath))
                {
                    MessageBox.Show(fileInPath + " - does not exist.");
                    return;
                }
                byte[] fileIn = fileIn = File.ReadAllBytes(fileInPath);
                if (fileIn == null)
                {
                    MessageBox.Show("Failed to read - " + fileInPath);
                    return;
                }

                // read language file  (eng or cht)
                ReadLangFile(ref fileIn, ref fileInData);
            }

            // translated.txt
            string fileTranslatedPath = "translated.txt";
            List<TextItem> translatedItems = new List<TextItem>();
            if (File.Exists(fileTranslatedPath))
            {
                var lines = File.ReadAllLines(fileTranslatedPath);
                if (lines.Length <= 0)
                {
                    MessageBox.Show(fileTranslatedPath + " file does have any text.");
                    return;
                }
                if (lines[0][0] != '[' || lines[0][9] != ']')
                {
                    MessageBox.Show(fileTranslatedPath + " file does not start with [ID].");
                    return;
                }
                int i = 0;
                TextItem item;
                while (i < lines.Length)
                {
                    string line = lines[i];
                    if (line[0] == '[' && line[9] == ']')
                    {
                        item = new TextItem(); //[12345678] text
                        item.ID = line.Substring(1, 8);
                        if (line.Length < 11)
                            item.text = "";
                        else
                            item.text = line.Substring(11);
                        while (true)
                        {
                            i++;
                            if (i < lines.Length)
                                line = lines[i];
                            if ((i >= lines.Length) || ((line.Length >= 10) && (line[0] == '[' && line[9] == ']')))
                            {
                                // new ID found or end of text file.  Add current ID to list and move on
                                translatedItems.Add(item);
                                break;
                            }
                            // must be multiline text
                            item.text += '\n' + line;
                        }
                    }
                }
            }

            // parse japanese items to add new language
            byte[] newFile = new byte[300000];
            int offsetAddress = 0x80 + 4;
            int textAddress = 0x80 + (fileJapData.textItemCount * 8);
            Array.Copy(fileJap, newFile, textAddress); // copy initial data
            bool missingText = false;
            for (int i = 0; i < fileJapData.textItemCount; i++)
            {
                progressBar1.Value = i;
                bool found = false;
                for (int j = 0; j < fileInData.textItemCount; j++)
                {
                    if (fileJapData.items[i].ID == fileInData.items[j].ID)
                    {
                        // Translation ID found in language file

                        // check if there is text in Japanese but none in the language file
                        if (fileJapData.items[i].text.Length > 0 && fileInData.items[j].text.Length <= 0)
                            break;

                        // place offset to text in table after ID
                        int textOffset = textAddress - offsetAddress;
                        newFile[offsetAddress + 3] = (byte)((textOffset >> 24) & 0xff);
                        newFile[offsetAddress + 2] = (byte)((textOffset >> 16) & 0xff);
                        newFile[offsetAddress + 1] = (byte)((textOffset >> 8) & 0xff);
                        newFile[offsetAddress] = (byte)(textOffset & 0xff);
                        offsetAddress += 8;

                        // Place text in table after IDs
                        byte[] bytes = Encoding.UTF8.GetBytes(fileInData.items[j].text);
                        Array.Copy(bytes, 0, newFile, textAddress, bytes.Length);
                        Array.Copy(bytes, 0, newFile, textAddress, bytes.Length);
                        textAddress += bytes.Length;
                        newFile[textAddress] = 0;
                        textAddress++;

                        found = true;
                        break;
                    }
                }
                if (found) continue;
                for (int j = 0; j < translatedItems.Count; j++)
                {
                    if (fileJapData.items[i].ID == translatedItems[j].ID)
                    {
                        // check if there is text in Japanese but none in the translated file
                        if (fileJapData.items[i].text.Length > 0 && translatedItems[j].text.Length <= 0)
                            break;

                        // place offset to text in table after ID
                        int textOffset = textAddress - offsetAddress;
                        newFile[offsetAddress + 3] = (byte)((textOffset >> 24) & 0xff);
                        newFile[offsetAddress + 2] = (byte)((textOffset >> 16) & 0xff);
                        newFile[offsetAddress + 1] = (byte)((textOffset >> 8) & 0xff);
                        newFile[offsetAddress] = (byte)(textOffset & 0xff);
                        offsetAddress += 8;

                        // Place text in table after IDs
                        // Traslation found in translated.txt
                        byte[] bytes = Encoding.UTF8.GetBytes(translatedItems[j].text);
                        Array.Copy(bytes, 0, newFile, textAddress, bytes.Length);
                        textAddress += bytes.Length;
                        newFile[textAddress] = 0;
                        textAddress++;
                        found = true;
                        break;
                    }
                }
                if (found) continue;
                // no translation found.  Use text in Japanese file and display in the to be translated box
                textBox1.Text += "[" + fileJapData.items[i].ID + "] " + fileJapData.items[i].text + Environment.NewLine;
                missingText = true;
                {
                    // place offset to text in table after ID
                    int textOffset = textAddress - offsetAddress;
                    newFile[offsetAddress + 3] = (byte)((textOffset >> 24) & 0xff);
                    newFile[offsetAddress + 2] = (byte)((textOffset >> 16) & 0xff);
                    newFile[offsetAddress + 1] = (byte)((textOffset >> 8) & 0xff);
                    newFile[offsetAddress] = (byte)(textOffset & 0xff);
                    offsetAddress += 8;

                    // Place text in table after IDs
                    // No translation found.  Use original Japanese text
                    byte[] bytes = Encoding.UTF8.GetBytes(fileJapData.items[i].text);
                    Array.Copy(bytes, 0, newFile, textAddress, bytes.Length);
                    textAddress += bytes.Length;
                    newFile[textAddress] = 0;
                    textAddress++;
                }
            }
            if (!missingText)
            {
                textBox1.Text = "Complete, with no missing text.";
            }

            // set new start of second instance
            newFile[4 + 3] = (byte)((textAddress >> 24) & 0xff);
            newFile[4 + 2] = (byte)((textAddress >> 16) & 0xff);
            newFile[4 + 1] = (byte)((textAddress >> 8) & 0xff);
            newFile[4] = (byte)(textAddress & 0xff);

            // copy current second instance
            int secondInstanceLegth = fileJap.Length - fileJapData.secondBlockAddress;
            Array.Copy(fileJap, fileJapData.secondBlockAddress, newFile, textAddress, secondInstanceLegth);
            textAddress += secondInstanceLegth;
            Array.Resize(ref newFile, textAddress);
            

            if (checkBoxCF.Checked) File.WriteAllBytes(fileJapPathBak, fileJap);    // backup jap\ file
            if (checkBoxCF.Checked) File.WriteAllBytes(fileJapPath, newFile);
            textBox1.Refresh();
            label2.Visible = true;
        }
    }
}
