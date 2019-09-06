using Microsoft.AspNetCore.Http;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Services.Media
{
    /// <summary>
    /// Picture service interface
    /// </summary>
    public partial interface IPictureService
    {
        /// <summary>
        /// Returns the file extension from mime type.
        /// 从mime类型返回文件扩展名。
        /// </summary>
        /// <param name="mimeType">Mime type</param>
        /// <returns>File extension</returns>
        string GetFileExtensionFromMimeType(string mimeType);

        /// <summary>
        /// Gets the loaded picture binary depending on picture storage settings
        /// 根据图片存储设置获取加载的图片二进制文件
        /// </summary>
        /// <param name="picture">Picture</param>
        /// <returns>Picture binary</returns>
        byte[] LoadPictureBinary(Picture picture);

        /// <summary>
        /// Get picture SEO friendly name
        /// 获得图片搜索引擎优化友好的名称
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Result</returns>
        string GetPictureSeName(string name);

        /// <summary>
        /// Gets the default picture URL
        /// 获取默认图片URL
        /// </summary>
        /// <param name="targetSize">The target picture size (longest side)</param>
        /// <param name="defaultPictureType">Default picture type</param>
        /// <param name="storeLocation">Store location URL; null to use determine the current store location automatically</param>
        /// <returns>Picture URL</returns>
        string GetDefaultPictureUrl(int targetSize = 0,
            PictureType defaultPictureType = PictureType.Entity,
            string storeLocation = null);

        /// <summary>
        /// Get a picture URL
        /// 获取图片URL
        /// </summary>
        /// <param name="pictureId">Picture identifier</param>
        /// <param name="targetSize">The target picture size (longest side)</param>
        /// <param name="showDefaultPicture">A value indicating whether the default picture is shown</param>
        /// <param name="storeLocation">Store location URL; null to use determine the current store location automatically</param>
        /// <param name="defaultPictureType">Default picture type</param>
        /// <returns>Picture URL</returns>
        string GetPictureUrl(int pictureId,
            int targetSize = 0,
            bool showDefaultPicture = true,
            string storeLocation = null,
            PictureType defaultPictureType = PictureType.Entity);

        /// <summary>
        /// Get a picture URL
        /// </summary>
        /// <param name="picture">Picture instance</param>
        /// <param name="targetSize">The target picture size (longest side)</param>
        /// <param name="showDefaultPicture">A value indicating whether the default picture is shown</param>
        /// <param name="storeLocation">Store location URL; null to use determine the current store location automatically</param>
        /// <param name="defaultPictureType">Default picture type</param>
        /// <returns>Picture URL</returns>
        string GetPictureUrl(Picture picture,
            int targetSize = 0,
            bool showDefaultPicture = true,
            string storeLocation = null,
            PictureType defaultPictureType = PictureType.Entity);

        /// <summary>
        /// Get a picture local path
        /// 获取本地路径的图片
        /// </summary>
        /// <param name="picture">Picture instance</param>
        /// <param name="targetSize">The target picture size (longest side)</param>
        /// <param name="showDefaultPicture">A value indicating whether the default picture is shown</param>
        /// <returns></returns>
        string GetThumbLocalPath(Picture picture, int targetSize = 0, bool showDefaultPicture = true);

        /// <summary>
        /// Gets a picture
        /// 得到一张照片
        /// </summary>
        /// <param name="pictureId">Picture identifier</param>
        /// <returns>Picture</returns>
        Picture GetPictureById(int pictureId);

        /// <summary>
        /// Deletes a picture
        /// 删除照片
        /// </summary>
        /// <param name="picture">Picture</param>
        void DeletePicture(Picture picture);

        /// <summary>
        /// Gets a collection of pictures
        /// 获取图片集合
        /// </summary>
        /// <param name="virtualPath">Virtual path</param>
        /// <param name="pageIndex">Current page</param>
        /// <param name="pageSize">Items on each page</param>
        /// <returns>Paged list of pictures</returns>
        IPagedList<Picture> GetPictures(string virtualPath = "", int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Gets pictures by product identifier
        /// 按产品标识符获取图片
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <param name="recordsToReturn">Number of records to return. 0 if you want to get all items</param>
        /// <returns>Pictures</returns>
        IList<Picture> GetPicturesByProductId(int productId, int recordsToReturn = 0);

        /// <summary>
        /// Inserts a picture
        /// 插入一个图片
        /// </summary>
        /// <param name="pictureBinary">The picture binary</param>
        /// <param name="mimeType">The picture MIME type</param>
        /// <param name="seoFilename">The SEO filename</param>
        /// <param name="altAttribute">"alt" attribute for "img" HTML element</param>
        /// <param name="titleAttribute">"title" attribute for "img" HTML element</param>
        /// <param name="isNew">A value indicating whether the picture is new</param>
        /// <param name="validateBinary">A value indicating whether to validated provided picture binary</param>
        /// <returns>Picture</returns>
        Picture InsertPicture(byte[] pictureBinary, string mimeType, string seoFilename,
            string altAttribute = null, string titleAttribute = null,
            bool isNew = true, bool validateBinary = true);

        /// <summary>
        /// Inserts a picture
        /// </summary>
        /// <param name="formFile">Form file</param>
        /// <param name="defaultFileName">File name which will be use if IFormFile.FileName not present</param>
        /// <param name="virtualPath">Virtual path</param>
        /// <returns>Picture</returns>
        Picture InsertPicture(IFormFile formFile, string defaultFileName = "", string virtualPath = "");

        /// <summary>
        /// Updates the picture
        /// 更新图片
        /// </summary>
        /// <param name="pictureId">The picture identifier</param>
        /// <param name="pictureBinary">The picture binary</param>
        /// <param name="mimeType">The picture MIME type</param>
        /// <param name="seoFilename">The SEO filename</param>
        /// <param name="altAttribute">"alt" attribute for "img" HTML element</param>
        /// <param name="titleAttribute">"title" attribute for "img" HTML element</param>
        /// <param name="isNew">A value indicating whether the picture is new</param>
        /// <param name="validateBinary">A value indicating whether to validated provided picture binary</param>
        /// <returns>Picture</returns>
        Picture UpdatePicture(int pictureId, byte[] pictureBinary, string mimeType,
            string seoFilename, string altAttribute = null, string titleAttribute = null,
            bool isNew = true, bool validateBinary = true);

        /// <summary>
        /// Updates the picture
        /// </summary>
        /// <param name="picture">The picture to update</param>
        /// <returns>Picture</returns>
        Picture UpdatePicture(Picture picture);

        /// <summary>
        /// Updates a SEO filename of a picture
        /// 更新图片的SEO文件名
        /// </summary>
        /// <param name="pictureId">The picture identifier</param>
        /// <param name="seoFilename">The SEO filename</param>
        /// <returns>Picture</returns>
        Picture SetSeoFilename(int pictureId, string seoFilename);

        /// <summary>
        /// Validates input picture dimensions
        /// 验证输入图片的尺寸
        /// </summary>
        /// <param name="pictureBinary">Picture binary</param>
        /// <param name="mimeType">MIME type</param>
        /// <returns>Picture binary or throws an exception</returns>
        byte[] ValidatePicture(byte[] pictureBinary, string mimeType);

        /// <summary>
        /// Gets or sets a value indicating whether the images should be stored in data base.
        /// 获取或设置一个值，该值指示是否应将图像存储在数据库中。
        /// </summary>
        bool StoreInDb { get; set; }

        /// <summary>
        /// Get pictures hashes
        /// 获取散列图片
        /// </summary>
        /// <param name="picturesIds">Pictures Ids</param>
        /// <returns></returns>
        IDictionary<int, string> GetPicturesHash(int[] picturesIds);

        /// <summary>
        /// Get product picture (for shopping cart and order details pages)
        /// 获取产品图片(用于购物车和订单详情页面)
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="attributesXml">Attributes (in XML format)</param>
        /// <returns>Picture</returns>
        Picture GetProductPicture(Product product, string attributesXml);
    }
}
