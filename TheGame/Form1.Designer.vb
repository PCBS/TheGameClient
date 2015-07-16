<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.CPUBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GPUBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HDDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MBBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PSUBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RAMBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.HardwarepcbsDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Hardware_pcbsDataSet = New TheGame.hardware_pcbsDataSet()
        Me.VeciTableAdapter1 = New TheGame.hardware_pcbsDataSetTableAdapters.veciTableAdapter()
        Me.ReceptyTableAdapter1 = New TheGame.hardware_pcbsDataSetTableAdapters.receptyTableAdapter()
        Me.CPUTableAdapter = New TheGame.hardware_pcbsDataSetTableAdapters.CPUTableAdapter()
        Me.GPUTableAdapter = New TheGame.hardware_pcbsDataSetTableAdapters.GPUTableAdapter()
        Me.HDDTableAdapter = New TheGame.hardware_pcbsDataSetTableAdapters.HDDTableAdapter()
        Me.MBTableAdapter = New TheGame.hardware_pcbsDataSetTableAdapters.MBTableAdapter()
        Me.PSUTableAdapter = New TheGame.hardware_pcbsDataSetTableAdapters.PSUTableAdapter()
        Me.RAMTableAdapter = New TheGame.hardware_pcbsDataSetTableAdapters.RAMTableAdapter()
        Me.MoznesestavyBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.CPUBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GPUBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HDDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MBBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PSUBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RAMBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HardwarepcbsDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Hardware_pcbsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MoznesestavyBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(202, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "0"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CPUBindingSource
        '
        Me.CPUBindingSource.DataMember = "CPU"
        Me.CPUBindingSource.DataSource = Me.HardwarepcbsDataSetBindingSource
        '
        'GPUBindingSource
        '
        Me.GPUBindingSource.DataMember = "GPU"
        Me.GPUBindingSource.DataSource = Me.HardwarepcbsDataSetBindingSource
        '
        'HDDBindingSource
        '
        Me.HDDBindingSource.DataMember = "HDD"
        Me.HDDBindingSource.DataSource = Me.HardwarepcbsDataSetBindingSource
        '
        'MBBindingSource
        '
        Me.MBBindingSource.DataMember = "MB"
        Me.MBBindingSource.DataSource = Me.HardwarepcbsDataSetBindingSource
        '
        'PSUBindingSource
        '
        Me.PSUBindingSource.DataMember = "PSU"
        Me.PSUBindingSource.DataSource = Me.HardwarepcbsDataSetBindingSource
        '
        'RAMBindingSource
        '
        Me.RAMBindingSource.DataMember = "RAM"
        Me.RAMBindingSource.DataSource = Me.HardwarepcbsDataSetBindingSource
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
        Me.TextBox1.Size = New System.Drawing.Size(439, 408)
        Me.TextBox1.TabIndex = 1
        '
        'HardwarepcbsDataSetBindingSource
        '
        Me.HardwarepcbsDataSetBindingSource.DataSource = Me.Hardware_pcbsDataSet
        Me.HardwarepcbsDataSetBindingSource.Position = 0
        '
        'Hardware_pcbsDataSet
        '
        Me.Hardware_pcbsDataSet.DataSetName = "hardware_pcbsDataSet"
        Me.Hardware_pcbsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'VeciTableAdapter1
        '
        Me.VeciTableAdapter1.ClearBeforeFill = True
        '
        'ReceptyTableAdapter1
        '
        Me.ReceptyTableAdapter1.ClearBeforeFill = True
        '
        'CPUTableAdapter
        '
        Me.CPUTableAdapter.ClearBeforeFill = True
        '
        'GPUTableAdapter
        '
        Me.GPUTableAdapter.ClearBeforeFill = True
        '
        'HDDTableAdapter
        '
        Me.HDDTableAdapter.ClearBeforeFill = True
        '
        'MBTableAdapter
        '
        Me.MBTableAdapter.ClearBeforeFill = True
        '
        'PSUTableAdapter
        '
        Me.PSUTableAdapter.ClearBeforeFill = True
        '
        'RAMTableAdapter
        '
        Me.RAMTableAdapter.ClearBeforeFill = True
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
        CType(Me.CPUBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GPUBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HDDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MBBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PSUBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RAMBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HardwarepcbsDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Hardware_pcbsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MoznesestavyBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HardwarepcbsDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Hardware_pcbsDataSet As TheGame.hardware_pcbsDataSet
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents VeciTableAdapter1 As TheGame.hardware_pcbsDataSetTableAdapters.veciTableAdapter
    Friend WithEvents ReceptyTableAdapter1 As TheGame.hardware_pcbsDataSetTableAdapters.receptyTableAdapter
    Friend WithEvents CPUBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CPUTableAdapter As TheGame.hardware_pcbsDataSetTableAdapters.CPUTableAdapter
    Friend WithEvents GPUBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GPUTableAdapter As TheGame.hardware_pcbsDataSetTableAdapters.GPUTableAdapter
    Friend WithEvents HDDBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HDDTableAdapter As TheGame.hardware_pcbsDataSetTableAdapters.HDDTableAdapter
    Friend WithEvents MBBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MBTableAdapter As TheGame.hardware_pcbsDataSetTableAdapters.MBTableAdapter
    Friend WithEvents PSUBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PSUTableAdapter As TheGame.hardware_pcbsDataSetTableAdapters.PSUTableAdapter
    Friend WithEvents RAMBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RAMTableAdapter As TheGame.hardware_pcbsDataSetTableAdapters.RAMTableAdapter
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents MoznesestavyBindingSource As System.Windows.Forms.BindingSource

End Class
