using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Media.RoxyFileman
{
    /// <summary>
    /// RoxyFileman service interface
    /// RoxyFileman服务接口
    /// </summary>
    public interface IRoxyFilemanService
    {
        #region Configuration

        /// <summary>
        /// Initial service configuration
        /// 初始服务配置
        /// </summary>
        void Configure();

        /// <summary>
        /// Gets a configuration file path
        /// 获取配置文件路径
        /// </summary>
        string GetConfigurationFilePath();

        #endregion

        #region Directories

        /// <summary>
        /// Copy the directory
        /// 复制目录
        /// </summary>
        /// <param name="sourcePath">Path to the source directory</param>
        /// <param name="destinationPath">Path to the destination directory</param>
        /// <returns>A task that represents the completion of the operation</returns>
        Task CopyDirectoryAsync(string sourcePath, string destinationPath);

        /// <summary>
        /// Create the new directory
        /// 创建新目录
        /// </summary>
        /// <param name="parentDirectoryPath">Path to the parent directory</param>
        /// <param name="name">Name of the new directory</param>
        /// <returns>A task that represents the completion of the operation</returns>
        Task CreateDirectoryAsync(string parentDirectoryPath, string name);

        /// <summary>
        /// Delete the directory
        /// 删除目录
        /// </summary>
        /// <param name="path">Path to the directory</param>
        /// <returns>A task that represents the completion of the operation</returns>
        Task DeleteDirectoryAsync(string path);

        /// <summary>
        /// Download the directory from the server as a zip archive
        /// 从服务器下载该目录作为zip归档文件
        /// </summary>
        /// <param name="path">Path to the directory</param>
        /// <returns>A task that represents the completion of the operation</returns>
        Task DownloadDirectoryAsync(string path);

        /// <summary>
        /// Get all available directories as a directory tree
        /// 将所有可用的目录作为目录树
        /// </summary>
        /// <param name="type">Type of the file</param>
        /// <returns>A task that represents the completion of the operation</returns>
        Task GetDirectoriesAsync(string type);

        /// <summary>
        /// Move the directory
        /// 移动目录
        /// </summary>
        /// <param name="sourcePath">Path to the source directory</param>
        /// <param name="destinationPath">Path to the destination directory</param>
        /// <returns>A task that represents the completion of the operation</returns>
        Task MoveDirectoryAsync(string sourcePath, string destinationPath);

        /// <summary>
        /// Rename the directory
        /// 重命名目录
        /// </summary>
        /// <param name="sourcePath">Path to the source directory</param>
        /// <param name="newName">New name of the directory</param>
        /// <returns>A task that represents the completion of the operation</returns>
        Task RenameDirectoryAsync(string sourcePath, string newName);

        #endregion

        #region Files

        /// <summary>
        /// Copy the file
        /// 复制文件
        /// </summary>
        /// <param name="sourcePath">Path to the source file</param>
        /// <param name="destinationPath">Path to the destination file</param>
        /// <returns>A task that represents the completion of the operation</returns>
        Task CopyFileAsync(string sourcePath, string destinationPath);

        /// <summary>
        /// Delete the file
        /// 删除该文件
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <returns>A task that represents the completion of the operation</returns>
        Task DeleteFileAsync(string path);

        /// <summary>
        /// Download the file from the server
        /// 从服务器下载文件
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <returns>A task that represents the completion of the operation</returns>
        Task DownloadFileAsync(string path);

        /// <summary>
        /// Get files in the passed directory
        /// 获取传递目录中的文件
        /// </summary>
        /// <param name="directoryPath">Path to the files directory</param>
        /// <param name="type">Type of the files</param>
        /// <returns>A task that represents the completion of the operation</returns>
        Task GetFilesAsync(string directoryPath, string type);

        /// <summary>
        /// Move the file
        /// 移动文件
        /// </summary>
        /// <param name="sourcePath">Path to the source file</param>
        /// <param name="destinationPath">Path to the destination file</param>
        /// <returns>A task that represents the completion of the operation</returns>
        Task MoveFileAsync(string sourcePath, string destinationPath);

        /// <summary>
        /// Rename the file
        /// 重命名文件
        /// </summary>
        /// <param name="sourcePath">Path to the source file</param>
        /// <param name="newName">New name of the file</param>
        /// <returns>A task that represents the completion of the operation</returns>
        Task RenameFileAsync(string sourcePath, string newName);

        /// <summary>
        /// Upload files to a directory on passed path
        /// 将文件上载到传递路径上的目录
        /// </summary>
        /// <param name="directoryPath">Path to directory to upload files</param>
        /// <returns>A task that represents the completion of the operation</returns>
        Task UploadFilesAsync(string directoryPath);

        #endregion

        #region Images

        /// <summary>
        /// Create the thumbnail of the image and write it to the response
        /// 创建图像的缩略图并将其写入响应
        /// </summary>
        /// <param name="path">Path to the image</param>
        void CreateImageThumbnail(string path);

        /// <summary>
        /// Flush all images on disk
        /// 刷新磁盘上的所有图像
        /// </summary>
        /// <param name="removeOriginal">Specifies whether to delete original images</param>
        void FlushAllImagesOnDisk(bool removeOriginal = true);

        /// <summary>
        /// Flush images on disk
        /// 刷新磁盘上的图像
        /// </summary>
        /// <param name="directoryPath">Directory path to flush images</param>
        void FlushImagesOnDisk(string directoryPath);

        #endregion

        #region Others

        /// <summary>
        /// Get the string to write an error response
        /// 获取要编写错误响应的字符串
        /// </summary>
        /// <param name="message">Additional message</param>
        /// <returns>String to write to the response</returns>
        string GetErrorResponse(string message = null);

        /// <summary>
        /// Get the language resource value
        /// 获取语言资源值
        /// </summary>
        /// <param name="key">Language resource key</param>
        /// <returns>Language resource value</returns>
        string GetLanguageResource(string key);

        /// <summary>
        /// Whether the request is made with ajax 
        /// 请求是否使用ajax发出
        /// </summary>
        /// <returns>True or false</returns>
        bool IsAjaxRequest();

        #endregion
    }
}
