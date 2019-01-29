using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Newtonsoft.Json;
using Persistence.Dto;
using PersistenceTool;

namespace Persistence
{
    public class StreetLightPersistence: IStreetLightPersistence
    {
        private readonly DBhelper _dBhelper = new DBhelper();
        public int DeviceRegister(DtoRegister registerDto)
        {
            if (string.IsNullOrWhiteSpace(registerDto.ImeiNo))
                return 0;
            string sqlStr = "select imeiId,imeimac,imeiGLongitude,imeiGLatitude from cy_imeiInfo where imeimac = @imeimac";
            var param = new SqlParameter("@imeimac", SqlDbType.VarChar, 18) { Value = registerDto.ImeiNo };
            var oDs = _dBhelper.ExecuteQuery(sqlStr, param);
            int res;
            if (oDs.Tables[0].Rows.Count == 0)
            {
                res = _dBhelper.ExecuteTransaction(cmd =>
                {
                    var sqlStr1 = "insert into cy_imeiInfo(imeimac,imeiType,imeiVersion,imeiStatusNo,ImeiOnlineState,imeiIp,imeiServerIp,imeiServerOutIp,imeiIccid,addUserId,addTime,updateUserId,updateTime";
                    var sqlStr2 = "(@imeimac,@imeiType,@imeiVersion,'A',@statusNo,@imeiIp,@imeiServerIp,@imeiServerOutIp,@imeiIccid,@addUserId,@addTime,@updateUserId,@updateTime";
                    var parameters = new List<SqlParameter>()
                    {
                        new SqlParameter("@imeimac", SqlDbType.VarChar, 18) {Value = registerDto.ImeiNo},
                        new SqlParameter("@imeiType", SqlDbType.VarChar, 10) {Value = registerDto.ImeiType},
                        new SqlParameter("@imeiVersion", SqlDbType.VarChar, 10) {Value = registerDto.ImeiVersion},
                        new SqlParameter("@statusNo", SqlDbType.VarChar, 5) {Value = "On"},
                        new SqlParameter("@imeiIp", SqlDbType.VarChar, 25) {Value = registerDto.RemoteIpEndPoint},
                        new SqlParameter("@imeiServerIp", SqlDbType.VarChar, 25) {Value = registerDto.ServerIp},
                        new SqlParameter("@imeiServerOutIp", SqlDbType.VarChar, 25) {Value = registerDto.ServerOutIp},
                        new SqlParameter("@imeiIccid", SqlDbType.VarChar, 20) {Value = registerDto.Iccid},
                        new SqlParameter("@addUserId", SqlDbType.Int, 4) {Value = -1},
                        new SqlParameter("@addTime", SqlDbType.DateTime) {Value = DateTime.Now},
                        new SqlParameter("@updateUserId", SqlDbType.Int, 4) {Value = -1},
                        new SqlParameter("@updateTime", SqlDbType.DateTime) {Value = DateTime.Now}
                    };
                    if (registerDto.Lng.HasValue && registerDto.Lng != 0D && registerDto.Lat.HasValue && registerDto.Lat != 0D)
                    {
                        var qryres = CommonCode.GetWebRequest($"http://api.map.baidu.com/geocoder/v2/?location={registerDto.Lat.ToString()},{registerDto.Lng.ToString()}&output=json&ak=WEc8RlPXzSifaq9RHxE1WW7lRKgbid6Y");
                        var location = JsonConvert.DeserializeObject<QryLocation>(qryres);
                        if (location != null && location.status == 0)
                        {
                            sqlStr1 += ",imeiGLongitude,imeiGLatitude,imeiAddress,imeiProvince,imeiCity,imeiCountry";
                            sqlStr2 += ",@imeiGLongitude,@imeiGLatitude,@imeiAddress,@imeiProvince,@imeiCity,@imeiCountry";
                            parameters.Add(new SqlParameter("@imeiGLongitude", SqlDbType.Decimal) { Value = registerDto.Lng });
                            parameters.Add(new SqlParameter("@imeiGLatitude", SqlDbType.Decimal) { Value = registerDto.Lat });
                            parameters.Add(new SqlParameter("@imeiAddress", SqlDbType.NVarChar, 100) { Value = location.result.formatted_address });
                            parameters.Add(new SqlParameter("@imeiProvince", SqlDbType.NVarChar, 20) { Value = location.result.addressComponent.province });
                            parameters.Add(new SqlParameter("@imeiCity", SqlDbType.NVarChar, 20) { Value = location.result.addressComponent.city });
                            parameters.Add(new SqlParameter("@imeiCountry", SqlDbType.NVarChar, 20) { Value = location.result.addressComponent.country });
                            qryres = CommonCode.GetWebRequest($"http://api.map.baidu.com/ag/coord/convert?from=0&to=4&x={registerDto.Lng}&y={registerDto.Lat}");
                            var baiduxy = JsonConvert.DeserializeObject<BaiDuXy>(qryres);
                            if (baiduxy != null && baiduxy.error == 0&& !string.IsNullOrWhiteSpace(baiduxy.x) &&!string.IsNullOrWhiteSpace(baiduxy.y))
                            {
                                sqlStr1 += ",imeiLongitude,imeiLatitude";
                                sqlStr2 += ",@imeiLongitude,@imeiLatitude";
                                parameters.Add(new SqlParameter("@imeiLongitude", SqlDbType.Decimal) { Value = Convert.ToDecimal(Encoding.UTF8.GetString(Convert.FromBase64String(baiduxy.x))) });
                                parameters.Add(new SqlParameter("@imeiLatitude", SqlDbType.Decimal) { Value = Convert.ToDecimal(Encoding.UTF8.GetString(Convert.FromBase64String(baiduxy.y))) });
                            }
                        }
                    }
                    sqlStr = sqlStr1 + ")values" + sqlStr2 + ");select @@identity;";
                    cmd.CommandText = sqlStr;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters.ToArray());
                    cmd.ExecuteScalar();
                    return 1;
                });
            }
            else
            {
                var lng = 0.00D;
                var lat=0.00D;
                if (oDs.Tables[0].Rows[0]["imeiGLongitude"] != DBNull.Value &&
                    oDs.Tables[0].Rows[0]["imeiGLatitude"] != DBNull.Value)
                {
                    lng = double.Parse(oDs.Tables[0].Rows[0]["imeiGLongitude"].ToString());
                    lat = double.Parse(oDs.Tables[0].Rows[0]["imeiGLatitude"].ToString());
                }
                res = _dBhelper.ExecuteTransaction(cmd =>
                {
                    sqlStr = "update cy_imeiInfo set ";
                    var parameters =new List<SqlParameter>()
                    {
                        new SqlParameter("@imeiType", SqlDbType.VarChar, 10) {Value = registerDto.ImeiType},
                        new SqlParameter("@imeiVersion", SqlDbType.VarChar, 10) {Value = registerDto.ImeiVersion},
                        new SqlParameter("@imeiStatusNo", SqlDbType.VarChar, 5) {Value = "On"},
                        new SqlParameter("@imeiIp", SqlDbType.VarChar, 25) {Value = registerDto.RemoteIpEndPoint},
                        new SqlParameter("@imeiServerIp", SqlDbType.VarChar, 25) {Value = registerDto.ServerIp},
                        new SqlParameter("@imeiServerOutIp", SqlDbType.VarChar, 25) {Value = registerDto.ServerOutIp},
                        new SqlParameter("@imeiIccid", SqlDbType.VarChar, 20) {Value = registerDto.Iccid},
                        new SqlParameter("@imeimac", SqlDbType.VarChar, 18) {Value = registerDto.ImeiNo},
                        new SqlParameter("@updateUserId", SqlDbType.Int, 4) {Value = -1},
                        new SqlParameter("@updateTime", SqlDbType.DateTime) {Value = DateTime.Now}
                    };
                    if (registerDto.Lng.HasValue && registerDto.Lng != 0D && registerDto.Lat.HasValue && registerDto.Lat !=0D && (Math.Pow(registerDto.Lng.Value-lng,2)+ Math.Pow(registerDto.Lat.Value - lat, 2))> 0.000001)
                    {
                        var qryres=CommonCode.GetWebRequest($"http://api.map.baidu.com/geocoder/v2/?location={registerDto.Lat.ToString()},{registerDto.Lng.ToString()}&output=json&ak=WEc8RlPXzSifaq9RHxE1WW7lRKgbid6Y");
                        var location=JsonConvert.DeserializeObject<QryLocation>(qryres);
                        if (location!=null&&location.status == 0)
                        {
                            sqlStr += "imeiGLongitude=@imeiGLongitude,imeiGLatitude=@imeiGLatitude,imeiAddress=@imeiAddress,imeiProvince=@imeiProvince,imeiCity=@imeiCity,imeiCountry=@imeiCountry,";
                            parameters.Add(new SqlParameter("@imeiGLongitude", SqlDbType.Decimal) { Value = registerDto.Lng });
                            parameters.Add(new SqlParameter("@imeiGLatitude", SqlDbType.Decimal) { Value = registerDto.Lat });
                            parameters.Add(new SqlParameter("@imeiAddress", SqlDbType.NVarChar, 100) { Value = location.result.formatted_address });
                            parameters.Add(new SqlParameter("@imeiProvince", SqlDbType.NVarChar, 20) { Value = location.result.addressComponent.province });
                            parameters.Add(new SqlParameter("@imeiCity", SqlDbType.NVarChar, 20) { Value = location.result.addressComponent.city });
                            parameters.Add(new SqlParameter("@imeiCountry", SqlDbType.NVarChar, 20) { Value = location.result.addressComponent.country });
                            qryres = CommonCode.GetWebRequest($"http://api.map.baidu.com/ag/coord/convert?from=0&to=4&x={registerDto.Lng}&y={registerDto.Lat}");
                            var baiduxy = JsonConvert.DeserializeObject<BaiDuXy>(qryres);
                            if (baiduxy != null && baiduxy.error == 0)
                            {
                                sqlStr += "imeiLongitude=@imeiLongitude,imeiLatitude=@imeiLatitude,";
                                parameters.Add(new SqlParameter("@imeiLongitude", SqlDbType.Decimal) { Value = Convert.ToDecimal(Encoding.UTF8.GetString(Convert.FromBase64String(baiduxy.x))) });
                                parameters.Add(new SqlParameter("@imeiLatitude", SqlDbType.Decimal) { Value = Convert.ToDecimal(Encoding.UTF8.GetString(Convert.FromBase64String(baiduxy.y))) });
                            }
                        }
                    }
                    sqlStr += "imeiType=@imeiType,imeiVersion=@imeiVersion,ImeiOnlineState=@imeiStatusNo,imeiIp=@imeiIp,imeiServerIp=@imeiServerIp,imeiServerOutIp=@imeiServerOutIp,imeiIccid=@imeiIccid,updateUserId=@updateUserId,updateTime=@updateTime where imeimac = @imeimac";

                    cmd.CommandText = sqlStr;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters.ToArray());
                    cmd.ExecuteNonQuery();
                    return 1;
                });
            }
            return res;
        }

        public DtoDealRes DeviceLogin(DtoLogin loginDto)
        {
            var dealres = new DtoDealRes();
            if (string.IsNullOrWhiteSpace(loginDto.ImeiNo))
                return dealres;
            string sqlStr = "select imeiId from cy_imeiInfo where imeimac = @imeimac";
            var oDs = _dBhelper.ExecuteQuery(sqlStr, new SqlParameter("@imeimac", SqlDbType.VarChar, 18) { Value = loginDto.ImeiNo });
            if (oDs.Tables[0].Rows.Count == 0) return dealres;
            int imeiId = Convert.ToInt32(oDs.Tables[0].Rows[0]["imeiId"]);
            #region 设备绑定用户
            //dealres.UsrClients = new List<UsrClient>();
            //var sqlStr = "select a.loginNo,a.phoneMac from cy_userInfo a " +
            //                      " left join cy_imeiReplenUser b on a.userId = b.userId left join cy_imeiInfo c on b.imeiId = c.imeiId " +
            //                      " where c.imeiMac = '" + loginDto.ImeiNo + "'";
            //var oDs = _dBhelper.ExecuteQuery(sqlStr);
            //for (int n = 0; n < oDs?.Tables[0].Rows.Count; n++)
            //{
            //    if (oDs.Tables[0].Rows[n]["loginNo"] != DBNull.Value)
            //        dealres.UsrClients.Add(new UsrClient { LoginNo = oDs.Tables[0].Rows[n]["loginNo"].ToString(), ClientId = oDs.Tables[0].Rows[n]["phoneMac"].ToString() });
            //}
            #endregion

            #region 包含的路灯
            sqlStr = "select a.cellAddr,b.lightNo from cy_imeiCellInfo a join cy_lightInfo b on a.lightId=b.lightId and a.imeiId=b.imeiId and a.imeiId= "+ imeiId + " order by a.cellAddr";
            oDs = _dBhelper.ExecuteQuery(sqlStr);
            foreach (DataRow row in oDs.Tables[0].Rows)
            {
                dealres.Lights.Add(new CellLight
                {
                    CellAddr = Convert.ToInt32(row["cellAddr"]),
                    LightNo = row["lightNo"].ToString()
                });
            }
            #endregion
            dealres.Res = _dBhelper.ExecuteTransaction((cmd) =>
            {
               sqlStr = "update cy_imeiInfo set imeiIp=@imeiIp,imeiServerIp=@imeiServerIp,imeiServerOutIp=@imeiServerOutIp,ImeiOnlineState = @statusNo,updateUserId = @updateUserId,updateTime = @updateTime where imeiId = @imeiId";
                SqlParameter[] parameters =
                {
                        new SqlParameter("@imeiId", SqlDbType.Int, 4) {Value = imeiId},
                        new SqlParameter("@imeiIp", SqlDbType.VarChar, 25) {Value = loginDto.RemoteIpEndPoint},
                        new SqlParameter("@imeiServerIp", SqlDbType.VarChar, 25) {Value = loginDto.ServerIp},
                        new SqlParameter("@imeiServerOutIp", SqlDbType.VarChar, 25) {Value = loginDto.ServerOutIp},
                        new SqlParameter("@statusNo",SqlDbType.NVarChar,10) {Value = "On"},
                        new SqlParameter("@updateUserId", SqlDbType.Int, 4) {Value = -1},
                        new SqlParameter("@updateTime", SqlDbType.DateTime) {Value = DateTime.Now}
                    };
                cmd.CommandText = sqlStr;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            });
            return dealres;
        }

        public int DeviceOffLine(DtoOffLine offLineDto)
        {
            if (string.IsNullOrWhiteSpace(offLineDto.ImeiNo))
                return 0;
            if (!string.IsNullOrWhiteSpace(offLineDto.RemoteIpEndPoint) &&
                !string.IsNullOrWhiteSpace(offLineDto.ServerIp))
            {
                string sqlStr = "select imeiId from cy_imeiInfo where imeimac = @imeimac and imeiIp=@imeiIp and imeiServerIp=@imeiServerIp";
                var oDs = _dBhelper.ExecuteQuery(sqlStr,
                    new SqlParameter("@imeimac", SqlDbType.VarChar, 18) { Value = offLineDto.ImeiNo },
                    new SqlParameter("@imeiIp", SqlDbType.VarChar, 25) { Value = offLineDto.RemoteIpEndPoint },
                    new SqlParameter("@imeiServerIp", SqlDbType.VarChar, 25) { Value = offLineDto.ServerIp });
                if (oDs?.Tables[0].Rows.Count == 0)//当前已经掉线，然后重连上了，直接舍弃这种
                {
                    return 1;
                }
            }
            return _dBhelper.ExecuteTransaction(cmd =>
            {
               var sqlStr = "update cy_imeiInfo set ImeiOnlineState=@imeiStatusNo,updateUserId=@updateUserId,updateTime=@updateTime where imeimac = @imeimac";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@imeimac", SqlDbType.VarChar, 18) {Value = offLineDto.ImeiNo},
                    new SqlParameter("@imeiStatusNo", SqlDbType.NVarChar, 10) {Value = "Off"},
                    new SqlParameter("@updateUserId", SqlDbType.Int, 4) {Value = -1},
                    new SqlParameter("@updateTime", SqlDbType.DateTime) {Value = DateTime.Now}
                };
                cmd.CommandText = sqlStr;
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            });
        }

        public int DeviceStatusInfo(DtoStatusInfo statusDto)
        {
            //var dealres = new Res();
            if (string.IsNullOrWhiteSpace(statusDto.ImeiNo)) return 0;
            string sqlStr = "select imeiId from cy_imeiInfo where imeimac = @imeimac";
            var oDs = _dBhelper.ExecuteQuery(sqlStr, new SqlParameter("@imeimac", SqlDbType.VarChar, 18) { Value = statusDto.ImeiNo });
            if (oDs.Tables[0].Rows.Count == 0) return 0;
            int imeiId = Convert.ToInt32(oDs.Tables[0].Rows[0]["imeiId"]);
            #region 设备绑定用户
            //dealres.PostMsgs = new List<PostMsg>();
            //dealres.UsrLogNo = new List<string>();
            //sqlStr = "select a.loginNo from cy_userInfo a " +
            //                      " left join cy_houseUser b on a.userId = b.huserId and b.huStatusNo = 'A' " +
            //                      " left join cy_userInfo d on a.userId = d.userId and d.uStatusNo = 'A'" +
            //                      " left join cy_houseInfo c on b.huHouseId = c.houseId " +
            //                      " where c.imeiId = " + imeiId + " ";
            //oDs = _dBhelper.ExecuteQuery(sqlStr);
            //for (int n = 0; n < oDs?.Tables[0].Rows.Count; n++)
            //{
            //    if (oDs.Tables[0].Rows[n]["telPhone"] != DBNull.Value)
            //        dealres.UsrLogNo.Add(oDs.Tables[0].Rows[n]["telPhone"].ToString());
            //}
            #endregion
            return _dBhelper.ExecuteTransaction(cmd =>
            {
                sqlStr = "update cy_imeiInfo set imeiParamsContent=@imeiParamsContent,updateUserId=@updateUserId,updateTime=@updateTime where imeiId = @imeiId";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@imeiParamsContent", SqlDbType.VarChar, 8000) {Value = JsonConvert.SerializeObject(statusDto) },
                    new SqlParameter("@imeiId", SqlDbType.Int, 4) {Value = imeiId},
                    new SqlParameter("@updateUserId", SqlDbType.Int, 4) {Value = -1},
                    new SqlParameter("@updateTime", SqlDbType.DateTime) {Value = DateTime.Now}
                };
                cmd.CommandText = sqlStr;
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
                sqlStr ="select lightNo from cy_lightInfo a join cy_imeiCellInfo b on a.lightId = b.lightId join cy_imeiInfo c on b.imeiId =c.imeiId where c.imeiMac = '"+ statusDto.ImeiNo+ "' and b.cellAddr = "+ statusDto.LightStatus.CellAddr+ " ";
                oDs = _dBhelper.ExecuteQuery(sqlStr, new SqlParameter("@imeimac", SqlDbType.VarChar, 18) { Value = statusDto.ImeiNo });
                if (oDs.Tables[0].Rows.Count == 0) return 0;
                var lightNo = oDs.Tables[0].Rows[0]["lightNo"].ToString();
                sqlStr = $"update cy_lightInfo set imeiLightParamsContent='{JsonConvert.SerializeObject(statusDto.LightStatus)}',imeiLightStatus='{statusDto.LightStatus.lightstatus}',imeiLightPw={statusDto.LightStatus.lightPw},imeiLightLu={statusDto.LightStatus.lightLu},imeiLightLi={statusDto.LightStatus.lightLi},imeiLightBu={statusDto.LightStatus.lightBu},imeiLightBt={statusDto.LightStatus.lightBt},imeiLightUu={statusDto.LightStatus.lightUu},imeiLightUi={statusDto.LightStatus.lightUi},imeiLightBgu='{statusDto.LightStatus.lightBgu}',updateUserId=-1,updateTime=GETDATE() where lightNo='{lightNo}'";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Clear();
                cmd.ExecuteNonQuery();
                sqlStr = $"insert into cy_imeiHistory(ihmac,ihLightNo,ihStatus,ihLightPw,ihLightLu,ihLightLi,ihLightBu,ihLightBt,ihLightUu,ihLightUi,ihLightBgu,addTime)values('{statusDto.ImeiNo}','{lightNo}','{statusDto.LightStatus.lightstatus}',{statusDto.LightStatus.lightPw},{statusDto.LightStatus.lightLu},{statusDto.LightStatus.lightLi},{statusDto.LightStatus.lightBu},{statusDto.LightStatus.lightBt},{statusDto.LightStatus.lightUu},{statusDto.LightStatus.lightUi},'{statusDto.LightStatus.lightBgu}',GETDATE());";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Clear();
                cmd.ExecuteNonQuery();
                //foreach (var lightStatu in statusDto.LightStatus)
                //{
                //    sqlStr += $"update cy_lightInfo set imeiLightParamsContent='{JsonConvert.SerializeObject(lightStatu)}',imeiLightStatus='{lightStatu.lightstatus}',imeiLightPw={lightStatu.lightPw},imeiLightLu={lightStatu.lightLu},imeiLightLi={lightStatu.lightLi},imeiLightBu={lightStatu.lightBu},imeiLightBt={lightStatu.lightBt},imeiLightUu={lightStatu.lightUu},imeiLightUi={lightStatu.lightUi},imeiLightBgu='{lightStatu.lightBgu}',updateUserId=-1,updateTime=GETDATE() where lightNo='{lightStatu.lightNo}';";
                //    cmd.CommandText = sqlStr;
                //    cmd.Parameters.Clear();
                //    cmd.ExecuteNonQuery();
                //}
                //sqlStr = "";
                //foreach (var lightStatu in statusDto.LightStatus)
                //{
                //    sqlStr += $"insert into cy_imeiHistory(ihmac,ihLightNo,ihStatus,ihLightPw,ihLightLu,ihLightLi,ihLightBu,ihLightBt,ihLightUu,ihLightUi,ihLightBgu,addTime)values('{statusDto.ImeiNo}','{lightStatu.lightNo}','{lightStatu.lightstatus}',{lightStatu.lightPw},{lightStatu.lightLu},{lightStatu.lightLi},{lightStatu.lightBu},{lightStatu.lightBt},{lightStatu.lightUu},{lightStatu.lightUi},'{lightStatu.lightBgu}',GETDATE());";
                //    cmd.CommandText = sqlStr;
                //    cmd.Parameters.Clear();
                //    cmd.ExecuteNonQuery();
                //}
                return 1;
            });
        }
        
        public int AddWaringMessage(DtoWaring waring)
        {
            if (string.IsNullOrWhiteSpace(waring.ImeiNo)) return 0;
            string sqlStr = "select imeiId from cy_imeiInfo where imeimac = @imeimac";
            var oDs = _dBhelper.ExecuteQuery(sqlStr, new SqlParameter("@imeimac", SqlDbType.VarChar, 18) { Value = waring.ImeiNo });
            if (oDs.Tables[0].Rows.Count == 0) return 0;
            int imeiId = Convert.ToInt32(oDs.Tables[0].Rows[0]["imeiId"]);

            sqlStr = "insert into cy_waringMessage (imeiId,imeiMac,imeiLightNo,waringCode,waringMessage,dealState,imeiWaringMsgContent,addUserId,addTime,updateUserId,updateTime)values(@imeiId,@imeiMac,@imeiLightNo,@waringCode,@waringMessage,'A',@imeiWaringMsgContent,@userId,@time,@userId,@time)";
            SqlParameter[] parameters =
                {
                    new SqlParameter("@imeiId", SqlDbType.Int, 4) {Value = imeiId},
                    new SqlParameter("@imeiMac", SqlDbType.VarChar, 18) {Value = waring.ImeiNo},
                    new SqlParameter("@imeiLightNo", SqlDbType.VarChar, 18) {Value = waring.ImeiLightNo},
                    new SqlParameter("@waringCode", SqlDbType.NVarChar, 4) {Value = waring.WaringCode},
                    new SqlParameter("@waringMessage", SqlDbType.NVarChar, 500) {Value = waring.WaringMessage},
                    new SqlParameter("@imeiWaringMsgContent", SqlDbType.NVarChar, 4000) {Value = waring.ImeiWaringMsgContent},
                    new SqlParameter("@userId", SqlDbType.Int, 4) {Value = -1},
                    new SqlParameter("@time", SqlDbType.DateTime) {Value = DateTime.Now}
                };
            return _dBhelper.ExecuteResult(sqlStr, parameters);
        }

        public int UpdateSettingsTimeSpan(DtoSettingTimeSpan timeSpan)
        {
           var sqlStr = "update cy_imeiInfo set imeiReportSpan=@imeiReportSpan,updateUserId=@updateUserId,updateTime=@updateTime where imeimac = @imeimac";
            SqlParameter[] parameters =
            {
                    new SqlParameter("@imeiReportSpan", SqlDbType.Int, 4) {Value = timeSpan.TimeSpan},
                    new SqlParameter("@imeimac", SqlDbType.VarChar, 18) { Value = timeSpan.ImeiNo },
                    new SqlParameter("@updateUserId", SqlDbType.Int, 4) {Value = -1},
                    new SqlParameter("@updateTime", SqlDbType.DateTime) {Value = DateTime.Now}
                };
            return _dBhelper.ExecuteResult(sqlStr, parameters);
        }
    }
}
