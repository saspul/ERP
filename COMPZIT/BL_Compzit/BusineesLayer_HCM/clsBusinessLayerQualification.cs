using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using DL_Compzit.DataLayer_HCM;

namespace BL_Compzit.BusineesLayer_HCM
{
    
    //Business Layer for Qualification:Work Experience
    public class ClsBusinessLayerStaffWorkExperience
    {
        clsDataLayerStaffWorkExperience objDataLayerWorkExperience = new clsDataLayerStaffWorkExperience();
        //For inserting work experience details
        public void insertWorkExp(clsEntityLayerStaffWorkExperience objEntityWorkExperience)
        {
            objDataLayerWorkExperience.insertWorkExp(objEntityWorkExperience);
        }
        //For list page
        public DataTable readWrkExpList(clsEntityLayerStaffWorkExperience objEntityWorkExperience)
        {
            DataTable dtReadCountry = objDataLayerWorkExperience.readWrkExpList(objEntityWorkExperience);
            return dtReadCountry;
        }
        //For view work experience details by id
        public DataTable ReadWrkExpDtlById(clsEntityLayerStaffWorkExperience objEntityWorkExperience)
        {
            DataTable dtReadCountry = objDataLayerWorkExperience.ReadWrkExpDtlById(objEntityWorkExperience);
            return dtReadCountry;
        }
        //For updating work experience details
        public void updateWorkExp(clsEntityLayerStaffWorkExperience objEntityWorkExperience)
        {
            objDataLayerWorkExperience.updateWorkExp(objEntityWorkExperience);
        }
        //For deleting work experience details
        public void DeleteWrkExpDtl(clsEntityLayerStaffWorkExperience objEntityWorkExperience)
        {
            objDataLayerWorkExperience.DeleteWrkExpDtl(objEntityWorkExperience);
        }
    }
    // //Business Layer for Qualification:Education
    public class clsBusinessLayerStaffEducation
    {
        clsDataLayerStaffEducation objDataEducation = new clsDataLayerStaffEducation();
        //For education level dropdown load
        public DataTable ReadEduLvl(clsEntityLayerStaffEducation objEntityEducation)
        {
            DataTable dtRead = objDataEducation.ReadEduLvl(objEntityEducation);
            return dtRead;
        }
        //For inserting education details
        public void insertEducation(clsEntityLayerStaffEducation objEntityEducation)
        {
            objDataEducation.insertEducation(objEntityEducation);
        }
        //For updating education details
        public void updateEducation(clsEntityLayerStaffEducation objEntityEducation)
        {
            objDataEducation.updateEducation(objEntityEducation);
        }
        //For education list page
        public DataTable readEduList(clsEntityLayerStaffEducation objEntityEducation)
        {
            DataTable dt = objDataEducation.readEduList(objEntityEducation);
            return dt;
        }
        //For read education detail by id
        public DataTable ReadEduDtlById(clsEntityLayerStaffEducation objEntityEducation)
        {
            DataTable dt = objDataEducation.ReadEduDtlById(objEntityEducation);
            return dt;
        }
        //For deleting education details by id
        public void deleteEduById(clsEntityLayerStaffEducation objEntityEducation)
        {
            objDataEducation.deleteEduById(objEntityEducation);
        }
    }
    //Business Layer for Qualification:Language
    public class clsBusinessLayerStaffLanguage
    {
        clsDataLayerStaffLanguage objDataLanguage = new clsDataLayerStaffLanguage();
        //For language dropdown load
        public DataTable ReadLanguage()
        {
            DataTable dtRead = objDataLanguage.ReadLanguage();
            return dtRead;
        }
        //For inserting language details
        public void insertLanguageDtl(clsEntityLayerStaffLanguage objEntityLanguage)
        {
            objDataLanguage.insertLanguageDtl(objEntityLanguage);
        }
        //For updating language details
        public void updateLanguageDtl(clsEntityLayerStaffLanguage objEntityLanguage)
        {
            objDataLanguage.updateLanguageDtl(objEntityLanguage);
        }
        //For language list
        public DataTable readLangList(clsEntityLayerStaffLanguage objEntityLanguage)
        {
            DataTable dtRead = objDataLanguage.readLangList(objEntityLanguage);
            return dtRead;
        }
        //For read language details by id
        public DataTable ReadLangDtlById(clsEntityLayerStaffLanguage objEntityLanguage)
        {
            DataTable dtRead = objDataLanguage.ReadLangDtlById(objEntityLanguage);
            return dtRead;
        }
        //For deleting language details
        public void deleteLanguageDtl(clsEntityLayerStaffLanguage objEntityLanguage)
        {
            objDataLanguage.deleteLanguageDtl(objEntityLanguage);
        }
    }
}
