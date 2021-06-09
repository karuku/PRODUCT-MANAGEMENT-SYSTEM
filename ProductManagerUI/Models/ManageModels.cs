using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using ProductManagerData.DTO;

namespace ProductManagerUI.Models
{
    public class ManageModels
    {
       
    }

    //public class CategoryModel
    //{ 
    //    public MasterProductCategoryDTO ProductCategory { get; set; }
    //}


    //public class TypeModel
    //{ 
    //    public MasterProductTypeDTO ProductType { get; set; }
    //}

    //public class ProductModel
    //{
    //    public Int32 productId { get; set; }
    //    public ProductDTO Product { get; set; }
    //    public ProductStandardAllocDTO ProductStandard { get; set; }
    //    public List<ProductCompositeLineDTO> ProductCompositeLines { get; set; }
    //    public List<ProductVariantAllocDTO> ProductVariants { get; set; }
    //}

    //public class ProductAttributeModel
    //{
    //    public Int32 attributeId { get; set; }
    //    public MasterProductVariantAttributeDTO ProductVariantAttribute { get; set; }
    //    public List<MasterProductVariantSubAttributeDTO> ProductVariantSubAttributes { get; set; }
    //}


    //public class ProductAttributesViewModel
    //{ 
    //    public List<ProductAttributeModel> ProductAttributes { get; set; }
    //}

    //public class OutputModel
    //{
    //    public static string Exception
    //    {
    //        get { return " Error, Kindly contact your administrator"; }
    //    }

    //    public static string Empty
    //    {
    //        get { return " Edit Failed, this cannot be empty"; }
    //    }
    //    public static string Error
    //    {
    //        get { return " Error, Something went wrong"; }
    //    }
    //    public static string Success
    //    {
    //        get { return " Edited Successfully"; }
    //    }

    //    public static string AddError
    //    {
    //        get { return " Add Failed, Kindly check your entries and try again"; }
    //    }
    //    public static string AddSuccess
    //    {
    //        get { return " Added Successfully"; }
    //    }

    //    public static string GetEmpty(string key)
    //    {
    //        return " Edit Failed, " + key + " cannot be empty";
    //    }

    //    public static string GetNotImplementedError(string key)
    //    {
    //        return " Failed, " + key + " has not been implemented yet";
    //    }

    //    public static string GetInvalid(string key)
    //    {
    //        return " Failed, " + key + " is Invalid";
    //    }

    //    public static string GetUploadError()
    //    {
    //        return " Failed to upload file, this file could be Corrupted or path doesnt exist";
    //    }

    //    public static string GetErrorMessage(string key)
    //    {
    //        return " Failed to =>" + key;
    //    }

    //    public static string GetExists(string key)
    //    {
    //        return " Failed, " + key + " already exists";
    //    }

    //    public static string GetEditExceptionError(string key, string message = "")
    //    {
    //        return " Error, Failed to Edit " + key + ", Kindly contact your administrator =>" + message;
    //    }

    //    public static string GetException(string key)
    //    {
    //        return "Administrator error:=>" + key;
    //    }

    //    public static string GetExceptionError(string key)
    //    {
    //        return " Error, Failed to Get " + key + ", Kindly contact your administrator";
    //    }

    //    public static string GetBulkSuccessResult(string key, int successCount, int totalCount)
    //    {
    //        return " Success, " + successCount + " " + key + "(s) out of " + totalCount + " edited successfully";
    //    }

    //    public static string GetBulkExistsResult(string key, int successCount, int totalCount)
    //    {
    //        return " Info, " + successCount + " " + key + "(s) out of " + totalCount + " edited successfully, the rest already exist";
    //    }

    //    public static string GetBulkTypeNotImplementedResult(string key)
    //    {
    //        return " Sorry the bulk type => " + key + " is not yet implemented";
    //    }

    //    public static string GetBulkErrorResult(string key, int errorCount, int totalCount)
    //    {
    //        return " Error, " + errorCount + " " + key + "(s) out of " + totalCount + " failed";
    //    }


    //    public static string GetExcelDataConvertErrorResult(string key)
    //    {
    //        return " Error, unable to convert " + key + "(s) from excel file, Please check the excel format and try again";
    //    }
    //    public static string GetAlreadySubscribedError(string key)
    //    {
    //        return " Error, " + key + " is Already Subscribed";
    //    }

    //    public static string GetAlreadyExistsInfo(string key)
    //    {
    //        return " Info, " + key + " already exists";
    //    }

    //    public static string GetResetSuccess(string key)
    //    {
    //        return " Success, " + key + " Reset Successfully";
    //    }

    //    public static string GetResetError(string key)
    //    {
    //        return " Error, " + key + " Reset Failed";
    //    }

    //    public static string GetActivateSuccess(string key)
    //    {
    //        return " Success, " + key + " Activated Successfully";
    //    }

    //    public static string GetDeActivateSuccess(string key)
    //    {
    //        return " Success, " + key + " DeActivated Successfully";
    //    }

    //    public static string GetActivateError(string key)
    //    {
    //        return " Error, " + key + " Activation Failed";
    //    }

    //    public static string GetAddSuccess(string key)
    //    {
    //        return " Success, " + key + " Added Successfully";
    //    }

    //    public static string GetAddTransactionSuccess(string key)
    //    {
    //        return " Success, " + key + " Transaction Successful";
    //    }

    //    public static string GetAddTransactionError(string key)
    //    {
    //        return " Error, " + key + " Transaction Failed";
    //    }

    //    public static string GetAddError(string key)
    //    {
    //        return " Error, " + key + " Add Failed";
    //    }

    //    public static string GetUpdateSuccess(string key)
    //    {
    //        return " Success, " + key + " Updated Successfully";
    //    }

    //    public static string GetUpdateError(string key)
    //    {
    //        return " Error, " + key + " Update Failed";
    //    }

    //    public static string GetDeleteSuccess(string key)
    //    {
    //        return " Success, " + key + " Deleted Successfully";
    //    }

    //    public static string GetDeleteError(string key)
    //    {
    //        return " Error, " + key + " Delete Failed";
    //    }

    //    public static string UpdateError
    //    {
    //        get { return " Update Failed, Kindly check your entries and try again"; }
    //    }
    //    public static string UpdateSuccess
    //    {
    //        get { return " Updated Successfully"; }
    //    }

    //    public static string DeleteError
    //    {
    //        get { return " Delete Failed, Kindly check your entries and try again"; }
    //    }
    //    public static string DeleteSuccess
    //    {
    //        get { return " Deleted Successfully"; }
    //    }

    //    public static string GetError
    //    {
    //        get { return " Find Failed, Kindly check your entries and try again"; }
    //    }
    //    public static string GetSuccess
    //    {
    //        get { return " Found Successfully"; }
    //    }
    //}
}