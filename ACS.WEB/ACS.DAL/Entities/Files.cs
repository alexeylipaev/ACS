using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ACS.DAL.Entities
{
    public class Files : Entity
    {

        /// <summary>
        /// Имя файла
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Формат
        /// </summary>
        public string Extension { get; set; }

        private string _path;

        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;

                if (string.IsNullOrEmpty(DataString))
                    DataString = DateTime.Now.ToString("ddMMyyyyhhmmssfff");

            }
        }

        /// <summary>
        /// Дата добавления файла (уникальный параметр)
        /// </summary>
        public string DataString { get; private set; }


        public virtual ICollection<Chancellery> Chancelleries { get; set; }
    }
}
