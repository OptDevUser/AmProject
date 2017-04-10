Imports System.Runtime.InteropServices


Public Class cIMCHandle
    Implements IDisposable
    Implements InterfaceHandle




#Region "IMC 资讯"
    '状态值
    Public Enum IMC_STATUS
        IMC_OK = 0                     '成功
        IMC_SEND_FAIL                  '数据发送失败
        IMC_READ_FAIL                  '数据接收失败
        IMC_TIME_OUT                   '数据发送接收超时
        IMC_DEVICE_NOT_OPEN            '设备没有打开
        IMC_DEVICE_NOT_FOUND           '设备没有找到,用于打开设备时
        IMC_INVALID_HANDLE             '无效的设备句柄
        IMC_INVALID_PARAM              '无效的参数
        IMC_INVALID_AXIS               '无效的轴号
        IMC_INVALID_FIFO               '无效的FIFO
        IMC_FIFO_FULL                  'FIFO满
        IMC_FIFO_NULL                  'FIFO空
        IMC_PARAM_READ_ONLY            '只读参数
        IMC_OUT_OF_RANGE               '传递进来的函数参数值超出范围
        IMC_CHECK_ERROR                '校验错误
        IMC_VERSION_ERROR              '函数库版本与硬件版本不匹配
        IMC_OTHER_ERROR                '其他错误值
        IMC_PASSWORD_ERROR             '密码错误
        IMC_RBFIFO_EMPTY               'RBFIFO空
    End Enum

    Private Enum IMC_EventType
        IMC_Allways = 0     '每个周期都执行事件指令，即无条件事件
        IMC_Edge_Zero       '当前一条无条件事件指令的结果 由“不等于 0”变为“ 等于 0”时执行事件指令
        IMC_Edge_NotZero    '当前一条无条件事件指令的结果 由“等于 0”变为“不 等于 0”时执行事件指令
        IMC_Edge_Great      '当前一条无条件执行事件比较运算 (CMP32,CMP32i, CMP48,CMP48i) ，且结果由“ ≤0”变为“ >0 ”时执行事件指令
        IMC_Edge_GreatEqu   '当前一条无条件执行事件比较运算 (CMP32,CMP32i, CMP48,CMP48i) ，且结果由“ <0 ”变为“ ≥0”时执行事件指令
        IMC_Edge_Little     '当前一条无条件执行事件比较运算 (CMP32,CMP32i, CMP48,CMP48i) ，且结果由“ ≥0”变为“ <0”时执行事件指令
        IMC_Edge_Carry      '若前一条无件事指令由“无进位或借位”变为“有进位或借位”时执行事件指令
        IMC_Edge_NotCarry   '若前一条无件事指令由“有进位或借位”变为“无进位或借位”时执行事件指令

        IMC_IF_Zero         '若前一条无条件事件指令的结果等于0时执行事件指令
        IMC_IF_NotZero      '若前一条无条件事件指令的结果不等于 0时执行事件指令
        IMC_IF_Great        '若前一条无条件执行事比较运算 (CMP32,CMP32i, CMP48,CMP48i) ，且 结果 > 0时执行事件指令
        IMC_IF_GreatEqu     '若前一条无条件执行事比较运算 (CMP32,CMP32i, CMP48,CMP48i) ，且 结果 >= 0时执行事件指令
        IMC_IF_Little       '若前一条无条件执行事比较运算 (CMP32,CMP32i, CMP48,CMP48i) ，且 结果 < 0时执行事件指令
        IMC_IF_Carry        '若前一条无件事指令发生进位或借位时执行事件指令
        IMC_IF_NotCarry     '若前一条无件事指令不发生进位或借位时执行事件指令。发生该事件的情况与IMC_IF_Carry相反
    End Enum


    Private Enum IMC_EVENT_CMD
        CMD_ADD32 = 0   '两个32bit参数相加
        CMD_ADD32i      '32bit参数 加 32bit立即数
        CMD_ADD48       '两个48bit参数相加 
        CMD_ADD48i      '48bit参数 加 48bit立即数
        CMD_CMP32       '两个 32bit参数相比较
        CMD_CMP32i      '32bit参数 与 32bit立即数 相比较
        CMD_CMP48       '两个 48bit参数相比较
        CMD_CMP48i      '48bit参数 与 48bit立即数 相比较
        CMD_SCA32       '
        CMD_SCA32i      '
        CMD_SCA48       '
        CMD_SCA48i      '
        CMD_MUL32L      '32bit参数 乘以 32bit参数 其结果取低 32bit
        CMD_MUL32iL     '32bit参数 乘以 立即数 其结果取低 32bit
        CMD_MUL32A      '32bit参数 乘以 32bit参数 其结果取低 48bit
        CMD_MUL32iA     '32bit参数 乘以 立即数 其结果取低 48bit
        CMD_COP16       '拷贝 16bit参数
        CMD_COP32       '拷贝 32bit参数
        CMD_COP48       '拷贝 48bit参数
        CMD_SET16       '设置 16bit参数
        CMD_SET32       '设置 32bit参数
        CMD_SET48       '设置 48bit参数
        CMD_OR16        '参数 OR 参数
        CMD_OR16i       '参数 OR 立即数
        CMD_OR16B       '参数 OR 参数  其结果转换为BOOL类型
        CMD_OR16iB      '参数 OR 立即数  其结果转换为BOOL类型
        CMD_AND16       '参数 AND 参数
        CMD_AND16i      '参数 AND 立即数
        CMD_AND16B      '参数 AND 参数  其结果转换为BOOL类型
        CMD_AND16iB     '参数 AND 立即数  其结果转换为BOOL类型
        CMD_XOR16       '参数 XOR 参数
        CMD_XOR16i      '参数 XOR 立即数
        CMD_XOR16B      '参数 XOR 参数 其结果转换为BOOL类型
        CMD_XOR16iB     '参数 XOR 立即数 其结果转换为BOOL类型
    End Enum

    Public Enum TYPE_FIFO
        SEL_IFIFO = 0
        SEL_QFIFO
        SEL_PFIFO1
        SEL_PFIFO2
        SEL_CFIFO
    End Enum

    Private Structure IMC_param
        Dim Src2_loc As Short       '源参数2
        Dim Src2_axis As Short      '源参数2所属的轴号
        Dim reserve As Integer      '保留
    End Structure
    Private Structure Data16
        Dim data As Short           '16位宽的数据
        Dim reserve1 As Short       '保留
        Dim reserve2 As Integer     '保留
    End Structure
    Private Structure Data32
        Dim data As Integer         '32位宽的数据
        Dim reserve As Integer      '保留
    End Structure


    <Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Explicit)> _
    Private Structure Src2_union
        <FieldOffset(0)> Dim param As IMC_param
        <FieldOffset(0)> Dim data16 As Data16
        <FieldOffset(0)> Dim data32 As Data32
        <FieldOffset(0)> Dim data48 As Long          '48位宽的数据
    End Structure

    Private Structure EventInfo
        Dim EventCMD As Short           '事件指令，即枚举类型IMC_PATH_EVENT_CMD中的值
        Dim EventType As Short          '事件格式，即枚举类型IMC_EventType中的值
        Dim Src1_loc As Short               '源参数1
        Dim Src1_axis As Short          '源参数1所属的轴号
        Dim Src2 As Src2_union
        Dim dest_loc As Short               '目标参数
        Dim dest_axis As Short          '目标参数所属的轴号
        Dim reserve As Integer          '保留
    End Structure

    Private Structure DIST_AXIS
        Dim dist As Integer
        Dim axis As Integer
        Dim reserve As Integer
    End Structure

    Private Const AxisNo = 6


    <System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)> _
    Private Structure NIC_DESCRIPTION
        <System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=256, ArraySubType:=System.Runtime.InteropServices.UnmanagedType.Struct)> _
        Dim description() As Char
    End Structure
    <System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)> _
    Private Structure NIC_INFO
        <System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=16, ArraySubType:=System.Runtime.InteropServices.UnmanagedType.Struct)> _
        Dim description() As NIC_DESCRIPTION
    End Structure



    <System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)> _
    Private Structure PFIFOSegData
        Dim datanum As Integer      'SegEndData_x ~ SegEndData_m成员中有用数据个数
        '每段的终点数据
        Dim SegEndData_x As Integer
        Dim SegEndData_y As Integer
        Dim SegEndData_z As Integer
        Dim SegEndData_a As Integer
        Dim SegEndData_b As Integer
        Dim SegEndData_c As Integer
        Dim SegEndData_d As Integer
        Dim SegEndData_e As Integer
        Dim SegEndData_f As Integer
        Dim SegEndData_g As Integer
        Dim SegEndData_h As Integer
        Dim SegEndData_i As Integer
        Dim SegEndData_j As Integer
        Dim SegEndData_k As Integer
        Dim SegEndData_l As Integer
        Dim SegEndData_m As Integer
        Dim CenterX As Integer      '圆弧路径圆心的横坐标
        Dim CenterY As Integer      '圆弧路径圆心的纵坐标
        Dim dir As Integer          '0:顺时针方向，  -1：逆时针方向
    End Structure

    Private Structure PFIFOSegInfo
        Dim SegTgVel As Integer     '目标速度
        Dim SegEndVel As Integer    '终点速度
        Dim data As PFIFOSegData     '段数据
    End Structure

    <System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)> _
    Private Structure WR_MUL_DES
        Dim addr As Short      '参数地址
        Dim axis As Short       '轴号
        Dim len As Short        '//参数长度（单位：字（16位宽）, 其值为1、2、3； 1:表示一个字（short） 2:表示2个字（long) 3:表示3个字（））
        Dim data_0 As UShort     '写或读回的数据
        Dim data_1 As Short     '写或读回的数据
        Dim data_2 As Short     '写或读回的数据
        Dim data_3 As Short     '写或读回的数据
    End Structure



    '导入动态链接库中的函数
    Private Declare Function IMC_Open Lib "C:\DLL\IMCnet.dll" (ByRef Handle As Integer, ByVal netcardsel As Integer, ByVal imcid As Integer) As IMC_STATUS
    Private Declare Function IMC_FindNetCard Lib "C:\DLL\IMCnet.dll" (ByRef info As NIC_INFO, ByRef num As Integer) As IMC_STATUS
    Private Declare Function IMC_Close Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_OpenUsePassword Lib "C:\DLL\IMCnet.dll" (ByRef Handle As Integer, ByVal netcardsel As Integer, ByVal imcid As Integer, ByVal password As String) As IMC_STATUS


    '
    Private Declare Function IMC_SetMulParam Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByRef des As WR_MUL_DES, ByVal NumofArr As Short, ByVal fsel As Integer) As IMC_STATUS
    '
    Public Declare Function IMC_SetParam16 Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal paramaddr As Short, ByVal data As Short, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_SetParam32 Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal paramaddr As Short, ByVal data As Integer, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_SetParam48 Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal paramaddr As Short, ByVal data As Long, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Public Declare Function IMC_GetParam16 Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal paramaddr As Short, ByRef data As Short, ByVal axis As Integer) As IMC_STATUS
    '
    Public Declare Function IMC_GetParam32 Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal paramaddr As Short, ByRef data As Integer, ByVal axis As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_GetParam48 Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal paramaddr As Short, ByRef data As Long, ByVal axis As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_GetMulParam Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByRef des As WR_MUL_DES, ByVal NumofArr As Short) As IMC_STATUS
    '
    Private Declare Function IMC_GetParamBit Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal paramaddr As Short, ByRef data As Short, ByVal bit As Short, ByVal axis As Integer) As IMC_STATUS


    '
    Private Declare Function IMC_SetParamBit Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal paramaddr As Short, ByVal bit As Short, ByVal data As Short, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_TurnParamBit Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal paramaddr As Short, ByVal bit As Short, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_ORXORParam Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal paramaddr As Short, ByVal ORdata As Short, ByVal XORdata As Short, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS

    '
    Private Declare Function IMC_AddLineN Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByRef data As PFIFOSegData, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_AddLineNWithVel Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByRef data As PFIFOSegInfo, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_AddArcLine Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByRef data As PFIFOSegData, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_AddArcLineWithVel Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByRef data As PFIFOSegInfo, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_AddArc Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal Endx As Integer, ByVal Endy As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal dir As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_AddArcWithVel Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal TgVel As Integer, ByVal EndVel As Integer, ByVal Endx As Integer, ByVal Endy As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal dir As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_AddSpiral Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal Endx As Integer, ByVal Endy As Integer, ByVal EndLine As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal dir As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_AddSpiralWithVel Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal TgVel As Integer, ByVal EndVel As Integer, ByVal Endx As Integer, ByVal Endy As Integer, ByVal EndLine As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal dir As Integer, ByVal fsel As Integer) As IMC_STATUS


    '
    Private Declare Function IMC_WaitParamBit Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal paramloc As Short, ByVal bit As Short, ByVal data As Short, ByVal timeout As Integer, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_WaitParamMask Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal paramloc As Short, ByVal mask As Short, ByVal data As Short, ByVal timeout As Integer, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_WaitParam Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal paramloc As Short, ByVal data As Short, ByVal timeout As Integer, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_WaitTime Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal time As Short, ByVal fsel As Integer) As IMC_STATUS


    '
    Private Declare Function IMC_InstallEvent Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByRef data As EventInfo, ByVal num As Short, ByVal fsel As Integer) As IMC_STATUS

    '    
    '
    Private Declare Function IMC_PutContourData Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByRef pdata As Short, ByVal sizeofArr As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_GetCapData Lib "C:\DLL\IMCnet.dll" (ByVal handle As Integer, ByVal rdnum As Integer, ByRef pdata As Integer, ByRef dataNum As Integer, ByRef lastNum As Integer, ByVal axis As Integer) As IMC_STATUS

    '
    Private Declare Function IMC_ClearFIFO Lib "C:\DLL\IMCnet.dll" (ByVal handle As Integer, ByVal fsel As Integer) As IMC_STATUS

    '功能函数

    '
    Private Declare Function IMC_MoveAbsolute Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal pos As Integer, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_MoveRelative Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal pos As Integer, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_MoveSuperimposed Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal dist As Integer, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_Phasing Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal dist As Integer, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_MoveVelocity Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal vel As Integer, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_HomeSwitch1 Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal direction As Short, ByVal RiseEdge As Short, ByVal stops As Short, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_HomeSwitch2 Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal direction As Short, ByVal RiseEdge As Short, ByVal stops As Short, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_HomeSwitch3 Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal direction As Short, ByVal RiseEdge As Short, ByVal stops As Short, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_HomeSwitchIndex1 Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal direction As Short, ByVal RiseEdge As Short, ByVal stops As Short, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_HomeSwitchIndex2 Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal direction As Short, ByVal RiseEdge As Short, ByVal stops As Short, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_HomeSwitchIndex3 Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal direction As Short, ByVal RiseEdge As Short, ByVal stops As Short, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_HomeIndex Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal direction As Short, ByVal stops As Short, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_GearFree Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal ratio As Double, ByVal master As Integer, ByVal followtype As Integer, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_GearInDist Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal ratio As Double, ByVal master As Integer, ByVal sourcetype As Integer, ByVal syAxisNo As Integer, ByVal synsourcetype As Integer, ByVal syndist As Integer, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_GearInTime Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal ratio As Double, ByVal master As Integer, ByVal sourcetype As Integer, ByVal syntime As Integer, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS

    '
    Private Declare Function IMC_HandWheel Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal ratio As Double, ByVal encsaxis As Integer, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_TgvelInDist Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal refdist As Integer, ByVal refaxis As Integer, ByVal tgvel As Integer, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_TgvelInTime Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal time As Integer, ByVal tgvel As Integer, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_MoveInDist Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal refdist As Integer, ByVal refaxis As Integer, ByVal movedist As Integer, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS
    '
    Private Declare Function IMC_MoveInTime Lib "C:\DLL\IMCnet.dll" (ByVal Handle As Integer, ByVal time As Integer, ByVal movedist As Integer, ByVal axis As Integer, ByVal fsel As Integer) As IMC_STATUS



    '***********************************************************************************************************/
    '       此头文件为iMC参数地址的宏定义                                                                      */
    '       格式：                                                                                             */
    '       '描述                                                                                              */
    '       Public Const   参数名Loc =      地址     ' 轴或全局参数  数据格式                                  */
    '                                                                                                          */
    '       其中“参数名”是指在iMC的参数名，其后加Loc表示该参数的地址的宏定义                                 */
    '                                                                                                          */
    '       字母A表示轴参数，字母G表示全局参数                                                                 */
    '                                                                                                          */
    '       iMC中共有以下几种数据格式的类型：                                                                  */
    '       S32：32位带符号位的整数，即小数部分的位数为0，参数值的范围为：[-2147483648,2147483647]。           */
    '       U32：32位无符号位的整数，即小数部分的位数为0，参数值的范围为：[0, 4294967295]。                    */
    '       S16：16位带符号位的整数，即小数部分的位数为0，参数值的范围为：[-32768,32767]。                     */
    '       U16：16位无符号位的整数，即小数部分的位数为0，参数值的范围为：[0, 65535]。                         */
    '       F16：16位标志参数，仅取两个值：0或FFFFh。                                                          */
    '       R16：16位寄存器，各位域具有具体的意义，部分位域需设置。                                            */
    '       S16.32：48位带符号位，高16位为整数部分，低32位为小数部分，参数值的范围：[-32768.0,32767.999999999767] */
    '       U16.32：48位无符号位，高16位为整数部分，低32位为小数部分，参数值的范围：[0.0,65535.999999999767]   */
    '       S16.16：32位带符号位，高16位为整数部分，低16位为小数部分，参数值的范围：[-32768.0,32767.999984741211]  */
    '       U16.16：32位无符号位，高16位为整数部分，低32位为小数部分，参数值的范围：[0.0,65535.999984741211]。 */
    '       S0.16：16位有符号位，16位为小数部分。                                                              */
    '       因此，iMC中的参数值所表示的实际值为：                                                              */
    '       实际值=参数值/2^n                                                                                  */
    '       其中n为小数部分的位数。                                                                            */
    '       例如，对于一个S32格式的数，“00018000h”（h表示十六进制表示）表示的十进制的值为98304/2^0 = 98304； */
    '       对于一个S16.16格式的数，“00018000h”表示的十进制的值为98304/2^16 = 1.5。                          */
    '***********************************************************************************************************/

    '主坐标系（MCS）点到点参数
    '********************************************************************************************************/
    '当前规划速度（主坐标系）
    Private Const mcsvelLoc = 4                                      'A              S16.16

    '连续速度运动的目标速度（主坐标系）
    Private Const mcstgvelLoc = 6                                    'A              S16.16

    '主坐标系是否处于速度斜升过程中（加速或减速）。FFFFh：处于速度斜升过程，0：等于目标速度运行。
    '另：电子齿轮运动时，可以判断从动轴是否已达到传动速度，即是否达到主动轴速度乘以传动比率的值。0：达到，FFFFh：未达到
    Private Const mcsslopeLoc = 8                                    'A              F16

    '主坐标系的指令位置
    Private Const mcsposLoc = 10                                     'A              S32

    '绝对目标位置（主坐标系）
    Private Const mcstgposLoc = 12                                   'A              S32

    '目标移动距离（主坐标系点到点运动）
    Private Const mcsdistLoc = 14                                    'A              S32

    '点到点运动的最大速度（主坐标系）
    Private Const mcsmaxvelLoc = 16                                  'A              S16.16

    '加速度（主坐标系）
    Private Const mcsaccelLoc = 18                                   'A              S16.16

    '减速度（主坐标系）
    Private Const mcsdecelLoc = 20                                   'A              S16.16

    '点到点运动的模式，0：普通模式，FFFFh：跟踪模式（主坐标系）
    Private Const mcstrackLoc = 22                                   'A              F16

    '写入FFFFh启动点到点运动，写入零，停止当前的点到点运动（主坐标系）
    Private Const mcsgoLoc = 23                                      'A              F16

    '标志主坐标系是否规划运动中，0：规划运动已停止，FFFFh：规划运动中
    Private Const mcsmovingLoc = 25                                  'A              F16


    '********************************************************************************************************/
    '辅坐标系（PCS）点到点参数

    '当前规划速度（辅坐标系）
    Private Const pcsvelLoc = 27                                     'A              S16.16

    '连续速度运动的目标速度（辅坐标系）。
    Private Const pcstgvelLoc = 29                                   'A              S16.16

    '标志辅坐标系是否处于速度斜升过程中（加速或减速）。FFFFh：处于速度斜升过程，0：等于目标速度运行
    Private Const pcsslopeLoc = 31                                   'A              F16

    '指令位置（辅坐标系）
    Private Const pcsposLoc = 33                                     'A              S32

    '绝对目标位置（辅坐标系）
    Private Const pcstgposLoc = 35                                   'A              S32

    '目标移动距离（辅坐标系点到点运动）
    Private Const pcsdistLoc = 37                                    'A              S32

    '点到点运动的最大速度（辅坐标系）
    Private Const pcsmaxvelLoc = 39                                  'A              S16.16

    '加速度（辅坐标系）。
    Private Const pcsaccelLoc = 41                                   'A              S16.16

    '减速度（辅坐标系）。
    Private Const pcsdecelLoc = 43                                   'A              S16.16

    '点到点运动的模式，0：普通模式，1：跟踪模式（辅坐标系）。
    Private Const pcstrackLoc = 45                                   'A              F16

    '写入FFFFh启动点到点运动，写入零，停止当前的点到点运动（辅坐标系）。
    Private Const pcsgoLoc = 46                                      'A              F16

    '标志辅坐标系是否规划运动中，0：规划运动已停止，FFFFh：规划运动中。
    Private Const pcsmovingLoc = 48                                  'A              F16


    '当前指令位置，是主、辅坐标系目标位置叠加并经过运动平滑后总的指令位置。
    Private Const curposLoc = 225                                    'A              S32

    '当前速度，是主、辅坐标系的速度叠加并经过运动平滑后总的速度。
    Private Const curvelLoc = 227                                    'A              S16.16

    '0：辅坐标系移动的距离累加到主坐标系的目标位置mcstgpos，
    '非零：辅坐标系移动的距离不累加到主坐标系的目标位置mcstgpos
    Private Const shiftmasterLoc = 174                               'A              F16

    '********************************************************************************************************/
    '主编码器

    '主编码器的倍率因子，应为正值。
    Private Const encpfactorLoc = 73                                 'A              U16.16

    '主编码器速度，单位：计数值每控制周期。
    Public Const encpvelLoc = 75                                    'A              S16.16

    '主编码器计数值，即当前实际位置。
    Private Const encpLoc = 78                                       'A              S32

    '主编码器控制和状态寄存器
    Private Const encpctrLoc = 539                                   'A              R16

    '********************************************************************************************************/
    '辅编码器

    '辅编码器的倍率因子，应为正值。
    Private Const encsfactorLoc = 81                                 'A              U16.16

    '辅编码器速度，单位：计数值每控制周期。
    Private Const encsvelLoc = 83                                    'A              S16.16

    '辅编码器计数值寄存器。
    Private Const encsLoc = 86                                       'A              S32

    '辅助编码器的控制寄存器
    Private Const encsctrLoc = 531                                   'A              R16

    '写该寄存器清零辅编码器计数寄存器
    Private Const clrencsLoc = 532                                   'A              F16


    '********************************************************************************************************/
    '其它轴参数

    '运行该轴。只有运行该轴才能进行运动规划。若该轴因错误退出运行，run清零，该轴处于停止运行状态。
    Private Const runLoc = 128                                       'A              F16

    '状态寄存器
    Private Const statusLoc = 129                                    'A              R16

    '错误寄存器
    Public Const errorLoc = 130                                     'A              R16

    '位置误差(poserr)的限制值，超出该值，错误寄存器中相应的位域置位。注意：必须为正值。
    Private Const poserrlimLoc = 131                                 'A              U16

    '运动平滑因子。
    Private Const smoothLoc = 132                                    'A              U16

    '跟随误差窗口大小，单位：位移单位，参数值须大于零。
    Private Const trackwinLoc = 133                                  'A              U16

    '电机静止窗口大小，单位：位移单位，参数值须大于零。
    Private Const settlewinLoc = 134                                 'A              U16

    '设置电机自运动结束到进入静止状态的延时。若该轴已停止规划运动和平滑处理(moving=0)，
    '       在静止窗口内的状态(outsettle=0)保持settlen设定的控制周期个数后，清零motion参数，标志电机已静止。
    Private Const settlenLoc = 135                                   'A              U16

    '指定发生何种错误时停止规划运动。stopfilt中置位的位域将致使：若错误寄存器error中对应的位域置位则停止运动。
    Private Const stopfiltLoc = 136                                  'A              R16


    Private Const stopmodeLoc = 137                                  'A              R16

    '指定发生何种错误时停止该轴运行。exitfilt中置位的位域将致使：若错误寄存器error中对应的位域置位则停止运行(清零run)。
    Private Const exitfiltLoc = 138                                  'A              R16

    '正向软极限位置，默认为正方向最大值。
    Private Const psoftlimLoc = 139                                  'A              S32

    '负向软极限位置，默认为负方向最大值。
    Private Const nsoftlimLoc = 141                                  'A              S32

    '位置断点。若curpos<breakp，则状态寄存器status的BREAKP位域清零；若curpos≥breakp，则status的BREAKP位域置1。
    Private Const breakpLoc = 143                                    'A              S32

    '原点的偏移位置值，设置机械原点时，该值被拷贝到指令位置寄存器curpos和编码器寄存器encp中。
    Private Const homeposLoc = 145                                   'A              S32

    '搜寻原点时，低速段的速度预设值。
    Private Const lowvelLoc = 147                                    'A              S16.16

    '搜寻原点时，高速段的速度预设值。
    Private Const highvelLoc = 149                                   'A              S16.16

    '设置搜寻原点过程的运动序列和操作方式。
    Private Const homeseqLoc = 151                                   'A              R16

    '写入FFFFh，开始执行自动搜寻和设置机械原点的操作，执行的动作过程由homeseq参数定义，清零则退出。
    Private Const gohomeLoc = 152                                    'A              F16

    '主机设定原点位置指令，主机向该参数写入FFFFh，iMC将当前位置设为原点。
    Private Const sethomeLoc = 153                                   'A              F16

    '非零表示已搜寻到原点
    Private Const homedLoc = 154                                     'A              F16


    '写入非零值对该轴实施清零操作。清零该轴的编码器计数、指令位置、目标位置等各种位置参数，
    '       以及各种运动状态标志：mcspos、mcstgpos、curpos、encp、pcspos、pcstgpos、status、
    '       error、emstop、hpause、events、encs、ticks、aiolat。
    Public Const clearLoc = 157                                     'A              F16

    '设置该轴的速度极限值。无论何种运动模式，只要实际速度超出此极限值，将置位错误寄存器error中的位VELLIM域，
    '       此错误不可屏蔽，因此只要发生此错误，立刻退出该轴运行。注意：必须为正值。
    Private Const vellimLoc = 158                                    'A              S16.16


    '设置该轴的加速度极限值。无论何种运动模式，只要实际加速度超出此极限值，将置位错误寄存器error中的ACCLIM位域，
    '       此错误不可屏蔽，因此只要发生此错误，立刻退出该轴运行。注意：accellim必须为正值。
    Private Const accellimLoc = 160                                  'A              S16.16


    '误差补偿速度。
    Private Const fixvelLoc = 162                                    'A              S0.16

    '若设置搜寻到原点后移动到指定位置选项，该参数设置指定位置。
    Private Const homestposLoc = 163                                 'A              S32



    '********************************************************************************************************/
    '电子齿轮参数

    '电子齿轮运动模式中主动轴的轴号。
    Private Const masterLoc = 169                                    'A              U16

    '指针，指向从动轴所跟随的主动轴的参数。
    Private Const gearsrcLoc = 170                                   'A              U16

    '写入FFFFh开始接合，清零则脱离啮合。
    Private Const engearLoc = 171                                    'A              F16

    '脱离啮合后从动轴的运动模式。0：脱离啮合后从动轴以传动速度作为目标速度进入连续速度运动模式，
    '“传动速度”等于脱离啮合之时刻主动轴的速度乘以传动比率。FFFFh：脱离啮合后从动轴以由gearoutvel参数所设置的速度作为
    '目标速度进入连续速度运动模式。若需脱离啮合后停止，应设置gearoutvel参数值为0。
    Private Const gearoutmodLoc = 172                                'A              F16

    '传动比率，16.32格式，高16位为整数部分，低32位为小数部分。
    Private Const gearratioLoc = 175                                 'A              S16.32

    '脱离啮合后的运行速度。
    Private Const gearoutvelLoc = 178                                'A              S16.16


    '********************************************************************************************************/
    '环形轴

    '若该轴设为环形轴，此参数设置环形轴的最大位置。
    Private Const cirposLoc = 184                                    'A              S32

    '设置该轴为线性轴或环形轴。若ciraxis为0，该轴为线性轴；若为FFFFh，该轴设置为环形轴。
    Private Const ciraxisLoc = 186                                   'A              F16

    '单向或双向环形标志
    Private Const biciraxisLoc = 187                                 'A              F16

    '记录循环次数，向上溢出（即curpos>=cirpos）一次；该寄存器值加1，
    '       向下溢出（即curpos<=-cirpos或curpos<=0），该寄存器值减1。
    Private Const cirswapLoc = 214                                   'A              F16


    '********************************************************************************************************/
    '非线性同步控制参数

    '使能同步控制，0：禁止，FFFFh：使能。同步运动完成后startsyn和enasyn都自动清零。
    Private Const enasynLoc = 188                                    'A              F16

    '写入FFFFh开始执行同步，写入0退出同步。同步运动完成后startsyn和enasyn都自动清零。
    Private Const startsynLoc = 189                                  'A              F16

    '同步类型，电子齿轮的同步运动都是速度同步，因此syntype必须清零。
    Private Const syntypeLoc = 190                                   'A              F16

    '指向同步源参数的指针，写入时是取同步源参数的地址。
    Private Const synsrcLoc = 191                                    'A              U16

    '同步源参数所在的轴号，即参照轴。
    Private Const syAxisNoLoc = 192                                   'A              U16

    '设置整个同步过程中，同步源变化的量，若同步源是位移类参数，synsrcvar表示同步源轴移动的距离，
    '若同步源是ticks，synsrcvar表示历经的控制周期数。注意，该参数必须为正整数。
    Private Const synsrcvarLoc = 193                                 'A              S32


    '若syntype非零，该参数用于设置整个同步过程中从动轴的移动目标：
    '若slaveabs=0，该参数表示相对移动距离；若slaveab!=0，该参数表示绝对位置；若syntype为零，该参数无需设置。
    Private Const slavedistLoc = 197                                 'A              S32

    '若slaveabs标志参数为0，slavedist表示的移动目标是相对移动距离；
    '若slaveabs标志参数非零，slavedist表示的是绝对位置。
    Private Const slaveabsLoc = 199                                  'A              F16


    '********************************************************************************************************/
    '运动状态               '

    '标志是否规划运动中，0：规划运动已停止，FFFFh：规划运动中（包括主坐标系和辅坐标系，以及轮廓运动）。
    Private Const profilingLoc = 215                                 'A              F16

    '标志是否正在进行轮廓运动中，FFFFh：轮廓运动中，0：轮廓运动已结束或CFIFO已空。
    Private Const contouringLoc = 217                                'A              F16

    '标志是否规划运动（包括主坐标系和辅坐标系）以及运动平滑处理中，
    '0：停止规划运动且停止平滑处理，FFFFh：规划运动未完成或运动平滑处理进行中。
    Private Const movingLoc = 218                                    'A              F16

    '电机是否静止，0：规划运动已完成，且电机已静止；FFFFh：规划运动未完成，或虽已完成运动规划，但电机尚未静止。
    Private Const motionLoc = 219                                    'A              F16

    '位置误差越出静止窗口标志，若outsettle=FFFFh，表明当前位置误差poserr大于静止窗口参数settlewin。
    Private Const outsettleLoc = 220                                 'A              F16

    '位置误差越出跟随窗口标志，若outtrack=FFFFh，表明当前位置误差poserr大于跟随窗口参数。
    Private Const outtrackLoc = 221                                  'A              F16

    '位置误差，指令位置与实际位置（反馈值）之差：poserr=curpos-encp。
    Private Const poserrLoc = 223                                    'A              S16




    '********************************************************************************************************/
    '指令脉冲相关参数

    '脉冲输出模式及信号极性设置寄存器
    Private Const stepmodLoc = 615                                   'A              R16

    '设置方向信号变化的延迟时间，单位是系统的时钟周期
    Private Const dirtimeLoc = 618                                   'A              U16

    '设定脉冲有效电平宽度，单位是系统的时钟周期
    Private Const steptimeLoc = 619                                  'A              R16

    '非零则暂停输出脉冲，清零则又继续允许发脉冲
    Private Const haltstepLoc = 166                                  'A              R16

    '暂停输出脉冲模式。0:立刻停止；非零:减速输出指令脉冲，直到停止
    Private Const haltmodeLoc = 167                                  'A              R16

    '********************************************************************************************************/
    '位置捕获参数

    '当前读指针指向的位置值
    Private Const capfifoLoc = 696                                   'A              S32

    '写操作则将capfifo的读指针往后移一个
    Private Const popcapfifoLoc = 698                                'A              R16

    '写操作则清空位置捕获缓存器capfifo
    Private Const clrcapfifoLoc = 699                                'A              R16

    'capfifo中已压入的位置数据个数
    Private Const capfifocntLoc = 699                                'A              R16

    '往该寄存器写操作则触发捕获位置，并保存在cappos参数中。
    Private Const captureLoc = 543                                   'A              F16


    '********************************************************************************************************/
    '探针或index计数相关参数


    '探针或index的计数值
    Private Const counterLoc = 541                                   'A              F16

    '探针或index的计数值
    Private Const clrcounterLoc = 541                                'A              F16


    '********************************************************************************************************/
    '轮廓运动

    '置FFFFh开始执行轮廓运动，清零则结束轮廓运动。
    Private Const startgroupLoc = 256                                'G              F16

    '轮廓运动的轴组中，轴的数量。
    Private Const groupnumLoc = 257                                  'G              U16

    '轮廓运动的轴组中，X轴对应的轴号。
    Private Const group_xLoc = 258                                   'G              U16

    '轮廓运动的轴组中，Y轴对应的轴号。
    Private Const group_yLoc = 259                                   'G              U16

    '轮廓运动的轴组中，Z轴对应的轴号。
    Private Const group_zLoc = 260                                   'G              U16

    '轮廓运动的轴组中，A轴对应的轴号。
    Private Const group_aLoc = 261                                   'G              U16

    '轮廓运动的轴组中，B轴对应的轴号。
    Private Const group_bLoc = 262                                   'G              U16

    '轮廓运动的轴组中，C轴对应的轴号。
    Private Const group_cLoc = 263                                   'G              U16

    '轮廓运动的轴组中，D轴对应的轴号。
    Private Const group_dLoc = 264                                   'G              U16

    '轮廓运动的轴组中，E轴对应的轴号。
    Public Const group_eLoc = 265                                   'G              U16

    '轮廓运动的轴组中，F轴对应的轴号。
    Private Const group_fLoc = 266                                   'G              U16

    '轮廓运动的轴组中，G轴对应的轴号。
    Private Const group_gLoc = 267                                   'G              U16

    '轮廓运动的轴组中，H轴对应的轴号。
    Private Const group_hLoc = 268                                   'G              U16

    '轮廓运动的轴组中，I轴对应的轴号。
    Private Const group_iLoc = 269                                   'G              U16

    '轮廓运动的轴组中，J轴对应的轴号。
    Private Const group_jLoc = 270                                   'G              U16

    '轮廓运动的轴组中，K轴对应的轴号。
    Private Const group_kLoc = 271                                   'G              U16

    '轮廓运动的轴组中，L轴对应的轴号。
    Private Const group_lLoc = 272                                   'G              U16

    '轮廓运动的轴组中，M轴对应的轴号。
    Private Const group_mLoc = 273                                   'G              U16

    '轮廓运动的平滑拟合时间，单位为控制周期
    Private Const groupsmoothLoc = 274                               'G              U16

    '*************************************************************************************************************/
    '轮廓运动专用CFIFO缓存器的相关参数

    'CFIFO中数据（WORD）的个数
    Private Const cfifocntLoc = 519                                  'G              R16

    '写操作清空CFIFO
    Private Const clrCFIFOLoc = 519                                  'G              R16


    '*************************************************************************************************************/
    'IFIFO/QFIFO缓存器相关参数

    '写操作清空IFIFO
    Private Const clrififoLoc = 513                                  'G              F16

    'IFIFO中数据（WORD）的个数
    Private Const ififocntLoc = 513                                  'G              F16

    '写操作清空QFIFO
    Private Const clrqfifoLoc = 521                                  'G              F16

    'QFIFO中数据（WORD）的个数
    Private Const qfifocntLoc = 521                                  'G              F16

    'QFIFO的等待指令的超时时间
    Private Const qwaittimeLoc = 492                                 'G              S32

    '*************************************************************************************************************/
    '预定义用户参数
    Private Const user16b0Loc = 307                                  'G              S16
    Private Const user16b1Loc = 308                                  'G              S16
    Public Const user16b2Loc = 309                                  'G              S16
    Public Const user16b3Loc = 310                                  'G              S16
    Public Const user16b4Loc = 311                                  'G              S16
    Public Const user16b5Loc = 312                                  'G              S16
    Public Const user16b6Loc = 313                                  'G              S16
    Public Const user16b7Loc = 314                                  'G              S16
    Public Const user16b8Loc = 315                                  'G              S16
    Public Const user16b9Loc = 316                                  'G              S16

    Public Const user32b0Loc = 317                                  'G              S32
    Public Const user32b1Loc = 319                                  'G              S32
    Public Const user32b2Loc = 321                                  'G              S32
    Public Const user32b3Loc = 323                                  'G              S32
    Public Const user32b4Loc = 325                                  'G              S32
    Public Const user32b5Loc = 327                                  'G              S32
    Public Const user32b6Loc = 329                                  'G              S32
    Public Const user32b7Loc = 331                                  'G              S32
    Public Const user32b8Loc = 333                                  'G              S32
    Public Const user32b9Loc = 335                                  'G              S32

    Public Const user48b0Loc = 337                                  'G              S48
    Public Const user48b1Loc = 340                                  'G              S48
    Public Const user48b2Loc = 343                                  'G              S48
    Public Const user48b3Loc = 346                                  'G              S48
    Public Const user48b4Loc = 349                                  'G              S48


    '********************************************************************************************************/
    '插补运动的轴参数*/
    '轴参数，设置段的坐标数据以绝对值还是相对值表示
    Public Const pathabsLoc = 205                                   'A              F16

    '当前执行段的终点
    Public Const segendLoc = 202                                    'A              S32

    '当前执行段的起始点
    Public Const segstartLoc = 200                                  'A              S32

    '轴参数，表明该轴是否参与路径运动并正在运动中
    Public Const moveinpath1Loc = 204                               'A              F16

    '轴参数，表明该轴是否参与路径运动并正在运动中
    Public Const moveinpath2Loc = 165                               'A              F16

    '插补空间1的参数***********************************************************************************************************/

    '写入非零开始执行路径运动
    Public Const startpath1Loc = 352                                'G              F16

    '标志是否正在执行插补
    Public Const pathmoving1Loc = 354                               'G              F16

    '当前执行圆弧段的方向，0：顺时针，非零：逆时针
    Public Const arcdir1Loc = 355                                   'G              F16

    '指定速度规划是否基于该段合成路径的长度，或某个轴在该段的移动距离。
    '若asseglen为0，速度规划基于X、Y、Z三轴的合成路径长度，即pathvel是合成路径的速度。
    '当然，当pathaxisnum小于3时，则只有X轴或X、Y轴合成路径长度。
    '若asseglen非零，asseglen必须为1~pathaxisnum范围的一个值，表示采用segmap_x、segmap_y…所映射的轴的
    '移动距离进行速度规划，如1表示采用X轴的移动距离规划速度，因此pathvel即为X轴的速度。
    Public Const asseglen1Loc = 361                                 'G              F16

    '当前路径速度（只读）
    Public Const pathvel1Loc = 362                                          'G              S16.16

    '若非零：连续路径插补为轮廓模式，每个点的各个轴分量为16bit的增量，PFIFO中送入的全是轮廓路径中的各点坐标的增量
    '       Public Const contourmod1Loc =                   365     'G              F16

    '路径加速度
    Public Const pathacc1Loc = 366                                  'G              S16.16
    '进给倍率，供在路径运动过程中实时改变路径速度
    Public Const feedrate1Loc = 368                                 'G              S16.16
    '参与路径运动的轴数
    Public Const pathaxisnum1Loc = 370                              'G              F16
    '映射为X轴的轴号
    Public Const segmap_x1Loc = 371                                 'G              F16
    '映射为Y轴的轴号
    Public Const segmap_y1Loc = 372                                 'G              F16
    '映射为Z轴的轴号
    Public Const segmap_z1Loc = 373                                 'G              F16
    '映射为A轴的轴号
    Public Const segmap_a1Loc = 374                                 'G              F16
    '映射为B轴的轴号
    Public Const segmap_b1Loc = 375                                 'G              F16
    '映射为C轴的轴号
    Public Const segmap_c1Loc = 376                                 'G              F16
    '映射为D轴的轴号
    Public Const segmap_d1Loc = 377                                 'G              F16
    '映射为E轴的轴号
    Public Const segmap_e1Loc = 378                                 'G              F16
    '映射为F轴的轴号
    Public Const segmap_f1Loc = 379                                 'G              F16
    '映射为G轴的轴号
    Public Const segmap_g1Loc = 380                                 'G              F16
    '映射为H轴的轴号
    Public Const segmap_h1Loc = 381                                 'G              F16
    '映射为I轴的轴号
    Public Const segmap_i1Loc = 382                                 'G              F16
    '映射为J轴的轴号
    Public Const segmap_j1Loc = 383                                 'G              F16
    '映射为K轴的轴号
    Public Const segmap_k1Loc = 384                                 'G              F16
    '映射为L轴的轴号
    Public Const segmap_l1Loc = 385                                 'G              F16
    '映射为M轴的轴号
    Public Const segmap_m1Loc = 386                                 'G              F16
    '段执行的目标速度
    Public Const segtgvel1Loc = 387                                 'G              S16.16
    '段结束时的速度
    Public Const segendvel1Loc = 389                                'G              S16.16
    '正在执行的段的ID号，每执行一段，该ID加1
    Public Const segID1Loc = 391                                    'G              U32
    '当前执行段的长度
    Public Const seglen1Loc = 393                                   'G              U32
    '当前执行圆弧段的半径
    Public Const radius1Loc = 395                                   'G              U32


    'PFIFO1缓存器相关参数

    '对此寄存器写操作清空PFIFO
    Public Const clrPFIFO1Loc = 565                                'G              F16

    'PFIFO中数据个数
    Public Const PFIFOcnt1Loc = 565                                 'G              F16

    'PFIFO1等待指令超时时间
    Public Const pwaittime1Loc = 399                                'G              S32


    'PFIFO2***********************************************************************************************************/

    '写入非零开始执行路径运动
    Public Const startpath2Loc = 405                                'G              F16
    '标志是否正在执行插补
    Public Const pathmoving2Loc = 407                               'G              F16
    '当前执行圆弧段的方向，0：顺时针，非零：逆时针
    Public Const arcdir2Loc = 408                                   'G              F16

    '指定速度规划是否基于该段合成路径的长度，或某个轴在该段的移动距离。
    '若asseglen为0，速度规划基于X、Y、Z三轴的合成路径长度，即pathvel是合成路径的速度。
    '当然，当pathaxisnum小于3时，则只有X轴或X、Y轴合成路径长度。
    '若asseglen非零，asseglen必须为1~pathaxisnum范围的一个值，表示采用segmap_x、segmap_y…所映射的轴的
    '移动距离进行速度规划，如1表示采用X轴的移动距离规划速度，因此pathvel即为X轴的速度。
    Public Const asseglen2Loc = 414                                 'G              F16

    '当前路径速度（只读）
    Public Const pathvel2Loc = 415                                  'G              S16.16

    '若非零：连续路径插补为轮廓模式，每个点的各个轴分量为16bit的增量，PFIFO中送入的全是轮廓路径中的各点坐标的增量
    '       Public Const contourmod2Loc = 418                               'G              F16

    '路径加速度
    Public Const pathacc2Loc = 419                                  'G              S16.16
    '进给倍率，供在路径运动过程中实时改变路径速度
    Public Const feedrate2Loc = 421                                 'G              S16.16
    '参与路径运动的轴数
    Public Const pathaxisnum2Loc = 423                              'G              F16
    '映射为X轴的轴号
    Public Const segmap_x2Loc = 424                                 'G              F16
    '映射为Y轴的轴号
    Public Const segmap_y2Loc = 425                                 'G              F16
    '映射为Z轴的轴号
    Public Const segmap_z2Loc = 426                                 'G              F16
    '映射为A轴的轴号
    Public Const segmap_a2Loc = 427                                 'G              F16
    '映射为B轴的轴号
    Public Const segmap_b2Loc = 428                                 'G              F16
    '映射为C轴的轴号
    Public Const segmap_c2Loc = 429                                 'G              F16
    '映射为D轴的轴号
    Public Const segmap_d2Loc = 430                                 'G              F16
    '映射为E轴的轴号
    Public Const segmap_e2Loc = 431                                 'G              F16
    '映射为F轴的轴号
    Public Const segmap_f2Loc = 432                                 'G              F16
    '映射为G轴的轴号
    Public Const segmap_g2Loc = 433                                 'G              F16
    '映射为H轴的轴号
    Public Const segmap_h2Loc = 434                                 'G              F16
    '映射为I轴的轴号
    Public Const segmap_i2Loc = 435                                 'G              F16
    '映射为J轴的轴号
    Public Const segmap_j2Loc = 436                                 'G              F16
    '映射为K轴的轴号
    Public Const segmap_k2Loc = 437                                 'G              F16
    '映射为L轴的轴号
    Public Const segmap_l2Loc = 438                                 'G              F16
    '映射为M轴的轴号
    Public Const segmap_m2Loc = 439                                 'G              F16
    '段执行的目标速度
    Public Const segtgvel2Loc = 440                                 'G              S16.16
    '段结束时的速度
    Public Const segendvel2Loc = 442                                'G              S16.16
    '段的ID，用于标识正在执行第几段
    Public Const segID2Loc = 444                                    'G              U32




    'PFIFO2缓存器相关参数

    '对此寄存器写操作清空PFIFO
    Public Const clrPFIFO2Loc = 685                                 'G              F16

    'PFIFO中数据个数
    Public Const PFIFOcnt2Loc = 685                                 'G              F16

    'PFIFO2等待指令超时时间
    Public Const pwaittime2Loc = 452                                'G              S32

    '*****************************************************************************************************************/
    '输入输出（I/O）相关参数


    '脉冲输出及驱动器使能。写入FFFFh则使能脉冲输出及使能驱动器。注意：写入FFFFh，驱动器使能信号为低电平，
    '写入0则为高电平。若需将轴作为虚拟轴(运行正常，但不输出脉冲)，可清零ena。
    '另：可以用于判断脉冲输出和驱动器是否使能，0：脉冲输出和驱动器禁止，FFFFh：脉冲输出和驱动器使能。
    Public Const enaLoc = 550                                       'A              F16

    '轴I/O数据寄存器。某I/O设为输入时，读出的是对应管脚的实时信号值；
    '若设为输出，写入0或1可使该管脚输出低或高电平，读则得到写入到该寄存器的值。
    Public Const aioLoc = 562                                       'A              R16

    '轴I/O的控制寄存器
    Public Const aioctrLoc = 680                                    'A              R16

    '轴I/O设为输入时锁存信号的有效边沿。
    Public Const aiolatLoc = 682                                    'A              R16

    '相应的位域写入1则清零轴I/O的锁存值。
    Public Const clraiolatLoc = 682                                 'A              R16

    '全局开关量输出gout1
    Public Const gout1Loc = 560                                     'G              R16

    '全局开关量输出gout2
    Public Const gout2Loc = 561                                     'G              R16

    '全局开关量输出gout3
    Public Const gout3Loc = 555                                     'G              R16

    '全局开关量输入gin1
    Public Const gin1Loc = 706                                      'G              R16

    '全局开关量输入gin2
    Public Const gin2Loc = 707                                      'G              R16

    '锁存全局开关量输入gin1的有效边沿
    Public Const gin1latLoc = 612                                      'G              R16

    '锁存全局开关量输入gin2的有效边沿
    Public Const gin2latLoc = 613                                      'G              R16

    '读得到停止开关的状态，写则设置停止开关的有效极性
    Public Const stopinLoc = 563                                    'G              R16

    '输入开关量的数字滤波设置寄存器
    Public Const swfilterLoc = 548                                  'G              R16

    '伺服驱动器误差清零
    Public Const srstLoc = 551                                      'A              R16



    '计时单元相关的参数*****************************************************************

    '毫秒计时，写入毫秒数，每毫秒减1
    Public Const delaymsLoc = 704                                   'G              U32

    'delayms倒计时为0后该参数为0
    Public Const delayoutLoc = 704                                  'G              U32

    '倒计时计数器，写入非零开始每周期减1
    Public Const timerLoc = 481                                     'G              U16

    '控制周期计数器，每控制周期加1
    Public Const ticksLoc = 502                                     'G              U32

    '事件指令相关参数************************************************************************
    '事件指令数量，清零则禁止所有事件指令
    Public Const eventsLoc = 489                                    'G              U16


    '急停/暂停相关参数*******************************************************************
    '某些位域若置位，则使所有轴的error寄存器相应位域置位
    Public Const emstopLoc = 500                                    'G              F16

    '非零则暂停
    Public Const hpauseLoc = 501                                    'G              F16

    '系统参数 Read only********************************************************************
    Public Const clkdivLoc = 509                                    'G              U16             控制分频
    Public Const fwversionLoc = 511                                 'G              U16             本控制器firmware的版本号。
    Public Const sysclkLoc = 628                                    'G              U32             系统基准时钟。
    Public Const AxisNoLoc = 634                                     'G              U16             本控制器支持的最大轴数。
    Public Const hwversionLoc = 635                                 'G              U16             硬件版本（根据硬件版本不同）

    '清空所有FIFO和残留的等待指令等
    Public Const clearimcLoc = 494                                  'G              R16





