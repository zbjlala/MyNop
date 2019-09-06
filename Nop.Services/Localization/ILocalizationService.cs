using Nop.Core;
using Nop.Core.Configuration;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Security;
using Nop.Services.Plugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace Nop.Services.Localization
{
    /// <summary>
    /// Localization manager interface
    /// 本地化管理器接口
    /// </summary>
    public partial interface ILocalizationService
    {
        /// <summary>
        /// Deletes a locale string resource
        /// 删除区域设置字符串资源
        /// </summary>
        /// <param name="localeStringResource">Locale string resource</param>
        void DeleteLocaleStringResource(LocaleStringResource localeStringResource);

        /// <summary>
        /// Gets a locale string resource
        /// 获取区域设置字符串资源
        /// </summary>
        /// <param name="localeStringResourceId">Locale string resource identifier</param>
        /// <returns>Locale string resource</returns>
        LocaleStringResource GetLocaleStringResourceById(int localeStringResourceId);

        /// <summary>
        /// Gets a locale string resource
        /// 获取区域设置字符串资源
        /// </summary>
        /// <param name="resourceName">A string representing a resource name</param>
        /// <returns>Locale string resource</returns>
        LocaleStringResource GetLocaleStringResourceByName(string resourceName);

        /// <summary>
        /// Gets a locale string resource
        /// </summary>
        /// <param name="resourceName">A string representing a resource name</param>
        /// <param name="languageId">Language identifier</param>
        /// <param name="logIfNotFound">A value indicating whether to log error if locale string resource is not found</param>
        /// <returns>Locale string resource</returns>
        LocaleStringResource GetLocaleStringResourceByName(string resourceName, int languageId,
            bool logIfNotFound = true);

        /// <summary>
        /// Gets all locale string resources by language identifier
        /// 通过语言标识符获取所有区域设置字符串资源
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Locale string resources</returns>
        IList<LocaleStringResource> GetAllResources(int languageId);

        /// <summary>
        /// Inserts a locale string resource
        /// 插入区域设置字符串资源
        /// </summary>
        /// <param name="localeStringResource">Locale string resource</param>
        void InsertLocaleStringResource(LocaleStringResource localeStringResource);

        /// <summary>
        /// Updates the locale string resource
        /// 更新区域设置字符串资源
        /// </summary>
        /// <param name="localeStringResource">Locale string resource</param>
        void UpdateLocaleStringResource(LocaleStringResource localeStringResource);

        /// <summary>
        /// Gets all locale string resources by language identifier
        /// 通过语言标识符获取所有区域设置字符串资源
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <param name="loadPublicLocales">A value indicating whether to load data for the public store only (if "false", then for admin area only. If null, then load all locales. We use it for performance optimization of the site startup</param>
        /// <returns>Locale string resources</returns>
        Dictionary<string, KeyValuePair<int, string>> GetAllResourceValues(int languageId, bool? loadPublicLocales);

        /// <summary>
        /// Gets a resource string based on the specified ResourceKey property.
        /// 获取基于指定的ResourceKey属性的资源字符串
        /// </summary>
        /// <param name="resourceKey">A string representing a ResourceKey.</param>
        /// <returns>A string representing the requested resource string.</returns>
        string GetResource(string resourceKey);

        /// <summary>
        /// Gets a resource string based on the specified ResourceKey property.
        /// 获取基于指定的ResourceKey属性的资源字符串
        /// </summary>
        /// <param name="resourceKey">A string representing a ResourceKey.</param>
        /// <param name="languageId">Language identifier</param>
        /// <param name="logIfNotFound">A value indicating whether to log error if locale string resource is not found</param>
        /// <param name="defaultValue">Default value</param>
        /// <param name="returnEmptyIfNotFound">A value indicating whether an empty string will be returned if a resource is not found and default value is set to empty string</param>
        /// <returns>A string representing the requested resource string.</returns>
        string GetResource(string resourceKey, int languageId,
            bool logIfNotFound = true, string defaultValue = "", bool returnEmptyIfNotFound = false);

        /// <summary>
        /// Export language resources to XML
        /// 将语言资源导出到XML
        /// </summary>
        /// <param name="language">Language</param>
        /// <returns>Result in XML format</returns>
        string ExportResourcesToXml(Language language);

        /// <summary>
        /// Import language resources from XML file
        /// 从XML文件导入语言资源
        /// </summary>
        /// <param name="language">Language</param>
        /// <param name="xmlStreamReader">Stream reader of XML file</param>
        /// <param name="updateExistingResources">A value indicating whether to update existing resources</param>
        void ImportResourcesFromXml(Language language, StreamReader xmlStreamReader, bool updateExistingResources = true);

        /// <summary>
        /// Get localized property of an entity
        /// 获取实体的本地化属性
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <typeparam name="TPropType">Property type</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="keySelector">Key selector</param>
        /// <param name="languageId">Language identifier; pass null to use the current working language; pass 0 to get standard language value</param>
        /// <param name="returnDefaultValue">A value indicating whether to return default value (if localized is not found)</param>
        /// <param name="ensureTwoPublishedLanguages">A value indicating whether to ensure that we have at least two published languages; otherwise, load only default value</param>
        /// <returns>Localized property</returns>
        TPropType GetLocalized<TEntity, TPropType>(TEntity entity, Expression<Func<TEntity, TPropType>> keySelector,
            int? languageId = null, bool returnDefaultValue = true, bool ensureTwoPublishedLanguages = true)
            where TEntity : BaseEntity, ILocalizedEntity;

        /// <summary>
        /// Get localized property of setting
        /// 获取设置的本地化属性
        /// </summary>
        /// <typeparam name="TSettings">Settings type</typeparam>
        /// <param name="settings">Settings</param>
        /// <param name="keySelector">Key selector</param>
        /// <param name="languageId">Language identifier</param>
        /// <param name="storeId">Store identifier</param>
        /// <param name="returnDefaultValue">A value indicating whether to return default value (if localized is not found)</param>
        /// <param name="ensureTwoPublishedLanguages">A value indicating whether to ensure that we have at least two published languages; otherwise, load only default value</param>
        /// <returns>Localized property</returns>
        string GetLocalizedSetting<TSettings>(TSettings settings, Expression<Func<TSettings, string>> keySelector,
            int languageId, int storeId, bool returnDefaultValue = true, bool ensureTwoPublishedLanguages = true)
            where TSettings : ISettings, new();

        /// <summary>
        /// Save localized property of setting
        /// 保存设置的本地化属性
        /// </summary>
        /// <typeparam name="TSettings">Settings type</typeparam>
        /// <param name="settings">Settings</param>
        /// <param name="keySelector">Key selector</param>
        /// <param name="languageId">Language identifier</param>
        /// <param name="value">Localized value</param>
        /// <returns>Localized property</returns>
        void SaveLocalizedSetting<TSettings>(TSettings settings, Expression<Func<TSettings, string>> keySelector,
            int languageId, string value) where TSettings : ISettings, new();

        /// <summary>
        /// Get localized value of enum
        /// 获取枚举的本地化值
        /// </summary>
        /// <typeparam name="TEnum">Enum type</typeparam>
        /// <param name="enumValue">Enum value</param>
        /// <param name="languageId">Language identifier; pass null to use the current working language</param>
        /// <returns>Localized value</returns>
        string GetLocalizedEnum<TEnum>(TEnum enumValue, int? languageId = null) where TEnum : struct;

        /// <summary>
        /// Get localized value of enum
        /// 获取枚举的本地化值
        /// We don't have UI to manage permission localizable name. That's why we're using this method
        /// </summary>
        /// <param name="permissionRecord">Permission record</param>
        /// <param name="languageId">Language identifier; pass null to use the current working language</param>
        /// <returns>Localized value</returns>
        string GetLocalizedPermissionName(PermissionRecord permissionRecord, int? languageId = null);

        /// <summary>
        /// Save localized name of a permission
        /// 保存权限的本地化名称
        /// </summary>
        /// <param name="permissionRecord">Permission record</param>
        void SaveLocalizedPermissionName(PermissionRecord permissionRecord);

        /// <summary>
        /// Delete a localized name of a permission
        /// 删除权限的本地化名称
        /// </summary>
        /// <param name="permissionRecord">Permission record</param>
        void DeleteLocalizedPermissionName(PermissionRecord permissionRecord);

        /// <summary>
        /// Add a locale resource (if new) or update an existing one
        /// 添加语言环境资源(如果是新的)或更新现有的语言环境资源
        /// </summary>
        /// <param name="resourceName">Resource name</param>
        /// <param name="resourceValue">Resource value</param>
        /// <param name="languageCulture">Language culture code. If null or empty, then a resource will be added for all languages</param>
        void AddOrUpdatePluginLocaleResource(string resourceName, string resourceValue, string languageCulture = null);

        /// <summary>
        /// Delete a locale resource
        /// 删除区域设置资源
        /// </summary>
        /// <param name="resourceName">Resource name</param>
        void DeletePluginLocaleResource(string resourceName);

        /// <summary>
        /// Get localized friendly name of a plugin
        /// 获取插件的本地化友好名称
        /// </summary>
        /// <typeparam name="TPlugin">Plugin type</typeparam>
        /// <param name="plugin">Plugin</param>
        /// <param name="languageId">Language identifier</param>
        /// <param name="returnDefaultValue">A value indicating whether to return default value (if localized is not found)</param>
        /// <returns>Localized value</returns>
        string GetLocalizedFriendlyName<TPlugin>(TPlugin plugin, int languageId, bool returnDefaultValue = true)
            where TPlugin : IPlugin;

        /// <summary>
        /// Save localized friendly name of a plugin
        /// 保存插件的本地化友好名称
        /// </summary>
        /// <typeparam name="TPlugin">Plugin</typeparam>
        /// <param name="plugin">Plugin</param>
        /// <param name="languageId">Language identifier</param>
        /// <param name="localizedFriendlyName">Localized friendly name</param>
        void SaveLocalizedFriendlyName<TPlugin>(TPlugin plugin, int languageId, string localizedFriendlyName)
            where TPlugin : IPlugin;
    }
}
