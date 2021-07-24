using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;

// CREATED BY:EVM-0006
// CREATED DATE:17/08/2016
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
   public class clsBusinessLayerLeadRate
    {
        //Creating object for datalayer
        clsDataLayerLeadRating objDatalayerLeadRating = new clsDataLayerLeadRating();

        //Method of passing data about lead rate for insertion from ui layer to datalayer.
        public void AddLeadRateMstr(clsEntityLeadRating objEntityLeadRateMstr)
        {
            objDatalayerLeadRating.AddLeadRateMstr(objEntityLeadRateMstr);
        }

        //Method of passing Lead Rate name count that have in the table.
        public string CheckLeadRateName(clsEntityLeadRating objEntityLeadRateMstr)
        {
            string strCount = objDatalayerLeadRating.CheckLeadRateName(objEntityLeadRateMstr);
            return strCount;
        }
        //Method of passing lead rate table from datalayer to ui layer with their id
        public DataTable ReadLeadrateById(clsEntityLeadRating objEntityLeadRateMstr)
        {
            DataTable ReadLeadrateById = objDatalayerLeadRating.ReadLeadrateById(objEntityLeadRateMstr);
            return ReadLeadrateById;
        }
        //Passing lead rating name for checking duplication at the time of updation
        public string Check_Lead_rate_NameUpdation(clsEntityLeadRating objEntityLeadRateMstr)
        {
            string strCount = objDatalayerLeadRating.CheckLeadRateNameUpdate(objEntityLeadRateMstr);
            return strCount;
        }
        //Method for passing data about lead rating modification for updation ui layer to data layer
        public void Update_LeadRate(clsEntityLeadRating objEntityLeadRateMstr)
        {
            objDatalayerLeadRating.Update_LeadRate(objEntityLeadRateMstr);
        }

        //Method for cancel the lead rate so passing data about lead rate that get cancel
        public void Cancel_LeadRate(clsEntityLeadRating objEntityLeadRateMstr)
        {
            objDatalayerLeadRating.Cancel_LeadRate(objEntityLeadRateMstr);
        }

        //Method for passing Premise master table from datalayer to uilayer for list view.
        public DataTable ReadLeadRateList(clsEntityLeadRating objEntityLeadRateMstr)
        {
            DataTable dtLeadrateList = objDatalayerLeadRating.ReadLeadRateList(objEntityLeadRateMstr);
            return dtLeadrateList;
        }
        public void Update_LeadRate_Sts(clsEntityLeadRating objEntityLeadRateMstr)
        {
            objDatalayerLeadRating.Update_LeadRate_Sts(objEntityLeadRateMstr);
        }
    }
}
