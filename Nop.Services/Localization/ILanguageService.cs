using Nop.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Services.Localization
{
    /// <summary>
    /// Language service interface
    /// 语言服务接口
    /// </summary>
    public partial interface ILanguageService
    {
        /// <summary>
        /// Deletes a language
        /// 删除一个语言
        /// </summary>
        /// <param name="language">Language</param>
        void DeleteLanguage(Language language);

        /// <summary>
        /// Gets all languages
        /// 得到所有的语言
        /// </summary>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <param name="loadCacheableCopy">A value indicating whether to load a copy that could be cached (workaround until Entity Framework supports 2-level caching)</param>
        /// <returns>Languages</returns>
        IList<Language> GetAllLanguages(bool showHidden = false, int storeId = 0, bool loadCacheableCopy = true);

        /// <summary>
        /// Gets a language
        /// 得到一种语言
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <param name="loadCacheableCopy">A value indicating whether to load a copy that could be cached (workaround until Entity Framework supports 2-level caching)</param>
        /// <returns>Language</returns>
        Language GetLanguageById(int languageId, bool loadCacheableCopy = true);

        /// <summary>
        /// Inserts a language
        /// 插入一个语言
        /// </summary>
        /// <param name="language">Language</param>
        void InsertLanguage(Language language);

        /// <summary>
        /// Updates a language
        /// 更新的语言
        /// </summary>
        /// <param name="language">Language</param>
        void UpdateLanguage(Language language);

        /// <summary>
        /// Get 2 letter ISO language code
        /// </summary>
        /// <param name="language">Language</param>
        /// <returns>ISO language code</returns>
        string GetTwoLetterIsoLanguageName(Language language);
    }
}
