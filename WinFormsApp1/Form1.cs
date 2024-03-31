namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // считывем значения из настроек
            textBox1.Text = Properties.Settings.Default.a.ToString();
            textBox2.Text = Properties.Settings.Default.b.ToString();
            textBox3.Text = Properties.Settings.Default.c.ToString();
        }
        private void buttonResult_Click(object sender, EventArgs e)
        {
            double a, b, c; // вынес инициализацию переменных за блок try-catch
            try
            {
                // тут теперь просто присваиваем значения
                a = double.Parse(this.textBox1.Text);
                b = double.Parse(this.textBox2.Text);
                c = double.Parse(this.textBox3.Text);
            }
            catch (FormatException)
            {
                // сообщение об ошибке
                MessageBox.Show("Некорректный ввод", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // а затем прерываем обработчик
            }

            //  передаем введенные значения в параметры
            Properties.Settings.Default.a = a;
            Properties.Settings.Default.b = b;
            Properties.Settings.Default.c = c;
            // сохраняем переданные значения, чтобы они восстановились пре очередном запуске
            Properties.Settings.Default.Save();

            string outMessage = Logic.ExistTriangle(a, b, c);
            labelAnswer.Text = "Ответ: " + outMessage;
        }
        private void buttonTask_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Даны вещественные положительные числа a, b, c. " +
                "Если существует треугольник со сторонами a, b, c, то определить, " +
                "является ли он прямоугольным.", "Задание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }
        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonResult.Focus();
            }
        }
        private void buttonReslut_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }
        private void buttonResult_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                textBox1.Focus();
            }
        }
        private void buttonClean_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            labelAnswer.Text = "Ответ: ";
        }
    }
    public class Logic
    {
        public static string ExistTriangle(double a, double b, double c)
        {
            // НАЧАЛО Логики
            string outMessage = "";
            if (a <= 0 && b > 0 && c > 0)
                outMessage = "Первое значение не подходит";
            else if (a > 0 && b <= 0 && c > 0)
                outMessage = "Второе значение не подходит";
            else if (a > 0 && b > 0 && c <= 0)
                outMessage = "Третье значение не подходит";
            else if (a <= 0 && b <= 0 && c <= 0)
                outMessage = "Все значения не подходят";
            else if (a <= 0 && b <= 0 && c > 0)
                outMessage = "Первое и второе значения не подходят";
            else if (a <= 0 && b > 0 && c <= 0)
                outMessage = "Первое и третье значения не подходят";
            else if (a > 0 && b <= 0 && c <= 0)
                outMessage = "Второе и третье значения не подходят";
            else
            {
                if (a + b <= c || a + c <= b || b + c <= a)
                    outMessage = "Не существует треугольника с такими параметрами";
                else if (a * a + b * b == c * c || a * a + c * c == b * b || b * b + c * c == a * a)
                    outMessage = "Треугольник является прямоугольным";
                else
                    outMessage = "Треугольник не является прямоугольным";
            }
            // КОНЕЦ Логики
            return outMessage;
        }
    }
}