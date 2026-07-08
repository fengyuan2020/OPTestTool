/**
This is an automatically generated class by OpExport. Please do not modify it.
License：https://github.com/WallBreaker2/op/blob/master/LICENSE 
**/


using System;
using System.Runtime.InteropServices;
public partial class OpSoft: IDisposable, IComparable<OpSoft>
{
#if X86
    const string DLL_NAME = "./Dll/op_c_api_x86.dll";
#else
    const string DLL_NAME = "./Dll/op_c_api_x64.dll";
#endif

    private IntPtr handle; // 非托管资源

    #region Dispose
    private bool disposed = false;   // 是否已经释放资源的标志
    public OpSoft()
    {
        handle = OpCreate();
    }
    ~OpSoft() => Dispose(false);
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
            }
            OpDestroy(handle);
            handle = IntPtr.Zero;
        }
        disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion
    #region Overroid
    public override bool Equals(object obj) => obj is OpSoft soft && GetID() == soft.GetID();
    public override int GetHashCode() => GetID().GetHashCode();
    public override string ToString() => string.Format("id:{0}", GetID());
    public int CompareTo(OpSoft other) => GetID().CompareTo(other.GetID());
    #endregion
    
    /// <summary>
    /// 向指定字库添加一条字库信息。<code>dict_info</code> 可以是 <code>FetchWord/GetDict</code> 返回的 OP 文本单条格式，也可以是大漠文本点阵单条格式。
    /// </summary>
    /// <param name="idx">字库序号</param>
    /// <param name="dict_info">字库条目，可来自 FetchWord/GetDict，也可使用大漠文本格式</param>
    /// <returns>0：失败 1：成功</returns>
    public int AddDict(int idx, string dict_info) 
        => OpAddDict(handle, idx, dict_info);

    /// <summary>
    /// 根据 A 星算法，获取地图上从源坐标到目的坐标的一条最短路径
    /// </summary>
    /// <param name="mapWidth">地图宽度</param>
    /// <param name="mapHeight">地图高度</param>
    /// <param name="disable_points">不可通行的坐标，以 "|" 分割，例如 "10,15|20,30"</param>
    /// <param name="beginX">源坐标 X</param>
    /// <param name="beginY">源坐标 Y</param>
    /// <param name="endX">目的坐标 X</param>
    /// <param name="endY">目的坐标 Y</param>
    /// <returns>找到的路径结果</returns>
    public string AStarFindPath(int mapWidth, int mapHeight, string disable_points, int beginX, int beginY, int endX, int endY) 
        => OpAStarFindPath(handle, mapWidth, mapHeight, disable_points, beginX, beginY, endX, endY);

    /// <summary>
    /// 绑定指定的窗口,并指定这个窗口的屏幕颜色获取方式,鼠标仿真模式,键盘仿真模式,以及模式设定.
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <param name="display">屏幕显示模式,取值定义如下 normal:正常模式,平常我们用的前台截屏模式 normal.auto:自动选择普通窗口截图方式，优先使用更合适的后台截图后端 normal.dxgi:dxgi 截图模式，这个速度更快，更省 CPU normal.wgc:wgc 截图模式，支持 Windows 10 1903 及以上版本 gdi:gdi 模式,用于窗口采用 GDI 方式刷新时,此模式占用 CPU 较大 gdi2:gdi2 模式,此模式兼容性较强,但是速度比 gdi 模式要慢许多 dx:dx 模式,等同于 dx.d3d9 dx2:dx2 模式,用于窗口采用 dx 模式刷新 dx.d3d9:d3d9 模式,使用 d3d9 渲染 dx.d3d10:d3d10 模式,使用 d3d10 渲染 dx.d3d11:d3d11 模式,使用 d3d11 渲染 dx.d3d12:d3d12 模式,使用 d3d12 渲染 opengl:opengl 模式，使用 opengl 渲染的窗口 opengl.std:测试中 opengl.nox:opengl 模式，针对最新夜神模拟器的渲染方式，测试中... opengl.es:测试中... opengl.fi:测试中...</param>
    /// <param name="mouse">鼠标仿真模式,取值定义如下 normal:正常模式,平常我们用的前台鼠标模式 windows:Windows 模式,采取模拟 windows 消息方式 dx:dx 模式</param>
    /// <param name="keypad">键盘仿真模式,取值定义如下 normal:正常模式,平常我们用的前台键盘模式 normal.hd:硬件按键模式 windows:Windows 模式,采取模拟 windows 消息方式 dx:dx 模式</param>
    /// <param name="mode">模式,取值 0、1</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int BindWindow(IntPtr hwnd, string display, string mouse, string keypad, int mode) 
        => OpBindWindow(handle, hwnd, display, mouse, keypad, mode);

    /// <summary>
    /// 扩展绑定接口，用于显示窗口和输入窗口不是同一个句柄的场景，取值与上述相同。
    /// </summary>
    /// <param name="display_hwnd">显示窗口句柄，用于截图、取色、找图等显示相关操作</param>
    /// <param name="input_hwnd">输入窗口句柄，用于鼠标和键盘模拟</param>
    /// <param name="display">屏幕显示模式</param>
    /// <param name="mouse">鼠标仿真模式</param>
    /// <param name="keypad">键盘仿真模式</param>
    /// <param name="mode">模式，取值 0、1</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int BindWindowEx(IntPtr display_hwnd, IntPtr input_hwnd, string display, string mouse, string keypad, int mode) 
        => OpBindWindowEx(handle, display_hwnd, input_hwnd, display, mouse, keypad, mode);

    /// <summary>
    /// 抓取指定区域(x1, y1, x2, y2)的图像, 保存为文件
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="file_name">文件名,保存在 SetPath 中设置的目录，也可以自定义路径</param>
    /// <returns>0：失败 1：成功</returns>
    public int Capture(int x1, int y1, int x2, int y2, string file_name) 
        => OpCapture(handle, x1, y1, x2, y2, file_name);

    /// <summary>
    /// 取上次操作的图色区域，并保存为 24 位位图。
    /// </summary>
    /// <param name="file_name">保存文件名，默认保存到 <code>SetPath</code> 设置的目录，也可以指定全路径</param>
    /// <returns>0：表示操作失败 1：表示操作成功</returns>
    public int CapturePre(string file_name) 
        => OpCapturePre(handle, file_name);

    /// <summary>
    /// 返回每条记录的检查摘要
    /// </summary>
    /// <param name="dict_info">字库文本，支持多行</param>
    /// <param name="ret"></param>
    /// <returns>返回合法条目数量。</returns>
    public string CheckWordDict(string dict_info, out int ret) 
        => OpCheckWordDict(handle, dict_info, out ret);

    /// <summary>
    /// 清空指定字库
    /// </summary>
    /// <param name="idx">字库序号</param>
    /// <returns>0：失败 1：成功</returns>
    public int ClearDict(int idx) 
        => OpClearDict(handle, idx);

    /// <summary>
    /// 把窗口坐标转换为屏幕坐标
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <param name="x">变参指针: 接收窗口 X 坐标</param>
    /// <param name="y">变参指针: 接收窗口 Y 坐标</param>
    /// <returns>0：表示操作失败。 1：表示操作成功。</returns>
    public int ClientToScreen(IntPtr hwnd, ref int x, ref int y) 
        => OpClientToScreen(handle, hwnd, ref x, ref y);

    /// <summary>
    /// 比较指定坐标点(x,y)的颜色
    /// </summary>
    /// <param name="x">X 坐标</param>
    /// <param name="y">Y 坐标</param>
    /// <param name="color">颜色字符串，例如"ffffff-202020|000000-000000"，每种颜色用"|"分割，最多 10 种</param>
    /// <param name="sim">相似度，取值范围 0.1-1.0</param>
    /// <returns>0：颜色不匹配 1：颜色匹配</returns>
    public int CmpColor(int x, int y, string color, double sim) 
        => OpCmpColor(handle, x, y, color, sim);

    /// <summary>
    /// 对图片进行模糊处理
    /// </summary>
    /// <param name="src_file">源图片路径</param>
    /// <param name="dst_file">输出图片路径</param>
    /// <param name="mode">模式：<code>gaussian</code>、<code>median</code>、<code>bilateral</code>、<code>box</code> </param>
    /// <param name="kernel_size">核大小</param>
    /// <returns>0：失败 1：成功</returns>
    public int CvBlur(string src_file, string dst_file, string mode, int kernel_size) 
        => OpCvBlur(handle, src_file, dst_file, mode, kernel_size);

    /// <summary>
    /// 使用 CLAHE 对图片进行局部对比度增强
    /// </summary>
    /// <param name="src_file">源图片路径</param>
    /// <param name="dst_file">输出图片路径</param>
    /// <param name="clip_limit">对比度限制</param>
    /// <param name="tile_grid_size">网格大小</param>
    /// <returns>0：失败 1：成功</returns>
    public int CvCLAHE(string src_file, string dst_file, double clip_limit, int tile_grid_size) 
        => OpCvCLAHE(handle, src_file, dst_file, clip_limit, tile_grid_size);

    /// <summary>
    /// 变参指针: 返回连通区域结果 JSON
    /// </summary>
    /// <param name="src_file">源图片路径</param>
    /// <param name="min_area">最小面积，小于该面积的区域会被忽略</param>
    /// <param name="ret"></param>
    /// <returns>0：失败 1：成功</returns>
    public string CvConnectedComponents(string src_file, double min_area) 
        => OpCvConnectedComponents(handle, src_file, min_area);

    /// <summary>
    /// 裁剪图片
    /// </summary>
    /// <param name="src_file">源图片路径</param>
    /// <param name="x">裁剪区域 X</param>
    /// <param name="y">裁剪区域 Y</param>
    /// <param name="width">裁剪宽度</param>
    /// <param name="height">裁剪高度</param>
    /// <param name="dst_file">输出图片路径</param>
    /// <returns>0：失败 1：成功</returns>
    public int CvCrop(string src_file, int x, int y, int width, int height, string dst_file) 
        => OpCvCrop(handle, src_file, x, y, width, height, dst_file);

    /// <summary>
    /// 裁剪图片中的有效内容区域
    /// </summary>
    /// <param name="src_file">源图片路径</param>
    /// <param name="dst_file">输出图片路径</param>
    /// <returns>0：失败 1：成功</returns>
    public int CvCropValid(string src_file, string dst_file) 
        => OpCvCropValid(handle, src_file, dst_file);

    /// <summary>
    /// 对图片进行去噪处理
    /// </summary>
    /// <param name="src_file">源图片路径</param>
    /// <param name="dst_file">输出图片路径</param>
    /// <returns>0：失败 1：成功</returns>
    public int CvDenoise(string src_file, string dst_file) 
        => OpCvDenoise(handle, src_file, dst_file);

    /// <summary>
    /// 变参指针: 返回匹配结果 JSON
    /// </summary>
    /// <param name="x">区域左上 X 坐标</param>
    /// <param name="y">区域左上 Y 坐标</param>
    /// <param name="width">区域宽度</param>
    /// <param name="height">区域高度</param>
    /// <param name="template_name">已加载的模板名称</param>
    /// <param name="threshold">匹配阈值，通常取值 0.0-1.0</param>
    /// <param name="ret"></param>
    /// <returns>0：失败或未命中 1：成功命中</returns>
    public string CvEdgeMatchTemplate(int x, int y, int width, int height, string template_name, double threshold) 
        => OpCvEdgeMatchTemplate(handle, x, y, width, height, template_name, threshold);

    /// <summary>
    /// 对图片进行直方图均衡
    /// </summary>
    /// <param name="src_file">源图片路径</param>
    /// <param name="dst_file">输出图片路径</param>
    /// <returns>0：失败 1：成功</returns>
    public int CvEqualize(string src_file, string dst_file) 
        => OpCvEqualize(handle, src_file, dst_file);

    /// <summary>
    /// 变参指针: 返回匹配结果 JSON
    /// </summary>
    /// <param name="x">区域左上 X 坐标</param>
    /// <param name="y">区域左上 Y 坐标</param>
    /// <param name="width">区域宽度</param>
    /// <param name="height">区域高度</param>
    /// <param name="template_name">已加载的模板名称</param>
    /// <param name="threshold">匹配阈值，通常取值 0.0-1.0</param>
    /// <param name="ret"></param>
    /// <returns>0：失败或未命中 1：成功命中</returns>
    public string CvFeatureMatchTemplate(int x, int y, int width, int height, string template_name, double threshold) 
        => OpCvFeatureMatchTemplate(handle, x, y, width, height, template_name, threshold);

    /// <summary>
    /// 变参指针: 返回轮廓结果 JSON
    /// </summary>
    /// <param name="src_file">源图片路径</param>
    /// <param name="min_area">最小面积，小于该面积的轮廓会被忽略</param>
    /// <param name="ret"></param>
    /// <returns>0：失败 1：成功</returns>
    public string CvFindContours(string src_file, double min_area) 
        => OpCvFindContours(handle, src_file, min_area);

    /// <summary>
    /// 获取全部 OpenCV 模板名称
    /// </summary>
    /// <returns>返回以 <code>|</code> 分割的模板名称列表</returns>
    public string CvGetAllTemplateNames() 
        => OpCvGetAllTemplateNames(handle);

    /// <summary>
    /// 获取当前 OpenCV 版本
    /// </summary>
    /// <returns>返回 OpenCV 版本号</returns>
    public string CvGetOpenCvVersion() 
        => OpCvGetOpenCvVersion(handle);

    /// <summary>
    /// 获取已加载的 OpenCV 模板数量
    /// </summary>
    /// <returns>返回模板数量</returns>
    public int CvGetTemplateCount() 
        => OpCvGetTemplateCount(handle);

    /// <summary>
    /// 判断 OpenCV 模板是否存在
    /// </summary>
    /// <param name="name">模板名称</param>
    /// <returns>0：不存在 1：存在</returns>
    public int CvHasTemplate(string name) 
        => OpCvHasTemplate(handle, name);

    /// <summary>
    /// 按颜色范围过滤图片
    /// </summary>
    /// <param name="src_file">源图片路径</param>
    /// <param name="dst_file">输出图片路径</param>
    /// <param name="color_space">颜色空间：<code>bgr</code>、<code>hsv</code>、<code>gray</code> </param>
    /// <param name="lower">下限，格式如"0,0,250"，也支持竖线分隔</param>
    /// <param name="upper">上限，格式如"5,5,255"，也支持竖线分隔</param>
    /// <returns>0：失败 1：成功</returns>
    public int CvInRange(string src_file, string dst_file, string color_space, string lower, string upper) 
        => OpCvInRange(handle, src_file, dst_file, color_space, lower, upper);

    /// <summary>
    /// 加载带掩码的 OpenCV 模板
    /// </summary>
    /// <param name="name">模板名称</param>
    /// <param name="template_path">模板图片路径</param>
    /// <param name="mask_path">掩码图片路径</param>
    /// <returns>0：失败 1：成功</returns>
    public int CvLoadMaskedTemplate(string name, string template_path, string mask_path) 
        => OpCvLoadMaskedTemplate(handle, name, template_path, mask_path);

    /// <summary>
    /// 加载 OpenCV 模板
    /// </summary>
    /// <param name="name">模板名称</param>
    /// <param name="file_path">模板图片路径</param>
    /// <returns>0：失败 1：成功</returns>
    public int CvLoadTemplate(string name, string file_path) 
        => OpCvLoadTemplate(handle, name, file_path);

    /// <summary>
    /// 批量加载 OpenCV 模板
    /// </summary>
    /// <param name="template_list">模板列表，格式为"name,path|name2,path2"</param>
    /// <returns>0：失败 1：成功</returns>
    public int CvLoadTemplateList(string template_list) 
        => OpCvLoadTemplateList(handle, template_list);

    /// <summary>
    /// 变参指针: 返回匹配结果 JSON
    /// </summary>
    /// <param name="x">区域左上 X 坐标</param>
    /// <param name="y">区域左上 Y 坐标</param>
    /// <param name="width">区域宽度</param>
    /// <param name="height">区域高度</param>
    /// <param name="template_names">模板名称列表，使用竖线分割</param>
    /// <param name="threshold">匹配阈值，通常取值 0.0-1.0</param>
    /// <param name="dir">OpenCV 查找方向</param>
    /// <param name="strip_mode">条带搜索模式</param>
    /// <param name="method">OpenCV 模板匹配方法</param>
    /// <param name="color_mode">颜色模式</param>
    /// <param name="ret"></param>
    /// <returns>0：失败或无命中 1：有命中结果</returns>
    public string CvMatchAllTemplates(int x, int y, int width, int height, string template_names, double threshold, int dir, int strip_mode, int method, int color_mode) 
        => OpCvMatchAllTemplates(handle, x, y, width, height, template_names, threshold, dir, strip_mode, method, color_mode);

    /// <summary>
    /// 变参指针: 返回匹配结果 JSON
    /// </summary>
    /// <param name="x">区域左上 X 坐标</param>
    /// <param name="y">区域左上 Y 坐标</param>
    /// <param name="width">区域宽度</param>
    /// <param name="height">区域高度</param>
    /// <param name="template_names">模板名称列表，使用竖线分割</param>
    /// <param name="threshold">匹配阈值，通常取值 0.0-1.0</param>
    /// <param name="dir">OpenCV 查找方向</param>
    /// <param name="strip_mode">条带搜索模式</param>
    /// <param name="method">OpenCV 模板匹配方法</param>
    /// <param name="color_mode">颜色模式</param>
    /// <param name="ret"></param>
    /// <returns>0：失败或未命中 1：成功命中</returns>
    public string CvMatchAnyTemplate(int x, int y, int width, int height, string template_names, double threshold, int dir, int strip_mode, int method, int color_mode) 
        => OpCvMatchAnyTemplate(handle, x, y, width, height, template_names, threshold, dir, strip_mode, method, color_mode);

    /// <summary>
    /// 变参指针: 返回匹配结果 JSON
    /// </summary>
    /// <param name="x">区域左上 X 坐标</param>
    /// <param name="y">区域左上 Y 坐标</param>
    /// <param name="width">区域宽度</param>
    /// <param name="height">区域高度</param>
    /// <param name="template_name">已加载的模板名称</param>
    /// <param name="threshold">匹配阈值，通常取值 0.0-1.0</param>
    /// <param name="dir">OpenCV 查找方向，见上方 dir</param>
    /// <param name="strip_mode">条带搜索模式，见上方 strip_mode</param>
    /// <param name="method">OpenCV 模板匹配方法，见上方 method</param>
    /// <param name="color_mode">颜色模式，见上方 color_mode</param>
    /// <param name="ret"></param>
    /// <returns>0：失败或未命中 1：成功命中</returns>
    public string CvMatchTemplate(int x, int y, int width, int height, string template_name, double threshold, int dir, int strip_mode, int method, int color_mode) 
        => OpCvMatchTemplate(handle, x, y, width, height, template_name, threshold, dir, strip_mode, method, color_mode);

    /// <summary>
    /// 变参指针: 返回匹配结果 JSON
    /// </summary>
    /// <param name="x">区域左上 X 坐标</param>
    /// <param name="y">区域左上 Y 坐标</param>
    /// <param name="width">区域宽度</param>
    /// <param name="height">区域高度</param>
    /// <param name="template_name">已加载的模板名称</param>
    /// <param name="scales">缩放比例列表，格式如"0.8|1|1.2"；传空字符串时使用自动缩放候选</param>
    /// <param name="threshold">匹配阈值，通常取值 0.0-1.0</param>
    /// <param name="method">OpenCV 模板匹配方法</param>
    /// <param name="color_mode">颜色模式</param>
    /// <param name="ret"></param>
    /// <returns>0：失败或未命中 1：成功命中</returns>
    public string CvMatchTemplateScale(int x, int y, int width, int height, string template_name, string scales, double threshold, int method, int color_mode) 
        => OpCvMatchTemplateScale(handle, x, y, width, height, template_name, scales, threshold, method, color_mode);

    /// <summary>
    /// 对图片进行形态学处理
    /// </summary>
    /// <param name="src_file">源图片路径</param>
    /// <param name="dst_file">输出图片路径</param>
    /// <param name="mode">模式：<code>erode</code>、<code>dilate</code>、<code>open</code>、<code>close</code> </param>
    /// <param name="kernel_size">核大小</param>
    /// <param name="iterations">迭代次数</param>
    /// <returns>0：失败 1：成功</returns>
    public int CvMorphology(string src_file, string dst_file, string mode, int kernel_size, int iterations) 
        => OpCvMorphology(handle, src_file, dst_file, mode, kernel_size, iterations);

    /// <summary>
    /// 按顺序执行 OpenCV 预处理流水线
    /// </summary>
    /// <param name="src_file">源图片路径</param>
    /// <param name="dst_file">输出图片路径</param>
    /// <param name="pipeline">流水线，步骤用竖线分隔，参数用 <code>:</code> 和 <code>,</code> </param>
    /// <returns>0：失败 1：成功</returns>
    public int CvPreprocessPipeline(string src_file, string dst_file, string pipeline) 
        => OpCvPreprocessPipeline(handle, src_file, dst_file, pipeline);

    /// <summary>
    /// 移除全部 OpenCV 模板
    /// </summary>
    /// <returns>1：成功</returns>
    public int CvRemoveAllTemplates() 
        => OpCvRemoveAllTemplates(handle);

    /// <summary>
    /// 移除指定 OpenCV 模板
    /// </summary>
    /// <param name="name">模板名称</param>
    /// <returns>0：失败 1：成功</returns>
    public int CvRemoveTemplate(string name) 
        => OpCvRemoveTemplate(handle, name);

    /// <summary>
    /// 调整图片尺寸
    /// </summary>
    /// <param name="src_file">源图片路径</param>
    /// <param name="width">输出宽度</param>
    /// <param name="height">输出高度</param>
    /// <param name="dst_file">输出图片路径</param>
    /// <returns>0：失败 1：成功</returns>
    public int CvResize(string src_file, int width, int height, string dst_file) 
        => OpCvResize(handle, src_file, width, height, dst_file);

    /// <summary>
    /// 变参指针: 返回匹配结果 JSON
    /// </summary>
    /// <param name="x">区域左上 X 坐标</param>
    /// <param name="y">区域左上 Y 坐标</param>
    /// <param name="width">区域宽度</param>
    /// <param name="height">区域高度</param>
    /// <param name="template_name">已加载的模板名称</param>
    /// <param name="threshold">匹配阈值，通常取值 0.0-1.0</param>
    /// <param name="ret"></param>
    /// <returns>0：失败或未命中 1：成功命中</returns>
    public string CvShapeMatchTemplate(int x, int y, int width, int height, string template_name, double threshold) 
        => OpCvShapeMatchTemplate(handle, x, y, width, height, template_name, threshold);

    /// <summary>
    /// 对图片进行锐化处理
    /// </summary>
    /// <param name="src_file">源图片路径</param>
    /// <param name="dst_file">输出图片路径</param>
    /// <param name="strength">锐化强度</param>
    /// <returns>0：失败 1：成功</returns>
    public int CvSharpen(string src_file, string dst_file, double strength) 
        => OpCvSharpen(handle, src_file, dst_file, strength);

    /// <summary>
    /// 对图片进行细化/骨架化处理
    /// </summary>
    /// <param name="src_file">源图片路径</param>
    /// <param name="dst_file">输出图片路径</param>
    /// <param name="mode">模式：<code>zhang_suen</code>、<code>guo_hall</code>、<code>morph</code> </param>
    /// <returns>0：失败 1：成功</returns>
    public int CvThin(string src_file, string dst_file, string mode) 
        => OpCvThin(handle, src_file, dst_file, mode);

    /// <summary>
    /// 对图片进行阈值化处理
    /// </summary>
    /// <param name="src_file">源图片路径</param>
    /// <param name="dst_file">输出图片路径</param>
    /// <param name="threshold">阈值</param>
    /// <param name="max_value">最大值</param>
    /// <param name="mode">模式：<code>binary</code>、<code>binary_inv</code>、<code>otsu</code>、<code>otsu_inv</code>、<code>adaptive</code>、<code>adaptive_inv</code> </param>
    /// <returns>0：失败 1：成功</returns>
    public int CvThreshold(string src_file, string dst_file, double threshold, double max_value, string mode) 
        => OpCvThreshold(handle, src_file, dst_file, threshold, max_value, mode);

    /// <summary>
    /// 自动二值化图片
    /// </summary>
    /// <param name="src_file">源图片路径</param>
    /// <param name="dst_file">输出图片路径</param>
    /// <returns>0：失败 1：成功</returns>
    public int CvToBinary(string src_file, string dst_file) 
        => OpCvToBinary(handle, src_file, dst_file);

    /// <summary>
    /// 提取图片边缘
    /// </summary>
    /// <param name="src_file">源图片路径</param>
    /// <param name="dst_file">输出图片路径</param>
    /// <returns>0：失败 1：成功</returns>
    public int CvToEdge(string src_file, string dst_file) 
        => OpCvToEdge(handle, src_file, dst_file);

    /// <summary>
    /// 将图片转换为灰度图
    /// </summary>
    /// <param name="src_file">源图片路径</param>
    /// <param name="dst_file">输出图片路径</param>
    /// <returns>0：失败 1：成功</returns>
    public int CvToGray(string src_file, string dst_file) 
        => OpCvToGray(handle, src_file, dst_file);

    /// <summary>
    /// 提取图片轮廓线
    /// </summary>
    /// <param name="src_file">源图片路径</param>
    /// <param name="dst_file">输出图片路径</param>
    /// <returns>0：失败 1：成功</returns>
    public int CvToOutline(string src_file, string dst_file) 
        => OpCvToOutline(handle, src_file, dst_file);

    /// <summary>
    /// 该函数旨在实现一个指定毫秒数的延迟，同时确保在此期间不会阻塞用户界面（UI）操作
    /// </summary>
    /// <param name="mis">指定延迟的时间，单位为毫秒</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int Delay(int mis) 
        => OpDelay(handle, mis);

    /// <summary>
    /// 该函数旨在实现一个指定毫秒数的延迟，同时确保在此期间不会阻塞用户界面（UI）操作；
    /// </summary>
    /// <param name="mis_min">指定延迟时间的最小值，单位为毫秒</param>
    /// <param name="mis_max">指定延迟时间的最大值，单位为毫秒</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int Delays(int mis_min, int mis_max) 
        => OpDelays(handle, mis_min, mis_max);

    /// <summary>
    /// 按指定路径拖拽鼠标。函数会先移动到路径第一个点，然后按下左键，沿路径移动到最后一个点，最后松开左键。
    /// </summary>
    /// <param name="path">拖拽路径，格式为 `x,y</param>
    /// <param name="duration">拖拽过程耗时，单位毫秒</param>
    /// <returns>0：失败 1：成功</returns>
    public int DragPath(string path, int duration) 
        => OpDragPath(handle, path, duration);

    /// <summary>
    /// 设置是否启用插件内部的图片缓存机制
    /// </summary>
    /// <param name="enable">0：关闭，1：打开</param>
    /// <returns>0：表示操作失败 1：表示操作成功</returns>
    public int EnablePicCache(int enable) 
        => OpEnablePicCache(handle, enable);

    /// <summary>
    /// 根据指定进程名,枚举系统中符合条件的进程 PID
    /// </summary>
    /// <param name="name">进程名称</param>
    /// <returns>返回所有匹配的进程 PID,返回格式："10180,15352,15000,17620,19412"</returns>
    public string EnumProcess(string name) 
        => OpEnumProcess(handle, name);

    /// <summary>
    /// 根据指定条件,枚举系统中符合条件的窗口
    /// </summary>
    /// <param name="parent">父窗口的句柄</param>
    /// <param name="title">窗口的标题</param>
    /// <param name="class_name">窗口的类名</param>
    /// <param name="filter">窗口过滤条件，可使用下表中的值相加 1:匹配窗口标题，参数 title 有效 2:匹配窗口类名，参数 class_name 有效 4:只匹配指定父窗口的第一层子窗口 8:匹配所有者窗口为 0 的窗口，即顶级窗口 16:匹配可见的窗口 32:匹配出的窗口按照窗口打开顺序依次排列</param>
    /// <returns>返回所有匹配到的窗口句柄</returns>
    public string EnumWindow(IntPtr parent, string title, string class_name, int filter) 
        => OpEnumWindow(handle, parent, title, class_name, filter);

    /// <summary>
    /// 根据指定进程以及其它条件,枚举系统中符合条件的窗口
    /// </summary>
    /// <param name="process_name">进程名称</param>
    /// <param name="title">窗口的标题</param>
    /// <param name="class_name">窗口的类名</param>
    /// <param name="filter">窗口过滤条件，可使用下表中的值相加 1:匹配窗口标题，参数 title 有效 2:匹配窗口类名，参数 class_name 有效 4:只匹配指定父窗口的第一层子窗口 8:匹配所有者窗口为 0 的窗口，即顶级窗口 16:匹配可见的窗口 32:匹配出的窗口按照窗口打开顺序依次排列</param>
    /// <returns>返回所有匹配到的窗口句柄</returns>
    public string EnumWindowByProcess(string process_name, string title, string class_name, int filter) 
        => OpEnumWindowByProcess(handle, process_name, title, class_name, filter);

    /// <summary>
    /// 按颜色规则把指定区域里的点阵字块自动切出来。
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="color">颜色格式串</param>
    /// <param name="sim">相似度，取值范围 0.1-1.0</param>
    /// <param name="min_word_h">字块最小高度，小于等于 0 时按 2 处理</param>
    /// <returns>返回字块矩形列表，格式为 <code>x1,y1,x2,y2|...</code>。没有切出字块时返回空字符串。</returns>
    public string ExtractWordRects(int x1, int y1, int x2, int y2, string color, double sim, int min_word_h) 
        => OpExtractWordRects(handle, x1, y1, x2, y2, color, sim, min_word_h);

    /// <summary>
    /// 按最小宽高和边距自动切出点阵字块，适合截图里夹杂小噪点或字形贴边的情况。
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="color">颜色格式串</param>
    /// <param name="sim">相似度，取值范围 0.1-1.0</param>
    /// <param name="min_word_w">字块最小宽度，小于等于 0 时按 1 处理</param>
    /// <param name="min_word_h">字块最小高度，小于等于 0 时按 2 处理</param>
    /// <param name="padding">给每个字块额外保留的边距，小于 0 时按 0 处理</param>
    /// <returns>返回字块矩形列表，格式为 <code>x1,y1,x2,y2|...</code>。</returns>
    public string ExtractWordRectsEx(int x1, int y1, int x2, int y2, string color, double sim, int min_word_w, int min_word_h, int padding) 
        => OpExtractWordRectsEx(handle, x1, y1, x2, y2, color, sim, min_word_w, min_word_h, padding);

    /// <summary>
    /// 根据指定范围和颜色描述，提取字库条目信息
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="color">颜色格式串，比如"FFFFFF-000000|CCCCCC-000000"每种颜色用"|"分割</param>
    /// <param name="word">字符名称</param>
    /// <returns>返回可传给 AddDict 的字库条目，区域为空或失败时返回空字符串</returns>
    public string FetchWord(int x1, int y1, int x2, int y2, string color, string word) 
        => OpFetchWord(handle, x1, y1, x2, y2, color, word);

    /// <summary>
    /// 根据指定范围、颜色和相似度，提取单个点阵字库条目。相比 <code>FetchWord</code>，该接口可以处理轻微色差或抗锯齿边缘。
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="color">颜色格式串，比如 `"FFFFFF-000000</param>
    /// <param name="sim">相似度，取值范围 0.1-1.0</param>
    /// <param name="word">字符名称</param>
    /// <returns>返回可传给 <code>AddDict</code> 的字库条目。区域为空、切图失败或没有前景点时返回空字符串。</returns>
    public string FetchWordEx(int x1, int y1, int x2, int y2, string color, double sim, string word) 
        => OpFetchWordEx(handle, x1, y1, x2, y2, color, sim, word);

    /// <summary>
    /// 自动切字，并按 <code>words</code> 的字符顺序生成多条点阵字库。切出的字块数量必须和 <code>words</code> 的字符数一致，否则返回空字符串。
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="color">颜色格式串</param>
    /// <param name="sim">相似度，取值范围 0.1-1.0</param>
    /// <param name="words">字符标签，顺序要和截图里从左到右切出的字块一致</param>
    /// <param name="min_word_h">字块最小高度</param>
    /// <returns>返回多行字库文本，每行是一条字库。失败或数量不匹配时返回空字符串。</returns>
    public string FetchWords(int x1, int y1, int x2, int y2, string color, double sim, string words, int min_word_h) 
        => OpFetchWords(handle, x1, y1, x2, y2, color, sim, words, min_word_h);

    /// <summary>
    /// 按指定字块矩形生成多条点阵字库。<code>rects</code> 可以直接使用 <code>ExtractWordRects</code> 或 <code>ExtractWordRectsEx</code> 的返回值。
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="color">颜色格式串</param>
    /// <param name="sim">相似度，取值范围 0.1-1.0</param>
    /// <param name="words">字符标签，数量必须和 <code>rects</code> 中的矩形数量一致</param>
    /// <param name="rects">字块矩形列表，格式为 `x1,y1,x2,y2</param>
    /// <returns>返回多行字库文本。矩形数量和 <code>words</code> 数量不一致时返回空字符串。</returns>
    public string FetchWordsByRects(int x1, int y1, int x2, int y2, string color, double sim, string words, string rects) 
        => OpFetchWordsByRects(handle, x1, y1, x2, y2, color, sim, words, rects);

    /// <summary>
    /// 使用更细的切字参数批量生成点阵字库。
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="color">颜色格式串</param>
    /// <param name="sim">相似度，取值范围 0.1-1.0</param>
    /// <param name="words">字符标签，数量必须和切出的字块数量一致</param>
    /// <param name="min_word_w">字块最小宽度</param>
    /// <param name="min_word_h">字块最小高度</param>
    /// <param name="padding">给每个字块额外保留的边距</param>
    /// <returns>返回多行字库文本。失败或数量不匹配时返回空字符串。</returns>
    public string FetchWordsEx(int x1, int y1, int x2, int y2, string color, double sim, string words, int min_word_w, int min_word_h, int padding) 
        => OpFetchWordsEx(handle, x1, y1, x2, y2, color, sim, words, min_word_w, min_word_h, padding);

    /// <summary>
    /// 查找指定区域内的颜色
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="color">颜色格式串，比如"FFFFFF-000000|CCCCCC-000000"每种颜色用"|"分割</param>
    /// <param name="sim">相似度,取值范围 0.1-1.0</param>
    /// <param name="dir">查找方向,取值如下</param>
    /// <param name="x">变参指针: 返回 X 坐标</param>
    /// <param name="y">变参指针: 返回 Y 坐标</param>
    /// <returns>0：未找到 1：成功找到</returns>
    public int FindColor(int x1, int y1, int x2, int y2, string color, double sim, int dir, out int x, out int y) 
        => OpFindColor(handle, x1, y1, x2, y2, color, sim, dir, out x, out y);

    /// <summary>
    /// 查找指定区域内的颜色块,颜色格式"RRGGBB-DRDGDB"
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="color">颜色格式串，比如"FFFFFF-000000|CCCCCC-000000"每种颜色用"|"分割</param>
    /// <param name="sim">相似度,取值范围 0.1-1.0</param>
    /// <param name="count">在宽度为 width,高度为 height 的颜色块中，符合 color 颜色的最小数量,通过工具在二值化区域中查看</param>
    /// <param name="height">颜色块的宽度</param>
    /// <param name="width">颜色块的高度</param>
    /// <param name="x">变参指针: 返回颜色块的左上角的 X 坐标</param>
    /// <param name="y">变参指针: 返回颜色块的左上角的 Y 坐标</param>
    /// <returns>0:找到 1:没找到</returns>
    public int FindColorBlock(int x1, int y1, int x2, int y2, string color, double sim, int count, int height, int width, out int x, out int y) 
        => OpFindColorBlock(handle, x1, y1, x2, y2, color, sim, count, height, width, out x, out y);

    /// <summary>
    /// 查找指定区域内的所有颜色块, 颜色格式"RRGGBB-DRDGDB"
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="color">颜色格式串，比如"FFFFFF-000000|CCCCCC-000000"每种颜色用"|"分割</param>
    /// <param name="sim">相似度,取值范围 0.1-1.0</param>
    /// <param name="count">在宽度为 width,高度为 height 的颜色块中，符合 color 颜色的最小数量,通过工具在二值化区域中查看</param>
    /// <param name="height">颜色块的宽度</param>
    /// <param name="width">颜色块的高度</param>
    /// <returns>返回所有颜色块信息的坐标</returns>
    public string FindColorBlockEx(int x1, int y1, int x2, int y2, string color, double sim, int count, int height, int width) 
        => OpFindColorBlockEx(handle, x1, y1, x2, y2, color, sim, count, height, width);

    /// <summary>
    /// 查找指定区域内的所有颜色
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="color">颜色格式串，比如"FFFFFF-000000|CCCCCC-000000"每种颜色用"|"分割</param>
    /// <param name="sim">相似度,取值范围 0.1-1.0</param>
    /// <param name="dir">查找方向,取值如下</param>
    /// <returns>返回所有颜色信息的坐标值</returns>
    public string FindColorEx(int x1, int y1, int x2, int y2, string color, double sim, int dir) 
        => OpFindColorEx(handle, x1, y1, x2, y2, color, sim, dir);

    /// <summary>
    /// 在指定的屏幕坐标范围内，查找指定颜色的直线
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="color">颜色格式串，比如"FFFFFF-000000|CCCCCC-000000"每种颜色用"|"分割</param>
    /// <param name="sim">相似度,取值范围 0.1-1.0</param>
    /// <returns>返回直线描述。结果包含直线角度和距离等信息，失败时返回空字符串。</returns>
    public string FindLine(int x1, int y1, int x2, int y2, string color, double sim) 
        => OpFindLine(handle, x1, y1, x2, y2, color, sim);

    /// <summary>
    /// 根据指定的多点查找颜色坐标
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="first_color">颜色格式串，比如"FFFFFF-000000|CCCCCC-000000"每种颜色用"|"分割</param>
    /// <param name="offset_color">偏移颜色可以支持任意多个点,格式为"x1|y1|RRGGBB-DRDGDB|RRGGBB-DRDGDB……</param>
    /// <param name="sim">相似度,取值范围 0.1-1.0</param>
    /// <param name="dir">查找方向,取值如下<a href="#dir">Dir</a> </param>
    /// <param name="x">变参指针: 返回 X 坐标, 坐标为 first_color 所在坐标</param>
    /// <param name="y">变参指针: 返回 Y 坐标, 坐标为 first_color 所在坐标</param>
    /// <returns>0：未找到 1：成功找到</returns>
    public int FindMultiColor(int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir, out int x, out int y) 
        => OpFindMultiColor(handle, x1, y1, x2, y2, first_color, offset_color, sim, dir, out x, out y);

    /// <summary>
    /// 根据指定的多点查找所有颜色坐标
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="first_color">颜色格式串，比如"FFFFFF-000000|CCCCCC-000000"每种颜色用"|"分割</param>
    /// <param name="offset_color">偏移颜色可以支持任意多个点,格式为"x1|y1|RRGGBB-DRDGDB|RRGGBB-DRDGDB……</param>
    /// <param name="sim">相似度,取值范围 0.1-1.0</param>
    /// <param name="dir">查找方向,取值如下<a href="#dir">Dir</a> </param>
    /// <returns>返回所有颜色信息的坐标,坐标是 first_color 所在的坐标</returns>
    public string FindMultiColorEx(int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir) 
        => OpFindMultiColorEx(handle, x1, y1, x2, y2, first_color, offset_color, sim, dir);

    /// <summary>
    /// 在一组位置中查找最近的位置
    /// </summary>
    /// <param name="all_pos">位置列表，以 "|" 分割</param>
    /// <param name="type">0：每项格式为 <code>name,x,y</code>；1：每项格式为 <code>x,y</code> </param>
    /// <param name="x">参考点 X 坐标</param>
    /// <param name="y">参考点 Y 坐标</param>
    /// <returns>返回最接近指定坐标 <code>(x,y)</code> 的位置。<code>type=0</code> 时返回 <code>name,x,y</code>，<code>type=1</code> 时返回 <code>x,y</code>。</returns>
    public string FindNearestPos(string all_pos, int type, int x, int y) 
        => OpFindNearestPos(handle, all_pos, type, x, y);

    /// <summary>
    /// 查找指定区域内的图片
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="files">图片名,可以是多个图片,比如"test1.bmp|test2.bmp|test3.bmp"</param>
    /// <param name="delta_color">颜色色偏,比如"203040"</param>
    /// <param name="sim">相似度,取值范围 0.1-1.0</param>
    /// <param name="dir">查找方向,取值如下<a href="#dir">Dir</a> </param>
    /// <param name="x">变参指针: 返回图片左上角的 X 坐标</param>
    /// <param name="y">变参指针: 返回图片左上角的 Y 坐标</param>
    /// <returns>返回找到的图片的序号,从 0 开始索引.如果没找到返回-1</returns>
    public int FindPic(int x1, int y1, int x2, int y2, string files, string delta_color, double sim, int dir, out int x, out int y) 
        => OpFindPic(handle, x1, y1, x2, y2, files, delta_color, sim, dir, out x, out y);

    /// <summary>
    /// 查找多个图片,并且返回所有找到的图像的坐标
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="files">图片名,可以是多个图片,比如"test1.bmp|test2.bmp|test3.bmp"</param>
    /// <param name="delta_color">颜色色偏,比如"203040"</param>
    /// <param name="sim">相似度,取值范围 0.1-1.0</param>
    /// <param name="dir">查找方向,取值如下<a href="#dir">Dir</a> </param>
    /// <returns>返回的是所有找到的坐标格式如下:"id,x,y|id,x,y..|id,x,y";id 对应图片序号，x,y 图片左上角的坐标</returns>
    public string FindPicEx(int x1, int y1, int x2, int y2, string files, string delta_color, double sim, int dir) 
        => OpFindPicEx(handle, x1, y1, x2, y2, files, delta_color, sim, dir);

    /// <summary>
    /// 查找多个图片，并返回所有命中的图片名和坐标。
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="files">图片名,可以是多个图片,比如"test1.bmp|test2.bmp|test3.bmp"</param>
    /// <param name="delta_color">颜色色偏,比如"203040"</param>
    /// <param name="sim">相似度,取值范围 0.1-1.0</param>
    /// <param name="dir">查找方向,取值如下<a href="#dir">Dir</a> </param>
    /// <returns>返回的是所有找到的坐标格式如下:"file,x,y| file,x,y..| file,x,y" (图片左上角的坐标)</returns>
    public string FindPicExS(int x1, int y1, int x2, int y2, string files, string delta_color, double sim, int dir) 
        => OpFindPicExS(handle, x1, y1, x2, y2, files, delta_color, sim, dir);

    /// <summary>
    /// 在屏幕范围(x1,y1,x2,y2)内查找字符串，并返回符合 color_format 的坐标位置
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="strs">待查找的字符串，支持用 "|" 分隔多个候选项，比如"长安|洛阳|大雁塔"</param>
    /// <param name="color">颜色格式串，比如"FFFFFF-000000|CCCCCC-000000"每种颜色用"|"分割</param>
    /// <param name="sim">相似度,取值范围 0.1-1.0</param>
    /// <param name="retx">变参指针: 返回 X 坐标没找到返回-1</param>
    /// <param name="rety">变参指针: 返回 Y 坐标没找到返回-1</param>
    /// <returns>返回字符串的索引 没找到返回-1, 比如"长安|洛阳",若找到长安，则返回 0</returns>
    public int FindStr(int x1, int y1, int x2, int y2, string strs, string color, double sim, out int retx, out int rety) 
        => OpFindStr(handle, x1, y1, x2, y2, strs, color, sim, out retx, out rety);

    /// <summary>
    /// 在屏幕范围(x1,y1,x2,y2)内查找字符串
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="strs">待查找的字符串，支持用 "|" 分隔多个候选项，比如"长安|洛阳|大雁塔"</param>
    /// <param name="color">颜色格式串，比如"FFFFFF-000000|CCCCCC-000000"每种颜色用"|"分割</param>
    /// <param name="sim">相似度,取值范围 0.1-1.0</param>
    /// <returns>返回所有找到的坐标集合,格式如下: "id,x0,y0|id,x1,y1|......|id,xn,yn" 比如"0,100,20|2,30,40" 表示找到了两个,第一个,对应的是序号为 0 的字符串,坐标是(100,20),第二个是序号为 2 的字符串,坐标(30,40)</returns>
    public string FindStrEx(int x1, int y1, int x2, int y2, string strs, string color, double sim) 
        => OpFindStrEx(handle, x1, y1, x2, y2, strs, color, sim);

    /// <summary>
    /// 查找符合类名或者标题名的顶层可见窗口
    /// </summary>
    /// <param name="class_name">窗口类名,如果为空,则匹配所有,这里的匹配是模糊匹配</param>
    /// <param name="title">窗口标题,如果为空,则匹配所有,这里的匹配是模糊匹配</param>
    /// <returns>返回窗口句柄,没找到则返回 0</returns>
    public IntPtr FindWindow(string class_name, string title) 
        => OpFindWindow(handle, class_name, title);

    /// <summary>
    /// 根据指定的进程名字，来查找可见窗口
    /// </summary>
    /// <param name="process_name">进程名,比如(notepad.exe),这里是精确匹配,但不区分大小写</param>
    /// <param name="class_name">窗口类名,如果为空,则匹配所有,这里的匹配是模糊匹配</param>
    /// <param name="title">窗口标题,如果为空,则匹配所有,这里的匹配是模糊匹配</param>
    /// <returns>返回窗口句柄,没找到则返回 0</returns>
    public IntPtr FindWindowByProcess(string process_name, string class_name, string title) 
        => OpFindWindowByProcess(handle, process_name, class_name, title);

    /// <summary>
    /// 根据指定的进程 Id，来查找可见窗口
    /// </summary>
    /// <param name="process_id">进程 id</param>
    /// <param name="class_name">窗口类名,如果为空,则匹配所有,这里的匹配是模糊匹配</param>
    /// <param name="title">窗口标题,如果为空,则匹配所有,这里的匹配是模糊匹配</param>
    /// <returns>返回窗口句柄,没找到则返回 0</returns>
    public IntPtr FindWindowByProcessId(int process_id, string class_name, string title) 
        => OpFindWindowByProcessId(handle, process_id, class_name, title);

    /// <summary>
    /// 查找符合类名或者标题名的顶层可见窗口,如果指定了 parent,则在 parent 的第一层子窗口中查找
    /// </summary>
    /// <param name="parent">父窗口句柄，如果为空，则匹配所有顶层窗口</param>
    /// <param name="class_name">窗口类名,如果为空,则匹配所有,这里的匹配是模糊匹配</param>
    /// <param name="title">窗口标题,如果为空,则匹配所有,这里的匹配是模糊匹配</param>
    /// <returns>返回窗口句柄,没找到则返回 0</returns>
    public IntPtr FindWindowEx(IntPtr parent, string class_name, string title) 
        => OpFindWindowEx(handle, parent, class_name, title);

    /// <summary>
    /// 释放指定图片的缓存入口。
    /// </summary>
    /// <param name="file_name">文件名</param>
    /// <returns>0：失败 1：成功</returns>
    public int FreePic(string file_name) 
        => OpFreePic(handle, file_name);

    /// <summary>
    /// 获取插件目录
    /// </summary>
    /// <returns>返回当前插件所在路径</returns>
    public string GetBasePath() 
        => OpGetBasePath(handle);

    /// <summary>
    /// 获取当前点阵二值图预处理参数。
    /// </summary>
    /// <param name="mode">返回当前预处理模式</param>
    /// <param name="isolated_threshold">返回孤立点判断阈值</param>
    /// <param name="min_component_area">返回小连通域最小面积</param>
    /// <param name="bridge_gap">返回是否连接 1 像素断笔</param>
    /// <returns>0：失败 1：成功</returns>
    public int GetBinaryPreprocess(out int mode, out int isolated_threshold, out int min_component_area, out int bridge_gap) 
        => OpGetBinaryPreprocess(handle, out mode, out isolated_threshold, out min_component_area, out bridge_gap);

    /// <summary>
    /// 返回文本预览
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="color">颜色格式串</param>
    /// <param name="sim">相似度，取值范围 0.1-1.0</param>
    /// <param name="ret"></param>
    /// <returns>返回前景点数量。失败或没有前景点时返回 0。</returns>
    public string GetBinaryPreview(int x1, int y1, int x2, int y2, string color, double sim, out int ret) 
        => OpGetBinaryPreview(handle, x1, y1, x2, y2, color, sim, out ret);

    /// <summary>
    /// 获取当前对象已经绑定的窗口句柄. 无绑定返回:0
    /// </summary>
    /// <returns>0: 没有绑定窗口</returns>
    public IntPtr GetBindWindow() 
        => OpGetBindWindow(handle);

    /// <summary>
    /// 获取窗口客户区域在屏幕上的位置
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <param name="x1">变参指针: 返回窗口客户区左上角 X 坐标</param>
    /// <param name="y1">变参指针: 返回窗口客户区左上角 Y 坐标</param>
    /// <param name="x2">变参指针: 返回窗口客户区右下角 X 坐标</param>
    /// <param name="y2">变参指针: 返回窗口客户区右下角 Y 坐标</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int GetClientRect(IntPtr hwnd, out int x1, out int y1, out int x2, out int y2) 
        => OpGetClientRect(handle, hwnd, out x1, out y1, out x2, out y2);

    /// <summary>
    /// 获取窗口客户区域的宽度和高度
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <param name="width">变参指针: 窗口宽度</param>
    /// <param name="height">变参指针: 窗口高度</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int GetClientSize(IntPtr hwnd, out int width, out int height) 
        => OpGetClientSize(handle, hwnd, out width, out height);

    /// <summary>
    /// 从系统剪贴板获取数据
    /// </summary>
    /// <returns>成功则返回剪贴板数据</returns>
    public string GetClipboard() 
        => OpGetClipboard(handle);

    /// <summary>
    /// 运行命令行并返回结果
    /// </summary>
    /// <param name="cmd">指定的可执行程序全路径</param>
    /// <param name="millseconds">等待的时间(毫秒)</param>
    /// <returns>cmd 输出的字符</returns>
    public string GetCmdStr(string cmd, int millseconds) 
        => OpGetCmdStr(handle, cmd, millseconds);

    /// <summary>
    /// 获取(x,y)的颜色
    /// </summary>
    /// <param name="x">X 坐标</param>
    /// <param name="y">Y 坐标</param>
    /// <returns>返回颜色字符串</returns>
    public string GetColor(int x, int y) 
        => OpGetColor(handle, x, y);

    /// <summary>
    /// 统计指定区域内匹配颜色的像素数量
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="color">颜色格式串，比如"FFFFFF-000000|CCCCCC-000000"每种颜色用"|"分割</param>
    /// <param name="sim">相似度,取值范围 0.1-1.0</param>
    /// <returns>返回匹配到的颜色像素数量</returns>
    public int GetColorNum(int x1, int y1, int x2, int y2, string color, double sim) 
        => OpGetColorNum(handle, x1, y1, x2, y2, color, sim);

    /// <summary>
    /// 获取鼠标位置
    /// </summary>
    /// <param name="x">变参指针: 返回 X 坐标</param>
    /// <param name="y">变参指针: 返回 Y 坐标</param>
    /// <returns>0：失败 1：成功</returns>
    public int GetCursorPos(out int x, out int y) 
        => OpGetCursorPos(handle, out x, out y);

    /// <summary>
    /// 获取当前鼠标形状特征
    /// </summary>
    /// <returns>返回当前鼠标形状的特征字符串，获取失败返回空字符串</returns>
    public string GetCursorShape() 
        => OpGetCursorShape(handle);

    /// <summary>
    /// 获取指定字库中的条目内容
    /// </summary>
    /// <param name="idx">字库序号</param>
    /// <param name="font_index">条目序号</param>
    /// <returns>返回字库条目字符串，失败返回空字符串</returns>
    public string GetDict(int idx, int font_index) 
        => OpGetDict(handle, idx, font_index);

    /// <summary>
    /// 获取指定字库中的字符数量
    /// </summary>
    /// <param name="idx">字库序号</param>
    /// <returns>返回字库条目数量</returns>
    public int GetDictCount(int idx) 
        => OpGetDictCount(handle, idx);

    /// <summary>
    /// 获取顶层活动窗口中具有输入焦点的窗口句柄
    /// </summary>
    /// <returns>返回窗口句柄</returns>
    public IntPtr GetForegroundFocus() 
        => OpGetForegroundFocus(handle);

    /// <summary>
    /// 获取顶层活动窗口,可以获取到按键自带插件无法获取到的句柄
    /// </summary>
    /// <returns>返回窗口句柄</returns>
    public IntPtr GetForegroundWindow() 
        => OpGetForegroundWindow(handle);

    /// <summary>
    /// 返回当前对象的 ID。每个对象都有独立 ID，可用来判断两个变量是否指向同一个 OP 对象。
    /// </summary>
    /// <returns>当前对象的 ID。</returns>
    public int GetID() 
        => OpGetID(handle);

    /// <summary>
    /// 获取指定的按键状态.(前台信息,不是后台)
    /// </summary>
    /// <param name="vk_code">虚拟按键码</param>
    /// <returns>0：失败 1：成功</returns>
    public int GetKeyState(int vk_code) 
        => OpGetKeyState(handle, vk_code);

    /// <summary>
    /// 获取最后的错误
    /// </summary>
    /// <returns>0: 表示无错误</returns>
    public int GetLastError() 
        => OpGetLastError(handle);

    /// <summary>
    /// 获取鼠标指向的可见窗口句柄,可以获取到按键自带的插件无法获取到的句柄
    /// </summary>
    /// <returns>返回窗口句柄</returns>
    public IntPtr GetMousePointWindow() 
        => OpGetMousePointWindow(handle);

    /// <summary>
    /// 获取当前使用的字库序号
    /// </summary>
    /// <returns>返回当前字库序号</returns>
    public int GetNowDict() 
        => OpGetNowDict(handle);

    /// <summary>
    /// 获取全局路径
    /// </summary>
    /// <returns>返回当前设置的全局路径</returns>
    public string GetPath() 
        => OpGetPath(handle);

    /// <summary>
    /// 获取图片宽高
    /// </summary>
    /// <param name="pic_name">图片文件名</param>
    /// <param name="width">变参指针: 返回图片宽</param>
    /// <param name="height">变参指针: 返回图片高</param>
    /// <returns>0：失败 1：成功</returns>
    public int GetPicSize(string pic_name, out int width, out int height) 
        => OpGetPicSize(handle, pic_name, out width, out height);

    /// <summary>
    /// 获取给定坐标的可见窗口句柄
    /// </summary>
    /// <param name="x">屏幕 X 坐标</param>
    /// <param name="y">屏幕 Y 坐标</param>
    /// <returns>返回窗口句柄</returns>
    public IntPtr GetPointWindow(int x, int y) 
        => OpGetPointWindow(handle, x, y);

    /// <summary>
    /// 根据指定的 pid 获取进程详细信息,(进程名,进程全路径,CPU 占用率(百分比),内存占用量(字节))
    /// </summary>
    /// <param name="pid">进程 pid</param>
    /// <returns>返回格式"进程名|进程路径|cpu|内存"</returns>
    public string GetProcessInfo(int pid) 
        => OpGetProcessInfo(handle, pid);

    /// <summary>
    /// 获取指定区域的图像,用二进制数据的方式返回
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="data"></param>
    /// <param name="ret"></param>
    /// <returns>返回的是指定区域的二进制图片颜色数据，每个颜色是 4 个字节,表示方式为(00RRGGBB)</returns>
    public IntPtr GetScreenData(int x1, int y1, int x2, int y2, out int ret) 
        => OpGetScreenData(handle, x1, y1, x2, y2, out ret);

    /// <summary>
    /// 获取指定区域的图像,用 24 位位图的数据格式返回
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="data">变参指针:返回图片的数据指针</param>
    /// <param name="size">变参指针:返回图片的数据长度</param>
    /// <param name="ret"></param>
    /// <returns>0：失败 1：成功</returns>
    public IntPtr GetScreenDataBmp(int x1, int y1, int x2, int y2, out int size, out int ret) 
        => OpGetScreenDataBmp(handle, x1, y1, x2, y2, out size, out ret);

    /// <summary>
    /// 获取屏幕帧信息
    /// </summary>
    /// <param name="frame_id">屏幕帧的 ID</param>
    /// <param name="time"></param>
    public void GetScreenFrameInfo(out int frame_id, out int time) 
        => OpGetScreenFrameInfo(handle, out frame_id, out time);

    /// <summary>
    /// 获取特殊窗口
    /// </summary>
    /// <param name="flag">取值如下 0:获取桌面窗口 1:获取任务栏窗口</param>
    /// <returns>返回窗口句柄</returns>
    public IntPtr GetSpecialWindow(int flag) 
        => OpGetSpecialWindow(handle, flag);

    /// <summary>
    /// 获取给定窗口相关的窗口句柄
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <param name="flag">取值如下 0:获取父窗口 1:获取第一个儿子窗口 2:获取 First 窗口 3:获取 Last 窗口 4:获取下一个窗口 5:获取上一个窗口 6:获取拥有者窗口 7:获取顶层窗口</param>
    /// <returns>返回窗口句柄</returns>
    public IntPtr GetWindow(IntPtr hwnd, int flag) 
        => OpGetWindow(handle, hwnd, flag);

    /// <summary>
    /// 获取窗口的类名
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <returns>窗口的类名</returns>
    public string GetWindowClass(IntPtr hwnd) 
        => OpGetWindowClass(handle, hwnd);

    /// <summary>
    /// 获取指定窗口所在的进程 ID
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <returns>返回进程 ID</returns>
    public int GetWindowProcessId(IntPtr hwnd) 
        => OpGetWindowProcessId(handle, hwnd);

    /// <summary>
    /// 获取指定窗口所在的进程的 exe 文件全路径
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <returns>返回进程所在的全路径</returns>
    public string GetWindowProcessPath(IntPtr hwnd) 
        => OpGetWindowProcessPath(handle, hwnd);

    /// <summary>
    /// 获取窗口在屏幕上的位置
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <param name="x1">变参指针: 返回窗口左上角 X 坐标</param>
    /// <param name="y1">变参指针: 返回窗口左上角 Y 坐标</param>
    /// <param name="x2">变参指针: 返回窗口右下角 X 坐标</param>
    /// <param name="y2">变参指针: 返回窗口右下角 Y 坐标</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int GetWindowRect(IntPtr hwnd, out int x1, out int y1, out int x2, out int y2) 
        => OpGetWindowRect(handle, hwnd, out x1, out y1, out x2, out y2);

    /// <summary>
    /// 获取指定窗口的一些属性
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <param name="flag">取值如下 0:判断窗口是否存在 1:判断窗口是否处于激活 2:判断窗口是否可见 3:判断窗口是否最小化 4:判断窗口是否最大化 5:判断窗口是否置顶 6:判断窗口是否无响应 7:判断窗口是否可用(灰色为不可用)</param>
    /// <returns>0: 不满足条件 1: 满足条件</returns>
    public int GetWindowState(IntPtr hwnd, int flag) 
        => OpGetWindowState(handle, hwnd, flag);

    /// <summary>
    /// 获取窗口的标题
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <returns>返回窗口的标题</returns>
    public string GetWindowTitle(IntPtr hwnd) 
        => OpGetWindowTitle(handle, hwnd);

    /// <summary>
    /// 返回点阵预览
    /// </summary>
    /// <param name="dict_info">单条字库文本，可来自 <code>FetchWord/GetDict</code> </param>
    /// <param name="ret"></param>
    /// <returns>0：字库条目无效 1：字库条目有效</returns>
    public string GetWordPreview(string dict_info, out int ret) 
        => OpGetWordPreview(handle, dict_info, out ret);

    /// <summary>
    /// 获取 GetWordsNoDict 结果中的词块数量
    /// </summary>
    /// <param name="result">GetWordsNoDict 返回的字符串</param>
    /// <returns>返回词块数量</returns>
    public int GetWordResultCount(string result) 
        => OpGetWordResultCount(handle, result);

    /// <summary>
    /// 获取 GetWordsNoDict 结果中指定词块的坐标
    /// </summary>
    /// <param name="result">GetWordsNoDict 返回值</param>
    /// <param name="index">词块序号，从 0 开始</param>
    /// <param name="x">变参指针: 返回 X 坐标</param>
    /// <param name="y">变参指针: 返回 Y 坐标</param>
    /// <returns>0：失败 1：成功</returns>
    public int GetWordResultPos(string result, int index, out int x, out int y) 
        => OpGetWordResultPos(handle, result, index, out x, out y);

    /// <summary>
    /// 获取 GetWordsNoDict 结果中指定词块的内容
    /// </summary>
    /// <param name="result">GetWordsNoDict 返回值</param>
    /// <param name="index">词块序号，从 0 开始</param>
    /// <returns>返回词块内容，失败返回空字符串</returns>
    public string GetWordResultStr(string result, int index) 
        => OpGetWordResultStr(handle, result, index);

    /// <summary>
    /// 不依赖字库，识别指定范围内所有满足颜色条件的词块位置和点阵信息
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="color">颜色格式串，比如"FFFFFF-000000|CCCCCC-000000"每种颜色用"|"分割</param>
    /// <returns>返回格式为 <code>x,y-word/x,y-word/</code></returns>
    public string GetWordsNoDict(int x1, int y1, int x2, int y2, string color) 
        => OpGetWordsNoDict(handle, x1, y1, x2, y2, color);

    /// <summary>
    /// 水平滚轮滚动指定距离
    /// </summary>
    /// <param name="delta">滚动距离。正数向右，负数向左，120 为一格滚轮距离</param>
    /// <returns>0：失败 1：成功</returns>
    public int HWheel(int delta) 
        => OpHWheel(handle, delta);

    /// <summary>
    /// 将指定的 DLL 注入到指定的进程中
    /// </summary>
    /// <param name="process_name">指定要注入 DLL 的进程名称</param>
    /// <param name="dll_name">注入的 DLL 名称</param>
    /// <returns>0：表示操作失败 1：表示操作成功</returns>
    public int InjectDll(string process_name, string dll_name) 
        => OpInjectDll(handle, process_name, dll_name);

    /// <summary>
    /// 该函数旨在判断当前对象是否已绑定窗口
    /// </summary>
    /// <returns>0: 表示未绑定状态 1: 表示已绑定状态</returns>
    public int IsBind() 
        => OpIsBind(handle);

    /// <summary>
    /// 按住指定的虚拟键码
    /// </summary>
    /// <param name="vk_code">虚拟按键码</param>
    /// <returns>0：失败 1：成功</returns>
    public int KeyDown(int vk_code) 
        => OpKeyDown(handle, vk_code);

    /// <summary>
    /// 按住指定的虚拟键码,字符串形式
    /// </summary>
    /// <param name="vk_code">字符串描述的键码,大小写无所谓，按键具体对应关系<a href="#keycode">按键码</a> </param>
    /// <returns>0：失败 1：成功</returns>
    public int KeyDownChar(string vk_code) 
        => OpKeyDownChar(handle, vk_code);

    /// <summary>
    /// 按住指定的虚拟键码
    /// </summary>
    /// <param name="vk_code">虚拟按键码</param>
    /// <returns>0：失败 1：成功</returns>
    public int KeyPress(int vk_code) 
        => OpKeyPress(handle, vk_code);

    /// <summary>
    /// 按住指定的虚拟键码,字符串形式
    /// </summary>
    /// <param name="vk_code">字符串描述的键码,大小写无所谓，按键具体对应关系查看<a href="#keycode">按键码</a> </param>
    /// <returns>0：失败 1：成功</returns>
    public int KeyPressChar(string vk_code) 
        => OpKeyPressChar(handle, vk_code);

    /// <summary>
    /// 按顺序输入字符串
    /// </summary>
    /// <param name="key_str">要输入的字符串</param>
    /// <param name="delay">每个字符之间的延迟时间，单位通常为毫秒</param>
    /// <returns>0：失败 1：成功</returns>
    public int KeyPressStr(string key_str, int delay) 
        => OpKeyPressStr(handle, key_str, delay);

    /// <summary>
    /// 弹起来虚拟键 vk_code
    /// </summary>
    /// <param name="vk_code">虚拟按键码</param>
    /// <returns>0：失败 1：成功</returns>
    public int KeyUp(int vk_code) 
        => OpKeyUp(handle, vk_code);

    /// <summary>
    /// 弹起来虚拟键,字符串形式
    /// </summary>
    /// <param name="vk_code">字符串描述的键码,大小写无所谓，按键具体对应关系查看<a href="#keycode">按键码</a> </param>
    /// <returns>0：失败 1：成功</returns>
    public int KeyUpChar(string vk_code) 
        => OpKeyUpChar(handle, vk_code);

    /// <summary>
    /// 按指定方式排列窗口
    /// </summary>
    /// <param name="hwnds">窗口句柄列表，多个句柄使用竖线分割</param>
    /// <param name="layout_type">排列方式，取值如下 0:宫格 1:对角线</param>
    /// <param name="columns">宫格模式下每行窗口数量</param>
    /// <param name="start_x">排列起点 X 坐标</param>
    /// <param name="start_y">排列起点 Y 坐标</param>
    /// <param name="gap_x">窗口横向间距</param>
    /// <param name="gap_y">窗口纵向间距</param>
    /// <param name="size_mode">窗口大小策略，取值如下 0:保持原窗口大小 1:统一客户区大小</param>
    /// <param name="window_width">统一大小时的目标客户区宽度</param>
    /// <param name="window_height">统一大小时的目标客户区高度</param>
    /// <param name="anchor_mode">排列时使用的矩形基准，取值如下 0:按窗口外框排列 1:按客户区排列</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int LayoutWindows(string hwnds, int layout_type, int columns, int start_x, int start_y, int gap_x, int gap_y, int size_mode, int window_width, int window_height, int anchor_mode) 
        => OpLayoutWindows(handle, hwnds, layout_type, columns, start_x, start_y, gap_x, gap_y, size_mode, window_width, window_height, anchor_mode);

    /// <summary>
    /// 按下鼠标左键
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int LeftClick() 
        => OpLeftClick(handle);

    /// <summary>
    /// 双击鼠标左键
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int LeftDoubleClick() 
        => OpLeftDoubleClick(handle);

    /// <summary>
    /// 按住鼠标左键
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int LeftDown() 
        => OpLeftDown(handle);

    /// <summary>
    /// 弹起鼠标左键
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int LeftUp() 
        => OpLeftUp(handle);

    /// <summary>
    /// 从内存中加载图片，并以 <code>file_name</code> 作为缓存名保存。
    /// </summary>
    /// <param name="file_name">图片的文件名</param>
    /// <param name="data">图像数据</param>
    /// <param name="size">图像数据的大小</param>
    /// <returns>0：失败 1：成功</returns>
    public int LoadMemPic(string file_name, IntPtr data, int size) 
        => OpLoadMemPic(handle, file_name, data, size);

    /// <summary>
    /// 预加载指定图片并写入缓存。
    /// </summary>
    /// <param name="file_name">文件名,比如"1.bmp|2.bmp|3.bmp" 等.</param>
    /// <returns>0：失败 1：成功</returns>
    public int LoadPic(string file_name) 
        => OpLoadPic(handle, file_name);

    /// <summary>
    /// 锁定目标窗口的外部输入，防止脚本执行过程中被人工鼠标、键盘操作打断。此接口只对 <code>dx</code> 鼠标、<code>dx</code> 键盘模式有效，普通前台模式和 <code>windows</code> 后台模式不会生效。
    /// </summary>
    /// <param name="lock">0 解除锁定；1 锁定鼠标和键盘；2 只锁定鼠标；3 只锁定键盘</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int LockInput(int lock_) 
        => OpLockInput(handle, lock_);

    /// <summary>
    /// 根据通配符获取文件集合. 方便用于 FindPic 和 FindPicEx
    /// </summary>
    /// <param name="pic_name">文件名,比如"1.bmp|2.bmp|3.bmp" 等</param>
    /// <returns>返回的是通配符对应的文件集合，每个图片以|分割</returns>
    public string MatchPicName(string pic_name) 
        => OpMatchPicName(handle, pic_name);

    /// <summary>
    /// 按下鼠标中键
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int MiddleClick() 
        => OpMiddleClick(handle);

    /// <summary>
    /// 双击鼠标中键
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int MiddleDoubleClick() 
        => OpMiddleDoubleClick(handle);

    /// <summary>
    /// 按住鼠标中键
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int MiddleDown() 
        => OpMiddleDown(handle);

    /// <summary>
    /// 弹起鼠标中键
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int MiddleUp() 
        => OpMiddleUp(handle);

    /// <summary>
    /// 按指定路径移动鼠标。适合使用录制出来的轨迹，或者脚本自己生成的轨迹点。
    /// </summary>
    /// <param name="path">路径点，格式为 `x,y</param>
    /// <param name="duration">整条路径耗时，单位毫秒</param>
    /// <returns>0：失败 1：成功</returns>
    public int MovePath(string path, int duration) 
        => OpMovePath(handle, path, duration);

    /// <summary>
    /// 鼠标相对于上次的位置移动 rx,ry.
    /// </summary>
    /// <param name="x">相对于上次的 X 偏移</param>
    /// <param name="y">相对于上次的 Y 偏移</param>
    /// <returns>0：失败 1：成功</returns>
    public int MoveR(int x, int y) 
        => OpMoveR(handle, x, y);

    /// <summary>
    /// 把鼠标移动到目的点(x,y)
    /// </summary>
    /// <param name="x">X 坐标</param>
    /// <param name="y">Y 坐标</param>
    /// <returns>0：失败 1：成功</returns>
    public int MoveTo(int x, int y) 
        => OpMoveTo(handle, x, y);

    /// <summary>
    /// 把鼠标移动到目的范围内的任意一点
    /// </summary>
    /// <param name="x">X 坐标</param>
    /// <param name="y">Y 坐标</param>
    /// <param name="w">宽度(从 x 计算起)</param>
    /// <param name="h">高度(从 y 计算起)</param>
    /// <returns>返回要移动到的目标点. 格式为 x,y. 比如 MoveToEx 100,100,10,10,返回值可能是 101,102</returns>
    public string MoveToEx(int x, int y, int w, int h) 
        => OpMoveToEx(handle, x, y, w, h);

    /// <summary>
    /// 在指定范围内随机取一个目标点，然后按轨迹移动过去。
    /// </summary>
    /// <param name="x">起始 X 坐标</param>
    /// <param name="y">起始 Y 坐标</param>
    /// <param name="w">宽度，从 x 开始计算</param>
    /// <param name="h">高度，从 y 开始计算</param>
    /// <param name="duration">整段轨迹耗时，单位毫秒</param>
    /// <returns>成功时返回最终移动到的点，格式为 <code>x,y</code>。失败时返回空字符串。</returns>
    public string MoveToExSmooth(int x, int y, int w, int h, int duration) 
        => OpMoveToExSmooth(handle, x, y, w, h, duration);

    /// <summary>
    /// 按轨迹把鼠标移动到指定坐标。
    /// </summary>
    /// <param name="x">目标 X 坐标</param>
    /// <param name="y">目标 Y 坐标</param>
    /// <param name="duration">整段轨迹耗时，单位毫秒</param>
    /// <returns>0：失败 1：成功</returns>
    public int MoveToSmooth(int x, int y, int duration) 
        => OpMoveToSmooth(handle, x, y, duration);

    /// <summary>
    /// 移动指定窗口到指定位置
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <param name="x">指定的 X 坐标</param>
    /// <param name="y">指定的 Y 坐标</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int MoveWindow(IntPtr hwnd, int x, int y) 
        => OpMoveWindow(handle, hwnd, x, y);

    /// <summary>
    /// 返回规范化后的字库文本
    /// </summary>
    /// <param name="dict_info">字库文本，支持多行</param>
    /// <param name="ret"></param>
    /// <returns>返回保留下来的合法条目数量。</returns>
    public string NormalizeWordDict(string dict_info, out int ret) 
        => OpNormalizeWordDict(handle, dict_info, out ret);

    /// <summary>
    /// 识别屏幕范围(x1,y1,x2,y2)内符合 color_format 的字符串
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="color">颜色格式串，比如"FFFFFF-000000|CCCCCC-000000"每种颜色用"|"分割</param>
    /// <param name="sim">相似度,取值范围 0.1-1.0</param>
    /// <returns>返回识别到的字符串</returns>
    public string Ocr(int x1, int y1, int x2, int y2, string color, double sim) 
        => OpOcr(handle, x1, y1, x2, y2, color, sim);

    /// <summary>
    /// 识别屏幕范围(x1,y1,x2,y2)内的字符串，自动二值化，不需要指定颜色
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="sim">相似度,取值范围 0.1-1.0</param>
    /// <returns>返回识别到的字符串</returns>
    public string OcrAuto(int x1, int y1, int x2, int y2, double sim) 
        => OpOcrAuto(handle, x1, y1, x2, y2, sim);

    /// <summary>
    /// 从文件中识别图片，自动二值化，不需要指定颜色
    /// </summary>
    /// <param name="file_name">文件名</param>
    /// <param name="sim">相似度,取值范围 0.1-1.0</param>
    /// <returns>返回识别到的字符串</returns>
    public string OcrAutoFromFile(string file_name, double sim) 
        => OpOcrAutoFromFile(handle, file_name, sim);

    /// <summary>
    /// 该方法可以返回识别到的字符串，以及每个字符的坐标
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="color">颜色格式串，比如"FFFFFF-000000|CCCCCC-000000"每种颜色用"|"分割</param>
    /// <param name="sim">相似度,取值范围 0.1-1.0</param>
    /// <returns>返回识别到的字符串以及坐标</returns>
    public string OcrEx(int x1, int y1, int x2, int y2, string color, double sim) 
        => OpOcrEx(handle, x1, y1, x2, y2, color, sim);

    /// <summary>
    /// 从文件中识别图片
    /// </summary>
    /// <param name="file_name">文件名</param>
    /// <param name="color_format">颜色格式串</param>
    /// <param name="sim">相似度,取值范围 0.1-1.0</param>
    /// <returns>返回识别到的字符串</returns>
    public string OcrFromFile(string file_name, string color_format, double sim) 
        => OpOcrFromFile(handle, file_name, color_format, sim);

    /// <summary>
    /// 读取数据
    /// </summary>
    /// <param name="hwnd">窗口句柄，用于指定要从哪个窗口内读取数据</param>
    /// <param name="address">表示要读取数据的地址</param>
    /// <param name="size">要读取的数据的大小</param>
    /// <returns>读取到的数值</returns>
    public string ReadData(IntPtr hwnd, string address, int size) 
        => OpReadData(handle, hwnd, address, size);

    /// <summary>
    /// 读取双精度浮点数
    /// </summary>
    /// <param name="hwnd">窗口句柄</param>
    /// <param name="address">读取数据的地址</param>
    /// <param name="ret"></param>
    /// <returns>读取到的双精度浮点数，失败返回 0</returns>
    public int ReadDouble(IntPtr hwnd, string address, out double ret) 
        => OpReadDouble(handle, hwnd, address, out ret);

    /// <summary>
    /// 读取单精度浮点数
    /// </summary>
    /// <param name="hwnd">窗口句柄</param>
    /// <param name="address">读取数据的地址</param>
    /// <param name="ret"></param>
    /// <returns>读取到的单精度浮点数，失败返回 0</returns>
    public int ReadFloat(IntPtr hwnd, string address, out float ret) 
        => OpReadFloat(handle, hwnd, address, out ret);

    /// <summary>
    /// 读取整数
    /// </summary>
    /// <param name="hwnd">窗口句柄</param>
    /// <param name="address">读取数据的地址</param>
    /// <param name="type">整数类型，见上表</param>
    /// <param name="ret"></param>
    /// <returns>读取到的整数，失败返回 0</returns>
    public int ReadInt(IntPtr hwnd, string address, int type, out long ret) 
        => OpReadInt(handle, hwnd, address, type, out ret);

    /// <summary>
    /// 读取字符串
    /// </summary>
    /// <param name="hwnd">窗口句柄</param>
    /// <param name="address">读取数据的地址</param>
    /// <param name="type">字符串编码，见上表</param>
    /// <param name="len">读取字节数，0 表示自动到结尾</param>
    /// <returns>读取到的字符串，失败返回空字符串</returns>
    public string ReadString(IntPtr hwnd, string address, int type, int len) 
        => OpReadString(handle, hwnd, address, type, len);

    /// <summary>
    /// 返回重命名后的字库文本
    /// </summary>
    /// <param name="dict_info">字库文本，支持多行</param>
    /// <param name="words">新字名，字符数量必须和合法字库条目数量一致</param>
    /// <param name="ret"></param>
    /// <returns>返回重命名成功的条目数量。字库为空或数量不一致时返回 0。</returns>
    public string RenameWordDict(string dict_info, string words, out int ret) 
        => OpRenameWordDict(handle, dict_info, words, out ret);

    /// <summary>
    /// 按下鼠标右键
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int RightClick() 
        => OpRightClick(handle);

    /// <summary>
    /// 双击鼠标右键
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int RightDoubleClick() 
        => OpRightDoubleClick(handle);

    /// <summary>
    /// 按住鼠标右键
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int RightDown() 
        => OpRightDown(handle);

    /// <summary>
    /// 弹起鼠标右键
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int RightUp() 
        => OpRightUp(handle);

    /// <summary>
    /// 运行可执行文件,可指定模式，并返回启动后的进程 ID
    /// </summary>
    /// <param name="cmdline">指定的可执行程序全路径</param>
    /// <param name="mode">取值如下 0:普通模式 1:加强模式</param>
    /// <param name="pid">变参指针: 返回进程 ID</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int RunApp(string cmdline, int mode, out uint pid) 
        => OpRunApp(handle, cmdline, mode, out pid);

    /// <summary>
    /// 保存指定字库到文件
    /// </summary>
    /// <param name="idx">字库序号</param>
    /// <param name="file_name">文件名</param>
    /// <returns>0：失败 1：成功</returns>
    public int SaveDict(int idx, string file_name) 
        => OpSaveDict(handle, idx, file_name);

    /// <summary>
    /// 把屏幕坐标转换为窗口坐标
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <param name="x">变参指针: 屏幕 X 坐标</param>
    /// <param name="y">变参指针: 屏幕 Y 坐标</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int ScreenToClient(IntPtr hwnd, ref int x, ref int y) 
        => OpScreenToClient(handle, hwnd, ref x, ref y);

    /// <summary>
    /// 向指定窗口发送粘贴命令
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int SendPaste(IntPtr hwnd) 
        => OpSendPaste(handle, hwnd);

    /// <summary>
    /// 向指定窗口发送文本数据
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <param name="str">发送的文本数据</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int SendString(IntPtr hwnd, string str) 
        => OpSendString(handle, hwnd, str);

    /// <summary>
    /// 向指定窗口发送文本数据-输入法
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <param name="str">发送的文本数据</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int SendStringIme(IntPtr hwnd, string str) 
        => OpSendStringIme(handle, hwnd, str);

    /// <summary>
    /// 设置点阵 OCR 的二值图预处理。它只在使用本地点阵字库时生效，会影响 <code>Ocr/OcrEx/FindStr/FindStrEx</code> 和点阵制作接口；走 HTTP OCR 服务时不生效。
    /// </summary>
    /// <param name="mode">图片干净、字体较细</param>
    /// <param name="isolated_threshold">字体边缘有零散点</param>
    /// <param name="min_component_area">背景有小块干扰</param>
    /// <param name="bridge_gap">笔画有 1 像素断裂</param>
    /// <returns>0：失败 1：成功</returns>
    public int SetBinaryPreprocess(int mode, int isolated_threshold, int min_component_area, int bridge_gap) 
        => OpSetBinaryPreprocess(handle, mode, isolated_threshold, min_component_area, bridge_gap);

    /// <summary>
    /// 设置窗口客户区域的宽度和高度
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <param name="width">宽度</param>
    /// <param name="hight">高度</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int SetClientSize(IntPtr hwnd, int width, int hight) 
        => OpSetClientSize(handle, hwnd, width, hight);

    /// <summary>
    /// 设置剪贴板数据
    /// </summary>
    /// <param name="str">指设置剪贴板内容的字符串</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int SetClipboard(string str) 
        => OpSetClipboard(handle, str);

    /// <summary>
    /// 加载文件字库到指定槽位。<code>index</code> 范围为 0-99，最多 100 个槽位。支持 OP 二进制字库和大漠文本点阵字库。
    /// </summary>
    /// <param name="idx">字库的序号，取值为 0-99</param>
    /// <param name="file_name">字库文件名，支持 OP <code>.dict</code> 或大漠文本字库</param>
    /// <returns>0：失败 1：成功</returns>
    public int SetDict(int idx, string file_name) 
        => OpSetDict(handle, idx, file_name);

    /// <summary>
    /// 设置图像输入方式，默认窗口截图
    /// </summary>
    /// <param name="mode">图色输入模式 screen:默认的模式，表示使用显示器或者后台窗口 pic:指定输入模式为指定的图片,可以是相对路径,相对于 SetPath 的路径：pic:test.bmp,也可以是绝对路径: pic:d:\test\test.bmp mem:指定输入模式为内存图片，格式见下方说明</param>
    /// <returns>0：失败 1：成功</returns>
    public int SetDisplayInput(string mode) 
        => OpSetDisplayInput(handle, mode);

    /// <summary>
    /// 该函数旨在设置按键时，键盘按下和弹起之间的时间间隔。
    /// </summary>
    /// <param name="type">键盘类型，取值： "normal" | "normal.hd" | "windows" | "dx"</param>
    /// <param name="delay">指定键盘按下和弹起之间的时间间隔，单位通常为毫秒（milliseconds）</param>
    /// <returns>0：失败 1：成功</returns>
    public int SetKeypadDelay(string type, int delay) 
        => OpSetKeypadDelay(handle, type, delay);

    /// <summary>
    /// 把内存中的字库内容加载到指定槽位。该槽位会写入进程级共享字库，多个 OP 对象使用同一个 <code>index</code> 时可以直接复用。
    /// </summary>
    /// <param name="idx">字库的序号，取值为 0-99</param>
    /// <param name="data">字库内容数据，可为 OP <code>.dict</code> 文件字节、大漠文本字库内容或 OP 文本条目</param>
    /// <param name="size"></param>
    /// <returns>0：失败 1：成功</returns>
    public int SetMemDict(int idx, IntPtr data, int size) 
        => OpSetMemDict(handle, idx, data, size);

    /// <summary>
    /// 该函数旨在设置鼠标单击或双击时，鼠标按下和弹起之间的时间间隔。
    /// </summary>
    /// <param name="type">鼠标类型，取值： "normal" | "windows" | "dx"</param>
    /// <param name="delay">指定鼠标按下和弹起之间的时间间隔，单位通常为毫秒（milliseconds）</param>
    /// <returns>0：失败 1：成功</returns>
    public int SetMouseDelay(string type, int delay) 
        => OpSetMouseDelay(handle, type, delay);

    /// <summary>
    /// 设置鼠标轨迹参数。这个设置保存在当前对象里，后续的轨迹移动都会使用这组参数。
    /// </summary>
    /// <param name="mode">轨迹类型：0 默认，1 直线，2 贝塞尔曲线</param>
    /// <param name="min_duration">最小轨迹耗时，单位毫秒。<code>duration</code> 传 0 时会使用这个值</param>
    /// <param name="max_duration">最大轨迹耗时，单位毫秒。传 0 表示不限制</param>
    /// <param name="jitter">抖动幅度，范围 0-100。0 表示不做曲线偏移</param>
    /// <param name="start_delay">起步停顿，单位毫秒。移动前等待</param>
    /// <param name="end_delay">落点停顿，单位毫秒。<code>DragPath</code> 会在松开左键前等待</param>
    /// <returns>0：失败 1：成功</returns>
    public int SetMouseTrajectory(int mode, int min_duration, int max_duration, int jitter, int start_delay, int end_delay) 
        => OpSetMouseTrajectory(handle, mode, min_duration, max_duration, jitter, start_delay, end_delay);

    /// <summary>
    /// 设置 OCR HTTP 引擎
    /// </summary>
    /// <param name="path_of_engine">OCR 后端别名或 URL，可传 <code>tesseract</code>、<code>paddle</code> </param>
    /// <param name="dll_name">兼容参数，也可以传 OCR URL</param>
    /// <param name="argv"></param>
    /// <returns>0：失败 1：成功</returns>
    public int SetOcrEngine(string path_of_engine, string dll_name, string argv) 
        => OpSetOcrEngine(handle, path_of_engine, dll_name, argv);

    /// <summary>
    /// 设置全局路径。设置后，图片、字库等相对路径都会以此目录为基准。
    /// </summary>
    /// <param name="path">指定的路径。</param>
    /// <returns>0：表示操作失败 1：表示操作成功</returns>
    public int SetPath(string path) 
        => OpSetPath(handle, path);

    /// <summary>
    /// 设置屏幕数据模式
    /// </summary>
    /// <param name="mode">0：从上到下，默认值；1：从下到上</param>
    /// <returns>0：表示操作失败 1：表示操作成功</returns>
    public int SetScreenDataMode(int mode) 
        => OpSetScreenDataMode(handle, mode);

    /// <summary>
    /// 设置是否显示错误信息，默认打开。
    /// </summary>
    /// <param name="show_type">0：关闭，1：显示为信息框，2：保存到文件，3：输出到标准输出</param>
    /// <returns>0：表示操作失败 1：表示操作成功</returns>
    public int SetShowErrorMsg(int show_type) 
        => OpSetShowErrorMsg(handle, show_type);

    /// <summary>
    /// 设置窗口客户区域的宽度和高度
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <param name="width">宽度</param>
    /// <param name="height">高度</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int SetWindowSize(IntPtr hwnd, int width, int height) 
        => OpSetWindowSize(handle, hwnd, width, height);

    /// <summary>
    /// 设置窗口的状态
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <param name="flag">取值定义如下 0:关闭指定窗口 1:激活指定窗口 2:最小化指定窗口,但不激活 3:最小化指定窗口,并释放内存,但同时也会激活窗口 4:最大化指定窗口,同时激活窗口 5:恢复指定窗口 ,但不激活 6:隐藏指定窗口 7:显示指定窗口 8:置顶指定窗口 9:取消置顶指定窗口 10:禁止指定窗口 11:取消禁止指定窗口 12:恢复并激活指定窗口 13:强制结束窗口所在进程 14:闪烁指定的窗口 15:使指定的窗口获取输入焦点</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int SetWindowState(IntPtr hwnd, int flag) 
        => OpSetWindowState(handle, hwnd, flag);

    /// <summary>
    /// 设置窗口的标题
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <param name="title">标题</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int SetWindowText(IntPtr hwnd, string title) 
        => OpSetWindowText(handle, hwnd, title);

    /// <summary>
    /// 设置窗口的透明度
    /// </summary>
    /// <param name="hwnd">指定的窗口句柄</param>
    /// <param name="trans">透明度取值(0-255) 越小透明度越大 0 为完全透明(不可见) 255 为完全显示(不透明)</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int SetWindowTransparent(IntPtr hwnd, int trans) 
        => OpSetWindowTransparent(handle, hwnd, trans);

    /// <summary>
    /// 设置 YOLO HTTP 引擎
    /// </summary>
    /// <param name="path_of_engine">YOLO 后端别名或 URL，可传 <code>yolo</code>、<code>yolo11</code> 等</param>
    /// <param name="dll_name">兼容参数，也可以传 YOLO URL</param>
    /// <param name="argv"></param>
    /// <returns>0：失败 1：成功</returns>
    public int SetYoloEngine(string path_of_engine, string dll_name, string argv) 
        => OpSetYoloEngine(handle, path_of_engine, dll_name, argv);

    /// <summary>
    /// 设置休眠时间
    /// </summary>
    /// <param name="millseconds">休眠时间(毫秒)</param>
    /// <returns>0：表示操作失败 1：表示操作成功</returns>
    public int Sleep(int millseconds) 
        => OpSleep(handle, millseconds);

    /// <summary>
    /// 解除绑定窗口,并释放系统资源
    /// </summary>
    /// <returns>0: 失败 1: 成功</returns>
    public int UnBindWindow() 
        => OpUnBindWindow(handle);

    /// <summary>
    /// 选择当前使用的字库槽位，<code>index</code> 范围为 0-99。
    /// </summary>
    /// <param name="idx">字库的序号</param>
    /// <returns>0：失败 1：成功</returns>
    public int UseDict(int idx) 
        => OpUseDict(handle, idx);

    /// <summary>
    /// 获取当前 op 插件的版本号
    /// </summary>
    /// <returns>返回 op 插件的版本号</returns>
    public string Ver() 
        => OpVer();

    /// <summary>
    /// 等待指定的按键按下 (前台,不是后台)
    /// </summary>
    /// <param name="vk_code">虚拟按键码,当此值为：0，表示等待任意按键。 鼠标左键是：1,鼠标右键时：2,鼠标中键是：4</param>
    /// <param name="time_out">等待多久,单位毫秒. 如果是 0，表示一直等待</param>
    /// <returns>0：失败 1：成功</returns>
    public int WaitKey(int vk_code, int time_out) 
        => OpWaitKey(handle, vk_code, time_out);

    /// <summary>
    /// 垂直滚轮滚动指定距离
    /// </summary>
    /// <param name="delta">滚动距离。正数向上，负数向下，120 为一格滚轮</param>
    /// <returns>0：失败 1：成功</returns>
    public int Wheel(int delta) 
        => OpWheel(handle, delta);

    /// <summary>
    /// 滚轮向下滚
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int WheelDown() 
        => OpWheelDown(handle);

    /// <summary>
    /// 滚轮向上滚
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int WheelUp() 
        => OpWheelUp(handle);

    /// <summary>
    /// 运行可执行文件，可指定显示模式
    /// </summary>
    /// <param name="cmdline">指定的可执行程序全路径</param>
    /// <param name="cmdshow">取值如下 0:隐藏 1:用最近的大小和位置显示,激活</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int WinExec(string cmdline, int cmdshow) 
        => OpWinExec(handle, cmdline, cmdshow);

    /// <summary>
    /// 向某进程写入数据
    /// </summary>
    /// <param name="hwnd">窗口句柄，用于指定要在哪个窗口内写入数据</param>
    /// <param name="address">写入数据的地址</param>
    /// <param name="data">写入的数据，使用十六进制字符串</param>
    /// <param name="size">写入的数据的大小</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int WriteData(IntPtr hwnd, string address, string data, int size) 
        => OpWriteData(handle, hwnd, address, data, size);

    /// <summary>
    /// 写入双精度浮点数
    /// </summary>
    /// <param name="hwnd">窗口句柄</param>
    /// <param name="address">写入数据的地址</param>
    /// <param name="value">要写入的数值</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int WriteDouble(IntPtr hwnd, string address, double value) 
        => OpWriteDouble(handle, hwnd, address, value);

    /// <summary>
    /// 写入单精度浮点数
    /// </summary>
    /// <param name="hwnd">窗口句柄</param>
    /// <param name="address">写入数据的地址</param>
    /// <param name="value">要写入的数值</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int WriteFloat(IntPtr hwnd, string address, float value) 
        => OpWriteFloat(handle, hwnd, address, value);

    /// <summary>
    /// 写入整数
    /// </summary>
    /// <param name="hwnd">窗口句柄</param>
    /// <param name="address">写入数据的地址</param>
    /// <param name="type">整数类型，见上表</param>
    /// <param name="value">要写入的整数</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int WriteInt(IntPtr hwnd, string address, int type, long value) 
        => OpWriteInt(handle, hwnd, address, type, value);

    /// <summary>
    /// 写入字符串
    /// </summary>
    /// <param name="hwnd">窗口句柄</param>
    /// <param name="address">写入数据的地址</param>
    /// <param name="type">字符串编码，见上表</param>
    /// <param name="value">要写入的字符串</param>
    /// <returns>0: 失败 1: 成功</returns>
    public int WriteString(IntPtr hwnd, string address, int type, string value) 
        => OpWriteString(handle, hwnd, address, type, value);

    /// <summary>
    /// 按下鼠标侧键 1
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int XButton1Click() 
        => OpXButton1Click(handle);

    /// <summary>
    /// 双击鼠标侧键 1
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int XButton1DoubleClick() 
        => OpXButton1DoubleClick(handle);

    /// <summary>
    /// 按住鼠标侧键 1
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int XButton1Down() 
        => OpXButton1Down(handle);

    /// <summary>
    /// 弹起鼠标侧键 1
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int XButton1Up() 
        => OpXButton1Up(handle);

    /// <summary>
    /// 按下鼠标侧键 2
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int XButton2Click() 
        => OpXButton2Click(handle);

    /// <summary>
    /// 双击鼠标侧键 2
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int XButton2DoubleClick() 
        => OpXButton2DoubleClick(handle);

    /// <summary>
    /// 按住鼠标侧键 2
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int XButton2Down() 
        => OpXButton2Down(handle);

    /// <summary>
    /// 弹起鼠标侧键 2
    /// </summary>
    /// <returns>0：失败 1：成功</returns>
    public int XButton2Up() 
        => OpXButton2Up(handle);

    /// <summary>
    /// 返回检测结果 JSON 字符串
    /// </summary>
    /// <param name="x1">区域的左上 X 坐标</param>
    /// <param name="y1">区域的左上 Y 坐标</param>
    /// <param name="x2">区域的右下 X 坐标</param>
    /// <param name="y2">区域的右下 Y 坐标</param>
    /// <param name="conf">置信度阈值</param>
    /// <param name="iou">NMS 的 IOU 阈值</param>
    /// <param name="ret"></param>
    /// <returns>返回检测到的目标数量。请求失败、未绑定截图或检测失败时返回 0，<code>retjson</code> 为空。</returns>
    public string YoloDetect(int x1, int y1, int x2, int y2, double conf, double iou) 
        => OpYoloDetect(handle, x1, y1, x2, y2, conf, iou);

    /// <summary>
    /// 返回检测结果 JSON 字符串
    /// </summary>
    /// <param name="file_name">图片文件名</param>
    /// <param name="conf">置信度阈值</param>
    /// <param name="iou">NMS 的 IOU 阈值</param>
    /// <param name="ret"></param>
    /// <returns>返回检测到的目标数量。文件不存在、请求失败或检测失败时返回 0，<code>retjson</code> 为空。</returns>
    public string YoloDetectFromFile(string file_name, double conf, double iou) 
        => OpYoloDetectFromFile(handle, file_name, conf, iou);

    #region DLL Import Define
    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr OpCreate();

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern void OpDestroy(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpAddDict(IntPtr handle, int idx, string dict_info);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpAStarFindPath(IntPtr handle, int mapWidth, int mapHeight, string disable_points, int beginX, int beginY, int endX, int endY);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpBindWindow(IntPtr handle, IntPtr hwnd, string display, string mouse, string keypad, int mode);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpBindWindowEx(IntPtr handle, IntPtr display_hwnd, IntPtr input_hwnd, string display, string mouse, string keypad, int mode);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCapture(IntPtr handle, int x1, int y1, int x2, int y2, string file_name);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCapturePre(IntPtr handle, string file_name);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpCheckWordDict(IntPtr handle, string dict_info, out int ret);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpClearDict(IntPtr handle, int idx);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpClientToScreen(IntPtr handle, IntPtr hwnd, ref int x, ref int y);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCmpColor(IntPtr handle, int x, int y, string color, double sim);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvBlur(IntPtr handle, string src_file, string dst_file, string mode, int kernel_size);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvCLAHE(IntPtr handle, string src_file, string dst_file, double clip_limit, int tile_grid_size);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpCvConnectedComponents(IntPtr handle, string src_file, double min_area);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvCrop(IntPtr handle, string src_file, int x, int y, int width, int height, string dst_file);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvCropValid(IntPtr handle, string src_file, string dst_file);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvDenoise(IntPtr handle, string src_file, string dst_file);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpCvEdgeMatchTemplate(IntPtr handle, int x, int y, int width, int height, string template_name, double threshold);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvEqualize(IntPtr handle, string src_file, string dst_file);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpCvFeatureMatchTemplate(IntPtr handle, int x, int y, int width, int height, string template_name, double threshold);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpCvFindContours(IntPtr handle, string src_file, double min_area);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpCvGetAllTemplateNames(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpCvGetOpenCvVersion(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvGetTemplateCount(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvHasTemplate(IntPtr handle, string name);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvInRange(IntPtr handle, string src_file, string dst_file, string color_space, string lower, string upper);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvLoadMaskedTemplate(IntPtr handle, string name, string template_path, string mask_path);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvLoadTemplate(IntPtr handle, string name, string file_path);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvLoadTemplateList(IntPtr handle, string template_list);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpCvMatchAllTemplates(IntPtr handle, int x, int y, int width, int height, string template_names, double threshold, int dir, int strip_mode, int method, int color_mode);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpCvMatchAnyTemplate(IntPtr handle, int x, int y, int width, int height, string template_names, double threshold, int dir, int strip_mode, int method, int color_mode);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpCvMatchTemplate(IntPtr handle, int x, int y, int width, int height, string template_name, double threshold, int dir, int strip_mode, int method, int color_mode);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpCvMatchTemplateScale(IntPtr handle, int x, int y, int width, int height, string template_name, string scales, double threshold, int method, int color_mode);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvMorphology(IntPtr handle, string src_file, string dst_file, string mode, int kernel_size, int iterations);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvPreprocessPipeline(IntPtr handle, string src_file, string dst_file, string pipeline);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvRemoveAllTemplates(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvRemoveTemplate(IntPtr handle, string name);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvResize(IntPtr handle, string src_file, int width, int height, string dst_file);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpCvShapeMatchTemplate(IntPtr handle, int x, int y, int width, int height, string template_name, double threshold);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvSharpen(IntPtr handle, string src_file, string dst_file, double strength);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvThin(IntPtr handle, string src_file, string dst_file, string mode);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvThreshold(IntPtr handle, string src_file, string dst_file, double threshold, double max_value, string mode);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvToBinary(IntPtr handle, string src_file, string dst_file);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvToEdge(IntPtr handle, string src_file, string dst_file);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvToGray(IntPtr handle, string src_file, string dst_file);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpCvToOutline(IntPtr handle, string src_file, string dst_file);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpDelay(IntPtr handle, int mis);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpDelays(IntPtr handle, int mis_min, int mis_max);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpDragPath(IntPtr handle, string path, int duration);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpEnablePicCache(IntPtr handle, int enable);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpEnumProcess(IntPtr handle, string name);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpEnumWindow(IntPtr handle, IntPtr parent, string title, string class_name, int filter);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpEnumWindowByProcess(IntPtr handle, string process_name, string title, string class_name, int filter);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpExtractWordRects(IntPtr handle, int x1, int y1, int x2, int y2, string color, double sim, int min_word_h);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpExtractWordRectsEx(IntPtr handle, int x1, int y1, int x2, int y2, string color, double sim, int min_word_w, int min_word_h, int padding);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpFetchWord(IntPtr handle, int x1, int y1, int x2, int y2, string color, string word);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpFetchWordEx(IntPtr handle, int x1, int y1, int x2, int y2, string color, double sim, string word);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpFetchWords(IntPtr handle, int x1, int y1, int x2, int y2, string color, double sim, string words, int min_word_h);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpFetchWordsByRects(IntPtr handle, int x1, int y1, int x2, int y2, string color, double sim, string words, string rects);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpFetchWordsEx(IntPtr handle, int x1, int y1, int x2, int y2, string color, double sim, string words, int min_word_w, int min_word_h, int padding);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpFindColor(IntPtr handle, int x1, int y1, int x2, int y2, string color, double sim, int dir, out int x, out int y);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpFindColorBlock(IntPtr handle, int x1, int y1, int x2, int y2, string color, double sim, int count, int height, int width, out int x, out int y);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpFindColorBlockEx(IntPtr handle, int x1, int y1, int x2, int y2, string color, double sim, int count, int height, int width);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpFindColorEx(IntPtr handle, int x1, int y1, int x2, int y2, string color, double sim, int dir);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpFindLine(IntPtr handle, int x1, int y1, int x2, int y2, string color, double sim);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpFindMultiColor(IntPtr handle, int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir, out int x, out int y);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpFindMultiColorEx(IntPtr handle, int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpFindNearestPos(IntPtr handle, string all_pos, int type, int x, int y);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpFindPic(IntPtr handle, int x1, int y1, int x2, int y2, string files, string delta_color, double sim, int dir, out int x, out int y);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpFindPicEx(IntPtr handle, int x1, int y1, int x2, int y2, string files, string delta_color, double sim, int dir);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpFindPicExS(IntPtr handle, int x1, int y1, int x2, int y2, string files, string delta_color, double sim, int dir);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpFindStr(IntPtr handle, int x1, int y1, int x2, int y2, string strs, string color, double sim, out int retx, out int rety);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpFindStrEx(IntPtr handle, int x1, int y1, int x2, int y2, string strs, string color, double sim);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr OpFindWindow(IntPtr handle, string class_name, string title);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr OpFindWindowByProcess(IntPtr handle, string process_name, string class_name, string title);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr OpFindWindowByProcessId(IntPtr handle, int process_id, string class_name, string title);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr OpFindWindowEx(IntPtr handle, IntPtr parent, string class_name, string title);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpFreePic(IntPtr handle, string file_name);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpGetBasePath(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpGetBinaryPreprocess(IntPtr handle, out int mode, out int isolated_threshold, out int min_component_area, out int bridge_gap);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpGetBinaryPreview(IntPtr handle, int x1, int y1, int x2, int y2, string color, double sim, out int ret);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr OpGetBindWindow(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpGetClientRect(IntPtr handle, IntPtr hwnd, out int x1, out int y1, out int x2, out int y2);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpGetClientSize(IntPtr handle, IntPtr hwnd, out int width, out int height);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpGetClipboard(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpGetCmdStr(IntPtr handle, string cmd, int millseconds);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpGetColor(IntPtr handle, int x, int y);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpGetColorNum(IntPtr handle, int x1, int y1, int x2, int y2, string color, double sim);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpGetCursorPos(IntPtr handle, out int x, out int y);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpGetCursorShape(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpGetDict(IntPtr handle, int idx, int font_index);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpGetDictCount(IntPtr handle, int idx);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr OpGetForegroundFocus(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr OpGetForegroundWindow(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpGetID(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpGetKeyState(IntPtr handle, int vk_code);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpGetLastError(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr OpGetMousePointWindow(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpGetNowDict(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpGetPath(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpGetPicSize(IntPtr handle, string pic_name, out int width, out int height);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr OpGetPointWindow(IntPtr handle, int x, int y);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpGetProcessInfo(IntPtr handle, int pid);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr OpGetScreenData(IntPtr handle, int x1, int y1, int x2, int y2, out int ret);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr OpGetScreenDataBmp(IntPtr handle, int x1, int y1, int x2, int y2, out int size, out int ret);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern void OpGetScreenFrameInfo(IntPtr handle, out int frame_id, out int time);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr OpGetSpecialWindow(IntPtr handle, int flag);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr OpGetWindow(IntPtr handle, IntPtr hwnd, int flag);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpGetWindowClass(IntPtr handle, IntPtr hwnd);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpGetWindowProcessId(IntPtr handle, IntPtr hwnd);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpGetWindowProcessPath(IntPtr handle, IntPtr hwnd);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpGetWindowRect(IntPtr handle, IntPtr hwnd, out int x1, out int y1, out int x2, out int y2);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpGetWindowState(IntPtr handle, IntPtr hwnd, int flag);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpGetWindowTitle(IntPtr handle, IntPtr hwnd);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpGetWordPreview(IntPtr handle, string dict_info, out int ret);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpGetWordResultCount(IntPtr handle, string result);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpGetWordResultPos(IntPtr handle, string result, int index, out int x, out int y);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpGetWordResultStr(IntPtr handle, string result, int index);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpGetWordsNoDict(IntPtr handle, int x1, int y1, int x2, int y2, string color);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpHWheel(IntPtr handle, int delta);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpInjectDll(IntPtr handle, string process_name, string dll_name);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpIsBind(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpKeyDown(IntPtr handle, int vk_code);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpKeyDownChar(IntPtr handle, string vk_code);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpKeyPress(IntPtr handle, int vk_code);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpKeyPressChar(IntPtr handle, string vk_code);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpKeyPressStr(IntPtr handle, string key_str, int delay);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpKeyUp(IntPtr handle, int vk_code);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpKeyUpChar(IntPtr handle, string vk_code);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpLayoutWindows(IntPtr handle, string hwnds, int layout_type, int columns, int start_x, int start_y, int gap_x, int gap_y, int size_mode, int window_width, int window_height, int anchor_mode);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpLeftClick(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpLeftDoubleClick(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpLeftDown(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpLeftUp(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpLoadMemPic(IntPtr handle, string file_name, IntPtr data, int size);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpLoadPic(IntPtr handle, string file_name);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpLockInput(IntPtr handle, int lock_);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpMatchPicName(IntPtr handle, string pic_name);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpMiddleClick(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpMiddleDoubleClick(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpMiddleDown(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpMiddleUp(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpMovePath(IntPtr handle, string path, int duration);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpMoveR(IntPtr handle, int x, int y);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpMoveTo(IntPtr handle, int x, int y);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpMoveToEx(IntPtr handle, int x, int y, int w, int h);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpMoveToExSmooth(IntPtr handle, int x, int y, int w, int h, int duration);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpMoveToSmooth(IntPtr handle, int x, int y, int duration);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpMoveWindow(IntPtr handle, IntPtr hwnd, int x, int y);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpNormalizeWordDict(IntPtr handle, string dict_info, out int ret);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpOcr(IntPtr handle, int x1, int y1, int x2, int y2, string color, double sim);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpOcrAuto(IntPtr handle, int x1, int y1, int x2, int y2, double sim);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpOcrAutoFromFile(IntPtr handle, string file_name, double sim);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpOcrEx(IntPtr handle, int x1, int y1, int x2, int y2, string color, double sim);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpOcrFromFile(IntPtr handle, string file_name, string color_format, double sim);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpReadData(IntPtr handle, IntPtr hwnd, string address, int size);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpReadDouble(IntPtr handle, IntPtr hwnd, string address, out double ret);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpReadFloat(IntPtr handle, IntPtr hwnd, string address, out float ret);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpReadInt(IntPtr handle, IntPtr hwnd, string address, int type, out long ret);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpReadString(IntPtr handle, IntPtr hwnd, string address, int type, int len);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpRenameWordDict(IntPtr handle, string dict_info, string words, out int ret);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpRightClick(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpRightDoubleClick(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpRightDown(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpRightUp(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpRunApp(IntPtr handle, string cmdline, int mode, out uint pid);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSaveDict(IntPtr handle, int idx, string file_name);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpScreenToClient(IntPtr handle, IntPtr hwnd, ref int x, ref int y);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSendPaste(IntPtr handle, IntPtr hwnd);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSendString(IntPtr handle, IntPtr hwnd, string str);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSendStringIme(IntPtr handle, IntPtr hwnd, string str);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSetBinaryPreprocess(IntPtr handle, int mode, int isolated_threshold, int min_component_area, int bridge_gap);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSetClientSize(IntPtr handle, IntPtr hwnd, int width, int hight);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSetClipboard(IntPtr handle, string str);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSetDict(IntPtr handle, int idx, string file_name);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSetDisplayInput(IntPtr handle, string mode);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSetKeypadDelay(IntPtr handle, string type, int delay);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSetMemDict(IntPtr handle, int idx, IntPtr data, int size);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSetMouseDelay(IntPtr handle, string type, int delay);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSetMouseTrajectory(IntPtr handle, int mode, int min_duration, int max_duration, int jitter, int start_delay, int end_delay);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSetOcrEngine(IntPtr handle, string path_of_engine, string dll_name, string argv);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSetPath(IntPtr handle, string path);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSetScreenDataMode(IntPtr handle, int mode);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSetShowErrorMsg(IntPtr handle, int show_type);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSetWindowSize(IntPtr handle, IntPtr hwnd, int width, int height);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSetWindowState(IntPtr handle, IntPtr hwnd, int flag);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSetWindowText(IntPtr handle, IntPtr hwnd, string title);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSetWindowTransparent(IntPtr handle, IntPtr hwnd, int trans);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSetYoloEngine(IntPtr handle, string path_of_engine, string dll_name, string argv);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpSleep(IntPtr handle, int millseconds);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpUnBindWindow(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpUseDict(IntPtr handle, int idx);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpVer();

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpWaitKey(IntPtr handle, int vk_code, int time_out);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpWheel(IntPtr handle, int delta);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpWheelDown(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpWheelUp(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpWinExec(IntPtr handle, string cmdline, int cmdshow);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpWriteData(IntPtr handle, IntPtr hwnd, string address, string data, int size);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpWriteDouble(IntPtr handle, IntPtr hwnd, string address, double value);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpWriteFloat(IntPtr handle, IntPtr hwnd, string address, float value);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpWriteInt(IntPtr handle, IntPtr hwnd, string address, int type, long value);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpWriteString(IntPtr handle, IntPtr hwnd, string address, int type, string value);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpXButton1Click(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpXButton1DoubleClick(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpXButton1Down(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpXButton1Up(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpXButton2Click(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpXButton2DoubleClick(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpXButton2Down(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpXButton2Up(IntPtr handle);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpYoloDetect(IntPtr handle, int x1, int y1, int x2, int y2, double conf, double iou);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    private static extern string OpYoloDetectFromFile(IntPtr handle, string file_name, double conf, double iou);

    #endregion
}