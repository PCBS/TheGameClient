﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TrhDataSet = New TheGame.trhDataSet()
        Me.VeciBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VeciTableAdapter = New TheGame.trhDataSetTableAdapters.veciTableAdapter()
        Me.TableAdapterManager = New TheGame.trhDataSetTableAdapters.TableAdapterManager()
        CType(Me.TrhDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VeciBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(431, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "0"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(12, 41)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(431, 400)
        Me.TextBox1.TabIndex = 1
        '
        'TrhDataSet
        '
        Me.TrhDataSet.DataSetName = "trhDataSet"
        Me.TrhDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'VeciBindingSource
        '
        Me.VeciBindingSource.DataMember = "veci"
        Me.VeciBindingSource.DataSource = Me.TrhDataSet
        '
        'VeciTableAdapter
        '
        Me.VeciTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.hraciTableAdapter = Nothing
        Me.TableAdapterManager.kuponyTableAdapter = Nothing
        Me.TableAdapterManager.logTableAdapter = Nothing
        Me.TableAdapterManager.mozne_sestavyTableAdapter = Nothing
        Me.TableAdapterManager.obchodTableAdapter = Nothing
        Me.TableAdapterManager.receptyTableAdapter = Nothing
        Me.TableAdapterManager.sestavyTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = TheGame.trhDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.veciTableAdapter = Me.VeciTableAdapter
        Me.TableAdapterManager.vyrobaTableAdapter = Nothing
        Me.TableAdapterManager.vyzkumyTableAdapter = Nothing
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 461)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.DoubleBuffered = True
        Me.Name = "Form1"
        Me.Text = "Generator"
        CType(Me.TrhDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VeciBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TrhDataSet As TheGame.trhDataSet
    Friend WithEvents VeciBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VeciTableAdapter As TheGame.trhDataSetTableAdapters.veciTableAdapter
    Friend WithEvents TableAdapterManager As TheGame.trhDataSetTableAdapters.TableAdapterManager

End Class
