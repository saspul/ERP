using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;
using CL_Compzit;

namespace BL_Compzit
{
   //Business Layer for Qualification:Work Experience
   public class ClsBusinessLayerWorkExperience
   {
       ClsDataLayerWorkExperience objDataLayerWorkExperience = new ClsDataLayerWorkExperience();
       //For inserting work experience details
       public void insertWorkExp(ClsEntityLayerWorkExperience objEntityWorkExperience)
       {
           objDataLayerWorkExperience.insertWorkExp(objEntityWorkExperience);
       }
       //For list page
       public DataTable readWrkExpList(ClsEntityLayerWorkExperience objEntityWorkExperience)
       {
           DataTable dtReadCountry = objDataLayerWorkExperience.readWrkExpList(objEntityWorkExperience);
           return dtReadCountry;
       }
       //For view work experience details by id
       public DataTable ReadWrkExpDtlById(ClsEntityLayerWorkExperience objEntityWorkExperience)
       {
           DataTable dtReadCountry = objDataLayerWorkExperience.ReadWrkExpDtlById(objEntityWorkExperience);
           return dtReadCountry;
       }
       //For updating work experience details
       public void updateWorkExp(ClsEntityLayerWorkExperience objEntityWorkExperience)
       {
           objDataLayerWorkExperience.updateWorkExp(objEntityWorkExperience);
       }
       //For deleting work experience details
       public void DeleteWrkExpDtl(ClsEntityLayerWorkExperience objEntityWorkExperience)
       {
           objDataLayerWorkExperience.DeleteWrkExpDtl(objEntityWorkExperience);
       }
    }
   //Business Layer for Qualification:Education
   public class ClsBusinessLayerEducation
   {
       ClsDataLayerEducation objDataEducation = new ClsDataLayerEducation();
       //For education level dropdown load
       public DataTable ReadEduLvl()
       {
           DataTable dtRead = objDataEducation.ReadEduLvl();
           return dtRead;
       }
       //For inserting education details
       public void insertEducation(ClsEntityLayerEducation objEntityEducation)
       {
           objDataEducation.insertEducation(objEntityEducation);
       }
       //For updating education details
       public void updateEducation(ClsEntityLayerEducation objEntityEducation)
       {
           objDataEducation.updateEducation(objEntityEducation);
       }
       //For education list page
       public DataTable readEduList(ClsEntityLayerEducation objEntityEducation)
       {
           DataTable dt = objDataEducation.readEduList(objEntityEducation);
           return dt;
       }
       //For read education detail by id
       public DataTable ReadEduDtlById(ClsEntityLayerEducation objEntityEducation)
       {
           DataTable dt = objDataEducation.ReadEduDtlById(objEntityEducation);
           return dt;
       }
       //For deleting education details by id
       public void deleteEduById(ClsEntityLayerEducation objEntityEducation)
       {
           objDataEducation.deleteEduById(objEntityEducation);
       }
   }
   //Business Layer for Qualification:Skills & Certifications
   public class ClsBusinessLayerSkillCertfn
   {
       ClsDataLayerSkillCertfcn objDataSkillCertfcn = new ClsDataLayerSkillCertfcn();
       //For skill dropdown load
       public DataTable ReadSkillDropdown()
       {
           DataTable dtRead = objDataSkillCertfcn.ReadSkillDropdown();
           return dtRead;
       }
       //For inserting skill & certification details
       public void insertSkillCertfcn(ClsEntityLayerSkillCertifcn objEntitySkillCertfcn)
       {
           objDataSkillCertfcn.insertSkillCertfcn(objEntitySkillCertfcn);
       }
       //For updating skill & certification details
       public void updateSkillCertfcn(ClsEntityLayerSkillCertifcn objEntitySkillCertfcn)
       {
           objDataSkillCertfcn.updateSkillCertfcn(objEntitySkillCertfcn);
       }
       //For skill & certification list
       public DataTable readSklCerList(ClsEntityLayerSkillCertifcn objEntitySkillCertfcn)
       {
           DataTable dtRead = objDataSkillCertfcn.readSklCerList(objEntitySkillCertfcn);
           return dtRead;
       }
       //For view skill & certification details by id
       public DataTable ReadSklCerDtlById(ClsEntityLayerSkillCertifcn objEntitySkillCertfcn)
       {
           DataTable dtReadCountry = objDataSkillCertfcn.ReadSklCerDtlById(objEntitySkillCertfcn);
           return dtReadCountry;
       }
       //For deleting skill & certification details
       public void DeleSkillCertfcn(ClsEntityLayerSkillCertifcn objEntitySkillCertfcn)
       {
           objDataSkillCertfcn.DeleSkillCertfcn(objEntitySkillCertfcn);
       }
   }
   //Business Layer for Qualification:Language
   public class ClsBusinessLayerLanguage
   {
       ClsDataLayerLanguage objDataLanguage = new ClsDataLayerLanguage();
       //For language dropdown load
       public DataTable ReadLanguage()
       {
           DataTable dtRead = objDataLanguage.ReadLanguage();
           return dtRead;
       }
       //For inserting language details
       public void insertLanguageDtl(ClsEntityLayerLanguage objEntityLanguage)
       {
           objDataLanguage.insertLanguageDtl(objEntityLanguage);
       }
       //For updating language details
       public void updateLanguageDtl(ClsEntityLayerLanguage objEntityLanguage)
       {
           objDataLanguage.updateLanguageDtl(objEntityLanguage);
       }
       //For language list
       public DataTable readLangList(ClsEntityLayerLanguage objEntityLanguage)
       {
           DataTable dtRead = objDataLanguage.readLangList(objEntityLanguage);
           return dtRead;
       }
       //For read language details by id
       public DataTable ReadLangDtlById(ClsEntityLayerLanguage objEntityLanguage)
       {
           DataTable dtRead = objDataLanguage.ReadLangDtlById(objEntityLanguage);
           return dtRead;
       }
       //For deleting language details
       public void deleteLanguageDtl(ClsEntityLayerLanguage objEntityLanguage)
       {
           objDataLanguage.deleteLanguageDtl(objEntityLanguage);
       }
   }
}
