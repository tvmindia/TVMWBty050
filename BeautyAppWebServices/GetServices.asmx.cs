﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Net.Mail;
using System.Threading;


namespace BeautyAppWebServices
{
 
    [WebService(Namespace = "http://192.168.1.102/Beauty")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    //// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class GetServices : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]  
        public string GetServicesList()
        {
            SqlConnection con = null;
           
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetServices", con);
                cmd.CommandType = CommandType.StoredProcedure;

                return getDbDataAsJSON(cmd);
             
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                {

                    con.Dispose();

                }
            }

            return "";
        }


        [WebMethod]
        public string GetOffers()
        {
            SqlConnection con = null;

            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetOffers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                ArrayList imgColNames = new ArrayList();
                ArrayList imgFileNameCols = new ArrayList();
                imgColNames.Add("OfferImage");
                imgFileNameCols.Add("ImageName");
                return getDbDataAsJSON(cmd, imgColNames, imgFileNameCols);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                {

                    con.Dispose();

                }
            }

            return "";
        }

        [WebMethod]
        public string GetNotifications(string notIDs)
        {
            SqlConnection con = null;

            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetNotifications", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Notification_ID", notIDs);

                return getDbDataAsJSON(cmd);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                {

                    con.Dispose();

                }
            }

            return "";
        }

        [WebMethod]
        public string GetServiceTypes(string ServiceCode)
        {
            SqlConnection con = null;
          
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetServiceTypes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceCode", ServiceCode);
                return getDbDataAsJSON(cmd);
              
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                {

                    con.Dispose();

                }
            }

            return "";
        }

        [WebMethod]
        public string GetSearchResults(string ServiceCode, string sTypeCode, string user)
        {
            SqlConnection con = null;

            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetSearchResults", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceCode", ServiceCode);
                cmd.Parameters.AddWithValue("@S_typeCode", sTypeCode);
                cmd.Parameters.AddWithValue("@user", user);
                ArrayList imgColNames = new ArrayList();
                ArrayList imgFileNameCols = new ArrayList();
                imgColNames.Add("StyleImg");
                imgFileNameCols.Add("StyleImageName");
                return getDbDataAsJSON(cmd, imgColNames, imgFileNameCols);


            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                {

                    con.Dispose();

                }
            }

            return "";
        }

        [WebMethod]
        public string AddToFavorites(string user, string sTypeCode, string providerCode,string addORremove)
        {
            SqlConnection con = null;

            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("AddFavorites", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@S_typeCode", sTypeCode);
                cmd.Parameters.AddWithValue("@provider", providerCode);
                cmd.Parameters.AddWithValue("@addORremove", addORremove);
                cmd.ExecuteNonQuery();
             }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                {

                    con.Dispose();

                }
            }

            return "";
        }

        [WebMethod]
        public string GetServiceProviderDetails(string ProviderCode, string serviceCode, string sTypeCode)
        {
            SqlConnection con = null;

            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetServiceProviderDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProviderCode", ProviderCode);
                cmd.Parameters.AddWithValue("@S_typeCode", sTypeCode);
                cmd.Parameters.AddWithValue("@serviceCode", serviceCode);
                ArrayList imgColNames = new ArrayList();
                ArrayList imgFileNameCols = new ArrayList();
                imgColNames.Add("ProviderImage");
                imgFileNameCols.Add("ProviderImageName");
                imgColNames.Add("StyleImg");
                imgFileNameCols.Add("StyleImageName");
                return getDbDataAsJSON(cmd, imgColNames,imgFileNameCols);  //passing col names of image and imagefilename
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                {

                    con.Dispose();

                }
            }

            return "";
        }

        [WebMethod]
        public string GetDetailsOfItems(string ProviderCode, string serviceCode, string sTypeCode, string req_type)
        {
            SqlConnection con = null;

            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetDetailsOfItems", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProviderCode", ProviderCode);
                cmd.Parameters.AddWithValue("@serviceCode", serviceCode);
                cmd.Parameters.AddWithValue("@S_typeCode", sTypeCode);
                cmd.Parameters.AddWithValue("@req_type", req_type);
                ArrayList imgColNames = new ArrayList();
                ArrayList imgFileNameCols = new ArrayList();
                imgColNames.Add("StyleImg");
                imgFileNameCols.Add("StyleImageName");
                return getDbDataAsJSON(cmd, imgColNames, imgFileNameCols);  //passing col names of image and imagefilename
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                {

                    con.Dispose();

                }
            }

            return "";
        }


        [WebMethod]
        public string AddUsers(string username, string password, string mobile, string email, string gender)
        {
            SqlConnection con = null;

            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("AddUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_name", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@gender", gender);
                
                //output messages
                SqlParameter outMsg1 = cmd.Parameters.Add("@msg", SqlDbType.NVarChar, 100);
                outMsg1.Direction = ParameterDirection.Output;
                SqlParameter outMsg2 = cmd.Parameters.Add("@pass", SqlDbType.Bit);
                outMsg2.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                String msg = outMsg1.Value.ToString();
                Boolean pass = (Boolean)outMsg2.Value;

                //making it as JSON
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                Dictionary<string, object> row = new Dictionary<string, object>();
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                row.Add("msg", msg);
                row.Add("pass", pass);
                rows.Add(row);
                return serializer.Serialize(rows);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                {

                    con.Dispose();

                }
            }

            return "";
        }


        [WebMethod]
        public string UserLogin(string email, string password)
        {
            SqlConnection con = null;

            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("UserLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                
                //output messages
                SqlParameter outMsg1 = cmd.Parameters.Add("@msg", SqlDbType.NVarChar, 100);
                outMsg1.Direction = ParameterDirection.Output;
                SqlParameter outMsg2 = cmd.Parameters.Add("@pass", SqlDbType.Bit);
                outMsg2.Direction = ParameterDirection.Output;
                SqlParameter outMsg3 = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 30);
                outMsg3.Direction = ParameterDirection.Output;
                SqlParameter outMsg4 = cmd.Parameters.Add("@mobile", SqlDbType.NVarChar, 20);
                outMsg4.Direction = ParameterDirection.Output;
                SqlParameter outMsg5 = cmd.Parameters.Add("@gender", SqlDbType.NVarChar, 7);
                outMsg5.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                String msg = outMsg1.Value.ToString();
                Boolean pass = (Boolean)outMsg2.Value;
                String user_name = outMsg3.Value.ToString();
                String mobile_no = outMsg4.Value.ToString();
                String gender = outMsg5.Value.ToString();

                //making it as JSON
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                Dictionary<string, object> row = new Dictionary<string, object>();
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                row.Add("msg", msg);
                row.Add("pass", pass);
                if (pass)
                {
                    row.Add("user_name", user_name);
                    row.Add("mobile_no", mobile_no);
                    row.Add("gender", gender);
                }
               
                rows.Add(row);
                return serializer.Serialize(rows);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                {

                    con.Dispose();

                }
            }

            return "";
        }



        [WebMethod]
        public string EditUser(string username, string password, string mobile, string email, string type)
        {
            SqlConnection con = null;

            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("EditUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_name", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@type", type);

                //output messages
                SqlParameter outMsg1 = cmd.Parameters.Add("@msg", SqlDbType.NVarChar, 100);
                outMsg1.Direction = ParameterDirection.Output;
                SqlParameter outMsg2 = cmd.Parameters.Add("@pass", SqlDbType.Bit);
                outMsg2.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                String msg = outMsg1.Value.ToString();
                Boolean pass = (Boolean)outMsg2.Value;

                //making it as JSON
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                Dictionary<string, object> row = new Dictionary<string, object>();
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                row.Add("msg", msg);
                row.Add("pass", pass);
                rows.Add(row);
                return serializer.Serialize(rows);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                {

                    con.Dispose();

                }
            }

            return "";
        }

        [WebMethod]
        public string Booking(string bookingID, string user, string serviceCode, string sTypeCode, string providerCode, DateTime timing,string bookORcancel)
        {
            SqlConnection con = null;

            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("Booking", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@serviceCode", serviceCode);
                cmd.Parameters.AddWithValue("@S_typeCode", sTypeCode);
                cmd.Parameters.AddWithValue("@provider", providerCode);
                cmd.Parameters.AddWithValue("@timing", timing);
                cmd.Parameters.AddWithValue("@bookORcancel", bookORcancel);
                String activityTime=DateTime.Now.ToString();
                cmd.Parameters.AddWithValue("@activityTime", activityTime);
                if (bookORcancel == "book")
                {
                    bookingID = ((user.Length<20)? user : user.Substring(0,20) )+ DateTime.Now.ToString("ddHHmmssfff");
                }
                cmd.Parameters.AddWithValue("@BookingID", bookingID);

                //output messages
                SqlParameter outMsg1 = cmd.Parameters.Add("@msg", SqlDbType.NVarChar, 100);
                outMsg1.Direction = ParameterDirection.Output;
                SqlParameter outMsg2 = cmd.Parameters.Add("@pass", SqlDbType.Bit);
                outMsg2.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                String msg = outMsg1.Value.ToString();
                Boolean pass = (Boolean)outMsg2.Value;

                //making it as JSON
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                Dictionary<string, object> row = new Dictionary<string, object>();
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                row.Add("msg", msg);
                row.Add("pass", pass);
                row.Add("bookID", bookingID);
                rows.Add(row);
                
                //sending mail
                if (pass==true)
                {
                    new Thread(delegate()
                    {
                        SendMail(bookORcancel, activityTime, bookingID);
                    }).Start();
                    
                }

                return serializer.Serialize(rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {

                    con.Dispose();

                }
            }

            return "";
        }

        [WebMethod]
        public string GetBookingDetails(string Email)
        {
           
            SqlConnection con = null;

            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetBookingDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", Email);
                ArrayList imgColNames = new ArrayList();
                ArrayList imgFileNameCols = new ArrayList();
                imgColNames.Add("StyleImg");
                imgFileNameCols.Add("StyleImageName");
                return getDbDataAsJSON(cmd, imgColNames, imgFileNameCols);


            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                {

                    con.Dispose();

                }
            }

            return "";
        }

        public String getDbDataAsJSON(SqlCommand cmd, ArrayList imgColName, ArrayList imgFileNameCol)
        {
            try
            {
                DataSet ds = null;
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = ds.Tables[0];
                String filePath = Server.MapPath("~/tempImages/");      //temporary folder to store images

                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;
                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    //adding data in JSON
                    foreach (DataColumn col in dt.Columns)
                    {
                        if ( !imgColName.Contains(col.ColumnName))                  
                       {
                         if( !imgFileNameCol.Contains(col.ColumnName))                           
                             row.Add(col.ColumnName, dr[col]);
                        }
                    }
                    //adding image details in JSON
                    for (int i = 0; i < imgColName.Count; i++)
                    {
                        if (dr[imgColName[i]as string] != DBNull.Value)
                        {
                            String fileURL = filePath + DateTime.Now.ToString("ddHHmmssfff") + dr[imgFileNameCol[i] as string];
                            if (!System.IO.File.Exists(fileURL))
                            {
                                byte[] buffer = (byte[])dr[imgColName[i] as string];
                                System.IO.File.WriteAllBytes(fileURL, buffer);
                            }
                            row.Add(imgColName[i] as string, fileURL);
                        }
                    }
                    rows.Add(row);
                }

                this.Context.Response.ContentType = "";
                
                return serializer.Serialize(rows);

            }
            catch (Exception)
            {

                return "";
            }
            finally
            {

            }
            
        }


        public String getDbDataAsJSON(SqlCommand cmd)
        {
            try
            {
                DataSet ds = null;
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = ds.Tables[0];
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;
                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                       row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }

                this.Context.Response.ContentType = "";

                return serializer.Serialize(rows);

            }
            catch (Exception)
            {

                return "";
            }
            finally
            {

            }

        }

        public void SendMail(string bookORcancel, string activityTime, string bookingID)
        {
            try
            {
              //get mailing details
                SqlConnection con = null;
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetMailingDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bookingID", bookingID);
                SqlParameter outMsg1 = cmd.Parameters.Add("@userName", SqlDbType.NVarChar, 30);
                outMsg1.Direction = ParameterDirection.Output;
                SqlParameter outMsg2 = cmd.Parameters.Add("@mobile", SqlDbType.NVarChar, 20);
                outMsg2.Direction = ParameterDirection.Output;
                SqlParameter outMsg3 = cmd.Parameters.Add("@serviceName", SqlDbType.NVarChar, 20);
                outMsg3.Direction = ParameterDirection.Output;
                SqlParameter outMsg4 = cmd.Parameters.Add("@serviceTypeName", SqlDbType.NVarChar, 20);
                outMsg4.Direction = ParameterDirection.Output;
                SqlParameter outMsg5 = cmd.Parameters.Add("@providerName", SqlDbType.NVarChar, 200);
                outMsg5.Direction = ParameterDirection.Output;
                SqlParameter outMsg6 = cmd.Parameters.Add("@providerMail", SqlDbType.NVarChar, 300);
                outMsg6.Direction = ParameterDirection.Output;
                SqlParameter outMsg7 = cmd.Parameters.Add("@userMail", SqlDbType.NVarChar, 300);
                outMsg7.Direction = ParameterDirection.Output;
                SqlParameter outMsg8 = cmd.Parameters.Add("@timing", SqlDbType.SmallDateTime);
                outMsg8.Direction = ParameterDirection.Output;
         
                cmd.ExecuteNonQuery();

                String userName = outMsg1.Value.ToString();
                String mobile = outMsg2.Value.ToString();
                String serviceName = outMsg3.Value.ToString();
                String serviceTypeName = outMsg4.Value.ToString();
                String providerName = outMsg5.Value.ToString();
                String providerMail = outMsg6.Value.ToString();
                String userMail= outMsg7.Value.ToString();
                String timing = outMsg8.Value.ToString();// ("HH:mm dd-MM-yyyy");
               
               


                string MailTo = "sreejith.thrithvam@gmail.com";//change to providerMail
                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress("jabaajabaaa@gmail.com");
                Msg.To.Add(MailTo);
                string fileName = Server.MapPath("~/Templates/mailTemplate.html");//System.Web.Hosting.HostingEnvironment.MapPath("/Templates/mailTemplate.html");
                string body = fileName;
                System.IO.StreamReader objReader;
                objReader = new System.IO.StreamReader(fileName);
                body = objReader.ReadToEnd();
                //replacing contents
                string title = "Error Mail";
                string contentMsg="This mail is due to server error in mailing system";
                if (bookORcancel.Equals("book"))
                {
                    contentMsg = "There is a new booking for below mensioned service. Please inform the client whether you can provide the specified service on that time.";
                   title = "New Booking";
                   Msg.Subject = "New booking for " + serviceName;
                   body = body.Replace("$bORc$", "Booked at");
                
                }
                else if (bookORcancel.Equals("cancel"))
                {
                    contentMsg = "There is a cancellation for on a booking for below mensioned service.";
                    title = "Booking Cancellation";
                    Msg.Subject = "A cancellation on" + serviceName;
                    body = body.Replace("$bORc$", "Cancelled at");
                }
                body = body.Replace("$contentMsg$", contentMsg);
                body = body.Replace("$title$",title);
                body = body.Replace("$providerName$", providerName);
                body = body.Replace("$serviceName$", serviceName);
                body = body.Replace("$serviceType$", serviceTypeName);
                body = body.Replace("$timing$", timing);
                body = body.Replace("$bORCtime$", activityTime);
                body = body.Replace("$clientName$", userName);
                body = body.Replace("$clientContact$", userMail);
                body = body.Replace("$clientPhone$", mobile);
                body = body.Replace("$bookingID$", bookingID);
               
               
                Msg.Body = body;
                Msg.IsBodyHtml = true;
                // your remote SMTP server IP.
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("info.thrithvam", "thrithvam@2015");
                smtp.EnableSsl = true;
                smtp.Send(Msg);
                Msg = null;

                
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}