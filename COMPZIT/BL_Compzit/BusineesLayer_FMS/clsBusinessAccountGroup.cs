using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_FMS;
using EL_Compzit.EntityLayer_FMS;
using CL_Compzit;

namespace BL_Compzit.BusinessLayer_FMS
{
    public class clsBusinessAccountGroup
    {
        clsDataLayerAccountGroup ObjDataAccountGroup = new clsDataLayerAccountGroup();
        public void InsertAccountGroup(clsEntityAccountGroup objEntityAccountGroup)
        {
            ObjDataAccountGroup.InsertAccountGroup(objEntityAccountGroup);
        }
        public void UpadteAccountGroup(clsEntityAccountGroup objEntityAccountGroup)
        {
            ObjDataAccountGroup.UpdateAccountGroup(objEntityAccountGroup);
        }
        public DataTable ReadAccountGroupByID(clsEntityAccountGroup objEntityAccountGroup)
        {
            DataTable dtAccountdetails = ObjDataAccountGroup.ReadAccountGroupByID(objEntityAccountGroup);
            return dtAccountdetails;
        }
        public DataTable LoadAccountGroup(clsEntityAccountGroup objEntityAccountGroup)
        {
            DataTable dtAccountdetails = ObjDataAccountGroup.LoadAccountGroup(objEntityAccountGroup);
            return dtAccountdetails;
        }
        public void CancelAccountGroup(clsEntityAccountGroup objEntityAccountGroup)
        {
            ObjDataAccountGroup.CancelAccountGroup(objEntityAccountGroup);
        }
        public DataTable ReadAccountGroupList(clsEntityAccountGroup objEntityAccountGroup)
        {
            DataTable dtAccountdetails = ObjDataAccountGroup.ReadAccountGroupList(objEntityAccountGroup);
            return dtAccountdetails;
        }
        public void ChangeAccountStatus(clsEntityAccountGroup objEntityAccountGroup)
        {
            ObjDataAccountGroup.ChangeAccountStatus(objEntityAccountGroup);
        }
        public DataTable AccountGroupDplctnChk(clsEntityAccountGroup objEntityAccountGroup)
        {
            DataTable dtAccountdetails = ObjDataAccountGroup.AccountGroupDplctnChk(objEntityAccountGroup);
            return dtAccountdetails;
        }
        public DataTable AccountGroupDplctnUpdChk(clsEntityAccountGroup objEntityAccountGroup)
        {
            DataTable dtAccountdetails = ObjDataAccountGroup.AccountGroupDplctnUpdChk(objEntityAccountGroup);
            return dtAccountdetails;
        }
        public DataTable AccountGroupCancelChk(clsEntityAccountGroup objEntityAccountGroup)
        {
            DataTable dtAccountdetails = ObjDataAccountGroup.AccountGroupCancelChk(objEntityAccountGroup);
            return dtAccountdetails;
        }

        public string CheckCodeDuplicatn(clsEntityAccountGroup objEntityAccountGroup)
        {
            string count = ObjDataAccountGroup.CheckCodeDuplicatn(objEntityAccountGroup);
            return count;
        }
        //evm 0044
        public DataTable LoadAccountGroupBYId(clsEntityAccountGroup objEntityAccountGroup)
        {
            DataTable dtAccountdetails = ObjDataAccountGroup.LoadAccountGroupById(objEntityAccountGroup);
            return dtAccountdetails;
        }
        public void UpdateAccountGroupNextGroup(clsEntityAccountGroup objEntityAccountGroup)
        {
            ObjDataAccountGroup.UpdateAccountGroupNextGroup(objEntityAccountGroup);
        }
        //----------
      
    }
}
