using System.Windows.Forms;
using System.Xml;

namespace decoder
{
    public partial class Form1 : Form
    {
        private List<string> alphabet = new List<string>() { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "ң", "о", "ө", "п", "р", "с", "т", "у", "ү", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
        private List<TextBox> inputs = new List<TextBox>();
        private List<double> posibilities = new List<double>() { 0.123996723996724, 0.0276003276003276, 0.0022113022113022115, 0.030466830466830467, 0.04365274365274365, 0.044062244062244064, 8.19000819000819e-05, 0.015315315315315315, 0.015642915642915645, 0.04455364455364455, 0.014987714987714987, 0.06068796068796069, 0.05167895167895168, 0.03104013104013104, 0.08108108108108109, 0.0031122031122031123, 0.045372645372645376, 0.02293202293202293, 0.013595413595413596, 0.06330876330876331, 0.025143325143325145, 0.05176085176085176, 0.04357084357084357, 0.026371826371826373, 0.002702702702702703, 0.0021294021294021295, 0.0009828009828009828, 0.014823914823914824, 0.013104013104013105, 0.0, 0.0, 0.060032760032760035, 0.0012285012285012285, 0.014578214578214578, 0.0015561015561015561, 0.006633906633906634 };
        int textSize = 0;
        string decryptedText;
        bool flag = false;
        
        public Form1()
        {
            InitializeComponent();
            setKeys();
        }

        private void setKeys()
        {
            FlowLayoutPanel key;
            Label text;
            TextBox input;
            int autoWidth = keys.Size.Width / alphabet.Count;
            keys.Padding = new Padding(((keys.Size.Width - autoWidth * alphabet.Count) / 2), 0, ((keys.Size.Width - autoWidth * alphabet.Count) / 2), 0);
            for (int i=0; i< alphabet.Count; i++)
            {
                key = new FlowLayoutPanel();
                text = new Label();
                input = new TextBox();
                key.Size = new Size(autoWidth, 100);
                key.Margin = new Padding(0);
                text.Margin = new Padding(0);
                input.Margin = new Padding(0);
                input.TextAlign = HorizontalAlignment.Center;
                input.MaxLength = 1;
                text.TextAlign = ContentAlignment.MiddleCenter;
                text.Text = alphabet[i];
                text.Size = new Size(key.Size.Width, 20);
                input.Size = new Size(key.Size.Width, 20);
                key.FlowDirection = FlowDirection.TopDown;
                key.Controls.Add(text);
                key.Controls.Add(input);
                inputs.Add(input);
                keys.Controls.Add(key);
            }
            keys.ResumeLayout();
        }

        private string getLetter(char a)
        {
            if (alphabet.Contains(a.ToString().ToLower()))
            {
                if (Char.IsUpper(a))
                {
                    return inputs[alphabet.IndexOf(Char.ToLower(a).ToString())].Text.ToUpper();
                }
                return inputs[alphabet.IndexOf(a.ToString())].Text;
            }
            return a.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
            ress.Text = "";
            string input = inputText.Text;
            List<string> lines = input.Split("\n").ToList();
            string resItem;
            for (int i = 0; i < lines.Count; i++)
            {
                resItem = "";
                for (int j = 0; j < lines[i].Length; j++)
                {
                    resItem += getLetter(lines[i][j]);
                }
                ress.Text += resItem + Environment.NewLine;
            }
            textSize = ress.Text.Length;
            decryptedText = decrypted();
        }

        private string decrypted()
        {
            string input = inputText.Text;
            List<string> lines = input.Split("\n").ToList();
            string resItem;
            string final = "";
            for (int i = 0; i < lines.Count; i++)
            {
                resItem = "";
                for (int j = 0; j < lines[i].Length; j++)
                {
                    resItem += getLetter(lines[i][j]);
                }
                final += resItem + "\n";
            }
            return final;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag = false;
            textSize = 0;
            ress.Text = "";
            List<int> notEnabled = new List<int>();
            List<int> notEnabledCur = new List<int>();
            List<double> curPosibilities = getListWithPosibilities();
            int maxIndexCur;
            int maxIndex;
            ress.Text += "Сorrelation Counting" + Environment.NewLine;
            ress.Text += "-------------------------" + Environment.NewLine;
            for (int i = 0; i < curPosibilities.Count; i++)
            {
                maxIndexCur = -1;
                maxIndex = -1;
                for (int j = 0; j < curPosibilities.Count; j++)
                {
                    if (!notEnabledCur.Contains(j))
                    {
                        if (maxIndexCur == -1)
                        {
                            maxIndexCur = j;
                        }
                        if (curPosibilities[j] > curPosibilities[maxIndexCur])
                        {
                            maxIndexCur = j;
                        }
                    }
                }
                notEnabledCur.Add(maxIndexCur);

                for (int j = 0; j < posibilities.Count; j++)
                {
                    if (!notEnabled.Contains(j))
                    {
                        if (maxIndex == -1)
                        {
                            maxIndex = j;
                        }
                        if (posibilities[j] > posibilities[maxIndex])
                        {
                            maxIndex = j;
                        }
                    }
                }
                notEnabled.Add(maxIndex);

                inputs[maxIndexCur].Text = alphabet[maxIndex];
            }

            int step = 0;
            int corrCount = -1;
            int temp;
            for (int i = 0; i < alphabet.Count; i++)
            {
                temp = 0;
                for (int j = 0; j < alphabet.Count; j++)
                {
                    if (i + j >= alphabet.Count)
                    {
                        if (inputs[j].Text.Equals(alphabet[i + j - alphabet.Count]))
                        {
                            temp += 1;
                        }
                    }
                    else
                    {
                        if (inputs[j].Text.Equals(alphabet[i + j]))
                        {
                            temp += 1;
                        }
                    }
                }
                if (temp > corrCount)
                {
                    corrCount = temp;
                    step = i;
                }
                ress.Text += "Key - " + alphabet[i] + " | Amount - " + temp + Environment.NewLine;
            }
            if (corrCount > 0)
            {
                keyTextBox.Text = alphabet[step];
            }
        }

        private List<double> getListWithPosibilities()
        {
            List<int> counts = new List<int>();
            List<double> res = new List<double>();
            string input = inputText.Text;
            for (int i = 0; i < alphabet.Count; i++)
            {
                counts.Add(0);
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (alphabet.Contains(input[i].ToString().ToLower()))
                {
                    counts[alphabet.IndexOf(input[i].ToString().ToLower())] += 1;
                }
            }
            int sum = counts.Sum();
            for (int i = 0; i < counts.Count; i++)
            {
                res.Add((double)counts[i] / sum);
            }
            return res;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private string getByKey(char a, char b)
        {
            int step = alphabet.IndexOf(b.ToString());
            int letter = step + alphabet.IndexOf(Char.ToLower(a).ToString());
            if (letter >= alphabet.Count)
            {
                letter -= alphabet.Count;
            }
            if (Char.IsUpper(a))
            {
                return alphabet[letter].ToUpper();
            }
            return alphabet[letter];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flag = true;
            string key = keyTextBox.Text.ToLower();
            int keyId = 0;
            ress.Text = "";
            string input = inputText.Text;
            List<string> lines = input.Split("\n").ToList();
            string resItem;
            for (int i = 0; i < lines.Count; i++)
            {
                resItem = "";
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (alphabet.Contains(lines[i][j].ToString().ToLower()))
                    {
                        resItem += getByKey(lines[i][j], key[keyId]);
                        keyId++;
                        if (keyId == key.Length)
                        {
                            keyId = 0;
                        }
                    } 
                    else
                    {
                        resItem += lines[i][j];
                    }
                }
                ress.Text += resItem + Environment.NewLine;
            }
            if (key.Length == 1)
            {
                for (int i = 0; i < alphabet.Count; i++)
                {
                    inputs[i].Text = getByKey(alphabet[i][0], key[0]);
                }
            }
            textSize = ress.Text.Length;
            decryptedText = decrypted();
        }

        private void result_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void ress_TextChanged(object sender, EventArgs e)
        {
            if (!flag)
            {
                if (textSize != 0)
                {
                    if (textSize == ress.Text.Length)
                    {
                        changeAlphabet();
                    }
                }
            }
        }

        private void changeAlphabet()
        {
            int n;
            string actualLetters = "";
            string lettersToChange = "";
            for (int i = decryptedText.Length - 1; i >= 0; i--)
            {
                if (!decryptedText[i].Equals(ress.Text[i]))
                {
                    actualLetters += decryptedText[i].ToString().ToLower();
                    lettersToChange += ress.Text[i].ToString().ToLower();
                }
            }
            for (int i = 0; i < actualLetters.Length; i++)
            {
                n = 0;
                for (int j = 0; j < inputs.Count; j++)
                {
                    if (inputs[j].Text.Equals(actualLetters[i].ToString()))
                    {
                        inputs[j].Text = lettersToChange[i].ToString();
                        n++;
                    }
                    else if (inputs[j].Text.Equals(lettersToChange[i].ToString()))
                    {
                        inputs[j].Text = actualLetters[i].ToString();
                        n++;
                    }
                    if (n == 2)
                    {
                        break;
                    }
                }
            }
        }

        private void ress_KeyDown(object sender, KeyEventArgs e)
        {
            flag = false;
        }
    }
}