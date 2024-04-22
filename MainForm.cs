namespace a2_multithread;

public partial class MainForm : Form
{
    private BankManager bankManager;

    public MainForm()
    {
        InitializeComponent();
        bankManager = new BankManager(lstOutput, lstItems);
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        bankManager.StartClients();
    }

    public void UpdateEventLog(string item, int i)
    {
        if (lstOutput.InvokeRequired)
        {
            lstOutput.Invoke(new Action<string, int>(UpdateEventLog), item, i);
        }
        else
        {
            if (i == 0)
                lstOutput.Items.Clear();

            lstOutput.Items.Add(item);
        }
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
        bankManager.StopClients();
    }

    private void UpdateProductListBox(string item, int i)
    {
        if (lstItems.InvokeRequired)
        {
            lstItems.Invoke(new Action<string, int>(UpdateProductListBox), item, i);
        }
        else
        {
            if (i == 0)
                lstItems.Items.Clear();

            lstItems.Items.Add(item);
        }
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        bankManager.StopClients();
        Application.Exit();
    }
}