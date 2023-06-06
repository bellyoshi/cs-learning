using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using NDDD.Domain;

namespace NDDD.WinForm.Views;

public partial class BaseForm : Form
{
    private static ILog _logger = AppLog.GetLogger();

    public BaseForm()
    {
        InitializeComponent();
        DebugModeDisp();
        UserIdDisp();
    }

    private void UserIdDisp()
    {
        UserIdLabel.Text = CurrentUser.LoginId;
    }

    private void DebugModeDisp()
    {
        DebugStatusLabel.Visible = false;
#if DEBUG
        DebugStatusLabel.Visible = true;
#endif
    }
    private void BaseForm_Load(object sender, EventArgs e)
    {
        _logger.Info("open:" + this.Name);
    }
    private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        _logger.Info("close:" + this.Name);
    }
}
