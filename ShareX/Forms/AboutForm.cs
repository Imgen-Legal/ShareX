#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (c) 2007-2025 ShareX Team

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

using ShareX.HelpersLib;
using ShareX.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShareX
{
    public partial class AboutForm : Form
    {
        private EasterEggAboutAnimation easterEgg;
        private bool checkUpdate = false;

        public AboutForm()
        {
            InitializeComponent();
            pbLogo.Image = ShareXResources.Logo;
            ShareXResources.ApplyTheme(this, true);

            rtbInfo.AppendLine(@"This software is a modified version of ShareX, an open-source screen
capture and file-sharing tool.", FontStyle.Regular);

            rtbInfo.SelectionFont = new Font(rtbInfo.Font, FontStyle.Bold);
            rtbInfo.AppendText(@"
Original Software: ");
            rtbInfo.SelectionFont = new Font(rtbInfo.Font, FontStyle.Regular);
            rtbInfo.AppendText("ShareX");

            rtbInfo.SelectionFont = new Font(rtbInfo.Font, FontStyle.Bold);
            rtbInfo.AppendText(@"
Original License: ");
            rtbInfo.SelectionFont = new Font(rtbInfo.Font, FontStyle.Regular);
            rtbInfo.AppendText("GNU General Public License, Version 3");

            rtbInfo.SelectionFont = new Font(rtbInfo.Font, FontStyle.Bold);
            rtbInfo.AppendText(@"
Modifications By: ");
            rtbInfo.SelectionFont = new Font(rtbInfo.Font, FontStyle.Regular);
            rtbInfo.AppendText("Itransition, Inc.");

            rtbInfo.SelectionFont = new Font(rtbInfo.Font, FontStyle.Bold);
            rtbInfo.AppendText(@"
Date of Modification: ");
            rtbInfo.SelectionFont = new Font(rtbInfo.Font, FontStyle.Regular);
            rtbInfo.AppendText("29.09.2025");

            rtbInfo.AppendLine(@"

This modified program is free software; you can redistribute it and/or modify it under the terms of the
GNU General Public License as published by the Free Software Foundation, either version 3 of the License,
or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even
the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
General Public License for more details. In accordance with the terms of the GNU General Public License, \
we provide access to the source code of this modified version.
To obtain the source code of this modified version, please contact: (Your preferred method of contact,
e.g. an email address for source code requests)

A copy of the GNU General Public License was included with the original program. If you did not receive
a copy, you can view it here: http://www.gnu.org/licenses/.”
", FontStyle.Regular);

            easterEgg = new EasterEggAboutAnimation(cLogo, this);
        }

        private async void AboutForm_Shown(object sender, EventArgs e)
        {
            this.ForceActivate();

            if (checkUpdate)
            {
                UpdateChecker updateChecker = Program.UpdateManager.CreateUpdateChecker();
            }
        }

        private void pbLogo_MouseDown(object sender, MouseEventArgs e)
        {
            easterEgg.Start();
            pbLogo.Visible = false;
            TaskHelpers.PlayNotificationSoundAsync(NotificationSound.ActionCompleted);
        }

        private void rtb_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            URLHelpers.OpenURL(e.LinkText);
        }

        private void btnShareXLicense_Click(object sender, EventArgs e)
        {
            FileHelpers.OpenFile(FileHelpers.GetAbsolutePath("Licenses\\ShareX_license.txt"));
        }

        private void btnLicenses_Click(object sender, EventArgs e)
        {
            FileHelpers.OpenFolder(FileHelpers.GetAbsolutePath("Licenses"));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}