#End Region






    Public _IsPauseThread As Boolean = False

    Private DataRefreshThread As Threading.Thread
    Public Sub RefreshData()
        While True

            If _IsPauseThread = False Then
                For i As Int16 = 0 To _IMCCardInformation.Count - 1
                    If AxisInitalPara.AxisInitalParameter(i).IsUseSensor = True Then
                        Dim tmp As Double
                        GetChannelData(AxisInitalPara.AxisInitalParameter(i).SensorChanel, tmp)
                        If tmp > AxisInitalPara.AxisInitalParameter(i).SafeSensorValue Then
                            StopJog(i, JogTpye.Pos)
                            StopJog(i, JogTpye.Speed)
                            ChangeFlowlb("机台异常！")
                            ContorlPerClick(MainForm.cmdReset)
                            '  Throw New Exception("机台异常！")
                        End If
                    End If
                    _IMCCardInformation(i).Postion = GetCurrentPos(i)
                    _IMCCardInformation(i).Plus = GetPos(i)
                    _IMCCardInformation(i).Org = ORG(i)
                    _IMCCardInformation(i).PLM = PLM(i)
                    _IMCCardInformation(i).NLM = NLM(i)
                    _IMCCardInformation(i).ErrorMessage = ErrorValue(i)
                    _IMCCardInformation(i).MotionDone = MoveDone(i)
                Next
            End If

        End While
    End Sub
    ''' <summary>
    ''' 网卡的讯息
    ''' </summary>
    ''' <remarks></remarks>
    Public _NetCardInformation As New List(Of NetCardInforMation)
    ''' <summary>
    ''' IMC卡的讯息
    ''' </summary>
    ''' <remarks></remarks>
    Public _IMCCardInformation As New List(Of IMCCardInforMation)
    ''' <summary>
    ''' Search NetCard
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SearchNet() As Boolean Implements InterfaceHandle.SearchNet
        Dim status As IMC_STATUS
        Dim numDevs As Integer
        _NetCardInformation.Clear()
        Dim info As NIC_INFO = New NIC_INFO()
        status = IMC_FindNetCard(info, numDevs)
        If status <> IMC_STATUS.IMC_OK Then Return False
        Dim NetCardName As String
        If numDevs <= 0 Then Return False
        For i As Integer = 0 To numDevs - 1
            NetCardName = Convert.ToString(info.description(i).description)
            '   Dim NetStr As String = IO.File.ReadAllText(Application.StartupPath & "NetCard.TXT")
            If NetCardName.ToUpper.Contains("DM") Or NetCardName.ToUpper.Contains("PCIE") Or NetCardName.Contains("Realtek Ethernet Controller") Then
                Dim net As New NetCardInforMation
                net.CardInfor = NetCardName

                net.CardID = i
                _NetCardInformation.Add(net)
            End If
        Next i
        Return True
    End Function
    ''' <summary>
    ''' 打开设备
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OpenDev() Implements InterfaceHandle.OpenDev
        For i As Int16 = 0 To _NetCardInformation.Count - 1
            SearchDev(_NetCardInformation.Item(i).CardID)
        Next
    End Sub
    ''' <summary>
    ''' 搜索对应网卡的IMC
    ''' </summary>
    ''' <param name="NetCardId"></param>
    ''' <remarks></remarks>
    Private Sub SearchDev(ByVal NetCardId As Integer) Implements InterfaceHandle.SearchDev
        Dim status As IMC_STATUS
        Dim m_handle As Integer
        Dim sel As Integer, id As Integer, cnt As Integer
        cnt = 0
        If sel >= 0 Then
            For id = 0 To 1
                status = IMC_Open(m_handle, NetCardId, id)
                'Dim A As IntPtr
                'A = IntPtr.Zero
                'A = PKG_IMC_Open(NetCardId, id)
                If (status = IMC_STATUS.IMC_OK) Then


                    For i As Int16 = 0 To 3
                        Dim IMCCard As New IMCCardInforMation
                        IMCCard.CardID = id
                        IMCCard.AxisNo = i
                        IMCCard.CardHandle = m_handle
                        IMCCard.IsOpen = True
                        IMCCard.IsOpen = True
                        _IMCCardInformation.Add(IMCCard)
                    Next
                End If
            Next id
        End If

        DataRefreshThread = New Threading.Thread(New Threading.ThreadStart(AddressOf RefreshData))
        DataRefreshThread.IsBackground = True
        DataRefreshThread.Start()
    End Sub
    Private WithEvents Trm As New System.Windows.Forms.Timer
    ''' <summary>
    ''' 初始化对应轴的参数
    ''' </summary>
    ''' <param name="Axis"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InitalCard(ByVal Axis As Integer) As Boolean Implements InterfaceHandle.InitalCard
        Try
            Dim status As IMC_STATUS
            Dim m_handle As Integer
            If _IMCCardInformation.Count = 0 Then Return False
            m_handle = _IMCCardInformation(Axis).CardHandle
            Dim InitalPara As New cAxisParameter
            For i As Int16 = 0 To AxisInitalPara.AxisInitalParameter.Length - 1
                If Axis = AxisInitalPara.AxisInitalParameter(i).AxisNo Then
                    InitalPara = AxisInitalPara.AxisInitalParameter(i)
                    Exit For
                End If
            Next
            Axis = _IMCCardInformation(Axis).AxisNo

            ' status = IMC_SetParam16(m_handle, clearLoc, InitalPara.clearLoc, Axis, TYPE_FIFO.SEL_IFIFO)       '清除各轴的位置值及状态,配置clear参数必须放在第一
            status = IMC_SetParam32(m_handle, accellimLoc, InitalPara.accellimLoc, Axis, TYPE_FIFO.SEL_IFIFO)  '设置加速度极限
            status = IMC_SetParam32(m_handle, vellimLoc, InitalPara.vellimLoc, Axis, TYPE_FIFO.SEL_IFIFO) '设置速度极限50000000
            status = IMC_SetParam32(m_handle, mcsmaxvelLoc, InitalPara.mcsmaxvelLoc, Axis, TYPE_FIFO.SEL_IFIFO) '主坐标系点到点运动的规划速度
            status = IMC_SetParam32(m_handle, mcsaccelLoc, InitalPara.mcsaccelLoc, Axis, TYPE_FIFO.SEL_IFIFO)  '主坐标系加速度
            status = IMC_SetParam32(m_handle, mcstgposLoc, InitalPara.mcstgposLoc, Axis, TYPE_FIFO.SEL_IFIFO) '主坐标系起始速度
            status = IMC_SetParam32(m_handle, mcsdecelLoc, InitalPara.mcsdecelLoc, Axis, TYPE_FIFO.SEL_IFIFO)  '主坐标系减速度
            status = IMC_SetParam16(m_handle, enaLoc, -1, Axis, TYPE_FIFO.SEL_IFIFO)         '使能该轴，同时也输出电平使能驱动器（低电平）
            status = IMC_SetParam16(m_handle, aioctrLoc, InitalPara.aioctrLoc, Axis, TYPE_FIFO.SEL_IFIFO)  '设置各轴IO的功能, AIO0、AIO1为限位开关输入（应接入限位开关，且低电平有效'；若无限位开关，请去掉该语句）191
            status = IMC_SetParam16(m_handle, homeseqLoc, InitalPara.homeseqLoc, Axis, TYPE_FIFO.SEL_IFIFO)   '搜寻原点方式：仅使用原点开关，正方向出发
            status = IMC_SetParam32(m_handle, lowvelLoc, InitalPara.lowvelLoc, Axis, TYPE_FIFO.SEL_IFIFO)   '低速搜寻原点的速度
            status = IMC_SetParam32(m_handle, highvelLoc, InitalPara.highvelLoc, Axis, TYPE_FIFO.SEL_IFIFO)  '高速搜寻原点的速度
            status = IMC_SetParam16(m_handle, exitfiltLoc, InitalPara.exitfiltLoc, Axis, TYPE_FIFO.SEL_IFIFO)     '发送错误时(error寄存器置位时)不退出控制器运行
            status = IMC_SetParam16(m_handle, stopfiltLoc, -1, Axis, TYPE_FIFO.SEL_IFIFO)    '发送错误时(error寄存器置位时)停止运动
            ' status = IMC_SetParam16(m_handle, gout1Loc, -1, Axis, TYPE_FIFO.SEL_IFIFO)         '16个全局IO的方向全部设为输出
            status = IMC_SetParam16(m_handle, runLoc, -1, Axis, TYPE_FIFO.SEL_IFIFO)         '运行该轴
            status = IMC_SetParam16(m_handle, emstopLoc, 0, 0, TYPE_FIFO.SEL_IFIFO)




            'status = IMC_SetParam16(m_handle, clearLoc, -1, Axis, TYPE_FIFO.SEL_IFIFO)       '清除各轴的位置值及状态,配置clear参数必须放在第一
            'status = IMC_SetParam32(m_handle, accellimLoc, 50000000, Axis, TYPE_FIFO.SEL_IFIFO)  '设置加速度极限
            'status = IMC_SetParam32(m_handle, vellimLoc, 500000000, Axis, TYPE_FIFO.SEL_IFIFO) '设置速度极限50000000
            'status = IMC_SetParam32(m_handle, mcsmaxvelLoc, 10000000, Axis, TYPE_FIFO.SEL_IFIFO) '主坐标系点到点运动的规划速度
            'status = IMC_SetParam32(m_handle, mcsaccelLoc, 1000000, Axis, TYPE_FIFO.SEL_IFIFO)  '主坐标系加速度
            'status = IMC_SetParam32(m_handle, mcstgposLoc, 5000000, Axis, TYPE_FIFO.SEL_IFIFO) '主坐标系起始速度
            'status = IMC_SetParam32(m_handle, mcsdecelLoc, 1000000, Axis, TYPE_FIFO.SEL_IFIFO)  '主坐标系减速度
            'status = IMC_SetParam16(m_handle, enaLoc, -1, Axis, TYPE_FIFO.SEL_IFIFO)         '使能该轴，同时也输出电平使能驱动器（低电平）
            'status = IMC_SetParam16(m_handle, aioctrLoc, 191, Axis, TYPE_FIFO.SEL_IFIFO)  '设置各轴IO的功能, AIO0、AIO1为限位开关输入（应接入限位开关，且低电平有效；若无限位开关，请去掉该语句）191
            'status = IMC_SetParam16(m_handle, homeseqLoc, &H14, Axis, TYPE_FIFO.SEL_IFIFO)   '搜寻原点方式：仅使用原点开关，正方向出发
            'status = IMC_SetParam32(m_handle, lowvelLoc, 83646, Axis, TYPE_FIFO.SEL_IFIFO)   '低速搜寻原点的速度
            'status = IMC_SetParam32(m_handle, highvelLoc, 83646, Axis, TYPE_FIFO.SEL_IFIFO)  '高速搜寻原点的速度
            'status = IMC_SetParam16(m_handle, exitfiltLoc, 0, Axis, TYPE_FIFO.SEL_IFIFO)     '发送错误时(error寄存器置位时)不退出控制器运行
            'status = IMC_SetParam16(m_handle, stopfiltLoc, -1, Axis, TYPE_FIFO.SEL_IFIFO)    '发送错误时(error寄存器置位时)停止运动
            'status = IMC_SetParam16(m_handle, gout1Loc, -1, Axis, TYPE_FIFO.SEL_IFIFO)         '16个全局IO的方向全部设为输出
            'status = IMC_SetParam16(m_handle, runLoc, -1, Axis, TYPE_FIFO.SEL_IFIFO)         '运行该轴
            'status = IMC_SetParam16(m_handle, emstopLoc, 0, 0, TYPE_FIFO.SEL_IFIFO)
            For i As Int16 = 0 To 15
                ' IMC_SetParamBit(m_handle, gout1Loc, i, 0, 0, TYPE_FIFO.SEL_QFIFO)
            Next
            Return True
        Catch ex As Exception

            Return False
        End Try

        Return True
    End Function
    ' 50000000，50000000 5千万 | 10000000,5000000 1千万、5百万 |  1000000，1000000 1百万
    ' 50000，500000 5万，5十万 |100000，50000 十万、5万|  100000，10000 十万、一万| 
    Public Sub SetVelDown(ByVal Axis As Integer) Implements InterfaceHandle.SetVelDown
        Dim status As IMC_STATUS
        Dim m_handle As Integer
        m_handle = _IMCCardInformation(Axis).CardHandle
        If Axis > 3 Then
            Axis = Axis - 4
        End If
        While True
            status = IMC_SetParam32(m_handle, accellimLoc, 50000, _IMCCardInformation(Axis).AxisNo, TYPE_FIFO.SEL_IFIFO)  '设置加速度极限
            If status = IMC_STATUS.IMC_OK Then
                Exit While
            Else
                System.Threading.Thread.Sleep(10)
            End If
        End While

        While True
            status = IMC_SetParam32(m_handle, vellimLoc, 500000, _IMCCardInformation(Axis).AxisNo, TYPE_FIFO.SEL_IFIFO) '设置速度极限50000000
            If status = IMC_STATUS.IMC_OK Then
                Exit While
            Else
                System.Threading.Thread.Sleep(10)
            End If
        End While
        While True
            status = IMC_SetParam32(m_handle, mcsmaxvelLoc, 100000, _IMCCardInformation(Axis).AxisNo, TYPE_FIFO.SEL_IFIFO) '主坐标系点到点运动的规划速度
            If status = IMC_STATUS.IMC_OK Then
                Exit While
            Else
                System.Threading.Thread.Sleep(10)
            End If
        End While
        While True
            status = IMC_SetParam32(m_handle, mcsaccelLoc, 100000, _IMCCardInformation(Axis).AxisNo, TYPE_FIFO.SEL_IFIFO)  '主坐标系加速度
            If status = IMC_STATUS.IMC_OK Then
                Exit While
            Else
                System.Threading.Thread.Sleep(10)
            End If
        End While
        While True
            status = IMC_SetParam32(m_handle, mcstgposLoc, 50000, _IMCCardInformation(Axis).AxisNo, TYPE_FIFO.SEL_IFIFO) '主坐标系起始速度
            If status = IMC_STATUS.IMC_OK Then
                Exit While
            Else
                System.Threading.Thread.Sleep(10)
            End If
        End While
        While True
            status = IMC_SetParam32(m_handle, mcsdecelLoc, 10000, _IMCCardInformation(Axis).AxisNo, TYPE_FIFO.SEL_IFIFO)  '主坐标系减速度
            If status = IMC_STATUS.IMC_OK Then
                Exit While
            Else
                System.Threading.Thread.Sleep(10)
            End If
        End While

    End Sub
    Public Sub SetVeldef(ByVal Axis As Integer) Implements InterfaceHandle.SetVeldef
        Dim InitalPara As New cAxisParameter
        For i As Int16 = 0 To AxisInitalPara.AxisInitalParameter.Length - 1
            If Axis = AxisInitalPara.AxisInitalParameter(i).AxisNo Then
                InitalPara = AxisInitalPara.AxisInitalParameter(i)
                Exit For
            End If
        Next
        Axis = _IMCCardInformation(Axis).AxisNo
        Dim m_handle As Integer = _IMCCardInformation(Axis).CardHandle
        Dim status As IMC_STATUS
        ' status = IMC_SetParam16(m_handle, clearLoc, InitalPara.clearLoc, Axis, TYPE_FIFO.SEL_IFIFO)       '清除各轴的位置值及状态,配置clear参数必须放在第一
        IMC_SetParam32(m_handle, accellimLoc, InitalPara.accellimLoc, Axis, TYPE_FIFO.SEL_IFIFO)  '设置加速度极限
        status = IMC_SetParam32(m_handle, vellimLoc, InitalPara.vellimLoc, Axis, TYPE_FIFO.SEL_IFIFO) '设置速度极限50000000
        status = IMC_SetParam32(m_handle, mcsmaxvelLoc, InitalPara.mcsmaxvelLoc, Axis, TYPE_FIFO.SEL_IFIFO) '主坐标系点到点运动的规划速度
        status = IMC_SetParam32(m_handle, mcsaccelLoc, InitalPara.mcsaccelLoc, Axis, TYPE_FIFO.SEL_IFIFO)  '主坐标系加速度
        status = IMC_SetParam32(m_handle, mcstgposLoc, InitalPara.mcstgposLoc, Axis, TYPE_FIFO.SEL_IFIFO) '主坐标系起始速度
        status = IMC_SetParam32(m_handle, mcsdecelLoc, InitalPara.mcsdecelLoc, Axis, TYPE_FIFO.SEL_IFIFO)  '主坐标系减速度




    End Sub
    ' 50000000\50000000 5千万 | 10000000,5000000 1千万、5百万 |  1000000\1000000 1百万
    Public Sub SetVelAcc(ByVal Axis As Integer) Implements InterfaceHandle.SetVelAcc
        Dim status As IMC_STATUS
        Dim m_handle As Integer
        m_handle = _IMCCardInformation(Axis).CardHandle

        If Axis = 3 Then Return
        While True
            status = IMC_SetParam32(m_handle, accellimLoc, 50000000, _IMCCardInformation(Axis).AxisNo, TYPE_FIFO.SEL_IFIFO)  '设置加速度极限
            If status = IMC_STATUS.IMC_OK Then
                Exit While
            Else
                System.Threading.Thread.Sleep(10)
            End If
        End While

        While True
            status = IMC_SetParam32(m_handle, vellimLoc, 50000000, _IMCCardInformation(Axis).AxisNo, TYPE_FIFO.SEL_IFIFO) '设置速度极限50000000
            If status = IMC_STATUS.IMC_OK Then
                Exit While
            Else
                System.Threading.Thread.Sleep(10)
            End If
        End While
        While True
            status = IMC_SetParam32(m_handle, mcsmaxvelLoc, 10000000, _IMCCardInformation(Axis).AxisNo, TYPE_FIFO.SEL_IFIFO) '主坐标系点到点运动的规划速度
            If status = IMC_STATUS.IMC_OK Then
                Exit While
            Else
                System.Threading.Thread.Sleep(10)
            End If
        End While
        While True
            status = IMC_SetParam32(m_handle, mcsaccelLoc, 1000000, _IMCCardInformation(Axis).AxisNo, TYPE_FIFO.SEL_IFIFO)  '主坐标系加速度
            If status = IMC_STATUS.IMC_OK Then
                Exit While
            Else
                System.Threading.Thread.Sleep(10)
            End If
        End While
        While True
            'X 已OK （应该是vel，而不是pos）
            status = IMC_SetParam32(m_handle, mcstgvelLoc, 5000000, _IMCCardInformation(Axis).AxisNo, TYPE_FIFO.SEL_IFIFO) '主坐标系起始速度
            If status = IMC_STATUS.IMC_OK Then
                Exit While
            Else
                System.Threading.Thread.Sleep(10)
            End If
        End While
        While True
            status = IMC_SetParam32(m_handle, mcsdecelLoc, 1000000, _IMCCardInformation(Axis).AxisNo, TYPE_FIFO.SEL_IFIFO)  '主坐标系减速度
            If status = IMC_STATUS.IMC_OK Then
                Exit While
            Else
                System.Threading.Thread.Sleep(10)
            End If
        End While

    End Sub
    ''' <summary>
    ''' 检测马达是否处于停滞状态
    ''' </summary>
    ''' <param name="AxisNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MoveDone(ByVal AxisNo As Integer) As Boolean Implements InterfaceHandle.MoveDone
        Try
            If _IMCCardInformation.Count = 0 Then Return False
            If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
            If AxisInitalPara.AxisInitalParameter(AxisNo).IsNeedMotionDone = True Then
                Dim a, b As Short
                a = -1
                b = -1
                System.Threading.Thread.Sleep(1)
                IMC_GetParam16(_IMCCardInformation(AxisNo).CardHandle, movingLoc, a, _IMCCardInformation(AxisNo).AxisNo)
                IMC_GetParam16(_IMCCardInformation(AxisNo).CardHandle, mcsgoLoc, b, _IMCCardInformation(AxisNo).AxisNo)
                If a = 0 AndAlso b = 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Dim a, b As Short
                
                System.Threading.Thread.Sleep(1)
                IMC_GetParam16(_IMCCardInformation(AxisNo).CardHandle, movingLoc, a, _IMCCardInformation(AxisNo).AxisNo)
                ' IMC_GetParam16(_IMCCardInformation(AxisNo).CardHandle, mcsgoLoc, b, _IMCCardInformation(AxisNo).AxisNo)
                If a = 0 Then
                    Return True
                Else
                    Return False
                End If
            End If


        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    ''' <summary>
    ''' Jog
    ''' </summary>
    ''' <param name="AxisNo"></param>
    ''' <param name="VelSpeed"></param>
    ''' <param name="Pos"></param>
    ''' <param name="JogMode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function JOG(ByVal AxisNo As Integer, ByVal VelSpeed As Double, ByVal Pos As Integer, ByVal JogMode As Integer) As Boolean Implements InterfaceHandle.JOG
        If _IMCCardInformation.Count = 0 Then Return False
        If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
        Dim status As IMC_STATUS
        Dim StartReadTime As Date = Now

        While True
            If Now.Subtract(StartReadTime).TotalMilliseconds > 2 Then
                Exit While
            End If
        End While
        If JogMode = JogTpye.Speed Then
            status = IMC_MoveVelocity(_IMCCardInformation(AxisNo).CardHandle, VelSpeed, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
        Else
            status = IMC_MoveRelative(_IMCCardInformation(AxisNo).CardHandle, Pos, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
        End If
        If status <> IMC_STATUS.IMC_OK Then Return False
        Return True
    End Function

    Public IsHome As Boolean = False
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="AxisNo"></param>
    ''' <param name="JogMode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StopJog(ByVal AxisNo As Integer, ByVal JogMode As Integer) As Boolean Implements InterfaceHandle.StopJog
        Dim status As IMC_STATUS
        If _IMCCardInformation.Count = 0 Then Return False
        If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
        Dim StartReadTime As Date = Now

        While True
            If Now.Subtract(StartReadTime).TotalMilliseconds > 2 Then
                Exit While
            End If
        End While
        If JogMode = JogTpye.Speed Then
            status = IMC_MoveVelocity(_IMCCardInformation(AxisNo).CardHandle, 0, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
        Else
            status = IMC_SetParam16(_IMCCardInformation(AxisNo).CardHandle, mcsgoLoc, 0, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
        End If
        If status <> IMC_STATUS.IMC_OK Then Return False
        Return True
    End Function
    ''' <summary>
    ''' 对应轴相对位移
    ''' </summary>
    ''' <param name="AxisNo"></param>
    ''' <param name="pos"></param>
    ''' <param name="IntialVel"></param>
    ''' <param name="MaxVel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MoveVel(ByVal AxisNo As Integer, ByVal pos As Double, Optional ByVal IntialVel As Integer = 100000, Optional ByVal MaxVel As Integer = 10, Optional ByVal Timeout As Integer = 100) As Integer Implements InterfaceHandle.MoveVel
        If _IMCCardInformation.Count = 0 Then Return False
        Try
            _IsPauseThread = True
            'Dim PerPos As Double = _IMCCardInformation(AxisNo).Postion
            'If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
            Dim status As IMC_STATUS
            '  _IsPauseThread = True
            System.Threading.Thread.Sleep(1)
            If IsHome = True Then GoTo lbhome
            'SoftWareLimit
            Dim CurrentPostion As String = GetCurrentPos(AxisNo)
            If pos > 0 Then
                If AxisInitalPara.AxisInitalParameter(AxisNo).IsUseSoftLimitPostion = True Then
                    If (pos + CurrentPostion) >= AxisInitalPara.AxisInitalParameter(AxisNo).PostionLimitPostion Then
                        While True
                            status = IMC_MoveAbsolute(_IMCCardInformation(AxisNo).CardHandle, AxisInitalPara.AxisInitalParameter(AxisNo).PostionLimitPostion / _IMCCardInformation(AxisNo).Resoulotion, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                            If status = IMC_STATUS.IMC_OK Then
                                Exit While
                            Else
                                System.Threading.Thread.Sleep(10)
                            End If
                        End While
                    Else
                        While True
                            status = IMC_MoveRelative(_IMCCardInformation(AxisNo).CardHandle, pos / _IMCCardInformation(AxisNo).Resoulotion, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                            If status = IMC_STATUS.IMC_OK Then
                                Exit While
                            Else
                                System.Threading.Thread.Sleep(10)
                            End If
                        End While
                    End If
                Else
                    While True
                        status = IMC_MoveRelative(_IMCCardInformation(AxisNo).CardHandle, pos / _IMCCardInformation(AxisNo).Resoulotion, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                        If status = IMC_STATUS.IMC_OK Then
                            Exit While
                        Else
                            System.Threading.Thread.Sleep(10)
                        End If
                    End While
                End If
            Else
                If AxisInitalPara.AxisInitalParameter(AxisNo).IsUseSoftLimitNeg = True Then
                    If (pos + CurrentPostion) <= AxisInitalPara.AxisInitalParameter(AxisNo).NegLimitPostion Then
                        While True
                            status = IMC_MoveAbsolute(_IMCCardInformation(AxisNo).CardHandle, AxisInitalPara.AxisInitalParameter(AxisNo).NegLimitPostion / _IMCCardInformation(AxisNo).Resoulotion, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                            If status = IMC_STATUS.IMC_OK Then
                                Exit While
                            Else
                                System.Threading.Thread.Sleep(10)
                            End If
                        End While
                    Else
                        While True
                            status = IMC_MoveRelative(_IMCCardInformation(AxisNo).CardHandle, pos / _IMCCardInformation(AxisNo).Resoulotion, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                            If status = IMC_STATUS.IMC_OK Then
                                Exit While
                            Else
                                System.Threading.Thread.Sleep(10)
                            End If
                        End While
                    End If
                Else
                    While True
                        status = IMC_MoveRelative(_IMCCardInformation(AxisNo).CardHandle, pos / _IMCCardInformation(AxisNo).Resoulotion, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                        If status = IMC_STATUS.IMC_OK Then
                            Exit While
                        Else
                            System.Threading.Thread.Sleep(10)
                        End If
                    End While
                End If
            End If

            'While True
            '    status = IMC_MoveRelative(_IMCCardInformation(AxisNo).CardHandle, pos / _IMCCardInformation(AxisNo).Resoulotion, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
            '    If status = IMC_STATUS.IMC_OK Then
            '        Exit While
            '    Else
            '        System.Threading.Thread.Sleep(10)
            '    End If
            'End While
lbhome:
            If IsHome = True Then
                While True
                    status = IMC_MoveRelative(_IMCCardInformation(AxisNo).CardHandle, pos / _IMCCardInformation(AxisNo).Resoulotion, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                    If status = IMC_STATUS.IMC_OK Then
                        Exit While
                    Else
                        System.Threading.Thread.Sleep(10)
                    End If
                End While
            End If

            System.Threading.Thread.Sleep(10)
           MoveDone(AxisNo)
            _IsPauseThread = False
            Return status
        Catch ex As Exception

        End Try
        Return 0
    End Function
    Public Function MoveVelPlus(ByVal AxisNo As Integer, ByVal pos As Double, Optional ByVal IntialVel As Integer = 100000, Optional ByVal MaxVel As Integer = 10, Optional ByVal Timeout As Integer = 100) As Integer Implements InterfaceHandle.MoveVelPlus
        If _IMCCardInformation.Count = 0 Then Return False
        Try
            'Dim PerPos As Double = _IMCCardInformation(AxisNo).Postion
            'If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
            Dim status As IMC_STATUS
            ''SoftWareLimit
            'Dim CurrentPostion As String = GetCurrentPos(_IMCCardInformation(AxisNo).AxisNo)
            'If pos > 0 Then
            '    If AxisInitalPara.AxisInitalParameter(AxisNo).IsUseSoftLimitPostion = True Then
            '        If (pos * _IMCCardInformation(AxisNo).Resoulotion) > AxisInitalPara.AxisInitalParameter(AxisNo).PostionLimitPostion Then
            '            Return 0
            '        End If
            '    End If
            'Else
            '    If AxisInitalPara.AxisInitalParameter(AxisNo).IsUseSoftLimitNeg = True Then

            '        If pos <= AxisInitalPara.AxisInitalParameter(AxisNo).NegLimitPostion Then
            '            Return 0
            '        End If
            '    End If
            'End If
            '     _IsPauseThread = True
            System.Threading.Thread.Sleep(1)
            'SoftWareLimit
            Dim CurrentPostion As String = GetCurrentPos(_IMCCardInformation(AxisNo).AxisNo)
            If pos > 0 Then
                If AxisInitalPara.AxisInitalParameter(AxisNo).IsUseSoftLimitPostion = True Then
                    If pos >= AxisInitalPara.AxisInitalParameter(AxisNo).PostionLimitPostion Then
                        While True
                            status = IMC_MoveAbsolute(_IMCCardInformation(AxisNo).CardHandle, AxisInitalPara.AxisInitalParameter(AxisNo).PostionLimitPostion / _IMCCardInformation(AxisNo).Resoulotion, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                            If status = IMC_STATUS.IMC_OK Then
                                Exit While
                            Else
                                System.Threading.Thread.Sleep(10)
                            End If
                        End While
                    Else
                        While True
                            status = IMC_MoveAbsolute(_IMCCardInformation(AxisNo).CardHandle, pos / _IMCCardInformation(AxisNo).Resoulotion, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                            If status = IMC_STATUS.IMC_OK Then
                                Exit While
                            Else
                                System.Threading.Thread.Sleep(10)
                            End If
                        End While
                    End If
                End If
            Else
                If AxisInitalPara.AxisInitalParameter(AxisNo).IsUseSoftLimitNeg = True Then
                    If pos <= AxisInitalPara.AxisInitalParameter(AxisNo).NegLimitPostion Then
                        While True
                            status = IMC_MoveAbsolute(_IMCCardInformation(AxisNo).CardHandle, AxisInitalPara.AxisInitalParameter(AxisNo).NegLimitPostion / _IMCCardInformation(AxisNo).Resoulotion, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                            If status = IMC_STATUS.IMC_OK Then
                                Exit While
                            Else
                                System.Threading.Thread.Sleep(10)
                            End If
                        End While
                    Else
                        While True
                            status = IMC_MoveAbsolute(_IMCCardInformation(AxisNo).CardHandle, pos / _IMCCardInformation(AxisNo).Resoulotion, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                            If status = IMC_STATUS.IMC_OK Then
                                Exit While
                            Else
                                System.Threading.Thread.Sleep(10)
                            End If
                        End While
                    End If
                End If
            End If

            System.Threading.Thread.Sleep(10)
      MoveDone(AxisNo)

            Return status
        Catch ex As Exception

        End Try
        Return 0
    End Function
    ''' <summary>
    ''' 对应轴绝对位移
    ''' </summary>
    ''' <param name="AxisNo"></param>
    ''' <param name="pos"></param>
    ''' <param name="Timeout"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MoveAbs(ByVal AxisNo As Integer, ByVal pos As Double, Optional ByVal Timeout As Integer = 100) As Integer Implements InterfaceHandle.MoveAbs
        If _IMCCardInformation.Count = 0 Then Return False
        Try
            If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
            Dim status As IMC_STATUS
            Dim StartReadTime As Date = Now
            If IsHome = True Then GoTo lbhome
            _IsPauseThread = True
            Dim CurrentPostion As String = GetCurrentPos(AxisNo)
            If pos > 0 Then
                If AxisInitalPara.AxisInitalParameter(AxisNo).IsUseSoftLimitPostion = True Then
                    If pos >= AxisInitalPara.AxisInitalParameter(AxisNo).PostionLimitPostion Then
                        While True
                            status = IMC_MoveAbsolute(_IMCCardInformation(AxisNo).CardHandle, AxisInitalPara.AxisInitalParameter(AxisNo).PostionLimitPostion / _IMCCardInformation(AxisNo).Resoulotion, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                            If status = IMC_STATUS.IMC_OK Then
                                Exit While
                            Else
                                System.Threading.Thread.Sleep(10)
                            End If
                        End While
                    Else
                        While True
                            status = IMC_MoveAbsolute(_IMCCardInformation(AxisNo).CardHandle, pos / _IMCCardInformation(AxisNo).Resoulotion, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                            If status = IMC_STATUS.IMC_OK Then
                                Exit While
                            Else
                                System.Threading.Thread.Sleep(10)
                            End If
                        End While
                    End If
                Else
                    While True
                        status = IMC_MoveAbsolute(_IMCCardInformation(AxisNo).CardHandle, pos / _IMCCardInformation(AxisNo).Resoulotion, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                        If status = IMC_STATUS.IMC_OK Then
                            Exit While
                        Else
                            System.Threading.Thread.Sleep(10)
                        End If
                    End While
                End If
            Else
                If AxisInitalPara.AxisInitalParameter(AxisNo).IsUseSoftLimitNeg = True Then
                    If pos <= AxisInitalPara.AxisInitalParameter(AxisNo).NegLimitPostion Then
                        While True
                            status = IMC_MoveAbsolute(_IMCCardInformation(AxisNo).CardHandle, AxisInitalPara.AxisInitalParameter(AxisNo).NegLimitPostion / _IMCCardInformation(AxisNo).Resoulotion, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                            If status = IMC_STATUS.IMC_OK Then
                                Exit While
                            Else
                                System.Threading.Thread.Sleep(10)
                            End If
                        End While
                    Else
                        While True
                            status = IMC_MoveAbsolute(_IMCCardInformation(AxisNo).CardHandle, pos / _IMCCardInformation(AxisNo).Resoulotion, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                            If status = IMC_STATUS.IMC_OK Then
                                Exit While
                            Else
                                System.Threading.Thread.Sleep(10)
                            End If
                        End While
                    End If
                Else
                    While True
                        status = IMC_MoveAbsolute(_IMCCardInformation(AxisNo).CardHandle, pos / _IMCCardInformation(AxisNo).Resoulotion, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                        If status = IMC_STATUS.IMC_OK Then
                            Exit While
                        Else
                            System.Threading.Thread.Sleep(10)
                        End If
                    End While
                End If
            End If


lbhome:
            If IsHome = True Then
                While True
                    status = IMC_MoveAbsolute(_IMCCardInformation(AxisNo).CardHandle, pos / _IMCCardInformation(AxisNo).Resoulotion, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                    If status = IMC_STATUS.IMC_OK Then
                        Exit While
                    Else
                        System.Threading.Thread.Sleep(10)
                    End If
                End While
            End If


            System.Threading.Thread.Sleep(2)
          MoveDone(AxisNo)
            _IsPauseThread = False
            Return status
        Catch ex As Exception

        End Try
        Return 0
    End Function
    Enum HomeMode
        正方向
        负方向
    End Enum
    Private HomeThread As System.Threading.Thread
    Public WriteOnly Property HandleHome(ByVal obj As HomeParameter) As Boolean Implements InterfaceHandle.HandleHome
        Set(ByVal value As Boolean)
            If value = False Then
                If HomeThread IsNot Nothing Then
                    HomeThread.Abort()
                End If
            End If
            If value = True Then
                Dim s As System.Threading.ParameterizedThreadStart = New Threading.ParameterizedThreadStart(AddressOf Home)
                HomeThread = New Threading.Thread(s)
                HomeThread.IsBackground = True
                HomeThread.Start(obj)
            End If
        End Set
    End Property
    Private Function Home(ByVal obj As HomeParameter) As Boolean Implements InterfaceHandle.Home

        _IsPauseThread = False
        Dim AxisNo As Integer = obj._AxisNo
        Dim HomeDir As HomeMode = HomeMode.正方向
        Dim HomeSpeed As Double = 1000000
        Dim TimeOut As Double = 20
        IsHome = True
        If AxisInitalPara.AxisInitalParameter(obj._AxisNo).HomeDir = 0 Then
            HomeDir = HomeMode.正方向
        Else
            If AxisInitalPara.AxisInitalParameter(obj._AxisNo).HomeDir = 1 Then
                HomeDir = HomeMode.负方向
            Else
                If AxisInitalPara.AxisInitalParameter(obj._AxisNo).HomeDir = 3 Then
                    GoTo OnlyHomePEL
                Else
                    GoTo OnlyHomeMEL
                End If
            End If

        End If

        TimeOut = obj._TimeOut
        AxisNo = obj._AxisNo
        HomeSpeed = obj._HomeSpeed
        If _IMCCardInformation.Count = 0 Then Return False
        If AxisNo > _IMCCardInformation.Count - 1 Then Return False
        If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
        Dim status As IMC_STATUS
        ' 清0 
        status = IMC_SetParam16(_IMCCardInformation(AxisNo).CardHandle, clearLoc, -1, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)

        Dim HomeStartTime As Date = Now
        Dim InitalPara As New cAxisParameter
        For i As Int16 = 0 To AxisInitalPara.AxisInitalParameter.Length - 1
            If AxisNo = AxisInitalPara.AxisInitalParameter(i).AxisNo Then
                InitalPara = AxisInitalPara.AxisInitalParameter(i)
                Exit For
            End If
        Next
        If InitalPara.aioctrLoc <> 0 Then
            While True

                If Now.Subtract(HomeStartTime).TotalSeconds < TimeOut Then
                    If HomeDir = HomeMode.正方向 Then
                        If PLM(AxisNo) = False Then

                            JOG(AxisNo, HomeSpeed, 0, JogTpye.Speed)
                        Else
                            status = IMC_SetParam16(_IMCCardInformation(AxisNo).CardHandle, clearLoc, -1, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                            Exit While
                        End If
                    Else
                        If NLM(AxisNo) = False Then

                            JOG(AxisNo, -1 * HomeSpeed, 0, JogTpye.Speed)
                        Else
                            status = IMC_SetParam16(_IMCCardInformation(AxisNo).CardHandle, clearLoc, -1, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
                            Exit While
                        End If
                    End If
                Else
                    MessageBox.Show(AxisNo & "轴" & "回原点逾时")
                    _IMCCardInformation(AxisNo).IsHome = False
                    Return False
                End If

            End While

            status = IMC_HomeSwitch1(_IMCCardInformation(AxisNo).CardHandle, 0, 0, 1, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_QFIFO)
            If status <> cIMCHandle.IMC_STATUS.IMC_OK Then _IMCCardInformation(AxisNo).IsHome = False : Return False
            _IMCCardInformation(AxisNo).IsHome = True
            IsHome = False
            Return True
            Exit Function
        End If

        status = IMC_HomeSwitch1(_IMCCardInformation(AxisNo).CardHandle, 0, 0, 1, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_QFIFO)
        For i As Int16 = 0 To AxisInitalPara.AxisInitalParameter.Length - 1
            If AxisInitalPara.AxisInitalParameter(i).aioctrLoc = 0 Then
                If AxisNo = AxisInitalPara.AxisInitalParameter(i).AxisNo Then
                    Do
                        System.Threading.Thread.Sleep(1000)
                        If _IMCCardInformation(AxisNo).Postion = 0 Then
                            status = IMC_HomeSwitch1(_IMCCardInformation(AxisNo).CardHandle, 1, 0, 1, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_QFIFO)

                            GoTo overff
                            Exit Do
                        End If
                    Loop

                    '  
                End If
            End If
        Next
OnlyHomePEL:
        While True
            If PLM(obj._AxisNo) = False Then
                JOG(obj._AxisNo, HomeSpeed, 0, JogTpye.Speed)
            Else
                While True

                    JOG(obj._AxisNo, -1 * HomeSpeed * 0.1, 0, JogTpye.Speed)
                    If PLM(obj._AxisNo) = False Then
                        status = IMC_SetParam16(_IMCCardInformation(obj._AxisNo).CardHandle, clearLoc, -1, _IMCCardInformation(obj._AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)

                        Exit While
                    End If
                End While
                Exit While
            End If
        End While
OnlyHomeMEL:
        While True
            If NLM(obj._AxisNo) = False Then
                JOG(obj._AxisNo, -1 * HomeSpeed, 0, JogTpye.Speed)
            Else
                While True

                    JOG(obj._AxisNo, HomeSpeed * 0.1, 0, JogTpye.Speed)
                    If NLM(obj._AxisNo) = False Then
                        status = IMC_SetParam16(_IMCCardInformation(obj._AxisNo).CardHandle, clearLoc, -1, _IMCCardInformation(obj._AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)

                        Exit While
                    End If
                End While
                Exit While
            End If
        End While
overff:
        IsHome = False
        If status <> cIMCHandle.IMC_STATUS.IMC_OK Then _IMCCardInformation(AxisNo).IsHome = False : Return False
        _IMCCardInformation(AxisNo).IsHome = True
        Return True
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Timeout"></param>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function HomeAll(Optional ByVal Timeout As Integer = 10, Optional ByVal ID As Int16 = 0) As Boolean
        Dim status As IMC_STATUS
        If _IMCCardInformation.Count = 0 Then Return False
        For i As Integer = 0 To _IMCCardInformation.Count - 1

            If _IMCCardInformation(i).IsOpen = False Then Return False
            status = IMC_SetParam16(_IMCCardInformation(i).CardHandle, clearLoc, -1, _IMCCardInformation(i).AxisNo, TYPE_FIFO.SEL_IFIFO)       '清除各轴的位置值及状态,配置clear参数必须放在第一
            status = IMC_SetParam16(_IMCCardInformation(i).CardHandle, emstopLoc, 0, 0, TYPE_FIFO.SEL_IFIFO)
            status = IMC_HomeSwitch1(_IMCCardInformation(i).CardHandle, 0, 0, 1, _IMCCardInformation(i).AxisNo, TYPE_FIFO.SEL_QFIFO)
        Next
        Return True
    End Function
    ''' <summary>
    ''' 获取对应轴的位置
    ''' </summary>
    ''' <param name="AxisNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCurrentPos(ByVal AxisNo As Integer) As Double Implements InterfaceHandle.GetCurrentPos
        If _IMCCardInformation.Count = 0 Then Return False
        If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
        Dim status As IMC_STATUS
        Dim des As WR_MUL_DES
        des.addr = encpLoc
        des.axis = _IMCCardInformation(AxisNo).AxisNo
        des.len = 2
        Dim StartReadTime As Date = Now

        While True
            If Now.Subtract(StartReadTime).TotalMilliseconds > 1 Then
                Exit While
            End If
        End While
        System.Threading.Thread.Sleep(1)
        status = IMC_GetMulParam(_IMCCardInformation(AxisNo).CardHandle, des, 1)
        If status <> IMC_STATUS.IMC_OK Then Return -99
        Dim a As String = des.data_0 + des.data_1 * 65536
        _IMCCardInformation(AxisNo).Postion = a * _IMCCardInformation(AxisNo).Resoulotion
        Return _IMCCardInformation(AxisNo).Postion
    End Function
    ''' <summary>
    ''' 获取对应轴的位置
    ''' </summary>
    ''' <param name="AxisNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPos(ByVal AxisNo As Integer) As Double Implements InterfaceHandle.GetPos
        If _IMCCardInformation.Count = 0 Then Return False
        If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
        Dim status As IMC_STATUS
        Dim des As WR_MUL_DES
        des.addr = encpLoc
        des.axis = _IMCCardInformation(AxisNo).AxisNo
        des.len = 2
        Dim StartReadTime As Date = Now

        While True
            If Now.Subtract(StartReadTime).TotalMilliseconds > 1 Then
                Exit While
            End If
        End While
        System.Threading.Thread.Sleep(1)
        status = IMC_GetMulParam(_IMCCardInformation(AxisNo).CardHandle, des, 1)
        If status <> IMC_STATUS.IMC_OK Then Return -99
        Dim a As String = des.data_0 + des.data_1 * 65536
        _IMCCardInformation(AxisNo).Plus = a '/ _IMCCardInformation(AxisNo).Resoulotion
        Return a
    End Function
    ''' <summary>
    ''' 读取原点状态
    ''' </summary>
    ''' <param name="AxisNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ORG(ByVal AxisNo As Integer) As Boolean Implements InterfaceHandle.ORG
        If _IMCCardInformation.Count = 0 Then Return False
        If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
        Dim RefData As Short
        Dim status As IMC_STATUS = IMC_GetParamBit(_IMCCardInformation(AxisNo).CardHandle, aioLoc, RefData, 2, _IMCCardInformation(AxisNo).AxisNo)
        If status <> IMC_STATUS.IMC_OK Then Return False
        Return IIf(RefData = 0, True, False)
    End Function
    ''' <summary>
    ''' 读取正极限状态
    ''' </summary>
    ''' <param name="AxisNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PLM(ByVal AxisNo As Integer) As Boolean Implements InterfaceHandle.PLM

        If _IMCCardInformation.Count = 0 Then Return False
        If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
        Dim RefData As Short
        Dim InitalPara As New cAxisParameter
        For i As Int16 = 0 To AxisInitalPara.AxisInitalParameter.Length - 1
            If AxisNo = AxisInitalPara.AxisInitalParameter(i).AxisNo Then
                InitalPara = AxisInitalPara.AxisInitalParameter(i)
                Exit For
            End If
        Next

        If InitalPara.aioctrLoc = 0 Then Return False
        If AxisInitalPara.AxisInitalParameter(AxisNo).IsUseSoftLimitPostion = True AndAlso IsHome = False Then
            Dim Postion As String = GetCurrentPos(AxisNo)
            'If Postion > AxisInitalPara.AxisInitalParameter(AxisNo).PostionLimitPostion Then
            '    Return True
            'End If
        End If
        Dim status As IMC_STATUS = IMC_GetParamBit(_IMCCardInformation(AxisNo).CardHandle, aioLoc, RefData, 0, _IMCCardInformation(AxisNo).AxisNo)
        If status <> IMC_STATUS.IMC_OK Then Return False
        Return IIf(RefData = 1, True, False)
    End Function
    ''' <summary>
    ''' 读取负极限状态
    ''' </summary>
    ''' <param name="AxisNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function NLM(ByVal AxisNo As Integer) As Boolean Implements InterfaceHandle.NLM
        If _IMCCardInformation.Count = 0 Then Return False
        If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
        Dim RefData As Short
        Dim InitalPara As New cAxisParameter
        For i As Int16 = 0 To AxisInitalPara.AxisInitalParameter.Length - 1
            If AxisNo = AxisInitalPara.AxisInitalParameter(i).AxisNo Then
                InitalPara = AxisInitalPara.AxisInitalParameter(i)
                Exit For
            End If
        Next
        If InitalPara.aioctrLoc = 0 Then Return False

        If AxisInitalPara.AxisInitalParameter(AxisNo).aioctrLoc = 0 Then Return True

        If InitalPara.IsUseSoftLimitNeg = True AndAlso IsHome = False Then
            'Dim Postion As String = GetCurrentPos(AxisNo)
            'If Val(Postion) < Val(AxisInitalPara.AxisInitalParameter(AxisNo).NegLimitPostion) Then
            '    Return True
            'Else
            '    Return False
            'End If
        End If
        Dim status As IMC_STATUS = IMC_GetParamBit(_IMCCardInformation(AxisNo).CardHandle, aioLoc, RefData, 1, _IMCCardInformation(AxisNo).AxisNo)
        If status <> IMC_STATUS.IMC_OK Then Return False
        Return IIf(RefData = 1, True, False)
    End Function
    Public Function ErrorValue(ByVal AxisNo As Int16) As String Implements InterfaceHandle.ErrorValue
        If _IMCCardInformation.Count = 0 Then Return -9
        If _IMCCardInformation(AxisNo).IsOpen = False Then Return -9
        Dim status As IMC_STATUS
        Dim des As WR_MUL_DES
        des.addr = errorLoc
        des.axis = _IMCCardInformation(AxisNo).AxisNo
        des.len = 1
        status = IMC_GetMulParam(_IMCCardInformation(AxisNo).CardHandle, des, 1)
        'out info 
        If AxisNo = 0 Then Debug.WriteLine(Now & " " & _IMCCardInformation(AxisNo).CardHandle & ": " & des.data_0)
        '
        If status <> IMC_STATUS.IMC_OK Then Return 0
        _IMCCardInformation(AxisNo).ErrorMessage = des.data_0
        Return _IMCCardInformation(AxisNo).ErrorMessage
    End Function
    Private Function Ch10_2(ByVal V As Int32) As Boolean()
        Dim S As String
        Dim B(15) As Boolean
        Try
            S = Convert.ToString(V, 2)
            For i As Integer = 0 To S.Length - 1
                B(i) = (S.Substring(S.Length - i - 1, 1) = "1")
            Next i
        Catch ex As Exception

        End Try
        Return B
    End Function
    ''' <summary>
    ''' 设置输出端口及读取端口
    ''' </summary>
    ''' <param name="Index">端口号</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WriteOut(ByVal Index As Integer, Optional ByVal AxisNo As Int16 = 0) As Boolean Implements InterfaceHandle.WriteOut

        Set(ByVal value As Boolean)

            If _IMCCardInformation.Count = 0 Then Return
            If _IMCCardInformation(AxisNo).IsOpen = False Then Return
            Dim status As IMC_STATUS
            While True
                status = IMC_SetParamBit(_IMCCardInformation(AxisNo).CardHandle, gout1Loc, Index, value, 0, TYPE_FIFO.SEL_QFIFO)
                If status = IMC_STATUS.IMC_OK Then
                    Exit While
                Else
                    If status = IMC_STATUS.IMC_INVALID_PARAM Then Exit While
                    System.Threading.Thread.Sleep(10)
                End If
            End While




        End Set
        Get

            If _IMCCardInformation.Count = 0 Then Return False
            If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
            Dim RefStatus As Short
            Dim status As IMC_STATUS
            While True
                status = IMC_GetParamBit(_IMCCardInformation(AxisNo).CardHandle, gout1Loc, RefStatus, Index, 0)
                If status = IMC_STATUS.IMC_OK Then
                    Exit While
                Else
                    If status = IMC_STATUS.IMC_INVALID_PARAM Then Exit While
                    System.Threading.Thread.Sleep(10)
                End If
            End While

            If RefStatus <> 1 Then Return False


            Return True
        End Get
    End Property

    Public ReadOnly Property ReadIn(ByVal Index As Integer, Optional ByVal AxisNo As Int16 = 0) As Boolean Implements InterfaceHandle.ReadIn
        Get

            If _IMCCardInformation.Count = 0 Then Return False
            If _IMCCardInformation(AxisNo).IsOpen = False Then Return False
            Dim RefStatus As Short
            Dim status As IMC_STATUS = IMC_GetParamBit(_IMCCardInformation(AxisNo).CardHandle, gin1Loc, RefStatus, Index, 0)
            If RefStatus <> 0 Then Return False


            Return True
        End Get
    End Property

    Public Sub CloseCard() Implements InterfaceHandle.CloseCard '(ByVal AxisNo As Int16)
        If _IMCCardInformation.Count = 0 Then Return
        For i = 0 To _IMCCardInformation.Count - 1

            Dim status As IMC_STATUS = IMC_Close(_IMCCardInformation(i).CardHandle)
        Next

    End Sub
    Public Property EMS(ByVal AxisNo As Integer, Optional ByVal IsEMS As Boolean = False) As Boolean Implements InterfaceHandle.EMS
        Get
            Return True
        End Get
        Set(ByVal value As Boolean)
            If _IMCCardInformation.Count = 0 Then Return
            If IsEMS = False Then
                IMC_SetParam16(_IMCCardInformation(AxisNo).CardHandle, mcsgoLoc, 0, _IMCCardInformation(AxisNo).AxisNo, TYPE_FIFO.SEL_IFIFO)
            Else
                IMC_SetParam16(_IMCCardInformation(AxisNo).CardHandle, emstopLoc, 16, 0, TYPE_FIFO.SEL_IFIFO)
            End If
        End Set
    End Property

#Region "IDisposable Support"
    Private disposedValue As Boolean ' 偵測多餘的呼叫

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 處置 Managed 狀態 (Managed 物件)。
            End If

            ' TODO: 釋放 Unmanaged 資源 (Unmanaged 物件) 並覆寫下面的 Finalize()。
            ' TODO: 將大型欄位設定為 null。
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: 只有當上面的 Dispose(ByVal disposing As Boolean) 有可釋放 Unmanaged 資源的程式碼時，才覆寫 Finalize()。
    'Protected Overrides Sub Finalize()
    '    ' 請勿變更此程式碼。在上面的 Dispose(ByVal disposing As Boolean) 中輸入清除程式碼。
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
        Dispose(True)
        If DataRefreshThread Is Nothing Then
            DataRefreshThread.Abort()
        End If
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Private Sub Trm_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Trm.Tick
        Trm.Stop()
        RefreshData()
        Trm.Start()
    End Sub



    Public ReadOnly Property _IMCCardInformation1 As List(Of IMCCardInforMation) Implements InterfaceHandle._IMCCardInformation
        Get
            Return _IMCCardInformation
        End Get
    End Property

    Public Property _IsPauseThread1 As Boolean Implements InterfaceHandle._IsPauseThread
        Get
            Return _IsPauseThread
        End Get
        Set(value As Boolean)
            _IsPauseThread = value
        End Set
    End Property
    Public Property _NetCardInformation1 As List(Of NetCardInforMation) Implements InterfaceHandle._NetCardInformation
        Get
            Return _NetCardInformation
        End Get
        Set(value As List(Of NetCardInforMation))
            _NetCardInformation = value
        End Set
    End Property
End Class
Public Class NetCardInforMation
    Private _CardID As Int16
    Private _CardInfor As String
    Public Property CardID As Int16
        Get
            Return _CardID
        End Get
        Set(ByVal value As Int16)
            _CardID = value
        End Set
    End Property
    Public Property CardInfor As String
        Get
            Return _CardInfor
        End Get
        Set(ByVal value As String)
            _CardInfor = value
        End Set
    End Property
End Class
Public Class IMCCardInforMation
    Private _Org As Boolean
    Public Property Org As Boolean
        Get
            Return _Org
        End Get
        Set(ByVal value As Boolean)
            _Org = value
        End Set
    End Property
    Private _PLM As Boolean
    Public Property PLM As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
            _PLM = value
        End Set
    End Property
    Private _NLM As Boolean
    Public Property NLM As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
            _NLM = value
        End Set
    End Property
    Private _IsOpen As Boolean
    Public Property IsOpen As Boolean
        Get
            Return _IsOpen
        End Get
        Set(ByVal value As Boolean)
            _IsOpen = value
        End Set
    End Property
    Private _IsHome As Boolean
    Public Property IsHome As Boolean
        Get
            Return _IsHome
        End Get
        Set(ByVal value As Boolean)
            _IsHome = value
        End Set
    End Property
    Private _MotionDone As Boolean
    Public Property MotionDone As Boolean
        Get

            Return _MotionDone
        End Get
        Set(ByVal value As Boolean)
            _MotionDone = value
        End Set
    End Property
    Private _CardID As Int16
    Public Property CardID As Int16
        Get
            Return _CardID
        End Get
        Set(ByVal value As Int16)
            _CardID = value
        End Set
    End Property

    Private _AxisNo As Int16
    Public Property AxisNo As Int16
        Get
            Return _AxisNo
        End Get
        Set(ByVal value As Int16)
            _AxisNo = value
        End Set
    End Property
    Private _CardHandle As Integer
    Public Property CardHandle As Integer
        Get
            Return _CardHandle
        End Get
        Set(ByVal value As Integer)
            _CardHandle = value
        End Set
    End Property
    Private _Plus As String
    Public Property Plus() As Double
        Get
            Return _Plus
        End Get
        Set(ByVal value As Double)
            _Plus = value
        End Set
    End Property
    Private _Postion As String
    Public Property Postion() As Double
        Get
            Return _Postion
        End Get
        Set(ByVal value As Double)
            _Postion = value
        End Set
    End Property
    Private _ErrorMessage As String
    Public Property ErrorMessage As String
        Get
            Return _ErrorMessage
        End Get
        Set(ByVal value As String)
            _ErrorMessage = value
        End Set
    End Property
    Private _Resoulotion As Double
    Public Property Resoulotion As Double
        Get
            Dim Temp As String = Ini.GetINIValue("AxisResoulotion", "Axis" & AxisNo + CardID * 4, IniFile)
            Try
                _Resoulotion = Convert.ToDouble(Temp)
            Catch ex As Exception
                _Resoulotion = 10
                Ini.WriteINIValue("AxisResoulotion", "Axis" & AxisNo + CardID * 4, _Resoulotion, IniFile)
            End Try


            Return _Resoulotion
        End Get

        Set(value As Double)
            Ini.WriteINIValue("AxisResoulotion", "Axis" & AxisNo + CardID * 4, value, IniFile)
        End Set
    End Property
End Class
Public Class HomeParameter
    Public _AxisNo As Integer
    Public _HomeDir As cIMCHandle.HomeMode = cIMCHandle.HomeMode.正方向
    Public _HomeSpeed As Double = 1000000
    Public _TimeOut As Double = 20
    Sub New(ByVal AxisNo As Integer, Optional ByVal HomeDir As cIMCHandle.HomeMode = cIMCHandle.HomeMode.正方向, Optional ByVal HomeSpeed As Double = 1000000, Optional ByVal TimeOut As Double = 20)
        _AxisNo = AxisNo
        _HomeDir = HomeDir
        _HomeSpeed = HomeSpeed
        _TimeOut = TimeOut
    End Sub
End Class