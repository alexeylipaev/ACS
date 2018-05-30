using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL
{
    static public class LastEdit<T> where T : class
    {
        static public void SetData(ref T entity, int EditorId)
        {
            var sysparam = (entity as Entities.SystemParameters);
            if (sysparam != null)
            {
                DateTime editDate = DateTime.Now;
                if (sysparam.s_AuthorId == 0)
                {
                    sysparam.s_AuthorId = EditorId;
                    sysparam.s_DateCreation = editDate;
                }
                sysparam.s_EditorId = EditorId;
                
                sysparam.s_EditDate = editDate;
            }

        }
        static public void SetData(ref IEnumerable<T> entities, int EditorId)
        {
            foreach (var Entity in entities)
            {
                var entity = Entity;
                SetData(ref entity, EditorId);
            }
        }
        static public void SetData(ref T[] entities, int EditorId)
        {
            foreach (var Entity in entities)
            {
                var entity = Entity;
                SetData(ref entity, EditorId);
            }
        }
    }
}