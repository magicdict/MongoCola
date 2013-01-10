using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool.UnitTest
{
    public partial class frmSinaWeiBo : Form
    {

        public frmSinaWeiBo()
        {
            InitializeComponent();
        }
        private void frmSinaWeiBo_Load(object sender, EventArgs e)
        {
            txtAppKey.Text = "1953953400";
            txtAppSrect.Text = "6d0dd1b827b5f4b87d3651428160cfb8";
            txtWeiBoUsr.Text = "mynightelfplayer@hotmail.com";
            txtSupperStarID.Text = "1195242865";
            txtSupperStarName.Text = "YangMi";
        }
        private void btnGetMyFriendsAndFollowers_Click(object sender, EventArgs e)
        {
            var Srv = SystemManager.GetCurrentServer();
            if (Srv != null)
            {
                var db = Srv.GetDatabase("SinaWeibo");
                var oauth = new NetDimension.Weibo.OAuth(txtAppKey.Text, txtAppSrect.Text);
                bool result = oauth.ClientLogin(txtWeiBoUsr.Text, txtWeiBoPsw.Text);
                if (result) //返回true成功
                {
                    var Sina = new NetDimension.Weibo.Client(oauth);
                    var uid = Sina.API.Account.GetUID();
                    var friends = Sina.API.Friendships.Friends(uid);
                    foreach (var friend in friends.Users)
                    {
                        var col = db.GetCollection("MyFriends");
                        col.Insert(friend);
                    }
                    var followers = Sina.API.Friendships.Followers(uid);
                    foreach (var follow in followers.Users)
                    {
                        var col = db.GetCollection("MyFollowers");
                        col.Insert(follow);
                    }
                }
            }
            MessageBox.Show("OK");

        }
        private void btnGetAllWeiBoUsers_Click(object sender, EventArgs e)
        {
            var Srv = SystemManager.GetCurrentServer();
            if (Srv != null)
            {
                var db = Srv.GetDatabase("SinaWeibo");
                var col = db.GetCollection("User");
                var oauth = new NetDimension.Weibo.OAuth(txtAppKey.Text, txtAppSrect.Text);
                bool result = oauth.ClientLogin(txtWeiBoUsr.Text, txtWeiBoPsw.Text);
                if (result) //返回true成功
                {
                    var Sina = new NetDimension.Weibo.Client(oauth);
                    var uid = Sina.API.Account.GetUID();
                    GetUser(col, Sina, uid);
                }
            }
            MessageBox.Show("OK");
        }

        private void GetUser(MongoCollection<BsonDocument> col, NetDimension.Weibo.Client Sina, string uid)
        {
            var friends = Sina.API.Friendships.Friends(uid);
            int UserCount = 0;
            foreach (var friend in friends.Users)
            {
                col.Insert(friend);
                UserCount++;
            }
            foreach (var friend in friends.Users)
            {
                GetUser(col, Sina, friend.ID);
            }
        }

        private void btnGetFollowers_Click(object sender, EventArgs e)
        {
            var Srv = SystemManager.GetCurrentServer();
            if (Srv != null)
            {
                var db = Srv.GetDatabase("SinaWeibo");
                var oauth = new NetDimension.Weibo.OAuth(txtAppKey.Text, txtAppSrect.Text);
                bool result = oauth.ClientLogin(txtWeiBoUsr.Text, txtWeiBoPsw.Text);
                if (result) //返回true成功
                {
                    var Sina = new NetDimension.Weibo.Client(oauth);
                    var uid = Sina.API.Account.GetUID();
                    var col = db.GetCollection(txtSupperStarID.Text + txtSupperStarName.Text + "(Followers)");
                    int UserCount;
                    int TotalCount;
                    UserCount = 0;
                    TotalCount = 0;

                    NetDimension.Weibo.Entities.user.Collection followers;
                    do
                    {
                        followers = Sina.API.Friendships.Followers(txtSupperStarID.Text, "", 150, UserCount, true);
                        if (TotalCount == 0)
                        {
                            TotalCount = followers.TotalNumber;
                        }
                        foreach (var follow in followers.Users)
                        {
                            col.Insert(follow);
                            UserCount++;
                        }
                    } while (UserCount < TotalCount);
                    MessageBox.Show("OK");
                }
            }
            else {
                MessageBox.Show("MongoDB Not Found");
            }
        }
    }
}
