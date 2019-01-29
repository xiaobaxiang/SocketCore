using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Google.Protobuf;
using Persistence;
using Socket.Core;
using Socket.Core.Model;
using Socket.Reflect;
using SocketCmd;

namespace SocketTestServer
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            ContextMenuStrip listboxMenu = new ContextMenuStrip();
            ToolStripMenuItem rightMenu = new ToolStripMenuItem("Copy");
            rightMenu.Click += Copy_Click;
            listboxMenu.Items.AddRange(new ToolStripItem[] { rightMenu });
            lstMsg.ContextMenuStrip = listboxMenu;

            SocketConnectionServerDispatcherRef<StreetLightPersistence>.ServerSocketRefListing(new SocketConnectConfig()
            {
                KeepAliveTime=2*60*1000,//心跳间隔2分钟
                AcceptCallback = con =>
                {
#if DEBUG
                    lstMsg.Invoke(new Action(() =>
                    {
                        lstMsg.Items.Add($"有连接到达{con.ConnectSocket.RemoteEndPoint}");
                    }));
#endif
                },
                ReceiveCallback = (bytes, con) =>
                {
#if DEBUG
                    var header = CmdHeader.Parser.ParseFrom(bytes);
                    if (header.CmdCode == 0x0101 || header.CmdCode==0x0102|| header.CmdCode==0x0202)
                    {
                        lstMsg.Invoke(new Action(() =>
                        {
                            lstClient.Items.Remove(header.Identity);
                            lstClient.Items.Add(header.Identity);
                        }));
                    }
                    lstMsg.Invoke(new Action(() =>
                    {
                        lstMsg.Items.Add($"接收header{header}");
                    }));
#endif
                },
                DisConnectCallback = con =>
                {
                    SocketConnection currSocket;
                    if (con.Identity == null ||!SocketConnectionServerDispatcher.DicSockectConnection.TryGetValue(con.Identity,out currSocket)) return;
                    if (con != currSocket) return;
                    SocketConnectionServerDispatcher.DicSockectConnection.TryRemove(con.Identity, out currSocket);
                    lstMsg.Invoke(new Action(() =>
                    {
                        lstClient.Items.Remove(con.Identity);
#if DEBUG
                        lstMsg.Items.Add($"有连接断开{con.ConnectSocket.RemoteEndPoint}-----{con.Identity}");
#endif
                    }));
                },
                ShowMsg = msg =>
                {
#if DEBUG
                    lstMsg.Invoke(new Action(() =>
                    {
                        lstMsg.Items.Add(msg);
                    }));
#endif
                },
                SocketConnectExceptionCallback = ex =>
                {
#if DEBUG
                    lstMsg.Invoke(new Action(() =>
                    {
                        lstMsg.Items.Add(ex.Message);
                    }));
#endif
                },
                BeforeSend = (bs,con) =>
                {
#if DEBUG
                    var cmdHeader = CmdHeader.Parser.ParseFrom(bs);
                    lstMsg.Invoke(new Action(() =>
                    {
                        lstMsg.Items.Add($"耗时:{DateTime.Now - con.LastSessionTime}发送header{cmdHeader}");
                    }));
#endif
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMsg.TextLength == 0) return;
#region 发送字节消息
            var bytes=new byte[0];
            if (!chxIsMsg.Checked)
            {
                var hexReg = new Regex("(\\d|[A-F])+");
                var match = hexReg.Matches(txtMsg.Text);
                bytes = new byte[match.Count];
                if (match.Count > 0)
                {
                    for (int i = 0; i < match.Count; i++)
                    {
                        bytes[i] = Convert.ToByte(match[i].Value, 16);
                    }
                    txtMsg.BackColor = Color.White;
                }
                else
                {
                    txtMsg.BackColor = Color.Red;
                }
            }
#endregion
            List<string> selectList=new List<string>();
            foreach (var selectedItem in lstClient.SelectedItems)
            {
                selectList.Add(selectedItem.ToString());
            }
            foreach (var select in selectList)
            {
                SocketConnection socketcon;
                if (SocketConnectionServerDispatcher.DicSockectConnection.TryGetValue(select, out socketcon) &&
                    socketcon.ConnectSocket.Connected)
                {
                    if (!chxIsMsg.Checked)
                    {
                        if (bytes.Length > 0)
                            socketcon.Send(bytes);
                    }
                    else
                    {
                        var message = new Hellomessage
                        {
                            Identity = socketcon.Identity,
                            Cmdcode = "0001",
                            Timetoken = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                            Serverid = SocketConnectionServerDispatcher.ServerId,
                            Msg = txtMsg.Text
                        };
                        lstMsg.Items.Add($"向[{socketcon.Identity}]发送消息[{txtMsg.Text}]");
                        socketcon.Send(message.ToByteArray());
                    }
                }
                else
                {
                    lstClient.Items.Remove(select);
                    SocketConnectionServerDispatcher.DicSockectConnection.TryRemove(select, out socketcon);
                }
            }
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
