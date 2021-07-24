using DL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsDataStaffFamily
/// </summary>
public class clsDataStaffFamily
{

    public DataTable ReadRelationship(clsEntityLayerFamilyDetails objEntityDependent)
    {
        string strQueryReadRelationship = "STAFF_DEPENDENT_DETAILS.SP_READ_RELATIONSHIP";
        using (OracleCommand cmdReadRelationship = new OracleCommand())
        {
            cmdReadRelationship.CommandText = strQueryReadRelationship;
            cmdReadRelationship.CommandType = CommandType.StoredProcedure;
            cmdReadRelationship.Parameters.Add("DP_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCountry = new DataTable();
            dtCountry = clsDataLayer.SelectDataTable(cmdReadRelationship);
            return dtCountry;
        }
    }
    public void insertFamilyDtls(clsEntityLayerFamilyDetails objEntityDependent)
    {
        string strQueryAddPersnlDtls = "STAFF_FAMILY_DETAILS.SP_INS_FAMILY_DETAILS";
        using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
        {
            cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
            cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
            cmdAddPersnlDtls.Parameters.Add("D_CAND_ID", OracleDbType.Int32).Value = objEntityDependent.EmpUserId;
            cmdAddPersnlDtls.Parameters.Add("D_STAFF_FMLY_MRG_STS", OracleDbType.Int32).Value = objEntityDependent.Maritalstst;
            cmdAddPersnlDtls.Parameters.Add("D_STAFF_FMLY_SPOUSE_NAMEE", OracleDbType.Varchar2).Value = objEntityDependent.SpsName;
            cmdAddPersnlDtls.Parameters.Add("D_CORPRTID", OracleDbType.Int32).Value = objEntityDependent.Corporate_id;
            cmdAddPersnlDtls.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityDependent.Organisation_id;
            cmdAddPersnlDtls.Parameters.Add("D_INSUSRID", OracleDbType.Int32).Value = objEntityDependent.User_Id;
            cmdAddPersnlDtls.Parameters.Add("D_INSDATE", OracleDbType.Date).Value = objEntityDependent.Date;
            cmdAddPersnlDtls.Parameters.Add("D_GUARDTYP", OracleDbType.Int32).Value = objEntityDependent.GuardTyp;
            cmdAddPersnlDtls.Parameters.Add("D_GUARDNAME", OracleDbType.Varchar2).Value = objEntityDependent.GuardName;
            cmdAddPersnlDtls.Parameters.Add("D_GUARDOCCP", OracleDbType.Varchar2).Value = objEntityDependent.GuardOccp;

            clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
        }
    }

    public void insertDependentDtls(clsEntityLayerFamilyDetails objEntityDependent)
    {
        string strQueryAddPersnlDtls = "STAFF_DEPENDENT_DETAILS.SP_INS_DPNT_DETAILS";
        using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
        {
            cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
            cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
            cmdAddPersnlDtls.Parameters.Add("DP_CAND_ID", OracleDbType.Int32).Value = objEntityDependent.EmpUserId;
            cmdAddPersnlDtls.Parameters.Add("DP_RELTNID", OracleDbType.Int32).Value = objEntityDependent.RelatnshpId;
            cmdAddPersnlDtls.Parameters.Add("DP_STAFF_FMLY_NAME", OracleDbType.Varchar2).Value = objEntityDependent.DepntName;
            if (objEntityDependent.DateOfBirth ==DateTime.MinValue)
            {
                cmdAddPersnlDtls.Parameters.Add("DP_STAFF_FMLY_AGE", OracleDbType.Varchar2).Value = null;
            }
            else
            {
                cmdAddPersnlDtls.Parameters.Add("DP_STAFF_FMLY_AGE", OracleDbType.Date).Value = objEntityDependent.DateOfBirth;

            }
           
            cmdAddPersnlDtls.Parameters.Add("DP_STAFF_FMLY_OCCUPATION", OracleDbType.Varchar2).Value = objEntityDependent.Occupation;


            cmdAddPersnlDtls.Parameters.Add("DP_CORPRTID", OracleDbType.Int32).Value = objEntityDependent.Corporate_id;
            cmdAddPersnlDtls.Parameters.Add("DP_ORGID", OracleDbType.Int32).Value = objEntityDependent.Organisation_id;


            cmdAddPersnlDtls.Parameters.Add("DP_INSUSRID", OracleDbType.Int32).Value = objEntityDependent.User_Id;
            cmdAddPersnlDtls.Parameters.Add("DP_INSDATE", OracleDbType.Date).Value = objEntityDependent.Date;
            clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
        }
    }
    public void UpdateDependentDtls(clsEntityLayerFamilyDetails objEntityDependent)
    {
        string strQueryAddPersnlDtls = "STAFF_DEPENDENT_DETAILS.SP_UPD_DPNT_DETAILS";
        using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
        {
            cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
            cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
            cmdAddPersnlDtls.Parameters.Add("DP_STAFF_DPNT_ID", OracleDbType.Int32).Value = objEntityDependent.DepntId;
            cmdAddPersnlDtls.Parameters.Add("DP_RELTNID", OracleDbType.Int32).Value = objEntityDependent.RelatnshpId;
            cmdAddPersnlDtls.Parameters.Add("DP_STAFF_FMLY_NAME", OracleDbType.Varchar2).Value = objEntityDependent.DepntName;

            cmdAddPersnlDtls.Parameters.Add("DP_STAFF_FMLY_AGE", OracleDbType.Date).Value = objEntityDependent.DateOfBirth;

            cmdAddPersnlDtls.Parameters.Add("DP_STAFF_FMLY_OCCUPATION", OracleDbType.Varchar2).Value = objEntityDependent.Occupation;


            cmdAddPersnlDtls.Parameters.Add("DP_CORPRTID", OracleDbType.Int32).Value = objEntityDependent.Corporate_id;
            cmdAddPersnlDtls.Parameters.Add("DP_ORGID", OracleDbType.Int32).Value = objEntityDependent.Organisation_id;


            cmdAddPersnlDtls.Parameters.Add("DP_UPDUSRID", OracleDbType.Int32).Value = objEntityDependent.User_Id;
            cmdAddPersnlDtls.Parameters.Add("DP_UPDDATE", OracleDbType.Date).Value = objEntityDependent.Date;
            clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
        }
    }
    public DataTable readDependentList(clsEntityLayerFamilyDetails objEntityDependent)
    {
        string strQueryReadCountry = "STAFF_FAMILY_DETAILS.SP_READ_FAMILY_DEPNDLIST";
        using (OracleCommand cmdReadCountry = new OracleCommand())
        {
            cmdReadCountry.CommandText = strQueryReadCountry;
            cmdReadCountry.CommandType = CommandType.StoredProcedure;
            cmdReadCountry.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDependent.EmpUserId;

            cmdReadCountry.Parameters.Add("DP_CORPRTID", OracleDbType.Int32).Value = objEntityDependent.Corporate_id;
            cmdReadCountry.Parameters.Add("DP_ORGID", OracleDbType.Int32).Value = objEntityDependent.Organisation_id;
            cmdReadCountry.Parameters.Add("D_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            DataTable dtCountry = new DataTable();
            dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
            return dtCountry;
        }
    }
    public DataTable readFamilyList(clsEntityLayerFamilyDetails objEntityDependent)
    {
        string strQueryReadCountry = "STAFF_FAMILY_DETAILS.SP_READ_FAMILY_LIST";
        using (OracleCommand cmdReadCountry = new OracleCommand())
        {
            cmdReadCountry.CommandText = strQueryReadCountry;
            cmdReadCountry.CommandType = CommandType.StoredProcedure;
            cmdReadCountry.Parameters.Add("D_ID", OracleDbType.Int32).Value = objEntityDependent.EmpUserId;

            cmdReadCountry.Parameters.Add("DP_CORPRTID", OracleDbType.Int32).Value = objEntityDependent.Corporate_id;
            cmdReadCountry.Parameters.Add("DP_ORGID", OracleDbType.Int32).Value = objEntityDependent.Organisation_id;
            cmdReadCountry.Parameters.Add("D_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            DataTable dtCountry = new DataTable();
            dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
            return dtCountry;
        }
    }
    public DataTable ReadDepntById(clsEntityLayerFamilyDetails objEntityDependent)
    {
        string strQueryReadCountry = "STAFF_DEPENDENT_DETAILS.SP_READ_DEPNT_BYID";
        using (OracleCommand cmdReadCountry = new OracleCommand())
        {
            cmdReadCountry.CommandText = strQueryReadCountry;
            cmdReadCountry.CommandType = CommandType.StoredProcedure;
            cmdReadCountry.Parameters.Add("DP_DEPNTID", OracleDbType.Int32).Value = objEntityDependent.DepntId;
            cmdReadCountry.Parameters.Add("DP_CORPRTID", OracleDbType.Int32).Value = objEntityDependent.Corporate_id;
            cmdReadCountry.Parameters.Add("DP_ORGID", OracleDbType.Int32).Value = objEntityDependent.Organisation_id;

            cmdReadCountry.Parameters.Add("D_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCountry = new DataTable();
            dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
            return dtCountry;
        }
    }
    public void DeleteDepntById(clsEntityLayerFamilyDetails objEntityDependent)
    {
        string strQueryReadCountry = "STAFF_DEPENDENT_DETAILS.SP_DELE_DPNT_DETAILS";
        using (OracleCommand cmdReadCountry = new OracleCommand())
        {
            cmdReadCountry.CommandText = strQueryReadCountry;
            cmdReadCountry.CommandType = CommandType.StoredProcedure;
            cmdReadCountry.Parameters.Add("DP_DEPNTID", OracleDbType.Int32).Value = objEntityDependent.DepntId;
            clsDataLayer.ExecuteNonQuery(cmdReadCountry);

        }
    }

    public void UpdateFamilyDtls(clsEntityLayerFamilyDetails objEntityDependent)
    {
        string strQueryAddPersnlDtls = "STAFF_FAMILY_DETAILS.SP_UPD_FAMILY_DETAILS";
        using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
        {
            cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
            cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
            cmdAddPersnlDtls.Parameters.Add("D_CAND_ID", OracleDbType.Int32).Value = objEntityDependent.EmpUserId;
            cmdAddPersnlDtls.Parameters.Add("D_STAFF_FMLY_MRG_STS", OracleDbType.Int32).Value = objEntityDependent.Maritalstst;
            cmdAddPersnlDtls.Parameters.Add("D_STAFF_FMLY_SPOUSE_NAMEE", OracleDbType.Varchar2).Value = objEntityDependent.SpsName;

            cmdAddPersnlDtls.Parameters.Add("D_CORPRTID", OracleDbType.Int32).Value = objEntityDependent.Corporate_id;

            cmdAddPersnlDtls.Parameters.Add("D_ORGID", OracleDbType.Varchar2).Value = objEntityDependent.Organisation_id;


            cmdAddPersnlDtls.Parameters.Add("D_UPDUSRID", OracleDbType.Int32).Value = objEntityDependent.User_Id;
            cmdAddPersnlDtls.Parameters.Add("D_UPDDATE", OracleDbType.Date).Value = objEntityDependent.Date;


            cmdAddPersnlDtls.Parameters.Add("D_GUARDTYP", OracleDbType.Int32).Value = objEntityDependent.GuardTyp;
            cmdAddPersnlDtls.Parameters.Add("D_GUARDNAME", OracleDbType.Varchar2).Value = objEntityDependent.GuardName;
            cmdAddPersnlDtls.Parameters.Add("D_GUARDOCCP", OracleDbType.Varchar2).Value = objEntityDependent.GuardOccp;
            clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
        }
    }
}