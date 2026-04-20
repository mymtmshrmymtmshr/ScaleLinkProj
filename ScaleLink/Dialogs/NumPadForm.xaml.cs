using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace ScaleLink.Dialogs;

public partial class NumPadForm : Window
{
    public string InputValue => txtDisplay.Text;

    public NumPadForm(string initialValue = "")
    {
        InitializeComponent();
        txtDisplay.Text = NormalizeDisplayText(initialValue);
    }

    private void NumKey_Click(object sender, RoutedEventArgs e)
    {
        if (sender is not Button btn || btn.Content is not string key)
            return;

        switch (key)
        {
            case "C":
                txtDisplay.Text = string.Empty;
                break;
            case "?":
                BackspaceDisplay();
                break;
            default:
                if (key.Length == 1 && char.IsDigit(key[0]))
                    AppendDigit(key[0]);
                break;
        }
    }

    private void BtnOk_Click(object sender, RoutedEventArgs e)
    {
        if (decimal.TryParse(txtDisplay.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out _))
        {
            DialogResult = true;
            Close();
        }
        else
        {
            MessageBox.Show("—LŒø‚È”’l‚ð“ü—Í‚µ‚Ä‚­‚¾‚³‚¢B");
        }
    }

    private void AppendDigit(char digit)
    {
        if (!char.IsDigit(digit))
            return;

        var currentDigits = GetDigitsOnly(txtDisplay.Text);

        if (currentDigits == "0")
        {
            txtDisplay.Text = digit == '0' ? "0" : digit.ToString();
            return;
        }

        currentDigits += digit;
        txtDisplay.Text = NormalizeDisplayText(currentDigits);
    }

    private void BackspaceDisplay()
    {
        var digits = GetDigitsOnly(txtDisplay.Text);
        if (digits.Length == 0)
        {
            txtDisplay.Text = string.Empty;
            return;
        }

        digits = digits[..^1];
        txtDisplay.Text = NormalizeDisplayText(digits);
    }

    private static string NormalizeDisplayText(string text)
    {
        var digits = GetDigitsOnly(text);
        if (string.IsNullOrEmpty(digits))
            return string.Empty;

        digits = digits.TrimStart('0');
        if (digits.Length == 0)
            return "0";

        if (decimal.TryParse(digits, NumberStyles.Number, CultureInfo.InvariantCulture, out var value))
            return value.ToString("#,##0", CultureInfo.CurrentCulture);

        return digits;
    }

    private static string GetDigitsOnly(string text) =>
        new(text.Where(char.IsDigit).ToArray());
}
