using System;
using System.Collections;
using System.Collections.Generic;

using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Gasanov.Utils.SaveUtilities
 {
    public static class SaveUtils
    {
        /// <summary>
        /// Расширение файла для сохраняемых данных
        /// </summary>
        private const string SaveExtension = ".txt";

        /// <summary>
        /// Папка сохраняемых данных. Оканчивается на "/"
        /// </summary>
        private static readonly string SaveFolder = Application.dataPath + "/Storage/";

        /// <summary>
        /// Возвращает прокси для файла со свойствами.
        /// При отсутствии файла создает новый, если createDefault == true.
        /// </summary>
        public static PropertyFileProxy GetProxy(string filePath, bool createDefault = true)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(SaveFolder + filePath + SaveExtension));
            
            if (File.Exists(SaveFolder + filePath + SaveExtension))
            {
                var fs = File.Open(SaveFolder + filePath + SaveExtension,
                    FileMode.Open, FileAccess.ReadWrite);
                
                return new PropertyFileProxy(fs);
            }

            if (createDefault)
            {
                var fs = new FileStream(SaveFolder+filePath+SaveExtension, FileMode.Create,
                    FileAccess.ReadWrite);
                
                return new PropertyFileProxy(fs);
            }
            
            throw new FileNotFoundException();
        }

    }
}




