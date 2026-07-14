Overview
===========
OPTestTool([OP](https://github.com/WallBreaker2/op) & Export)是一个OP的绑定测试工具.主要功能有:窗口句柄查看、绑定窗口测试、找图找色测试、字库制作测试、鼠标测试、键盘测试、文本输入测试、内存读写测试、[OPExport](https://github.com/flaot/OPExport)的GUI

OPTestTool是为OP在不同环境下的快捷测试工具，不局限于某个APP。它可以帮助开发者和用户快捷测试OP的常用功能，例如在工具中用不同的绑定模式去绑定窗口等。
## 功能特色
- 快捷查看指定窗口句柄、窗口类名、窗口标题
- OP专用字库制作
- 测试OP与某个APP的交互
- 生成开发者调用`op_c_api.dll`的胶水代码操作界面

## 社区
- [GitHub Issues](https://github.com/WallBreaker2/op/issues)
- [GitHub Discussions](https://github.com/WallBreaker2/op/discussions)
- QQ 群：`743710486`、`27872381`

## 编译

### 编译环境
* 操作系统: Visual Studio 2026
* 目标框架：.NET 10.0

## 功能模块
- 以代码方式呈现，实际在设计面板中设置
#### TextBox限制输入
```C#
// 整数
TextChanged += TextBoxInt_TextChanged;
KeyPress += TextBoxInt_KeyPress;

// 正整数
TextChanged += TextBoxUInt_TextChanged;
KeyPress += TextBoxUInt_KeyPress;

// 浮点数 0~1
TextChanged += TextBoxFloatBar_TextChanged;
KeyPress += TextBoxFloatBar_KeyPress;
```

#### TextBox支持拖入
```C#
// 拖入文件
AllowDrop = true;
DragDrop += Txt_Path_DragDrop;
DragEnter += Txt_Path_DragEnter;

// 拖入目录
AllowDrop = true;
DragDrop += Txt_Folder_DragDrop;
DragEnter += Txt_Folder_DragEnter;
```

#### Label无极变速
* 鼠标长按此lable并左右上下拖动，将改变目标的Text
* 需与目标在同层容器下
```C#
Cursor = Cursors.SizeWE;//可选,仅外观
Tag = "Txt_MoveToX";//目标TextBox控件名称

//目标为整数值
MouseDown += LabelInt_MouseDown;
MouseMove += LabelInt_MouseMove;
MouseUp += LabelInt_MouseUp;

//目标为正整数值
MouseDown += LabelUInt_MouseDown;
MouseMove += LabelUInt_MouseMove;
MouseUp += LabelUInt_MouseUp;
```

#### LinkLabel链接跳转
* 菜单栏(ToolStripMenuItem)也可
```C#
Tag = "https://github.com/WallBreaker2/op/releases";
LinkClicked += LinkLabel_LinkClicked;
```

#### DPI适配
```C#
//From
AutoScaleMode = Dpi;
```

#### 保存控件状态(是否勾选、内容等)
```C#
//打开'Properties/Settings.settings'
//添加字段'字段A'
private void MainForm_Load(object sender, EventArgs e)
{
    .......
    控件.Text = setting.字段A;
}
private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
{
    .......
    setting.字段A = 控件.Text;
}
```