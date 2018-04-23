using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DevExpress.Xpf.Docking;

namespace SilverlightApplication1 {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            CreateLayout();
        }
        private void CreateLayout() {
            CreateLayoutRoot();
            CreateFloatPanels();
            CreateAutoHideGroups();
        }
        private static LayoutPanel CreateLayoutPanel(string caption) {
            LayoutPanel panel = new LayoutPanel() { Caption = caption, Content = new TextBox() };
            return panel;
        }
        private void CreateLayoutRoot() {
            LayoutGroup root = new LayoutGroup();
            LayoutGroup group = new LayoutGroup() { Orientation = Orientation.Vertical };
            LayoutPanel panel1 = CreateLayoutPanel("Panel3");
            LayoutPanel panel2 = CreateLayoutPanel("Panel3");
            LayoutPanel panel3 = CreateLayoutPanel("Panel3");
            group.AddRange(new BaseLayoutItem[] { panel2, panel3 });
            root.AddRange(new BaseLayoutItem[] { panel1, group });
            dockManager.LayoutRoot = root;
        }
        private void CreateFloatPanels() {
            FloatGroup fGroup1 = new FloatGroup() { FloatLocation = new Point(100, 100), FloatSize = new Size(200, 200) };
            LayoutGroup group = new LayoutGroup() { Orientation = Orientation.Vertical };
            LayoutPanel panel4 = CreateLayoutPanel("Panel4");
            LayoutPanel panel5 = CreateLayoutPanel("Panel5");
            group.AddRange(new BaseLayoutItem[] { panel4, panel5 });
            fGroup1.Add(group);
            
            FloatGroup fGroup2 = new FloatGroup() { FloatLocation = new Point(150, 150), FloatSize = new Size(200, 200) };
            LayoutPanel panel6 = CreateLayoutPanel("Panel6");
            fGroup2.Add(panel6);

            dockManager.FloatGroups.AddRange(new FloatGroup[] { fGroup1, fGroup2 });
        }
        private void CreateAutoHideGroups() {
            AutoHideGroup autoHideGroup1 = new AutoHideGroup();
            LayoutPanel panel7 = CreateLayoutPanel("Panel7");
            LayoutPanel panel8 = CreateLayoutPanel("Panel8");
            autoHideGroup1.AddRange(new BaseLayoutItem[] { panel7, panel8 });

            AutoHideGroup autoHideGroup2 = new AutoHideGroup() { DockType = DevExpress.Xpf.Layout.Core.Dock.Bottom};
            LayoutPanel panel9 = CreateLayoutPanel("Panel9");
            autoHideGroup2.Add(panel9);

            dockManager.AutoHideGroups.AddRange(new AutoHideGroup[] { autoHideGroup1, autoHideGroup2 });
        }
    }
}
