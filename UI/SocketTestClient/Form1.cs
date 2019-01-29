using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Google.Protobuf;
using Socket.Core;
using Socket.Core.Model;
using SocketCmd;

namespace SocketTestClient
{
    public partial class Form1 : Form
    {
        //private static int currentOrderId;
        public Form1()
        {
            InitializeComponent();
            ContextMenuStrip listboxMenu = new ContextMenuStrip();
            ToolStripMenuItem rightMenu = new ToolStripMenuItem("Copy");
            rightMenu.Click += Copy_Click;
            listboxMenu.Items.AddRange(new ToolStripItem[] { rightMenu });
            lstMsg.ContextMenuStrip = listboxMenu;

            SocketConnectionClient.ClientSocketStarting(new SocketConnectConfig()
            {
                //ConnectCallback = con =>
                //{
                //    var message = new Hellomessage
                //    {
                //        Identity = Guid.NewGuid().ToString("N"),
                //        Cmdcode = "0000",
                //        Timetoken = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")
                //    };
                //    con.Identity = message.Identity;
                //    con.Send(message.ToByteArray());
                //},
                ReceiveCallback = (bytes, con) =>
                {
                    var header = CmdHeader.Parser.ParseFrom(bytes);
                    //var msg = Hellomessage.Parser.ParseFrom(bytes);
                    lstMsg.Invoke(new Action(() =>
                    {
                        lstMsg.Items.Add($"接收header[{header}]");
                    }));
                    switch (header.CmdCode)
                    {
                        case 0xFF01://硬件注册后，上位机返回
                            break;
                        case 0xFF02://登录后，上位机返回
                            break;
                        case 0xFF03://硬件上报状态后，上位机返回
                            break;
                        case 0x0203://下单前查询设备状态
                            break;
                        case 0x0204://用户设置上报时间间隔
                            var timeSpan=SettingsTimeSpan.Parser.ParseFrom(bytes);
                            var timeSpanBk=new CmdHeader
                            {
                                CmdCode = 0x0104,
                                Identity = timeSpan.OppositeId,
                                OppositeId = timeSpan.Identity,
                                ServerId = header.ServerId,
                                ResultCode = 1,
                                //TimeToken = header.TimeToken
                            };
                            con.Send(timeSpanBk.ToByteArray());
                            break;
                        case 0x0205://返回添加格子、灯
                            var addLightBk = new CmdHeader
                            {
                                CmdCode = 0x0105,
                                Identity = header.OppositeId,
                                OppositeId = header.Identity,
                                ServerId = header.ServerId,
                                ResultCode = 1,
                                //TimeToken = header.TimeToken
                            };
                            con.Send(addLightBk.ToByteArray());
                            break;
                        case 0x0206://删除灯
                            //var removeLightBk = new CmdHeader
                            //{
                            //    CmdCode = "0106",
                            //    Identity = header.OppositeId,
                            //    OppositeId = header.Identity,
                            //    ServerId = header.ServerId,
                            //    ResultCode = 1,
                            //    //TimeToken = header.TimeToken
                            //};
                            var removeLight = RemoveLight.Parser.ParseFrom(bytes);
                            var removeLightBk = new ComDealBk
                            {
                                CmdCode = "0106",
                                Identity = header.OppositeId,
                                OppositeId = header.Identity,
                                ServerId = header.ServerId,
                                ResultCode = 1
                            };
                            foreach (var c in removeLight.CellAddrs)
                            {
                                removeLightBk.Res.Add(new DealRes()
                                {
                                    CellAddr = c,
                                    ResultCode = 1
                                });
                            }
                            con.Send(removeLightBk.ToByteArray());
                            break;
                        case 0x0207://设置中继开关
                            var openDeviceBk = new CmdHeader
                            {
                                CmdCode = 0x0107,
                                Identity = header.OppositeId,
                                OppositeId = header.Identity,
                                ServerId = header.ServerId,
                                ResultCode = 1,
                                //TimeToken = header.TimeToken
                            };
                            con.Send(openDeviceBk.ToByteArray());
                            break;
                        case 0x0208://设置路灯开关
                            var openLight = OpenLight.Parser.ParseFrom(bytes);
                            //var lightBk = new OpenLightBk
                            //{
                            //    CmdCode = "0108",
                            //    Identity = openLight.OppositeId,
                            //    OppositeId = openLight.Identity,
                            //    ServerId = openLight.ServerId,
                            //    ResultCode = 1,
                            //    Status = openLight.Status,
                            //    LightNos =
                            //    {
                            //        openLight.LightNos
                            //    },
                            //    //TimeToken = header.TimeToken
                            //};
                            var lightBk = new ComDealBk
                            {
                                CmdCode = "0108",
                                Identity = header.OppositeId,
                                OppositeId = header.Identity,
                                ServerId = header.ServerId,
                                ResultCode = 1
                            };
                            foreach (var c in openLight.CellAddrs)
                            {
                                lightBk.Res.Add(new DealRes()
                                {
                                    CellAddr = c,
                                    ResultCode = openLight.CellAddrs.Count > 1 ? 0 : 1
                                });
                            }
                            con.Send(lightBk.ToByteArray());
                            break;
                        case 0x0209://设置路灯开/关功率上下限值
                            //var pbk = new CmdHeader
                            //{
                            //    CmdCode = "0109",
                            //    Identity = header.OppositeId,
                            //    OppositeId = header.Identity,
                            //    ServerId = header.ServerId,
                            //    ResultCode = 1,
                            //    //TimeToken = header.TimeToken
                            //};
                            var setp = SettingsRange.Parser.ParseFrom(bytes);
                            var cdpk = new ComDealBk
                            {
                                CmdCode = "0109",
                                Identity = header.OppositeId,
                                OppositeId = header.Identity,
                                ServerId = header.ServerId,
                                ResultCode = 1
                            };
                            foreach (var c in setp.CellAddrs)
                            {
                                cdpk.Res.Add(new DealRes()
                                {
                                    CellAddr = c,
                                    ResultCode = setp.CellAddrs.Count > 1 ? 0 : 1
                                });
                            }
                            con.Send(cdpk.ToByteArray());
                            break;
                        case 0x020A://设置路灯开/关电压上下限值
                            //var ubk = new CmdHeader
                            //{
                            //    CmdCode = "010A",
                            //    Identity = header.OppositeId,
                            //    OppositeId = header.Identity,
                            //    ServerId = header.ServerId,
                            //    ResultCode = 1,
                            //    //TimeToken = header.TimeToken
                            //};
                            var setu = SettingsRange.Parser.ParseFrom(bytes);
                            var cduk = new ComDealBk
                            {
                                CmdCode = "010A",
                                Identity = header.OppositeId,
                                OppositeId = header.Identity,
                                ServerId = header.ServerId,
                                ResultCode = 1
                            };
                            foreach (var c in setu.CellAddrs)
                            {
                                cduk.Res.Add(new DealRes()
                                {
                                    CellAddr = c,
                                    ResultCode = setu.CellAddrs.Count > 1 ? 0 : 1
                                });
                            }
                            con.Send(cduk.ToByteArray());
                            break;
                        case 0x020B://设置温度上下限值
                            //var tembk = new CmdHeader
                            //{
                            //    CmdCode = "010B",
                            //    Identity = header.OppositeId,
                            //    OppositeId = header.Identity,
                            //    ServerId = header.ServerId,
                            //    ResultCode = 1,
                            //    //TimeToken = header.TimeToken
                            //};
                            var sett = SettingsRange.Parser.ParseFrom(bytes);
                            var cdtk = new ComDealBk
                            {
                                CmdCode = "010B",
                                Identity = header.OppositeId,
                                OppositeId = header.Identity,
                                ServerId = header.ServerId,
                                ResultCode = 1
                            };
                            foreach (var c in sett.CellAddrs)
                            {
                                cdtk.Res.Add(new DealRes()
                                {
                                    CellAddr = c,
                                    ResultCode = sett.CellAddrs.Count > 1 ? 0 : 1
                                });
                            }
                            con.Send(cdtk.ToByteArray());
                            break;
                        case 0x020C://设置阶段点
                            //var stageBk = new CmdHeader
                            //{
                            //    CmdCode = "010C",
                            //    Identity = header.OppositeId,
                            //    OppositeId = header.Identity,
                            //    ServerId = header.ServerId,
                            //    ResultCode = 1,
                            //    //TimeToken = header.TimeToken
                            //};
                            var setr = SettingsRange.Parser.ParseFrom(bytes);
                            var cdrk = new ComDealBk
                            {
                                CmdCode = "010C",
                                Identity = header.OppositeId,
                                OppositeId = header.Identity,
                                ServerId = header.ServerId,
                                ResultCode = 1
                            };
                            foreach (var c in setr.CellAddrs)
                            {
                                cdrk.Res.Add(new DealRes()
                                {
                                    CellAddr = c,
                                    ResultCode = setr.CellAddrs.Count > 1 ? 0 : 1
                                });
                            }
                            con.Send(cdrk.ToByteArray());
                            break;
                        case 0x020D://中继器重置
                            var restBk = new CmdHeader
                            {
                                CmdCode = 0x010D,
                                Identity = header.OppositeId,
                                OppositeId = header.Identity,
                                ServerId = header.ServerId,
                                ResultCode = 1,
                                //TimeToken = header.TimeToken
                            };
                            con.Send(restBk.ToByteArray());
                            break;
                        case 0x020E://设置默认功率
                            var dpBk = new CmdHeader
                            {
                                CmdCode = 0x010E,
                                Identity = header.OppositeId,
                                OppositeId = header.Identity,
                                ServerId = header.ServerId,
                                ResultCode = 1,
                                //TimeToken = header.TimeToken
                            };
                            con.Send(dpBk.ToByteArray());
                            break;
                        case 0xFF0F://硬件发送报警信息返回
                            break;
                    }
                },
                ShowMsg = msg =>
                {
                    lstMsg.Invoke(new Action(() =>
                    {
                        lstMsg.Items.Add(msg);
                    }));
                },
                SocketConnectExceptionCallback = ex =>
                {
                    lstMsg.Invoke(new Action(() =>
                    {
                        lstMsg.Items.Add(ex.Message);
                    }));
                },
                BeforeSend = (bs,con) =>
                {
                    var cmdHeader = CmdHeader.Parser.ParseFrom(bs);
                    lstMsg.Invoke(new Action(() =>
                    {
                        lstMsg.Items.Add($"耗时:{DateTime.Now-con.LastSessionTime}发送header{cmdHeader}");
                    }));
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!SocketConnectionClient.SocketClient.Connected || txtMsg.TextLength == 0) return;
            #region 发送二进制消息
            if (!chxSendMsg.Checked)
            {
                var hexReg = new Regex("(\\d|[A-F])+");
                var match = hexReg.Matches(txtMsg.Text);
                if (match.Count > 0)
                {
                    var bytes = new byte[match.Count];
                    for (int i = 0; i < match.Count; i++)
                    {
                        bytes[i] = Convert.ToByte(match[i].Value, 16);
                    }
                    txtMsg.BackColor = Color.White;
                    SocketConnectionClient.SocketClientConnection.Send(bytes);
                }
                else
                {
                    txtMsg.BackColor = Color.Red;
                }
            }
            else
            {
                var message = new Hellomessage()
                {
                    Identity = SocketConnectionClient.SocketClientConnection.Identity,
                    Cmdcode = "0002",
                    Timetoken = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    Msg = txtMsg.Text
                };
                lstMsg.Items.Add($"发送消息[{txtMsg.Text}]");
                SocketConnectionClient.SocketClientConnection.Send(message.ToByteArray());
            }
            #endregion
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            string copyText = "";
            foreach (object t in lstMsg.SelectedItems)
            {
                copyText = copyText + Environment.NewLine + t;
            }
            Clipboard.SetText(copyText);
        }

        #region device
        private static string CurrentTime  => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        private static string DeviceIdentity = "ZZCY5ccf7fdf754c";
        private static string DeviceLightNo = "1111111111";
        /// <summary>
        /// 设备注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcute_Click(object sender, EventArgs e)
        {
            Register register = new Register
            {
                CmdCode = "0101",
                Iccid = "123456789abcdefg",
                Identity = DeviceIdentity,
                ImeiVersion = "1.0.0",//设备版本号
                ImeiType = "BF00",//设备类型
                //TimeToken = CurrentTime
            };
            SocketConnectionClient.SocketClientConnection.Send(register.ToByteArray());
        }

        /// <summary>
        /// 硬件登录
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            CmdHeader register = new CmdHeader
            {
                CmdCode = 0x0102,
                Identity = DeviceIdentity,
                //TimeToken = CurrentTime
            };
            SocketConnectionClient.SocketClientConnection.Send(register.ToByteArray());
        }

        /// <summary>
        /// 设备上报状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUploadState_Click(object sender, EventArgs e)
        {
            //售卖柜项目
            //var dto = new DeviceStatusPb
            //{
            //    CmdCode = "0103",
            //    Identity = "ZZCY5ccf7fdf754c",
            //    TimeToken = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
            //    Status = "000000000"//第0位是门上锁的状态
            //};
            //早餐柜项目
            //var dto = new DeviceStatusFdPb
            //{
            //    CmdCode = "0103",
            //    Identity = "ZZCY5ccf7fdf754c",
            //    TimeToken = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
            //    Temperature = 200,
            //    Wetness = 60,
            //    Status = "00000000"//货物状态
            //};
            //智能路灯
            var dto=new DeviceStatus
            {
                CmdCode = "0103",
                Identity = DeviceIdentity,
                //TimeToken = CurrentTime,
                LightStatus = new LightStatus
                {
                    Status = "1",
                    CellAddr = 0,
                    //LightNo = DeviceLightNo,
                    LightBgus = { new[] { 5, 5, 5, 5 } },
                    LightBt = 50,
                    LightUu = 10,
                    LightLi = 1,
                    LightPw = 500,
                    LightBu = 10,
                    LightLu = 5,
                    LightUi = 1
                }
                //{
                //    new List<LightStatus>()
                //    {
                //        new LightStatus
                //        {
                //            Status = "1",
                //            CellAddr = 0,
                //            //LightNo = DeviceLightNo,
                //            LightBgus = { new [] { 5,5,5,5}},
                //            LightBt = 50,
                //            LightUu = 10,
                //            LightLi = 1,
                //            LightPw = 500,
                //            LightBu = 10,
                //            LightLu = 5,
                //            LightUi = 1
                //        }
                //    }
                //}
            };
            SocketConnectionClient.SocketClientConnection.Send(dto.ToByteArray());
        }

        /// <summary>
        /// 设备警报
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendWaring_Click(object sender, EventArgs e)
        {
            var dto = new Waring()
            {
                CmdCode = "010F",
                Identity = DeviceIdentity,
                LightNo = DeviceLightNo,
                WaringCode = "0001",
                WaringDesc = "电池温度过高",
                //TimeToken = CurrentTime
            };
            SocketConnectionClient.SocketClientConnection.Send(dto.ToByteArray());
        }
        
        #endregion

        #region User

        private static string UserIdentity = "15737936731";
        private static uint[] CellAddrs = new uint[] {0, 1, 2, 3};
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUserLogin_Click(object sender, EventArgs e)
        {
            var register = new CmdHeader
            {
                CmdCode = 0x0202,
                Identity = UserIdentity,
                //TimeToken = CurrentTime
            };
            SocketConnectionClient.SocketClientConnection.Send(register.ToByteArray());
        }
        
        /// <summary>
        /// 查询设备状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQryDeviceState_Click(object sender, EventArgs e)
        {
            var dto = new CmdHeader()
            {
                CmdCode = 0x0203,
                Identity = UserIdentity,
                OppositeId = DeviceIdentity,
                //TimeToken = CurrentTime
            };
            SocketConnectionClient.SocketClientConnection.Send(dto.ToByteArray());
        }

        /// <summary>
        /// 设置上报时间间隔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetUploadTimeSpan_Click(object sender, EventArgs e)
        {
            var setTimeSpan=new SettingsTimeSpan
            {
                CmdCode = "0204",
                Identity = UserIdentity,
                OppositeId = DeviceIdentity,
                TimeSpan = 2*60,
                //TimeToken = CurrentTime
            };
            SocketConnectionClient.SocketClientConnection.Send(setTimeSpan.ToByteArray());
        }

        /// <summary>
        /// 添加灯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBhOpenLock_Click(object sender, EventArgs e)
        {
            var dto = new AddLight
            {
                CmdCode = "0205",
                Identity = UserIdentity,
                OppositeId = DeviceIdentity,
                LightNo = DeviceLightNo,
                CellAddr = 0,
                //TimeToken = CurrentTime
            };
            SocketConnectionClient.SocketClientConnection.Send(dto.ToByteArray());
        }

        /// <summary>
        /// 删除灯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFullProduct_Click(object sender, EventArgs e)
        {
            var dto = new RemoveLight
            {
                CmdCode = "0206",
                Identity = UserIdentity,
                OppositeId = DeviceIdentity,
                CellAddrs =
                {
                    CellAddrs
                }
                //LightNo = DeviceLightNo,
                //CellAddr = 0,
                //TimeToken = CurrentTime
            };
            SocketConnectionClient.SocketClientConnection.Send(dto.ToByteArray());
        }

        /// <summary>
        /// 设置中继开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenDevice_Click(object sender, EventArgs e)
        {
            var dto = new OpenDevice
            {
                CmdCode = "0207",
                Identity = UserIdentity,
                OppositeId = DeviceIdentity,
                Status = "1",
                //TimeToken = CurrentTime
            };
            SocketConnectionClient.SocketClientConnection.Send(dto.ToByteArray());
        }
        /// <summary>
        /// 设置路灯开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetTem_Click(object sender, EventArgs e)
        {
            var dto = new OpenLight
            {
                CmdCode = "0208",
                Identity = UserIdentity,
                OppositeId = DeviceIdentity,
                Status = "1",
                CellAddrs = { CellAddrs }
                //LightNos = { DeviceLightNo },
                //TimeToken = CurrentTime
            };
            SocketConnectionClient.SocketClientConnection.Send(dto.ToByteArray());
        }

        /// <summary>
        /// 设置路灯开/关功率上下限值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetWet_Click(object sender, EventArgs e)
        {
            var dto = new SettingsRange
            {
                CmdCode = "0209",
                Identity = UserIdentity,
                OppositeId = DeviceIdentity,
                LowValue = 10,
                HeighValue = 20,
                CellAddrs = { CellAddrs}
                //TimeToken = CurrentTime
            };
            SocketConnectionClient.SocketClientConnection.Send(dto.ToByteArray());
        }

        /// <summary>
        /// 设置路灯开/关电压上下限值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetTemRange_Click(object sender, EventArgs e)
        {
            var dto = new SettingsRange
            {
                CmdCode = "020A",
                Identity = UserIdentity,
                OppositeId = DeviceIdentity,
                LowValue = 5,
                HeighValue = 10,
                CellAddrs = { CellAddrs}
                //TimeToken = CurrentTime
            };
            SocketConnectionClient.SocketClientConnection.Send(dto.ToByteArray());
        }

        /// <summary>
        /// 设置温度上下限值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetWetRange_Click(object sender, EventArgs e)
        {
            var dto = new SettingsRange
            {
                CmdCode = "020B",
                Identity = UserIdentity,
                OppositeId = DeviceIdentity,
                LowValue = 5,
                HeighValue = 10,
                CellAddrs = { CellAddrs}
                //TimeToken = CurrentTime
            };
            SocketConnectionClient.SocketClientConnection.Send(dto.ToByteArray());
        }

        /// <summary>
        /// 设置阶段点功率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStage_Click(object sender, EventArgs e)
        {
            var dto = new SettingsStage
            {
                CmdCode = "020C",
                Identity = UserIdentity,
                OppositeId = DeviceIdentity,
                Stage = { new List<Stage>
                {
                    new Stage
                    {
                        Stage_ = 1,
                        StageBeginTime = "1:00:00",
                        Value = 10
                    },new Stage
                    {
                        Stage_ = 2,
                        StageBeginTime = "5:00:00",
                        Value = 20
                    },new Stage
                    {
                        Stage_ = 3,
                        StageBeginTime = "18:00:00",
                        Value = 30
                    },new Stage
                    {
                        Stage_ = 4,
                        StageBeginTime = "22:00:00",
                        Value = 40
                    },
                } },
                CellAddrs = { CellAddrs}
                //LightNo = { DeviceLightNo },
                //TimeToken = CurrentTime
            };
            SocketConnectionClient.SocketClientConnection.Send(dto.ToByteArray());
        }

        /// <summary>
        /// 中继重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            var dto=new CmdHeader
            {
                CmdCode = 0x020,
                Identity = UserIdentity,
                OppositeId = DeviceIdentity,
                //TimeToken = CurrentTime
            };
            SocketConnectionClient.SocketClientConnection.Send(dto.ToByteArray());
        }
        /// <summary>
        /// 设置默认功率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetDefault_Click(object sender, EventArgs e)
        {
            var dto = new Settings
            {
                CmdCode = "020E",
                Identity = UserIdentity,
                OppositeId = DeviceIdentity,
                Value = 20,
                //TimeToken = CurrentTime
            };
            SocketConnectionClient.SocketClientConnection.Send(dto.ToByteArray());
        }
        #endregion

        private void txbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            lsbSearchRes.Items.Clear();
            foreach (var item in lstMsg.Items)
            {
                if (item.ToString().Contains(txbSearch.Text))
                    lsbSearchRes.Items.Add(item);
            }
        }

    }
}
