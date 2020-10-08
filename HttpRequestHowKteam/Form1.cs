using AE.Net.Mail;
using IronOcr;
using Newtonsoft.Json;
using Patagames.Ocr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

namespace HttpRequestHowKteam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            var html = GetData("https://www.howkteam.vn/");
            ShowData(html);
        }

        public void ShowData(string html)
        {
            File.WriteAllText("res.html", html);
            Process.Start("res.html");
        }

        #region Kteam code
        public void AddCookie(HttpRequest http, string cookie)
        {
            var temp = cookie.Split(';');
            foreach (var item in temp)
            {
                var temp2 = item.Split('=');
                if (temp2.Count() > 1)
                {
                    http.Cookies.Add(temp2[0], temp2[1]);
                }
            }
        }

        public string GetData(string url, HttpRequest http = null, string userArgent = "", string cookie = null)
        {
            if (http == null)
            {
                http = new HttpRequest();
                http.Cookies = new CookieDictionary();
            }

            if (!string.IsNullOrEmpty(cookie))
            {
                AddCookie(http, cookie);
            }

            if (!string.IsNullOrEmpty(userArgent))
            {
                http.UserAgent = userArgent;
            }
            string html = http.Get(url).ToString();
            return html;
        }

        public string GetLoginDataToken(string html)
        {
            string token = "";

            //var res = Regex.Matches(html, @"(?<=__RequestVerificationToken"" type=""hidden"" value="").*?(?="")", RegexOptions.Singleline);
            var res = Regex.Matches(html, @"(<input type=""hidden"" name=""token"" value="").*? (/>)", RegexOptions.Singleline);

            if (res != null && res.Count > 0)
            {
                token = res[0].ToString();
                token = token.Replace("<input type=\"hidden\" name=\"token\" value=", "").Trim();
                token = token.Replace("/>", "").Trim();
                token = token.Replace("\"", "").Trim();
            }

            return token;
        }

        public string PostData(HttpRequest http, string url, string data = null, string contentType = null, string userArgent = "", string cookie = null)
        {
            if (http == null)
            {
                http = new HttpRequest();
                http.Cookies = new CookieDictionary();
            }

            if (!string.IsNullOrEmpty(cookie))
            {
                AddCookie(http, cookie);
            }

            if (!string.IsNullOrEmpty(userArgent))
            {
                http.UserAgent = userArgent;
            }

            string html = http.Post(url, data, contentType).ToString();
            return html;
        }
        public string PostDataTracuuhoadon(HttpRequest http, string url, string data = null, string contentType = null, string userArgent = "", string cookie = null)
        {
            if (http == null)
            {
                http = new HttpRequest();
                http.Cookies = new CookieDictionary();
            }

            if (!string.IsNullOrEmpty(cookie))
            {
                AddCookie(http, cookie);
            }

            if (!string.IsNullOrEmpty(userArgent))
            {
                http.UserAgent = userArgent;
            }

            string html = http.Post(url).ToString();
            return html;
        }
        #endregion


        private void btnGetDataWithCookies_Click(object sender, EventArgs e)
        {
            string cookies = "_ga=GA1.2.119624101.1601525823; _gid=GA1.2.1957109173.1601525823; __RequestVerificationToken=zZjelqBLIJKlrrZ5RsCIrlpks-pRLwnukV4xOMHNlrnVXoWMs-YBH0JNSeGXgGZVhuaSCKDi1pN84KmnTGw8eT06G7JnFW0OZqfaed0JR5g1; _gat=1; .AspNet.ApplicationCookie=WbWxL_UF-Z1MHc8HnZQjW4g8JzdKuHodRduQ4zit5nf7TuVyrGdODH_jYs2CJ4MdA0wrQDk63OxBfeJ1fxiwDP4mCW6F6WSopwCbSIxs0XDR_dwrsHA9BwdhvlwQWWYAggLezRhGUVnY1l9Uk_qpdgvX5-kQw8wHDAHVEwJ21-yHPEP-rTNOVX9WyvjVihkQmHQ37jktxkq7AuIo9c5dFAbjsovzhvc1wkjIJx2wSMGCJIQw9bEHx1LFe0HMQ6SHyaVFfbQAE2aiaQCvYYlvyaiAqF8l7oWW-3Ocek20y40V-GHUP3LiW6qB5gaVmYYYsTUxrv-WdhjjZv-3DG_ULEwelB03gW4YJw4oeDEUXgno3kQ5PndaQjWNGVpb1PPu9XWPLT-mBRsnpbt_HHl8TnzURz8z6OS3VCGlmP0k5QVsrI_XvGvbU2_DI5HD8UuBeMsY8K1y4DTiV_bElDLbExYp3VPLilAkk8TCAx-O6sVbw68SegPsYMi6rjxSypps";
            string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.83 YaBrowser/20.9.0.933 Yowser/2.5 Safari/537.36";

            var html = GetData("https://www.howkteam.vn/", null, UserAgent, cookies);
            ShowData(html);
        }
        private void btnPostDataLogin_Click(object sender, EventArgs e)
        {
            HttpRequest httpRequest = new HttpRequest();
            httpRequest.Cookies = new CookieDictionary();
            string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.83 YaBrowser/20.9.0.933 Yowser/2.5 Safari/537.36";

            var html = GetData("https://www.howkteam.vn/account/login?ReturnUrl=%2F", httpRequest, UserAgent);
            string token = GetLoginDataToken(html);
            string email = "dangphuocduy";
            string password = "GoodLuck300588@2020";
            string data = "__RequestVerificationToken=" + token + "&Email=" + WebUtility.UrlEncode(email) + "&Password=" + WebUtility.UrlEncode(password) + "&RememberMe=true&RememberMe=false";
            html = PostData(httpRequest, "https://www.howkteam.vn/account/login?ReturnUrl=%2F", data, "application/x-www-form-urlencoded", UserAgent).ToString();

            html = GetData("https://www.howkteam.vn", httpRequest, UserAgent);

            File.WriteAllText("res.html", html);
            Process.Start("res.html");
        }
        public string GetCaptChaCode()
        {
            string captchaCode = "";
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri("http://tracuuhoadon.gdt.gov.vn/Captcha.jpg"), "Captcha.jpg");
                //var autoOcr = new AutoOcr();
                //Image img = new Bitmap(Application.StartupPath + "\\Captcha.jpg");
                //captchaCode = autoOcr.Read(img).ToString();
                using (var objOcr = OcrApi.Create())
                {
                    objOcr.Init(Patagames.Ocr.Enums.Languages.English);

                    captchaCode = objOcr.GetTextFromImage(Application.StartupPath + "\\Captcha.jpg");
                }
                return captchaCode = Regex.Replace(captchaCode, @"\r\n?|\n", "");
            }
        }
        public string PostDataCaptcha(HttpRequest http, string url, MultipartContent data = null, string contentType = null, string userArgent = "", string cookie = null)
        {
            if (http == null)
            {
                http = new HttpRequest();
                http.Cookies = new CookieDictionary();
            }

            if (!string.IsNullOrEmpty(cookie))
            {
                AddCookie(http, cookie);
            }

            if (!string.IsNullOrEmpty(userArgent))
            {
                http.UserAgent = userArgent;
            }

            string html = http.Post(url, data).ToString();
            return html;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            HttpRequest httpRequest = new HttpRequest();
            httpRequest.Cookies = new CookieDictionary();
            httpRequest.KeepAlive = true;
            httpRequest.KeepAliveTimeout = 10;

            //httpRequest.AddHeader("Accept-Encoding", "gzip,deflate");
            //httpRequest.AddHeader("Accept-Language", "vi,en-US;q=0.9,en;q=0.8");
            //httpRequest.AddHeader("Connection", "keep-alive");
            //httpRequest.AddHeader("Content-Length", "18");
            //httpRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            //httpRequest.AddHeader("Host", "tracuuhoadon.gdt.gov.vn");
            //httpRequest.AddHeader("Origin", "http://tracuuhoadon.gdt.gov.vn");
            //httpRequest.AddHeader("Referer", "http://tracuuhoadon.gdt.gov.vn/tbphtc.html");
            //httpRequest.AddHeader("X-Requested-With", "XMLHttpRequest");
            //httpRequest.AddHeader("Save-Data", "on");

            string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.83 YaBrowser/20.9.0.933 Yowser/2.5 Safari/537.36";

            var html = GetData("http://tracuuhoadon.gdt.gov.vn/tbphtc.html#", httpRequest, UserAgent);
            string token = GetLoginDataToken(html);

            string tin = "0400466187";
            string captchaCode = GetCaptChaCode();
            captchaCode = Regex.Replace(captchaCode, @"\s+", "");
            //MultipartContent data = new MultipartContent()
            //{
            //    { new StringContent("captchaCode"),captchaCode},
            //};

            html = PostDataTracuuhoadon(httpRequest, "http://tracuuhoadon.gdt.gov.vn/validcode.html?captchaCode=" + captchaCode + "", null, "application/x-www-form-urlencoded; charset=UTF-8");

            Thread.Sleep(TimeSpan.FromSeconds(3));

            html = PostDataTracuuhoadon(httpRequest, "http://tracuuhoadon.gdt.gov.vn/gettin.html?tin=" + tin + "&captchaCode=" + captchaCode + "", null, "application/json;charset=UTF-8", UserAgent).ToString();

            Thread.Sleep(TimeSpan.FromSeconds(10));
            html = GetData("http://tracuuhoadon.gdt.gov.vn/searchtbph.html?_search=false&nd=" + 1601881184080 + "&rows=10&page=1&sidx=&sord=asc&kind=tc&tin=" + tin + "&ngayTu=01%2F01%2F2018&ngayDen=01%2F01%2F2020&captchaCode=" + captchaCode + "&token=" + token + "&struts.token.name=token&_=" + 1601880739099 + "", httpRequest, UserAgent); ;

            //Tracuuhoadon resData = JsonConvert.DeserializeObject<Tracuuhoadon>(html);
            File.WriteAllText("res.html", html);
            Process.Start("res.html");
        }

        public string UploadData(HttpRequest http, string url, MultipartContent data = null, string contentType = null, string userArgent = "", string cookie = null)
        {
            if (http == null)
            {
                http = new HttpRequest();
                http.Cookies = new CookieDictionary();
            }

            if (!string.IsNullOrEmpty(cookie))
            {
                AddCookie(http, cookie);
            }

            if (!string.IsNullOrEmpty(userArgent))
            {
                http.UserAgent = userArgent;
            }

            string html = http.Post(url, data).ToString();
            return html;
        }
        public void UploadFile(string path)
        {
            MultipartContent data = new MultipartContent()
            {
                { new StringContent ("dzuuid"), "27246ca7-0817-46fa-855c-953310ced99e" },
                { new StringContent ("dzchunkindex"), "0" },
                { new StringContent ("dztotalfilesize"), "1746" },
                { new StringContent ("dzchunksize"), "104572000" },
                { new StringContent ("dztotalchunkcount"), "1" },
                { new StringContent ("dzchunkbyteoffset"), "0" },
                { new StringContent ("session_id"), "7kin8qttarlj65r5lfuav1tpsrt4ch6s" },
                { new FileContent (path),"file", Path.GetFileName(path) },
            };

            var html = UploadData(null, "https://up.uploadfiles.io/upload", data);

            var resData = JsonConvert.DeserializeObject<UploadFileModel>(html);

            Process.Start(resData.destination);

        }

        public void UploadFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                UploadFile(openFileDialog.FileName);
            }
        }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            UploadFile();
        }

        private void btnVerifyEmail_Click(object sender, EventArgs e)
        {
            Mail.Verify("", "", "imap.one.com", 993);
        }

        private void btnDowloadFile_Click(object sender, EventArgs e)
        {
            HttpRequest httpRequest = new HttpRequest();
            httpRequest.ConnectTimeout = 99999999;
            httpRequest.KeepAliveTimeout = 99999999;
            httpRequest.ReadWriteTimeout = 99999999;

            var binImage = httpRequest.Get("").ToMemoryStream().ToArray();
            string fileName = "FileDowload.pdf";
            File.WriteAllBytes(fileName, binImage);
            Process.Start(fileName);
        }

        private void btnFakeIP_Click(object sender, EventArgs e)
        {
            HttpRequest httpRequest = new HttpRequest();
            string Ip = "62.219.249.204:8080";
            httpRequest.Proxy = HttpProxyClient.Parse(Ip);
            var html = GetData("https://whoer.net/", httpRequest);

            ShowData(html);
        }
    }
    public class UploadFileModel
    {
        public bool status { get; set; }
        public int id { get; set; }
        public string url { get; set; }
        public string destination { get; set; }
        public string name { get; set; }
        public string filename { get; set; }
        public string slug { get; set; }
        public string size { get; set; }
        public string type { get; set; }
        public string expiry { get; set; }
        public int location { get; set; }
    }


    public class Tracuuhoadon
    {
        public string captchaCode { get; set; }
        public object dvsd { get; set; }
        public object kind { get; set; }
        public object ltd { get; set; }
        public object ngayDen { get; set; }
        public object ngayTu { get; set; }
        public object strMess { get; set; }
        public string tin { get; set; }
        public Tinmodel tinModel { get; set; }
    }

    public class Tinmodel
    {
        public DateTime chan_date { get; set; }
        public object den_ngay { get; set; }
        public object dvsd { get; set; }
        public string econ_name { get; set; }
        public string economy { get; set; }
        public object link { get; set; }
        public string norm_name { get; set; }
        public object pare_tin { get; set; }
        public string pay_taxo_id { get; set; }
        public string pay_taxo_name { get; set; }
        public string pay_taxo_name_blhd { get; set; }
        public DateTime regi_date { get; set; }
        public bool search { get; set; }
        public string status { get; set; }
        public string statusName { get; set; }
        public string tin { get; set; }
        public string tran_addr { get; set; }
        public string tran_dist { get; set; }
        public object tran_fax { get; set; }
        public string tran_tel { get; set; }
        public DateTime tu_ngay { get; set; }
    }

    public class Rootobject
    {
        public object[] actionErrors { get; set; }
        public object[] actionMessages { get; set; }
        public object bkes { get; set; }
        public bool brcr { get; set; }
        public string captchaCode { get; set; }
        public object dtls { get; set; }
        public object dtnt_tin { get; set; }
        public object[] errorMessages { get; set; }
        public Errors errors { get; set; }
        public Fielderrors fieldErrors { get; set; }
        public object id { get; set; }
        public string kind { get; set; }
        public List[] list { get; set; }
        public object loaitb_phanh { get; set; }
        public string locale { get; set; }
        public object ltd { get; set; }
        public string newToken { get; set; }
        public DateTime ngayDen { get; set; }
        public DateTime ngayTu { get; set; }
        public string page { get; set; }
        public string pager { get; set; }
        public Paramsearch paramSearch { get; set; }
        public string records { get; set; }
        public string rows { get; set; }
        public string sidx { get; set; }
        public string sord { get; set; }
        public object systemParam { get; set; }
        public object tbph { get; set; }
        public string tbphDcDtls { get; set; }
        public string tbphDtls { get; set; }
        public object texts { get; set; }
        public string theNewToken { get; set; }
        public string tin { get; set; }
        public object tinModel { get; set; }
        public string tinProc { get; set; }
        public string total { get; set; }
    }

    public class Errors
    {
    }

    public class Fielderrors
    {
    }

    public class Paramsearch
    {
        public string nguonGoc { get; set; }
        public DateTime ngayTu { get; set; }
        public string tin { get; set; }
        public string rows { get; set; }
        public DateTime ngayDen { get; set; }
        public string page { get; set; }
    }

    public class List
    {
        public object bkes { get; set; }
        public int cqt_id { get; set; }
        public string cqt_ten { get; set; }
        public object dnghiep_cquan_tin { get; set; }
        public object dtls { get; set; }
        public string dtnt_diachi { get; set; }
        public string dtnt_tel { get; set; }
        public string dtnt_ten { get; set; }
        public string dtnt_tin { get; set; }
        public object ghi_chu { get; set; }
        public object hdo_dnghiep_cquan { get; set; }
        public string id { get; set; }
        public int lan_thaydoi { get; set; }
        public object link { get; set; }
        public string loaitb_phanh { get; set; }
        public object ngay_nhan_tbao { get; set; }
        public string ngay_phathanh { get; set; }
        public object ngay_sdttb { get; set; }
        public bool search { get; set; }
        public string so_thong_bao { get; set; }
        public object tbphs { get; set; }
        public string thu_truong { get; set; }
        public string tthai_tbao { get; set; }
    }
    public static class Mail
    {
        public static void Verify(string email, string pass, string ipmap, int port)
        {
            string url = null;
            using (ImapClient ic = new ImapClient())
            {
                ic.Connect(ipmap, port, true, false);
                ic.Login(email, pass);
                ic.SelectMailbox("INBOX");
                int mailcount;
                for (mailcount = ic.GetMessageCount(); mailcount < 2; mailcount = ic.GetMessageCount())
                {
                    Mail.Delay(5);
                    ic.SelectMailbox("INBOX");
                }
                MailMessage[] mm = ic.GetMessages(mailcount - 1, mailcount - 1, false, false);
                MailMessage[] array = mm;
                for (int j = 0; j < array.Length; j++)
                {
                    MailMessage i = array[j];
                    //bool flag = i.Subject == "Account registration confirmation" || i.Subject.Contains("Please verify your account");
                    //if (flag)
                    {
                        string sbody = i.Body;
                        url = Regex.Match(i.Body, "a href=\"(https:[^\n]+)").Groups[1].Value;
                        bool flag2 = string.IsNullOrEmpty(url);
                        if (flag2)
                        {
                            url = Regex.Match(i.Body, "(http.*)").Groups[1].Value.Trim();
                            url = url.Substring(0, url.IndexOf('"'));
                        }
                        break;
                    }
                }
                ic.Dispose();
            }
            HttpRequest rq = new HttpRequest();
            rq.Cookies = new CookieDictionary(false);
            rq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.92 Safari/537.36";
            bool Load = false;
            while (!Load)
            {
                try
                {
                    rq.Get(url, null);
                    Load = true;
                }
                catch (Exception)
                {
                }
            }
        }
        private static void Delay(int time)
        {
            for (int i = 0; i < time; i++)
            {
                Thread.Sleep(time);
            }
        }
    }
}
