Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Docking

Namespace SilverlightApplication1
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			CreateLayout()
		End Sub
		Private Sub CreateLayout()
			CreateLayoutRoot()
			CreateFloatPanels()
			CreateAutoHideGroups()
		End Sub
		Private Shared Function CreateLayoutPanel(ByVal caption As String) As LayoutPanel
			Dim panel As New LayoutPanel() With {.Caption = caption, .Content = New TextBox()}
			Return panel
		End Function
		Private Sub CreateLayoutRoot()
			Dim root As New LayoutGroup()
			Dim group As New LayoutGroup() With {.Orientation = Orientation.Vertical}
			Dim panel1 As LayoutPanel = CreateLayoutPanel("Panel3")
			Dim panel2 As LayoutPanel = CreateLayoutPanel("Panel3")
			Dim panel3 As LayoutPanel = CreateLayoutPanel("Panel3")
			group.AddRange(New BaseLayoutItem() { panel2, panel3 })
			root.AddRange(New BaseLayoutItem() { panel1, group })
			dockManager.LayoutRoot = root
		End Sub
		Private Sub CreateFloatPanels()
			Dim fGroup1 As New FloatGroup() With {.FloatLocation = New Point(100, 100), .FloatSize = New Size(200, 200)}
			Dim group As New LayoutGroup() With {.Orientation = Orientation.Vertical}
			Dim panel4 As LayoutPanel = CreateLayoutPanel("Panel4")
			Dim panel5 As LayoutPanel = CreateLayoutPanel("Panel5")
			group.AddRange(New BaseLayoutItem() { panel4, panel5 })
			fGroup1.Add(group)

			Dim fGroup2 As New FloatGroup() With {.FloatLocation = New Point(150, 150), .FloatSize = New Size(200, 200)}
			Dim panel6 As LayoutPanel = CreateLayoutPanel("Panel6")
			fGroup2.Add(panel6)

			dockManager.FloatGroups.AddRange(New FloatGroup() { fGroup1, fGroup2 })
		End Sub
		Private Sub CreateAutoHideGroups()
			Dim autoHideGroup1 As New AutoHideGroup()
			Dim panel7 As LayoutPanel = CreateLayoutPanel("Panel7")
			Dim panel8 As LayoutPanel = CreateLayoutPanel("Panel8")
			autoHideGroup1.AddRange(New BaseLayoutItem() { panel7, panel8 })

			Dim autoHideGroup2 As New AutoHideGroup() With {.DockType = DevExpress.Xpf.Layout.Core.Dock.Bottom}
			Dim panel9 As LayoutPanel = CreateLayoutPanel("Panel9")
			autoHideGroup2.Add(panel9)

			dockManager.AutoHideGroups.AddRange(New AutoHideGroup() { autoHideGroup1, autoHideGroup2 })
		End Sub
	End Class
End Namespace
