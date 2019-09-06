using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace Nop.Core.Infrastructure
{
    /// <summary>
    /// A file provider abstraction
    /// 文件提供程序抽象
    /// </summary>
    public interface INopFileProvider : IFileProvider
    {
        /// <summary>
        /// Combines an array of strings into a path
        /// 将字符串数组组合到路径中
        /// </summary>
        /// <param name="paths">An array of parts of the path</param>
        /// <returns>The combined paths</returns>
        string Combine(params string[] paths);

        /// <summary>
        /// Creates all directories and subdirectories in the specified path unless they already exist
        /// 创建指定路径中的所有目录和子目录，除非它们已经存在
        /// </summary>
        /// <param name="path">The directory to create</param>
        void CreateDirectory(string path);

        /// <summary>
        /// Creates or overwrites a file in the specified path
        /// 创建或覆盖指定路径中的文件
        /// </summary>
        /// <param name="path">The path and name of the file to create</param>
        void CreateFile(string path);

        /// <summary>
        /// Depth-first recursive delete, with handling for descendant directories open in Windows Explorer.
        /// 深度优先递归删除，在Windows资源管理器中打开对后代目录的处理。
        /// </summary>
        /// <param name="path">Directory path</param>
        void DeleteDirectory(string path);

        /// <summary>
        /// Deletes the specified file
        /// 删除指定的文件
        /// </summary>
        /// <param name="filePath">The name of the file to be deleted. Wildcard characters are not supported</param>
        void DeleteFile(string filePath);

        /// <summary>
        /// Determines whether the given path refers to an existing directory on disk
        /// 确定给定路径是否引用磁盘上的现有目录
        /// </summary>
        /// <param name="path">The path to test</param>
        /// <returns>
        /// true if path refers to an existing directory; false if the directory does not exist or an error occurs when
        /// trying to determine if the specified file exists
        /// </returns>
        bool DirectoryExists(string path);

        /// <summary>
        /// Moves a file or a directory and its contents to a new location
        /// 将文件或目录及其内容移动到新位置
        /// </summary>
        /// <param name="sourceDirName">The path of the file or directory to move</param>
        /// <param name="destDirName">
        /// The path to the new location for sourceDirName. If sourceDirName is a file, then destDirName
        /// must also be a file name
        /// </param>
        void DirectoryMove(string sourceDirName, string destDirName);

        /// <summary>
        /// Returns an enumerable collection of file names that match a search pattern in
        /// a specified path, and optionally searches subdirectories.
        /// 返回匹配搜索模式的可枚举文件名集合
        ///指定路径，并可选择搜索子目录。
        /// </summary>
        /// <param name="directoryPath">The path to the directory to search</param>
        /// <param name="searchPattern">
        /// The search string to match against the names of files in path. This parameter
        /// can contain a combination of valid literal path and wildcard (* and ?) characters
        /// , but doesn't support regular expressions.
        /// </param>
        /// <param name="topDirectoryOnly">
        /// Specifies whether to search the current directory, or the current directory and all
        /// subdirectories
        /// </param>
        /// <returns>
        /// An enumerable collection of the full names (including paths) for the files in
        /// the directory specified by path and that match the specified search pattern
        /// </returns>
        IEnumerable<string> EnumerateFiles(string directoryPath, string searchPattern, bool topDirectoryOnly = true);

        /// <summary>
        /// Copies an existing file to a new file. Overwriting a file of the same name is allowed
        /// 将现有文件复制到新文件。允许覆盖同名文件
        /// </summary>
        /// <param name="sourceFileName">The file to copy</param>
        /// <param name="destFileName">The name of the destination file. This cannot be a directory</param>
        /// <param name="overwrite">true if the destination file can be overwritten; otherwise, false</param>
        void FileCopy(string sourceFileName, string destFileName, bool overwrite = false);

        /// <summary>
        /// Determines whether the specified file exists
        /// 确定指定文件是否存在
        /// </summary>
        /// <param name="filePath">The file to check</param>
        /// <returns>
        /// True if the caller has the required permissions and path contains the name of an existing file; otherwise,
        /// false.
        /// </returns>
        bool FileExists(string filePath);

        /// <summary>
        /// Gets the length of the file in bytes, or -1 for a directory or non-existing files
        /// 获取文件的长度(以字节为单位)，对于目录或不存在的文件，获取-1
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>The length of the file</returns>
        long FileLength(string path);

        /// <summary>
        /// Moves a specified file to a new location, providing the option to specify a new file name
        /// 将指定的文件移动到新位置，提供指定新文件名的选项
        /// </summary>
        /// <param name="sourceFileName">The name of the file to move. Can include a relative or absolute path</param>
        /// <param name="destFileName">The new path and name for the file</param>
        void FileMove(string sourceFileName, string destFileName);

        /// <summary>
        /// Returns the absolute path to the directory
        /// 返回目录的绝对路径
        /// </summary>
        /// <param name="paths">An array of parts of the path</param>
        /// <returns>The absolute path to the directory</returns>
        string GetAbsolutePath(params string[] paths);

        /// <summary>
        /// Gets a System.Security.AccessControl.DirectorySecurity object that encapsulates the access control list (ACL) entries for a specified directory
        /// System.Security.AccessControl。对象，该对象封装指定目录的访问控制列表(ACL)项
        /// </summary>
        /// <param name="path">The path to a directory containing a System.Security.AccessControl.DirectorySecurity object that describes the file's access control list (ACL) information</param>
        /// <returns>An object that encapsulates the access control rules for the file described by the path parameter</returns>
        DirectorySecurity GetAccessControl(string path);

        /// <summary>
        /// Returns the creation date and time of the specified file or directory
        /// 返回指定文件或目录的创建日期和时间
        /// </summary>
        /// <param name="path">The file or directory for which to obtain creation date and time information</param>
        /// <returns>
        /// A System.DateTime structure set to the creation date and time for the specified file or directory. This value
        /// is expressed in local time
        /// </returns>
        DateTime GetCreationTime(string path);

        /// <summary>
        /// Returns the names of the subdirectories (including their paths) that match the
        /// specified search pattern in the specified directory
        /// 返回匹配的子目录的名称(包括它们的路径)
        ///指定目录中的指定搜索模式
        /// </summary>
        /// <param name="path">The path to the directory to search</param>
        /// <param name="searchPattern">
        /// The search string to match against the names of subdirectories in path. This
        /// parameter can contain a combination of valid literal and wildcard characters
        /// , but doesn't support regular expressions.
        /// </param>
        /// <param name="topDirectoryOnly">
        /// Specifies whether to search the current directory, or the current directory and all
        /// subdirectories
        /// </param>
        /// <returns>
        /// An array of the full names (including paths) of the subdirectories that match
        /// the specified criteria, or an empty array if no directories are found
        /// </returns>
        string[] GetDirectories(string path, string searchPattern = "", bool topDirectoryOnly = true);

        /// <summary>
        /// Returns the directory information for the specified path string
        /// 返回指定路径字符串的目录信息
        /// </summary>
        /// <param name="path">The path of a file or directory</param>
        /// <returns>
        /// Directory information for path, or null if path denotes a root directory or is null. Returns
        /// System.String.Empty if path does not contain directory information
        /// </returns>
        string GetDirectoryName(string path);

        /// <summary>
        /// Returns the directory name only for the specified path string
        /// 仅返回指定路径字符串的目录名
        /// </summary>
        /// <param name="path">The path of directory</param>
        /// <returns>The directory name</returns>
        string GetDirectoryNameOnly(string path);

        /// <summary>
        /// Returns the extension of the specified path string
        /// 返回指定路径字符串的扩展名
        /// </summary>
        /// <param name="filePath">The path string from which to get the extension</param>
        /// <returns>The extension of the specified path (including the period ".")</returns>
        string GetFileExtension(string filePath);

        /// <summary>
        /// Returns the file name and extension of the specified path string
        /// 返回指定路径字符串的文件名和扩展名
        /// </summary>
        /// <param name="path">The path string from which to obtain the file name and extension</param>
        /// <returns>The characters after the last directory character in path</returns>
        string GetFileName(string path);

        /// <summary>
        /// Returns the file name of the specified path string without the extension
        /// 返回不带扩展名的指定路径字符串的文件名
        /// </summary>
        /// <param name="filePath">The path of the file</param>
        /// <returns>The file name, minus the last period (.) and all characters following it</returns>
        string GetFileNameWithoutExtension(string filePath);

        /// <summary>
        /// Returns the names of files (including their paths) that match the specified search
        /// pattern in the specified directory, using a value to determine whether to search subdirectories.
        /// 返回与指定搜索匹配的文件名(包括它们的路径)模式，使用一个值确定是否搜索子目录。
        /// </summary>
        /// <param name="directoryPath">The path to the directory to search</param>
        /// <param name="searchPattern">
        /// The search string to match against the names of files in path. This parameter
        /// can contain a combination of valid literal path and wildcard (* and ?) characters
        /// , but doesn't support regular expressions.
        /// </param>
        /// <param name="topDirectoryOnly">
        /// Specifies whether to search the current directory, or the current directory and all
        /// subdirectories
        /// </param>
        /// <returns>
        /// An array of the full names (including paths) for the files in the specified directory
        /// that match the specified search pattern, or an empty array if no files are found.
        /// </returns>
        string[] GetFiles(string directoryPath, string searchPattern = "", bool topDirectoryOnly = true);

        /// <summary>
        /// Returns the date and time the specified file or directory was last accessed
        /// 返回最后访问指定文件或目录的日期和时间
        /// </summary>
        /// <param name="path">The file or directory for which to obtain access date and time information</param>
        /// <returns>A System.DateTime structure set to the date and time that the specified file</returns>
        DateTime GetLastAccessTime(string path);

        /// <summary>
        /// Returns the date and time the specified file or directory was last written to
        /// 返回最后写入指定文件或目录的日期和时间
        /// </summary>
        /// <param name="path">The file or directory for which to obtain write date and time information</param>
        /// <returns>
        /// A System.DateTime structure set to the date and time that the specified file or directory was last written to.
        /// This value is expressed in local time
        /// </returns>
        DateTime GetLastWriteTime(string path);

        /// <summary>
        /// Returns the date and time, in coordinated universal time (UTC), that the specified file or directory was last
        /// 在协调世界时(UTC)中返回指定文件或目录最后出现的日期和时间
        /// written to
        /// </summary>
        /// <param name="path">The file or directory for which to obtain write date and time information</param>
        /// <returns>
        /// A System.DateTime structure set to the date and time that the specified file or directory was last written to.
        /// This value is expressed in UTC time
        /// </returns>
        DateTime GetLastWriteTimeUtc(string path);

        /// <summary>
        /// Retrieves the parent directory of the specified path
        /// 检索指定路径的父目录
        /// </summary>
        /// <param name="directoryPath">The path for which to retrieve the parent directory</param>
        /// <returns>The parent directory, or null if path is the root directory, including the root of a UNC server or share name</returns>
        string GetParentDirectory(string directoryPath);

        /// <summary>
        /// Gets a virtual path from a physical disk path.
        /// 从物理磁盘路径获取虚拟路径。
        /// </summary>
        /// <param name="path">The physical disk path</param>
        /// <returns>The virtual path. E.g. "~/bin"</returns>
        string GetVirtualPath(string path);

        /// <summary>
        /// Checks if the path is directory
        /// 检查路径是否为目录
        /// </summary>
        /// <param name="path">Path for check</param>
        /// <returns>True, if the path is a directory, otherwise false</returns>
        bool IsDirectory(string path);

        /// <summary>
        /// Maps a virtual path to a physical disk path.
        /// 将虚拟路径映射到物理磁盘路径。
        /// </summary>
        /// <param name="path">The path to map. E.g. "~/bin"</param>
        /// <returns>The physical path. E.g. "c:\inetpub\wwwroot\bin"</returns>
        string MapPath(string path);

        /// <summary>
        /// Reads the contents of the file into a byte array
        /// 将文件的内容读入字节数组
        /// </summary>
        /// <param name="filePath">The file for reading</param>
        /// <returns>A byte array containing the contents of the file</returns>
        byte[] ReadAllBytes(string filePath);

        /// <summary>
        /// Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
        /// 打开一个文件，读取具有指定编码的文件的所有行，然后关闭该文件。
        /// </summary>
        /// <param name="path">The file to open for reading</param>
        /// <param name="encoding">The encoding applied to the contents of the file</param>
        /// <returns>A string containing all lines of the file</returns>
        string ReadAllText(string path, Encoding encoding);

        /// <summary>
        /// Sets the date and time, in coordinated universal time (UTC), that the specified file was last written to
        /// 设置最后写入指定文件的日期和时间，在协调世界时(UTC)中
        /// </summary>
        /// <param name="path">The file for which to set the date and time information</param>
        /// <param name="lastWriteTimeUtc">
        /// A System.DateTime containing the value to set for the last write date and time of path.
        /// This value is expressed in UTC time
        /// </param>
        void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);

        /// <summary>
        /// Writes the specified byte array to the file
        /// 将指定的字节数组写入文件
        /// </summary>
        /// <param name="filePath">The file to write to</param>
        /// <param name="bytes">The bytes to write to the file</param>
        void WriteAllBytes(string filePath, byte[] bytes);

        /// <summary>
        /// Creates a new file, writes the specified string to the file using the specified encoding,
        /// 创建一个新文件，使用指定的编码将指定的字符串写入文件，
        /// and then closes the file. If the target file already exists, it is overwritten.
        /// 然后关闭文件。如果目标文件已经存在，它将被覆盖。
        /// </summary>
        /// <param name="path">The file to write to</param>
        /// <param name="contents">The string to write to the file</param>
        /// <param name="encoding">The encoding to apply to the string</param>
        void WriteAllText(string path, string contents, Encoding encoding);
    }
}
