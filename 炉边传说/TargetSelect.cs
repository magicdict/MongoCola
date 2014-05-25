using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Card;
using Card.Client;

namespace 炉边传说
{
    public partial class TargetSelect : Form
    {
        Card.CardUtility.TargetSelectDirectEnum direct;
        Card.CardUtility.TargetSelectRoleEnum role;
        GameManager game;
        public CardUtility.TargetPosition pos = new CardUtility.TargetPosition();
        public TargetSelect(CardUtility.TargetSelectDirectEnum mDirect, CardUtility.TargetSelectRoleEnum mRole, GameManager mGame)
        {
            InitializeComponent();
            direct = mDirect;
            role = mRole;
            game = mGame;
        }

        private void TargetSelect_Load(object sender, EventArgs e)
        {
            btnMyHero.Text = game.MySelf.RoleInfo.GetInfo();
            btnYourHero.Text = game.AgainstInfo.GetInfo();
            for (int i = 0; i < game.MySelf.RoleInfo.BattleField.MinionCount; i++)
            {
                Controls.Find("btnMe" + (i + 1).ToString(), true)[0].Text = game.MySelf.RoleInfo.BattleField.BattleMinions[i].GetInfo();
                Controls.Find("btnMe" + (i + 1).ToString(), true)[0].Click += (x, y) =>
                {
                    pos.MeOrYou = true;
                    pos.Postion = i + 1;
                    this.Close();
                };
            }
            for (int i = 0; i < game.AgainstInfo.BattleField.MinionCount; i++)
            {
                Controls.Find("btnYou" + (i + 1).ToString(), true)[0].Text = game.AgainstInfo.BattleField.BattleMinions[i].GetInfo();
                Controls.Find("btnYou" + (i + 1).ToString(), true)[0].Click += (x, y) =>
                {
                    pos.MeOrYou = false;
                    pos.Postion = i + 1;
                    this.Close();
                };
            }
            btnMyHero.Enabled = false;
            btnMyHero.Click += (x, y) =>
            {
                pos.MeOrYou = true;
                pos.Postion = 0;
                this.Close();
            };
            btnYourHero.Enabled = false;
            btnYourHero.Click += (x, y) =>
            {
                pos.MeOrYou = false;
                pos.Postion = 0;
                this.Close();
            };

            for (int i = 0; i < 7; i++)
            {
                Controls.Find("btnMe" + (i + 1).ToString(), true)[0].Enabled = false;
                Controls.Find("btnMe" + (i + 1).ToString(), true)[0].Click += (x, y) =>
                {
                    pos.MeOrYou = false;
                    pos.Postion = 0;
                    this.Close();
                };
            }
            for (int i = 0; i < 7; i++)
            {
                Controls.Find("btnYou" + (i + 1).ToString(), true)[0].Enabled = false;
            }
            switch (direct)
            {
                case CardUtility.TargetSelectDirectEnum.本方:
                    switch (role)
                    {
                        case CardUtility.TargetSelectRoleEnum.随从:
                            for (int i = 0; i < game.MySelf.RoleInfo.BattleField.MinionCount; i++)
                            {
                                Controls.Find("btnMe" + (i + 1).ToString(), true)[0].Enabled = true;
                            }
                            break;
                        case CardUtility.TargetSelectRoleEnum.英雄:
                            btnMyHero.Enabled = true;
                            break;
                        case CardUtility.TargetSelectRoleEnum.所有角色:
                            btnMyHero.Enabled = true;
                            for (int i = 0; i < game.MySelf.RoleInfo.BattleField.MinionCount; i++)
                            {
                                Controls.Find("btnMe" + (i + 1).ToString(), true)[0].Enabled = true;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case CardUtility.TargetSelectDirectEnum.对方:
                    switch (role)
                    {
                        case CardUtility.TargetSelectRoleEnum.随从:
                            for (int i = 0; i < game.AgainstInfo.BattleField.MinionCount; i++)
                            {
                                Controls.Find("btnYou" + (i + 1).ToString(), true)[0].Enabled = true;
                            }
                            break;
                        case CardUtility.TargetSelectRoleEnum.英雄:
                            btnYourHero.Enabled = true;
                            break;
                        case CardUtility.TargetSelectRoleEnum.所有角色:
                            btnYourHero.Enabled = true;
                            for (int i = 0; i < game.AgainstInfo.BattleField.MinionCount; i++)
                            {
                                Controls.Find("btnYou" + (i + 1).ToString(), true)[0].Enabled = true;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case CardUtility.TargetSelectDirectEnum.双方:
                    switch (role)
                    {
                        case CardUtility.TargetSelectRoleEnum.随从:
                            for (int i = 0; i < game.MySelf.RoleInfo.BattleField.MinionCount; i++)
                            {
                                Controls.Find("btnMe" + (i + 1).ToString(), true)[0].Enabled = true;
                            }
                            for (int i = 0; i < game.AgainstInfo.BattleField.MinionCount; i++)
                            {
                                Controls.Find("btnYou" + (i + 1).ToString(), true)[0].Enabled = true;
                            }
                            break;
                        case CardUtility.TargetSelectRoleEnum.英雄:
                            btnMyHero.Enabled = true;
                            btnYourHero.Enabled = true;
                            break;
                        case CardUtility.TargetSelectRoleEnum.所有角色:
                            btnMyHero.Enabled = true;
                            btnYourHero.Enabled = true;
                            for (int i = 0; i < game.MySelf.RoleInfo.BattleField.MinionCount; i++)
                            {
                                Controls.Find("btnMe" + (i + 1).ToString(), true)[0].Enabled = true;
                            }
                            for (int i = 0; i < game.AgainstInfo.BattleField.MinionCount; i++)
                            {
                                Controls.Find("btnYou" + (i + 1).ToString(), true)[0].Enabled = true;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
