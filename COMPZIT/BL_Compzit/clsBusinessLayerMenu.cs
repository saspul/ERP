using DL_Compzit;
using EL_Compzit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CL_Compzit;
namespace BL_Compzit
{
    public class clsBusinessLayerMenu
    {

        private enum USERLIMITED
        {
            ISLIMITED = 1,
            NOTLIMITED = 2

        }

        //FMS,PMS
        public StringBuilder GetMenuDataCompzitNew(clsEntityLayerLogin objEntity, int intUserId)
        {
            int intUserLimited = Convert.ToInt32(USERLIMITED.ISLIMITED);

            clsBusinessLayerDesignation objBusinessLayerDsgnMaster = new clsBusinessLayerDesignation();
            clsEntityLayerDesignation objEntityDsgn = new clsEntityLayerDesignation();
            objEntityDsgn.DesignationUserId = intUserId;

            DataTable dtUserLimitedDetails = objBusinessLayerDsgnMaster.ReadIfUserLimitedByUsrId(objEntityDsgn);
            if (dtUserLimitedDetails.Rows.Count > 0)
            {
                intUserLimited = Convert.ToInt32(dtUserLimitedDetails.Rows[0]["USR_LMTD"].ToString());
            }

            StringBuilder objstr = new StringBuilder();
            List<MenuParant> objpmenu = new List<MenuParant>();
            List<MenuChild> objcmenu = new List<MenuChild>();
            List<MenuChildChild> objccmenu = new List<MenuChildChild>();

            objpmenu = GetParantMenu(objEntity);
            objcmenu = GetChildMenu(objEntity);
            objccmenu = GetChildChildMenu(objEntity);

            objstr.Append("<ul id=\"myUL\" class=\"menu_ul\">");

            foreach (MenuParant _pitem in objpmenu)
            {
                if (_pitem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                {
                }
                else
                {
                    var childitem = objcmenu.Where(m => m.PairantId == _pitem.Id).ToList();
                    if (_pitem.ParentTarget == "S")
                    {
                        if (_pitem.ParentImage != "")
                        {
                            if (childitem.Count > 0)
                            {
                                objstr.Append("<li class=\"dropdown drop2\"><a href='" + _pitem.Url + "' class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\" onclick=\" InsertRecent('" + _pitem.Id + "','" + _pitem.Url + "')\" ><i class=\"men_img\"> <img src='" + _pitem.ParentImage + "' /></i>" + _pitem.MenuName + "<span class=\"caret c2\"></span></a>");
                            }
                            else
                            {
                                objstr.Append("<li ><a href='" + _pitem.Url + "' onclick=\" InsertRecent('" + _pitem.Id + "','" + _pitem.Url + "')\"><i class=\"men_img\"> <img src='" + _pitem.ParentImage + "'  /></i>" + _pitem.MenuName + "</a>");
                            }
                        }
                        else
                        {
                            if (childitem.Count > 0)
                            {
                                objstr.Append("<li  class=\"dropdown drop2\"><a href='" + _pitem.Url + "' class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\" onclick=\" InsertRecent('" + _pitem.Id + "','" + _pitem.Url + "')\"> " + _pitem.MenuName + "<span class=\"caret c2\"></span></a>");
                            }
                            else
                            {
                                objstr.Append("<li><a href='" + _pitem.Url + "' onclick=\" InsertRecent('" + _pitem.Id + "','" + _pitem.Url + "')\"> " + _pitem.MenuName + "</a>");
                            }
                        }
                    }
                    else if (_pitem.ParentTarget == "N")
                    {
                        if (_pitem.ParentImage != "")
                        {
                            if (childitem.Count > 0)
                            {
                                objstr.Append("<li  class=\"dropdown drop2\"><a href='" + _pitem.Url + "' target='_blank' class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\" onclick=\" InsertRecent('" + _pitem.Id + "','" + _pitem.Url + "')\"><i class=\"men_img\"><img src='" + _pitem.ParentImage + "'  /></i>" + _pitem.MenuName + "<span class=\"caret c2\"></span></a>");
                            }
                            else
                            {
                                objstr.Append("<li ><a href='" + _pitem.Url + "' target='_blank' onclick=\" InsertRecent('" + _pitem.Id + "','" + _pitem.Url + "')\"><i class=\"men_img\"><img src='" + _pitem.ParentImage + "' /></i>" + _pitem.MenuName + "</a>");
                            }
                        }
                        else
                        {
                            if (childitem.Count > 0)
                            {
                                objstr.Append("<li  class=\"dropdown drop2\"><a href='" + _pitem.Url + "' target='_blank' class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\" onclick=\" InsertRecent('" + _pitem.Id + "','" + _pitem.Url + "')\"> " + _pitem.MenuName + "<span class=\"caret c2\"></span></a>");
                            }
                            else
                            {
                                objstr.Append("<li><a href='" + _pitem.Url + "' target='_blank' onclick=\" InsertRecent('" + _pitem.Id + "','" + _pitem.Url + "')\"> " + _pitem.MenuName + "</a>");
                            }

                        }
                    }
                    if (childitem.Count > 0)
                    {
                        objstr.Append("<ul class=\"dropdown-menu dropul\">");
                        /*Level 2*/
                        foreach (var _citem in childitem)
                        {
                            if (_citem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                            {
                            }
                            else if (_citem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Job_role) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                            {

                            }
                            else if (_citem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Master) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                            {

                            }
                            else
                            {
                                var childchilditem = objccmenu.Where(mc => mc.PairantChildId == _citem.Id).ToList();

                                if (_citem.ChildTarget == "S")
                                {
                                    if (childchilditem.Count > 0)
                                    {
                                        if (_citem.ChildImage != "")
                                        {
                                            objstr.Append("<li  class=\"dropdown drop2\"><a href='" + _citem.ChildUrl + "'  class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\" onclick=\" InsertRecent('" + _citem.Id + "','" + _citem.ChildUrl + "')\"><i class=\"men_img\"><img src='" + _citem.ChildImage + "' /></i>" + _citem.ChildName + "<span class=\"caret c2\"></span></a>");
                                        }
                                        else
                                        {
                                            objstr.Append("<li  class=\"dropdown drop2\"><a href='" + _citem.ChildUrl + "'  class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\" onclick=\" InsertRecent('" + _citem.Id + "','" + _citem.ChildUrl + "')\">" + _citem.ChildName + "<span class=\"caret c2\"></span></a>");
                                        }
                                    }
                                    else
                                    {
                                        if (_citem.ChildImage != "")
                                        {
                                            objstr.Append("<li><a href='" + _citem.ChildUrl + "' onclick=\" InsertRecent('" + _citem.Id + "','" + _citem.ChildUrl + "')\" ><i class=\"men_img\"><img src='" + _citem.ChildImage + "' /></i>" + _citem.ChildName + "</a>");
                                        }
                                        else
                                        {
                                            objstr.Append("<li ><a href='" + _citem.ChildUrl + "' onclick=\" InsertRecent('" + _citem.Id + "','" + _citem.ChildUrl + "')\" >" + _citem.ChildName + "</a>");
                                        }
                                    }
                                }
                                else
                                {
                                    if (childchilditem.Count > 0)
                                    {
                                        if (_citem.ChildImage != "")
                                        {
                                            objstr.Append("<li  class=\"dropdown drop2\"><a href='" + _citem.ChildUrl + "' target='_blank' class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\" onclick=\" InsertRecent('" + _citem.Id + "','" + _citem.ChildUrl + "')\"><i class=\"men_img\"><img src='" + _citem.ChildImage + "'/></i>" + _citem.ChildName + "<span class=\"caret c2\"></span></a>");
                                        }
                                        else
                                        {
                                            objstr.Append("<li  class=\"dropdown drop2\"><a href='" + _citem.ChildUrl + "' target='_blank' class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\" onclick=\" InsertRecent('" + _citem.Id + "','" + _citem.ChildUrl + "')\">" + _citem.ChildName + "<span class=\"caret c2\"></span></a>");
                                        }
                                    }
                                    else
                                    {
                                        if (_citem.ChildImage != "")
                                        {
                                            objstr.Append("<li><a href='" + _citem.ChildUrl + "' target='_blank' onclick=\" InsertRecent('" + _citem.Id + "','" + _citem.ChildUrl + "')\"><i class=\"men_img\"><img src='" + _citem.ChildImage + "'/></i>" + _citem.ChildName + "</a>");
                                        }
                                        else
                                        {
                                            objstr.Append("<li><a href='" + _citem.ChildUrl + "' target='_blank' onclick=\" InsertRecent('" + _citem.Id + "','" + _citem.ChildUrl + "')\">" + _citem.ChildName + "</a>");
                                        }
                                    }
                                }


                                if (childchilditem.Count > 0)
                                {
                                    objstr.Append("<ul class=\"dropdown-menu dropul\">");

                                    /*Level 3*/
                                    foreach (MenuChildChild _ccitem in childchilditem)
                                    {
                                        if (_ccitem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                                        {
                                        }
                                        else
                                        {
                                            if (_ccitem.ChildChildTarget == "S")
                                            {
                                                if (_ccitem.ChildChildImage != "")
                                                {
                                                    objstr.Append("<li><a href='" + _ccitem.ChildChildUrl + "' onclick=\" InsertRecent('" + _ccitem.Id + "','" + _ccitem.ChildChildUrl + "')\"><i class=\"men_img\"><img src='" + _ccitem.ChildChildImage + "'/></i>" + _ccitem.ChildChildName + "</a></li>");
                                                }
                                                else
                                                {
                                                    objstr.Append("<li ><a href='" + _ccitem.ChildChildUrl + "' onclick=\" InsertRecent('" + _ccitem.Id + "','" + _ccitem.ChildChildUrl + "')\">" + _ccitem.ChildChildName + "</a></li>");

                                                }
                                            }
                                            else
                                            {
                                                if (_ccitem.ChildChildImage != "")
                                                {
                                                    objstr.Append("<li><a href='" + _ccitem.ChildChildUrl + "' target='_blank'  onclick=\" InsertRecent('" + _ccitem.Id + "','" + _ccitem.ChildChildUrl + "')\"><i class=\"men_img\"><img src='" + _ccitem.ChildChildImage + "'/></i>" + _ccitem.ChildChildName + "</a></li>");
                                                }
                                                else
                                                {
                                                    objstr.Append("<li ><a href='" + _ccitem.ChildChildUrl + "' target='_blank'  onclick=\" InsertRecent('" + _ccitem.Id + "','" + _ccitem.ChildChildUrl + "')\">" + _ccitem.ChildChildName + "</a></li>");

                                                }
                                            }

                                        }
                                    }
                                    objstr.Append("</ul >");
                                }


                                objstr.Append("</li >");

                            }

                        }
                        objstr.Append("</ul>");
                    }
                    objstr.Append("</li>");
                }
            }
            objstr.Append("</ul>");
            objstr.ToString();
            return objstr;
        }

        public StringBuilder GetMenuDataForRecentMenuNew(clsEntityLayerLogin objEntity, int intUserId, string strRecentCount)
        {
            int intUserLimited = Convert.ToInt32(USERLIMITED.ISLIMITED);
            clsBusinessLayerDesignation objBusinessLayerDsgnMaster = new clsBusinessLayerDesignation();
            clsEntityLayerDesignation objEntityDsgn = new clsEntityLayerDesignation();

            clsBusinessLayerRecentMenu objRecentMenu = new clsBusinessLayerRecentMenu();
            clsEntityLayerRecentMenu objEntityRecentmenu = new clsEntityLayerRecentMenu();

            objEntityRecentmenu.CorpId = objEntity.CorpOfficeId;
            objEntityRecentmenu.OrgId = objEntity.OrgId;
            objEntityRecentmenu.UserId = intUserId;
            objEntityRecentmenu.AppId = objEntity.Cmp_AppId;

            DataTable dtRecentmenu = objRecentMenu.ReadRecentMenu(objEntityRecentmenu);
            Array[] arrMenuID = new Array[dtRecentmenu.Rows.Count];

            objEntityDsgn.DesignationUserId = intUserId;

            DataTable dtUserLimitedDetails = new DataTable();

            dtUserLimitedDetails = objBusinessLayerDsgnMaster.ReadIfUserLimitedByUsrId(objEntityDsgn);
            if (dtUserLimitedDetails.Rows.Count > 0)
            {
                intUserLimited = Convert.ToInt32(dtUserLimitedDetails.Rows[0]["USR_LMTD"].ToString());
            }

            StringBuilder objstr = new StringBuilder();
            List<MenuParant> objpmenu = new List<MenuParant>();
            List<MenuChild> objcmenu = new List<MenuChild>();
            List<MenuChildChild> objccmenu = new List<MenuChildChild>();

            objpmenu = GetParantMenu(objEntity);
            objcmenu = GetChildMenu(objEntity);
            objccmenu = GetChildChildMenu(objEntity);

            if (dtRecentmenu.Rows.Count > 0)
            {
                objstr.Append("<ul class=\"menu_ul\" >");
                objstr.Append("<li class=\"dropdown drop2 pin1\" ><a href=\"javascript:;\" class=\"dropdown-toggle active\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\"><i class=\"men_img\" /><img src=\"/images/menu/pn.png\"></i> Recently Used <span class=\"caret c2\"></span></a>");
                objstr.Append("<ul class=\"dropdown-menu dropul pin_ul\" >");

                for (int i = 0; (i < Convert.ToInt32(strRecentCount)) && (i < dtRecentmenu.Rows.Count); i++)
                {
                    foreach (MenuParant _pitem in objpmenu)
                    {
                        if (dtRecentmenu.Rows[i]["MENU_ID"].ToString() == _pitem.Id.ToString())
                        {
                            objstr.Append("<li><a href='" + _pitem.Url + "' title='" + _pitem.MenuName + "'  onclick=\" InsertRecent('" + _pitem.Id + "','" + _pitem.Url + "')\"><i class=\"men_img\"><img src='" + _pitem.ParentImage + "' /></i>" + _pitem.MenuName + "<span class=\"c2\"></span></a></li>");
                        }
                    }
                }

                for (int i = 0; (i < Convert.ToInt32(strRecentCount)) && (i < dtRecentmenu.Rows.Count); i++)
                {
                    foreach (MenuChild _citem in objcmenu)
                    {
                        if (dtRecentmenu.Rows[i]["MENU_ID"].ToString() == _citem.Id.ToString())
                        {
                            objstr.Append("<li><a href='" + _citem.ChildUrl + "' title='" + _citem.ChildName + "' onclick=\" InsertRecent('" + _citem.Id + "','" + _citem.ChildUrl + "')\"><i class=\"men_img\"><img src='" + _citem.ChildImage + "' /></i>" + _citem.ChildName + "<span class=\"c2\"></span></a></li>");
                        }
                    }
                }

                for (int i = 0; (i < Convert.ToInt32(strRecentCount)) && (i < dtRecentmenu.Rows.Count); i++)
                {
                    foreach (MenuChildChild _ccitem in objccmenu)
                    {
                        if (dtRecentmenu.Rows[i]["MENU_ID"].ToString() == _ccitem.Id.ToString())
                        {
                            objstr.Append("<li><a href='" + _ccitem.ChildChildUrl + "' title='" + _ccitem.ChildChildName + "' onclick=\" InsertRecent('" + _ccitem.Id + "','" + _ccitem.ChildChildUrl + "')\"><i class=\"men_img\"><img src='" + _ccitem.ChildChildImage + "'/></i>" + _ccitem.ChildChildName + "<span class=\"c2\"></span></a></li>");
                        }
                    }
                }

                objstr.Append("</ul>");
                objstr.Append("</li>");
                objstr.Append("</ul>");
            }

            objstr.ToString();
            return objstr;
        }
        public StringBuilder GetMenuDataForFrequentlyMenuNew(clsEntityLayerLogin objEntity, int intUserId, string strFrequentCount)
        {
            int intUserLimited = Convert.ToInt32(USERLIMITED.ISLIMITED);
            clsBusinessLayerDesignation objBusinessLayerDsgnMaster = new clsBusinessLayerDesignation();
            clsEntityLayerDesignation objEntityDsgn = new clsEntityLayerDesignation();

            clsBusinessLayerRecentMenu objRecentMenu = new clsBusinessLayerRecentMenu();
            clsEntityLayerRecentMenu objEntityRecentmenu = new clsEntityLayerRecentMenu();

            objEntityRecentmenu.CorpId = objEntity.CorpOfficeId;
            objEntityRecentmenu.OrgId = objEntity.OrgId;
            objEntityRecentmenu.UserId = intUserId;
            objEntityRecentmenu.AppId = objEntity.Cmp_AppId;

            DataTable dtRecentmenu = objRecentMenu.ReadFrquentMenu(objEntityRecentmenu);
            Array[] arrMenuID = new Array[dtRecentmenu.Rows.Count];

            objEntityDsgn.DesignationUserId = intUserId;

            DataTable dtUserLimitedDetails = new DataTable();

            dtUserLimitedDetails = objBusinessLayerDsgnMaster.ReadIfUserLimitedByUsrId(objEntityDsgn);
            if (dtUserLimitedDetails.Rows.Count > 0)
            {
                intUserLimited = Convert.ToInt32(dtUserLimitedDetails.Rows[0]["USR_LMTD"].ToString());
            }

            StringBuilder objstr = new StringBuilder();
            List<MenuParant> objpmenu = new List<MenuParant>();
            List<MenuChild> objcmenu = new List<MenuChild>();
            List<MenuChildChild> objccmenu = new List<MenuChildChild>();

            objpmenu = GetParantMenu(objEntity);
            objcmenu = GetChildMenu(objEntity);
            objccmenu = GetChildChildMenu(objEntity);

            if (dtRecentmenu.Rows.Count > 0)
            {
                objstr.Append("<ul class=\"menu_ul\" >");
                objstr.Append("<li class=\"dropdown drop2 pin2\" ><a href=\"javascript:;\" class=\"dropdown-toggle active\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\"><i class=\"men_img\"><img src=\"/images/menu/pn.png\" /></i> Frequently Used <span class=\"caret c2\"></span></a>");
                objstr.Append("<ul class=\"dropdown-menu dropul pin_ul\" >");

                foreach (MenuParant _pitem in objpmenu)
                {
                    if (_pitem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                    {
                    }
                    else
                    {
                        var childitem = objcmenu.Where(m => m.PairantId == _pitem.Id).ToList();
                        for (int i = 0; (i < Convert.ToInt32(strFrequentCount)) && (i < dtRecentmenu.Rows.Count); i++)
                        {


                            if (dtRecentmenu.Rows[i]["MENU_ID"].ToString() == _pitem.Id.ToString())
                            {
                                if (_pitem.ParentTarget == "S")
                                {
                                    if (_pitem.ParentImage != "")
                                    {
                                        if (childitem.Count > 0)
                                        {
                                            objstr.Append("<li><a href='" + _pitem.Url + "'><i class=\"men_img\"><img src='" + _pitem.ParentImage + "'/></i>" + _pitem.MenuName + "<span class=\"c2\"></span><i class=\"fa fa-angle-left pull-right\"></i></a>");
                                        }
                                        else
                                        {
                                            objstr.Append("<li><a href='" + _pitem.Url + "'><i class=\"men_img\"><img src='" + _pitem.ParentImage + "' /></i>" + _pitem.MenuName + "<span class=\"c2\"></span></a>");
                                        }
                                    }
                                    else
                                    {
                                        if (childitem.Count > 0)
                                        {
                                            objstr.Append("<li><a href='" + _pitem.Url + "'> " + _pitem.MenuName + "<i class=\"fa fa-angle-left pull-right\"></i></a>");
                                        }
                                        else
                                        {
                                            objstr.Append("<li><a href='" + _pitem.Url + "'> " + _pitem.MenuName + "</a>");
                                        }

                                    }
                                }
                                else if (_pitem.ParentTarget == "N")
                                {
                                    if (_pitem.ParentImage != "")
                                    {
                                        if (childitem.Count > 0)
                                        {
                                            objstr.Append("<li><a href='" + _pitem.Url + "' target='_blank'><i class=\"men_img\"><img src='" + _pitem.ParentImage + "' /></i>" + _pitem.MenuName + "<span class=\"c2\"></span><i class=\"fa fa-angle-left pull-right\"></i></a>");
                                        }
                                        else
                                        {
                                            objstr.Append("<li><a href='" + _pitem.Url + "' target='_blank'><i class=\"men_img\"><img src='" + _pitem.ParentImage + "' /></i>" + _pitem.MenuName + "<span class=\"c2\"></span></a>");
                                        }
                                    }
                                    else
                                    {
                                        if (childitem.Count > 0)
                                        {
                                            objstr.Append("<li><a href='" + _pitem.Url + "' target='_blank'> " + _pitem.MenuName + "<i class=\"fa fa-angle-left pull-right\"></i></a>");
                                        }
                                        else
                                        {
                                            objstr.Append("<li><a href='" + _pitem.Url + "' target='_blank'> " + _pitem.MenuName + "</a>");
                                        }

                                    }
                                }
                            }
                        }

                        if (childitem.Count > 0)
                        {
                            /*Level 2*/
                            foreach (var _citem in childitem)
                            {
                                if (_citem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                                {
                                }
                                //EVM-0012
                                else if (_citem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Job_role) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                                {

                                }
                                else if (_citem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Master) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                                {

                                }
                                else
                                {
                                    var childchilditem = objccmenu.Where(mc => mc.PairantChildId == _citem.Id).ToList();

                                    for (int i = 0; (i < Convert.ToInt32(strFrequentCount)) && (i < dtRecentmenu.Rows.Count); i++)
                                    {
                                        if (dtRecentmenu.Rows[i]["MENU_ID"].ToString() == _citem.Id.ToString())
                                        {
                                            if (_citem.ChildTarget == "S")
                                            {
                                                if (childchilditem.Count > 0)
                                                {
                                                    if (_citem.ChildImage != "")
                                                    {
                                                        objstr.Append("<li><a href='" + _citem.ChildUrl + "' title='" + _citem.ChildName + "'><i class=\"men_img\"><img src='" + _citem.ChildImage + "' /></i>" + _citem.ChildName + "<span class=\"c2\"></span><i class=\"fa fa-angle-left pull-right\"></i></a>");
                                                    }
                                                    else
                                                    {
                                                        objstr.Append("<li><a href='" + _citem.ChildUrl + "' title='" + _citem.ChildName + "'>" + _citem.ChildName + "<i class=\"fa fa-angle-left pull-right\"></i></a>");
                                                    }
                                                }
                                                else
                                                {
                                                    if (_citem.ChildImage != "")
                                                    {
                                                        objstr.Append("<li><a href='" + _citem.ChildUrl + "' title='" + _citem.ChildName + "'><i class=\"men_img\"><img src='" + _citem.ChildImage + "' /></i>" + _citem.ChildName + "<span class=\"c2\"></span></i></a>");
                                                    }
                                                    else
                                                    {
                                                        objstr.Append("<li><a href='" + _citem.ChildUrl + "' title='" + _citem.ChildName + "'>" + _citem.ChildName + "</a>");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (childchilditem.Count > 0)
                                                {
                                                    if (_citem.ChildImage != "")
                                                    {
                                                        objstr.Append("<li><a href='" + _citem.ChildUrl + "' target='_blank' title='" + _citem.ChildName + "' ><i class=\"men_img\"><img src='" + _citem.ChildImage + " /></i>" + _citem.ChildName + "<span class=\"c2\"><span><i class=\"fa fa-angle-left pull-right\"></i></a>");
                                                    }
                                                    else
                                                    {
                                                        objstr.Append("<li><a href='" + _citem.ChildUrl + "' target='_blank' title='" + _citem.ChildName + "' >" + _citem.ChildName + "<i class=\"fa fa-angle-left pull-right\"></i></a>");

                                                    }
                                                }
                                                else
                                                {
                                                    if (_citem.ChildImage != "")
                                                    {
                                                        objstr.Append("<li><a href='" + _citem.ChildUrl + "' target='_blank' title='" + _citem.ChildName + "' ><i class=\"men_img\"><img src='" + _citem.ChildImage + "' /></i>" + _citem.ChildName + "<span class=\"c2\"><span></a>");
                                                    }
                                                    else
                                                    {
                                                        objstr.Append("<li><a href='" + _citem.ChildUrl + "' target='_blank' title='" + _citem.ChildName + "' >" + _citem.ChildName + "</a>");

                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (childchilditem.Count > 0)
                                    {
                                        //objstr.Append("<ul class=\"sidebar-submenu\">");

                                        /*Level 3*/
                                        foreach (MenuChildChild _ccitem in childchilditem)
                                        {
                                            if (_ccitem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                                            {
                                            }
                                            else
                                            {
                                                for (int i = 0; (i < Convert.ToInt32(strFrequentCount)) && (i < dtRecentmenu.Rows.Count); i++)
                                                {
                                                    if (dtRecentmenu.Rows[i]["MENU_ID"].ToString() == _ccitem.Id.ToString())
                                                    {
                                                        if (_ccitem.ChildChildTarget == "S")
                                                        {
                                                            if (_ccitem.ChildChildImage != "")
                                                            {
                                                                objstr.Append("<li><a href='" + _ccitem.ChildChildUrl + "' title='" + _ccitem.ChildChildName + "'><i class=\"men_img\"><img src='" + _ccitem.ChildChildImage + "' /></i>" + _ccitem.ChildChildName + "<span class=\"c2\"></span></a></li>");
                                                            }
                                                            else
                                                            {
                                                                objstr.Append("<li><a href='" + _ccitem.ChildChildUrl + "' title='" + _ccitem.ChildChildName + "'>" + _ccitem.ChildChildName + "</a></li>");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (_ccitem.ChildChildImage != "")
                                                            {
                                                                objstr.Append("<li><a href='" + _ccitem.ChildChildUrl + "' target='_blank'  title='" + _ccitem.ChildChildName + "' ><i class=\"men_img\"><img src='" + _ccitem.ChildChildImage + "' /></i>" + _ccitem.ChildChildName + "<span class=\"c2\"></span></a></li>");
                                                            }
                                                            else
                                                            {
                                                                objstr.Append("<li><a href='" + _ccitem.ChildChildUrl + "' target='_blank'  title='" + _ccitem.ChildChildName + "' >" + _ccitem.ChildChildName + "</a></li>");
                                                            }
                                                        }


                                                    }
                                                }
                                            }
                                        }

                                    }

                                    objstr.Append("</li >");

                                }

                            }

                        }
                    }


                }
                objstr.Append("</ul>");
                objstr.Append("</li>");
                objstr.Append("</ul>");
            }

            objstr.ToString();
            return objstr;
        }

        //APP,SFA,AWMS,GMS,HCM
        public StringBuilder GetMenuDataCompzit(clsEntityLayerLogin objEntity, int intUserId)
        {
            int intUserLimited = Convert.ToInt32(USERLIMITED.ISLIMITED);
            clsBusinessLayerDesignation objBusinessLayerDsgnMaster = new clsBusinessLayerDesignation();
            clsEntityLayerDesignation objEntityDsgn = new clsEntityLayerDesignation();
            objEntityDsgn.DesignationUserId = intUserId;
            DataTable dtUserLimitedDetails = new DataTable();

            dtUserLimitedDetails = objBusinessLayerDsgnMaster.ReadIfUserLimitedByUsrId(objEntityDsgn);
            if (dtUserLimitedDetails.Rows.Count > 0)
            {
                intUserLimited = Convert.ToInt32(dtUserLimitedDetails.Rows[0]["USR_LMTD"].ToString());
            }

            StringBuilder objstr = new StringBuilder();
            List<MenuParant> objpmenu = new List<MenuParant>();
            List<MenuChild> objcmenu = new List<MenuChild>();
            List<MenuChildChild> objccmenu = new List<MenuChildChild>();
            objpmenu = GetParantMenu(objEntity);
            objcmenu = GetChildMenu(objEntity);
            objccmenu = GetChildChildMenu(objEntity);
            objstr.Append("<ul class=\"sidebar-menu\" >");
            foreach (MenuParant _pitem in objpmenu)
            {
                if (_pitem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                {
                }
                else
                {
                    var childitem = objcmenu.Where(m => m.PairantId == _pitem.Id).ToList();
                    if (_pitem.ParentTarget == "S")
                    {
                        if (_pitem.ParentImage != "")
                        {
                            if (childitem.Count > 0)
                            {
                                objstr.Append("<li style=\"font-family: Calibri;\"><a href='" + _pitem.Url + "' onclick=\" InsertRecent('" + _pitem.Id + "','" + _pitem.Url + "')\"> <img src='" + _pitem.ParentImage + "'  style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _pitem.MenuName + "</span><i class=\"fa fa-angle-left pull-right\"></i></a>");
                            }
                            else
                            {
                                objstr.Append("<li  style=\"font-family: Calibri;\"><a href='" + _pitem.Url + "' onclick=\" InsertRecent('" + _pitem.Id + "','" + _pitem.Url + "')\"> <img src='" + _pitem.ParentImage + "'  style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _pitem.MenuName + "</span></a>");
                            }
                        }
                        else
                        {
                            if (childitem.Count > 0)
                            {
                                objstr.Append("<li  style=\"font-family: Calibri;\"><a href='" + _pitem.Url + "' onclick=\" InsertRecent('" + _pitem.Id + "','" + _pitem.Url + "')\"> " + _pitem.MenuName + "<i class=\"fa fa-angle-left pull-right\"></i></a>");
                            }
                            else
                            {
                                objstr.Append("<li  style=\"font-family: Calibri;\"><a href='" + _pitem.Url + "' onclick=\" InsertRecent('" + _pitem.Id + "','" + _pitem.Url + "')\"> " + _pitem.MenuName + "</a>");
                            }

                        }
                    }
                    else if (_pitem.ParentTarget == "N")
                    {
                        if (_pitem.ParentImage != "")
                        {
                            if (childitem.Count > 0)
                            {
                                objstr.Append("<li  style=\"font-family: Calibri;\"><a href='" + _pitem.Url + "' target='_blank' onclick=\" InsertRecent('" + _pitem.Id + "','" + _pitem.Url + "')\"><img src='" + _pitem.ParentImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _pitem.MenuName + "</span><i class=\"fa fa-angle-left pull-right\"></i></a>");
                            }
                            else
                            {
                                objstr.Append("<li  style=\"font-family: Calibri;\"><a href='" + _pitem.Url + "' target='_blank' onclick=\" InsertRecent('" + _pitem.Id + "','" + _pitem.Url + "')\"><img src='" + _pitem.ParentImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _pitem.MenuName + "</span></a>");
                            }
                        }
                        else
                        {
                            if (childitem.Count > 0)
                            {
                                objstr.Append("<li  style=\"font-family: Calibri;\"><a href='" + _pitem.Url + "' target='_blank' onclick=\" InsertRecent('" + _pitem.Id + "','" + _pitem.Url + "')\"> " + _pitem.MenuName + "<i class=\"fa fa-angle-left pull-right\"></i></a>");
                            }
                            else
                            {
                                objstr.Append("<li  style=\"font-family: Calibri;\"><a href='" + _pitem.Url + "' target='_blank' onclick=\" InsertRecent('" + _pitem.Id + "','" + _pitem.Url + "')\"> " + _pitem.MenuName + "</a>");
                            }

                        }
                    }


                    if (childitem.Count > 0)
                    {
                        objstr.Append("<ul   class=\"sidebar-submenu\">");
                        /*Level 2*/
                        foreach (var _citem in childitem)
                        {
                            if (_citem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                            {
                            }
                            //EVM-0012
                            else if (_citem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Job_role) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                            {

                            }
                            else if (_citem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Master) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                            {

                            }
                            else
                            {
                                var childchilditem = objccmenu.Where(mc => mc.PairantChildId == _citem.Id).ToList();

                                if (_citem.ChildTarget == "S")
                                {
                                    if (childchilditem.Count > 0)
                                    {
                                        if (_citem.ChildImage != "")
                                        {
                                            objstr.Append("<li  style=\"font-family: Calibri;\"><a href='" + _citem.ChildUrl + "' title='" + _citem.ChildName + "' onclick=\" InsertRecent('" + _citem.Id + "','" + _citem.ChildUrl + "')\"><img src='" + _citem.ChildImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _citem.ChildName + "</span><i class=\"fa fa-angle-left pull-right\"></i></a>");
                                        }
                                        else
                                        {
                                            objstr.Append("<li  style=\"font-family: Calibri;\"><a href='" + _citem.ChildUrl + "' title='" + _citem.ChildName + "' onclick=\" InsertRecent('" + _citem.Id + "','" + _citem.ChildUrl + "')\">" + _citem.ChildName + "<i class=\"fa fa-angle-left pull-right\"></i></a>");
                                        }
                                    }
                                    else
                                    {
                                        if (_citem.ChildImage != "")
                                        {
                                            objstr.Append("<li  style=\"font-family: Calibri;\"><a href='" + _citem.ChildUrl + "' title='" + _citem.ChildName + "' onclick=\" InsertRecent('" + _citem.Id + "','" + _citem.ChildUrl + "')\"><img src='" + _citem.ChildImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _citem.ChildName + "</span></i></a>");
                                        }
                                        else
                                        {
                                            objstr.Append("<li  style=\"font-family: Calibri;\"><a href='" + _citem.ChildUrl + "' title='" + _citem.ChildName + "' onclick=\" InsertRecent('" + _citem.Id + "','" + _citem.ChildUrl + "')\">" + _citem.ChildName + "</a>");
                                        }
                                    }
                                }
                                else
                                {
                                    if (childchilditem.Count > 0)
                                    {
                                        if (_citem.ChildImage != "")
                                        {
                                            objstr.Append("<li  style=\"font-family: Calibri;\"><a href='" + _citem.ChildUrl + "' target='_blank' title='" + _citem.ChildName + "' onclick=\" InsertRecent('" + _citem.Id + "','" + _citem.ChildUrl + "')\" ><img src='" + _citem.ChildImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _citem.ChildName + "<span><i class=\"fa fa-angle-left pull-right\"></i></a>");
                                        }
                                        else
                                        {
                                            objstr.Append("<li  style=\"font-family: Calibri;\"><a href='" + _citem.ChildUrl + "' target='_blank' title='" + _citem.ChildName + "' onclick=\" InsertRecent('" + _citem.Id + "','" + _citem.ChildUrl + "')\">" + _citem.ChildName + "<i class=\"fa fa-angle-left pull-right\"></i></a>");

                                        }
                                    }
                                    else
                                    {
                                        if (_citem.ChildImage != "")
                                        {
                                            objstr.Append("<li  style=\"font-family: Calibri;\"><a href='" + _citem.ChildUrl + "' target='_blank' title='" + _citem.ChildName + "' onclick=\" InsertRecent('" + _citem.Id + "','" + _citem.ChildUrl + "')\"><img src='" + _citem.ChildImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _citem.ChildName + "<span></a>");
                                        }
                                        else
                                        {
                                            objstr.Append("<li  style=\"font-family: Calibri;\"><a href='" + _citem.ChildUrl + "' target='_blank' title='" + _citem.ChildName + "' onclick=\" InsertRecent('" + _citem.Id + "','" + _citem.ChildUrl + "')\" >" + _citem.ChildName + "</a>");

                                        }
                                    }
                                }


                                if (childchilditem.Count > 0)
                                {
                                    objstr.Append("<ul class=\"sidebar-submenu\">");

                                    /*Level 3*/
                                    foreach (MenuChildChild _ccitem in childchilditem)
                                    {
                                        if (_ccitem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                                        {
                                        }
                                        else
                                        {
                                            if (_ccitem.ChildChildTarget == "S")
                                            {
                                                if (_ccitem.ChildChildImage != "")
                                                {
                                                    objstr.Append("<li  style=\"font-family: Calibri;\"><a href='" + _ccitem.ChildChildUrl + "' title='" + _ccitem.ChildChildName + "' onclick=\" InsertRecent('" + _ccitem.Id + "','" + _ccitem.ChildChildUrl + "')\"><img src='" + _ccitem.ChildChildImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _ccitem.ChildChildName + "</span></a></li>");
                                                }
                                                else
                                                {
                                                    objstr.Append("<li  style=\"font-family: Calibri;\"><a href='" + _ccitem.ChildChildUrl + "' title='" + _ccitem.ChildChildName + "' onclick=\" InsertRecent('" + _ccitem.Id + "','" + _ccitem.ChildChildUrl + "')\">" + _ccitem.ChildChildName + "</a></li>");

                                                }
                                            }
                                            else
                                            {
                                                if (_ccitem.ChildChildImage != "")
                                                {
                                                    objstr.Append("<li  style=\"font-family: Calibri;\"><a href='" + _ccitem.ChildChildUrl + "' target='_blank'  title='" + _ccitem.ChildChildName + "' onclick=\" InsertRecent('" + _ccitem.Id + "','" + _ccitem.ChildChildUrl + "')\"><img src='" + _ccitem.ChildChildImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _ccitem.ChildChildName + "</span></a></li>");
                                                }
                                                else
                                                {
                                                    objstr.Append("<li  style=\"font-family: Calibri;\"><a href='" + _ccitem.ChildChildUrl + "' target='_blank'  title='" + _ccitem.ChildChildName + "' onclick=\" InsertRecent('" + _ccitem.Id + "','" + _ccitem.ChildChildUrl + "')\" >" + _ccitem.ChildChildName + "</a></li>");

                                                }
                                            }


                                        }
                                    }
                                    objstr.Append("</ul >");
                                }


                                objstr.Append("</li >");



                            }

                        }
                        objstr.Append("</ul>");
                    }
                    objstr.Append("</li>");
                }
            }
            objstr.Append("</ul>");
            objstr.ToString();
            return objstr;
        }

        public StringBuilder GetMenuDataForRecentMenu(clsEntityLayerLogin objEntity, int intUserId, string strRecentCount)
        {
            int intUserLimited = Convert.ToInt32(USERLIMITED.ISLIMITED);

            clsBusinessLayerDesignation objBusinessLayerDsgnMaster = new clsBusinessLayerDesignation();
            clsEntityLayerDesignation objEntityDsgn = new clsEntityLayerDesignation();

            clsBusinessLayerRecentMenu objRecentMenu = new clsBusinessLayerRecentMenu();
            clsEntityLayerRecentMenu objEntityRecentmenu = new clsEntityLayerRecentMenu();

            objEntityRecentmenu.CorpId = objEntity.CorpOfficeId;
            objEntityRecentmenu.OrgId = objEntity.OrgId;
            objEntityRecentmenu.UserId = intUserId;
            objEntityRecentmenu.AppId = objEntity.Cmp_AppId;

            DataTable dtRecentmenu = objRecentMenu.ReadRecentMenu(objEntityRecentmenu);
            Array[] arrMenuID = new Array[dtRecentmenu.Rows.Count];

            objEntityDsgn.DesignationUserId = intUserId;

            DataTable dtUserLimitedDetails = objBusinessLayerDsgnMaster.ReadIfUserLimitedByUsrId(objEntityDsgn);
            if (dtUserLimitedDetails.Rows.Count > 0)
            {
                intUserLimited = Convert.ToInt32(dtUserLimitedDetails.Rows[0]["USR_LMTD"].ToString());
            }

            StringBuilder objstr = new StringBuilder();
            List<MenuParant> objpmenu = new List<MenuParant>();
            List<MenuChild> objcmenu = new List<MenuChild>();
            List<MenuChildChild> objccmenu = new List<MenuChildChild>();

            objpmenu = GetParantMenu(objEntity);
            objcmenu = GetChildMenu(objEntity);
            objccmenu = GetChildChildMenu(objEntity);

            if (dtRecentmenu.Rows.Count > 0)
            {
                objstr.Append("<ul class=\"sidebar-menu\" ><li  style=\"font-family: Calibri;background-color: #0370ab;\"><a> <img src=\"/images/menu/pn.png\" style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">Recently Used</span><i class=\"fa fa-angle-left pull-right\"></i></a>");
                objstr.Append("<ul class=\"sidebar-submenu\" >");

                for (int i = 0; (i < Convert.ToInt32(strRecentCount)) && (i < dtRecentmenu.Rows.Count); i++)
                {
                    foreach (MenuParant _pitem in objpmenu)
                    {
                        if (dtRecentmenu.Rows[i]["MENU_ID"].ToString() == _pitem.Id.ToString())
                        {
                            objstr.Append("<li  style=\"font-family: Calibri;background-color: #0370ab;\"><a href='" + _pitem.Url + "' title='" + _pitem.MenuName + "'  onclick=\" InsertRecent('" + _pitem.Id + "','" + _pitem.Url + "')\"><img src='" + _pitem.ParentImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _pitem.MenuName + "</span></a></li>");
                        }
                    }
                }

                for (int i = 0; (i < Convert.ToInt32(strRecentCount)) && (i < dtRecentmenu.Rows.Count); i++)
                {
                    foreach (MenuChild _citem in objcmenu)
                    {
                        if (dtRecentmenu.Rows[i]["MENU_ID"].ToString() == _citem.Id.ToString())
                        {
                            objstr.Append("<li  style=\"font-family: Calibri;background-color: #0370ab;\"><a href='" + _citem.ChildUrl + "' title='" + _citem.ChildName + "' onclick=\" InsertRecent('" + _citem.Id + "','" + _citem.ChildUrl + "')\"><img src='" + _citem.ChildImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _citem.ChildName + "</span></a></li>");
                        }
                    }
                }


                for (int i = 0; (i < Convert.ToInt32(strRecentCount)) && (i < dtRecentmenu.Rows.Count); i++)
                {
                    foreach (MenuChildChild _ccitem in objccmenu)
                    {
                        if (dtRecentmenu.Rows[i]["MENU_ID"].ToString() == _ccitem.Id.ToString())
                        {
                            objstr.Append("<li  style=\"font-family: Calibri;background-color: #0370ab;\"><a href='" + _ccitem.ChildChildUrl + "' title='" + _ccitem.ChildChildName + "' onclick=\" InsertRecent('" + _ccitem.Id + "','" + _ccitem.ChildChildUrl + "')\"><img src='" + _ccitem.ChildChildImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _ccitem.ChildChildName + "</span></a></li>");
                        }
                    }
                }
                objstr.Append("</ul>");
                objstr.Append("</li>");
                objstr.Append("</ul>");
            }

            objstr.ToString();
            return objstr;

        }
        public StringBuilder GetMenuDataForFrequentlyMenu(clsEntityLayerLogin objEntity, int intUserId, string strFrequentCount)
        {
            int intUserLimited = Convert.ToInt32(USERLIMITED.ISLIMITED);

            clsBusinessLayerDesignation objBusinessLayerDsgnMaster = new clsBusinessLayerDesignation();
            clsEntityLayerDesignation objEntityDsgn = new clsEntityLayerDesignation();

            clsBusinessLayerRecentMenu objRecentMenu = new clsBusinessLayerRecentMenu();
            clsEntityLayerRecentMenu objEntityRecentmenu = new clsEntityLayerRecentMenu();

            objEntityRecentmenu.CorpId = objEntity.CorpOfficeId;
            objEntityRecentmenu.OrgId = objEntity.OrgId;
            objEntityRecentmenu.UserId = intUserId;
            objEntityRecentmenu.AppId = objEntity.Cmp_AppId;

            DataTable dtRecentmenu = objRecentMenu.ReadFrquentMenu(objEntityRecentmenu);
            Array[] arrMenuID = new Array[dtRecentmenu.Rows.Count];

            objEntityDsgn.DesignationUserId = intUserId;

            DataTable dtUserLimitedDetails = objBusinessLayerDsgnMaster.ReadIfUserLimitedByUsrId(objEntityDsgn);
            if (dtUserLimitedDetails.Rows.Count > 0)
            {
                intUserLimited = Convert.ToInt32(dtUserLimitedDetails.Rows[0]["USR_LMTD"].ToString());
            }

            StringBuilder objstr = new StringBuilder();
            List<MenuParant> objpmenu = new List<MenuParant>();
            List<MenuChild> objcmenu = new List<MenuChild>();
            List<MenuChildChild> objccmenu = new List<MenuChildChild>();

            objpmenu = GetParantMenu(objEntity);
            objcmenu = GetChildMenu(objEntity);
            objccmenu = GetChildChildMenu(objEntity);

            if (dtRecentmenu.Rows.Count > 0)
            {
                objstr.Append("<ul class=\"sidebar-menu\" ><li  style=\"font-family: Calibri;background-color: #18717d;\"><a> <img src=\"/images/menu/pn.png\" style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">Frequently Used</span><i class=\"fa fa-angle-left pull-right\"></i></a>");
                objstr.Append("<ul class=\"sidebar-submenu\" >");
                foreach (MenuParant _pitem in objpmenu)
                {
                    if (_pitem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                    {
                    }
                    else
                    {
                        var childitem = objcmenu.Where(m => m.PairantId == _pitem.Id).ToList();
                        for (int i = 0; (i < Convert.ToInt32(strFrequentCount)) && (i < dtRecentmenu.Rows.Count); i++)
                        {


                            if (dtRecentmenu.Rows[i]["MENU_ID"].ToString() == _pitem.Id.ToString())
                            {
                                if (_pitem.ParentTarget == "S")
                                {
                                    if (_pitem.ParentImage != "")
                                    {
                                        if (childitem.Count > 0)
                                        {
                                            objstr.Append("<li style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _pitem.Url + "'> <img src='" + _pitem.ParentImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _pitem.MenuName + "</span><i class=\"fa fa-angle-left pull-right\"></i></a>");
                                        }
                                        else
                                        {
                                            objstr.Append("<li  style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _pitem.Url + "'> <img src='" + _pitem.ParentImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _pitem.MenuName + "</span></a>");
                                        }
                                    }
                                    else
                                    {
                                        if (childitem.Count > 0)
                                        {
                                            objstr.Append("<li  style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _pitem.Url + "'> " + _pitem.MenuName + "<i class=\"fa fa-angle-left pull-right\"></i></a>");
                                        }
                                        else
                                        {
                                            objstr.Append("<li  style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _pitem.Url + "'> " + _pitem.MenuName + "</a>");
                                        }

                                    }
                                }
                                else if (_pitem.ParentTarget == "N")
                                {
                                    if (_pitem.ParentImage != "")
                                    {
                                        if (childitem.Count > 0)
                                        {
                                            objstr.Append("<li  style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _pitem.Url + "' target='_blank'><img src='" + _pitem.ParentImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _pitem.MenuName + "</span><i class=\"fa fa-angle-left pull-right\"></i></a>");
                                        }
                                        else
                                        {
                                            objstr.Append("<li  style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _pitem.Url + "' target='_blank'><img src='" + _pitem.ParentImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _pitem.MenuName + "</span></a>");
                                        }
                                    }
                                    else
                                    {
                                        if (childitem.Count > 0)
                                        {
                                            objstr.Append("<li  style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _pitem.Url + "' target='_blank'> " + _pitem.MenuName + "<i class=\"fa fa-angle-left pull-right\"></i></a>");
                                        }
                                        else
                                        {
                                            objstr.Append("<li  style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _pitem.Url + "' target='_blank'> " + _pitem.MenuName + "</a>");
                                        }

                                    }
                                }
                            }
                        }

                        if (childitem.Count > 0)
                        {
                            //objstr.Append("<ul   class=\"sidebar-submenu\">");
                            /*Level 2*/
                            foreach (var _citem in childitem)
                            {
                                if (_citem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                                {
                                }
                                //EVM-0012
                                else if (_citem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Job_role) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                                {

                                }
                                else if (_citem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Master) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                                {

                                }
                                else
                                {

                                    var childchilditem = objccmenu.Where(mc => mc.PairantChildId == _citem.Id).ToList();


                                    for (int i = 0; (i < Convert.ToInt32(strFrequentCount)) && (i < dtRecentmenu.Rows.Count); i++)
                                    {
                                        if (dtRecentmenu.Rows[i]["MENU_ID"].ToString() == _citem.Id.ToString())
                                        {
                                            if (_citem.ChildTarget == "S")
                                            {
                                                if (childchilditem.Count > 0)
                                                {
                                                    if (_citem.ChildImage != "")
                                                    {
                                                        objstr.Append("<li  style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _citem.ChildUrl + "' title='" + _citem.ChildName + "'><img src='" + _citem.ChildImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _citem.ChildName + "</span><i class=\"fa fa-angle-left pull-right\"></i></a>");
                                                    }
                                                    else
                                                    {
                                                        objstr.Append("<li  style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _citem.ChildUrl + "' title='" + _citem.ChildName + "'>" + _citem.ChildName + "<i class=\"fa fa-angle-left pull-right\"></i></a>");
                                                    }
                                                }
                                                else
                                                {
                                                    if (_citem.ChildImage != "")
                                                    {
                                                        objstr.Append("<li  style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _citem.ChildUrl + "' title='" + _citem.ChildName + "'><img src='" + _citem.ChildImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _citem.ChildName + "</span></i></a>");
                                                    }
                                                    else
                                                    {
                                                        objstr.Append("<li  style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _citem.ChildUrl + "' title='" + _citem.ChildName + "'>" + _citem.ChildName + "</a>");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (childchilditem.Count > 0)
                                                {
                                                    if (_citem.ChildImage != "")
                                                    {
                                                        objstr.Append("<li  style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _citem.ChildUrl + "' target='_blank' title='" + _citem.ChildName + "' ><img src='" + _citem.ChildImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _citem.ChildName + "<span><i class=\"fa fa-angle-left pull-right\"></i></a>");
                                                    }
                                                    else
                                                    {
                                                        objstr.Append("<li  style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _citem.ChildUrl + "' target='_blank' title='" + _citem.ChildName + "' >" + _citem.ChildName + "<i class=\"fa fa-angle-left pull-right\"></i></a>");

                                                    }
                                                }
                                                else
                                                {
                                                    if (_citem.ChildImage != "")
                                                    {
                                                        objstr.Append("<li  style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _citem.ChildUrl + "' target='_blank' title='" + _citem.ChildName + "' ><img src='" + _citem.ChildImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _citem.ChildName + "<span></a>");
                                                    }
                                                    else
                                                    {
                                                        objstr.Append("<li  style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _citem.ChildUrl + "' target='_blank' title='" + _citem.ChildName + "' >" + _citem.ChildName + "</a>");

                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (childchilditem.Count > 0)
                                    {
                                        //objstr.Append("<ul class=\"sidebar-submenu\">");

                                        /*Level 3*/
                                        foreach (MenuChildChild _ccitem in childchilditem)
                                        {
                                            if (_ccitem.Id == Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.DesignationMaster) && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED))
                                            {
                                            }
                                            else
                                            {
                                                for (int i = 0; (i < Convert.ToInt32(strFrequentCount)) && (i < dtRecentmenu.Rows.Count); i++)
                                                {
                                                    if (dtRecentmenu.Rows[i]["MENU_ID"].ToString() == _ccitem.Id.ToString())
                                                    {
                                                        if (_ccitem.ChildChildTarget == "S")
                                                        {
                                                            if (_ccitem.ChildChildImage != "")
                                                            {
                                                                objstr.Append("<li  style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _ccitem.ChildChildUrl + "' title='" + _ccitem.ChildChildName + "'><img src='" + _ccitem.ChildChildImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _ccitem.ChildChildName + "</span></a></li>");
                                                            }
                                                            else
                                                            {
                                                                objstr.Append("<li  style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _ccitem.ChildChildUrl + "' title='" + _ccitem.ChildChildName + "'>" + _ccitem.ChildChildName + "</a></li>");

                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (_ccitem.ChildChildImage != "")
                                                            {
                                                                objstr.Append("<li  style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _ccitem.ChildChildUrl + "' target='_blank'  title='" + _ccitem.ChildChildName + "' ><img src='" + _ccitem.ChildChildImage + "' style=\"vertical-align: middle;\" /><span style=\"margin-left: 5%;\">" + _ccitem.ChildChildName + "</span></a></li>");
                                                            }
                                                            else
                                                            {
                                                                objstr.Append("<li  style=\"font-family: Calibri;background-color: #18717d;\"><a href='" + _ccitem.ChildChildUrl + "' target='_blank'  title='" + _ccitem.ChildChildName + "' >" + _ccitem.ChildChildName + "</a></li>");

                                                            }
                                                        }


                                                    }
                                                }
                                            }
                                        }
                                        //objstr.Append("</ul >");
                                    }


                                    objstr.Append("</li >");



                                }

                            }
                            //objstr.Append("</ul>");
                        }
                        //objstr.Append("</li>");
                    }


                }
                objstr.Append("</ul>");
                objstr.Append("</li>");
                objstr.Append("</ul>");
            }

            objstr.ToString();
            return objstr;
        }
        
        //----------old-----------
        public StringBuilder GetMenuData(clsEntityLayerLogin objEntity)
        {
            StringBuilder objstr = new StringBuilder();
            List<MenuParant> objpmenu = new List<MenuParant>();
            List<MenuChild> objcmenu = new List<MenuChild>();
            List<MenuChildChild> objccmenu = new List<MenuChildChild>();
            objpmenu = GetParantMenu(objEntity);
            objcmenu = GetChildMenu(objEntity);
            objccmenu = GetChildChildMenu(objEntity);
            objstr.Append("<ul id=\"nav\">");
            foreach (MenuParant _pitem in objpmenu)
            {
                if (_pitem.ParentTarget == "S")
                {

                    objstr.Append("<li><a href='" + _pitem.Url + "'> <img src='" + _pitem.ParentImage + "'alt='" + _pitem.MenuName + "'height='18' width='99%'/></a>");
                }
                else if (_pitem.ParentTarget == "N")
                {

                    objstr.Append("<li><a href='" + _pitem.Url + "' target='_blank'><img src='" + _pitem.ParentImage + "'alt='" + _pitem.MenuName + "'height='18' width='99%'/></a>");
                }

                var childitem = objcmenu.Where(m => m.PairantId == _pitem.Id).ToList();
                if (childitem.Count > 0)
                {
                    objstr.Append("<ul >");
                    /*Level 2*/
                    foreach (var _citem in childitem)
                    {
                        if (_citem.ChildTarget == "S")
                        {
                            objstr.Append("<li><a href='" + _citem.ChildUrl + "'><img src='" + _citem.ChildImage + "'alt='" + _citem.ChildName + "'height='18' width='99%'/></a>");
                        }
                        else
                        {
                            objstr.Append("<li><a href='" + _citem.ChildUrl + "' target='_blank' ><img src='" + _citem.ChildImage + "'alt='" + _citem.ChildName + "'height='18' width='99%'/></a>");
                        }
                        var childchilditem = objccmenu.Where(mc => mc.PairantChildId == _citem.Id).ToList();

                        if (childchilditem.Count > 0)
                        {
                            objstr.Append("<ul>");

                            /*Level 3*/
                            foreach (MenuChildChild _ccitem in childchilditem)
                            {
                                if (_ccitem.ChildChildTarget == "S")
                                {
                                    objstr.Append("<li><a href='" + _ccitem.ChildChildUrl + "'><img src='" + _ccitem.ChildChildImage + "'alt='" + _ccitem.ChildChildName + "'height='18' width='99%'/></a></li>");
                                }
                                else
                                {
                                    objstr.Append("<li><a href='" + _ccitem.ChildChildUrl + "' target='_blank' ><img src='" + _ccitem.ChildChildImage + "'alt='" + _ccitem.ChildChildName + "'height='18' width='99%'/></a></li>");
                                }



                            }
                            objstr.Append("</ul >");
                        }


                        objstr.Append("</li >");





                    }
                    objstr.Append("</ul>");
                }
                objstr.Append("</li>");
            }
            objstr.Append("</ul>");
            objstr.ToString();
            return objstr;
        }

        // Get Data from parant table

        public List<MenuParant> GetParantMenu(clsEntityLayerLogin objEntity)
        {

            List<MenuParant> objmenu = new List<MenuParant>();

            DataTable dtMenu = new DataTable();
            clsMenu objBussiness = new clsMenu();
            dtMenu = objBussiness.LoadMenu(objEntity);


            if (dtMenu.Rows.Count > 0)
            {
                for (int i = 0; i < dtMenu.Rows.Count; i++)
                {
                    if (dtMenu.Rows[i]["USROL_LVL"].ToString() == "1")
                    {

                        if (objEntity.WorkStatnId == 0)
                        {//work station linked roles
                            if (dtMenu.Rows[i]["USROL_WK_LINKED"].ToString() == "1")
                            { }
                            else
                            {//generic roles
                                objmenu.Add(new MenuParant { Id = Convert.ToInt32(dtMenu.Rows[i]["USROL_ID"]), MenuName = dtMenu.Rows[i]["USROL_NAME"].ToString(), Url = dtMenu.Rows[i]["USROL_URL"].ToString(), ParentTarget = dtMenu.Rows[i]["USROL_TARGET"].ToString(), ParentImage = dtMenu.Rows[i]["USROL_IMAGE"].ToString() });
                            }
                        }
                        else
                        {
                            objmenu.Add(new MenuParant { Id = Convert.ToInt32(dtMenu.Rows[i]["USROL_ID"]), MenuName = dtMenu.Rows[i]["USROL_NAME"].ToString(), Url = dtMenu.Rows[i]["USROL_URL"].ToString(), ParentTarget = dtMenu.Rows[i]["USROL_TARGET"].ToString(), ParentImage = dtMenu.Rows[i]["USROL_IMAGE"].ToString() });
                        }
                    }
                }
            }
            return objmenu;
        }

        // Get data from child table

        public List<MenuChild> GetChildMenu(clsEntityLayerLogin objEntity)
        {
            List<MenuChild> objmenu = new List<MenuChild>();

            DataTable dtMenu = new DataTable();
            clsMenu objBussiness = new clsMenu();
            dtMenu = objBussiness.LoadMenu(objEntity);

            if (dtMenu.Rows.Count > 0)
            {
                for (int i = 0; i < dtMenu.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtMenu.Rows[i]["USROL_LVL"].ToString()) == 2)
                    {
                        if (objEntity.WorkStatnId == 0)
                        {//work station linked roles
                            if (dtMenu.Rows[i]["USROL_WK_LINKED"].ToString() == "1")
                            {
                            }
                            else
                            {//generic roles
                                objmenu.Add(new MenuChild { Id = Convert.ToInt32(dtMenu.Rows[i]["USROL_ID"]), PairantId = Convert.ToInt32(dtMenu.Rows[i]["USROL_PARENT_ID"]), ChildName = dtMenu.Rows[i]["USROL_NAME"].ToString(), ChildUrl = dtMenu.Rows[i]["USROL_URL"].ToString(), ChildTarget = dtMenu.Rows[i]["USROL_TARGET"].ToString(), ChildImage = dtMenu.Rows[i]["USROL_IMAGE"].ToString() });
                            }

                        }

                        else
                        {

                            objmenu.Add(new MenuChild { Id = Convert.ToInt32(dtMenu.Rows[i]["USROL_ID"]), PairantId = Convert.ToInt32(dtMenu.Rows[i]["USROL_PARENT_ID"]), ChildName = dtMenu.Rows[i]["USROL_NAME"].ToString(), ChildUrl = dtMenu.Rows[i]["USROL_URL"].ToString(), ChildTarget = dtMenu.Rows[i]["USROL_TARGET"].ToString(), ChildImage = dtMenu.Rows[i]["USROL_IMAGE"].ToString() });
                        }
                    }
                }
            }
            return objmenu;
        }


        // Get data from Child Child table

        public List<MenuChildChild> GetChildChildMenu(clsEntityLayerLogin objEntity)
        {
            List<MenuChildChild> objmenu = new List<MenuChildChild>();
            DataTable dtMenu = new DataTable();
            clsMenu objBussiness = new clsMenu();
            dtMenu = objBussiness.LoadMenu(objEntity);
            if (dtMenu.Rows.Count > 0)
            {
                for (int i = 0; i < dtMenu.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtMenu.Rows[i]["USROL_LVL"].ToString()) == 3)
                    {

                        if (objEntity.WorkStatnId == 0)
                        {//work station linked roles
                            if (dtMenu.Rows[i]["USROL_WK_LINKED"].ToString() == "1")
                            {
                            }
                            else
                            {//generic roles
                                objmenu.Add(new MenuChildChild { Id = Convert.ToInt32(dtMenu.Rows[i]["USROL_ID"]), PairantChildId = Convert.ToInt32(dtMenu.Rows[i]["USROL_PARENT_ID"]), ChildChildName = dtMenu.Rows[i]["USROL_NAME"].ToString(), ChildChildUrl = dtMenu.Rows[i]["USROL_URL"].ToString(), ChildChildTarget = dtMenu.Rows[i]["USROL_TARGET"].ToString(), ChildChildImage = dtMenu.Rows[i]["USROL_IMAGE"].ToString() });
                            }

                        }

                        else
                        {
                            objmenu.Add(new MenuChildChild { Id = Convert.ToInt32(dtMenu.Rows[i]["USROL_ID"]), PairantChildId = Convert.ToInt32(dtMenu.Rows[i]["USROL_PARENT_ID"]), ChildChildName = dtMenu.Rows[i]["USROL_NAME"].ToString(), ChildChildUrl = dtMenu.Rows[i]["USROL_URL"].ToString(), ChildChildTarget = dtMenu.Rows[i]["USROL_TARGET"].ToString(), ChildChildImage = dtMenu.Rows[i]["USROL_IMAGE"].ToString() });
                        }
                    }
                }
            }
            return objmenu;
        }

    }

    /*Menu Class*/
    public class MenuParant
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string Url { get; set; }
        public string ParentTarget { get; set; }
        public string ParentImage { get; set; }

    }
    public class MenuChild
    {
        public int Id { get; set; }
        public int PairantId { get; set; }
        public string ChildName { get; set; }
        public string ChildUrl { get; set; }
        public string ChildTarget { get; set; }
        public string ChildImage { get; set; }

    }
    public class MenuChildChild
    {
        public int Id { get; set; }
        public int PairantChildId { get; set; }
        public string ChildChildName { get; set; }
        public string ChildChildUrl { get; set; }
        public string ChildChildTarget { get; set; }
        public string ChildChildImage { get; set; }
    }
    public class clsMenu
    {

        // function for loading menu to the page
        public DataTable LoadMenu(clsEntityLayerLogin objMenu)
        {
            clsDataLayer objDataLayer = new clsDataLayer();
            DataTable dt_Menu = new DataTable();
            dt_Menu = objDataLayer.LoadmenuDB(objMenu);
            return dt_Menu;
        }



        // function for loading child menu to the page in case of desktop application
        public DataTable LoadChildMenu(clsEntityLayerLogin objMenu)
        {
            clsDataLayer objDataLayer = new clsDataLayer();
            DataTable dt_Menu = new DataTable();
            dt_Menu = objDataLayer.LoadChildMenuDB(objMenu);
            return dt_Menu;
        }

    }
}
